using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Valmanway_Projectile : Projectile
	{
		private Vector2 _collisionPos;

		private Vector2 _spritePos;

		private ParticleEmitterManager _pfxManager;

		private ParticleSystem _pfx;

		private uint[] _colors;

		private readonly BlendMode[] _blendModes;

		private readonly float[] _angles;

		private SoundManager.SoundConfig _soundConfig;

		private float _life;

		private Transform _cachedSpriteTransform;

		private MultiTargetTween _tween1;

		private MultiTargetTween _tween2;

		private MultiTargetTween _tween3;

		private PhaserSprite _lanceSprite;

		private MultiTargetTween _tween2b;

		private List<int> _modifiers;

		private Tween lifeTween;

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

		public override void InternalUpdate()
		{
		}

		public override void Despawn()
		{
		}
	}
}
