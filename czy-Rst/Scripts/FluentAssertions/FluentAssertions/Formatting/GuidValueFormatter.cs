using System;

namespace FluentAssertions.Formatting
{
	public class GuidValueFormatter : IValueFormatter
	{
		public bool CanHandle(object value)
		{
			return value is Guid;
		}

		public void Format(object value, FormattedObjectGraph formattedGraph, FormattingContext context, FormatChild formatChild)
		{
			formattedGraph.AddFragment($"{{{value}}}");
		}
	}
}
