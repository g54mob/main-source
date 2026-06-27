using System;
using System.Collections.Generic;
using NSubstitute.Core;
using NSubstitute.Routing.AutoValues;

namespace NSubstitute.Routing.Handlers
{
	public class ReturnAutoValue : ICallHandler
	{
		private readonly IAutoValueProvider[] _autoValueProviders;

		public ReturnAutoValue(AutoValueBehaviour autoValueBehaviour, IEnumerable<IAutoValueProvider> autoValueProviders, ICallResults callResults, ICallSpecificationFactory callSpecificationFactory)
		{
			_003CautoValueBehaviour_003EP = autoValueBehaviour;
			_003CcallResults_003EP = callResults;
			_003CcallSpecificationFactory_003EP = callSpecificationFactory;
			_autoValueProviders = autoValueProviders.AsArray();
			base._002Ector();
		}

		public RouteAction Handle(ICall call)
		{
			if (_003CcallResults_003EP.TryGetResult(call, out object result))
			{
				return RouteAction.Return(result);
			}
			Type returnType = call.GetReturnType();
			IAutoValueProvider[] autoValueProviders = _autoValueProviders;
			foreach (IAutoValueProvider autoValueProvider in autoValueProviders)
			{
				if (autoValueProvider.CanProvideValueFor(returnType))
				{
					return RouteAction.Return(GetResultValueUsingProvider(call, returnType, autoValueProvider));
				}
			}
			return RouteAction.Continue();
		}

		private object? GetResultValueUsingProvider(ICall call, Type type, IAutoValueProvider provider)
		{
			object value = provider.GetValue(type);
			if (_003CautoValueBehaviour_003EP == AutoValueBehaviour.UseValueForSubsequentCalls)
			{
				ICallSpecification callSpecification = _003CcallSpecificationFactory_003EP.CreateFrom(call, MatchArgs.AsSpecifiedInCall);
				_003CcallResults_003EP.SetResult(callSpecification, new ReturnValue(value));
			}
			return value;
		}
	}
}
