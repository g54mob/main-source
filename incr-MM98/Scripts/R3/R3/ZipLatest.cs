using System;
using System.Collections.Generic;
using System.Linq;

namespace R3
{
	internal sealed class ZipLatest<T> : Observable<T[]>
	{
		private sealed class _CombineLatest : IDisposable
		{
			private sealed class CombineLatestObserver : Observer<T>
			{
				private T? value;

				public bool HasValue { get; private set; }

				public bool IsCompleted { get; private set; }

				public CombineLatestObserver(_CombineLatest parent)
				{
					_003Cparent_003EP = parent;
					base._002Ector();
				}

				public T GetValue()
				{
					T? result = value;
					value = default(T);
					HasValue = false;
					return result;
				}

				protected override void OnNextCore(T value)
				{
					lock (_003Cparent_003EP.observers)
					{
						this.value = value;
						HasValue = true;
						_003Cparent_003EP.TryPublishOnNext();
					}
				}

				protected override void OnErrorResumeCore(Exception error)
				{
					_003Cparent_003EP.observer.OnErrorResume(error);
				}

				protected override void OnCompletedCore(Result result)
				{
					lock (_003Cparent_003EP.observer)
					{
						IsCompleted = true;
						_003Cparent_003EP.TryPublishOnCompleted(result, !HasValue);
					}
				}
			}

			private readonly Observer<T[]> observer;

			private readonly Observable<T>[] sources;

			private readonly CombineLatestObserver[] observers;

			public _CombineLatest(Observer<T[]> observer, IEnumerable<Observable<T>> sources)
			{
				this.observer = observer;
				if (sources is Observable<T>[] array)
				{
					this.sources = array;
				}
				else
				{
					this.sources = sources.ToArray();
				}
				CombineLatestObserver[] array2 = new CombineLatestObserver[this.sources.Length];
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i] = new CombineLatestObserver(this);
				}
				observers = array2;
			}

			public IDisposable Run()
			{
				try
				{
					for (int i = 0; i < sources.Length; i++)
					{
						sources[i].Subscribe(observers[i]);
					}
					return this;
				}
				catch
				{
					Dispose();
					throw;
				}
			}

			public void TryPublishOnNext()
			{
				bool flag = false;
				CombineLatestObserver[] array = observers;
				foreach (CombineLatestObserver combineLatestObserver in array)
				{
					if (!combineLatestObserver.HasValue)
					{
						return;
					}
					if (combineLatestObserver.IsCompleted)
					{
						flag = true;
					}
				}
				T[] array2 = new T[observers.Length];
				for (int j = 0; j < observers.Length; j++)
				{
					array2[j] = observers[j].GetValue();
				}
				observer.OnNext(array2);
				if (flag)
				{
					observer.OnCompleted();
					Dispose();
				}
			}

			public void TryPublishOnCompleted(Result result, bool empty)
			{
				if (result.IsFailure)
				{
					observer.OnCompleted(result);
					Dispose();
				}
				else if (empty || AllObserverIsCompleted())
				{
					observer.OnCompleted();
					Dispose();
				}
			}

			private bool AllObserverIsCompleted()
			{
				CombineLatestObserver[] array = observers;
				for (int i = 0; i < array.Length; i++)
				{
					if (!array[i].IsCompleted)
					{
						return false;
					}
				}
				return true;
			}

			public void Dispose()
			{
				CombineLatestObserver[] array = observers;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].Dispose();
				}
			}
		}

		public ZipLatest(IEnumerable<Observable<T>> sources)
		{
			_003Csources_003EP = sources;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T[]> observer)
		{
			return new _CombineLatest(observer, _003Csources_003EP).Run();
		}
	}
	internal sealed class ZipLatest<T1, T2, TResult> : Observable<TResult>
	{
		private sealed class _ZipLatest : IDisposable
		{
			private sealed class ZipLatestObserver<T> : Observer<T>
			{
				private T? value;

				public bool HasValue { get; private set; }

				public bool IsCompleted { get; private set; }

				public ZipLatestObserver(_ZipLatest parent)
				{
					_003Cparent_003EP = parent;
					base._002Ector();
				}

				public T GetValue()
				{
					T? result = value;
					value = default(T);
					HasValue = false;
					return result;
				}

				protected override void OnNextCore(T value)
				{
					lock (_003Cparent_003EP.gate)
					{
						this.value = value;
						HasValue = true;
						_003Cparent_003EP.TryPublishOnNext();
					}
				}

				protected override void OnErrorResumeCore(Exception error)
				{
					_003Cparent_003EP.observer.OnErrorResume(error);
				}

				protected override void OnCompletedCore(Result result)
				{
					lock (_003Cparent_003EP.gate)
					{
						IsCompleted = true;
						_003Cparent_003EP.TryPublishOnCompleted(result, !HasValue);
					}
				}
			}

			private readonly Observer<TResult> observer;

			private readonly Observable<T1> source1;

			private readonly Observable<T2> source2;

			private readonly Func<T1, T2, TResult> resultSelector;

			private readonly ZipLatestObserver<T1> observer1;

			private readonly ZipLatestObserver<T2> observer2;

			private readonly object gate = new object();

			public _ZipLatest(Observer<TResult> observer, Observable<T1> source1, Observable<T2> source2, Func<T1, T2, TResult> resultSelector)
			{
				this.observer = observer;
				this.source1 = source1;
				this.source2 = source2;
				this.resultSelector = resultSelector;
				observer1 = new ZipLatestObserver<T1>(this);
				observer2 = new ZipLatestObserver<T2>(this);
			}

			public IDisposable Run()
			{
				try
				{
					source1.Subscribe(observer1);
					source2.Subscribe(observer2);
					return this;
				}
				catch
				{
					Dispose();
					throw;
				}
			}

			public void TryPublishOnNext()
			{
				if (observer1.HasValue && observer2.HasValue)
				{
					TResult value = resultSelector(observer1.GetValue(), observer2.GetValue());
					observer.OnNext(value);
					if (observer1.IsCompleted || observer2.IsCompleted)
					{
						observer.OnCompleted();
						Dispose();
					}
				}
			}

			public void TryPublishOnCompleted(Result result, bool empty)
			{
				if (result.IsFailure)
				{
					observer.OnCompleted(result);
					Dispose();
				}
				else if (empty || (observer1.IsCompleted && observer2.IsCompleted))
				{
					observer.OnCompleted();
					Dispose();
				}
			}

			public void Dispose()
			{
				observer1.Dispose();
				observer2.Dispose();
			}
		}

		public ZipLatest(Observable<T1> source1, Observable<T2> source2, Func<T1, T2, TResult> resultSelector)
		{
			_003Csource1_003EP = source1;
			_003Csource2_003EP = source2;
			_003CresultSelector_003EP = resultSelector;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<TResult> observer)
		{
			return new _ZipLatest(observer, _003Csource1_003EP, _003Csource2_003EP, _003CresultSelector_003EP).Run();
		}
	}
	internal sealed class ZipLatest<T1, T2, T3, TResult> : Observable<TResult>
	{
		private sealed class _ZipLatest : IDisposable
		{
			private sealed class ZipLatestObserver<T> : Observer<T>
			{
				private T? value;

				public bool HasValue { get; private set; }

				public bool IsCompleted { get; private set; }

				public ZipLatestObserver(_ZipLatest parent)
				{
					_003Cparent_003EP = parent;
					base._002Ector();
				}

				public T GetValue()
				{
					T? result = value;
					value = default(T);
					HasValue = false;
					return result;
				}

				protected override void OnNextCore(T value)
				{
					lock (_003Cparent_003EP.gate)
					{
						this.value = value;
						HasValue = true;
						_003Cparent_003EP.TryPublishOnNext();
					}
				}

				protected override void OnErrorResumeCore(Exception error)
				{
					_003Cparent_003EP.observer.OnErrorResume(error);
				}

				protected override void OnCompletedCore(Result result)
				{
					lock (_003Cparent_003EP.gate)
					{
						IsCompleted = true;
						_003Cparent_003EP.TryPublishOnCompleted(result, !HasValue);
					}
				}
			}

			private readonly Observer<TResult> observer;

			private readonly Observable<T1> source1;

			private readonly Observable<T2> source2;

			private readonly Observable<T3> source3;

			private readonly Func<T1, T2, T3, TResult> resultSelector;

			private readonly ZipLatestObserver<T1> observer1;

			private readonly ZipLatestObserver<T2> observer2;

			private readonly ZipLatestObserver<T3> observer3;

			private readonly object gate = new object();

			public _ZipLatest(Observer<TResult> observer, Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Func<T1, T2, T3, TResult> resultSelector)
			{
				this.observer = observer;
				this.source1 = source1;
				this.source2 = source2;
				this.source3 = source3;
				this.resultSelector = resultSelector;
				observer1 = new ZipLatestObserver<T1>(this);
				observer2 = new ZipLatestObserver<T2>(this);
				observer3 = new ZipLatestObserver<T3>(this);
			}

			public IDisposable Run()
			{
				try
				{
					source1.Subscribe(observer1);
					source2.Subscribe(observer2);
					source3.Subscribe(observer3);
					return this;
				}
				catch
				{
					Dispose();
					throw;
				}
			}

			public void TryPublishOnNext()
			{
				if (observer1.HasValue && observer2.HasValue && observer3.HasValue)
				{
					TResult value = resultSelector(observer1.GetValue(), observer2.GetValue(), observer3.GetValue());
					observer.OnNext(value);
					if (observer1.IsCompleted || observer2.IsCompleted || observer3.IsCompleted)
					{
						observer.OnCompleted();
						Dispose();
					}
				}
			}

			public void TryPublishOnCompleted(Result result, bool empty)
			{
				if (result.IsFailure)
				{
					observer.OnCompleted(result);
					Dispose();
				}
				else if (empty || (observer1.IsCompleted && observer2.IsCompleted && observer3.IsCompleted))
				{
					observer.OnCompleted();
					Dispose();
				}
			}

			public void Dispose()
			{
				observer1.Dispose();
				observer2.Dispose();
				observer3.Dispose();
			}
		}

		public ZipLatest(Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Func<T1, T2, T3, TResult> resultSelector)
		{
			_003Csource1_003EP = source1;
			_003Csource2_003EP = source2;
			_003Csource3_003EP = source3;
			_003CresultSelector_003EP = resultSelector;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<TResult> observer)
		{
			return new _ZipLatest(observer, _003Csource1_003EP, _003Csource2_003EP, _003Csource3_003EP, _003CresultSelector_003EP).Run();
		}
	}
	internal sealed class ZipLatest<T1, T2, T3, T4, TResult> : Observable<TResult>
	{
		private sealed class _ZipLatest : IDisposable
		{
			private sealed class ZipLatestObserver<T> : Observer<T>
			{
				private T? value;

				public bool HasValue { get; private set; }

				public bool IsCompleted { get; private set; }

				public ZipLatestObserver(_ZipLatest parent)
				{
					_003Cparent_003EP = parent;
					base._002Ector();
				}

				public T GetValue()
				{
					T? result = value;
					value = default(T);
					HasValue = false;
					return result;
				}

				protected override void OnNextCore(T value)
				{
					lock (_003Cparent_003EP.gate)
					{
						this.value = value;
						HasValue = true;
						_003Cparent_003EP.TryPublishOnNext();
					}
				}

				protected override void OnErrorResumeCore(Exception error)
				{
					_003Cparent_003EP.observer.OnErrorResume(error);
				}

				protected override void OnCompletedCore(Result result)
				{
					lock (_003Cparent_003EP.gate)
					{
						IsCompleted = true;
						_003Cparent_003EP.TryPublishOnCompleted(result, !HasValue);
					}
				}
			}

			private readonly Observer<TResult> observer;

			private readonly Observable<T1> source1;

			private readonly Observable<T2> source2;

			private readonly Observable<T3> source3;

			private readonly Observable<T4> source4;

			private readonly Func<T1, T2, T3, T4, TResult> resultSelector;

			private readonly ZipLatestObserver<T1> observer1;

			private readonly ZipLatestObserver<T2> observer2;

			private readonly ZipLatestObserver<T3> observer3;

			private readonly ZipLatestObserver<T4> observer4;

			private readonly object gate = new object();

			public _ZipLatest(Observer<TResult> observer, Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Func<T1, T2, T3, T4, TResult> resultSelector)
			{
				this.observer = observer;
				this.source1 = source1;
				this.source2 = source2;
				this.source3 = source3;
				this.source4 = source4;
				this.resultSelector = resultSelector;
				observer1 = new ZipLatestObserver<T1>(this);
				observer2 = new ZipLatestObserver<T2>(this);
				observer3 = new ZipLatestObserver<T3>(this);
				observer4 = new ZipLatestObserver<T4>(this);
			}

			public IDisposable Run()
			{
				try
				{
					source1.Subscribe(observer1);
					source2.Subscribe(observer2);
					source3.Subscribe(observer3);
					source4.Subscribe(observer4);
					return this;
				}
				catch
				{
					Dispose();
					throw;
				}
			}

			public void TryPublishOnNext()
			{
				if (observer1.HasValue && observer2.HasValue && observer3.HasValue && observer4.HasValue)
				{
					TResult value = resultSelector(observer1.GetValue(), observer2.GetValue(), observer3.GetValue(), observer4.GetValue());
					observer.OnNext(value);
					if (observer1.IsCompleted || observer2.IsCompleted || observer3.IsCompleted || observer4.IsCompleted)
					{
						observer.OnCompleted();
						Dispose();
					}
				}
			}

			public void TryPublishOnCompleted(Result result, bool empty)
			{
				if (result.IsFailure)
				{
					observer.OnCompleted(result);
					Dispose();
				}
				else if (empty || (observer1.IsCompleted && observer2.IsCompleted && observer3.IsCompleted && observer4.IsCompleted))
				{
					observer.OnCompleted();
					Dispose();
				}
			}

			public void Dispose()
			{
				observer1.Dispose();
				observer2.Dispose();
				observer3.Dispose();
				observer4.Dispose();
			}
		}

		public ZipLatest(Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Func<T1, T2, T3, T4, TResult> resultSelector)
		{
			_003Csource1_003EP = source1;
			_003Csource2_003EP = source2;
			_003Csource3_003EP = source3;
			_003Csource4_003EP = source4;
			_003CresultSelector_003EP = resultSelector;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<TResult> observer)
		{
			return new _ZipLatest(observer, _003Csource1_003EP, _003Csource2_003EP, _003Csource3_003EP, _003Csource4_003EP, _003CresultSelector_003EP).Run();
		}
	}
	internal sealed class ZipLatest<T1, T2, T3, T4, T5, TResult> : Observable<TResult>
	{
		private sealed class _ZipLatest : IDisposable
		{
			private sealed class ZipLatestObserver<T> : Observer<T>
			{
				private T? value;

				public bool HasValue { get; private set; }

				public bool IsCompleted { get; private set; }

				public ZipLatestObserver(_ZipLatest parent)
				{
					_003Cparent_003EP = parent;
					base._002Ector();
				}

				public T GetValue()
				{
					T? result = value;
					value = default(T);
					HasValue = false;
					return result;
				}

				protected override void OnNextCore(T value)
				{
					lock (_003Cparent_003EP.gate)
					{
						this.value = value;
						HasValue = true;
						_003Cparent_003EP.TryPublishOnNext();
					}
				}

				protected override void OnErrorResumeCore(Exception error)
				{
					_003Cparent_003EP.observer.OnErrorResume(error);
				}

				protected override void OnCompletedCore(Result result)
				{
					lock (_003Cparent_003EP.gate)
					{
						IsCompleted = true;
						_003Cparent_003EP.TryPublishOnCompleted(result, !HasValue);
					}
				}
			}

			private readonly Observer<TResult> observer;

			private readonly Observable<T1> source1;

			private readonly Observable<T2> source2;

			private readonly Observable<T3> source3;

			private readonly Observable<T4> source4;

			private readonly Observable<T5> source5;

			private readonly Func<T1, T2, T3, T4, T5, TResult> resultSelector;

			private readonly ZipLatestObserver<T1> observer1;

			private readonly ZipLatestObserver<T2> observer2;

			private readonly ZipLatestObserver<T3> observer3;

			private readonly ZipLatestObserver<T4> observer4;

			private readonly ZipLatestObserver<T5> observer5;

			private readonly object gate = new object();

			public _ZipLatest(Observer<TResult> observer, Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Func<T1, T2, T3, T4, T5, TResult> resultSelector)
			{
				this.observer = observer;
				this.source1 = source1;
				this.source2 = source2;
				this.source3 = source3;
				this.source4 = source4;
				this.source5 = source5;
				this.resultSelector = resultSelector;
				observer1 = new ZipLatestObserver<T1>(this);
				observer2 = new ZipLatestObserver<T2>(this);
				observer3 = new ZipLatestObserver<T3>(this);
				observer4 = new ZipLatestObserver<T4>(this);
				observer5 = new ZipLatestObserver<T5>(this);
			}

			public IDisposable Run()
			{
				try
				{
					source1.Subscribe(observer1);
					source2.Subscribe(observer2);
					source3.Subscribe(observer3);
					source4.Subscribe(observer4);
					source5.Subscribe(observer5);
					return this;
				}
				catch
				{
					Dispose();
					throw;
				}
			}

			public void TryPublishOnNext()
			{
				if (observer1.HasValue && observer2.HasValue && observer3.HasValue && observer4.HasValue && observer5.HasValue)
				{
					TResult value = resultSelector(observer1.GetValue(), observer2.GetValue(), observer3.GetValue(), observer4.GetValue(), observer5.GetValue());
					observer.OnNext(value);
					if (observer1.IsCompleted || observer2.IsCompleted || observer3.IsCompleted || observer4.IsCompleted || observer5.IsCompleted)
					{
						observer.OnCompleted();
						Dispose();
					}
				}
			}

			public void TryPublishOnCompleted(Result result, bool empty)
			{
				if (result.IsFailure)
				{
					observer.OnCompleted(result);
					Dispose();
				}
				else if (empty || (observer1.IsCompleted && observer2.IsCompleted && observer3.IsCompleted && observer4.IsCompleted && observer5.IsCompleted))
				{
					observer.OnCompleted();
					Dispose();
				}
			}

			public void Dispose()
			{
				observer1.Dispose();
				observer2.Dispose();
				observer3.Dispose();
				observer4.Dispose();
				observer5.Dispose();
			}
		}

		public ZipLatest(Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Func<T1, T2, T3, T4, T5, TResult> resultSelector)
		{
			_003Csource1_003EP = source1;
			_003Csource2_003EP = source2;
			_003Csource3_003EP = source3;
			_003Csource4_003EP = source4;
			_003Csource5_003EP = source5;
			_003CresultSelector_003EP = resultSelector;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<TResult> observer)
		{
			return new _ZipLatest(observer, _003Csource1_003EP, _003Csource2_003EP, _003Csource3_003EP, _003Csource4_003EP, _003Csource5_003EP, _003CresultSelector_003EP).Run();
		}
	}
	internal sealed class ZipLatest<T1, T2, T3, T4, T5, T6, TResult> : Observable<TResult>
	{
		private sealed class _ZipLatest : IDisposable
		{
			private sealed class ZipLatestObserver<T> : Observer<T>
			{
				private T? value;

				public bool HasValue { get; private set; }

				public bool IsCompleted { get; private set; }

				public ZipLatestObserver(_ZipLatest parent)
				{
					_003Cparent_003EP = parent;
					base._002Ector();
				}

				public T GetValue()
				{
					T? result = value;
					value = default(T);
					HasValue = false;
					return result;
				}

				protected override void OnNextCore(T value)
				{
					lock (_003Cparent_003EP.gate)
					{
						this.value = value;
						HasValue = true;
						_003Cparent_003EP.TryPublishOnNext();
					}
				}

				protected override void OnErrorResumeCore(Exception error)
				{
					_003Cparent_003EP.observer.OnErrorResume(error);
				}

				protected override void OnCompletedCore(Result result)
				{
					lock (_003Cparent_003EP.gate)
					{
						IsCompleted = true;
						_003Cparent_003EP.TryPublishOnCompleted(result, !HasValue);
					}
				}
			}

			private readonly Observer<TResult> observer;

			private readonly Observable<T1> source1;

			private readonly Observable<T2> source2;

			private readonly Observable<T3> source3;

			private readonly Observable<T4> source4;

			private readonly Observable<T5> source5;

			private readonly Observable<T6> source6;

			private readonly Func<T1, T2, T3, T4, T5, T6, TResult> resultSelector;

			private readonly ZipLatestObserver<T1> observer1;

			private readonly ZipLatestObserver<T2> observer2;

			private readonly ZipLatestObserver<T3> observer3;

			private readonly ZipLatestObserver<T4> observer4;

			private readonly ZipLatestObserver<T5> observer5;

			private readonly ZipLatestObserver<T6> observer6;

			private readonly object gate = new object();

			public _ZipLatest(Observer<TResult> observer, Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Func<T1, T2, T3, T4, T5, T6, TResult> resultSelector)
			{
				this.observer = observer;
				this.source1 = source1;
				this.source2 = source2;
				this.source3 = source3;
				this.source4 = source4;
				this.source5 = source5;
				this.source6 = source6;
				this.resultSelector = resultSelector;
				observer1 = new ZipLatestObserver<T1>(this);
				observer2 = new ZipLatestObserver<T2>(this);
				observer3 = new ZipLatestObserver<T3>(this);
				observer4 = new ZipLatestObserver<T4>(this);
				observer5 = new ZipLatestObserver<T5>(this);
				observer6 = new ZipLatestObserver<T6>(this);
			}

			public IDisposable Run()
			{
				try
				{
					source1.Subscribe(observer1);
					source2.Subscribe(observer2);
					source3.Subscribe(observer3);
					source4.Subscribe(observer4);
					source5.Subscribe(observer5);
					source6.Subscribe(observer6);
					return this;
				}
				catch
				{
					Dispose();
					throw;
				}
			}

			public void TryPublishOnNext()
			{
				if (observer1.HasValue && observer2.HasValue && observer3.HasValue && observer4.HasValue && observer5.HasValue && observer6.HasValue)
				{
					TResult value = resultSelector(observer1.GetValue(), observer2.GetValue(), observer3.GetValue(), observer4.GetValue(), observer5.GetValue(), observer6.GetValue());
					observer.OnNext(value);
					if (observer1.IsCompleted || observer2.IsCompleted || observer3.IsCompleted || observer4.IsCompleted || observer5.IsCompleted || observer6.IsCompleted)
					{
						observer.OnCompleted();
						Dispose();
					}
				}
			}

			public void TryPublishOnCompleted(Result result, bool empty)
			{
				if (result.IsFailure)
				{
					observer.OnCompleted(result);
					Dispose();
				}
				else if (empty || (observer1.IsCompleted && observer2.IsCompleted && observer3.IsCompleted && observer4.IsCompleted && observer5.IsCompleted && observer6.IsCompleted))
				{
					observer.OnCompleted();
					Dispose();
				}
			}

			public void Dispose()
			{
				observer1.Dispose();
				observer2.Dispose();
				observer3.Dispose();
				observer4.Dispose();
				observer5.Dispose();
				observer6.Dispose();
			}
		}

		public ZipLatest(Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Func<T1, T2, T3, T4, T5, T6, TResult> resultSelector)
		{
			_003Csource1_003EP = source1;
			_003Csource2_003EP = source2;
			_003Csource3_003EP = source3;
			_003Csource4_003EP = source4;
			_003Csource5_003EP = source5;
			_003Csource6_003EP = source6;
			_003CresultSelector_003EP = resultSelector;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<TResult> observer)
		{
			return new _ZipLatest(observer, _003Csource1_003EP, _003Csource2_003EP, _003Csource3_003EP, _003Csource4_003EP, _003Csource5_003EP, _003Csource6_003EP, _003CresultSelector_003EP).Run();
		}
	}
	internal sealed class ZipLatest<T1, T2, T3, T4, T5, T6, T7, TResult> : Observable<TResult>
	{
		private sealed class _ZipLatest : IDisposable
		{
			private sealed class ZipLatestObserver<T> : Observer<T>
			{
				private T? value;

				public bool HasValue { get; private set; }

				public bool IsCompleted { get; private set; }

				public ZipLatestObserver(_ZipLatest parent)
				{
					_003Cparent_003EP = parent;
					base._002Ector();
				}

				public T GetValue()
				{
					T? result = value;
					value = default(T);
					HasValue = false;
					return result;
				}

				protected override void OnNextCore(T value)
				{
					lock (_003Cparent_003EP.gate)
					{
						this.value = value;
						HasValue = true;
						_003Cparent_003EP.TryPublishOnNext();
					}
				}

				protected override void OnErrorResumeCore(Exception error)
				{
					_003Cparent_003EP.observer.OnErrorResume(error);
				}

				protected override void OnCompletedCore(Result result)
				{
					lock (_003Cparent_003EP.gate)
					{
						IsCompleted = true;
						_003Cparent_003EP.TryPublishOnCompleted(result, !HasValue);
					}
				}
			}

			private readonly Observer<TResult> observer;

			private readonly Observable<T1> source1;

			private readonly Observable<T2> source2;

			private readonly Observable<T3> source3;

			private readonly Observable<T4> source4;

			private readonly Observable<T5> source5;

			private readonly Observable<T6> source6;

			private readonly Observable<T7> source7;

			private readonly Func<T1, T2, T3, T4, T5, T6, T7, TResult> resultSelector;

			private readonly ZipLatestObserver<T1> observer1;

			private readonly ZipLatestObserver<T2> observer2;

			private readonly ZipLatestObserver<T3> observer3;

			private readonly ZipLatestObserver<T4> observer4;

			private readonly ZipLatestObserver<T5> observer5;

			private readonly ZipLatestObserver<T6> observer6;

			private readonly ZipLatestObserver<T7> observer7;

			private readonly object gate = new object();

			public _ZipLatest(Observer<TResult> observer, Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Func<T1, T2, T3, T4, T5, T6, T7, TResult> resultSelector)
			{
				this.observer = observer;
				this.source1 = source1;
				this.source2 = source2;
				this.source3 = source3;
				this.source4 = source4;
				this.source5 = source5;
				this.source6 = source6;
				this.source7 = source7;
				this.resultSelector = resultSelector;
				observer1 = new ZipLatestObserver<T1>(this);
				observer2 = new ZipLatestObserver<T2>(this);
				observer3 = new ZipLatestObserver<T3>(this);
				observer4 = new ZipLatestObserver<T4>(this);
				observer5 = new ZipLatestObserver<T5>(this);
				observer6 = new ZipLatestObserver<T6>(this);
				observer7 = new ZipLatestObserver<T7>(this);
			}

			public IDisposable Run()
			{
				try
				{
					source1.Subscribe(observer1);
					source2.Subscribe(observer2);
					source3.Subscribe(observer3);
					source4.Subscribe(observer4);
					source5.Subscribe(observer5);
					source6.Subscribe(observer6);
					source7.Subscribe(observer7);
					return this;
				}
				catch
				{
					Dispose();
					throw;
				}
			}

			public void TryPublishOnNext()
			{
				if (observer1.HasValue && observer2.HasValue && observer3.HasValue && observer4.HasValue && observer5.HasValue && observer6.HasValue && observer7.HasValue)
				{
					TResult value = resultSelector(observer1.GetValue(), observer2.GetValue(), observer3.GetValue(), observer4.GetValue(), observer5.GetValue(), observer6.GetValue(), observer7.GetValue());
					observer.OnNext(value);
					if (observer1.IsCompleted || observer2.IsCompleted || observer3.IsCompleted || observer4.IsCompleted || observer5.IsCompleted || observer6.IsCompleted || observer7.IsCompleted)
					{
						observer.OnCompleted();
						Dispose();
					}
				}
			}

			public void TryPublishOnCompleted(Result result, bool empty)
			{
				if (result.IsFailure)
				{
					observer.OnCompleted(result);
					Dispose();
				}
				else if (empty || (observer1.IsCompleted && observer2.IsCompleted && observer3.IsCompleted && observer4.IsCompleted && observer5.IsCompleted && observer6.IsCompleted && observer7.IsCompleted))
				{
					observer.OnCompleted();
					Dispose();
				}
			}

			public void Dispose()
			{
				observer1.Dispose();
				observer2.Dispose();
				observer3.Dispose();
				observer4.Dispose();
				observer5.Dispose();
				observer6.Dispose();
				observer7.Dispose();
			}
		}

		public ZipLatest(Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Func<T1, T2, T3, T4, T5, T6, T7, TResult> resultSelector)
		{
			_003Csource1_003EP = source1;
			_003Csource2_003EP = source2;
			_003Csource3_003EP = source3;
			_003Csource4_003EP = source4;
			_003Csource5_003EP = source5;
			_003Csource6_003EP = source6;
			_003Csource7_003EP = source7;
			_003CresultSelector_003EP = resultSelector;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<TResult> observer)
		{
			return new _ZipLatest(observer, _003Csource1_003EP, _003Csource2_003EP, _003Csource3_003EP, _003Csource4_003EP, _003Csource5_003EP, _003Csource6_003EP, _003Csource7_003EP, _003CresultSelector_003EP).Run();
		}
	}
	internal sealed class ZipLatest<T1, T2, T3, T4, T5, T6, T7, T8, TResult> : Observable<TResult>
	{
		private sealed class _ZipLatest : IDisposable
		{
			private sealed class ZipLatestObserver<T> : Observer<T>
			{
				private T? value;

				public bool HasValue { get; private set; }

				public bool IsCompleted { get; private set; }

				public ZipLatestObserver(_ZipLatest parent)
				{
					_003Cparent_003EP = parent;
					base._002Ector();
				}

				public T GetValue()
				{
					T? result = value;
					value = default(T);
					HasValue = false;
					return result;
				}

				protected override void OnNextCore(T value)
				{
					lock (_003Cparent_003EP.gate)
					{
						this.value = value;
						HasValue = true;
						_003Cparent_003EP.TryPublishOnNext();
					}
				}

				protected override void OnErrorResumeCore(Exception error)
				{
					_003Cparent_003EP.observer.OnErrorResume(error);
				}

				protected override void OnCompletedCore(Result result)
				{
					lock (_003Cparent_003EP.gate)
					{
						IsCompleted = true;
						_003Cparent_003EP.TryPublishOnCompleted(result, !HasValue);
					}
				}
			}

			private readonly Observer<TResult> observer;

			private readonly Observable<T1> source1;

			private readonly Observable<T2> source2;

			private readonly Observable<T3> source3;

			private readonly Observable<T4> source4;

			private readonly Observable<T5> source5;

			private readonly Observable<T6> source6;

			private readonly Observable<T7> source7;

			private readonly Observable<T8> source8;

			private readonly Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> resultSelector;

			private readonly ZipLatestObserver<T1> observer1;

			private readonly ZipLatestObserver<T2> observer2;

			private readonly ZipLatestObserver<T3> observer3;

			private readonly ZipLatestObserver<T4> observer4;

			private readonly ZipLatestObserver<T5> observer5;

			private readonly ZipLatestObserver<T6> observer6;

			private readonly ZipLatestObserver<T7> observer7;

			private readonly ZipLatestObserver<T8> observer8;

			private readonly object gate = new object();

			public _ZipLatest(Observer<TResult> observer, Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> resultSelector)
			{
				this.observer = observer;
				this.source1 = source1;
				this.source2 = source2;
				this.source3 = source3;
				this.source4 = source4;
				this.source5 = source5;
				this.source6 = source6;
				this.source7 = source7;
				this.source8 = source8;
				this.resultSelector = resultSelector;
				observer1 = new ZipLatestObserver<T1>(this);
				observer2 = new ZipLatestObserver<T2>(this);
				observer3 = new ZipLatestObserver<T3>(this);
				observer4 = new ZipLatestObserver<T4>(this);
				observer5 = new ZipLatestObserver<T5>(this);
				observer6 = new ZipLatestObserver<T6>(this);
				observer7 = new ZipLatestObserver<T7>(this);
				observer8 = new ZipLatestObserver<T8>(this);
			}

			public IDisposable Run()
			{
				try
				{
					source1.Subscribe(observer1);
					source2.Subscribe(observer2);
					source3.Subscribe(observer3);
					source4.Subscribe(observer4);
					source5.Subscribe(observer5);
					source6.Subscribe(observer6);
					source7.Subscribe(observer7);
					source8.Subscribe(observer8);
					return this;
				}
				catch
				{
					Dispose();
					throw;
				}
			}

			public void TryPublishOnNext()
			{
				if (observer1.HasValue && observer2.HasValue && observer3.HasValue && observer4.HasValue && observer5.HasValue && observer6.HasValue && observer7.HasValue && observer8.HasValue)
				{
					TResult value = resultSelector(observer1.GetValue(), observer2.GetValue(), observer3.GetValue(), observer4.GetValue(), observer5.GetValue(), observer6.GetValue(), observer7.GetValue(), observer8.GetValue());
					observer.OnNext(value);
					if (observer1.IsCompleted || observer2.IsCompleted || observer3.IsCompleted || observer4.IsCompleted || observer5.IsCompleted || observer6.IsCompleted || observer7.IsCompleted || observer8.IsCompleted)
					{
						observer.OnCompleted();
						Dispose();
					}
				}
			}

			public void TryPublishOnCompleted(Result result, bool empty)
			{
				if (result.IsFailure)
				{
					observer.OnCompleted(result);
					Dispose();
				}
				else if (empty || (observer1.IsCompleted && observer2.IsCompleted && observer3.IsCompleted && observer4.IsCompleted && observer5.IsCompleted && observer6.IsCompleted && observer7.IsCompleted && observer8.IsCompleted))
				{
					observer.OnCompleted();
					Dispose();
				}
			}

			public void Dispose()
			{
				observer1.Dispose();
				observer2.Dispose();
				observer3.Dispose();
				observer4.Dispose();
				observer5.Dispose();
				observer6.Dispose();
				observer7.Dispose();
				observer8.Dispose();
			}
		}

		public ZipLatest(Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> resultSelector)
		{
			_003Csource1_003EP = source1;
			_003Csource2_003EP = source2;
			_003Csource3_003EP = source3;
			_003Csource4_003EP = source4;
			_003Csource5_003EP = source5;
			_003Csource6_003EP = source6;
			_003Csource7_003EP = source7;
			_003Csource8_003EP = source8;
			_003CresultSelector_003EP = resultSelector;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<TResult> observer)
		{
			return new _ZipLatest(observer, _003Csource1_003EP, _003Csource2_003EP, _003Csource3_003EP, _003Csource4_003EP, _003Csource5_003EP, _003Csource6_003EP, _003Csource7_003EP, _003Csource8_003EP, _003CresultSelector_003EP).Run();
		}
	}
	internal sealed class ZipLatest<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> : Observable<TResult>
	{
		private sealed class _ZipLatest : IDisposable
		{
			private sealed class ZipLatestObserver<T> : Observer<T>
			{
				private T? value;

				public bool HasValue { get; private set; }

				public bool IsCompleted { get; private set; }

				public ZipLatestObserver(_ZipLatest parent)
				{
					_003Cparent_003EP = parent;
					base._002Ector();
				}

				public T GetValue()
				{
					T? result = value;
					value = default(T);
					HasValue = false;
					return result;
				}

				protected override void OnNextCore(T value)
				{
					lock (_003Cparent_003EP.gate)
					{
						this.value = value;
						HasValue = true;
						_003Cparent_003EP.TryPublishOnNext();
					}
				}

				protected override void OnErrorResumeCore(Exception error)
				{
					_003Cparent_003EP.observer.OnErrorResume(error);
				}

				protected override void OnCompletedCore(Result result)
				{
					lock (_003Cparent_003EP.gate)
					{
						IsCompleted = true;
						_003Cparent_003EP.TryPublishOnCompleted(result, !HasValue);
					}
				}
			}

			private readonly Observer<TResult> observer;

			private readonly Observable<T1> source1;

			private readonly Observable<T2> source2;

			private readonly Observable<T3> source3;

			private readonly Observable<T4> source4;

			private readonly Observable<T5> source5;

			private readonly Observable<T6> source6;

			private readonly Observable<T7> source7;

			private readonly Observable<T8> source8;

			private readonly Observable<T9> source9;

			private readonly Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> resultSelector;

			private readonly ZipLatestObserver<T1> observer1;

			private readonly ZipLatestObserver<T2> observer2;

			private readonly ZipLatestObserver<T3> observer3;

			private readonly ZipLatestObserver<T4> observer4;

			private readonly ZipLatestObserver<T5> observer5;

			private readonly ZipLatestObserver<T6> observer6;

			private readonly ZipLatestObserver<T7> observer7;

			private readonly ZipLatestObserver<T8> observer8;

			private readonly ZipLatestObserver<T9> observer9;

			private readonly object gate = new object();

			public _ZipLatest(Observer<TResult> observer, Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> resultSelector)
			{
				this.observer = observer;
				this.source1 = source1;
				this.source2 = source2;
				this.source3 = source3;
				this.source4 = source4;
				this.source5 = source5;
				this.source6 = source6;
				this.source7 = source7;
				this.source8 = source8;
				this.source9 = source9;
				this.resultSelector = resultSelector;
				observer1 = new ZipLatestObserver<T1>(this);
				observer2 = new ZipLatestObserver<T2>(this);
				observer3 = new ZipLatestObserver<T3>(this);
				observer4 = new ZipLatestObserver<T4>(this);
				observer5 = new ZipLatestObserver<T5>(this);
				observer6 = new ZipLatestObserver<T6>(this);
				observer7 = new ZipLatestObserver<T7>(this);
				observer8 = new ZipLatestObserver<T8>(this);
				observer9 = new ZipLatestObserver<T9>(this);
			}

			public IDisposable Run()
			{
				try
				{
					source1.Subscribe(observer1);
					source2.Subscribe(observer2);
					source3.Subscribe(observer3);
					source4.Subscribe(observer4);
					source5.Subscribe(observer5);
					source6.Subscribe(observer6);
					source7.Subscribe(observer7);
					source8.Subscribe(observer8);
					source9.Subscribe(observer9);
					return this;
				}
				catch
				{
					Dispose();
					throw;
				}
			}

			public void TryPublishOnNext()
			{
				if (observer1.HasValue && observer2.HasValue && observer3.HasValue && observer4.HasValue && observer5.HasValue && observer6.HasValue && observer7.HasValue && observer8.HasValue && observer9.HasValue)
				{
					TResult value = resultSelector(observer1.GetValue(), observer2.GetValue(), observer3.GetValue(), observer4.GetValue(), observer5.GetValue(), observer6.GetValue(), observer7.GetValue(), observer8.GetValue(), observer9.GetValue());
					observer.OnNext(value);
					if (observer1.IsCompleted || observer2.IsCompleted || observer3.IsCompleted || observer4.IsCompleted || observer5.IsCompleted || observer6.IsCompleted || observer7.IsCompleted || observer8.IsCompleted || observer9.IsCompleted)
					{
						observer.OnCompleted();
						Dispose();
					}
				}
			}

			public void TryPublishOnCompleted(Result result, bool empty)
			{
				if (result.IsFailure)
				{
					observer.OnCompleted(result);
					Dispose();
				}
				else if (empty || (observer1.IsCompleted && observer2.IsCompleted && observer3.IsCompleted && observer4.IsCompleted && observer5.IsCompleted && observer6.IsCompleted && observer7.IsCompleted && observer8.IsCompleted && observer9.IsCompleted))
				{
					observer.OnCompleted();
					Dispose();
				}
			}

			public void Dispose()
			{
				observer1.Dispose();
				observer2.Dispose();
				observer3.Dispose();
				observer4.Dispose();
				observer5.Dispose();
				observer6.Dispose();
				observer7.Dispose();
				observer8.Dispose();
				observer9.Dispose();
			}
		}

		public ZipLatest(Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> resultSelector)
		{
			_003Csource1_003EP = source1;
			_003Csource2_003EP = source2;
			_003Csource3_003EP = source3;
			_003Csource4_003EP = source4;
			_003Csource5_003EP = source5;
			_003Csource6_003EP = source6;
			_003Csource7_003EP = source7;
			_003Csource8_003EP = source8;
			_003Csource9_003EP = source9;
			_003CresultSelector_003EP = resultSelector;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<TResult> observer)
		{
			return new _ZipLatest(observer, _003Csource1_003EP, _003Csource2_003EP, _003Csource3_003EP, _003Csource4_003EP, _003Csource5_003EP, _003Csource6_003EP, _003Csource7_003EP, _003Csource8_003EP, _003Csource9_003EP, _003CresultSelector_003EP).Run();
		}
	}
	internal sealed class ZipLatest<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> : Observable<TResult>
	{
		private sealed class _ZipLatest : IDisposable
		{
			private sealed class ZipLatestObserver<T> : Observer<T>
			{
				private T? value;

				public bool HasValue { get; private set; }

				public bool IsCompleted { get; private set; }

				public ZipLatestObserver(_ZipLatest parent)
				{
					_003Cparent_003EP = parent;
					base._002Ector();
				}

				public T GetValue()
				{
					T? result = value;
					value = default(T);
					HasValue = false;
					return result;
				}

				protected override void OnNextCore(T value)
				{
					lock (_003Cparent_003EP.gate)
					{
						this.value = value;
						HasValue = true;
						_003Cparent_003EP.TryPublishOnNext();
					}
				}

				protected override void OnErrorResumeCore(Exception error)
				{
					_003Cparent_003EP.observer.OnErrorResume(error);
				}

				protected override void OnCompletedCore(Result result)
				{
					lock (_003Cparent_003EP.gate)
					{
						IsCompleted = true;
						_003Cparent_003EP.TryPublishOnCompleted(result, !HasValue);
					}
				}
			}

			private readonly Observer<TResult> observer;

			private readonly Observable<T1> source1;

			private readonly Observable<T2> source2;

			private readonly Observable<T3> source3;

			private readonly Observable<T4> source4;

			private readonly Observable<T5> source5;

			private readonly Observable<T6> source6;

			private readonly Observable<T7> source7;

			private readonly Observable<T8> source8;

			private readonly Observable<T9> source9;

			private readonly Observable<T10> source10;

			private readonly Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> resultSelector;

			private readonly ZipLatestObserver<T1> observer1;

			private readonly ZipLatestObserver<T2> observer2;

			private readonly ZipLatestObserver<T3> observer3;

			private readonly ZipLatestObserver<T4> observer4;

			private readonly ZipLatestObserver<T5> observer5;

			private readonly ZipLatestObserver<T6> observer6;

			private readonly ZipLatestObserver<T7> observer7;

			private readonly ZipLatestObserver<T8> observer8;

			private readonly ZipLatestObserver<T9> observer9;

			private readonly ZipLatestObserver<T10> observer10;

			private readonly object gate = new object();

			public _ZipLatest(Observer<TResult> observer, Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> resultSelector)
			{
				this.observer = observer;
				this.source1 = source1;
				this.source2 = source2;
				this.source3 = source3;
				this.source4 = source4;
				this.source5 = source5;
				this.source6 = source6;
				this.source7 = source7;
				this.source8 = source8;
				this.source9 = source9;
				this.source10 = source10;
				this.resultSelector = resultSelector;
				observer1 = new ZipLatestObserver<T1>(this);
				observer2 = new ZipLatestObserver<T2>(this);
				observer3 = new ZipLatestObserver<T3>(this);
				observer4 = new ZipLatestObserver<T4>(this);
				observer5 = new ZipLatestObserver<T5>(this);
				observer6 = new ZipLatestObserver<T6>(this);
				observer7 = new ZipLatestObserver<T7>(this);
				observer8 = new ZipLatestObserver<T8>(this);
				observer9 = new ZipLatestObserver<T9>(this);
				observer10 = new ZipLatestObserver<T10>(this);
			}

			public IDisposable Run()
			{
				try
				{
					source1.Subscribe(observer1);
					source2.Subscribe(observer2);
					source3.Subscribe(observer3);
					source4.Subscribe(observer4);
					source5.Subscribe(observer5);
					source6.Subscribe(observer6);
					source7.Subscribe(observer7);
					source8.Subscribe(observer8);
					source9.Subscribe(observer9);
					source10.Subscribe(observer10);
					return this;
				}
				catch
				{
					Dispose();
					throw;
				}
			}

			public void TryPublishOnNext()
			{
				if (observer1.HasValue && observer2.HasValue && observer3.HasValue && observer4.HasValue && observer5.HasValue && observer6.HasValue && observer7.HasValue && observer8.HasValue && observer9.HasValue && observer10.HasValue)
				{
					TResult value = resultSelector(observer1.GetValue(), observer2.GetValue(), observer3.GetValue(), observer4.GetValue(), observer5.GetValue(), observer6.GetValue(), observer7.GetValue(), observer8.GetValue(), observer9.GetValue(), observer10.GetValue());
					observer.OnNext(value);
					if (observer1.IsCompleted || observer2.IsCompleted || observer3.IsCompleted || observer4.IsCompleted || observer5.IsCompleted || observer6.IsCompleted || observer7.IsCompleted || observer8.IsCompleted || observer9.IsCompleted || observer10.IsCompleted)
					{
						observer.OnCompleted();
						Dispose();
					}
				}
			}

			public void TryPublishOnCompleted(Result result, bool empty)
			{
				if (result.IsFailure)
				{
					observer.OnCompleted(result);
					Dispose();
				}
				else if (empty || (observer1.IsCompleted && observer2.IsCompleted && observer3.IsCompleted && observer4.IsCompleted && observer5.IsCompleted && observer6.IsCompleted && observer7.IsCompleted && observer8.IsCompleted && observer9.IsCompleted && observer10.IsCompleted))
				{
					observer.OnCompleted();
					Dispose();
				}
			}

			public void Dispose()
			{
				observer1.Dispose();
				observer2.Dispose();
				observer3.Dispose();
				observer4.Dispose();
				observer5.Dispose();
				observer6.Dispose();
				observer7.Dispose();
				observer8.Dispose();
				observer9.Dispose();
				observer10.Dispose();
			}
		}

		public ZipLatest(Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> resultSelector)
		{
			_003Csource1_003EP = source1;
			_003Csource2_003EP = source2;
			_003Csource3_003EP = source3;
			_003Csource4_003EP = source4;
			_003Csource5_003EP = source5;
			_003Csource6_003EP = source6;
			_003Csource7_003EP = source7;
			_003Csource8_003EP = source8;
			_003Csource9_003EP = source9;
			_003Csource10_003EP = source10;
			_003CresultSelector_003EP = resultSelector;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<TResult> observer)
		{
			return new _ZipLatest(observer, _003Csource1_003EP, _003Csource2_003EP, _003Csource3_003EP, _003Csource4_003EP, _003Csource5_003EP, _003Csource6_003EP, _003Csource7_003EP, _003Csource8_003EP, _003Csource9_003EP, _003Csource10_003EP, _003CresultSelector_003EP).Run();
		}
	}
	internal sealed class ZipLatest<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> : Observable<TResult>
	{
		private sealed class _ZipLatest : IDisposable
		{
			private sealed class ZipLatestObserver<T> : Observer<T>
			{
				private T? value;

				public bool HasValue { get; private set; }

				public bool IsCompleted { get; private set; }

				public ZipLatestObserver(_ZipLatest parent)
				{
					_003Cparent_003EP = parent;
					base._002Ector();
				}

				public T GetValue()
				{
					T? result = value;
					value = default(T);
					HasValue = false;
					return result;
				}

				protected override void OnNextCore(T value)
				{
					lock (_003Cparent_003EP.gate)
					{
						this.value = value;
						HasValue = true;
						_003Cparent_003EP.TryPublishOnNext();
					}
				}

				protected override void OnErrorResumeCore(Exception error)
				{
					_003Cparent_003EP.observer.OnErrorResume(error);
				}

				protected override void OnCompletedCore(Result result)
				{
					lock (_003Cparent_003EP.gate)
					{
						IsCompleted = true;
						_003Cparent_003EP.TryPublishOnCompleted(result, !HasValue);
					}
				}
			}

			private readonly Observer<TResult> observer;

			private readonly Observable<T1> source1;

			private readonly Observable<T2> source2;

			private readonly Observable<T3> source3;

			private readonly Observable<T4> source4;

			private readonly Observable<T5> source5;

			private readonly Observable<T6> source6;

			private readonly Observable<T7> source7;

			private readonly Observable<T8> source8;

			private readonly Observable<T9> source9;

			private readonly Observable<T10> source10;

			private readonly Observable<T11> source11;

			private readonly Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> resultSelector;

			private readonly ZipLatestObserver<T1> observer1;

			private readonly ZipLatestObserver<T2> observer2;

			private readonly ZipLatestObserver<T3> observer3;

			private readonly ZipLatestObserver<T4> observer4;

			private readonly ZipLatestObserver<T5> observer5;

			private readonly ZipLatestObserver<T6> observer6;

			private readonly ZipLatestObserver<T7> observer7;

			private readonly ZipLatestObserver<T8> observer8;

			private readonly ZipLatestObserver<T9> observer9;

			private readonly ZipLatestObserver<T10> observer10;

			private readonly ZipLatestObserver<T11> observer11;

			private readonly object gate = new object();

			public _ZipLatest(Observer<TResult> observer, Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Observable<T11> source11, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> resultSelector)
			{
				this.observer = observer;
				this.source1 = source1;
				this.source2 = source2;
				this.source3 = source3;
				this.source4 = source4;
				this.source5 = source5;
				this.source6 = source6;
				this.source7 = source7;
				this.source8 = source8;
				this.source9 = source9;
				this.source10 = source10;
				this.source11 = source11;
				this.resultSelector = resultSelector;
				observer1 = new ZipLatestObserver<T1>(this);
				observer2 = new ZipLatestObserver<T2>(this);
				observer3 = new ZipLatestObserver<T3>(this);
				observer4 = new ZipLatestObserver<T4>(this);
				observer5 = new ZipLatestObserver<T5>(this);
				observer6 = new ZipLatestObserver<T6>(this);
				observer7 = new ZipLatestObserver<T7>(this);
				observer8 = new ZipLatestObserver<T8>(this);
				observer9 = new ZipLatestObserver<T9>(this);
				observer10 = new ZipLatestObserver<T10>(this);
				observer11 = new ZipLatestObserver<T11>(this);
			}

			public IDisposable Run()
			{
				try
				{
					source1.Subscribe(observer1);
					source2.Subscribe(observer2);
					source3.Subscribe(observer3);
					source4.Subscribe(observer4);
					source5.Subscribe(observer5);
					source6.Subscribe(observer6);
					source7.Subscribe(observer7);
					source8.Subscribe(observer8);
					source9.Subscribe(observer9);
					source10.Subscribe(observer10);
					source11.Subscribe(observer11);
					return this;
				}
				catch
				{
					Dispose();
					throw;
				}
			}

			public void TryPublishOnNext()
			{
				if (observer1.HasValue && observer2.HasValue && observer3.HasValue && observer4.HasValue && observer5.HasValue && observer6.HasValue && observer7.HasValue && observer8.HasValue && observer9.HasValue && observer10.HasValue && observer11.HasValue)
				{
					TResult value = resultSelector(observer1.GetValue(), observer2.GetValue(), observer3.GetValue(), observer4.GetValue(), observer5.GetValue(), observer6.GetValue(), observer7.GetValue(), observer8.GetValue(), observer9.GetValue(), observer10.GetValue(), observer11.GetValue());
					observer.OnNext(value);
					if (observer1.IsCompleted || observer2.IsCompleted || observer3.IsCompleted || observer4.IsCompleted || observer5.IsCompleted || observer6.IsCompleted || observer7.IsCompleted || observer8.IsCompleted || observer9.IsCompleted || observer10.IsCompleted || observer11.IsCompleted)
					{
						observer.OnCompleted();
						Dispose();
					}
				}
			}

			public void TryPublishOnCompleted(Result result, bool empty)
			{
				if (result.IsFailure)
				{
					observer.OnCompleted(result);
					Dispose();
				}
				else if (empty || (observer1.IsCompleted && observer2.IsCompleted && observer3.IsCompleted && observer4.IsCompleted && observer5.IsCompleted && observer6.IsCompleted && observer7.IsCompleted && observer8.IsCompleted && observer9.IsCompleted && observer10.IsCompleted && observer11.IsCompleted))
				{
					observer.OnCompleted();
					Dispose();
				}
			}

			public void Dispose()
			{
				observer1.Dispose();
				observer2.Dispose();
				observer3.Dispose();
				observer4.Dispose();
				observer5.Dispose();
				observer6.Dispose();
				observer7.Dispose();
				observer8.Dispose();
				observer9.Dispose();
				observer10.Dispose();
				observer11.Dispose();
			}
		}

		public ZipLatest(Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Observable<T11> source11, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> resultSelector)
		{
			_003Csource1_003EP = source1;
			_003Csource2_003EP = source2;
			_003Csource3_003EP = source3;
			_003Csource4_003EP = source4;
			_003Csource5_003EP = source5;
			_003Csource6_003EP = source6;
			_003Csource7_003EP = source7;
			_003Csource8_003EP = source8;
			_003Csource9_003EP = source9;
			_003Csource10_003EP = source10;
			_003Csource11_003EP = source11;
			_003CresultSelector_003EP = resultSelector;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<TResult> observer)
		{
			return new _ZipLatest(observer, _003Csource1_003EP, _003Csource2_003EP, _003Csource3_003EP, _003Csource4_003EP, _003Csource5_003EP, _003Csource6_003EP, _003Csource7_003EP, _003Csource8_003EP, _003Csource9_003EP, _003Csource10_003EP, _003Csource11_003EP, _003CresultSelector_003EP).Run();
		}
	}
	internal sealed class ZipLatest<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> : Observable<TResult>
	{
		private sealed class _ZipLatest : IDisposable
		{
			private sealed class ZipLatestObserver<T> : Observer<T>
			{
				private T? value;

				public bool HasValue { get; private set; }

				public bool IsCompleted { get; private set; }

				public ZipLatestObserver(_ZipLatest parent)
				{
					_003Cparent_003EP = parent;
					base._002Ector();
				}

				public T GetValue()
				{
					T? result = value;
					value = default(T);
					HasValue = false;
					return result;
				}

				protected override void OnNextCore(T value)
				{
					lock (_003Cparent_003EP.gate)
					{
						this.value = value;
						HasValue = true;
						_003Cparent_003EP.TryPublishOnNext();
					}
				}

				protected override void OnErrorResumeCore(Exception error)
				{
					_003Cparent_003EP.observer.OnErrorResume(error);
				}

				protected override void OnCompletedCore(Result result)
				{
					lock (_003Cparent_003EP.gate)
					{
						IsCompleted = true;
						_003Cparent_003EP.TryPublishOnCompleted(result, !HasValue);
					}
				}
			}

			private readonly Observer<TResult> observer;

			private readonly Observable<T1> source1;

			private readonly Observable<T2> source2;

			private readonly Observable<T3> source3;

			private readonly Observable<T4> source4;

			private readonly Observable<T5> source5;

			private readonly Observable<T6> source6;

			private readonly Observable<T7> source7;

			private readonly Observable<T8> source8;

			private readonly Observable<T9> source9;

			private readonly Observable<T10> source10;

			private readonly Observable<T11> source11;

			private readonly Observable<T12> source12;

			private readonly Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> resultSelector;

			private readonly ZipLatestObserver<T1> observer1;

			private readonly ZipLatestObserver<T2> observer2;

			private readonly ZipLatestObserver<T3> observer3;

			private readonly ZipLatestObserver<T4> observer4;

			private readonly ZipLatestObserver<T5> observer5;

			private readonly ZipLatestObserver<T6> observer6;

			private readonly ZipLatestObserver<T7> observer7;

			private readonly ZipLatestObserver<T8> observer8;

			private readonly ZipLatestObserver<T9> observer9;

			private readonly ZipLatestObserver<T10> observer10;

			private readonly ZipLatestObserver<T11> observer11;

			private readonly ZipLatestObserver<T12> observer12;

			private readonly object gate = new object();

			public _ZipLatest(Observer<TResult> observer, Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Observable<T11> source11, Observable<T12> source12, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> resultSelector)
			{
				this.observer = observer;
				this.source1 = source1;
				this.source2 = source2;
				this.source3 = source3;
				this.source4 = source4;
				this.source5 = source5;
				this.source6 = source6;
				this.source7 = source7;
				this.source8 = source8;
				this.source9 = source9;
				this.source10 = source10;
				this.source11 = source11;
				this.source12 = source12;
				this.resultSelector = resultSelector;
				observer1 = new ZipLatestObserver<T1>(this);
				observer2 = new ZipLatestObserver<T2>(this);
				observer3 = new ZipLatestObserver<T3>(this);
				observer4 = new ZipLatestObserver<T4>(this);
				observer5 = new ZipLatestObserver<T5>(this);
				observer6 = new ZipLatestObserver<T6>(this);
				observer7 = new ZipLatestObserver<T7>(this);
				observer8 = new ZipLatestObserver<T8>(this);
				observer9 = new ZipLatestObserver<T9>(this);
				observer10 = new ZipLatestObserver<T10>(this);
				observer11 = new ZipLatestObserver<T11>(this);
				observer12 = new ZipLatestObserver<T12>(this);
			}

			public IDisposable Run()
			{
				try
				{
					source1.Subscribe(observer1);
					source2.Subscribe(observer2);
					source3.Subscribe(observer3);
					source4.Subscribe(observer4);
					source5.Subscribe(observer5);
					source6.Subscribe(observer6);
					source7.Subscribe(observer7);
					source8.Subscribe(observer8);
					source9.Subscribe(observer9);
					source10.Subscribe(observer10);
					source11.Subscribe(observer11);
					source12.Subscribe(observer12);
					return this;
				}
				catch
				{
					Dispose();
					throw;
				}
			}

			public void TryPublishOnNext()
			{
				if (observer1.HasValue && observer2.HasValue && observer3.HasValue && observer4.HasValue && observer5.HasValue && observer6.HasValue && observer7.HasValue && observer8.HasValue && observer9.HasValue && observer10.HasValue && observer11.HasValue && observer12.HasValue)
				{
					TResult value = resultSelector(observer1.GetValue(), observer2.GetValue(), observer3.GetValue(), observer4.GetValue(), observer5.GetValue(), observer6.GetValue(), observer7.GetValue(), observer8.GetValue(), observer9.GetValue(), observer10.GetValue(), observer11.GetValue(), observer12.GetValue());
					observer.OnNext(value);
					if (observer1.IsCompleted || observer2.IsCompleted || observer3.IsCompleted || observer4.IsCompleted || observer5.IsCompleted || observer6.IsCompleted || observer7.IsCompleted || observer8.IsCompleted || observer9.IsCompleted || observer10.IsCompleted || observer11.IsCompleted || observer12.IsCompleted)
					{
						observer.OnCompleted();
						Dispose();
					}
				}
			}

			public void TryPublishOnCompleted(Result result, bool empty)
			{
				if (result.IsFailure)
				{
					observer.OnCompleted(result);
					Dispose();
				}
				else if (empty || (observer1.IsCompleted && observer2.IsCompleted && observer3.IsCompleted && observer4.IsCompleted && observer5.IsCompleted && observer6.IsCompleted && observer7.IsCompleted && observer8.IsCompleted && observer9.IsCompleted && observer10.IsCompleted && observer11.IsCompleted && observer12.IsCompleted))
				{
					observer.OnCompleted();
					Dispose();
				}
			}

			public void Dispose()
			{
				observer1.Dispose();
				observer2.Dispose();
				observer3.Dispose();
				observer4.Dispose();
				observer5.Dispose();
				observer6.Dispose();
				observer7.Dispose();
				observer8.Dispose();
				observer9.Dispose();
				observer10.Dispose();
				observer11.Dispose();
				observer12.Dispose();
			}
		}

		public ZipLatest(Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Observable<T11> source11, Observable<T12> source12, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> resultSelector)
		{
			_003Csource1_003EP = source1;
			_003Csource2_003EP = source2;
			_003Csource3_003EP = source3;
			_003Csource4_003EP = source4;
			_003Csource5_003EP = source5;
			_003Csource6_003EP = source6;
			_003Csource7_003EP = source7;
			_003Csource8_003EP = source8;
			_003Csource9_003EP = source9;
			_003Csource10_003EP = source10;
			_003Csource11_003EP = source11;
			_003Csource12_003EP = source12;
			_003CresultSelector_003EP = resultSelector;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<TResult> observer)
		{
			return new _ZipLatest(observer, _003Csource1_003EP, _003Csource2_003EP, _003Csource3_003EP, _003Csource4_003EP, _003Csource5_003EP, _003Csource6_003EP, _003Csource7_003EP, _003Csource8_003EP, _003Csource9_003EP, _003Csource10_003EP, _003Csource11_003EP, _003Csource12_003EP, _003CresultSelector_003EP).Run();
		}
	}
	internal sealed class ZipLatest<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> : Observable<TResult>
	{
		private sealed class _ZipLatest : IDisposable
		{
			private sealed class ZipLatestObserver<T> : Observer<T>
			{
				private T? value;

				public bool HasValue { get; private set; }

				public bool IsCompleted { get; private set; }

				public ZipLatestObserver(_ZipLatest parent)
				{
					_003Cparent_003EP = parent;
					base._002Ector();
				}

				public T GetValue()
				{
					T? result = value;
					value = default(T);
					HasValue = false;
					return result;
				}

				protected override void OnNextCore(T value)
				{
					lock (_003Cparent_003EP.gate)
					{
						this.value = value;
						HasValue = true;
						_003Cparent_003EP.TryPublishOnNext();
					}
				}

				protected override void OnErrorResumeCore(Exception error)
				{
					_003Cparent_003EP.observer.OnErrorResume(error);
				}

				protected override void OnCompletedCore(Result result)
				{
					lock (_003Cparent_003EP.gate)
					{
						IsCompleted = true;
						_003Cparent_003EP.TryPublishOnCompleted(result, !HasValue);
					}
				}
			}

			private readonly Observer<TResult> observer;

			private readonly Observable<T1> source1;

			private readonly Observable<T2> source2;

			private readonly Observable<T3> source3;

			private readonly Observable<T4> source4;

			private readonly Observable<T5> source5;

			private readonly Observable<T6> source6;

			private readonly Observable<T7> source7;

			private readonly Observable<T8> source8;

			private readonly Observable<T9> source9;

			private readonly Observable<T10> source10;

			private readonly Observable<T11> source11;

			private readonly Observable<T12> source12;

			private readonly Observable<T13> source13;

			private readonly Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> resultSelector;

			private readonly ZipLatestObserver<T1> observer1;

			private readonly ZipLatestObserver<T2> observer2;

			private readonly ZipLatestObserver<T3> observer3;

			private readonly ZipLatestObserver<T4> observer4;

			private readonly ZipLatestObserver<T5> observer5;

			private readonly ZipLatestObserver<T6> observer6;

			private readonly ZipLatestObserver<T7> observer7;

			private readonly ZipLatestObserver<T8> observer8;

			private readonly ZipLatestObserver<T9> observer9;

			private readonly ZipLatestObserver<T10> observer10;

			private readonly ZipLatestObserver<T11> observer11;

			private readonly ZipLatestObserver<T12> observer12;

			private readonly ZipLatestObserver<T13> observer13;

			private readonly object gate = new object();

			public _ZipLatest(Observer<TResult> observer, Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Observable<T11> source11, Observable<T12> source12, Observable<T13> source13, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> resultSelector)
			{
				this.observer = observer;
				this.source1 = source1;
				this.source2 = source2;
				this.source3 = source3;
				this.source4 = source4;
				this.source5 = source5;
				this.source6 = source6;
				this.source7 = source7;
				this.source8 = source8;
				this.source9 = source9;
				this.source10 = source10;
				this.source11 = source11;
				this.source12 = source12;
				this.source13 = source13;
				this.resultSelector = resultSelector;
				observer1 = new ZipLatestObserver<T1>(this);
				observer2 = new ZipLatestObserver<T2>(this);
				observer3 = new ZipLatestObserver<T3>(this);
				observer4 = new ZipLatestObserver<T4>(this);
				observer5 = new ZipLatestObserver<T5>(this);
				observer6 = new ZipLatestObserver<T6>(this);
				observer7 = new ZipLatestObserver<T7>(this);
				observer8 = new ZipLatestObserver<T8>(this);
				observer9 = new ZipLatestObserver<T9>(this);
				observer10 = new ZipLatestObserver<T10>(this);
				observer11 = new ZipLatestObserver<T11>(this);
				observer12 = new ZipLatestObserver<T12>(this);
				observer13 = new ZipLatestObserver<T13>(this);
			}

			public IDisposable Run()
			{
				try
				{
					source1.Subscribe(observer1);
					source2.Subscribe(observer2);
					source3.Subscribe(observer3);
					source4.Subscribe(observer4);
					source5.Subscribe(observer5);
					source6.Subscribe(observer6);
					source7.Subscribe(observer7);
					source8.Subscribe(observer8);
					source9.Subscribe(observer9);
					source10.Subscribe(observer10);
					source11.Subscribe(observer11);
					source12.Subscribe(observer12);
					source13.Subscribe(observer13);
					return this;
				}
				catch
				{
					Dispose();
					throw;
				}
			}

			public void TryPublishOnNext()
			{
				if (observer1.HasValue && observer2.HasValue && observer3.HasValue && observer4.HasValue && observer5.HasValue && observer6.HasValue && observer7.HasValue && observer8.HasValue && observer9.HasValue && observer10.HasValue && observer11.HasValue && observer12.HasValue && observer13.HasValue)
				{
					TResult value = resultSelector(observer1.GetValue(), observer2.GetValue(), observer3.GetValue(), observer4.GetValue(), observer5.GetValue(), observer6.GetValue(), observer7.GetValue(), observer8.GetValue(), observer9.GetValue(), observer10.GetValue(), observer11.GetValue(), observer12.GetValue(), observer13.GetValue());
					observer.OnNext(value);
					if (observer1.IsCompleted || observer2.IsCompleted || observer3.IsCompleted || observer4.IsCompleted || observer5.IsCompleted || observer6.IsCompleted || observer7.IsCompleted || observer8.IsCompleted || observer9.IsCompleted || observer10.IsCompleted || observer11.IsCompleted || observer12.IsCompleted || observer13.IsCompleted)
					{
						observer.OnCompleted();
						Dispose();
					}
				}
			}

			public void TryPublishOnCompleted(Result result, bool empty)
			{
				if (result.IsFailure)
				{
					observer.OnCompleted(result);
					Dispose();
				}
				else if (empty || (observer1.IsCompleted && observer2.IsCompleted && observer3.IsCompleted && observer4.IsCompleted && observer5.IsCompleted && observer6.IsCompleted && observer7.IsCompleted && observer8.IsCompleted && observer9.IsCompleted && observer10.IsCompleted && observer11.IsCompleted && observer12.IsCompleted && observer13.IsCompleted))
				{
					observer.OnCompleted();
					Dispose();
				}
			}

			public void Dispose()
			{
				observer1.Dispose();
				observer2.Dispose();
				observer3.Dispose();
				observer4.Dispose();
				observer5.Dispose();
				observer6.Dispose();
				observer7.Dispose();
				observer8.Dispose();
				observer9.Dispose();
				observer10.Dispose();
				observer11.Dispose();
				observer12.Dispose();
				observer13.Dispose();
			}
		}

		public ZipLatest(Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Observable<T11> source11, Observable<T12> source12, Observable<T13> source13, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> resultSelector)
		{
			_003Csource1_003EP = source1;
			_003Csource2_003EP = source2;
			_003Csource3_003EP = source3;
			_003Csource4_003EP = source4;
			_003Csource5_003EP = source5;
			_003Csource6_003EP = source6;
			_003Csource7_003EP = source7;
			_003Csource8_003EP = source8;
			_003Csource9_003EP = source9;
			_003Csource10_003EP = source10;
			_003Csource11_003EP = source11;
			_003Csource12_003EP = source12;
			_003Csource13_003EP = source13;
			_003CresultSelector_003EP = resultSelector;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<TResult> observer)
		{
			return new _ZipLatest(observer, _003Csource1_003EP, _003Csource2_003EP, _003Csource3_003EP, _003Csource4_003EP, _003Csource5_003EP, _003Csource6_003EP, _003Csource7_003EP, _003Csource8_003EP, _003Csource9_003EP, _003Csource10_003EP, _003Csource11_003EP, _003Csource12_003EP, _003Csource13_003EP, _003CresultSelector_003EP).Run();
		}
	}
	internal sealed class ZipLatest<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> : Observable<TResult>
	{
		private sealed class _ZipLatest : IDisposable
		{
			private sealed class ZipLatestObserver<T> : Observer<T>
			{
				private T? value;

				public bool HasValue { get; private set; }

				public bool IsCompleted { get; private set; }

				public ZipLatestObserver(_ZipLatest parent)
				{
					_003Cparent_003EP = parent;
					base._002Ector();
				}

				public T GetValue()
				{
					T? result = value;
					value = default(T);
					HasValue = false;
					return result;
				}

				protected override void OnNextCore(T value)
				{
					lock (_003Cparent_003EP.gate)
					{
						this.value = value;
						HasValue = true;
						_003Cparent_003EP.TryPublishOnNext();
					}
				}

				protected override void OnErrorResumeCore(Exception error)
				{
					_003Cparent_003EP.observer.OnErrorResume(error);
				}

				protected override void OnCompletedCore(Result result)
				{
					lock (_003Cparent_003EP.gate)
					{
						IsCompleted = true;
						_003Cparent_003EP.TryPublishOnCompleted(result, !HasValue);
					}
				}
			}

			private readonly Observer<TResult> observer;

			private readonly Observable<T1> source1;

			private readonly Observable<T2> source2;

			private readonly Observable<T3> source3;

			private readonly Observable<T4> source4;

			private readonly Observable<T5> source5;

			private readonly Observable<T6> source6;

			private readonly Observable<T7> source7;

			private readonly Observable<T8> source8;

			private readonly Observable<T9> source9;

			private readonly Observable<T10> source10;

			private readonly Observable<T11> source11;

			private readonly Observable<T12> source12;

			private readonly Observable<T13> source13;

			private readonly Observable<T14> source14;

			private readonly Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> resultSelector;

			private readonly ZipLatestObserver<T1> observer1;

			private readonly ZipLatestObserver<T2> observer2;

			private readonly ZipLatestObserver<T3> observer3;

			private readonly ZipLatestObserver<T4> observer4;

			private readonly ZipLatestObserver<T5> observer5;

			private readonly ZipLatestObserver<T6> observer6;

			private readonly ZipLatestObserver<T7> observer7;

			private readonly ZipLatestObserver<T8> observer8;

			private readonly ZipLatestObserver<T9> observer9;

			private readonly ZipLatestObserver<T10> observer10;

			private readonly ZipLatestObserver<T11> observer11;

			private readonly ZipLatestObserver<T12> observer12;

			private readonly ZipLatestObserver<T13> observer13;

			private readonly ZipLatestObserver<T14> observer14;

			private readonly object gate = new object();

			public _ZipLatest(Observer<TResult> observer, Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Observable<T11> source11, Observable<T12> source12, Observable<T13> source13, Observable<T14> source14, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> resultSelector)
			{
				this.observer = observer;
				this.source1 = source1;
				this.source2 = source2;
				this.source3 = source3;
				this.source4 = source4;
				this.source5 = source5;
				this.source6 = source6;
				this.source7 = source7;
				this.source8 = source8;
				this.source9 = source9;
				this.source10 = source10;
				this.source11 = source11;
				this.source12 = source12;
				this.source13 = source13;
				this.source14 = source14;
				this.resultSelector = resultSelector;
				observer1 = new ZipLatestObserver<T1>(this);
				observer2 = new ZipLatestObserver<T2>(this);
				observer3 = new ZipLatestObserver<T3>(this);
				observer4 = new ZipLatestObserver<T4>(this);
				observer5 = new ZipLatestObserver<T5>(this);
				observer6 = new ZipLatestObserver<T6>(this);
				observer7 = new ZipLatestObserver<T7>(this);
				observer8 = new ZipLatestObserver<T8>(this);
				observer9 = new ZipLatestObserver<T9>(this);
				observer10 = new ZipLatestObserver<T10>(this);
				observer11 = new ZipLatestObserver<T11>(this);
				observer12 = new ZipLatestObserver<T12>(this);
				observer13 = new ZipLatestObserver<T13>(this);
				observer14 = new ZipLatestObserver<T14>(this);
			}

			public IDisposable Run()
			{
				try
				{
					source1.Subscribe(observer1);
					source2.Subscribe(observer2);
					source3.Subscribe(observer3);
					source4.Subscribe(observer4);
					source5.Subscribe(observer5);
					source6.Subscribe(observer6);
					source7.Subscribe(observer7);
					source8.Subscribe(observer8);
					source9.Subscribe(observer9);
					source10.Subscribe(observer10);
					source11.Subscribe(observer11);
					source12.Subscribe(observer12);
					source13.Subscribe(observer13);
					source14.Subscribe(observer14);
					return this;
				}
				catch
				{
					Dispose();
					throw;
				}
			}

			public void TryPublishOnNext()
			{
				if (observer1.HasValue && observer2.HasValue && observer3.HasValue && observer4.HasValue && observer5.HasValue && observer6.HasValue && observer7.HasValue && observer8.HasValue && observer9.HasValue && observer10.HasValue && observer11.HasValue && observer12.HasValue && observer13.HasValue && observer14.HasValue)
				{
					TResult value = resultSelector(observer1.GetValue(), observer2.GetValue(), observer3.GetValue(), observer4.GetValue(), observer5.GetValue(), observer6.GetValue(), observer7.GetValue(), observer8.GetValue(), observer9.GetValue(), observer10.GetValue(), observer11.GetValue(), observer12.GetValue(), observer13.GetValue(), observer14.GetValue());
					observer.OnNext(value);
					if (observer1.IsCompleted || observer2.IsCompleted || observer3.IsCompleted || observer4.IsCompleted || observer5.IsCompleted || observer6.IsCompleted || observer7.IsCompleted || observer8.IsCompleted || observer9.IsCompleted || observer10.IsCompleted || observer11.IsCompleted || observer12.IsCompleted || observer13.IsCompleted || observer14.IsCompleted)
					{
						observer.OnCompleted();
						Dispose();
					}
				}
			}

			public void TryPublishOnCompleted(Result result, bool empty)
			{
				if (result.IsFailure)
				{
					observer.OnCompleted(result);
					Dispose();
				}
				else if (empty || (observer1.IsCompleted && observer2.IsCompleted && observer3.IsCompleted && observer4.IsCompleted && observer5.IsCompleted && observer6.IsCompleted && observer7.IsCompleted && observer8.IsCompleted && observer9.IsCompleted && observer10.IsCompleted && observer11.IsCompleted && observer12.IsCompleted && observer13.IsCompleted && observer14.IsCompleted))
				{
					observer.OnCompleted();
					Dispose();
				}
			}

			public void Dispose()
			{
				observer1.Dispose();
				observer2.Dispose();
				observer3.Dispose();
				observer4.Dispose();
				observer5.Dispose();
				observer6.Dispose();
				observer7.Dispose();
				observer8.Dispose();
				observer9.Dispose();
				observer10.Dispose();
				observer11.Dispose();
				observer12.Dispose();
				observer13.Dispose();
				observer14.Dispose();
			}
		}

		public ZipLatest(Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Observable<T11> source11, Observable<T12> source12, Observable<T13> source13, Observable<T14> source14, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> resultSelector)
		{
			_003Csource1_003EP = source1;
			_003Csource2_003EP = source2;
			_003Csource3_003EP = source3;
			_003Csource4_003EP = source4;
			_003Csource5_003EP = source5;
			_003Csource6_003EP = source6;
			_003Csource7_003EP = source7;
			_003Csource8_003EP = source8;
			_003Csource9_003EP = source9;
			_003Csource10_003EP = source10;
			_003Csource11_003EP = source11;
			_003Csource12_003EP = source12;
			_003Csource13_003EP = source13;
			_003Csource14_003EP = source14;
			_003CresultSelector_003EP = resultSelector;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<TResult> observer)
		{
			return new _ZipLatest(observer, _003Csource1_003EP, _003Csource2_003EP, _003Csource3_003EP, _003Csource4_003EP, _003Csource5_003EP, _003Csource6_003EP, _003Csource7_003EP, _003Csource8_003EP, _003Csource9_003EP, _003Csource10_003EP, _003Csource11_003EP, _003Csource12_003EP, _003Csource13_003EP, _003Csource14_003EP, _003CresultSelector_003EP).Run();
		}
	}
	internal sealed class ZipLatest<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> : Observable<TResult>
	{
		private sealed class _ZipLatest : IDisposable
		{
			private sealed class ZipLatestObserver<T> : Observer<T>
			{
				private T? value;

				public bool HasValue { get; private set; }

				public bool IsCompleted { get; private set; }

				public ZipLatestObserver(_ZipLatest parent)
				{
					_003Cparent_003EP = parent;
					base._002Ector();
				}

				public T GetValue()
				{
					T? result = value;
					value = default(T);
					HasValue = false;
					return result;
				}

				protected override void OnNextCore(T value)
				{
					lock (_003Cparent_003EP.gate)
					{
						this.value = value;
						HasValue = true;
						_003Cparent_003EP.TryPublishOnNext();
					}
				}

				protected override void OnErrorResumeCore(Exception error)
				{
					_003Cparent_003EP.observer.OnErrorResume(error);
				}

				protected override void OnCompletedCore(Result result)
				{
					lock (_003Cparent_003EP.gate)
					{
						IsCompleted = true;
						_003Cparent_003EP.TryPublishOnCompleted(result, !HasValue);
					}
				}
			}

			private readonly Observer<TResult> observer;

			private readonly Observable<T1> source1;

			private readonly Observable<T2> source2;

			private readonly Observable<T3> source3;

			private readonly Observable<T4> source4;

			private readonly Observable<T5> source5;

			private readonly Observable<T6> source6;

			private readonly Observable<T7> source7;

			private readonly Observable<T8> source8;

			private readonly Observable<T9> source9;

			private readonly Observable<T10> source10;

			private readonly Observable<T11> source11;

			private readonly Observable<T12> source12;

			private readonly Observable<T13> source13;

			private readonly Observable<T14> source14;

			private readonly Observable<T15> source15;

			private readonly Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> resultSelector;

			private readonly ZipLatestObserver<T1> observer1;

			private readonly ZipLatestObserver<T2> observer2;

			private readonly ZipLatestObserver<T3> observer3;

			private readonly ZipLatestObserver<T4> observer4;

			private readonly ZipLatestObserver<T5> observer5;

			private readonly ZipLatestObserver<T6> observer6;

			private readonly ZipLatestObserver<T7> observer7;

			private readonly ZipLatestObserver<T8> observer8;

			private readonly ZipLatestObserver<T9> observer9;

			private readonly ZipLatestObserver<T10> observer10;

			private readonly ZipLatestObserver<T11> observer11;

			private readonly ZipLatestObserver<T12> observer12;

			private readonly ZipLatestObserver<T13> observer13;

			private readonly ZipLatestObserver<T14> observer14;

			private readonly ZipLatestObserver<T15> observer15;

			private readonly object gate = new object();

			public _ZipLatest(Observer<TResult> observer, Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Observable<T11> source11, Observable<T12> source12, Observable<T13> source13, Observable<T14> source14, Observable<T15> source15, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> resultSelector)
			{
				this.observer = observer;
				this.source1 = source1;
				this.source2 = source2;
				this.source3 = source3;
				this.source4 = source4;
				this.source5 = source5;
				this.source6 = source6;
				this.source7 = source7;
				this.source8 = source8;
				this.source9 = source9;
				this.source10 = source10;
				this.source11 = source11;
				this.source12 = source12;
				this.source13 = source13;
				this.source14 = source14;
				this.source15 = source15;
				this.resultSelector = resultSelector;
				observer1 = new ZipLatestObserver<T1>(this);
				observer2 = new ZipLatestObserver<T2>(this);
				observer3 = new ZipLatestObserver<T3>(this);
				observer4 = new ZipLatestObserver<T4>(this);
				observer5 = new ZipLatestObserver<T5>(this);
				observer6 = new ZipLatestObserver<T6>(this);
				observer7 = new ZipLatestObserver<T7>(this);
				observer8 = new ZipLatestObserver<T8>(this);
				observer9 = new ZipLatestObserver<T9>(this);
				observer10 = new ZipLatestObserver<T10>(this);
				observer11 = new ZipLatestObserver<T11>(this);
				observer12 = new ZipLatestObserver<T12>(this);
				observer13 = new ZipLatestObserver<T13>(this);
				observer14 = new ZipLatestObserver<T14>(this);
				observer15 = new ZipLatestObserver<T15>(this);
			}

			public IDisposable Run()
			{
				try
				{
					source1.Subscribe(observer1);
					source2.Subscribe(observer2);
					source3.Subscribe(observer3);
					source4.Subscribe(observer4);
					source5.Subscribe(observer5);
					source6.Subscribe(observer6);
					source7.Subscribe(observer7);
					source8.Subscribe(observer8);
					source9.Subscribe(observer9);
					source10.Subscribe(observer10);
					source11.Subscribe(observer11);
					source12.Subscribe(observer12);
					source13.Subscribe(observer13);
					source14.Subscribe(observer14);
					source15.Subscribe(observer15);
					return this;
				}
				catch
				{
					Dispose();
					throw;
				}
			}

			public void TryPublishOnNext()
			{
				if (observer1.HasValue && observer2.HasValue && observer3.HasValue && observer4.HasValue && observer5.HasValue && observer6.HasValue && observer7.HasValue && observer8.HasValue && observer9.HasValue && observer10.HasValue && observer11.HasValue && observer12.HasValue && observer13.HasValue && observer14.HasValue && observer15.HasValue)
				{
					TResult value = resultSelector(observer1.GetValue(), observer2.GetValue(), observer3.GetValue(), observer4.GetValue(), observer5.GetValue(), observer6.GetValue(), observer7.GetValue(), observer8.GetValue(), observer9.GetValue(), observer10.GetValue(), observer11.GetValue(), observer12.GetValue(), observer13.GetValue(), observer14.GetValue(), observer15.GetValue());
					observer.OnNext(value);
					if (observer1.IsCompleted || observer2.IsCompleted || observer3.IsCompleted || observer4.IsCompleted || observer5.IsCompleted || observer6.IsCompleted || observer7.IsCompleted || observer8.IsCompleted || observer9.IsCompleted || observer10.IsCompleted || observer11.IsCompleted || observer12.IsCompleted || observer13.IsCompleted || observer14.IsCompleted || observer15.IsCompleted)
					{
						observer.OnCompleted();
						Dispose();
					}
				}
			}

			public void TryPublishOnCompleted(Result result, bool empty)
			{
				if (result.IsFailure)
				{
					observer.OnCompleted(result);
					Dispose();
				}
				else if (empty || (observer1.IsCompleted && observer2.IsCompleted && observer3.IsCompleted && observer4.IsCompleted && observer5.IsCompleted && observer6.IsCompleted && observer7.IsCompleted && observer8.IsCompleted && observer9.IsCompleted && observer10.IsCompleted && observer11.IsCompleted && observer12.IsCompleted && observer13.IsCompleted && observer14.IsCompleted && observer15.IsCompleted))
				{
					observer.OnCompleted();
					Dispose();
				}
			}

			public void Dispose()
			{
				observer1.Dispose();
				observer2.Dispose();
				observer3.Dispose();
				observer4.Dispose();
				observer5.Dispose();
				observer6.Dispose();
				observer7.Dispose();
				observer8.Dispose();
				observer9.Dispose();
				observer10.Dispose();
				observer11.Dispose();
				observer12.Dispose();
				observer13.Dispose();
				observer14.Dispose();
				observer15.Dispose();
			}
		}

		public ZipLatest(Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Observable<T11> source11, Observable<T12> source12, Observable<T13> source13, Observable<T14> source14, Observable<T15> source15, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> resultSelector)
		{
			_003Csource1_003EP = source1;
			_003Csource2_003EP = source2;
			_003Csource3_003EP = source3;
			_003Csource4_003EP = source4;
			_003Csource5_003EP = source5;
			_003Csource6_003EP = source6;
			_003Csource7_003EP = source7;
			_003Csource8_003EP = source8;
			_003Csource9_003EP = source9;
			_003Csource10_003EP = source10;
			_003Csource11_003EP = source11;
			_003Csource12_003EP = source12;
			_003Csource13_003EP = source13;
			_003Csource14_003EP = source14;
			_003Csource15_003EP = source15;
			_003CresultSelector_003EP = resultSelector;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<TResult> observer)
		{
			return new _ZipLatest(observer, _003Csource1_003EP, _003Csource2_003EP, _003Csource3_003EP, _003Csource4_003EP, _003Csource5_003EP, _003Csource6_003EP, _003Csource7_003EP, _003Csource8_003EP, _003Csource9_003EP, _003Csource10_003EP, _003Csource11_003EP, _003Csource12_003EP, _003Csource13_003EP, _003Csource14_003EP, _003Csource15_003EP, _003CresultSelector_003EP).Run();
		}
	}
}
