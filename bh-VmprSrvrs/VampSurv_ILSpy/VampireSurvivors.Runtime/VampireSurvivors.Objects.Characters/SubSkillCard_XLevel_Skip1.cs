using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters;

public class SubSkillCard_XLevel_Skip1 : CharacterSkillCard_Base
{
	public SubSkillCard_XLevel_Skip1(ArcanaType type)
		: base(type)
	{
		OnEveryLevelUp = new ModifierStats
		{
			_003CSkips_003Ek__BackingField = 1f
		};
	}
}
