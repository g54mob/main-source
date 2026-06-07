using LocoSim.Attributes;
using LocoSim.Definitions;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.ModularAudioCar
{
	public class CylinderCockLayeredPortReader : ALayeredAudioSimReader
	{
		private const float AIR_SOUND_INTENSITY = 0.1f;

		[PortId(PortValueType.STATE, false)]
		public string crankRotationPortId;

		[PortId(PortValueType.STATE, false)]
		public string cylindersInletValveOpenPortId;

		[PortId(PortValueType.STATE, false)]
		public string cylinderCockFlowNormalizedPortId;

		[PortId(PortValueType.CONTROL, false)]
		public string cylinderCockControlPortId;

		[Header("order matters, need to match with cylinder index")]
		public LayeredAudio[] cylCockAudio;

		private Port crankRotationPort;

		private Port cylindersInletValveOpenPort;

		private Port cylinderCockFlowNormalizedPort;

		private Port cylinderCockControlPort;

		private TrainCar car;

		public override void Init(TrainCar car, SimulationFlow simFlow)
		{
			this.car = car;
			if (!simFlow.TryGetPort(crankRotationPortId, out crankRotationPort))
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: CylinderCockLayeredPortReader not initialized properly");
				return;
			}
			if (!simFlow.TryGetPort(cylindersInletValveOpenPortId, out cylindersInletValveOpenPort))
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: CylinderCockLayeredPortReader not initialized properly");
				return;
			}
			if (!simFlow.TryGetPort(cylinderCockFlowNormalizedPortId, out cylinderCockFlowNormalizedPort))
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: CylinderCockLayeredPortReader not initialized properly");
				return;
			}
			if (!simFlow.TryGetPort(cylinderCockControlPortId, out cylinderCockControlPort))
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: CylinderCockLayeredPortReader not initialized properly");
				return;
			}
			crankRotationPort.ValueUpdatedInternally += UpdateCylCockHiss;
			cylinderCockFlowNormalizedPort.ValueUpdatedInternally += UpdateCylCockHiss;
			cylinderCockControlPort.ValueUpdatedInternally += UpdateCylCockHiss;
		}

		private void UpdateCylCockHiss(float crankRotation)
		{
			for (int i = 0; i < cylCockAudio.Length; i++)
			{
				LayeredAudio layeredAudio = cylCockAudio[i];
				bool flag = (Mathf.RoundToInt(cylindersInletValveOpenPort.Value) & (1 << i)) > 0;
				layeredAudio.MasterVolume = (flag ? 1f : 0f);
				float value = cylinderCockFlowNormalizedPort.Value;
				if (value <= 0.01f)
				{
					float num = 0f;
					float value2 = cylinderCockControlPort.Value;
					if (value2 > 0f)
					{
						num = Mathf.InverseLerp(0.5f, 1f, car.GetAbsSpeed()) * value2;
					}
					layeredAudio.Set(num * 0.1f);
				}
				else
				{
					layeredAudio.Set(value);
				}
			}
		}

		public override void Deinit()
		{
			crankRotationPort.ValueUpdatedInternally -= UpdateCylCockHiss;
			cylinderCockFlowNormalizedPort.ValueUpdatedInternally -= UpdateCylCockHiss;
			cylinderCockControlPort.ValueUpdatedInternally -= UpdateCylCockHiss;
			crankRotationPort = null;
			cylinderCockFlowNormalizedPort = null;
			cylinderCockControlPort = null;
			car = null;
		}
	}
}
