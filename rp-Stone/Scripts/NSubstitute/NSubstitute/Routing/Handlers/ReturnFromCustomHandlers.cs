using NSubstitute.Core;

namespace NSubstitute.Routing.Handlers
{
	public class ReturnFromCustomHandlers : ICallHandler
	{
		private readonly ICustomHandlers _customHandlers;

		public ReturnFromCustomHandlers(ICustomHandlers customHandlers)
		{
			_customHandlers = customHandlers;
		}

		public RouteAction Handle(ICall call)
		{
			if (_customHandlers.Handlers.Count == 0)
			{
				return RouteAction.Continue();
			}
			foreach (ICallHandler handler in _customHandlers.Handlers)
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
