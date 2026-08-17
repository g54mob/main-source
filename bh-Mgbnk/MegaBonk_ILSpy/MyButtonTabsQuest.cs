using System;
using Assets.Scripts._Data.Progression;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.Saves___Serialization.Progression.Unlocks;
using Assets.Scripts.Saves___Serialization.SaveFiles;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MyButtonTabsQuest : MyButtonTabs
{
	public TextMeshProUGUI t_progress;

	public TextMeshProUGUI t_unlcaimed;

	public RawImage i_progressBar;

	public GameObject unclaimedUi;

	private EAchievementType achievementType;

	private int unclaimed;

	private new void Awake()
	{
		//IL_00c4: Expected I, but got O
		//IL_009c: Expected I, but got O
		base.Awake();
		Action<MyAchievement> b = OnClaimed;
		Delegate obj = Delegate.Combine(ProgressionSaveFile.A_AchievementClaimed, b);
		if ((object)obj == null)
		{
			ProgressionSaveFile.A_AchievementClaimed = (Action<MyAchievement>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<MyAchievement> action = default(Action<MyAchievement>);
		if (action != null)
		{
			ProgressionSaveFile.A_AchievementClaimed = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<MyAchievement>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<MyAchievement>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnDestroy()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<MyAchievement> value = OnClaimed;
		Delegate obj = Delegate.Remove(ProgressionSaveFile.A_AchievementClaimed, value);
		if ((object)obj == null)
		{
			ProgressionSaveFile.A_AchievementClaimed = (Action<MyAchievement>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<MyAchievement> action = default(Action<MyAchievement>);
		if (action != null)
		{
			ProgressionSaveFile.A_AchievementClaimed = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<MyAchievement>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<MyAchievement>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public unsafe void Set(EAchievementType achievementType)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected Ref, but got Unknown
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected Ref, but got Unknown
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Ref, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected O, but got Unknown
		//IL_01dd: Expected O, but got I
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Expected O, but got Unknown
		//IL_026d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0272: Expected I4, but got Unknown
		//IL_012d: Expected O, but got I
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Expected O, but got Unknown
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Expected O, but got Unknown
		_ = 0;
		_ = 0;
		_ = 0;
		object obj = default(object);
		MyAchievements.GetAchievementTypeProgress(achievementType, out *(int*)(obj + 40), out *(int*)(obj + 48), out *(int*)(obj + 64));
		object obj2 = obj - 40;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+40]");
		unclaimed = 0;
		this.achievementType = achievementType;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object obj3 = obj - 36;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+30]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg = default(object);
		object arg2 = default(object);
		string text = $"{arg} / {arg2}";
		t_progress.text = text;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+30]");
		if ((nint)0 > (nint)0)
		{
			Transform transform = i_progressBar.transform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+28]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+30]");
			object obj4 = num / 0;
			Vector3 localScale = (Vector3)(obj - 24);
			_ = 1065353216;
			_ = 1065353216;
			transform.localScale = localScale;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+28]");
			float num2 = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+30]");
			float t = num2 / 0f;
			Color redToGreenGradient = MyColorUtility.GetRedToGreenGradient(t);
			Color color = (Color)(obj - 24);
			_ = redToGreenGradient.r;
			i_progressBar.color = color;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+40]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+40]");
		object obj5 = num3 ^ 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+40]");
		object obj6 = 0 & obj5;
		bool flag = (nint)obj6 < 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+40]");
		bool flag2 = (nint)0 < (nint)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+40]");
		bool flag3 = (nint)0 == 0;
		bool flag4 = flag2 == flag;
		bool flag5 = !flag3;
		bool active = flag5 & flag4;
		unclaimedUi.SetActive(active);
		int num4 = obj + 64;
		string text2 = ((int*)num4)->ToString();
		t_unlcaimed.text = text2;
	}

	private unsafe void OnClaimed(MyAchievement achievement)
	{
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected I4, but got Unknown
		if (achievement != null && t_unlcaimed != null && unclaimedUi != null && achievement.achievementType == achievementType)
		{
			int num = unclaimed - 1;
			unclaimed = num;
			int num2 = this + 188;
			string text = ((int*)num2)->ToString();
			t_unlcaimed.text = text;
			if (unclaimed <= 0)
			{
				unclaimedUi.SetActive(value: false);
			}
		}
	}

	public MyButtonTabsQuest()
	{
		hoverScale = 1.05f;
		((MonoBehaviour)this)._002Ector();
	}
}
