using System;
using System.Threading;
using System.Threading.Tasks;

namespace R3
{
	public static class ReactiveCommandExtensions
	{
		public static ReactiveCommand<T> ToReactiveCommand<T>(this Observable<bool> canExecuteSource, bool initialCanExecute = true)
		{
			return new ReactiveCommand<T>(canExecuteSource, initialCanExecute);
		}

		public static ReactiveCommand<T> ToReactiveCommand<T>(this Observable<bool> canExecuteSource, Action<T> execute, bool initialCanExecute = true)
		{
			ReactiveCommand<T> reactiveCommand = new ReactiveCommand<T>(canExecuteSource, initialCanExecute);
			IDisposable disposable = reactiveCommand.Subscribe(execute);
			reactiveCommand.CombineSubscription(disposable);
			return reactiveCommand;
		}

		public static ReactiveCommand<TInput, TOutput> ToReactiveCommand<TInput, TOutput>(this Observable<bool> canExecuteSource, Func<TInput, TOutput> convert, bool initialCanExecute = true)
		{
			return new ReactiveCommand<TInput, TOutput>(canExecuteSource, initialCanExecute, convert);
		}

		public static ReactiveCommand ToReactiveCommand(this Observable<bool> canExecuteSource, bool initialCanExecute = true)
		{
			return new ReactiveCommand(canExecuteSource, initialCanExecute);
		}

		public static ReactiveCommand ToReactiveCommand(this Observable<bool> canExecuteSource, Action<Unit> execute, bool initialCanExecute = true)
		{
			ReactiveCommand reactiveCommand = new ReactiveCommand(canExecuteSource, initialCanExecute);
			IDisposable disposable = reactiveCommand.Subscribe(execute);
			reactiveCommand.CombineSubscription(disposable);
			return reactiveCommand;
		}

		public static ReactiveCommand<T> ToReactiveCommand<T>(this Observable<bool> canExecuteSource, Func<T, CancellationToken, ValueTask> executeAsync, bool initialCanExecute = true, AwaitOperation awaitOperation = AwaitOperation.Sequential, bool configureAwait = true, bool cancelOnCompleted = false, int maxSequential = -1)
		{
			ReactiveCommand<T> reactiveCommand = new ReactiveCommand<T>(canExecuteSource, initialCanExecute);
			IDisposable disposable = reactiveCommand.SubscribeAwait(async delegate(T x, CancellationToken ct)
			{
				await executeAsync(x, ct);
			}, awaitOperation, configureAwait, cancelOnCompleted, maxSequential);
			reactiveCommand.CombineSubscription(disposable);
			return reactiveCommand;
		}

		public static ReactiveCommand<TInput, TOutput> ToReactiveCommand<TInput, TOutput>(this Observable<bool> canExecuteSource, Func<TInput, CancellationToken, ValueTask<TOutput>> convertAsync, bool initialCanExecute = true, AwaitOperation awaitOperation = AwaitOperation.Sequential, bool configureAwait = true, bool cancelOnCompleted = false, int maxSequential = -1)
		{
			return new ReactiveCommand<TInput, TOutput>(canExecuteSource, initialCanExecute, convertAsync, awaitOperation, configureAwait, cancelOnCompleted, maxSequential);
		}
	}
}
