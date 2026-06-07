using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters
{
	public class SubSkillCard_OnDamaged_AddCoin : CharacterSkillCard_Base
	{
		private bool _canRetaliate;

		private float retaliationDelay;

		public SubSkillCard_OnDamaged_AddCoin(ArcanaType type)
			: base(default(ArcanaType))
		{
		}

		public override void OnOwnerGetDamaged(float damageAmount)
		{
		}
	}
}
