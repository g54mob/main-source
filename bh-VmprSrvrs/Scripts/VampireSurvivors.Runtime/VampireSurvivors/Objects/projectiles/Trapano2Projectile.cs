using System;
using UnityEngine;
using UnityEngine.Serialization;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class Trapano2Projectile : Projectile
	{
		[FormerlySerializedAs("_trail")]
		[SerializeField]
		private TrailRenderer _Trail;

		[SerializeField]
		private TrailRenderer _Trail2;

		[SerializeField]
		private Material _Trail2MaterialLight;

		[SerializeField]
		private Material _Trail2MaterialDark;

		[NonSerialized]
		public bool _isYeeted;

		[NonSerialized]
		public float _durataMillis;

		private Vector2 _aimVec;

		private MultiTargetTween _tween1;

		private SpriteRenderer _groundFx;

		private PhaserSprite _spikeSprite;

		private Vector2 _previousVector;

		private Timer _hitboxTimer;

		private Timer _expireTimer;

		private Trapano2Weapon _trueWeapon;

		private uint _tint;

		private float _timeStopped;

		private bool _tpDlcLoaded;

		private TP_Savrog_Weapon _unionWeapon;

		private MultiTargetTween _unionTintTween;

		private int _unionTintCounter;

		private const int RADIUS = 8;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void InitTrails()
		{
		}

		private void UpdateUnionTrails()
		{
		}

		private void DoUnionTintTween()
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

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}
	}
}
