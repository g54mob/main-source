namespace FluentAssertions.Formatting
{
	public interface IValueFormatter
	{
		bool CanHandle(object value);

		void Format(object value, FormattedObjectGraph formattedGraph, FormattingContext context, FormatChild formatChild);
	}
}
