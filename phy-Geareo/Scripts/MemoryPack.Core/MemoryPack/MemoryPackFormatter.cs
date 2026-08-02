using System.Buffers;
using System.Runtime.CompilerServices;
using MemoryPack.Internal;

namespace MemoryPack
{
	[Preserve]
	public abstract class MemoryPackFormatter<T> : IMemoryPackFormatter<T>, IMemoryPackFormatter
	{
		[Preserve]
		public abstract void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref T? value) where TBufferWriter : class, IBufferWriter<byte>;

		[Preserve]
		public abstract void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref T? value);

		[Preserve]
		void IMemoryPackFormatter.Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref object? value)
		{
		}

		[Preserve]
		void IMemoryPackFormatter.Deserialize(ref MemoryPackReader reader, [ScopedRef] ref object? value)
		{
		}
	}
}
