using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MemoryPack.Internal;

namespace MemoryPack.Formatters
{
	[Preserve]
	public abstract class GenericDictionaryFormatterBase<TDictionary, TKey, TValue> : MemoryPackFormatter<TDictionary?> where TDictionary : notnull, IDictionary<TKey, TValue> where TKey : notnull where TValue : notnull
	{
		[Preserve]
		protected abstract TDictionary CreateDictionary();

		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref TDictionary? value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref TDictionary? value)
		{
		}
	}
}
