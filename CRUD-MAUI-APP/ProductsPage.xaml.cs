using ApiClientPackage;
using Models;

namespace CRUD_MAUI_APP;

public partial class ProductsPage : ContentPage
{
    private String url = "https://clase-cloud-api.azurewebsites.net";

    public ProductsPage()
    {
        InitializeComponent();
    }

    private async void GetProduct_Clicked(object sender, EventArgs e)
    {
        int id = txtIdProduct.Text != null ? int.Parse(txtIdProduct.Text) : 0;
        var result = ApiConsumer<Product>.Read(url + "/api/Products", id);

        if (result.Name == null)
        {
            await DisplayAlert("Get", "Product not found", "Ok");
            return;
        }

        txtNameProduct.Text = result.Name;
        txtPriceProduct.Text = result.Prices.ToString();
        txtIvaProduct.Text = result.IVA.ToString();
        txtCategoryIdProduct.Text = result.categoryId.ToString();
        await DisplayAlert("Get", "Product retrieved", "Ok");
    }

    private async void PutProduct_Clicked(object sender, EventArgs e)
    {
        Product product = new Product
        {
            Id = int.Parse(txtIdProduct.Text),
            Name = txtNameProduct.Text,
            Prices = double.Parse(txtPriceProduct.Text),
            IVA = double.Parse(txtIvaProduct.Text),
            categoryId = int.Parse(txtCategoryIdProduct.Text)
        };

        var result = ApiConsumer<Product>.Update(url + "/api/Products", product.Id, product);
        await DisplayAlert("Update", "Product updated", "Ok");
    }

    private async void DeleteProduct_Clicked(object sender, EventArgs e)
    {
        int id = txtIdProduct.Text != null ? int.Parse(txtIdProduct.Text) : 0;
        ApiConsumer<Product>.Delete(url + "/api/Products", id);

        txtIdProduct.Text = "";
        txtNameProduct.Text = "";
        txtPriceProduct.Text = "";
        txtIvaProduct.Text = "";
        txtCategoryIdProduct.Text = "";
        await DisplayAlert("Delete", "Product deleted", "Ok");
    }

    private async void PostProduct_Clicked(object sender, EventArgs e)
    {
        Product product = new Product
        {
            Name = txtNameProduct.Text,
            Prices = double.Parse(txtPriceProduct.Text),
            IVA = double.Parse(txtIvaProduct.Text),
            categoryId = int.Parse(txtCategoryIdProduct.Text)
        };

        var result = ApiConsumer<Product>.Create(url + "/api/Products", product);

        if (result == null)
        {
            await DisplayAlert("Create", "Product not created", "Ok");
            return;
        }

        txtIdProduct.Text = result.Id.ToString();

        await DisplayAlert("Create", "Product created", "Ok");
    }
}