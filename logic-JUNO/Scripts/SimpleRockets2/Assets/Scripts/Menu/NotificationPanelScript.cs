using Assets.Scripts.Web;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Menu
{
	public class NotificationPanelScript : MonoBehaviour
	{
		private JundrooNotification _notification;

		private XmlLayout _xmlLayout;

		public void Initialize(XmlLayout layout)
		{
			_xmlLayout = layout;
		}

		public void ShowNotification(JundrooNotification notification)
		{
			_notification = notification;
			TextMeshProUGUI elementById = _xmlLayout.GetElementById<TextMeshProUGUI>("notification-title");
			TextMeshProUGUI elementById2 = _xmlLayout.GetElementById<TextMeshProUGUI>("notification-text");
			TextMeshProUGUI elementById3 = _xmlLayout.GetElementById<TextMeshProUGUI>("notification-button-text");
			elementById.text = notification.Title;
			elementById2.text = notification.Text;
			elementById3.text = notification.ButtonText;
			_xmlLayout.GetElementById("notification-close-button").AddOnClickEvent(delegate
			{
				OnCloseClicked();
			});
			_xmlLayout.GetElementById("notification-okay-button").AddOnClickEvent(delegate
			{
				OnOkayClicked();
			});
			Image component = _xmlLayout.GetElementById("notification-image").GetComponent<Image>();
			if (notification.Image != null)
			{
				Texture2D image = notification.Image;
				component.sprite = Sprite.Create(image, new Rect(0f, 0f, image.width, image.height), new Vector2(image.width / 2, image.height / 2));
			}
			else
			{
				component.gameObject.SetActive(value: false);
			}
		}

		protected virtual void Update()
		{
			if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
			{
				CloseNotificationPanel();
			}
		}

		private void CloseNotificationPanel()
		{
			Game.Instance.Settings.AddNotification(_notification.Id);
			Game.Instance.Settings.Save();
			base.gameObject.SetActive(value: false);
		}

		private void OnCloseClicked()
		{
			CloseNotificationPanel();
		}

		private void OnOkayClicked()
		{
			if (_notification != null)
			{
				string link = _notification.Link;
				string arg = "?";
				if (link.Contains("?"))
				{
					arg = "&";
				}
				WebUtility.OpenUrl(link + $"{arg}cv={1}");
			}
			CloseNotificationPanel();
		}
	}
}
