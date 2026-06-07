using System;
using Kamgam.UGUIComponentsForSettings;
using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	[AddComponentMenu("UI/Settings/StepperUGUIResolver")]
	[RequireComponent(typeof(StepperUGUI))]
	public class StepperUGUIResolver : SettingResolver, ISettingResolver
	{
		protected StepperUGUI stepperUGUI;

		protected SettingData.DataType[] supportedDataTypes = new SettingData.DataType[2]
		{
			SettingData.DataType.Int,
			SettingData.DataType.Float
		};

		protected bool stopPropagation;

		public StepperUGUI StepperUGUI
		{
			get
			{
				if (stepperUGUI == null)
				{
					stepperUGUI = GetComponent<StepperUGUI>();
				}
				return stepperUGUI;
			}
		}

		public override SettingData.DataType[] GetSupportedDataTypes()
		{
			return supportedDataTypes;
		}

		public override void Start()
		{
			base.Start();
			StepperUGUI.WholeNumbers = GetDataType() == SettingData.DataType.Int;
			StepperUGUI obj = StepperUGUI;
			obj.OnValueChanged = (StepperUGUI.OnValueChangedDelegate)Delegate.Combine(obj.OnValueChanged, new StepperUGUI.OnValueChangedDelegate(onValueChanged));
			if (HasValidSettingForID(ID, GetSupportedDataTypes()) && HasActiveSettingForID(ID))
			{
				SettingsProvider.Settings.GetSetting(ID).AddPulledFromConnectionListener(Refresh);
				Refresh();
			}
		}

		public override void OnDestroy()
		{
			base.OnDestroy();
			if (StepperUGUI != null)
			{
				StepperUGUI obj = StepperUGUI;
				obj.OnValueChanged = (StepperUGUI.OnValueChangedDelegate)Delegate.Remove(obj.OnValueChanged, new StepperUGUI.OnValueChangedDelegate(onValueChanged));
			}
		}

		private void onValueChanged(float value)
		{
			if (!stopPropagation && HasValidSettingForID(ID, GetSupportedDataTypes()) && HasActiveSettingForID(ID))
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
					StepperUGUI.Value = settingInt.GetValue();
					return;
				}
				SettingFloat settingFloat = SettingsProvider.Settings.GetFloat(ID);
				if (settingFloat != null)
				{
					StepperUGUI.Value = settingFloat.GetValue();
				}
			}
			finally
			{
				stopPropagation = false;
			}
		}
	}
}
