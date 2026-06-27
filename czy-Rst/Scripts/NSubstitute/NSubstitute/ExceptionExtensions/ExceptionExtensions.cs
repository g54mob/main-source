using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using NSubstitute.Core;

namespace NSubstitute.ExceptionExtensions
{
	public static class ExceptionExtensions
	{
		public static ConfiguredCall Throws(this object value, Exception ex)
		{
			return value.Returns<object>(delegate
			{
				throw ex;
			}, Array.Empty<Func<CallInfo, object>>());
		}

		public static ConfiguredCall Throws<TException>(this object value) where TException : notnull, Exception, new()
		{
			return value.Returns<object>(delegate
			{
				throw new TException();
			}, Array.Empty<Func<CallInfo, object>>());
		}

		public static ConfiguredCall Throws(this object value, Func<CallInfo, Exception> createException)
		{
			return value.Returns<object>(delegate(CallInfo ci)
			{
				throw createException(ci);
			}, Array.Empty<Func<CallInfo, object>>());
		}

		public static ConfiguredCall ThrowsForAnyArgs(this object value, Exception ex)
		{
			return value.ReturnsForAnyArgs<object>(delegate
			{
				throw ex;
			}, Array.Empty<Func<CallInfo, object>>());
		}

		public static ConfiguredCall ThrowsForAnyArgs<TException>(this object value) where TException : notnull, Exception, new()
		{
			return value.ReturnsForAnyArgs<object>(delegate
			{
				throw new TException();
			}, Array.Empty<Func<CallInfo, object>>());
		}

		public static ConfiguredCall ThrowsForAnyArgs(this object value, Func<CallInfo, Exception> createException)
		{
			return value.ReturnsForAnyArgs<object>(delegate(CallInfo ci)
			{
				throw createException(ci);
			}, Array.Empty<Func<CallInfo, object>>());
		}

		public static ConfiguredCall ThrowsAsync(this Task value, Exception ex)
		{
			return value.Returns((CallInfo _) => Task.FromException(ex));
		}

		public static ConfiguredCall ThrowsAsync<T>(this Task<T> value, Exception ex)
		{
			return value.Returns((CallInfo _) => Task.FromException<T>(ex));
		}

		public static ConfiguredCall ThrowsAsync<TException>(this Task value) where TException : notnull, Exception, new()
		{
			return value.Returns((CallInfo _) => FromException(value, new TException()));
		}

		public static ConfiguredCall ThrowsAsync(this Task value, Func<CallInfo, Exception> createException)
		{
			return value.Returns((CallInfo ci) => Task.FromException(createException(ci)));
		}

		public static ConfiguredCall ThrowsAsync<T>(this Task<T> value, Func<CallInfo, Exception> createException)
		{
			return value.Returns((CallInfo ci) => Task.FromException<T>(createException(ci)));
		}

		public static ConfiguredCall ThrowsAsyncForAnyArgs(this Task value, Exception ex)
		{
			return value.ReturnsForAnyArgs((CallInfo _) => Task.FromException(ex));
		}

		public static ConfiguredCall ThrowsAsyncForAnyArgs<T>(this Task<T> value, Exception ex)
		{
			return value.ReturnsForAnyArgs((CallInfo _) => Task.FromException<T>(ex));
		}

		public static ConfiguredCall ThrowsAsyncForAnyArgs<TException>(this Task value) where TException : notnull, Exception, new()
		{
			return value.ReturnsForAnyArgs((CallInfo _) => FromException(value, new TException()));
		}

		public static ConfiguredCall ThrowsAsyncForAnyArgs(this Task value, Func<CallInfo, Exception> createException)
		{
			return value.ReturnsForAnyArgs((CallInfo ci) => Task.FromException(createException(ci)));
		}

		public static ConfiguredCall ThrowsAsyncForAnyArgs<T>(this Task<T> value, Func<CallInfo, Exception> createException)
		{
			return value.ReturnsForAnyArgs((CallInfo ci) => Task.FromException<T>(createException(ci)));
		}

		private static object FromException(object value, Exception exception)
		{
			Type type = value.GetType();
			if (type.IsConstructedGenericType)
			{
				return typeof(Task).GetMethods(BindingFlags.Static | BindingFlags.Public).Single((MethodInfo m) => m.Name == "FromException" && m.ContainsGenericParameters).MakeGenericMethod(type.GenericTypeArguments)
					.Invoke(null, new object[1] { exception });
			}
			return Task.FromException(exception);
		}
	}
}
