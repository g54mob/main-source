using System;

namespace NSubstitute.Exceptions
{
	public sealed class CanNotForwardCallsToAbstractClassException : TypeForwardingException
	{
		public CanNotForwardCallsToAbstractClassException(Type type)
			: base(DescribeProblem(type))
		{
		}

		private static string DescribeProblem(Type type)
		{
			return $"The provided class '{type.Name}' is abstract. ";
		}
	}
}
