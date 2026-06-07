using System;
using UniRx.InternalUtil;

namespace UniRx
{
	public class AsyncReactiveCommand : AsyncReactiveCommand<Unit>
	{
		public AsyncReactiveCommand()
		{
		}

		public AsyncReactiveCommand(IObservable<bool> canExecuteSource)
			: base(canExecuteSource)
		{
		}

		public AsyncReactiveCommand(IReactiveProperty<bool> sharedCanExecute)
			: base(sharedCanExecute)
		{
		}

		public IDisposable Execute()
		{
			return Execute(Unit.Default);
		}
	}
	public class AsyncReactiveCommand<T> : IAsyncReactiveCommand<T>
	{
		private class Subscription : IDisposable
		{
			private readonly AsyncReactiveCommand<T> parent;

			private readonly Func<T, IObservable<Unit>> asyncAction;

			public Subscription(AsyncReactiveCommand<T> parent, Func<T, IObservable<Unit>> asyncAction)
			{
				this.parent = parent;
				this.asyncAction = asyncAction;
			}

			public void Dispose()
			{
				lock (parent.gate)
				{
					parent.asyncActions = parent.asyncActions.Remove(asyncAction);
				}
			}
		}

		private ImmutableList<Func<T, IObservable<Unit>>> asyncActions = ImmutableList<Func<T, IObservable<Unit>>>.Empty;

		private readonly object gate = new object();

		private readonly IReactiveProperty<bool> canExecuteSource;

		private readonly IReadOnlyReactiveProperty<bool> canExecute;

		public IReadOnlyReactiveProperty<bool> CanExecute => canExecute;

		public bool IsDisposed { get; private set; }

		public AsyncReactiveCommand()
		{
			canExecuteSource = new ReactiveProperty<bool>(initialValue: true);
			canExecute = canExecuteSource;
		}

		public AsyncReactiveCommand(IObservable<bool> canExecuteSource)
		{
			this.canExecuteSource = new ReactiveProperty<bool>(initialValue: true);
			canExecute = this.canExecuteSource.CombineLatest(canExecuteSource, (bool x, bool y) => x && y).ToReactiveProperty();
		}

		public AsyncReactiveCommand(IReactiveProperty<bool> sharedCanExecute)
		{
			canExecuteSource = sharedCanExecute;
			canExecute = sharedCanExecute;
		}

		public IDisposable Execute(T parameter)
		{
			if (canExecute.Value)
			{
				canExecuteSource.Value = false;
				Func<T, IObservable<Unit>>[] data = asyncActions.Data;
				if (data.Length == 1)
				{
					try
					{
						return (data[0](parameter) ?? Observable.ReturnUnit()).Finally(delegate
						{
							canExecuteSource.Value = true;
						}).Subscribe();
					}
					catch
					{
						canExecuteSource.Value = true;
						throw;
					}
				}
				IObservable<Unit>[] array = new IObservable<Unit>[data.Length];
				try
				{
					for (int num = 0; num < data.Length; num++)
					{
						array[num] = data[num](parameter) ?? Observable.ReturnUnit();
					}
				}
				catch
				{
					canExecuteSource.Value = true;
					throw;
				}
				return Observable.WhenAll(array).Finally(delegate
				{
					canExecuteSource.Value = true;
				}).Subscribe();
			}
			return Disposable.Empty;
		}

		public IDisposable Subscribe(Func<T, IObservable<Unit>> asyncAction)
		{
			lock (gate)
			{
				asyncActions = asyncActions.Add(asyncAction);
			}
			return new Subscription(this, asyncAction);
		}

		public void Dispose()
		{
			if (!IsDisposed)
			{
				IsDisposed = true;
				asyncActions = ImmutableList<Func<T, IObservable<Unit>>>.Empty;
			}
		}
	}
}
