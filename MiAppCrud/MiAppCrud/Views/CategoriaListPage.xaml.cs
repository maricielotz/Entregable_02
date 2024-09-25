using Microsoft.Maui.Controls;
using MiAppCrud.Controllers;
using MiAppCrud.Models;

namespace MiAppCrud.Views
{
    public partial class CategoriaListPage : ContentPage
    {
        private CategoriaController _controller;

        public CategoriaListPage()
        {
            InitializeComponent();
            _controller = new CategoriaController();
            LoadCategorias();
        }

        private async void LoadCategorias()
        {
            CategoriasListView.ItemsSource = await _controller.GetAllCategorias();
        }

        private async void OnCategoryTapped(object sender, ItemTappedEventArgs e)
        {
            var categoria = (Categoria)e.Item;
            await Navigation.PushAsync(new CategoriaEditPage(categoria));
        }

        private async void OnAddCategoryClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CategoriaEditPage());
        }
    }
}
