using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using UniRx.InternalUtil;
using UnityEngine.UI;

namespace UniRx
{
	public static class ReactiveCommandExtensions
	{
		private static readonly Action<object> Callback = CancelCallback;

		public static ReactiveCommand ToReactiveCommand(this IObservable<bool> canExecuteSource, bool initialValue = true)
		{
			return new ReactiveCommand(canExecuteSource, initialValue);
		}

		public static ReactiveCommand<T> ToReactiveCommand<T>(this IObservable<bool> canExecuteSource, bool initialValue = true)
		{
			return new ReactiveCommand<T>(canExecuteSource, initialValue);
		}

		private static void CancelCallback(object state)
		{
			Tuple<ICancellableTaskCompletionSource, IDisposable> obj = (Tuple<ICancellableTaskCompletionSource, IDisposable>)state;
			obj.Item2.Dispose();
			obj.Item1.TrySetCanceled();
		}

		public static Task<T> WaitUntilExecuteAsync<T>(this IReactiveCommand<T> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			CancellableTaskCompletionSource<T> tcs = new CancellableTaskCompletionSource<T>();
			SingleAssignmentDisposable disposable = new SingleAssignmentDisposable();
			disposable.Disposable = source.Subscribe(delegate(T x)
			{
				disposable.Dispose();
				tcs.TrySetResult(x);
			}, delegate(Exception ex)
			{
				tcs.TrySetException(ex);
			}, delegate
			{
				tcs.TrySetCanceled();
			});
			cancellationToken.Register(Callback, Tuple.Create(tcs, disposable.Disposable), useSynchronizationContext: false);
			return tcs.Task;
		}

		public static TaskAwaiter<T> GetAwaiter<T>(this IReactiveCommand<T> command)
		{
			return command.WaitUntilExecuteAsync(CancellationToken.None).GetAwaiter();
		}

		public static IDisposable BindTo(this IReactiveCommand<Unit> command, Button button)
		{
			IDisposable disposable = command.CanExecute.SubscribeToInteractable(button);
			IDisposable disposable2 = button.OnClickAsObservable().SubscribeWithState(command, delegate(Unit x, IReactiveCommand<Unit> c)
			{
				c.Execute(x);
			});
			return StableCompositeDisposable.Create(disposable, disposable2);
		}

		public static IDisposable BindToOnClick(this IReactiveCommand<Unit> command, Button button, Action<Unit> onClick)
		{
			IDisposable disposable = command.CanExecute.SubscribeToInteractable(button);
			IDisposable disposable2 = button.OnClickAsObservable().SubscribeWithState(command, delegate(Unit x, IReactiveCommand<Unit> c)
			{
				c.Execute(x);
			});
			IDisposable disposable3 = command.Subscribe(onClick);
			return StableCompositeDisposable.Create(disposable, disposable2, disposable3);
		}

		public static IDisposable BindToButtonOnClick(this IObservable<bool> canExecuteSource, Button button, Action<Unit> onClick, bool initialValue = true)
		{
			return canExecuteSource.ToReactiveCommand(initialValue).BindToOnClick(button, onClick);
		}
	}
}
