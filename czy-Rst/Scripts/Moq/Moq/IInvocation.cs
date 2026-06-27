using System;
using System.Collections.Generic;
using System.Reflection;

namespace Moq
{
	public interface IInvocation
	{
		MethodInfo Method { get; }

		IReadOnlyList<object> Arguments { get; }

		ISetup MatchingSetup { get; }

		bool IsVerified { get; }

		object ReturnValue { get; }

		Exception Exception { get; }
	}
}
