using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.ObjectModel;

namespace dbtest
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		//private SqlConnection sqlConn = null;
		//private SqlDataAdapter dataAdapter = null;
		//private DataSet dataSet = null;
		//private DataTable dataTable = null;


		private IDW3Entities1 entities = null;


		public MainWindow()
		{
			InitializeComponent();
			this.Loaded += MainWindow_Loaded;
		}

		private ObservableCollection<Model.mCMGPerson> personList = null;

		void MainWindow_Loaded(object sender, RoutedEventArgs e)
		{
			try
			{
				XmlTest.Run();

				entities = new IDW3Entities1();

				/*
				Model.mCMGPerson mPerson = new Model.mCMGPerson( entities.CMGPersons.First(x => x.CMGPersonID == 1));
				mPerson.FirstName = "NewName";
				entities.SaveChanges();
				*/

				personList = new ObservableCollection<Model.mCMGPerson>();
				foreach (CMGPerson person in entities.CMGPersons)
				{
					personList.Add(new Model.mCMGPerson(person));
				}
				cMGPersonDataGrid.ItemsSource = personList;




				//dataEntry.DataContext = new Model.mCMGPerson() { FirstName = "First", LastName = "Last", CMGPersonID=23 };
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message, "Exception");
			}


		
		}

		private void btnLoad_Click(object sender, RoutedEventArgs e)
		{

		}

		private void saveButton_Click(object sender, RoutedEventArgs e)
		{
			ObservableCollection<Model.mCMGPerson> personList = (ObservableCollection<Model.mCMGPerson>)cMGPersonDataGrid.ItemsSource;
			foreach (Model.mCMGPerson person in personList) 
			{
				if (person.IsChanged)
				{
					MessageBox.Show(person.FirstName);
				}
			}
			entities.SaveChanges();
		}

		private void cMGPersonDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			Model.mCMGPerson person = cMGPersonDataGrid.SelectedItem as Model.mCMGPerson;
			if (person != null)
			{
				dlgCMGPerson dialog = new dlgCMGPerson(person);
				bool? result = dialog.ShowDialog();
				if (result.HasValue && result.Value)
				{
					entities.SaveChanges();
				}
				else
				{
					entities.Entry(person.m_Person).Reload();
				}
				person.AllChanged();
			}
		}

		private void btnAdd_Click(object sender, RoutedEventArgs e)
		{
			Model.mCMGPerson person = new Model.mCMGPerson(new CMGPerson());
			person.RecordCreatedUser = "Me";
			person.RecordCreatedDate = DateTime.Now;
			dlgCMGPerson dialog = new dlgCMGPerson(person);
			bool? result = dialog.ShowDialog();
			if (result.HasValue && result.Value)
			{
				entities.CMGPersons.Add(person.m_Person);
				try
				{
					entities.SaveChanges();
					personList.Add(person);
					person.AllChanged();
				}
				catch (Exception exc)
				{
					MessageBox.Show(exc.Message, "Exception");
				}
			}
			else
			{
			}
		}
	}
}
