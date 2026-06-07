using System;
using System.Collections.Generic;

namespace R3
{
	internal sealed class ChunkWindow<T, TWindowBoundary> : Observable<T[]>
	{
		private sealed class _Chunk : Observer<T>
		{
			private sealed class WindowBoundaryObserver : Observer<TWindowBoundary>
			{
				public WindowBoundaryObserver(_Chunk parent)
				{
					_003Cparent_003EP = parent;
					base._002Ector();
				}

				protected override void OnNextCore(TWindowBoundary _)
				{
					lock (_003Cparent_003EP.list)
					{
						if (_003Cparent_003EP.list.Count == 0)
						{
							_003Cparent_003EP.observer.OnNext(Array.Empty<T>());
							return;
						}
						_003Cparent_003EP.observer.OnNext(_003Cparent_003EP.list.ToArray());
						_003Cparent_003EP.list.Clear();
					}
				}

				protected override void OnErrorResumeCore(Exception error)
				{
					_003Cparent_003EP.OnErrorResume(error);
				}

				protected override void OnCompletedCore(Result result)
				{
					_003Cparent_003EP.OnCompleted();
				}
			}

			private readonly Observer<T[]> observer;

			private readonly List<T> list;

			private IDisposable? windowSubscription;

			public _Chunk(Observer<T[]> observer)
			{
				this.observer = observer;
				list = new List<T>();
				base._002Ector();
			}

			public IDisposable Run(Observable<T> source, Observable<TWindowBoundary> windowBoundaries)
			{
				windowSubscription = windowBoundaries.Subscribe(new WindowBoundaryObserver(this));
				try
				{
					return source.Subscribe(this);
				}
				catch
				{
					windowSubscription.Dispose();
					throw;
				}
			}

			protected override void OnNextCore(T value)
			{
				lock (list)
				{
					list.Add(value);
				}
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				observer.OnErrorResume(error);
			}

			protected override void OnCompletedCore(Result result)
			{
				lock (list)
				{
					if (list.Count > 0)
					{
						observer.OnNext(list.ToArray());
						list.Clear();
					}
				}
				observer.OnCompleted(result);
			}

			protected override void DisposeCore()
			{
				windowSubscription?.Dispose();
			}
		}

		public ChunkWindow(Observable<T> source, Observable<TWindowBoundary> windowBoundaries)
		{
			_003Csource_003EP = source;
			_003CwindowBoundaries_003EP = windowBoundaries;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T[]> observer)
		{
			return new _Chunk(observer).Run(_003Csource_003EP, _003CwindowBoundaries_003EP);
		}
	}
}
