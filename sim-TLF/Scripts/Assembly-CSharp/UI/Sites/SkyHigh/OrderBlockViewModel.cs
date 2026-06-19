using System;
using System.Globalization;
using Computer.Sites.Services.Delivery;
using Loxodon.Framework.Observables;
using Loxodon.Framework.ViewModels;
using Michsky.DreamOS;
using Services.Missions;
using Zenject;

namespace UI.Sites.SkyHigh
{
	public class OrderBlockViewModel : ViewModelBase
	{
		public ObservableProperty<float> Progress = new ObservableProperty<float>();

		public ObservableList<OrderBlockItemViewModel> OrderItems = new ObservableList<OrderBlockItemViewModel>();

		public readonly DeliveryOrder DeliveryOrder;

		[Inject]
		private readonly WebBrowserManager _webBrowserManager;

		[Inject]
		private readonly MissionEventBus _missionEventBus;

		private string _dateText;

		private bool _isCompleted;

		private bool _isInProgress;

		private bool _destinationNotSet;

		public string DateText
		{
			get
			{
				return _dateText;
			}
			internal set
			{
				Set(ref _dateText, value, "DateText");
			}
		}

		public bool IsCompleted
		{
			get
			{
				return _isCompleted;
			}
			internal set
			{
				Set(ref _isCompleted, value, "IsCompleted");
			}
		}

		public bool IsInProgress
		{
			get
			{
				return _isInProgress;
			}
			internal set
			{
				Set(ref _isInProgress, value, "IsInProgress");
			}
		}

		public bool DestinationNotSet
		{
			get
			{
				return _destinationNotSet;
			}
			internal set
			{
				Set(ref _destinationNotSet, value, "DestinationNotSet");
			}
		}

		public OrderBlockViewModel(DeliveryOrder order)
		{
			DeliveryOrder = order;
			_isCompleted = order.Completed;
			_isInProgress = order.InProgress;
			_destinationNotSet = !order.DestinationSet;
			_dateText = order.OrderDate.ToString("MMM. dd. yyyy", CultureInfo.InvariantCulture);
			foreach (DeliveryItem item2 in order.Items)
			{
				OrderBlockItemViewModel item = new OrderBlockItemViewModel(item2.ItemName, item2.Quantity, completed: false);
				OrderItems.Add(item);
			}
			Progress.ValueChanged += TutorialProgressCheck;
		}

		private void TutorialProgressCheck(object sender, EventArgs e)
		{
			if (Progress.Value == 1f)
			{
				_missionEventBus.Emit("interact", "waitDelivery");
			}
		}

		public void SetDate(DateTime dateTime)
		{
			DateText = dateTime.ToString("MMM. dd. yyyy", CultureInfo.InvariantCulture);
		}

		public void AddOrderItem(OrderBlockItemViewModel item)
		{
			OrderItems.Add(item);
		}

		public void ClearOrderItems()
		{
			OrderItems.Clear();
		}

		public void EvaluateProgress()
		{
			Progress.Value = DeliveryOrder.Progress;
			SyncWithDeliveryOrderObject();
		}

		public void SetDestination()
		{
			_webBrowserManager.CreateNewTab("map.com");
			_missionEventBus.Emit("interact", "setDestination");
		}

		private void SyncWithDeliveryOrderObject()
		{
			IsCompleted = DeliveryOrder.Completed;
			IsInProgress = DeliveryOrder.InProgress;
			bool destinationSet = DeliveryOrder.DestinationSet;
			DestinationNotSet = !destinationSet;
			if (IsInProgress)
			{
				_missionEventBus.Emit("interact", "selectIsland");
			}
		}
	}
}
