using System;

namespace R3
{
	internal sealed class SelectManyIndexed<TSource, TCollection, TResult> : Observable<TResult>
	{
		private sealed class _SelectMany : Observer<TSource>
		{
			private sealed class _SelectManyCollectionObserver : Observer<TCollection>
			{
				private int index;

				public _SelectManyCollectionObserver(TSource sourceValue, _SelectMany parent, int sourceIndex)
				{
					_003CsourceValue_003EP = sourceValue;
					_003Cparent_003EP = parent;
					_003CsourceIndex_003EP = sourceIndex;
					base._002Ector();
				}

				protected override void OnNextCore(TCollection value)
				{
					TResult value2 = _003Cparent_003EP.resultSelector(_003CsourceValue_003EP, _003CsourceIndex_003EP, value, index++);
					lock (_003Cparent_003EP.gate)
					{
						_003Cparent_003EP.observer.OnNext(value2);
					}
				}

				protected override void OnErrorResumeCore(Exception error)
				{
					lock (_003Cparent_003EP.gate)
					{
						_003Cparent_003EP.observer.OnErrorResume(error);
					}
				}

				protected override void OnCompletedCore(Result result)
				{
					if (result.IsFailure)
					{
						_003Cparent_003EP.OnCompleted(result);
						return;
					}
					lock (_003Cparent_003EP.gate)
					{
						if (_003Cparent_003EP.isStopped && _003Cparent_003EP.compositeDisposable.Count == 1)
						{
							_003Cparent_003EP.PublishCompleted(result);
						}
					}
				}

				protected override void DisposeCore()
				{
					_003Cparent_003EP.compositeDisposable.Remove(this);
				}
			}

			private readonly Observer<TResult> observer;

			private readonly Func<TSource, int, Observable<TCollection>> collectionSelector;

			private readonly Func<TSource, int, TCollection, int, TResult> resultSelector;

			private readonly CompositeDisposable compositeDisposable;

			private readonly object gate;

			private bool isStopped;

			private int index;

			protected override bool AutoDisposeOnCompleted => false;

			public _SelectMany(Observer<TResult> observer, Func<TSource, int, Observable<TCollection>> collectionSelector, Func<TSource, int, TCollection, int, TResult> resultSelector)
			{
				this.observer = observer;
				this.collectionSelector = collectionSelector;
				this.resultSelector = resultSelector;
				compositeDisposable = new CompositeDisposable();
				gate = new object();
				base._002Ector();
			}

			protected override void OnNextCore(TSource value)
			{
				int num = index++;
				Observable<TCollection> observable = collectionSelector(value, num);
				_SelectManyCollectionObserver item = new _SelectManyCollectionObserver(value, this, num);
				compositeDisposable.Add(item);
				observable.Subscribe(item);
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				lock (gate)
				{
					observer.OnErrorResume(error);
				}
			}

			protected override void OnCompletedCore(Result result)
			{
				if (result.IsFailure)
				{
					PublishCompleted(result);
					return;
				}
				lock (gate)
				{
					isStopped = true;
					if (compositeDisposable.Count == 0)
					{
						PublishCompleted(result);
					}
				}
			}

			protected override void DisposeCore()
			{
				compositeDisposable.Dispose();
			}

			private void PublishCompleted(Result result)
			{
				try
				{
					lock (gate)
					{
						observer.OnCompleted(result);
					}
				}
				finally
				{
					Dispose();
				}
			}
		}

		public SelectManyIndexed(Observable<TSource> source, Func<TSource, int, Observable<TCollection>> collectionSelector, Func<TSource, int, TCollection, int, TResult> resultSelector)
		{
			_003Csource_003EP = source;
			_003CcollectionSelector_003EP = collectionSelector;
			_003CresultSelector_003EP = resultSelector;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<TResult> observer)
		{
			return _003Csource_003EP.Subscribe(new _SelectMany(observer, _003CcollectionSelector_003EP, _003CresultSelector_003EP));
		}
	}
}
