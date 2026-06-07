using System.Numerics;
using System.Runtime.CompilerServices;

namespace Coherence.Brook
{
	internal static class Utils
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint TruncateFloat(float value, int bits)
		{
			return 0u;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong TruncateDouble(double value, int bits)
		{
			return 0uL;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float GetTruncatedFloatValue(float value, int bits)
		{
			return 0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double GetTruncatedDoubleValue(double value, int bits)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int CountMSBitPosition(uint input)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int CountMSBitPosition(ulong input)
		{
			return 0;
		}

		public static uint GetMaxCursorForFixedPointCompression(long minRange, long maxRange, double precision, out long range)
		{
			range = default(long);
			return 0u;
		}

		public static int GetNumberOfBitsForFixedPointCompression(long minRange, long maxRange, double precision, out long range, out uint maxCursor)
		{
			range = default(long);
			maxCursor = default(uint);
			return 0;
		}

		public static uint CalculateCursorForFixedFloatCompression(double value, long minRange, long maxRange, double precision, out int bits)
		{
			bits = default(int);
			return 0u;
		}

		public static double UncompressFixedPoint(uint cursor, long minRange, long maxRange, double precision)
		{
			return 0.0;
		}

		public static double CompressFixedPoint(double value, long minRange, long maxRange, double precision)
		{
			return 0.0;
		}

		public static (uint, uint, uint, uint) CalculateCursorsForQuaternionCompression(in Quaternion q, int bitsPerComponent)
		{
			return default((uint, uint, uint, uint));
		}

		public static Quaternion UncompressQuaternion(int bitsPerComponent, int xCursor, int yCursor, int zCursor, uint wSign)
		{
			return default(Quaternion);
		}

		public static Quaternion CompressQuaternion(Quaternion quaternion, int bitsPerComponent)
		{
			return default(Quaternion);
		}
	}
}
