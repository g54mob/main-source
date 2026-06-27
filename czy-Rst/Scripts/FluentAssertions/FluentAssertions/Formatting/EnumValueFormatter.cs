using System;
using System.Globalization;

namespace FluentAssertions.Formatting
{
	public class EnumValueFormatter : IValueFormatter
	{
		public virtual bool CanHandle(object value)
		{
			return value is Enum;
		}

		public void Format(object value, FormattedObjectGraph formattedGraph, FormattingContext context, FormatChild formatChild)
		{
			string name = value.GetType().Name;
			string text = SystemExtensions.Replace(value.ToString(), ", ", "|", StringComparison.Ordinal);
			string text2 = Convert.ToDecimal(value, CultureInfo.InvariantCulture).ToString(CultureInfo.InvariantCulture);
			formattedGraph.AddFragment(name + "." + text + " {value: " + text2 + "}");
		}
	}
}
