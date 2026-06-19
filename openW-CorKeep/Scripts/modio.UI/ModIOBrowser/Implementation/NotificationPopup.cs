using System;
using System.Collections.Generic;
using System.Linq;
using ModIO.Util;
using TMPro;
using UnityEngine;

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
				this.name = name;
				this.action = action;
			}
		}

		public TextMeshProUGUI header;

		public TextMeshProUGUI body;

		public List<NotificationPopupButton> buttons;

		private Translation headerTranslation;

		private Translation bodyTranslation;

		protected override void Awake()
		{
			base.Awake();
			Hide();
		}

		public void Open(string header, string body, params ButtonConfig[] buttonConfigs)
		{
			this.header.text = header;
			this.body.text = body;
			buttons.ForEach(delegate(NotificationPopupButton button)
			{
				button.Hide();
			});
			if (buttonConfigs.Count() > buttons.Count())
			{
				Translation.Get(headerTranslation, "Error", this.header);
				Translation.Get(bodyTranslation, "This textbox is unable to display the input configuration.", this.body);
				buttons[0].Set(new ButtonConfig("Error", delegate
				{
					Debug.LogWarning("There are not enough buttons to display these choices.");
				}), this);
				throw new NotImplementedException("Error. Contact modio.");
			}
			for (int num = 0; num < buttonConfigs.Count(); num++)
			{
				buttons[num].Set(buttonConfigs[num], this);
			}
			Show();
		}

		private void Show()
		{
			base.gameObject.SetActive(value: true);
			SelfInstancingMonoSingleton<SelectionManager>.Instance.SelectView(UiViews.NotificationPopup);
		}

		private void Hide()
		{
			base.gameObject.SetActive(value: false);
		}

		public void Close()
		{
			Hide();
			SelfInstancingMonoSingleton<SelectionManager>.Instance.SelectPreviousView();
		}
	}
}
