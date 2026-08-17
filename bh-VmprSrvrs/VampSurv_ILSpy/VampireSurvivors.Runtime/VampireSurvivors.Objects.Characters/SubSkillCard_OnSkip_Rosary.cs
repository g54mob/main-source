using VampireSurvivors.Data;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Characters;

public class SubSkillCard_OnSkip_Rosary : CharacterSkillCard_Base
{
	public SubSkillCard_OnSkip_Rosary(ArcanaType type)
		: base(type)
	{
	}

	public override void OnOwnerLevelUpSkipped()
	{
		base.OnOwnerLevelUpSkipped();
		bool setDark = default(bool);
		GM.Core.RosaryDamage(showVfx: true, 1.8f, WeaponType.ROSARY, setDark);
	}
}
