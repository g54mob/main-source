using Cpp2ILInjected;
using VampireSurvivors.Framework.NumberTypes;

namespace VampireSurvivors.Objects.Characters;

public class CharacterControllerToastie : CharacterController
{
	public override float PArmor()
	{
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected O, but got Unknown
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CArmor_003Ek__BackingField;
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
		value = eggFloat._val + ArmorManualIncrease;
		float num = eggFloat2._eggVal + eggFloat2._val;
		object obj = num & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001875C4E56h\"");
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
