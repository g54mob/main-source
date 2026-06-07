using CTS.Core;
using CTS.StockInventory;
using UnityEngine;

namespace CTS
{
	public class NotifStock : CTSBehaviour
	{
		[SerializeField]
		private StringKey<StockType> _stockToMonitor;

		[SerializeField]
		private NotificationData _notificationData;

		[SerializeField]
		private NotificationData _stockEmptyNotificationData;

		[SerializeField]
		private int _stockCountUntilNotification = 10;

		[InjectScope(EGetScope.Singleton)]
		[SerializeField]
		[Inject(false)]
		private Notifications _notificationManager;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			Stocks.BarStock.StockChanged += OnStockChanged;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			Stocks.BarStock.StockChanged -= OnStockChanged;
		}

		private void OnStockChanged(StockInventory<StockStack, CTS.BBT.StockItemSO>.StockChangedData data)
		{
			if (!(data.StockType != _stockToMonitor))
			{
				CheckLowStock(data);
				CheckFullStock(data);
			}
		}

		private void CheckLowStock(StockInventory<StockStack, CTS.BBT.StockItemSO>.StockChangedData data)
		{
			if (data.Operation == EOperation.ChangedCapacity)
			{
				return;
			}
			if (data.Operation == EOperation.Added)
			{
				if (data.StockCapacity.CurrentCapacity > _stockCountUntilNotification)
				{
					_notificationManager.RemoveAll(_notificationData);
				}
			}
			else if (data.StockCapacity.CurrentCapacity <= _stockCountUntilNotification && !_notificationManager.HasNotification(_notificationData))
			{
				_notificationManager.ShowNotification(_notificationData, removable: false);
			}
		}

		private void CheckFullStock(StockInventory<StockStack, CTS.BBT.StockItemSO>.StockChangedData data)
		{
			if ((object)_stockEmptyNotificationData == null)
			{
				return;
			}
			if (data.Operation == EOperation.ChangedCapacity)
			{
				if (data.StockCapacity.MaxCapacity.HasValue && data.StockCapacity.CurrentCapacity == data.StockCapacity.MaxCapacity.Value)
				{
					if (!_notificationManager.HasNotification(_stockEmptyNotificationData))
					{
						_notificationManager.ShowNotification(_stockEmptyNotificationData, removable: false);
					}
				}
				else
				{
					_notificationManager.RemoveAll(_stockEmptyNotificationData);
				}
			}
			else
			{
				if (!data.StockCapacity.MaxCapacity.HasValue)
				{
					return;
				}
				int value = data.StockCapacity.MaxCapacity.Value;
				if (data.Operation == EOperation.Removed)
				{
					if (data.StockCapacity.CurrentCapacity < value)
					{
						_notificationManager.RemoveAll(_stockEmptyNotificationData);
					}
				}
				else if (data.StockCapacity.CurrentCapacity >= value && !_notificationManager.HasNotification(_stockEmptyNotificationData))
				{
					_notificationManager.ShowNotification(_stockEmptyNotificationData, removable: false);
				}
			}
		}
	}
}
