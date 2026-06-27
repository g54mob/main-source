using System.Reflection;

namespace FluentAssertions.Formatting
{
	public class PropertyInfoFormatter : IValueFormatter
	{
		public bool CanHandle(object value)
		{
			return value is PropertyInfo;
		}

		public void Format(object value, FormattedObjectGraph formattedGraph, FormattingContext context, FormatChild formatChild)
		{
			if (!(value is PropertyInfo propertyInfo))
			{
				formattedGraph.AddFragment("<null>");
			}
			else
			{
				formattedGraph.AddFragment((propertyInfo.DeclaringType?.Name ?? string.Empty) + "." + propertyInfo.Name);
			}
		}
	}
}
