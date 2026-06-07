using System;
using System.Threading;

namespace R3
{
	internal sealed class SkipUntil<T, TOther> : Observable<T>
	{
		private sealed class _SkipUntil : Observer<T>
		{
			private readonly Observer<T> observer;

			internal readonly SkipUntilOtherObserver otherObserver;

			internal bool open;

			public _SkipUntil(Observer<T> observer)
			{
				this.observer = observer;
				otherObserver = new SkipUntilOtherObserver(this);
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

			protected override void DisposeCore()
			{
				otherObserver.Dispose();
			}
		}

		private sealed class SkipUntilOtherObserver : Observer<TOther>
		{
			public SkipUntilOtherObserver(_SkipUntil parent)
			{
				_003Cparent_003EP = parent;
				base._002Ector();
			}

			protected override void OnNextCore(TOther value)
			{
				Volatile.Write(ref _003Cparent_003EP.open, value: true);
				Dispose();
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				_003Cparent_003EP.OnErrorResume(error);
			}

			protected override void OnCompletedCore(Result result)
			{
				_003Cparent_003EP.OnCompleted(result);
			}
		}

		public SkipUntil(Observable<T> source, Observable<TOther> other)
		{
			_003Csource_003EP = source;
			_003Cother_003EP = other;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			_SkipUntil skipUntil = new _SkipUntil(observer);
			IDisposable disposable = _003Cother_003EP.Subscribe(skipUntil.otherObserver);
			try
			{
				return _003Csource_003EP.Subscribe(skipUntil);
			}
			catch
			{
				disposable.Dispose();
				throw;
			}
		}
	}
}
