using NSubstitute.Core;
using NSubstitute.Exceptions;

namespace NSubstitute.ReceivedExtensions
{
	public static class ReceivedExtensions
	{
		public static T Received<T>(this T substitute, Quantity requiredQuantity)
		{
			if (substitute == null)
			{
				throw new NullSubstituteReferenceException();
			}
			ISubstitutionContext context = SubstitutionContext.Current;
			ICallRouter callRouterFor = context.GetCallRouterFor(substitute);
			context.ThreadContext.SetNextRoute(callRouterFor, (ISubstituteState x) => context.RouteFactory.CheckReceivedCalls(x, MatchArgs.AsSpecifiedInCall, requiredQuantity));
			return substitute;
		}

		public static T ReceivedWithAnyArgs<T>(this T substitute, Quantity requiredQuantity)
		{
			if (substitute == null)
			{
				throw new NullSubstituteReferenceException();
			}
			ISubstitutionContext context = SubstitutionContext.Current;
			ICallRouter callRouterFor = context.GetCallRouterFor(substitute);
			context.ThreadContext.SetNextRoute(callRouterFor, (ISubstituteState x) => context.RouteFactory.CheckReceivedCalls(x, MatchArgs.Any, requiredQuantity));
			return substitute;
		}
	}
}
