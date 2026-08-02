using System.Collections.Concurrent;

namespace MemoryPack
{
	public static class MemoryPackReaderOptionalStatePool
	{
		private static readonly ConcurrentQueue<MemoryPackReaderOptionalState> queue;

		public static MemoryPackReaderOptionalState Rent(MemoryPackSerializerOptions? options)
		{
			return null;
		}

		internal static void Return(MemoryPackReaderOptionalState state)
		{
		}
	}
}
