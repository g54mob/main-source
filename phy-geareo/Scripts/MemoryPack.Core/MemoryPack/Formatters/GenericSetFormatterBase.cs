using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MemoryPack.Internal;

namespace MemoryPack.Formatters
{
	[Preserve]
	public abstract class GenericSetFormatterBase<TSet, TElement> : MemoryPackFormatter<TSet?> where TSet : notnull, ISet<TElement> where TElement : notnull
	{
		[Preserve]
		protected abstract TSet CreateSet();

		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref TSet? value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref TSet? value)
		{
		}
	}
}
