using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using R3.Internal;

namespace R3
{
	public static class Observable
	{
		public static Observable<T[]> CombineLatest<T>(params Observable<T>[] sources)
		{
			return new CombineLatest<T>(sources);
		}

		public static Observable<T[]> CombineLatest<T>(IEnumerable<Observable<T>> sources)
		{
			return new CombineLatest<T>(sources);
		}

		public static Observable<T> Concat<T>(params Observable<T>[] sources)
		{
			return new Concat<T>(sources);
		}

		public static Observable<T> Concat<T>(IEnumerable<Observable<T>> sources)
		{
			return new Concat<T>(sources);
		}

		public static Observable<T> Create<T>(Func<Observer<T>, IDisposable> subscribe, bool rawObserver = false)
		{
			return new AnonymousObservable<T>(subscribe, rawObserver);
		}

		public static Observable<T> Create<T, TState>(TState state, Func<Observer<T>, TState, IDisposable> subscribe, bool rawObserver = false)
		{
			return new AnonymousObservable<T, TState>(state, subscribe, rawObserver);
		}

		public static Observable<T> Create<T>(Func<Observer<T>, CancellationToken, ValueTask> subscribe, bool rawObserver = false)
		{
			return new AsyncAnonymousObservable<T>(subscribe, rawObserver);
		}

		public static Observable<T> Create<T, TState>(TState state, Func<Observer<T>, TState, CancellationToken, ValueTask> subscribe, bool rawObserver = false)
		{
			return new AsyncAnonymousObservable<T, TState>(state, subscribe, rawObserver);
		}

		public static Observable<T> CreateFrom<T>(Func<CancellationToken, IAsyncEnumerable<T>> factory)
		{
			return new CreateFrom<T>(factory);
		}

		public static Observable<T> CreateFrom<T, TState>(TState state, Func<CancellationToken, TState, IAsyncEnumerable<T>> factory)
		{
			return new CreateFrom<T, TState>(state, factory);
		}

		public static Observable<T> Defer<T>(Func<Observable<T>> observableFactory, bool rawObserver = false)
		{
			return new Defer<T>(observableFactory, rawObserver);
		}

		public static Observable<T> Empty<T>()
		{
			return R3.Empty<T>.Instance;
		}

		public static Observable<T> Empty<T>(TimeProvider timeProvider)
		{
			return ReturnOnCompleted<T>(Result.Success, timeProvider);
		}

		public static Observable<T> Empty<T>(TimeSpan dueTime, TimeProvider timeProvider)
		{
			return ReturnOnCompleted<T>(Result.Success, dueTime, timeProvider);
		}

		public static Observable<Unit> EveryUpdate()
		{
			return new EveryUpdate(ObservableSystem.DefaultFrameProvider, CancellationToken.None);
		}

		public static Observable<Unit> EveryUpdate(CancellationToken cancellationToken)
		{
			if (cancellationToken.IsCancellationRequested)
			{
				return Empty<Unit>();
			}
			return new EveryUpdate(ObservableSystem.DefaultFrameProvider, cancellationToken);
		}

		public static Observable<Unit> EveryUpdate(FrameProvider frameProvider)
		{
			return new EveryUpdate(frameProvider, CancellationToken.None);
		}

		public static Observable<Unit> EveryUpdate(FrameProvider frameProvider, CancellationToken cancellationToken)
		{
			if (cancellationToken.IsCancellationRequested)
			{
				return Empty<Unit>();
			}
			return new EveryUpdate(frameProvider, cancellationToken);
		}

		public static Observable<TProperty> EveryValueChanged<TSource, TProperty>(TSource source, Func<TSource, TProperty> propertySelector, CancellationToken cancellationToken = default(CancellationToken)) where TSource : class
		{
			return EveryValueChanged(source, propertySelector, ObservableSystem.DefaultFrameProvider, EqualityComparer<TProperty>.Default, cancellationToken);
		}

		public static Observable<TProperty> EveryValueChanged<TSource, TProperty>(TSource source, Func<TSource, TProperty> propertySelector, FrameProvider frameProvider, CancellationToken cancellationToken = default(CancellationToken)) where TSource : class
		{
			return EveryValueChanged(source, propertySelector, frameProvider, EqualityComparer<TProperty>.Default, cancellationToken);
		}

		public static Observable<TProperty> EveryValueChanged<TSource, TProperty>(TSource source, Func<TSource, TProperty> propertySelector, EqualityComparer<TProperty> equalityComparer, CancellationToken cancellationToken = default(CancellationToken)) where TSource : class
		{
			return EveryValueChanged(source, propertySelector, ObservableSystem.DefaultFrameProvider, equalityComparer, cancellationToken);
		}

		public static Observable<TProperty> EveryValueChanged<TSource, TProperty>(TSource source, Func<TSource, TProperty> propertySelector, FrameProvider frameProvider, EqualityComparer<TProperty> equalityComparer, CancellationToken cancellationToken = default(CancellationToken)) where TSource : class
		{
			return new EveryValueChanged<TSource, TProperty>(source, propertySelector, frameProvider, equalityComparer, cancellationToken);
		}

		public static Observable<Unit> FromAsync(Func<CancellationToken, ValueTask> asyncFactory, bool configureAwait = true)
		{
			return new FromAsync(asyncFactory, configureAwait);
		}

		public static Observable<T> FromAsync<T>(Func<CancellationToken, ValueTask<T>> asyncFactory, bool configureAwait = true)
		{
			return new FromAsync<T>(asyncFactory, configureAwait);
		}

		public static Observable<(object? sender, EventArgs e)> FromEventHandler(Action<EventHandler> addHandler, Action<EventHandler> removeHandler, CancellationToken cancellationToken = default(CancellationToken))
		{
			return new FromEvent<EventHandler, (object, EventArgs)>((Action<(object? sender, EventArgs e)> h) => delegate(object sender, EventArgs e)
			{
				h((sender, e));
			}, addHandler, removeHandler, cancellationToken);
		}

		public static Observable<(object? sender, TEventArgs e)> FromEventHandler<TEventArgs>(Action<EventHandler<TEventArgs>> addHandler, Action<EventHandler<TEventArgs>> removeHandler, CancellationToken cancellationToken = default(CancellationToken))
		{
			return new FromEvent<EventHandler<TEventArgs>, (object, TEventArgs)>((Action<(object? sender, TEventArgs e)> h) => delegate(object sender, TEventArgs e)
			{
				h((sender, e));
			}, addHandler, removeHandler, cancellationToken);
		}

		public static Observable<Unit> FromEvent(Action<Action> addHandler, Action<Action> removeHandler, CancellationToken cancellationToken = default(CancellationToken))
		{
			return new FromEvent<Action>((Action h) => h, addHandler, removeHandler, cancellationToken);
		}

		public static Observable<T> FromEvent<T>(Action<Action<T>> addHandler, Action<Action<T>> removeHandler, CancellationToken cancellationToken = default(CancellationToken))
		{
			return new FromEvent<Action<T>, T>((Action<T> h) => h, addHandler, removeHandler, cancellationToken);
		}

		public static Observable<Unit> FromEvent<TDelegate>(Func<Action, TDelegate> conversion, Action<TDelegate> addHandler, Action<TDelegate> removeHandler, CancellationToken cancellationToken = default(CancellationToken))
		{
			return new FromEvent<TDelegate>(conversion, addHandler, removeHandler, cancellationToken);
		}

		public static Observable<T> FromEvent<TDelegate, T>(Func<Action<T>, TDelegate> conversion, Action<TDelegate> addHandler, Action<TDelegate> removeHandler, CancellationToken cancellationToken = default(CancellationToken))
		{
			return new FromEvent<TDelegate, T>(conversion, addHandler, removeHandler, cancellationToken);
		}

		public static Observable<T> Merge<T>(params Observable<T>[] sources)
		{
			return new Merge<T>(sources);
		}

		public static Observable<T> Merge<T>(this IEnumerable<Observable<T>> sources)
		{
			return new Merge<T>(sources);
		}

		public static Observable<T> Never<T>()
		{
			return R3.Never<T>.Instance;
		}

		public static Observable<TProperty> ObservePropertyChanged<T, TProperty>(this T value, Func<T, TProperty> propertySelector, bool pushCurrentValueOnSubscribe = true, CancellationToken cancellationToken = default(CancellationToken), [CallerArgumentExpression("propertySelector")] string? expr = null) where T : INotifyPropertyChanged
		{
			if (expr == null)
			{
				throw new ArgumentNullException(expr);
			}
			string propertyName = expr.Substring(expr.LastIndexOf('.') + 1);
			return new ObservePropertyChanged<T, TProperty>(value, propertySelector, propertyName, pushCurrentValueOnSubscribe, cancellationToken);
		}

		public static Observable<TProperty2> ObservePropertyChanged<T, TProperty1, TProperty2>(this T value, Func<T, TProperty1?> propertySelector1, Func<TProperty1, TProperty2> propertySelector2, bool pushCurrentValueOnSubscribe = true, CancellationToken cancellationToken = default(CancellationToken), [CallerArgumentExpression("propertySelector1")] string? propertySelector1Expr = null, [CallerArgumentExpression("propertySelector2")] string? propertySelector2Expr = null) where T : INotifyPropertyChanged where TProperty1 : INotifyPropertyChanged
		{
			if (propertySelector1Expr == null)
			{
				throw new ArgumentNullException(propertySelector1Expr);
			}
			if (propertySelector2Expr == null)
			{
				throw new ArgumentNullException(propertySelector2Expr);
			}
			string propertyName = propertySelector1Expr.Substring(propertySelector1Expr.LastIndexOf('.') + 1);
			string item = propertySelector2Expr.Substring(propertySelector2Expr.LastIndexOf('.') + 1);
			return new ObservePropertyChanged<T, TProperty1>(value, propertySelector1, propertyName, pushCurrentValueOnSubscribe: true, cancellationToken).Select((propertySelector2, item, pushCurrentValueOnSubscribe, cancellationToken), (TProperty1 firstPropertyValue, (Func<TProperty1, TProperty2> propertySelector2, string property2Name, bool pushCurrentValueOnSubscribe, CancellationToken cancellationToken) state) => (firstPropertyValue == null) ? Empty<TProperty2>() : new ObservePropertyChanged<TProperty1, TProperty2>(firstPropertyValue, state.propertySelector2, state.property2Name, state.pushCurrentValueOnSubscribe, state.cancellationToken)).Switch();
		}

		public static Observable<TProperty3> ObservePropertyChanged<T, TProperty1, TProperty2, TProperty3>(this T value, Func<T, TProperty1?> propertySelector1, Func<TProperty1, TProperty2?> propertySelector2, Func<TProperty2, TProperty3> propertySelector3, bool pushCurrentValueOnSubscribe = true, CancellationToken cancellationToken = default(CancellationToken), [CallerArgumentExpression("propertySelector1")] string? propertySelector1Expr = null, [CallerArgumentExpression("propertySelector2")] string? propertySelector2Expr = null, [CallerArgumentExpression("propertySelector3")] string? propertySelector3Expr = null) where T : INotifyPropertyChanged where TProperty1 : INotifyPropertyChanged where TProperty2 : INotifyPropertyChanged
		{
			if (propertySelector1Expr == null)
			{
				throw new ArgumentNullException(propertySelector1Expr);
			}
			if (propertySelector2Expr == null)
			{
				throw new ArgumentNullException(propertySelector2Expr);
			}
			if (propertySelector3Expr == null)
			{
				throw new ArgumentNullException(propertySelector3Expr);
			}
			string propertyName = propertySelector1Expr.Substring(propertySelector1Expr.LastIndexOf('.') + 1);
			string item = propertySelector2Expr.Substring(propertySelector2Expr.LastIndexOf('.') + 1);
			string item2 = propertySelector3Expr.Substring(propertySelector3Expr.LastIndexOf('.') + 1);
			return new ObservePropertyChanged<T, TProperty1>(value, propertySelector1, propertyName, pushCurrentValueOnSubscribe: true, cancellationToken).Select((propertySelector2, item, propertySelector3, item2, pushCurrentValueOnSubscribe, cancellationToken), (TProperty1 firstPropertyValue, (Func<TProperty1, TProperty2> propertySelector2, string property2Name, Func<TProperty2, TProperty3> propertySelector3, string property3Name, bool pushCurrentValueOnSubscribe, CancellationToken cancellationToken) state) => (firstPropertyValue == null) ? Empty<TProperty3>() : new ObservePropertyChanged<TProperty1, TProperty2>(firstPropertyValue, state.propertySelector2, state.property2Name, pushCurrentValueOnSubscribe: true, state.cancellationToken).Select((state.propertySelector3, state.property3Name, pushCurrentValueOnSubscribe, cancellationToken), (TProperty2 secondPropertyValue, (Func<TProperty2, TProperty3> propertySelector3, string property3Name, bool pushCurrentValueOnSubscribe, CancellationToken cancellationToken) tuple) => (secondPropertyValue == null) ? Empty<TProperty3>() : new ObservePropertyChanged<TProperty2, TProperty3>(secondPropertyValue, tuple.propertySelector3, tuple.property3Name, tuple.pushCurrentValueOnSubscribe, tuple.cancellationToken)).Switch()).Switch();
		}

		public static Observable<TProperty> ObservePropertyChanging<T, TProperty>(this T value, Func<T, TProperty> propertySelector, bool pushCurrentValueOnSubscribe = true, CancellationToken cancellationToken = default(CancellationToken), [CallerArgumentExpression("propertySelector")] string? expr = null) where T : INotifyPropertyChanging
		{
			if (expr == null)
			{
				throw new ArgumentNullException(expr);
			}
			string propertyName = expr.Substring(expr.LastIndexOf('.') + 1);
			return new ObservePropertyChanging<T, TProperty>(value, propertySelector, propertyName, pushCurrentValueOnSubscribe, cancellationToken);
		}

		public static Observable<TProperty2> ObservePropertyChanging<T, TProperty1, TProperty2>(this T value, Func<T, TProperty1?> propertySelector1, Func<TProperty1, TProperty2> propertySelector2, bool pushCurrentValueOnSubscribe = true, CancellationToken cancellationToken = default(CancellationToken), [CallerArgumentExpression("propertySelector1")] string? propertySelector1Expr = null, [CallerArgumentExpression("propertySelector2")] string? propertySelector2Expr = null) where T : INotifyPropertyChanged where TProperty1 : INotifyPropertyChanging
		{
			if (propertySelector2Expr == null)
			{
				throw new ArgumentNullException(propertySelector2Expr);
			}
			string item = propertySelector2Expr.Substring(propertySelector2Expr.LastIndexOf('.') + 1);
			return value.ObservePropertyChanged(propertySelector1, pushCurrentValueOnSubscribe: true, cancellationToken, propertySelector1Expr).Select<TProperty1, Observable<TProperty2>, (Func<TProperty1, TProperty2>, string, bool, CancellationToken)>((propertySelector2, item, pushCurrentValueOnSubscribe, cancellationToken), (TProperty1 firstPropertyValue, (Func<TProperty1, TProperty2> propertySelector2, string property2Name, bool pushCurrentValueOnSubscribe, CancellationToken cancellationToken) state) => (firstPropertyValue == null) ? Empty<TProperty2>() : new ObservePropertyChanging<TProperty1, TProperty2>(firstPropertyValue, state.propertySelector2, state.property2Name, state.pushCurrentValueOnSubscribe, state.cancellationToken)).Switch();
		}

		public static Observable<TProperty3> ObservePropertyChanging<T, TProperty1, TProperty2, TProperty3>(this T value, Func<T, TProperty1?> propertySelector1, Func<TProperty1, TProperty2?> propertySelector2, Func<TProperty2, TProperty3> propertySelector3, bool pushCurrentValueOnSubscribe = true, CancellationToken cancellationToken = default(CancellationToken), [CallerArgumentExpression("propertySelector1")] string? propertySelector1Expr = null, [CallerArgumentExpression("propertySelector2")] string? propertySelector2Expr = null, [CallerArgumentExpression("propertySelector3")] string? propertySelector3Expr = null) where T : INotifyPropertyChanged where TProperty1 : INotifyPropertyChanged where TProperty2 : INotifyPropertyChanging
		{
			if (propertySelector3Expr == null)
			{
				throw new ArgumentNullException(propertySelector3Expr);
			}
			string item = propertySelector3Expr.Substring(propertySelector3Expr.LastIndexOf('.') + 1);
			return value.ObservePropertyChanged(propertySelector1, propertySelector2, pushCurrentValueOnSubscribe: true, cancellationToken, propertySelector1Expr, propertySelector2Expr).Select<TProperty2, Observable<TProperty3>, (Func<TProperty2, TProperty3>, string, bool, CancellationToken)>((propertySelector3, item, pushCurrentValueOnSubscribe, cancellationToken), (TProperty2 secondPropertyValue, (Func<TProperty2, TProperty3> propertySelector3, string property3Name, bool pushCurrentValueOnSubscribe, CancellationToken cancellationToken) state) => (secondPropertyValue == null) ? Empty<TProperty3>() : new ObservePropertyChanging<TProperty2, TProperty3>(secondPropertyValue, state.propertySelector3, state.property3Name, state.pushCurrentValueOnSubscribe, state.cancellationToken)).Switch();
		}

		public static Observable<T> Race<T>(params Observable<T>[] sources)
		{
			return new Race<T>(sources);
		}

		public static Observable<T> Race<T>(IEnumerable<Observable<T>> sources)
		{
			return new Race<T>(sources);
		}

		[Obsolete("Amb is renamed to Race.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Observable<T> Amb<T>(params Observable<T>[] sources)
		{
			return Race(sources);
		}

		[Obsolete("Amb is renamed to Race.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Observable<T> Amb<T>(IEnumerable<Observable<T>> sources)
		{
			return Race(sources);
		}

		public static Observable<int> Range(int start, int count)
		{
			long num = (long)start + (long)count - 1;
			if (count < 0 || num > int.MaxValue)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (count == 0)
			{
				return Empty<int>();
			}
			return new Range(start, count);
		}

		public static Observable<int> Range(int start, int count, CancellationToken cancellationToken)
		{
			long num = (long)start + (long)count - 1;
			if (count < 0 || num > int.MaxValue)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (count == 0)
			{
				return Empty<int>();
			}
			return new RangeC(start, count, cancellationToken);
		}

		public static Observable<T> Repeat<T>(T value, int count)
		{
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (count == 0)
			{
				return Empty<T>();
			}
			return new Repeat<T>(value, count);
		}

		public static Observable<T> Repeat<T>(T value, int count, CancellationToken cancellationToken)
		{
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (count == 0)
			{
				return Empty<T>();
			}
			return new RepeatC<T>(value, count, cancellationToken);
		}

		public static Observable<T> Return<T>(T value)
		{
			return new ImmediateScheduleReturn<T>(value);
		}

		public static Observable<T> Return<T>(T value, TimeProvider timeProvider, CancellationToken cancellationToken = default(CancellationToken))
		{
			return Return(value, TimeSpan.Zero, timeProvider, cancellationToken);
		}

		public static Observable<T> Return<T>(T value, TimeSpan dueTime, TimeProvider timeProvider, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (dueTime == TimeSpan.Zero && timeProvider == TimeProvider.System)
			{
				return new ThreadPoolScheduleReturn<T>(value, cancellationToken);
			}
			return new Return<T>(value, dueTime.Normalize(), timeProvider, cancellationToken);
		}

		public static Observable<Unit> ReturnUnit()
		{
			return R3.ReturnUnit.Instance;
		}

		public static Observable<Unit> Return(Unit value)
		{
			return R3.ReturnUnit.Instance;
		}

		public static Observable<bool> Return(bool value)
		{
			if (!value)
			{
				return ReturnBoolean.False;
			}
			return ReturnBoolean.True;
		}

		public static Observable<int> Return(int value)
		{
			return ReturnInt32.GetObservable(value);
		}

		public static Observable<Unit> Yield(CancellationToken cancellationToken = default(CancellationToken))
		{
			return new ThreadPoolScheduleReturn<Unit>(default(Unit), cancellationToken);
		}

		public static Observable<Unit> Yield(TimeProvider timeProvider, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (timeProvider == TimeProvider.System)
			{
				return new ThreadPoolScheduleReturn<Unit>(default(Unit), cancellationToken);
			}
			return new Return<Unit>(default(Unit), TimeSpan.Zero, timeProvider, cancellationToken);
		}

		public static Observable<T> ReturnFrame<T>(T value, CancellationToken cancellationToken = default(CancellationToken))
		{
			return ReturnFrame(value, ObservableSystem.DefaultFrameProvider, cancellationToken);
		}

		public static Observable<T> ReturnFrame<T>(T value, FrameProvider frameProvider, CancellationToken cancellationToken = default(CancellationToken))
		{
			return new ReturnFrame<T>(value, frameProvider, cancellationToken);
		}

		public static Observable<T> ReturnFrame<T>(T value, int dueTimeFrame, CancellationToken cancellationToken = default(CancellationToken))
		{
			return ReturnFrame(value, dueTimeFrame, ObservableSystem.DefaultFrameProvider, cancellationToken);
		}

		public static Observable<T> ReturnFrame<T>(T value, int dueTimeFrame, FrameProvider frameProvider, CancellationToken cancellationToken = default(CancellationToken))
		{
			return new ReturnFrameTime<T>(value, dueTimeFrame, frameProvider, cancellationToken);
		}

		public static Observable<Unit> NextFrame(CancellationToken cancellationToken = default(CancellationToken))
		{
			return NextFrame(ObservableSystem.DefaultFrameProvider, cancellationToken);
		}

		public static Observable<Unit> NextFrame(FrameProvider frameProvider, CancellationToken cancellationToken = default(CancellationToken))
		{
			return new NextFrame(frameProvider, cancellationToken);
		}

		public static Observable<Unit> YieldFrame(CancellationToken cancellationToken = default(CancellationToken))
		{
			return ReturnFrame(Unit.Default, ObservableSystem.DefaultFrameProvider, cancellationToken);
		}

		public static Observable<Unit> YieldFrame(FrameProvider frameProvider, CancellationToken cancellationToken = default(CancellationToken))
		{
			return ReturnFrame(Unit.Default, frameProvider, cancellationToken);
		}

		public static Observable<T> ReturnOnCompleted<T>(Result result)
		{
			if (result.IsSuccess)
			{
				return ImmediateScheduleReturnOnCompletedSuccess<T>.Instance;
			}
			return new ImmediateScheduleReturnOnCompleted<T>(result);
		}

		public static Observable<T> ReturnOnCompleted<T>(Result result, TimeProvider timeProvider)
		{
			return ReturnOnCompleted<T>(result, TimeSpan.Zero, timeProvider);
		}

		public static Observable<T> ReturnOnCompleted<T>(Result result, TimeSpan dueTime, TimeProvider timeProvider)
		{
			if (dueTime == TimeSpan.Zero && timeProvider == TimeProvider.System)
			{
				return new ThreadPoolScheduleReturnOnCompleted<T>(result);
			}
			return new ReturnOnCompleted<T>(result, dueTime, timeProvider);
		}

		public static Observable<T> Throw<T>(Exception exception)
		{
			return ReturnOnCompleted<T>(Result.Failure(exception));
		}

		public static Observable<T> Throw<T>(Exception exception, TimeProvider timeProvider)
		{
			return ReturnOnCompleted<T>(Result.Failure(exception), timeProvider);
		}

		public static Observable<T> Throw<T>(Exception exception, TimeSpan dueTime, TimeProvider timeProvider)
		{
			return ReturnOnCompleted<T>(Result.Failure(exception), dueTime, timeProvider);
		}

		public static Observable<Unit> Interval(TimeSpan period, CancellationToken cancellationToken = default(CancellationToken))
		{
			return Timer(period, period, cancellationToken);
		}

		public static Observable<Unit> Interval(TimeSpan period, TimeProvider timeProvider, CancellationToken cancellationToken = default(CancellationToken))
		{
			return Timer(period, period, timeProvider, cancellationToken);
		}

		public static Observable<Unit> Timer(TimeSpan dueTime, CancellationToken cancellationToken = default(CancellationToken))
		{
			return Timer(dueTime, ObservableSystem.DefaultTimeProvider, cancellationToken);
		}

		public static Observable<Unit> Timer(DateTimeOffset dueTime, CancellationToken cancellationToken = default(CancellationToken))
		{
			return Timer(dueTime, ObservableSystem.DefaultTimeProvider, cancellationToken);
		}

		public static Observable<Unit> Timer(TimeSpan dueTime, TimeSpan period, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (period < TimeSpan.Zero)
			{
				throw new ArgumentOutOfRangeException("period");
			}
			return Timer(dueTime, period, ObservableSystem.DefaultTimeProvider, cancellationToken);
		}

		public static Observable<Unit> Timer(DateTimeOffset dueTime, TimeSpan period, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (period < TimeSpan.Zero)
			{
				throw new ArgumentOutOfRangeException("period");
			}
			return Timer(dueTime, period, ObservableSystem.DefaultTimeProvider, cancellationToken);
		}

		public static Observable<Unit> Timer(TimeSpan dueTime, TimeProvider timeProvider, CancellationToken cancellationToken = default(CancellationToken))
		{
			return new Timer(dueTime, null, timeProvider, cancellationToken);
		}

		public static Observable<Unit> Timer(DateTimeOffset dueTime, TimeProvider timeProvider, CancellationToken cancellationToken = default(CancellationToken))
		{
			return new Timer(dueTime, null, timeProvider, cancellationToken);
		}

		public static Observable<Unit> Timer(TimeSpan dueTime, TimeSpan period, TimeProvider timeProvider, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (period < TimeSpan.Zero)
			{
				throw new ArgumentOutOfRangeException("period");
			}
			return new Timer(dueTime, period, timeProvider, cancellationToken);
		}

		public static Observable<Unit> Timer(DateTimeOffset dueTime, TimeSpan period, TimeProvider timeProvider, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (period < TimeSpan.Zero)
			{
				throw new ArgumentOutOfRangeException("period");
			}
			return new Timer(dueTime, period, timeProvider, cancellationToken);
		}

		public static Observable<Unit> IntervalFrame(int periodFrame, CancellationToken cancellationToken = default(CancellationToken))
		{
			return TimerFrame(periodFrame, periodFrame, cancellationToken);
		}

		public static Observable<Unit> IntervalFrame(int periodFrame, FrameProvider frameProvider, CancellationToken cancellationToken = default(CancellationToken))
		{
			return TimerFrame(periodFrame, periodFrame, frameProvider, cancellationToken);
		}

		public static Observable<Unit> TimerFrame(int dueTimeFrame, CancellationToken cancellationToken = default(CancellationToken))
		{
			return new TimerFrame(dueTimeFrame, null, ObservableSystem.DefaultFrameProvider, cancellationToken);
		}

		public static Observable<Unit> TimerFrame(int dueTimeFrame, int periodFrame, CancellationToken cancellationToken = default(CancellationToken))
		{
			return new TimerFrame(dueTimeFrame, periodFrame, ObservableSystem.DefaultFrameProvider, cancellationToken);
		}

		public static Observable<Unit> TimerFrame(int dueTimeFrame, FrameProvider frameProvider, CancellationToken cancellationToken = default(CancellationToken))
		{
			return new TimerFrame(dueTimeFrame, null, frameProvider, cancellationToken);
		}

		public static Observable<Unit> TimerFrame(int dueTimeFrame, int periodFrame, FrameProvider frameProvider, CancellationToken cancellationToken = default(CancellationToken))
		{
			return new TimerFrame(dueTimeFrame, periodFrame, frameProvider, cancellationToken);
		}

		public static Observable<Unit> ToObservable(this Task task, bool configureAwait = true)
		{
			return new TaskToObservable(task, configureAwait);
		}

		public static Observable<T> ToObservable<T>(this Task<T> task, bool configureAwait = true)
		{
			return new TaskToObservable<T>(task, configureAwait);
		}

		public static Observable<Unit> ToObservable(this ValueTask task, bool configureAwait = true)
		{
			return new ValueTaskToObservable(task, configureAwait);
		}

		public static Observable<T> ToObservable<T>(this ValueTask<T> task, bool configureAwait = true)
		{
			return new ValueTaskToObservable<T>(task, configureAwait);
		}

		public static Observable<T> ToObservable<T>(this IEnumerable<T> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			return new EnumerableToObservable<T>(source, cancellationToken);
		}

		public static Observable<T> ToObservable<T>(this IAsyncEnumerable<T> source)
		{
			return new AsyncEnumerableToObservable<T>(source);
		}

		public static Observable<T> ToObservable<T>(this IObservable<T> source)
		{
			return new IObservableToObservable<T>(source);
		}

		public static Observable<T[]> Zip<T>(params Observable<T>[] sources)
		{
			return new Zip<T>(sources);
		}

		public static Observable<T[]> Zip<T>(IEnumerable<Observable<T>> sources)
		{
			return new Zip<T>(sources);
		}

		public static Observable<T[]> ZipLatest<T>(params Observable<T>[] sources)
		{
			return new ZipLatest<T>(sources);
		}

		public static Observable<T[]> ZipLatest<T>(IEnumerable<Observable<T>> sources)
		{
			return new ZipLatest<T>(sources);
		}

		public static Observable<TResult> CombineLatest<T1, T2, TResult>(this Observable<T1> source1, Observable<T2> source2, Func<T1, T2, TResult> resultSelector)
		{
			return new CombineLatest<T1, T2, TResult>(source1, source2, resultSelector);
		}

		public static Observable<TResult> CombineLatest<T1, T2, T3, TResult>(this Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Func<T1, T2, T3, TResult> resultSelector)
		{
			return new CombineLatest<T1, T2, T3, TResult>(source1, source2, source3, resultSelector);
		}

		public static Observable<TResult> CombineLatest<T1, T2, T3, T4, TResult>(this Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Func<T1, T2, T3, T4, TResult> resultSelector)
		{
			return new CombineLatest<T1, T2, T3, T4, TResult>(source1, source2, source3, source4, resultSelector);
		}

		public static Observable<TResult> CombineLatest<T1, T2, T3, T4, T5, TResult>(this Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Func<T1, T2, T3, T4, T5, TResult> resultSelector)
		{
			return new CombineLatest<T1, T2, T3, T4, T5, TResult>(source1, source2, source3, source4, source5, resultSelector);
		}

		public static Observable<TResult> CombineLatest<T1, T2, T3, T4, T5, T6, TResult>(this Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Func<T1, T2, T3, T4, T5, T6, TResult> resultSelector)
		{
			return new CombineLatest<T1, T2, T3, T4, T5, T6, TResult>(source1, source2, source3, source4, source5, source6, resultSelector);
		}

		public static Observable<TResult> CombineLatest<T1, T2, T3, T4, T5, T6, T7, TResult>(this Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Func<T1, T2, T3, T4, T5, T6, T7, TResult> resultSelector)
		{
			return new CombineLatest<T1, T2, T3, T4, T5, T6, T7, TResult>(source1, source2, source3, source4, source5, source6, source7, resultSelector);
		}

		public static Observable<TResult> CombineLatest<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(this Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> resultSelector)
		{
			return new CombineLatest<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(source1, source2, source3, source4, source5, source6, source7, source8, resultSelector);
		}

		public static Observable<TResult> CombineLatest<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(this Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> resultSelector)
		{
			return new CombineLatest<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(source1, source2, source3, source4, source5, source6, source7, source8, source9, resultSelector);
		}

		public static Observable<TResult> CombineLatest<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(this Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> resultSelector)
		{
			return new CombineLatest<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(source1, source2, source3, source4, source5, source6, source7, source8, source9, source10, resultSelector);
		}

		public static Observable<TResult> CombineLatest<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(this Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Observable<T11> source11, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> resultSelector)
		{
			return new CombineLatest<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(source1, source2, source3, source4, source5, source6, source7, source8, source9, source10, source11, resultSelector);
		}

		public static Observable<TResult> CombineLatest<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(this Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Observable<T11> source11, Observable<T12> source12, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> resultSelector)
		{
			return new CombineLatest<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(source1, source2, source3, source4, source5, source6, source7, source8, source9, source10, source11, source12, resultSelector);
		}

		public static Observable<TResult> CombineLatest<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(this Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Observable<T11> source11, Observable<T12> source12, Observable<T13> source13, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> resultSelector)
		{
			return new CombineLatest<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(source1, source2, source3, source4, source5, source6, source7, source8, source9, source10, source11, source12, source13, resultSelector);
		}

		public static Observable<TResult> CombineLatest<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(this Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Observable<T11> source11, Observable<T12> source12, Observable<T13> source13, Observable<T14> source14, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> resultSelector)
		{
			return new CombineLatest<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(source1, source2, source3, source4, source5, source6, source7, source8, source9, source10, source11, source12, source13, source14, resultSelector);
		}

		public static Observable<TResult> CombineLatest<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(this Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Observable<T11> source11, Observable<T12> source12, Observable<T13> source13, Observable<T14> source14, Observable<T15> source15, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> resultSelector)
		{
			return new CombineLatest<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(source1, source2, source3, source4, source5, source6, source7, source8, source9, source10, source11, source12, source13, source14, source15, resultSelector);
		}

		public static Observable<T> Concat<T>(this Observable<Observable<T>> sources)
		{
			return new ConcatMany<T>(sources);
		}

		public static Observable<T> Merge<T>(this Observable<Observable<T>> sources)
		{
			return new MergeMany<T>(sources);
		}

		public static Observable<TResult> Zip<T1, T2, TResult>(this Observable<T1> source1, Observable<T2> source2, Func<T1, T2, TResult> resultSelector)
		{
			return new Zip<T1, T2, TResult>(source1, source2, resultSelector);
		}

		public static Observable<TResult> Zip<T1, T2, T3, TResult>(this Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Func<T1, T2, T3, TResult> resultSelector)
		{
			return new Zip<T1, T2, T3, TResult>(source1, source2, source3, resultSelector);
		}

		public static Observable<TResult> Zip<T1, T2, T3, T4, TResult>(this Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Func<T1, T2, T3, T4, TResult> resultSelector)
		{
			return new Zip<T1, T2, T3, T4, TResult>(source1, source2, source3, source4, resultSelector);
		}

		public static Observable<TResult> Zip<T1, T2, T3, T4, T5, TResult>(this Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Func<T1, T2, T3, T4, T5, TResult> resultSelector)
		{
			return new Zip<T1, T2, T3, T4, T5, TResult>(source1, source2, source3, source4, source5, resultSelector);
		}

		public static Observable<TResult> Zip<T1, T2, T3, T4, T5, T6, TResult>(this Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Func<T1, T2, T3, T4, T5, T6, TResult> resultSelector)
		{
			return new Zip<T1, T2, T3, T4, T5, T6, TResult>(source1, source2, source3, source4, source5, source6, resultSelector);
		}

		public static Observable<TResult> Zip<T1, T2, T3, T4, T5, T6, T7, TResult>(this Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Func<T1, T2, T3, T4, T5, T6, T7, TResult> resultSelector)
		{
			return new Zip<T1, T2, T3, T4, T5, T6, T7, TResult>(source1, source2, source3, source4, source5, source6, source7, resultSelector);
		}

		public static Observable<TResult> Zip<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(this Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> resultSelector)
		{
			return new Zip<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(source1, source2, source3, source4, source5, source6, source7, source8, resultSelector);
		}

		public static Observable<TResult> Zip<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(this Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> resultSelector)
		{
			return new Zip<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(source1, source2, source3, source4, source5, source6, source7, source8, source9, resultSelector);
		}

		public static Observable<TResult> Zip<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(this Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> resultSelector)
		{
			return new Zip<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(source1, source2, source3, source4, source5, source6, source7, source8, source9, source10, resultSelector);
		}

		public static Observable<TResult> Zip<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(this Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Observable<T11> source11, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> resultSelector)
		{
			return new Zip<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(source1, source2, source3, source4, source5, source6, source7, source8, source9, source10, source11, resultSelector);
		}

		public static Observable<TResult> Zip<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(this Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Observable<T11> source11, Observable<T12> source12, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> resultSelector)
		{
			return new Zip<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(source1, source2, source3, source4, source5, source6, source7, source8, source9, source10, source11, source12, resultSelector);
		}

		public static Observable<TResult> Zip<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(this Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Observable<T11> source11, Observable<T12> source12, Observable<T13> source13, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> resultSelector)
		{
			return new Zip<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(source1, source2, source3, source4, source5, source6, source7, source8, source9, source10, source11, source12, source13, resultSelector);
		}

		public static Observable<TResult> Zip<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(this Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Observable<T11> source11, Observable<T12> source12, Observable<T13> source13, Observable<T14> source14, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> resultSelector)
		{
			return new Zip<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(source1, source2, source3, source4, source5, source6, source7, source8, source9, source10, source11, source12, source13, source14, resultSelector);
		}

		public static Observable<TResult> Zip<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(this Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Observable<T11> source11, Observable<T12> source12, Observable<T13> source13, Observable<T14> source14, Observable<T15> source15, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> resultSelector)
		{
			return new Zip<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(source1, source2, source3, source4, source5, source6, source7, source8, source9, source10, source11, source12, source13, source14, source15, resultSelector);
		}

		public static Observable<TResult> ZipLatest<T1, T2, TResult>(this Observable<T1> source1, Observable<T2> source2, Func<T1, T2, TResult> resultSelector)
		{
			return new ZipLatest<T1, T2, TResult>(source1, source2, resultSelector);
		}

		public static Observable<TResult> ZipLatest<T1, T2, T3, TResult>(this Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Func<T1, T2, T3, TResult> resultSelector)
		{
			return new ZipLatest<T1, T2, T3, TResult>(source1, source2, source3, resultSelector);
		}

		public static Observable<TResult> ZipLatest<T1, T2, T3, T4, TResult>(this Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Func<T1, T2, T3, T4, TResult> resultSelector)
		{
			return new ZipLatest<T1, T2, T3, T4, TResult>(source1, source2, source3, source4, resultSelector);
		}

		public static Observable<TResult> ZipLatest<T1, T2, T3, T4, T5, TResult>(this Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Func<T1, T2, T3, T4, T5, TResult> resultSelector)
		{
			return new ZipLatest<T1, T2, T3, T4, T5, TResult>(source1, source2, source3, source4, source5, resultSelector);
		}

		public static Observable<TResult> ZipLatest<T1, T2, T3, T4, T5, T6, TResult>(this Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Func<T1, T2, T3, T4, T5, T6, TResult> resultSelector)
		{
			return new ZipLatest<T1, T2, T3, T4, T5, T6, TResult>(source1, source2, source3, source4, source5, source6, resultSelector);
		}

		public static Observable<TResult> ZipLatest<T1, T2, T3, T4, T5, T6, T7, TResult>(this Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Func<T1, T2, T3, T4, T5, T6, T7, TResult> resultSelector)
		{
			return new ZipLatest<T1, T2, T3, T4, T5, T6, T7, TResult>(source1, source2, source3, source4, source5, source6, source7, resultSelector);
		}

		public static Observable<TResult> ZipLatest<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(this Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> resultSelector)
		{
			return new ZipLatest<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(source1, source2, source3, source4, source5, source6, source7, source8, resultSelector);
		}

		public static Observable<TResult> ZipLatest<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(this Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> resultSelector)
		{
			return new ZipLatest<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(source1, source2, source3, source4, source5, source6, source7, source8, source9, resultSelector);
		}

		public static Observable<TResult> ZipLatest<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(this Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> resultSelector)
		{
			return new ZipLatest<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(source1, source2, source3, source4, source5, source6, source7, source8, source9, source10, resultSelector);
		}

		public static Observable<TResult> ZipLatest<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(this Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Observable<T11> source11, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> resultSelector)
		{
			return new ZipLatest<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(source1, source2, source3, source4, source5, source6, source7, source8, source9, source10, source11, resultSelector);
		}

		public static Observable<TResult> ZipLatest<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(this Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Observable<T11> source11, Observable<T12> source12, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> resultSelector)
		{
			return new ZipLatest<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(source1, source2, source3, source4, source5, source6, source7, source8, source9, source10, source11, source12, resultSelector);
		}

		public static Observable<TResult> ZipLatest<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(this Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Observable<T11> source11, Observable<T12> source12, Observable<T13> source13, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> resultSelector)
		{
			return new ZipLatest<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(source1, source2, source3, source4, source5, source6, source7, source8, source9, source10, source11, source12, source13, resultSelector);
		}

		public static Observable<TResult> ZipLatest<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(this Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Observable<T11> source11, Observable<T12> source12, Observable<T13> source13, Observable<T14> source14, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> resultSelector)
		{
			return new ZipLatest<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(source1, source2, source3, source4, source5, source6, source7, source8, source9, source10, source11, source12, source13, source14, resultSelector);
		}

		public static Observable<TResult> ZipLatest<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(this Observable<T1> source1, Observable<T2> source2, Observable<T3> source3, Observable<T4> source4, Observable<T5> source5, Observable<T6> source6, Observable<T7> source7, Observable<T8> source8, Observable<T9> source9, Observable<T10> source10, Observable<T11> source11, Observable<T12> source12, Observable<T13> source13, Observable<T14> source14, Observable<T15> source15, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> resultSelector)
		{
			return new ZipLatest<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(source1, source2, source3, source4, source5, source6, source7, source8, source9, source10, source11, source12, source13, source14, source15, resultSelector);
		}
	}
	public abstract class Observable<T>
	{
		[System.Diagnostics.StackTraceHidden]
		[DebuggerStepThrough]
		public IDisposable Subscribe(Observer<T> observer)
		{
			try
			{
				IDisposable disposable = SubscribeCore(observer);
				if (ObservableTracker.TryTrackActiveSubscription(disposable, 2, out TrackableDisposable trackableDisposable))
				{
					disposable = trackableDisposable;
				}
				observer.SourceSubscription.Disposable = disposable;
				return observer;
			}
			catch
			{
				observer.Dispose();
				throw;
			}
		}

		protected abstract IDisposable SubscribeCore(Observer<T> observer);
	}
}
