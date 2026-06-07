using System;
using DV.MultipleUnit;
using LocoSim.Attributes;
using LocoSim.Definitions;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Cars
{
	public class MultipleUnitStateObserver : MonoBehaviour
	{
		public delegate void MUTemperatureStateChangedDelegate(TemperatureState previTemperatureState, TemperatureState currentTemperatureState);

		[Flags]
		public enum TemperatureState
		{
			Nominal = 0,
			Warning = 1,
			Critical = 2,
			WarningAndCritical = 3
		}

		[Header("optional")]
		[PortId(PortValueType.TEMPERATURE, false)]
		public string temperaturePortId;

		[SerializeField]
		private float overheatStandardThreshold = 90f;

		[SerializeField]
		private float overheatCriticalThreshold = 105f;

		protected Port temperaturePort;

		protected MultipleUnitModule multipleUnitModule;

		protected TrainCar car;

		protected ILocomotiveRemoteControl remoteControl;

		public bool IsWheelslipping { get; private set; }

		public bool AnyInChainWheelslipping { get; private set; }

		public TemperatureState CarTemperatureState { get; private set; }

		public TemperatureState MUChainTemperatureState { get; private set; }

		public event MUTemperatureStateChangedDelegate MUChainTemperatureChanged;

		public event Action<bool> MUChainWheelslippingChanged;

		private void Start()
		{
			car = GetComponentInParent<TrainCar>();
			multipleUnitModule = car.muModule;
			remoteControl = GetComponentInParent<ILocomotiveRemoteControl>();
			SimulationFlow simulationFlow = TrainCar.Resolve(base.transform)?.SimController?.simFlow;
			if (simulationFlow == null)
			{
				Debug.LogError("Couldn't find simFlow, ignoring MultipleUnitStateObserver initialization!");
				return;
			}
			simulationFlow.TryGetPort(temperaturePortId, out temperaturePort, canBeNullOrEmpty: true);
			SetupListeners(on: true);
			base.enabled = PlayerManager.Car == car || (remoteControl != null && remoteControl.IsPaired);
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				if (car.adhesionController.wheelslipController.IsSome(out var value))
				{
					value.WheelslipStateChanged += OnWheelslipStateChanged;
				}
				if (multipleUnitModule != null)
				{
					MultipleUnitCable.AnyConnectionChanged += OnAnyConnectionChanged;
				}
				if (remoteControl is Component)
				{
					remoteControl.PairingChanged += OnPairingChanged;
				}
				if (temperaturePort != null)
				{
					temperaturePort.ValueUpdatedInternally += OnTemperatureUpdated;
				}
				PlayerManager.CarChanged += OnPlayerCarChanged;
			}
			else
			{
				if ((bool)car && car.adhesionController.wheelslipController.IsSome(out var value2))
				{
					value2.WheelslipStateChanged -= OnWheelslipStateChanged;
				}
				if (multipleUnitModule != null)
				{
					MultipleUnitCable.AnyConnectionChanged -= OnAnyConnectionChanged;
				}
				if (remoteControl is Component)
				{
					remoteControl.PairingChanged -= OnPairingChanged;
				}
				if (temperaturePort != null)
				{
					temperaturePort.ValueUpdatedInternally -= OnTemperatureUpdated;
				}
				PlayerManager.CarChanged -= OnPlayerCarChanged;
			}
		}

		private void OnDestroy()
		{
			SetupListeners(on: false);
		}

		private void Update()
		{
			UpdateAllAndFire();
		}

		private void OnTemperatureUpdated(float temperature)
		{
			if (temperature < overheatStandardThreshold)
			{
				CarTemperatureState = TemperatureState.Nominal;
			}
			else if (temperature < overheatCriticalThreshold)
			{
				CarTemperatureState = TemperatureState.Warning;
			}
			else
			{
				CarTemperatureState = TemperatureState.Critical;
			}
		}

		private void OnPlayerCarChanged(TrainCar car)
		{
			base.enabled = (car != null && car == this.car) || (remoteControl is Component && remoteControl.IsPaired);
		}

		private void OnPairingChanged(bool paired)
		{
			base.enabled = paired || (PlayerManager.Car != null && PlayerManager.Car == car);
		}

		private void OnAnyConnectionChanged(bool _, MultipleUnitCable __, MultipleUnitCable ___)
		{
			if (base.enabled)
			{
				UpdateAllAndFire();
			}
		}

		private void UpdateAllAndFire()
		{
			bool anyInChainWheelslipping = AnyInChainWheelslipping;
			TemperatureState mUChainTemperatureState = MUChainTemperatureState;
			MUChainTemperatureState = CarTemperatureState;
			AnyInChainWheelslipping = IsWheelslipping;
			if (multipleUnitModule.UseCable)
			{
				UpdateFront();
				UpdateRear();
			}
			if (multipleUnitModule.UseWireless)
			{
				UpdateRadio();
			}
			if (AnyInChainWheelslipping != anyInChainWheelslipping)
			{
				this.MUChainWheelslippingChanged?.Invoke(AnyInChainWheelslipping);
			}
			if (mUChainTemperatureState != MUChainTemperatureState)
			{
				this.MUChainTemperatureChanged?.Invoke(mUChainTemperatureState, MUChainTemperatureState);
			}
		}

		private void UpdateFront()
		{
			MultipleUnitModule multipleUnitModule = this.multipleUnitModule;
			MultipleUnitModule multipleUnitModule2 = (this.multipleUnitModule.FrontCable.IsConnected ? this.multipleUnitModule.FrontCable.connectedTo.muModule : null);
			bool flag = false;
			while (multipleUnitModule2 != null)
			{
				MultipleUnitModule multipleUnitModule3 = (multipleUnitModule2.FrontCable.IsConnected ? multipleUnitModule2.FrontCable.connectedTo.muModule : null);
				MultipleUnitModule multipleUnitModule4 = (multipleUnitModule2.RearCable.IsConnected ? multipleUnitModule2.RearCable.connectedTo.muModule : null);
				bool num = multipleUnitModule3 != null && multipleUnitModule3 == multipleUnitModule;
				MultipleUnitStateObserver component = multipleUnitModule2.GetComponent<MultipleUnitStateObserver>();
				if (component.IsWheelslipping)
				{
					flag = true;
				}
				MUChainTemperatureState |= component.CarTemperatureState;
				multipleUnitModule = multipleUnitModule2;
				multipleUnitModule2 = (num ? multipleUnitModule4 : multipleUnitModule3);
			}
			AnyInChainWheelslipping |= flag;
		}

		private void UpdateRear()
		{
			MultipleUnitModule multipleUnitModule = this.multipleUnitModule;
			MultipleUnitModule multipleUnitModule2 = (this.multipleUnitModule.RearCable.IsConnected ? this.multipleUnitModule.RearCable.connectedTo.muModule : null);
			bool flag = false;
			while (multipleUnitModule2 != null)
			{
				MultipleUnitModule multipleUnitModule3 = (multipleUnitModule2.FrontCable.IsConnected ? multipleUnitModule2.FrontCable.connectedTo.muModule : null);
				MultipleUnitModule multipleUnitModule4 = (multipleUnitModule2.RearCable.IsConnected ? multipleUnitModule2.RearCable.connectedTo.muModule : null);
				bool num = multipleUnitModule4 != null && multipleUnitModule4 == multipleUnitModule;
				MultipleUnitStateObserver component = multipleUnitModule2.GetComponent<MultipleUnitStateObserver>();
				if (component.IsWheelslipping)
				{
					flag = true;
				}
				MUChainTemperatureState |= component.CarTemperatureState;
				multipleUnitModule = multipleUnitModule2;
				multipleUnitModule2 = (num ? multipleUnitModule3 : multipleUnitModule4);
			}
			AnyInChainWheelslipping |= flag;
		}

		private void UpdateRadio()
		{
			bool flag = false;
			foreach (MultipleUnitModule device in multipleUnitModule.RemoteChannel.devices)
			{
				if (!(device == this) && device.TryGetComponent<MultipleUnitStateObserver>(out var component))
				{
					if (component.IsWheelslipping)
					{
						flag = true;
					}
					MUChainTemperatureState |= component.CarTemperatureState;
				}
			}
			AnyInChainWheelslipping |= flag;
		}

		private void OnWheelslipStateChanged(bool wheelslipping)
		{
			IsWheelslipping = wheelslipping;
		}
	}
}
