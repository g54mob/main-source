using System;
using NSubstitute.Core;

namespace NSubstitute.Proxies
{
	[Obsolete("This class is deprecated and will be removed in future versions of the product.")]
	public class ProxyFactory : IProxyFactory
	{
		private readonly IProxyFactory _delegateFactory;

		private readonly IProxyFactory _dynamicProxyFactory;

		public ProxyFactory(IProxyFactory delegateFactory, IProxyFactory dynamicProxyFactory)
		{
			_delegateFactory = delegateFactory;
			_dynamicProxyFactory = dynamicProxyFactory;
		}

		public object GenerateProxy(ICallRouter callRouter, Type typeToProxy, Type[]? additionalInterfaces, object?[]? constructorArguments)
		{
			if (!typeToProxy.IsDelegate())
			{
				return _dynamicProxyFactory.GenerateProxy(callRouter, typeToProxy, additionalInterfaces, constructorArguments);
			}
			return _delegateFactory.GenerateProxy(callRouter, typeToProxy, additionalInterfaces, constructorArguments);
		}
	}
}
