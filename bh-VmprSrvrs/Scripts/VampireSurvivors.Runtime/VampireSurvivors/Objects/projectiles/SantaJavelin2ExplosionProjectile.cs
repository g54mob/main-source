using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class SantaJavelin2ExplosionProjectile : Projectile
	{
		[SerializeField]
		private SpriteRenderer _VisibleSprite;

		private Tween _alphaTween;

		private Tween _despawnTween;

		private Tween _exploAlphaTween;

		private Tween _exploScaleTween;

		private Tween _colliderTween;

		private Transform _cachedWeaponTransform;

		private bool _particlesGenerated;

		private ParticleEmitterManager _particlesManager;

		private ParticleEmitterManager _particlesManagerLine;

		private ParticleSystem _pfxEmitter;

		private ParticleSystem _pfxEmitter2;

		private GravityWell _well;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void Explode()
		{
		}

		public override void Despawn()
		{
		}

		private void GenerateParticleSystems()
		{
		}
	}
}
