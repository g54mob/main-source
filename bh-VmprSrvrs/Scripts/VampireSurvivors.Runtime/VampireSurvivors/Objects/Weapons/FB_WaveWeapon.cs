using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class FB_WaveWeapon : Weapon
	{
		private float _mainCooldownTimer;

		private float _chargeCooldownTimer;

		private ParticleEmitterManager _particlesManager;

		private ParticleSystem _pfxEmitter;

		private ParticleEmitterManager _chargingParticlesManager;

		private ParticleSystem _chargingPfxEmitter;

		private PhaserSprite _chargingBall;

		private GravityWellConfig _gravityWellConfig;

		private PhaserSprite _smokeBoom;

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}

		private void GenerateParticleSystems()
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

		public Projectile CustomFireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null, bool isCharged = false)
		{
			return null;
		}

		public override void CheckArcanas()
		{
		}

		protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}
	}
}
