using System;
using UnityEngine;
using UnityEngine.UI;

namespace UniversalSettings
{
	[DisallowMultipleComponent]
	public abstract class SettingsComponentToggle : SettingsComponent
	{
		private Toggle toggle;

		protected virtual ref bool SettingsValue()
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

		protected virtual void OnValueChanged(bool value)
		{
			SettingsValue() = value;
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
			toggle = GetComponent<Toggle>();
			toggle.onValueChanged.AddListener(OnValueChanged);
		}

		internal override void UpdateComponent(SettingsProfile settings)
		{
			toggle.SetIsOnWithoutNotify(SettingsValue());
		}

		protected void SetToggleActive(bool value)
		{
			toggle.interactable = value;
		}

		private void OnDestroy()
		{
			if ((bool)toggle)
			{
				toggle.onValueChanged.RemoveListener(OnValueChanged);
			}
		}
	}
}
