using Coherence.Brook;

namespace Coherence.Brisk.Models
{
	public class ChangeSendFrequencyRequest : IOobMessage
	{
		public bool IsReliable { get; set; }

		public OobMessageType Type => default(OobMessageType);

		public byte sendFrequency { get; }

		public ChangeSendFrequencyRequest(byte frequency)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public void Serialize(IOutOctetStream stream, uint _)
		{
		}

		public static ChangeSendFrequencyRequest Deserialize(IInOctetStream stream, uint _)
		{
			return null;
		}
	}
}
