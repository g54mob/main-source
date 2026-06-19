using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Sentry.Internal;
using Sentry.Protocol.Metrics;

namespace Sentry
{
	internal static class MetricHelper
	{
		private static readonly RandomValuesFactory Random = new SynchronizedRandomValuesFactory();

		private const int RollupInSeconds = 10;

		private const string InvalidMetricKeyOrNameCharactersPattern = "[^\\w\\-.]+";

		private const string InvalidTagKeyCharactersPattern = "[^\\w\\-.\\/]+";

		private const string InvalidMetricUnitCharactersPattern = "[^\\w]+";

		private static readonly DateTimeOffset UnixEpoch = new DateTimeOffset(1970, 1, 1, 0, 0, 0, 0, TimeSpan.Zero);

		internal static double FlushShift = Random.NextInt(0, 1000) * 10;

		private static readonly Regex InvalidMetricKeyOrNameCharacters = new Regex("[^\\w\\-.]+", RegexOptions.Compiled);

		private static readonly Regex InvalidTagKeyCharacters = new Regex("[^\\w\\-.\\/]+", RegexOptions.Compiled);

		private static readonly Regex InvalidMetricUnitCharacters = new Regex("[^\\w]+", RegexOptions.Compiled);

		private static readonly Lazy<KeyValuePair<string, string>[]> LazyTagValueReplacements = new Lazy<KeyValuePair<string, string>[]>(() => new KeyValuePair<string, string>[5]
		{
			new KeyValuePair<string, string>("\n", "\\n"),
			new KeyValuePair<string, string>("\r", "\\r"),
			new KeyValuePair<string, string>("\t", "\\t"),
			new KeyValuePair<string, string>("|", "|"),
			new KeyValuePair<string, string>(",", ",")
		});

		private static KeyValuePair<string, string>[] TagValueReplacements => LazyTagValueReplacements.Value;

		internal static long GetDayBucketKey(this DateTimeOffset timestamp)
		{
			DateTimeOffset dateTimeOffset = timestamp.ToUniversalTime();
			return (long)(new DateTimeOffset(dateTimeOffset.Year, dateTimeOffset.Month, dateTimeOffset.Day, 0, 0, 0, 0, TimeSpan.Zero) - UnixEpoch).TotalSeconds;
		}

		internal static long GetTimeBucketKey(this DateTimeOffset timestamp)
		{
			return (long)(timestamp.ToUniversalTime() - UnixEpoch).TotalSeconds / 10 * 10;
		}

		internal static DateTimeOffset GetCutoff()
		{
			return DateTimeOffset.UtcNow.Subtract(TimeSpan.FromSeconds(10.0)).Subtract(TimeSpan.FromMilliseconds(FlushShift));
		}

		internal static string SanitizeMetricKeyOrName(string input)
		{
			return InvalidMetricKeyOrNameCharacters.Replace(input, "_");
		}

		internal static string SanitizeTagKey(string input)
		{
			return InvalidTagKeyCharacters.Replace(input, "");
		}

		internal static string SanitizeMetricUnit(string input)
		{
			return InvalidMetricUnitCharacters.Replace(input, "");
		}

		internal static string SanitizeTagValue(string input)
		{
			input = input.Replace("\\", "\\\\");
			KeyValuePair<string, string>[] tagValueReplacements = TagValueReplacements;
			for (int i = 0; i < tagValueReplacements.Length; i++)
			{
				PolyfillExtensions.Deconstruct(tagValueReplacements[i], out var key, out var value);
				string oldValue = key;
				string newValue = value;
				input = input.Replace(oldValue, newValue);
			}
			return input;
		}

		public static string GetMetricBucketKey(MetricType type, string metricKey, MeasurementUnit unit, IDictionary<string, string>? tags)
		{
			string text = type.ToStatsdType();
			string tagsKey = GetTagsKey(tags);
			return $"{text}_{metricKey}_{unit}_{tagsKey}";
		}

		internal static string GetTagsKey(IDictionary<string, string>? tags)
		{
			if (tags == null || tags.Count == 0)
			{
				return string.Empty;
			}
			StringBuilder stringBuilder = new StringBuilder();
			foreach (KeyValuePair<string, string> tag in tags)
			{
				string value = EscapeString(tag.Key, new char[3] { ',', '=', '\\' });
				string value2 = EscapeString(tag.Value, new char[3] { ',', '=', '\\' });
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(',');
				}
				stringBuilder.Append(value).Append('=').Append(value2);
			}
			return stringBuilder.ToString();
			static string EscapeString(string input, char[] charsToEscape)
			{
				StringBuilder stringBuilder2 = new StringBuilder(input.Length);
				foreach (char value3 in input)
				{
					if (charsToEscape.Contains(value3))
					{
						stringBuilder2.Append('\\');
					}
					stringBuilder2.Append(value3);
				}
				return stringBuilder2.ToString();
			}
		}
	}
}
