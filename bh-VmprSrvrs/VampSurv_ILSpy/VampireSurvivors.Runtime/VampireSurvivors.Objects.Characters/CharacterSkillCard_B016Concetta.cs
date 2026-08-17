using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters;

public class CharacterSkillCard_B016Concetta : CharacterSkillCard_Base
{
	public override ArcanaType GalaType => ArcanaType.SUB_XLEVEL_AREA1;

	public CharacterSkillCard_B016Concetta(ArcanaType type)
		: base(type)
	{
		InitialBonus = new ModifierStats
		{
			_003CPower_003Ek__BackingField = 0.2f
		};
		OnEveryLevelUp = new ModifierStats
		{
			_003CArea_003Ek__BackingField = 0.01f
		};
	}
}
