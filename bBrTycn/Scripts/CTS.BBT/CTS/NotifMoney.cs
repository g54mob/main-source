using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class NotifMoney : CTSBehaviour
	{
		[SerializeField]
		private NotificationData _notificationData;

		[SerializeField]
		private int _moneyUntilNotification = 500;

		[InjectScope(EGetScope.Singleton)]
		[SerializeField]
		[Inject(false)]
		private Notifications _notificationManager;

		private int _currentMoney;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			MoneyHandler.MoneyAmountChanged += OnMoneyAmountChanged;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			MoneyHandler.MoneyAmountChanged -= OnMoneyAmountChanged;
		}

		private void OnMoneyAmountChanged(int newAmount)
		{
			if (_currentMoney != newAmount)
			{
				if (newAmount < _currentMoney)
				{
					OnMoneyLost(newAmount);
				}
				else
				{
					OnMoneyGained(newAmount);
				}
			}
		}

		private void OnMoneyLost(int newAmount)
		{
			if (newAmount > _moneyUntilNotification)
			{
				_currentMoney = newAmount;
			}
			else if (newAmount <= 0)
			{
				if (_currentMoney > 0)
				{
					_notificationManager.ShowNotification(_notificationData, removable: false);
				}
				_currentMoney = newAmount;
			}
			else
			{
				if (_currentMoney > _moneyUntilNotification)
				{
					_notificationManager.ShowNotification(_notificationData, removable: false);
				}
				_currentMoney = newAmount;
			}
		}

		private void OnMoneyGained(int newAmount)
		{
			if (newAmount > _moneyUntilNotification && _currentMoney <= _moneyUntilNotification)
			{
				_notificationManager.RemoveAll(_notificationData);
			}
			_currentMoney = newAmount;
		}
	}
}
