using System;

namespace R3.Internal
{
	internal static class Stubs
	{
		internal static readonly Action<Result> HandleResult = delegate(Result x)
		{
			if (x.IsFailure)
			{
				ObservableSystem.GetUnhandledExceptionHandler()(x.Exception);
			}
		};
	}
	internal static class Stubs<T>
	{
		internal static readonly Func<T, T> ReturnSelf = (T x) => x;

		internal static readonly Action<Exception, T> HandleException = delegate(Exception x, T _)
		{
			ObservableSystem.GetUnhandledExceptionHandler()(x);
		};

		internal static readonly Action<Result, T> HandleResult = delegate(Result x, T _)
		{
			if (x.IsFailure)
			{
				ObservableSystem.GetUnhandledExceptionHandler()(x.Exception);
			}
		};
	}
}
