using System;

namespace Moq
{
	[Flags]
	internal enum MockExceptionReasons
	{
		IncorrectNumberOfCalls = 1,
		NoMatchingCalls = 4,
		NoSetup = 8,
		ReturnValueRequired = 0x10,
		UnmatchedSetup = 0x20,
		UnverifiedInvocations = 0x40
	}
}
