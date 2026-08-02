using System.Runtime.CompilerServices;

namespace K4os.Compression.LZ4.Internal
{
	public class Mem
	{
		public const int K1 = 1024;

		public const int K2 = 2048;

		public const int K4 = 4096;

		public const int K8 = 8192;

		public const int K16 = 16384;

		public const int K32 = 32768;

		public const int K64 = 65536;

		public const int K128 = 131072;

		public const int K256 = 262144;

		public const int K512 = 524288;

		public const int M1 = 1048576;

		public const int M4 = 4194304;

		public static readonly byte[] Empty;

		public static bool System32
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return false;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int RoundUp(int value, int step)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal unsafe static void CpBlk(void* target, void* source, uint length)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal unsafe static void ZBlk(void* target, byte value, uint length)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void Copy(byte* target, byte* source, int length)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void Move(byte* target, byte* source, int length)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void* Alloc(int size)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static byte* Zero(byte* target, int length)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static byte* Fill(byte* target, byte value, int length)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void* AllocZero(int size)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void Free(void* ptr)
		{
		}

		public unsafe static T* CloneArray<T>(T[] array) where T : unmanaged
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static byte Peek1(void* p)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void Poke1(void* p, byte v)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static ushort Peek2(void* p)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void Poke2(void* p, ushort v)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static uint Peek4(void* p)
		{
			return 0u;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void Poke4(void* p, uint v)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static ulong Peek8(void* p)
		{
			return 0uL;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void Poke8(void* p, ulong v)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void Copy1(byte* target, byte* source)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void Copy2(byte* target, byte* source)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void Copy4(byte* target, byte* source)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void Copy8(byte* target, byte* source)
		{
		}
	}
}
