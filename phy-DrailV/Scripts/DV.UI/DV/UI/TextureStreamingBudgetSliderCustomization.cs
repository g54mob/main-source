using DV.Localization;
using DV.UIFramework;
using UnityEngine;

namespace DV.UI
{
	[DisallowMultipleComponent]
	public class TextureStreamingBudgetSliderCustomization : UIElementTooltipCustomText
	{
		public ToggleDV textureStreamingEnabledToggle;

		public SliderDV slider;

		public string locKey;

		private void Start()
		{
			slider.onValueChanged.AddListener(delegate
			{
				TextChanged_Fire();
			});
			textureStreamingEnabledToggle.onValueChanged.AddListener(UpdateInteractable);
			UpdateInteractable();
		}

		private void UpdateInteractable(bool _ = false)
		{
			slider.ToggleInteractable(textureStreamingEnabledToggle.isOn);
		}

		public override string GetText()
		{
			if (!slider.interactable)
			{
				return "";
			}
			int num = Mathf.RoundToInt(slider.value / 100f * (float)SystemInfo.graphicsMemorySize);
			return LocalizationAPI.L(locKey, num.ToString("N0", LocalizationAPI.CC));
		}
	}
}
