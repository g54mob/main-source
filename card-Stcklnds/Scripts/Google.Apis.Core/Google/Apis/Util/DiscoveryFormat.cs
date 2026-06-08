using System;
using System.Globalization;

namespace Google.Apis.Util
{
	public static class DiscoveryFormat
	{
		private static readonly char[] OffsetLeaders = new char[3] { 'Z', '-', '+' };

		public static DateTimeOffset? ParseDateTimeToDateTimeOffset(string value)
		{
			if (value == null)
			{
				return null;
			}
			int num = value.LastIndexOfAny(OffsetLeaders);
			if (num == -1)
			{
				ThrowFormatException();
			}
			string value2 = value.Substring(0, num);
			string offset = value.Substring(num);
			DateTime dateTime = ParseLocalDateTime(value2);
			TimeSpan offset2 = ParseUtcOffset(offset);
			if (offset2.Seconds != 0)
			{
				dateTime = dateTime.AddSeconds(-offset2.Seconds);
				offset2 = new TimeSpan(offset2.Hours, offset2.Minutes, 0);
			}
			return new DateTimeOffset(dateTime, offset2);
		}

		public static DateTimeOffset? ParseGoogleDateTimeToDateTimeOffset(string value)
		{
			if (value == null)
			{
				return null;
			}
			if (!value.EndsWith("Z", StringComparison.Ordinal))
			{
				ThrowFormatException();
			}
			return new DateTimeOffset(ParseLocalDateTime(value.Substring(0, value.Length - 1)), TimeSpan.Zero);
		}

		public static string FormatDateTimeOffsetToDateTime(DateTimeOffset? value)
		{
			return FormatDateTimeOffsetImpl(value);
		}

		public static string FormatDateTimeOffsetToGoogleDateTime(DateTimeOffset? value)
		{
			return FormatDateTimeOffsetImpl(value?.ToUniversalTime());
		}

		private static DateTime ParseLocalDateTime(string value)
		{
			return value.Length switch
			{
				19 => DateTime.ParseExact(value, "yyyy-MM-dd'T'HH:mm:ss", CultureInfo.InvariantCulture), 
				23 => DateTime.ParseExact(value, "yyyy-MM-dd'T'HH:mm:ss.fff", CultureInfo.InvariantCulture), 
				26 => DateTime.ParseExact(value, "yyyy-MM-dd'T'HH:mm:ss.ffffff", CultureInfo.InvariantCulture), 
				29 => DateTime.ParseExact(AdjustForNanoseconds(value), "yyyy-MM-dd'T'HH:mm:ss.fffffff", CultureInfo.InvariantCulture), 
				_ => ThrowFormatException<DateTime>(), 
			};
			static string AdjustForNanoseconds(string text)
			{
				ValidateDigit(text[27]);
				ValidateDigit(text[28]);
				return text.Substring(0, 27);
			}
			static void ValidateDigit(char c)
			{
				if (c < '0' || c > '9')
				{
					ThrowFormatException();
				}
			}
		}

		private static string FormatDateTimeOffsetImpl(DateTimeOffset? value)
		{
			if (value.HasValue)
			{
				DateTimeOffset valueOrDefault = value.GetValueOrDefault();
				long num = valueOrDefault.Ticks % 10000000;
				string text = ((num == 0L) ? "yyyy-MM-dd'T'HH:mm:ss" : ((num % 10000 == 0L) ? "yyyy-MM-dd'T'HH:mm:ss.fff" : ((num % 10 != 0L) ? "yyyy-MM-dd'T'HH:mm:ss.fffffff'00'" : "yyyy-MM-dd'T'HH:mm:ss.ffffff")));
				string text2 = text;
				return valueOrDefault.DateTime.ToString(text2, CultureInfo.InvariantCulture) + FormatOffset(valueOrDefault.Offset);
			}
			return null;
			static string FormatOffset(TimeSpan offset)
			{
				int num2 = (int)offset.TotalSeconds;
				if (num2 == 0)
				{
					return "Z";
				}
				int num3 = Math.Abs(num2);
				int value2 = num3 / 3600;
				int value3 = num3 % 3600 / 60;
				int value4 = num3 % 60;
				string text3 = ((num3 % 3600 == 0) ? FormatTwoDigits(value2) : ((num3 % 60 == 0) ? (FormatTwoDigits(value2) + ":" + FormatTwoDigits(value3)) : (FormatTwoDigits(value2) + ":" + FormatTwoDigits(value3) + ":" + FormatTwoDigits(value4))));
				return ((num2 > 0) ? "+" : "-") + text3;
			}
			static string FormatTwoDigits(int num2)
			{
				return num2.ToString("00", CultureInfo.InvariantCulture);
			}
		}

		private static TimeSpan ParseUtcOffset(string offset)
		{
			if (offset == "Z")
			{
				return TimeSpan.Zero;
			}
			string format = offset.Length switch
			{
				3 => "hh", 
				6 => "hh\\:mm", 
				9 => "hh\\:mm\\:ss", 
				_ => ThrowFormatException<string>(), 
			};
			bool flag = offset[0] switch
			{
				'+' => true, 
				'-' => false, 
				_ => ThrowFormatException<bool>(), 
			};
			try
			{
				TimeSpan timeSpan = TimeSpan.ParseExact(offset.Substring(1), format, CultureInfo.InvariantCulture);
				return flag ? timeSpan : (-timeSpan);
			}
			catch (OverflowException)
			{
				return ThrowFormatException<TimeSpan>();
			}
		}

		private static void ThrowFormatException()
		{
			throw new FormatException("String was not recognized as a valid DateTime");
		}

		private static T ThrowFormatException<T>()
		{
			throw new FormatException("String was not recognized as a valid DateTime");
		}
	}
}
