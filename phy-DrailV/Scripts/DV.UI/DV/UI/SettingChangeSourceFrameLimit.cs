using DV.UIFramework;
using UnityEngine;

namespace DV.UI
{
	[RequireComponent(typeof(SliderDV))]
	public class SettingChangeSourceFrameLimit : SettingChangeSource<float>
	{
		private SliderDV slider;

		protected override void Awake()
		{
			base.Awake();
			slider = GetComponent<SliderDV>();
			slider.onValueChanged.AddListener(UpdateAndFireEvent);
		}

		protected override void OnResetOrApplied()
		{
			if (base.gameObject.activeSelf)
			{
				float num = GetLatestValueFromProvider();
				if (num == 999f)
				{
					num = slider.maxValue;
				}
				slider.SetValueNoStepping(num);
				base.OnResetOrApplied();
			}
		}

		protected override void UpdateAndFireEvent(float newValue)
		{
			if (newValue == slider.maxValue)
			{
				newValue = 999f;
			}
			base.UpdateAndFireEvent(newValue);
		}
	}
}
