using System;
using System.Threading;
using System.Threading.Tasks;

namespace R3
{
	internal sealed class SkipUntilT<T> : Observable<T>
	{
		private sealed class _SkipUntil : Observer<T>, IDisposable
		{
			private readonly bool configureAwait;

			private readonly Observer<T> observer;

			private bool open;

			public _SkipUntil(Observer<T> observer, Task task, bool configureAwait)
			{
				this.configureAwait = configureAwait;
				this.observer = observer;
				TaskAwait(task);
			}

			protected override void OnNextCore(T value)
			{
				if (Volatile.Read(ref open))
				{
					observer.OnNext(value);
				}
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				observer.OnErrorResume(error);
			}

			protected override void OnCompletedCore(Result result)
			{
				observer.OnCompleted(result);
			}

			private async void TaskAwait(Task task)
			{
				try
				{
					await task.ConfigureAwait(configureAwait);
					Volatile.Write(ref open, value: true);
				}
				catch (Exception exception)
				{
					OnCompleted(Result.Failure(exception));
				}
			}
		}

		public SkipUntilT(Observable<T> source, Task task, bool configureAwait)
		{
			_003Csource_003EP = source;
			_003Ctask_003EP = task;
			_003CconfigureAwait_003EP = configureAwait;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _SkipUntil(observer, _003Ctask_003EP, _003CconfigureAwait_003EP));
		}
	}
}
