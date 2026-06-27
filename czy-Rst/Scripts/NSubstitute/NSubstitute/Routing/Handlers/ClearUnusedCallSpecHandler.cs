using NSubstitute.Core;

namespace NSubstitute.Routing.Handlers
{
	public class ClearUnusedCallSpecHandler : ICallHandler
	{
		public ClearUnusedCallSpecHandler(IPendingSpecification pendingSpecification)
		{
			_003CpendingSpecification_003EP = pendingSpecification;
			base._002Ector();
		}

		public RouteAction Handle(ICall call)
		{
			_003CpendingSpecification_003EP.Clear();
			return RouteAction.Continue();
		}
	}
}
