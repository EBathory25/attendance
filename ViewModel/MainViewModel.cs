using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastAndFinalVersion.ViewModel
{
   public class MainViewModel:ViewModelBase
    {
        private ObservableCollection<object> items = new ObservableCollection<object>();
        private int _selectedTab = 0;
       
        
        public MainViewModel()
        {
            TabItems.Add(new AttendanceListViewModel());
            TabItems.Add(new RegisterStudentViewModel());
        }
        public string Header { get; set; }
        public object Content { set; get; }
       public ObservableCollection<object> TabItems
        {
            get
            {
                return items;
            }
            private set
            {
                items = value;
                RaisePropertyChanged("TabItems");
            }
        }
        public int SelectedTab
        {
            get { return _selectedTab; }
            set
            {
                if(value!=_selectedTab)
                {
                    _selectedTab = value;
                    RaisePropertyChanged("SelectedTab");
                }
            }
        }
    }
}
