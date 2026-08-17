using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters;

public class SubSkillCard_XLevel_MaxHP5 : CharacterSkillCard_Base
{
	public SubSkillCard_XLevel_MaxHP5(ArcanaType type)
		: base(type)
	{
		OnEveryLevelUp = new ModifierStats
		{
			_003CMaxHp_003Ek__BackingField = 5f
		};
	}
}
