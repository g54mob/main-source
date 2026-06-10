using System;
using System.Collections.Generic;
using ModIO.Util;
using TMPro;

namespace ModIOBrowser.Implementation
{
	internal class NotificationPopup : SelfInstancingMonoSingleton<NotificationPopup>
	{
		public class ButtonConfig
		{
			public string name;

			public Action action;

			public ButtonConfig(string name, Action action)
			{
			}
		}

		public TextMeshProUGUI header;

		public TextMeshProUGUI body;

		public List<NotificationPopupButton> buttons;

		private Translation headerTranslation;

		private Translation bodyTranslation;

		protected override void Awake()
		{
		}

		public void Open(string header, string body, params ButtonConfig[] buttonConfigs)
		{
		}

		private void Show()
		{
		}

		private void Hide()
		{
		}

		public void Close()
		{
		}
	}
}
