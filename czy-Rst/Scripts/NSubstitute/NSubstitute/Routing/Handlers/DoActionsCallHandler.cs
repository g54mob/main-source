using NSubstitute.Core;

namespace NSubstitute.Routing.Handlers
{
	public class DoActionsCallHandler : ICallHandler
	{
		public DoActionsCallHandler(ICallActions callActions)
		{
			_003CcallActions_003EP = callActions;
			base._002Ector();
		}

		public RouteAction Handle(ICall call)
		{
			_003CcallActions_003EP.InvokeMatchingActions(call);
			return RouteAction.Continue();
		}
	}
}
