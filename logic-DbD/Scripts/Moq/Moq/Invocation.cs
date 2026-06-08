using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Moq.Async;

namespace Moq
{
	internal abstract class Invocation : IInvocation
	{
		private readonly struct ExceptionResult
		{
			public Exception Exception { get; }

			public ExceptionResult(Exception exception)
			{
				Exception = exception;
			}
		}

		private object[] arguments;

		private MethodInfo method;

		private MethodInfo methodImplementation;

		private readonly Type proxyType;

		private object result;

		private Setup matchingSetup;

		private bool verified;

		public MethodInfo Method => method;

		public MethodInfo MethodImplementation
		{
			get
			{
				if (methodImplementation == null)
				{
					methodImplementation = method.GetImplementingMethod(proxyType);
				}
				return methodImplementation;
			}
		}

		public object[] Arguments => arguments;

		IReadOnlyList<object> IInvocation.Arguments => arguments;

		public ISetup MatchingSetup => matchingSetup;

		public Type ProxyType => proxyType;

		public object ReturnValue
		{
			get
			{
				if (!(result is ExceptionResult))
				{
					return result;
				}
				return null;
			}
			set
			{
				result = value;
			}
		}

		public Exception Exception
		{
			get
			{
				if (!(result is ExceptionResult exceptionResult))
				{
					return null;
				}
				return exceptionResult.Exception;
			}
			set
			{
				result = new ExceptionResult(value);
			}
		}

		public bool IsVerified => verified;

		protected Invocation(Type proxyType, MethodInfo method, params object[] arguments)
		{
			this.arguments = arguments;
			this.method = method;
			this.proxyType = proxyType;
		}

		public void ConvertResultToAwaitable(IAwaitableFactory awaitableFactory)
		{
			if (result is ExceptionResult exceptionResult)
			{
				result = awaitableFactory.CreateFaulted(exceptionResult.Exception);
			}
			else if (!method.ReturnType.IsAssignableFrom(result?.GetType()))
			{
				result = awaitableFactory.CreateCompleted(result);
			}
		}

		protected internal abstract object CallBase();

		internal void MarkAsMatchedBy(Setup setup)
		{
			matchingSetup = setup;
		}

		internal void MarkAsVerified()
		{
			verified = true;
		}

		internal void MarkAsVerifiedIfMatchedBy(Func<Setup, bool> predicate)
		{
			if (matchingSetup != null && predicate(matchingSetup))
			{
				verified = true;
			}
		}

		public override string ToString()
		{
			MethodInfo methodInfo = Method;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendNameOf(methodInfo.DeclaringType);
			stringBuilder.Append('.');
			if (methodInfo.IsGetAccessor())
			{
				stringBuilder.Append(methodInfo.Name, 4, methodInfo.Name.Length - 4);
			}
			else if (methodInfo.IsSetAccessor())
			{
				stringBuilder.Append(methodInfo.Name, 4, methodInfo.Name.Length - 4);
				stringBuilder.Append(" = ");
				stringBuilder.AppendValueOf(Arguments[0]);
			}
			else
			{
				stringBuilder.AppendNameOf(methodInfo, includeGenericArgumentList: true);
				stringBuilder.Append('(');
				int i = 0;
				for (int num = Arguments.Length; i < num; i++)
				{
					if (i > 0)
					{
						stringBuilder.Append(", ");
					}
					stringBuilder.AppendValueOf(Arguments[i]);
				}
				stringBuilder.Append(')');
			}
			return stringBuilder.ToString();
		}
	}
}
