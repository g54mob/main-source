using System.IO;
using System.Text;

namespace ATL
{
	internal static class StreamUtils
	{
		public static bool StringEqualsArr(string a, char[] b)
		{
			return false;
		}

		private static bool ArrEqualsArr(char[] a, char[] b)
		{
			return false;
		}

		public static bool ArrEqualsArr(byte[] a, byte[] b)
		{
			return false;
		}

		public static bool ArrBeginsWith(byte[] data, byte[] beginning)
		{
			return false;
		}

		public static void CopyStream(Stream from, Stream to, long length = 0L)
		{
		}

		private static int toInt(long value)
		{
			return 0;
		}

		public static sbyte DecodeSignedByte(byte[] data)
		{
			return 0;
		}

		public static byte DecodeUByte(byte[] data)
		{
			return 0;
		}

		public static ushort DecodeBEUInt16(byte[] data)
		{
			return 0;
		}

		public static ushort DecodeUInt16(byte[] data)
		{
			return 0;
		}

		public static short DecodeInt16(byte[] data)
		{
			return 0;
		}

		public static short DecodeBEInt16(byte[] data)
		{
			return 0;
		}

		public static int DecodeBEInt24(byte[] data)
		{
			return 0;
		}

		public static uint DecodeBEUInt24(byte[] data, int offset = 0)
		{
			return 0u;
		}

		public static uint DecodeBEUInt32(byte[] data)
		{
			return 0u;
		}

		public static uint DecodeUInt32(byte[] data)
		{
			return 0u;
		}

		public static int DecodeBEInt32(byte[] data)
		{
			return 0;
		}

		public static int DecodeInt32(byte[] data)
		{
			return 0;
		}

		public static ulong DecodeUInt64(byte[] data)
		{
			return 0uL;
		}

		public static long DecodeInt64(byte[] data)
		{
			return 0L;
		}

		public static long DecodeBEInt64(byte[] data)
		{
			return 0L;
		}

		public static double DecodeBEDouble(byte[] data)
		{
			return 0.0;
		}

		public static string ReadNullTerminatedString(Stream s, Encoding encoding)
		{
			return null;
		}

		public static string ReadNullTerminatedStringFixed(BufferedBinaryReader r, Encoding encoding, int limit)
		{
			return null;
		}

		private static string readNullTerminatedString(Stream r, Encoding encoding, int limit, bool moveStreamToLimit)
		{
			return null;
		}

		public static int DecodeSynchSafeInt(byte[] bytes)
		{
			return 0;
		}

		public static int DecodeSynchSafeInt32(byte[] data)
		{
			return 0;
		}

		public static bool FindSequence(Stream stream, byte[] sequence, long limit = 0L)
		{
			return false;
		}

		public static uint ReadBEBits(Stream source, int bitPosition, int bitCount)
		{
			return 0u;
		}

		public static double ExtendedToDouble(byte[] extended)
		{
			return 0.0;
		}

		private static double FromComponents(int s, int e, long f)
		{
			return 0.0;
		}

		public static long TraversePadding(Stream source)
		{
			return 0L;
		}

		public static int SkipValues(Stream source, int[] dataToSkip)
		{
			return 0;
		}

		public static int SkipValuesEnd(Stream source, int[] dataToSkip)
		{
			return 0;
		}
	}
}
