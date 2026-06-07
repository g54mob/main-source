using LocoSim.Attributes;
using LocoSim.Definitions;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Ports
{
	public class OilingPointPortFeederReader : MonoBehaviour
	{
		[PortId(PortType.EXTERNAL_IN, PortValueType.CONTROL, false)]
		public string refillPortId;

		[PortId(PortType.READONLY_OUT, PortValueType.STATE, false)]
		public string refillingFlowNormalizedPortId;

		public LayeredAudio refillAudio;

		private Port refillPort;

		private Port refillingFlowNormalizedPort;

		public void Init(Port refillPort, Port refillingFlowNormalizedPort)
		{
			this.refillPort = refillPort;
			this.refillingFlowNormalizedPort = refillingFlowNormalizedPort;
			refillingFlowNormalizedPort.ValueUpdatedInternally += OnFlowChanged;
		}

		public void Deinit()
		{
			if (refillingFlowNormalizedPort != null)
			{
				refillingFlowNormalizedPort.ValueUpdatedInternally -= OnFlowChanged;
			}
			if (refillPort != null)
			{
				refillPort.ExternalValueUpdate(0f);
			}
		}

		public void SetRefill(float set)
		{
			refillPort.ExternalValueUpdate(set);
		}

		private void OnFlowChanged(float obj)
		{
			refillAudio.Set(obj);
		}

		public void RefillOilToggle()
		{
			float value = refillPort.Value;
			refillPort.ExternalValueUpdate(1f - value);
		}
	}
}
