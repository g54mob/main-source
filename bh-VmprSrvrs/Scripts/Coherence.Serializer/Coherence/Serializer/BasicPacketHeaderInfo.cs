using Coherence.SimulationFrame;

namespace Coherence.Serializer
{
	public struct BasicPacketHeaderInfo
	{
		public byte Flags;

		public AbsoluteSimulationFrame SimulationFrame;

		public SpecialCommand SpecialCommand;

		public SpecialCommandInfo SpecialCommandInfo;

		public override string ToString()
		{
			return null;
		}
	}
}
