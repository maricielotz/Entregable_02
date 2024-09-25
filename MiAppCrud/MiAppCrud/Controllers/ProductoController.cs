using System.IO;
using Microsoft.Maui.Controls;
using MiAppCrud.Models;
using MiAppCrud.Services;
using MiAppCrud;
using MiAppCrud.Controllers;


namespace MiAppCrud.Controllers
{
    public class ProductoController
    {
        private readonly ProductoService _productoService;

        public ProductoController()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "productos.db3");
            _productoService = new ProductoService(dbPath);
        }

        public async Task<List<Producto>> GetAllProductos()
        {
            return await _productoService.GetAll();
        }

        public async 
        Task
AddProducto(Producto producto)
        {
            await _productoService.Add(producto);
        }

        public async 
        Task
UpdateProducto(Producto producto)
        {
            await _productoService.Update(producto);
        }

        public async void DeleteProducto(int id)
        {
            await _productoService.Delete(id);
        }
    }

}
