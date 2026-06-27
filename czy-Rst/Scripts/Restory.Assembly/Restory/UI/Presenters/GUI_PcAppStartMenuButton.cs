using System;
using Restory.Data.PC;
using Restory.UserInterface;
using Restory.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace Restory.UI.Presenters
{
	public class GUI_PcAppStartMenuButton : MonoBehaviour
	{
		[SerializeField]
		private Button button;

		[SerializeField]
		private Image appIcon;

		[SerializeField]
		private GUI_LocalisedText appName;

		public PcAppInfo AppInfo { get; private set; }

		public event Action<GUI_PcAppStartMenuButton> OnClicked;

		public void Init(PcAppInfo appInfo)
		{
			AppInfo = appInfo;
			appName.LocalizationID = appInfo.NameLocalizationKey;
			appIcon.sprite = appInfo.DesktopIcon;
		}

		private void OnEnable()
		{
			button.onClick.AddListener(ResolveButtonClicked);
		}

		private void OnDisable()
		{
			if (button.MonoShellExists())
			{
				button.onClick.RemoveListener(ResolveButtonClicked);
			}
		}

		private void ResolveButtonClicked()
		{
			this.OnClicked?.Invoke(this);
		}
	}
}
