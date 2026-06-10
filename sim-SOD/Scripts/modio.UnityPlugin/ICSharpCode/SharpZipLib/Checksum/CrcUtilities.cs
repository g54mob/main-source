using System.Runtime.CompilerServices;

namespace ICSharpCode.SharpZipLib.Checksum
{
	internal static class CrcUtilities
	{
		internal const int SlicingDegree = 16;

		internal static uint[] GenerateSlicingLookupTable(uint polynomial, bool isReversed)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static uint UpdateDataForNormalPoly(byte[] input, int offset, uint[] crcTable, uint checkValue)
		{
			return 0u;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static uint UpdateDataForReversedPoly(byte[] input, int offset, uint[] crcTable, uint checkValue)
		{
			return 0u;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static uint UpdateDataCommon(byte[] input, int offset, uint[] crcTable, byte x1, byte x2, byte x3, byte x4)
		{
			return 0u;
		}
	}
}
