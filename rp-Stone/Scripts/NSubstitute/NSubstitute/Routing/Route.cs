using System.Collections.Generic;
using NSubstitute.Core;

namespace NSubstitute.Routing
{
	public class Route : IRoute
	{
		private readonly ICallHandler[] _handlers;

		public IEnumerable<ICallHandler> Handlers => _handlers;

		public Route(ICallHandler[] handlers)
		{
			_handlers = handlers;
		}

		public object? Handle(ICall call)
		{
			for (int i = 0; i < _handlers.Length; i++)
			{
				RouteAction routeAction = _handlers[i].Handle(call);
				if (routeAction.HasReturnValue)
				{
					return routeAction.ReturnValue;
				}
			}
			return null;
		}
	}
}
