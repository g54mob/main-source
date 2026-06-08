using System.Linq;
using System.Reflection;
using NSubstitute.Exceptions;

namespace NSubstitute.Core.SequenceChecking
{
	public class SequenceInOrderAssertion
	{
		public void Assert(IQueryResults queryResult)
		{
			ICall[] array = (from x in queryResult.MatchingCallsInOrder()
				where IsNotPropertyGetterCall(x.GetMethodInfo())
				select x).ToArray();
			CallSpecAndTarget[] array2 = (from x in queryResult.QuerySpecification()
				where IsNotPropertyGetterCall(x.CallSpecification.GetMethodInfo())
				select x).ToArray();
			if (array.Length != array2.Length)
			{
				throw new CallSequenceNotFoundException(GetExceptionMessage(array2, array));
			}
			if (array.Zip(array2, (ICall call, CallSpecAndTarget specAndTarget) => new
			{
				Call = call,
				Spec = specAndTarget.CallSpecification,
				IsMatch = Matches(call, specAndTarget)
			}).Any(x => !x.IsMatch))
			{
				throw new CallSequenceNotFoundException(GetExceptionMessage(array2, array));
			}
		}

		private bool Matches(ICall call, CallSpecAndTarget specAndTarget)
		{
			if (call.Target() == specAndTarget.Target)
			{
				return specAndTarget.CallSpecification.IsSatisfiedBy(call);
			}
			return false;
		}

		private bool IsNotPropertyGetterCall(MethodInfo methodInfo)
		{
			return methodInfo.GetPropertyFromGetterCallOrNull() == null;
		}

		private string GetExceptionMessage(CallSpecAndTarget[] querySpec, ICall[] matchingCallsInOrder)
		{
			SequenceFormatter sequenceFormatter = new SequenceFormatter("\n    ", querySpec, matchingCallsInOrder);
			return string.Format("\nExpected to receive these calls in order:\n{0}{1}\n\nActually received matching calls in this order:\n{0}{2}\n\n{3}", "\n    ", sequenceFormatter.FormatQuery(), sequenceFormatter.FormatActualCalls(), "*** Note: calls to property getters are not considered part of the query. ***");
		}
	}
}
