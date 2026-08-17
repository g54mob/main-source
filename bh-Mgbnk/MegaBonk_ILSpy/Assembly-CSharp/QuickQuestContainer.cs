using System;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class QuickQuestContainer : MonoBehaviour
{
	public RawImage icon;

	public RawImage progress;

	public TextMeshProUGUI t_name;

	public TextMeshProUGUI t_desc;

	public TextMeshProUGUI t_progress;

	private MyAchievement currentAchievement;

	private void Awake()
	{
		Action<Locale> value = OnLocaleChanged;
		LocalizationSettings.SelectedLocaleChanged += value;
	}

	private void OnDestroy()
	{
		Action<Locale> value = OnLocaleChanged;
		LocalizationSettings.SelectedLocaleChanged -= value;
	}

	private void OnLocaleChanged(Locale obj)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 2 Invalid \"Jump target not found in method: 0x180576AB0\"");
	}

	public unsafe void SetQuest(MyAchievement ach)
	{
		//IL_00c6: Expected O, but got Ref
		//IL_00f7: Expected O, but got Ref
		//IL_018d: Expected I, but got O
		//IL_019a: Expected O, but got Ref
		if (ach != null)
		{
			currentAchievement = ach;
			Texture texture = ach.GetIcon();
			icon.texture = texture;
			string displayName = ach.GetDisplayName();
			t_name.text = displayName;
			string unlockDescription = ach.GetUnlockDescription();
			t_desc.text = unlockDescription;
			float t = ach.GetProgress();
			Transform transform = progress.transform;
			float num = default(float);
			transform.localScale = (Vector3)(&num);
			RawImage rawImage = progress;
			Color redToGreenGradient = MyColorUtility.GetRedToGreenGradient(t);
			progress.color = (Color)(&num);
			TextMeshProUGUI textMeshProUGUI = t_progress;
			Color redToGreenGradient2 = MyColorUtility.GetRedToGreenGradient(t);
			float num2 = 1f - redToGreenGradient2.g;
			float num3 = 1f - redToGreenGradient2.b;
			float num4 = num2 * 0.5f;
			float num5 = num3 * 0.5f;
			float num6 = num4 + redToGreenGradient2.g;
			float num7 = num5 + redToGreenGradient2.b;
			nint num8 = (nint)textMeshProUGUI;
			textMeshProUGUI.color = (Color)(&num);
			int currentValue = ach.GetCurrentValue();
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg = default(object);
			object arg2 = default(object);
			string text = $"{arg} / {arg2}";
			t_progress.text = text;
		}
	}
}
