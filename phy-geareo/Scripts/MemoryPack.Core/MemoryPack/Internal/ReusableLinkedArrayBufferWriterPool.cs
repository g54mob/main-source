using System.Collections.Concurrent;

namespace MemoryPack.Internal
{
	public static class ReusableLinkedArrayBufferWriterPool
	{
		private static readonly ConcurrentQueue<ReusableLinkedArrayBufferWriter> queue;

		public static ReusableLinkedArrayBufferWriter Rent()
		{
			return null;
		}

		public static void Return(ReusableLinkedArrayBufferWriter writer)
		{
		}
	}
}
