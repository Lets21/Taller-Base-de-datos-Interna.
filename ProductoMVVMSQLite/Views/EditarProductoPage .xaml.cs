using ProductoMVVMSQLite.ViewModels;
using ProductoMVVMSQLite.Models;
namespace ProductoMVVMSQLite.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditarProductoPage : ContentPage
    {
        public EditarProductoPage(Producto producto)
        {
            InitializeComponent();
            BindingContext = new DetalleProductoViewModel(producto);
        }
    }
}