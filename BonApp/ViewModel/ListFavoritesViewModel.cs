﻿using BonApp.Data;
using BonApp.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonApp.ViewModel
{
    public class ListFavoritesViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private ObservableCollection<Recipe> _recipes;
        private Recipe _selectedRecipe;
        private INavigationService _navigationService;
        AzureDataAccess data;

        [PreferredConstructor]
        public ListFavoritesViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            data = new AzureDataAccess();
            Recipes = new ObservableCollection<Recipe>();
            //GetAllRecipes();

        }

        public ObservableCollection<Recipe> Recipes
        {
            get { return _recipes; }
            set
            {
                _recipes = value;
                RaisePropertyChanged("Recipes");
            }
        }

        public Recipe SelectedRecipe
        {
            get { return _selectedRecipe; }
            set
            {
                _selectedRecipe = value;
                if (_selectedRecipe != null)
                {
                    RaisePropertyChanged("SelectedRecipe");
                }
            }
        }

        public void OnNavigatedTo()
        {
            GetAllRecipes();
        }

        public async void GetAllRecipes()
        {
            List<Recipe> listRecipes = await data.GetAllRecipes();

            foreach (var item in listRecipes)
            {
                Recipes.Add(item);
            }
        }
    }

}
