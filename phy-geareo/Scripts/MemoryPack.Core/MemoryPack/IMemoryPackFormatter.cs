using System.Buffers;
using System.Runtime.CompilerServices;
using MemoryPack.Internal;

namespace MemoryPack
{
	[Preserve]
	public interface IMemoryPackFormatter
	{
		[Preserve]
		void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref object? value) where TBufferWriter : class, IBufferWriter<byte>;

		[Preserve]
		void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref object? value);
	}
	[Preserve]
	public interface IMemoryPackFormatter<T>
	{
		[Preserve]
		void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref T? value) where TBufferWriter : class, IBufferWriter<byte>;

		[Preserve]
		void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref T? value);
	}
}
