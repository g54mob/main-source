using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using MemoryPack.Internal;

namespace MemoryPack.Formatters
{
	[Preserve]
	public sealed class ImmutableQueueFormatter<T> : MemoryPackFormatter<ImmutableQueue<T?>>
	{
		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref ImmutableQueue<T?>? value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref ImmutableQueue<T?>? value)
		{
		}
	}
}
