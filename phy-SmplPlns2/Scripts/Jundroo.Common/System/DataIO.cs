using System.Globalization;
using Jundroo.Common.Math;
using Jundroo.Common.Utils;
using Unity.Mathematics;
using UnityEngine;

namespace System
{
	public static class DataIO
	{
		public static readonly CultureInfo Culture = CultureInfo.InvariantCulture;

		public static readonly DateTimeFormatInfo DateTimeFormat = CultureInfo.InvariantCulture.DateTimeFormat;

		public static readonly NumberFormatInfo NumberFormat = CultureInfo.InvariantCulture.NumberFormat;

		public static readonly NumberStyles NumberStyleDouble = NumberStyles.Float | NumberStyles.AllowThousands;

		public static readonly NumberStyles NumberStyleFloat = NumberStyles.Float | NumberStyles.AllowThousands;

		private const string InputStringFormatExceptionMessage = "Input string is not in the correct format";

		public static bool ParseBool(ReadOnlySpan<char> value)
		{
			return bool.Parse(value);
		}

		public static bool ParseBool(string value)
		{
			return bool.Parse(value);
		}

		public static bool ParseBool(ReadOnlySpan<char> value, bool defaultValue)
		{
			if (bool.TryParse(value, out var result))
			{
				return result;
			}
			return defaultValue;
		}

		public static bool ParseBool(string value, bool defaultValue)
		{
			if (bool.TryParse(value, out var result))
			{
				return result;
			}
			return defaultValue;
		}

		public static bool2 ParseBool2(ReadOnlySpan<char> value)
		{
			if (!TryParseBool2(value, out var result))
			{
				throw new FormatException("Input string is not in the correct format");
			}
			return result;
		}

		public static bool2 ParseBool2(string value)
		{
			if (!TryParseBool2(value, out var result))
			{
				throw new FormatException("Input string is not in the correct format");
			}
			return result;
		}

		public static bool3 ParseBool3(ReadOnlySpan<char> value)
		{
			if (!TryParseBool3(value, out var result))
			{
				throw new FormatException("Input string is not in the correct format");
			}
			return result;
		}

		public static bool3 ParseBool3(string value)
		{
			if (!TryParseBool3(value, out var result))
			{
				throw new FormatException("Input string is not in the correct format");
			}
			return result;
		}

		public static bool4 ParseBool4(ReadOnlySpan<char> value)
		{
			if (!TryParseBool4(value, out var result))
			{
				throw new FormatException("Input string is not in the correct format");
			}
			return result;
		}

		public static bool4 ParseBool4(string value)
		{
			if (!TryParseBool4(value, out var result))
			{
				throw new FormatException("Input string is not in the correct format");
			}
			return result;
		}

		public static bool2 ParseBool2(ReadOnlySpan<char> value, bool2 defaultValue)
		{
			if (!TryParseBool2(value, out var result))
			{
				return defaultValue;
			}
			return result;
		}

		public static bool2 ParseBool2(string value, bool2 defaultValue)
		{
			if (!TryParseBool2(value, out var result))
			{
				return defaultValue;
			}
			return result;
		}

		public static bool3 ParseBool3(ReadOnlySpan<char> value, bool3 defaultValue)
		{
			if (!TryParseBool3(value, out var result))
			{
				return defaultValue;
			}
			return result;
		}

		public static bool3 ParseBool3(string value, bool3 defaultValue)
		{
			if (!TryParseBool3(value, out var result))
			{
				return defaultValue;
			}
			return result;
		}

		public static bool4 ParseBool4(ReadOnlySpan<char> value, bool4 defaultValue)
		{
			if (!TryParseBool4(value, out var result))
			{
				return defaultValue;
			}
			return result;
		}

		public static bool4 ParseBool4(string value, bool4 defaultValue)
		{
			if (!TryParseBool4(value, out var result))
			{
				return defaultValue;
			}
			return result;
		}

		public static bool? ParseBoolNullable(ReadOnlySpan<char> value, bool? defaultValue)
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

		public static byte ParseByte(ReadOnlySpan<char> value)
		{
			return byte.Parse(value, NumberStyles.Integer, NumberFormat);
		}

		public static byte ParseByte(string value)
		{
			return byte.Parse(value, NumberFormat);
		}

		public static byte ParseByte(ReadOnlySpan<char> value, byte defaultValue)
		{
			if (byte.TryParse(value, NumberStyles.Integer, NumberFormat, out var result))
			{
				return result;
			}
			return defaultValue;
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

		public static DateTime ParseDateTime(ReadOnlySpan<char> value)
		{
			return DateTime.Parse(value, DateTimeFormat);
		}

		public static DateTime ParseDateTime(string value)
		{
			return DateTime.Parse(value, DateTimeFormat);
		}

		public static DateTime ParseDateTime(ReadOnlySpan<char> value, DateTime defaultValue)
		{
			if (DateTime.TryParse(value, DateTimeFormat, DateTimeStyles.None, out var result))
			{
				return result;
			}
			return defaultValue;
		}

		public static DateTime ParseDateTime(string value, DateTime defaultValue)
		{
			if (DateTime.TryParse(value, DateTimeFormat, DateTimeStyles.None, out var result))
			{
				return result;
			}
			return defaultValue;
		}

		public static DateTimeOffset ParseDateTimeOffset(ReadOnlySpan<char> value)
		{
			return DateTimeOffset.Parse(value, DateTimeFormat);
		}

		public static DateTimeOffset ParseDateTimeOffset(string value)
		{
			return DateTimeOffset.Parse(value, DateTimeFormat);
		}

		public static DateTimeOffset ParseDateTimeOffset(ReadOnlySpan<char> value, DateTimeOffset defaultValue)
		{
			if (DateTimeOffset.TryParse(value, DateTimeFormat, DateTimeStyles.None, out var result))
			{
				return result;
			}
			return defaultValue;
		}

		public static DateTimeOffset ParseDateTimeOffset(string value, DateTimeOffset defaultValue)
		{
			if (DateTimeOffset.TryParse(value, DateTimeFormat, DateTimeStyles.None, out var result))
			{
				return result;
			}
			return defaultValue;
		}

		public static double ParseDouble(ReadOnlySpan<char> value)
		{
			return double.Parse(value, NumberStyleDouble, NumberFormat);
		}

		public static double ParseDouble(string value)
		{
			return double.Parse(value, NumberFormat);
		}

		public static double ParseDouble(ReadOnlySpan<char> value, double defaultValue)
		{
			if (double.TryParse(value, NumberStyleDouble, NumberFormat, out var result))
			{
				return result;
			}
			return defaultValue;
		}

		public static double ParseDouble(string value, double defaultValue)
		{
			if (double.TryParse(value, NumberStyleDouble, NumberFormat, out var result))
			{
				return result;
			}
			return defaultValue;
		}

		public static double2 ParseDouble2(ReadOnlySpan<char> value)
		{
			if (!TryParseDouble2(value, out var result))
			{
				throw new FormatException("Input string is not in the correct format");
			}
			return result;
		}

		public static double2 ParseDouble2(ReadOnlySpan<char> value, double2 defaultValue)
		{
			if (!TryParseDouble2(value, out var result))
			{
				return defaultValue;
			}
			return result;
		}

		public static double2 ParseDouble2(string value)
		{
			if (!TryParseDouble2(value.AsSpan(), out var result))
			{
				throw new FormatException("Input string is not in the correct format");
			}
			return result;
		}

		public static double2 ParseDouble2(string value, double2 defaultValue)
		{
			if (!TryParseDouble2(value.AsSpan(), out var result))
			{
				return defaultValue;
			}
			return result;
		}

		public static double3 ParseDouble3(ReadOnlySpan<char> value)
		{
			if (!TryParseDouble3(value, out var result))
			{
				throw new FormatException("Input string is not in the correct format");
			}
			return result;
		}

		public static double3 ParseDouble3(ReadOnlySpan<char> value, double3 defaultValue)
		{
			if (!TryParseDouble3(value, out var result))
			{
				return defaultValue;
			}
			return result;
		}

		public static double3 ParseDouble3(string value)
		{
			if (!TryParseDouble3(value.AsSpan(), out var result))
			{
				throw new FormatException("Input string is not in the correct format");
			}
			return result;
		}

		public static double3 ParseDouble3(string value, double3 defaultValue)
		{
			if (!TryParseDouble3(value.AsSpan(), out var result))
			{
				return defaultValue;
			}
			return result;
		}

		public static double4 ParseDouble4(ReadOnlySpan<char> value)
		{
			if (!TryParseDouble4(value, out var result))
			{
				throw new FormatException("Input string is not in the correct format");
			}
			return result;
		}

		public static double4 ParseDouble4(ReadOnlySpan<char> value, double4 defaultValue)
		{
			if (!TryParseDouble4(value, out var result))
			{
				return defaultValue;
			}
			return result;
		}

		public static double4 ParseDouble4(string value)
		{
			if (!TryParseDouble4(value.AsSpan(), out var result))
			{
				throw new FormatException("Input string is not in the correct format");
			}
			return result;
		}

		public static double4 ParseDouble4(string value, double4 defaultValue)
		{
			if (!TryParseDouble4(value.AsSpan(), out var result))
			{
				return defaultValue;
			}
			return result;
		}

		public static float ParseFloat(ReadOnlySpan<char> value)
		{
			return float.Parse(value, NumberStyleFloat, NumberFormat);
		}

		public static float ParseFloat(string value)
		{
			return float.Parse(value, NumberFormat);
		}

		public static float ParseFloat(ReadOnlySpan<char> value, float defaultValue)
		{
			if (float.TryParse(value, NumberStyleFloat, NumberFormat, out var result))
			{
				return result;
			}
			return defaultValue;
		}

		public static float ParseFloat(string value, float defaultValue)
		{
			if (float.TryParse(value, NumberStyleFloat, NumberFormat, out var result))
			{
				return result;
			}
			return defaultValue;
		}

		public static float2 ParseFloat2(ReadOnlySpan<char> value)
		{
			if (!TryParseFloat2(value, out var result))
			{
				throw new FormatException("Input string is not in the correct format");
			}
			return result;
		}

		public static float2 ParseFloat2(ReadOnlySpan<char> value, float2 defaultValue)
		{
			if (!TryParseFloat2(value, out var result))
			{
				return defaultValue;
			}
			return result;
		}

		public static float2 ParseFloat2(string value)
		{
			if (!TryParseFloat2(value.AsSpan(), out var result))
			{
				throw new FormatException("Input string is not in the correct format");
			}
			return result;
		}

		public static float2 ParseFloat2(string value, float2 defaultValue)
		{
			if (!TryParseFloat2(value.AsSpan(), out var result))
			{
				return defaultValue;
			}
			return result;
		}

		public static float3 ParseFloat3(ReadOnlySpan<char> value)
		{
			if (!TryParseFloat3(value, out var result))
			{
				throw new FormatException("Input string is not in the correct format");
			}
			return result;
		}

		public static float3 ParseFloat3(ReadOnlySpan<char> value, float3 defaultValue)
		{
			if (!TryParseFloat3(value, out var result))
			{
				return defaultValue;
			}
			return result;
		}

		public static float3 ParseFloat3(string value)
		{
			if (!TryParseFloat3(value.AsSpan(), out var result))
			{
				throw new FormatException("Input string is not in the correct format");
			}
			return result;
		}

		public static float3 ParseFloat3(string value, float3 defaultValue)
		{
			if (!TryParseFloat3(value.AsSpan(), out var result))
			{
				return defaultValue;
			}
			return result;
		}

		public static float4 ParseFloat4(ReadOnlySpan<char> value)
		{
			if (!TryParseFloat4(value, out var result))
			{
				throw new FormatException("Input string is not in the correct format");
			}
			return result;
		}

		public static float4 ParseFloat4(ReadOnlySpan<char> value, float4 defaultValue)
		{
			if (!TryParseFloat4(value, out var result))
			{
				return defaultValue;
			}
			return result;
		}

		public static float4 ParseFloat4(string value)
		{
			if (!TryParseFloat4(value.AsSpan(), out var result))
			{
				throw new FormatException("Input string is not in the correct format");
			}
			return result;
		}

		public static float4 ParseFloat4(string value, float4 defaultValue)
		{
			if (!TryParseFloat4(value.AsSpan(), out var result))
			{
				return defaultValue;
			}
			return result;
		}

		public static Guid ParseGuid(ReadOnlySpan<char> value)
		{
			return Guid.Parse(value);
		}

		public static Guid ParseGuid(string value)
		{
			return Guid.Parse(value);
		}

		public static Guid ParseGuid(ReadOnlySpan<char> value, Guid defaultValue)
		{
			if (Guid.TryParse(value, out var result))
			{
				return result;
			}
			return defaultValue;
		}

		public static Guid ParseGuid(string value, Guid defaultValue)
		{
			if (Guid.TryParse(value, out var result))
			{
				return result;
			}
			return defaultValue;
		}

		public static int ParseInt(ReadOnlySpan<char> value)
		{
			return int.Parse(value, NumberStyles.Integer, NumberFormat);
		}

		public static int ParseInt(string value)
		{
			return int.Parse(value, NumberFormat);
		}

		public static int ParseInt(ReadOnlySpan<char> value, int defaultValue)
		{
			if (int.TryParse(value, NumberStyles.Integer, NumberFormat, out var result))
			{
				return result;
			}
			return defaultValue;
		}

		public static int ParseInt(string value, int defaultValue)
		{
			if (int.TryParse(value, NumberStyles.Integer, NumberFormat, out var result))
			{
				return result;
			}
			return defaultValue;
		}

		public static int2 ParseInt2(ReadOnlySpan<char> value)
		{
			if (!TryParseInt2(value, out var result))
			{
				throw new FormatException("Input string is not in the correct format");
			}
			return result;
		}

		public static int2 ParseInt2(ReadOnlySpan<char> value, int2 defaultValue)
		{
			if (!TryParseInt2(value, out var result))
			{
				return defaultValue;
			}
			return result;
		}

		public static int2 ParseInt2(string value)
		{
			if (!TryParseInt2(value.AsSpan(), out var result))
			{
				throw new FormatException("Input string is not in the correct format");
			}
			return result;
		}

		public static int2 ParseInt2(string value, int2 defaultValue)
		{
			if (!TryParseInt2(value.AsSpan(), out var result))
			{
				return defaultValue;
			}
			return result;
		}

		public static int3 ParseInt3(ReadOnlySpan<char> value)
		{
			if (!TryParseInt3(value, out var result))
			{
				throw new FormatException("Input string is not in the correct format");
			}
			return result;
		}

		public static int3 ParseInt3(ReadOnlySpan<char> value, int3 defaultValue)
		{
			if (!TryParseInt3(value, out var result))
			{
				return defaultValue;
			}
			return result;
		}

		public static int3 ParseInt3(string value)
		{
			if (!TryParseInt3(value.AsSpan(), out var result))
			{
				throw new FormatException("Input string is not in the correct format");
			}
			return result;
		}

		public static int3 ParseInt3(string value, int3 defaultValue)
		{
			if (!TryParseInt3(value.AsSpan(), out var result))
			{
				return defaultValue;
			}
			return result;
		}

		public static int4 ParseInt4(ReadOnlySpan<char> value)
		{
			if (!TryParseInt4(value, out var result))
			{
				throw new FormatException("Input string is not in the correct format");
			}
			return result;
		}

		public static int4 ParseInt4(ReadOnlySpan<char> value, int4 defaultValue)
		{
			if (!TryParseInt4(value, out var result))
			{
				return defaultValue;
			}
			return result;
		}

		public static int4 ParseInt4(string value)
		{
			if (!TryParseInt4(value.AsSpan(), out var result))
			{
				throw new FormatException("Input string is not in the correct format");
			}
			return result;
		}

		public static int4 ParseInt4(string value, int4 defaultValue)
		{
			if (!TryParseInt4(value.AsSpan(), out var result))
			{
				return defaultValue;
			}
			return result;
		}

		public static long ParseLong(ReadOnlySpan<char> value)
		{
			return long.Parse(value, NumberStyles.Integer, NumberFormat);
		}

		public static long ParseLong(string value)
		{
			return long.Parse(value, NumberFormat);
		}

		public static long ParseLong(ReadOnlySpan<char> value, long defaultValue)
		{
			if (long.TryParse(value, NumberStyles.Integer, NumberFormat, out var result))
			{
				return result;
			}
			return defaultValue;
		}

		public static long ParseLong(string value, long defaultValue)
		{
			if (long.TryParse(value, NumberStyles.Integer, NumberFormat, out var result))
			{
				return result;
			}
			return defaultValue;
		}

		public static RangeFloat ParseRangeFloat(ReadOnlySpan<char> value)
		{
			if (!TryParseRangeFloat(value, out var result))
			{
				throw new FormatException("Input string is not in the correct format");
			}
			return result;
		}

		public static RangeFloat ParseRangeFloat(ReadOnlySpan<char> value, RangeFloat defaultValue)
		{
			if (!TryParseRangeFloat(value, out var result))
			{
				return defaultValue;
			}
			return result;
		}

		public static RangeFloat ParseRangeFloat(string value)
		{
			if (!TryParseRangeFloat(value.AsSpan(), out var result))
			{
				throw new FormatException("Input string is not in the correct format");
			}
			return result;
		}

		public static RangeFloat ParseRangeFloat(string value, RangeFloat defaultValue)
		{
			if (!TryParseRangeFloat(value.AsSpan(), out var result))
			{
				return defaultValue;
			}
			return result;
		}

		public static RangeInteger ParseRangeInteger(ReadOnlySpan<char> value)
		{
			if (!TryParseRangeInteger(value, out var result))
			{
				throw new FormatException("Input string is not in the correct format");
			}
			return result;
		}

		public static RangeInteger ParseRangeInteger(ReadOnlySpan<char> value, RangeInteger defaultValue)
		{
			if (!TryParseRangeInteger(value, out var result))
			{
				return defaultValue;
			}
			return result;
		}

		public static RangeInteger ParseRangeInteger(string value)
		{
			if (!TryParseRangeInteger(value.AsSpan(), out var result))
			{
				throw new FormatException("Input string is not in the correct format");
			}
			return result;
		}

		public static RangeInteger ParseRangeInteger(string value, RangeInteger defaultValue)
		{
			if (!TryParseRangeInteger(value.AsSpan(), out var result))
			{
				return defaultValue;
			}
			return result;
		}

		public static sbyte ParseSByte(ReadOnlySpan<char> value)
		{
			return sbyte.Parse(value, NumberStyles.Integer, NumberFormat);
		}

		public static sbyte ParseSByte(string value)
		{
			return sbyte.Parse(value, NumberFormat);
		}

		public static sbyte ParseSByte(ReadOnlySpan<char> value, sbyte defaultValue)
		{
			if (sbyte.TryParse(value, NumberStyles.Integer, NumberFormat, out var result))
			{
				return result;
			}
			return defaultValue;
		}

		public static sbyte ParseSByte(string value, sbyte defaultValue)
		{
			if (sbyte.TryParse(value, NumberStyles.Integer, NumberFormat, out var result))
			{
				return result;
			}
			return defaultValue;
		}

		public static short ParseShort(ReadOnlySpan<char> value)
		{
			return short.Parse(value, NumberStyles.Integer, NumberFormat);
		}

		public static short ParseShort(string value)
		{
			return short.Parse(value, NumberFormat);
		}

		public static short ParseShort(ReadOnlySpan<char> value, short defaultValue)
		{
			if (short.TryParse(value, NumberStyles.Integer, NumberFormat, out var result))
			{
				return result;
			}
			return defaultValue;
		}

		public static short ParseShort(string value, short defaultValue)
		{
			if (short.TryParse(value, NumberStyles.Integer, NumberFormat, out var result))
			{
				return result;
			}
			return defaultValue;
		}

		public static TimeSpan ParseTimeSpan(ReadOnlySpan<char> value)
		{
			return TimeSpan.Parse(value, Culture);
		}

		public static TimeSpan ParseTimeSpan(string value)
		{
			return TimeSpan.Parse(value, Culture);
		}

		public static TimeSpan ParseTimeSpan(ReadOnlySpan<char> value, TimeSpan defaultValue)
		{
			if (TimeSpan.TryParse(value, Culture, out var result))
			{
				return result;
			}
			return defaultValue;
		}

		public static TimeSpan ParseTimeSpan(string value, TimeSpan defaultValue)
		{
			if (TimeSpan.TryParse(value, Culture, out var result))
			{
				return result;
			}
			return defaultValue;
		}

		public static uint ParseUInt(ReadOnlySpan<char> value)
		{
			return uint.Parse(value, NumberStyles.Integer, NumberFormat);
		}

		public static uint ParseUInt(string value)
		{
			return uint.Parse(value, NumberFormat);
		}

		public static uint ParseUInt(ReadOnlySpan<char> value, uint defaultValue)
		{
			if (uint.TryParse(value, NumberStyles.Integer, NumberFormat, out var result))
			{
				return result;
			}
			return defaultValue;
		}

		public static uint ParseUInt(string value, uint defaultValue)
		{
			if (uint.TryParse(value, NumberStyles.Integer, NumberFormat, out var result))
			{
				return result;
			}
			return defaultValue;
		}

		public static ulong ParseULong(ReadOnlySpan<char> value)
		{
			return ulong.Parse(value, NumberStyles.Integer, NumberFormat);
		}

		public static ulong ParseULong(string value)
		{
			return ulong.Parse(value, NumberFormat);
		}

		public static ulong ParseULong(ReadOnlySpan<char> value, ulong defaultValue)
		{
			if (ulong.TryParse(value, NumberStyles.Integer, NumberFormat, out var result))
			{
				return result;
			}
			return defaultValue;
		}

		public static ulong ParseULong(string value, ulong defaultValue)
		{
			if (ulong.TryParse(value, NumberStyles.Integer, NumberFormat, out var result))
			{
				return result;
			}
			return defaultValue;
		}

		public static ushort ParseUShort(ReadOnlySpan<char> value)
		{
			return ushort.Parse(value, NumberStyles.Integer, NumberFormat);
		}

		public static ushort ParseUShort(string value)
		{
			return ushort.Parse(value, NumberFormat);
		}

		public static ushort ParseUShort(ReadOnlySpan<char> value, ushort defaultValue)
		{
			if (ushort.TryParse(value, NumberStyles.Integer, NumberFormat, out var result))
			{
				return result;
			}
			return defaultValue;
		}

		public static ushort ParseUShort(string value, ushort defaultValue)
		{
			if (ushort.TryParse(value, NumberStyles.Integer, NumberFormat, out var result))
			{
				return result;
			}
			return defaultValue;
		}

		public static Vector2 ParseVector2(ReadOnlySpan<char> value)
		{
			if (!TryParseVector2(value, out var result))
			{
				throw new FormatException("Input string is not in the correct format");
			}
			return result;
		}

		public static Vector2 ParseVector2(ReadOnlySpan<char> value, Vector2 defaultValue)
		{
			if (!TryParseVector2(value, out var result))
			{
				return defaultValue;
			}
			return result;
		}

		public static Vector2 ParseVector2(string value)
		{
			if (!TryParseVector2(value.AsSpan(), out var result))
			{
				throw new FormatException("Input string is not in the correct format");
			}
			return result;
		}

		public static Vector2 ParseVector2(string value, Vector2 defaultValue)
		{
			if (!TryParseVector2(value.AsSpan(), out var result))
			{
				return defaultValue;
			}
			return result;
		}

		public static Vector2d ParseVector2d(ReadOnlySpan<char> value)
		{
			if (!TryParseVector2d(value, out var result))
			{
				throw new FormatException("Input string is not in the correct format");
			}
			return result;
		}

		public static Vector2d ParseVector2d(ReadOnlySpan<char> value, Vector2d defaultValue)
		{
			if (!TryParseVector2d(value, out var result))
			{
				return defaultValue;
			}
			return result;
		}

		public static Vector2d ParseVector2d(string value)
		{
			if (!TryParseVector2d(value.AsSpan(), out var result))
			{
				throw new FormatException("Input string is not in the correct format");
			}
			return result;
		}

		public static Vector2d ParseVector2d(string value, Vector2d defaultValue)
		{
			if (!TryParseVector2d(value.AsSpan(), out var result))
			{
				return defaultValue;
			}
			return result;
		}

		public static Vector2i ParseVector2i(ReadOnlySpan<char> value)
		{
			if (!TryParseVector2i(value, out var result))
			{
				throw new FormatException("Input string is not in the correct format");
			}
			return result;
		}

		public static Vector2i ParseVector2i(ReadOnlySpan<char> value, Vector2i defaultValue)
		{
			if (!TryParseVector2i(value, out var result))
			{
				return defaultValue;
			}
			return result;
		}

		public static Vector2i ParseVector2i(string value)
		{
			if (!TryParseVector2i(value.AsSpan(), out var result))
			{
				throw new FormatException("Input string is not in the correct format");
			}
			return result;
		}

		public static Vector2i ParseVector2i(string value, Vector2i defaultValue)
		{
			if (!TryParseVector2i(value.AsSpan(), out var result))
			{
				return defaultValue;
			}
			return result;
		}

		public static Vector3 ParseVector3(ReadOnlySpan<char> value)
		{
			if (!TryParseVector3(value, out var result))
			{
				throw new FormatException("Input string is not in the correct format");
			}
			return result;
		}

		public static Vector3 ParseVector3(ReadOnlySpan<char> value, Vector3 defaultValue)
		{
			if (!TryParseVector3(value, out var result))
			{
				return defaultValue;
			}
			return result;
		}

		public static Vector3 ParseVector3(string value)
		{
			if (!TryParseVector3(value.AsSpan(), out var result))
			{
				throw new FormatException("Input string is not in the correct format");
			}
			return result;
		}

		public static Vector3 ParseVector3(string value, Vector3 defaultValue)
		{
			if (!TryParseVector3(value.AsSpan(), out var result))
			{
				return defaultValue;
			}
			return result;
		}

		public static Vector3d ParseVector3d(ReadOnlySpan<char> value)
		{
			if (!TryParseVector3d(value, out var result))
			{
				throw new FormatException("Input string is not in the correct format");
			}
			return result;
		}

		public static Vector3d ParseVector3d(ReadOnlySpan<char> value, Vector3d defaultValue)
		{
			if (!TryParseVector3d(value, out var result))
			{
				return defaultValue;
			}
			return result;
		}

		public static Vector3d ParseVector3d(string value)
		{
			if (!TryParseVector3d(value.AsSpan(), out var result))
			{
				throw new FormatException("Input string is not in the correct format");
			}
			return result;
		}

		public static Vector3d ParseVector3d(string value, Vector3d defaultValue)
		{
			if (!TryParseVector3d(value.AsSpan(), out var result))
			{
				return defaultValue;
			}
			return result;
		}

		public static Vector3i ParseVector3i(ReadOnlySpan<char> value)
		{
			if (!TryParseVector3i(value, out var result))
			{
				throw new FormatException("Input string is not in the correct format");
			}
			return result;
		}

		public static Vector3i ParseVector3i(ReadOnlySpan<char> value, Vector3i defaultValue)
		{
			if (!TryParseVector3i(value, out var result))
			{
				return defaultValue;
			}
			return result;
		}

		public static Vector3i ParseVector3i(string value)
		{
			if (!TryParseVector3i(value.AsSpan(), out var result))
			{
				throw new FormatException("Input string is not in the correct format");
			}
			return result;
		}

		public static Vector3i ParseVector3i(string value, Vector3i defaultValue)
		{
			if (!TryParseVector3i(value.AsSpan(), out var result))
			{
				return defaultValue;
			}
			return result;
		}

		public static Vector4 ParseVector4(ReadOnlySpan<char> value)
		{
			if (!TryParseVector4(value, out var result))
			{
				throw new FormatException("Input string is not in the correct format");
			}
			return result;
		}

		public static Vector4 ParseVector4(ReadOnlySpan<char> value, Vector4 defaultValue)
		{
			if (!TryParseVector4(value, out var result))
			{
				return defaultValue;
			}
			return result;
		}

		public static Vector4 ParseVector4(string value)
		{
			if (!TryParseVector4(value.AsSpan(), out var result))
			{
				throw new FormatException("Input string is not in the correct format");
			}
			return result;
		}

		public static Vector4 ParseVector4(string value, Vector4 defaultValue)
		{
			if (!TryParseVector4(value.AsSpan(), out var result))
			{
				return defaultValue;
			}
			return result;
		}

		public static Vector4d ParseVector4d(ReadOnlySpan<char> value)
		{
			if (!TryParseVector4d(value, out var result))
			{
				throw new FormatException("Input string is not in the correct format");
			}
			return result;
		}

		public static Vector4d ParseVector4d(ReadOnlySpan<char> value, Vector4d defaultValue)
		{
			if (!TryParseVector4d(value, out var result))
			{
				return defaultValue;
			}
			return result;
		}

		public static Vector4d ParseVector4d(string value)
		{
			if (!TryParseVector4d(value.AsSpan(), out var result))
			{
				throw new FormatException("Input string is not in the correct format");
			}
			return result;
		}

		public static Vector4d ParseVector4d(string value, Vector4d defaultValue)
		{
			if (!TryParseVector4d(value.AsSpan(), out var result))
			{
				return defaultValue;
			}
			return result;
		}

		public static Vector4i ParseVector4i(ReadOnlySpan<char> value)
		{
			if (!TryParseVector4i(value, out var result))
			{
				throw new FormatException("Input string is not in the correct format");
			}
			return result;
		}

		public static Vector4i ParseVector4i(ReadOnlySpan<char> value, Vector4i defaultValue)
		{
			if (!TryParseVector4i(value, out var result))
			{
				return defaultValue;
			}
			return result;
		}

		public static Vector4i ParseVector4i(string value)
		{
			if (!TryParseVector4i(value.AsSpan(), out var result))
			{
				throw new FormatException("Input string is not in the correct format");
			}
			return result;
		}

		public static Vector4i ParseVector4i(string value, Vector4i defaultValue)
		{
			if (!TryParseVector4i(value.AsSpan(), out var result))
			{
				return defaultValue;
			}
			return result;
		}

		public static Vector4m ParseVector4m(ReadOnlySpan<char> value)
		{
			if (!TryParseVector4m(value, out var result))
			{
				throw new FormatException("Input string is not in the correct format");
			}
			return result;
		}

		public static Vector4m ParseVector4m(ReadOnlySpan<char> value, Vector4m defaultValue)
		{
			if (!TryParseVector4m(value, out var result))
			{
				return defaultValue;
			}
			return result;
		}

		public static Vector4m ParseVector4m(string value)
		{
			if (!TryParseVector4m(value.AsSpan(), out var result))
			{
				throw new FormatException("Input string is not in the correct format");
			}
			return result;
		}

		public static Vector4m ParseVector4m(string value, Vector4m defaultValue)
		{
			if (!TryParseVector4m(value.AsSpan(), out var result))
			{
				return defaultValue;
			}
			return result;
		}

		public static string ToString(float value)
		{
			return value.ToString(NumberFormat);
		}

		public static string ToString(decimal value)
		{
			return value.ToString(NumberFormat);
		}

		public static string ToString(RangeFloat value)
		{
			return ToString(value.Start) + "," + ToString(value.Length);
		}

		public static string ToString(RangeInteger value)
		{
			return ToString(value.Start) + "," + ToString(value.Length);
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

		public static bool TryParseBool(ReadOnlySpan<char> stringValue, out bool value)
		{
			return bool.TryParse(stringValue, out value);
		}

		public static bool TryParseBool(string stringValue, out bool value)
		{
			return bool.TryParse(stringValue, out value);
		}

		public static bool? TryParseBool(ReadOnlySpan<char> stringValue)
		{
			if (bool.TryParse(stringValue, out var result))
			{
				return result;
			}
			return null;
		}

		public static bool? TryParseBool(string stringValue)
		{
			if (bool.TryParse(stringValue, out var result))
			{
				return result;
			}
			return null;
		}

		public static bool TryParseBool2(ReadOnlySpan<char> value, out bool2 result)
		{
			result = default(bool2);
			if (value.Length == 0)
			{
				return false;
			}
			if (value[0] == '(')
			{
				value = value.TrimStart('(').TrimEnd(')');
			}
			StringUtility.StringSplitEnumerator enumerator = StringUtility.SpanSplit(value, ',').GetEnumerator();
			while (enumerator.MoveNext())
			{
				StringUtility.StringSplitEntry current = enumerator.Current;
				if (!bool.TryParse(current.Span, out var result2))
				{
					return false;
				}
				if (current.Index == 0)
				{
					result.x = result2;
				}
				else if (current.Index == 1)
				{
					result.y = result2;
					return true;
				}
			}
			return false;
		}

		public static bool TryParseBool3(ReadOnlySpan<char> value, out bool3 result)
		{
			result = default(bool3);
			if (value.Length == 0)
			{
				return false;
			}
			if (value[0] == '(')
			{
				value = value.TrimStart('(').TrimEnd(')');
			}
			StringUtility.StringSplitEnumerator enumerator = StringUtility.SpanSplit(value, ',').GetEnumerator();
			while (enumerator.MoveNext())
			{
				StringUtility.StringSplitEntry current = enumerator.Current;
				if (!bool.TryParse(current.Span, out var result2))
				{
					return false;
				}
				if (current.Index == 0)
				{
					result.x = result2;
				}
				else if (current.Index == 1)
				{
					result.y = result2;
				}
				else if (current.Index == 2)
				{
					result.z = result2;
					return true;
				}
			}
			return false;
		}

		public static bool TryParseBool4(ReadOnlySpan<char> value, out bool4 result)
		{
			result = default(bool4);
			if (value.Length == 0)
			{
				return false;
			}
			if (value[0] == '(')
			{
				value = value.TrimStart('(').TrimEnd(')');
			}
			StringUtility.StringSplitEnumerator enumerator = StringUtility.SpanSplit(value, ',').GetEnumerator();
			while (enumerator.MoveNext())
			{
				StringUtility.StringSplitEntry current = enumerator.Current;
				if (!bool.TryParse(current.Span, out var result2))
				{
					return false;
				}
				if (current.Index == 0)
				{
					result.x = result2;
				}
				else if (current.Index == 1)
				{
					result.y = result2;
				}
				else if (current.Index == 2)
				{
					result.z = result2;
				}
				else if (current.Index == 3)
				{
					result.w = result2;
					return true;
				}
			}
			return false;
		}

		public static bool TryParseByte(ReadOnlySpan<char> stringValue, out byte value)
		{
			return byte.TryParse(stringValue, NumberStyles.Integer, NumberFormat, out value);
		}

		public static bool TryParseByte(string stringValue, out byte value)
		{
			return byte.TryParse(stringValue, NumberStyles.Integer, NumberFormat, out value);
		}

		public static byte? TryParseByte(ReadOnlySpan<char> stringValue)
		{
			if (byte.TryParse(stringValue, NumberStyles.Integer, NumberFormat, out var result))
			{
				return result;
			}
			return null;
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

		public static bool TryParseDateTime(ReadOnlySpan<char> stringValue, out DateTime value)
		{
			return DateTime.TryParse(stringValue, DateTimeFormat, DateTimeStyles.None, out value);
		}

		public static bool TryParseDateTime(string stringValue, out DateTime value)
		{
			return DateTime.TryParse(stringValue, DateTimeFormat, DateTimeStyles.None, out value);
		}

		public static DateTime? TryParseDateTime(ReadOnlySpan<char> stringValue)
		{
			if (DateTime.TryParse(stringValue, DateTimeFormat, DateTimeStyles.None, out var result))
			{
				return result;
			}
			return null;
		}

		public static DateTime? TryParseDateTime(string stringValue)
		{
			if (DateTime.TryParse(stringValue, DateTimeFormat, DateTimeStyles.None, out var result))
			{
				return result;
			}
			return null;
		}

		public static bool TryParseDateTimeOffset(ReadOnlySpan<char> stringValue, out DateTimeOffset value)
		{
			return DateTimeOffset.TryParse(stringValue, DateTimeFormat, DateTimeStyles.None, out value);
		}

		public static bool TryParseDateTimeOffset(string stringValue, out DateTimeOffset value)
		{
			return DateTimeOffset.TryParse(stringValue, DateTimeFormat, DateTimeStyles.None, out value);
		}

		public static DateTimeOffset? TryParseDateTimeOffset(ReadOnlySpan<char> stringValue)
		{
			if (DateTimeOffset.TryParse(stringValue, DateTimeFormat, DateTimeStyles.None, out var result))
			{
				return result;
			}
			return null;
		}

		public static DateTimeOffset? TryParseDateTimeOffset(string stringValue)
		{
			if (DateTimeOffset.TryParse(stringValue, DateTimeFormat, DateTimeStyles.None, out var result))
			{
				return result;
			}
			return null;
		}

		public static bool TryParseDecimal(ReadOnlySpan<char> stringValue, out decimal value)
		{
			return decimal.TryParse(stringValue, NumberStyleFloat, NumberFormat, out value);
		}

		public static bool TryParseDouble(ReadOnlySpan<char> stringValue, out double value)
		{
			return double.TryParse(stringValue, NumberStyleDouble, NumberFormat, out value);
		}

		public static bool TryParseDouble(string stringValue, out double value)
		{
			return double.TryParse(stringValue, NumberStyleDouble, NumberFormat, out value);
		}

		public static double? TryParseDouble(ReadOnlySpan<char> stringValue)
		{
			if (double.TryParse(stringValue, NumberStyleDouble, NumberFormat, out var result))
			{
				return result;
			}
			return null;
		}

		public static double? TryParseDouble(string stringValue)
		{
			if (double.TryParse(stringValue, NumberStyleDouble, NumberFormat, out var result))
			{
				return result;
			}
			return null;
		}

		public static bool TryParseDouble2(ReadOnlySpan<char> value, out double2 result)
		{
			result = default(double2);
			if (value.Length == 0)
			{
				return false;
			}
			StringUtility.StringSplitEnumerator enumerator = StringUtility.SpanSplit(value, ',').GetEnumerator();
			while (enumerator.MoveNext())
			{
				StringUtility.StringSplitEntry current = enumerator.Current;
				if (!double.TryParse(current.Span, NumberStyleDouble, NumberFormat, out var result2))
				{
					return false;
				}
				if (current.Index == 0)
				{
					result.x = result2;
				}
				else if (current.Index == 1)
				{
					result.y = result2;
					return true;
				}
			}
			return false;
		}

		public static double2? TryParseDouble2(ReadOnlySpan<char> value)
		{
			if (!TryParseDouble2(value, out var result))
			{
				return null;
			}
			return result;
		}

		public static bool TryParseDouble2(string value, out double2 result)
		{
			return TryParseDouble2(value.AsSpan(), out result);
		}

		public static double2? TryParseDouble2(string value)
		{
			if (!TryParseDouble2(value.AsSpan(), out var result))
			{
				return null;
			}
			return result;
		}

		public static bool TryParseDouble3(ReadOnlySpan<char> value, out double3 result)
		{
			result = default(double3);
			if (value.Length == 0)
			{
				return false;
			}
			StringUtility.StringSplitEnumerator enumerator = StringUtility.SpanSplit(value, ',').GetEnumerator();
			while (enumerator.MoveNext())
			{
				StringUtility.StringSplitEntry current = enumerator.Current;
				if (!double.TryParse(current.Span, NumberStyleDouble, NumberFormat, out var result2))
				{
					return false;
				}
				if (current.Index == 0)
				{
					result.x = result2;
				}
				else if (current.Index == 1)
				{
					result.y = result2;
				}
				else if (current.Index == 2)
				{
					result.z = result2;
					return true;
				}
			}
			return false;
		}

		public static double3? TryParseDouble3(ReadOnlySpan<char> value)
		{
			if (!TryParseDouble3(value, out var result))
			{
				return null;
			}
			return result;
		}

		public static bool TryParseDouble3(string value, out double3 result)
		{
			return TryParseDouble3(value.AsSpan(), out result);
		}

		public static double3? TryParseDouble3(string value)
		{
			if (!TryParseDouble3(value.AsSpan(), out var result))
			{
				return null;
			}
			return result;
		}

		public static bool TryParseDouble4(ReadOnlySpan<char> value, out double4 result)
		{
			result = default(double4);
			if (value.Length == 0)
			{
				return false;
			}
			StringUtility.StringSplitEnumerator enumerator = StringUtility.SpanSplit(value, ',').GetEnumerator();
			while (enumerator.MoveNext())
			{
				StringUtility.StringSplitEntry current = enumerator.Current;
				if (!double.TryParse(current.Span, NumberStyleDouble, NumberFormat, out var result2))
				{
					return false;
				}
				if (current.Index == 0)
				{
					result.x = result2;
				}
				else if (current.Index == 1)
				{
					result.y = result2;
				}
				else if (current.Index == 2)
				{
					result.z = result2;
				}
				else if (current.Index == 3)
				{
					result.w = result2;
					return true;
				}
			}
			return false;
		}

		public static double4? TryParseDouble4(ReadOnlySpan<char> value)
		{
			if (!TryParseDouble4(value, out var result))
			{
				return null;
			}
			return result;
		}

		public static bool TryParseDouble4(string value, out double4 result)
		{
			return TryParseDouble4(value.AsSpan(), out result);
		}

		public static double4? TryParseDouble4(string value)
		{
			if (!TryParseDouble4(value.AsSpan(), out var result))
			{
				return null;
			}
			return result;
		}

		public static bool TryParseFloat(ReadOnlySpan<char> stringValue, out float value)
		{
			return float.TryParse(stringValue, NumberStyleFloat, NumberFormat, out value);
		}

		public static bool TryParseFloat(string stringValue, out float value)
		{
			return float.TryParse(stringValue, NumberStyleFloat, NumberFormat, out value);
		}

		public static float? TryParseFloat(ReadOnlySpan<char> stringValue)
		{
			if (float.TryParse(stringValue, NumberStyleFloat, NumberFormat, out var result))
			{
				return result;
			}
			return null;
		}

		public static float? TryParseFloat(string stringValue)
		{
			if (float.TryParse(stringValue, NumberStyleFloat, NumberFormat, out var result))
			{
				return result;
			}
			return null;
		}

		public static bool TryParseFloat2(ReadOnlySpan<char> value, out float2 result)
		{
			result = default(float2);
			if (value.Length == 0)
			{
				return false;
			}
			StringUtility.StringSplitEnumerator enumerator = StringUtility.SpanSplit(value, ',').GetEnumerator();
			while (enumerator.MoveNext())
			{
				StringUtility.StringSplitEntry current = enumerator.Current;
				if (!float.TryParse(current.Span, NumberStyleFloat, NumberFormat, out var result2))
				{
					return false;
				}
				if (current.Index == 0)
				{
					result.x = result2;
				}
				else if (current.Index == 1)
				{
					result.y = result2;
					return true;
				}
			}
			return false;
		}

		public static float2? TryParseFloat2(ReadOnlySpan<char> value)
		{
			if (!TryParseFloat2(value, out var result))
			{
				return null;
			}
			return result;
		}

		public static bool TryParseFloat2(string value, out float2 result)
		{
			return TryParseFloat2(value.AsSpan(), out result);
		}

		public static float2? TryParseFloat2(string value)
		{
			if (!TryParseFloat2(value.AsSpan(), out var result))
			{
				return null;
			}
			return result;
		}

		public static bool TryParseFloat3(ReadOnlySpan<char> value, out float3 result)
		{
			result = default(float3);
			if (value.Length == 0)
			{
				return false;
			}
			StringUtility.StringSplitEnumerator enumerator = StringUtility.SpanSplit(value, ',').GetEnumerator();
			while (enumerator.MoveNext())
			{
				StringUtility.StringSplitEntry current = enumerator.Current;
				if (!float.TryParse(current.Span, NumberStyleFloat, NumberFormat, out var result2))
				{
					return false;
				}
				if (current.Index == 0)
				{
					result.x = result2;
				}
				else if (current.Index == 1)
				{
					result.y = result2;
				}
				else if (current.Index == 2)
				{
					result.z = result2;
					return true;
				}
			}
			return false;
		}

		public static float3? TryParseFloat3(ReadOnlySpan<char> value)
		{
			if (!TryParseFloat3(value, out var result))
			{
				return null;
			}
			return result;
		}

		public static bool TryParseFloat3(string value, out float3 result)
		{
			return TryParseFloat3(value.AsSpan(), out result);
		}

		public static float3? TryParseFloat3(string value)
		{
			if (!TryParseFloat3(value.AsSpan(), out var result))
			{
				return null;
			}
			return result;
		}

		public static bool TryParseFloat4(ReadOnlySpan<char> value, out float4 result)
		{
			result = default(float4);
			if (value.Length == 0)
			{
				return false;
			}
			StringUtility.StringSplitEnumerator enumerator = StringUtility.SpanSplit(value, ',').GetEnumerator();
			while (enumerator.MoveNext())
			{
				StringUtility.StringSplitEntry current = enumerator.Current;
				if (!float.TryParse(current.Span, NumberStyleFloat, NumberFormat, out var result2))
				{
					return false;
				}
				if (current.Index == 0)
				{
					result.x = result2;
				}
				else if (current.Index == 1)
				{
					result.y = result2;
				}
				else if (current.Index == 2)
				{
					result.z = result2;
				}
				else if (current.Index == 3)
				{
					result.w = result2;
					return true;
				}
			}
			return false;
		}

		public static float4? TryParseFloat4(ReadOnlySpan<char> value)
		{
			if (!TryParseFloat4(value, out var result))
			{
				return null;
			}
			return result;
		}

		public static bool TryParseFloat4(string value, out float4 result)
		{
			return TryParseFloat4(value.AsSpan(), out result);
		}

		public static float4? TryParseFloat4(string value)
		{
			if (!TryParseFloat4(value.AsSpan(), out var result))
			{
				return null;
			}
			return result;
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

		public static bool TryParseInt(ReadOnlySpan<char> stringValue, out int value)
		{
			return int.TryParse(stringValue, NumberStyles.Integer, NumberFormat, out value);
		}

		public static bool TryParseInt(string stringValue, out int value)
		{
			return int.TryParse(stringValue, NumberStyles.Integer, NumberFormat, out value);
		}

		public static int? TryParseInt(ReadOnlySpan<char> stringValue)
		{
			if (int.TryParse(stringValue, NumberStyles.Integer, NumberFormat, out var result))
			{
				return result;
			}
			return null;
		}

		public static int? TryParseInt(string stringValue)
		{
			if (int.TryParse(stringValue, NumberStyles.Integer, NumberFormat, out var result))
			{
				return result;
			}
			return null;
		}

		public static bool TryParseInt2(ReadOnlySpan<char> value, out int2 result)
		{
			result = default(int2);
			if (value.Length == 0)
			{
				return false;
			}
			StringUtility.StringSplitEnumerator enumerator = StringUtility.SpanSplit(value, ',').GetEnumerator();
			while (enumerator.MoveNext())
			{
				StringUtility.StringSplitEntry current = enumerator.Current;
				if (!int.TryParse(current.Span, NumberStyles.Integer, NumberFormat, out var result2))
				{
					return false;
				}
				if (current.Index == 0)
				{
					result.x = result2;
				}
				else if (current.Index == 1)
				{
					result.y = result2;
					return true;
				}
			}
			return false;
		}

		public static int2? TryParseInt2(ReadOnlySpan<char> value)
		{
			if (!TryParseInt2(value, out var result))
			{
				return null;
			}
			return result;
		}

		public static bool TryParseInt2(string value, out int2 result)
		{
			return TryParseInt2(value.AsSpan(), out result);
		}

		public static int2? TryParseInt2(string value)
		{
			if (!TryParseInt2(value.AsSpan(), out var result))
			{
				return null;
			}
			return result;
		}

		public static bool TryParseInt3(ReadOnlySpan<char> value, out int3 result)
		{
			result = default(int3);
			if (value.Length == 0)
			{
				return false;
			}
			StringUtility.StringSplitEnumerator enumerator = StringUtility.SpanSplit(value, ',').GetEnumerator();
			while (enumerator.MoveNext())
			{
				StringUtility.StringSplitEntry current = enumerator.Current;
				if (!int.TryParse(current.Span, NumberStyles.Integer, NumberFormat, out var result2))
				{
					return false;
				}
				if (current.Index == 0)
				{
					result.x = result2;
				}
				else if (current.Index == 1)
				{
					result.y = result2;
				}
				else if (current.Index == 2)
				{
					result.z = result2;
					return true;
				}
			}
			return false;
		}

		public static int3? TryParseInt3(ReadOnlySpan<char> value)
		{
			if (!TryParseInt3(value, out var result))
			{
				return null;
			}
			return result;
		}

		public static bool TryParseInt3(string value, out int3 result)
		{
			return TryParseInt3(value.AsSpan(), out result);
		}

		public static int3? TryParseInt3(string value)
		{
			if (!TryParseInt3(value.AsSpan(), out var result))
			{
				return null;
			}
			return result;
		}

		public static bool TryParseInt4(ReadOnlySpan<char> value, out int4 result)
		{
			result = default(int4);
			if (value.Length == 0)
			{
				return false;
			}
			StringUtility.StringSplitEnumerator enumerator = StringUtility.SpanSplit(value, ',').GetEnumerator();
			while (enumerator.MoveNext())
			{
				StringUtility.StringSplitEntry current = enumerator.Current;
				if (!int.TryParse(current.Span, NumberStyles.Integer, NumberFormat, out var result2))
				{
					return false;
				}
				if (current.Index == 0)
				{
					result.x = result2;
				}
				else if (current.Index == 1)
				{
					result.y = result2;
				}
				else if (current.Index == 2)
				{
					result.z = result2;
				}
				else if (current.Index == 3)
				{
					result.w = result2;
					return true;
				}
			}
			return false;
		}

		public static int4? TryParseInt4(ReadOnlySpan<char> value)
		{
			if (!TryParseInt4(value, out var result))
			{
				return null;
			}
			return result;
		}

		public static bool TryParseInt4(string value, out int4 result)
		{
			return TryParseInt4(value.AsSpan(), out result);
		}

		public static int4? TryParseInt4(string value)
		{
			if (!TryParseInt4(value.AsSpan(), out var result))
			{
				return null;
			}
			return result;
		}

		public static bool TryParseLong(ReadOnlySpan<char> stringValue, out long value)
		{
			return long.TryParse(stringValue, NumberStyles.Integer, NumberFormat, out value);
		}

		public static bool TryParseLong(string stringValue, out long value)
		{
			return long.TryParse(stringValue, NumberStyles.Integer, NumberFormat, out value);
		}

		public static long? TryParseLong(ReadOnlySpan<char> stringValue)
		{
			if (long.TryParse(stringValue, NumberStyles.Integer, NumberFormat, out var result))
			{
				return result;
			}
			return null;
		}

		public static long? TryParseLong(string stringValue)
		{
			if (long.TryParse(stringValue, NumberStyles.Integer, NumberFormat, out var result))
			{
				return result;
			}
			return null;
		}

		public static bool TryParseRangeFloat(ReadOnlySpan<char> value, out RangeFloat result)
		{
			result = default(RangeFloat);
			if (value.Length == 0)
			{
				return false;
			}
			float start = 0f;
			StringUtility.StringSplitEnumerator enumerator = StringUtility.SpanSplit(value, ',').GetEnumerator();
			while (enumerator.MoveNext())
			{
				StringUtility.StringSplitEntry current = enumerator.Current;
				if (!float.TryParse(current.Span, NumberStyleFloat, NumberFormat, out var result2))
				{
					return false;
				}
				if (current.Index == 0)
				{
					start = result2;
				}
				else if (current.Index == 1)
				{
					result = new RangeFloat(start, result2);
					return true;
				}
			}
			return false;
		}

		public static RangeFloat? TryParseRangeFloat(ReadOnlySpan<char> value)
		{
			if (!TryParseRangeFloat(value, out var result))
			{
				return null;
			}
			return result;
		}

		public static bool TryParseRangeFloat(string value, out RangeFloat result)
		{
			return TryParseRangeFloat(value.AsSpan(), out result);
		}

		public static RangeFloat? TryParseRangeFloat(string value)
		{
			if (!TryParseRangeFloat(value.AsSpan(), out var result))
			{
				return null;
			}
			return result;
		}

		public static bool TryParseRangeInteger(ReadOnlySpan<char> value, out RangeInteger result)
		{
			result = default(RangeInteger);
			if (value.Length == 0)
			{
				return false;
			}
			int start = 0;
			StringUtility.StringSplitEnumerator enumerator = StringUtility.SpanSplit(value, ',').GetEnumerator();
			while (enumerator.MoveNext())
			{
				StringUtility.StringSplitEntry current = enumerator.Current;
				if (!int.TryParse(current.Span, NumberStyles.Integer, NumberFormat, out var result2))
				{
					return false;
				}
				if (current.Index == 0)
				{
					start = result2;
				}
				else if (current.Index == 1)
				{
					result = new RangeInteger(start, result2);
					return true;
				}
			}
			return false;
		}

		public static RangeInteger? TryParseRangeInteger(ReadOnlySpan<char> value)
		{
			if (!TryParseRangeInteger(value, out var result))
			{
				return null;
			}
			return result;
		}

		public static bool TryParseRangeInteger(string value, out RangeInteger result)
		{
			return TryParseRangeInteger(value.AsSpan(), out result);
		}

		public static RangeInteger? TryParseRangeInteger(string value)
		{
			if (!TryParseRangeInteger(value.AsSpan(), out var result))
			{
				return null;
			}
			return result;
		}

		public static bool TryParseSByte(ReadOnlySpan<char> stringValue, out sbyte value)
		{
			return sbyte.TryParse(stringValue, NumberStyles.Integer, NumberFormat, out value);
		}

		public static bool TryParseSByte(string stringValue, out sbyte value)
		{
			return sbyte.TryParse(stringValue, NumberStyles.Integer, NumberFormat, out value);
		}

		public static sbyte? TryParseSByte(ReadOnlySpan<char> stringValue)
		{
			if (sbyte.TryParse(stringValue, NumberStyles.Integer, NumberFormat, out var result))
			{
				return result;
			}
			return null;
		}

		public static sbyte? TryParseSByte(string stringValue)
		{
			if (sbyte.TryParse(stringValue, NumberStyles.Integer, NumberFormat, out var result))
			{
				return result;
			}
			return null;
		}

		public static bool TryParseShort(ReadOnlySpan<char> stringValue, out short value)
		{
			return short.TryParse(stringValue, NumberStyles.Integer, NumberFormat, out value);
		}

		public static bool TryParseShort(string stringValue, out short value)
		{
			return short.TryParse(stringValue, NumberStyles.Integer, NumberFormat, out value);
		}

		public static short? TryParseShort(ReadOnlySpan<char> stringValue)
		{
			if (short.TryParse(stringValue, NumberStyles.Integer, NumberFormat, out var result))
			{
				return result;
			}
			return null;
		}

		public static short? TryParseShort(string stringValue)
		{
			if (short.TryParse(stringValue, NumberStyles.Integer, NumberFormat, out var result))
			{
				return result;
			}
			return null;
		}

		public static bool TryParseTimeSpan(ReadOnlySpan<char> stringValue, out TimeSpan value)
		{
			return TimeSpan.TryParse(stringValue, Culture, out value);
		}

		public static bool TryParseTimeSpan(string stringValue, out TimeSpan value)
		{
			return TimeSpan.TryParse(stringValue, Culture, out value);
		}

		public static TimeSpan? TryParseTimeSpan(ReadOnlySpan<char> stringValue)
		{
			if (TimeSpan.TryParse(stringValue, Culture, out var result))
			{
				return result;
			}
			return null;
		}

		public static TimeSpan? TryParseTimeSpan(string stringValue)
		{
			if (TimeSpan.TryParse(stringValue, Culture, out var result))
			{
				return result;
			}
			return null;
		}

		public static bool TryParseUInt(ReadOnlySpan<char> stringValue, out uint value)
		{
			return uint.TryParse(stringValue, NumberStyles.Integer, NumberFormat, out value);
		}

		public static bool TryParseUInt(string stringValue, out uint value)
		{
			return uint.TryParse(stringValue, NumberStyles.Integer, NumberFormat, out value);
		}

		public static uint? TryParseUInt(ReadOnlySpan<char> stringValue)
		{
			if (uint.TryParse(stringValue, NumberStyles.Integer, NumberFormat, out var result))
			{
				return result;
			}
			return null;
		}

		public static uint? TryParseUInt(string stringValue)
		{
			if (uint.TryParse(stringValue, NumberStyles.Integer, NumberFormat, out var result))
			{
				return result;
			}
			return null;
		}

		public static bool TryParseULong(ReadOnlySpan<char> stringValue, out ulong value)
		{
			return ulong.TryParse(stringValue, NumberStyles.Integer, NumberFormat, out value);
		}

		public static bool TryParseULong(string stringValue, out ulong value)
		{
			return ulong.TryParse(stringValue, NumberStyles.Integer, NumberFormat, out value);
		}

		public static ulong? TryParseULong(ReadOnlySpan<char> stringValue)
		{
			if (ulong.TryParse(stringValue, NumberStyles.Integer, NumberFormat, out var result))
			{
				return result;
			}
			return null;
		}

		public static ulong? TryParseULong(string stringValue)
		{
			if (ulong.TryParse(stringValue, NumberStyles.Integer, NumberFormat, out var result))
			{
				return result;
			}
			return null;
		}

		public static bool TryParseUShort(ReadOnlySpan<char> stringValue, out ushort value)
		{
			return ushort.TryParse(stringValue, NumberStyles.Integer, NumberFormat, out value);
		}

		public static bool TryParseUShort(string stringValue, out ushort value)
		{
			return ushort.TryParse(stringValue, NumberStyles.Integer, NumberFormat, out value);
		}

		public static ushort? TryParseUShort(ReadOnlySpan<char> stringValue)
		{
			if (ushort.TryParse(stringValue, NumberStyles.Integer, NumberFormat, out var result))
			{
				return result;
			}
			return null;
		}

		public static ushort? TryParseUShort(string stringValue)
		{
			if (ushort.TryParse(stringValue, NumberStyles.Integer, NumberFormat, out var result))
			{
				return result;
			}
			return null;
		}

		public static bool TryParseVector2(ReadOnlySpan<char> value, out Vector2 result)
		{
			result = default(Vector2);
			if (value.Length == 0)
			{
				return false;
			}
			if (value[0] == '(')
			{
				value = value.TrimStart('(').TrimEnd(')');
			}
			StringUtility.StringSplitEnumerator enumerator = StringUtility.SpanSplit(value, ',').GetEnumerator();
			while (enumerator.MoveNext())
			{
				StringUtility.StringSplitEntry current = enumerator.Current;
				if (!float.TryParse(current.Span, NumberStyleFloat, NumberFormat, out var result2))
				{
					return false;
				}
				if (current.Index == 0)
				{
					result.x = result2;
				}
				else if (current.Index == 1)
				{
					result.y = result2;
					return true;
				}
			}
			return false;
		}

		public static Vector2? TryParseVector2(ReadOnlySpan<char> value)
		{
			if (!TryParseVector2(value, out var result))
			{
				return null;
			}
			return result;
		}

		public static bool TryParseVector2(string value, out Vector2 result)
		{
			return TryParseVector2(value.AsSpan(), out result);
		}

		public static Vector2? TryParseVector2(string value)
		{
			if (!TryParseVector2(value.AsSpan(), out var result))
			{
				return null;
			}
			return result;
		}

		public static bool TryParseVector2d(ReadOnlySpan<char> value, out Vector2d result)
		{
			result = default(Vector2d);
			if (value.Length == 0)
			{
				return false;
			}
			if (value[0] == '(')
			{
				value = value.TrimStart('(').TrimEnd(')');
			}
			StringUtility.StringSplitEnumerator enumerator = StringUtility.SpanSplit(value, ',').GetEnumerator();
			while (enumerator.MoveNext())
			{
				StringUtility.StringSplitEntry current = enumerator.Current;
				if (!double.TryParse(current.Span, NumberStyleDouble, NumberFormat, out var result2))
				{
					return false;
				}
				if (current.Index == 0)
				{
					result.x = result2;
				}
				else if (current.Index == 1)
				{
					result.y = result2;
					return true;
				}
			}
			return false;
		}

		public static Vector2d? TryParseVector2d(ReadOnlySpan<char> value)
		{
			if (!TryParseVector2d(value, out var result))
			{
				return null;
			}
			return result;
		}

		public static bool TryParseVector2d(string value, out Vector2d result)
		{
			return TryParseVector2d(value.AsSpan(), out result);
		}

		public static Vector2d? TryParseVector2d(string value)
		{
			if (!TryParseVector2d(value.AsSpan(), out var result))
			{
				return null;
			}
			return result;
		}

		public static bool TryParseVector2i(ReadOnlySpan<char> value, out Vector2i result)
		{
			result = default(Vector2i);
			if (value.Length == 0)
			{
				return false;
			}
			StringUtility.StringSplitEnumerator enumerator = StringUtility.SpanSplit(value, ',').GetEnumerator();
			while (enumerator.MoveNext())
			{
				StringUtility.StringSplitEntry current = enumerator.Current;
				if (!int.TryParse(current.Span, NumberStyles.Integer, NumberFormat, out var result2))
				{
					return false;
				}
				if (current.Index == 0)
				{
					result.x = result2;
				}
				else if (current.Index == 1)
				{
					result.y = result2;
					return true;
				}
			}
			return false;
		}

		public static Vector2i? TryParseVector2i(ReadOnlySpan<char> value)
		{
			if (!TryParseVector2i(value, out var result))
			{
				return null;
			}
			return result;
		}

		public static bool TryParseVector2i(string value, out Vector2i result)
		{
			return TryParseVector2i(value.AsSpan(), out result);
		}

		public static Vector2i? TryParseVector2i(string value)
		{
			if (!TryParseVector2i(value.AsSpan(), out var result))
			{
				return null;
			}
			return result;
		}

		public static bool TryParseVector3(ReadOnlySpan<char> value, out Vector3 result)
		{
			result = default(Vector3);
			if (value.Length == 0)
			{
				return false;
			}
			if (value[0] == '(')
			{
				value = value.TrimStart('(').TrimEnd(')');
			}
			StringUtility.StringSplitEnumerator enumerator = StringUtility.SpanSplit(value, ',').GetEnumerator();
			while (enumerator.MoveNext())
			{
				StringUtility.StringSplitEntry current = enumerator.Current;
				if (!float.TryParse(current.Span, NumberStyleFloat, NumberFormat, out var result2))
				{
					return false;
				}
				if (current.Index == 0)
				{
					result.x = result2;
				}
				else if (current.Index == 1)
				{
					result.y = result2;
				}
				else if (current.Index == 2)
				{
					result.z = result2;
					return true;
				}
			}
			return false;
		}

		public static Vector3? TryParseVector3(ReadOnlySpan<char> value)
		{
			if (!TryParseVector3(value, out var result))
			{
				return null;
			}
			return result;
		}

		public static bool TryParseVector3(string value, out Vector3 result)
		{
			return TryParseVector3(value.AsSpan(), out result);
		}

		public static Vector3? TryParseVector3(string value)
		{
			if (!TryParseVector3(value.AsSpan(), out var result))
			{
				return null;
			}
			return result;
		}

		public static bool TryParseVector3d(ReadOnlySpan<char> value, out Vector3d result)
		{
			result = default(Vector3d);
			if (value.Length == 0)
			{
				return false;
			}
			if (value[0] == '(')
			{
				value = value.TrimStart('(').TrimEnd(')');
			}
			StringUtility.StringSplitEnumerator enumerator = StringUtility.SpanSplit(value, ',').GetEnumerator();
			while (enumerator.MoveNext())
			{
				StringUtility.StringSplitEntry current = enumerator.Current;
				if (!double.TryParse(current.Span, NumberStyleDouble, NumberFormat, out var result2))
				{
					return false;
				}
				if (current.Index == 0)
				{
					result.x = result2;
				}
				else if (current.Index == 1)
				{
					result.y = result2;
				}
				else if (current.Index == 2)
				{
					result.z = result2;
					return true;
				}
			}
			return false;
		}

		public static Vector3d? TryParseVector3d(ReadOnlySpan<char> value)
		{
			if (!TryParseVector3d(value, out var result))
			{
				return null;
			}
			return result;
		}

		public static bool TryParseVector3d(string value, out Vector3d result)
		{
			return TryParseVector3d(value.AsSpan(), out result);
		}

		public static Vector3d? TryParseVector3d(string value)
		{
			if (!TryParseVector3d(value.AsSpan(), out var result))
			{
				return null;
			}
			return result;
		}

		public static bool TryParseVector3i(ReadOnlySpan<char> value, out Vector3i result)
		{
			result = default(Vector3i);
			if (value.Length == 0)
			{
				return false;
			}
			StringUtility.StringSplitEnumerator enumerator = StringUtility.SpanSplit(value, ',').GetEnumerator();
			while (enumerator.MoveNext())
			{
				StringUtility.StringSplitEntry current = enumerator.Current;
				if (!int.TryParse(current.Span, NumberStyles.Integer, NumberFormat, out var result2))
				{
					return false;
				}
				if (current.Index == 0)
				{
					result.x = result2;
				}
				else if (current.Index == 1)
				{
					result.y = result2;
				}
				else if (current.Index == 2)
				{
					result.z = result2;
					return true;
				}
			}
			return false;
		}

		public static Vector3i? TryParseVector3i(ReadOnlySpan<char> value)
		{
			if (!TryParseVector3i(value, out var result))
			{
				return null;
			}
			return result;
		}

		public static bool TryParseVector3i(string value, out Vector3i result)
		{
			return TryParseVector3i(value.AsSpan(), out result);
		}

		public static Vector3i? TryParseVector3i(string value)
		{
			if (!TryParseVector3i(value.AsSpan(), out var result))
			{
				return null;
			}
			return result;
		}

		public static bool TryParseVector4(ReadOnlySpan<char> value, out Vector4 result)
		{
			result = default(Vector4);
			if (value.Length == 0)
			{
				return false;
			}
			if (value[0] == '(')
			{
				value = value.TrimStart('(').TrimEnd(')');
			}
			StringUtility.StringSplitEnumerator enumerator = StringUtility.SpanSplit(value, ',').GetEnumerator();
			while (enumerator.MoveNext())
			{
				StringUtility.StringSplitEntry current = enumerator.Current;
				if (!float.TryParse(current.Span, NumberStyleFloat, NumberFormat, out var result2))
				{
					return false;
				}
				if (current.Index == 0)
				{
					result.x = result2;
				}
				else if (current.Index == 1)
				{
					result.y = result2;
				}
				else if (current.Index == 2)
				{
					result.z = result2;
				}
				else if (current.Index == 3)
				{
					result.w = result2;
					return true;
				}
			}
			return false;
		}

		public static Vector4? TryParseVector4(ReadOnlySpan<char> value)
		{
			if (!TryParseVector4(value, out var result))
			{
				return null;
			}
			return result;
		}

		public static bool TryParseVector4(string value, out Vector4 result)
		{
			return TryParseVector4(value.AsSpan(), out result);
		}

		public static Vector4? TryParseVector4(string value)
		{
			if (!TryParseVector4(value.AsSpan(), out var result))
			{
				return null;
			}
			return result;
		}

		public static bool TryParseVector4d(ReadOnlySpan<char> value, out Vector4d result)
		{
			result = default(Vector4d);
			if (value.Length == 0)
			{
				return false;
			}
			if (value[0] == '(')
			{
				value = value.TrimStart('(').TrimEnd(')');
			}
			StringUtility.StringSplitEnumerator enumerator = StringUtility.SpanSplit(value, ',').GetEnumerator();
			while (enumerator.MoveNext())
			{
				StringUtility.StringSplitEntry current = enumerator.Current;
				if (!double.TryParse(current.Span, NumberStyleDouble, NumberFormat, out var result2))
				{
					return false;
				}
				if (current.Index == 0)
				{
					result.x = result2;
				}
				else if (current.Index == 1)
				{
					result.y = result2;
				}
				else if (current.Index == 2)
				{
					result.z = result2;
				}
				else if (current.Index == 3)
				{
					result.w = result2;
					return true;
				}
			}
			return false;
		}

		public static Vector4d? TryParseVector4d(ReadOnlySpan<char> value)
		{
			if (!TryParseVector4d(value, out var result))
			{
				return null;
			}
			return result;
		}

		public static bool TryParseVector4d(string value, out Vector4d result)
		{
			return TryParseVector4d(value.AsSpan(), out result);
		}

		public static Vector4d? TryParseVector4d(string value)
		{
			if (!TryParseVector4d(value.AsSpan(), out var result))
			{
				return null;
			}
			return result;
		}

		public static bool TryParseVector4i(ReadOnlySpan<char> value, out Vector4i result)
		{
			result = default(Vector4i);
			if (value.Length == 0)
			{
				return false;
			}
			StringUtility.StringSplitEnumerator enumerator = StringUtility.SpanSplit(value, ',').GetEnumerator();
			while (enumerator.MoveNext())
			{
				StringUtility.StringSplitEntry current = enumerator.Current;
				if (!int.TryParse(current.Span, NumberStyles.Integer, NumberFormat, out var result2))
				{
					return false;
				}
				if (current.Index == 0)
				{
					result.x = result2;
				}
				else if (current.Index == 1)
				{
					result.y = result2;
				}
				else if (current.Index == 2)
				{
					result.z = result2;
				}
				else if (current.Index == 3)
				{
					result.w = result2;
					return true;
				}
			}
			return false;
		}

		public static bool TryParseVector4m(ReadOnlySpan<char> value, out Vector4m result)
		{
			result = default(Vector4m);
			if (value.Length == 0)
			{
				return false;
			}
			StringUtility.StringSplitEnumerator enumerator = StringUtility.SpanSplit(value, ',').GetEnumerator();
			while (enumerator.MoveNext())
			{
				StringUtility.StringSplitEntry current = enumerator.Current;
				if (!decimal.TryParse(current.Span, NumberStyleDouble, NumberFormat, out var result2))
				{
					return false;
				}
				result[current.Index] = result2;
				if (current.Index == 3)
				{
					return true;
				}
			}
			return false;
		}

		public static Vector4i? TryParseVector4i(ReadOnlySpan<char> value)
		{
			if (!TryParseVector4i(value, out var result))
			{
				return null;
			}
			return result;
		}

		public static bool TryParseVector4i(string value, out Vector4i result)
		{
			return TryParseVector4i(value.AsSpan(), out result);
		}

		public static Vector4i? TryParseVector4i(string value)
		{
			if (!TryParseVector4i(value.AsSpan(), out var result))
			{
				return null;
			}
			return result;
		}
	}
}
