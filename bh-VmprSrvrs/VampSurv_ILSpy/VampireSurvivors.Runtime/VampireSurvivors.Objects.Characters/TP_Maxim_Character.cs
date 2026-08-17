using System;
using Cpp2ILInjected;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters;

public class TP_Maxim_Character : TP_Character
{
	public float bonusConst = 0.001f;

	public float bonusStats;

	public float overhealingTotal = 1f;

	private float OverhealTriggerValue = 1f;

	private Timer _overHealTimer;

	public override float PPower()
	{
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Expected O, but got Unknown
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Expected O, but got Unknown
		float num;
		if (!_isInvul && !_receivingDamage)
		{
			num = 1f;
		}
		else
		{
			float num2 = bonusStats + 1.5f;
			bool flag = !(2f > num2);
			num = 2f;
			if (!flag)
			{
				num = num2;
			}
		}
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CPower_003Ek__BackingField;
		float eggValue = default(float);
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggValue);
		eggValue = eggFloat._eggVal * num;
		value = eggFloat._val * num;
		float num3 = eggFloat2._eggVal + eggFloat2._val;
		object obj = num3 & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num3 & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018763E6E0h\"");
				if (num3 == -1f / 0f)
				{
					num3 = -3.4028235E+38f;
				}
				return num3;
			}
		}
		return 3.4028235E+38f;
	}

	public override float PSpeed()
	{
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected O, but got Unknown
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected O, but got Unknown
		PlayerModifierStats playerStats = _playerStats;
		bool flag = !(3f > bonusStats);
		float num = 3f;
		if (!flag)
		{
			num = bonusStats;
		}
		EggFloat eggFloat = playerStats._003CSpeed_003Ek__BackingField;
		float num2 = eggFloat._eggVal + eggFloat._val;
		object obj = num2 & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num2 & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018763E785h\"");
				if (num2 == -1f / 0f)
				{
					return -3.4028235E+38f + num;
				}
				goto IL_011a;
			}
		}
		num2 = 3.4028235E+38f;
		goto IL_011a;
		IL_011a:
		return num2 + num;
	}

	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
		Action<float, float> b = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAE6B0");
		Delegate obj = Delegate.Combine(((CharacterController)this)._onHpRecoveryCallback, b);
		if ((object)obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			if ((object)obj == null)
			{
				throw new InvalidCastException();
			}
		}
		((CharacterController)this)._onHpRecoveryCallback = (Action<float, float>)obj;
	}

	private void StatsUp(float value, float rawValue)
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
			bonusStats = num4;
		}
	}
}
