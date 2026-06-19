using Loxodon.Framework.Observables;
using Loxodon.Framework.ViewModels;

namespace UI.Sites.SellOrWaste
{
	public class ShopViewModel : ViewModelBase
	{
		public ObservableList<ProductViewModel> Products = new ObservableList<ProductViewModel>();

		private bool _active;

		public bool Active
		{
			get
			{
				return _active;
			}
			internal set
			{
				Set(ref _active, value, "Active");
			}
		}

		public void BackButtonClicked()
		{
			Active = false;
		}

		public void AddProduct(ProductViewModel product)
		{
			Products.Add(product);
		}

		public void ClearProducts()
		{
			Products.Clear();
		}
	}
}
