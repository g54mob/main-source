using Coherence.SimulationFrame;

namespace Coherence
{
	public static class SimulationFrameEx
	{
		private const long SimFramesPerSecond = 60L;

		public static AbsoluteSimulationFrame Zero;

		public static AbsoluteSimulationFrame Now()
		{
			return default(AbsoluteSimulationFrame);
		}
	}
}
