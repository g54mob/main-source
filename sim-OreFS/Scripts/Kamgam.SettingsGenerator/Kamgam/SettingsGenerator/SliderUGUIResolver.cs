using System;
using Kamgam.UGUIComponentsForSettings;
using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	[AddComponentMenu("UI/Settings/SliderUGUIResolver")]
	[RequireComponent(typeof(SliderUGUI))]
	public class SliderUGUIResolver : SettingResolver, ISettingResolver
	{
		protected SliderUGUI _sliderUGUI;

		protected SettingData.DataType[] supportedDataTypes = new SettingData.DataType[2]
		{
			SettingData.DataType.Int,
			SettingData.DataType.Float
		};

		protected float _lastValue = float.NegativeInfinity;

		protected bool stopPropagation;

		public SliderUGUI SliderUGUI
		{
			get
			{
				if (_sliderUGUI == null)
				{
					_sliderUGUI = GetComponent<SliderUGUI>();
				}
				return _sliderUGUI;
			}
		}

		public override SettingData.DataType[] GetSupportedDataTypes()
		{
			return supportedDataTypes;
		}

		public override void Start()
		{
			base.Start();
			SliderUGUI.WholeNumbers = GetDataType() == SettingData.DataType.Int;
			SliderUGUI sliderUGUI = SliderUGUI;
			sliderUGUI.OnValueChanged = (SliderUGUI.ValueChangedDelegate)Delegate.Combine(sliderUGUI.OnValueChanged, new SliderUGUI.ValueChangedDelegate(onValueChanged));
			if (HasValidSettingForID(ID, GetSupportedDataTypes()) && HasActiveSettingForID(ID))
			{
				SettingsProvider.Settings.GetSetting(ID).AddPulledFromConnectionListener(Refresh);
				Refresh();
			}
		}

		public override void OnDestroy()
		{
			base.OnDestroy();
			if (SliderUGUI != null)
			{
				SliderUGUI sliderUGUI = SliderUGUI;
				sliderUGUI.OnValueChanged = (SliderUGUI.ValueChangedDelegate)Delegate.Remove(sliderUGUI.OnValueChanged, new SliderUGUI.ValueChangedDelegate(onValueChanged));
			}
		}

		private void onValueChanged(float value)
		{
			if (!stopPropagation && !Mathf.Approximately(_lastValue, value) && HasValidSettingForID(ID, GetSupportedDataTypes()) && HasActiveSettingForID(ID))
			{
				SettingInt settingInt = SettingsProvider.Settings.GetInt(ID);
				if (settingInt != null)
				{
					settingInt.SetValue(Mathf.RoundToInt(value));
				}
				else
				{
					SettingsProvider.Settings.GetFloat(ID)?.SetValue(value);
				}
			}
		}

		public override void Refresh()
		{
			if (!HasValidSettingForID(ID, GetSupportedDataTypes()) || !HasActiveSettingForID(ID))
			{
				return;
			}
			try
			{
				stopPropagation = true;
				SettingInt settingInt = SettingsProvider.Settings.GetInt(ID);
				if (settingInt != null)
				{
					SliderUGUI.Value = settingInt.GetValue();
					return;
				}
				SettingFloat settingFloat = SettingsProvider.Settings.GetFloat(ID);
				if (settingFloat != null)
				{
					SliderUGUI.Value = settingFloat.GetValue();
				}
			}
			finally
			{
				stopPropagation = false;
			}
		}
	}
}
