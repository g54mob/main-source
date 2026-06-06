using System;
using System.Diagnostics;

namespace R3
{
	[DebuggerStepThrough]
	internal sealed class AnonymousRObserver<T> : Observer<T>
	{
		public AnonymousRObserver(Action<T> onNext, Action<Exception> onErrorResume)
		{
			_003ConNext_003EP = onNext;
			_003ConErrorResume_003EP = onErrorResume;
			base._002Ector();
		}

		[DebuggerStepThrough]
		protected override void OnNextCore(T value)
		{
			_003ConNext_003EP(value);
		}

		[DebuggerStepThrough]
		protected override void OnErrorResumeCore(Exception error)
		{
			_003ConErrorResume_003EP(error);
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
