using System;
using System.Text.RegularExpressions;
using Kamgam.UGUIComponentsForSettings;
using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	[AddComponentMenu("UI/Settings/InputBindingUGUIResolver")]
	[RequireComponent(typeof(InputBindingUGUI))]
	public class InputBindingUGUIResolver : SettingResolver, ISettingResolver
	{
		protected InputBindingUGUI inputBindingUGUI;

		[NonSerialized]
		protected SettingData.DataType[] supportedDataTypes = new SettingData.DataType[1] { SettingData.DataType.String };

		protected bool stopPropagation;

		public InputBindingUGUI InputBindingUGUI
		{
			get
			{
				if (inputBindingUGUI == null)
				{
					inputBindingUGUI = GetComponent<InputBindingUGUI>();
				}
				return inputBindingUGUI;
			}
		}

		public override SettingData.DataType[] GetSupportedDataTypes()
		{
			return supportedDataTypes;
		}

		public override void Start()
		{
			base.Start();
			InputBindingUGUI obj = InputBindingUGUI;
			obj.OnChanged = (InputBindingUGUI.OnChangedDelegate)Delegate.Combine(obj.OnChanged, new InputBindingUGUI.OnChangedDelegate(onChanged));
			InputBindingUGUI.PathToDisplayNameFunc = localizeKeyCode;
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
			if (InputBindingUGUI != null)
			{
				InputBindingUGUI obj = InputBindingUGUI;
				obj.OnChanged = (InputBindingUGUI.OnChangedDelegate)Delegate.Remove(obj.OnChanged, new InputBindingUGUI.OnChangedDelegate(onChanged));
				InputBindingUGUI.PathToDisplayNameFunc = null;
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

		protected string localizeKeyCode(string bindingPath)
		{
			if (LocalizationProvider != null && LocalizationProvider.HasLocalization())
			{
				if (LocalizationProvider.GetLocalization().HasTerm(bindingPath))
				{
					return LocalizationProvider.GetLocalization().Get(bindingPath);
				}
			}
			return bindingPathToDisplayName(bindingPath);
		}

		protected void onChanged(string bindingPath)
		{
			if (!stopPropagation && HasValidSettingForID(ID, GetSupportedDataTypes()) && HasActiveSettingForID(ID))
			{
				SettingsProvider.Settings.GetString(ID).SetValue(bindingPath);
			}
		}

		public override void Refresh()
		{
			if (!HasValidSettingForID(ID, GetSupportedDataTypes()) || !HasActiveSettingForID(ID))
			{
				return;
			}
			SettingString settingString = SettingsProvider.Settings.GetString(ID);
			if (settingString == null)
			{
				return;
			}
			InputBindingUGUI.InputBinding.SetBindingPath(settingString.GetValue());
			InputBindingUGUI.UpdateDisplayName();
			try
			{
				stopPropagation = true;
				if (InputBindingUGUI.PathToDisplayNameFunc == null)
				{
					InputBindingUGUI.PathToDisplayNameFunc = localizeKeyCode;
				}
				InputBindingUGUI.DisplayName = localizeKeyCode(settingString.GetValue());
			}
			finally
			{
				stopPropagation = false;
			}
		}

		protected string bindingPathToDisplayName(string bindingPath)
		{
			if (bindingPath == null)
			{
				return null;
			}
			bindingPath = Regex.Replace(bindingPath, "<[^>]*>/", "");
			if (bindingPath.Length < 6)
			{
				bindingPath = bindingPath.ToUpper();
			}
			return bindingPath;
		}
	}
}
