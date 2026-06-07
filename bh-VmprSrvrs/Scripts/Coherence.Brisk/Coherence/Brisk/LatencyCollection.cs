using System.Collections.Generic;
using Coherence.Common;

namespace Coherence.Brisk
{
	public class LatencyCollection
	{
		private readonly int size;

		private readonly int minSamplesForStability;

		private readonly int maxStableDeviation;

		private readonly List<ushort> latencies;

		public Ping Ping => default(Ping);

		public LatencyCollection(ConnectionSettings.PingSettings settings)
		{
		}

		public void AddLatency(ushort latencyInMilliseconds)
		{
		}

		public bool StableLatency(out ushort latency)
		{
			latency = default(ushort);
			return false;
		}

		private ushort CalculateAverageLatency()
		{
			return 0;
		}
	}
}
