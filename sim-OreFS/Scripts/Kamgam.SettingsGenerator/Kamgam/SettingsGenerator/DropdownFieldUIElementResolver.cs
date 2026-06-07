using System.Collections.Generic;
using UnityEngine.UIElements;

namespace Kamgam.SettingsGenerator
{
	public class DropdownFieldUIElementResolver : SettingResolverForVisualElement, ISettingResolver
	{
		protected DropdownField _dropDown;

		protected SettingData.DataType[] supportedDataTypes = new SettingData.DataType[2]
		{
			SettingData.DataType.Option,
			SettingData.DataType.Int
		};

		protected bool stopPropagation;

		protected List<string> _localizedOptionLabels = new List<string>(3);

		public DropdownField DropDown
		{
			get
			{
				if ((_dropDown == null && base.VisualElement != null) || _dropDown != base.VisualElement)
				{
					_dropDown = base.VisualElement as DropdownField;
					if (_dropDown != null)
					{
						_dropDown.RegisterValueChangedCallback(onSelectionChanged);
					}
				}
				return _dropDown;
			}
		}

		public override SettingData.DataType[] GetSupportedDataTypes()
		{
			return supportedDataTypes;
		}

		public override void Start()
		{
			base.Start();
			if (LocalizationProvider != null && LocalizationProvider.HasLocalization())
			{
				LocalizationProvider.GetLocalization().AddOnLanguageChangedListener(onLanguageChanged);
			}
			if (HasValidSettingForID(ID, GetSupportedDataTypes()))
			{
				SettingsProvider.Settings.GetSetting(ID).AddPulledFromConnectionListener(Refresh);
			}
		}

		public override void OnDisable()
		{
			_dropDown = null;
			base.OnDisable();
		}

		public override void OnDestroy()
		{
			base.OnDestroy();
			if (DropDown != null)
			{
				DropDown.UnregisterValueChangedCallback(onSelectionChanged);
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

		protected void onSelectionChanged(ChangeEvent<string> evt)
		{
			int num = DropDown.choices.IndexOf(evt.newValue);
			if (num >= 0 && !stopPropagation && HasValidSettingForID(ID, GetSupportedDataTypes()) && HasActiveSettingForID(ID))
			{
				SettingOption option = SettingsProvider.Settings.GetOption(ID);
				if (option != null)
				{
					option.SetValue(num);
				}
				else
				{
					SettingsProvider.Settings.GetInt(ID)?.SetValue(num);
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
					DropDown.index = option.GetValue();
					return;
				}
				SettingInt settingInt = SettingsProvider.Settings.GetInt(ID);
				if (settingInt != null)
				{
					DropDown.index = settingInt.GetValue();
				}
			}
			finally
			{
				stopPropagation = false;
			}
		}

		protected void refreshOptions()
		{
			if (!HasValidSettingForID(ID, GetSupportedDataTypes()) || !HasActiveSettingForID(ID))
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
					DropDown.choices = _localizedOptionLabels;
				}
				else
				{
					DropDown.choices = list;
				}
			}
			else
			{
				LocalizationProvider.GetLocalization().LocalizeList(DropDown.choices, _localizedOptionLabels);
				DropDown.choices = _localizedOptionLabels;
			}
		}
	}
}
