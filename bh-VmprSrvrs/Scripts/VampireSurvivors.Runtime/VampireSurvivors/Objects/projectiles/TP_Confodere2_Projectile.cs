using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Confodere2_Projectile : Projectile
	{
		private ParticleEmitterManager _pfxManager;

		private ParticleSystem _emitter1;

		private ParticleSystem _emitter2;

		private Timer expireTimer;

		private bool _isDespawning;

		private PhaserSprite _lanceSprite;

		private Vector2 _collisionPos;

		private Vector2 _spritePos;

		private float _life;

		private Transform _cachedSpriteTransform;

		private MultiTargetTween _tween1;

		private MultiTargetTween _tween2;

		private MultiTargetTween _tween3;

		private Tween lifeTween;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		public void StartDespawn()
		{
		}

		public override void Despawn()
		{
		}

		private void MakeEmitters()
		{
		}
	}
}
