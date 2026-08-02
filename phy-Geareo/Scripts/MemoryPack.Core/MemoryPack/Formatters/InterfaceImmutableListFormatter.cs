using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using MemoryPack.Internal;

namespace MemoryPack.Formatters
{
	[Preserve]
	public sealed class InterfaceImmutableListFormatter<T> : MemoryPackFormatter<IImmutableList<T?>>
	{
		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref IImmutableList<T?>? value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref IImmutableList<T?>? value)
		{
		}
	}
}
