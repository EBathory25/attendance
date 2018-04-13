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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LastAndFinalVersion.View
{
    /// <summary>
    /// Interaction logic for AttendanceListStudents.xaml
    /// </summary>
    public partial class AttendanceListStudents : UserControl
    {
        object param=new object() ;
        AttendanceListViewModel attendance;
        public AttendanceListStudents()
        {
            InitializeComponent();
            attendance = new AttendanceListViewModel();
            this.DataContext = attendance;
          //  SearchStudent=attendance.Filter();
            

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.SNtextbox.Focus();
            SNtextbox.Focusable = true;
            Keyboard.Focus(SNtextbox);
        }
    }
}
