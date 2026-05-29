using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class NotifVigilance : CTSBehaviour
	{
		[SerializeField]
		private NotificationData _notificationData;

		[SerializeField]
		[Range(0f, 1f)]
		private float _notificationVigilanceThreshold = 0.8f;

		[InjectScope(EGetScope.Singleton)]
		[SerializeField]
		[Inject(false)]
		private Notifications _notificationManager;

		private float _currentVigilance;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			VigilanceHandlers.VigilanceChanged += OnVigilanceChanged;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			VigilanceHandlers.VigilanceChanged -= OnVigilanceChanged;
		}

		private void OnVigilanceChanged(int newVigilance)
		{
			float num = MonoSingleton<VigilanceHandlers>.Instance.GetCurrentVigilancePercentageWithDifficulty() * 0.01f;
			if (num <= _currentVigilance)
			{
				if (num < _notificationVigilanceThreshold && _currentVigilance >= _notificationVigilanceThreshold)
				{
					_notificationManager.RemoveAll(_notificationData);
				}
				_currentVigilance = num;
			}
			else
			{
				_currentVigilance = num;
				if (!(_currentVigilance < _notificationVigilanceThreshold) && !_notificationManager.HasNotification(_notificationData))
				{
					_notificationManager.ShowNotification(_notificationData, removable: false);
				}
			}
		}
	}
}
