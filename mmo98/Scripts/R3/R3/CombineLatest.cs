using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace R3
{
	internal sealed class CombineLatest<T> : Observable<T[]>
	{
		private sealed class _CombineLatest : IDisposable
		{
			private sealed class CombineLatestObserver : Observer<T>
			{
				public T? Value { get; private set; }

				[System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, "Value")]
				public bool HasValue
				{
					[System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, "Value")]
					get;
					[System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, "Value")]
					private set;
				}

				public CombineLatestObserver(_CombineLatest parent)
				{
					_003Cparent_003EP = parent;
					base._002Ector();
				}

				protected override void OnNextCore(T value)
				{
					lock (_003Cparent_003EP.observers)
					{
						Value = value;
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
					lock (_003Cparent_003EP.observers)
					{
						_003Cparent_003EP.TryPublishOnCompleted(result, !HasValue);
					}
				}
			}

			private readonly Observer<T[]> observer;

			private readonly Observable<T>[] sources;

			private readonly CombineLatestObserver[] observers;

			private bool hasValueAll;

			private int completedCount;

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
				if (this.sources.Length == 0)
				{
					observers = Array.Empty<CombineLatestObserver>();
					return;
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
				if (observers.Length == 0)
				{
					observer.OnCompleted();
					return Disposable.Empty;
				}
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
				if (!hasValueAll)
				{
					CombineLatestObserver[] array = observers;
					for (int i = 0; i < array.Length; i++)
					{
						if (!array[i].HasValue)
						{
							return;
						}
					}
					hasValueAll = true;
				}
				T[] array2 = new T[observers.Length];
				for (int j = 0; j < observers.Length; j++)
				{
					array2[j] = observers[j].Value;
				}
				observer.OnNext(array2);
			}

			public void TryPublishOnCompleted(Result result, bool empty)
			{
				if (result.IsFailure)
				{
					observer.OnCompleted(result);
					Dispose();
					return;
				}
				completedCount++;
				if (empty || completedCount == sources.Length)
				{
					observer.OnCompleted();
					Dispose();
				}
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

		public CombineLatest(IEnumerable<Observable<T>> sources)
		{
			_003Csources_003EP = sources;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T[]> observer)
		{
			return new _CombineLatest(observer, _003Csources_003EP).Run();
		}
	}
	internal sealed class CombineLatest<T1, T2, TResult> : Observable<TResult>
	{
		private sealed class _CombineLatest : IDisposable
		{
			private sealed class CombineLatestObserver<T> : Observer<T>
			{
				public T? Value { get; private set; }

				[System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, "Value")]
				public bool HasValue
				{
					[System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, "Value")]
					get;
					[System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, "Value")]
					private set;
				}

				public CombineLatestObserver(_CombineLatest parent)
				{
					_003Cparent_003EP = parent;
					base._002Ector();
				}

				protected override void OnNextCore(T value)
				{
					lock (_003Cparent_003EP.gate)
					{
						Value = value;
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
						_003Cparent_003EP.TryPublishOnCompleted(result, !HasValue);
					}
				}
			}

			private const int SourceCount = 2;

			private readonly Observer<TResult> observer;

			private readonly Observable<T1> source1;

			private readonly Observable<T2> source2;

			private readonly Func<T1, T2, TResult> resultSelector;

			private readonly CombineLatestObserver<T1> observer1;

			private readonly CombineLatestObserver<T2> observer2;

			private readonly object gate = new object();

			private bool hasValueAll;

			private int completedCount;

			public _CombineLatest(Observer<TResult> observer, Observable<T1> source1, Observable<T2> source2, Func<T1, T2, TResult> resultSelector)
			{
				this.observer = observer;
				this.source1 = source1;
				this.source2 = source2;
				this.resultSelector = resultSelector;
				observer1 = new CombineLatestObserver<T1>(this);
				observer2 = new CombineLatestObserver<T2>(this);
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
				if (!hasValueAll)
				{
					if (!observer1.HasValue || !observer2.HasValue)
					{
						return;
					}
					hasValueAll = true;
				}
				TResult value = resultSelector(observer1.Value, observer2.Value);
				observer.OnNext(value);
			}

			public void TryPublishOnCompleted(Result result, bool empty)
			{
				if (result.IsFailure)
				{
					observer.OnCompleted(result);
					Dispose();
					return;
				}
				completedCount++;
				if (empty || completedCount == 2)
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

		public CombineLatest(Observable<T1> source1, Observable<T2> source2, Func<T1, T2, TResult> resultSelector)
		{
			_003Csource1_003EP = source1;
			_003Csource2_003EP = source2;
			_003CresultSelector_003EP = resultSelector;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<TResult> observer)
		{
			return new _CombineLatest(observer, _003Csource1_003EP, _003Csource2_003EP, _003CresultSelector_003EP).Run();
		}
	}
	internal sealed class CombineLatest<T1, T2, T3, TResult> : Observable<TResult>
	{
		private sealed class _CombineLatest : IDisposable
		{
			private sealed class CombineLatestObserver<T> : Observer<T>
			{
				public T? Value { get; private set; }

				[System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, "Value")]
				public bool HasValue
				{
					[System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, "Value")]
					get;
					[System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, "Value")]
					private set;
				}

				public CombineLatestObserver(_CombineLatest parent)
				{
					_003Cparent_003EP = parent;
					base._002Ector();
				}

				protected override void OnNextCore(T value)
				{
					lock (_003Cparent_003EP.gate)
					{
						Value = value;
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
						_003Cparent_003EP.TryPublishOnCompleted(result, !HasValue);
					}
				}
			}

			private const int SourceCount = 3;

			private readonly Observer<TResult> observer;

			private readonly Observable<T1> source1;

			private readonly Observable<T2> source2;

			private readonly Observable<T3> source3;

			private readonly Func<T1, T2, T3, TResult> resultSelector;

			private readonly CombineLatestObserver<T1> observer1;

			private readonly CombineLatestObserver<T2> observer2;

			private readonly CombineLatestObserver<T3> observer3;

			private readonly object gate = new object();

			private bool hasValueAll;

			private int completedCount;

			public _CombineLatest(Observer<TResult> observer, Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Func<T1, T2, T3, TResult> resultSelector)
			{
				this.observer = observer;
				this.source1 = source1;
				this.source2 = source2;
				this.source3 = source3;
				this.resultSelector = resultSelector;
				observer1 = new CombineLatestObserver<T1>(this);
				observer2 = new CombineLatestObserver<T2>(this);
				observer3 = new CombineLatestObserver<T3>(this);
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
				if (!hasValueAll)
				{
					if (!observer1.HasValue || !observer2.HasValue || !observer3.HasValue)
					{
						return;
					}
					hasValueAll = true;
				}
				TResult value = resultSelector(observer1.Value, observer2.Value, observer3.Value);
				observer.OnNext(value);
			}

			public void TryPublishOnCompleted(Result result, bool empty)
			{
				if (result.IsFailure)
				{
					observer.OnCompleted(result);
					Dispose();
					return;
				}
				completedCount++;
				if (empty || completedCount == 3)
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

		public CombineLatest(Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Func<T1, T2, T3, TResult> resultSelector)
		{
			_003Csource1_003EP = source1;
			_003Csource2_003EP = source2;
			_003Csource3_003EP = source3;
			_003CresultSelector_003EP = resultSelector;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<TResult> observer)
		{
			return new _CombineLatest(observer, _003Csource1_003EP, _003Csource2_003EP, _003Csource3_003EP, _003CresultSelector_003EP).Run();
		}
	}
	internal sealed class CombineLatest<T1, T2, T3, T4, TResult> : Observable<TResult>
	{
		private sealed class _CombineLatest : IDisposable
		{
			private sealed class CombineLatestObserver<T> : Observer<T>
			{
				public T? Value { get; private set; }

				[System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, "Value")]
				public bool HasValue
				{
					[System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, "Value")]
					get;
					[System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, "Value")]
					private set;
				}

				public CombineLatestObserver(_CombineLatest parent)
				{
					_003Cparent_003EP = parent;
					base._002Ector();
				}

				protected override void OnNextCore(T value)
				{
					lock (_003Cparent_003EP.gate)
					{
						Value = value;
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
						_003Cparent_003EP.TryPublishOnCompleted(result, !HasValue);
					}
				}
			}

			private const int SourceCount = 4;

			private readonly Observer<TResult> observer;

			private readonly Observable<T1> source1;

			private readonly Observable<T2> source2;

			private readonly Observable<T3> source3;

			private readonly Observable<T4> source4;

			private readonly Func<T1, T2, T3, T4, TResult> resultSelector;

			private readonly CombineLatestObserver<T1> observer1;

			private readonly CombineLatestObserver<T2> observer2;

			private readonly CombineLatestObserver<T3> observer3;

			private readonly CombineLatestObserver<T4> observer4;

			private readonly object gate = new object();

			private bool hasValueAll;

			private int completedCount;

			public _CombineLatest(Observer<TResult> observer, Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Func<T1, T2, T3, T4, TResult> resultSelector)
			{
				this.observer = observer;
				this.source1 = source1;
				this.source2 = source2;
				this.source3 = source3;
				this.source4 = source4;
				this.resultSelector = resultSelector;
				observer1 = new CombineLatestObserver<T1>(this);
				observer2 = new CombineLatestObserver<T2>(this);
				observer3 = new CombineLatestObserver<T3>(this);
				observer4 = new CombineLatestObserver<T4>(this);
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
				if (!hasValueAll)
				{
					if (!observer1.HasValue || !observer2.HasValue || !observer3.HasValue || !observer4.HasValue)
					{
						return;
					}
					hasValueAll = true;
				}
				TResult value = resultSelector(observer1.Value, observer2.Value, observer3.Value, observer4.Value);
				observer.OnNext(value);
			}

			public void TryPublishOnCompleted(Result result, bool empty)
			{
				if (result.IsFailure)
				{
					observer.OnCompleted(result);
					Dispose();
					return;
				}
				completedCount++;
				if (empty || completedCount == 4)
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

		public CombineLatest(Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Func<T1, T2, T3, T4, TResult> resultSelector)
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
			return new _CombineLatest(observer, _003Csource1_003EP, _003Csource2_003EP, _003Csource3_003EP, _003Csource4_003EP, _003CresultSelector_003EP).Run();
		}
	}
	internal sealed class CombineLatest<T1, T2, T3, T4, T5, TResult> : Observable<TResult>
	{
		private sealed class _CombineLatest : IDisposable
		{
			private sealed class CombineLatestObserver<T> : Observer<T>
			{
				public T? Value { get; private set; }

				[System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, "Value")]
				public bool HasValue
				{
					[System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, "Value")]
					get;
					[System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, "Value")]
					private set;
				}

				public CombineLatestObserver(_CombineLatest parent)
				{
					_003Cparent_003EP = parent;
					base._002Ector();
				}

				protected override void OnNextCore(T value)
				{
					lock (_003Cparent_003EP.gate)
					{
						Value = value;
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
						_003Cparent_003EP.TryPublishOnCompleted(result, !HasValue);
					}
				}
			}

			private const int SourceCount = 5;

			private readonly Observer<TResult> observer;

			private readonly Observable<T1> source1;

			private readonly Observable<T2> source2;

			private readonly Observable<T3> source3;

			private readonly Observable<T4> source4;

			private readonly Observable<T5> source5;

			private readonly Func<T1, T2, T3, T4, T5, TResult> resultSelector;

			private readonly CombineLatestObserver<T1> observer1;

			private readonly CombineLatestObserver<T2> observer2;

			private readonly CombineLatestObserver<T3> observer3;

			private readonly CombineLatestObserver<T4> observer4;

			private readonly CombineLatestObserver<T5> observer5;

			private readonly object gate = new object();

			private bool hasValueAll;

			private int completedCount;

			public _CombineLatest(Observer<TResult> observer, Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Func<T1, T2, T3, T4, T5, TResult> resultSelector)
			{
				this.observer = observer;
				this.source1 = source1;
				this.source2 = source2;
				this.source3 = source3;
				this.source4 = source4;
				this.source5 = source5;
				this.resultSelector = resultSelector;
				observer1 = new CombineLatestObserver<T1>(this);
				observer2 = new CombineLatestObserver<T2>(this);
				observer3 = new CombineLatestObserver<T3>(this);
				observer4 = new CombineLatestObserver<T4>(this);
				observer5 = new CombineLatestObserver<T5>(this);
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
				if (!hasValueAll)
				{
					if (!observer1.HasValue || !observer2.HasValue || !observer3.HasValue || !observer4.HasValue || !observer5.HasValue)
					{
						return;
					}
					hasValueAll = true;
				}
				TResult value = resultSelector(observer1.Value, observer2.Value, observer3.Value, observer4.Value, observer5.Value);
				observer.OnNext(value);
			}

			public void TryPublishOnCompleted(Result result, bool empty)
			{
				if (result.IsFailure)
				{
					observer.OnCompleted(result);
					Dispose();
					return;
				}
				completedCount++;
				if (empty || completedCount == 5)
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

		public CombineLatest(Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Func<T1, T2, T3, T4, T5, TResult> resultSelector)
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
			return new _CombineLatest(observer, _003Csource1_003EP, _003Csource2_003EP, _003Csource3_003EP, _003Csource4_003EP, _003Csource5_003EP, _003CresultSelector_003EP).Run();
		}
	}
	internal sealed class CombineLatest<T1, T2, T3, T4, T5, T6, TResult> : Observable<TResult>
	{
		private sealed class _CombineLatest : IDisposable
		{
			private sealed class CombineLatestObserver<T> : Observer<T>
			{
				public T? Value { get; private set; }

				[System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, "Value")]
				public bool HasValue
				{
					[System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, "Value")]
					get;
					[System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, "Value")]
					private set;
				}

				public CombineLatestObserver(_CombineLatest parent)
				{
					_003Cparent_003EP = parent;
					base._002Ector();
				}

				protected override void OnNextCore(T value)
				{
					lock (_003Cparent_003EP.gate)
					{
						Value = value;
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
						_003Cparent_003EP.TryPublishOnCompleted(result, !HasValue);
					}
				}
			}

			private const int SourceCount = 6;

			private readonly Observer<TResult> observer;

			private readonly Observable<T1> source1;

			private readonly Observable<T2> source2;

			private readonly Observable<T3> source3;

			private readonly Observable<T4> source4;

			private readonly Observable<T5> source5;

			private readonly Observable<T6> source6;

			private readonly Func<T1, T2, T3, T4, T5, T6, TResult> resultSelector;

			private readonly CombineLatestObserver<T1> observer1;

			private readonly CombineLatestObserver<T2> observer2;

			private readonly CombineLatestObserver<T3> observer3;

			private readonly CombineLatestObserver<T4> observer4;

			private readonly CombineLatestObserver<T5> observer5;

			private readonly CombineLatestObserver<T6> observer6;

			private readonly object gate = new object();

			private bool hasValueAll;

			private int completedCount;

			public _CombineLatest(Observer<TResult> observer, Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Func<T1, T2, T3, T4, T5, T6, TResult> resultSelector)
			{
				this.observer = observer;
				this.source1 = source1;
				this.source2 = source2;
				this.source3 = source3;
				this.source4 = source4;
				this.source5 = source5;
				this.source6 = source6;
				this.resultSelector = resultSelector;
				observer1 = new CombineLatestObserver<T1>(this);
				observer2 = new CombineLatestObserver<T2>(this);
				observer3 = new CombineLatestObserver<T3>(this);
				observer4 = new CombineLatestObserver<T4>(this);
				observer5 = new CombineLatestObserver<T5>(this);
				observer6 = new CombineLatestObserver<T6>(this);
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
				if (!hasValueAll)
				{
					if (!observer1.HasValue || !observer2.HasValue || !observer3.HasValue || !observer4.HasValue || !observer5.HasValue || !observer6.HasValue)
					{
						return;
					}
					hasValueAll = true;
				}
				TResult value = resultSelector(observer1.Value, observer2.Value, observer3.Value, observer4.Value, observer5.Value, observer6.Value);
				observer.OnNext(value);
			}

			public void TryPublishOnCompleted(Result result, bool empty)
			{
				if (result.IsFailure)
				{
					observer.OnCompleted(result);
					Dispose();
					return;
				}
				completedCount++;
				if (empty || completedCount == 6)
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

		public CombineLatest(Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Func<T1, T2, T3, T4, T5, T6, TResult> resultSelector)
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
			return new _CombineLatest(observer, _003Csource1_003EP, _003Csource2_003EP, _003Csource3_003EP, _003Csource4_003EP, _003Csource5_003EP, _003Csource6_003EP, _003CresultSelector_003EP).Run();
		}
	}
	internal sealed class CombineLatest<T1, T2, T3, T4, T5, T6, T7, TResult> : Observable<TResult>
	{
		private sealed class _CombineLatest : IDisposable
		{
			private sealed class CombineLatestObserver<T> : Observer<T>
			{
				public T? Value { get; private set; }

				[System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, "Value")]
				public bool HasValue
				{
					[System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, "Value")]
					get;
					[System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, "Value")]
					private set;
				}

				public CombineLatestObserver(_CombineLatest parent)
				{
					_003Cparent_003EP = parent;
					base._002Ector();
				}

				protected override void OnNextCore(T value)
				{
					lock (_003Cparent_003EP.gate)
					{
						Value = value;
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
						_003Cparent_003EP.TryPublishOnCompleted(result, !HasValue);
					}
				}
			}

			private const int SourceCount = 7;

			private readonly Observer<TResult> observer;

			private readonly Observable<T1> source1;

			private readonly Observable<T2> source2;

			private readonly Observable<T3> source3;

			private readonly Observable<T4> source4;

			private readonly Observable<T5> source5;

			private readonly Observable<T6> source6;

			private readonly Observable<T7> source7;

			private readonly Func<T1, T2, T3, T4, T5, T6, T7, TResult> resultSelector;

			private readonly CombineLatestObserver<T1> observer1;

			private readonly CombineLatestObserver<T2> observer2;

			private readonly CombineLatestObserver<T3> observer3;

			private readonly CombineLatestObserver<T4> observer4;

			private readonly CombineLatestObserver<T5> observer5;

			private readonly CombineLatestObserver<T6> observer6;

			private readonly CombineLatestObserver<T7> observer7;

			private readonly object gate = new object();

			private bool hasValueAll;

			private int completedCount;

			public _CombineLatest(Observer<TResult> observer, Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Func<T1, T2, T3, T4, T5, T6, T7, TResult> resultSelector)
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
				observer1 = new CombineLatestObserver<T1>(this);
				observer2 = new CombineLatestObserver<T2>(this);
				observer3 = new CombineLatestObserver<T3>(this);
				observer4 = new CombineLatestObserver<T4>(this);
				observer5 = new CombineLatestObserver<T5>(this);
				observer6 = new CombineLatestObserver<T6>(this);
				observer7 = new CombineLatestObserver<T7>(this);
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
				if (!hasValueAll)
				{
					if (!observer1.HasValue || !observer2.HasValue || !observer3.HasValue || !observer4.HasValue || !observer5.HasValue || !observer6.HasValue || !observer7.HasValue)
					{
						return;
					}
					hasValueAll = true;
				}
				TResult value = resultSelector(observer1.Value, observer2.Value, observer3.Value, observer4.Value, observer5.Value, observer6.Value, observer7.Value);
				observer.OnNext(value);
			}

			public void TryPublishOnCompleted(Result result, bool empty)
			{
				if (result.IsFailure)
				{
					observer.OnCompleted(result);
					Dispose();
					return;
				}
				completedCount++;
				if (empty || completedCount == 7)
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

		public CombineLatest(Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Func<T1, T2, T3, T4, T5, T6, T7, TResult> resultSelector)
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
			return new _CombineLatest(observer, _003Csource1_003EP, _003Csource2_003EP, _003Csource3_003EP, _003Csource4_003EP, _003Csource5_003EP, _003Csource6_003EP, _003Csource7_003EP, _003CresultSelector_003EP).Run();
		}
	}
	internal sealed class CombineLatest<T1, T2, T3, T4, T5, T6, T7, T8, TResult> : Observable<TResult>
	{
		private sealed class _CombineLatest : IDisposable
		{
			private sealed class CombineLatestObserver<T> : Observer<T>
			{
				public T? Value { get; private set; }

				[System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, "Value")]
				public bool HasValue
				{
					[System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, "Value")]
					get;
					[System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, "Value")]
					private set;
				}

				public CombineLatestObserver(_CombineLatest parent)
				{
					_003Cparent_003EP = parent;
					base._002Ector();
				}

				protected override void OnNextCore(T value)
				{
					lock (_003Cparent_003EP.gate)
					{
						Value = value;
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
						_003Cparent_003EP.TryPublishOnCompleted(result, !HasValue);
					}
				}
			}

			private const int SourceCount = 8;

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

			private readonly CombineLatestObserver<T1> observer1;

			private readonly CombineLatestObserver<T2> observer2;

			private readonly CombineLatestObserver<T3> observer3;

			private readonly CombineLatestObserver<T4> observer4;

			private readonly CombineLatestObserver<T5> observer5;

			private readonly CombineLatestObserver<T6> observer6;

			private readonly CombineLatestObserver<T7> observer7;

			private readonly CombineLatestObserver<T8> observer8;

			private readonly object gate = new object();

			private bool hasValueAll;

			private int completedCount;

			public _CombineLatest(Observer<TResult> observer, Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> resultSelector)
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
				observer1 = new CombineLatestObserver<T1>(this);
				observer2 = new CombineLatestObserver<T2>(this);
				observer3 = new CombineLatestObserver<T3>(this);
				observer4 = new CombineLatestObserver<T4>(this);
				observer5 = new CombineLatestObserver<T5>(this);
				observer6 = new CombineLatestObserver<T6>(this);
				observer7 = new CombineLatestObserver<T7>(this);
				observer8 = new CombineLatestObserver<T8>(this);
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
				if (!hasValueAll)
				{
					if (!observer1.HasValue || !observer2.HasValue || !observer3.HasValue || !observer4.HasValue || !observer5.HasValue || !observer6.HasValue || !observer7.HasValue || !observer8.HasValue)
					{
						return;
					}
					hasValueAll = true;
				}
				TResult value = resultSelector(observer1.Value, observer2.Value, observer3.Value, observer4.Value, observer5.Value, observer6.Value, observer7.Value, observer8.Value);
				observer.OnNext(value);
			}

			public void TryPublishOnCompleted(Result result, bool empty)
			{
				if (result.IsFailure)
				{
					observer.OnCompleted(result);
					Dispose();
					return;
				}
				completedCount++;
				if (empty || completedCount == 8)
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

		public CombineLatest(Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> resultSelector)
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
			return new _CombineLatest(observer, _003Csource1_003EP, _003Csource2_003EP, _003Csource3_003EP, _003Csource4_003EP, _003Csource5_003EP, _003Csource6_003EP, _003Csource7_003EP, _003Csource8_003EP, _003CresultSelector_003EP).Run();
		}
	}
	internal sealed class CombineLatest<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> : Observable<TResult>
	{
		private sealed class _CombineLatest : IDisposable
		{
			private sealed class CombineLatestObserver<T> : Observer<T>
			{
				public T? Value { get; private set; }

				[System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, "Value")]
				public bool HasValue
				{
					[System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, "Value")]
					get;
					[System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, "Value")]
					private set;
				}

				public CombineLatestObserver(_CombineLatest parent)
				{
					_003Cparent_003EP = parent;
					base._002Ector();
				}

				protected override void OnNextCore(T value)
				{
					lock (_003Cparent_003EP.gate)
					{
						Value = value;
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
						_003Cparent_003EP.TryPublishOnCompleted(result, !HasValue);
					}
				}
			}

			private const int SourceCount = 9;

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

			private readonly CombineLatestObserver<T1> observer1;

			private readonly CombineLatestObserver<T2> observer2;

			private readonly CombineLatestObserver<T3> observer3;

			private readonly CombineLatestObserver<T4> observer4;

			private readonly CombineLatestObserver<T5> observer5;

			private readonly CombineLatestObserver<T6> observer6;

			private readonly CombineLatestObserver<T7> observer7;

			private readonly CombineLatestObserver<T8> observer8;

			private readonly CombineLatestObserver<T9> observer9;

			private readonly object gate = new object();

			private bool hasValueAll;

			private int completedCount;

			public _CombineLatest(Observer<TResult> observer, Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> resultSelector)
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
				observer1 = new CombineLatestObserver<T1>(this);
				observer2 = new CombineLatestObserver<T2>(this);
				observer3 = new CombineLatestObserver<T3>(this);
				observer4 = new CombineLatestObserver<T4>(this);
				observer5 = new CombineLatestObserver<T5>(this);
				observer6 = new CombineLatestObserver<T6>(this);
				observer7 = new CombineLatestObserver<T7>(this);
				observer8 = new CombineLatestObserver<T8>(this);
				observer9 = new CombineLatestObserver<T9>(this);
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
				if (!hasValueAll)
				{
					if (!observer1.HasValue || !observer2.HasValue || !observer3.HasValue || !observer4.HasValue || !observer5.HasValue || !observer6.HasValue || !observer7.HasValue || !observer8.HasValue || !observer9.HasValue)
					{
						return;
					}
					hasValueAll = true;
				}
				TResult value = resultSelector(observer1.Value, observer2.Value, observer3.Value, observer4.Value, observer5.Value, observer6.Value, observer7.Value, observer8.Value, observer9.Value);
				observer.OnNext(value);
			}

			public void TryPublishOnCompleted(Result result, bool empty)
			{
				if (result.IsFailure)
				{
					observer.OnCompleted(result);
					Dispose();
					return;
				}
				completedCount++;
				if (empty || completedCount == 9)
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

		public CombineLatest(Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> resultSelector)
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
			return new _CombineLatest(observer, _003Csource1_003EP, _003Csource2_003EP, _003Csource3_003EP, _003Csource4_003EP, _003Csource5_003EP, _003Csource6_003EP, _003Csource7_003EP, _003Csource8_003EP, _003Csource9_003EP, _003CresultSelector_003EP).Run();
		}
	}
	internal sealed class CombineLatest<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> : Observable<TResult>
	{
		private sealed class _CombineLatest : IDisposable
		{
			private sealed class CombineLatestObserver<T> : Observer<T>
			{
				public T? Value { get; private set; }

				[System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, "Value")]
				public bool HasValue
				{
					[System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, "Value")]
					get;
					[System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, "Value")]
					private set;
				}

				public CombineLatestObserver(_CombineLatest parent)
				{
					_003Cparent_003EP = parent;
					base._002Ector();
				}

				protected override void OnNextCore(T value)
				{
					lock (_003Cparent_003EP.gate)
					{
						Value = value;
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
						_003Cparent_003EP.TryPublishOnCompleted(result, !HasValue);
					}
				}
			}

			private const int SourceCount = 10;

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

			private readonly CombineLatestObserver<T1> observer1;

			private readonly CombineLatestObserver<T2> observer2;

			private readonly CombineLatestObserver<T3> observer3;

			private readonly CombineLatestObserver<T4> observer4;

			private readonly CombineLatestObserver<T5> observer5;

			private readonly CombineLatestObserver<T6> observer6;

			private readonly CombineLatestObserver<T7> observer7;

			private readonly CombineLatestObserver<T8> observer8;

			private readonly CombineLatestObserver<T9> observer9;

			private readonly CombineLatestObserver<T10> observer10;

			private readonly object gate = new object();

			private bool hasValueAll;

			private int completedCount;

			public _CombineLatest(Observer<TResult> observer, Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> resultSelector)
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
				observer1 = new CombineLatestObserver<T1>(this);
				observer2 = new CombineLatestObserver<T2>(this);
				observer3 = new CombineLatestObserver<T3>(this);
				observer4 = new CombineLatestObserver<T4>(this);
				observer5 = new CombineLatestObserver<T5>(this);
				observer6 = new CombineLatestObserver<T6>(this);
				observer7 = new CombineLatestObserver<T7>(this);
				observer8 = new CombineLatestObserver<T8>(this);
				observer9 = new CombineLatestObserver<T9>(this);
				observer10 = new CombineLatestObserver<T10>(this);
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
				if (!hasValueAll)
				{
					if (!observer1.HasValue || !observer2.HasValue || !observer3.HasValue || !observer4.HasValue || !observer5.HasValue || !observer6.HasValue || !observer7.HasValue || !observer8.HasValue || !observer9.HasValue || !observer10.HasValue)
					{
						return;
					}
					hasValueAll = true;
				}
				TResult value = resultSelector(observer1.Value, observer2.Value, observer3.Value, observer4.Value, observer5.Value, observer6.Value, observer7.Value, observer8.Value, observer9.Value, observer10.Value);
				observer.OnNext(value);
			}

			public void TryPublishOnCompleted(Result result, bool empty)
			{
				if (result.IsFailure)
				{
					observer.OnCompleted(result);
					Dispose();
					return;
				}
				completedCount++;
				if (empty || completedCount == 10)
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

		public CombineLatest(Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> resultSelector)
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
			return new _CombineLatest(observer, _003Csource1_003EP, _003Csource2_003EP, _003Csource3_003EP, _003Csource4_003EP, _003Csource5_003EP, _003Csource6_003EP, _003Csource7_003EP, _003Csource8_003EP, _003Csource9_003EP, _003Csource10_003EP, _003CresultSelector_003EP).Run();
		}
	}
	internal sealed class CombineLatest<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> : Observable<TResult>
	{
		private sealed class _CombineLatest : IDisposable
		{
			private sealed class CombineLatestObserver<T> : Observer<T>
			{
				public T? Value { get; private set; }

				[System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, "Value")]
				public bool HasValue
				{
					[System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, "Value")]
					get;
					[System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, "Value")]
					private set;
				}

				public CombineLatestObserver(_CombineLatest parent)
				{
					_003Cparent_003EP = parent;
					base._002Ector();
				}

				protected override void OnNextCore(T value)
				{
					lock (_003Cparent_003EP.gate)
					{
						Value = value;
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
						_003Cparent_003EP.TryPublishOnCompleted(result, !HasValue);
					}
				}
			}

			private const int SourceCount = 11;

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

			private readonly CombineLatestObserver<T1> observer1;

			private readonly CombineLatestObserver<T2> observer2;

			private readonly CombineLatestObserver<T3> observer3;

			private readonly CombineLatestObserver<T4> observer4;

			private readonly CombineLatestObserver<T5> observer5;

			private readonly CombineLatestObserver<T6> observer6;

			private readonly CombineLatestObserver<T7> observer7;

			private readonly CombineLatestObserver<T8> observer8;

			private readonly CombineLatestObserver<T9> observer9;

			private readonly CombineLatestObserver<T10> observer10;

			private readonly CombineLatestObserver<T11> observer11;

			private readonly object gate = new object();

			private bool hasValueAll;

			private int completedCount;

			public _CombineLatest(Observer<TResult> observer, Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Observable<T11> source11, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> resultSelector)
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
				observer1 = new CombineLatestObserver<T1>(this);
				observer2 = new CombineLatestObserver<T2>(this);
				observer3 = new CombineLatestObserver<T3>(this);
				observer4 = new CombineLatestObserver<T4>(this);
				observer5 = new CombineLatestObserver<T5>(this);
				observer6 = new CombineLatestObserver<T6>(this);
				observer7 = new CombineLatestObserver<T7>(this);
				observer8 = new CombineLatestObserver<T8>(this);
				observer9 = new CombineLatestObserver<T9>(this);
				observer10 = new CombineLatestObserver<T10>(this);
				observer11 = new CombineLatestObserver<T11>(this);
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
				if (!hasValueAll)
				{
					if (!observer1.HasValue || !observer2.HasValue || !observer3.HasValue || !observer4.HasValue || !observer5.HasValue || !observer6.HasValue || !observer7.HasValue || !observer8.HasValue || !observer9.HasValue || !observer10.HasValue || !observer11.HasValue)
					{
						return;
					}
					hasValueAll = true;
				}
				TResult value = resultSelector(observer1.Value, observer2.Value, observer3.Value, observer4.Value, observer5.Value, observer6.Value, observer7.Value, observer8.Value, observer9.Value, observer10.Value, observer11.Value);
				observer.OnNext(value);
			}

			public void TryPublishOnCompleted(Result result, bool empty)
			{
				if (result.IsFailure)
				{
					observer.OnCompleted(result);
					Dispose();
					return;
				}
				completedCount++;
				if (empty || completedCount == 11)
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

		public CombineLatest(Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Observable<T11> source11, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> resultSelector)
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
			return new _CombineLatest(observer, _003Csource1_003EP, _003Csource2_003EP, _003Csource3_003EP, _003Csource4_003EP, _003Csource5_003EP, _003Csource6_003EP, _003Csource7_003EP, _003Csource8_003EP, _003Csource9_003EP, _003Csource10_003EP, _003Csource11_003EP, _003CresultSelector_003EP).Run();
		}
	}
	internal sealed class CombineLatest<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> : Observable<TResult>
	{
		private sealed class _CombineLatest : IDisposable
		{
			private sealed class CombineLatestObserver<T> : Observer<T>
			{
				public T? Value { get; private set; }

				[System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, "Value")]
				public bool HasValue
				{
					[System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, "Value")]
					get;
					[System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, "Value")]
					private set;
				}

				public CombineLatestObserver(_CombineLatest parent)
				{
					_003Cparent_003EP = parent;
					base._002Ector();
				}

				protected override void OnNextCore(T value)
				{
					lock (_003Cparent_003EP.gate)
					{
						Value = value;
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
						_003Cparent_003EP.TryPublishOnCompleted(result, !HasValue);
					}
				}
			}

			private const int SourceCount = 12;

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

			private readonly CombineLatestObserver<T1> observer1;

			private readonly CombineLatestObserver<T2> observer2;

			private readonly CombineLatestObserver<T3> observer3;

			private readonly CombineLatestObserver<T4> observer4;

			private readonly CombineLatestObserver<T5> observer5;

			private readonly CombineLatestObserver<T6> observer6;

			private readonly CombineLatestObserver<T7> observer7;

			private readonly CombineLatestObserver<T8> observer8;

			private readonly CombineLatestObserver<T9> observer9;

			private readonly CombineLatestObserver<T10> observer10;

			private readonly CombineLatestObserver<T11> observer11;

			private readonly CombineLatestObserver<T12> observer12;

			private readonly object gate = new object();

			private bool hasValueAll;

			private int completedCount;

			public _CombineLatest(Observer<TResult> observer, Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Observable<T11> source11, Observable<T12> source12, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> resultSelector)
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
				observer1 = new CombineLatestObserver<T1>(this);
				observer2 = new CombineLatestObserver<T2>(this);
				observer3 = new CombineLatestObserver<T3>(this);
				observer4 = new CombineLatestObserver<T4>(this);
				observer5 = new CombineLatestObserver<T5>(this);
				observer6 = new CombineLatestObserver<T6>(this);
				observer7 = new CombineLatestObserver<T7>(this);
				observer8 = new CombineLatestObserver<T8>(this);
				observer9 = new CombineLatestObserver<T9>(this);
				observer10 = new CombineLatestObserver<T10>(this);
				observer11 = new CombineLatestObserver<T11>(this);
				observer12 = new CombineLatestObserver<T12>(this);
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
				if (!hasValueAll)
				{
					if (!observer1.HasValue || !observer2.HasValue || !observer3.HasValue || !observer4.HasValue || !observer5.HasValue || !observer6.HasValue || !observer7.HasValue || !observer8.HasValue || !observer9.HasValue || !observer10.HasValue || !observer11.HasValue || !observer12.HasValue)
					{
						return;
					}
					hasValueAll = true;
				}
				TResult value = resultSelector(observer1.Value, observer2.Value, observer3.Value, observer4.Value, observer5.Value, observer6.Value, observer7.Value, observer8.Value, observer9.Value, observer10.Value, observer11.Value, observer12.Value);
				observer.OnNext(value);
			}

			public void TryPublishOnCompleted(Result result, bool empty)
			{
				if (result.IsFailure)
				{
					observer.OnCompleted(result);
					Dispose();
					return;
				}
				completedCount++;
				if (empty || completedCount == 12)
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

		public CombineLatest(Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Observable<T11> source11, Observable<T12> source12, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> resultSelector)
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
			return new _CombineLatest(observer, _003Csource1_003EP, _003Csource2_003EP, _003Csource3_003EP, _003Csource4_003EP, _003Csource5_003EP, _003Csource6_003EP, _003Csource7_003EP, _003Csource8_003EP, _003Csource9_003EP, _003Csource10_003EP, _003Csource11_003EP, _003Csource12_003EP, _003CresultSelector_003EP).Run();
		}
	}
	internal sealed class CombineLatest<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> : Observable<TResult>
	{
		private sealed class _CombineLatest : IDisposable
		{
			private sealed class CombineLatestObserver<T> : Observer<T>
			{
				public T? Value { get; private set; }

				[System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, "Value")]
				public bool HasValue
				{
					[System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, "Value")]
					get;
					[System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, "Value")]
					private set;
				}

				public CombineLatestObserver(_CombineLatest parent)
				{
					_003Cparent_003EP = parent;
					base._002Ector();
				}

				protected override void OnNextCore(T value)
				{
					lock (_003Cparent_003EP.gate)
					{
						Value = value;
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
						_003Cparent_003EP.TryPublishOnCompleted(result, !HasValue);
					}
				}
			}

			private const int SourceCount = 13;

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

			private readonly CombineLatestObserver<T1> observer1;

			private readonly CombineLatestObserver<T2> observer2;

			private readonly CombineLatestObserver<T3> observer3;

			private readonly CombineLatestObserver<T4> observer4;

			private readonly CombineLatestObserver<T5> observer5;

			private readonly CombineLatestObserver<T6> observer6;

			private readonly CombineLatestObserver<T7> observer7;

			private readonly CombineLatestObserver<T8> observer8;

			private readonly CombineLatestObserver<T9> observer9;

			private readonly CombineLatestObserver<T10> observer10;

			private readonly CombineLatestObserver<T11> observer11;

			private readonly CombineLatestObserver<T12> observer12;

			private readonly CombineLatestObserver<T13> observer13;

			private readonly object gate = new object();

			private bool hasValueAll;

			private int completedCount;

			public _CombineLatest(Observer<TResult> observer, Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Observable<T11> source11, Observable<T12> source12, Observable<T13> source13, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> resultSelector)
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
				observer1 = new CombineLatestObserver<T1>(this);
				observer2 = new CombineLatestObserver<T2>(this);
				observer3 = new CombineLatestObserver<T3>(this);
				observer4 = new CombineLatestObserver<T4>(this);
				observer5 = new CombineLatestObserver<T5>(this);
				observer6 = new CombineLatestObserver<T6>(this);
				observer7 = new CombineLatestObserver<T7>(this);
				observer8 = new CombineLatestObserver<T8>(this);
				observer9 = new CombineLatestObserver<T9>(this);
				observer10 = new CombineLatestObserver<T10>(this);
				observer11 = new CombineLatestObserver<T11>(this);
				observer12 = new CombineLatestObserver<T12>(this);
				observer13 = new CombineLatestObserver<T13>(this);
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
				if (!hasValueAll)
				{
					if (!observer1.HasValue || !observer2.HasValue || !observer3.HasValue || !observer4.HasValue || !observer5.HasValue || !observer6.HasValue || !observer7.HasValue || !observer8.HasValue || !observer9.HasValue || !observer10.HasValue || !observer11.HasValue || !observer12.HasValue || !observer13.HasValue)
					{
						return;
					}
					hasValueAll = true;
				}
				TResult value = resultSelector(observer1.Value, observer2.Value, observer3.Value, observer4.Value, observer5.Value, observer6.Value, observer7.Value, observer8.Value, observer9.Value, observer10.Value, observer11.Value, observer12.Value, observer13.Value);
				observer.OnNext(value);
			}

			public void TryPublishOnCompleted(Result result, bool empty)
			{
				if (result.IsFailure)
				{
					observer.OnCompleted(result);
					Dispose();
					return;
				}
				completedCount++;
				if (empty || completedCount == 13)
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

		public CombineLatest(Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Observable<T11> source11, Observable<T12> source12, Observable<T13> source13, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> resultSelector)
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
			return new _CombineLatest(observer, _003Csource1_003EP, _003Csource2_003EP, _003Csource3_003EP, _003Csource4_003EP, _003Csource5_003EP, _003Csource6_003EP, _003Csource7_003EP, _003Csource8_003EP, _003Csource9_003EP, _003Csource10_003EP, _003Csource11_003EP, _003Csource12_003EP, _003Csource13_003EP, _003CresultSelector_003EP).Run();
		}
	}
	internal sealed class CombineLatest<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> : Observable<TResult>
	{
		private sealed class _CombineLatest : IDisposable
		{
			private sealed class CombineLatestObserver<T> : Observer<T>
			{
				public T? Value { get; private set; }

				[System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, "Value")]
				public bool HasValue
				{
					[System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, "Value")]
					get;
					[System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, "Value")]
					private set;
				}

				public CombineLatestObserver(_CombineLatest parent)
				{
					_003Cparent_003EP = parent;
					base._002Ector();
				}

				protected override void OnNextCore(T value)
				{
					lock (_003Cparent_003EP.gate)
					{
						Value = value;
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
						_003Cparent_003EP.TryPublishOnCompleted(result, !HasValue);
					}
				}
			}

			private const int SourceCount = 14;

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

			private readonly CombineLatestObserver<T1> observer1;

			private readonly CombineLatestObserver<T2> observer2;

			private readonly CombineLatestObserver<T3> observer3;

			private readonly CombineLatestObserver<T4> observer4;

			private readonly CombineLatestObserver<T5> observer5;

			private readonly CombineLatestObserver<T6> observer6;

			private readonly CombineLatestObserver<T7> observer7;

			private readonly CombineLatestObserver<T8> observer8;

			private readonly CombineLatestObserver<T9> observer9;

			private readonly CombineLatestObserver<T10> observer10;

			private readonly CombineLatestObserver<T11> observer11;

			private readonly CombineLatestObserver<T12> observer12;

			private readonly CombineLatestObserver<T13> observer13;

			private readonly CombineLatestObserver<T14> observer14;

			private readonly object gate = new object();

			private bool hasValueAll;

			private int completedCount;

			public _CombineLatest(Observer<TResult> observer, Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Observable<T11> source11, Observable<T12> source12, Observable<T13> source13, Observable<T14> source14, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> resultSelector)
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
				observer1 = new CombineLatestObserver<T1>(this);
				observer2 = new CombineLatestObserver<T2>(this);
				observer3 = new CombineLatestObserver<T3>(this);
				observer4 = new CombineLatestObserver<T4>(this);
				observer5 = new CombineLatestObserver<T5>(this);
				observer6 = new CombineLatestObserver<T6>(this);
				observer7 = new CombineLatestObserver<T7>(this);
				observer8 = new CombineLatestObserver<T8>(this);
				observer9 = new CombineLatestObserver<T9>(this);
				observer10 = new CombineLatestObserver<T10>(this);
				observer11 = new CombineLatestObserver<T11>(this);
				observer12 = new CombineLatestObserver<T12>(this);
				observer13 = new CombineLatestObserver<T13>(this);
				observer14 = new CombineLatestObserver<T14>(this);
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
				if (!hasValueAll)
				{
					if (!observer1.HasValue || !observer2.HasValue || !observer3.HasValue || !observer4.HasValue || !observer5.HasValue || !observer6.HasValue || !observer7.HasValue || !observer8.HasValue || !observer9.HasValue || !observer10.HasValue || !observer11.HasValue || !observer12.HasValue || !observer13.HasValue || !observer14.HasValue)
					{
						return;
					}
					hasValueAll = true;
				}
				TResult value = resultSelector(observer1.Value, observer2.Value, observer3.Value, observer4.Value, observer5.Value, observer6.Value, observer7.Value, observer8.Value, observer9.Value, observer10.Value, observer11.Value, observer12.Value, observer13.Value, observer14.Value);
				observer.OnNext(value);
			}

			public void TryPublishOnCompleted(Result result, bool empty)
			{
				if (result.IsFailure)
				{
					observer.OnCompleted(result);
					Dispose();
					return;
				}
				completedCount++;
				if (empty || completedCount == 14)
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

		public CombineLatest(Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Observable<T11> source11, Observable<T12> source12, Observable<T13> source13, Observable<T14> source14, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> resultSelector)
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
			return new _CombineLatest(observer, _003Csource1_003EP, _003Csource2_003EP, _003Csource3_003EP, _003Csource4_003EP, _003Csource5_003EP, _003Csource6_003EP, _003Csource7_003EP, _003Csource8_003EP, _003Csource9_003EP, _003Csource10_003EP, _003Csource11_003EP, _003Csource12_003EP, _003Csource13_003EP, _003Csource14_003EP, _003CresultSelector_003EP).Run();
		}
	}
	internal sealed class CombineLatest<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> : Observable<TResult>
	{
		private sealed class _CombineLatest : IDisposable
		{
			private sealed class CombineLatestObserver<T> : Observer<T>
			{
				public T? Value { get; private set; }

				[System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, "Value")]
				public bool HasValue
				{
					[System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, "Value")]
					get;
					[System.Diagnostics.CodeAnalysis.MemberNotNullWhen(true, "Value")]
					private set;
				}

				public CombineLatestObserver(_CombineLatest parent)
				{
					_003Cparent_003EP = parent;
					base._002Ector();
				}

				protected override void OnNextCore(T value)
				{
					lock (_003Cparent_003EP.gate)
					{
						Value = value;
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
						_003Cparent_003EP.TryPublishOnCompleted(result, !HasValue);
					}
				}
			}

			private const int SourceCount = 15;

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

			private readonly CombineLatestObserver<T1> observer1;

			private readonly CombineLatestObserver<T2> observer2;

			private readonly CombineLatestObserver<T3> observer3;

			private readonly CombineLatestObserver<T4> observer4;

			private readonly CombineLatestObserver<T5> observer5;

			private readonly CombineLatestObserver<T6> observer6;

			private readonly CombineLatestObserver<T7> observer7;

			private readonly CombineLatestObserver<T8> observer8;

			private readonly CombineLatestObserver<T9> observer9;

			private readonly CombineLatestObserver<T10> observer10;

			private readonly CombineLatestObserver<T11> observer11;

			private readonly CombineLatestObserver<T12> observer12;

			private readonly CombineLatestObserver<T13> observer13;

			private readonly CombineLatestObserver<T14> observer14;

			private readonly CombineLatestObserver<T15> observer15;

			private readonly object gate = new object();

			private bool hasValueAll;

			private int completedCount;

			public _CombineLatest(Observer<TResult> observer, Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Observable<T11> source11, Observable<T12> source12, Observable<T13> source13, Observable<T14> source14, Observable<T15> source15, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> resultSelector)
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
				observer1 = new CombineLatestObserver<T1>(this);
				observer2 = new CombineLatestObserver<T2>(this);
				observer3 = new CombineLatestObserver<T3>(this);
				observer4 = new CombineLatestObserver<T4>(this);
				observer5 = new CombineLatestObserver<T5>(this);
				observer6 = new CombineLatestObserver<T6>(this);
				observer7 = new CombineLatestObserver<T7>(this);
				observer8 = new CombineLatestObserver<T8>(this);
				observer9 = new CombineLatestObserver<T9>(this);
				observer10 = new CombineLatestObserver<T10>(this);
				observer11 = new CombineLatestObserver<T11>(this);
				observer12 = new CombineLatestObserver<T12>(this);
				observer13 = new CombineLatestObserver<T13>(this);
				observer14 = new CombineLatestObserver<T14>(this);
				observer15 = new CombineLatestObserver<T15>(this);
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
				if (!hasValueAll)
				{
					if (!observer1.HasValue || !observer2.HasValue || !observer3.HasValue || !observer4.HasValue || !observer5.HasValue || !observer6.HasValue || !observer7.HasValue || !observer8.HasValue || !observer9.HasValue || !observer10.HasValue || !observer11.HasValue || !observer12.HasValue || !observer13.HasValue || !observer14.HasValue || !observer15.HasValue)
					{
						return;
					}
					hasValueAll = true;
				}
				TResult value = resultSelector(observer1.Value, observer2.Value, observer3.Value, observer4.Value, observer5.Value, observer6.Value, observer7.Value, observer8.Value, observer9.Value, observer10.Value, observer11.Value, observer12.Value, observer13.Value, observer14.Value, observer15.Value);
				observer.OnNext(value);
			}

			public void TryPublishOnCompleted(Result result, bool empty)
			{
				if (result.IsFailure)
				{
					observer.OnCompleted(result);
					Dispose();
					return;
				}
				completedCount++;
				if (empty || completedCount == 15)
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

		public CombineLatest(Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Observable<T11> source11, Observable<T12> source12, Observable<T13> source13, Observable<T14> source14, Observable<T15> source15, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> resultSelector)
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
			return new _CombineLatest(observer, _003Csource1_003EP, _003Csource2_003EP, _003Csource3_003EP, _003Csource4_003EP, _003Csource5_003EP, _003Csource6_003EP, _003Csource7_003EP, _003Csource8_003EP, _003Csource9_003EP, _003Csource10_003EP, _003Csource11_003EP, _003Csource12_003EP, _003Csource13_003EP, _003Csource14_003EP, _003Csource15_003EP, _003CresultSelector_003EP).Run();
		}
	}
}
