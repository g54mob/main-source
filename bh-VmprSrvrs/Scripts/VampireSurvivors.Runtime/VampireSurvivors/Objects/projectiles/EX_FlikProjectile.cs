using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EX_FlikProjectile : Projectile
	{
		private MultiTargetTween _scaleTween;

		private MultiTargetTween _alphaTween;

		private MultiTargetTween _animTween;

		private SpriteAnimation _anims;

		private Transform _cachedSpriteTransform;

		private Vector2 _collisionPos;

		private Vector2 _spritePos;

		private float physArea;

		public float _life;

		private ParticleEmitterManager _pfxEmitterManager;

		private ParticleSystem _pfxEmitter;

		[SerializeField]
		private SpriteRenderer _lanceSprite;

		private MultiTargetTween _tween3;

		private bool _initialisedParticles;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void OnRecycle()
		{
		}

		public override void Despawn()
		{
		}

		public override void InternalUpdate()
		{
		}
	}
}
