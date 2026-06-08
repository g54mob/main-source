using System.Collections.Generic;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using MemoryPack.Internal;

namespace MemoryPack.Formatters
{
	[Preserve]
	public sealed class ImmutableSortedDictionaryFormatter<TKey, TValue> : MemoryPackFormatter<ImmutableSortedDictionary<TKey, TValue?>?>
	{
		private readonly IComparer<TKey>? keyComparer;

		private readonly IEqualityComparer<TValue?>? valueEqualityComparer;

		public ImmutableSortedDictionaryFormatter()
		{
		}

		public ImmutableSortedDictionaryFormatter(IComparer<TKey>? keyComparer, IEqualityComparer<TValue?>? valueEqualityComparer)
		{
		}

		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref ImmutableSortedDictionary<TKey, TValue?>? value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref ImmutableSortedDictionary<TKey, TValue?>? value)
		{
		}
	}
}
