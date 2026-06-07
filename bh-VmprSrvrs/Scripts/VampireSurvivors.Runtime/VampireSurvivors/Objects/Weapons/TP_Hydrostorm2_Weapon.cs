using UnityEngine;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Hydrostorm2_Weapon : TP_Hydrostorm_Weapon
	{
		[SerializeField]
		private Projectile _BoraProjectilePrefab;

		private const float BoraDamageMultiplier = 2f;

		private const float Mul = 333.33334f;

		private bool _cooldownAffectedByMovement;

		private BulletPool _boraProjectilePool;

		protected override uint RainEmitterTint1 => 0u;

		protected override uint RainEmitterTint2 => 0u;

		protected override int RainEmitterQuantity => 0;

		protected override ParticleSystem.MinMaxCurve RainEmitterAlpha => default(ParticleSystem.MinMaxCurve);

		protected override bool EnableBottleEmitters => false;

		protected override bool EnableGroundEmitters => false;

		public float BoraFallDurationMillis => 0f;

		protected override void OnStart()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		private void FireBoraProjectiles()
		{
		}

		protected override void UpdateFiringInterval()
		{
		}

		protected override void PlaySfx()
		{
		}

		public override void CheckArcanas()
		{
		}

		private bool OnBulletOverlapsEnemy_Bora(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}
	}
}
