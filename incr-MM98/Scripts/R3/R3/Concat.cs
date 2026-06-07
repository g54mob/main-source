using System;
using System.Collections.Generic;

namespace R3
{
	internal sealed class Concat<T> : Observable<T>
	{
		private sealed class _Concat : IDisposable
		{
			public Observer<T> observer;

			public IEnumerator<Observable<T>> enumerator;

			public SerialDisposableCore disposable;

			private int id;

			private readonly object gate = new object();

			public _Concat(Observer<T> observer, IEnumerable<Observable<T>> sources)
			{
				this.observer = observer;
				enumerator = sources.GetEnumerator();
			}

			public IDisposable Run()
			{
				if (!enumerator.MoveNext())
				{
					observer.OnCompleted();
					enumerator.Dispose();
					return Disposable.Empty;
				}
				SubscribeNext();
				return this;
			}

			public void Dispose()
			{
				enumerator.Dispose();
				disposable.Dispose();
			}

			public void SubscribeNext()
			{
				lock (gate)
				{
					id++;
					int num = id;
					IDisposable disposable = enumerator.Current.Subscribe(new _ConcatObserver(this));
					if (num == id)
					{
						this.disposable.Disposable = disposable;
					}
				}
			}
		}

		private sealed class _ConcatObserver : Observer<T>
		{
			public _ConcatObserver(_Concat parent)
			{
				_003Cparent_003EP = parent;
				base._002Ector();
			}

			protected override void OnNextCore(T value)
			{
				_003Cparent_003EP.observer.OnNext(value);
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				_003Cparent_003EP.observer.OnErrorResume(error);
			}

			protected override void OnCompletedCore(Result result)
			{
				if (result.IsFailure)
				{
					try
					{
						_003Cparent_003EP.observer.OnCompleted(result);
						return;
					}
					finally
					{
						Dispose();
					}
				}
				if (_003Cparent_003EP.enumerator.MoveNext())
				{
					_003Cparent_003EP.SubscribeNext();
				}
				else
				{
					_003Cparent_003EP.observer.OnCompleted();
				}
			}
		}

		public Concat(IEnumerable<Observable<T>> sources)
		{
			_003Csources_003EP = sources;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return new _Concat(observer, _003Csources_003EP).Run();
		}
	}
}
