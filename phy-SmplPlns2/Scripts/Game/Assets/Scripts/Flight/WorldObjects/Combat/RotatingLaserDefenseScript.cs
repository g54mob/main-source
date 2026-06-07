using System;
using Assets.Scripts.Flight.Combat;
using Assets.Scripts.Flight.WorldObjects.Combat.Targets;
using Jundroo.Common.Extensions;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Combat
{
	public class RotatingLaserDefenseScript : RotatingWeaponScript
	{
		[SerializeField]
		[Tooltip("The laser renderer.")]
		private LineRenderer _laser;

		[SerializeField]
		[Tooltip("The maximum width of the laser right before it causes an explosion.")]
		private float _laserMaxWidth = 0.7f;

		[SerializeField]
		[Tooltip("The minimum width of the laser right after it acquires a lock.")]
		private float _laserMinWidth = 0.1f;

		[SerializeField]
		[Tooltip("The laser start point.")]
		private Transform _laserStartPoint;

		[SerializeField]
		[Range(0f, 1f)]
		[Tooltip("The percentage of the lock time that is spent 'acquiring the lock', during which the laser is not visible.")]
		private float _lockTimeAcquirePercentage = 0.25f;

		[SerializeField]
		[Tooltip("The maximum angle from the target that the turret can be pointing and still acquire a lock.")]
		private float _maxLockAngle = 5f;

		[SerializeField]
		[Tooltip("The lock time required before the laser destroys its target.")]
		private float _requiredLockTime = 3f;

		[SerializeField]
		[Tooltip("The lock time required for rockets before the laser destroys its target.")]
		private float _requiredRocketLockTime = 1f;

		protected LineRenderer Laser => _laser;

		protected float LaserMaxWidth => _laserMaxWidth;

		protected float LaserMinWidth => _laserMinWidth;

		protected Transform LaserStartPoint => _laserStartPoint;

		protected float LockedTime { get; set; }

		protected float LockTimeAcquirePercentage => _lockTimeAcquirePercentage;

		protected float MaxLockAngle => _maxLockAngle;

		protected TrackedTarget PreviousFrameTarget { get; set; }

		protected float RequiredLockTime => _requiredLockTime;

		protected float RequiredRocketLockTime => _requiredRocketLockTime;

		protected override void Awake()
		{
			base.Awake();
			_laser.enabled = false;
		}

		protected override void Start()
		{
			base.Start();
			MissileDefenseBaseScript componentInParent = GetComponentInParent<MissileDefenseBaseScript>();
			if (componentInParent != null)
			{
				componentInParent.AddTurret(this);
			}
		}

		protected override void Update()
		{
			base.Update();
			if (PauseManager.Paused)
			{
				return;
			}
			TrackedTarget previousFrameTarget = PreviousFrameTarget;
			PreviousFrameTarget = base.CurrentTarget;
			if (IsDisabled || base.CurrentTarget == null || base.CurrentTarget.Target.IsDead || base.CurrentTarget != previousFrameTarget)
			{
				LockedTime = 0f;
				_laser.enabled = false;
				return;
			}
			float num = Math.Max(Math.Abs(CurrentAnglesToTarget.x), Math.Abs(CurrentAnglesToTarget.y));
			if (base.CurrentTarget.Occluded || num > MaxLockAngle)
			{
				LockedTime = 0f;
				_laser.enabled = false;
				return;
			}
			LockedTime += Time.deltaTime;
			float num2 = ((base.CurrentTarget.Target is EnemyWeaponRocketTarget) ? RequiredRocketLockTime : RequiredLockTime);
			if (!(LockedTime > num2 * _lockTimeAcquirePercentage))
			{
				return;
			}
			_laser.enabled = true;
			_laser.SetPosition(0, LaserStartPoint.position);
			_laser.SetPosition(1, base.CurrentTarget.Target.Position);
			Color color = new Color(1f, 0f, 0f, Mathf.Lerp(0.5f, 1f, LockedTime / num2));
			float num3 = Mathf.Lerp(LaserMinWidth, LaserMaxWidth, LockedTime / num2);
			_laser.startColor = color;
			_laser.endColor = color;
			_laser.startWidth = num3;
			_laser.endWidth = num3;
			if (LockedTime >= num2)
			{
				LockedTime = 0f;
				if (!(base.CurrentTarget.Target is EnemyLaserWeaponTarget enemyLaserWeaponTarget))
				{
					this.LogError("Laser turret targeting a non-laser target.");
					return;
				}
				enemyLaserWeaponTarget.Explode();
				enemyLaserWeaponTarget.MarkAsDead();
			}
		}
	}
}
