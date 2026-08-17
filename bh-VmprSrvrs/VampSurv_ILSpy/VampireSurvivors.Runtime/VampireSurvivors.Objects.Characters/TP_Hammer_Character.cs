using Cpp2ILInjected;
using VampireSurvivors.Framework.NumberTypes;

namespace VampireSurvivors.Objects.Characters;

public class TP_Hammer_Character : TP_Character
{
	public override float PAmount()
	{
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected O, but got Unknown
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Expected O, but got Unknown
		float num = ((_isInvul || _receivingDamage) ? 2f : 1f);
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CAmount_003Ek__BackingField;
		float eggValue = default(float);
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggValue);
		eggValue = eggFloat._eggVal * num;
		value = eggFloat._val * num;
		float num2 = eggFloat2._eggVal + eggFloat2._val;
		object obj = num2 & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num2 & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187633CDBh\"");
				if (num2 == -1f / 0f)
				{
					num2 = -3.4028235E+38f;
				}
				return num2;
			}
		}
		return 3.4028235E+38f;
	}
}
