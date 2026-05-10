using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace LiteNetLib.Utils
{
	public static class FastBitConverter
	{
		[StructLayout((LayoutKind)2)]
		private struct ConverterHelperDouble
		{
			[FieldOffset(0)]
			public ulong Along;

			[FieldOffset(0)]
			public double Adouble;
		}

		[StructLayout((LayoutKind)2)]
		private struct ConverterHelperFloat
		{
			[FieldOffset(0)]
			public int Aint;

			[FieldOffset(0)]
			public float Afloat;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void WriteLittleEndian(byte[] buffer, int offset, ulong data)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void WriteLittleEndian(byte[] buffer, int offset, int data)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteLittleEndian(byte[] buffer, int offset, short data)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void GetBytes(byte[] bytes, int startIndex, double value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void GetBytes(byte[] bytes, int startIndex, float value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void GetBytes(byte[] bytes, int startIndex, short value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void GetBytes(byte[] bytes, int startIndex, ushort value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void GetBytes(byte[] bytes, int startIndex, int value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void GetBytes(byte[] bytes, int startIndex, uint value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void GetBytes(byte[] bytes, int startIndex, long value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void GetBytes(byte[] bytes, int startIndex, ulong value)
		{
		}
	}
}
