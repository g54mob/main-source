using Coherence.Brisk.Models;
using Coherence.Brook;

namespace Coherence.Brisk.Serializers
{
	public static class BriskSerializer
	{
		public static void SerializeOobMessage(IOutOctetStream outStream, IOobMessage oobMessage, uint protocolVersion)
		{
		}

		public static IOobMessage DeserializeOobMessage(IInOctetStream stream, uint protocolVersion)
		{
			return null;
		}
	}
}
