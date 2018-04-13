using LastAndFinalVersion.Commands;
using LastAndFinalVersion.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace LastAndFinalVersion.ViewModel
{
    class AttendanceListViewModel : INotifyPropertyChanged
    {
        private DelegateCommand btnCommand;
        public DelegateCommand BtnCommand
        {
            get { return btnCommand; }
            set
            {
                if (btnCommand != value)
                {
                    btnCommand = value;
                    NotifyPropertyChanged("BtnCommand");
                }
            }
        }
        private int SerialN;
        public int SNr
        {
            get { return SerialN; }
            set
            {
                if (SerialN != value)
                {
                    SerialN = value;
                    NotifyPropertyChanged("SNr");
                    
                }
            }
        }
        private int studentNr;
        public int StudentNR
        {
            get { return studentNr; }
            set
            {
                if (studentNr != value)
                {
                    studentNr = value;
                    NotifyPropertyChanged("StudentNR");
                }
            }
        }
        private String firstName;
        public String FName
        {
            get { return firstName; }
            set
            {
                if (firstName != value)
                {
                    firstName = value;
                    NotifyPropertyChanged("FName");
                }

            }
        }
        private String lastName;
        public String LName
        {
            get { return lastName; }
            set
            {
                if (lastName != value)
                {
                    lastName = value;
                    NotifyPropertyChanged("LName");
                }
            }
        }
        public String FullName
        {
            get
            {
                return string.Format("{0} {1}", FName, LName);
            }
        }
        private DateTime dateT = DateTime.Now;
        public DateTime StartDate
        {
            get { return dateT; }
            set
            {
                dateT = value;
                NotifyPropertyChanged("StartDate");
            }
        }
        private DateTime departure = DateTime.Now;
        public DateTime DepartureTime
        {
            get { return departure; }
            set
            {
                departure = value;
                NotifyPropertyChanged("DepartureTime");
            }
        }
        private int hoursSpent;
        public int HoursSpent
        {
            get { return dateT.Hour - departure.Hour; }
        }
        private ObservableCollection<AttendanceList> list;
        public ObservableCollection<AttendanceList> Items
        {
            get
            {
                return list;

            }
            set
            {
                list = value;
                NotifyPropertyChanged("Items");
            }
        }

        private int txtBox;
        public int TextBoxSerialNr
        {
            get { return txtBox; }
            set
            {
                if(txtBox!=value)
                {
                    txtBox = value;
                    NotifyPropertyChanged("TextBoxSerialNr");
                    
                }
            }
        }
        private string filterString;
        public string FilterString
        {
            get { return filterString; }
            set
            {
                if(filterString!=value)
                {
                    filterString = value;
                    NotifyPropertyChanged("FilterString");
                   Filter();
                }
            }
        }



        private async void AccessData()
        {
            await Task.Factory.StartNew(() =>
            {
                foreach (var item in Items)
                {
                    if (txtBox == SerialN)
                    {
                        using (DatabaseStudentsEntitiesLastStand db = new DatabaseStudentsEntitiesLastStand())
                        {
                           var students = (from d in db.RegisterStudents
                                            select new { SerialN = d.SN, firstName = d.fName, lastName = d.lName, studentNr = d.sNr }).ToList();

                          
                        };

                    }
                 
                }
                return new List<AttendanceList>();
            });


        }

      
        public void Filter()
        {
            object param = new object();
            var data = param as AttendanceList;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(filterString))
                {
                    param=data.fName.Contains(filterString) || data.lName.Contains(filterString);
                }
                param.ToString();
            }
        }
      
     
        public AttendanceListViewModel()
        {
            BtnCommand = new DelegateCommand(AttendanceList);
            
            
    }

      
        public void AttendanceList(object param)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\source\repos\VIAApp2Demo\VIAApp2Demo\DB\DatabaseStudents.mdf;Integrated Security=True;Connect Timeout=30");
                conn.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand("SELECT SNr,SN,fName,lNAme,dateTime from AttendanceList ", conn);
                adapter.Fill(dt);
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        ObservableCollection<AttendanceList> _students;
        public ObservableCollection<AttendanceList> Students
        {
            get
            {
                return _students;
            }
            set
            {
                _students = value;
            }
        }
       
       
       
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
