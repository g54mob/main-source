using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_GothMissile2_Projectile : Projectile
	{
		private const float Radius = 12f;

		private const float Speed = 4f;

		private const float Scale = 2f;

		private ParticleEmitterManager _pfxManager;

		private ParticleSystem _pfx;

		private MultiTargetTween _scaleTween;

		private MultiTargetTween _alphaTween;

		private PhaserSprite _missileSprite;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void UpdatePfx()
		{
		}

		public void SetAngle(float angleDeg)
		{
		}

		public override void Despawn()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}

		private void GenerateParticleSystem()
		{
		}
	}
}
