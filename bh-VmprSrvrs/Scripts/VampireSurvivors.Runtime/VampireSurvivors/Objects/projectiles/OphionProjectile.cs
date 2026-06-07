using UnityEngine;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class OphionProjectile : Projectile
	{
		private float _exploRadius;

		private PhaserSprite _snakeSprite;

		private MultiTargetTween _explosionTween;

		private bool _isExploding;

		private ShadowServantWeapon _trueWeaponShadowSerpant;

		private OphionWeapon _trueWeapon;

		private ParticleEmitterManager _particlesManager;

		private Circle _explosionCircle;

		private ParticleSystem _purpleEmitter1;

		private ParticleSystem _purpleEmitter2;

		private MultiTargetTween _displayScaleTween;

		private MultiTargetTween _displayScaleTween2;

		private PhaserSprite _displaySprite;

		private MultiTargetTween _snakeTween;

		private MultiTargetTween _scaleTween;

		private Timer _durationTimer;

		private MultiTargetTween _implosionTween;

		private Timer _hitboxTimer;

		public float _explo1DUration;

		public float _explo2DUration;

		public float _explo3DUration;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		protected override void OnHasHitAnObject(IDamageable target)
		{
		}

		public void Explode()
		{
		}

		public void Implode()
		{
		}

		public void Explode2()
		{
		}

		protected override void OnUpdate()
		{
		}

		public void Disable()
		{
		}

		public override void Despawn()
		{
		}
	}
}
