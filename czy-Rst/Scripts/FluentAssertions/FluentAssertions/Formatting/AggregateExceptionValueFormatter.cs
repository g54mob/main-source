using System;

namespace FluentAssertions.Formatting
{
	public class AggregateExceptionValueFormatter : IValueFormatter
	{
		public bool CanHandle(object value)
		{
			return value is AggregateException;
		}

		public void Format(object value, FormattedObjectGraph formattedGraph, FormattingContext context, FormatChild formatChild)
		{
			AggregateException ex = (AggregateException)value;
			if (ex.InnerExceptions.Count == 1)
			{
				formattedGraph.AddFragment("(aggregated) ");
				formatChild("inner", ex.InnerException, formattedGraph);
				return;
			}
			formattedGraph.AddLine(FormattableString.Invariant($"{ex.InnerExceptions.Count} (aggregated) exceptions:"));
			foreach (Exception innerException in ex.InnerExceptions)
			{
				formattedGraph.AddLine(string.Empty);
				formatChild("InnerException", innerException, formattedGraph);
			}
		}
	}
}
