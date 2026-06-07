using System;
using System.Threading.Tasks;

namespace R3
{
	internal sealed class TaskToObservable : Observable<Unit>
	{
		public TaskToObservable(Task task, bool configureAwait)
		{
			_003Ctask_003EP = task;
			_003CconfigureAwait_003EP = configureAwait;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<Unit> observer)
		{
			SubscribeTask(observer);
			return Disposable.Empty;
		}

		private async void SubscribeTask(Observer<Unit> observer)
		{
			try
			{
				await _003Ctask_003EP.ConfigureAwait(_003CconfigureAwait_003EP);
			}
			catch (Exception exception)
			{
				if (!observer.IsDisposed)
				{
					observer.OnCompleted(exception);
				}
				return;
			}
			if (!observer.IsDisposed)
			{
				observer.OnNext(Unit.Default);
				observer.OnCompleted();
			}
		}
	}
	internal sealed class TaskToObservable<T> : Observable<T>
	{
		public TaskToObservable(Task<T> task, bool configureAwait)
		{
			_003Ctask_003EP = task;
			_003CconfigureAwait_003EP = configureAwait;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			SubscribeTask(observer);
			return Disposable.Empty;
		}

		private async void SubscribeTask(Observer<T> observer)
		{
			T value;
			try
			{
				value = await _003Ctask_003EP.ConfigureAwait(_003CconfigureAwait_003EP);
			}
			catch (Exception exception)
			{
				if (!observer.IsDisposed)
				{
					observer.OnCompleted(exception);
				}
				return;
			}
			if (!observer.IsDisposed)
			{
				observer.OnNext(value);
				observer.OnCompleted();
			}
		}
	}
}
