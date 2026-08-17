using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters;

public class SubSkillCard_XLevel_Might1 : CharacterSkillCard_Base
{
	public SubSkillCard_XLevel_Might1(ArcanaType type)
		: base(type)
	{
		OnEveryLevelUp = new ModifierStats
		{
			_003CPower_003Ek__BackingField = 0.01f
		};
	}
}
