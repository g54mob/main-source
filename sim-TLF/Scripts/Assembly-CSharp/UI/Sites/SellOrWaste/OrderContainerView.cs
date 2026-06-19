using System.Collections.Specialized;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Observables;
using Loxodon.Framework.Views;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Sites.SellOrWaste
{
	public class OrderContainerView : UIView
	{
		[SerializeField]
		private OrderItemView _orderItemPrefab;

		[SerializeField]
		private Transform _orderItemsParent;

		[SerializeField]
		private Button _takeAwayButton;

		[SerializeField]
		private Button _deliveryButton;

		[SerializeField]
		private Button _orderPlane;

		[SerializeField]
		private Button _closeButton;

		[SerializeField]
		private TextMeshProUGUI _orderNumberText;

		private ObservableList<OrderItemViewModel> _orderItems = new ObservableList<OrderItemViewModel>();

		public void CreateBinding()
		{
			BindingSet<OrderContainerView, OrderContainerViewModel> bindingSet = this.CreateBindingSet<OrderContainerView, OrderContainerViewModel>();
			bindingSet.Bind(_takeAwayButton).For((Button v) => v.onClick).To((OrderContainerViewModel vm) => vm.TakeAwayCommand)
				.OneWay();
			bindingSet.Bind(_deliveryButton).For((Button v) => v.onClick).To((OrderContainerViewModel vm) => vm.DeliveryCommand)
				.OneWay();
			bindingSet.Bind(_orderPlane).For((Button v) => v.onClick).To((OrderContainerViewModel vm) => vm.OrderPlaneCommand)
				.OneWay();
			bindingSet.Bind(_orderPlane).For((Button v) => v.interactable).To((OrderContainerViewModel vm) => vm.OrderPlaneButtonEnabled)
				.OneWay();
			bindingSet.Bind(_closeButton).For((Button v) => v.onClick).To((OrderContainerViewModel vm) => vm.CloseCommand)
				.OneWay();
			bindingSet.Bind(_orderNumberText).For((TextMeshProUGUI v) => v.text).To((OrderContainerViewModel vm) => vm.OrderNumberText)
				.OneWay();
			bindingSet.Bind(this).For((OrderContainerView v) => v.Visibility).To((OrderContainerViewModel vm) => vm.Active)
				.OneWay();
			bindingSet.Bind(this).For((OrderContainerView v) => v._orderItems).To((OrderContainerViewModel vm) => vm.OrderItems)
				.OneWay();
			bindingSet.Build();
			_orderItems.CollectionChanged += OrderItemsChanged;
		}

		private void OrderItemsChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			switch (e.Action)
			{
			case NotifyCollectionChangedAction.Add:
				CreateOrderItem(e.NewItems[0] as OrderItemViewModel);
				break;
			case NotifyCollectionChangedAction.Reset:
				ClearOrderItems();
				break;
			case NotifyCollectionChangedAction.Remove:
			case NotifyCollectionChangedAction.Replace:
			case NotifyCollectionChangedAction.Move:
				break;
			}
		}

		private void ClearOrderItems()
		{
			foreach (Transform item in _orderItemsParent)
			{
				item.gameObject.SetActive(value: false);
			}
		}

		private void CreateOrderItem(OrderItemViewModel orderItemViewModel)
		{
			OrderItemView orderItemView = Object.Instantiate(_orderItemPrefab, _orderItemsParent);
			orderItemView.SetDataContext(orderItemViewModel);
			orderItemView.CreateBinding();
		}
	}
}
