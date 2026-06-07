using DV.UIFramework;
using UnityEngine;

namespace DV.UI
{
	[RequireComponent(typeof(SliderDV))]
	public class SettingReadoutSlider : SettingChangeSource<float>
	{
		private SliderDV slider;

		protected override void Awake()
		{
			base.Awake();
			slider = GetComponent<SliderDV>();
			slider.interactable = false;
			slider.wholeNumbers = false;
		}

		private void Update()
		{
			slider.value = provider.GetLiveReadout<float>(PreferencesName);
		}
	}
}
