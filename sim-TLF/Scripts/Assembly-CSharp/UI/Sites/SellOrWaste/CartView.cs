using System.Collections.Specialized;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Observables;
using Loxodon.Framework.Views;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Sites.SellOrWaste
{
	public class CartView : UIView
	{
		[SerializeField]
		private CartProductView _cartProductPrefab;

		[SerializeField]
		private Transform _productsParent;

		[SerializeField]
		private Button _orderButton;

		private ObservableList<CartProductViewModel> _cartProducts = new ObservableList<CartProductViewModel>();

		public void CreateBinding()
		{
			BindingSet<CartView, CartViewModel> bindingSet = this.CreateBindingSet<CartView, CartViewModel>();
			bindingSet.Bind(this).For((CartView v) => v.Visibility).To((CartViewModel vm) => vm.Active)
				.OneWay();
			bindingSet.Bind(this).For((CartView v) => v._cartProducts).To((CartViewModel vm) => vm.CartProducts)
				.OneWay();
			bindingSet.Bind(_orderButton).For((Button v) => v.onClick).To((CartViewModel vm) => vm.PlaceOrderCommand)
				.OneWay();
			bindingSet.Build();
			_cartProducts.CollectionChanged += ProductsChanged;
		}

		private void ProductsChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			switch (e.Action)
			{
			case NotifyCollectionChangedAction.Add:
				SpawnCartProduct(e.NewItems[0] as CartProductViewModel);
				break;
			case NotifyCollectionChangedAction.Remove:
				RemoveCartProduct(e.OldItems[0] as CartProductViewModel);
				break;
			case NotifyCollectionChangedAction.Replace:
			case NotifyCollectionChangedAction.Move:
			case NotifyCollectionChangedAction.Reset:
				break;
			}
		}

		private void RemoveCartProduct(CartProductViewModel cartProductViewModel)
		{
		}

		private void SpawnCartProduct(CartProductViewModel cartProductViewModel)
		{
			CartProductView cartProductView = Object.Instantiate(_cartProductPrefab, _productsParent);
			cartProductView.SetDataContext(cartProductViewModel);
			cartProductView.CreateBinding();
		}
	}
}
