using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RalfsMSSQLTool.ViewModels
{
    public class QueryTabViewModel : ObservableObject
    {
        #region Fields
        private string _header;
        private string _query;
        #endregion Fields

        #region Properties
        public string Header
        {
            get { return _header; }
            set { _header = value; OnPropertyChanged(); }
        }
        public string Query
        {
            get { return _query; }
            set { _query = value; OnPropertyChanged(); }
        }
        #endregion Properties

        #region Constructors
        public QueryTabViewModel(string header)
        {
            Header = header;
        }
        #endregion Constructors
        
    }
}
