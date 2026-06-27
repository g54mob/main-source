using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using NSubstitute.Core;

namespace NSubstitute.Routing.Handlers
{
	public class ReturnFromAndConfigureDynamicCall : ICallHandler
	{
		public class DynamicStub
		{
			public ConfiguredCall Returns<T>(T? returnThis, params T?[] returnThese)
			{
				return default(T).Returns<T>(returnThis, returnThese);
			}

			public ConfiguredCall Returns<T>(Func<CallInfo, T?> returnThis, params Func<CallInfo, T?>[] returnThese)
			{
				return default(T).Returns(returnThis, returnThese);
			}

			public ConfiguredCall ReturnsForAnyArgs<T>(T? returnThis, params T?[] returnThese)
			{
				return default(T).ReturnsForAnyArgs<T>(returnThis, returnThese);
			}

			public ConfiguredCall ReturnsForAnyArgs<T>(Func<CallInfo, T?> returnThis, params Func<CallInfo, T?>[] returnThese)
			{
				return default(T).ReturnsForAnyArgs(returnThis, returnThese);
			}
		}

		private static readonly Type DynamicAttributeType = typeof(DynamicAttribute);

		public ReturnFromAndConfigureDynamicCall(IConfigureCall configureCall)
		{
			_003CconfigureCall_003EP = configureCall;
			base._002Ector();
		}

		public RouteAction Handle(ICall call)
		{
			if (ReturnsDynamic(call))
			{
				DynamicStub value = new DynamicStub();
				_003CconfigureCall_003EP.SetResultForCall(call, new ReturnValue(value), MatchArgs.AsSpecifiedInCall);
				return RouteAction.Return(new DynamicStub());
			}
			return RouteAction.Continue();
		}

		private bool ReturnsDynamic(ICall call)
		{
			ParameterInfo returnParameter = call.GetMethodInfo().ReturnParameter;
			if (returnParameter == null)
			{
				return false;
			}
			return returnParameter.GetCustomAttributes(DynamicAttributeType, inherit: false).Length != 0;
		}
	}
}
