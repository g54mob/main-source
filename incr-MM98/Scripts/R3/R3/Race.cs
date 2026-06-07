using System;
using System.Collections.Generic;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal sealed class Race<T> : Observable<T>
	{
		private sealed class _Race : IDisposable
		{
			public Observer<T> observer;

			public ListDisposableCore disposables;

			public _RaceObserver? winner;

			public _Race(Observer<T> observer, int initialCount)
			{
				this.observer = observer;
				disposables = new ListDisposableCore(initialCount, this);
			}

			public void Dispose()
			{
				disposables.Dispose();
			}
		}

		private sealed class _RaceObserver : Observer<T>
		{
			private bool won;

			public _RaceObserver(_Race parent, int index)
			{
				_003Cparent_003EP = parent;
				_003Cindex_003EP = index;
				base._002Ector();
			}

			protected override void OnNextCore(T value)
			{
				if (won)
				{
					_003Cparent_003EP.observer.OnNext(value);
					return;
				}
				_RaceObserver raceObserver = Interlocked.CompareExchange(ref _003Cparent_003EP.winner, this, null);
				if (raceObserver == null)
				{
					won = true;
					_003Cparent_003EP.disposables.RemoveAllExceptAt(_003Cindex_003EP);
					_003Cparent_003EP.observer.OnNext(value);
				}
				else if (raceObserver == this)
				{
					_003Cparent_003EP.observer.OnNext(value);
				}
				else
				{
					Dispose();
				}
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				if (won)
				{
					_003Cparent_003EP.observer.OnErrorResume(error);
					return;
				}
				_RaceObserver raceObserver = Interlocked.CompareExchange(ref _003Cparent_003EP.winner, this, null);
				if (raceObserver == null)
				{
					won = true;
					_003Cparent_003EP.disposables.RemoveAllExceptAt(_003Cindex_003EP);
					_003Cparent_003EP.observer.OnErrorResume(error);
				}
				else if (raceObserver == this)
				{
					_003Cparent_003EP.observer.OnErrorResume(error);
				}
				else
				{
					Dispose();
				}
			}

			protected override void OnCompletedCore(Result result)
			{
				if (won)
				{
					_003Cparent_003EP.observer.OnCompleted(result);
					return;
				}
				_RaceObserver raceObserver = Interlocked.CompareExchange(ref _003Cparent_003EP.winner, this, null);
				if (raceObserver == null)
				{
					won = true;
					_003Cparent_003EP.disposables.RemoveAllExceptAt(_003Cindex_003EP);
					_003Cparent_003EP.observer.OnCompleted(result);
				}
				else if (raceObserver == this)
				{
					_003Cparent_003EP.observer.OnCompleted(result);
				}
				else
				{
					Dispose();
				}
			}

			protected override void DisposeCore()
			{
				_003Cparent_003EP.disposables.RemoveAt(_003Cindex_003EP);
			}
		}

		public Race(IEnumerable<Observable<T>> sources)
		{
			_003Csources_003EP = sources;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			if (!_003Csources_003EP.TryGetNonEnumeratedCount(out var count))
			{
				count = 4;
			}
			_Race race = new _Race(observer, count);
			int num = 0;
			foreach (Observable<T> item in _003Csources_003EP)
			{
				IDisposable disposable = item.Subscribe(new _RaceObserver(race, num++));
				race.disposables.Add(disposable);
			}
			return race;
		}
	}
}
