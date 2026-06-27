using NSubstitute.Core;

namespace NSubstitute.Routing.Handlers
{
	public class ClearLastCallRouterHandler : ICallHandler
	{
		public ClearLastCallRouterHandler(IThreadLocalContext threadContext)
		{
			_003CthreadContext_003EP = threadContext;
			base._002Ector();
		}

		public RouteAction Handle(ICall call)
		{
			_003CthreadContext_003EP.ClearLastCallRouter();
			return RouteAction.Continue();
		}
	}
}
