using Cpp2ILInjected;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework.NumberTypes;

namespace VampireSurvivors.Objects.Characters;

public class FB_Probo : CharacterController_FirstBlood
{
	protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
	{
		base.MakeLevelOne();
		base.SetBloodColor(16777147u);
	}

	public override float PPower()
	{
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Expected O, but got Unknown
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Expected O, but got Unknown
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CPower_003Ek__BackingField;
		EggFloat eggFloat2 = playerStats._003CArmor_003Ek__BackingField;
		CharacterData currentCharacterData = _currentCharacterData;
		float value = default(float);
		EggFloat eggFloat3 = new EggFloat(value, eggFloat2._eggVal);
		value = eggFloat2._val - currentCharacterData._003Carmor_003Ek__BackingField;
		float eggValue = default(float);
		float value2 = default(float);
		EggFloat eggFloat4 = new EggFloat(value2, eggValue);
		eggValue = eggFloat3._eggVal * 0.1f;
		value2 = eggFloat3._val * 0.1f;
		float eggValue2 = default(float);
		float value3 = default(float);
		EggFloat eggFloat5 = new EggFloat(value3, eggValue2);
		eggValue2 = eggFloat4._eggVal + eggFloat._eggVal;
		value3 = eggFloat4._val + eggFloat._val;
		float num = eggFloat5._eggVal + eggFloat5._val;
		object obj = num & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001875E09A1h\"");
				if (num == -1f / 0f)
				{
					num = -3.4028235E+38f;
				}
				goto IL_01c3;
			}
		}
		num = 3.4028235E+38f;
		goto IL_01c3;
		IL_01c3:
		return num;
	}
}
