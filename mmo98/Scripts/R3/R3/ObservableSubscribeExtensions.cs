using System;
using System.Diagnostics;
using R3.Internal;

namespace R3
{
	public static class ObservableSubscribeExtensions
	{
		[DebuggerStepThrough]
		public static IDisposable Subscribe<T>(this Observable<T> source)
		{
			return source.Subscribe(new NopObserver<T>());
		}

		[DebuggerStepThrough]
		public static IDisposable Subscribe<T>(this Observable<T> source, Action<T> onNext)
		{
			return source.Subscribe(new AnonymousObserver<T>(onNext, ObservableSystem.GetUnhandledExceptionHandler(), Stubs.HandleResult));
		}

		[DebuggerStepThrough]
		public static IDisposable Subscribe<T>(this Observable<T> source, Action<T> onNext, Action<Result> onCompleted)
		{
			return source.Subscribe(new AnonymousObserver<T>(onNext, ObservableSystem.GetUnhandledExceptionHandler(), onCompleted));
		}

		[DebuggerStepThrough]
		public static IDisposable Subscribe<T>(this Observable<T> source, Action<T> onNext, Action<Exception> onErrorResume, Action<Result> onCompleted)
		{
			return source.Subscribe(new AnonymousObserver<T>(onNext, onErrorResume, onCompleted));
		}

		[DebuggerStepThrough]
		public static IDisposable Subscribe<T, TState>(this Observable<T> source, TState state, Action<T, TState> onNext)
		{
			return source.Subscribe(new AnonymousObserver<T, TState>(onNext, Stubs<TState>.HandleException, Stubs<TState>.HandleResult, state));
		}

		[DebuggerStepThrough]
		public static IDisposable Subscribe<T, TState>(this Observable<T> source, TState state, Action<T, TState> onNext, Action<Result, TState> onCompleted)
		{
			return source.Subscribe(new AnonymousObserver<T, TState>(onNext, Stubs<TState>.HandleException, onCompleted, state));
		}

		[DebuggerStepThrough]
		public static IDisposable Subscribe<T, TState>(this Observable<T> source, TState state, Action<T, TState> onNext, Action<Exception, TState> onErrorResume, Action<Result, TState> onCompleted)
		{
			return source.Subscribe(new AnonymousObserver<T, TState>(onNext, onErrorResume, onCompleted, state));
		}
	}
}
