using System;
using System.Threading;
using System.Threading.Tasks;

namespace UniRx
{
	public static class TaskObservableExtensions
	{
		public static IObservable<Unit> ToObservable(this Task task)
		{
			if (task == null)
			{
				throw new ArgumentNullException("task");
			}
			return ToObservableImpl(task, null);
		}

		public static IObservable<Unit> ToObservable(this Task task, IScheduler scheduler)
		{
			if (task == null)
			{
				throw new ArgumentNullException("task");
			}
			if (scheduler == null)
			{
				throw new ArgumentNullException("scheduler");
			}
			return ToObservableImpl(task, scheduler);
		}

		private static IObservable<Unit> ToObservableImpl(Task task, IScheduler scheduler)
		{
			IObservable<Unit> result = null;
			if (task.IsCompleted)
			{
				scheduler = scheduler ?? Scheduler.Immediate;
				switch (task.Status)
				{
				case TaskStatus.RanToCompletion:
					result = Observable.Return(Unit.Default, scheduler);
					break;
				case TaskStatus.Faulted:
					result = Observable.Throw<Unit>(task.Exception.InnerException, scheduler);
					break;
				case TaskStatus.Canceled:
					result = Observable.Throw<Unit>(new TaskCanceledException(task), scheduler);
					break;
				}
			}
			else
			{
				result = ToObservableSlow(task, scheduler);
			}
			return result;
		}

		private static IObservable<Unit> ToObservableSlow(Task task, IScheduler scheduler)
		{
			AsyncSubject<Unit> subject = new AsyncSubject<Unit>();
			TaskContinuationOptions taskContinuationOptions = GetTaskContinuationOptions(scheduler);
			task.ContinueWith(delegate
			{
				ToObservableDone(task, subject);
			}, taskContinuationOptions);
			return ToObservableResult(subject, scheduler);
		}

		private static void ToObservableDone(Task task, IObserver<Unit> subject)
		{
			switch (task.Status)
			{
			case TaskStatus.RanToCompletion:
				subject.OnNext(Unit.Default);
				subject.OnCompleted();
				break;
			case TaskStatus.Faulted:
				subject.OnError(task.Exception.InnerException);
				break;
			case TaskStatus.Canceled:
				subject.OnError(new TaskCanceledException(task));
				break;
			}
		}

		public static IObservable<TResult> ToObservable<TResult>(this Task<TResult> task)
		{
			if (task == null)
			{
				throw new ArgumentNullException("task");
			}
			return ToObservableImpl(task, null);
		}

		public static IObservable<TResult> ToObservable<TResult>(this Task<TResult> task, IScheduler scheduler)
		{
			if (task == null)
			{
				throw new ArgumentNullException("task");
			}
			if (scheduler == null)
			{
				throw new ArgumentNullException("scheduler");
			}
			return ToObservableImpl(task, scheduler);
		}

		private static IObservable<TResult> ToObservableImpl<TResult>(Task<TResult> task, IScheduler scheduler)
		{
			IObservable<TResult> result = null;
			if (task.IsCompleted)
			{
				scheduler = scheduler ?? Scheduler.Immediate;
				switch (task.Status)
				{
				case TaskStatus.RanToCompletion:
					result = Observable.Return(task.Result, scheduler);
					break;
				case TaskStatus.Faulted:
					result = Observable.Throw<TResult>(task.Exception.InnerException, scheduler);
					break;
				case TaskStatus.Canceled:
					result = Observable.Throw<TResult>(new TaskCanceledException(task), scheduler);
					break;
				}
			}
			else
			{
				result = ToObservableSlow(task, scheduler);
			}
			return result;
		}

		private static IObservable<TResult> ToObservableSlow<TResult>(Task<TResult> task, IScheduler scheduler)
		{
			AsyncSubject<TResult> subject = new AsyncSubject<TResult>();
			TaskContinuationOptions taskContinuationOptions = GetTaskContinuationOptions(scheduler);
			task.ContinueWith(delegate
			{
				ToObservableDone(task, subject);
			}, taskContinuationOptions);
			return ToObservableResult(subject, scheduler);
		}

		private static void ToObservableDone<TResult>(Task<TResult> task, IObserver<TResult> subject)
		{
			switch (task.Status)
			{
			case TaskStatus.RanToCompletion:
				subject.OnNext(task.Result);
				subject.OnCompleted();
				break;
			case TaskStatus.Faulted:
				subject.OnError(task.Exception.InnerException);
				break;
			case TaskStatus.Canceled:
				subject.OnError(new TaskCanceledException(task));
				break;
			}
		}

		private static TaskContinuationOptions GetTaskContinuationOptions(IScheduler scheduler)
		{
			TaskContinuationOptions taskContinuationOptions = TaskContinuationOptions.None;
			if (scheduler != null)
			{
				taskContinuationOptions |= TaskContinuationOptions.ExecuteSynchronously;
			}
			return taskContinuationOptions;
		}

		private static IObservable<TResult> ToObservableResult<TResult>(AsyncSubject<TResult> subject, IScheduler scheduler)
		{
			if (scheduler != null)
			{
				return subject.ObserveOn(scheduler);
			}
			return subject.AsObservable();
		}

		public static Task<TResult> ToTask<TResult>(this IObservable<TResult> observable)
		{
			if (observable == null)
			{
				throw new ArgumentNullException("observable");
			}
			return observable.ToTask(default(CancellationToken), null);
		}

		public static Task<TResult> ToTask<TResult>(this IObservable<TResult> observable, object state)
		{
			if (observable == null)
			{
				throw new ArgumentNullException("observable");
			}
			return observable.ToTask(default(CancellationToken), state);
		}

		public static Task<TResult> ToTask<TResult>(this IObservable<TResult> observable, CancellationToken cancellationToken)
		{
			if (observable == null)
			{
				throw new ArgumentNullException("observable");
			}
			return observable.ToTask(cancellationToken, null);
		}

		public static Task<TResult> ToTask<TResult>(this IObservable<TResult> observable, CancellationToken cancellationToken, object state)
		{
			if (observable == null)
			{
				throw new ArgumentNullException("observable");
			}
			bool hasValue = false;
			TResult lastValue = default(TResult);
			TaskCompletionSource<TResult> tcs = new TaskCompletionSource<TResult>(state);
			SingleAssignmentDisposable disposable = new SingleAssignmentDisposable();
			CancellationTokenRegistration ctr = default(CancellationTokenRegistration);
			if (cancellationToken.CanBeCanceled)
			{
				ctr = cancellationToken.Register(delegate
				{
					disposable.Dispose();
					tcs.TrySetCanceled(cancellationToken);
				});
			}
			IObserver<TResult> observer = Observer.Create(delegate(TResult value)
			{
				hasValue = true;
				lastValue = value;
			}, delegate(Exception ex)
			{
				tcs.TrySetException(ex);
				ctr.Dispose();
				disposable.Dispose();
			}, delegate
			{
				if (hasValue)
				{
					tcs.TrySetResult(lastValue);
				}
				else
				{
					tcs.TrySetException(new InvalidOperationException("Strings_Linq.NO_ELEMENTS"));
				}
				ctr.Dispose();
				disposable.Dispose();
			});
			try
			{
				disposable.Disposable = observable.Subscribe(observer);
			}
			catch (Exception exception)
			{
				tcs.TrySetException(exception);
			}
			return tcs.Task;
		}
	}
}
