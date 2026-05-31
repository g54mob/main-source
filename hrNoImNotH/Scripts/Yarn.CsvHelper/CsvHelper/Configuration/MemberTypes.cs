using System;

namespace CsvHelper.Configuration
{
	[Flags]
	public enum MemberTypes
	{
		None = 0,
		Properties = 1,
		Fields = 2
	}
}
