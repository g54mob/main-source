using System;
using System.Collections.Generic;
using System.Linq;
using Sentry.Extensibility;
using Sentry.Internal.Extensions;

namespace Sentry
{
	public class BaggageHeader
	{
		internal const string HttpHeaderName = "baggage";

		internal const string SentryKeyPrefix = "sentry-";

		internal static IDiagnosticLogger? Logger { get; set; } = SentrySdk.CurrentOptions?.DiagnosticLogger;

		internal IReadOnlyList<KeyValuePair<string, string>> Members { get; }

		private BaggageHeader(IEnumerable<KeyValuePair<string, string>> members)
		{
			Members = members.ToList();
		}

		internal IReadOnlyDictionary<string, string> GetSentryMembers()
		{
			return (from kvp in Members
				where kvp.Key.StartsWith("sentry-")
				group kvp.Value by kvp.Key).ToDictionary(delegate(IGrouping<string, string> g)
			{
				string key = g.Key;
				int length = "sentry-".Length;
				return key.Substring(length, key.Length - length);
			}, (IGrouping<string, string> g) => g.First());
		}

		public override string ToString()
		{
			IEnumerable<string> values = Members.Select<KeyValuePair<string, string>, string>((KeyValuePair<string, string> x) => x.Key + "=" + Uri.EscapeDataString(x.Value));
			return string.Join(", ", values);
		}

		internal static BaggageHeader? TryParse(string baggage, bool onlySentry = false)
		{
			string[] array = PolyfillExtensions.Split(baggage, ',', StringSplitOptions.RemoveEmptyEntries);
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>(array.Length);
			string[] array2 = array;
			foreach (string text in array2)
			{
				string[] array3 = PolyfillExtensions.Split(text, '=', 2);
				if (array3.Length != 2)
				{
					Logger?.LogWarning("The baggage header has an item without a '=' separator, and it will be discarded. The item is: \"{0}\"", text);
					continue;
				}
				string text2 = array3[0].Trim();
				if (text2.Length == 0)
				{
					Logger?.LogWarning("The baggage header has an item with an empty key, and it will be discarded. The item is: \"{0}\"", text);
					continue;
				}
				string text3 = array3[1].Trim();
				if (text3.Length == 0)
				{
					Logger?.LogWarning("The baggage header has an item with an empty value, and it will be discarded. The item is: \"{0}\"", text);
				}
				else if (!onlySentry || text2.StartsWith("sentry-"))
				{
					list.Add(text2, Uri.UnescapeDataString(text3));
				}
			}
			if (list.Count != 0)
			{
				return new BaggageHeader(list);
			}
			return null;
		}

		internal static BaggageHeader Create(IEnumerable<KeyValuePair<string, string>> items, bool useSentryPrefix = false)
		{
			IEnumerable<KeyValuePair<string, string>> enumerable = items.Where<KeyValuePair<string, string>>((KeyValuePair<string, string> member) => IsValidKey(member.Key));
			if (useSentryPrefix)
			{
				enumerable = enumerable.Select((KeyValuePair<string, string> kvp) => new KeyValuePair<string, string>("sentry-" + kvp.Key, kvp.Value));
			}
			return new BaggageHeader(enumerable);
		}

		internal static BaggageHeader Merge(IEnumerable<BaggageHeader> baggageHeaders)
		{
			return new BaggageHeader(baggageHeaders.SelectMany((BaggageHeader x) => x.Members));
		}

		private static bool IsValidKey(string? key)
		{
			if (string.IsNullOrEmpty(key))
			{
				return false;
			}
			return key.All((char c) => c >= '!' && c != '\u007f' && !PolyfillExtensions.Contains("\"(),/:;<=>?@[\\]{}", c));
		}
	}
}
