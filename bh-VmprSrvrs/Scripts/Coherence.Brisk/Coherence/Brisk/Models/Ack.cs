using Coherence.Brook;

namespace Coherence.Brisk.Models
{
	public class Ack : IOobMessage
	{
		public static readonly Ack Instance;

		public bool IsReliable { get; set; }

		public OobMessageType Type => default(OobMessageType);

		public void Serialize(IOutOctetStream outStream, uint protocolVersion)
		{
		}
	}
}
