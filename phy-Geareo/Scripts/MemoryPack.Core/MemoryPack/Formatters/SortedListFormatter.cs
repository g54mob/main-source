using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MemoryPack.Internal;

namespace MemoryPack.Formatters
{
	[Preserve]
	public sealed class SortedListFormatter<TKey, TValue> : MemoryPackFormatter<SortedList<TKey, TValue?>> where TKey : notnull where TValue : notnull
	{
		private readonly IComparer<TKey>? comparer;

		public SortedListFormatter()
		{
		}

		public SortedListFormatter(IComparer<TKey>? comparer)
		{
		}

		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref SortedList<TKey, TValue?>? value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref SortedList<TKey, TValue?>? value)
		{
		}
	}
}
