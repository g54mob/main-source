using System;
using System.Collections.Generic;
using System.Linq;

namespace R3
{
	internal sealed class Zip<T> : Observable<T[]>
	{
		private sealed class _Zip : IDisposable
		{
			private sealed class ZipObserver : Observer<T>
			{
				public Queue<T> Values { get; }

				public bool IsCompleted { get; private set; }

				public ZipObserver(_Zip parent)
				{
					_003Cparent_003EP = parent;
					Values = new Queue<T>();
					base._002Ector();
				}

				public bool HasValue(out bool shouldComplete)
				{
					int count = Values.Count;
					shouldComplete = IsCompleted && count == 1;
					return count != 0;
				}

				protected override void OnNextCore(T value)
				{
					lock (_003Cparent_003EP.observers)
					{
						Values.Enqueue(value);
						_003Cparent_003EP.TryPublishOnNext();
					}
				}

				protected override void OnErrorResumeCore(Exception error)
				{
					_003Cparent_003EP.observer.OnErrorResume(error);
				}

				protected override void OnCompletedCore(Result result)
				{
					lock (_003Cparent_003EP.observers)
					{
						IsCompleted = true;
						_003Cparent_003EP.TryPublishOnCompleted(result, Values.Count == 0);
					}
				}
			}

			private readonly Observer<T[]> observer;

			private readonly Observable<T>[] sources;

			private readonly ZipObserver[] observers;

			public _Zip(Observer<T[]> observer, IEnumerable<Observable<T>> sources)
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
				ZipObserver[] array2 = new ZipObserver[this.sources.Length];
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i] = new ZipObserver(this);
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
				ZipObserver[] array = observers;
				for (int i = 0; i < array.Length; i++)
				{
					if (!array[i].HasValue(out var shouldComplete))
					{
						return;
					}
					if (shouldComplete)
					{
						flag = true;
					}
				}
				T[] array2 = new T[observers.Length];
				for (int j = 0; j < observers.Length; j++)
				{
					array2[j] = observers[j].Values.Dequeue();
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
				ZipObserver[] array = observers;
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
				ZipObserver[] array = observers;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].Dispose();
				}
			}
		}

		public Zip(IEnumerable<Observable<T>> sources)
		{
			_003Csources_003EP = sources;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T[]> observer)
		{
			return new _Zip(observer, _003Csources_003EP).Run();
		}
	}
	internal sealed class Zip<T1, T2, TResult> : Observable<TResult>
	{
		private sealed class _Zip : IDisposable
		{
			private sealed class ZipObserver<T> : Observer<T>
			{
				public Queue<T> Values { get; }

				public bool IsCompleted { get; private set; }

				public ZipObserver(_Zip parent)
				{
					_003Cparent_003EP = parent;
					Values = new Queue<T>();
					base._002Ector();
				}

				public bool HasValue(out bool shouldComplete)
				{
					int count = Values.Count;
					shouldComplete = IsCompleted && count == 1;
					return count != 0;
				}

				protected override void OnNextCore(T value)
				{
					lock (_003Cparent_003EP.gate)
					{
						Values.Enqueue(value);
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
						_003Cparent_003EP.TryPublishOnCompleted(result, Values.Count == 0);
					}
				}
			}

			private readonly Observer<TResult> observer;

			private readonly Observable<T1> source1;

			private readonly Observable<T2> source2;

			private readonly Func<T1, T2, TResult> resultSelector;

			private readonly ZipObserver<T1> observer1;

			private readonly ZipObserver<T2> observer2;

			private readonly object gate = new object();

			public _Zip(Observer<TResult> observer, Observable<T1> source1, Observable<T2> source2, Func<T1, T2, TResult> resultSelector)
			{
				this.observer = observer;
				this.source1 = source1;
				this.source2 = source2;
				this.resultSelector = resultSelector;
				observer1 = new ZipObserver<T1>(this);
				observer2 = new ZipObserver<T2>(this);
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
				if (observer1.HasValue(out var shouldComplete) && observer2.HasValue(out var shouldComplete2))
				{
					TResult value = resultSelector(observer1.Values.Dequeue(), observer2.Values.Dequeue());
					observer.OnNext(value);
					if (shouldComplete || shouldComplete2)
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

		public Zip(Observable<T1> source1, Observable<T2> source2, Func<T1, T2, TResult> resultSelector)
		{
			_003Csource1_003EP = source1;
			_003Csource2_003EP = source2;
			_003CresultSelector_003EP = resultSelector;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<TResult> observer)
		{
			return new _Zip(observer, _003Csource1_003EP, _003Csource2_003EP, _003CresultSelector_003EP).Run();
		}
	}
	internal sealed class Zip<T1, T2, T3, TResult> : Observable<TResult>
	{
		private sealed class _Zip : IDisposable
		{
			private sealed class ZipObserver<T> : Observer<T>
			{
				public Queue<T> Values { get; }

				public bool IsCompleted { get; private set; }

				public ZipObserver(_Zip parent)
				{
					_003Cparent_003EP = parent;
					Values = new Queue<T>();
					base._002Ector();
				}

				public bool HasValue(out bool shouldComplete)
				{
					int count = Values.Count;
					shouldComplete = IsCompleted && count == 1;
					return count != 0;
				}

				protected override void OnNextCore(T value)
				{
					lock (_003Cparent_003EP.gate)
					{
						Values.Enqueue(value);
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
						_003Cparent_003EP.TryPublishOnCompleted(result, Values.Count == 0);
					}
				}
			}

			private readonly Observer<TResult> observer;

			private readonly Observable<T1> source1;

			private readonly Observable<T2> source2;

			private readonly Observable<T3> source3;

			private readonly Func<T1, T2, T3, TResult> resultSelector;

			private readonly ZipObserver<T1> observer1;

			private readonly ZipObserver<T2> observer2;

			private readonly ZipObserver<T3> observer3;

			private readonly object gate = new object();

			public _Zip(Observer<TResult> observer, Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Func<T1, T2, T3, TResult> resultSelector)
			{
				this.observer = observer;
				this.source1 = source1;
				this.source2 = source2;
				this.source3 = source3;
				this.resultSelector = resultSelector;
				observer1 = new ZipObserver<T1>(this);
				observer2 = new ZipObserver<T2>(this);
				observer3 = new ZipObserver<T3>(this);
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
				if (observer1.HasValue(out var shouldComplete) && observer2.HasValue(out var shouldComplete2) && observer3.HasValue(out var shouldComplete3))
				{
					TResult value = resultSelector(observer1.Values.Dequeue(), observer2.Values.Dequeue(), observer3.Values.Dequeue());
					observer.OnNext(value);
					if (shouldComplete || shouldComplete2 || shouldComplete3)
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

		public Zip(Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Func<T1, T2, T3, TResult> resultSelector)
		{
			_003Csource1_003EP = source1;
			_003Csource2_003EP = source2;
			_003Csource3_003EP = source3;
			_003CresultSelector_003EP = resultSelector;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<TResult> observer)
		{
			return new _Zip(observer, _003Csource1_003EP, _003Csource2_003EP, _003Csource3_003EP, _003CresultSelector_003EP).Run();
		}
	}
	internal sealed class Zip<T1, T2, T3, T4, TResult> : Observable<TResult>
	{
		private sealed class _Zip : IDisposable
		{
			private sealed class ZipObserver<T> : Observer<T>
			{
				public Queue<T> Values { get; }

				public bool IsCompleted { get; private set; }

				public ZipObserver(_Zip parent)
				{
					_003Cparent_003EP = parent;
					Values = new Queue<T>();
					base._002Ector();
				}

				public bool HasValue(out bool shouldComplete)
				{
					int count = Values.Count;
					shouldComplete = IsCompleted && count == 1;
					return count != 0;
				}

				protected override void OnNextCore(T value)
				{
					lock (_003Cparent_003EP.gate)
					{
						Values.Enqueue(value);
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
						_003Cparent_003EP.TryPublishOnCompleted(result, Values.Count == 0);
					}
				}
			}

			private readonly Observer<TResult> observer;

			private readonly Observable<T1> source1;

			private readonly Observable<T2> source2;

			private readonly Observable<T3> source3;

			private readonly Observable<T4> source4;

			private readonly Func<T1, T2, T3, T4, TResult> resultSelector;

			private readonly ZipObserver<T1> observer1;

			private readonly ZipObserver<T2> observer2;

			private readonly ZipObserver<T3> observer3;

			private readonly ZipObserver<T4> observer4;

			private readonly object gate = new object();

			public _Zip(Observer<TResult> observer, Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Func<T1, T2, T3, T4, TResult> resultSelector)
			{
				this.observer = observer;
				this.source1 = source1;
				this.source2 = source2;
				this.source3 = source3;
				this.source4 = source4;
				this.resultSelector = resultSelector;
				observer1 = new ZipObserver<T1>(this);
				observer2 = new ZipObserver<T2>(this);
				observer3 = new ZipObserver<T3>(this);
				observer4 = new ZipObserver<T4>(this);
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
				if (observer1.HasValue(out var shouldComplete) && observer2.HasValue(out var shouldComplete2) && observer3.HasValue(out var shouldComplete3) && observer4.HasValue(out var shouldComplete4))
				{
					TResult value = resultSelector(observer1.Values.Dequeue(), observer2.Values.Dequeue(), observer3.Values.Dequeue(), observer4.Values.Dequeue());
					observer.OnNext(value);
					if (shouldComplete || shouldComplete2 || shouldComplete3 || shouldComplete4)
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

		public Zip(Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Func<T1, T2, T3, T4, TResult> resultSelector)
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
			return new _Zip(observer, _003Csource1_003EP, _003Csource2_003EP, _003Csource3_003EP, _003Csource4_003EP, _003CresultSelector_003EP).Run();
		}
	}
	internal sealed class Zip<T1, T2, T3, T4, T5, TResult> : Observable<TResult>
	{
		private sealed class _Zip : IDisposable
		{
			private sealed class ZipObserver<T> : Observer<T>
			{
				public Queue<T> Values { get; }

				public bool IsCompleted { get; private set; }

				public ZipObserver(_Zip parent)
				{
					_003Cparent_003EP = parent;
					Values = new Queue<T>();
					base._002Ector();
				}

				public bool HasValue(out bool shouldComplete)
				{
					int count = Values.Count;
					shouldComplete = IsCompleted && count == 1;
					return count != 0;
				}

				protected override void OnNextCore(T value)
				{
					lock (_003Cparent_003EP.gate)
					{
						Values.Enqueue(value);
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
						_003Cparent_003EP.TryPublishOnCompleted(result, Values.Count == 0);
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

			private readonly ZipObserver<T1> observer1;

			private readonly ZipObserver<T2> observer2;

			private readonly ZipObserver<T3> observer3;

			private readonly ZipObserver<T4> observer4;

			private readonly ZipObserver<T5> observer5;

			private readonly object gate = new object();

			public _Zip(Observer<TResult> observer, Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Func<T1, T2, T3, T4, T5, TResult> resultSelector)
			{
				this.observer = observer;
				this.source1 = source1;
				this.source2 = source2;
				this.source3 = source3;
				this.source4 = source4;
				this.source5 = source5;
				this.resultSelector = resultSelector;
				observer1 = new ZipObserver<T1>(this);
				observer2 = new ZipObserver<T2>(this);
				observer3 = new ZipObserver<T3>(this);
				observer4 = new ZipObserver<T4>(this);
				observer5 = new ZipObserver<T5>(this);
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
				if (observer1.HasValue(out var shouldComplete) && observer2.HasValue(out var shouldComplete2) && observer3.HasValue(out var shouldComplete3) && observer4.HasValue(out var shouldComplete4) && observer5.HasValue(out var shouldComplete5))
				{
					TResult value = resultSelector(observer1.Values.Dequeue(), observer2.Values.Dequeue(), observer3.Values.Dequeue(), observer4.Values.Dequeue(), observer5.Values.Dequeue());
					observer.OnNext(value);
					if (shouldComplete || shouldComplete2 || shouldComplete3 || shouldComplete4 || shouldComplete5)
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

		public Zip(Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Func<T1, T2, T3, T4, T5, TResult> resultSelector)
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
			return new _Zip(observer, _003Csource1_003EP, _003Csource2_003EP, _003Csource3_003EP, _003Csource4_003EP, _003Csource5_003EP, _003CresultSelector_003EP).Run();
		}
	}
	internal sealed class Zip<T1, T2, T3, T4, T5, T6, TResult> : Observable<TResult>
	{
		private sealed class _Zip : IDisposable
		{
			private sealed class ZipObserver<T> : Observer<T>
			{
				public Queue<T> Values { get; }

				public bool IsCompleted { get; private set; }

				public ZipObserver(_Zip parent)
				{
					_003Cparent_003EP = parent;
					Values = new Queue<T>();
					base._002Ector();
				}

				public bool HasValue(out bool shouldComplete)
				{
					int count = Values.Count;
					shouldComplete = IsCompleted && count == 1;
					return count != 0;
				}

				protected override void OnNextCore(T value)
				{
					lock (_003Cparent_003EP.gate)
					{
						Values.Enqueue(value);
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
						_003Cparent_003EP.TryPublishOnCompleted(result, Values.Count == 0);
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

			private readonly ZipObserver<T1> observer1;

			private readonly ZipObserver<T2> observer2;

			private readonly ZipObserver<T3> observer3;

			private readonly ZipObserver<T4> observer4;

			private readonly ZipObserver<T5> observer5;

			private readonly ZipObserver<T6> observer6;

			private readonly object gate = new object();

			public _Zip(Observer<TResult> observer, Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Func<T1, T2, T3, T4, T5, T6, TResult> resultSelector)
			{
				this.observer = observer;
				this.source1 = source1;
				this.source2 = source2;
				this.source3 = source3;
				this.source4 = source4;
				this.source5 = source5;
				this.source6 = source6;
				this.resultSelector = resultSelector;
				observer1 = new ZipObserver<T1>(this);
				observer2 = new ZipObserver<T2>(this);
				observer3 = new ZipObserver<T3>(this);
				observer4 = new ZipObserver<T4>(this);
				observer5 = new ZipObserver<T5>(this);
				observer6 = new ZipObserver<T6>(this);
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
				if (observer1.HasValue(out var shouldComplete) && observer2.HasValue(out var shouldComplete2) && observer3.HasValue(out var shouldComplete3) && observer4.HasValue(out var shouldComplete4) && observer5.HasValue(out var shouldComplete5) && observer6.HasValue(out var shouldComplete6))
				{
					TResult value = resultSelector(observer1.Values.Dequeue(), observer2.Values.Dequeue(), observer3.Values.Dequeue(), observer4.Values.Dequeue(), observer5.Values.Dequeue(), observer6.Values.Dequeue());
					observer.OnNext(value);
					if (shouldComplete || shouldComplete2 || shouldComplete3 || shouldComplete4 || shouldComplete5 || shouldComplete6)
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

		public Zip(Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Func<T1, T2, T3, T4, T5, T6, TResult> resultSelector)
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
			return new _Zip(observer, _003Csource1_003EP, _003Csource2_003EP, _003Csource3_003EP, _003Csource4_003EP, _003Csource5_003EP, _003Csource6_003EP, _003CresultSelector_003EP).Run();
		}
	}
	internal sealed class Zip<T1, T2, T3, T4, T5, T6, T7, TResult> : Observable<TResult>
	{
		private sealed class _Zip : IDisposable
		{
			private sealed class ZipObserver<T> : Observer<T>
			{
				public Queue<T> Values { get; }

				public bool IsCompleted { get; private set; }

				public ZipObserver(_Zip parent)
				{
					_003Cparent_003EP = parent;
					Values = new Queue<T>();
					base._002Ector();
				}

				public bool HasValue(out bool shouldComplete)
				{
					int count = Values.Count;
					shouldComplete = IsCompleted && count == 1;
					return count != 0;
				}

				protected override void OnNextCore(T value)
				{
					lock (_003Cparent_003EP.gate)
					{
						Values.Enqueue(value);
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
						_003Cparent_003EP.TryPublishOnCompleted(result, Values.Count == 0);
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

			private readonly ZipObserver<T1> observer1;

			private readonly ZipObserver<T2> observer2;

			private readonly ZipObserver<T3> observer3;

			private readonly ZipObserver<T4> observer4;

			private readonly ZipObserver<T5> observer5;

			private readonly ZipObserver<T6> observer6;

			private readonly ZipObserver<T7> observer7;

			private readonly object gate = new object();

			public _Zip(Observer<TResult> observer, Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Func<T1, T2, T3, T4, T5, T6, T7, TResult> resultSelector)
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
				observer1 = new ZipObserver<T1>(this);
				observer2 = new ZipObserver<T2>(this);
				observer3 = new ZipObserver<T3>(this);
				observer4 = new ZipObserver<T4>(this);
				observer5 = new ZipObserver<T5>(this);
				observer6 = new ZipObserver<T6>(this);
				observer7 = new ZipObserver<T7>(this);
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
				if (observer1.HasValue(out var shouldComplete) && observer2.HasValue(out var shouldComplete2) && observer3.HasValue(out var shouldComplete3) && observer4.HasValue(out var shouldComplete4) && observer5.HasValue(out var shouldComplete5) && observer6.HasValue(out var shouldComplete6) && observer7.HasValue(out var shouldComplete7))
				{
					TResult value = resultSelector(observer1.Values.Dequeue(), observer2.Values.Dequeue(), observer3.Values.Dequeue(), observer4.Values.Dequeue(), observer5.Values.Dequeue(), observer6.Values.Dequeue(), observer7.Values.Dequeue());
					observer.OnNext(value);
					if (shouldComplete || shouldComplete2 || shouldComplete3 || shouldComplete4 || shouldComplete5 || shouldComplete6 || shouldComplete7)
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

		public Zip(Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Func<T1, T2, T3, T4, T5, T6, T7, TResult> resultSelector)
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
			return new _Zip(observer, _003Csource1_003EP, _003Csource2_003EP, _003Csource3_003EP, _003Csource4_003EP, _003Csource5_003EP, _003Csource6_003EP, _003Csource7_003EP, _003CresultSelector_003EP).Run();
		}
	}
	internal sealed class Zip<T1, T2, T3, T4, T5, T6, T7, T8, TResult> : Observable<TResult>
	{
		private sealed class _Zip : IDisposable
		{
			private sealed class ZipObserver<T> : Observer<T>
			{
				public Queue<T> Values { get; }

				public bool IsCompleted { get; private set; }

				public ZipObserver(_Zip parent)
				{
					_003Cparent_003EP = parent;
					Values = new Queue<T>();
					base._002Ector();
				}

				public bool HasValue(out bool shouldComplete)
				{
					int count = Values.Count;
					shouldComplete = IsCompleted && count == 1;
					return count != 0;
				}

				protected override void OnNextCore(T value)
				{
					lock (_003Cparent_003EP.gate)
					{
						Values.Enqueue(value);
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
						_003Cparent_003EP.TryPublishOnCompleted(result, Values.Count == 0);
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

			private readonly ZipObserver<T1> observer1;

			private readonly ZipObserver<T2> observer2;

			private readonly ZipObserver<T3> observer3;

			private readonly ZipObserver<T4> observer4;

			private readonly ZipObserver<T5> observer5;

			private readonly ZipObserver<T6> observer6;

			private readonly ZipObserver<T7> observer7;

			private readonly ZipObserver<T8> observer8;

			private readonly object gate = new object();

			public _Zip(Observer<TResult> observer, Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> resultSelector)
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
				observer1 = new ZipObserver<T1>(this);
				observer2 = new ZipObserver<T2>(this);
				observer3 = new ZipObserver<T3>(this);
				observer4 = new ZipObserver<T4>(this);
				observer5 = new ZipObserver<T5>(this);
				observer6 = new ZipObserver<T6>(this);
				observer7 = new ZipObserver<T7>(this);
				observer8 = new ZipObserver<T8>(this);
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
				if (observer1.HasValue(out var shouldComplete) && observer2.HasValue(out var shouldComplete2) && observer3.HasValue(out var shouldComplete3) && observer4.HasValue(out var shouldComplete4) && observer5.HasValue(out var shouldComplete5) && observer6.HasValue(out var shouldComplete6) && observer7.HasValue(out var shouldComplete7) && observer8.HasValue(out var shouldComplete8))
				{
					TResult value = resultSelector(observer1.Values.Dequeue(), observer2.Values.Dequeue(), observer3.Values.Dequeue(), observer4.Values.Dequeue(), observer5.Values.Dequeue(), observer6.Values.Dequeue(), observer7.Values.Dequeue(), observer8.Values.Dequeue());
					observer.OnNext(value);
					if (shouldComplete || shouldComplete2 || shouldComplete3 || shouldComplete4 || shouldComplete5 || shouldComplete6 || shouldComplete7 || shouldComplete8)
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

		public Zip(Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> resultSelector)
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
			return new _Zip(observer, _003Csource1_003EP, _003Csource2_003EP, _003Csource3_003EP, _003Csource4_003EP, _003Csource5_003EP, _003Csource6_003EP, _003Csource7_003EP, _003Csource8_003EP, _003CresultSelector_003EP).Run();
		}
	}
	internal sealed class Zip<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> : Observable<TResult>
	{
		private sealed class _Zip : IDisposable
		{
			private sealed class ZipObserver<T> : Observer<T>
			{
				public Queue<T> Values { get; }

				public bool IsCompleted { get; private set; }

				public ZipObserver(_Zip parent)
				{
					_003Cparent_003EP = parent;
					Values = new Queue<T>();
					base._002Ector();
				}

				public bool HasValue(out bool shouldComplete)
				{
					int count = Values.Count;
					shouldComplete = IsCompleted && count == 1;
					return count != 0;
				}

				protected override void OnNextCore(T value)
				{
					lock (_003Cparent_003EP.gate)
					{
						Values.Enqueue(value);
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
						_003Cparent_003EP.TryPublishOnCompleted(result, Values.Count == 0);
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

			private readonly ZipObserver<T1> observer1;

			private readonly ZipObserver<T2> observer2;

			private readonly ZipObserver<T3> observer3;

			private readonly ZipObserver<T4> observer4;

			private readonly ZipObserver<T5> observer5;

			private readonly ZipObserver<T6> observer6;

			private readonly ZipObserver<T7> observer7;

			private readonly ZipObserver<T8> observer8;

			private readonly ZipObserver<T9> observer9;

			private readonly object gate = new object();

			public _Zip(Observer<TResult> observer, Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> resultSelector)
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
				observer1 = new ZipObserver<T1>(this);
				observer2 = new ZipObserver<T2>(this);
				observer3 = new ZipObserver<T3>(this);
				observer4 = new ZipObserver<T4>(this);
				observer5 = new ZipObserver<T5>(this);
				observer6 = new ZipObserver<T6>(this);
				observer7 = new ZipObserver<T7>(this);
				observer8 = new ZipObserver<T8>(this);
				observer9 = new ZipObserver<T9>(this);
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
				if (observer1.HasValue(out var shouldComplete) && observer2.HasValue(out var shouldComplete2) && observer3.HasValue(out var shouldComplete3) && observer4.HasValue(out var shouldComplete4) && observer5.HasValue(out var shouldComplete5) && observer6.HasValue(out var shouldComplete6) && observer7.HasValue(out var shouldComplete7) && observer8.HasValue(out var shouldComplete8) && observer9.HasValue(out var shouldComplete9))
				{
					TResult value = resultSelector(observer1.Values.Dequeue(), observer2.Values.Dequeue(), observer3.Values.Dequeue(), observer4.Values.Dequeue(), observer5.Values.Dequeue(), observer6.Values.Dequeue(), observer7.Values.Dequeue(), observer8.Values.Dequeue(), observer9.Values.Dequeue());
					observer.OnNext(value);
					if (shouldComplete || shouldComplete2 || shouldComplete3 || shouldComplete4 || shouldComplete5 || shouldComplete6 || shouldComplete7 || shouldComplete8 || shouldComplete9)
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

		public Zip(Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> resultSelector)
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
			return new _Zip(observer, _003Csource1_003EP, _003Csource2_003EP, _003Csource3_003EP, _003Csource4_003EP, _003Csource5_003EP, _003Csource6_003EP, _003Csource7_003EP, _003Csource8_003EP, _003Csource9_003EP, _003CresultSelector_003EP).Run();
		}
	}
	internal sealed class Zip<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> : Observable<TResult>
	{
		private sealed class _Zip : IDisposable
		{
			private sealed class ZipObserver<T> : Observer<T>
			{
				public Queue<T> Values { get; }

				public bool IsCompleted { get; private set; }

				public ZipObserver(_Zip parent)
				{
					_003Cparent_003EP = parent;
					Values = new Queue<T>();
					base._002Ector();
				}

				public bool HasValue(out bool shouldComplete)
				{
					int count = Values.Count;
					shouldComplete = IsCompleted && count == 1;
					return count != 0;
				}

				protected override void OnNextCore(T value)
				{
					lock (_003Cparent_003EP.gate)
					{
						Values.Enqueue(value);
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
						_003Cparent_003EP.TryPublishOnCompleted(result, Values.Count == 0);
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

			private readonly ZipObserver<T1> observer1;

			private readonly ZipObserver<T2> observer2;

			private readonly ZipObserver<T3> observer3;

			private readonly ZipObserver<T4> observer4;

			private readonly ZipObserver<T5> observer5;

			private readonly ZipObserver<T6> observer6;

			private readonly ZipObserver<T7> observer7;

			private readonly ZipObserver<T8> observer8;

			private readonly ZipObserver<T9> observer9;

			private readonly ZipObserver<T10> observer10;

			private readonly object gate = new object();

			public _Zip(Observer<TResult> observer, Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> resultSelector)
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
				observer1 = new ZipObserver<T1>(this);
				observer2 = new ZipObserver<T2>(this);
				observer3 = new ZipObserver<T3>(this);
				observer4 = new ZipObserver<T4>(this);
				observer5 = new ZipObserver<T5>(this);
				observer6 = new ZipObserver<T6>(this);
				observer7 = new ZipObserver<T7>(this);
				observer8 = new ZipObserver<T8>(this);
				observer9 = new ZipObserver<T9>(this);
				observer10 = new ZipObserver<T10>(this);
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
				if (observer1.HasValue(out var shouldComplete) && observer2.HasValue(out var shouldComplete2) && observer3.HasValue(out var shouldComplete3) && observer4.HasValue(out var shouldComplete4) && observer5.HasValue(out var shouldComplete5) && observer6.HasValue(out var shouldComplete6) && observer7.HasValue(out var shouldComplete7) && observer8.HasValue(out var shouldComplete8) && observer9.HasValue(out var shouldComplete9) && observer10.HasValue(out var shouldComplete10))
				{
					TResult value = resultSelector(observer1.Values.Dequeue(), observer2.Values.Dequeue(), observer3.Values.Dequeue(), observer4.Values.Dequeue(), observer5.Values.Dequeue(), observer6.Values.Dequeue(), observer7.Values.Dequeue(), observer8.Values.Dequeue(), observer9.Values.Dequeue(), observer10.Values.Dequeue());
					observer.OnNext(value);
					if (shouldComplete || shouldComplete2 || shouldComplete3 || shouldComplete4 || shouldComplete5 || shouldComplete6 || shouldComplete7 || shouldComplete8 || shouldComplete9 || shouldComplete10)
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

		public Zip(Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> resultSelector)
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
			return new _Zip(observer, _003Csource1_003EP, _003Csource2_003EP, _003Csource3_003EP, _003Csource4_003EP, _003Csource5_003EP, _003Csource6_003EP, _003Csource7_003EP, _003Csource8_003EP, _003Csource9_003EP, _003Csource10_003EP, _003CresultSelector_003EP).Run();
		}
	}
	internal sealed class Zip<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> : Observable<TResult>
	{
		private sealed class _Zip : IDisposable
		{
			private sealed class ZipObserver<T> : Observer<T>
			{
				public Queue<T> Values { get; }

				public bool IsCompleted { get; private set; }

				public ZipObserver(_Zip parent)
				{
					_003Cparent_003EP = parent;
					Values = new Queue<T>();
					base._002Ector();
				}

				public bool HasValue(out bool shouldComplete)
				{
					int count = Values.Count;
					shouldComplete = IsCompleted && count == 1;
					return count != 0;
				}

				protected override void OnNextCore(T value)
				{
					lock (_003Cparent_003EP.gate)
					{
						Values.Enqueue(value);
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
						_003Cparent_003EP.TryPublishOnCompleted(result, Values.Count == 0);
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

			private readonly ZipObserver<T1> observer1;

			private readonly ZipObserver<T2> observer2;

			private readonly ZipObserver<T3> observer3;

			private readonly ZipObserver<T4> observer4;

			private readonly ZipObserver<T5> observer5;

			private readonly ZipObserver<T6> observer6;

			private readonly ZipObserver<T7> observer7;

			private readonly ZipObserver<T8> observer8;

			private readonly ZipObserver<T9> observer9;

			private readonly ZipObserver<T10> observer10;

			private readonly ZipObserver<T11> observer11;

			private readonly object gate = new object();

			public _Zip(Observer<TResult> observer, Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Observable<T11> source11, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> resultSelector)
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
				observer1 = new ZipObserver<T1>(this);
				observer2 = new ZipObserver<T2>(this);
				observer3 = new ZipObserver<T3>(this);
				observer4 = new ZipObserver<T4>(this);
				observer5 = new ZipObserver<T5>(this);
				observer6 = new ZipObserver<T6>(this);
				observer7 = new ZipObserver<T7>(this);
				observer8 = new ZipObserver<T8>(this);
				observer9 = new ZipObserver<T9>(this);
				observer10 = new ZipObserver<T10>(this);
				observer11 = new ZipObserver<T11>(this);
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
				if (observer1.HasValue(out var shouldComplete) && observer2.HasValue(out var shouldComplete2) && observer3.HasValue(out var shouldComplete3) && observer4.HasValue(out var shouldComplete4) && observer5.HasValue(out var shouldComplete5) && observer6.HasValue(out var shouldComplete6) && observer7.HasValue(out var shouldComplete7) && observer8.HasValue(out var shouldComplete8) && observer9.HasValue(out var shouldComplete9) && observer10.HasValue(out var shouldComplete10) && observer11.HasValue(out var shouldComplete11))
				{
					TResult value = resultSelector(observer1.Values.Dequeue(), observer2.Values.Dequeue(), observer3.Values.Dequeue(), observer4.Values.Dequeue(), observer5.Values.Dequeue(), observer6.Values.Dequeue(), observer7.Values.Dequeue(), observer8.Values.Dequeue(), observer9.Values.Dequeue(), observer10.Values.Dequeue(), observer11.Values.Dequeue());
					observer.OnNext(value);
					if (shouldComplete || shouldComplete2 || shouldComplete3 || shouldComplete4 || shouldComplete5 || shouldComplete6 || shouldComplete7 || shouldComplete8 || shouldComplete9 || shouldComplete10 || shouldComplete11)
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

		public Zip(Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Observable<T11> source11, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> resultSelector)
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
			return new _Zip(observer, _003Csource1_003EP, _003Csource2_003EP, _003Csource3_003EP, _003Csource4_003EP, _003Csource5_003EP, _003Csource6_003EP, _003Csource7_003EP, _003Csource8_003EP, _003Csource9_003EP, _003Csource10_003EP, _003Csource11_003EP, _003CresultSelector_003EP).Run();
		}
	}
	internal sealed class Zip<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> : Observable<TResult>
	{
		private sealed class _Zip : IDisposable
		{
			private sealed class ZipObserver<T> : Observer<T>
			{
				public Queue<T> Values { get; }

				public bool IsCompleted { get; private set; }

				public ZipObserver(_Zip parent)
				{
					_003Cparent_003EP = parent;
					Values = new Queue<T>();
					base._002Ector();
				}

				public bool HasValue(out bool shouldComplete)
				{
					int count = Values.Count;
					shouldComplete = IsCompleted && count == 1;
					return count != 0;
				}

				protected override void OnNextCore(T value)
				{
					lock (_003Cparent_003EP.gate)
					{
						Values.Enqueue(value);
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
						_003Cparent_003EP.TryPublishOnCompleted(result, Values.Count == 0);
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

			private readonly ZipObserver<T1> observer1;

			private readonly ZipObserver<T2> observer2;

			private readonly ZipObserver<T3> observer3;

			private readonly ZipObserver<T4> observer4;

			private readonly ZipObserver<T5> observer5;

			private readonly ZipObserver<T6> observer6;

			private readonly ZipObserver<T7> observer7;

			private readonly ZipObserver<T8> observer8;

			private readonly ZipObserver<T9> observer9;

			private readonly ZipObserver<T10> observer10;

			private readonly ZipObserver<T11> observer11;

			private readonly ZipObserver<T12> observer12;

			private readonly object gate = new object();

			public _Zip(Observer<TResult> observer, Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Observable<T11> source11, Observable<T12> source12, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> resultSelector)
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
				observer1 = new ZipObserver<T1>(this);
				observer2 = new ZipObserver<T2>(this);
				observer3 = new ZipObserver<T3>(this);
				observer4 = new ZipObserver<T4>(this);
				observer5 = new ZipObserver<T5>(this);
				observer6 = new ZipObserver<T6>(this);
				observer7 = new ZipObserver<T7>(this);
				observer8 = new ZipObserver<T8>(this);
				observer9 = new ZipObserver<T9>(this);
				observer10 = new ZipObserver<T10>(this);
				observer11 = new ZipObserver<T11>(this);
				observer12 = new ZipObserver<T12>(this);
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
				if (observer1.HasValue(out var shouldComplete) && observer2.HasValue(out var shouldComplete2) && observer3.HasValue(out var shouldComplete3) && observer4.HasValue(out var shouldComplete4) && observer5.HasValue(out var shouldComplete5) && observer6.HasValue(out var shouldComplete6) && observer7.HasValue(out var shouldComplete7) && observer8.HasValue(out var shouldComplete8) && observer9.HasValue(out var shouldComplete9) && observer10.HasValue(out var shouldComplete10) && observer11.HasValue(out var shouldComplete11) && observer12.HasValue(out var shouldComplete12))
				{
					TResult value = resultSelector(observer1.Values.Dequeue(), observer2.Values.Dequeue(), observer3.Values.Dequeue(), observer4.Values.Dequeue(), observer5.Values.Dequeue(), observer6.Values.Dequeue(), observer7.Values.Dequeue(), observer8.Values.Dequeue(), observer9.Values.Dequeue(), observer10.Values.Dequeue(), observer11.Values.Dequeue(), observer12.Values.Dequeue());
					observer.OnNext(value);
					if (shouldComplete || shouldComplete2 || shouldComplete3 || shouldComplete4 || shouldComplete5 || shouldComplete6 || shouldComplete7 || shouldComplete8 || shouldComplete9 || shouldComplete10 || shouldComplete11 || shouldComplete12)
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

		public Zip(Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Observable<T11> source11, Observable<T12> source12, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> resultSelector)
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
			return new _Zip(observer, _003Csource1_003EP, _003Csource2_003EP, _003Csource3_003EP, _003Csource4_003EP, _003Csource5_003EP, _003Csource6_003EP, _003Csource7_003EP, _003Csource8_003EP, _003Csource9_003EP, _003Csource10_003EP, _003Csource11_003EP, _003Csource12_003EP, _003CresultSelector_003EP).Run();
		}
	}
	internal sealed class Zip<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> : Observable<TResult>
	{
		private sealed class _Zip : IDisposable
		{
			private sealed class ZipObserver<T> : Observer<T>
			{
				public Queue<T> Values { get; }

				public bool IsCompleted { get; private set; }

				public ZipObserver(_Zip parent)
				{
					_003Cparent_003EP = parent;
					Values = new Queue<T>();
					base._002Ector();
				}

				public bool HasValue(out bool shouldComplete)
				{
					int count = Values.Count;
					shouldComplete = IsCompleted && count == 1;
					return count != 0;
				}

				protected override void OnNextCore(T value)
				{
					lock (_003Cparent_003EP.gate)
					{
						Values.Enqueue(value);
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
						_003Cparent_003EP.TryPublishOnCompleted(result, Values.Count == 0);
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

			private readonly ZipObserver<T1> observer1;

			private readonly ZipObserver<T2> observer2;

			private readonly ZipObserver<T3> observer3;

			private readonly ZipObserver<T4> observer4;

			private readonly ZipObserver<T5> observer5;

			private readonly ZipObserver<T6> observer6;

			private readonly ZipObserver<T7> observer7;

			private readonly ZipObserver<T8> observer8;

			private readonly ZipObserver<T9> observer9;

			private readonly ZipObserver<T10> observer10;

			private readonly ZipObserver<T11> observer11;

			private readonly ZipObserver<T12> observer12;

			private readonly ZipObserver<T13> observer13;

			private readonly object gate = new object();

			public _Zip(Observer<TResult> observer, Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Observable<T11> source11, Observable<T12> source12, Observable<T13> source13, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> resultSelector)
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
				observer1 = new ZipObserver<T1>(this);
				observer2 = new ZipObserver<T2>(this);
				observer3 = new ZipObserver<T3>(this);
				observer4 = new ZipObserver<T4>(this);
				observer5 = new ZipObserver<T5>(this);
				observer6 = new ZipObserver<T6>(this);
				observer7 = new ZipObserver<T7>(this);
				observer8 = new ZipObserver<T8>(this);
				observer9 = new ZipObserver<T9>(this);
				observer10 = new ZipObserver<T10>(this);
				observer11 = new ZipObserver<T11>(this);
				observer12 = new ZipObserver<T12>(this);
				observer13 = new ZipObserver<T13>(this);
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
				if (observer1.HasValue(out var shouldComplete) && observer2.HasValue(out var shouldComplete2) && observer3.HasValue(out var shouldComplete3) && observer4.HasValue(out var shouldComplete4) && observer5.HasValue(out var shouldComplete5) && observer6.HasValue(out var shouldComplete6) && observer7.HasValue(out var shouldComplete7) && observer8.HasValue(out var shouldComplete8) && observer9.HasValue(out var shouldComplete9) && observer10.HasValue(out var shouldComplete10) && observer11.HasValue(out var shouldComplete11) && observer12.HasValue(out var shouldComplete12) && observer13.HasValue(out var shouldComplete13))
				{
					TResult value = resultSelector(observer1.Values.Dequeue(), observer2.Values.Dequeue(), observer3.Values.Dequeue(), observer4.Values.Dequeue(), observer5.Values.Dequeue(), observer6.Values.Dequeue(), observer7.Values.Dequeue(), observer8.Values.Dequeue(), observer9.Values.Dequeue(), observer10.Values.Dequeue(), observer11.Values.Dequeue(), observer12.Values.Dequeue(), observer13.Values.Dequeue());
					observer.OnNext(value);
					if (shouldComplete || shouldComplete2 || shouldComplete3 || shouldComplete4 || shouldComplete5 || shouldComplete6 || shouldComplete7 || shouldComplete8 || shouldComplete9 || shouldComplete10 || shouldComplete11 || shouldComplete12 || shouldComplete13)
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

		public Zip(Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Observable<T11> source11, Observable<T12> source12, Observable<T13> source13, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> resultSelector)
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
			return new _Zip(observer, _003Csource1_003EP, _003Csource2_003EP, _003Csource3_003EP, _003Csource4_003EP, _003Csource5_003EP, _003Csource6_003EP, _003Csource7_003EP, _003Csource8_003EP, _003Csource9_003EP, _003Csource10_003EP, _003Csource11_003EP, _003Csource12_003EP, _003Csource13_003EP, _003CresultSelector_003EP).Run();
		}
	}
	internal sealed class Zip<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> : Observable<TResult>
	{
		private sealed class _Zip : IDisposable
		{
			private sealed class ZipObserver<T> : Observer<T>
			{
				public Queue<T> Values { get; }

				public bool IsCompleted { get; private set; }

				public ZipObserver(_Zip parent)
				{
					_003Cparent_003EP = parent;
					Values = new Queue<T>();
					base._002Ector();
				}

				public bool HasValue(out bool shouldComplete)
				{
					int count = Values.Count;
					shouldComplete = IsCompleted && count == 1;
					return count != 0;
				}

				protected override void OnNextCore(T value)
				{
					lock (_003Cparent_003EP.gate)
					{
						Values.Enqueue(value);
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
						_003Cparent_003EP.TryPublishOnCompleted(result, Values.Count == 0);
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

			private readonly ZipObserver<T1> observer1;

			private readonly ZipObserver<T2> observer2;

			private readonly ZipObserver<T3> observer3;

			private readonly ZipObserver<T4> observer4;

			private readonly ZipObserver<T5> observer5;

			private readonly ZipObserver<T6> observer6;

			private readonly ZipObserver<T7> observer7;

			private readonly ZipObserver<T8> observer8;

			private readonly ZipObserver<T9> observer9;

			private readonly ZipObserver<T10> observer10;

			private readonly ZipObserver<T11> observer11;

			private readonly ZipObserver<T12> observer12;

			private readonly ZipObserver<T13> observer13;

			private readonly ZipObserver<T14> observer14;

			private readonly object gate = new object();

			public _Zip(Observer<TResult> observer, Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Observable<T11> source11, Observable<T12> source12, Observable<T13> source13, Observable<T14> source14, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> resultSelector)
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
				observer1 = new ZipObserver<T1>(this);
				observer2 = new ZipObserver<T2>(this);
				observer3 = new ZipObserver<T3>(this);
				observer4 = new ZipObserver<T4>(this);
				observer5 = new ZipObserver<T5>(this);
				observer6 = new ZipObserver<T6>(this);
				observer7 = new ZipObserver<T7>(this);
				observer8 = new ZipObserver<T8>(this);
				observer9 = new ZipObserver<T9>(this);
				observer10 = new ZipObserver<T10>(this);
				observer11 = new ZipObserver<T11>(this);
				observer12 = new ZipObserver<T12>(this);
				observer13 = new ZipObserver<T13>(this);
				observer14 = new ZipObserver<T14>(this);
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
				if (observer1.HasValue(out var shouldComplete) && observer2.HasValue(out var shouldComplete2) && observer3.HasValue(out var shouldComplete3) && observer4.HasValue(out var shouldComplete4) && observer5.HasValue(out var shouldComplete5) && observer6.HasValue(out var shouldComplete6) && observer7.HasValue(out var shouldComplete7) && observer8.HasValue(out var shouldComplete8) && observer9.HasValue(out var shouldComplete9) && observer10.HasValue(out var shouldComplete10) && observer11.HasValue(out var shouldComplete11) && observer12.HasValue(out var shouldComplete12) && observer13.HasValue(out var shouldComplete13) && observer14.HasValue(out var shouldComplete14))
				{
					TResult value = resultSelector(observer1.Values.Dequeue(), observer2.Values.Dequeue(), observer3.Values.Dequeue(), observer4.Values.Dequeue(), observer5.Values.Dequeue(), observer6.Values.Dequeue(), observer7.Values.Dequeue(), observer8.Values.Dequeue(), observer9.Values.Dequeue(), observer10.Values.Dequeue(), observer11.Values.Dequeue(), observer12.Values.Dequeue(), observer13.Values.Dequeue(), observer14.Values.Dequeue());
					observer.OnNext(value);
					if (shouldComplete || shouldComplete2 || shouldComplete3 || shouldComplete4 || shouldComplete5 || shouldComplete6 || shouldComplete7 || shouldComplete8 || shouldComplete9 || shouldComplete10 || shouldComplete11 || shouldComplete12 || shouldComplete13 || shouldComplete14)
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

		public Zip(Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Observable<T11> source11, Observable<T12> source12, Observable<T13> source13, Observable<T14> source14, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> resultSelector)
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
			return new _Zip(observer, _003Csource1_003EP, _003Csource2_003EP, _003Csource3_003EP, _003Csource4_003EP, _003Csource5_003EP, _003Csource6_003EP, _003Csource7_003EP, _003Csource8_003EP, _003Csource9_003EP, _003Csource10_003EP, _003Csource11_003EP, _003Csource12_003EP, _003Csource13_003EP, _003Csource14_003EP, _003CresultSelector_003EP).Run();
		}
	}
	internal sealed class Zip<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> : Observable<TResult>
	{
		private sealed class _Zip : IDisposable
		{
			private sealed class ZipObserver<T> : Observer<T>
			{
				public Queue<T> Values { get; }

				public bool IsCompleted { get; private set; }

				public ZipObserver(_Zip parent)
				{
					_003Cparent_003EP = parent;
					Values = new Queue<T>();
					base._002Ector();
				}

				public bool HasValue(out bool shouldComplete)
				{
					int count = Values.Count;
					shouldComplete = IsCompleted && count == 1;
					return count != 0;
				}

				protected override void OnNextCore(T value)
				{
					lock (_003Cparent_003EP.gate)
					{
						Values.Enqueue(value);
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
						_003Cparent_003EP.TryPublishOnCompleted(result, Values.Count == 0);
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

			private readonly ZipObserver<T1> observer1;

			private readonly ZipObserver<T2> observer2;

			private readonly ZipObserver<T3> observer3;

			private readonly ZipObserver<T4> observer4;

			private readonly ZipObserver<T5> observer5;

			private readonly ZipObserver<T6> observer6;

			private readonly ZipObserver<T7> observer7;

			private readonly ZipObserver<T8> observer8;

			private readonly ZipObserver<T9> observer9;

			private readonly ZipObserver<T10> observer10;

			private readonly ZipObserver<T11> observer11;

			private readonly ZipObserver<T12> observer12;

			private readonly ZipObserver<T13> observer13;

			private readonly ZipObserver<T14> observer14;

			private readonly ZipObserver<T15> observer15;

			private readonly object gate = new object();

			public _Zip(Observer<TResult> observer, Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Observable<T11> source11, Observable<T12> source12, Observable<T13> source13, Observable<T14> source14, Observable<T15> source15, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> resultSelector)
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
				observer1 = new ZipObserver<T1>(this);
				observer2 = new ZipObserver<T2>(this);
				observer3 = new ZipObserver<T3>(this);
				observer4 = new ZipObserver<T4>(this);
				observer5 = new ZipObserver<T5>(this);
				observer6 = new ZipObserver<T6>(this);
				observer7 = new ZipObserver<T7>(this);
				observer8 = new ZipObserver<T8>(this);
				observer9 = new ZipObserver<T9>(this);
				observer10 = new ZipObserver<T10>(this);
				observer11 = new ZipObserver<T11>(this);
				observer12 = new ZipObserver<T12>(this);
				observer13 = new ZipObserver<T13>(this);
				observer14 = new ZipObserver<T14>(this);
				observer15 = new ZipObserver<T15>(this);
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
				if (observer1.HasValue(out var shouldComplete) && observer2.HasValue(out var shouldComplete2) && observer3.HasValue(out var shouldComplete3) && observer4.HasValue(out var shouldComplete4) && observer5.HasValue(out var shouldComplete5) && observer6.HasValue(out var shouldComplete6) && observer7.HasValue(out var shouldComplete7) && observer8.HasValue(out var shouldComplete8) && observer9.HasValue(out var shouldComplete9) && observer10.HasValue(out var shouldComplete10) && observer11.HasValue(out var shouldComplete11) && observer12.HasValue(out var shouldComplete12) && observer13.HasValue(out var shouldComplete13) && observer14.HasValue(out var shouldComplete14) && observer15.HasValue(out var shouldComplete15))
				{
					TResult value = resultSelector(observer1.Values.Dequeue(), observer2.Values.Dequeue(), observer3.Values.Dequeue(), observer4.Values.Dequeue(), observer5.Values.Dequeue(), observer6.Values.Dequeue(), observer7.Values.Dequeue(), observer8.Values.Dequeue(), observer9.Values.Dequeue(), observer10.Values.Dequeue(), observer11.Values.Dequeue(), observer12.Values.Dequeue(), observer13.Values.Dequeue(), observer14.Values.Dequeue(), observer15.Values.Dequeue());
					observer.OnNext(value);
					if (shouldComplete || shouldComplete2 || shouldComplete3 || shouldComplete4 || shouldComplete5 || shouldComplete6 || shouldComplete7 || shouldComplete8 || shouldComplete9 || shouldComplete10 || shouldComplete11 || shouldComplete12 || shouldComplete13 || shouldComplete14 || shouldComplete15)
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

		public Zip(Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Observable<T11> source11, Observable<T12> source12, Observable<T13> source13, Observable<T14> source14, Observable<T15> source15, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> resultSelector)
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
			return new _Zip(observer, _003Csource1_003EP, _003Csource2_003EP, _003Csource3_003EP, _003Csource4_003EP, _003Csource5_003EP, _003Csource6_003EP, _003Csource7_003EP, _003Csource8_003EP, _003Csource9_003EP, _003Csource10_003EP, _003Csource11_003EP, _003Csource12_003EP, _003Csource13_003EP, _003Csource14_003EP, _003Csource15_003EP, _003CresultSelector_003EP).Run();
		}
	}
}
