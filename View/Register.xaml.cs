using LastAndFinalVersion.Model;
using LastAndFinalVersion.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        RegisterTeacherViewModel regTeacher;
        Object obj = new object();
        public Register()
        {
            InitializeComponent();
            regTeacher = new RegisterTeacherViewModel();
           
            cbxCourses.ItemsSource = regTeacher.GetByEducation();
            //coursesList.ItemsSource = regTeacher.GetByEducation();
            //regTeacher.CreateCrazy(ShowCourse);
            
        }
      
     
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

      

     
    }
}
