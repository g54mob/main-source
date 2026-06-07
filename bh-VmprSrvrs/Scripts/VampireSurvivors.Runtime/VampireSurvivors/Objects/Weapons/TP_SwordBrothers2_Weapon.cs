using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_SwordBrothers2_Weapon : Weapon
	{
		[SerializeField]
		private Projectile _FiringPrefab;

		private bool _cooldownAffectedByMovement;

		private const float Mul = 166.66667f;

		private const float ExplosionDamageMultiplier = 0.3f;

		private BulletPool _explosionPool;

		public BulletPool ExplosionPool => null;

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}

		protected override void OnStart()
		{
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void ResetFiringTimer()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		private void DoBriefInvulnerability()
		{
		}

		protected override void OnDestroy()
		{
		}

		public override void Cleanup()
		{
		}

		public override void CheckArcanas()
		{
		}

		private bool OnBulletOverlapsEnemy_Explosion(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}
	}
}
