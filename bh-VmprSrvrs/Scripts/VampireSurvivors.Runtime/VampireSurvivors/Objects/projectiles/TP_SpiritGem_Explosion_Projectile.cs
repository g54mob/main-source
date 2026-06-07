using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_SpiritGem_Explosion_Projectile : Projectile
	{
		private ParticleEmitterManager _particlesManager;

		private ParticleSystem _pfxEmitter;

		private ParticleSystem _pfxEmitter2;

		private uint[] _onEmitCustomTint;

		private SpriteRenderer _windowVfx;

		private SpriteAnimation _windowVfxAnimation;

		private SpriteRenderer _exploSprite;

		private Tween _scaleTween;

		private MultiTargetTween _scaleTween2;

		private const float ExplosionDuration = 500f;

		private Transform _cachedRendererTransform;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void Despawn()
		{
		}
	}
}
