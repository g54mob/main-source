using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

namespace Cysharp.Text
{
	internal static class ShimsExtensions
	{
		public unsafe static int GetBytes(this Encoding encoding, ReadOnlySpan<char> span, Span<byte> bytes)
		{
			if (span.Length == 0)
			{
				return 0;
			}
			fixed (char* chars = span)
			{
				fixed (byte* bytes2 = bytes)
				{
					return encoding.GetBytes(chars, span.Length, bytes2, bytes.Length);
				}
			}
		}

		public static bool TryFormat(this Guid value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default(ReadOnlySpan<char>))
		{
			return Unsafe.As<Guid, GuidEx>(ref value).TryFormat(destination, out charsWritten, format);
		}

		public static bool TryFormat(this TimeSpan value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default(ReadOnlySpan<char>))
		{
			string format2 = GetFormat(format);
			ReadOnlySpan<char> readOnlySpan = ((format2 == null) ? value.ToString() : value.ToString(format2)).AsSpan();
			if (readOnlySpan.TryCopyTo(destination))
			{
				charsWritten = readOnlySpan.Length;
				return true;
			}
			charsWritten = 0;
			return false;
		}

		public static bool TryFormat(this DateTime value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default(ReadOnlySpan<char>))
		{
			string format2 = GetFormat(format);
			ReadOnlySpan<char> readOnlySpan = ((format2 == null) ? value.ToString() : value.ToString(format2)).AsSpan();
			if (readOnlySpan.TryCopyTo(destination))
			{
				charsWritten = readOnlySpan.Length;
				return true;
			}
			charsWritten = 0;
			return false;
		}

		public static bool TryFormat(this DateTimeOffset value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default(ReadOnlySpan<char>))
		{
			string format2 = GetFormat(format);
			ReadOnlySpan<char> readOnlySpan = ((format2 == null) ? value.ToString() : value.ToString(format2)).AsSpan();
			if (readOnlySpan.TryCopyTo(destination))
			{
				charsWritten = readOnlySpan.Length;
				return true;
			}
			charsWritten = 0;
			return false;
		}

		public static bool TryFormat(this decimal value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default(ReadOnlySpan<char>))
		{
			return System.Number.TryFormatDecimal(value, format, NumberFormatInfo.CurrentInfo, destination, out charsWritten);
		}

		public static bool TryFormat(this float value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default(ReadOnlySpan<char>))
		{
			return System.Number.TryFormatSingle(value, format, NumberFormatInfo.CurrentInfo, destination, out charsWritten);
		}

		public static bool TryFormat(this double value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default(ReadOnlySpan<char>))
		{
			return System.Number.TryFormatDouble(value, format, NumberFormatInfo.CurrentInfo, destination, out charsWritten);
		}

		public static bool TryFormat(this sbyte value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default(ReadOnlySpan<char>))
		{
			if (format.Length == 0)
			{
				return FastNumberWriter.TryWriteInt64(destination, out charsWritten, value);
			}
			if (value < 0 && format.Length > 0 && (format[0] == 'X' || format[0] == 'x'))
			{
				return System.Number.TryFormatUInt32((uint)(value & 0xFF), format, NumberFormatInfo.CurrentInfo, destination, out charsWritten);
			}
			return System.Number.TryFormatInt32(value, format, NumberFormatInfo.CurrentInfo, destination, out charsWritten);
		}

		public static bool TryFormat(this short value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default(ReadOnlySpan<char>))
		{
			if (format.Length == 0)
			{
				return FastNumberWriter.TryWriteInt64(destination, out charsWritten, value);
			}
			if (value < 0 && format.Length > 0 && (format[0] == 'X' || format[0] == 'x'))
			{
				return System.Number.TryFormatUInt32((uint)(value & 0xFFFF), format, NumberFormatInfo.CurrentInfo, destination, out charsWritten);
			}
			return System.Number.TryFormatInt32(value, format, NumberFormatInfo.CurrentInfo, destination, out charsWritten);
		}

		public static bool TryFormat(this int value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default(ReadOnlySpan<char>))
		{
			if (format.Length == 0)
			{
				return FastNumberWriter.TryWriteInt64(destination, out charsWritten, value);
			}
			return System.Number.TryFormatInt32(value, format, NumberFormatInfo.CurrentInfo, destination, out charsWritten);
		}

		public static bool TryFormat(this long value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default(ReadOnlySpan<char>))
		{
			if (format.Length == 0)
			{
				return FastNumberWriter.TryWriteInt64(destination, out charsWritten, value);
			}
			return System.Number.TryFormatInt64(value, format, NumberFormatInfo.CurrentInfo, destination, out charsWritten);
		}

		public static bool TryFormat(this byte value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default(ReadOnlySpan<char>))
		{
			if (format.Length == 0)
			{
				return FastNumberWriter.TryWriteUInt64(destination, out charsWritten, value);
			}
			return System.Number.TryFormatUInt32(value, format, NumberFormatInfo.CurrentInfo, destination, out charsWritten);
		}

		public static bool TryFormat(this ushort value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default(ReadOnlySpan<char>))
		{
			if (format.Length == 0)
			{
				return FastNumberWriter.TryWriteUInt64(destination, out charsWritten, value);
			}
			return System.Number.TryFormatUInt32(value, format, NumberFormatInfo.CurrentInfo, destination, out charsWritten);
		}

		public static bool TryFormat(this uint value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default(ReadOnlySpan<char>))
		{
			if (format.Length == 0)
			{
				return FastNumberWriter.TryWriteUInt64(destination, out charsWritten, value);
			}
			return System.Number.TryFormatUInt32(value, format, NumberFormatInfo.CurrentInfo, destination, out charsWritten);
		}

		public static bool TryFormat(this ulong value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default(ReadOnlySpan<char>))
		{
			if (format.Length == 0)
			{
				return FastNumberWriter.TryWriteUInt64(destination, out charsWritten, value);
			}
			return System.Number.TryFormatUInt64(value, format, NumberFormatInfo.CurrentInfo, destination, out charsWritten);
		}

		private static string? GetFormat(ReadOnlySpan<char> format)
		{
			if (format.Length == 0)
			{
				return null;
			}
			return format.ToString();
		}
	}
}
