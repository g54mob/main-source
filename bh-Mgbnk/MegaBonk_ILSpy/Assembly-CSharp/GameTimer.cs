using System;
using Assets.Scripts.Managers;
using Assets.Scripts.Saves___Serialization.Progression.Challenges;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
	public TextMeshProUGUI t_timerRun;

	public TextMeshProUGUI t_timerStage;

	public TextMeshProUGUI t_timerSpeedrun;

	private float fontSizeDefault;

	private bool isRed;

	private ChallengeModifierSpeedrun speedrunModifier;

	private int lastRunMinutes;

	private int lastRunSeconds;

	private int lastStageMinutes;

	private int lastStageSeconds;

	private void Start()
	{
		TextMeshProUGUI textMeshProUGUI = t_timerStage;
		fontSizeDefault = ((TMP_Text)textMeshProUGUI).m_fontSize;
		UpdateTimers();
	}

	private void FixedUpdate()
	{
		GameManager instance = GameManager.Instance;
		if (instance.isPlaying)
		{
			UpdateTimers();
		}
	}

	private unsafe void UpdateTimers()
	{
		//IL_02a7: Expected O, but got I
		//IL_02b7: Expected O, but got I
		//IL_037a: Invalid comparison between I4 and F4
		//IL_01c6: Expected O, but got Ref
		//IL_0224: Expected F4, but got I4
		//IL_015e: Expected O, but got Ref
		//IL_02f9: Invalid comparison between I4 and F4
		//IL_012a: Expected F4, but got I4
		//IL_00d4: Expected O, but got Ref
		ref int lastMinutes = default(ref int);
		ref int lastSeconds = default(ref int);
		bool useSpeedrunModifier = default(bool);
		UpdateTimer(MyTime.runTimer, t_timerRun, useClock: true, ref lastMinutes, ref lastSeconds, useSpeedrunModifier);
		if (!(EnemyManager.Instance != null))
		{
			return;
		}
		EnemyManager instance = EnemyManager.Instance;
		if (!instance.enabledWaves)
		{
			return;
		}
		GameManager instance2 = GameManager.Instance;
		object obj = default(object);
		float num;
		bool useClock;
		if (!instance2._003CisCrypt_003Ek__BackingField)
		{
			bool flag = EnemyManager.Instance.IsFinalSwarm();
			if (!flag)
			{
				if (~(isRed ? 1u : 0u) == 0)
				{
					isRed = flag;
					t_timerStage.color = (Color)(&obj);
				}
				float stageTimeMax = GameManager.Instance.GetStageTimeMax();
				num = stageTimeMax - MyTime.stageTimer;
				if (!(0f > num))
				{
					if (num > stageTimeMax)
					{
						useClock = false;
						num = stageTimeMax;
						goto IL_031b;
					}
				}
				else
				{
					num = 0f;
				}
				useClock = false;
			}
			else
			{
				if (!isRed)
				{
					isRed = true;
					t_timerStage.color = (Color)(&obj);
				}
				num = MyTime.finalSwarmTimer;
				useClock = false;
			}
		}
		else
		{
			if (!instance2._003CisDungeonTimerStarted_003Ek__BackingField)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v535 @ rax_v24+B8]");
				object text = 0;
				t_timerStage.text = (string)text;
				return;
			}
			if (!isRed)
			{
				isRed = true;
				t_timerStage.color = (Color)(&obj);
				t_timerStage.fontSize = 50f;
			}
			GameManager instance3 = GameManager.Instance;
			num = instance3._003CdungeonTimeToComplete_003Ek__BackingField - MyTime.cryptTimer;
			if (!(0f > num))
			{
				if (num > instance3._003CdungeonTimeToComplete_003Ek__BackingField)
				{
					num = instance3._003CdungeonTimeToComplete_003Ek__BackingField;
				}
			}
			else
			{
				num = 0f;
			}
			useClock = true;
		}
		goto IL_031b;
		IL_031b:
		UpdateTimer(num, t_timerStage, useClock, ref lastMinutes, ref lastSeconds, useSpeedrunModifier);
		GameManager instance4 = GameManager.Instance;
		if (!instance4._003CisCrypt_003Ek__BackingField)
		{
			TMP_Text tMP_Text = t_timerStage;
			if (tMP_Text.m_fontSize > fontSizeDefault)
			{
				tMP_Text.fontSize = fontSizeDefault;
			}
		}
	}

	private float GetForcedTime()
	{
		//IL_003a: Expected O, but got I4
		//IL_0043: Expected O, but got I4
		//IL_00ac: Expected I, but got O
		//IL_00b4: Expected I, but got O
		//IL_00c4: Expected O, but got I
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		//IL_0100: Expected O, but got I
		//IL_01d1: Invalid comparison between I4 and F4
		//IL_01e0: Expected F4, but got I4
		if (ChallengesTracker.HasChallengeModifier("speedrun"))
		{
			ChallengeModifier[] challengeModifiers = ChallengesTracker.challengeModifiers;
			object obj = 0;
			object obj2 = 0;
			while ((nint)obj2 < challengeModifiers.Length)
			{
				ChallengeModifier challengeModifier = challengeModifiers[obj];
				if (!(challengeModifier.internalName == "speedrun"))
				{
					obj++;
					obj2 = obj;
					continue;
				}
				nint num = (nint)typeof(ChallengeModifierSpeedrun);
				nint num2 = (nint)challengeModifier;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rdx_v7 (Il2CppClass<ChallengeModifierSpeedrun>)+130]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ r8_v6 (Il2CppClass<ChallengeModifier>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rdx_v7 (Il2CppClass<ChallengeModifierSpeedrun>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ r8_v6 (Il2CppClass<ChallengeModifier>)+C8]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v290 @ rax_v19+FFFFFFF8+v276 @ rax_v16*8]");
					if (0 == (nint)typeof(ChallengeModifierSpeedrun))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rsi_v6 (ChallengeModifier)+28]");
						float num4 = 0f * 60f;
						float num5 = num4 - MyTime.runTimer;
						bool flag = 0f > num5;
						float result = 0f;
						if (!flag)
						{
							result = num5;
						}
						return result;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				throw new IndexOutOfRangeException();
			}
		}
		return -1f;
	}

	private unsafe void UpdateTimer(float time, TextMeshProUGUI textMesh, bool useClock, ref int lastMinutes, ref int lastSeconds, bool useSpeedrunModifier)
	{
		//IL_0059: Expected I, but got O
		//IL_021d: Invalid comparison between F4 and I4
		//IL_007d: Expected O, but got I4
		//IL_008b: Expected O, but got I4
		//IL_03a7: Expected I, but got O
		//IL_0291: Invalid comparison between O and F8
		//IL_00a1: Expected F8, but got O
		//IL_02cc: Expected O, but got F8
		//IL_02d4: Expected O, but got F8
		//IL_00bc: Expected O, but got I
		//IL_02b0: Invalid comparison between O and F8
		//IL_0105: Expected I, but got O
		//IL_0109: Expected native int or pointer, but got F8
		//IL_0112: Expected O, but got F8
		//IL_0122: Expected O, but got I
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected O, but got Unknown
		//IL_03f6: Invalid comparison between I4 and F4
		//IL_040d: Expected I, but got O
		//IL_01f3: Expected F4, but got I4
		//IL_0201: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172F34]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag = ChallengesTracker.HasChallengeModifier("speedrun");
		bool flag2 = !flag;
		TextMeshProUGUI textMeshProUGUI = textMesh;
		nint num = unchecked((nint)null);
		double num2;
		if (!flag2)
		{
			ChallengeModifier[] challengeModifiers = ChallengesTracker.challengeModifiers;
			textMeshProUGUI = textMesh;
			object obj = 0;
			string text = null;
			object obj2 = 0;
			while (true)
			{
				bool flag3 = (nint)obj2 >= challengeModifiers.Length;
				num = (nint)text;
				if (flag3)
				{
					break;
				}
				num2 = (double)challengeModifiers[obj];
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rdi_v10 (System.Double)+18]");
				if (!((string)0 == "speedrun"))
				{
					obj++;
					textMeshProUGUI = null;
					text = "speedrun";
					obj2 = obj;
					continue;
				}
				goto IL_00f7;
			}
		}
		float num3 = -1f;
		goto IL_041b;
		IL_00f7:
		nint num4 = (nint)typeof(ChallengeModifierSpeedrun);
		textMeshProUGUI = (TextMeshProUGUI)((double*)(nint)num2)->m_value;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rdx_v19 (Il2CppClass<ChallengeModifierSpeedrun>)+130]");
		object obj3 = 0;
		Material[] fontSharedMaterials = ((TMP_Text)textMeshProUGUI).m_fontSharedMaterials;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rdx_v19 (Il2CppClass<ChallengeModifierSpeedrun>)+130]");
		bool flag4 = (nint)fontSharedMaterials < 0;
		bool flag5 = false;
		float num5 = 60f;
		object obj5 = default(object);
		object obj4 = obj5;
		double num7 = default(double);
		double num6 = num7;
		object obj7 = default(object);
		object obj6 = obj7;
		if (!flag4)
		{
			MaskableGraphic.CullStateChangedEvent onCullStateChanged = ((MaskableGraphic)textMeshProUGUI).m_OnCullStateChanged;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v43 (UnityEngine.UI.MaskableGraphic+CullStateChangedEvent)+FFFFFFF8+v547 @ rax_v42*8]");
			bool flag6 = 0 != (nint)typeof(ChallengeModifierSpeedrun);
			flag5 = useClock;
			double num8 = default(double);
			num7 = num8;
			num5 = time;
			obj4 = textMeshProUGUI;
			num6 = num2;
			obj6 = typeof(ChallengeModifierSpeedrun);
			if (!flag6)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rdi_v10 (System.Double)+28]");
				float num9 = 0f * 60f;
				num3 = num9 - MyTime.runTimer;
				bool flag7 = !(0f > num3);
				num = (nint)typeof(ChallengeModifierSpeedrun);
				if (!flag7)
				{
					num3 = 0f;
					num = (nint)typeof(ChallengeModifierSpeedrun);
				}
				goto IL_041b;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		throw new IndexOutOfRangeException();
		IL_041b:
		object obj8 = default(object);
		bool flag8 = obj8 == null;
		float num10 = time;
		if (!flag8)
		{
			bool flag9 = num3 < 0f;
			num10 = time;
			if (!flag9)
			{
				bool flag10 = !(time > num3);
				num10 = time;
				if (!flag10)
				{
					num10 = num3;
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm6\"");
		double num11 = Math.Floor(0.0);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FFEE0");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm6\"");
		num7 = Math.Floor(0.0);
		object obj9 = default(object);
		object obj10 = default(object);
		if (obj9 != (object)num11 || obj10 != (object)num7)
		{
			obj9 = num11;
			obj10 = num7;
			string text2;
			if (!useClock)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
				object arg = default(object);
				object arg2 = default(object);
				text2 = $"{arg}:{arg2:00}";
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
				text2 = $"<size=110%><sprite name=clock></size> {obj7}:{obj5:00}";
			}
			textMesh.text = text2;
		}
	}
}
