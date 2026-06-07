using VampireSurvivors.Data;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class OphionWeapon : Weapon
	{
		private ParticleEmitterManager _pfxEmitter;

		private GravityWell _well;

		private WeaponType _counterWeaponType;

		private ShadowServantCounterWeapon _counterWeapon;

		protected override void Awake()
		{
		}

		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void CheckArcanas()
		{
		}

		public override bool LevelUp()
		{
			return false;
		}

		protected override void OnUpdate()
		{
		}

		protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}
	}
}
