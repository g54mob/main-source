using System;
using System.Collections.Generic;
using System.Reflection;
using Castle.Core.Internal;
using Castle.Core.Logging;
using Castle.DynamicProxy.Generators;

namespace Castle.DynamicProxy
{
	public class DefaultProxyBuilder : IProxyBuilder
	{
		private readonly ModuleScope scope;

		private ILogger logger = NullLogger.Instance;

		public ILogger Logger
		{
			get
			{
				return logger;
			}
			set
			{
				logger = value;
			}
		}

		public ModuleScope ModuleScope => scope;

		public DefaultProxyBuilder()
			: this(new ModuleScope())
		{
		}

		public DefaultProxyBuilder(ModuleScope scope)
		{
			this.scope = scope;
		}

		public Type CreateClassProxyType(Type classToProxy, Type[] additionalInterfacesToProxy, ProxyGenerationOptions options)
		{
			AssertValidType(classToProxy);
			AssertValidTypes(additionalInterfacesToProxy);
			return new ClassProxyGenerator(scope, classToProxy)
			{
				Logger = logger
			}.GenerateCode(additionalInterfacesToProxy, options);
		}

		public Type CreateClassProxyTypeWithTarget(Type classToProxy, Type[] additionalInterfacesToProxy, ProxyGenerationOptions options)
		{
			AssertValidType(classToProxy);
			AssertValidTypes(additionalInterfacesToProxy);
			return new ClassProxyWithTargetGenerator(scope, classToProxy, additionalInterfacesToProxy, options)
			{
				Logger = logger
			}.GetGeneratedType();
		}

		public Type CreateInterfaceProxyTypeWithTarget(Type interfaceToProxy, Type[] additionalInterfacesToProxy, Type targetType, ProxyGenerationOptions options)
		{
			AssertValidType(interfaceToProxy);
			AssertValidTypes(additionalInterfacesToProxy);
			return new InterfaceProxyWithTargetGenerator(scope, interfaceToProxy)
			{
				Logger = logger
			}.GenerateCode(targetType, additionalInterfacesToProxy, options);
		}

		public Type CreateInterfaceProxyTypeWithTargetInterface(Type interfaceToProxy, Type[] additionalInterfacesToProxy, ProxyGenerationOptions options)
		{
			AssertValidType(interfaceToProxy);
			AssertValidTypes(additionalInterfacesToProxy);
			return new InterfaceProxyWithTargetInterfaceGenerator(scope, interfaceToProxy)
			{
				Logger = logger
			}.GenerateCode(interfaceToProxy, additionalInterfacesToProxy, options);
		}

		public Type CreateInterfaceProxyTypeWithoutTarget(Type interfaceToProxy, Type[] additionalInterfacesToProxy, ProxyGenerationOptions options)
		{
			AssertValidType(interfaceToProxy);
			AssertValidTypes(additionalInterfacesToProxy);
			return new InterfaceProxyWithoutTargetGenerator(scope, interfaceToProxy)
			{
				Logger = logger
			}.GenerateCode(typeof(object), additionalInterfacesToProxy, options);
		}

		private void AssertValidType(Type target)
		{
			AssertValidTypeForTarget(target, target);
		}

		private void AssertValidTypeForTarget(Type type, Type target)
		{
			if (type.GetTypeInfo().IsGenericTypeDefinition)
			{
				throw new GeneratorException($"Can not create proxy for type {target.GetBestName()} because type {type.GetBestName()} is an open generic type.");
			}
			if (!ProxyUtil.IsAccessibleType(type))
			{
				throw new GeneratorException(ExceptionMessageBuilder.CreateMessageForInaccessibleType(type, target));
			}
			Type[] genericArguments = type.GetGenericArguments();
			foreach (Type type2 in genericArguments)
			{
				AssertValidTypeForTarget(type2, target);
			}
		}

		private void AssertValidTypes(IEnumerable<Type> targetTypes)
		{
			if (targetTypes == null)
			{
				return;
			}
			foreach (Type targetType in targetTypes)
			{
				AssertValidType(targetType);
			}
		}
	}
}
