using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using RalfsMSSQLTool.Classes;
using RalfsMSSQLTool.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RalfsMSSQLTool.ViewModels
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainViewModel : ObservableObject
    {
        #region Fields
        private ObservableCollection<QueryTab> _queryItems;
        private QueryTab _selectedQuery;
        private QueryHandler _queryHandler;
        #endregion Fields

        #region Properties
        public ObservableCollection<QueryTab> QueryItems
        {
            get { return _queryItems; }
            set { _queryItems = value; OnPropertyChanged(); }
        }
        public QueryTab SelectedQuery
        {
            get { return _selectedQuery; }
            set { _selectedQuery = value; OnPropertyChanged(); }
        }
        #endregion Properties

        #region Commands
        public RelayCommand<QueryTab> CloseQueryTabCommand { get; private set; }
        public RelayCommand NewQueryCommand { get; private set; }
        #endregion Commands

        #region Constructors
        public MainViewModel()
        {
            _queryItems = new ObservableCollection<QueryTab>();
            _queryHandler = new QueryHandler();
            CloseQueryTabCommand = new RelayCommand<QueryTab>(DoCloseQueryTabCommand);
            NewQueryCommand = new RelayCommand(DoNewQueryCommand);
        }
        #endregion Constructors

        #region Methods
        private void NewQuery()
        {
            QueryTabViewModel newQuery = new QueryTabViewModel("Query");
            QueryTab newTab = new QueryTab();
            newTab.DataContext = newQuery;
            _queryItems.Add(newTab);
            SelectedQuery = newTab;
        }

        private void CloseQueryTab(QueryTab tabToClose)
        {
            QueryItems.Remove(tabToClose);
        }
        #endregion Methods

        #region Command Methods
        private void DoCloseQueryTabCommand(QueryTab tabToClose)
        {
            CloseQueryTab(tabToClose);
        }

        private void DoExecuteQueryCommand()
        {

        }

        private void DoNewQueryCommand()
        {
            NewQuery();
        }
        #endregion Command Methods
    }
}
