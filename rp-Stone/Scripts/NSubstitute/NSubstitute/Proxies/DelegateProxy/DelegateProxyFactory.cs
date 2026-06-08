using System;
using NSubstitute.Core;
using NSubstitute.Proxies.CastleDynamicProxy;

namespace NSubstitute.Proxies.DelegateProxy
{
	[Obsolete("This class is deprecated and will be removed in future versions of the product.")]
	public class DelegateProxyFactory : IProxyFactory
	{
		private readonly CastleDynamicProxyFactory _castleObjectProxyFactory;

		public DelegateProxyFactory(CastleDynamicProxyFactory objectProxyFactory)
		{
			_castleObjectProxyFactory = objectProxyFactory ?? throw new ArgumentNullException("objectProxyFactory");
		}

		public object GenerateProxy(ICallRouter callRouter, Type typeToProxy, Type[]? additionalInterfaces, object?[]? constructorArguments)
		{
			return _castleObjectProxyFactory.GenerateProxy(callRouter, typeToProxy, additionalInterfaces, constructorArguments);
		}
	}
}
