using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Elevator_Projectile : Projectile
	{
		private PhaserSprite _elevatorSprite;

		private PhaserSprite _weightSprite;

		private bool _isDespawning;

		private Timer _expireTimer;

		private Timer _hitBoxTimer;

		private List<string> FrameNames_Elevators;

		private List<string> FrameNames_Weights;

		private int repeats;

		private float tripDuration;

		private int completedTrips;

		private int directionMultiplier;

		private bool isElevator;

		private int _isRight;

		private MultiTargetTween _scaleTween;

		private float initialPosX;

		private float _speedMultiplier;

		private Tween yoyoTween;

		private float _currentProjectileSpeed;

		private Sequence _yoyoSequence;

		private Tween accelTween;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void SetTarget(Transform target)
		{
		}

		private void StartDespawn()
		{
		}

		public override void Despawn()
		{
		}

		private void LateUpdate()
		{
		}
	}
}
