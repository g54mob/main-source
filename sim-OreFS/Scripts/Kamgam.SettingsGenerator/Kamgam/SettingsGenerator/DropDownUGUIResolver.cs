using System;
using System.Collections.Generic;
using Kamgam.UGUIComponentsForSettings;
using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	[AddComponentMenu("UI/Settings/DropDownUGUIResolver")]
	[RequireComponent(typeof(DropDownUGUI))]
	public class DropDownUGUIResolver : SettingResolver, ISettingResolver
	{
		protected DropDownUGUI dropDownUGUI;

		protected SettingData.DataType[] supportedDataTypes = new SettingData.DataType[2]
		{
			SettingData.DataType.Option,
			SettingData.DataType.Int
		};

		protected bool stopPropagation;

		protected List<string> _localizedOptionLabels = new List<string>(3);

		public DropDownUGUI DropDownUGUI
		{
			get
			{
				if (dropDownUGUI == null)
				{
					dropDownUGUI = GetComponent<DropDownUGUI>();
				}
				return dropDownUGUI;
			}
		}

		public override SettingData.DataType[] GetSupportedDataTypes()
		{
			return supportedDataTypes;
		}

		public override void Start()
		{
			base.Start();
			DropDownUGUI obj = DropDownUGUI;
			obj.OnSelectionChanged = (DropDownUGUI.OnSelectionChangedDelegate)Delegate.Combine(obj.OnSelectionChanged, new DropDownUGUI.OnSelectionChangedDelegate(onSelectionChanged));
			if (LocalizationProvider != null && LocalizationProvider.HasLocalization())
			{
				LocalizationProvider.GetLocalization().AddOnLanguageChangedListener(onLanguageChanged);
			}
			if (HasValidSettingForID(ID, GetSupportedDataTypes()) && HasActiveSettingForID(ID))
			{
				SettingsProvider.Settings.GetSetting(ID).AddPulledFromConnectionListener(Refresh);
			}
		}

		public override void OnDestroy()
		{
			base.OnDestroy();
			if (DropDownUGUI != null)
			{
				DropDownUGUI obj = DropDownUGUI;
				obj.OnSelectionChanged = (DropDownUGUI.OnSelectionChangedDelegate)Delegate.Remove(obj.OnSelectionChanged, new DropDownUGUI.OnSelectionChangedDelegate(onSelectionChanged));
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

		protected void onSelectionChanged(int selectedIndex)
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
			try
			{
				stopPropagation = true;
				SettingOption option = SettingsProvider.Settings.GetOption(ID);
				if (option != null)
				{
					refreshOptions();
					DropDownUGUI.SelectedIndex = option.GetValue();
					return;
				}
				SettingInt settingInt = SettingsProvider.Settings.GetInt(ID);
				if (settingInt != null)
				{
					DropDownUGUI.SelectedIndex = settingInt.GetValue();
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
			if (option.HasOptions())
			{
				List<string> list = new List<string>(option.GetOptionLabels());
				if (LocalizationProvider != null && LocalizationProvider.HasLocalization())
				{
					LocalizationProvider.GetLocalization().LocalizeList(list, _localizedOptionLabels);
					DropDownUGUI.SetOptions(_localizedOptionLabels);
				}
				else
				{
					DropDownUGUI.SetOptions(list);
				}
			}
			else
			{
				LocalizationProvider.GetLocalization().LocalizeList(DropDownUGUI.GetOptions(), _localizedOptionLabels);
				DropDownUGUI.SetOptions(_localizedOptionLabels);
			}
		}
	}
}
