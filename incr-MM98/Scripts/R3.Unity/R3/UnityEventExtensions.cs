using System;
using System.Threading;
using UnityEngine.Events;

namespace R3
{
	public static class UnityEventExtensions
	{
		public static Observable<Unit> AsObservable(this UnityEvent unityEvent, CancellationToken cancellationToken = default(CancellationToken))
		{
			return Observable.FromEvent<UnityAction>((Action h) => h.Invoke, delegate(UnityAction h)
			{
				unityEvent.AddListener(h);
			}, delegate(UnityAction h)
			{
				unityEvent.RemoveListener(h);
			}, cancellationToken);
		}

		public static Observable<T> AsObservable<T>(this UnityEvent<T> unityEvent, CancellationToken cancellationToken = default(CancellationToken))
		{
			return Observable.FromEvent<UnityAction<T>, T>((Action<T> h) => h.Invoke, delegate(UnityAction<T> h)
			{
				unityEvent.AddListener(h);
			}, delegate(UnityAction<T> h)
			{
				unityEvent.RemoveListener(h);
			}, cancellationToken);
		}

		public static Observable<(T0 Arg0, T1 Arg1)> AsObservable<T0, T1>(this UnityEvent<T0, T1> unityEvent, CancellationToken cancellationToken = default(CancellationToken))
		{
			return Observable.FromEvent<UnityAction<T0, T1>, (T0, T1)>((Action<(T0, T1)> h) => delegate(T0 t0, T1 t1)
			{
				h((t0, t1));
			}, delegate(UnityAction<T0, T1> h)
			{
				unityEvent.AddListener(h);
			}, delegate(UnityAction<T0, T1> h)
			{
				unityEvent.RemoveListener(h);
			}, cancellationToken);
		}

		public static Observable<(T0 Arg0, T1 Arg1, T2 Arg2)> AsObservable<T0, T1, T2>(this UnityEvent<T0, T1, T2> unityEvent, CancellationToken cancellationToken = default(CancellationToken))
		{
			return Observable.FromEvent<UnityAction<T0, T1, T2>, (T0, T1, T2)>((Action<(T0, T1, T2)> h) => delegate(T0 t0, T1 t1, T2 t2)
			{
				h((t0, t1, t2));
			}, delegate(UnityAction<T0, T1, T2> h)
			{
				unityEvent.AddListener(h);
			}, delegate(UnityAction<T0, T1, T2> h)
			{
				unityEvent.RemoveListener(h);
			}, cancellationToken);
		}

		public static Observable<(T0 Arg0, T1 Arg1, T2 Arg2, T3 Arg3)> AsObservable<T0, T1, T2, T3>(this UnityEvent<T0, T1, T2, T3> unityEvent, CancellationToken cancellationToken = default(CancellationToken))
		{
			return Observable.FromEvent<UnityAction<T0, T1, T2, T3>, (T0, T1, T2, T3)>((Action<(T0, T1, T2, T3)> h) => delegate(T0 t0, T1 t1, T2 t2, T3 t3)
			{
				h((t0, t1, t2, t3));
			}, delegate(UnityAction<T0, T1, T2, T3> h)
			{
				unityEvent.AddListener(h);
			}, delegate(UnityAction<T0, T1, T2, T3> h)
			{
				unityEvent.RemoveListener(h);
			}, cancellationToken);
		}
	}
}
