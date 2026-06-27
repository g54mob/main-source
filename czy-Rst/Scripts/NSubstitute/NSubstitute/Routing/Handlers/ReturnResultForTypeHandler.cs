using NSubstitute.Core;

namespace NSubstitute.Routing.Handlers
{
	public class ReturnResultForTypeHandler : ICallHandler
	{
		public ReturnResultForTypeHandler(IResultsForType resultsForType)
		{
			_003CresultsForType_003EP = resultsForType;
			base._002Ector();
		}

		public RouteAction Handle(ICall call)
		{
			if (_003CresultsForType_003EP.TryGetResult(call, out object result))
			{
				return RouteAction.Return(result);
			}
			return RouteAction.Continue();
		}
	}
}
