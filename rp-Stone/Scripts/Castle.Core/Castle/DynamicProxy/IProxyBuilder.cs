using System;
using Castle.Core.Logging;

namespace Castle.DynamicProxy
{
	public interface IProxyBuilder
	{
		ILogger Logger { get; set; }

		ModuleScope ModuleScope { get; }

		Type CreateClassProxyType(Type classToProxy, Type[] additionalInterfacesToProxy, ProxyGenerationOptions options);

		Type CreateClassProxyTypeWithTarget(Type classToProxy, Type[] additionalInterfacesToProxy, ProxyGenerationOptions options);

		Type CreateInterfaceProxyTypeWithTarget(Type interfaceToProxy, Type[] additionalInterfacesToProxy, Type targetType, ProxyGenerationOptions options);

		Type CreateInterfaceProxyTypeWithTargetInterface(Type interfaceToProxy, Type[] additionalInterfacesToProxy, ProxyGenerationOptions options);

		Type CreateInterfaceProxyTypeWithoutTarget(Type interfaceToProxy, Type[] additionalInterfacesToProxy, ProxyGenerationOptions options);
	}
}
