using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters;

public class SubSkillCard_XLevel_Reroll1 : CharacterSkillCard_Base
{
	public SubSkillCard_XLevel_Reroll1(ArcanaType type)
		: base(type)
	{
		OnEveryLevelUp = new ModifierStats
		{
			_003CReRolls_003Ek__BackingField = 1f
		};
	}
}
