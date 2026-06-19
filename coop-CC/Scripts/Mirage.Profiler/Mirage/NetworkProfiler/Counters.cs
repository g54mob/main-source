using Unity.Profiling;

namespace Mirage.NetworkProfiler
{
	internal static class Counters
	{
		public static readonly ProfilerCategory Category = ProfilerCategory.Network;

		private const ProfilerMarkerDataUnit COUNT = ProfilerMarkerDataUnit.Count;

		private const ProfilerMarkerDataUnit BYTES = ProfilerMarkerDataUnit.Bytes;

		public static readonly ProfilerCounter<int> PlayerCount = new ProfilerCounter<int>(Category, "Player Count", ProfilerMarkerDataUnit.Count);

		public static readonly ProfilerCounter<int> CharCount = new ProfilerCounter<int>(Category, "Character Count", ProfilerMarkerDataUnit.Count);

		public static readonly ProfilerCounter<int> ObjectCount = new ProfilerCounter<int>(Category, "Object Count", ProfilerMarkerDataUnit.Count);

		public static readonly ProfilerCounter<int> SentCount = new ProfilerCounter<int>(Category, "Sent Messages", ProfilerMarkerDataUnit.Count);

		public static readonly ProfilerCounter<int> SentBytes = new ProfilerCounter<int>(Category, "Sent Bytes", ProfilerMarkerDataUnit.Bytes);

		public static readonly ProfilerCounter<int> SentPerSecond = new ProfilerCounter<int>(Category, "Sent Per Second", ProfilerMarkerDataUnit.Bytes);

		public static readonly ProfilerCounter<int> ReceiveCount = new ProfilerCounter<int>(Category, "Received Messages", ProfilerMarkerDataUnit.Count);

		public static readonly ProfilerCounter<int> ReceiveBytes = new ProfilerCounter<int>(Category, "Received Bytes", ProfilerMarkerDataUnit.Bytes);

		public static readonly ProfilerCounter<int> ReceivePerSecond = new ProfilerCounter<int>(Category, "Received Per Second", ProfilerMarkerDataUnit.Bytes);
	}
}
