using FluentAssertions.Execution;

namespace FluentAssertions.Formatting
{
	internal class PassthroughValueFormatter : IValueFormatter
	{
		public bool CanHandle(object value)
		{
			return value is WithoutFormattingWrapper;
		}

		public void Format(object value, FormattedObjectGraph formattedGraph, FormattingContext context, FormatChild formatChild)
		{
			formattedGraph.AddFragment(((WithoutFormattingWrapper)value).ToString());
		}
	}
}
