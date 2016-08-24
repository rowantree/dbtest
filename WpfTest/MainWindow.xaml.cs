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
using System.ComponentModel;

namespace WpfTest
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public DataContext dataContext = null;

		public MainWindow()
		{
			InitializeComponent();
			this.Loaded += MainWindow_Loaded;
		}

		void MainWindow_Loaded(object sender, RoutedEventArgs e)
		{
			dataContext = new DataContext() { FontSize=13, DecimalValue = 123.45M, DecimalValueUpDown = 123.45M, HomePhone = "207-555-1212", SSN="123456789" };
			this.DataContext = dataContext;

			/*
			TextBox tb = new TextBox() { MinWidth = 50 };
			Binding binding = new Binding("OtherValue") { NotifyOnValidationError = true, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged };
			tb.SetBinding(TextBox.TextProperty, binding);
			stackPanel.Children.Add(tb);
			*/
		}

		private void BtnFontSizeUp(object sender, RoutedEventArgs e)
		{
			++dataContext.FontSize;
		}
		private void BtnFontSizeDown(object sender, RoutedEventArgs e)
		{
			--dataContext.FontSize;
		}

		private void btnClear_Click(object sender, RoutedEventArgs e)
		{
			dataContext.SSN = String.Empty;
			dataContext.HomePhone = String.Empty;
			dataContext.DecimalValue = 0;
			dataContext.DecimalValueUpDown = 0;
		}

		private void btnOpen_Click(object sender, RoutedEventArgs e)
		{
			openDialog dialog = new openDialog();
			dialog.ShowDialog();
		}

		private void btnClick(object sender, RoutedEventArgs e)
		{
		}
	}

	public class DataContext : INotifyDataErrorInfo, INotifyPropertyChanged
	{
		public decimal OtherValue { get; set; }
		public string Msg { get; set; }

		private string _HomePhone;
		public string HomePhone
		{
			get
			{
				return _HomePhone;
			}
			set
			{
				if (_HomePhone != value)
				{
					_HomePhone = value;
					NotifyPropertyChanged("HomePhone");
				}
			}
		}

		private string _SSN;
		public string SSN
		{
			get
			{
				return _SSN;
			}
			set
			{
				if (_SSN != value)
				{
					_SSN = value;
					NotifyPropertyChanged("SSN");
				}
			}
		}

		private double _FontSize;
		public double FontSize
		{
			get
			{
				return _FontSize;
			}
			set
			{
				if (_FontSize != value)
				{
					_FontSize = value;
					NotifyPropertyChanged("FontSize");
				}
			}
		}

		private decimal _DecimalValue;
		public decimal DecimalValue
		{
			get
			{
				return _DecimalValue;
			}
			set
			{
				if (_DecimalValue != value)
				{
					_DecimalValue = value;
					NotifyPropertyChanged("DecimalValue");
				}
			}
		}

		private decimal _DecimalValueUpDown;
		public decimal DecimalValueUpDown
		{
			get
			{
				return _DecimalValueUpDown;
			}
			set
			{
				if (_DecimalValueUpDown != value)
				{
					_DecimalValueUpDown = value;
					NotifyPropertyChanged("DecimalValueUpDown");
				}
			}
		}

		public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

		public System.Collections.IEnumerable GetErrors(string propertyName)
		{
			return null;
		}

		public bool HasErrors
		{
			get { return false; }
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected void NotifyPropertyChanged(string propName)
		{
			if (this.PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propName));
		}
	}
}
