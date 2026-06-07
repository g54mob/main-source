using System;

namespace Utf8Json.Internal.DoubleConversion
{
	internal static class StringToDoubleConverter
	{
		private enum Flags
		{
			NO_FLAGS = 0,
			ALLOW_HEX = 1,
			ALLOW_OCTALS = 2,
			ALLOW_TRAILING_JUNK = 4,
			ALLOW_LEADING_SPACES = 8,
			ALLOW_TRAILING_SPACES = 0x10,
			ALLOW_SPACES_AFTER_SIGN = 0x20,
			ALLOW_CASE_INSENSIBILITY = 0x40
		}

		[ThreadStatic]
		private static byte[] kBuffer;

		[ThreadStatic]
		private static byte[] fallbackBuffer;

		private const Flags flags_ = (Flags)52;

		private const double empty_string_value_ = 0.0;

		private const double junk_string_value_ = 0.0 / 0.0;

		private const int kMaxSignificantDigits = 772;

		private const int kBufferSize = 782;

		private static readonly byte[] infinity_symbol_;

		private static readonly byte[] nan_symbol_;

		private static readonly byte[] kWhitespaceTable7;

		private static readonly int kWhitespaceTable7Length;

		private static readonly ushort[] kWhitespaceTable16;

		private static readonly int kWhitespaceTable16Length;

		private static byte[] GetBuffer()
		{
			return null;
		}

		private static byte[] GetFallbackBuffer()
		{
			return null;
		}

		public static double ToDouble(byte[] buffer, int offset, out int readCount)
		{
			readCount = default(int);
			return 0.0;
		}

		public static float ToSingle(byte[] buffer, int offset, out int readCount)
		{
			readCount = default(int);
			return 0f;
		}

		private static bool isWhitespace(int x)
		{
			return false;
		}

		private static bool AdvanceToNonspace(ref Iterator current, Iterator end)
		{
			return false;
		}

		private static bool ConsumeSubString(ref Iterator current, Iterator end, byte[] substring)
		{
			return false;
		}

		private static bool ConsumeFirstCharacter(ref Iterator iter, byte[] str, int offset)
		{
			return false;
		}

		private static double SignedZero(bool sign)
		{
			return 0.0;
		}

		private static double StringToIeee(Iterator input, int length, bool read_as_double, out int processed_characters_count)
		{
			processed_characters_count = default(int);
			return 0.0;
		}
	}
}
