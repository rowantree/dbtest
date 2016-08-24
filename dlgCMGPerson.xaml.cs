﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace dbtest
{
	/// <summary>
	/// Interaction logic for dlgCMGPerson.xaml
	/// </summary>
	public partial class dlgCMGPerson : Window
	{
		public dlgCMGPerson(Model.mCMGPerson person)
		{
			DataContext = person;
			InitializeComponent();
		}

		private void btnSave_Click(object sender, RoutedEventArgs e)
		{
			this.DialogResult = true;

		}

		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			this.DialogResult = false;
		}
	}
}
