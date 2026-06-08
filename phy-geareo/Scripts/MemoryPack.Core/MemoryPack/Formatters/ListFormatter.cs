using System.Buffers;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MemoryPack.Internal;

namespace MemoryPack.Formatters
{
	[Preserve]
	public static class ListFormatter
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Preserve]
		public static void SerializePackable<T, TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, List<T?>? value) where T : notnull, IMemoryPackable<T> where TBufferWriter : class, IBufferWriter<byte>
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Preserve]
		public static List<T> DeserializePackable<T>(ref MemoryPackReader reader) where T : IMemoryPackable<T>
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Preserve]
		public static void DeserializePackable<T>(ref MemoryPackReader reader, [ScopedRef] ref List<T?>? value) where T : IMemoryPackable<T>
		{
		}
	}
	[Preserve]
	public sealed class ListFormatter<T> : MemoryPackFormatter<List<T?>>
	{
		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref List<T?>? value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref List<T?>? value)
		{
		}
	}
}
