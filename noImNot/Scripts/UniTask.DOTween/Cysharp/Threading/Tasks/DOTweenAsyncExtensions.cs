using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks.Sources;
using DG.Tweening;

namespace Cysharp.Threading.Tasks
{
	public static class DOTweenAsyncExtensions
	{
		private enum CallbackType
		{
			Kill = 0,
			Complete = 1,
			Pause = 2,
			Play = 3,
			Rewind = 4,
			StepComplete = 5
		}

		public struct TweenAwaiter : ICriticalNotifyCompletion, INotifyCompletion
		{
			private readonly Tween tween;

			public bool IsCompleted => false;

			public TweenAwaiter(Tween tween)
			{
				this.tween = null;
			}

			public TweenAwaiter GetAwaiter()
			{
				return default(TweenAwaiter);
			}

			public void GetResult()
			{
			}

			public void OnCompleted(Action continuation)
			{
			}

			public void UnsafeOnCompleted(Action continuation)
			{
			}
		}

		private sealed class TweenConfiguredSource : IUniTaskSource, IValueTaskSource, ITaskPoolNode<TweenConfiguredSource>
		{
			private static TaskPool<TweenConfiguredSource> pool;

			private TweenConfiguredSource nextNode;

			private readonly TweenCallback onCompleteCallbackDelegate;

			private Tween tween;

			private TweenCancelBehaviour cancelBehaviour;

			private CancellationToken cancellationToken;

			private CancellationTokenRegistration cancellationRegistration;

			private CallbackType callbackType;

			private bool canceled;

			private TweenCallback originalCompleteAction;

			private UniTaskCompletionSourceCore<AsyncUnit> core;

			public ref TweenConfiguredSource NextNode
			{
				get
				{
					throw null;
				}
			}

			static TweenConfiguredSource()
			{
			}

			private TweenConfiguredSource()
			{
			}

			public static IUniTaskSource Create(Tween tween, TweenCancelBehaviour cancelBehaviour, CancellationToken cancellationToken, CallbackType callbackType, out short token)
			{
				token = default(short);
				return null;
			}

			private void OnCompleteCallbackDelegate()
			{
			}

			private static void DoCancelBeforeCreate(Tween tween, TweenCancelBehaviour tweenCancelBehaviour)
			{
			}

			public void GetResult(short token)
			{
			}

			public UniTaskStatus GetStatus(short token)
			{
				return default(UniTaskStatus);
			}

			public UniTaskStatus UnsafeGetStatus()
			{
				return default(UniTaskStatus);
			}

			public void OnCompleted(Action<object> continuation, object state, short token)
			{
			}

			private bool TryReturn()
			{
				return false;
			}

			private void RestoreOriginalCallback()
			{
			}
		}

		public static TweenAwaiter GetAwaiter(this Tween tween)
		{
			return default(TweenAwaiter);
		}

		public static UniTask WithCancellation(this Tween tween, CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		public static UniTask ToUniTask(this Tween tween, TweenCancelBehaviour tweenCancelBehaviour = TweenCancelBehaviour.Kill, CancellationToken cancellationToken = default(CancellationToken))
		{
			return default(UniTask);
		}

		public static UniTask AwaitForComplete(this Tween tween, TweenCancelBehaviour tweenCancelBehaviour = TweenCancelBehaviour.Kill, CancellationToken cancellationToken = default(CancellationToken))
		{
			return default(UniTask);
		}

		public static UniTask AwaitForPause(this Tween tween, TweenCancelBehaviour tweenCancelBehaviour = TweenCancelBehaviour.Kill, CancellationToken cancellationToken = default(CancellationToken))
		{
			return default(UniTask);
		}

		public static UniTask AwaitForPlay(this Tween tween, TweenCancelBehaviour tweenCancelBehaviour = TweenCancelBehaviour.Kill, CancellationToken cancellationToken = default(CancellationToken))
		{
			return default(UniTask);
		}

		public static UniTask AwaitForRewind(this Tween tween, TweenCancelBehaviour tweenCancelBehaviour = TweenCancelBehaviour.Kill, CancellationToken cancellationToken = default(CancellationToken))
		{
			return default(UniTask);
		}

		public static UniTask AwaitForStepComplete(this Tween tween, TweenCancelBehaviour tweenCancelBehaviour = TweenCancelBehaviour.Kill, CancellationToken cancellationToken = default(CancellationToken))
		{
			return default(UniTask);
		}
	}
}
