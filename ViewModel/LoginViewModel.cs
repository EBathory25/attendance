using LastAndFinalVersion.Commands;
using LastAndFinalVersion.Helpers;
using LastAndFinalVersion.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace LastAndFinalVersion.ViewModel
{
    class LoginViewModel : ViewModelBase
    {

        private DelegateCommand loginCommand;

     //   private Login CurrentUser { get; set; }

        //private Login _userName;
        //private Login _pwd;

        public event PropertyChangedEventHandler OnPropertyChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        public string TestUserName { get; set; }
        public string TestPassword { get; set; }

      ////  public Login UserName
      //  {
      //      get { return _userName; }
      //      set
      //      {
      //          _userName.UserName = value.UserName;
      //          NotifyPropertyChanged("UserName");
      //      }


      //  }


        //public Login pwd
        //{
        //    get { return _pwd; }
        //    set
        //    {
        //        if (_pwd != value)
        //        {
        //            _pwd = value;
        //            NotifyPropertyChanged("PWD");
        //        }
        //    }
        //}


        public LoginViewModel() 
        {
            ButtonCommand = new DelegateCommand(SubmitButton);
           


        }
        public DelegateCommand ButtonCommand
        {
            get { return loginCommand; }
            set
            {
                if (loginCommand != value)
                    loginCommand = value;
                NotifyPropertyChanged("ButtonCommand");
            }
        }

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (OnPropertyChanged != null)
            {
                OnPropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private bool _isFocused = false;
        public bool IsTextBoxFocused
        {
            get
            {
                return _isFocused;
            }
            set
            {
                if (_isFocused == value)
                {
                    _isFocused = false;
                    NotifyPropertyChanged("IsTextBoxFocused");
                }
                _isFocused = value;
                NotifyPropertyChanged("IsTextBoxFocused");
            }
        }
        private String classID;
        public string ClassID
        {
            get { return classID; }
            set
            {
                if(classID!=value)
                {
                    classID =value;
                    NotifyPropertyChanged("ClassID");
                }
            }
        }

        public void SubmitButton(object param)
        {

            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\source\repos\VIAApp2Demo\VIAApp2Demo\DB\DatabaseStudents.mdf;Integrated Security=True;Connect Timeout=30");
            try
            {
                var _UserName = TestUserName;

                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
                String query = "SELECT COUNT (*) FROM Login WHERE UserName=@UserName AND pwd=@pwd";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.Text;

                //_UserName = new Logi
                SqlParameter Username = cmd.Parameters.AddWithValue("@UserName", SqlDbType.NVarChar);

                cmd.Parameters["@UserName"].Value = _UserName;
                if (Username.Value == null)
                {
                    Username.Value = DBNull.Value;
                }
                SqlParameter Pwd = cmd.Parameters.AddWithValue("@pwd", SqlDbType.Int);
                //cmd.Parameters["@pwd"].Value = _pwd.pwd;
                cmd.Parameters["@pwd"].Value = TestPassword;
                if (Pwd.Value == null)
                {
                    Pwd.Value = DBNull.Value;
                }

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0)

                {
                    SqlParameter boxtext = cmd.Parameters.AddWithValue("@ClassID", SqlDbType.NVarChar);

                    cmd.Parameters["@ClassID"].Value = classID;
                    if (classID == null)
                    {
                       classID = "";
                    }
                  
                    MainWindow main = new MainWindow();
                    main.Show();
                   
                }
                else
                {
                    MessageBox.Show("Username or password is incorrect!");
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}


