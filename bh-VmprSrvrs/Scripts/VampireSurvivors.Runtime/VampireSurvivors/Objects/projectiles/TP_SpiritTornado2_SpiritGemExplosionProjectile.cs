using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_SpiritTornado2_SpiritGemExplosionProjectile : Projectile
	{
		private ParticleEmitterManager _particlesManager;

		private ParticleSystem _pfxEmitter;

		private ParticleSystem _pfxEmitter2;

		private const float _pfxAlpha = 0.75f;

		private readonly uint[] _onEmitCustomTint;

		private readonly uint[] _onEmitCustomTint2;

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

		private void SetDominantPfx(ref ParticleSystem pfx)
		{
		}

		private void SetNonDominantPfx(ref ParticleSystem pfx)
		{
		}

		private float GetScaledPfxAlpha()
		{
			return 0f;
		}

		public override void Despawn()
		{
		}
	}
}
