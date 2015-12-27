using BonApp.Model;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;

namespace BonApp.ViewModel
{
    public class RecipeViewModel : ViewModelBase, INotifyPropertyChanged
    {

        private Recipe _selectedRecipe;
        public Recipe SelectedRecipe
        {
            get { return _selectedRecipe; }
            set
            {
                _selectedRecipe = value;
                RaisePropertyChanged("SelectedRecipe");
            }
        }

        private Uri _uri;
        public Uri uri
        {
            get { return _uri; }
            set
            {
                _uri = value;
                RaisePropertyChanged("uri");
            }
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
            SelectedRecipe = (Recipe)e.Parameter;
            uri = new Uri(SelectedRecipe.source_url);
        }
    }
}
