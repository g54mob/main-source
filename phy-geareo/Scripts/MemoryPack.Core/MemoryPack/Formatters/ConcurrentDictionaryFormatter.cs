using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MemoryPack.Internal;

namespace MemoryPack.Formatters
{
	[Preserve]
	public sealed class ConcurrentDictionaryFormatter<TKey, TValue> : MemoryPackFormatter<ConcurrentDictionary<TKey, TValue?>> where TKey : notnull where TValue : notnull
	{
		private readonly IEqualityComparer<TKey>? equalityComparer;

		public ConcurrentDictionaryFormatter()
		{
		}

		public ConcurrentDictionaryFormatter(IEqualityComparer<TKey>? equalityComparer)
		{
		}

		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref ConcurrentDictionary<TKey, TValue?>? value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref ConcurrentDictionary<TKey, TValue?>? value)
		{
		}
	}
}
