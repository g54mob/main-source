using System;
using UnityEngine;
using UnityEngine.Serialization;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TrapanoProjectile : Projectile
	{
		[FormerlySerializedAs("_trail")]
		[SerializeField]
		private TrailRenderer _Trail;

		[NonSerialized]
		public bool _isYeeted;

		[NonSerialized]
		public float _durataMillis;

		private MultiTargetTween _angleTween;

		private Vector2 _aimVec;

		private MultiTargetTween _tween1;

		private SpriteRenderer _groundFx;

		private PhaserSprite _spikeSprite;

		private Vector2 _previousVector;

		private Timer _hitboxTimer;

		private bool _isFading;

		private Timer _expireTimer;

		private float _timeStopped;

		private const int Radius = 8;

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

		private void FadeOut()
		{
		}

		private void Yeet()
		{
		}
	}
}
