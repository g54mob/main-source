using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters
{
	public class SubSkillCard_OnDamaged_ArmorUp : CharacterSkillCard_Base
	{
		private float armorDelay;

		private float currentBonusStacks;

		public SubSkillCard_OnDamaged_ArmorUp(ArcanaType type)
			: base(default(ArcanaType))
		{
		}

		public override void OnOwnerGetDamaged(float damageAmount)
		{
		}
	}
}
