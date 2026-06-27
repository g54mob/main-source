namespace FluentAssertions.Formatting
{
	public class NullValueFormatter : IValueFormatter
	{
		public bool CanHandle(object value)
		{
			return value == null;
		}

		public void Format(object value, FormattedObjectGraph formattedGraph, FormattingContext context, FormatChild formatChild)
		{
			formattedGraph.AddFragment("<null>");
		}
	}
}
