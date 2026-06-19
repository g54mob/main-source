using System.IO;
using System.Runtime.CompilerServices;
using Unity.Burst;

namespace Aggro.Core
{
	[BurstCompile]
	public static class XXHash
	{
		[BurstCompile]
		private static class Bits
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal static ulong RotateLeft(ulong value, int bits)
			{
				return (value << bits) | (value >> 64 - bits);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal static uint RotateLeft(uint value, int bits)
			{
				return (value << bits) | (value >> 32 - bits);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal static uint RotateRight(uint value, int bits)
			{
				return (value >> bits) | (value << 32 - bits);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal static ulong RotateRight(ulong value, int bits)
			{
				return (value >> bits) | (value << 64 - bits);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal unsafe static ulong PartialBytesToUInt64(byte* ptr, int leftBytes)
			{
				ulong num = 0uL;
				for (int i = 0; i < leftBytes; i++)
				{
					num |= (ulong)ptr[i] << (i << 3);
				}
				return num;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal static ulong PartialBytesToUInt64(byte[] buffer, int leftBytes)
			{
				ulong num = 0uL;
				for (int i = 0; i < leftBytes; i++)
				{
					num |= (ulong)buffer[i] << (i << 3);
				}
				return num;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal unsafe static uint PartialBytesToUInt32(byte* ptr, int leftBytes)
			{
				if (leftBytes > 3)
				{
					return *(uint*)ptr;
				}
				uint num = *ptr;
				if (leftBytes > 1)
				{
					num |= (uint)(ptr[1] << 8);
				}
				if (leftBytes > 2)
				{
					num |= (uint)(ptr[2] << 16);
				}
				return num;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal static uint PartialBytesToUInt32(byte[] buffer, int leftBytes)
			{
				if (leftBytes > 3)
				{
					return ToUInt32(buffer, 0);
				}
				uint num = buffer[0];
				if (leftBytes > 1)
				{
					num |= (uint)(buffer[1] << 8);
				}
				if (leftBytes > 2)
				{
					num |= (uint)(buffer[2] << 16);
				}
				return num;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal static uint SwapBytes32(uint num)
			{
				return (RotateLeft(num, 8) & 0xFF00FF) | (RotateRight(num, 8) & 0xFF00FF00u);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal static ulong SwapBytes64(ulong num)
			{
				num = (RotateLeft(num, 48) & 0xFFFF0000FFFF0000uL) | (RotateLeft(num, 16) & 0xFFFF0000FFFFL);
				return (RotateLeft(num, 8) & 0xFF00FF00FF00FF00uL) | (RotateRight(num, 8) & 0xFF00FF00FF00FFL);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static uint ToUInt32(byte[] value, int startIndex)
			{
				return (uint)ToInt32(value, startIndex);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public unsafe static int ToInt32(byte[] value, int startIndex)
			{
				fixed (byte* ptr = &value[startIndex])
				{
					if ((startIndex & 3) == 0)
					{
						return *(int*)ptr;
					}
					return *ptr | (ptr[1] << 8) | (ptr[2] << 16) | (ptr[3] << 24);
				}
			}
		}

		private const ulong prime64v1 = 11400714785074694791uL;

		private const ulong prime64v2 = 14029467366897019727uL;

		private const ulong prime64v3 = 1609587929392839161uL;

		private const ulong prime64v4 = 9650029242287828579uL;

		private const ulong prime64v5 = 2870177450012600261uL;

		private const uint prime32v1 = 2654435761u;

		private const uint prime32v2 = 2246822519u;

		private const uint prime32v3 = 3266489917u;

		private const uint prime32v4 = 668265263u;

		private const uint prime32v5 = 374761393u;

		public unsafe static uint Hash32(byte* buffer, int bufferLength, uint seed = 0u)
		{
			int num = bufferLength;
			byte* pInput = buffer;
			uint num2;
			if (bufferLength >= 16)
			{
				uint acc = (uint)((int)seed + -1640531535 + -2048144777);
				uint acc2 = seed + 2246822519u;
				uint acc3 = seed;
				uint acc4 = seed - 2654435761u;
				do
				{
					num2 = processStripe32(ref pInput, ref acc, ref acc2, ref acc3, ref acc4);
					num -= 16;
				}
				while (num >= 16);
			}
			else
			{
				num2 = seed + 374761393;
			}
			num2 += (uint)bufferLength;
			num2 = processRemaining32(pInput, num2, num);
			return avalanche32(num2);
		}

		public unsafe static uint Hash32(Stream stream, uint seed = 0u)
		{
			byte[] array = new byte[16384];
			int num = stream.Read(array, 0, 16384);
			int num2 = num;
			uint num3;
			fixed (byte* ptr = array)
			{
				byte* pInput = ptr;
				if (num >= 16)
				{
					uint acc = (uint)((int)seed + -1640531535 + -2048144777);
					uint acc2 = seed + 2246822519u;
					uint acc3 = seed;
					uint acc4 = seed - 2654435761u;
					while (true)
					{
						num3 = processStripe32(ref pInput, ref acc, ref acc2, ref acc3, ref acc4);
						num -= 16;
						if (num < 16)
						{
							if (num == 0)
							{
								num = stream.Read(array, 0, 16384);
								pInput = ptr;
								num2 += num;
							}
							if (num < 16)
							{
								break;
							}
						}
					}
				}
				else
				{
					num3 = seed + 374761393;
				}
				num3 += (uint)num2;
				num3 = processRemaining32(pInput, num3, num);
			}
			return avalanche32(num3);
		}

		public unsafe static ulong Hash64(byte* buffer, int bufferLength, ulong seed = 0uL)
		{
			int num = bufferLength;
			byte* pInput = buffer;
			ulong num2;
			if (bufferLength >= 32)
			{
				ulong acc = (ulong)((long)seed + -7046029288634856825L + -4417276706812531889L);
				ulong acc2 = seed + 14029467366897019727uL;
				ulong acc3 = seed;
				ulong acc4 = seed - 11400714785074694791uL;
				do
				{
					num2 = processStripe64(ref pInput, ref acc, ref acc2, ref acc3, ref acc4);
					num -= 32;
				}
				while (num >= 32);
			}
			else
			{
				num2 = seed + 2870177450012600261L;
			}
			num2 += (ulong)bufferLength;
			num2 = processRemaining64(pInput, num2, num);
			return avalanche64(num2);
		}

		public unsafe static ulong Hash64(Stream stream, ulong seed = 0uL)
		{
			byte[] array = new byte[32768];
			int num = stream.Read(array, 0, 32768);
			ulong num2 = (ulong)num;
			ulong num3;
			fixed (byte* ptr = array)
			{
				byte* pInput = ptr;
				if (num >= 32)
				{
					ulong acc = (ulong)((long)seed + -7046029288634856825L + -4417276706812531889L);
					ulong acc2 = seed + 14029467366897019727uL;
					ulong acc3 = seed;
					ulong acc4 = seed - 11400714785074694791uL;
					while (true)
					{
						num3 = processStripe64(ref pInput, ref acc, ref acc2, ref acc3, ref acc4);
						num -= 32;
						if (num < 32)
						{
							if (num == 0)
							{
								num = stream.Read(array, 0, 32768);
								pInput = ptr;
								num2 += (ulong)num;
							}
							if (num < 32)
							{
								break;
							}
						}
					}
				}
				else
				{
					num3 = seed + 2870177450012600261L;
				}
				num3 += num2;
				num3 = processRemaining64(pInput, num3, num);
			}
			return avalanche64(num3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe static ulong processStripe64(ref byte* pInput, ref ulong acc1, ref ulong acc2, ref ulong acc3, ref ulong acc4)
		{
			processLane64(ref acc1, ref pInput);
			processLane64(ref acc2, ref pInput);
			processLane64(ref acc3, ref pInput);
			processLane64(ref acc4, ref pInput);
			ulong acc5 = Bits.RotateLeft(acc1, 1) + Bits.RotateLeft(acc2, 7) + Bits.RotateLeft(acc3, 12) + Bits.RotateLeft(acc4, 18);
			mergeAccumulator64(ref acc5, acc1);
			mergeAccumulator64(ref acc5, acc2);
			mergeAccumulator64(ref acc5, acc3);
			mergeAccumulator64(ref acc5, acc4);
			return acc5;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe static void processLane64(ref ulong accn, ref byte* pInput)
		{
			ulong lane = *(ulong*)pInput;
			accn = round64(accn, lane);
			pInput += 8;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe static ulong processRemaining64(byte* pInput, ulong acc, int remainingLen)
		{
			while (remainingLen >= 8)
			{
				ulong lane = *(ulong*)pInput;
				acc ^= round64(0uL, lane);
				acc = Bits.RotateLeft(acc, 27) * 11400714785074694791uL;
				acc += 9650029242287828579uL;
				remainingLen -= 8;
				pInput += 8;
			}
			while (remainingLen >= 4)
			{
				uint num = *(uint*)pInput;
				acc ^= (ulong)(num * -7046029288634856825L);
				acc = Bits.RotateLeft(acc, 23) * 14029467366897019727uL;
				acc += 1609587929392839161L;
				remainingLen -= 4;
				pInput += 4;
			}
			while (remainingLen >= 1)
			{
				byte b = *pInput;
				acc ^= (ulong)(b * 2870177450012600261L);
				acc = Bits.RotateLeft(acc, 11) * 11400714785074694791uL;
				remainingLen--;
				pInput++;
			}
			return acc;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static ulong avalanche64(ulong acc)
		{
			acc ^= acc >> 33;
			acc *= 14029467366897019727uL;
			acc ^= acc >> 29;
			acc *= 1609587929392839161L;
			acc ^= acc >> 32;
			return acc;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static ulong round64(ulong accn, ulong lane)
		{
			accn += (ulong)((long)lane * -4417276706812531889L);
			return Bits.RotateLeft(accn, 31) * 11400714785074694791uL;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void mergeAccumulator64(ref ulong acc, ulong accn)
		{
			acc ^= round64(0uL, accn);
			acc *= 11400714785074694791uL;
			acc += 9650029242287828579uL;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe static uint processStripe32(ref byte* pInput, ref uint acc1, ref uint acc2, ref uint acc3, ref uint acc4)
		{
			processLane32(ref pInput, ref acc1);
			processLane32(ref pInput, ref acc2);
			processLane32(ref pInput, ref acc3);
			processLane32(ref pInput, ref acc4);
			return Bits.RotateLeft(acc1, 1) + Bits.RotateLeft(acc2, 7) + Bits.RotateLeft(acc3, 12) + Bits.RotateLeft(acc4, 18);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe static void processLane32(ref byte* pInput, ref uint accn)
		{
			uint lane = *(uint*)pInput;
			accn = round32(accn, lane);
			pInput += 4;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe static uint processRemaining32(byte* pInput, uint acc, int remainingLen)
		{
			while (remainingLen >= 4)
			{
				uint num = *(uint*)pInput;
				acc += (uint)((int)num * -1028477379);
				acc = Bits.RotateLeft(acc, 17) * 668265263;
				remainingLen -= 4;
				pInput += 4;
			}
			while (remainingLen >= 1)
			{
				byte b = *pInput;
				acc += (uint)(b * 374761393);
				acc = Bits.RotateLeft(acc, 11) * 2654435761u;
				remainingLen--;
				pInput++;
			}
			return acc;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static uint round32(uint accn, uint lane)
		{
			accn += (uint)((int)lane * -2048144777);
			accn = Bits.RotateLeft(accn, 13);
			accn *= 2654435761u;
			return accn;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static uint avalanche32(uint acc)
		{
			acc ^= acc >> 15;
			acc *= 2246822519u;
			acc ^= acc >> 13;
			acc *= 3266489917u;
			acc ^= acc >> 16;
			return acc;
		}
	}
}
