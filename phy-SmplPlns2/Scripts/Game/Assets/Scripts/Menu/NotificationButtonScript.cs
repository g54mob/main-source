using System;
using System.Collections;
using System.Linq;
using Assets.Scripts.Net;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Assets.Scripts.Menu
{
	public class NotificationButtonScript : MonoBehaviour
	{
		private const string NotificationsUrl = "https://jundroo.com/service/Notifications";

		private static DateTime? _lastDownloadTime;

		private JundrooNotification _notification;

		[SerializeField]
		private Button _notificationButton;

		[SerializeField]
		private NotificationPanelScript _notificationPanel;

		public void OnClick()
		{
			try
			{
				if (_notification != null)
				{
					_notificationPanel.gameObject.SetActive(value: true);
					_notificationButton.gameObject.SetActive(value: false);
					_notificationPanel.ShowNotification(_notification);
					Game.Instance.Settings.App.AddNotification(_notification.Id);
					Game.Instance.Settings.App.Save();
					WebRequest.Get(string.Format("{0}/Open/{1}?cv={2}", "https://jundroo.com/service/Notifications", _notification.ClickId, 1));
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		protected virtual void Start()
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

		private static string GetPlatform()
		{
			RuntimePlatform platform = Application.platform;
			if (platform != RuntimePlatform.OSXPlayer && platform != RuntimePlatform.IPhonePlayer)
			{
				_ = 11;
			}
			return "Steam";
		}

		private IEnumerator DownloadNotification()
		{
			UnityWebRequest notificationDownload;
			try
			{
				string platform = GetPlatform();
				string uri = string.Format("{0}/Xml/{1}?version={2}&platform={3}", "https://jundroo.com/service/Notifications", "SimplePlanesNext", Game.Version.ToString(), platform);
				notificationDownload = UnityWebRequest.Get(uri);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				yield break;
			}
			yield return notificationDownload.SendWebRequest();
			bool flag = false;
			try
			{
				if (string.IsNullOrEmpty(notificationDownload.error))
				{
					_notification = JundrooNotification.Create(notificationDownload.downloadHandler.text);
					if (_notification != null && !Game.Instance.Settings.App.SeenNotifications.Contains(_notification.Id) && Game.Instance.Settings.App.NumberOfApplicationRuns >= _notification.NumApplicationRuns)
					{
						if (!string.IsNullOrEmpty(_notification.ImageUrl))
						{
							flag = true;
						}
						_notificationButton.gameObject.SetActive(value: true);
					}
					else
					{
						_notificationButton.gameObject.SetActive(value: false);
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
			if (!flag)
			{
				yield break;
			}
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
	}
}
