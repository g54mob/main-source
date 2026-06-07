using System;
using DV.Simulation.Cars;
using DV.Simulation.Controllers;
using DV.Wheels;
using LocoSim.Attributes;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.RemoteControls
{
	public class RemoteControllerModule : MonoBehaviour, ILocomotiveRemoteControl
	{
		private const float CONTROL_UPDATE_SPEED = 0.1f;

		private const float MANUAL_LAP_APPLY_OFFSET = 0.15f;

		[FuseId]
		public string powerFuseId;

		private Fuse powerFuse;

		private TrainCar car;

		private BaseControlsOverrider controlsOverrider;

		private WheelslipController wheelslipController;

		private ExternalCouplingHandler couplingHandler;

		private LocomotiveRemoteController pairedLocomotiveRemote;

		private MultipleUnitStateObserver multipleUnitStateObserver;

		private float throttleStepSize;

		private float brakeStepSize;

		private float indBrakeStepSize;

		public bool IsPaired { get; private set; }

		public bool IsReadyToPair
		{
			get
			{
				if (powerFuse != null)
				{
					return powerFuse.State;
				}
				return true;
			}
		}

		public bool IsActivelyControlled
		{
			get
			{
				if (IsPaired)
				{
					return pairedLocomotiveRemote.InControl;
				}
				return false;
			}
		}

		public static event Action<bool, LocomotiveRemoteController> PairingChangedAny;

		public event Action<bool> PairingChanged;

		public void Init(TrainCar car, WheelslipController wheelslipController, BaseControlsOverrider controlsOverrider, SimulationFlow simFlow)
		{
			this.car = car;
			this.wheelslipController = wheelslipController;
			if (wheelslipController == null)
			{
				Debug.LogError("Unexpected state: wheelslipController is not set on SimController");
			}
			this.controlsOverrider = controlsOverrider;
			if (simFlow.TryGetFuse(powerFuseId, out powerFuse, canBeNull: true))
			{
				powerFuse.StateUpdated += OnPowerFuseChanged;
			}
			multipleUnitStateObserver = GetComponent<MultipleUnitStateObserver>();
			couplingHandler = GetComponent<ExternalCouplingHandler>();
			if (!couplingHandler)
			{
				couplingHandler = base.gameObject.AddComponent<ExternalCouplingHandler>();
			}
			car.OnDestroyCar += OnDestroyCar;
			throttleStepSize = CalcControlStepSize(controlsOverrider.Throttle);
			brakeStepSize = CalcControlStepSize(controlsOverrider.Brake);
			indBrakeStepSize = CalcControlStepSize(controlsOverrider.IndependentBrake);
		}

		private float CalcControlStepSize(OverridableBaseControl control)
		{
			if (control == null || !control.IsNotched)
			{
				return 0.1f;
			}
			return 1f / control.NotchCount;
		}

		private void OnDestroyCar(TrainCar obj)
		{
			if (pairedLocomotiveRemote != null)
			{
				pairedLocomotiveRemote.ExternalUnpair();
			}
			if (powerFuse != null)
			{
				powerFuse.StateUpdated -= OnPowerFuseChanged;
			}
		}

		private void OnPowerFuseChanged(bool newState)
		{
			if (!newState && IsPaired)
			{
				pairedLocomotiveRemote.ExternalUnpair();
			}
		}

		public void RemoteControllerCouple()
		{
			couplingHandler.Couple();
		}

		public void Uncouple(int selectedCoupler)
		{
			couplingHandler.Uncouple(selectedCoupler);
		}

		public bool IsCouplerInRange(float range)
		{
			return couplingHandler.IsCouplerInRange(range);
		}

		public int GetNumberOfCarsInFront()
		{
			return couplingHandler.GetNumberOfCarsInFront();
		}

		public int GetNumberOfCarsInRear()
		{
			return couplingHandler.GetNumberOfCarsInRear();
		}

		public float GetForwardSpeed()
		{
			return car.GetForwardSpeed();
		}

		public Vector3 GetPosition()
		{
			return car.transform.position;
		}

		public bool IsDerailed()
		{
			return car.derailed;
		}

		public bool IsWheelslipping(bool includeMUConnections = false)
		{
			if (includeMUConnections && multipleUnitStateObserver != null)
			{
				return multipleUnitStateObserver.AnyInChainWheelslipping;
			}
			return wheelslipController.wheelslip > 0f;
		}

		public float GetBrakeIndicatorValue()
		{
			if (car.brakeSystem.selfLappingController)
			{
				return GetTargetBrake();
			}
			return car.brakeSystem.TrainPipePressureFactor;
		}

		public float GetTargetThrottle()
		{
			return controlsOverrider.Throttle?.Value ?? 0f;
		}

		public float GetTargetBrake()
		{
			return controlsOverrider.Brake?.Value ?? 0f;
		}

		public float GetTargetIndependentBrake()
		{
			return controlsOverrider.IndependentBrake?.Value ?? 0f;
		}

		public bool IsSandOn()
		{
			return (controlsOverrider.Sander?.Value ?? 0f) > 0f;
		}

		public string GetReverserSymbol()
		{
			float num = controlsOverrider.Reverser?.Value ?? 0.5f;
			if (num == 1f)
			{
				return "F";
			}
			if (num == 0f)
			{
				return "R";
			}
			return "N";
		}

		public void PairRemoteController(LocomotiveRemoteController locomotiveRemote)
		{
			if (pairedLocomotiveRemote != null)
			{
				Debug.LogError("Trying to pair a remote controller to a locomotive which is already paired");
				return;
			}
			pairedLocomotiveRemote = locomotiveRemote;
			IsPaired = true;
			this.PairingChanged?.Invoke(obj: true);
			RemoteControllerModule.PairingChangedAny?.Invoke(arg1: true, locomotiveRemote);
		}

		public void UnpairRemoteController(LocomotiveRemoteController locomotiveRemote)
		{
			if (pairedLocomotiveRemote != locomotiveRemote)
			{
				Debug.LogError("Trying to unpair a remote controller which is not paired");
				return;
			}
			pairedLocomotiveRemote = null;
			IsPaired = false;
			this.PairingChanged?.Invoke(obj: false);
			RemoteControllerModule.PairingChangedAny?.Invoke(arg1: false, locomotiveRemote);
		}

		public void UpdateThrottle(float factor)
		{
			controlsOverrider.Throttle?.Set(controlsOverrider.Throttle.Value + factor * throttleStepSize);
		}

		public void UpdateBrake(float factor)
		{
			if (car.brakeSystem.selfLappingController)
			{
				controlsOverrider.Brake?.Set(controlsOverrider.Brake.Value + factor * brakeStepSize);
				return;
			}
			float num = ((factor == 0f) ? 0f : (Mathf.Sign(factor) * 0.15f));
			controlsOverrider.Brake?.Set(0.5f + num);
		}

		public void UpdateIndependentBrake(float factor)
		{
			controlsOverrider.IndependentBrake?.Set(controlsOverrider.IndependentBrake.Value + factor * indBrakeStepSize);
		}

		public void UpdateReverser(ToggleDirection toggle)
		{
			controlsOverrider.Reverser?.Set(GetReverserValue() + ((toggle == ToggleDirection.UP) ? 0.5f : (-0.5f)));
		}

		public float GetReverserValue()
		{
			return controlsOverrider.Reverser?.Value ?? 0.5f;
		}

		public void UpdateSand(ToggleDirection toggle)
		{
			controlsOverrider.Sander?.Set((toggle == ToggleDirection.UP) ? 1f : 0f);
		}

		public void UpdateHorn(float value)
		{
			controlsOverrider.Horn?.Set(Mathf.Abs(value));
		}

		public string GetLocoGuid()
		{
			if (!(car != null))
			{
				return "";
			}
			return car.CarGUID;
		}

		public MultipleUnitStateObserver.TemperatureState GetEngineTemperatureState(bool includeMUConnections)
		{
			if (multipleUnitStateObserver == null)
			{
				return MultipleUnitStateObserver.TemperatureState.Nominal;
			}
			if (!includeMUConnections)
			{
				return multipleUnitStateObserver.CarTemperatureState;
			}
			return multipleUnitStateObserver.MUChainTemperatureState;
		}
	}
}
