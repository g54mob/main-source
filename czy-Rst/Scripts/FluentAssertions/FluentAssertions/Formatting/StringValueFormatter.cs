namespace FluentAssertions.Formatting
{
	public class StringValueFormatter : IValueFormatter
	{
		public bool CanHandle(object value)
		{
			return value is string;
		}

		public void Format(object value, FormattedObjectGraph formattedGraph, FormattingContext context, FormatChild formatChild)
		{
			string fragment = $"\"{value}\"";
			if (context.UseLineBreaks)
			{
				formattedGraph.AddFragmentOnNewLine(fragment);
			}
			else
			{
				formattedGraph.AddFragment(fragment);
			}
		}
	}
}
