using NSubstitute.Core;

namespace NSubstitute.Routing.Handlers
{
	public class ReturnFromCustomHandlers : ICallHandler
	{
		public ReturnFromCustomHandlers(ICustomHandlers customHandlers)
		{
			_003CcustomHandlers_003EP = customHandlers;
			base._002Ector();
		}

		public RouteAction Handle(ICall call)
		{
			if (_003CcustomHandlers_003EP.Handlers.Count == 0)
			{
				return RouteAction.Continue();
			}
			foreach (ICallHandler handler in _003CcustomHandlers_003EP.Handlers)
			{
				RouteAction routeAction = handler.Handle(call);
				if (routeAction.HasReturnValue)
				{
					return routeAction;
				}
			}
			return RouteAction.Continue();
		}
	}
}
