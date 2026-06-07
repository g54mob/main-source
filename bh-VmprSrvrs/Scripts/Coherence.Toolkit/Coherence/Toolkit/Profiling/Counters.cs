using Unity.Profiling;

namespace Coherence.Toolkit.Profiling
{
	internal static class Counters
	{
		public static readonly ProfilerCategory Category;

		private const ProfilerCounterOptions FlushReset = ProfilerCounterOptions.FlushOnEndOfFrame | ProfilerCounterOptions.ResetToZeroOnFlush;

		public static readonly ProfilerCounterValue<long> BandwidthSent;

		public static readonly ProfilerCounterValue<long> BandwidthReceived;

		public static readonly ProfilerCounterValue<long> MessagesSent;

		public static readonly ProfilerCounterValue<long> MessagesReceived;

		public static readonly ProfilerCounterValue<long> UpdatesSent;

		public static readonly ProfilerCounterValue<long> UpdatesReceived;

		public static readonly ProfilerCounterValue<long> CommandsSent;

		public static readonly ProfilerCounterValue<long> CommandsReceived;

		public static readonly ProfilerCounterValue<long> InputsSent;

		public static readonly ProfilerCounterValue<long> InputsReceived;

		public static readonly ProfilerCounterValue<int> PacketsSent;

		public static readonly ProfilerCounterValue<int> PacketReceived;

		public static readonly ProfilerCounter<int> Latency;

		public static readonly ProfilerCounter<int> EntityCount;
	}
}
