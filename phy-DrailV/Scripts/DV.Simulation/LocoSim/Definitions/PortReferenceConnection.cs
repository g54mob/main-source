using System;

namespace LocoSim.Definitions
{
	[Serializable]
	public class PortReferenceConnection
	{
		public string portReferenceId;

		public string portId;

		public PortReferenceConnection(string portReferenceId, string portId)
		{
			this.portReferenceId = portReferenceId;
			this.portId = portId;
		}
	}
}
