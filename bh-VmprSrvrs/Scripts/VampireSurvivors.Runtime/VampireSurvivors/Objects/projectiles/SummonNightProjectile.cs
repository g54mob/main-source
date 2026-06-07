using UnityEngine;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class SummonNightProjectile : Projectile
	{
		private Timer _HitboxTimer;

		private Timer _ExpireTimer;

		private MultiTargetTween _ScaleTween;

		private PhaserSprite _fangSprite;

		private MultiTargetTween _fangTween;

		private ParticleEmitterManager _frontEmitterManager;

		private ParticleSystem _frontEmitter;

		private Rectangle _explosionRect;

		private ParticleEmitterManager _backEmitterManager;

		private ParticleSystem _backEmitter;

		private MultiTargetTween _fangTweenOut;

		private ParticleEmitterManager _fragmentsEmitterManager;

		private float _reach;

		private ParticleSystem _fragmentsEmitter;

		private EmitZone _emitZone;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
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
