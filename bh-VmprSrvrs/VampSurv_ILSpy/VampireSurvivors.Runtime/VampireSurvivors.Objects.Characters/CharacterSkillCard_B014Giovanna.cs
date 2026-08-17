using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters;

public class CharacterSkillCard_B014Giovanna : CharacterSkillCard_Base
{
	public override ArcanaType GalaType => ArcanaType.SUB_XLEVEL_SPEED1;

	public CharacterSkillCard_B014Giovanna(ArcanaType type)
		: base(type)
	{
		InitialBonus = new ModifierStats
		{
			_003CDuration_003Ek__BackingField = 0.2f
		};
		OnEveryLevelUp = new ModifierStats
		{
			_003CSpeed_003Ek__BackingField = 0.01f
		};
	}
}
