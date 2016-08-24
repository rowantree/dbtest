using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace dbtest.Model
{
	public class mCMGPerson : INotifyPropertyChanged, IDataErrorInfo
	{
		private mCMGPerson()
		{
		}


		public dbtest.CMGPerson m_Person = null;

		public bool IsChanged { get; set; }

		public mCMGPerson(dbtest.CMGPerson person) : this()
		{
			m_Person = person;
		}

		public void AllChanged()
		{
			NotifyPropertyChanged(string.Empty);
		}


		public string ClassName
		{
			get
			{
				return "mCMGPerson";
			}
		}

		public int CMGPersonID
		{
			get { return m_Person.CMGPersonID; }
			set
			{
				if (value != m_Person.CMGPersonID)
				{
					m_Person.CMGPersonID = value;
					NotifyPropertyChanged("CMGPersonID");
				}
			}
		}
		public string FirstName
		{
			get { return m_Person.FirstName; }
			set
			{
				if (value != m_Person.FirstName)
				{
					m_Person.FirstName = value;
					NotifyPropertyChanged("FirstName");
				}
			}
		}
		public string LastName
		{
			get { return m_Person.LastName; }
			set
			{
				if (value != m_Person.LastName)
				{
					m_Person.LastName = value;
					NotifyPropertyChanged("LastName");
				}
			}
		}
		public string ADAccount
		{
			get { return m_Person.ADAccount; }
			set
			{
				if (value != m_Person.ADAccount)
				{
					m_Person.ADAccount = value;
					NotifyPropertyChanged("ADAccount");
				}
			}
		}
		public string MobilePhone
		{
			get { return m_Person.MobilePhone; }
			set
			{
				if (value != m_Person.MobilePhone)
				{
					m_Person.MobilePhone = value;
					NotifyPropertyChanged("MobilePhone");
				}
			}
		}
		public string HomePhone
		{
			get { return m_Person.HomePhone; }
			set
			{
				if (value != m_Person.HomePhone)
				{
					m_Person.HomePhone = value;
					NotifyPropertyChanged("HomePhone");
				}
			}
		}
		public string HomePhone2
		{
			get { return m_Person.HomePhone2; }
			set
			{
				if (value != m_Person.HomePhone2)
				{
					m_Person.HomePhone2 = value;
					NotifyPropertyChanged("HomePhone2");
				}
			}
		}
		public string WorkPhone
		{
			get { return m_Person.WorkPhone; }
			set
			{
				if (value != m_Person.WorkPhone)
				{
					m_Person.WorkPhone = value;
					NotifyPropertyChanged("WorkPhone");
				}
			}
		}
		public byte[] RecordTimestamp
		{
			get { return m_Person.RecordTimestamp; }
			set
			{
				if (value != m_Person.RecordTimestamp)
				{
					m_Person.RecordTimestamp = value;
					NotifyPropertyChanged("RecordTimestamp");
				}
			}
		}
		public Nullable<System.DateTime> RecordLastModifiedDate
		{
			get { return m_Person.RecordLastModifiedDate; }
			set
			{
				if (value != m_Person.RecordLastModifiedDate)
				{
					m_Person.RecordLastModifiedDate = value;
					NotifyPropertyChanged("RecordLastModifiedDate");
				}
			}
		}
		public string RecordLastModifiedUser
		{
			get { return m_Person.RecordLastModifiedUser; }
			set
			{
				if (value != m_Person.RecordLastModifiedUser)
				{
					m_Person.RecordLastModifiedUser = value;
					NotifyPropertyChanged("RecordLastModifiedUser");
				}
			}
		}
		public System.DateTime RecordCreatedDate
		{
			get { return m_Person.RecordCreatedDate; }
			set
			{
				if (value != m_Person.RecordCreatedDate)
				{
					m_Person.RecordCreatedDate = value;
					NotifyPropertyChanged("RecordCreatedDate");
				}
			}
		}
		public string RecordCreatedUser
		{
			get { return m_Person.RecordCreatedUser; }
			set
			{
				if (value != m_Person.RecordCreatedUser)
				{
					m_Person.RecordCreatedUser = value;
					NotifyPropertyChanged("RecordCreatedUser");
				}
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		protected void NotifyPropertyChanged(string propName)
		{
			IsChanged = true;
			if (this.PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propName));
		}


		public string Error
		{
			get { return string.Empty; }
		}

		public string this[string columnName]
		{
			get
			{
				string errorMsg = string.Empty;
				switch (columnName)
				{
					case "FirstName":
						if (m_Person.FirstName != "abc") errorMsg = m_Person.FirstName + " is not equal to 'abc'";
						break;
				}
				return errorMsg;
			}
		}
	}
}