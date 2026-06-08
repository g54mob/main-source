using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Google.Apis.Json;
using Google.Apis.Testing;
using Newtonsoft.Json;

namespace Google.Apis.Util
{
	public static class Utilities
	{
		private static readonly JsonSerializerSettings s_serializerSettingsWithoutDateParsing = new JsonSerializerSettings
		{
			DateParseHandling = DateParseHandling.None
		};

		[VisibleForTestOnly]
		public static string GetLibraryVersion()
		{
			return Regex.Match(typeof(Utilities).GetTypeInfo().Assembly.FullName, "Version=([\\d\\.]+)").Groups[1].ToString();
		}

		public static T ThrowIfNull<T>(this T obj, string paramName)
		{
			if (obj == null)
			{
				throw new ArgumentNullException(paramName);
			}
			return obj;
		}

		public static string ThrowIfNullOrEmpty(this string str, string paramName)
		{
			if (string.IsNullOrEmpty(str))
			{
				throw new ArgumentException("Parameter was empty", paramName);
			}
			return str;
		}

		internal static bool IsNullOrEmpty<T>(this IEnumerable<T> coll)
		{
			if (coll != null)
			{
				return coll.Count() == 0;
			}
			return true;
		}

		public static T CheckEnumValue<T>(T value, string paramName) where T : struct
		{
			CheckArgument(Enum.IsDefined(typeof(T), value), paramName, "Value {0} not defined in enum {1}", value, typeof(T).Name);
			return value;
		}

		public static void CheckArgument<T1, T2>(bool condition, string paramName, string format, T1 arg0, T2 arg1)
		{
			if (!condition)
			{
				throw new ArgumentException(string.Format(format, arg0, arg1), paramName);
			}
		}

		public static T GetCustomAttribute<T>(this MemberInfo info) where T : Attribute
		{
			object[] array = info.GetCustomAttributes(typeof(T), inherit: false).ToArray();
			if (array.Length != 0)
			{
				return (T)array[0];
			}
			return null;
		}

		internal static string GetStringValue(this Enum value)
		{
			FieldInfo field = value.GetType().GetField(value.ToString());
			field.ThrowIfNull("value");
			StringValueAttribute customAttribute = field.GetCustomAttribute<StringValueAttribute>();
			if (customAttribute != null)
			{
				return customAttribute.Text;
			}
			throw new ArgumentException($"Enum value '{field}' does not contain a StringValue attribute", "value");
		}

		public static string GetEnumStringValue(Enum value)
		{
			return value.GetStringValue();
		}

		[VisibleForTestOnly]
		public static string ConvertToString(object o)
		{
			if (o == null)
			{
				return null;
			}
			if (o.GetType().GetTypeInfo().IsEnum)
			{
				StringValueAttribute customAttribute = o.GetType().GetField(o.ToString()).GetCustomAttribute<StringValueAttribute>();
				if (customAttribute == null)
				{
					return o.ToString();
				}
				return customAttribute.Text;
			}
			if (o is DateTime)
			{
				return ConvertToRFC3339((DateTime)o);
			}
			if (o is bool)
			{
				return o.ToString().ToLowerInvariant();
			}
			return o.ToString();
		}

		internal static string ConvertToRFC3339(DateTime date)
		{
			if (date.Kind == DateTimeKind.Unspecified)
			{
				date = date.ToUniversalTime();
			}
			return date.ToString("yyyy-MM-dd'T'HH:mm:ss.fffK", DateTimeFormatInfo.InvariantInfo);
		}

		public static DateTime? GetDateTimeFromString(string raw)
		{
			if (!DateTime.TryParse(raw, out var result))
			{
				return null;
			}
			return result;
		}

		public static string GetStringFromDateTime(DateTime? date)
		{
			if (!date.HasValue)
			{
				return null;
			}
			return ConvertToRFC3339(date.Value);
		}

		public static DateTimeOffset? GetDateTimeOffsetFromString(string raw)
		{
			if (raw != null)
			{
				return DateTimeOffset.ParseExact(raw, "yyyy-MM-dd'T'HH:mm:ss.FFF'Z'", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
			}
			return null;
		}

		public static string GetStringFromDateTimeOffset(DateTimeOffset? date)
		{
			if (date.HasValue)
			{
				if (date.Value.Millisecond != 0)
				{
					return date.Value.ToUniversalTime().ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'", CultureInfo.InvariantCulture);
				}
				return date.Value.ToUniversalTime().ToString("yyyy-MM-dd'T'HH:mm:ss'Z'");
			}
			return null;
		}

		public static object DeserializeForGoogleFormat(string rawValue)
		{
			if (rawValue == null)
			{
				return null;
			}
			string input = JsonConvert.SerializeObject(rawValue);
			return NewtonsoftJsonSerializer.Instance.Deserialize<object>(input);
		}

		public static string SerializeForGoogleFormat(object value)
		{
			if (value == null)
			{
				return null;
			}
			string text = NewtonsoftJsonSerializer.Instance.Serialize(value);
			if (text == null || text.Length < 2 || !text.StartsWith("\"", StringComparison.Ordinal) || !text.EndsWith("\"", StringComparison.Ordinal))
			{
				throw new ArgumentException("Value did not serialize to a JSON string.");
			}
			return JsonConvert.DeserializeObject<string>(text, s_serializerSettingsWithoutDateParsing);
		}
	}
}
