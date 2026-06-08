using System;
using System.Reflection;

namespace Castle.DynamicProxy
{
	public abstract class AbstractInvocation : IInvocation
	{
		private sealed class ProceedInfo : IInvocationProceedInfo
		{
			private readonly AbstractInvocation invocation;

			private readonly int interceptorIndex;

			public ProceedInfo(AbstractInvocation invocation)
			{
				this.invocation = invocation;
				interceptorIndex = invocation.currentInterceptorIndex;
			}

			public void Invoke()
			{
				int currentInterceptorIndex = invocation.currentInterceptorIndex;
				try
				{
					invocation.currentInterceptorIndex = interceptorIndex;
					invocation.Proceed();
				}
				finally
				{
					invocation.currentInterceptorIndex = currentInterceptorIndex;
				}
			}
		}

		private readonly IInterceptor[] interceptors;

		private readonly object[] arguments;

		private int currentInterceptorIndex = -1;

		private Type[] genericMethodArguments;

		private readonly MethodInfo proxiedMethod;

		protected readonly object proxyObject;

		public abstract object InvocationTarget { get; }

		public abstract Type TargetType { get; }

		public abstract MethodInfo MethodInvocationTarget { get; }

		public Type[] GenericArguments => genericMethodArguments;

		public object Proxy => proxyObject;

		public MethodInfo Method => proxiedMethod;

		public object ReturnValue { get; set; }

		public object[] Arguments => arguments;

		protected AbstractInvocation(object proxy, IInterceptor[] interceptors, MethodInfo proxiedMethod, object[] arguments)
		{
			proxyObject = proxy;
			this.interceptors = interceptors;
			this.proxiedMethod = proxiedMethod;
			this.arguments = arguments;
		}

		public void SetGenericMethodArguments(Type[] arguments)
		{
			genericMethodArguments = arguments;
		}

		public MethodInfo GetConcreteMethod()
		{
			return EnsureClosedMethod(Method);
		}

		public MethodInfo GetConcreteMethodInvocationTarget()
		{
			return MethodInvocationTarget;
		}

		public void SetArgumentValue(int index, object value)
		{
			arguments[index] = value;
		}

		public object GetArgumentValue(int index)
		{
			return arguments[index];
		}

		public void Proceed()
		{
			if (interceptors == null)
			{
				InvokeMethodOnTarget();
				return;
			}
			currentInterceptorIndex++;
			try
			{
				if (currentInterceptorIndex == interceptors.Length)
				{
					InvokeMethodOnTarget();
					return;
				}
				if (currentInterceptorIndex > interceptors.Length)
				{
					throw new InvalidOperationException("Cannot proceed past the end of the interception pipeline. This likely signifies a bug in the calling code.");
				}
				interceptors[currentInterceptorIndex].Intercept(this);
			}
			finally
			{
				currentInterceptorIndex--;
			}
		}

		public IInvocationProceedInfo CaptureProceedInfo()
		{
			return new ProceedInfo(this);
		}

		protected abstract void InvokeMethodOnTarget();

		protected void ThrowOnNoTarget()
		{
			string text = ((interceptors.Length != 0) ? "The interceptor attempted to 'Proceed'" : "There are no interceptors specified");
			string text2;
			string text3;
			if (Method.DeclaringType.IsClass && Method.IsAbstract)
			{
				text2 = "is abstract";
				text3 = "an abstract method";
			}
			else
			{
				text2 = "has no target";
				text3 = "method without target";
			}
			throw new NotImplementedException($"This is a DynamicProxy2 error: {text} for method '{Method}' which {text2}. When calling {text3} there is no implementation to 'proceed' to and it is the responsibility of the interceptor to mimic the implementation (set return value, out arguments etc)");
		}

		private MethodInfo EnsureClosedMethod(MethodInfo method)
		{
			if (method.ContainsGenericParameters)
			{
				return method.GetGenericMethodDefinition().MakeGenericMethod(genericMethodArguments);
			}
			return method;
		}
	}
}
