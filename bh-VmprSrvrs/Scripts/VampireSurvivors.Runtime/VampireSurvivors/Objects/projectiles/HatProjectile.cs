using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class HatProjectile : Projectile
	{
		[NonSerialized]
		public float2 PosOffset;

		private List<HatType> _hatTypes;

		public float Acceleration;

		private float _accelerationOffset;

		private Vector2 _velocity;

		private MultiTargetTween _accelTween;

		private MultiTargetTween _scaleTween;

		private bool _followOwner;

		private HatWeapon _trueWeapon;

		private HatType _hatType;

		private int _moveDownCount;

		private Timer _triggerTimer;

		private Timer _accelTimer;

		private MultiTargetTween _moveTween;

		private float _hatLayerOffset;

		private bool _shouldSpin;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void setHatStats()
		{
		}

		private void triggerHat()
		{
		}

		private void moveHatDown()
		{
		}

		private void FireHat()
		{
		}

		public override void InternalUpdate()
		{
		}

		private void LateUpdate()
		{
		}

		public override void Despawn()
		{
		}

		private void Bounce(Body b, bool up, bool down, bool left, bool right)
		{
		}

		protected override void OnHasHitAnotherPlayerObject(IDamageable other)
		{
		}

		public override void OnHasHitWallPhaser(PhaserTile tile)
		{
		}

		protected override void OnHasHitAnObject(IDamageable target)
		{
		}
	}
}
