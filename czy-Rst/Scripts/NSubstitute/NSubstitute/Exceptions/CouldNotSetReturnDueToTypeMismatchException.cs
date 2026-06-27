using System;
using System.Reflection;

namespace NSubstitute.Exceptions
{
	public class CouldNotSetReturnDueToTypeMismatchException : CouldNotSetReturnException
	{
		public CouldNotSetReturnDueToTypeMismatchException(Type? returnType, MethodInfo member)
			: base(DescribeProblem(returnType, member))
		{
		}

		private static string DescribeProblem(Type? typeOfReturnValue, MethodInfo member)
		{
			if (!(typeOfReturnValue == null))
			{
				return $"Can not return value of type {typeOfReturnValue.Name} for {member.DeclaringType.Name}.{member.Name} (expected type {member.ReturnType.Name}).";
			}
			return $"Can not return null for {member.DeclaringType.Name}.{member.Name} (expected type {member.ReturnType.Name}).";
		}
	}
}
