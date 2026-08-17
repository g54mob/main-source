using Cpp2ILInjected;
using VampireSurvivors.Framework.NumberTypes;

namespace VampireSurvivors.Objects.Characters;

public class FB_Bradfang : CharacterController_FirstBlood
{
	private float cooldownOffset;

	private float moveSpeedPercIncrease;

	private float speedPercIncrease;

	protected override void OnUpdate()
	{
		//IL_007b: Expected I, but got O
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		base.OnUpdate();
		nint num = (nint)this;
		float num2 = base.MaxHp();
		object obj = default(object);
		float num3 = ((CharacterController)this)._currentHp / (float)obj;
		float num4 = num3 * 100f;
		float num5 = 100f - num4;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
		float num6 = num5 * -0.005f;
		float num7 = num5 / 10f;
		cooldownOffset = num6;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
		float num8;
		if (!(num7 > 50f))
		{
			object obj2 = 50f & -2147483649L;
			bool flag = (nint)obj2 <= 2139095040;
			num8 = num7;
			if (flag)
			{
				goto IL_00f9;
			}
		}
		num8 = 50f;
		goto IL_00f9;
		IL_00f9:
		float num9 = num8 * 0.01f;
		float num10 = num8 * 0.01f;
		speedPercIncrease = num9;
		moveSpeedPercIncrease = num10;
	}

	public override float PCooldown()
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_0116: Expected F4, but got I4
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CCooldown_003Ek__BackingField;
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
		value = eggFloat._val + cooldownOffset;
		float num = eggFloat2._eggVal + eggFloat2._val;
		object obj = num & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001875DEC54h\"");
				if (num == -1f / 0f)
				{
					num = -3.4028235E+38f;
				}
				goto IL_0106;
			}
		}
		num = 3.4028235E+38f;
		goto IL_0106;
		IL_0106:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1875FFEF0");
		return 0f;
	}

	public override float PMoveSpeed()
	{
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected O, but got Unknown
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Expected O, but got Unknown
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CMoveSpeed_003Ek__BackingField;
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
		value = eggFloat._val + moveSpeedPercIncrease;
		float eggValue = default(float);
		float value2 = default(float);
		EggFloat eggFloat3 = new EggFloat(value2, eggValue);
		eggValue = eggFloat2._eggVal * MoveSpeedMultiplier;
		value2 = eggFloat2._val * MoveSpeedMultiplier;
		float num = eggFloat3._eggVal + eggFloat3._val;
		object obj = num & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001875DEDCAh\"");
				if (num == -1f / 0f)
				{
					num = -3.4028235E+38f;
				}
				goto IL_0158;
			}
		}
		num = 3.4028235E+38f;
		goto IL_0158;
		IL_0158:
		return num;
	}

	public override float PSpeed()
	{
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected O, but got Unknown
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CSpeed_003Ek__BackingField;
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
		value = eggFloat._val + speedPercIncrease;
		float num = eggFloat2._eggVal + eggFloat2._val;
		object obj = num & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001875DEED6h\"");
				if (num == -1f / 0f)
				{
					num = -3.4028235E+38f;
				}
				return num;
			}
		}
		return 3.4028235E+38f;
	}
}
