using NSubstitute.Routing;

namespace NSubstitute.Core
{
	public class CallRouterFactory : ICallRouterFactory
	{
		private readonly IThreadLocalContext _threadLocalContext;

		private readonly IRouteFactory _routeFactory;

		public CallRouterFactory(IThreadLocalContext threadLocalContext, IRouteFactory routeFactory)
		{
			_threadLocalContext = threadLocalContext;
			_routeFactory = routeFactory;
		}

		public ICallRouter Create(ISubstituteState substituteState, bool canConfigureBaseCalls)
		{
			RouteFactoryCacheWrapper routeFactory = new RouteFactoryCacheWrapper(_routeFactory);
			return new CallRouter(substituteState, _threadLocalContext, routeFactory, canConfigureBaseCalls);
		}
	}
}
