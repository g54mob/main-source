using System;
using Cpp2ILInjected;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters;

public class TP_Barlowe_Character : TP_Character
{
	public float bonusConst = 0.001f;

	public float bonusStat;

	public float overhealingTotal = 1f;

	private float OverhealTriggerValue = 1f;

	private Timer _overHealTimer;

	public override float PPower()
	{
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected O, but got Unknown
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CPower_003Ek__BackingField;
		EggFloat eggFloat2 = new EggFloat(eggFloat._val, eggFloat._eggVal);
		float num = eggFloat2._eggVal + eggFloat2._val;
		object obj = num & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001875FA2BAh\"");
				if (num == -1f / 0f)
				{
					return -3.4028235E+38f + bonusStat;
				}
				goto IL_0108;
			}
		}
		num = 3.4028235E+38f;
		goto IL_0108;
		IL_0108:
		return num + bonusStat;
	}

	public override float PCurse()
	{
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CCurse_003Ek__BackingField;
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		WickedSeason wickedSeason = arcanaManager._wickedSeason;
		float eggValue = default(float);
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggValue);
		eggValue = eggFloat._eggVal * wickedSeason._curse;
		value = eggFloat._val * wickedSeason._curse;
		float num = eggFloat2._eggVal + eggFloat2._val;
		object obj = num & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001875FA42Fh\"");
				if (num == -1f / 0f)
				{
					num = -3.4028235E+38f;
				}
				goto IL_015e;
			}
		}
		num = 3.4028235E+38f;
		goto IL_015e;
		IL_015e:
		return num + bonusStat;
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
		HasFourthLevelUpOption = true;
	}

	public override WeaponType GetFourthLevelUpOption()
	{
		if ((((CharacterController)this)._level & 1) != 0)
		{
			bool flag = ((CharacterController)this)._level < 10;
			WeaponType result = WeaponType.TP_DIABOLOGUE;
			if (!flag)
			{
				result = WeaponType.VOID;
			}
			return result;
		}
		return WeaponType.VOID;
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
			bonusStat = num4;
		}
	}
}
