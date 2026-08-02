using System.Runtime.CompilerServices;
using MemoryPack.Internal;

namespace MemoryPack.Compression
{
	[Preserve]
	public sealed class BitPackFormatter : MemoryPackFormatter<bool[]>
	{
		public static readonly BitPackFormatter Default;

		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref bool[]? value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref bool[]? value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Get(int data, int index)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Set(ref int data, int index, bool value)
		{
		}
	}
}
