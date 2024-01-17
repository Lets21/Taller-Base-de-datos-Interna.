using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductoMVVMSQLite.Models;
using ProductoMVVMSQLite.Utils;
using ProductoMVVMSQLite.Views;
using PropertyChanged;
using System.Windows.Input;

namespace ProductoMVVMSQLite.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class DetalleProductoViewModel
    {
        public Producto Producto { get; private set; }
        public ICommand EditarProductoCommand { get; }
        public ICommand EliminarProductoCommand { get; }
        public ICommand GuardarCambiosCommand { get; }
        public DetalleProductoViewModel(Producto producto)
        {
            Producto = producto;
            EditarProductoCommand = new Command(async () => await EditarProducto());
            EliminarProductoCommand = new Command(async () => await EliminarProducto());
            GuardarCambiosCommand = new Command(async () => await GuardarCambios());
        }

        private async Task EditarProducto()
        {
            // Lógica para editar el producto
            await App.Current.MainPage.Navigation.PushModalAsync(new EditarProductoPage(Producto));
        }

        private async Task GuardarCambios()
        {
            // Lógica para guardar los cambios del producto
            App.productoRepository.Update(Producto);
            await App.Current.MainPage.Navigation.PopModalAsync();
        }
        private async Task EliminarProducto()
        {
            App.productoRepository.Delete(Producto);
            Util.ListaProductos.Clear();
            App.productoRepository.GetAll().ForEach(Util.ListaProductos.Add);
            await App.Current.MainPage.Navigation.PopAsync();

        }
    }
}