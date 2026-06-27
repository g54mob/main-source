using System;
using System.Collections.Generic;
using System.Linq;

namespace FluentAssertions.Equivalency.Steps
{
	internal class AssertionResultSet
	{
		private readonly Dictionary<object, string[]> set = new Dictionary<object, string[]>();

		public void AddSet(object key, string[] failures)
		{
			set[key] = failures;
		}

		public string[] GetTheFailuresForTheSetWithTheFewestFailures(object key = null)
		{
			if (ContainsSuccessfulSet())
			{
				return Array.Empty<string>();
			}
			KeyValuePair<object, string[]>[] bestResultSets = GetBestResultSets();
			KeyValuePair<object, string[]> keyValuePair = Array.Find(bestResultSets, (KeyValuePair<object, string[]> r) => r.Key.Equals(key));
			object key2 = keyValuePair.Key;
			string[] value = keyValuePair.Value;
			if (key2 == null && value == null)
			{
				return bestResultSets[0].Value;
			}
			return keyValuePair.Value;
		}

		private KeyValuePair<object, string[]>[] GetBestResultSets()
		{
			int fewestFailures = set.Values.Min((string[] r) => r.Length);
			return set.Where((KeyValuePair<object, string[]> r) => r.Value.Length == fewestFailures).ToArray();
		}

		public bool ContainsSuccessfulSet()
		{
			return set.Values.Any((string[] v) => v.Length == 0);
		}
	}
}
