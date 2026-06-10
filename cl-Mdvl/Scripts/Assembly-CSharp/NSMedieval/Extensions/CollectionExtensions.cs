using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSMedieval.Village.Map;

namespace NSMedieval.Extensions
{
	public static class CollectionExtensions
	{
		public static string ToPrettyString<T>(this IEnumerable<T> enumerable, bool newLineSeparator = false)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (newLineSeparator)
			{
				stringBuilder.AppendLine("[ ");
			}
			else
			{
				stringBuilder.Append("[ ");
			}
			foreach (T item in enumerable)
			{
				object value = item;
				stringBuilder.Append(value);
				if (newLineSeparator)
				{
					stringBuilder.AppendLine(", ");
				}
				else
				{
					stringBuilder.Append(", ");
				}
			}
			stringBuilder.Remove(stringBuilder.Length - 2, 2);
			if (stringBuilder.Length == 0)
			{
				stringBuilder.Append("[");
			}
			stringBuilder.Append(" ]");
			return stringBuilder.ToString();
		}

		public static string ToPrettyString(this IEnumerable<MapNode> enumerable, bool newLineSeparator = false)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (newLineSeparator)
			{
				stringBuilder.AppendLine("[ ");
			}
			else
			{
				stringBuilder.Append("[ ");
			}
			foreach (MapNode item in enumerable)
			{
				stringBuilder.Append(item.Position);
				if (newLineSeparator)
				{
					stringBuilder.AppendLine(", ");
				}
				else
				{
					stringBuilder.Append(", ");
				}
			}
			stringBuilder.Remove(stringBuilder.Length - 2, 2);
			if (stringBuilder.Length == 0)
			{
				stringBuilder.Append("[");
			}
			stringBuilder.Append(" ]");
			return stringBuilder.ToString();
		}

		public static string ToPrettyString<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("{ ");
			foreach (TKey key in dictionary.Keys)
			{
				stringBuilder.Append($"{key}: {dictionary[key]}, ");
			}
			stringBuilder.Remove(stringBuilder.Length - 2, 2);
			stringBuilder.Append(" }");
			return stringBuilder.ToString();
		}

		public static string ToPrettyStringNoBrackets<T>(this IEnumerable<T> enumerable, string separator = ", ", string lastEntrySeparator = "", bool newLineSeparator = false, int indentPercent = 0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (newLineSeparator)
			{
				foreach (T item in enumerable)
				{
					stringBuilder.AppendLine($"<indent={indentPercent}%>{item}</indent>");
				}
				return stringBuilder.ToString();
			}
			if (string.IsNullOrEmpty(lastEntrySeparator))
			{
				lastEntrySeparator = separator;
			}
			stringBuilder.Append($"{enumerable.First()}");
			foreach (T item2 in enumerable)
			{
				object obj = enumerable.First();
				if (!item2.Equals(obj))
				{
					object obj2 = enumerable.Last();
					if (item2.Equals(obj2))
					{
						separator = lastEntrySeparator;
					}
					stringBuilder.Append($"{separator}{item2}");
				}
			}
			return stringBuilder.ToString();
		}
	}
}
