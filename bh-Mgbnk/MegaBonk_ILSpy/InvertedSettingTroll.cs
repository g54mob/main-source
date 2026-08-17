using System;
using Assets.Scripts._Data.Progression.Achievements.Challenges.ChallengeModifiers;
using Assets.Scripts.UI.Localization;
using Cpp2ILInjected;
using UnityEngine;

public class InvertedSettingTroll : MonoBehaviour
{
	private BetterSetting betterSetting;

	private static int trollStage;

	private float startedTrollingTime;

	private float trollCooldownSeconds = 20f;

	private void Start()
	{
		//IL_00b7: Expected I, but got O
		//IL_008f: Expected I, but got O
		BetterSetting component = GetComponent<BetterSetting>();
		betterSetting = component;
		Refresh();
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
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172076]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (settingName == "vsync")
		{
			Refresh();
		}
	}

	private void Refresh()
	{
		if (!(SaveManager._003CInstance_003Ek__BackingField != null))
		{
			return;
		}
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		if (saveManager.config == null)
		{
			return;
		}
		float time = Time.time;
		if (!ChallengeModifierInvertedControls.disableInvertedControlsOptions)
		{
			BetterSetting betterSetting = this.betterSetting;
			betterSetting.disabledOverlay.SetActive(value: false);
			return;
		}
		if (trollStage != 0)
		{
			float num = time - startedTrollingTime;
			if (!(num > trollCooldownSeconds))
			{
				return;
			}
		}
		string key;
		if (!(GameManager.Instance != null))
		{
			key = "TROLL_INVERTED_CONTROLS_2";
		}
		else
		{
			float time2 = Time.time;
			startedTrollingTime = time2;
			trollStage = 1;
			key = "TROLL_INVERTED_CONTROLS";
		}
		string localizedString = LocalizationUtility.GetLocalizedString("Other", key);
		bool flag = localizedString == null;
		string disableText = "";
		if (!flag)
		{
			disableText = localizedString;
		}
		this.betterSetting.Disable(disableText);
	}
}
