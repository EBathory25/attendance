using LastAndFinalVersion.Helpers;
using LastAndFinalVersion.ViewModel;
using System.Security;
using System.Windows;
using System.Windows.Controls;

namespace LastAndFinalVersion.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login :Window
    {
       private LoginViewModel lg;
        public Login()
        {
            InitializeComponent();
            lg = new LoginViewModel();
            this.DataContext = lg;
         
        }

      
       
       

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Register reg = new Register();
            reg.Show();
            this.Close();
        }

        private void Hyperlink_Click_1(object sender, RoutedEventArgs e)
        {
            LoginWithCardreader cr = new LoginWithCardreader();
            cr.Show();
            this.Close();
        }
    }
}
