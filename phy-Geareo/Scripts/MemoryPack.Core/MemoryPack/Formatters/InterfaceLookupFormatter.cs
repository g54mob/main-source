using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using MemoryPack.Internal;

namespace MemoryPack.Formatters
{
	[Preserve]
	public sealed class InterfaceLookupFormatter<TKey, TElement> : MemoryPackFormatter<ILookup<TKey, TElement>> where TKey : notnull where TElement : notnull
	{
		private readonly IEqualityComparer<TKey>? equalityComparer;

		static InterfaceLookupFormatter()
		{
		}

		public InterfaceLookupFormatter()
		{
		}

		public InterfaceLookupFormatter(IEqualityComparer<TKey>? equalityComparer)
		{
		}

		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref ILookup<TKey, TElement>? value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref ILookup<TKey, TElement>? value)
		{
		}
	}
}
