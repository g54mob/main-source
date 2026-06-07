using DV.Damage;
using LocoSim.Attributes;
using LocoSim.Definitions;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Brake
{
	public class CompressorSimController : MonoBehaviour
	{
		[PortId(PortType.EXTERNAL_IN, PortValueType.CONTROL, true)]
		public string activationSignalExtInPortId;

		[PortId(PortValueType.STATE, true)]
		public string productionRateOutPortId;

		[PortId(PortValueType.GENERIC, true)]
		public string mainReservoirVolumePortId;

		[PortId(PortValueType.GENERIC, true)]
		public string activationPressureThresholdPortId;

		[Header("optional")]
		[PortId(PortType.EXTERNAL_IN, PortValueType.STATE, true)]
		public string compressorHealthStatePortId;

		[PortId(PortValueType.PRESSURE, true)]
		public string mainResPressureNormalizedPortId;

		private BrakeSystem brakeSystem;

		private CarDamageModel bodyDamage;

		private Port activationSignalExtInPort;

		private Port productionRateOutPort;

		private Port compressorHealthStatePort;

		private Port mainResPressureNormalizedPort;

		public void Init(TrainCar car, SimulationFlow simFlow)
		{
			brakeSystem = car.brakeSystem;
			if (brakeSystem == null)
			{
				Debug.LogError("Unexpected state: Missing BrakeSystem. CompressorSimController can't function! Destroying self!", this);
				Object.Destroy(this);
				return;
			}
			bodyDamage = car.CarDamage;
			if (bodyDamage == null)
			{
				Debug.LogError("Unexpected state: Missing CarDamageModel. CompressorSimController can't function! Destroying self!", this);
				Object.Destroy(this);
				return;
			}
			if (!simFlow.TryGetPort(activationSignalExtInPortId, out activationSignalExtInPort) || !simFlow.TryGetPort(productionRateOutPortId, out productionRateOutPort) || !simFlow.TryGetPort(mainReservoirVolumePortId, out var port) || !simFlow.TryGetPort(activationPressureThresholdPortId, out var port2))
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: CompressorSimController isn't initialized properly! Destroying self!", this);
				Object.Destroy(this);
				return;
			}
			simFlow.TryGetPort(compressorHealthStatePortId, out compressorHealthStatePort, canBeNullOrEmpty: true);
			simFlow.TryGetPort(mainResPressureNormalizedPortId, out mainResPressureNormalizedPort, canBeNullOrEmpty: true);
			if (!brakeSystem.hasCompressor)
			{
				Debug.LogError("Unexpected state: hasCompressor is not set. CompressorSimController will be useless!", this);
			}
			brakeSystem.mainResVolume = port.Value;
			brakeSystem.compressorActivationPressure = port2.Value;
			OnProductionRateChanged(productionRateOutPort.Value);
			productionRateOutPort.ValueUpdatedInternally += OnProductionRateChanged;
			OnCompressorActivationSignalChanged(brakeSystem.compressorActivationSignal);
			brakeSystem.CompressorActivationSignalChanged += OnCompressorActivationSignalChanged;
			if (compressorHealthStatePort != null)
			{
				OnBodyHealthStateChanged();
				bodyDamage.CarEffectiveHealthStateUpdate += OnBodyHealthStateChanged;
			}
			if (mainResPressureNormalizedPort != null)
			{
				OnMainResPressureChanged(brakeSystem.MainResPressureNormalized, brakeSystem.mainReservoirPressure);
				brakeSystem.MainResPressureChanged += OnMainResPressureChanged;
			}
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading)
			{
				if (productionRateOutPort != null)
				{
					productionRateOutPort.ValueUpdatedInternally -= OnProductionRateChanged;
				}
				if (brakeSystem != null)
				{
					brakeSystem.CompressorActivationSignalChanged -= OnCompressorActivationSignalChanged;
				}
				if (compressorHealthStatePort != null)
				{
					bodyDamage.CarEffectiveHealthStateUpdate -= OnBodyHealthStateChanged;
				}
				if (mainResPressureNormalizedPort != null)
				{
					brakeSystem.MainResPressureChanged -= OnMainResPressureChanged;
				}
			}
		}

		private void OnCompressorActivationSignalChanged(bool compressorActivationSignal)
		{
			activationSignalExtInPort.ExternalValueUpdate(compressorActivationSignal ? 1f : 0f);
		}

		private void OnProductionRateChanged(float productionRateValue)
		{
			brakeSystem.compressorProductionRate = productionRateValue;
		}

		private void OnBodyHealthStateChanged(float _ = 0f)
		{
			compressorHealthStatePort.ExternalValueUpdate(bodyDamage.EffectiveHealthPercentage);
		}

		private void OnMainResPressureChanged(float normalizedPressure, float pressure)
		{
			mainResPressureNormalizedPort.ExternalValueUpdate(normalizedPressure);
		}
	}
}
