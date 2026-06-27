using System;
using System.Reflection;
using Castle.DynamicProxy;
using Moq.Internals;
using Moq.Properties;

namespace Moq
{
	internal sealed class CastleProxyFactory : ProxyFactory
	{
		private sealed class Interceptor : Castle.DynamicProxy.IInterceptor
		{
			private static readonly MethodInfo proxyInterceptorGetter = typeof(IProxy).GetProperty("Interceptor").GetMethod;

			private IInterceptor interceptor;

			internal Interceptor(IInterceptor interceptor)
			{
				this.interceptor = interceptor;
			}

			public void Intercept(Castle.DynamicProxy.IInvocation underlying)
			{
				if (underlying.Method == proxyInterceptorGetter)
				{
					underlying.ReturnValue = interceptor;
					return;
				}
				Invocation invocation = new Invocation(underlying);
				try
				{
					interceptor.Intercept(invocation);
					underlying.ReturnValue = invocation.ReturnValue;
				}
				catch (Exception exception)
				{
					invocation.Exception = exception;
					throw;
				}
				finally
				{
					invocation.DetachFromUnderlying();
				}
			}
		}

		private sealed class Invocation : Moq.Invocation
		{
			private Castle.DynamicProxy.IInvocation underlying;

			internal Invocation(Castle.DynamicProxy.IInvocation underlying)
				: base(underlying.Proxy.GetType(), underlying.Method, underlying.Arguments)
			{
				this.underlying = underlying;
			}

			protected internal override object CallBase()
			{
				underlying.Proceed();
				return underlying.ReturnValue;
			}

			public void DetachFromUnderlying()
			{
				underlying = null;
			}
		}

		private sealed class IncludeObjectMethodsHook : AllMethodsHook
		{
			public override bool ShouldInterceptMethod(Type type, MethodInfo method)
			{
				if (!base.ShouldInterceptMethod(type, method))
				{
					return IsRelevantObjectMethod(method);
				}
				return true;
			}

			private static bool IsRelevantObjectMethod(MethodInfo method)
			{
				if (method.DeclaringType == typeof(object))
				{
					if (!(method.Name == "ToString") && !(method.Name == "Equals"))
					{
						return method.Name == "GetHashCode";
					}
					return true;
				}
				return false;
			}
		}

		private ProxyGenerationOptions generationOptions;

		private ProxyGenerator generator;

		public CastleProxyFactory()
		{
			generationOptions = new ProxyGenerationOptions
			{
				Hook = new IncludeObjectMethodsHook(),
				BaseTypeForInterfaceProxy = typeof(InterfaceProxy)
			};
			generator = new ProxyGenerator();
		}

		public override object CreateProxy(Type mockType, IInterceptor interceptor, Type[] interfaces, object[] arguments)
		{
			Type[] array = new Type[1 + interfaces.Length];
			array[0] = typeof(IProxy);
			Array.Copy(interfaces, 0, array, 1, interfaces.Length);
			if (mockType.IsInterface)
			{
				return generator.CreateInterfaceProxyWithoutTarget(mockType, array, generationOptions, new Interceptor(interceptor));
			}
			if (mockType.IsDelegateType())
			{
				ProxyGenerationOptions proxyGenerationOptions = new ProxyGenerationOptions();
				proxyGenerationOptions.AddDelegateTypeMixin(mockType);
				object obj = generator.CreateClassProxy(typeof(object), array, proxyGenerationOptions, new Interceptor(interceptor));
				return Delegate.CreateDelegate(mockType, obj, obj.GetType().GetMethod("Invoke"));
			}
			try
			{
				return generator.CreateClassProxy(mockType, array, generationOptions, arguments, new Interceptor(interceptor));
			}
			catch (TypeLoadException innerException)
			{
				throw new ArgumentException(string.Format(Resources.TypeNotMockable, mockType), innerException);
			}
			catch (MissingMethodException innerException2)
			{
				throw new ArgumentException(Resources.ConstructorNotFound, innerException2);
			}
		}

		public override bool IsMethodVisible(MethodInfo method, out string messageIfNotVisible)
		{
			return ProxyUtil.IsAccessible(method, out messageIfNotVisible);
		}

		public override bool IsTypeVisible(Type type)
		{
			return ProxyUtil.IsAccessible(type);
		}
	}
}
