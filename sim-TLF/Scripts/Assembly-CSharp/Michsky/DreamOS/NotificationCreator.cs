using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Michsky.DreamOS
{
	[AddComponentMenu("DreamOS/Notification/Notification Creator")]
	public class NotificationCreator : MonoBehaviour
	{
		public enum NotificationType
		{
			Default = 0,
			OnlyStandard = 1,
			OnlyPopup = 2
		}

		public Sprite icon;

		public string title;

		[TextArea]
		public string description;

		[TextArea(2, 4)]
		public string popupDescription;

		public List<NotificationManager.ButtonItem> notificationButtons = new List<NotificationManager.ButtonItem>();

		[SerializeField]
		private bool enableSound = true;

		[SerializeField]
		private bool createOnEnable;

		public NotificationType notificationType;

		private void OnEnable()
		{
			if (createOnEnable)
			{
				CreateNotification();
			}
		}

		public void CreateNotification()
		{
			if (notificationType == NotificationType.Default)
			{
				NotificationManager.instance.CreateNotificationWithButtons(icon, title, description, notificationButtons, enableSound);
			}
			else if (notificationType == NotificationType.OnlyStandard)
			{
				NotificationManager.instance.CreateNotificationWithButtons(icon, title, description, notificationButtons, enableSound, createPopup: false);
			}
			else if (notificationType == NotificationType.OnlyPopup)
			{
				NotificationManager.instance.CreatePopupNotification(icon, title, description, enableSound, null);
			}
		}

		public void CreateButton(string title, Sprite icon, UnityEvent onClick)
		{
			NotificationManager.ButtonItem buttonItem = new NotificationManager.ButtonItem();
			buttonItem.buttonText = title;
			buttonItem.buttonIcon = icon;
			buttonItem.onClick.AddListener(delegate
			{
				onClick = new UnityEvent();
			});
			notificationButtons.Add(buttonItem);
		}
	}
}
