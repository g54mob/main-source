using System;

namespace DevCmdLine
{
	[Flags]
	public enum DevCmdCompleteFlags
	{
		None = 0,
		Cache = 1,
		ValueCaseInsensitive = 2,
		Sort = 4,
		Default = 7
	}
}
