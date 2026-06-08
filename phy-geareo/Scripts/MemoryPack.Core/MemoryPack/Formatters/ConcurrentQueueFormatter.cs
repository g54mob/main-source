using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using MemoryPack.Internal;

namespace MemoryPack.Formatters
{
	[Preserve]
	public sealed class ConcurrentQueueFormatter<T> : MemoryPackFormatter<ConcurrentQueue<T?>>
	{
		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref ConcurrentQueue<T?>? value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref ConcurrentQueue<T?>? value)
		{
		}
	}
}
