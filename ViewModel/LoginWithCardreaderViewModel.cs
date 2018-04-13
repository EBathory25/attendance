using LastAndFinalVersion.Commands;
using LastAndFinalVersion.Model;
using LastAndFinalVersion.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace LastAndFinalVersion.ViewModel
{
    class LoginWithCardreaderViewModel : INotifyPropertyChanged
    {
        private bool checkDbProcess;
        public bool CheckDb
        {
            get { return checkDbProcess; }
            set
            {
                checkDbProcess = value;
                NotifyOnPropertyChange("CheckDb");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyOnPropertyChange(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }





        private static int pwd;
        int length = pwd.ToString().Length;
        public int PWD
        {
            get { return pwd; }
            set
            {
                if (pwd != value)
                {
                    pwd = value;
                    NotifyOnPropertyChange("PWD");
                   
                }
            }
        }
        private DelegateCommand buttonCommand;
        public DelegateCommand ButtonCommand
        {
            get { return buttonCommand; }
            set
            {
                buttonCommand = value;
                NotifyOnPropertyChange("ButtonCommand");
            }
        }
        public LoginWithCardreaderViewModel()
        {
            



        }
        public static string CreatePasswordHash(string plainpassword)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(plainpassword);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            return System.Text.Encoding.ASCII.GetString(data);
        }
        //public void SubmitButton()
        //{ while (pwd == 10)
        //    {

        //    }
        //    do
        //    {
        //        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\source\repos\VIAApp2Demo\VIAApp2Demo\DB\DatabaseStudents.mdf;Integrated Security=True;Connect Timeout=30");
        //        try
        //        {


        //            if (conn.State == System.Data.ConnectionState.Closed)
        //                conn.Open();
        //            String query = "SELECT COUNT (*) FROM Login WHERE pwd=@pwd";
        //            SqlCommand cmd = new SqlCommand(query, conn);
        //            cmd.CommandType = CommandType.Text;


        //            SqlParameter Pwd = cmd.Parameters.AddWithValue("@pwd", SqlDbType.Int);
        //            cmd.Parameters["@pwd"].Value = pwd;
        //            if (Pwd == null)
        //            {
        //                Pwd.Value = DBNull.Value;
        //            }
        //            SqlDataReader reader = cmd.ExecuteReader();


        //            int count = Convert.ToInt32(cmd.ExecuteScalar());
        //            if (count > 0)
        //            {


        //                MainWindow main = new MainWindow();
        //                main.Show();

        //            }
        //            else
        //            {
        //                MessageBox.Show("Username or password is incorrect!");

        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //        finally
        //        {
        //            conn.Close();
        //        }



        //    } while (pwd == 10);
        //}
        public static bool IsValidLogin(string password)
        {
            new Thread(() =>
           {
               try
               {
                   Thread.CurrentThread.IsBackground = true;
                   password = CreatePasswordHash(password);
                   using (DatabaseStudentsEntitiesLastStand db = new DatabaseStudentsEntitiesLastStand())
                   {


                       do
                       {

                           var query = (from u in db.RegisterTeachers where u.pwd.Equals(password) select u);

                       } while (password.Length == 10);
                       Thread.Sleep(500);
                       if (password.Length == 10 && password.Equals(pwd))
                       {
                           MessageBox.Show("Logged in succesfully,please wait...");
                           MainWindow mv = new MainWindow();
                           mv.Show();
                           mv.Hide();
                       }
                       else
                       {
                           MessageBox.Show("Error!Password is incorrect");
                       }
                   }


               }
               catch (Exception e)
               {
                   MessageBox.Show(e.Message);
               }

           });
        return true;
        }


           
           
        
    }
} 
                   
     
    


        
        
    



