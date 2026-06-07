using LocoSim.Attributes;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Cars
{
	public class ResourceMassPortReader : MonoBehaviour
	{
		[PortId(null, null, true)]
		public string resourceMassPortId;

		private Port resourceMassPort;

		public float Mass => resourceMassPort.Value;

		public void Init(SimulationFlow simFlow)
		{
			if (!simFlow.TryGetPort(resourceMassPortId, out resourceMassPort))
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: ResourceMassPortReader isn't initialized properly!", this);
				Object.Destroy(this);
			}
		}
	}
}
