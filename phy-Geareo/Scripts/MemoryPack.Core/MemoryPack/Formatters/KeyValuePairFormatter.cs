using System.Buffers;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MemoryPack.Internal;

namespace MemoryPack.Formatters
{
	[Preserve]
	public static class KeyValuePairFormatter
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Preserve]
		public static void Serialize<TKey, TValue, TBufferWriter>(IMemoryPackFormatter<TKey> keyFormatter, IMemoryPackFormatter<TValue> valueFormatter, ref MemoryPackWriter<TBufferWriter> writer, KeyValuePair<TKey?, TValue?> value) where TKey : notnull where TValue : notnull where TBufferWriter : class, IBufferWriter<byte>
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Preserve]
		public static void Deserialize<TKey, TValue>(IMemoryPackFormatter<TKey> keyFormatter, IMemoryPackFormatter<TValue> valueFormatter, ref MemoryPackReader reader, out TKey? key, out TValue? value)
		{
			key = default(TKey);
			value = default(TValue);
		}
	}
	[Preserve]
	public sealed class KeyValuePairFormatter<TKey, TValue> : MemoryPackFormatter<KeyValuePair<TKey?, TValue?>>
	{
		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref KeyValuePair<TKey?, TValue?> value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref KeyValuePair<TKey?, TValue?> value)
		{
		}
	}
}
