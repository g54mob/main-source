using Coherence.Brook;

namespace Coherence.Serializer
{
	public struct PacketHeaderInfo
	{
		public IInBitStream Stream;

		public SpecialCommand SpecialCommand;

		public SpecialCommandInfo SpecialCommandInfo;
	}
}
