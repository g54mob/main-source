using System.Collections.Generic;
using System.Linq;
using NSubstitute.Core;
using NSubstitute.ReceivedExtensions;

namespace NSubstitute.Routing.Handlers
{
	public class CheckReceivedCallsHandler : ICallHandler
	{
		public CheckReceivedCallsHandler(ICallCollection receivedCalls, ICallSpecificationFactory callSpecificationFactory, IReceivedCallsExceptionThrower exceptionThrower, MatchArgs matchArgs, Quantity requiredQuantity)
		{
			_003CreceivedCalls_003EP = receivedCalls;
			_003CcallSpecificationFactory_003EP = callSpecificationFactory;
			_003CexceptionThrower_003EP = exceptionThrower;
			_003CmatchArgs_003EP = matchArgs;
			_003CrequiredQuantity_003EP = requiredQuantity;
			base._002Ector();
		}

		public RouteAction Handle(ICall call)
		{
			ICallSpecification callSpecification = _003CcallSpecificationFactory_003EP.CreateFrom(call, _003CmatchArgs_003EP);
			ICallSpecification callSpecification2 = _003CcallSpecificationFactory_003EP.CreateFrom(call, MatchArgs.Any);
			List<ICall> source = _003CreceivedCalls_003EP.AllCalls().ToList();
			List<ICall> list = source.Where(callSpecification.IsSatisfiedBy).ToList();
			if (!_003CrequiredQuantity_003EP.Matches(list))
			{
				IEnumerable<ICall> nonMatchingCalls = source.Where(callSpecification2.IsSatisfiedBy).Except(list);
				_003CexceptionThrower_003EP.Throw(callSpecification, list, nonMatchingCalls, _003CrequiredQuantity_003EP);
			}
			return RouteAction.Continue();
		}
	}
}
