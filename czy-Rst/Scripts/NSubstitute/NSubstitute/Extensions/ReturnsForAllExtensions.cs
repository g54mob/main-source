using System;
using NSubstitute.Core;
using NSubstitute.Exceptions;

namespace NSubstitute.Extensions
{
	public static class ReturnsForAllExtensions
	{
		public static void ReturnsForAll<T>(this object substitute, T returnThis)
		{
			if (substitute == null)
			{
				throw new NullSubstituteReferenceException();
			}
			SubstitutionContext.Current.GetCallRouterFor(substitute).SetReturnForType(typeof(T), new ReturnValue(returnThis));
		}

		public static void ReturnsForAll<T>(this object substitute, Func<CallInfo, T> returnThis)
		{
			if (substitute == null)
			{
				throw new NullSubstituteReferenceException();
			}
			SubstitutionContext.Current.GetCallRouterFor(substitute).SetReturnForType(typeof(T), new ReturnValueFromFunc<T>(returnThis));
		}
	}
}
