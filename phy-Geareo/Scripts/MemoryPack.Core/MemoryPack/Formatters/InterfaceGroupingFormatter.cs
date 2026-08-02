using System.Linq;
using System.Runtime.CompilerServices;
using MemoryPack.Internal;

namespace MemoryPack.Formatters
{
	[Preserve]
	public sealed class InterfaceGroupingFormatter<TKey, TElement> : MemoryPackFormatter<IGrouping<TKey, TElement>> where TKey : notnull where TElement : notnull
	{
		static InterfaceGroupingFormatter()
		{
		}

		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref IGrouping<TKey, TElement>? value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref IGrouping<TKey, TElement>? value)
		{
		}
	}
}
