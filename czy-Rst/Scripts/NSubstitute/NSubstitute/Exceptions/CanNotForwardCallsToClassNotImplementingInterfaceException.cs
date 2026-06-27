using System;

namespace NSubstitute.Exceptions
{
	public sealed class CanNotForwardCallsToClassNotImplementingInterfaceException : TypeForwardingException
	{
		public CanNotForwardCallsToClassNotImplementingInterfaceException(Type type)
			: base(DescribeProblem(type))
		{
		}

		private static string DescribeProblem(Type type)
		{
			return $"The provided class '{type.Name}' doesn't implement all requested interfaces. ";
		}
	}
}
