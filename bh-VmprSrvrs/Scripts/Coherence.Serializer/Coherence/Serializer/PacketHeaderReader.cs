using Coherence.Brook;
using Coherence.SimulationFrame;

namespace Coherence.Serializer
{
	public static class PacketHeaderReader
	{
		public static BasicPacketHeaderInfo DeserializeBasicHeader(IInOctetStream reader)
		{
			return default(BasicPacketHeaderInfo);
		}

		internal static SpecialCommandInfo DeserializeSpecialCommand(SpecialCommand command, IInOctetStream reader)
		{
			return default(SpecialCommandInfo);
		}

		private static AbsoluteSimulationFrame ReadSimulationFrame(IInOctetStream stream)
		{
			return default(AbsoluteSimulationFrame);
		}

		private static ClockSpeedFactor ReadClockSpeedFactor(IInOctetStream stream)
		{
			return default(ClockSpeedFactor);
		}

		public static PacketHeaderInfo ToPacketHeaderInfo(IInOctetStream octetStream, BasicPacketHeaderInfo basicHeader)
		{
			return default(PacketHeaderInfo);
		}
	}
}
