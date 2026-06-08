using System.Linq;
using NSubstitute.Core;

namespace NSubstitute.Routing.Handlers
{
	public class PropertySetterHandler : ICallHandler
	{
		private readonly IPropertyHelper _propertyHelper;

		private readonly IConfigureCall _configureCall;

		public PropertySetterHandler(IPropertyHelper propertyHelper, IConfigureCall configureCall)
		{
			_propertyHelper = propertyHelper;
			_configureCall = configureCall;
		}

		public RouteAction Handle(ICall call)
		{
			if (_propertyHelper.IsCallToSetAReadWriteProperty(call))
			{
				ICall call2 = _propertyHelper.CreateCallToPropertyGetterFromSetterCall(call);
				object value = call.GetOriginalArguments().Last();
				_configureCall.SetResultForCall(call2, new ReturnValue(value), MatchArgs.AsSpecifiedInCall);
			}
			return RouteAction.Continue();
		}
	}
}
