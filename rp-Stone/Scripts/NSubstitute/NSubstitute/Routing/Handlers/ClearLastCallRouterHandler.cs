using NSubstitute.Core;

namespace NSubstitute.Routing.Handlers
{
	public class ClearLastCallRouterHandler : ICallHandler
	{
		private readonly IThreadLocalContext _threadContext;

		public ClearLastCallRouterHandler(IThreadLocalContext threadContext)
		{
			_threadContext = threadContext;
		}

		public RouteAction Handle(ICall call)
		{
			_threadContext.ClearLastCallRouter();
			return RouteAction.Continue();
		}
	}
}
