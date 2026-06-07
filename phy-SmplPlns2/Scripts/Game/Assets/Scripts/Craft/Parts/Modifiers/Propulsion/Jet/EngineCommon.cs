using System;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion.Jet
{
	public class EngineCommon
	{
		private bool _active;

		private bool _bypassInputControllers;

		private bool _canGimbalRoll;

		private IInputController _inputPitch;

		private IInputController _inputRoll;

		private IInputController _inputThrottle;

		private IInputController _inputYaw;

		private float _lastTargetThrottle;

		private PartModifierScript _modifier;

		private float _powerConsumption;

		private bool _recalculateGimbalAxes;

		public static float GlobalDebugThrustScale { get; set; } = 1f;

		public bool Active => _active;

		public Func<float> AfterburnerThrottle { get; set; }

		public float CurrentThrust
		{
			get
			{
				float num = 0f;
				EngineNozzleScript[] nozzles = Nozzles;
				foreach (EngineNozzleScript engineNozzleScript in nozzles)
				{
					num += engineNozzleScript.CurrentThrust;
				}
				return num;
			}
		}

		public Func<float> DistortionIntensity { get; set; }

		public float ElectricalConsumptionRate { get; set; }

		public float EngineThrottle { get; set; }

		public float FuelConsumptionRate { get; set; }

		public IFuelSource FuelSource { get; set; }

		public bool HasFuel => !(FuelSource?.IsEmpty ?? true);

		public float MaxGimbalAngle { get; }

		public float MinThrottle { get; set; }

		public EngineNozzleScript[] Nozzles { get; }

		public PartScript PartScript { get; }

		public float Pitch { get; set; }

		public bool PlayAudioWhileIdle { get; set; }

		public float Roll { get; set; }

		public bool SupportsDeactivation { get; set; } = true;

		public float ThrottleResponse { get; set; } = 20f;

		public float Yaw { get; set; }

		public EngineCommon(PartModifierScript partModifier, float maxGimbalAngle, float gimbalSpeed)
		{
			_modifier = partModifier;
			PartScript = _modifier.PartScript;
			MaxGimbalAngle = maxGimbalAngle;
			Nozzles = PartScript.gameObject.GetComponentsInChildren<EngineNozzleScript>();
			EngineNozzleScript[] nozzles = Nozzles;
			for (int i = 0; i < nozzles.Length; i++)
			{
				nozzles[i].Initialize(this, gimbalSpeed);
			}
		}

		public void FlightFixedUpdate(float nozzleThrust)
		{
			PartScript partScript = PartScript;
			if (_active != _inputThrottle.Active)
			{
				if (_inputThrottle.Active && HasFuel)
				{
					OnActivated();
				}
				else if (SupportsDeactivation)
				{
					OnDeactivated();
				}
			}
			if (!_active)
			{
				return;
			}
			if (HasFuel)
			{
				if (_recalculateGimbalAxes)
				{
					_recalculateGimbalAxes = false;
					RecalculateGimbalAxes(partScript.Aircraft.OrientedCenterOfMassRigidBodies);
				}
				UpdateInputs();
				EngineNozzleScript[] nozzles = Nozzles;
				for (int i = 0; i < nozzles.Length; i++)
				{
					nozzles[i].UpdateNozzle(nozzleThrust * GlobalDebugThrustScale, PartScript.PhysicsEnabled);
				}
				if (FuelConsumptionRate > 0f)
				{
					ConsumeFuel(Time.fixedDeltaTime);
				}
			}
			else
			{
				OnDeactivated();
			}
		}

		public void FlightUpdate()
		{
			if (!_active)
			{
				UpdateEngineThrottle(0f);
			}
			float engineThrottle = EngineThrottle;
			float afterburnerThrottle = AfterburnerThrottle?.Invoke() ?? 0f;
			float value = 0f;
			if (DistortionIntensity != null)
			{
				value = DistortionIntensity();
			}
			engineThrottle = Mathf.Clamp01(engineThrottle);
			value = Mathf.Clamp01(value);
			EngineNozzleScript[] nozzles = Nozzles;
			for (int i = 0; i < nozzles.Length; i++)
			{
				nozzles[i].FlightUpdate(engineThrottle, afterburnerThrottle, value);
			}
		}

		public void OnActivated()
		{
			if (!_active)
			{
				_active = true;
				EngineNozzleScript[] nozzles = Nozzles;
				for (int i = 0; i < nozzles.Length; i++)
				{
					nozzles[i].Activate();
				}
				UpdateInputs();
			}
		}

		public void OnCraftStructureChanged()
		{
			_recalculateGimbalAxes = true;
			EngineNozzleScript[] nozzles = Nozzles;
			for (int i = 0; i < nozzles.Length; i++)
			{
				nozzles[i].RigidBody = PartScript.Body.RigidBody;
			}
		}

		public void OnFlightPreStart()
		{
			_recalculateGimbalAxes = true;
			_inputThrottle = _modifier.GetInputController((AircraftControls x) => x.Throttle);
			_inputPitch = _modifier.GetInputController((AircraftControls x) => x.Pitch);
			_inputRoll = _modifier.GetInputController((AircraftControls x) => x.Roll);
			_inputYaw = _modifier.GetInputController((AircraftControls x) => x.Yaw);
			Type typeFromHandle = typeof(SimpleInputController);
			if (_inputThrottle.GetType() == typeFromHandle && _inputPitch.GetType() == typeFromHandle && _inputRoll.GetType() == typeFromHandle && _inputYaw.GetType() == typeFromHandle)
			{
				_bypassInputControllers = true;
			}
		}

		public void OnFlightStart()
		{
		}

		public void RecalculateGimbalAxes(Transform craftCom)
		{
			bool flag = false;
			EngineNozzleScript[] nozzles = Nozzles;
			foreach (EngineNozzleScript obj in nozzles)
			{
				obj.RecalculateGimbalAxes(craftCom);
				flag = obj.CanGimbalRoll || flag;
			}
			_canGimbalRoll = flag;
		}

		public void UpdateInputs(bool immediateThrottle = false)
		{
			bool flag = false;
			if (PartScript.EstimateOfUnderwaterPercent > 0.8f)
			{
				UpdateEngineThrottle(0f, immediateThrottle);
				flag = true;
			}
			else if (PartScript.ConnectedToMainCockpit && _inputThrottle != null)
			{
				float targetThrottle;
				if (_bypassInputControllers)
				{
					AircraftControls controls = PartScript.Aircraft.Controls;
					targetThrottle = ClampThrottle(controls.Throttle);
					if (MaxGimbalAngle > 0f)
					{
						Yaw = controls.Yaw;
						Pitch = controls.Pitch;
						Roll = controls.Roll;
					}
				}
				else
				{
					targetThrottle = ClampThrottle(_inputThrottle.Value);
					if (MaxGimbalAngle > 0f)
					{
						Yaw = _inputYaw.Value;
						Pitch = _inputPitch.Value;
						Roll = _inputRoll.Value;
					}
				}
				UpdateEngineThrottle(targetThrottle, immediateThrottle);
				flag = true;
			}
			if (!flag)
			{
				UpdateEngineThrottle(_lastTargetThrottle, immediateThrottle);
			}
		}

		private float ClampThrottle(float throttle)
		{
			if (throttle == 0f && SupportsDeactivation)
			{
				return throttle;
			}
			return Mathf.Clamp(throttle, MinThrottle, 1f);
		}

		private float ConsumeFuel(float fuelRequired, float electricityRequired)
		{
			float num = 1f;
			if (fuelRequired > 0f && fuelRequired > FuelSource.TotalFuel)
			{
				num = FuelSource.TotalFuel / fuelRequired;
			}
			FuelSource.RemoveFuel(fuelRequired * num);
			return num;
		}

		private float ConsumeFuel(float deltaTime)
		{
			float fuelRequired = deltaTime * FuelConsumptionRate;
			_powerConsumption = deltaTime * ElectricalConsumptionRate;
			float num = ConsumeFuel(fuelRequired, _powerConsumption);
			if (num < 1f)
			{
				_powerConsumption *= num;
				EngineThrottle *= num;
			}
			return num;
		}

		private void OnDeactivated()
		{
			if (_active)
			{
				_active = false;
				_powerConsumption = 0f;
				EngineNozzleScript[] nozzles = Nozzles;
				for (int i = 0; i < nozzles.Length; i++)
				{
					nozzles[i].Deactivate();
				}
			}
		}

		private void UpdateEngineThrottle(float targetThrottle, bool immediateThrottle = false)
		{
			_lastTargetThrottle = targetThrottle;
			if (immediateThrottle)
			{
				EngineThrottle = targetThrottle;
			}
			else
			{
				EngineThrottle = Utilities.StepTowards(EngineThrottle, Time.deltaTime * ThrottleResponse, targetThrottle);
			}
		}
	}
}
