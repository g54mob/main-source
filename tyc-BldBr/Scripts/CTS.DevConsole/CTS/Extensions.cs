using System;
using System.Collections.Generic;
using System.Linq;

namespace CTS
{
	public static class Extensions
	{
		public static string AggregateString(this ICollection<string> collection, string prefix, string separator)
		{
			string text = collection.Aggregate(prefix, (string current, string match) => current + match + separator);
			if (collection.Count <= 0)
			{
				return text;
			}
			string text2 = text;
			int length = separator.Length;
			return text2.Substring(0, text2.Length - length);
		}

		public static bool IsSubclassOfRawGeneric(this Type toCheck, Type generic)
		{
			while (toCheck != null && toCheck != typeof(object))
			{
				Type type = (toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck);
				if (generic == type)
				{
					return true;
				}
				toCheck = toCheck.BaseType;
			}
			return false;
		}

		public static string[] MergeQuotes(this IEnumerable<string> strings, char separator, bool removeQuotes = true)
		{
			List<string> list = new List<string>();
			List<string> list2 = new List<string>();
			foreach (string @string in strings)
			{
				if (list.Count > 0)
				{
					if (@string.EndsWith("\""))
					{
						if (removeQuotes)
						{
							list.Add(@string.Remove(@string.Length - 1));
						}
						else
						{
							list.Add(@string);
						}
						list2.Add(string.Join(separator, list));
						list.Clear();
					}
					else
					{
						list.Add(@string);
					}
				}
				else if (@string.StartsWith("\""))
				{
					if (@string.EndsWith("\"") && @string.Length > 1)
					{
						if (removeQuotes)
						{
							list2.Add(@string.Remove(0, 1).Remove(@string.Length - 2));
						}
						else
						{
							list2.Add(@string);
						}
					}
					else if (removeQuotes)
					{
						list.Add(@string.Remove(0, 1));
					}
					else
					{
						list.Add(@string);
					}
				}
				else
				{
					list2.Add(@string);
				}
			}
			if (list.Count > 0)
			{
				if (removeQuotes)
				{
					list[0] = "\"" + list[0];
				}
				list2.Add(string.Join(separator, list));
			}
			return list2.ToArray();
		}
	}
}
