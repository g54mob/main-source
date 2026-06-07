using System;
using UnityEngine;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class SpellstreamProjectile : Projectile
	{
		private ParticleEmitterManager _pfxEmitter;

		private Circle _emitZone;

		private ParticleSystem _emitter1;

		private ParticleSystem _emitter2;

		private MultiTargetTween _scaleTween;

		private MultiTargetTween _speedTween;

		private Vector2 _aimVec;

		private float _setDuration;

		private Timer _durationTween;

		[NonSerialized]
		public float Deceleration;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
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
