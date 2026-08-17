using Cpp2ILInjected;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework.NumberTypes;

namespace VampireSurvivors.Objects.Characters;

public class FB_Stanley : CharacterController_FirstBlood
{
	protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
	{
		base.MakeLevelOne();
		base.SetBloodColor(16777147u);
	}

	public override float PArmor()
	{
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected O, but got Unknown
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CArmor_003Ek__BackingField;
		float num = base.PPower();
		CharacterData currentCharacterData = _currentCharacterData;
		object obj = default(object);
		double num2 = (double)obj - currentCharacterData._003Cpower_003Ek__BackingField;
		float num3 = (float)num2 * 10f;
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
		value = eggFloat._val + num3;
		float num4 = eggFloat2._eggVal + eggFloat2._val;
		object obj2 = num4 & -2147483649L;
		if ((nint)obj2 != 2139095040)
		{
			object obj3 = num4 & -2147483649L;
			if ((nint)obj3 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001875E1DBFh\"");
				if (num4 == -1f / 0f)
				{
					num4 = -3.4028235E+38f;
				}
				goto IL_0158;
			}
		}
		num4 = 3.4028235E+38f;
		goto IL_0158;
		IL_0158:
		bool flag = !(50f > num4);
		float num5 = 50f;
		if (!flag)
		{
			num5 = num4;
		}
		return num5 + ArmorManualIncrease;
	}
}
