using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Castle.Core.Internal;
using Castle.Core.Logging;

namespace Castle.DynamicProxy
{
	[CLSCompliant(true)]
	public class ProxyGenerator : IProxyGenerator
	{
		private ILogger logger = NullLogger.Instance;

		private readonly IProxyBuilder proxyBuilder;

		public ILogger Logger
		{
			get
			{
				return logger;
			}
			set
			{
				logger = value;
				proxyBuilder.Logger = value;
			}
		}

		public IProxyBuilder ProxyBuilder => proxyBuilder;

		public ProxyGenerator(IProxyBuilder builder)
		{
			proxyBuilder = builder;
			Logger = new TraceLogger("Castle.DynamicProxy", LoggerLevel.Warn);
		}

		public ProxyGenerator()
			: this(new DefaultProxyBuilder())
		{
		}

		public ProxyGenerator(bool disableSignedModule)
			: this(new DefaultProxyBuilder(new ModuleScope(savePhysicalAssembly: false, disableSignedModule)))
		{
		}

		public TInterface CreateInterfaceProxyWithTarget<TInterface>(TInterface target, params IInterceptor[] interceptors) where TInterface : class
		{
			return (TInterface)CreateInterfaceProxyWithTarget(typeof(TInterface), target, ProxyGenerationOptions.Default, interceptors);
		}

		public TInterface CreateInterfaceProxyWithTarget<TInterface>(TInterface target, ProxyGenerationOptions options, params IInterceptor[] interceptors) where TInterface : class
		{
			return (TInterface)CreateInterfaceProxyWithTarget(typeof(TInterface), target, options, interceptors);
		}

		public object CreateInterfaceProxyWithTarget(Type interfaceToProxy, object target, params IInterceptor[] interceptors)
		{
			return CreateInterfaceProxyWithTarget(interfaceToProxy, target, ProxyGenerationOptions.Default, interceptors);
		}

		public object CreateInterfaceProxyWithTarget(Type interfaceToProxy, object target, ProxyGenerationOptions options, params IInterceptor[] interceptors)
		{
			return CreateInterfaceProxyWithTarget(interfaceToProxy, null, target, options, interceptors);
		}

		public object CreateInterfaceProxyWithTarget(Type interfaceToProxy, Type[] additionalInterfacesToProxy, object target, params IInterceptor[] interceptors)
		{
			return CreateInterfaceProxyWithTarget(interfaceToProxy, additionalInterfacesToProxy, target, ProxyGenerationOptions.Default, interceptors);
		}

		public virtual object CreateInterfaceProxyWithTarget(Type interfaceToProxy, Type[] additionalInterfacesToProxy, object target, ProxyGenerationOptions options, params IInterceptor[] interceptors)
		{
			if (interfaceToProxy == null)
			{
				throw new ArgumentNullException("interfaceToProxy");
			}
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			if (interceptors == null)
			{
				throw new ArgumentNullException("interceptors");
			}
			if (!interfaceToProxy.IsInterface)
			{
				throw new ArgumentException("Specified type is not an interface", "interfaceToProxy");
			}
			Type type = target.GetType();
			if (!interfaceToProxy.IsAssignableFrom(type))
			{
				throw new ArgumentException("Target does not implement interface " + interfaceToProxy.FullName, "target");
			}
			CheckNotGenericTypeDefinition(interfaceToProxy, "interfaceToProxy");
			CheckNotGenericTypeDefinitions(additionalInterfacesToProxy, "additionalInterfacesToProxy");
			Type type2 = CreateInterfaceProxyTypeWithTarget(interfaceToProxy, additionalInterfacesToProxy, type, options);
			List<object> constructorArguments = GetConstructorArguments(target, interceptors, options);
			return Activator.CreateInstance(type2, constructorArguments.ToArray());
		}

		protected List<object> GetConstructorArguments(object target, IInterceptor[] interceptors, ProxyGenerationOptions options)
		{
			List<object> list = new List<object>(options.MixinData.Mixins) { interceptors, target };
			if (options.Selector != null)
			{
				list.Add(options.Selector);
			}
			return list;
		}

		public object CreateInterfaceProxyWithTargetInterface(Type interfaceToProxy, object target, params IInterceptor[] interceptors)
		{
			return CreateInterfaceProxyWithTargetInterface(interfaceToProxy, target, ProxyGenerationOptions.Default, interceptors);
		}

		public TInterface CreateInterfaceProxyWithTargetInterface<TInterface>(TInterface target, params IInterceptor[] interceptors) where TInterface : class
		{
			return (TInterface)CreateInterfaceProxyWithTargetInterface(typeof(TInterface), target, ProxyGenerationOptions.Default, interceptors);
		}

		public TInterface CreateInterfaceProxyWithTargetInterface<TInterface>(TInterface target, ProxyGenerationOptions options, params IInterceptor[] interceptors) where TInterface : class
		{
			return (TInterface)CreateInterfaceProxyWithTargetInterface(typeof(TInterface), target, options, interceptors);
		}

		public object CreateInterfaceProxyWithTargetInterface(Type interfaceToProxy, Type[] additionalInterfacesToProxy, object target, params IInterceptor[] interceptors)
		{
			return CreateInterfaceProxyWithTargetInterface(interfaceToProxy, additionalInterfacesToProxy, target, ProxyGenerationOptions.Default, interceptors);
		}

		public object CreateInterfaceProxyWithTargetInterface(Type interfaceToProxy, object target, ProxyGenerationOptions options, params IInterceptor[] interceptors)
		{
			return CreateInterfaceProxyWithTargetInterface(interfaceToProxy, null, target, options, interceptors);
		}

		public virtual object CreateInterfaceProxyWithTargetInterface(Type interfaceToProxy, Type[] additionalInterfacesToProxy, object target, ProxyGenerationOptions options, params IInterceptor[] interceptors)
		{
			if (interfaceToProxy == null)
			{
				throw new ArgumentNullException("interfaceToProxy");
			}
			if (target != null && !interfaceToProxy.IsInstanceOfType(target))
			{
				throw new ArgumentException("Target does not implement interface " + interfaceToProxy.FullName, "target");
			}
			if (interceptors == null)
			{
				throw new ArgumentNullException("interceptors");
			}
			if (!interfaceToProxy.IsInterface)
			{
				throw new ArgumentException("Specified type is not an interface", "interfaceToProxy");
			}
			if (target != null && true && Marshal.IsComObject(target))
			{
				Guid iid = interfaceToProxy.GUID;
				if (iid != Guid.Empty)
				{
					IntPtr iUnknownForObject = Marshal.GetIUnknownForObject(target);
					IntPtr ppv = IntPtr.Zero;
					int num = Marshal.QueryInterface(iUnknownForObject, ref iid, out ppv);
					bool flag = ppv == IntPtr.Zero;
					Marshal.Release(iUnknownForObject);
					if (!flag)
					{
						Marshal.Release(ppv);
					}
					if (num == 0 && flag)
					{
						throw new ArgumentException("Target COM object does not implement interface " + interfaceToProxy.FullName, "target");
					}
				}
			}
			CheckNotGenericTypeDefinition(interfaceToProxy, "interfaceToProxy");
			CheckNotGenericTypeDefinitions(additionalInterfacesToProxy, "additionalInterfacesToProxy");
			Type type = CreateInterfaceProxyTypeWithTargetInterface(interfaceToProxy, additionalInterfacesToProxy, options);
			List<object> constructorArguments = GetConstructorArguments(target, interceptors, options);
			return Activator.CreateInstance(type, constructorArguments.ToArray());
		}

		public TInterface CreateInterfaceProxyWithoutTarget<TInterface>(IInterceptor interceptor) where TInterface : class
		{
			return (TInterface)CreateInterfaceProxyWithoutTarget(typeof(TInterface), interceptor);
		}

		public TInterface CreateInterfaceProxyWithoutTarget<TInterface>(params IInterceptor[] interceptors) where TInterface : class
		{
			return (TInterface)CreateInterfaceProxyWithoutTarget(typeof(TInterface), interceptors);
		}

		public TInterface CreateInterfaceProxyWithoutTarget<TInterface>(ProxyGenerationOptions options, params IInterceptor[] interceptors) where TInterface : class
		{
			return (TInterface)CreateInterfaceProxyWithoutTarget(typeof(TInterface), Type.EmptyTypes, options, interceptors);
		}

		public object CreateInterfaceProxyWithoutTarget(Type interfaceToProxy, IInterceptor interceptor)
		{
			return CreateInterfaceProxyWithoutTarget(interfaceToProxy, Type.EmptyTypes, ProxyGenerationOptions.Default, interceptor);
		}

		public object CreateInterfaceProxyWithoutTarget(Type interfaceToProxy, params IInterceptor[] interceptors)
		{
			return CreateInterfaceProxyWithoutTarget(interfaceToProxy, Type.EmptyTypes, ProxyGenerationOptions.Default, interceptors);
		}

		public object CreateInterfaceProxyWithoutTarget(Type interfaceToProxy, Type[] additionalInterfacesToProxy, params IInterceptor[] interceptors)
		{
			return CreateInterfaceProxyWithoutTarget(interfaceToProxy, additionalInterfacesToProxy, ProxyGenerationOptions.Default, interceptors);
		}

		public object CreateInterfaceProxyWithoutTarget(Type interfaceToProxy, ProxyGenerationOptions options, params IInterceptor[] interceptors)
		{
			return CreateInterfaceProxyWithoutTarget(interfaceToProxy, Type.EmptyTypes, options, interceptors);
		}

		public virtual object CreateInterfaceProxyWithoutTarget(Type interfaceToProxy, Type[] additionalInterfacesToProxy, ProxyGenerationOptions options, params IInterceptor[] interceptors)
		{
			if (interfaceToProxy == null)
			{
				throw new ArgumentNullException("interfaceToProxy");
			}
			if (interceptors == null)
			{
				throw new ArgumentNullException("interceptors");
			}
			if (!interfaceToProxy.IsInterface)
			{
				throw new ArgumentException("Specified type is not an interface", "interfaceToProxy");
			}
			CheckNotGenericTypeDefinition(interfaceToProxy, "interfaceToProxy");
			CheckNotGenericTypeDefinitions(additionalInterfacesToProxy, "additionalInterfacesToProxy");
			Type type = CreateInterfaceProxyTypeWithoutTarget(interfaceToProxy, additionalInterfacesToProxy, options);
			List<object> constructorArguments = GetConstructorArguments(null, interceptors, options);
			return Activator.CreateInstance(type, constructorArguments.ToArray());
		}

		public TClass CreateClassProxyWithTarget<TClass>(TClass target, params IInterceptor[] interceptors) where TClass : class
		{
			return (TClass)CreateClassProxyWithTarget(typeof(TClass), Type.EmptyTypes, target, ProxyGenerationOptions.Default, new object[0], interceptors);
		}

		public TClass CreateClassProxyWithTarget<TClass>(TClass target, ProxyGenerationOptions options, params IInterceptor[] interceptors) where TClass : class
		{
			return (TClass)CreateClassProxyWithTarget(typeof(TClass), Type.EmptyTypes, target, options, new object[0], interceptors);
		}

		public object CreateClassProxyWithTarget(Type classToProxy, Type[] additionalInterfacesToProxy, object target, params IInterceptor[] interceptors)
		{
			return CreateClassProxyWithTarget(classToProxy, additionalInterfacesToProxy, target, ProxyGenerationOptions.Default, new object[0], interceptors);
		}

		public object CreateClassProxyWithTarget(Type classToProxy, object target, ProxyGenerationOptions options, object[] constructorArguments, params IInterceptor[] interceptors)
		{
			return CreateClassProxyWithTarget(classToProxy, Type.EmptyTypes, target, options, constructorArguments, interceptors);
		}

		public object CreateClassProxyWithTarget(Type classToProxy, object target, object[] constructorArguments, params IInterceptor[] interceptors)
		{
			return CreateClassProxyWithTarget(classToProxy, Type.EmptyTypes, target, ProxyGenerationOptions.Default, constructorArguments, interceptors);
		}

		public object CreateClassProxyWithTarget(Type classToProxy, object target, params IInterceptor[] interceptors)
		{
			return CreateClassProxyWithTarget(classToProxy, Type.EmptyTypes, target, ProxyGenerationOptions.Default, new object[0], interceptors);
		}

		public object CreateClassProxyWithTarget(Type classToProxy, object target, ProxyGenerationOptions options, params IInterceptor[] interceptors)
		{
			return CreateClassProxyWithTarget(classToProxy, Type.EmptyTypes, target, options, new object[0], interceptors);
		}

		public object CreateClassProxyWithTarget(Type classToProxy, Type[] additionalInterfacesToProxy, object target, ProxyGenerationOptions options, params IInterceptor[] interceptors)
		{
			return CreateClassProxyWithTarget(classToProxy, additionalInterfacesToProxy, target, options, new object[0], interceptors);
		}

		public virtual object CreateClassProxyWithTarget(Type classToProxy, Type[] additionalInterfacesToProxy, object target, ProxyGenerationOptions options, object[] constructorArguments, params IInterceptor[] interceptors)
		{
			if (classToProxy == null)
			{
				throw new ArgumentNullException("classToProxy");
			}
			if (options == null)
			{
				throw new ArgumentNullException("options");
			}
			if (!classToProxy.IsClass)
			{
				throw new ArgumentException("'classToProxy' must be a class", "classToProxy");
			}
			CheckNotGenericTypeDefinition(classToProxy, "classToProxy");
			CheckNotGenericTypeDefinitions(additionalInterfacesToProxy, "additionalInterfacesToProxy");
			Type proxyType = CreateClassProxyTypeWithTarget(classToProxy, additionalInterfacesToProxy, options);
			List<object> list = BuildArgumentListForClassProxyWithTarget(target, options, interceptors);
			if (constructorArguments != null && constructorArguments.Length != 0)
			{
				list.AddRange(constructorArguments);
			}
			return CreateClassProxyInstance(proxyType, list, classToProxy, constructorArguments);
		}

		public TClass CreateClassProxy<TClass>(params IInterceptor[] interceptors) where TClass : class
		{
			return (TClass)CreateClassProxy(typeof(TClass), ProxyGenerationOptions.Default, interceptors);
		}

		public TClass CreateClassProxy<TClass>(ProxyGenerationOptions options, params IInterceptor[] interceptors) where TClass : class
		{
			return (TClass)CreateClassProxy(typeof(TClass), options, interceptors);
		}

		public object CreateClassProxy(Type classToProxy, Type[] additionalInterfacesToProxy, params IInterceptor[] interceptors)
		{
			return CreateClassProxy(classToProxy, additionalInterfacesToProxy, ProxyGenerationOptions.Default, interceptors);
		}

		public object CreateClassProxy(Type classToProxy, ProxyGenerationOptions options, object[] constructorArguments, params IInterceptor[] interceptors)
		{
			return CreateClassProxy(classToProxy, null, options, constructorArguments, interceptors);
		}

		public object CreateClassProxy(Type classToProxy, object[] constructorArguments, params IInterceptor[] interceptors)
		{
			return CreateClassProxy(classToProxy, null, ProxyGenerationOptions.Default, constructorArguments, interceptors);
		}

		public object CreateClassProxy(Type classToProxy, params IInterceptor[] interceptors)
		{
			return CreateClassProxy(classToProxy, null, ProxyGenerationOptions.Default, null, interceptors);
		}

		public object CreateClassProxy(Type classToProxy, ProxyGenerationOptions options, params IInterceptor[] interceptors)
		{
			return CreateClassProxy(classToProxy, null, options, interceptors);
		}

		public object CreateClassProxy(Type classToProxy, Type[] additionalInterfacesToProxy, ProxyGenerationOptions options, params IInterceptor[] interceptors)
		{
			return CreateClassProxy(classToProxy, additionalInterfacesToProxy, options, null, interceptors);
		}

		public virtual object CreateClassProxy(Type classToProxy, Type[] additionalInterfacesToProxy, ProxyGenerationOptions options, object[] constructorArguments, params IInterceptor[] interceptors)
		{
			if (classToProxy == null)
			{
				throw new ArgumentNullException("classToProxy");
			}
			if (options == null)
			{
				throw new ArgumentNullException("options");
			}
			if (!classToProxy.IsClass)
			{
				throw new ArgumentException("'classToProxy' must be a class", "classToProxy");
			}
			CheckNotGenericTypeDefinition(classToProxy, "classToProxy");
			CheckNotGenericTypeDefinitions(additionalInterfacesToProxy, "additionalInterfacesToProxy");
			Type proxyType = CreateClassProxyType(classToProxy, additionalInterfacesToProxy, options);
			List<object> list = BuildArgumentListForClassProxy(options, interceptors);
			if (constructorArguments != null && constructorArguments.Length != 0)
			{
				list.AddRange(constructorArguments);
			}
			return CreateClassProxyInstance(proxyType, list, classToProxy, constructorArguments);
		}

		protected object CreateClassProxyInstance(Type proxyType, List<object> proxyArguments, Type classToProxy, object[] constructorArguments)
		{
			try
			{
				return Activator.CreateInstance(proxyType, proxyArguments.ToArray());
			}
			catch (MissingMethodException innerException)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendFormat("Can not instantiate proxy of class: {0}.", classToProxy.FullName);
				stringBuilder.AppendLine();
				if (constructorArguments == null || constructorArguments.Length == 0)
				{
					stringBuilder.Append("Could not find a parameterless constructor.");
				}
				else
				{
					stringBuilder.AppendLine("Could not find a constructor that would match given arguments:");
					foreach (object obj in constructorArguments)
					{
						string value = ((obj == null) ? "<null>" : obj.GetType().ToString());
						stringBuilder.AppendLine(value);
					}
				}
				throw new ArgumentException(stringBuilder.ToString(), "constructorArguments", innerException);
			}
		}

		protected void CheckNotGenericTypeDefinition(Type type, string argumentName)
		{
			if (type != null && type.IsGenericTypeDefinition)
			{
				throw new ArgumentException("Can not create proxy for type " + type.GetBestName() + " because it is an open generic type.", argumentName);
			}
		}

		protected void CheckNotGenericTypeDefinitions(IEnumerable<Type> types, string argumentName)
		{
			if (types == null)
			{
				return;
			}
			foreach (Type type in types)
			{
				CheckNotGenericTypeDefinition(type, argumentName);
			}
		}

		protected List<object> BuildArgumentListForClassProxyWithTarget(object target, ProxyGenerationOptions options, IInterceptor[] interceptors)
		{
			List<object> list = new List<object>();
			list.Add(target);
			list.AddRange(options.MixinData.Mixins);
			list.Add(interceptors);
			if (options.Selector != null)
			{
				list.Add(options.Selector);
			}
			return list;
		}

		protected List<object> BuildArgumentListForClassProxy(ProxyGenerationOptions options, IInterceptor[] interceptors)
		{
			List<object> list = new List<object>(options.MixinData.Mixins) { interceptors };
			if (options.Selector != null)
			{
				list.Add(options.Selector);
			}
			return list;
		}

		protected Type CreateClassProxyType(Type classToProxy, Type[] additionalInterfacesToProxy, ProxyGenerationOptions options)
		{
			return ProxyBuilder.CreateClassProxyType(classToProxy, additionalInterfacesToProxy, options);
		}

		protected Type CreateInterfaceProxyTypeWithTarget(Type interfaceToProxy, Type[] additionalInterfacesToProxy, Type targetType, ProxyGenerationOptions options)
		{
			return ProxyBuilder.CreateInterfaceProxyTypeWithTarget(interfaceToProxy, additionalInterfacesToProxy, targetType, options);
		}

		protected Type CreateInterfaceProxyTypeWithTargetInterface(Type interfaceToProxy, Type[] additionalInterfacesToProxy, ProxyGenerationOptions options)
		{
			return ProxyBuilder.CreateInterfaceProxyTypeWithTargetInterface(interfaceToProxy, additionalInterfacesToProxy, options);
		}

		protected Type CreateInterfaceProxyTypeWithoutTarget(Type interfaceToProxy, Type[] additionalInterfacesToProxy, ProxyGenerationOptions options)
		{
			return ProxyBuilder.CreateInterfaceProxyTypeWithoutTarget(interfaceToProxy, additionalInterfacesToProxy, options);
		}

		protected Type CreateClassProxyTypeWithTarget(Type classToProxy, Type[] additionalInterfacesToProxy, ProxyGenerationOptions options)
		{
			return ProxyBuilder.CreateClassProxyTypeWithTarget(classToProxy, additionalInterfacesToProxy, options);
		}
	}
}
