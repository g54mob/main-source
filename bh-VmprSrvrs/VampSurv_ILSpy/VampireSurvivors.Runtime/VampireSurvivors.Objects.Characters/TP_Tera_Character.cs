using System;
using Cpp2ILInjected;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters;

public class TP_Tera_Character : TP_Character
{
	private const float bonusConst = -0.01f;

	private float bonusStats;

	private float overhealingTotal;

	private float OverhealTriggerValue = 1f;

	private Timer _overHealTimer;

	public override float LootMult_Rosary => 2f;

	public override float PCooldown()
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CCooldown_003Ek__BackingField;
		float num = eggFloat._eggVal + eggFloat._val;
		object obj = num & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001875F3F29h\"");
				if (num == -1f / 0f)
				{
					return -3.4028235E+38f + bonusStats;
				}
				goto IL_00e7;
			}
		}
		num = 3.4028235E+38f;
		goto IL_00e7;
		IL_00e7:
		return num + bonusStats;
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
		//IL_0088: Invalid comparison between F4 and I4
		float num = rawValue - value;
		if (num < OverhealTriggerValue)
		{
			return;
		}
		float num2 = (overhealingTotal = num + overhealingTotal);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B71D10");
		float num3 = num2 * -0.01f;
		if (!(-0.4f > num3))
		{
			if (num3 > 0f)
			{
				bonusStats = 0f;
				return;
			}
		}
		else
		{
			num3 = -0.4f;
		}
		bonusStats = num3;
	}
}
