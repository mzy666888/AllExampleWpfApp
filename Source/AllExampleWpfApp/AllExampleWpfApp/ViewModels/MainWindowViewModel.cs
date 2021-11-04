using AllExampleWpfApp.Models;
using Prism.Mvvm;

namespace AllExampleWpfApp.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        private readonly ProductContext _productContext;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel(ProductContext productContext)
        {
            this._productContext = productContext;

            _productContext.Add<Category>(new Category {Name="First Product Name" });
            _productContext.SaveChanges(); 
        }
    }
}
