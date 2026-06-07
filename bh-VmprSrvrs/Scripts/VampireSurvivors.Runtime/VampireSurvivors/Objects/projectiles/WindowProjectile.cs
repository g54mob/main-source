using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class WindowProjectile : Projectile
	{
		private ParticleEmitterManager _particlesManager;

		private ParticleSystem _pfxEmitter;

		private ParticleSystem _pfxEmitter2;

		private GravityWell _well;

		private uint[] _onEmitCustomTint;

		private SpriteRenderer _windowVfx;

		private SpriteAnimation _windowVfxAnimation;

		private SpriteRenderer _exploSprite;

		private Tween _scaleTween;

		private MultiTargetTween _scaleTween2;

		private MultiTargetTween _exploTween;

		private Transform _cachedRendererTransform;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}
	}
}
