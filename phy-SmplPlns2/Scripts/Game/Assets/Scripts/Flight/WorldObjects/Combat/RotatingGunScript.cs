using System;
using Assets.Scripts.Craft.Parts.Modifiers.Weapons;
using Assets.Scripts.Flight.Combat.Bullets;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Combat
{
	public class RotatingGunScript : RotatingWeaponScript
	{
		[SerializeField]
		[ColorUsage(false, true)]
		[Tooltip("The color of the bullets.")]
		private Color _bulletColor = GunData.DefaultTracerColor;

		[SerializeField]
		[Tooltip("The delay between firing bullets.")]
		private float _bulletFireDelay;

		[SerializeField]
		[Tooltip("The scale applied to the bullets.")]
		private Vector3 _bulletScale = Vector3.one;

		[SerializeField]
		[Tooltip("The speed of the bullets in meters per second.")]
		private float _bulletSpeed;

		[SerializeField]
		[Tooltip("The bullet start positions.")]
		private Transform[] _bulletStartPositions;

		[SerializeField]
		[Tooltip("The angle from the current orientation to the target aim position (in degrees) at which the guns stop firing.")]
		private float _ceaseFireAngle;

		[SerializeField]
		[Range(1f, 1000f)]
		private float _gunAccuracyDecreaseFactor = 100f;

		[SerializeField]
		[Range(0f, 1f)]
		private float _gunAccuracyIncreaseFactor = 0.9f;

		[SerializeField]
		[Range(0f, 5f)]
		private float _gunAccuracyMax = 1f;

		[SerializeField]
		[Range(0f, 5f)]
		private float _gunAccuracyMin = 0.05f;

		[SerializeField]
		[Range(0f, 1f)]
		private float _gunMissPercentageDecreaseFactor = 0.9f;

		[SerializeField]
		[Range(1f, 1000f)]
		private float _gunMissPercentageIncreaseFactor = 100f;

		[SerializeField]
		[Range(0f, 1f)]
		private float _gunMissPercentageMax = 1f;

		[SerializeField]
		[Range(0f, 1f)]
		private float _gunMissPercentageMin = 0.05f;

		public Transform OverrideTarget { get; set; }

		protected virtual float BulletFireDelay => _bulletFireDelay;

		protected virtual BulletPool BulletPool { get; set; }

		protected virtual float BulletSpeed => _bulletSpeed;

		protected virtual Transform[] BulletStartPositions => _bulletStartPositions;

		protected override bool CanRotateTowardsTarget
		{
			get
			{
				if (!(OverrideTarget != null))
				{
					return base.CanRotateTowardsTarget;
				}
				return true;
			}
		}

		protected virtual float CeaseFireAngle => _ceaseFireAngle;

		protected virtual int CurrentBulletStartPositionIndex { get; set; }

		protected float CurrentFireDelay { get; set; }

		protected float GunAccuracy { get; set; }

		protected virtual float GunAccuracyDecreaseFactor => _gunAccuracyDecreaseFactor;

		protected virtual float GunAccuracyIncreaseFactor => _gunAccuracyIncreaseFactor;

		protected virtual float GunAccuracyMax => _gunAccuracyMax;

		protected virtual float GunAccuracyMin => _gunAccuracyMin;

		protected float GunMissPercentage { get; set; }

		protected virtual float GunMissPercentageDecreaseFactor => _gunMissPercentageDecreaseFactor;

		protected virtual float GunMissPercentageMax => _gunMissPercentageMax;

		protected virtual float GunMissPercentageMin => _gunMissPercentageMin;

		protected virtual float GunMissPercentageyIncreaseFactor => _gunMissPercentageIncreaseFactor;

		protected override void FixedUpdate()
		{
			if (PauseManager.Paused || IsDisabled || !base.CanFire)
			{
				return;
			}
			if (OverrideTarget == null && (base.CurrentTarget == null || base.CurrentTarget.Occluded || base.CurrentTarget.Target.IsDead))
			{
				GunMissPercentage = GunMissPercentageMax;
				GunAccuracy = GunAccuracyMax;
				CurrentFireDelay = BulletFireDelay;
				return;
			}
			CurrentFireDelay -= Time.deltaTime;
			float num = Math.Max(Math.Abs(CurrentAnglesToTarget.x), Math.Abs(CurrentAnglesToTarget.y));
			GunMissPercentage = Mathf.Clamp(GunMissPercentage + num / GunMissPercentageyIncreaseFactor * Time.deltaTime, GunMissPercentageMin, GunMissPercentageMax);
			GunAccuracy = Mathf.Clamp(GunAccuracy + num / GunAccuracyDecreaseFactor * Time.deltaTime, GunAccuracyMin, GunAccuracyMax);
			if (!(num >= CeaseFireAngle) && CurrentFireDelay <= 0f)
			{
				Transform transform = BulletStartPositions[CurrentBulletStartPositionIndex];
				Vector3 forward = transform.forward;
				Vector3 normalized = (base.CurrentAimPosition - transform.position).normalized;
				Vector3 normalized2 = Vector3.Slerp(forward, normalized, Mathf.Clamp01((3f - num) / 3f)).normalized;
				Vector3 vector = normalized2 * BulletSpeed;
				vector = Quaternion.Euler(UnityEngine.Random.Range(0f - GunAccuracy, GunAccuracy), UnityEngine.Random.Range(0f - GunAccuracy, GunAccuracy), UnityEngine.Random.Range(0f - GunAccuracy, GunAccuracy)) * vector;
				BulletPool.CreateBullet(transform.position, vector, normalized2);
				CurrentBulletStartPositionIndex++;
				if (CurrentBulletStartPositionIndex >= BulletStartPositions.Length)
				{
					CurrentBulletStartPositionIndex = 0;
				}
				CurrentFireDelay = BulletFireDelay;
				GunMissPercentage = Mathf.Clamp(GunMissPercentage * GunMissPercentageDecreaseFactor, GunMissPercentageMin, GunMissPercentageMax);
				GunAccuracy = Mathf.Clamp(GunAccuracy * GunAccuracyIncreaseFactor, GunAccuracyMin, GunAccuracyMax);
			}
		}

		protected override Vector3 GetTargetAimPosition()
		{
			if (OverrideTarget != null)
			{
				return OverrideTarget.position;
			}
			if (base.CurrentTarget == null || base.CurrentTarget.Target.IsDead)
			{
				return Vector3.zero;
			}
			Vector3 vector = base.CurrentTarget.Target.Position;
			for (int i = 0; i < 3; i++)
			{
				float num = (vector - BulletStartPositions[CurrentBulletStartPositionIndex].position).magnitude / BulletSpeed;
				vector = base.CurrentTarget.Target.Position + base.CurrentTarget.Target.Velocity * (num * (1f - GunMissPercentage));
			}
			return vector;
		}

		protected virtual void OnDestroy()
		{
			BulletPool?.Dispose();
		}

		protected override void Start()
		{
			base.Start();
			BulletData bulletData = new BulletData
			{
				Color = _bulletColor,
				Scale = _bulletScale
			};
			BulletPool = BulletPoolManager.Instance.CreatePool(bulletData);
		}
	}
}
