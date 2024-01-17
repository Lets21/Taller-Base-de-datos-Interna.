using ProductoMVVMSQLite.Models;
using ProductoMVVMSQLite.ViewModels;

namespace ProductoMVVMSQLite.Views;

public partial class ProductoPage : ContentPage
{
    public ProductoPage()
    {
        InitializeComponent();
        BindingContext = new ProductoViewModel();
    }

    private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is Producto selectedProducto)
        {
            (BindingContext as ProductoViewModel)?.VerDetallesProductoCommand.Execute(selectedProducto);

            // Deseleccionar el ítem
            ((ListView)sender).SelectedItem = null;
        }
    }
}