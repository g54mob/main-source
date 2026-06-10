using System;
using TMPro;
using UnityEngine;

namespace ModIOBrowser.Implementation
{
	internal class NotificationPopupButton : MonoBehaviour
	{
		public TextMeshProUGUI buttonName;

		private Action action;

		private NotificationPopup master;

		public void Set(NotificationPopup.ButtonConfig config, NotificationPopup master)
		{
		}

		public void OnClick()
		{
		}

		public void Hide()
		{
		}
	}
}
