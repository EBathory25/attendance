using LastAndFinalVersion.Commands;
using LastAndFinalVersion.Helpers;
using LastAndFinalVersion.Model;
using LastAndFinalVersion.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;


namespace LastAndFinalVersion.ViewModel
{
    class RegisterTeacherViewModel : ViewModelBase, INotifyPropertyChanged
    {

        private DelegateCommand mergeCommand;
        public DelegateCommand MergeCommand
        {
            get { return mergeCommand; }
            set
            {
                if (mergeCommand != value)
                {
                    mergeCommand = value;
                    NotifyOnPropertyChange("MergeCommand");
                }
            }
        }
        private String _UserName;
        public string UserName
        {
            get { return _UserName; }
            set
            {
                if (_UserName != value)
                {
                    _UserName = value;
                    NotifyOnPropertyChange("UserName");
                }
            }
        }
        private ObservableCollection<Cours> selectedCourses;
        public ObservableCollection<Cours> SelectedCourses
        {
            get { return selectedCourses; }
            set
            {
                selectedCourses = value;
                NotifyOnPropertyChange("SelectedCourse");
            }
        }
        private int pwd;
        public int Pwd
        {
            get { return pwd; }
            set
            {
                if (pwd != value)
                {
                    pwd = value;
                    NotifyOnPropertyChange("Pwd");
                }
            }
        }

        private int SNTeacher;
        public int SerialNT
        {
            get { return SNTeacher; }
            set
            {
                if (SNTeacher != value)
                {
                    SNTeacher = value;
                    NotifyOnPropertyChange("SerialNT");
                }
            }
        }
        private string fullName;
        public string FullName
        {
            get { return fullName; }
            set
            {
                if (fullName != value)
                {
                    fullName = value;
                    NotifyOnPropertyChange("FullName");
                }
            }
        }
        private string courseName;
        public string CourseName
        {
            get { return courseName; }
            set
            {
                if (courseName != value)
                {
                    courseName = value;
                    NotifyOnPropertyChange("CourseName");
                }
            }
        }
        public String education = string.Empty;
        public String Education
        {
            get { return education; }
            set
            {
                education = value;
                NotifyOnPropertyChange("Education");
            }
        }

        private ObservableCollection<Cours> _courses;
        public ObservableCollection<Cours> Courses
        {
            get => _courses;
            set
            {
                _courses = value;
                NotifyOnPropertyChange(nameof(Courses));
            }
        }

        public RegisterTeacherViewModel()
        {
            mergeCommand = new DelegateCommand(CreateCrazy);
            saveCommand = new DelegateCommand(SaveTeacher);
         
          

        }
      

        private DelegateCommand saveCommand;
        public DelegateCommand SaveCommand
        {
            get { return saveCommand; }
            set
            {
                if (saveCommand != value)
                {
                    saveCommand = value;
                    NotifyOnPropertyChange("SaveCommand");
                }
            }
        }
       
        public IEnumerable<Cours> GetByEducation()
        {

            using (var context = new DatabaseStudentsEntitiesLastStand())
            {
                var query = (from data in context.Courses select new { Education = data.education }).ToList().Select(c => new Cours { education = c.Education }).ToList();

                return query.ToList();

            }

        }
       
        //private bool isChecked;
        //public bool Checked
        //{
        //    get { return isChecked; }
        //    set
        //    {
        //        isChecked = value;
        //        NotifyOnPropertyChange("Checked");
        //    }
        //}

        public void CreateCrazy(object para)
        {
            var retur = new List<Cours>();
            using (DatabaseStudentsEntitiesLastStand db = new DatabaseStudentsEntitiesLastStand())
            {
                try
                {
                    var testing = Education;
                    var query = (from data in db.Courses where data.education == testing select new { CourseName = data.courseName }).ToList().Select(c => new Cours { courseName = c.CourseName }).ToList();
                    retur = query;
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            Courses = new ObservableCollection<Cours>(retur);
        }
       
        



        public void SaveTeacher(object param)
        {

            using (DatabaseStudentsEntitiesLastStand db = new DatabaseStudentsEntitiesLastStand())
            {
                Cours c = new Cours();
                RegisterTeacher t = new RegisterTeacher();

                if(c.IsChecked==true)
                {
                  
                   t.CourseName=courseName;

                }
                t.SNTeacher = SNTeacher;
                t.UserName = _UserName;
                t.pwd = pwd;
                t.fullName = fullName;
                t.education = education;

                db.RegisterTeachers.Attach(t);
               
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                   
                            MessageBox.Show(ex.Message);
                       
                }
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

    }
}