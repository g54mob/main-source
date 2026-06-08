using System;
using System.Linq;
using System.Reflection;
using NSubstitute.Exceptions;

namespace NSubstitute.Core
{
	public class SubstituteFactory : ISubstituteFactory
	{
		private readonly ISubstituteStateFactory _substituteStateFactory;

		private readonly ICallRouterFactory _callRouterFactory;

		private readonly IProxyFactory _proxyFactory;

		public SubstituteFactory(ISubstituteStateFactory substituteStateFactory, ICallRouterFactory callRouterFactory, IProxyFactory proxyFactory)
		{
			_substituteStateFactory = substituteStateFactory;
			_callRouterFactory = callRouterFactory;
			_proxyFactory = proxyFactory;
		}

		public object Create(Type[] typesToProxy, object?[] constructorArguments)
		{
			return Create(typesToProxy, constructorArguments, callBaseByDefault: false);
		}

		public object CreatePartial(Type[] typesToProxy, object?[] constructorArguments)
		{
			Type primaryProxyType = GetPrimaryProxyType(typesToProxy);
			if (!CanCallBaseImplementation(primaryProxyType))
			{
				throw new CanNotPartiallySubForInterfaceOrDelegateException(primaryProxyType);
			}
			return Create(typesToProxy, constructorArguments, callBaseByDefault: true);
		}

		private object Create(Type[] typesToProxy, object?[] constructorArguments, bool callBaseByDefault)
		{
			ISubstituteState substituteState = _substituteStateFactory.Create(this);
			substituteState.CallBaseConfiguration.CallBaseByDefault = callBaseByDefault;
			Type primaryProxyType = GetPrimaryProxyType(typesToProxy);
			bool canConfigureBaseCalls = callBaseByDefault || CanCallBaseImplementation(primaryProxyType);
			ICallRouter callRouter = _callRouterFactory.Create(substituteState, canConfigureBaseCalls);
			Type[] additionalInterfaces = typesToProxy.Where((Type x) => x != primaryProxyType).ToArray();
			return _proxyFactory.GenerateProxy(callRouter, primaryProxyType, additionalInterfaces, constructorArguments);
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
