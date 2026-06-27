using System;
using NSubstitute.Core;

namespace NSubstitute.Proxies
{
	[Obsolete("This class is deprecated and will be removed in future versions of the product.")]
	public class ProxyFactory : IProxyFactory
	{
		public ProxyFactory(IProxyFactory delegateFactory, IProxyFactory dynamicProxyFactory)
		{
			_003CdelegateFactory_003EP = delegateFactory;
			_003CdynamicProxyFactory_003EP = dynamicProxyFactory;
			base._002Ector();
		}

		public object GenerateProxy(ICallRouter callRouter, Type typeToProxy, Type[]? additionalInterfaces, bool isPartial, object?[]? constructorArguments)
		{
			if (!typeToProxy.IsDelegate())
			{
				return _003CdynamicProxyFactory_003EP.GenerateProxy(callRouter, typeToProxy, additionalInterfaces, isPartial, constructorArguments);
			}
			return _003CdelegateFactory_003EP.GenerateProxy(callRouter, typeToProxy, additionalInterfaces, isPartial, constructorArguments);
		}
	}
}
