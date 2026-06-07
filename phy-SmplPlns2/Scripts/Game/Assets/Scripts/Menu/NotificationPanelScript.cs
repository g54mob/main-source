using Assets.Scripts.GuiNew;
using Assets.Scripts.Net;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.Menu
{
	public class NotificationPanelScript : MonoBehaviour
	{
		private ButtonScript _cancelButton;

		private GameObject _canvas;

		private RawImageWidget _imageControl;

		private JundrooNotification _notification;

		private ButtonScript _okayButton;

		private TextWidget _textLabel;

		private TextWidget _titleLabel;

		public void ShowNotification(JundrooNotification notification)
		{
			_canvas.SetActive(value: false);
			_notification = notification;
			_titleLabel.Text = notification.Title;
			_okayButton.Text = notification.ButtonText;
			if (notification.Image != null)
			{
				_imageControl.Image.texture = notification.Image;
				int num = (int)((float)Screen.width * 0.75f);
				float num2 = _imageControl.Width.Value / _imageControl.Height.Value;
				if (_imageControl.Width > (float)num)
				{
					_imageControl.Width = num;
					_imageControl.Height = (int)((float)num / num2);
				}
				if (_imageControl.Height > (float)num)
				{
					_imageControl.Height = num;
					_imageControl.Width = (int)((float)num * num2);
				}
			}
			else
			{
				_imageControl.Visible = false;
			}
			_textLabel.Text = notification.Text;
		}

		protected virtual void Start()
		{
			_cancelButton.Clicked += CancelClicked;
			_okayButton.Clicked += OkayClicked;
		}

		private void CancelClicked(ButtonScript button)
		{
			CloseNotificationPanel();
		}

		private void CloseNotificationPanel()
		{
			_canvas.SetActive(value: true);
			base.gameObject.SetActive(value: false);
		}

		private void OkayClicked(ButtonScript button)
		{
			if (_notification != null)
			{
				string link = _notification.Link;
				string arg = "?";
				if (link.Contains('?'))
				{
					arg = "&";
				}
				WebUtility.OpenUrl(link + $"{arg}cv={1}");
			}
			CloseNotificationPanel();
		}
	}
}
