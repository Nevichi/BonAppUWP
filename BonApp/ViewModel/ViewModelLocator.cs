using BonApp.View;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonApp.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainPageViewModel>();
            SimpleIoc.Default.Register<SearchRecipeViewModel>();
            SimpleIoc.Default.Register<ListRecipesViewModel>();
            SimpleIoc.Default.Register<ListFavoritesViewModel>();
            SimpleIoc.Default.Register<RecipeViewModel>();

            NavigationService navigationService = new NavigationService();
            SimpleIoc.Default.Register<INavigationService>(() => navigationService);
            navigationService.Configure("MainPage", typeof(MainPage));
            navigationService.Configure("SearchRecipe", typeof(SearchRecipe));
            navigationService.Configure("ListRecipes", typeof(ListRecipes));
            navigationService.Configure("ListFavorites", typeof(ListFavorites));
            navigationService.Configure("Recipe", typeof(Recipe));
        }

        public MainPageViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainPageViewModel>();
            }
        }

        public SearchRecipeViewModel SearchRecipe
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SearchRecipeViewModel>();
            }
        }

        public ListRecipesViewModel ListRecipes
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ListRecipesViewModel>();
            }
        }

        public ListFavoritesViewModel ListFavorites
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ListFavoritesViewModel>();
            }
        }

        public RecipeViewModel Recipe
        {
            get
            {
                return ServiceLocator.Current.GetInstance<RecipeViewModel>();
            }
        }
    }
}
