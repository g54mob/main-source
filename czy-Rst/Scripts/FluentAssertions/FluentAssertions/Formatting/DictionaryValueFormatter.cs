using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using FluentAssertions.Common;

namespace FluentAssertions.Formatting
{
	public class DictionaryValueFormatter : IValueFormatter
	{
		protected virtual int MaxItems => 32;

		public virtual bool CanHandle(object value)
		{
			return value is IDictionary;
		}

		public void Format(object value, FormattedObjectGraph formattedGraph, FormattingContext context, FormatChild formatChild)
		{
			int lineCount = formattedGraph.LineCount;
			IEnumerable<KeyValuePair<object, object>> enumerable = AsEnumerable((IDictionary)value);
			using Iterator<KeyValuePair<object, object>> iterator = new Iterator<KeyValuePair<object, object>>(enumerable, MaxItems);
			while (iterator.MoveNext())
			{
				if (iterator.IsFirst)
				{
					formattedGraph.AddFragment("{");
				}
				if (!iterator.HasReachedMaxItems)
				{
					string text = iterator.Index.ToString(CultureInfo.InvariantCulture);
					formattedGraph.AddFragment("[");
					formatChild(text + ".Key", iterator.Current.Key, formattedGraph);
					formattedGraph.AddFragment("] = ");
					formatChild(text + ".Value", iterator.Current.Value, formattedGraph);
				}
				else
				{
					using (formattedGraph.WithIndentation())
					{
						string fragment = $"…{enumerable.Count() - MaxItems} more…";
						AddLineOrFragment(formattedGraph, lineCount, fragment);
					}
				}
				if (iterator.IsLast)
				{
					AddLineOrFragment(formattedGraph, lineCount, "}");
				}
				else
				{
					formattedGraph.AddFragment(", ");
				}
			}
			if (iterator.IsEmpty)
			{
				formattedGraph.AddFragment("{empty}");
			}
		}

		private static void AddLineOrFragment(FormattedObjectGraph formattedGraph, int startCount, string fragment)
		{
			if (formattedGraph.LineCount > startCount + 1)
			{
				formattedGraph.AddLine(fragment);
			}
			else
			{
				formattedGraph.AddFragment(fragment);
			}
		}

		private static IEnumerable<KeyValuePair<object, object>> AsEnumerable(IDictionary dictionary)
		{
			IDictionaryEnumerator iterator = dictionary.GetEnumerator();
			using (iterator as IDisposable)
			{
				while (iterator.MoveNext())
				{
					yield return new KeyValuePair<object, object>(iterator.Key, iterator.Value);
				}
			}
		}
	}
}
