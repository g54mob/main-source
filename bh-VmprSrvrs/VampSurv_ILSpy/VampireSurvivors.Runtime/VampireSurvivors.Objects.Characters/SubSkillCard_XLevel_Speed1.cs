using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters;

public class SubSkillCard_XLevel_Speed1 : CharacterSkillCard_Base
{
	public SubSkillCard_XLevel_Speed1(ArcanaType type)
		: base(type)
	{
		OnEveryLevelUp = new ModifierStats
		{
			_003CSpeed_003Ek__BackingField = 0.01f
		};
	}
}
