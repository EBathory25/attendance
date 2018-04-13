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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LastAndFinalVersion.View
{
    /// <summary>
    /// Interaction logic for RegisterStudent.xaml
    /// </summary>
    public partial class RegisterStudent : UserControl
    {
       
        public RegisterStudent()
        {
            
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
           FontSize = 16;
            Content= "C:\\Users\\User\\Documents\\AttendanceProjectFiles\register.png";
           Background = Brushes.Black;
        }
    }
}
