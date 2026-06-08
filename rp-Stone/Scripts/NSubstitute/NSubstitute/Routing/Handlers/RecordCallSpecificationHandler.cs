using System.Linq;
using NSubstitute.Core;
using NSubstitute.Core.Arguments;

namespace NSubstitute.Routing.Handlers
{
	public class RecordCallSpecificationHandler : ICallHandler
	{
		private readonly IPendingSpecification _pendingCallSpecification;

		private readonly ICallSpecificationFactory _callSpecificationFactory;

		private readonly ICallActions _callActions;

		public RecordCallSpecificationHandler(IPendingSpecification pendingCallSpecification, ICallSpecificationFactory callSpecificationFactory, ICallActions callActions)
		{
			_pendingCallSpecification = pendingCallSpecification;
			_callSpecificationFactory = callSpecificationFactory;
			_callActions = callActions;
		}

		public RouteAction Handle(ICall call)
		{
			ICallSpecification callSpecification = _callSpecificationFactory.CreateFrom(call, MatchArgs.AsSpecifiedInCall);
			_pendingCallSpecification.SetCallSpecification(callSpecification);
			if (call.GetArgumentSpecifications().Any((IArgumentSpecification x) => x.HasAction))
			{
				_callActions.Add(callSpecification);
			}
			return RouteAction.Continue();
		}
	}
}
