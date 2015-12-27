using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BonApp.ViewModel
{
    public class MainPageViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private ICommand _searchRecipeCommand;
        private ICommand _favoriteRecipeCommand;
         
        private INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public ICommand searchRecipeCommand
        {
            get
            {
                if (this._searchRecipeCommand == null)
                {
                    this._searchRecipeCommand = new RelayCommand(() => SearchRecipeNavigate());
                }
                return this._searchRecipeCommand;
            }
        }

        private void SearchRecipeNavigate()
        {
            _navigationService.NavigateTo("SearchRecipe");
        }


        public ICommand favoriteRecipeCommand
        {
            get
            {
                if(this._favoriteRecipeCommand == null)
                {
                    this._favoriteRecipeCommand = new RelayCommand(() => FavoriteRecipeNavigate());
                }
                return this._favoriteRecipeCommand;
            }
        }

        private void FavoriteRecipeNavigate()
        {
            _navigationService.NavigateTo("ListFavorites");
        }
    }
}
