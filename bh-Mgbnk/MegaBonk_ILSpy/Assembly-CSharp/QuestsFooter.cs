using System;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.Saves___Serialization.Progression.Stats;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestsFooter : MonoBehaviour
{
	public UnlockContainer achievementContainer;

	public TextMeshProUGUI t_description;

	public TextMeshProUGUI t_unlock;

	public TextMeshProUGUI t_reward;

	public GameObject checkMark;

	public RawImage i_progressBar;

	public TextMeshProUGUI t_progress;

	private void Awake()
	{
		//IL_0049: Expected O, but got I
		//IL_0051: Expected I, but got O
		//IL_0061: Expected O, but got I
		//IL_0071: Expected O, but got I
		//IL_00b9: Expected O, but got I
		//IL_00c1: Expected I, but got O
		//IL_00d1: Expected O, but got I
		//IL_00e1: Expected O, but got I
		//IL_0127: Expected O, but got I
		//IL_0137: Expected O, but got I
		//IL_01cb: Expected I, but got O
		//IL_01d4: Expected O, but got I4
		//IL_01d9: Expected I, but got O
		//IL_021f: Expected I, but got O
		//IL_0228: Expected O, but got I4
		//IL_022d: Expected I, but got O
		if ((object)achievementContainer != null)
		{
			achievementContainer.SetEmpty();
			TextMeshProUGUI textMeshProUGUI = t_description;
			if ((object)t_description != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
				object obj = 0;
				nint num = (nint)textMeshProUGUI;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rax_v9+B8]");
				object text = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ r9_v2 (Il2CppClass<TMPro.TextMeshProUGUI>)+560]");
				object obj2 = 0;
				t_description.text = (string)text;
				TextMeshProUGUI textMeshProUGUI2 = t_unlock;
				if ((object)t_unlock != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
					object obj3 = 0;
					nint num2 = (nint)textMeshProUGUI2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rax_v11+B8]");
					object text2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r9_v5 (Il2CppClass<TMPro.TextMeshProUGUI>)+560]");
					obj2 = 0;
					t_unlock.text = (string)text2;
					bool flag = (object)t_reward == null;
					num = num2;
					if (!flag)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rax_v13+B8]");
						object text3 = 0;
						t_reward.text = (string)text3;
						Action<MyButtonQuest> b = OnAchievementHover;
						Delegate obj5 = Delegate.Combine(MyButtonQuest.A_Hover, b);
						if ((object)obj5 == null)
						{
							MyButtonQuest.A_Hover = (Action<MyButtonQuest>)obj5;
							return;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
						Action<MyButtonQuest> action = default(Action<MyButtonQuest>);
						bool flag2 = action == null;
						Delegate obj6 = obj5;
						nint num3 = (nint)typeof(Action<MyButtonQuest>);
						obj2 = 0;
						num = unchecked((nint)null);
						if (!flag2)
						{
							MyButtonQuest.A_Hover = action;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
							object obj7 = default(object);
							bool flag3 = obj7 == null;
							obj6 = obj5;
							num3 = (nint)typeof(Action<MyButtonQuest>);
							obj2 = 0;
							num = unchecked((nint)null);
							if (!flag3)
							{
								return;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void OnDestroy()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<MyButtonQuest> value = OnAchievementHover;
		Delegate obj = Delegate.Remove(MyButtonQuest.A_Hover, value);
		if ((object)obj == null)
		{
			MyButtonQuest.A_Hover = (Action<MyButtonQuest>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<MyButtonQuest> action = default(Action<MyButtonQuest>);
		if (action != null)
		{
			MyButtonQuest.A_Hover = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<MyButtonQuest>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<MyButtonQuest>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void SetEmpty()
	{
		//IL_0020: Expected O, but got I
		//IL_0030: Expected O, but got I
		//IL_0054: Expected O, but got I
		//IL_0064: Expected O, but got I
		//IL_0088: Expected O, but got I
		//IL_0098: Expected O, but got I
		achievementContainer.SetEmpty();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rax_v4+B8]");
		object text = 0;
		t_description.text = (string)text;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rax_v6+B8]");
		object text2 = 0;
		t_unlock.text = (string)text2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v8+B8]");
		object text3 = 0;
		t_reward.text = (string)text3;
	}

	private void OnAchievementHover(MyButtonQuest questButton)
	{
		//IL_02f3: Expected F4, but got I4
		//IL_02fc: Invalid comparison between I4 and F4
		//IL_0342: Expected F4, but got I4
		//IL_024a: Unknown result type (might be due to invalid IL or missing references)
		//IL_024f: Expected O, but got Unknown
		//IL_0446: Unknown result type (might be due to invalid IL or missing references)
		//IL_044b: Expected O, but got Unknown
		//IL_0350: Unknown result type (might be due to invalid IL or missing references)
		//IL_0355: Expected O, but got Unknown
		//IL_0289: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Expected O, but got Unknown
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected O, but got Unknown
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Expected O, but got Unknown
		//IL_03e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e5: Expected O, but got Unknown
		//IL_041e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0423: Expected O, but got Unknown
		achievementContainer.SetAchievement(questButton._003Cachievement_003Ek__BackingField);
		string unlockRequirement = questButton._003Cachievement_003Ek__BackingField.GetUnlockRequirement();
		t_description.text = unlockRequirement;
		string unlockedString = questButton._003Cachievement_003Ek__BackingField.GetUnlockedString();
		t_unlock.text = unlockedString;
		TextMeshProUGUI textMeshProUGUI = t_reward;
		string rewardString = questButton._003Cachievement_003Ek__BackingField.GetRewardString();
		t_reward.text = rewardString;
		GameObject gameObject = t_unlock.gameObject;
		string text = t_unlock.text;
		bool flag = string.IsNullOrEmpty(text);
		bool active = (byte)((flag ? 1u : 0u) ^ 1u) != 0;
		gameObject.SetActive(active);
		bool active2 = questButton._003Cachievement_003Ek__BackingField.IsCompleted();
		checkMark.SetActive(active2);
		bool flag2 = questButton._003Cachievement_003Ek__BackingField.IsTrackingStat();
		MyAchievement myAchievement = questButton._003Cachievement_003Ek__BackingField;
		object obj = default(object);
		if (!flag2)
		{
			if (!myAchievement.IsCompleted() && !questButton._003Cachievement_003Ek__BackingField.IsClaimed())
			{
				Transform transform = i_progressBar.transform;
				_ = 0;
				Vector3 localScale = (Vector3)(obj - 32);
				_ = 1065353216;
				_ = 1065353216;
				transform.localScale = localScale;
				Color redToGreenGradient = MyColorUtility.GetRedToGreenGradient(0f);
				Color color = (Color)(obj - 32);
				_ = redToGreenGradient.r;
				i_progressBar.color = color;
				t_progress.text = "0 / 1";
			}
			else
			{
				Transform transform2 = i_progressBar.transform;
				_ = 1065353216;
				Vector3 localScale2 = (Vector3)(obj - 32);
				_ = 1065353216;
				_ = 1065353216;
				transform2.localScale = localScale2;
				Color redToGreenGradient2 = MyColorUtility.GetRedToGreenGradient(1f);
				Color color2 = (Color)(obj - 32);
				_ = redToGreenGradient2.r;
				i_progressBar.color = color2;
				t_progress.text = "1 / 1";
			}
			return;
		}
		float stat = MyStats.GetStat(myAchievement.statName);
		MyAchievement myAchievement2 = questButton._003Cachievement_003Ek__BackingField;
		float num = myAchievement2.targetValue;
		if (!(0f > stat))
		{
			if (!(stat > num))
			{
				num = stat;
			}
		}
		else
		{
			num = 0f;
		}
		object obj2 = obj + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		MyAchievement myAchievement3 = questButton._003Cachievement_003Ek__BackingField;
		object obj3 = obj + 40;
		_ = myAchievement3.targetValue;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg = default(object);
		object arg2 = default(object);
		string text2 = $"{arg:N0}/{arg2:N0}";
		t_progress.text = text2;
		MyAchievement myAchievement4 = questButton._003Cachievement_003Ek__BackingField;
		float t = num / (float)myAchievement4.targetValue;
		Transform transform3 = i_progressBar.transform;
		Vector3 localScale3 = (Vector3)(obj - 32);
		_ = 1065353216;
		_ = 1065353216;
		transform3.localScale = localScale3;
		Color redToGreenGradient3 = MyColorUtility.GetRedToGreenGradient(t);
		Color color3 = (Color)(obj - 32);
		_ = redToGreenGradient3.r;
		i_progressBar.color = color3;
	}
}
