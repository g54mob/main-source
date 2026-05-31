using System;
using System.Threading;
using System.Threading.Tasks.Sources;
using UnityEngine.Events;

namespace Cysharp.Threading.Tasks
{
	public class AsyncUnityEventHandler : IUniTaskSource, IValueTaskSource, IDisposable, IAsyncClickEventHandler
	{
		private static Action<object> cancellationCallback;

		private readonly UnityAction action;

		private readonly UnityEvent unityEvent;

		private CancellationToken cancellationToken;

		private CancellationTokenRegistration registration;

		private bool isDisposed;

		private bool callOnce;

		private UniTaskCompletionSourceCore<AsyncUnit> core;

		public AsyncUnityEventHandler(UnityEvent unityEvent, CancellationToken cancellationToken, bool callOnce)
		{
		}

		public UniTask OnInvokeAsync()
		{
			return default(UniTask);
		}

		private void Invoke()
		{
		}

		private static void CancellationCallback(object state)
		{
		}

		public void Dispose()
		{
		}

		UniTask IAsyncClickEventHandler.OnClickAsync()
		{
			return default(UniTask);
		}

		void IUniTaskSource.GetResult(short token)
		{
		}

		UniTaskStatus IUniTaskSource.GetStatus(short token)
		{
			return default(UniTaskStatus);
		}

		UniTaskStatus IUniTaskSource.UnsafeGetStatus()
		{
			return default(UniTaskStatus);
		}

		void IUniTaskSource.OnCompleted(Action<object> continuation, object state, short token)
		{
		}
	}
	public class AsyncUnityEventHandler<T> : IUniTaskSource<T>, IUniTaskSource, IValueTaskSource, IValueTaskSource<T>, IDisposable, IAsyncValueChangedEventHandler<T>, IAsyncEndEditEventHandler<T>, IAsyncEndTextSelectionEventHandler<T>, IAsyncTextSelectionEventHandler<T>, IAsyncDeselectEventHandler<T>, IAsyncSelectEventHandler<T>, IAsyncSubmitEventHandler<T>
	{
		private static Action<object> cancellationCallback;

		private readonly UnityAction<T> action;

		private readonly UnityEvent<T> unityEvent;

		private CancellationToken cancellationToken;

		private CancellationTokenRegistration registration;

		private bool isDisposed;

		private bool callOnce;

		private UniTaskCompletionSourceCore<T> core;

		public AsyncUnityEventHandler(UnityEvent<T> unityEvent, CancellationToken cancellationToken, bool callOnce)
		{
		}

		public UniTask<T> OnInvokeAsync()
		{
			return default(UniTask<T>);
		}

		private void Invoke(T result)
		{
		}

		private static void CancellationCallback(object state)
		{
		}

		public void Dispose()
		{
		}

		UniTask<T> IAsyncValueChangedEventHandler<T>.OnValueChangedAsync()
		{
			return default(UniTask<T>);
		}

		UniTask<T> IAsyncEndEditEventHandler<T>.OnEndEditAsync()
		{
			return default(UniTask<T>);
		}

		UniTask<T> IAsyncEndTextSelectionEventHandler<T>.OnEndTextSelectionAsync()
		{
			return default(UniTask<T>);
		}

		UniTask<T> IAsyncTextSelectionEventHandler<T>.OnTextSelectionAsync()
		{
			return default(UniTask<T>);
		}

		UniTask<T> IAsyncDeselectEventHandler<T>.OnDeselectAsync()
		{
			return default(UniTask<T>);
		}

		UniTask<T> IAsyncSelectEventHandler<T>.OnSelectAsync()
		{
			return default(UniTask<T>);
		}

		UniTask<T> IAsyncSubmitEventHandler<T>.OnSubmitAsync()
		{
			return default(UniTask<T>);
		}

		T IUniTaskSource<T>.GetResult(short token)
		{
			return default(T);
		}

		void IUniTaskSource.GetResult(short token)
		{
		}

		UniTaskStatus IUniTaskSource.GetStatus(short token)
		{
			return default(UniTaskStatus);
		}

		UniTaskStatus IUniTaskSource.UnsafeGetStatus()
		{
			return default(UniTaskStatus);
		}

		void IUniTaskSource.OnCompleted(Action<object> continuation, object state, short token)
		{
		}
	}
}
