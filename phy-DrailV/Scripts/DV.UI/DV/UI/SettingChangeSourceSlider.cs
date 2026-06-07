using DV.UIFramework;
using UnityEngine;

namespace DV.UI
{
	[RequireComponent(typeof(SliderDV))]
	public class SettingChangeSourceSlider : SettingChangeSource<float>
	{
		public bool remapValue;

		public Vector2 remapToRange = new Vector2(0f, 1f);

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
				float value = GetLatestValueFromProvider();
				if (remapValue)
				{
					float t = Mathf.InverseLerp(remapToRange.x, remapToRange.y, value);
					value = Mathf.Lerp(slider.minValue, slider.maxValue, t);
				}
				slider.value = value;
				base.OnResetOrApplied();
			}
		}

		protected override void UpdateAndFireEvent(float newValue)
		{
			if (remapValue)
			{
				float t = Mathf.InverseLerp(slider.minValue, slider.maxValue, slider.value);
				newValue = Mathf.Lerp(remapToRange.x, remapToRange.y, t);
			}
			base.UpdateAndFireEvent(newValue);
		}
	}
}
