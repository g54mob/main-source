using Coherence.Brook;
using Coherence.Connection;

namespace Coherence.Brisk.Models
{
	public class DisconnectRequest : IOobMessage
	{
		public bool IsReliable { get; set; }

		public OobMessageType Type => default(OobMessageType);

		public ConnectionCloseReason Reason { get; }

		public DisconnectRequest(ConnectionCloseReason reason)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public void Serialize(IOutOctetStream outStream, uint _)
		{
		}

		public static DisconnectRequest Deserialize(IInOctetStream inStream, uint _)
		{
			return null;
		}
	}
}
