using System;

namespace R3
{
	internal sealed class Do<T> : Observable<T>
	{
		internal sealed class _Do : Observer<T>
		{
			public _Do(Observer<T> observer, Action<T>? onNext, Action<Exception>? onErrorResume, Action<Result>? onCompleted, Action? onDispose)
			{
				_003Cobserver_003EP = observer;
				_003ConNext_003EP = onNext;
				_003ConErrorResume_003EP = onErrorResume;
				_003ConCompleted_003EP = onCompleted;
				_003ConDispose_003EP = onDispose;
				base._002Ector();
			}

			protected override void OnNextCore(T value)
			{
				_003ConNext_003EP?.Invoke(value);
				_003Cobserver_003EP.OnNext(value);
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				_003ConErrorResume_003EP?.Invoke(error);
				_003Cobserver_003EP.OnErrorResume(error);
			}

			protected override void OnCompletedCore(Result result)
			{
				_003ConCompleted_003EP?.Invoke(result);
				_003Cobserver_003EP.OnCompleted(result);
			}

			protected override void DisposeCore()
			{
				_003ConDispose_003EP?.Invoke();
			}
		}

		public Do(Observable<T> source, Action<T>? onNext, Action<Exception>? onErrorResume, Action<Result>? onCompleted, Action? onDispose, Action? onSubscribe)
		{
			_003Csource_003EP = source;
			_003ConNext_003EP = onNext;
			_003ConErrorResume_003EP = onErrorResume;
			_003ConCompleted_003EP = onCompleted;
			_003ConDispose_003EP = onDispose;
			_003ConSubscribe_003EP = onSubscribe;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			_003ConSubscribe_003EP?.Invoke();
			return _003Csource_003EP.Subscribe(new _Do(observer, _003ConNext_003EP, _003ConErrorResume_003EP, _003ConCompleted_003EP, _003ConDispose_003EP));
		}
	}
	internal sealed class Do<T, TState> : Observable<T>
	{
		internal sealed class _Do : Observer<T>
		{
			public _Do(Observer<T> observer, TState state, Action<T, TState>? onNext, Action<Exception, TState>? onErrorResume, Action<Result, TState>? onCompleted, Action<TState>? onDispose)
			{
				_003Cobserver_003EP = observer;
				_003Cstate_003EP = state;
				_003ConNext_003EP = onNext;
				_003ConErrorResume_003EP = onErrorResume;
				_003ConCompleted_003EP = onCompleted;
				_003ConDispose_003EP = onDispose;
				base._002Ector();
			}

			protected override void OnNextCore(T value)
			{
				_003ConNext_003EP?.Invoke(value, _003Cstate_003EP);
				_003Cobserver_003EP.OnNext(value);
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				_003ConErrorResume_003EP?.Invoke(error, _003Cstate_003EP);
				_003Cobserver_003EP.OnErrorResume(error);
			}

			protected override void OnCompletedCore(Result result)
			{
				_003ConCompleted_003EP?.Invoke(result, _003Cstate_003EP);
				_003Cobserver_003EP.OnCompleted(result);
			}

			protected override void DisposeCore()
			{
				_003ConDispose_003EP?.Invoke(_003Cstate_003EP);
			}
		}

		public Do(Observable<T> source, TState state, Action<T, TState>? onNext, Action<Exception, TState>? onErrorResume, Action<Result, TState>? onCompleted, Action<TState>? onDispose, Action<TState>? onSubscribe)
		{
			_003Csource_003EP = source;
			_003Cstate_003EP = state;
			_003ConNext_003EP = onNext;
			_003ConErrorResume_003EP = onErrorResume;
			_003ConCompleted_003EP = onCompleted;
			_003ConDispose_003EP = onDispose;
			_003ConSubscribe_003EP = onSubscribe;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			_003ConSubscribe_003EP?.Invoke(_003Cstate_003EP);
			return _003Csource_003EP.Subscribe(new _Do(observer, _003Cstate_003EP, _003ConNext_003EP, _003ConErrorResume_003EP, _003ConCompleted_003EP, _003ConDispose_003EP));
		}
	}
}
