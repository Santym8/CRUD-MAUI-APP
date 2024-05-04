namespace CRUD_MAUI_APP
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void btnProducts_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProductsPage());
        }

        private void btnCatergories_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CategoriesPage());
        }
    }

}
