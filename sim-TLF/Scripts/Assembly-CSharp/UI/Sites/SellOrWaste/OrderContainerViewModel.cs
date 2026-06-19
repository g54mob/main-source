using System;
using System.Collections.Generic;
using Computer.Sites.Services.Delivery;
using Loxodon.Framework.Observables;
using Loxodon.Framework.ViewModels;
using Michsky.DreamOS;
using Services;
using Services.Missions;
using UI.HUD;
using UnityEngine;
using Zenject;

namespace UI.Sites.SellOrWaste
{
	public class OrderContainerViewModel : ViewModelBase
	{
		public ObservableList<OrderItemViewModel> OrderItems = new ObservableList<OrderItemViewModel>();

		private string _orderNumberText;

		private bool _active;

		private bool _orderPlaneEnabled;

		[Inject]
		protected WebBrowserManager _webBrowserManager;

		[Inject]
		protected ISiteDeliveryService _siteDeliveryService;

		[Inject]
		protected IMoneyService _moneyService;

		[Inject]
		protected PlayerHUDView _playerHUD;

		[Inject]
		protected MissionEventBus _missionEventBus;

		public string OrderNumberText
		{
			get
			{
				return _orderNumberText;
			}
			internal set
			{
				Set(ref _orderNumberText, value, "OrderNumberText");
			}
		}

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

		public bool OrderPlaneButtonEnabled
		{
			get
			{
				return _orderPlaneEnabled;
			}
			internal set
			{
				Set(ref _orderPlaneEnabled, value, "OrderPlaneButtonEnabled");
			}
		}

		public void AddOrderItem(OrderItemViewModel orderItem)
		{
			OrderItems.Add(orderItem);
		}

		public void CloseCommand()
		{
			Active = false;
			OrderItems.Clear();
		}

		public void TakeAwayCommand()
		{
		}

		public void DeliveryCommand()
		{
			float num = 0f;
			foreach (OrderItemViewModel orderItem in OrderItems)
			{
				for (int i = 0; i < orderItem.Quantity; i++)
				{
					num += orderItem.Price;
				}
			}
			if (num > (float)_moneyService.CurrencyBalance.FlyCoinsBalance)
			{
				OrderPlaneButtonEnabled = false;
				OrderNumberText = "Not Enough FlyCoins!";
			}
			else
			{
				OrderPlaneButtonEnabled = true;
				OrderNumberText = $"{UnityEngine.Random.Range(0, 100):D2}-{UnityEngine.Random.Range(0, 1000):D3}-{UnityEngine.Random.Range(0, 10000):D4}";
				_missionEventBus.Emit("interact", "generateDeliveryId");
			}
		}

		public void OrderPlaneCommand()
		{
			List<DeliveryItem> list = new List<DeliveryItem>();
			float num = 0f;
			foreach (OrderItemViewModel orderItem in OrderItems)
			{
				list.Add(new DeliveryItem
				{
					ItemName = orderItem.ProductName,
					Quantity = orderItem.Quantity,
					AssetReferenceID = orderItem.AssetReferenceID
				});
				for (int i = 0; i < orderItem.Quantity; i++)
				{
					num += orderItem.Price;
				}
			}
			_playerHUD.InfoMessageSender.SendMoneyMessage(0f - num);
			_moneyService.RemoveCurrency(num);
			DeliveryOrder order = new DeliveryOrder
			{
				OrderId = OrderNumberText,
				OrderDate = DateTime.Now.AddYears(100),
				InProgress = false,
				DestinationSet = false,
				Completed = false,
				Progress = 0f,
				Items = list
			};
			_siteDeliveryService.CreateNewOrder(order);
			_webBrowserManager.CreateNewTab("sky.com");
		}
	}
}
