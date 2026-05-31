using System;

namespace CsvHelper.Configuration
{
	[Flags]
	public enum TrimOptions
	{
		None = 0,
		Trim = 1,
		InsideQuotes = 2
	}
}
