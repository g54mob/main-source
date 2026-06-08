using System;
using System.Collections.Generic;
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
			AssertValidType(classToProxy, "classToProxy");
			AssertValidTypes(additionalInterfacesToProxy, "additionalInterfacesToProxy");
			AssertValidMixins(options, "options");
			return new ClassProxyGenerator(scope, classToProxy, additionalInterfacesToProxy, options)
			{
				Logger = logger
			}.GetProxyType();
		}

		public Type CreateClassProxyTypeWithTarget(Type classToProxy, Type[] additionalInterfacesToProxy, ProxyGenerationOptions options)
		{
			AssertValidType(classToProxy, "classToProxy");
			AssertValidTypes(additionalInterfacesToProxy, "additionalInterfacesToProxy");
			AssertValidMixins(options, "options");
			return new ClassProxyWithTargetGenerator(scope, classToProxy, additionalInterfacesToProxy, options)
			{
				Logger = logger
			}.GetProxyType();
		}

		public Type CreateInterfaceProxyTypeWithTarget(Type interfaceToProxy, Type[] additionalInterfacesToProxy, Type targetType, ProxyGenerationOptions options)
		{
			AssertValidType(interfaceToProxy, "interfaceToProxy");
			AssertValidTypes(additionalInterfacesToProxy, "additionalInterfacesToProxy");
			AssertValidMixins(options, "options");
			return new InterfaceProxyWithTargetGenerator(scope, interfaceToProxy, additionalInterfacesToProxy, targetType, options)
			{
				Logger = logger
			}.GetProxyType();
		}

		public Type CreateInterfaceProxyTypeWithTargetInterface(Type interfaceToProxy, Type[] additionalInterfacesToProxy, ProxyGenerationOptions options)
		{
			AssertValidType(interfaceToProxy, "interfaceToProxy");
			AssertValidTypes(additionalInterfacesToProxy, "additionalInterfacesToProxy");
			AssertValidMixins(options, "options");
			return new InterfaceProxyWithTargetInterfaceGenerator(scope, interfaceToProxy, additionalInterfacesToProxy, interfaceToProxy, options)
			{
				Logger = logger
			}.GetProxyType();
		}

		public Type CreateInterfaceProxyTypeWithoutTarget(Type interfaceToProxy, Type[] additionalInterfacesToProxy, ProxyGenerationOptions options)
		{
			AssertValidType(interfaceToProxy, "interfaceToProxy");
			AssertValidTypes(additionalInterfacesToProxy, "additionalInterfacesToProxy");
			AssertValidMixins(options, "options");
			return new InterfaceProxyWithoutTargetGenerator(scope, interfaceToProxy, additionalInterfacesToProxy, typeof(object), options)
			{
				Logger = logger
			}.GetProxyType();
		}

		private void AssertValidMixins(ProxyGenerationOptions options, string paramName)
		{
			try
			{
				options.Initialize();
			}
			catch (InvalidOperationException ex)
			{
				throw new ArgumentException(ex.Message, paramName, ex.InnerException);
			}
		}

		private void AssertValidType(Type target, string paramName)
		{
			AssertValidTypeForTarget(target, target, paramName);
		}

		private void AssertValidTypeForTarget(Type type, Type target, string paramName)
		{
			if (type.IsGenericTypeDefinition)
			{
				throw new ArgumentException("Can not create proxy for type " + target.GetBestName() + " because type " + type.GetBestName() + " is an open generic type.", paramName);
			}
			if (!ProxyUtil.IsAccessibleType(type))
			{
				throw new ArgumentException(ExceptionMessageBuilder.CreateMessageForInaccessibleType(type, target), paramName);
			}
			Type[] genericArguments = type.GetGenericArguments();
			foreach (Type type2 in genericArguments)
			{
				AssertValidTypeForTarget(type2, target, paramName);
			}
		}

		private void AssertValidTypes(IEnumerable<Type> targetTypes, string paramName)
		{
			if (targetTypes == null)
			{
				return;
			}
			foreach (Type targetType in targetTypes)
			{
				AssertValidType(targetType, paramName);
			}
		}
	}
}
