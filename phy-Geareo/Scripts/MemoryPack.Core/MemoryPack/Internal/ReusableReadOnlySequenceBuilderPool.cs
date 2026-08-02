using System.Collections.Concurrent;

namespace MemoryPack.Internal
{
	internal static class ReusableReadOnlySequenceBuilderPool
	{
		private static readonly ConcurrentQueue<ReusableReadOnlySequenceBuilder> queue;

		public static ReusableReadOnlySequenceBuilder Rent()
		{
			return null;
		}

		public static void Return(ReusableReadOnlySequenceBuilder builder)
		{
		}
	}
}
