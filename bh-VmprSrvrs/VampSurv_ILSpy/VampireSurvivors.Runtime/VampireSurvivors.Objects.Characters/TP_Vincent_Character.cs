using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters;

public class TP_Vincent_Character : TP_Character
{
	public float bonusConst = 0.0005f;

	public float bonusGreed;

	public float overhealingTotal = 1f;

	private float OverhealTriggerValue = 1f;

	private Timer _overHealTimer;

	public override float PGreed()
	{
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Expected O, but got Unknown
		float num = ((_isInvul || _receivingDamage) ? 2f : 1f);
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CGreed_003Ek__BackingField;
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		WickedSeason wickedSeason = arcanaManager._wickedSeason;
		float eggValue = default(float);
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggValue);
		eggValue = eggFloat._eggVal * wickedSeason._greed;
		value = eggFloat._val * wickedSeason._greed;
		float num2 = eggFloat2._eggVal + eggFloat2._val;
		object obj = num2 & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num2 & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187648C58h\"");
				if (num2 == -1f / 0f)
				{
					num2 = -3.4028235E+38f;
				}
				goto IL_01be;
			}
		}
		num2 = 3.4028235E+38f;
		goto IL_01be;
		IL_01be:
		float num3 = num2 + bonusGreed;
		return num3 * num;
	}

	public override void AfterFullInitialization()
	{
		//IL_004c: Expected O, but got I
		//IL_00a6: Expected O, but got I
		//IL_011d: Expected I4, but got O
		base.AfterFullInitialization();
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		List<System.Int32Enum> list = (List<System.Int32Enum>)(object)arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rcx_v10 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rcx_v10 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rcx_v10 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ r8_v4+18]");
		if (num >= 0)
		{
			list.AddWithResize((System.Int32Enum)15);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rcx_v10 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 15;
		}
		GameManager core2 = GM.Core;
		core2._arcanaManager.TriggerArcana(ArcanaType.T15_GOLD);
		GameManager core3 = GM.Core;
		ArcanaManager arcanaManager2 = core3._arcanaManager;
		int num2 = arcanaManager2._003CMaxArcanasPerRun_003Ek__BackingField + 1;
		arcanaManager2._003CMaxArcanasPerRun_003Ek__BackingField = num2;
		Action<float, float> action = null;
		((List<ArcanaType>)(object)action).Add((ArcanaType)this);
		Delegate obj3 = Delegate.Combine(((CharacterController)this)._onHpRecoveryCallback, action);
		if ((object)obj3 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			if ((object)obj3 == null)
			{
				throw new InvalidCastException();
			}
		}
		((CharacterController)this)._onHpRecoveryCallback = (Action<float, float>)obj3;
	}

	private void GreedUp(float value, float rawValue)
	{
		//IL_006c: Invalid comparison between I4 and F4
		//IL_007e: Expected F4, but got I4
		float num = rawValue - value;
		if (!(num < OverhealTriggerValue))
		{
			float num2 = num * bonusConst;
			float num3 = (overhealingTotal = num2 + overhealingTotal);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FD90");
			bool flag = !(0f < num3);
			float num4 = 0f;
			if (!flag)
			{
				num4 = num3;
			}
			bonusGreed = num4;
		}
	}
}
