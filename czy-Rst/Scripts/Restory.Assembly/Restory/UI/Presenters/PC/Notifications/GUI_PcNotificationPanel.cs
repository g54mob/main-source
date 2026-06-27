using System;
using System.Collections.Generic;
using Restory.Data.Localization;
using Restory.Data.PC;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.PC.Notifications
{
	public class GUI_PcNotificationPanel : MonoBehaviour
	{
		[SerializeField]
		private GUI_PcAppInstallNotification notificationPrefab;

		private readonly List<GUI_PcNotificationBase> activeNotifications = new List<GUI_PcNotificationBase>();

		private DiContainer diContainer;

		private LocalizationSystem localizationSystem;

		public bool HasActiveNotifications => activeNotifications.Count > 0;

		public event Action<PcAppInfo> OnAppInstallNotificationConfirmed;

		[Inject]
		private void Construct(DiContainer diContainer, LocalizationSystem localizationSystem)
		{
			this.diContainer = diContainer;
			this.localizationSystem = localizationSystem;
		}

		public void AddAppInstallNotification(PcAppInfo appInfo)
		{
			GUI_PcAppInstallNotification notification = diContainer.InstantiatePrefabForComponent<GUI_PcAppInstallNotification>(notificationPrefab, base.transform);
			notification.Init(appInfo, localizationSystem.GetTranslation(appInfo.NameLocalizationKey));
			notification.ConfirmButton.onClick.AddListener(delegate
			{
				ResolveConfirmButtonClick(notification);
			});
			activeNotifications.Add(notification);
		}

		private void ResolveConfirmButtonClick(GUI_PcAppInstallNotification notification)
		{
			if (!notification.AppInfo)
			{
				Debug.LogError("Confirmed not initialized GUI_PcAppInstallNotification");
			}
			notification.ConfirmButton.onClick.RemoveAllListeners();
			this.OnAppInstallNotificationConfirmed?.Invoke(notification.AppInfo);
			activeNotifications.Remove(notification);
			UnityEngine.Object.Destroy(notification.gameObject);
		}
	}
}
