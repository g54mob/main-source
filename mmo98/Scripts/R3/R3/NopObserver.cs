using System;
using System.Diagnostics;

namespace R3
{
	[DebuggerStepThrough]
	internal sealed class NopObserver<T> : Observer<T>
	{
		[DebuggerStepThrough]
		protected override void OnNextCore(T value)
		{
		}

		[DebuggerStepThrough]
		protected override void OnErrorResumeCore(Exception error)
		{
			ObservableSystem.GetUnhandledExceptionHandler()(error);
		}

		[DebuggerStepThrough]
		protected override void OnCompletedCore(Result result)
		{
			if (result.IsFailure)
			{
				ObservableSystem.GetUnhandledExceptionHandler()(result.Exception);
			}
		}
	}
}
