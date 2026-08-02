using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using MemoryPack.Internal;

namespace MemoryPack.Formatters
{
	[Preserve]
	public sealed class ImmutableArrayFormatter<T> : MemoryPackFormatter<ImmutableArray<T?>> where T : notnull
	{
		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref ImmutableArray<T?> value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref ImmutableArray<T?> value)
		{
		}
	}
}
