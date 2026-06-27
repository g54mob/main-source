using NSubstitute.Routing;

namespace NSubstitute.Core
{
	public class CallRouterFactory : ICallRouterFactory
	{
		public CallRouterFactory(IThreadLocalContext threadLocalContext, IRouteFactory routeFactory)
		{
			_003CthreadLocalContext_003EP = threadLocalContext;
			_003CrouteFactory_003EP = routeFactory;
			base._002Ector();
		}

		public ICallRouter Create(ISubstituteState substituteState, bool canConfigureBaseCalls)
		{
			RouteFactoryCacheWrapper routeFactoryCacheWrapper = new RouteFactoryCacheWrapper(_003CrouteFactory_003EP);
			return new CallRouter(substituteState, _003CthreadLocalContext_003EP, routeFactoryCacheWrapper, canConfigureBaseCalls);
		}
	}
}
