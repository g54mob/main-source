using System;
using System.Collections.Generic;
using NSubstitute.Core;
using NSubstitute.Routing.AutoValues;

namespace NSubstitute.Routing.Handlers
{
	public class ReturnAutoValue : ICallHandler
	{
		private readonly IAutoValueProvider[] _autoValueProviders;

		private readonly ICallResults _callResults;

		private readonly ICallSpecificationFactory _callSpecificationFactory;

		private readonly AutoValueBehaviour _autoValueBehaviour;

		public ReturnAutoValue(AutoValueBehaviour autoValueBehaviour, IEnumerable<IAutoValueProvider> autoValueProviders, ICallResults callResults, ICallSpecificationFactory callSpecificationFactory)
		{
			_autoValueProviders = autoValueProviders.AsArray();
			_callResults = callResults;
			_callSpecificationFactory = callSpecificationFactory;
			_autoValueBehaviour = autoValueBehaviour;
		}

		public RouteAction Handle(ICall call)
		{
			if (_callResults.TryGetResult(call, out object result))
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
			if (_autoValueBehaviour == AutoValueBehaviour.UseValueForSubsequentCalls)
			{
				ICallSpecification callSpecification = _callSpecificationFactory.CreateFrom(call, MatchArgs.AsSpecifiedInCall);
				_callResults.SetResult(callSpecification, new ReturnValue(value));
			}
			return value;
		}
	}
}
