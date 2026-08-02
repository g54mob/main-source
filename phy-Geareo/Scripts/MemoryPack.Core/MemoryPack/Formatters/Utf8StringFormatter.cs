using System.Runtime.CompilerServices;
using MemoryPack.Internal;

namespace MemoryPack.Formatters
{
	[Preserve]
	public sealed class Utf8StringFormatter : MemoryPackFormatter<string>
	{
		public static readonly Utf8StringFormatter Default;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref string? value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref string? value)
		{
		}
	}
}
