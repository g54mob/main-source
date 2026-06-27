using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;

namespace Moq.Internals
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract class InterfaceProxy
	{
		private sealed class Invocation : Moq.Invocation
		{
			private static object[] noArguments = new object[0];

			public Invocation(Type proxyType, MethodInfo method, params object[] arguments)
				: base(proxyType, method, arguments)
			{
			}

			public Invocation(Type proxyType, MethodInfo method)
				: base(proxyType, method, noArguments)
			{
			}

			protected internal override object CallBase()
			{
				throw new NotSupportedException();
			}
		}

		private static MethodInfo equalsMethod = typeof(object).GetMethod("Equals", BindingFlags.Instance | BindingFlags.Public);

		private static MethodInfo getHashCodeMethod = typeof(object).GetMethod("GetHashCode", BindingFlags.Instance | BindingFlags.Public);

		private static MethodInfo toStringMethod = typeof(object).GetMethod("ToString", BindingFlags.Instance | BindingFlags.Public);

		[DebuggerHidden]
		public sealed override bool Equals(object obj)
		{
			IInterceptor interceptor = (IInterceptor)((IProxy)this).Interceptor;
			Invocation invocation = new Invocation(GetType(), equalsMethod, obj);
			interceptor.Intercept(invocation);
			return (bool)invocation.ReturnValue;
		}

		[DebuggerHidden]
		public sealed override int GetHashCode()
		{
			IInterceptor interceptor = (IInterceptor)((IProxy)this).Interceptor;
			Invocation invocation = new Invocation(GetType(), getHashCodeMethod);
			interceptor.Intercept(invocation);
			return (int)invocation.ReturnValue;
		}

		[DebuggerHidden]
		public sealed override string ToString()
		{
			IInterceptor interceptor = (IInterceptor)((IProxy)this).Interceptor;
			Invocation invocation = new Invocation(GetType(), toStringMethod);
			interceptor.Intercept(invocation);
			return (string)invocation.ReturnValue;
		}
	}
}
