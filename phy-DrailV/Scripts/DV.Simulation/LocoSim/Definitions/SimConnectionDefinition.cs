using UnityEngine;

namespace LocoSim.Definitions
{
	public class SimConnectionDefinition : MonoBehaviour
	{
		public SimComponentDefinition[] executionOrder;

		public Connection[] connections;

		public PortReferenceConnection[] portReferenceConnections;
	}
}
