using DV.Localization;
using DV.UIFramework;
using TMPro;
using UnityEngine;

namespace DV.UI
{
	[RequireComponent(typeof(ButtonDV))]
	public class FullscreenToggleButton : MonoBehaviour
	{
		private ASettingsProvider provider;

		private ButtonDV button;

		private TextMeshProUGUI label;

		private bool lastState;

		public void SetProvider(ASettingsProvider provider)
		{
			this.provider = provider;
			if (!button)
			{
				button = GetComponent<ButtonDV>();
			}
			if (!label)
			{
				label = button.GetComponentInChildren<TextMeshProUGUI>();
			}
			if ((bool)provider)
			{
				lastState = provider.IsFullscreen;
				UpdateLabel();
				button.onClick.AddListener(OnClick);
			}
			else
			{
				button.onClick.RemoveListener(OnClick);
			}
		}

		private void OnClick()
		{
			if ((bool)provider)
			{
				provider.ToggleFullscreen();
				lastState = provider.IsFullscreen;
				UpdateLabel();
			}
		}

		private void UpdateLabel()
		{
			label.text = (lastState ? LocalizationAPI.L("settings/switch_windowed") : LocalizationAPI.L("settings/switch_fullscreen"));
		}

		private void Update()
		{
			if ((bool)provider && lastState != provider.IsFullscreen)
			{
				lastState = provider.IsFullscreen;
				UpdateLabel();
			}
		}

		private void OnDestroy()
		{
			if ((bool)button)
			{
				button.onClick.RemoveListener(OnClick);
			}
		}
	}
}
