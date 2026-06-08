using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MemoryPack.Internal;

namespace MemoryPack.Formatters
{
	[Preserve]
	public sealed class SortedDictionaryFormatter<TKey, TValue> : MemoryPackFormatter<SortedDictionary<TKey, TValue?>> where TKey : notnull where TValue : notnull
	{
		private readonly IComparer<TKey>? comparer;

		public SortedDictionaryFormatter()
		{
		}

		public SortedDictionaryFormatter(IComparer<TKey>? comparer)
		{
		}

		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref SortedDictionary<TKey, TValue?>? value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref SortedDictionary<TKey, TValue?>? value)
		{
		}
	}
}
