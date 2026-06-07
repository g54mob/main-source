using System;
using System.Diagnostics;

namespace R3
{
	[DebuggerStepThrough]
	internal sealed class AnonymousObserver<T> : Observer<T>
	{
		public AnonymousObserver(Action<T> onNext, Action<Exception> onErrorResume, Action<Result> onCompleted)
		{
			_003ConNext_003EP = onNext;
			_003ConErrorResume_003EP = onErrorResume;
			_003ConCompleted_003EP = onCompleted;
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
		protected override void OnCompletedCore(Result complete)
		{
			_003ConCompleted_003EP(complete);
		}
	}
	[DebuggerStepThrough]
	internal sealed class AnonymousObserver<T, TState> : Observer<T>
	{
		public AnonymousObserver(Action<T, TState> onNext, Action<Exception, TState> onErrorResume, Action<Result, TState> onCompleted, TState state)
		{
			_003ConNext_003EP = onNext;
			_003ConErrorResume_003EP = onErrorResume;
			_003ConCompleted_003EP = onCompleted;
			_003Cstate_003EP = state;
			base._002Ector();
		}

		[DebuggerStepThrough]
		protected override void OnNextCore(T value)
		{
			_003ConNext_003EP(value, _003Cstate_003EP);
		}

		[DebuggerStepThrough]
		protected override void OnErrorResumeCore(Exception error)
		{
			_003ConErrorResume_003EP(error, _003Cstate_003EP);
		}

		[DebuggerStepThrough]
		protected override void OnCompletedCore(Result complete)
		{
			_003ConCompleted_003EP(complete, _003Cstate_003EP);
		}
	}
}
