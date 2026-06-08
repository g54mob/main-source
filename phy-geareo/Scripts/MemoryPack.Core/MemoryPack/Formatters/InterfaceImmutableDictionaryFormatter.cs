using System.Collections.Generic;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using MemoryPack.Internal;

namespace MemoryPack.Formatters
{
	[Preserve]
	public sealed class InterfaceImmutableDictionaryFormatter<TKey, TValue> : MemoryPackFormatter<IImmutableDictionary<TKey, TValue?>?>
	{
		private readonly IEqualityComparer<TKey>? keyEqualityComparer;

		private readonly IEqualityComparer<TValue?>? valueEqualityComparer;

		public InterfaceImmutableDictionaryFormatter()
		{
		}

		public InterfaceImmutableDictionaryFormatter(IEqualityComparer<TKey>? keyEqualityComparer, IEqualityComparer<TValue?>? valueEqualityComparer)
		{
		}

		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref IImmutableDictionary<TKey, TValue?>? value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref IImmutableDictionary<TKey, TValue?>? value)
		{
		}
	}
}
