using Coherence.Common;

namespace Coherence.Core
{
	public struct InteropPing
	{
		public int AverageLatencyMs;

		public byte IsStable;

		public int LatestLatencyMs;

		public Ping Into()
		{
			return default(Ping);
		}
	}
}
