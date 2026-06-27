using System.Collections;
using System.Globalization;
using System.Linq;
using FluentAssertions.Common;

namespace FluentAssertions.Formatting
{
	public class EnumerableValueFormatter : IValueFormatter
	{
		protected virtual int MaxItems => 32;

		public virtual bool CanHandle(object value)
		{
			return value is IEnumerable;
		}

		public void Format(object value, FormattedObjectGraph formattedGraph, FormattingContext context, FormatChild formatChild)
		{
			using Iterator<object> iterator = new Iterator<object>(((IEnumerable)value).Cast<object>(), MaxItems);
			Anchor anchor = formattedGraph.GetAnchor();
			anchor.UseLineBreaks = context.UseLineBreaks;
			Anchor anchor2 = null;
			while (iterator.MoveNext())
			{
				if (!iterator.HasReachedMaxItems)
				{
					formatChild(iterator.Index.ToString(CultureInfo.InvariantCulture), iterator.Current, formattedGraph);
				}
				else
				{
					using (formattedGraph.WithIndentation())
					{
						string fragment = ((value is ICollection collection) ? $"…{collection.Count - MaxItems} more…" : "…more…");
						formattedGraph.AddLineOrFragment(fragment);
					}
				}
				anchor2?.InsertFragment(", ");
				anchor2 = formattedGraph.GetAnchor();
				if (iterator.IsLast)
				{
					anchor.InsertLineOrFragment("{");
					anchor.AddLineOrFragment("}");
				}
			}
			if (iterator.IsEmpty)
			{
				formattedGraph.AddFragment("{empty}");
			}
		}
	}
}
