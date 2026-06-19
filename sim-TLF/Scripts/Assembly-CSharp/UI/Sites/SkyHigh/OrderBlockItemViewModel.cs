using Loxodon.Framework.ViewModels;
using UnityEngine;

namespace UI.Sites.SkyHigh
{
	public class OrderBlockItemViewModel : ViewModelBase
	{
		private Color _indicatorColor;

		private string _productName;

		private int _quantity;

		private readonly bool _completed;

		public Color IndicatorColor
		{
			get
			{
				return _indicatorColor;
			}
			internal set
			{
				Set(ref _indicatorColor, value, "IndicatorColor");
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

		public OrderBlockItemViewModel(string productName, int quantity, bool completed)
		{
			_productName = productName;
			_quantity = quantity;
			_completed = completed;
			_indicatorColor = (_completed ? Color.green : Color.black);
		}
	}
}
