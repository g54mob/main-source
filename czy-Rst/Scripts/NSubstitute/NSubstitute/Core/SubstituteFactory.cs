using System;
using System.Linq;
using System.Reflection;
using NSubstitute.Exceptions;

namespace NSubstitute.Core
{
	public class SubstituteFactory : ISubstituteFactory
	{
		public SubstituteFactory(ISubstituteStateFactory substituteStateFactory, ICallRouterFactory callRouterFactory, IProxyFactory proxyFactory)
		{
			_003CsubstituteStateFactory_003EP = substituteStateFactory;
			_003CcallRouterFactory_003EP = callRouterFactory;
			_003CproxyFactory_003EP = proxyFactory;
			base._002Ector();
		}

		public object Create(Type[] typesToProxy, object?[] constructorArguments)
		{
			return Create(typesToProxy, constructorArguments, callBaseByDefault: false, isPartial: false);
		}

		public object CreatePartial(Type[] typesToProxy, object?[] constructorArguments)
		{
			Type primaryProxyType = GetPrimaryProxyType(typesToProxy);
			if (!CanCallBaseImplementation(primaryProxyType))
			{
				throw new CanNotPartiallySubForInterfaceOrDelegateException(primaryProxyType);
			}
			return Create(typesToProxy, constructorArguments, callBaseByDefault: true, isPartial: true);
		}

		private object Create(Type[] typesToProxy, object?[] constructorArguments, bool callBaseByDefault, bool isPartial)
		{
			ISubstituteState substituteState = _003CsubstituteStateFactory_003EP.Create(this);
			substituteState.CallBaseConfiguration.CallBaseByDefault = callBaseByDefault;
			Type primaryProxyType = GetPrimaryProxyType(typesToProxy);
			bool canConfigureBaseCalls = callBaseByDefault || CanCallBaseImplementation(primaryProxyType);
			ICallRouter callRouter = _003CcallRouterFactory_003EP.Create(substituteState, canConfigureBaseCalls);
			Type[] additionalInterfaces = typesToProxy.Where((Type x) => x != primaryProxyType).ToArray();
			return _003CproxyFactory_003EP.GenerateProxy(callRouter, primaryProxyType, additionalInterfaces, isPartial, constructorArguments);
		}

		private static Type GetPrimaryProxyType(Type[] typesToProxy)
		{
			return typesToProxy.FirstOrDefault((Type t) => t.IsDelegate()) ?? typesToProxy.FirstOrDefault((Type t) => t.GetTypeInfo().IsClass) ?? typesToProxy.First();
		}

		private static bool CanCallBaseImplementation(Type primaryProxyType)
		{
			bool flag = primaryProxyType.IsDelegate();
			if (primaryProxyType.GetTypeInfo().IsClass)
			{
				return !flag;
			}
			return false;
		}
	}
}
