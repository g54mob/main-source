using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using R3.Collections;

namespace R3
{
	public class ReactiveCommand<T> : Observable<T>, ICommand, IDisposable
	{
		private sealed class Subscription : IDisposable
		{
			public readonly Observer<T> observer;

			private readonly int removeKey;

			private ReactiveCommand<T>? parent;

			public Subscription(ReactiveCommand<T> parent, Observer<T> observer)
			{
				this.parent = parent;
				this.observer = observer;
				parent.list.Add(this, out removeKey);
			}

			public void Dispose()
			{
				Interlocked.Exchange(ref parent, null)?.list.Remove(removeKey);
			}
		}

		private FreeListCore<Subscription> list;

		private CompleteState completeState;

		private IDisposable subscription;

		private bool canExecute;

		public bool IsDisabled => !CanExecute();

		public event EventHandler? CanExecuteChanged;

		public ReactiveCommand()
		{
			list = new FreeListCore<Subscription>(this);
			canExecute = true;
			subscription = Disposable.Empty;
		}

		public ReactiveCommand(Action<T> execute)
		{
			list = new FreeListCore<Subscription>(this);
			canExecute = true;
			subscription = this.Subscribe(execute);
		}

		public ReactiveCommand(Func<T, CancellationToken, ValueTask> executeAsync, AwaitOperation awaitOperation = AwaitOperation.Sequential, bool configureAwait = true, bool cancelOnCompleted = false, int maxSequential = -1)
		{
			list = new FreeListCore<Subscription>(this);
			canExecute = true;
			subscription = this.SubscribeAwait(executeAsync, awaitOperation, configureAwait, cancelOnCompleted, maxSequential);
		}

		public ReactiveCommand(Observable<bool> canExecuteSource, bool initialCanExecute)
		{
			list = new FreeListCore<Subscription>(this);
			canExecute = initialCanExecute;
			subscription = canExecuteSource.Subscribe(this, delegate(bool newCanExecute, ReactiveCommand<T> state)
			{
				state.ChangeCanExecute(newCanExecute);
			});
		}

		bool ICommand.CanExecute(object? _)
		{
			return CanExecute();
		}

		void ICommand.Execute(object? parameter)
		{
			if (typeof(T) == typeof(Unit))
			{
				Execute(Unsafe.As<Unit, T>(ref Unsafe.AsRef(in Unit.Default)));
			}
			else
			{
				Execute((T)parameter);
			}
		}

		public void ChangeCanExecute(bool canExecute)
		{
			if (this.canExecute != canExecute)
			{
				this.canExecute = canExecute;
				this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
			}
		}

		public bool CanExecute()
		{
			return canExecute;
		}

		public void Execute(T parameter)
		{
			if (!completeState.IsCompleted)
			{
				ReadOnlySpan<Subscription> readOnlySpan = list.AsSpan();
				for (int i = 0; i < readOnlySpan.Length; i++)
				{
					readOnlySpan[i]?.observer.OnNext(parameter);
				}
			}
		}

		internal void CombineSubscription(IDisposable disposable)
		{
			subscription = Disposable.Combine(subscription, disposable);
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			Result? result = completeState.TryGetResult();
			if (result.HasValue)
			{
				observer.OnCompleted(result.Value);
				return Disposable.Empty;
			}
			Subscription subscription = new Subscription(this, observer);
			result = completeState.TryGetResult();
			if (result.HasValue)
			{
				subscription.observer.OnCompleted(result.Value);
				subscription.Dispose();
				return Disposable.Empty;
			}
			return subscription;
		}

		public void Dispose()
		{
			Dispose(callOnCompleted: true);
		}

		public void Dispose(bool callOnCompleted)
		{
			if (!completeState.TrySetDisposed(out var alreadyCompleted))
			{
				return;
			}
			if (callOnCompleted && !alreadyCompleted)
			{
				ReadOnlySpan<Subscription> readOnlySpan = list.AsSpan();
				for (int i = 0; i < readOnlySpan.Length; i++)
				{
					readOnlySpan[i]?.observer.OnCompleted();
				}
			}
			list.Dispose();
			subscription.Dispose();
		}
	}
	public class ReactiveCommand<TInput, TOutput> : Observable<TOutput>, ICommand, IDisposable
	{
		private sealed class Subscription : IDisposable
		{
			public readonly Observer<TOutput> observer;

			private readonly int removeKey;

			private ReactiveCommand<TInput, TOutput>? parent;

			public Subscription(ReactiveCommand<TInput, TOutput> parent, Observer<TOutput> observer)
			{
				this.parent = parent;
				this.observer = observer;
				parent.list.Add(this, out removeKey);
			}

			public void Dispose()
			{
				Interlocked.Exchange(ref parent, null)?.list.Remove(removeKey);
			}
		}

		private FreeListCore<Subscription> list;

		private CompleteState completeState;

		private bool canExecute;

		private IDisposable subscription;

		private readonly Func<TInput, TOutput>? convert;

		private SingleAssignmentSubject<TInput>? asyncInput;

		public bool IsDisabled => !CanExecute();

		public event EventHandler? CanExecuteChanged;

		public ReactiveCommand(Func<TInput, TOutput> convert)
		{
			list = new FreeListCore<Subscription>(this);
			canExecute = true;
			this.convert = convert;
			subscription = Disposable.Empty;
		}

		public ReactiveCommand(Func<TInput, CancellationToken, ValueTask<TOutput>> convertAsync, AwaitOperation awaitOperation = AwaitOperation.Sequential, bool configureAwait = true, bool cancelOnCompleted = false, int maxSequential = -1)
		{
			list = new FreeListCore<Subscription>(this);
			canExecute = true;
			asyncInput = new SingleAssignmentSubject<TInput>();
			subscription = asyncInput.SelectAwait(convertAsync, awaitOperation, configureAwait, cancelOnCompleted, maxSequential).Subscribe(this, delegate(TOutput x, ReactiveCommand<TInput, TOutput> state)
			{
				if (!state.completeState.IsCompleted)
				{
					ReadOnlySpan<Subscription> readOnlySpan = state.list.AsSpan();
					for (int i = 0; i < readOnlySpan.Length; i++)
					{
						readOnlySpan[i]?.observer.OnNext(x);
					}
				}
			});
		}

		public ReactiveCommand(Observable<bool> canExecuteSource, bool initialCanExecute, Func<TInput, TOutput> convert)
		{
			list = new FreeListCore<Subscription>(this);
			canExecute = initialCanExecute;
			this.convert = convert;
			subscription = canExecuteSource.Subscribe(this, delegate(bool newCanExecute, ReactiveCommand<TInput, TOutput> state)
			{
				state.ChangeCanExecute(newCanExecute);
			});
		}

		public ReactiveCommand(Observable<bool> canExecuteSource, bool initialCanExecute, Func<TInput, CancellationToken, ValueTask<TOutput>> convertAsync, AwaitOperation awaitOperation = AwaitOperation.Sequential, bool configureAwait = true, bool cancelOnCompleted = false, int maxSequential = -1)
		{
			list = new FreeListCore<Subscription>(this);
			canExecute = initialCanExecute;
			IDisposable disposable = canExecuteSource.Subscribe(this, delegate(bool newCanExecute, ReactiveCommand<TInput, TOutput> state)
			{
				state.ChangeCanExecute(newCanExecute);
			});
			asyncInput = new SingleAssignmentSubject<TInput>();
			IDisposable disposable2 = asyncInput.SelectAwait(convertAsync, awaitOperation, configureAwait, cancelOnCompleted, maxSequential).Subscribe(this, delegate(TOutput x, ReactiveCommand<TInput, TOutput> state)
			{
				if (!state.completeState.IsCompleted)
				{
					ReadOnlySpan<Subscription> readOnlySpan = state.list.AsSpan();
					for (int i = 0; i < readOnlySpan.Length; i++)
					{
						readOnlySpan[i]?.observer.OnNext(x);
					}
				}
			});
			subscription = Disposable.Combine(disposable, disposable2);
		}

		bool ICommand.CanExecute(object? _)
		{
			return CanExecute();
		}

		void ICommand.Execute(object? parameter)
		{
			if (typeof(TInput) == typeof(Unit))
			{
				Execute(Unsafe.As<Unit, TInput>(ref Unsafe.AsRef(in Unit.Default)));
			}
			else
			{
				Execute((TInput)parameter);
			}
		}

		public void ChangeCanExecute(bool canExecute)
		{
			if (this.canExecute != canExecute)
			{
				this.canExecute = canExecute;
				this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
			}
		}

		public bool CanExecute()
		{
			return canExecute;
		}

		public void Execute(TInput parameter)
		{
			if (completeState.IsCompleted)
			{
				return;
			}
			if (convert != null)
			{
				ReadOnlySpan<Subscription> readOnlySpan = list.AsSpan();
				for (int i = 0; i < readOnlySpan.Length; i++)
				{
					readOnlySpan[i]?.observer.OnNext(convert(parameter));
				}
			}
			else if (asyncInput != null)
			{
				asyncInput.OnNext(parameter);
			}
		}

		protected override IDisposable SubscribeCore(Observer<TOutput> observer)
		{
			Result? result = completeState.TryGetResult();
			if (result.HasValue)
			{
				observer.OnCompleted(result.Value);
				return Disposable.Empty;
			}
			Subscription subscription = new Subscription(this, observer);
			result = completeState.TryGetResult();
			if (result.HasValue)
			{
				subscription.observer.OnCompleted(result.Value);
				subscription.Dispose();
				return Disposable.Empty;
			}
			return subscription;
		}

		public void Dispose()
		{
			Dispose(callOnCompleted: true);
		}

		public void Dispose(bool callOnCompleted)
		{
			if (!completeState.TrySetDisposed(out var alreadyCompleted))
			{
				return;
			}
			if (callOnCompleted && !alreadyCompleted)
			{
				ReadOnlySpan<Subscription> readOnlySpan = list.AsSpan();
				for (int i = 0; i < readOnlySpan.Length; i++)
				{
					readOnlySpan[i]?.observer.OnCompleted();
				}
			}
			list.Dispose();
			subscription?.Dispose();
			asyncInput?.Dispose();
		}
	}
	public class ReactiveCommand : ReactiveCommand<Unit>
	{
		public ReactiveCommand()
		{
		}

		public ReactiveCommand(Action<Unit> execute)
			: base(execute)
		{
		}

		public ReactiveCommand(Func<Unit, CancellationToken, ValueTask> executeAsync, AwaitOperation awaitOperation = AwaitOperation.Sequential, bool configureAwait = true, bool cancelOnCompleted = false, int maxSequential = -1)
			: base(executeAsync, awaitOperation, configureAwait, cancelOnCompleted, maxSequential)
		{
		}

		public ReactiveCommand(Observable<bool> canExecuteSource, bool initialCanExecute)
			: base(canExecuteSource, initialCanExecute)
		{
		}
	}
}
