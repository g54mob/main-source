using Coherence.Brook;

namespace Coherence.Brisk.Models
{
	public class ConnectRequest : IOobMessage
	{
		public bool IsReliable { get; set; }

		public OobMessageType Type => default(OobMessageType);

		public ConnectInfo Info { get; }

		public ConnectRequest(ConnectInfo info)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public void Serialize(IOutOctetStream stream, uint _)
		{
		}

		public static ConnectRequest Deserialize(IInOctetStream stream, uint _)
		{
			return null;
		}
	}
}
