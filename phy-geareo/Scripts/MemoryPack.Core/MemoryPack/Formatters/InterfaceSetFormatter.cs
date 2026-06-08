using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MemoryPack.Internal;

namespace MemoryPack.Formatters
{
	[Preserve]
	public sealed class InterfaceSetFormatter<T> : MemoryPackFormatter<ISet<T?>>
	{
		private readonly IEqualityComparer<T?>? equalityComparer;

		static InterfaceSetFormatter()
		{
		}

		public InterfaceSetFormatter()
		{
		}

		public InterfaceSetFormatter(IEqualityComparer<T?>? equalityComparer)
		{
		}

		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref ISet<T?>? value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref ISet<T?>? value)
		{
		}
	}
}
