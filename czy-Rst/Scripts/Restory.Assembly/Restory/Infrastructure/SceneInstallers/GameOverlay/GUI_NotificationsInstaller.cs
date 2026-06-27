using Restory.UI.Presenters.Notifications;
using Restory.UserInterface.GameplayOverlay;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameOverlay
{
	public class GUI_NotificationsInstaller : MonoInstaller
	{
		[SerializeField]
		private GUI_NotificationCanvas notificationCanvasPrefab;

		[SerializeField]
		private GUI_TipsNotification tipsNotificationPrefab;

		[SerializeField]
		private GUI_MoneyNotification moneyNotificationPrefab;

		public override void InstallBindings()
		{
			base.Container.Bind<GUI_TipsNotificationPool>().FromNew().WithArguments(tipsNotificationPrefab.gameObject)
				.WhenInjectedInto<GUI_NotificationCanvas>();
			base.Container.Bind<GUI_MoneyNotificationPool>().FromNew().WithArguments(moneyNotificationPrefab.gameObject)
				.WhenInjectedInto<GUI_NotificationCanvas>();
			base.Container.Bind<GUI_NotificationCanvas>().FromComponentInNewPrefab(notificationCanvasPrefab.gameObject).UnderTransform(GetCanvas)
				.AsSingle();
		}

		private Transform GetCanvas(InjectContext c)
		{
			return c.Container.Resolve<GUI_GameplayOverlayCanvas>().transform;
		}
	}
}
