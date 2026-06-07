using Coherence.Brook;
using Coherence.Connection;

namespace Coherence.Brisk.Models
{
	public class ConnectResponse : IOobMessage
	{
		public bool IsReliable { get; set; }

		public OobMessageType Type => default(OobMessageType);

		public ClientID ClientID { get; }

		public byte SendFrequency { get; }

		public ulong SimulationFrame { get; }

		public ushort MTU { get; }

		public ConnectResponse(ClientID clientID, byte sendFrequency, ulong simulationFrame, ushort mtu)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public void Serialize(IOutOctetStream stream, uint protocolVersion)
		{
		}

		public static ConnectResponse Deserialize(IInOctetStream stream, uint protocolVersion)
		{
			return null;
		}
	}
}
