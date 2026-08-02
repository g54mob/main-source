using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MemoryPack.Internal;

namespace MemoryPack.Formatters
{
	[Preserve]
	public sealed class HashSetFormatter<T> : MemoryPackFormatter<HashSet<T?>>
	{
		private readonly IEqualityComparer<T?>? equalityComparer;

		public HashSetFormatter()
		{
		}

		public HashSetFormatter(IEqualityComparer<T?>? equalityComparer)
		{
		}

		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref HashSet<T?>? value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref HashSet<T?>? value)
		{
		}
	}
}
