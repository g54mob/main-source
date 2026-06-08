using System.Collections.Generic;
using System.Linq;
using NSubstitute.Core;
using NSubstitute.ReceivedExtensions;

namespace NSubstitute.Routing.Handlers
{
	public class CheckReceivedCallsHandler : ICallHandler
	{
		private readonly ICallCollection _receivedCalls;

		private readonly ICallSpecificationFactory _callSpecificationFactory;

		private readonly IReceivedCallsExceptionThrower _exceptionThrower;

		private readonly MatchArgs _matchArgs;

		private readonly Quantity _requiredQuantity;

		public CheckReceivedCallsHandler(ICallCollection receivedCalls, ICallSpecificationFactory callSpecificationFactory, IReceivedCallsExceptionThrower exceptionThrower, MatchArgs matchArgs, Quantity requiredQuantity)
		{
			_receivedCalls = receivedCalls;
			_callSpecificationFactory = callSpecificationFactory;
			_exceptionThrower = exceptionThrower;
			_matchArgs = matchArgs;
			_requiredQuantity = requiredQuantity;
		}

		public RouteAction Handle(ICall call)
		{
			ICallSpecification callSpecification = _callSpecificationFactory.CreateFrom(call, _matchArgs);
			ICallSpecification callSpecification2 = _callSpecificationFactory.CreateFrom(call, MatchArgs.Any);
			List<ICall> source = _receivedCalls.AllCalls().ToList();
			List<ICall> list = source.Where(callSpecification.IsSatisfiedBy).ToList();
			if (!_requiredQuantity.Matches(list))
			{
				IEnumerable<ICall> nonMatchingCalls = source.Where(callSpecification2.IsSatisfiedBy).Except(list);
				_exceptionThrower.Throw(callSpecification, list, nonMatchingCalls, _requiredQuantity);
			}
			return RouteAction.Continue();
		}
	}
}
