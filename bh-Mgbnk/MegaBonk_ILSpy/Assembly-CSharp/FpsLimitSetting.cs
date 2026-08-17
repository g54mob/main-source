using System;
using Assets.Scripts.Settings___Saves.SaveFiles;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Assets.Scripts.UI.Localization;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class FpsLimitSetting : MonoBehaviour
{
	private BetterSetting betterSetting;

	private void Start()
	{
		//IL_00db: Expected I, but got O
		//IL_008f: Expected I, but got O
		BetterSetting component = GetComponent<BetterSetting>();
		betterSetting = component;
		Refresh();
		Action<string, object, object> b = OnSettingUpdated;
		Delegate obj = Delegate.Combine(CurrentSettings.A_SettingUpdated, b);
		if ((object)obj == null)
		{
			CurrentSettings.A_SettingUpdated = (Action<string, object, object>)obj;
			goto IL_009d;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<string, object, object> action = default(Action<string, object, object>);
		if (action != null)
		{
			CurrentSettings.A_SettingUpdated = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<string, object, object>);
			if (!flag)
			{
				goto IL_009d;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<string, object, object>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_009d:
		Action<Locale> value = OnLocaleChanged;
		LocalizationSettings.SelectedLocaleChanged += value;
	}

	private void OnDestroy()
	{
		//IL_00d6: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<string, object, object> value = OnSettingUpdated;
		Delegate obj = Delegate.Remove(CurrentSettings.A_SettingUpdated, value);
		if ((object)obj == null)
		{
			CurrentSettings.A_SettingUpdated = (Action<string, object, object>)obj;
			goto IL_0098;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<string, object, object> action = default(Action<string, object, object>);
		if (action != null)
		{
			CurrentSettings.A_SettingUpdated = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<string, object, object>);
			if (!flag)
			{
				goto IL_0098;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<string, object, object>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0098:
		Action<Locale> value2 = OnLocaleChanged;
		LocalizationSettings.SelectedLocaleChanged -= value2;
	}

	private void OnSettingUpdated(string settingName, object oldValue, object newValue)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172072]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (settingName == "vsync")
		{
			Refresh();
		}
	}

	private void OnLocaleChanged(Locale locale)
	{
		Refresh();
	}

	private void Refresh()
	{
		if (!(SaveManager._003CInstance_003Ek__BackingField != null))
		{
			return;
		}
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		if (saveManager.config != null)
		{
			SaveManager saveManager2 = SaveManager._003CInstance_003Ek__BackingField;
			ConfigSaveFile config = saveManager2.config;
			CFVideoSettings cfVideoSettings = config.cfVideoSettings;
			BetterSetting betterSetting = this.betterSetting;
			if (cfVideoSettings.vsync == 0)
			{
				betterSetting.disabledOverlay.SetActive(value: false);
				return;
			}
			LocalizedString localizedStringReference = LocalizationUtility.GetLocalizedStringReference("Other", "REQUIRES");
			string localizedString = localizedStringReference.GetLocalizedString();
			LocalizedString localizedStringReference2 = LocalizationUtility.GetLocalizedStringReference("SettingsVideo", "vsync");
			string localizedString2 = localizedStringReference2.GetLocalizedString();
			LocalizedString localizedStringReference3 = LocalizationUtility.GetLocalizedStringReference("SettingEnums", "Off");
			string localizedString3 = localizedStringReference3.GetLocalizedString();
			string disableText = localizedString + ": " + localizedString2 + " - " + localizedString3;
			betterSetting.Disable(disableText);
		}
	}
}
