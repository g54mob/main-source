using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.Saves___Serialization.Progression.Stats;
using Assets.Scripts.Saves___Serialization.Progression.Unlocks;
using Assets.Scripts.UI.Localization;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RequirementPrefab : MonoBehaviour
{
	public GameObject checkMark;

	public GameObject progress;

	public TextMeshProUGUI t_requirement;

	public RawImage progressBar;

	public TextMeshProUGUI t_progress;

	public unsafe void Set(MyAchievement ach)
	{
		//IL_0137: Invalid comparison between F4 and I4
		//IL_019e: Invalid comparison between I4 and F4
		//IL_015b: Expected F4, but got I4
		//IL_01e9: Expected F4, but got I4
		//IL_020f: Expected O, but got Ref
		//IL_0235: Expected O, but got Ref
		bool flag = ach != null;
		if (flag)
		{
			flag = MyAchievements.IsUnlocked(ach);
		}
		checkMark.SetActive(flag);
		TextMeshProUGUI textMeshProUGUI = t_requirement;
		string text = ((!(ach == null)) ? ach.GetUnlockRequirement() : "Available in Full Game");
		t_requirement.text = text;
		if (ach != null && ach.IsTrackingStat())
		{
			progress.SetActive(value: true);
			float stat = MyStats.GetStat(ach.statName);
			if (stat > (float)ach.targetValue)
			{
				stat = ach.targetValue;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg = default(object);
			object arg2 = default(object);
			string text2 = $"{arg:N0} / {arg2:N0}";
			t_progress.text = text2;
			float stat2 = MyStats.GetStat(ach.statName);
			float num = stat2 / (float)ach.targetValue;
			if (!(0f > num))
			{
				if (num > 1f)
				{
					num = 1f;
				}
			}
			else
			{
				num = 0f;
			}
			Transform transform = progressBar.transform;
			float num2 = default(float);
			transform.localScale = (Vector3)(&num2);
			Color redToGreenGradient = MyColorUtility.GetRedToGreenGradient(num);
			progressBar.color = (Color)(&num2);
		}
		else
		{
			progress.SetActive(value: false);
		}
	}

	public void Set(UnlockableBase unlockable)
	{
		bool active = MyAchievements.IsPurchased(unlockable);
		checkMark.SetActive(active);
		string localizedString = LocalizationUtility.GetLocalizedString("Main Menu", "BUTTON_BUY_PURCHASE");
		string unlockableTypeDisplayString = unlockable.GetUnlockableTypeDisplayString();
		string text = unlockable.GetName();
		string text2 = localizedString + ": " + unlockableTypeDisplayString + " - " + text;
		t_requirement.text = text2;
		progress.SetActive(value: false);
	}

	public void HideBar()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1831720E0]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		progress.SetActive(value: false);
		t_progress.text = "";
	}
}
