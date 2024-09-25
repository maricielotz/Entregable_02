using Microsoft.Maui.Controls;
using MiAppCrud.Controllers;
using MiAppCrud.Models;

namespace MiAppCrud.Views
{
    public partial class CategoriaEditPage : ContentPage
    {
        private Categoria _categoria;

        public CategoriaEditPage(Categoria categoria = null)
        {
            InitializeComponent();
            _categoria = categoria ?? new Categoria();
            if (_categoria.Id != 0)
            {
                NombreEntry.Text = _categoria.Nombre;
                DescripcionEntry.Text = _categoria.Descripcion;
            }
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            _categoria.Nombre = NombreEntry.Text;
            _categoria.Descripcion = DescripcionEntry.Text;

            var controller = new CategoriaController();
            if (_categoria.Id == 0)
                controller.AddCategoria(_categoria);
            else
                controller.UpdateCategoria(_categoria);

            await Navigation.PopAsync();
        }
        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            if (_categoria.Id != 0)
            {
                bool isConfirmed = await DisplayAlert("Confirmar Eliminación", "¿Estás seguro de que deseas eliminar esta categoría?", "Sí", "No");
                if (isConfirmed)
                {
                    await Navigation.PopAsync();
                }
            }
        }
    }
}
