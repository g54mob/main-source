using System;
using Kamgam.UGUIComponentsForSettings;
using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	[AddComponentMenu("UI/Settings/InputKeyUGUIResolver")]
	[RequireComponent(typeof(InputKeyUGUI))]
	public class InputKeyUGUIResolver : SettingResolver, ISettingResolver
	{
		protected InputKeyUGUI inputKeyUGUI;

		[NonSerialized]
		protected SettingData.DataType[] supportedDataTypes = new SettingData.DataType[1] { SettingData.DataType.KeyCombination };

		protected bool stopPropagation;

		public InputKeyUGUI InputKeyUGUI
		{
			get
			{
				if (inputKeyUGUI == null)
				{
					inputKeyUGUI = GetComponent<InputKeyUGUI>();
				}
				return inputKeyUGUI;
			}
		}

		public override SettingData.DataType[] GetSupportedDataTypes()
		{
			return supportedDataTypes;
		}

		public override void Start()
		{
			base.Start();
			InputKeyUGUI obj = InputKeyUGUI;
			obj.OnChanged = (InputKeyUGUI.OnChangedDelegate)Delegate.Combine(obj.OnChanged, new InputKeyUGUI.OnChangedDelegate(onChanged));
			InputKeyUGUI.KeyCodeToKeyNameFunc = localizeKeyCode;
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
			if (InputKeyUGUI != null)
			{
				InputKeyUGUI obj = InputKeyUGUI;
				obj.OnChanged = (InputKeyUGUI.OnChangedDelegate)Delegate.Remove(obj.OnChanged, new InputKeyUGUI.OnChangedDelegate(onChanged));
				InputKeyUGUI.KeyCodeToKeyNameFunc = null;
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

		protected string localizeKeyCode(UniversalKeyCode keyCode)
		{
			if (LocalizationProvider != null && LocalizationProvider.HasLocalization())
			{
				string term = keyCode.ToString();
				if (LocalizationProvider.GetLocalization().HasTerm(term))
				{
					return LocalizationProvider.GetLocalization().Get(term);
				}
			}
			return InputUtils.UniversalKeyName(keyCode);
		}

		protected void onChanged(UniversalKeyCode key, UniversalKeyCode modifierKey)
		{
			if (!stopPropagation && HasValidSettingForID(ID, GetSupportedDataTypes()) && HasActiveSettingForID(ID))
			{
				SettingsProvider.Settings.GetKeyCombination(ID)?.SetValue(new KeyCombination(key, modifierKey));
			}
		}

		public override void Refresh()
		{
			if (!HasValidSettingForID(ID, GetSupportedDataTypes()) || !HasActiveSettingForID(ID))
			{
				return;
			}
			InputKeyUGUI.UpdateKeyName();
			SettingKeyCombination keyCombination = SettingsProvider.Settings.GetKeyCombination(ID);
			if (keyCombination == null)
			{
				return;
			}
			try
			{
				stopPropagation = true;
				if (InputKeyUGUI.KeyCodeToKeyNameFunc == null)
				{
					InputKeyUGUI.KeyCodeToKeyNameFunc = localizeKeyCode;
				}
				InputKeyUGUI.Key = keyCombination.GetValue().Key;
				InputKeyUGUI.ModifierKey = keyCombination.GetValue().ModifierKey;
			}
			finally
			{
				stopPropagation = false;
			}
		}
	}
}
