using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MemoryPack.Internal;

namespace MemoryPack.Formatters
{
	[Preserve]
	public sealed class DictionaryFormatter<TKey, TValue> : MemoryPackFormatter<Dictionary<TKey, TValue?>> where TKey : notnull where TValue : notnull
	{
		private readonly IEqualityComparer<TKey>? equalityComparer;

		public DictionaryFormatter()
		{
		}

		public DictionaryFormatter(IEqualityComparer<TKey>? equalityComparer)
		{
		}

		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref Dictionary<TKey, TValue?>? value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref Dictionary<TKey, TValue?>? value)
		{
		}
	}
}
