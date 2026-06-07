using Coherence.Brook;

namespace Coherence.Brisk.Models
{
	public interface IOobMessage
	{
		bool IsReliable { get; }

		OobMessageType Type { get; }

		void Serialize(IOutOctetStream outStream, uint protocolVersion);
	}
}
