using System;
using Kamgam.UGUIComponentsForSettings;
using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	[AddComponentMenu("UI/Settings/ToggleUGUIResolver")]
	[RequireComponent(typeof(ToggleUGUI))]
	public class ToggleUGUIResolver : SettingResolver, ISettingResolver
	{
		protected ToggleUGUI toggleUGUI;

		protected SettingData.DataType[] supportedDataTypes = new SettingData.DataType[1] { SettingData.DataType.Bool };

		protected bool stopPropagation;

		public ToggleUGUI ToggleUGUI
		{
			get
			{
				if (toggleUGUI == null)
				{
					toggleUGUI = GetComponent<ToggleUGUI>();
				}
				return toggleUGUI;
			}
		}

		public override SettingData.DataType[] GetSupportedDataTypes()
		{
			return supportedDataTypes;
		}

		public override void Start()
		{
			base.Start();
			ToggleUGUI obj = ToggleUGUI;
			obj.OnValueChanged = (ToggleUGUI.ValueChangedDelegate)Delegate.Combine(obj.OnValueChanged, new ToggleUGUI.ValueChangedDelegate(onValueChanged));
			if (HasValidSettingForID(ID, GetSupportedDataTypes()) && HasActiveSettingForID(ID))
			{
				SettingsProvider.Settings.GetSetting(ID).AddPulledFromConnectionListener(Refresh);
				Refresh();
			}
		}

		public override void OnDestroy()
		{
			base.OnDestroy();
			if (ToggleUGUI != null)
			{
				ToggleUGUI obj = ToggleUGUI;
				obj.OnValueChanged = (ToggleUGUI.ValueChangedDelegate)Delegate.Remove(obj.OnValueChanged, new ToggleUGUI.ValueChangedDelegate(onValueChanged));
			}
		}

		private void onValueChanged(bool value)
		{
			if (!stopPropagation && HasValidSettingForID(ID, GetSupportedDataTypes()) && HasActiveSettingForID(ID))
			{
				SettingsProvider.Settings.GetBool(ID)?.SetValue(value);
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
				SettingBool settingBool = SettingsProvider.Settings.GetBool(ID);
				if (settingBool != null)
				{
					ToggleUGUI.Value = settingBool.GetValue();
				}
			}
			finally
			{
				stopPropagation = false;
			}
		}
	}
}
