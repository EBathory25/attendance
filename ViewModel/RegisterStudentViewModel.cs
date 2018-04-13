using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastAndFinalVersion.ViewModel
{
    public class RegisterStudentViewModel : INotifyPropertyChanged
    {
        private int sn;
        public int SN
        { get { return sn; }
            set
            {
                if(sn!=value)
                {
                    sn = value;
                    NotifyOnPropertyChange("SN");
                }
            }
        }
        private String fName;
        public String FName
        {
            
            get { return fName; }
            set
            {
                if(fName!=value)
                {
                    fName = value;
                    NotifyOnPropertyChange("FName");
                }
            }
        }
        private string lName;
        public string LName
        {
            get { return lName; }
            set
            {
                if(lName!=value)
                {
                    lName = value;
                    NotifyOnPropertyChange("LName");
                }
            }
        }
        public String FullName
        {
            get { return lName + "" + fName.ToString(); }
        }
        private int studentNr;
        public int StudentNr
        {
            get { return studentNr; }
            set
            {
                if(studentNr!=value)
                {
                    studentNr = value;
                    NotifyOnPropertyChange("StudentNr");
                }
            }
        }
        private int semester;
        public int Semester
        {
            get { return semester; }
            set
            {
                if(semester!=value)
                {
                    semester = value;
                    NotifyOnPropertyChange("Semester");
                }
            }
        }
        public RegisterStudentViewModel()
        {
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
