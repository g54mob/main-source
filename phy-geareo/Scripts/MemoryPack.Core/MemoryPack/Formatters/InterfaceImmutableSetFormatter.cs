using System.Collections.Generic;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using MemoryPack.Internal;

namespace MemoryPack.Formatters
{
	[Preserve]
	public sealed class InterfaceImmutableSetFormatter<T> : MemoryPackFormatter<IImmutableSet<T?>>
	{
		private readonly IEqualityComparer<T?>? equalityComparer;

		public InterfaceImmutableSetFormatter()
		{
		}

		public InterfaceImmutableSetFormatter(IEqualityComparer<T?>? equalityComparer)
		{
		}

		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref IImmutableSet<T?>? value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref IImmutableSet<T?>? value)
		{
		}
	}
}
