using System.Collections.Generic;
using System.Linq;

namespace FluentAssertions.Formatting
{
	public class FormattingOptions
	{
		internal List<IValueFormatter> ScopedFormatters { get; set; } = new List<IValueFormatter>();

		public bool UseLineBreaks { get; set; }

		public int MaxDepth { get; set; } = 5;

		public int MaxLines { get; set; } = 100;

		public void RemoveFormatter(IValueFormatter formatter)
		{
			ScopedFormatters.Remove(formatter);
		}

		public void AddFormatter(IValueFormatter formatter)
		{
			if (!ScopedFormatters.Contains(formatter))
			{
				ScopedFormatters.Insert(0, formatter);
			}
		}

		internal FormattingOptions Clone()
		{
			return new FormattingOptions
			{
				UseLineBreaks = UseLineBreaks,
				MaxDepth = MaxDepth,
				MaxLines = MaxLines,
				ScopedFormatters = ScopedFormatters.ToList()
			};
		}
	}
}
