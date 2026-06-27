using System.Linq;
using NSubstitute.Core;
using NSubstitute.Core.Arguments;

namespace NSubstitute.Routing.Handlers
{
	public class RecordCallSpecificationHandler : ICallHandler
	{
		public RecordCallSpecificationHandler(IPendingSpecification pendingCallSpecification, ICallSpecificationFactory callSpecificationFactory, ICallActions callActions)
		{
			_003CpendingCallSpecification_003EP = pendingCallSpecification;
			_003CcallSpecificationFactory_003EP = callSpecificationFactory;
			_003CcallActions_003EP = callActions;
			base._002Ector();
		}

		public RouteAction Handle(ICall call)
		{
			ICallSpecification callSpecification = _003CcallSpecificationFactory_003EP.CreateFrom(call, MatchArgs.AsSpecifiedInCall);
			_003CpendingCallSpecification_003EP.SetCallSpecification(callSpecification);
			if (call.GetArgumentSpecifications().Any((IArgumentSpecification x) => x.HasAction))
			{
				_003CcallActions_003EP.Add(callSpecification);
			}
			return RouteAction.Continue();
		}
	}
}
