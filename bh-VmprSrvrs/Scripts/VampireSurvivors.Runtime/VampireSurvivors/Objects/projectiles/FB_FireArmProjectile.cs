using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class FB_FireArmProjectile : Projectile
	{
		private ParticleSystem _pfx;

		private Tween _scaleTween;

		private Tween _radiusTweenX;

		private float _deltaTime;

		private const float Percentage = 0.0625f;

		private const float Radius = 0.25f;

		private const float SpeedModifier = 35f;

		private Vector3 _centralPos;

		private Vector3 _movement;

		private SpriteAnimation _anim;

		private PhaserSprite _coronaSprite;

		private MultiTargetTween _coronaTween;

		private bool _isDespawning;

		private float coronaRatio;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void StartDespawn()
		{
		}

		public override void Despawn()
		{
		}

		private void GenerateParticleSystem()
		{
		}

		protected override void OnHasHitAnObject(IDamageable target)
		{
		}
	}
}
