using System.Runtime.CompilerServices;

namespace K4os.Compression.LZ4.Internal
{
	public class Mem32 : Mem
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static uint PeekW(void* p)
		{
			return 0u;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void PokeW(void* p, uint v)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void Copy16(byte* target, byte* source)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void Copy18(byte* target, byte* source)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void WildCopy8(byte* target, byte* source, void* limit)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void WildCopy32(byte* target, byte* source, void* limit)
		{
		}
	}
}
