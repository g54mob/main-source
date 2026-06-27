using System;

namespace NSubstitute
{
	[Flags]
	public enum ClearOptions
	{
		ReceivedCalls = 1,
		ReturnValues = 2,
		CallActions = 4,
		All = 7
	}
}
