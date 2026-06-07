using System;
using System.Collections.Generic;
using Kamgam.UGUIComponentsForSettings;
using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	[AddComponentMenu("UI/Settings/OptionsButtonUGUIResolver")]
	[RequireComponent(typeof(OptionsButtonUGUI))]
	public class OptionsButtonUGUIResolver : SettingResolver
	{
		protected OptionsButtonUGUI optionsButtonUGUI;

		protected SettingData.DataType[] supportedDataTypes = new SettingData.DataType[2]
		{
			SettingData.DataType.Option,
			SettingData.DataType.Int
		};

		protected bool stopPropagation;

		protected List<string> _localizedOptionLabels = new List<string>(3);

		public OptionsButtonUGUI OptionsButtonUGUI
		{
			get
			{
				if (optionsButtonUGUI == null)
				{
					optionsButtonUGUI = GetComponent<OptionsButtonUGUI>();
				}
				return optionsButtonUGUI;
			}
		}

		public override SettingData.DataType[] GetSupportedDataTypes()
		{
			return supportedDataTypes;
		}

		public override void Start()
		{
			base.Start();
			OptionsButtonUGUI obj = OptionsButtonUGUI;
			obj.OnValueChanged = (OptionsButtonUGUI.OnValueChangedDelegate)Delegate.Combine(obj.OnValueChanged, new OptionsButtonUGUI.OnValueChangedDelegate(onValueChanged));
			OptionsButtonUGUI.OptionToTextFunc = LocalizationProvider.GetLocalization().Get;
			if (LocalizationProvider != null && LocalizationProvider.HasLocalization())
			{
				LocalizationProvider.GetLocalization().AddOnLanguageChangedListener(onLanguageChanged);
			}
			if (HasValidSettingForID(ID, GetSupportedDataTypes()) && HasActiveSettingForID(ID))
			{
				SettingsProvider.Settings.GetSetting(ID).AddPulledFromConnectionListener(Refresh);
				Refresh();
			}
		}

		public override void OnDestroy()
		{
			base.OnDestroy();
			if (OptionsButtonUGUI != null)
			{
				OptionsButtonUGUI obj = OptionsButtonUGUI;
				obj.OnValueChanged = (OptionsButtonUGUI.OnValueChangedDelegate)Delegate.Remove(obj.OnValueChanged, new OptionsButtonUGUI.OnValueChangedDelegate(onValueChanged));
				OptionsButtonUGUI.OptionToTextFunc = null;
			}
			if (LocalizationProvider != null && LocalizationProvider.HasLocalization())
			{
				LocalizationProvider.GetLocalization().RemoveOnLanguageChangedListener(onLanguageChanged);
			}
		}

		protected void onLanguageChanged(string language)
		{
			Refresh();
		}

		private void onValueChanged(int selectedIndex)
		{
			if (!stopPropagation && HasValidSettingForID(ID, GetSupportedDataTypes()) && HasActiveSettingForID(ID))
			{
				SettingOption option = SettingsProvider.Settings.GetOption(ID);
				if (option != null)
				{
					option.SetValue(selectedIndex);
				}
				else
				{
					SettingsProvider.Settings.GetInt(ID)?.SetValue(selectedIndex);
				}
			}
		}

		public override void Refresh()
		{
			if (!HasValidSettingForID(ID, GetSupportedDataTypes()) || !HasActiveSettingForID(ID))
			{
				return;
			}
			OptionsButtonUGUI.UpdateText();
			try
			{
				stopPropagation = true;
				SettingOption option = SettingsProvider.Settings.GetOption(ID);
				if (option != null)
				{
					refreshOptions();
					OptionsButtonUGUI.SelectedIndex = option.GetValue();
					return;
				}
				SettingInt settingInt = SettingsProvider.Settings.GetInt(ID);
				if (settingInt != null)
				{
					OptionsButtonUGUI.SelectedIndex = settingInt.GetValue();
				}
			}
			finally
			{
				stopPropagation = false;
			}
		}

		protected void refreshOptions()
		{
			if (!HasActiveSettingForID(ID))
			{
				return;
			}
			SettingOption option = SettingsProvider.Settings.GetOption(ID);
			if (option != null && option.HasOptions())
			{
				List<string> optionLabels = option.GetOptionLabels();
				bool flag = option.HasConnection() && option.Connection is LanguageConnection;
				if (!flag && LocalizationProvider != null && LocalizationProvider.HasLocalization())
				{
					LocalizationProvider.GetLocalization().LocalizeList(optionLabels, _localizedOptionLabels);
					OptionsButtonUGUI.SetOptions(_localizedOptionLabels);
				}
				else if (!flag)
				{
					LocalizationProvider.GetLocalization().LocalizeList(OptionsButtonUGUI.GetOptions(), _localizedOptionLabels);
					OptionsButtonUGUI.SetOptions(_localizedOptionLabels);
				}
				else
				{
					OptionsButtonUGUI.SetOptions(optionLabels);
				}
			}
		}
	}
}
