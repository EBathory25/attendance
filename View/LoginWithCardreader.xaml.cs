using LastAndFinalVersion.ViewModel;
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

namespace LastAndFinalVersion.View
{
    /// <summary>
    /// Interaction logic for LoginWithCardreader.xaml
    /// </summary>
    public partial class LoginWithCardreader : Window
    {
        LoginWithCardreaderViewModel vm = new LoginWithCardreaderViewModel();
        public LoginWithCardreader()
        {
            InitializeComponent();
            
            this.DataContext = vm;
          
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            string pwd = passwordBox.Password;
         
          
           
        }
       
    }
}
