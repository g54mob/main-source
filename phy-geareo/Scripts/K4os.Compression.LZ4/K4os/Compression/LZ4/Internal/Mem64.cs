using System.Runtime.CompilerServices;

namespace K4os.Compression.LZ4.Internal
{
	public class Mem64 : Mem
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public new unsafe static ushort Peek2(void* p)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public new unsafe static void Poke2(void* p, ushort v)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public new unsafe static uint Peek4(void* p)
		{
			return 0u;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public new unsafe static void Poke4(void* p, uint v)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public new unsafe static void Copy1(byte* target, byte* source)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public new unsafe static void Copy2(byte* target, byte* source)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public new unsafe static void Copy4(byte* target, byte* source)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public new unsafe static ulong Peek8(void* p)
		{
			return 0uL;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public new unsafe static void Poke8(void* p, ulong v)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public new unsafe static void Copy8(byte* target, byte* source)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static ulong PeekW(void* p)
		{
			return 0uL;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void PokeW(void* p, ulong v)
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
