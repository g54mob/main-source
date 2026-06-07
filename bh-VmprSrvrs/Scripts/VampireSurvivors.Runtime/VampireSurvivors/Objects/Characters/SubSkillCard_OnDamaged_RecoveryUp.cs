using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters
{
	public class SubSkillCard_OnDamaged_RecoveryUp : CharacterSkillCard_Base
	{
		private float bonusDelay;

		private float currentBonusStacks;

		public SubSkillCard_OnDamaged_RecoveryUp(ArcanaType type)
			: base(default(ArcanaType))
		{
		}

		public override void OnOwnerGetDamaged(float damageAmount)
		{
		}
	}
}
