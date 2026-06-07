using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Combat;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons.Seeker
{
	public abstract class MissileSeeker : ITargetLockSource, IMissileSeeker
	{
		private AircraftScript _aircraft;

		private float _lastBreakLockChance;

		private float _lastTargetBreakChance;

		private float _lastTargetEvadeChance;

		private float _timeUntilCanLock;

		public bool AlertTarget { get; set; }

		public virtual string FireMessage => null;

		public FlightScenePlayer Player => _aircraft.Player;

		public abstract SignatureType SignatureType { get; }

		public ushort TeamId => _aircraft.TeamId;

		protected float AntiCountermeasureDecay { get; } = 0.2f;

		protected MissileScript Missile { get; }

		protected abstract float SeekerSensitivity { get; }

		public MissileSeeker(MissileScript missile)
		{
			Missile = missile;
			_aircraft = missile.PartScript.Aircraft;
		}

		public void AcquireTarget(TargetingSystem targetingSystem, TrackedTarget trackedTarget, float deltaTime)
		{
			bool num = CanAcquireTarget(trackedTarget) && !FlightSceneScript.IsPeacefulMode;
			if (_lastTargetEvadeChance > 0f)
			{
				_lastTargetEvadeChance = Mathf.Max(0f, _lastTargetEvadeChance - deltaTime * AntiCountermeasureDecay);
			}
			if (_lastBreakLockChance > 0f)
			{
				_lastTargetBreakChance = Mathf.Max(0f, _lastTargetBreakChance - deltaTime * AntiCountermeasureDecay);
			}
			trackedTarget.IsAcquiring = false;
			if (num && !trackedTarget.Occluded && _timeUntilCanLock <= 0f)
			{
				float acquisitionRate = GetAcquisitionRate(trackedTarget);
				acquisitionRate = Mathf.Max(acquisitionRate, 0.1f);
				if (Missile.TargetingStyle == TargetingStyle.ContinuousLock)
				{
					acquisitionRate *= 1.5f;
				}
				trackedTarget.IsAcquiring = true;
				trackedTarget.LockPercentage += acquisitionRate * deltaTime;
				if (trackedTarget.LockPercentage >= 1f)
				{
					trackedTarget.IsLocked = true;
					trackedTarget.LockPercentage = 1f;
				}
				float num2 = 1f;
				float num3 = 0f;
				Target target = trackedTarget.Target;
				float evadeLockProbability = target.GetEvadeLockProbability(SignatureType);
				float breakLockProbability = target.GetBreakLockProbability(SignatureType);
				if (target != null && (evadeLockProbability > _lastTargetEvadeChance || (breakLockProbability > _lastTargetBreakChance && trackedTarget.IsLocked)))
				{
					num2 = ((!trackedTarget.IsLocked) ? (num2 - evadeLockProbability) : (num2 - breakLockProbability));
					num3 = Random.Range(0.1f, 1f);
				}
				if (num2 < num3)
				{
					if (Player.IsPrimaryLocal)
					{
						FlightSceneScript.Instance.FlightUI.ShowMessage("Target disrupted lock!");
					}
					_timeUntilCanLock = 1.5f;
					trackedTarget.LockPercentage = 0f;
				}
				else if (target != null)
				{
					_lastTargetEvadeChance = evadeLockProbability;
					_lastTargetBreakChance = breakLockProbability;
				}
				if (SignatureType == SignatureType.Radar)
				{
					trackedTarget.Target.Alert(trackedTarget.IsLocked, this, trackedTarget);
				}
			}
			else
			{
				_lastTargetEvadeChance = 0f;
				_lastTargetBreakChance = 0f;
			}
			if (!trackedTarget.IsAcquiring)
			{
				trackedTarget.LockPercentage -= deltaTime * 0.5f;
				if (trackedTarget.LockPercentage < 0f)
				{
					trackedTarget.LockPercentage = 0f;
				}
			}
			if (_timeUntilCanLock > 0f)
			{
				_timeUntilCanLock -= deltaTime;
			}
		}

		public bool CanFire(TargetingSystem targetingSystem, TrackedTarget trackedTarget)
		{
			if (trackedTarget != null && trackedTarget.IsLocked)
			{
				return !trackedTarget.Target.IsDead;
			}
			return false;
		}

		public bool GetSuitabilityForTarget(TrackedTarget trackedTarget)
		{
			return CanAcquireTarget(trackedTarget);
		}

		public bool MaintainLock()
		{
			bool flag = true;
			if (_lastBreakLockChance > 0f)
			{
				_lastTargetBreakChance = Mathf.Max(0f, _lastTargetBreakChance - Time.deltaTime * AntiCountermeasureDecay);
			}
			if (Missile.CurrentTarget != null && !Missile.CurrentTarget.Target.IsDead)
			{
				float breakLockProbability = Missile.CurrentTarget.Target.GetBreakLockProbability(SignatureType);
				float num = 1f;
				float num2 = 0f;
				if (breakLockProbability > _lastBreakLockChance && Missile.IsLocked)
				{
					num -= breakLockProbability;
					num2 = Random.Range(0.1f, 1f);
				}
				if (num < num2)
				{
					Missile.CurrentTarget = null;
					flag = false;
				}
				else
				{
					_lastBreakLockChance = breakLockProbability;
				}
			}
			if (Missile.CurrentTarget != null)
			{
				if (!Missile.CurrentTarget.Target.IsDead)
				{
					flag = (Missile.TargetingStyle == TargetingStyle.ContinuousLock && Missile.CurrentTarget.IsLocked) || Missile.TargetingStyle == TargetingStyle.StandardLock;
				}
				else
				{
					Missile.CurrentTarget = null;
					flag = false;
				}
				if (flag)
				{
					Missile.CurrentTarget.Target.Alert(locked: true, this, Missile.CurrentTarget);
				}
			}
			else
			{
				flag = false;
			}
			return flag;
		}

		protected virtual bool CanAcquireTarget(TrackedTarget trackedTarget)
		{
			if (trackedTarget != null && !trackedTarget.IsFriendly)
			{
				if (trackedTarget.Angle <= Missile.MaxTargetingAngle && trackedTarget.Distance >= Missile.MinRange)
				{
					return trackedTarget.Distance <= Missile.MaxRange;
				}
				return false;
			}
			return false;
		}

		protected virtual float GetAcquisitionRate(TrackedTarget trackedTarget)
		{
			return Mathf.Clamp(trackedTarget.Target.GetSignature(SignatureType) / trackedTarget.Distance * SeekerSensitivity, 0f, 2f);
		}
	}
}
