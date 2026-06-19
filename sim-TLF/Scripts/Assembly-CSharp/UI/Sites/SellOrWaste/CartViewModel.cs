using System.Linq;
using Loxodon.Framework.Observables;
using Loxodon.Framework.ViewModels;
using Services.Missions;
using UnityEngine;
using Zenject;

namespace UI.Sites.SellOrWaste
{
	public class CartViewModel : ViewModelBase
	{
		public ObservableList<CartProductViewModel> CartProducts = new ObservableList<CartProductViewModel>();

		private bool _active;

		[Inject]
		private MissionEventBus _missionEventBus;

		protected OrderContainerViewModel _orderContainerViewModel;

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

		public CartViewModel(OrderContainerViewModel orderContainerVM)
		{
			_orderContainerViewModel = orderContainerVM;
		}

		public void PlaceOrderCommand()
		{
			_orderContainerViewModel.Active = true;
			foreach (CartProductViewModel cartProduct in CartProducts)
			{
				OrderItemViewModel orderItem = new OrderItemViewModel(cartProduct.ProductName, cartProduct.ProductQuantity, cartProduct.Price, cartProduct.AssetReferenceID);
				_orderContainerViewModel.AddOrderItem(orderItem);
			}
			_missionEventBus.Emit("interact", "orderCart");
		}

		public void AddProductToCart(CartProductViewModel productViewModel)
		{
			CartProductViewModel cartProductViewModel = CartProducts.FirstOrDefault((CartProductViewModel p) => p.ProductName == productViewModel.ProductName);
			if (cartProductViewModel != null)
			{
				Debug.Log("Increasing Quantity");
				cartProductViewModel.IncreaseQuantityCommand();
			}
			else
			{
				Debug.Log("Adding new Product to cart");
				CartProducts.Add(productViewModel);
			}
		}
	}
}
