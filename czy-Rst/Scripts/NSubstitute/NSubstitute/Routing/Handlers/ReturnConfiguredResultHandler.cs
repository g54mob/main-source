using NSubstitute.Core;

namespace NSubstitute.Routing.Handlers
{
	public class ReturnConfiguredResultHandler : ICallHandler
	{
		public ReturnConfiguredResultHandler(ICallResults callResults)
		{
			_003CcallResults_003EP = callResults;
			base._002Ector();
		}

		public RouteAction Handle(ICall call)
		{
			if (_003CcallResults_003EP.TryGetResult(call, out object result))
			{
				return RouteAction.Return(result);
			}
			return RouteAction.Continue();
		}
	}
}
