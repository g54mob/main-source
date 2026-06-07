using LocoSim.Attributes;
using LocoSim.Definitions;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Ports
{
	public class LampPortReader : MonoBehaviour
	{
		[PortId(PortType.READONLY_OUT, PortValueType.STATE, false)]
		public string lampStatePortId;

		private Port lampStatePort;

		private LampControl lampControl;

		private bool initialized;

		public void Init(Port lampStatePort)
		{
			lampControl = GetComponent<LampControl>();
			if (lampControl == null)
			{
				Debug.LogError("Can't find LampControl on " + base.gameObject.name + ". Ignoring init");
				return;
			}
			this.lampStatePort = lampStatePort;
			lampStatePort.ValueUpdatedInternally += OnLampStateChanged;
			OnLampStateChanged(lampStatePort.Value);
			initialized = true;
		}

		public void Deinit()
		{
			if (lampStatePort != null)
			{
				lampStatePort.ValueUpdatedInternally -= OnLampStateChanged;
			}
		}

		private void OnLampStateChanged(float newState)
		{
			lampControl.ProcessLampLogicCode(newState, initialized);
		}
	}
}
