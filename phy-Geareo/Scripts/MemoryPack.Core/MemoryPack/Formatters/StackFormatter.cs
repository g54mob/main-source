using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MemoryPack.Internal;

namespace MemoryPack.Formatters
{
	[Preserve]
	public sealed class StackFormatter<T> : MemoryPackFormatter<Stack<T?>>
	{
		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref Stack<T?>? value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref Stack<T?>? value)
		{
		}
	}
}
