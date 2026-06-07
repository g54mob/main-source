using System.Globalization;

namespace System
{
	public static class DataIO
	{
		public static readonly CultureInfo Culture = CultureInfo.InvariantCulture;

		public static readonly DateTimeFormatInfo DateTimeFormat = CultureInfo.InvariantCulture.DateTimeFormat;

		public static readonly NumberFormatInfo NumberFormat = CultureInfo.InvariantCulture.NumberFormat;

		public static readonly NumberStyles NumberStyleDouble = NumberStyles.Float | NumberStyles.AllowThousands;

		public static readonly NumberStyles NumberStyleFloat = NumberStyles.Float | NumberStyles.AllowThousands;

		public static bool ParseBool(string value)
		{
			return bool.Parse(value);
		}

		public static bool ParseBool(string value, bool defaultValue)
		{
			if (bool.TryParse(value, out var result))
			{
				return result;
			}
			return defaultValue;
		}

		public static bool? ParseBoolNullable(string value, bool? defaultValue)
		{
			if (bool.TryParse(value, out var result))
			{
				return result;
			}
			return defaultValue;
		}

		public static byte ParseByte(string value)
		{
			return byte.Parse(value, NumberFormat);
		}

		public static byte ParseByte(string value, byte defaultValue)
		{
			if (byte.TryParse(value, NumberStyles.Integer, NumberFormat, out var result))
			{
				return result;
			}
			return defaultValue;
		}

		public static char ParseChar(string value)
		{
			return char.Parse(value);
		}

		public static char ParseChar(string value, char defaultValue)
		{
			if (char.TryParse(value, out var result))
			{
				return result;
			}
			return defaultValue;
		}

		public static DateTime ParseDateTime(string value)
		{
			return DateTime.Parse(value, DateTimeFormat);
		}

		public static DateTime ParseDateTime(string value, DateTime defaultValue)
		{
			if (DateTime.TryParse(value, DateTimeFormat, DateTimeStyles.None, out var result))
			{
				return result;
			}
			return defaultValue;
		}

		public static DateTimeOffset ParseDateTimeOffset(string value)
		{
			return DateTimeOffset.Parse(value, DateTimeFormat);
		}

		public static DateTimeOffset ParseDateTimeOffset(string value, DateTimeOffset defaultValue)
		{
			if (DateTimeOffset.TryParse(value, DateTimeFormat, DateTimeStyles.None, out var result))
			{
				return result;
			}
			return defaultValue;
		}

		public static double ParseDouble(string value)
		{
			return double.Parse(value, NumberFormat);
		}

		public static double ParseDouble(string value, double defaultValue)
		{
			if (double.TryParse(value, NumberStyleDouble, NumberFormat, out var result))
			{
				return result;
			}
			return defaultValue;
		}

		public static float ParseFloat(string value)
		{
			return float.Parse(value, NumberFormat);
		}

		public static float ParseFloat(string value, float defaultValue)
		{
			if (float.TryParse(value, NumberStyleFloat, NumberFormat, out var result))
			{
				return result;
			}
			return defaultValue;
		}

		public static Guid ParseGuid(string value)
		{
			return Guid.Parse(value);
		}

		public static Guid ParseGuid(string value, Guid defaultValue)
		{
			if (Guid.TryParse(value, out var result))
			{
				return result;
			}
			return defaultValue;
		}

		public static int ParseInt(string value)
		{
			return int.Parse(value, NumberFormat);
		}

		public static int ParseInt(string value, int defaultValue)
		{
			if (int.TryParse(value, NumberStyles.Integer, NumberFormat, out var result))
			{
				return result;
			}
			return defaultValue;
		}

		public static long ParseLong(string value)
		{
			return long.Parse(value, NumberFormat);
		}

		public static long ParseLong(string value, long defaultValue)
		{
			if (long.TryParse(value, NumberStyles.Integer, NumberFormat, out var result))
			{
				return result;
			}
			return defaultValue;
		}

		public static sbyte ParseSByte(string value)
		{
			return sbyte.Parse(value, NumberFormat);
		}

		public static sbyte ParseSByte(string value, sbyte defaultValue)
		{
			if (sbyte.TryParse(value, NumberStyles.Integer, NumberFormat, out var result))
			{
				return result;
			}
			return defaultValue;
		}

		public static short ParseShort(string value)
		{
			return short.Parse(value, NumberFormat);
		}

		public static short ParseShort(string value, short defaultValue)
		{
			if (short.TryParse(value, NumberStyles.Integer, NumberFormat, out var result))
			{
				return result;
			}
			return defaultValue;
		}

		public static TimeSpan ParseTimeSpan(string value)
		{
			return TimeSpan.Parse(value, Culture);
		}

		public static TimeSpan ParseTimeSpan(string value, TimeSpan defaultValue)
		{
			if (TimeSpan.TryParse(value, Culture, out var result))
			{
				return result;
			}
			return defaultValue;
		}

		public static uint ParseUInt(string value)
		{
			return uint.Parse(value, NumberFormat);
		}

		public static uint ParseUInt(string value, uint defaultValue)
		{
			if (uint.TryParse(value, NumberStyles.Integer, NumberFormat, out var result))
			{
				return result;
			}
			return defaultValue;
		}

		public static ulong ParseULong(string value)
		{
			return ulong.Parse(value, NumberFormat);
		}

		public static ulong ParseULong(string value, ulong defaultValue)
		{
			if (ulong.TryParse(value, NumberStyles.Integer, NumberFormat, out var result))
			{
				return result;
			}
			return defaultValue;
		}

		public static ushort ParseUShort(string value)
		{
			return ushort.Parse(value, NumberFormat);
		}

		public static ushort ParseUShort(string value, ushort defaultValue)
		{
			if (ushort.TryParse(value, NumberStyles.Integer, NumberFormat, out var result))
			{
				return result;
			}
			return defaultValue;
		}

		public static string ToString(float value)
		{
			return value.ToString(NumberFormat);
		}

		public static string ToString(float value, string format)
		{
			return value.ToString(format, NumberFormat);
		}

		public static string ToString(double value)
		{
			return value.ToString(NumberFormat);
		}

		public static string ToString(double value, string format)
		{
			return value.ToString(format, NumberFormat);
		}

		public static string ToString(int value)
		{
			return value.ToString(NumberFormat);
		}

		public static string ToString(int value, string format)
		{
			return value.ToString(format, NumberFormat);
		}

		public static string ToString(long value)
		{
			return value.ToString(NumberFormat);
		}

		public static string ToString(long value, string format)
		{
			return value.ToString(format, NumberFormat);
		}

		public static string ToString(short value)
		{
			return value.ToString(NumberFormat);
		}

		public static string ToString(short value, string format)
		{
			return value.ToString(format, NumberFormat);
		}

		public static string ToString(byte value)
		{
			return value.ToString(NumberFormat);
		}

		public static string ToString(byte value, string format)
		{
			return value.ToString(format, NumberFormat);
		}

		public static string ToString(sbyte value)
		{
			return value.ToString(NumberFormat);
		}

		public static string ToString(sbyte value, string format)
		{
			return value.ToString(format, NumberFormat);
		}

		public static string ToString(uint value)
		{
			return value.ToString(NumberFormat);
		}

		public static string ToString(uint value, string format)
		{
			return value.ToString(format, NumberFormat);
		}

		public static string ToString(ulong value)
		{
			return value.ToString(NumberFormat);
		}

		public static string ToString(ulong value, string format)
		{
			return value.ToString(format, NumberFormat);
		}

		public static string ToString(ushort value)
		{
			return value.ToString(NumberFormat);
		}

		public static string ToString(ushort value, string format)
		{
			return value.ToString(format, NumberFormat);
		}

		public static string ToString(bool value)
		{
			return value.ToString(Culture);
		}

		public static string ToString(char value)
		{
			return value.ToString(Culture);
		}

		public static string ToString(DateTime value)
		{
			return value.ToString(DateTimeFormat);
		}

		public static string ToString(DateTime value, string format)
		{
			return value.ToString(format, DateTimeFormat);
		}

		public static string ToString(DateTimeOffset value)
		{
			return value.ToString(DateTimeFormat);
		}

		public static string ToString(DateTimeOffset value, string format)
		{
			return value.ToString(format, DateTimeFormat);
		}

		public static string ToString(Guid value)
		{
			return value.ToString();
		}

		public static string ToString(Guid value, string format)
		{
			return value.ToString(format, Culture);
		}

		public static string ToString(TimeSpan value)
		{
			return value.ToString();
		}

		public static string ToString(TimeSpan value, string format)
		{
			return value.ToString(format, Culture);
		}

		public static string ToString(FormattableString value)
		{
			return value.ToString(Culture);
		}

		public static string ToString(string value, params object[] args)
		{
			return string.Format(Culture, value, args);
		}

		public static string ToString(string value, object arg0)
		{
			return string.Format(Culture, value, arg0);
		}

		public static string ToString(string value, object arg0, object arg1)
		{
			return string.Format(Culture, value, arg0, arg1);
		}

		public static string ToString(string value, object arg0, object arg1, object arg2)
		{
			return string.Format(Culture, value, arg0, arg1, arg2);
		}

		public static bool TryParseBool(string stringValue, out bool value)
		{
			return bool.TryParse(stringValue, out value);
		}

		public static bool? TryParseBool(string stringValue)
		{
			if (bool.TryParse(stringValue, out var result))
			{
				return result;
			}
			return null;
		}

		public static bool TryParseByte(string stringValue, out byte value)
		{
			return byte.TryParse(stringValue, NumberStyles.Integer, NumberFormat, out value);
		}

		public static byte? TryParseByte(string stringValue)
		{
			if (byte.TryParse(stringValue, NumberStyles.Integer, NumberFormat, out var result))
			{
				return result;
			}
			return null;
		}

		public static bool TryParseChar(string stringValue, out char value)
		{
			return char.TryParse(stringValue, out value);
		}

		public static char? TryParseChar(string stringValue)
		{
			if (char.TryParse(stringValue, out var result))
			{
				return result;
			}
			return null;
		}

		public static bool TryParseDateTime(string stringValue, out DateTime value)
		{
			return DateTime.TryParse(stringValue, DateTimeFormat, DateTimeStyles.None, out value);
		}

		public static DateTime? TryParseDateTime(string stringValue)
		{
			if (DateTime.TryParse(stringValue, DateTimeFormat, DateTimeStyles.None, out var result))
			{
				return result;
			}
			return null;
		}

		public static bool TryParseDateTimeOffset(string stringValue, out DateTimeOffset value)
		{
			return DateTimeOffset.TryParse(stringValue, DateTimeFormat, DateTimeStyles.None, out value);
		}

		public static DateTimeOffset? TryParseDateTimeOffset(string stringValue)
		{
			if (DateTimeOffset.TryParse(stringValue, DateTimeFormat, DateTimeStyles.None, out var result))
			{
				return result;
			}
			return null;
		}

		public static bool TryParseDouble(string stringValue, out double value)
		{
			return double.TryParse(stringValue, NumberStyleDouble, NumberFormat, out value);
		}

		public static double? TryParseDouble(string stringValue)
		{
			if (double.TryParse(stringValue, NumberStyleDouble, NumberFormat, out var result))
			{
				return result;
			}
			return null;
		}

		public static bool TryParseFloat(string stringValue, out float value)
		{
			return float.TryParse(stringValue, NumberStyleFloat, NumberFormat, out value);
		}

		public static float? TryParseFloat(string stringValue)
		{
			if (float.TryParse(stringValue, NumberStyleFloat, NumberFormat, out var result))
			{
				return result;
			}
			return null;
		}

		public static bool TryParseGuid(string stringValue, out Guid value)
		{
			return Guid.TryParse(stringValue, out value);
		}

		public static Guid? TryParseGuid(string stringValue)
		{
			if (Guid.TryParse(stringValue, out var result))
			{
				return result;
			}
			return null;
		}

		public static bool TryParseInt(string stringValue, out int value)
		{
			return int.TryParse(stringValue, NumberStyles.Integer, NumberFormat, out value);
		}

		public static int? TryParseInt(string stringValue)
		{
			if (int.TryParse(stringValue, NumberStyles.Integer, NumberFormat, out var result))
			{
				return result;
			}
			return null;
		}

		public static bool TryParseLong(string stringValue, out long value)
		{
			return long.TryParse(stringValue, NumberStyles.Integer, NumberFormat, out value);
		}

		public static long? TryParseLong(string stringValue)
		{
			if (long.TryParse(stringValue, NumberStyles.Integer, NumberFormat, out var result))
			{
				return result;
			}
			return null;
		}

		public static bool TryParseSByte(string stringValue, out sbyte value)
		{
			return sbyte.TryParse(stringValue, NumberStyles.Integer, NumberFormat, out value);
		}

		public static sbyte? TryParseSByte(string stringValue)
		{
			if (sbyte.TryParse(stringValue, NumberStyles.Integer, NumberFormat, out var result))
			{
				return result;
			}
			return null;
		}

		public static bool TryParseShort(string stringValue, out short value)
		{
			return short.TryParse(stringValue, NumberStyles.Integer, NumberFormat, out value);
		}

		public static short? TryParseShort(string stringValue)
		{
			if (short.TryParse(stringValue, NumberStyles.Integer, NumberFormat, out var result))
			{
				return result;
			}
			return null;
		}

		public static bool TryParseTimeSpan(string stringValue, out TimeSpan value)
		{
			return TimeSpan.TryParse(stringValue, Culture, out value);
		}

		public static TimeSpan? TryParseTimeSpan(string stringValue)
		{
			if (TimeSpan.TryParse(stringValue, Culture, out var result))
			{
				return result;
			}
			return null;
		}

		public static bool TryParseUInt(string stringValue, out uint value)
		{
			return uint.TryParse(stringValue, NumberStyles.Integer, NumberFormat, out value);
		}

		public static uint? TryParseUInt(string stringValue)
		{
			if (uint.TryParse(stringValue, NumberStyles.Integer, NumberFormat, out var result))
			{
				return result;
			}
			return null;
		}

		public static bool TryParseULong(string stringValue, out ulong value)
		{
			return ulong.TryParse(stringValue, NumberStyles.Integer, NumberFormat, out value);
		}

		public static ulong? TryParseULong(string stringValue)
		{
			if (ulong.TryParse(stringValue, NumberStyles.Integer, NumberFormat, out var result))
			{
				return result;
			}
			return null;
		}

		public static bool TryParseUShort(string stringValue, out ushort value)
		{
			return ushort.TryParse(stringValue, NumberStyles.Integer, NumberFormat, out value);
		}

		public static ushort? TryParseUShort(string stringValue)
		{
			if (ushort.TryParse(stringValue, NumberStyles.Integer, NumberFormat, out var result))
			{
				return result;
			}
			return null;
		}
	}
}
