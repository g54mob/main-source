using System.Linq;
using NSubstitute.Core;

namespace NSubstitute.Routing.Handlers
{
	public class PropertySetterHandler : ICallHandler
	{
		public PropertySetterHandler(IPropertyHelper propertyHelper, IConfigureCall configureCall)
		{
			_003CpropertyHelper_003EP = propertyHelper;
			_003CconfigureCall_003EP = configureCall;
			base._002Ector();
		}

		public RouteAction Handle(ICall call)
		{
			if (_003CpropertyHelper_003EP.IsCallToSetAReadWriteProperty(call))
			{
				ICall call2 = _003CpropertyHelper_003EP.CreateCallToPropertyGetterFromSetterCall(call);
				object value = call.GetOriginalArguments().Last();
				_003CconfigureCall_003EP.SetResultForCall(call2, new ReturnValue(value), MatchArgs.AsSpecifiedInCall);
			}
			return RouteAction.Continue();
		}
	}
}
