using Loxodon.Framework.ViewModels;
using UnityEngine;

namespace UI.Sites.SellOrWaste
{
	public class OrderItemViewModel : ViewModelBase
	{
		private int _quantity;

		private string _productName;

		private float _price;

		private Sprite _productImage;

		private string _assetReferenceID;

		public int Quantity
		{
			get
			{
				return _quantity;
			}
			internal set
			{
				Set(ref _quantity, value, "Quantity");
			}
		}

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

		public Sprite ProductImage
		{
			get
			{
				return _productImage;
			}
			internal set
			{
				Set(ref _productImage, value, "ProductImage");
			}
		}

		public string AssetReferenceID => _assetReferenceID;

		public OrderItemViewModel(string productName, int productQuantity, float price, string assetReferenceID)
		{
			_productName = productName;
			_quantity = productQuantity;
			_price = price;
			_assetReferenceID = assetReferenceID;
		}
	}
}
