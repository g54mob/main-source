using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EX_Gaea_Cone_Projectile : Projectile
	{
		private Vector2 _collisionPos;

		private ParticleEmitterManager _pfxManager;

		private ParticleSystem _pfx;

		private uint[] _colors;

		private readonly BlendMode[] _blendModes;

		private SoundManager.SoundConfig _soundConfig;

		private float _life;

		private Transform _cachedSpriteTransform;

		private MultiTargetTween _tween1;

		private MultiTargetTween _tween2;

		private MultiTargetTween _tween3;

		private PhaserSprite _lanceSprite;

		private Tween lifeTween;

		private Timer _hitboxTimer;

		protected virtual bool IsEvolved => false;

		public override float ProjectileSpeed => 0f;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void OnRecycle()
		{
		}

		private void FadeOut()
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void Despawn()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}
	}
}
