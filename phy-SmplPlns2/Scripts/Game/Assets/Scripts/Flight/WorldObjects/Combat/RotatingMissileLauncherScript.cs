using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Flight.Combat;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Combat
{
	public class RotatingMissileLauncherScript : RotatingWeaponScript, ITargetLockSource
	{
		[SerializeField]
		[Tooltip("A value indicating whether or not the missile launcher has infinite ammunition.")]
		private bool _infiniteAmmo;

		private float _lastTargetBreakChance;

		private float _lastTargetEvadeChance;

		[SerializeField]
		[Tooltip("The amount of time before firing the missile at which the target receives a missile lock warning.")]
		private float _lockAlertTime;

		[SerializeField]
		[Range(0f, 180f)]
		[Tooltip("The maximum missile lock angle (in degrees), beyond which the missiles cannot acquire a lock or fire.")]
		private float _maxMissileLockAngle;

		[SerializeField]
		[Tooltip("The minimum range of the missiles. Closer than this, missiles will not fire.")]
		private float _minRange;

		[SerializeField]
		[Range(0f, 1f)]
		[Tooltip("The missile accuracy.")]
		private float _missileAccuracy;

		[SerializeField]
		[Tooltip("The fire delay for the missiles.")]
		private float _missileFireDelay;

		[SerializeField]
		[Tooltip("The maximum amount of random time to add to the missile fire delay when it is reset.")]
		private float _missileFireDelayRandomExtraTime = 0.5f;

		[SerializeField]
		[Tooltip("The maximum speed of missiles (in meters per second).")]
		private float _missileMaxSpeed = 400f;

		private List<AntiAircraftPlaceholderMissileScript> _missiles;

		[SerializeField]
		private SignatureType _signatureType = SignatureType.Radar;

		FlightScenePlayer ITargetLockSource.Player => null;

		ushort ITargetLockSource.TeamId => base.TargetingSystem.TeamId;

		protected float CurrentFireDelay { get; set; }

		protected virtual bool InfiniteAmmo => _infiniteAmmo;

		protected virtual float LockAlertTime => _lockAlertTime;

		protected virtual float MaxMissileLockAngle => _maxMissileLockAngle;

		protected virtual float MinRange => _minRange;

		protected virtual float MissileAccuracy => _missileAccuracy;

		protected virtual float MissileFireDelay => _missileFireDelay;

		protected virtual float MissileFireDelayRandomExtraTime => _missileFireDelayRandomExtraTime;

		protected virtual float MissileMaxSpeed => _missileMaxSpeed;

		protected virtual List<AntiAircraftPlaceholderMissileScript> Missiles
		{
			get
			{
				return _missiles;
			}
			set
			{
				_missiles = value;
			}
		}

		protected Transform OrphanedParticleEffectsParent { get; set; }

		protected override void FixedUpdate()
		{
			base.FixedUpdate();
			if (PauseManager.Paused || IsDisabled || Missiles.Count == 0 || !base.CanFire)
			{
				return;
			}
			if (base.CurrentTarget == null || base.CurrentTarget.Target.IsDead)
			{
				CurrentFireDelay = MissileFireDelay + UnityEngine.Random.Range(0f, MissileFireDelayRandomExtraTime);
				return;
			}
			float num = Math.Max(Math.Abs(CurrentAnglesToTarget.x), Math.Abs(CurrentAnglesToTarget.y));
			if (base.CurrentTarget.Occluded || num > MaxMissileLockAngle)
			{
				CurrentFireDelay = Mathf.Clamp(CurrentFireDelay + Time.deltaTime, 0f, MissileFireDelay + MissileFireDelayRandomExtraTime);
				return;
			}
			float num2 = 1f;
			float num3 = 0f;
			float evadeLockProbability = base.CurrentTarget.Target.GetEvadeLockProbability(_signatureType);
			float breakLockProbability = base.CurrentTarget.Target.GetBreakLockProbability(_signatureType);
			if (evadeLockProbability > _lastTargetEvadeChance || (breakLockProbability > _lastTargetBreakChance && CurrentFireDelay < LockAlertTime))
			{
				num2 = ((!(CurrentFireDelay <= 0f)) ? (num2 - evadeLockProbability) : (num2 - breakLockProbability));
				num3 = UnityEngine.Random.Range(0.1f, 1f);
			}
			if (num2 < num3)
			{
				CurrentFireDelay = Mathf.Clamp(CurrentFireDelay + Time.deltaTime, 0f, MissileFireDelay + MissileFireDelayRandomExtraTime);
				CurrentFireDelay = MissileFireDelay + UnityEngine.Random.Range(0f, MissileFireDelayRandomExtraTime);
				CurrentFireDelay += 1.5f;
			}
			else
			{
				_lastTargetEvadeChance = evadeLockProbability;
				_lastTargetBreakChance = breakLockProbability;
			}
			CurrentFireDelay -= Time.deltaTime;
			if (CurrentFireDelay <= 0f)
			{
				if ((base.CurrentAimPosition - base.transform.position).magnitude < MinRange)
				{
					CurrentFireDelay = 0f;
					return;
				}
				int index = UnityEngine.Random.Range(0, Missiles.Count - 1);
				AntiAircraftPlaceholderMissileScript antiAircraftPlaceholderMissileScript = Missiles[index];
				if (!InfiniteAmmo)
				{
					Missiles.RemoveAt(index);
				}
				AntiAircraftMissileScript antiAircraftMissileScript = antiAircraftPlaceholderMissileScript.Fire(base.CurrentTarget, OrphanedParticleEffectsParent, !InfiniteAmmo);
				antiAircraftMissileScript.LeadAccuracy = MissileAccuracy;
				antiAircraftMissileScript.MaxSpeed = MissileMaxSpeed;
				antiAircraftMissileScript.AltitudeGainTime = 0f;
				CurrentFireDelay = MissileFireDelay + UnityEngine.Random.Range(0f, MissileFireDelayRandomExtraTime);
			}
			else if (CurrentFireDelay < LockAlertTime)
			{
				base.CurrentTarget.Target.Alert(locked: false, this, base.CurrentTarget);
			}
		}

		protected override Vector3 GetTargetAimPosition()
		{
			if (base.CurrentTarget == null || base.CurrentTarget.Target.IsDead)
			{
				return Vector3.zero;
			}
			Vector3 vector = base.CurrentTarget.Target.Position;
			for (int i = 0; i < 3; i++)
			{
				float num = (vector - base.transform.position).magnitude / MissileMaxSpeed;
				vector = base.CurrentTarget.Target.Position + base.CurrentTarget.Target.Velocity * num;
			}
			return vector;
		}

		protected override void Start()
		{
			base.Start();
			Missiles = GetComponentsInChildren<AntiAircraftPlaceholderMissileScript>(includeInactive: true).ToList();
			OrphanedParticleEffectsParent = new GameObject("OrphanedParticleEffects").transform;
			OrphanedParticleEffectsParent.SetParent(base.transform, worldPositionStays: false);
			MissileDefenseBaseScript componentInParent = GetComponentInParent<MissileDefenseBaseScript>();
			if (componentInParent != null)
			{
				componentInParent.AddTurret(this);
			}
		}
	}
}
