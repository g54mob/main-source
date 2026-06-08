using System;
using Castle.Core.Logging;

namespace Castle.DynamicProxy
{
	[CLSCompliant(true)]
	public interface IProxyGenerator
	{
		ILogger Logger { get; set; }

		IProxyBuilder ProxyBuilder { get; }

		TInterface CreateInterfaceProxyWithTarget<TInterface>(TInterface target, params IInterceptor[] interceptors) where TInterface : class;

		TInterface CreateInterfaceProxyWithTarget<TInterface>(TInterface target, ProxyGenerationOptions options, params IInterceptor[] interceptors) where TInterface : class;

		object CreateInterfaceProxyWithTarget(Type interfaceToProxy, object target, params IInterceptor[] interceptors);

		object CreateInterfaceProxyWithTarget(Type interfaceToProxy, object target, ProxyGenerationOptions options, params IInterceptor[] interceptors);

		object CreateInterfaceProxyWithTarget(Type interfaceToProxy, Type[] additionalInterfacesToProxy, object target, params IInterceptor[] interceptors);

		object CreateInterfaceProxyWithTarget(Type interfaceToProxy, Type[] additionalInterfacesToProxy, object target, ProxyGenerationOptions options, params IInterceptor[] interceptors);

		object CreateInterfaceProxyWithTargetInterface(Type interfaceToProxy, object target, params IInterceptor[] interceptors);

		TInterface CreateInterfaceProxyWithTargetInterface<TInterface>(TInterface target, params IInterceptor[] interceptors) where TInterface : class;

		TInterface CreateInterfaceProxyWithTargetInterface<TInterface>(TInterface target, ProxyGenerationOptions options, params IInterceptor[] interceptors) where TInterface : class;

		object CreateInterfaceProxyWithTargetInterface(Type interfaceToProxy, Type[] additionalInterfacesToProxy, object target, params IInterceptor[] interceptors);

		object CreateInterfaceProxyWithTargetInterface(Type interfaceToProxy, object target, ProxyGenerationOptions options, params IInterceptor[] interceptors);

		object CreateInterfaceProxyWithTargetInterface(Type interfaceToProxy, Type[] additionalInterfacesToProxy, object target, ProxyGenerationOptions options, params IInterceptor[] interceptors);

		TInterface CreateInterfaceProxyWithoutTarget<TInterface>(IInterceptor interceptor) where TInterface : class;

		TInterface CreateInterfaceProxyWithoutTarget<TInterface>(params IInterceptor[] interceptors) where TInterface : class;

		TInterface CreateInterfaceProxyWithoutTarget<TInterface>(ProxyGenerationOptions options, params IInterceptor[] interceptors) where TInterface : class;

		object CreateInterfaceProxyWithoutTarget(Type interfaceToProxy, IInterceptor interceptor);

		object CreateInterfaceProxyWithoutTarget(Type interfaceToProxy, params IInterceptor[] interceptors);

		object CreateInterfaceProxyWithoutTarget(Type interfaceToProxy, Type[] additionalInterfacesToProxy, params IInterceptor[] interceptors);

		object CreateInterfaceProxyWithoutTarget(Type interfaceToProxy, ProxyGenerationOptions options, params IInterceptor[] interceptors);

		object CreateInterfaceProxyWithoutTarget(Type interfaceToProxy, Type[] additionalInterfacesToProxy, ProxyGenerationOptions options, params IInterceptor[] interceptors);

		TClass CreateClassProxyWithTarget<TClass>(TClass target, params IInterceptor[] interceptors) where TClass : class;

		TClass CreateClassProxyWithTarget<TClass>(TClass target, ProxyGenerationOptions options, params IInterceptor[] interceptors) where TClass : class;

		object CreateClassProxyWithTarget(Type classToProxy, Type[] additionalInterfacesToProxy, object target, params IInterceptor[] interceptors);

		object CreateClassProxyWithTarget(Type classToProxy, object target, ProxyGenerationOptions options, object[] constructorArguments, params IInterceptor[] interceptors);

		object CreateClassProxyWithTarget(Type classToProxy, object target, object[] constructorArguments, params IInterceptor[] interceptors);

		object CreateClassProxyWithTarget(Type classToProxy, object target, params IInterceptor[] interceptors);

		object CreateClassProxyWithTarget(Type classToProxy, object target, ProxyGenerationOptions options, params IInterceptor[] interceptors);

		object CreateClassProxyWithTarget(Type classToProxy, Type[] additionalInterfacesToProxy, object target, ProxyGenerationOptions options, params IInterceptor[] interceptors);

		object CreateClassProxyWithTarget(Type classToProxy, Type[] additionalInterfacesToProxy, object target, ProxyGenerationOptions options, object[] constructorArguments, params IInterceptor[] interceptors);

		TClass CreateClassProxy<TClass>(params IInterceptor[] interceptors) where TClass : class;

		TClass CreateClassProxy<TClass>(ProxyGenerationOptions options, params IInterceptor[] interceptors) where TClass : class;

		object CreateClassProxy(Type classToProxy, Type[] additionalInterfacesToProxy, params IInterceptor[] interceptors);

		object CreateClassProxy(Type classToProxy, ProxyGenerationOptions options, object[] constructorArguments, params IInterceptor[] interceptors);

		object CreateClassProxy(Type classToProxy, object[] constructorArguments, params IInterceptor[] interceptors);

		object CreateClassProxy(Type classToProxy, params IInterceptor[] interceptors);

		object CreateClassProxy(Type classToProxy, ProxyGenerationOptions options, params IInterceptor[] interceptors);

		object CreateClassProxy(Type classToProxy, Type[] additionalInterfacesToProxy, ProxyGenerationOptions options, params IInterceptor[] interceptors);

		object CreateClassProxy(Type classToProxy, Type[] additionalInterfacesToProxy, ProxyGenerationOptions options, object[] constructorArguments, params IInterceptor[] interceptors);
	}
}
