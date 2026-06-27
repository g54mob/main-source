using NSubstitute.Core;

namespace NSubstitute.Routing.Handlers
{
	public class ReturnDefaultForReturnTypeHandler : ICallHandler
	{
		public ReturnDefaultForReturnTypeHandler(IDefaultForType defaultForType)
		{
			_003CdefaultForType_003EP = defaultForType;
			base._002Ector();
		}

		public RouteAction Handle(ICall call)
		{
			return RouteAction.Return(_003CdefaultForType_003EP.GetDefaultFor(call.GetMethodInfo().ReturnType));
		}
	}
}
