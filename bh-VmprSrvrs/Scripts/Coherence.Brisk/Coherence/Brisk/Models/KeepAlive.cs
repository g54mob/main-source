using Coherence.Brook;

namespace Coherence.Brisk.Models
{
	public class KeepAlive : IOobMessage
	{
		public bool IsReliable { get; set; }

		public OobMessageType Type => default(OobMessageType);

		public override string ToString()
		{
			return null;
		}

		public void Serialize(IOutOctetStream stream, uint _)
		{
		}

		public static KeepAlive Deserialize(IInOctetStream stream, uint _)
		{
			return null;
		}
	}
}
