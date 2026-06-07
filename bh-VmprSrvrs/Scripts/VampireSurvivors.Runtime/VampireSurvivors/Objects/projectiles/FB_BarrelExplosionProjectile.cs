using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class FB_BarrelExplosionProjectile : Projectile
	{
		[SerializeField]
		private SpriteRenderer _GroundFx;

		private bool _particlesGenerated;

		private ParticleEmitterManager _particlesManager;

		private ParticleSystem _pfxEmitter;

		private ParticleSystem _pfxEmitter2;

		private GravityWell _well;

		private Tween _timer;

		private Tween _alphaTween;

		private Tween _radiusTween;

		private Timer _despawnTimer;

		private float _radius;

		private float _exploRadius;

		private EmitZone _explosionCircle;

		private Tween _despawnTween;

		public int ExplosionsSpritesNumber;

		private List<PhaserSprite> explosionSprites;

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
	}
}
