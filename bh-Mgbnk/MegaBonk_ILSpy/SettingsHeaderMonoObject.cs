using System;
using Assets.Scripts.Settings___Saves.SaveFiles;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Cpp2ILInjected;
using UnityEngine;

public class SettingsHeaderMonoObject : MonoBehaviour
{
	private SettingHeader settingHeader;

	public void Set(SettingHeader settingHeader)
	{
		this.settingHeader = settingHeader;
	}

	private void Start()
	{
		CheckVisibility();
	}

	private void Awake()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<string, object, object> b = OnSettingUpdated;
		Delegate obj = Delegate.Combine(CurrentSettings.A_SettingUpdated, b);
		if ((object)obj == null)
		{
			CurrentSettings.A_SettingUpdated = (Action<string, object, object>)obj;
			return;
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
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<string, object, object>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnDestroy()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<string, object, object> value = OnSettingUpdated;
		Delegate obj = Delegate.Remove(CurrentSettings.A_SettingUpdated, value);
		if ((object)obj == null)
		{
			CurrentSettings.A_SettingUpdated = (Action<string, object, object>)obj;
			return;
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
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<string, object, object>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnSettingUpdated(string settingName, object oldValue, object newValue)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1831720C9]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (settingName == "show_advanced_settings")
		{
			CheckVisibility();
		}
	}

	private void CheckVisibility()
	{
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Expected O, but got Unknown
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Expected I4, but got Unknown
		SettingHeader settingHeader = this.settingHeader;
		if (!(settingHeader.header == "ADVANCED"))
		{
			return;
		}
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		bool active;
		if ((object)SaveManager._003CInstance_003Ek__BackingField != null)
		{
			ConfigSaveFile config = saveManager.config;
			if (saveManager.config != null)
			{
				CFGameSettings cfGameSettings = config.cfGameSettings;
				int? num = cfGameSettings.show_advanced_settings;
				active = false;
			}
			else
			{
				object obj = (object)saveManager.config >> 32;
				object obj2 = obj - 1;
				bool flag = obj2 == null;
				active = (byte)((flag & saveManager.config) ? 1 : 0) != 0;
			}
		}
		else
		{
			active = false;
		}
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(active);
	}
}
