using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters;

public class SubSkillCard_XLevel_Area1 : CharacterSkillCard_Base
{
	public SubSkillCard_XLevel_Area1(ArcanaType type)
		: base(type)
	{
		OnEveryLevelUp = new ModifierStats
		{
			_003CArea_003Ek__BackingField = 0.01f
		};
	}
}
