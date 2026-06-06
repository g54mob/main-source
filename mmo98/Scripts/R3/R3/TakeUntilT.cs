using System;
using System.Threading.Tasks;

namespace R3
{
	internal sealed class TakeUntilT<T> : Observable<T>
	{
		private sealed class _TakeUntil : Observer<T>, IDisposable
		{
			private readonly Observer<T> observer;

			private readonly bool configureAwait;

			public _TakeUntil(Observer<T> observer, Task task, bool configureAwait)
			{
				this.observer = observer;
				this.configureAwait = configureAwait;
				TaskAwait(task);
			}

			protected override void OnNextCore(T value)
			{
				observer.OnNext(value);
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
					OnCompleted(Result.Success);
				}
				catch (Exception exception)
				{
					OnCompleted(Result.Failure(exception));
				}
			}
		}

		public TakeUntilT(Observable<T> source, Task task, bool configureAwait)
		{
			_003Csource_003EP = source;
			_003Ctask_003EP = task;
			_003CconfigureAwait_003EP = configureAwait;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _TakeUntil(observer, _003Ctask_003EP, _003CconfigureAwait_003EP));
		}
	}
}
