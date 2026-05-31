using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class NotifPanic : CTSBehaviour
	{
		[SerializeField]
		private NotificationData _notificationData;

		[InjectScope(EGetScope.Singleton)]
		[SerializeField]
		[Inject(false)]
		private Notifications _notificationManager;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			PanicCounter.PanicActive += OnPanicActive;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			PanicCounter.PanicActive -= OnPanicActive;
		}

		private void OnPanicActive(bool obj)
		{
			if (!obj)
			{
				_notificationManager.RemoveAll(_notificationData);
			}
			else if (!_notificationManager.HasNotification(_notificationData))
			{
				_notificationManager.ShowNotification(_notificationData, removable: false);
			}
		}
	}
}
