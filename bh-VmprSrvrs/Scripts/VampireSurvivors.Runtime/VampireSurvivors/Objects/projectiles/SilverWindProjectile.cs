using System;
using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class SilverWindProjectile : Projectile
	{
		[SerializeField]
		private TrailRenderer _trail;

		[SerializeField]
		private SpriteAnimation _anims;

		private Timer _expireTimer;

		[NonSerialized]
		private uint[] _colors;

		[NonSerialized]
		private uint[] _tints;

		[NonSerialized]
		private List<string> _particles;

		private float _fnTime;

		private bool _isInStartingPosition;

		private ParticleEmitterManager _pfxManager;

		private bool _canUpdateTrail;

		private MultiTargetTween _fadeInTween;

		private Timer _hitboxTimer;

		private ParticleSystem _pfxEmitter;

		protected virtual uint[] Colors => null;

		protected virtual uint[] Tints => null;

		protected virtual List<string> Particles => null;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void SetTarget(Transform target)
		{
		}

		private void FadeOut()
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
