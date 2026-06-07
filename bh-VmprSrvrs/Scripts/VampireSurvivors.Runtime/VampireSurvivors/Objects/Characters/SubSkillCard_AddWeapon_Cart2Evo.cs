using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters
{
	public class SubSkillCard_AddWeapon_Cart2Evo : CharacterSkillCard_Base
	{
		private bool hasGivenWeapon;

		private int weaponLevel;

		public SubSkillCard_AddWeapon_Cart2Evo(ArcanaType type)
			: base(default(ArcanaType))
		{
		}

		public override void OnOwnerLevelUp()
		{
		}
	}
}
