using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class CarnageExplosionProjectile : Projectile
	{
		[SerializeField]
		private SpriteRenderer _ScreenSprite;

		[SerializeField]
		private SpriteAnimation _ScreenSpriteAnimation;

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

		private float _totalTime;

		private CarnageWeapon _trueWeapon;

		private float _colliderRadius;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
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
