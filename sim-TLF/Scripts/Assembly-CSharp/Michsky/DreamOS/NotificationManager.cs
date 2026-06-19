using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Michsky.DreamOS
{
	public class NotificationManager : MonoBehaviour
	{
		[Serializable]
		public class ButtonItem
		{
			public string buttonText = "Button";

			public Sprite buttonIcon;

			public UnityEvent onClick = new UnityEvent();
		}

		public static NotificationManager instance;

		[SerializeField]
		private Transform notificationParent;

		[SerializeField]
		private Transform popupNotificationParent;

		[SerializeField]
		private GameObject notificationButton;

		public GameObject popupNotification;

		public GameObject standardNotification;

		[HideInInspector]
		public Image popupIcon;

		[HideInInspector]
		public TextMeshProUGUI popupTitle;

		[HideInInspector]
		public TextMeshProUGUI popupDescription;

		[Range(1f, 10f)]
		public float popupDuration = 2.5f;

		[HideInInspector]
		public Image standardIcon;

		[HideInInspector]
		public Image standardHeader;

		[HideInInspector]
		public TextMeshProUGUI standardTitle;

		[HideInInspector]
		public TextMeshProUGUI standardDescription;

		private List<ButtonItem> ntfButtons = new List<ButtonItem>();

		private void Awake()
		{
			instance = this;
			foreach (Transform item in notificationParent)
			{
				UnityEngine.Object.Destroy(item.gameObject);
			}
			foreach (Transform item2 in popupNotificationParent)
			{
				UnityEngine.Object.Destroy(item2.gameObject);
			}
		}

		public void CreateNotification(Sprite icon, string title, string description, bool createPopup = true, bool enableSound = true)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(standardNotification, new Vector3(0f, 0f, 0f), Quaternion.identity);
			gameObject.transform.SetParent(notificationParent);
			NotificationItem item = gameObject.GetComponent<NotificationItem>();
			item.iconObject.sprite = icon;
			item.titleObject.text = title;
			item.descriptionObject.text = description;
			for (int i = 0; i < ntfButtons.Count; i++)
			{
				GameObject obj = UnityEngine.Object.Instantiate(notificationButton, new Vector3(0f, 0f, 0f), Quaternion.identity);
				obj.transform.SetParent(item.buttonParent, worldPositionStays: false);
				int index = i;
				ButtonManager component = obj.GetComponent<ButtonManager>();
				component.buttonText = ntfButtons[i].buttonText;
				if (ntfButtons[i].buttonIcon == null)
				{
					component.enableIcon = false;
				}
				else
				{
					component.enableIcon = true;
					component.buttonIcon = ntfButtons[i].buttonIcon;
				}
				component.UpdateUI();
				component.onClick.AddListener(delegate
				{
					ntfButtons[index].onClick.Invoke();
					item.Close();
				});
			}
			if (enableSound && AudioManager.instance != null)
			{
				AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.UIManagerAsset.notificationSound);
			}
			if (createPopup)
			{
				CreatePopupNotification(icon, title, description, false, null);
			}
			item.Open();
		}

		public void CreateNotificationWithButtons(Sprite icon, string title, string description, List<ButtonItem> buttons, bool enableSound = true, bool createPopup = true)
		{
			ntfButtons = buttons;
			CreateNotification(icon, title, description, createPopup, enableSound);
		}

		public void CreatePopupNotification(Sprite icon, string title, string description, bool enableSound = true, AudioClip customSFX = null)
		{
			GameObject obj = UnityEngine.Object.Instantiate(popupNotification, new Vector3(0f, 0f, 0f), Quaternion.identity);
			obj.transform.SetParent(popupNotificationParent, worldPositionStays: false);
			NotificationItem component = obj.GetComponent<NotificationItem>();
			component.iconObject.sprite = icon;
			component.titleObject.text = title;
			component.descriptionObject.text = description;
			if (enableSound && customSFX != null && AudioManager.instance != null)
			{
				AudioManager.instance.audioSource.PlayOneShot(customSFX);
			}
			else if (enableSound && AudioManager.instance != null)
			{
				AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.UIManagerAsset.notificationSound);
			}
			component.OpenPopup(popupDuration);
		}

		public static void CreateNotification(Sprite icon, string title, string description, bool createPopup = true, bool enableSound = true, NotificationManager manager = null)
		{
			if (manager == null)
			{
				try
				{
					NotificationManager[] array = Resources.FindObjectsOfTypeAll(typeof(NotificationManager)) as NotificationManager[];
					foreach (NotificationManager notificationManager in array)
					{
						if (notificationManager.gameObject.scene.name != null)
						{
							manager = notificationManager;
						}
					}
				}
				catch
				{
					Debug.Log("<b>[Notification Creating]</b> Notification Manager is missing.");
					return;
				}
			}
			manager.CreateNotification(icon, title, description, createPopup, enableSound);
		}

		public static void CreatePopupNotification(Sprite icon, string title, string description, bool enableSound = true, AudioClip customSFX = null, NotificationManager manager = null)
		{
			if (manager == null)
			{
				try
				{
					NotificationManager[] array = Resources.FindObjectsOfTypeAll(typeof(NotificationManager)) as NotificationManager[];
					foreach (NotificationManager notificationManager in array)
					{
						if (notificationManager.gameObject.scene.name != null)
						{
							manager = notificationManager;
						}
					}
				}
				catch
				{
					Debug.Log("<b>[Notification Creating]</b> Notification Manager is missing.");
					return;
				}
			}
			manager.CreatePopupNotification(icon, title, description, enableSound, customSFX);
		}
	}
}
