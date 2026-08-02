using System;
using System.Runtime.CompilerServices;
using MemoryPack.Internal;

namespace MemoryPack.Formatters
{
	[Preserve]
	public sealed class ArraySegmentFormatter<T> : MemoryPackFormatter<ArraySegment<T?>> where T : notnull
	{
		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref ArraySegment<T?> value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref ArraySegment<T?> value)
		{
		}
	}
}
