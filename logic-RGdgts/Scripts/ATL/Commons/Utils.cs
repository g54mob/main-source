using System;
using System.Collections.Generic;
using System.Text;

namespace Commons
{
	internal static class Utils
	{
		private static Encoding latin1Encoding;

		private static IDictionary<string, Encoding> encodingCache;

		public static readonly string UNICODE_INVISIBLE_EMPTY;

		public static Encoding Latin1Encoding => null;

		public static string ProtectValue(string value)
		{
			return null;
		}

		public static int DecodeTimecodeToMs(string timeCode)
		{
			return 0;
		}

		public static string StripEndingZeroChars(string iStr)
		{
			return null;
		}

		public static string BuildStrictLengthString(string value, int length, char paddingChar, bool padRight = true)
		{
			return null;
		}

		public static byte[] DecodeFrom64(byte[] encodedData)
		{
			return null;
		}

		public static byte[] EncodeTo64(byte[] data)
		{
			return null;
		}

		public static bool IsNumeric(string s, bool allowsOnlyIntegers = false, bool allowsSigned = true)
		{
			return false;
		}

		public static bool IsDigit(char c)
		{
			return false;
		}

		public static double ParseDouble(string s)
		{
			return 0.0;
		}

		public static void TraceException(Exception e, int level = 1)
		{
		}
	}
}
