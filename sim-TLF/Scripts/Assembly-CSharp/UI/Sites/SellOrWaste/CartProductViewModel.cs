using Loxodon.Framework.Interactivity;
using Loxodon.Framework.ViewModels;

namespace UI.Sites.SellOrWaste
{
	public class CartProductViewModel : ViewModelBase
	{
		private string _productName;

		private int _productQuantity;

		private float _price;

		private string _assetReferenceID;

		public InteractionRequest<Notification> RemoveProductRequest = new InteractionRequest<Notification>();

		private readonly CartViewModel _cartViewModel;

		public string ProductName
		{
			get
			{
				return _productName;
			}
			internal set
			{
				Set(ref _productName, value, "ProductName");
			}
		}

		public float Price
		{
			get
			{
				return _price;
			}
			internal set
			{
				Set(ref _price, value, "Price");
			}
		}

		public int ProductQuantity
		{
			get
			{
				return _productQuantity;
			}
			internal set
			{
				Set(ref _productQuantity, value, "ProductQuantity");
			}
		}

		public string AssetReferenceID => _assetReferenceID;

		public CartProductViewModel(string productName, CartViewModel cartVM, string assetReferenceID, int quantity = 1, float price = 0f)
		{
			ProductName = productName;
			_productQuantity = quantity;
			_cartViewModel = cartVM;
			_price = price;
			_assetReferenceID = assetReferenceID;
		}

		public void IncreaseQuantityCommand()
		{
			ProductQuantity++;
		}

		public void DecreaseQuantityCommand()
		{
			ProductQuantity--;
			if (ProductQuantity < 1)
			{
				RemoveProductCommand();
			}
		}

		public void RemoveProductCommand()
		{
			RemoveProductRequest?.Raise(new Notification("Removed Cart Product"));
			_cartViewModel.CartProducts.Remove(this);
		}
	}
}
