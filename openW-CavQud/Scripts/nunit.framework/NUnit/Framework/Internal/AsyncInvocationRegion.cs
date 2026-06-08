using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NUnit.Framework.Internal
{
	internal abstract class AsyncInvocationRegion : IDisposable
	{
		private class AsyncTaskInvocationRegion : AsyncInvocationRegion
		{
			private const string TaskWaitMethod = "Wait";

			private const string TaskResultProperty = "Result";

			private const string VoidTaskResultType = "VoidTaskResult";

			private const string SystemAggregateException = "System.AggregateException";

			private const string InnerExceptionsProperty = "InnerExceptions";

			private const BindingFlags TaskResultPropertyBindingFlags = BindingFlags.Instance | BindingFlags.Public;

			public override object WaitForPendingOperationsToComplete(object invocationResult)
			{
				try
				{
					invocationResult.GetType().GetMethod("Wait", new Type[0]).Invoke(invocationResult, null);
				}
				catch (TargetInvocationException ex)
				{
					ExceptionHelper.Rethrow(GetAllExceptions(ex.InnerException)[0]);
				}
				Type[] genericArguments = invocationResult.GetType().GetGenericArguments();
				if (genericArguments != null && genericArguments.Length == 1 && genericArguments[0].Name == "VoidTaskResult")
				{
					return null;
				}
				PropertyInfo property = invocationResult.GetType().GetProperty("Result", BindingFlags.Instance | BindingFlags.Public);
				if (!(property != null))
				{
					return invocationResult;
				}
				return property.GetValue(invocationResult, null);
			}

			private static IList<Exception> GetAllExceptions(Exception exception)
			{
				if ("System.AggregateException".Equals(exception.GetType().FullName))
				{
					return (IList<Exception>)exception.GetType().GetProperty("InnerExceptions").GetValue(exception, null);
				}
				return new Exception[1] { exception };
			}
		}

		private const string TaskTypeName = "System.Threading.Tasks.Task";

		private const string AsyncAttributeTypeName = "System.Runtime.CompilerServices.AsyncStateMachineAttribute";

		private AsyncInvocationRegion()
		{
		}

		public static AsyncInvocationRegion Create(Delegate @delegate)
		{
			return Create(@delegate.Method);
		}

		public static AsyncInvocationRegion Create(MethodInfo method)
		{
			if (!IsAsyncOperation(method))
			{
				throw new ArgumentException("Either asynchronous support is not available or an attempt \r\nat wrapping a non-async method invocation in an async region was done");
			}
			if (method.ReturnType == typeof(void))
			{
				throw new ArgumentException("'async void' methods are not supported, please use 'async Task' instead");
			}
			return new AsyncTaskInvocationRegion();
		}

		public static bool IsAsyncOperation(MethodInfo method)
		{
			string fullName = method.ReturnType.FullName;
			if (fullName == null)
			{
				return false;
			}
			if (!fullName.StartsWith("System.Threading.Tasks.Task"))
			{
				return method.GetCustomAttributes(inherit: false).Any((object attr) => "System.Runtime.CompilerServices.AsyncStateMachineAttribute" == attr.GetType().FullName);
			}
			return true;
		}

		public static bool IsAsyncOperation(Delegate @delegate)
		{
			return IsAsyncOperation(@delegate.Method);
		}

		public abstract object WaitForPendingOperationsToComplete(object invocationResult);

		public virtual void Dispose()
		{
		}
	}
}
