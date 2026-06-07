using Coherence.SimulationFrame;

namespace Coherence.Core
{
	public struct InteropAbsoluteSimulationFrame
	{
		public long Frame;

		public InteropAbsoluteSimulationFrame(AbsoluteSimulationFrame frame)
		{
			Frame = 0L;
		}

		public AbsoluteSimulationFrame Into()
		{
			return default(AbsoluteSimulationFrame);
		}
	}
}
