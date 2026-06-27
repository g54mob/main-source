using System;

namespace FluentAssertions.Formatting
{
	public class ExceptionValueFormatter : IValueFormatter
	{
		public bool CanHandle(object value)
		{
			return value is Exception;
		}

		public void Format(object value, FormattedObjectGraph formattedGraph, FormattingContext context, FormatChild formatChild)
		{
			formattedGraph.AddFragment(((Exception)value).ToString());
		}
	}
}
