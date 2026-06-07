using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_HolyWhip1Smoke_Projectile : Projectile
	{
		private bool _particlesGenerated;

		private ParticleEmitterManager _particlesManager;

		private ParticleSystem _pfxEmitter;

		private Tween _timer;

		private Timer _despawnTimer;

		private float _exploRadius;

		private EmitZone _explosionCircle;

		private Tween _despawnTween;

		private PhaserSprite _animatedSprite;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void Explode(bool flashingVFX)
		{
		}

		private void TriggerDespawnTimer()
		{
		}

		private void GenerateParticleSystems()
		{
		}

		public override void Despawn()
		{
		}
	}
}
