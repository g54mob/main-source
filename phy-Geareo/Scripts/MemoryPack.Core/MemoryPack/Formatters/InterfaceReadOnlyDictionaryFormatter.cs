using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MemoryPack.Internal;

namespace MemoryPack.Formatters
{
	[Preserve]
	public sealed class InterfaceReadOnlyDictionaryFormatter<TKey, TValue> : MemoryPackFormatter<IReadOnlyDictionary<TKey, TValue?>> where TKey : notnull where TValue : notnull
	{
		private readonly IEqualityComparer<TKey>? equalityComparer;

		public InterfaceReadOnlyDictionaryFormatter()
		{
		}

		public InterfaceReadOnlyDictionaryFormatter(IEqualityComparer<TKey>? equalityComparer)
		{
		}

		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref IReadOnlyDictionary<TKey, TValue?>? value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref IReadOnlyDictionary<TKey, TValue?>? value)
		{
		}
	}
}
