using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters;

public class CharacterSkillCard_B013Pugnala : CharacterSkillCard_Base
{
	public override ArcanaType GalaType => ArcanaType.SUB_XLEVEL_MIGHT1;

	public CharacterSkillCard_B013Pugnala(ArcanaType type)
		: base(type)
	{
		InitialBonus = new ModifierStats
		{
			_003CSpeed_003Ek__BackingField = 0.2f
		};
		OnEveryLevelUp = new ModifierStats
		{
			_003CPower_003Ek__BackingField = 0.01f
		};
	}
}
