using System.Collections.Generic;
using System.Linq;

namespace NSubstitute.Core
{
	public class Query : IQuery, IQueryResults
	{
		private class CallSequenceNumberComparer : IEqualityComparer<ICall>
		{
			public bool Equals(ICall? x, ICall? y)
			{
				return x?.GetSequenceNumber() == y?.GetSequenceNumber();
			}

			public int GetHashCode(ICall obj)
			{
				return obj.GetSequenceNumber().GetHashCode();
			}
		}

		private readonly List<CallSpecAndTarget> _querySpec;

		private readonly HashSet<ICall> _matchingCalls;

		public Query(ICallSpecificationFactory callSpecificationFactory)
		{
			_003CcallSpecificationFactory_003EP = callSpecificationFactory;
			_querySpec = new List<CallSpecAndTarget>();
			_matchingCalls = new HashSet<ICall>(new CallSequenceNumberComparer());
			base._002Ector();
		}

		public void RegisterCall(ICall call)
		{
			object obj = call.Target();
			ICallSpecification callSpecification = _003CcallSpecificationFactory_003EP.CreateFrom(call, MatchArgs.AsSpecifiedInCall);
			_querySpec.Add(new CallSpecAndTarget(callSpecification, obj));
			IEnumerable<ICall> other = obj.ReceivedCalls().Where(callSpecification.IsSatisfiedBy);
			_matchingCalls.UnionWith(other);
		}

		public IQueryResults Result()
		{
			return this;
		}

		IEnumerable<ICall> IQueryResults.MatchingCallsInOrder()
		{
			return _matchingCalls.OrderBy((ICall x) => x.GetSequenceNumber());
		}

		IEnumerable<CallSpecAndTarget> IQueryResults.QuerySpecification()
		{
			return _querySpec.Select((CallSpecAndTarget x) => x);
		}
	}
}
