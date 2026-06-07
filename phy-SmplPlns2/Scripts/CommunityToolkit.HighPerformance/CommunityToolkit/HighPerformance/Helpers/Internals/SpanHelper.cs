using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace CommunityToolkit.HighPerformance.Helpers.Internals
{
	internal static class SpanHelper
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static nint Count<T>(ref T r0, nint length, T value) where T : IEquatable<T>
		{
			if (!Vector.IsHardwareAccelerated)
			{
				return CountSequential(ref r0, length, value);
			}
			if (typeof(T) == typeof(byte) || typeof(T) == typeof(sbyte) || typeof(T) == typeof(bool))
			{
				ref sbyte r1 = ref Unsafe.As<T, sbyte>(ref r0);
				sbyte value2 = Unsafe.As<T, sbyte>(ref value);
				return CountSimd(ref r1, length, value2);
			}
			if (typeof(T) == typeof(char) || typeof(T) == typeof(ushort) || typeof(T) == typeof(short))
			{
				ref short r2 = ref Unsafe.As<T, short>(ref r0);
				short value3 = Unsafe.As<T, short>(ref value);
				return CountSimd(ref r2, length, value3);
			}
			if (typeof(T) == typeof(int) || typeof(T) == typeof(uint))
			{
				ref int r3 = ref Unsafe.As<T, int>(ref r0);
				int value4 = Unsafe.As<T, int>(ref value);
				return CountSimd(ref r3, length, value4);
			}
			if (typeof(T) == typeof(long) || typeof(T) == typeof(ulong))
			{
				ref long r4 = ref Unsafe.As<T, long>(ref r0);
				long value5 = Unsafe.As<T, long>(ref value);
				return CountSimd(ref r4, length, value5);
			}
			return CountSequential(ref r0, length, value);
		}

		private static nint CountSequential<T>(ref T r0, nint length, T value) where T : IEquatable<T>
		{
			nint num = 0;
			nint num2 = 0;
			while (length >= 8)
			{
				num += Unsafe.Add(ref r0, num2 + 0).Equals(value).ToByte();
				num += Unsafe.Add(ref r0, num2 + 1).Equals(value).ToByte();
				num += Unsafe.Add(ref r0, num2 + 2).Equals(value).ToByte();
				num += Unsafe.Add(ref r0, num2 + 3).Equals(value).ToByte();
				num += Unsafe.Add(ref r0, num2 + 4).Equals(value).ToByte();
				num += Unsafe.Add(ref r0, num2 + 5).Equals(value).ToByte();
				num += Unsafe.Add(ref r0, num2 + 6).Equals(value).ToByte();
				num += Unsafe.Add(ref r0, num2 + 7).Equals(value).ToByte();
				length -= 8;
				num2 += 8;
			}
			if (length >= 4)
			{
				num += Unsafe.Add(ref r0, num2 + 0).Equals(value).ToByte();
				num += Unsafe.Add(ref r0, num2 + 1).Equals(value).ToByte();
				num += Unsafe.Add(ref r0, num2 + 2).Equals(value).ToByte();
				num += Unsafe.Add(ref r0, num2 + 3).Equals(value).ToByte();
				length -= 4;
				num2 += 4;
			}
			while (length > 0)
			{
				num += Unsafe.Add(ref r0, num2).Equals(value).ToByte();
				length--;
				num2++;
			}
			return num;
		}

		private static nint CountSimd<T>(ref T r0, nint length, T value) where T : unmanaged, IEquatable<T>
		{
			nint num = 0;
			nint num2 = 0;
			if (length >= Vector<T>.Count)
			{
				Vector<T> right = new Vector<T>(value);
				do
				{
					nint upperBound = GetUpperBound<T>();
					nint num3 = ((length <= upperBound) ? length : upperBound);
					nint num4 = num2;
					Vector<T> zero = Vector<T>.Zero;
					if (typeof(T) != typeof(sbyte))
					{
						while (num3 >= Vector<T>.Count * 8)
						{
							nint num5 = num2;
							_ = Vector<T>.Count;
							Vector<T> vector = Vector.Equals(Unsafe.As<T, Vector<T>>(ref Unsafe.Add(ref r0, num5 + 0)), right);
							zero -= vector;
							Vector<T> vector2 = Vector.Equals(Unsafe.As<T, Vector<T>>(ref Unsafe.Add(ref r0, num2 + Vector<T>.Count)), right);
							zero -= vector2;
							Vector<T> vector3 = Vector.Equals(Unsafe.As<T, Vector<T>>(ref Unsafe.Add(ref r0, num2 + Vector<T>.Count * 2)), right);
							zero -= vector3;
							Vector<T> vector4 = Vector.Equals(Unsafe.As<T, Vector<T>>(ref Unsafe.Add(ref r0, num2 + Vector<T>.Count * 3)), right);
							zero -= vector4;
							Vector<T> vector5 = Vector.Equals(Unsafe.As<T, Vector<T>>(ref Unsafe.Add(ref r0, num2 + Vector<T>.Count * 4)), right);
							zero -= vector5;
							Vector<T> vector6 = Vector.Equals(Unsafe.As<T, Vector<T>>(ref Unsafe.Add(ref r0, num2 + Vector<T>.Count * 5)), right);
							zero -= vector6;
							Vector<T> vector7 = Vector.Equals(Unsafe.As<T, Vector<T>>(ref Unsafe.Add(ref r0, num2 + Vector<T>.Count * 6)), right);
							zero -= vector7;
							Vector<T> vector8 = Vector.Equals(Unsafe.As<T, Vector<T>>(ref Unsafe.Add(ref r0, num2 + Vector<T>.Count * 7)), right);
							zero -= vector8;
							num3 -= Vector<T>.Count * 8;
							num2 += Vector<T>.Count * 8;
						}
					}
					while (num3 >= Vector<T>.Count)
					{
						Vector<T> vector9 = Vector.Equals(Unsafe.As<T, Vector<T>>(ref Unsafe.Add(ref r0, num2)), right);
						zero -= vector9;
						num3 -= Vector<T>.Count;
						num2 += Vector<T>.Count;
					}
					num += CastToNativeInt(Vector.Dot(zero, Vector<T>.One));
					length -= num2 - num4;
				}
				while (length >= Vector<T>.Count);
			}
			if (Vector<T>.Count > 8 && length >= 8)
			{
				num += Unsafe.Add(ref r0, num2 + 0).Equals(value).ToByte();
				num += Unsafe.Add(ref r0, num2 + 1).Equals(value).ToByte();
				num += Unsafe.Add(ref r0, num2 + 2).Equals(value).ToByte();
				num += Unsafe.Add(ref r0, num2 + 3).Equals(value).ToByte();
				num += Unsafe.Add(ref r0, num2 + 4).Equals(value).ToByte();
				num += Unsafe.Add(ref r0, num2 + 5).Equals(value).ToByte();
				num += Unsafe.Add(ref r0, num2 + 6).Equals(value).ToByte();
				num += Unsafe.Add(ref r0, num2 + 7).Equals(value).ToByte();
				length -= 8;
				num2 += 8;
			}
			if (Vector<T>.Count > 4 && length >= 4)
			{
				num += Unsafe.Add(ref r0, num2 + 0).Equals(value).ToByte();
				num += Unsafe.Add(ref r0, num2 + 1).Equals(value).ToByte();
				num += Unsafe.Add(ref r0, num2 + 2).Equals(value).ToByte();
				num += Unsafe.Add(ref r0, num2 + 3).Equals(value).ToByte();
				length -= 4;
				num2 += 4;
			}
			while (length > 0)
			{
				num += Unsafe.Add(ref r0, num2).Equals(value).ToByte();
				length--;
				num2++;
			}
			return num;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe static nint GetUpperBound<T>() where T : unmanaged
		{
			if (typeof(T) == typeof(sbyte))
			{
				return 127;
			}
			if (typeof(T) == typeof(short))
			{
				return 32767;
			}
			if (typeof(T) == typeof(int))
			{
				return int.MaxValue;
			}
			if (typeof(T) == typeof(long))
			{
				if (sizeof(IntPtr) == 4)
				{
					return int.MaxValue;
				}
				return unchecked((nint)long.MaxValue);
			}
			throw null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static nint CastToNativeInt<T>(T value) where T : unmanaged
		{
			if (typeof(T) == typeof(sbyte))
			{
				return (byte)(sbyte)(object)value;
			}
			if (typeof(T) == typeof(short))
			{
				return (ushort)(short)(object)value;
			}
			if (typeof(T) == typeof(int))
			{
				return (nint)(uint)(int)(object)value;
			}
			if (typeof(T) == typeof(long))
			{
				return (nint)(long)(object)value;
			}
			throw null;
		}

		public static int GetDjb2HashCode<T>(ref T r0, nint length) where T : notnull
		{
			int num = 5381;
			nint num2 = 0;
			while (length >= 8)
			{
				num = ((num << 5) + num) ^ Unsafe.Add(ref r0, num2 + 0).GetHashCode();
				num = ((num << 5) + num) ^ Unsafe.Add(ref r0, num2 + 1).GetHashCode();
				num = ((num << 5) + num) ^ Unsafe.Add(ref r0, num2 + 2).GetHashCode();
				num = ((num << 5) + num) ^ Unsafe.Add(ref r0, num2 + 3).GetHashCode();
				num = ((num << 5) + num) ^ Unsafe.Add(ref r0, num2 + 4).GetHashCode();
				num = ((num << 5) + num) ^ Unsafe.Add(ref r0, num2 + 5).GetHashCode();
				num = ((num << 5) + num) ^ Unsafe.Add(ref r0, num2 + 6).GetHashCode();
				num = ((num << 5) + num) ^ Unsafe.Add(ref r0, num2 + 7).GetHashCode();
				length -= 8;
				num2 += 8;
			}
			if (length >= 4)
			{
				num = ((num << 5) + num) ^ Unsafe.Add(ref r0, num2 + 0).GetHashCode();
				num = ((num << 5) + num) ^ Unsafe.Add(ref r0, num2 + 1).GetHashCode();
				num = ((num << 5) + num) ^ Unsafe.Add(ref r0, num2 + 2).GetHashCode();
				num = ((num << 5) + num) ^ Unsafe.Add(ref r0, num2 + 3).GetHashCode();
				length -= 4;
				num2 += 4;
			}
			while (length > 0)
			{
				num = ((num << 5) + num) ^ Unsafe.Add(ref r0, num2).GetHashCode();
				length--;
				num2++;
			}
			return num;
		}

		public unsafe static int GetDjb2LikeByteHash(ref byte r0, nint length)
		{
			int num = 5381;
			nint num2 = 0;
			if (Vector.IsHardwareAccelerated && length >= Vector<byte>.Count << 3)
			{
				Vector<int> left = new Vector<int>(5381);
				Vector<int> right = new Vector<int>(33);
				while (length >= Vector<byte>.Count << 3)
				{
					nint num3 = num2;
					_ = Vector<byte>.Count;
					Vector<int> right2 = Unsafe.ReadUnaligned<Vector<int>>(ref Unsafe.Add(ref r0, num3 + 0));
					left = Vector.Xor(Vector.Multiply(left, right), right2);
					Vector<int> right3 = Unsafe.ReadUnaligned<Vector<int>>(ref Unsafe.Add(ref r0, num2 + Vector<byte>.Count));
					left = Vector.Xor(Vector.Multiply(left, right), right3);
					Vector<int> right4 = Unsafe.ReadUnaligned<Vector<int>>(ref Unsafe.Add(ref r0, num2 + Vector<byte>.Count * 2));
					left = Vector.Xor(Vector.Multiply(left, right), right4);
					Vector<int> right5 = Unsafe.ReadUnaligned<Vector<int>>(ref Unsafe.Add(ref r0, num2 + Vector<byte>.Count * 3));
					left = Vector.Xor(Vector.Multiply(left, right), right5);
					Vector<int> right6 = Unsafe.ReadUnaligned<Vector<int>>(ref Unsafe.Add(ref r0, num2 + Vector<byte>.Count * 4));
					left = Vector.Xor(Vector.Multiply(left, right), right6);
					Vector<int> right7 = Unsafe.ReadUnaligned<Vector<int>>(ref Unsafe.Add(ref r0, num2 + Vector<byte>.Count * 5));
					left = Vector.Xor(Vector.Multiply(left, right), right7);
					Vector<int> right8 = Unsafe.ReadUnaligned<Vector<int>>(ref Unsafe.Add(ref r0, num2 + Vector<byte>.Count * 6));
					left = Vector.Xor(Vector.Multiply(left, right), right8);
					Vector<int> right9 = Unsafe.ReadUnaligned<Vector<int>>(ref Unsafe.Add(ref r0, num2 + Vector<byte>.Count * 7));
					left = Vector.Xor(Vector.Multiply(left, right), right9);
					length -= Vector<byte>.Count << 3;
					num2 += Vector<byte>.Count << 3;
				}
				while (length >= Vector<byte>.Count)
				{
					Vector<int> right10 = Unsafe.ReadUnaligned<Vector<int>>(ref Unsafe.Add(ref r0, num2));
					left = Vector.Xor(Vector.Multiply(left, right), right10);
					length -= Vector<byte>.Count;
					num2 += Vector<byte>.Count;
				}
				for (int i = 0; i < Vector<int>.Count; i++)
				{
					num = ((num << 5) + num) ^ left[i];
				}
			}
			else
			{
				if (sizeof(IntPtr) == 8)
				{
					while (length >= 64)
					{
						ulong num4 = Unsafe.ReadUnaligned<ulong>(ref Unsafe.Add(ref r0, num2 + 0));
						num = ((num << 5) + num) ^ (int)num4 ^ (int)(num4 >> 32);
						ulong num5 = Unsafe.ReadUnaligned<ulong>(ref Unsafe.Add(ref r0, num2 + 8));
						num = ((num << 5) + num) ^ (int)num5 ^ (int)(num5 >> 32);
						ulong num6 = Unsafe.ReadUnaligned<ulong>(ref Unsafe.Add(ref r0, num2 + 16));
						num = ((num << 5) + num) ^ (int)num6 ^ (int)(num6 >> 32);
						ulong num7 = Unsafe.ReadUnaligned<ulong>(ref Unsafe.Add(ref r0, num2 + 24));
						num = ((num << 5) + num) ^ (int)num7 ^ (int)(num7 >> 32);
						ulong num8 = Unsafe.ReadUnaligned<ulong>(ref Unsafe.Add(ref r0, num2 + 32));
						num = ((num << 5) + num) ^ (int)num8 ^ (int)(num8 >> 32);
						ulong num9 = Unsafe.ReadUnaligned<ulong>(ref Unsafe.Add(ref r0, num2 + 40));
						num = ((num << 5) + num) ^ (int)num9 ^ (int)(num9 >> 32);
						ulong num10 = Unsafe.ReadUnaligned<ulong>(ref Unsafe.Add(ref r0, num2 + 48));
						num = ((num << 5) + num) ^ (int)num10 ^ (int)(num10 >> 32);
						ulong num11 = Unsafe.ReadUnaligned<ulong>(ref Unsafe.Add(ref r0, num2 + 56));
						num = ((num << 5) + num) ^ (int)num11 ^ (int)(num11 >> 32);
						length -= 64;
						num2 += 64;
					}
				}
				while (length >= 32)
				{
					uint num12 = Unsafe.ReadUnaligned<uint>(ref Unsafe.Add(ref r0, num2 + 0));
					num = ((num << 5) + num) ^ (int)num12;
					uint num13 = Unsafe.ReadUnaligned<uint>(ref Unsafe.Add(ref r0, num2 + 4));
					num = ((num << 5) + num) ^ (int)num13;
					uint num14 = Unsafe.ReadUnaligned<uint>(ref Unsafe.Add(ref r0, num2 + 8));
					num = ((num << 5) + num) ^ (int)num14;
					uint num15 = Unsafe.ReadUnaligned<uint>(ref Unsafe.Add(ref r0, num2 + 12));
					num = ((num << 5) + num) ^ (int)num15;
					uint num16 = Unsafe.ReadUnaligned<uint>(ref Unsafe.Add(ref r0, num2 + 16));
					num = ((num << 5) + num) ^ (int)num16;
					uint num17 = Unsafe.ReadUnaligned<uint>(ref Unsafe.Add(ref r0, num2 + 20));
					num = ((num << 5) + num) ^ (int)num17;
					uint num18 = Unsafe.ReadUnaligned<uint>(ref Unsafe.Add(ref r0, num2 + 24));
					num = ((num << 5) + num) ^ (int)num18;
					uint num19 = Unsafe.ReadUnaligned<uint>(ref Unsafe.Add(ref r0, num2 + 28));
					num = ((num << 5) + num) ^ (int)num19;
					length -= 32;
					num2 += 32;
				}
			}
			if (length >= 16)
			{
				ushort num20 = Unsafe.ReadUnaligned<ushort>(ref Unsafe.Add(ref r0, num2 + 0));
				num = ((num << 5) + num) ^ num20;
				ushort num21 = Unsafe.ReadUnaligned<ushort>(ref Unsafe.Add(ref r0, num2 + 2));
				num = ((num << 5) + num) ^ num21;
				ushort num22 = Unsafe.ReadUnaligned<ushort>(ref Unsafe.Add(ref r0, num2 + 4));
				num = ((num << 5) + num) ^ num22;
				ushort num23 = Unsafe.ReadUnaligned<ushort>(ref Unsafe.Add(ref r0, num2 + 6));
				num = ((num << 5) + num) ^ num23;
				ushort num24 = Unsafe.ReadUnaligned<ushort>(ref Unsafe.Add(ref r0, num2 + 8));
				num = ((num << 5) + num) ^ num24;
				ushort num25 = Unsafe.ReadUnaligned<ushort>(ref Unsafe.Add(ref r0, num2 + 10));
				num = ((num << 5) + num) ^ num25;
				ushort num26 = Unsafe.ReadUnaligned<ushort>(ref Unsafe.Add(ref r0, num2 + 12));
				num = ((num << 5) + num) ^ num26;
				ushort num27 = Unsafe.ReadUnaligned<ushort>(ref Unsafe.Add(ref r0, num2 + 14));
				num = ((num << 5) + num) ^ num27;
				length -= 16;
				num2 += 16;
			}
			while (length > 0)
			{
				num = ((num << 5) + num) ^ Unsafe.Add(ref r0, num2);
				length--;
				num2++;
			}
			return num;
		}
	}
}
