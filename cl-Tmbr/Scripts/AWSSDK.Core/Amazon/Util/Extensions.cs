using System;
using System.Globalization;
using System.Text;

namespace Amazon.Util
{
	internal static class Extensions
	{
		internal static string ToUpper(this string str, CultureInfo culture)
		{
			if (culture != CultureInfo.InvariantCulture)
			{
				throw new ArgumentException("The extension method ToUpper only works for invariant culture");
			}
			return str.ToUpperInvariant();
		}

		public unsafe static int GetBytes(this Encoding encoding, ReadOnlySpan<char> src, Span<byte> dest)
		{
			if (src.Length == 0)
			{
				return 0;
			}
			if (dest.Length == 0)
			{
				return 0;
			}
			fixed (char* chars = src)
			{
				fixed (byte* bytes = dest)
				{
					return encoding.GetBytes(chars, src.Length, bytes, dest.Length);
				}
			}
		}

		public unsafe static string GetString(this Encoding encoding, ReadOnlySpan<byte> bytes)
		{
			if (bytes.Length == 0)
			{
				return string.Empty;
			}
			fixed (byte* bytes2 = bytes)
			{
				return encoding.GetString(bytes2, bytes.Length);
			}
		}
	}
}
