using System.Collections.Generic;
using Assets.Scripts.Craft;
using Assets.Scripts.Flight.AI.ControlFunctions;
using Assets.Scripts.Flight.Combat;
using UnityEngine;

namespace Assets.Scripts.Flight.AI.ControlSystems
{
	public abstract class AiControlSystem
	{
		public static Dictionary<AircraftScript, AiSharedAircraftInfo> SharedAircraftInfo = new Dictionary<AircraftScript, AiSharedAircraftInfo>();

		protected AiControlFunction _currentControlFunction;

		private bool _firstFrame = true;

		public AiControlledAircraftScript AiControlledAircraft { get; private set; }

		public AiControlFunction ControlFunction => _currentControlFunction;

		public virtual bool CycleTargetingMode()
		{
			return _currentControlFunction.GetCycleTargetingMode();
		}

		public virtual float GetBrake()
		{
			return _currentControlFunction.GetBrake();
		}

		public virtual bool GetFireGuns()
		{
			if (AiControlledAircraft.IsFlightTargetDestructible)
			{
				return _currentControlFunction.GetFireGuns();
			}
			return false;
		}

		public virtual bool GetFireWeapons()
		{
			if (AiControlledAircraft.IsFlightTargetDestructible)
			{
				return _currentControlFunction.GetFireWeapons();
			}
			return false;
		}

		public virtual bool GetLaunchCountermeasures()
		{
			if (AiControlledAircraft.AiAircraftScript.TargetingSystem.CurrentWarningState == TargetingSystem.WarningState.Locked)
			{
				return true;
			}
			return false;
		}

		public virtual float GetPitch()
		{
			float pitch = _currentControlFunction.GetPitch();
			if (float.IsNaN(pitch))
			{
				return 0f;
			}
			return AiControlledAircraft.DefaultPitchSensitivityCurve.Evaluate(pitch);
		}

		public virtual float GetRoll()
		{
			return _currentControlFunction.GetRoll();
		}

		public virtual bool GetSwitchNextTarget()
		{
			return _currentControlFunction.GetSwitchNextTarget();
		}

		public virtual bool GetSwitchNextWeapon()
		{
			return _currentControlFunction.GetSwitchNextWeapon();
		}

		public virtual bool GetSwitchPrevTarget()
		{
			return _currentControlFunction.GetSwitchPrevTarget();
		}

		public virtual bool GetSwitchPrevWeapon()
		{
			return _currentControlFunction.GetSwitchPrevWeapon();
		}

		public virtual Vector3? GetTargetOverridePosition()
		{
			return _currentControlFunction.GetTargetOverridePosition();
		}

		public virtual float GetThrottle()
		{
			return _currentControlFunction.GetThrottle();
		}

		public float GetVtol()
		{
			return _currentControlFunction.GetVtol();
		}

		public virtual float GetYaw()
		{
			return _currentControlFunction.GetYaw();
		}

		public virtual void Initialize(AiControlledAircraftScript aiControlledAircraft)
		{
			AiControlledAircraft = aiControlledAircraft;
		}

		public virtual bool LandingGearDown()
		{
			return _currentControlFunction.GetLandingGearDown();
		}

		public virtual float LeadTarget()
		{
			return _currentControlFunction.GetLeadTarget();
		}

		public virtual Vector3 LeadTargetSourceVelocity()
		{
			return _currentControlFunction.LeadTargetSourceVelocity();
		}

		public virtual void OnDrawGizmos()
		{
			_currentControlFunction.OnDrawGizmos();
		}

		public virtual void OnFirstFrameLateUpdate()
		{
			_currentControlFunction.OnFirstFrameLateUpdate();
		}

		public virtual void OnFixedUpdate()
		{
			_currentControlFunction.OnFixedUpdate();
		}

		public virtual void OnLateUpdate()
		{
			_currentControlFunction.OnLateUpdate();
			if (_firstFrame)
			{
				OnFirstFrameLateUpdate();
				_firstFrame = false;
			}
		}

		public virtual void OnUpdate()
		{
			_currentControlFunction.OnUpdate();
		}

		public virtual void SwitchActiveControlFunction(AiControlFunction newFunction)
		{
			_currentControlFunction = newFunction;
			AiControlledAircraft.ResetTargetToMainTarget();
			_currentControlFunction.Initialize(this);
		}

		public virtual void Unload()
		{
		}
	}
}
