using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters
{
	public class SubSkillCard_AddWeapon_Flower2 : CharacterSkillCard_Base
	{
		private bool hasGivenWeapon;

		private int weaponLevel;

		public SubSkillCard_AddWeapon_Flower2(ArcanaType type)
			: base(default(ArcanaType))
		{
		}

		public override void OnOwnerLevelUp()
		{
		}
	}
}
