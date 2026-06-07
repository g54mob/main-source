using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using UniRx.InternalUtil;
using UnityEngine.UI;

namespace UniRx
{
	public static class AsyncReactiveCommandExtensions
	{
		private static readonly Action<object> Callback = CancelCallback;

		public static AsyncReactiveCommand ToAsyncReactiveCommand(this IReactiveProperty<bool> sharedCanExecuteSource)
		{
			return new AsyncReactiveCommand(sharedCanExecuteSource);
		}

		public static AsyncReactiveCommand<T> ToAsyncReactiveCommand<T>(this IReactiveProperty<bool> sharedCanExecuteSource)
		{
			return new AsyncReactiveCommand<T>(sharedCanExecuteSource);
		}

		private static void CancelCallback(object state)
		{
			Tuple<ICancellableTaskCompletionSource, IDisposable> obj = (Tuple<ICancellableTaskCompletionSource, IDisposable>)state;
			obj.Item2.Dispose();
			obj.Item1.TrySetCanceled();
		}

		public static Task<T> WaitUntilExecuteAsync<T>(this IAsyncReactiveCommand<T> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			CancellableTaskCompletionSource<T> tcs = new CancellableTaskCompletionSource<T>();
			IDisposable item = source.Subscribe(delegate(T x)
			{
				tcs.TrySetResult(x);
				return Observable.ReturnUnit();
			});
			cancellationToken.Register(Callback, Tuple.Create(tcs, item), useSynchronizationContext: false);
			return tcs.Task;
		}

		public static TaskAwaiter<T> GetAwaiter<T>(this IAsyncReactiveCommand<T> command)
		{
			return command.WaitUntilExecuteAsync(CancellationToken.None).GetAwaiter();
		}

		public static IDisposable BindTo(this IAsyncReactiveCommand<Unit> command, Button button)
		{
			IDisposable disposable = command.CanExecute.SubscribeToInteractable(button);
			IDisposable disposable2 = button.OnClickAsObservable().SubscribeWithState(command, delegate(Unit x, IAsyncReactiveCommand<Unit> c)
			{
				c.Execute(x);
			});
			return StableCompositeDisposable.Create(disposable, disposable2);
		}

		public static IDisposable BindToOnClick(this IAsyncReactiveCommand<Unit> command, Button button, Func<Unit, IObservable<Unit>> asyncOnClick)
		{
			IDisposable disposable = command.CanExecute.SubscribeToInteractable(button);
			IDisposable disposable2 = button.OnClickAsObservable().SubscribeWithState(command, delegate(Unit x, IAsyncReactiveCommand<Unit> c)
			{
				c.Execute(x);
			});
			IDisposable disposable3 = command.Subscribe(asyncOnClick);
			return StableCompositeDisposable.Create(disposable, disposable2, disposable3);
		}

		public static IDisposable BindToOnClick(this Button button, Func<Unit, IObservable<Unit>> asyncOnClick)
		{
			return new AsyncReactiveCommand().BindToOnClick(button, asyncOnClick);
		}

		public static IDisposable BindToOnClick(this Button button, IReactiveProperty<bool> sharedCanExecuteSource, Func<Unit, IObservable<Unit>> asyncOnClick)
		{
			return sharedCanExecuteSource.ToAsyncReactiveCommand().BindToOnClick(button, asyncOnClick);
		}
	}
}
