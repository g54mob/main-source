using System.Runtime.CompilerServices;

namespace CommunityToolkit.HighPerformance.Helpers
{
	public static class BitHelper
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasFlag(uint value, int n)
		{
			byte b = (byte)((value >> n) & 1);
			return b != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasLookupFlag(uint table, int x, int min = 0)
		{
			int num = x - min;
			bool flag = (uint)num < 32u;
			int num2 = ~((flag ? 1 : 0) - 1);
			byte b = (byte)((table >> num) & 1 & (uint)num2);
			return b != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasZeroByte(uint value)
		{
			return ((value - 16843009) & ~value & 0x80808080u) != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasZeroByte(ulong value)
		{
			return ((value - 72340172838076673L) & ~value & 0x8080808080808080uL) != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasByteEqualTo(uint value, byte target)
		{
			return HasZeroByte(value ^ (uint)(16843009 * target));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasByteEqualTo(ulong value, byte target)
		{
			return HasZeroByte(value ^ (ulong)(72340172838076673L * target));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetFlag(ref uint value, int n, bool flag)
		{
			value = SetFlag(value, n, flag);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint SetFlag(uint value, int n, bool flag)
		{
			uint num = (uint)(~(1 << n));
			uint num2 = value & num;
			bool flag2 = flag;
			uint num3 = (flag2 ? 1u : 0u) << n;
			return num2 | num3;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint ExtractRange(uint value, byte start, byte length)
		{
			return (value >> (int)start) & (uint)((1 << (int)length) - 1);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRange(ref uint value, byte start, byte length, uint flags)
		{
			value = SetRange(value, start, length, flags);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint SetRange(uint value, byte start, byte length, uint flags)
		{
			uint num = (uint)((1 << (int)length) - 1);
			uint num2 = num << (int)start;
			uint num3 = (flags & num) << (int)start;
			return (~num2 & value) | num3;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasFlag(ulong value, int n)
		{
			byte b = (byte)((value >> n) & 1);
			return b != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasLookupFlag(ulong table, int x, int min = 0)
		{
			int num = x - min;
			bool flag = (uint)num < 64u;
			int num2 = ~((flag ? 1 : 0) - 1);
			byte b = (byte)((int)((table >> num) & 1) & num2);
			return b != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetFlag(ref ulong value, int n, bool flag)
		{
			value = SetFlag(value, n, flag);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong SetFlag(ulong value, int n, bool flag)
		{
			ulong num = (ulong)(~(1L << n));
			ulong num2 = value & num;
			bool flag2 = flag;
			ulong num3 = (flag2 ? 1uL : 0uL) << n;
			return num2 | num3;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong ExtractRange(ulong value, byte start, byte length)
		{
			return (value >> (int)start) & (ulong)((1L << (int)length) - 1);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRange(ref ulong value, byte start, byte length, ulong flags)
		{
			value = SetRange(value, start, length, flags);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong SetRange(ulong value, byte start, byte length, ulong flags)
		{
			ulong num = (ulong)((1L << (int)length) - 1);
			ulong num2 = num << (int)start;
			ulong num3 = (flags & num) << (int)start;
			return (~num2 & value) | num3;
		}
	}
}
