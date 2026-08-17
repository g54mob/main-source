using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters;

public class CharacterSkillCard_B024ZiAssunta : CharacterSkillCard_Base
{
	public override ArcanaType GalaType => ArcanaType.SUB_GOLDCOUNT_ADDPASSIVESLOTS;

	public CharacterSkillCard_B024ZiAssunta(ArcanaType type)
		: base(type)
	{
		Rarity = 2;
		InitialBonus = new ModifierStats
		{
			_003CPower_003Ek__BackingField = 0.06f,
			_003CSpeed_003Ek__BackingField = 0.06f,
			_003CDuration_003Ek__BackingField = 0.06f,
			_003CArea_003Ek__BackingField = 0.06f
		};
		OnEveryLevelUp = new ModifierStats
		{
			_003CPower_003Ek__BackingField = 0.005f,
			_003CSpeed_003Ek__BackingField = 0.005f,
			_003CDuration_003Ek__BackingField = 0.005f,
			_003CArea_003Ek__BackingField = 0.005f
		};
	}
}
