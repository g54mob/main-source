using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MemoryPack.Internal;

namespace MemoryPack.Formatters
{
	[Preserve]
	public sealed class SortedSetFormatter<T> : MemoryPackFormatter<SortedSet<T?>>
	{
		private readonly IComparer<T?>? comparer;

		public SortedSetFormatter()
		{
		}

		public SortedSetFormatter(IComparer<T?>? comparer)
		{
		}

		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref SortedSet<T?>? value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref SortedSet<T?>? value)
		{
		}
	}
}
