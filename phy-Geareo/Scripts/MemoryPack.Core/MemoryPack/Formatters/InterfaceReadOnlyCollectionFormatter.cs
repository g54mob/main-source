using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MemoryPack.Internal;

namespace MemoryPack.Formatters
{
	[Preserve]
	public sealed class InterfaceReadOnlyCollectionFormatter<T> : MemoryPackFormatter<IReadOnlyCollection<T?>>
	{
		static InterfaceReadOnlyCollectionFormatter()
		{
		}

		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref IReadOnlyCollection<T?>? value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref IReadOnlyCollection<T?>? value)
		{
		}
	}
}
