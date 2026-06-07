using System;
using System.Diagnostics;
using System.Threading;

namespace R3
{
	public abstract class Observer<T> : IDisposable
	{
		internal SingleAssignmentDisposableCore SourceSubscription;

		private int calledOnCompleted;

		private int disposed;

		public bool IsDisposed => disposed != 0;

		private bool IsCalledCompleted => calledOnCompleted != 0;

		protected virtual bool AutoDisposeOnCompleted => true;

		[System.Diagnostics.StackTraceHidden]
		[DebuggerStepThrough]
		public void OnNext(T value)
		{
			if (IsDisposed || IsCalledCompleted)
			{
				return;
			}
			try
			{
				OnNextCore(value);
			}
			catch (Exception error)
			{
				OnErrorResume(error);
			}
		}

		protected abstract void OnNextCore(T value);

		[System.Diagnostics.StackTraceHidden]
		[DebuggerStepThrough]
		public void OnErrorResume(Exception error)
		{
			if (IsDisposed || IsCalledCompleted)
			{
				return;
			}
			try
			{
				OnErrorResumeCore(error);
			}
			catch (Exception obj)
			{
				ObservableSystem.GetUnhandledExceptionHandler()(obj);
			}
		}

		protected abstract void OnErrorResumeCore(Exception error);

		[System.Diagnostics.StackTraceHidden]
		[DebuggerStepThrough]
		public void OnCompleted(Result result)
		{
			if (Interlocked.Exchange(ref calledOnCompleted, 1) != 0 || IsDisposed)
			{
				return;
			}
			bool flag = AutoDisposeOnCompleted;
			try
			{
				OnCompletedCore(result);
			}
			catch (Exception obj)
			{
				flag = true;
				ObservableSystem.GetUnhandledExceptionHandler()(obj);
			}
			finally
			{
				if (flag)
				{
					Dispose();
				}
			}
		}

		protected abstract void OnCompletedCore(Result result);

		[System.Diagnostics.StackTraceHidden]
		[DebuggerStepThrough]
		public void Dispose()
		{
			if (Interlocked.Exchange(ref disposed, 1) == 0)
			{
				DisposeCore();
				SourceSubscription.Dispose();
			}
		}

		[System.Diagnostics.StackTraceHidden]
		[DebuggerStepThrough]
		protected virtual void DisposeCore()
		{
		}
	}
}
