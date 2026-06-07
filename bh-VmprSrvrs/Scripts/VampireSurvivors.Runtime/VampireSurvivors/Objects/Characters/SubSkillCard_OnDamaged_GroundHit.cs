using VampireSurvivors.Data;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters
{
	public class SubSkillCard_OnDamaged_GroundHit : CharacterSkillCard_Base
	{
		private Weapon _groundHitWeapon;

		private bool _canRetaliate;

		private float retaliationDelay;

		public SubSkillCard_OnDamaged_GroundHit(ArcanaType type)
			: base(default(ArcanaType))
		{
		}

		public override void InitialActivate()
		{
		}

		public override void OnOwnerGetDamaged(float damageAmount)
		{
		}
	}
}
