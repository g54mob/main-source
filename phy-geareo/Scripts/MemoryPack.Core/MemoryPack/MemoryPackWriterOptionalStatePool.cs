using System.Collections.Concurrent;

namespace MemoryPack
{
	public static class MemoryPackWriterOptionalStatePool
	{
		private static readonly ConcurrentQueue<MemoryPackWriterOptionalState> queue;

		public static MemoryPackWriterOptionalState Rent(MemoryPackSerializerOptions? options)
		{
			return null;
		}

		internal static void Return(MemoryPackWriterOptionalState state)
		{
		}
	}
}
