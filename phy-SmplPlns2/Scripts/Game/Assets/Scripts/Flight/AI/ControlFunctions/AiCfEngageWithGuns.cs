using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft.Parts.Modifiers.Weapons;
using Assets.Scripts.Flight.AI.ControlSystems;
using Assets.Scripts.Flight.Combat;
using Jundroo.Common.Math;
using UnityEngine;

namespace Assets.Scripts.Flight.AI.ControlFunctions
{
	public class AiCfEngageWithGuns : AiControlFunction
	{
		private enum StaleMateBreakMode
		{
			FlyAway = 0
		}

		private const float FireGunsAngle = 5f;

		private float _avgMuzzleVelocity;

		private bool _breakingStalemate;

		private float _breakingStalemateStopTime = float.MinValue;

		private int _gunCount;

		private List<GunScript> _guns;

		private bool _hasMissiles;

		private float _nextAvailableStalemateBreakTime;

		private AiCfFlyToLocation _orientToLocation;

		private float _stalemateBreakerAvailableTime;

		private float _time;

		public override float GetBrake()
		{
			return 0f;
		}

		public override bool GetFireGuns()
		{
			if (!_breakingStalemate && _gunCount > 0 && _time >= 1f && _aiControlledAircraft.DistanceToFinalTarget < 3000f && _aiControlledAircraft.AngleToTarget < 5f)
			{
				return _aiControlledAircraft.IsFlightTargetDestructible;
			}
			return false;
		}

		public override bool GetFireWeapons()
		{
			bool result = true;
			foreach (WeaponPart firedWeapon in _aiControlledAircraft.AiAircraftScript.TargetingSystem.FiredWeapons)
			{
				if (!firedWeapon.Weapon.IsDestroyed)
				{
					MissileScript missileScript = firedWeapon.Weapon as MissileScript;
					result = ((missileScript != null && !missileScript.IsLocked) ? true : false);
					break;
				}
			}
			return result;
		}

		public override bool GetLandingGearDown()
		{
			return false;
		}

		public override float GetLeadTarget()
		{
			if (_breakingStalemate)
			{
				return -20f;
			}
			if (_hasMissiles)
			{
				return 0f;
			}
			return 1f;
		}

		public override float GetPitch()
		{
			return _orientToLocation.GetPitch();
		}

		public override float GetRoll()
		{
			if (!_breakingStalemate)
			{
				return _orientToLocation.GetRoll();
			}
			return 0f - _orientToLocation.GetRoll();
		}

		public override bool GetSwitchNextTarget()
		{
			return false;
		}

		public override bool GetSwitchNextWeapon()
		{
			return false;
		}

		public override bool GetSwitchPrevTarget()
		{
			return false;
		}

		public override bool GetSwitchPrevWeapon()
		{
			return false;
		}

		public override float GetThrottle()
		{
			return 1f;
		}

		public override float GetVtol()
		{
			return 0f;
		}

		public override float GetYaw()
		{
			float result = 0f;
			if (GetFireGuns() && !_hasMissiles && _aiControlledAircraft.IsFlightTargetDestructible)
			{
				result = Mathf.Clamp(Math3d.SignedVectorAngle(Vector3.forward, new Vector3(_aiControlledAircraft.VecToTargetLocal.normalized.x, 0f, 0f), Vector3.up), -0.25f, 0.25f);
			}
			return result;
		}

		public override void Initialize(AiControlSystem aiControlSystem)
		{
			base.Initialize(aiControlSystem);
			_orientToLocation = new AiCfFlyToLocation();
			_orientToLocation.Initialize(aiControlSystem);
			if (_aiControlledAircraft.AiAircraftScript.GetComponentsInChildren<GunScript>() == null)
			{
				return;
			}
			_guns = _aiControlledAircraft.AiAircraftScript.GetComponentsInChildren<GunScript>().ToList();
			_gunCount = _guns.Count;
			float num = 0f;
			foreach (GunScript gun in _guns)
			{
				num += gun.Gun.MuzzleVelocity;
			}
			_avgMuzzleVelocity = num / (float)_guns.Count;
		}

		public override Vector3 LeadTargetSourceVelocity()
		{
			if (_hasMissiles)
			{
				return base.LeadTargetSourceVelocity();
			}
			if (_avgMuzzleVelocity > 0f)
			{
				return base.LeadTargetSourceVelocity().normalized * _avgMuzzleVelocity;
			}
			if (!_aiControlledAircraft.TargetIsPlayer)
			{
				return Vector3.zero;
			}
			return base.LeadTargetSourceVelocity();
		}

		public override void OnShowDebugInfo()
		{
			base.OnShowDebugInfo();
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			_time += Time.deltaTime;
			UpdateWeaponInfo();
			CheckForStalemate();
			_aiControlledAircraft.AiAircraftScript.TargetingSystem.AutoSelectWeapon();
		}

		private void CheckForStalemate()
		{
			if (!_breakingStalemate && Time.fixedTime > _stalemateBreakerAvailableTime && _aiControlledAircraft.AverageAngleToTarget > 30f && _aiControlledAircraft.DistanceToTarget < _aiControlledAircraft.VelocityOfAi.magnitude * 2f)
			{
				_breakingStalemate = true;
				if (_hasMissiles)
				{
					float num = _aiControlledAircraft.AiAircraftScript.TargetingSystem.SelectedWeaponSystem.MinRange / _aiControlledAircraft.VelocityOfAi.magnitude;
					_breakingStalemateStopTime = Time.fixedTime + Random.Range(num, num * 1.5f);
				}
				else
				{
					_breakingStalemateStopTime = Time.fixedTime + (float)Random.Range(8, 15);
				}
			}
			if (_breakingStalemate && Time.fixedTime > _breakingStalemateStopTime)
			{
				_breakingStalemate = false;
				_stalemateBreakerAvailableTime = Time.fixedTime + 15f;
			}
		}

		private void UpdateWeaponInfo()
		{
			if (_aiControlledAircraft.AiAircraftScript.TargetingSystem.SelectedWeaponSystem != null)
			{
				_hasMissiles = _aiControlledAircraft.AiAircraftScript.TargetingSystem.SelectedWeaponSystem.Ammo > 0;
			}
			else
			{
				_hasMissiles = false;
			}
		}
	}
}
