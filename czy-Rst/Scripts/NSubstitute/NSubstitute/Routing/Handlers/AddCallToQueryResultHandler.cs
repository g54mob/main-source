using NSubstitute.Core;

namespace NSubstitute.Routing.Handlers
{
	public class AddCallToQueryResultHandler : ICallHandler
	{
		public AddCallToQueryResultHandler(IThreadLocalContext threadContext)
		{
			_003CthreadContext_003EP = threadContext;
			base._002Ector();
		}

		public RouteAction Handle(ICall call)
		{
			_003CthreadContext_003EP.RegisterInContextQuery(call);
			return RouteAction.Continue();
		}
	}
}
