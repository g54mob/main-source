using System;
using System.Linq;
using System.Reflection;
using Castle.DynamicProxy;
using NSubstitute.Core;
using NSubstitute.Exceptions;

namespace NSubstitute.Proxies.CastleDynamicProxy
{
	public class CastleDynamicProxyFactory : IProxyFactory
	{
		private class AllMethodsExceptCallRouterCallsHook : AllMethodsHook
		{
			public override bool ShouldInterceptMethod(Type type, MethodInfo methodInfo)
			{
				if (ProxyIdInterceptor.IsDefaultToStringMethod(methodInfo))
				{
					return true;
				}
				if (IsNotCallRouterProviderMethod(methodInfo) && IsNotBaseObjectMethod(methodInfo))
				{
					return base.ShouldInterceptMethod(type, methodInfo);
				}
				return false;
			}

			private static bool IsNotCallRouterProviderMethod(MethodInfo methodInfo)
			{
				return methodInfo.DeclaringType != typeof(ICallRouterProvider);
			}

			private static bool IsNotBaseObjectMethod(MethodInfo methodInfo)
			{
				return methodInfo.GetBaseDefinition().DeclaringType != typeof(object);
			}
		}

		private class StaticCallRouterProvider : ICallRouterProvider
		{
			private readonly ICallRouter _callRouter;

			public StaticCallRouterProvider(ICallRouter callRouter)
			{
				_callRouter = callRouter;
			}

			public ICallRouter GetCallRouter()
			{
				return _callRouter;
			}
		}

		private readonly ICallFactory _callFactory;

		private readonly IArgumentSpecificationDequeue _argSpecificationDequeue;

		private readonly ProxyGenerator _proxyGenerator;

		private readonly AllMethodsExceptCallRouterCallsHook _allMethodsExceptCallRouterCallsHook;

		public CastleDynamicProxyFactory(ICallFactory callFactory, IArgumentSpecificationDequeue argSpecificationDequeue)
		{
			_callFactory = callFactory;
			_argSpecificationDequeue = argSpecificationDequeue;
			_proxyGenerator = new ProxyGenerator();
			_allMethodsExceptCallRouterCallsHook = new AllMethodsExceptCallRouterCallsHook();
		}

		public object GenerateProxy(ICallRouter callRouter, Type typeToProxy, Type[]? additionalInterfaces, object?[]? constructorArguments)
		{
			if (!typeToProxy.IsDelegate())
			{
				return GenerateTypeProxy(callRouter, typeToProxy, additionalInterfaces, constructorArguments);
			}
			return GenerateDelegateProxy(callRouter, typeToProxy, additionalInterfaces, constructorArguments);
		}

		private object GenerateTypeProxy(ICallRouter callRouter, Type typeToProxy, Type[]? additionalInterfaces, object?[]? constructorArguments)
		{
			VerifyClassHasNotBeenPassedAsAnAdditionalInterface(additionalInterfaces);
			ProxyIdInterceptor proxyIdInterceptor = new ProxyIdInterceptor(typeToProxy);
			CastleForwardingInterceptor castleForwardingInterceptor = CreateForwardingInterceptor(callRouter);
			ProxyGenerationOptions optionsToMixinCallRouterProvider = GetOptionsToMixinCallRouterProvider(callRouter);
			object result = CreateProxyUsingCastleProxyGenerator(typeToProxy, additionalInterfaces, constructorArguments, new IInterceptor[2] { proxyIdInterceptor, castleForwardingInterceptor }, optionsToMixinCallRouterProvider);
			castleForwardingInterceptor.SwitchToFullDispatchMode();
			return result;
		}

		private object GenerateDelegateProxy(ICallRouter callRouter, Type delegateType, Type[]? additionalInterfaces, object?[]? constructorArguments)
		{
			VerifyNoAdditionalInterfacesGivenForDelegate(additionalInterfaces);
			VerifyNoConstructorArgumentsGivenForDelegate(constructorArguments);
			CastleForwardingInterceptor castleForwardingInterceptor = CreateForwardingInterceptor(callRouter);
			ProxyIdInterceptor proxyIdInterceptor = new ProxyIdInterceptor(delegateType);
			ProxyGenerationOptions optionsToMixinCallRouterProvider = GetOptionsToMixinCallRouterProvider(callRouter);
			optionsToMixinCallRouterProvider.AddDelegateTypeMixin(delegateType);
			object obj = CreateProxyUsingCastleProxyGenerator(typeof(object), null, null, new IInterceptor[2] { proxyIdInterceptor, castleForwardingInterceptor }, optionsToMixinCallRouterProvider);
			castleForwardingInterceptor.SwitchToFullDispatchMode();
			return obj.GetType().GetInvokeMethod().CreateDelegate(delegateType, obj);
		}

		private CastleForwardingInterceptor CreateForwardingInterceptor(ICallRouter callRouter)
		{
			return new CastleForwardingInterceptor(new CastleInvocationMapper(_callFactory, _argSpecificationDequeue), callRouter);
		}

		private object CreateProxyUsingCastleProxyGenerator(Type typeToProxy, Type[]? additionalInterfaces, object?[]? constructorArguments, IInterceptor[] interceptors, ProxyGenerationOptions proxyGenerationOptions)
		{
			if (typeToProxy.GetTypeInfo().IsInterface)
			{
				VerifyNoConstructorArgumentsGivenForInterface(constructorArguments);
				Type[] array = new Type[(additionalInterfaces == null) ? 1 : (additionalInterfaces.Length + 1)];
				array[0] = typeToProxy;
				if (additionalInterfaces != null)
				{
					Array.Copy(additionalInterfaces, 0, array, 1, additionalInterfaces.Length);
				}
				typeToProxy = typeof(object);
				additionalInterfaces = array;
			}
			return _proxyGenerator.CreateClassProxy(typeToProxy, additionalInterfaces, proxyGenerationOptions, constructorArguments, interceptors);
		}

		private ProxyGenerationOptions GetOptionsToMixinCallRouterProvider(ICallRouter callRouter)
		{
			ProxyGenerationOptions proxyGenerationOptions = new ProxyGenerationOptions(_allMethodsExceptCallRouterCallsHook);
			proxyGenerationOptions.AddMixinInstance(new StaticCallRouterProvider(callRouter));
			return proxyGenerationOptions;
		}

		private static void VerifyNoConstructorArgumentsGivenForInterface(object?[]? constructorArguments)
		{
			if (HasItems(constructorArguments))
			{
				throw new SubstituteException("Can not provide constructor arguments when substituting for an interface.");
			}
		}

		private static void VerifyNoConstructorArgumentsGivenForDelegate(object?[]? constructorArguments)
		{
			if (HasItems(constructorArguments))
			{
				throw new SubstituteException("Can not provide constructor arguments when substituting for a delegate.");
			}
		}

		private static void VerifyNoAdditionalInterfacesGivenForDelegate(Type[]? constructorArguments)
		{
			if (HasItems(constructorArguments))
			{
				throw new SubstituteException("Can not specify additional interfaces when substituting for a delegate. You must specify only a single delegate type if you need to substitute for a delegate.");
			}
		}

		private static void VerifyClassHasNotBeenPassedAsAnAdditionalInterface(Type[]? additionalInterfaces)
		{
			if (additionalInterfaces != null && additionalInterfaces.Any((Type x) => x.GetTypeInfo().IsClass))
			{
				throw new SubstituteException("Can not substitute for multiple classes. To substitute for multiple types only one type can be a concrete class; other types can only be interfaces.");
			}
		}

		private static bool HasItems<T>(T[]? array)
		{
			if (array == null)
			{
				return true;
			}
			return array.Length != 0;
		}
	}
}
