using Cpp2ILInjected;
using VampireSurvivors.Framework.NumberTypes;

namespace VampireSurvivors.Objects.Characters;

public class FB_Sheena : CharacterController_FirstBlood
{
	public override float PCooldown()
	{
		//IL_000a: Expected I, but got O
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected O, but got Unknown
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Expected O, but got Unknown
		PlayerModifierStats playerStats = _playerStats;
		nint num = (nint)this;
		EggFloat eggFloat = playerStats._003CCooldown_003Ek__BackingField;
		float num2 = base.PMoveSpeed();
		object obj = default(object);
		float num3 = (float)obj - 1f;
		float num4 = num3 * 0.5f;
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
		value = eggFloat._val - num4;
		float num5 = eggFloat2._eggVal + eggFloat2._val;
		object obj2 = num5 & -2147483649L;
		if ((nint)obj2 != 2139095040)
		{
			object obj3 = num5 & -2147483649L;
			if ((nint)obj3 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001875E0B07h\"");
				if (num5 == -1f / 0f)
				{
					num5 = -3.4028235E+38f;
				}
				goto IL_0133;
			}
		}
		num5 = 3.4028235E+38f;
		goto IL_0133;
		IL_0133:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1875FFEF0");
		return 0.1f;
	}
}
