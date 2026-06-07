using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Flight.AI.ControlSystems;
using UnityEngine;

namespace Assets.Scripts.Flight.AI.ControlFunctions
{
	[RequireComponent(typeof(AiControlSystem))]
	public abstract class AiControlFunction
	{
		public bool ShowDebugInfo;

		protected AiControlledAircraftScript _aiControlledAircraft;

		protected AiControlSystem _aiControlSystem;

		protected bool _carOptimized;

		protected bool _checkLandingGear = true;

		protected bool? _pitchAsThrottle;

		protected bool? _vtolAsThrottle;

		protected bool? _yawAsTurnInput;

		public bool CarOptimized => _carOptimized;

		public abstract float GetBrake();

		public virtual bool GetCycleTargetingMode()
		{
			return false;
		}

		public abstract bool GetFireGuns();

		public abstract bool GetFireWeapons();

		public abstract bool GetLandingGearDown();

		public virtual float GetLeadTarget()
		{
			return 1f;
		}

		public abstract float GetPitch();

		public abstract float GetRoll();

		public abstract bool GetSwitchNextTarget();

		public abstract bool GetSwitchNextWeapon();

		public abstract bool GetSwitchPrevTarget();

		public abstract bool GetSwitchPrevWeapon();

		public virtual Vector3? GetTargetOverridePosition()
		{
			return null;
		}

		public abstract float GetThrottle();

		public abstract float GetVtol();

		public abstract float GetYaw();

		public virtual void Initialize(AiControlSystem aiControlSystem)
		{
			_aiControlSystem = aiControlSystem;
			_aiControlledAircraft = _aiControlSystem.AiControlledAircraft;
		}

		public virtual Vector3 LeadTargetSourceVelocity()
		{
			return _aiControlledAircraft.AiRigidbody.linearVelocity;
		}

		public virtual void OnDrawGizmos()
		{
		}

		public virtual void OnFirstFrameLateUpdate()
		{
			CarEngineScript[] componentsInChildren = _aiControlSystem.AiControlledAircraft.AiAircraftScript.GetComponentsInChildren<CarEngineScript>();
			foreach (CarEngineScript carEngineScript in componentsInChildren)
			{
				if (!_pitchAsThrottle.HasValue)
				{
					_pitchAsThrottle = carEngineScript.ThrottleActivationGroup == "0" && carEngineScript.ThrottleInput == "Pitch";
					if (_pitchAsThrottle.HasValue && _pitchAsThrottle.Value)
					{
						_carOptimized = true;
					}
				}
				if (!_vtolAsThrottle.HasValue)
				{
					_vtolAsThrottle = carEngineScript.ThrottleActivationGroup == "0" && carEngineScript.ThrottleInput == "VTOL";
					if (_vtolAsThrottle.HasValue && _vtolAsThrottle.Value)
					{
						_carOptimized = true;
					}
				}
			}
			if (!_carOptimized)
			{
				return;
			}
			ResizableWheelScript[] componentsInChildren2 = _aiControlSystem.AiControlledAircraft.AiAircraftScript.GetComponentsInChildren<ResizableWheelScript>();
			foreach (ResizableWheelScript resizableWheelScript in componentsInChildren2)
			{
				if (!_yawAsTurnInput.HasValue)
				{
					_yawAsTurnInput = resizableWheelScript.TurnActivationGroup == "0" && resizableWheelScript.TurningInput == "Yaw";
				}
			}
		}

		public virtual void OnFixedUpdate()
		{
		}

		public virtual void OnLateUpdate()
		{
		}

		public virtual void OnShowDebugInfo()
		{
		}

		public virtual void OnUpdate()
		{
			if (_aiControlledAircraft.ShowDebugInfo && ShowDebugInfo)
			{
				OnShowDebugInfo();
			}
		}

		public void RecheckLandingGearPosition()
		{
			_checkLandingGear = true;
		}
	}
}
