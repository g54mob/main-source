using System;
using System.Buffers;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Amazon.Util;

namespace Amazon.Runtime.Internal.Util
{
	public static class StringUtils
	{
		private static readonly Encoding UTF_8 = Encoding.UTF8;

		private static readonly char[] rfc7230HeaderFieldValueDelimeters = "\"(),/:;<=>?@[\\]{}".ToCharArray();

		public static string FromString(string value)
		{
			return value;
		}

		public static string FromStringWithSlashEncoding(string value)
		{
			return AWSSDKUtils.UrlEncodeSlash(FromString(value));
		}

		public static string FromString(ConstantClass value)
		{
			if (!(value == null))
			{
				return value.Intern().Value;
			}
			return "";
		}

		public static string FromMemoryStream(MemoryStream value)
		{
			if (value.TryGetBuffer(out var buffer))
			{
				return Convert.ToBase64String(buffer.Array, buffer.Offset, buffer.Count);
			}
			byte[] array = ArrayPool<byte>.Shared.Rent((int)value.Length);
			try
			{
				value.Read(array, 0, (int)value.Length);
				return Convert.ToBase64String(array, 0, (int)value.Length);
			}
			finally
			{
				ArrayPool<byte>.Shared.Return(array);
			}
		}

		public static string FromInt(int value)
		{
			return value.ToString(CultureInfo.InvariantCulture);
		}

		public static string FromInt(int? value)
		{
			if (!value.HasValue)
			{
				return null;
			}
			return value.Value.ToString(CultureInfo.InvariantCulture);
		}

		public static string FromLong(long value)
		{
			return value.ToString(CultureInfo.InvariantCulture);
		}

		public static string FromLong(long? value)
		{
			if (!value.HasValue)
			{
				return null;
			}
			return value.Value.ToString(CultureInfo.InvariantCulture);
		}

		public static string FromFloat(float value)
		{
			return value.ToString(CultureInfo.InvariantCulture);
		}

		public static string FromFloat(float? value)
		{
			if (!value.HasValue)
			{
				return null;
			}
			return value.Value.ToString(CultureInfo.InvariantCulture);
		}

		public static string FromSpecialFloatValue(float value)
		{
			if (float.IsPositiveInfinity(value))
			{
				return "Infinity";
			}
			if (float.IsNegativeInfinity(value))
			{
				return "-Infinity";
			}
			if (float.IsNaN(value))
			{
				return "NaN";
			}
			throw new ArgumentException("Only float.PositiveInfinity, float.NegativeInfinity, or float.Nan are valid");
		}

		public static bool IsSpecialFloatValue(float value)
		{
			if (!float.IsInfinity(value))
			{
				return float.IsNaN(value);
			}
			return true;
		}

		public static bool IsSpecialDoubleValue(double value)
		{
			if (!double.IsInfinity(value))
			{
				return double.IsNaN(value);
			}
			return true;
		}

		public static string FromSpecialDoubleValue(double value)
		{
			if (double.IsPositiveInfinity(value))
			{
				return "Infinity";
			}
			if (double.IsNegativeInfinity(value))
			{
				return "-Infinity";
			}
			if (double.IsNaN(value))
			{
				return "NaN";
			}
			throw new ArgumentException("Only double.PositiveInfinity, double.NegativeInfinity, or double.Nan are valid");
		}

		public static string FromBool(bool? value)
		{
			return FromBool(value == true);
		}

		public static string FromBool(bool value)
		{
			if (!value)
			{
				return "false";
			}
			return "true";
		}

		public static string FromDateTimeToISO8601(DateTime value)
		{
			return value.ToUniversalTime().ToString("yyyy-MM-dd\\THH:mm:ss.fff\\Z", CultureInfo.InvariantCulture);
		}

		public static string FromDateTimeToISO8601(DateTime? value)
		{
			if (!value.HasValue)
			{
				return null;
			}
			return value.Value.ToUniversalTime().ToString("yyyy-MM-dd\\THH:mm:ss.fff\\Z", CultureInfo.InvariantCulture);
		}

		public static string FromDateTimeToISO8601NoMs(DateTime value)
		{
			return value.ToUniversalTime().ToString("yyyy-MM-dd\\THH:mm:ss\\Z", CultureInfo.InvariantCulture);
		}

		public static string FromDateTimeToISO8601NoMs(DateTime? value)
		{
			if (!value.HasValue)
			{
				return null;
			}
			return value.Value.ToUniversalTime().ToString("yyyy-MM-dd\\THH:mm:ss\\Z", CultureInfo.InvariantCulture);
		}

		public static string FromDateTimeToISO8601WithOptionalMs(DateTime value)
		{
			string text = ((value.Millisecond == 0) ? "yyyy-MM-dd\\THH:mm:ss\\Z" : "yyyy-MM-dd\\THH:mm:ss.fff\\Z");
			return value.ToUniversalTime().ToString(text, CultureInfo.InvariantCulture);
		}

		public static string FromDateTimeToISO8601WithOptionalMs(DateTime? value)
		{
			if (!value.HasValue)
			{
				return null;
			}
			string text = ((value.Value.Millisecond == 0) ? "yyyy-MM-dd\\THH:mm:ss\\Z" : "yyyy-MM-dd\\THH:mm:ss.fff\\Z");
			return value.Value.ToUniversalTime().ToString(text, CultureInfo.InvariantCulture);
		}

		public static string FromDateTimeToRFC822(DateTime value)
		{
			return value.ToUniversalTime().ToString("ddd, dd MMM yyyy HH:mm:ss \\G\\M\\T", CultureInfo.InvariantCulture);
		}

		public static string FromDateTimeToRFC822(DateTime? value)
		{
			if (!value.HasValue)
			{
				return null;
			}
			return value.Value.ToUniversalTime().ToString("ddd, dd MMM yyyy HH:mm:ss \\G\\M\\T", CultureInfo.InvariantCulture);
		}

		public static string FromDateTimeToUnixTimestamp(DateTime value)
		{
			return AWSSDKUtils.ConvertToUnixEpochSecondsString(value);
		}

		public static string FromDateTimeToUnixTimestamp(DateTime? value)
		{
			if (!value.HasValue)
			{
				return null;
			}
			return AWSSDKUtils.ConvertToUnixEpochSecondsString(value.Value);
		}

		public static string FromDouble(double value)
		{
			return value.ToString(CultureInfo.InvariantCulture);
		}

		public static string FromDouble(double? value)
		{
			if (!value.HasValue)
			{
				return null;
			}
			return value.Value.ToString(CultureInfo.InvariantCulture);
		}

		public static string FromDecimal(decimal value)
		{
			return value.ToString(CultureInfo.InvariantCulture);
		}

		public static string FromDecimal(decimal? value)
		{
			if (!value.HasValue)
			{
				return null;
			}
			return value.Value.ToString(CultureInfo.InvariantCulture);
		}

		public static string FromList(IEnumerable<Enum> values)
		{
			return FromList(values?.Select((Enum x) => x.ToString()));
		}

		public static string FromList(List<Enum> values)
		{
			return FromList(values?.Select((Enum x) => x.ToString()));
		}

		public static string FromList<T>(IEnumerable<T> values) where T : ConstantClass
		{
			return FromList(values?.Select((T x) => x.ToString()));
		}

		public static string FromList<T>(List<T> values) where T : ConstantClass
		{
			return FromList(values?.Select((T x) => x.ToString()));
		}

		public static string FromValueTypeList<T>(IEnumerable<T> values) where T : struct
		{
			return FromList(values?.Select((T x) => x.ToString()));
		}

		public static string FromValueTypeList<T>(List<T> values) where T : struct
		{
			if (typeof(T) == typeof(bool))
			{
				return FromList(values?.Select((T x) => x.ToString().ToLowerInvariant()));
			}
			if (typeof(T) == typeof(DateTime))
			{
				return string.Join(",", values?.Select((T x) => FromDateTimeToRFC822((DateTime)(object)x)));
			}
			return FromList(values?.Select((T x) => x.ToString()));
		}

		public static string FromList(IEnumerable<string> values)
		{
			if (values == null || values.Count() == 0)
			{
				return "";
			}
			return string.Join(",", (from x in values
				where !string.IsNullOrEmpty(x)
				select EscapeHeaderListEntry(x)).ToArray());
		}

		private static string EscapeHeaderListEntry(string headerListEntry)
		{
			if (headerListEntry.IndexOfAny(rfc7230HeaderFieldValueDelimeters) != -1)
			{
				return "\"" + headerListEntry.Replace("\"", "\\\"") + "\"";
			}
			return headerListEntry;
		}

		public static long Utf8ByteLength(string value)
		{
			if (value == null)
			{
				return 0L;
			}
			return UTF_8.GetByteCount(value);
		}
	}
}
