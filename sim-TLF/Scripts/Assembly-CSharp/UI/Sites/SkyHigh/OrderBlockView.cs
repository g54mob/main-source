using System;
using System.Collections.Specialized;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Observables;
using Loxodon.Framework.Views;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Sites.SkyHigh
{
	public class OrderBlockView : UIView
	{
		[SerializeField]
		private TextMeshProUGUI _dateText;

		[SerializeField]
		private GameObject _completedObject;

		[SerializeField]
		private GameObject _inProgressObject;

		[SerializeField]
		private RectTransform _progressBar;

		[SerializeField]
		private RectTransform _progressBarParent;

		[SerializeField]
		private Button _destinationSetButton;

		[SerializeField]
		private Transform _orderItemsParent;

		[SerializeField]
		private OrderBlockItemView _orderBlockItemPrefab;

		private ObservableList<OrderBlockItemViewModel> _orderItems = new ObservableList<OrderBlockItemViewModel>();

		private ObservableProperty<float> _progress = new ObservableProperty<float>();

		public void CreateBinding()
		{
			BindingSet<OrderBlockView, OrderBlockViewModel> bindingSet = this.CreateBindingSet<OrderBlockView, OrderBlockViewModel>();
			bindingSet.Bind(_dateText).For((TextMeshProUGUI v) => v.text).To((OrderBlockViewModel vm) => vm.DateText)
				.OneWay();
			bindingSet.Bind(_completedObject).For((GameObject v) => v.activeSelf).To((OrderBlockViewModel vm) => vm.IsCompleted)
				.OneWay();
			bindingSet.Bind(_inProgressObject).For((GameObject v) => v.activeSelf).To((OrderBlockViewModel vm) => vm.IsInProgress)
				.OneWay();
			bindingSet.Bind(_destinationSetButton.gameObject).For((GameObject v) => v.activeSelf).To((OrderBlockViewModel vm) => vm.DestinationNotSet)
				.OneWay();
			bindingSet.Bind(_destinationSetButton).For((Button v) => v.onClick).To((OrderBlockViewModel vm) => vm.SetDestination)
				.OneWay();
			bindingSet.Bind(this).For((OrderBlockView v) => v._progress).To((OrderBlockViewModel vm) => vm.Progress)
				.OneWay();
			bindingSet.Bind(this).For((OrderBlockView v) => v._orderItems).To((OrderBlockViewModel vm) => vm.OrderItems)
				.OneWay();
			bindingSet.Build();
			_progress.ValueChanged += ProgressChanged;
			_orderItems.CollectionChanged += OrderItemsChanged;
			InstantiateOrderItems();
		}

		private void InstantiateOrderItems()
		{
			foreach (OrderBlockItemViewModel orderItem in _orderItems)
			{
				InstantiateOrderItem(orderItem);
			}
		}

		private void OrderItemsChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			switch (e.Action)
			{
			case NotifyCollectionChangedAction.Add:
				InstantiateOrderItem(e.NewItems[0] as OrderBlockItemViewModel);
				break;
			case NotifyCollectionChangedAction.Remove:
			case NotifyCollectionChangedAction.Replace:
			case NotifyCollectionChangedAction.Move:
			case NotifyCollectionChangedAction.Reset:
				break;
			}
		}

		private void InstantiateOrderItem(OrderBlockItemViewModel orderBlockItemViewModel)
		{
			OrderBlockItemView orderBlockItemView = UnityEngine.Object.Instantiate(_orderBlockItemPrefab, _orderItemsParent);
			orderBlockItemView.SetDataContext(orderBlockItemViewModel);
			orderBlockItemView.CreateBinding();
		}

		private void ProgressChanged(object sender, EventArgs e)
		{
			float x = _progressBarParent.rect.width * _progress.Value;
			Vector2 sizeDelta = _progressBar.sizeDelta;
			sizeDelta.x = x;
			_progressBar.sizeDelta = sizeDelta;
			if ((double)_progress.Value >= 1.0)
			{
				_inProgressObject.gameObject.SetActive(value: false);
			}
		}
	}
}
