using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting;
using Castle.Core.Internal;
using Castle.DynamicProxy.Generators;
using Castle.DynamicProxy.Internal;

namespace Castle.DynamicProxy
{
	public static class ProxyUtil
	{
		private static readonly SynchronizedDictionary<Assembly, bool> internalsVisibleToDynamicProxy = new SynchronizedDictionary<Assembly, bool>();

		public static TDelegate CreateDelegateToMixin<TDelegate>(object proxy)
		{
			return (TDelegate)(object)CreateDelegateToMixin(proxy, typeof(TDelegate));
		}

		public static Delegate CreateDelegateToMixin(object proxy, Type delegateType)
		{
			if (proxy == null)
			{
				throw new ArgumentNullException("proxy");
			}
			if (delegateType == null)
			{
				throw new ArgumentNullException("delegateType");
			}
			if (!delegateType.IsDelegateType())
			{
				throw new ArgumentException("Type is not a delegate type.", "delegateType");
			}
			MethodInfo invokeMethod = delegateType.GetMethod("Invoke");
			MethodInfo methodInfo = proxy.GetType().GetMember("Invoke", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Cast<MethodInfo>()
				.FirstOrDefault((MethodInfo m) => MethodSignatureComparer.Instance.EqualParameters(m, invokeMethod));
			if (methodInfo == null)
			{
				throw new MissingMethodException("The proxy does not have an Invoke method that is compatible with the requested delegate type.");
			}
			return Delegate.CreateDelegate(delegateType, proxy, methodInfo);
		}

		public static object GetUnproxiedInstance(object instance)
		{
			if (!RemotingServices.IsTransparentProxy(instance) && instance is IProxyTargetAccessor proxyTargetAccessor)
			{
				instance = proxyTargetAccessor.DynProxyGetTarget();
			}
			return instance;
		}

		public static Type GetUnproxiedType(object instance)
		{
			if (!RemotingServices.IsTransparentProxy(instance) && instance is IProxyTargetAccessor proxyTargetAccessor)
			{
				object obj = proxyTargetAccessor.DynProxyGetTarget();
				if (obj != null)
				{
					if (obj == instance)
					{
						return instance.GetType().GetTypeInfo().BaseType;
					}
					instance = obj;
				}
			}
			return instance.GetType();
		}

		public static bool IsProxy(object instance)
		{
			if (RemotingServices.IsTransparentProxy(instance))
			{
				return true;
			}
			return instance is IProxyTargetAccessor;
		}

		public static bool IsProxyType(Type type)
		{
			return typeof(IProxyTargetAccessor).IsAssignableFrom(type);
		}

		public static bool IsAccessible(MethodBase method)
		{
			if (IsAccessibleMethod(method))
			{
				return IsAccessibleType(method.DeclaringType);
			}
			return false;
		}

		public static bool IsAccessible(MethodBase method, out string message)
		{
			if (IsAccessible(method))
			{
				message = null;
				return true;
			}
			message = CreateMessageForInaccessibleMethod(method);
			return false;
		}

		public static bool IsAccessible(Type type)
		{
			return IsAccessibleType(type);
		}

		internal static bool AreInternalsVisibleToDynamicProxy(Assembly asm)
		{
			return internalsVisibleToDynamicProxy.GetOrAdd(asm, (Assembly a) => asm.GetCustomAttributes<InternalsVisibleToAttribute>().Any((InternalsVisibleToAttribute attr) => attr.AssemblyName.Contains(ModuleScope.DEFAULT_ASSEMBLY_NAME)));
		}

		internal static bool IsAccessibleType(Type target)
		{
			TypeInfo typeInfo = target.GetTypeInfo();
			if (typeInfo.IsPublic || typeInfo.IsNestedPublic)
			{
				return true;
			}
			bool isNested = target.IsNested;
			bool flag = isNested && (typeInfo.IsNestedAssembly || typeInfo.IsNestedFamORAssem);
			if (((!typeInfo.IsVisible && !isNested) || flag) && AreInternalsVisibleToDynamicProxy(typeInfo.Assembly))
			{
				return true;
			}
			return false;
		}

		internal static bool IsAccessibleMethod(MethodBase method)
		{
			if (method.IsPublic || method.IsFamily || method.IsFamilyOrAssembly)
			{
				return true;
			}
			if (method.IsAssembly || method.IsFamilyAndAssembly)
			{
				return AreInternalsVisibleToDynamicProxy(method.DeclaringType.GetTypeInfo().Assembly);
			}
			return false;
		}

		internal static bool IsInternal(MethodBase method)
		{
			if (!method.IsAssembly)
			{
				if (method.IsFamilyAndAssembly)
				{
					return !method.IsFamilyOrAssembly;
				}
				return false;
			}
			return true;
		}

		private static string CreateMessageForInaccessibleMethod(MethodBase inaccessibleMethod)
		{
			Assembly assembly = inaccessibleMethod.DeclaringType.GetTypeInfo().Assembly;
			string text = $"Can not create proxy for method {inaccessibleMethod} because it or its declaring type is not accessible. ";
			string text2 = ExceptionMessageBuilder.CreateInstructionsToMakeVisible(assembly);
			return text + text2;
		}
	}
}
