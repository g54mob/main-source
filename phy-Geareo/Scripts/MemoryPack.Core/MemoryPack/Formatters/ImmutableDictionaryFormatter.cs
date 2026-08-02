using System.Collections.Generic;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using MemoryPack.Internal;

namespace MemoryPack.Formatters
{
	[Preserve]
	public sealed class ImmutableDictionaryFormatter<TKey, TValue> : MemoryPackFormatter<ImmutableDictionary<TKey, TValue?>?>
	{
		private readonly IEqualityComparer<TKey>? keyEqualityComparer;

		private readonly IEqualityComparer<TValue?>? valueEqualityComparer;

		public ImmutableDictionaryFormatter()
		{
		}

		public ImmutableDictionaryFormatter(IEqualityComparer<TKey>? keyEqualityComparer, IEqualityComparer<TValue?>? valueEqualityComparer)
		{
		}

		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref ImmutableDictionary<TKey, TValue?>? value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref ImmutableDictionary<TKey, TValue?>? value)
		{
		}
	}
}
