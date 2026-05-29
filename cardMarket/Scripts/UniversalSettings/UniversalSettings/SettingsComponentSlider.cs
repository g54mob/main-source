using System;
using UnityEngine;
using UnityEngine.UI;

namespace UniversalSettings
{
	[DisallowMultipleComponent]
	public abstract class SettingsComponentSlider : SettingsComponent
	{
		private Slider slider;

		protected virtual ref float SettingsValue()
		{
			Exception ex = new Exception("SettingsValue was not implemented!");
			Debug.LogException(ex, base.gameObject);
			throw ex;
		}

		protected virtual bool AutoApplyValue()
		{
			Exception ex = new Exception("AutoApplyValue was not implemented");
			Debug.LogException(ex, base.gameObject);
			throw ex;
		}

		protected virtual void OnValueChanged(float value)
		{
			SettingsValue() = value / 100f;
			if (AutoApplyValue())
			{
				AutoApply();
			}
			else
			{
				universalSettings.RegisterSettingsChange();
			}
		}

		internal override void Initialize(UniversalSettingsRunner universalSettings)
		{
			base.Initialize(universalSettings);
			slider = GetComponent<Slider>();
			slider.minValue = 0f;
			slider.maxValue = 100f;
			slider.wholeNumbers = true;
			slider.onValueChanged.AddListener(OnValueChanged);
		}

		internal override void UpdateComponent(SettingsProfile settings)
		{
			slider.SetValueWithoutNotify(SettingsValue() * 100f);
		}

		private void OnDestroy()
		{
			if ((bool)slider)
			{
				slider.onValueChanged.RemoveListener(OnValueChanged);
			}
		}
	}
}
