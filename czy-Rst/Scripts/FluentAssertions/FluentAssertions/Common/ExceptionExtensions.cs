using System;
using System.Reflection;
using System.Runtime.ExceptionServices;

namespace FluentAssertions.Common
{
	internal static class ExceptionExtensions
	{
		public static ExceptionDispatchInfo Unwrap(this TargetInvocationException exception)
		{
			Exception ex = exception;
			while (ex is TargetInvocationException)
			{
				ex = ex.InnerException;
			}
			return ExceptionDispatchInfo.Capture(ex);
		}
	}
}
