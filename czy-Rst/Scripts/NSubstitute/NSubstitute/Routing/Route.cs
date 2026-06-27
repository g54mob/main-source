using System.Collections.Generic;
using NSubstitute.Core;

namespace NSubstitute.Routing
{
	public class Route : IRoute
	{
		public IEnumerable<ICallHandler> Handlers => _003Chandlers_003EP;

		public Route(ICallHandler[] handlers)
		{
			_003Chandlers_003EP = handlers;
			base._002Ector();
		}

		public object? Handle(ICall call)
		{
			for (int i = 0; i < _003Chandlers_003EP.Length; i++)
			{
				RouteAction routeAction = _003Chandlers_003EP[i].Handle(call);
				if (routeAction.HasReturnValue)
				{
					return routeAction.ReturnValue;
				}
			}
			return null;
		}
	}
}
