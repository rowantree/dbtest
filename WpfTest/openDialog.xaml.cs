using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;

namespace WpfTest
{
	/// <summary>
	/// Interaction logic for openDialog.xaml
	/// </summary>
	public partial class openDialog : Window
	{
		public myDataContext dataContext = new myDataContext { };
		public openDialog()
		{
			InitializeComponent();
			Loaded += openDialog_Loaded;
		}

		void openDialog_Loaded(object sender, RoutedEventArgs e)
		{
			this.DataContext = dataContext;


			int row = 0;
			int column = 0;

			int fieldCnt = 40;
			int rowCnt = fieldCnt;
			int colCnt = 1;

			RowDefinition[] rows = new RowDefinition[rowCnt+1];
			ColumnDefinition[] columns = new ColumnDefinition[fieldCnt];


			for (int i = 0; i < rowCnt+1; ++i  )
			{
				rows[i] = new RowDefinition();
				dataGrid.RowDefinitions.Add(rows[i]);
				rows[i].Height = new GridLength();
			}

			for (int i = 0; i < colCnt; i+=2 )
			{
				dataGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(100) });
				dataGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(400) });
			}

			for (int i = 0; i < 40; ++i)
			{

				Label label = new Label() { Content = string.Format("Field {0}", i) };
				Grid.SetRow(label, row );
				Grid.SetColumn(label, column);
				dataGrid.Children.Add(label);

				//Binding binding = new Binding() {Path = new PropertyPath(layout.elements[i].Column), UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged};
				//binding.ValidatesOnDataErrors = true;
				//binding.NotifyOnValidationError = true;

				TextBox textBox = new TextBox();
				//textBox.SetBinding(TextBox.TextProperty, binding);

				Grid.SetRow(textBox, row );
				Grid.SetColumn(textBox, column+1);
				dataGrid.Children.Add(textBox);

				++row;
			}



		}

		private void btnClick(object sender, RoutedEventArgs e)
		{
			dataContext.ShowValidationErrors = dataContext.ShowValidationErrors == System.Windows.Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
		}
	}

	public class myDataContext : INotifyPropertyChanged 
	{
		private System.Windows.Visibility _ShowValidationErrors;
		public System.Windows.Visibility ShowValidationErrors
		{
			get
			{
				return _ShowValidationErrors;
			}
			set
			{
				_ShowValidationErrors = value;
				NotifyPropertyChanged("ShowValidationErrors");
			}
		}

		public myDataContext()
		{
			ShowValidationErrors = Visibility.Hidden;
		}

		public event PropertyChangedEventHandler PropertyChanged;
		protected void NotifyPropertyChanged(string propName)
		{
			//log.Debug("Notify Property Changed " + propName);
			if (this.PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propName));
		}
	}
}
