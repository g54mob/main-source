using System;
using System.Collections;
using System.Linq;
using DG.Tweening;
using ModApi;
using UI.Xml;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts.Menu
{
	internal class NotificationButtonScript : MonoBehaviour
	{
		private const string NotificationsUrl = "https://jundroo.com/service/Notifications";

		private static DateTime? _lastDownloadTime;

		private JundrooNotification _notification;

		private GameObject _notificationButton;

		private NotificationPanelScript _notificationPanel;

		private XmlLayout _xmlLayout;

		public static void AnimateNotificationButton(GameObject go)
		{
			go.transform.DOScale(1.5f, 1.5f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
			go.transform.localRotation = Quaternion.Euler(0f, 0f, -8f);
			go.transform.DORotate(new Vector3(0f, 0f, 5f), 3f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
		}

		public void Initialize(GameObject button, NotificationPanelScript notificationPanel)
		{
			_notificationButton = button;
			_notificationPanel = notificationPanel;
		}

		public void OnClick()
		{
			try
			{
				if (_notification != null)
				{
					_notificationPanel.gameObject.SetActive(value: true);
					_notificationButton.gameObject.SetActive(value: false);
					_notificationPanel.ShowNotification(_notification);
					UnityWebRequest.Get(string.Format("{0}/Open/{1}?cv={2}", "https://jundroo.com/service/Notifications", _notification.ClickId, 1)).SendWebRequest();
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		private IEnumerator DownloadNotification()
		{
			UnityWebRequest notificationDownload;
			try
			{
				string storeId = Device.StoreId;
				string uri = string.Format("{0}/Xml/{1}?version={2}&platform={3}", "https://jundroo.com/service/Notifications", "SimpleRockets%202", Game.Version.ToString(), storeId);
				notificationDownload = UnityWebRequest.Get(uri);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				yield break;
			}
			yield return notificationDownload.SendWebRequest();
			bool flag = false;
			bool showNotificationButton = false;
			try
			{
				if (string.IsNullOrEmpty(notificationDownload.error))
				{
					_notification = JundrooNotification.Create(notificationDownload.downloadHandler.text);
					if (_notification != null && !Game.Instance.Settings.SeenNotifications.Contains(_notification.Id) && Game.Instance.Settings.NumberOfApplicationRuns >= _notification.NumApplicationRuns)
					{
						if (!string.IsNullOrEmpty(_notification.ImageUrl))
						{
							flag = true;
						}
						showNotificationButton = true;
					}
				}
				else
				{
					Debug.Log("Notification Failed: " + notificationDownload.error);
				}
			}
			catch (Exception exception2)
			{
				Debug.LogException(exception2);
				yield break;
			}
			if (flag)
			{
				UnityWebRequest imageDownload;
				try
				{
					imageDownload = UnityWebRequestTexture.GetTexture(_notification.ImageUrl, nonReadable: true);
				}
				catch (Exception exception3)
				{
					Debug.LogException(exception3);
					yield break;
				}
				yield return imageDownload.SendWebRequest();
				try
				{
					if (string.IsNullOrEmpty(imageDownload.error))
					{
						try
						{
							_notification.Image = DownloadHandlerTexture.GetContent(imageDownload);
							_notification.Image.wrapMode = TextureWrapMode.Clamp;
						}
						catch (Exception)
						{
							_notification.Image = null;
						}
					}
				}
				catch (Exception exception4)
				{
					Debug.LogException(exception4);
				}
			}
			_notificationButton.gameObject.SetActive(showNotificationButton);
			if (showNotificationButton)
			{
				AnimateNotificationButton(_notificationButton);
			}
		}

		private void Start()
		{
			try
			{
				if (!_lastDownloadTime.HasValue || DateTime.UtcNow > _lastDownloadTime.Value.AddHours(4.0))
				{
					Debug.Log("Checking for notification");
					_lastDownloadTime = DateTime.UtcNow;
					StartCoroutine(DownloadNotification());
				}
				else
				{
					Debug.Log("Skipping notification check.");
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		private void Update()
		{
		}
	}
}
