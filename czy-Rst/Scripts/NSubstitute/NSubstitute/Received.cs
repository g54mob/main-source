using System;
using NSubstitute.Core;
using NSubstitute.Core.SequenceChecking;

namespace NSubstitute
{
	public class Received
	{
		public static void InOrder(Action calls)
		{
			Query query = new Query(SubstitutionContext.Current.CallSpecificationFactory);
			SubstitutionContext.Current.ThreadContext.RunInQueryContext(calls, query);
			new SequenceInOrderAssertion().Assert(query.Result());
		}
	}
}
