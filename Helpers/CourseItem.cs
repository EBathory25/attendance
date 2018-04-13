using LastAndFinalVersion.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastAndFinalVersion.Helpers
{
    class CourseItem:ViewModelBase
    {
        private string courseName = string.Empty;
        public string CourseName
        {
            get { return courseName; }
            set
            {
                if(courseName!=value)
                {
                    courseName = value;
                    RaisePropertyChanged("CourseName");
                    
                }
            }
        }
        public override string ToString()
        {
            string returnString = string.Empty;
            if(this.courseName!=string.Empty)
            {
                returnString = string.Format("Course name:{0}", this.courseName);
                
            }
            return returnString;
        }
    }
}
