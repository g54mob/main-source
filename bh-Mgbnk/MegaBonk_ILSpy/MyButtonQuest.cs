using System;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.Saves___Serialization.Progression.Stats;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MyButtonQuest : MyButton
{
	public TextMeshProUGUI t_description;

	public TextMeshProUGUI t_reward;

	public TextMeshProUGUI t_progress;

	public TextMeshProUGUI t_claimAmount;

	public RawImage i_icon;

	public RawImage i_progressBar;

	public RawImage i_outline;

	public RawImage i_background;

	public MaskableGraphic i_colorBg;

	public MaskableGraphic i_colorOutline;

	public MaskableGraphic i_completeCheck;

	public GameObject claimOverlay;

	public GameObject incompleteOverlay;

	public GameObject rewardContainer;

	public GameObject hoveringOverlay;

	private MyAchievement _003Cachievement_003Ek__BackingField;

	public Color bgColorDefault;

	public Color bgColorCompleted;

	public static Action<MyButtonQuest> A_Select;

	public static Action<MyButtonQuest> A_Hover;

	public MyAchievement achievement
	{
		get
		{
			return _003Cachievement_003Ek__BackingField;
		}
		private set
		{
			_003Cachievement_003Ek__BackingField = value;
		}
	}

	public unsafe void Set(MyAchievement achievement)
	{
		//IL_0048: Expected I, but got O
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Expected O, but got Unknown
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Expected O, but got Unknown
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected O, but got Unknown
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Expected O, but got Unknown
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Expected O, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Expected O, but got Unknown
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Expected O, but got Unknown
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Expected O, but got Unknown
		//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dc: Expected O, but got Unknown
		//IL_0316: Expected I, but got O
		//IL_031f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0324: Expected O, but got Unknown
		//IL_0495: Invalid comparison between I4 and F4
		//IL_04ed: Expected F4, but got I4
		//IL_037c: Expected O, but got I4
		//IL_075c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0761: Expected O, but got Unknown
		//IL_0779: Unknown result type (might be due to invalid IL or missing references)
		//IL_077e: Expected O, but got Unknown
		//IL_04b6: Invalid comparison between F4 and I4
		//IL_04c9: Expected F4, but got I4
		//IL_043a: Unknown result type (might be due to invalid IL or missing references)
		//IL_043f: Expected O, but got Unknown
		//IL_053c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0541: Expected O, but got Unknown
		//IL_03c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c7: Expected O, but got Unknown
		//IL_03f8: Expected F4, but got I4
		//IL_0584: Unknown result type (might be due to invalid IL or missing references)
		//IL_0589: Expected O, but got Unknown
		//IL_05dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e2: Expected O, but got Unknown
		//IL_061c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0621: Expected I4, but got Unknown
		//IL_066c: Expected O, but got I4
		//IL_0674: Unknown result type (might be due to invalid IL or missing references)
		//IL_0679: Expected I4, but got Unknown
		_003Cachievement_003Ek__BackingField = achievement;
		bool flag = achievement.IsCompleted();
		bool flag2 = achievement.IsClaimed();
		TextMeshProUGUI textMeshProUGUI = t_description;
		string unlockRequirement = achievement.GetUnlockRequirement();
		nint num = (nint)textMeshProUGUI;
		textMeshProUGUI.text = unlockRequirement;
		TextMeshProUGUI textMeshProUGUI2 = t_reward;
		int silverReward = achievement.GetSilverReward();
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg = default(object);
		string text = $"<size=110%><sprite name=silver></size> {arg}";
		t_reward.text = text;
		Color color = MyColorUtility.DifficultyToColor(achievement.difficulty);
		object obj3 = 0 - color.r;
		object obj4 = 0 - color.g;
		float num2 = 1f - color.a;
		object obj5 = 0 - color.b;
		object obj6 = obj3 * 0;
		object obj7 = obj4 * 0;
		object obj8 = obj6 + color.r;
		float num3 = num2 * 0f;
		object obj9 = obj7 + color.g;
		object obj10 = obj5 * 0;
		float num4 = num3 + color.a;
		object obj11 = obj10 + color.b;
		Color color2 = (Color)(obj2 - 96);
		i_colorOutline.color = color2;
		Color color3 = MyColorUtility.DifficultyToColor(achievement.difficulty);
		float num5 = 1f - color3.r;
		float num6 = 1f - color3.g;
		float num7 = 1f - color3.b;
		float num8 = 1f - color3.a;
		float num9 = num5 * 0.4f;
		float num10 = num6 * 0.4f;
		float num11 = num9 + color3.r;
		float num12 = num7 * 0.4f;
		float num13 = num10 + color3.g;
		float num14 = num8 * 0.4f;
		float num15 = num12 + color3.b;
		float num16 = num14 + color3.a;
		Color color4 = (Color)(obj2 - 96);
		i_completeCheck.color = color4;
		MaskableGraphic maskableGraphic = i_colorBg;
		nint num17 = (nint)maskableGraphic;
		Color color5 = (Color)(obj2 - 96);
		if (flag)
		{
			Color color6 = bgColorCompleted;
		}
		else
		{
			Color color6 = bgColorDefault;
		}
		maskableGraphic.color = color5;
		RawImage rawImage;
		Color redToGreenGradient;
		if (!achievement.IsTrackingStat())
		{
			bool flag3 = (object)t_progress == null;
			object obj12 = !flag3;
			float t;
			if (obj12 == null)
			{
				t_progress.text = "0 / 1";
				Transform transform = i_progressBar.transform;
				_ = 0;
				Vector3 localScale = (Vector3)(obj2 - 96);
				_ = 1065353216;
				_ = 1065353216;
				transform.localScale = localScale;
				rawImage = i_progressBar;
				t = 0f;
			}
			else
			{
				t_progress.text = "1 / 1";
				Transform transform2 = i_progressBar.transform;
				_ = 1065353216;
				Vector3 localScale2 = (Vector3)(obj2 - 96);
				_ = 1065353216;
				_ = 1065353216;
				transform2.localScale = localScale2;
				rawImage = i_progressBar;
				t = 1f;
			}
			redToGreenGradient = MyColorUtility.GetRedToGreenGradient(t);
		}
		else
		{
			float stat = MyStats.GetStat(achievement.statName);
			float num18;
			if (!(0f > stat))
			{
				bool flag4 = stat > (float)achievement.targetValue;
				num18 = achievement.targetValue;
				if (!flag4)
				{
					num18 = stat;
				}
			}
			else
			{
				num18 = 0f;
			}
			object obj13 = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object obj14 = obj2 + 40;
			_ = achievement.targetValue;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg2 = default(object);
			object arg3 = default(object);
			string text2 = $"{arg2:N0}/{arg3:N0}";
			t_progress.text = text2;
			float t2 = num18 / (float)achievement.targetValue;
			Transform transform3 = i_progressBar.transform;
			Vector3 localScale3 = (Vector3)(obj2 - 96);
			_ = 1065353216;
			_ = 1065353216;
			transform3.localScale = localScale3;
			rawImage = i_progressBar;
			redToGreenGradient = MyColorUtility.GetRedToGreenGradient(t2);
		}
		Color color7 = (Color)(obj2 - 96);
		_ = redToGreenGradient.r;
		rawImage.color = color7;
		Texture icon = achievement.GetIcon();
		i_icon.texture = icon;
		if (!flag)
		{
		}
		Color color8 = (Color)(obj2 - 96);
		_ = 1065353216;
		i_icon.color = color8;
		int silverReward2 = achievement.GetSilverReward();
		int num19 = obj2 + 56;
		string text3 = ((int*)num19)->ToString();
		string text4 = "<size=115%><sprite name=silver></size> " + text3;
		t_claimAmount.text = text4;
		object obj15 = (flag2 ? 1 : 0) ^ 1;
		bool active = (byte)((obj15 & flag) ? 1 : 0) != 0;
		claimOverlay.SetActive(active);
		bool active2 = ((!flag) ? ((byte)((flag2 ? 1u : 0u) ^ 1u) != 0) : false);
		rewardContainer.SetActive(active2);
		GameObject gameObject = i_completeCheck.gameObject;
		bool active3 = flag2 | flag;
		gameObject.SetActive(active3);
	}

	public override void StartHover()
	{
		hoveringOverlay.SetActive(value: true);
		isHovering = true;
		Action<MyButtonQuest> a_Hover = A_Hover;
		if (A_Hover != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v43 @ rax_v5 (System.Action`1<MyButtonQuest>)+18] (should have been resolved before IL gen)");
		}
	}

	public override void StopHover()
	{
		hoveringOverlay.SetActive(value: false);
		isHovering = false;
	}

	protected override void OnClick()
	{
		float time = Time.time;
		float num = time - 0.1f;
		if (!(selectedAtTime > num))
		{
			if (_003Cachievement_003Ek__BackingField.IsCompleted() && !_003Cachievement_003Ek__BackingField.IsClaimed())
			{
				Claim();
			}
			Action<MyButtonQuest> a_Select = A_Select;
			if (A_Select != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v58 @ rax_v8 (System.Action`1<MyButtonQuest>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	public void TryClaimButton()
	{
		if (_003Cachievement_003Ek__BackingField.IsCompleted() && !_003Cachievement_003Ek__BackingField.IsClaimed())
		{
			Claim();
		}
	}

	private unsafe void Claim()
	{
		//IL_007a: Expected O, but got Ref
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		saveManager.progression.ClaimAchievement(_003Cachievement_003Ek__BackingField);
		claimOverlay.SetActive(value: false);
		Transform transform = t_claimAmount.transform;
		Vector3 position = transform.position;
		object obj = default(object);
		MenuParticles.Instance.CoinEffect((Vector3)(&obj));
	}

	public MyButtonQuest()
	{
		hoverScale = 1.05f;
		((MonoBehaviour)this)._002Ector();
	}
}
