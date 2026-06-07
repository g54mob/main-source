using System;
using LocoSim.Attributes;
using LocoSim.Definitions;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Controllers
{
	public class EngineOnReader : MonoBehaviour
	{
		[PortId(PortType.READONLY_OUT, PortValueType.STATE, false, local = true)]
		public string portId;

		private Port engineOnPort;

		public bool IsOn => engineOnPort.Value > 0f;

		public event Action<bool> StateChanged;

		public void Init(SimulationFlow simFlow)
		{
			if (!simFlow.TryGetPort(portId, out engineOnPort))
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: EngineOnReader isn't initialized properly! Destroying self.", base.gameObject);
				UnityEngine.Object.Destroy(this);
			}
			else
			{
				engineOnPort.ValueUpdatedInternally += delegate
				{
					this.StateChanged?.Invoke(IsOn);
				};
			}
		}
	}
}
