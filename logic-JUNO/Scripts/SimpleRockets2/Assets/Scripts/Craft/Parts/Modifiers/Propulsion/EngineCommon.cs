using System;
using Assets.Scripts.Flight.Sim;
using ModApi;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Input;
using ModApi.Flight;
using ModApi.Scripts.State.Validation;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion
{
	public class EngineCommon
	{
		private bool _active;

		private LoopingAudioScript _audio;

		private IFuelSource _battery;

		private bool _bypassInputControllers;

		private bool _canGimbalRoll;

		private IInputController _inputPitch;

		private IInputController _inputRoll;

		private IInputController _inputThrottle;

		private IInputController _inputYaw;

		private float _lastTargetThrottle;

		private float _loopingAudioPitch = 1f;

		private PartModifierScript _modifier;

		private float _powerConsumption;

		private bool _recalculateGimbalAxes;

		public static float GlobalDebugThrustScale { get; set; } = 1f;

		public bool Active => _active;

		public LoopingAudioScript Audio => _audio;

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

		public Func<float> ExhaustThrottleOverride { get; set; }

		public float FuelConsumptionRate { get; set; }

		public IFuelSource FuelSource { get; set; }

		public bool HasFuel
		{
			get
			{
				bool flag = !(FuelSource?.IsEmpty ?? true);
				if (RequiresElectricity)
				{
					bool num = flag;
					IFuelSource battery = _battery;
					flag = num & (battery == null || !battery.IsEmpty);
				}
				return flag | Game.InfiniteFuelEnabled;
			}
		}

		public float MaxGimbalAngle { get; }

		public float MinThrottle { get; set; }

		public EngineNozzleScript[] Nozzles { get; }

		public IPartScript PartScript { get; }

		public float Pitch { get; set; }

		public bool PlayAudioWhileIdle { get; set; }

		public bool RequiresElectricity { get; set; }

		public float Roll { get; set; }

		public bool SupportsDeactivation { get; set; } = true;

		public float ThrottleResponse { get; set; } = 20f;

		public float Yaw { get; set; }

		public EngineCommon(PartModifierScript partModifier, float maxGimbalAngle, float gimbalSpeed)
		{
			_modifier = partModifier;
			PartScript = _modifier.PartScript;
			MaxGimbalAngle = maxGimbalAngle;
			Nozzles = PartScript.GameObject.GetComponentsInChildren<EngineNozzleScript>();
			EngineNozzleScript[] nozzles = Nozzles;
			foreach (EngineNozzleScript obj in nozzles)
			{
				obj.Initialize(this);
				obj.GimbalSpeed = gimbalSpeed;
			}
		}

		public void FlightFixedUpdate(float nozzleThrust, float maxTorque)
		{
			IPartScript partScript = PartScript;
			if (_active != partScript.Data.Activated)
			{
				if (partScript.Data.Activated && HasFuel)
				{
					if (partScript.CraftScript.IsPhysicsEnabled)
					{
						OnActivated();
					}
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
			if (HasFuel && partScript.CraftScript.IsPhysicsEnabled)
			{
				if (_recalculateGimbalAxes)
				{
					_recalculateGimbalAxes = false;
					RecalculateGimbalAxes(partScript.CraftScript.CenterOfMass);
				}
				UpdateInputs();
				EngineNozzleScript[] nozzles = Nozzles;
				for (int i = 0; i < nozzles.Length; i++)
				{
					nozzles[i].UpdateNozzle(nozzleThrust * GlobalDebugThrustScale, null);
				}
				if (!_canGimbalRoll && maxTorque > 0f)
				{
					partScript.BodyScript.RigidBody.AddTorque(maxTorque * (0f - Roll) * partScript.Transform.up);
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

		public void FlightUpdate(float smokeOpacity = 1f, float throttleAdjustment = 1f, float expansionSize = 1f)
		{
			if (!_active)
			{
				UpdateEngineThrottle(0f);
			}
			float num = ((throttleAdjustment == 1f) ? EngineThrottle : throttleAdjustment);
			float targetVolume = 0f;
			if (num > 0f || (PlayAudioWhileIdle && _active))
			{
				_loopingAudioPitch = Mathf.Lerp(0.5f, 1.25f, num);
				targetVolume = Mathf.Lerp(0.2f, 1f, num);
			}
			_audio.UpdateLoopAudio(targetVolume, _loopingAudioPitch);
			float value = num;
			if (ExhaustThrottleOverride != null)
			{
				value = ExhaustThrottleOverride();
			}
			float value2 = 0f;
			if (DistortionIntensity != null)
			{
				value2 = DistortionIntensity();
			}
			value = Mathf.Clamp01(value);
			value2 = Mathf.Clamp01(value2);
			smokeOpacity *= Mathf.Clamp01((PartScript.CraftScript.AtmosphereSample.AirDensity - 0.001f) * 10f);
			float light = Mathf.Clamp01((float)PartScript.CraftScript.FlightData.SolarRadiationIntensity + 0.05f);
			EngineNozzleScript[] nozzles = Nozzles;
			for (int i = 0; i < nozzles.Length; i++)
			{
				nozzles[i].FlightUpdate(value, value2, PartScript.BodyScript.SurfaceVelocity, smokeOpacity, light, expansionSize);
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
				((CraftScript)PartScript.CraftScript).OnEngineActivationStatusChanged(activated: true);
			}
		}

		public void OnCraftStructureChanged(ICraftScript craftScript)
		{
			_battery = PartScript.BatteryFuelSource;
			_recalculateGimbalAxes = true;
			EngineNozzleScript[] nozzles = Nozzles;
			for (int i = 0; i < nozzles.Length; i++)
			{
				nozzles[i].RigidBody = PartScript.BodyScript.RigidBody;
			}
		}

		public void OnFlightStart()
		{
			_recalculateGimbalAxes = true;
			_audio = PartScript.GameObject.GetComponentInChildren<LoopingAudioScript>(includeInactive: true);
			_audio.Initialize();
			_inputThrottle = _modifier.GetInputController((CraftControls x) => x.Throttle);
			_inputPitch = _modifier.GetInputController((CraftControls x) => x.Pitch);
			_inputRoll = _modifier.GetInputController((CraftControls x) => x.Roll);
			_inputYaw = _modifier.GetInputController((CraftControls x) => x.Yaw);
			Type typeFromHandle = typeof(SimpleInputController);
			if (_inputThrottle.GetType() == typeFromHandle && _inputPitch.GetType() == typeFromHandle && _inputRoll.GetType() == typeFromHandle && _inputYaw.GetType() == typeFromHandle)
			{
				_bypassInputControllers = true;
			}
		}

		public void OnTimeMultiplierModeChanged(TimeMultiplierModeChangedEvent e)
		{
			EngineNozzleScript[] nozzles = Nozzles;
			for (int i = 0; i < nozzles.Length; i++)
			{
				nozzles[i].OnTimeMultiplierModeChanged(e);
			}
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
			ICommandPod commandPod = PartScript.CommandPod;
			if (commandPod != null && _inputThrottle != null && !PartScript.Disconnected)
			{
				float targetThrottle;
				if (_bypassInputControllers)
				{
					CraftControls controls = commandPod.Controls;
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

		public void ValidatePart(ValidationResult result)
		{
			result.ValidatFuel(_modifier, FuelSource);
			if (RequiresElectricity)
			{
				result.ValidatFuel(_modifier, PartScript.BatteryFuelSource, _powerConsumption);
			}
		}

		public void WarpBurn(float nozzleThrust, float deltaTime, CraftNode craftNode)
		{
			float num = ConsumeFuel(deltaTime);
			Yaw = 0f;
			Pitch = 0f;
			Roll = 0f;
			EngineNozzleScript[] nozzles = Nozzles;
			for (int i = 0; i < nozzles.Length; i++)
			{
				nozzles[i].UpdateNozzle(nozzleThrust * num, craftNode);
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
			if (fuelRequired > 0f && (double)fuelRequired > FuelSource.TotalFuel)
			{
				num = (float)(FuelSource.TotalFuel / (double)fuelRequired);
			}
			if (electricityRequired > 0f)
			{
				if ((double)electricityRequired > _battery.TotalFuel)
				{
					float b = (float)(_battery.TotalFuel / (double)electricityRequired);
					num = Mathf.Min(num, b);
				}
				_battery.RemoveFuel(electricityRequired * num);
			}
			else if (electricityRequired < 0f)
			{
				_battery.AddFuel(0f - electricityRequired);
			}
			FuelSource.RemoveFuel(fuelRequired * num);
			return num;
		}

		private float ConsumeFuel(float deltaTime)
		{
			float fuelRequired = deltaTime * FuelConsumptionRate;
			_powerConsumption = deltaTime * ElectricalConsumptionRate;
			float num = ConsumeFuel(fuelRequired, _powerConsumption);
			if (Game.InfiniteFuelEnabled)
			{
				num = 1f;
			}
			else if (num < 1f)
			{
				_powerConsumption *= num;
				EngineThrottle *= num;
			}
			return num;
		}

		private void OnDeactivated()
		{
			if (!_active)
			{
				return;
			}
			_active = false;
			_powerConsumption = 0f;
			EngineNozzleScript[] nozzles = Nozzles;
			foreach (EngineNozzleScript engineNozzleScript in nozzles)
			{
				engineNozzleScript.Deactivate();
				if (!PartScript.CraftScript.IsPhysicsEnabled)
				{
					engineNozzleScript.DisableSmokeParticleSystem();
				}
			}
			((CraftScript)PartScript.CraftScript).OnEngineActivationStatusChanged(activated: false);
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
