using NSubstitute.Core;

namespace NSubstitute.Routing.Handlers
{
	public class ReturnFromBaseIfRequired : ICallHandler
	{
		public ReturnFromBaseIfRequired(ICallBaseConfiguration config)
		{
			_003Cconfig_003EP = config;
			base._002Ector();
		}

		public RouteAction Handle(ICall call)
		{
			if (_003Cconfig_003EP.ShouldCallBase(call))
			{
				return call.TryCallBase().Fold(RouteAction.Continue, RouteAction.Return);
			}
			return RouteAction.Continue();
		}
	}
}
