using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MemoryPack.Internal;

namespace MemoryPack.Formatters
{
	[Preserve]
	public sealed class GenericCollectionFormatter<TCollection, TElement> : MemoryPackFormatter<TCollection?> where TCollection : ICollection<TElement?>?, new()
	{
		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref TCollection? value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref TCollection? value)
		{
		}
	}
}
