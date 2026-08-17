using VampireSurvivors.Data;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Characters;

public class SubSkillCard_OnRevive_Rosary : CharacterSkillCard_Base
{
	public SubSkillCard_OnRevive_Rosary(ArcanaType type)
		: base(type)
	{
	}

	public override void OnOwnerRevived(float percentage = 1f, bool instantRevival = false)
	{
		base.OnOwnerRevived(percentage, instantRevival);
		bool setDark = default(bool);
		GM.Core.RosaryDamage(showVfx: true, 1.8f, WeaponType.ROSARY, setDark);
	}
}
