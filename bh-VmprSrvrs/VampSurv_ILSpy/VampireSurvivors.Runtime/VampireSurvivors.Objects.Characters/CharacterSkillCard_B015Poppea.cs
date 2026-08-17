using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters;

public class CharacterSkillCard_B015Poppea : CharacterSkillCard_Base
{
	public override ArcanaType GalaType => ArcanaType.SUB_XLEVEL_DURATION1;

	public CharacterSkillCard_B015Poppea(ArcanaType type)
		: base(type)
	{
		InitialBonus = new ModifierStats
		{
			_003CArea_003Ek__BackingField = 0.2f
		};
		OnEveryLevelUp = new ModifierStats
		{
			_003CDuration_003Ek__BackingField = 0.01f
		};
	}
}
