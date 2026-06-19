using System.Collections.Specialized;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Observables;
using Loxodon.Framework.Views;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Sites.SellOrWaste
{
	public class ShopView : UIView
	{
		[SerializeField]
		private ProductView _productViewRes;

		[SerializeField]
		private Transform _productParent;

		[SerializeField]
		private Button _backButton;

		private ObservableList<ProductViewModel> _products = new ObservableList<ProductViewModel>();

		public void CreateBinding()
		{
			BindingSet<ShopView, ShopViewModel> bindingSet = this.CreateBindingSet<ShopView, ShopViewModel>();
			bindingSet.Bind(this).For((ShopView v) => v._products).To((ShopViewModel vm) => vm.Products)
				.OneWay();
			bindingSet.Bind(this).For((ShopView v) => v.Visibility).To((ShopViewModel vm) => vm.Active)
				.OneWay();
			bindingSet.Bind(_backButton).For((Button v) => v.onClick).To((ShopViewModel vm) => vm.BackButtonClicked)
				.OneWay();
			bindingSet.Build();
			_products.CollectionChanged += ProdcutsChanged;
		}

		private void ProdcutsChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			switch (e.Action)
			{
			case NotifyCollectionChangedAction.Add:
				ProductAdded(e.NewItems[0] as ProductViewModel);
				break;
			case NotifyCollectionChangedAction.Reset:
				ClearProducts();
				break;
			case NotifyCollectionChangedAction.Remove:
			case NotifyCollectionChangedAction.Replace:
			case NotifyCollectionChangedAction.Move:
				break;
			}
		}

		private void ClearProducts()
		{
			foreach (Transform item in _productParent)
			{
				item.gameObject.SetActive(value: false);
			}
		}

		private void ProductAdded(ProductViewModel productViewModel)
		{
			ProductView productView = Object.Instantiate(_productViewRes, _productParent);
			productView.SetDataContext(productViewModel);
			productView.CreateBinding();
		}
	}
}
