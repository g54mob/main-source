using System;
using System.Linq.Expressions;

namespace FluentAssertions.Formatting
{
	public class ExpressionValueFormatter : IValueFormatter
	{
		public bool CanHandle(object value)
		{
			return value is Expression;
		}

		public void Format(object value, FormattedObjectGraph formattedGraph, FormattingContext context, FormatChild formatChild)
		{
			formattedGraph.AddFragment(SystemExtensions.Replace(value.ToString(), " = ", " == ", StringComparison.Ordinal));
		}
	}
}
