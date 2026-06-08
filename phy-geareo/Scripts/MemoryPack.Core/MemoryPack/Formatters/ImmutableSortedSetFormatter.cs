using System.Collections.Generic;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using MemoryPack.Internal;

namespace MemoryPack.Formatters
{
	[Preserve]
	public sealed class ImmutableSortedSetFormatter<T> : MemoryPackFormatter<ImmutableSortedSet<T?>>
	{
		private readonly IComparer<T?>? keyComparer;

		public ImmutableSortedSetFormatter()
		{
		}

		public ImmutableSortedSetFormatter(IComparer<T?>? keyComparer)
		{
		}

		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref ImmutableSortedSet<T?>? value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref ImmutableSortedSet<T?>? value)
		{
		}
	}
}
