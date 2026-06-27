using NSubstitute.Core;

namespace NSubstitute.Routing.Handlers
{
	public class TrackLastCallHandler : ICallHandler
	{
		public TrackLastCallHandler(IPendingSpecification pendingSpecification)
		{
			_003CpendingSpecification_003EP = pendingSpecification;
			base._002Ector();
		}

		public RouteAction Handle(ICall call)
		{
			_003CpendingSpecification_003EP.SetLastCall(call);
			return RouteAction.Continue();
		}
	}
}
