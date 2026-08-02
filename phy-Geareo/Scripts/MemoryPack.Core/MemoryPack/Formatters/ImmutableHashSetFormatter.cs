using System.Collections.Generic;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using MemoryPack.Internal;

namespace MemoryPack.Formatters
{
	[Preserve]
	public sealed class ImmutableHashSetFormatter<T> : MemoryPackFormatter<ImmutableHashSet<T?>>
	{
		private readonly IEqualityComparer<T?>? equalityComparer;

		public ImmutableHashSetFormatter()
		{
		}

		public ImmutableHashSetFormatter(IEqualityComparer<T?>? equalityComparer)
		{
		}

		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref ImmutableHashSet<T?>? value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref ImmutableHashSet<T?>? value)
		{
		}
	}
}
