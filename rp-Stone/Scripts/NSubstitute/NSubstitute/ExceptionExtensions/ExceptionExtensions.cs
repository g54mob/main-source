using System;
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
			}, new Func<CallInfo, object>[0]);
		}

		public static ConfiguredCall Throws<TException>(this object value) where TException : notnull, Exception, new()
		{
			return value.Returns<object>(delegate
			{
				throw new TException();
			}, new Func<CallInfo, object>[0]);
		}

		public static ConfiguredCall Throws(this object value, Func<CallInfo, Exception> createException)
		{
			return value.Returns<object>(delegate(CallInfo ci)
			{
				throw createException(ci);
			}, new Func<CallInfo, object>[0]);
		}

		public static ConfiguredCall ThrowsForAnyArgs(this object value, Exception ex)
		{
			return value.ReturnsForAnyArgs<object>(delegate
			{
				throw ex;
			}, new Func<CallInfo, object>[0]);
		}

		public static ConfiguredCall ThrowsForAnyArgs<TException>(this object value) where TException : notnull, Exception, new()
		{
			return value.ReturnsForAnyArgs<object>(delegate
			{
				throw new TException();
			}, new Func<CallInfo, object>[0]);
		}

		public static ConfiguredCall ThrowsForAnyArgs(this object value, Func<CallInfo, Exception> createException)
		{
			return value.ReturnsForAnyArgs<object>(delegate(CallInfo ci)
			{
				throw createException(ci);
			}, new Func<CallInfo, object>[0]);
		}
	}
}
