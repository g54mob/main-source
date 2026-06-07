using System.Collections.Generic;
using Assets.Scripts.Craft.Parts.Modifiers.Weapons;
using UnityEngine;

namespace Assets.Scripts.Flight.Combat
{
	public class MissileWeaponSystem : WeaponSystem, ITargetLockSource
	{
		private MissileScript _activeMissile;

		private WeaponPart _activeWeapon;

		private List<MissileScript> _firedContinuousMissiles = new List<MissileScript>();

		private float _fireTime;

		private float _minRange;

		private WeaponFunction _mode;

		public override float MinRange => _minRange;

		FlightScenePlayer ITargetLockSource.Player => base.TargetingSystem.Aircraft.Player;

		public override Transform TargetingTransform => _activeMissile?.TargetingTransform;

		ushort ITargetLockSource.TeamId => base.TargetingSystem.Aircraft.Player?.TeamId ?? 0;

		public override WeaponFunction WeaponFunction => _mode;

		public MissileWeaponSystem(WeaponPart weaponPart, IMissile missile)
			: base(weaponPart)
		{
			_mode = missile.Function;
			_minRange = missile.MinRange;
			base.TargetingAngle = missile.MaxTargetingAngle;
		}

		public override bool CanFire(TrackedTarget trackedTarget)
		{
			return _activeMissile?.Seeker.CanFire(base.TargetingSystem, trackedTarget) ?? false;
		}

		public override WeaponPart Fire(TrackedTarget trackedTarget)
		{
			if (_time >= _fireTime && _activeWeapon != null)
			{
				_activeMissile.Fire(trackedTarget);
				if (_activeMissile.TargetingStyle == TargetingStyle.ContinuousLock)
				{
					_firedContinuousMissiles.Add(_activeMissile);
				}
				string text = _activeMissile.Seeker?.FireMessage;
				if (!string.IsNullOrEmpty(text))
				{
					ShowMessage(text);
				}
				GetNextActiveMissile();
				_activeWeapon = GetNextActiveWeapon(_activeWeapon);
				if (_activeMissile != null)
				{
					_fireTime = _time + _activeMissile.FireDelay;
				}
			}
			return _activeWeapon;
		}

		public override float GetSuitabilityForTarget(TrackedTarget trackedTarget)
		{
			MissileScript activeMissile = _activeMissile;
			if ((object)activeMissile != null && activeMissile.Seeker.GetSuitabilityForTarget(trackedTarget))
			{
				return 1f;
			}
			return 0f;
		}

		public override void OnBeforeUpdateWeaponList()
		{
			if (_activeWeapon != null && !_activeWeapon.IsActive)
			{
				GetNextActiveMissile();
			}
		}

		public override void OnDeselected()
		{
			_activeWeapon = null;
			_activeMissile = null;
		}

		public override void OnSelected()
		{
			GetNextActiveMissile();
		}

		public override void ProcessTarget(TrackedTarget trackedTarget, float deltaTime)
		{
			for (int num = _firedContinuousMissiles.Count - 1; num >= 0; num--)
			{
				MissileScript missileScript = _firedContinuousMissiles[num];
				if (missileScript.IsDestroyed)
				{
					_firedContinuousMissiles.RemoveAt(num);
				}
				else if (!missileScript.gameObject.activeInHierarchy)
				{
					_firedContinuousMissiles.RemoveAt(num);
				}
				else if (missileScript.CurrentTarget != trackedTarget)
				{
					missileScript.CurrentTarget = trackedTarget;
				}
			}
			if (_activeMissile != null)
			{
				_activeMissile.Seeker.AcquireTarget(base.TargetingSystem, trackedTarget, deltaTime);
			}
			else if (_firedContinuousMissiles.Count > 0)
			{
				_firedContinuousMissiles[0].Seeker.AcquireTarget(base.TargetingSystem, trackedTarget, deltaTime);
			}
		}

		private void GetNextActiveMissile()
		{
			_activeWeapon = null;
			_activeMissile = null;
			WeaponPart nextActiveWeapon = GetNextActiveWeapon(_activeWeapon);
			if (nextActiveWeapon != null)
			{
				_activeMissile = nextActiveWeapon.Part.GetModifier<MissileScript>();
				if (_activeMissile != null)
				{
					base.TargetingAngle = _activeMissile.MaxTargetingAngle;
					_activeWeapon = nextActiveWeapon;
				}
			}
		}
	}
}
