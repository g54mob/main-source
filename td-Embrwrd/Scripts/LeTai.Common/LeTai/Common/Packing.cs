using System.Runtime.CompilerServices;

namespace LeTai.Common
{
	public static class Packing
	{
		public readonly struct FloatPacker
		{
			private readonly int _bitsPerFloat;

			private readonly uint _payload;

			private readonly int _nBitsUsed;

			private FloatPacker(uint payload, int nBitsUsed, int bitsPerFloat)
			{
				_bitsPerFloat = 0;
				_payload = 0u;
				_nBitsUsed = 0;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static FloatPacker Varying()
			{
				return default(FloatPacker);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static FloatPacker Uniform(int bitsPerFloat)
			{
				return default(FloatPacker);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public FloatPacker Enqueue(float value, float min, float max, int nBits)
			{
				return default(FloatPacker);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public FloatPacker Enqueue(float value, float min, float max)
			{
				return default(FloatPacker);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public FloatPacker Enqueue(float value, float max)
			{
				return default(FloatPacker);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public float Finish()
			{
				return 0f;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static implicit operator float(FloatPacker packer)
			{
				return 0f;
			}
		}

		public static float PackFloatsSafe(float a, float minA, float maxA, int nBitsA, float b, float minB, float maxB, int nBitsB)
		{
			return 0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint Quantize(float x, float min, float max, int nBits)
		{
			return 0u;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static uint EnsureNormalFloatExponent(uint bits)
		{
			return 0u;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float UintToFloatBits(uint bits)
		{
			return 0f;
		}
	}
}
