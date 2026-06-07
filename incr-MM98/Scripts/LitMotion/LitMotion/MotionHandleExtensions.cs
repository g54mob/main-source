using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace LitMotion
{
	public static class MotionHandleExtensions
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsValid(this MotionHandle handle)
		{
			return MotionManager.IsValid(handle);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsActive(this MotionHandle handle)
		{
			return MotionManager.IsActive(handle);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsPlaying(this MotionHandle handle)
		{
			return MotionManager.IsPlaying(handle);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static string GetDebugName(this MotionHandle handle)
		{
			return handle.ToString();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static MotionHandle Preserve(this MotionHandle handle)
		{
			MotionManager.GetDataRef(handle).State.IsPreserved = true;
			return handle;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Complete(this MotionHandle handle)
		{
			MotionManager.Complete(handle);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryComplete(this MotionHandle handle)
		{
			return MotionManager.TryComplete(handle);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Cancel(this MotionHandle handle)
		{
			MotionManager.Cancel(handle);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryCancel(this MotionHandle handle)
		{
			return MotionManager.TryCancel(handle);
		}

		public static MotionHandle AddTo(this MotionHandle handle, CompositeMotionHandle compositeMotionHandle)
		{
			compositeMotionHandle.Add(handle);
			return handle;
		}

		public static MotionHandle AddTo(this MotionHandle handle, GameObject target)
		{
			GetOrAddComponent<MotionHandleLinker>(target).Register(handle, LinkBehavior.CancelOnDestroy);
			return handle;
		}

		public static MotionHandle AddTo(this MotionHandle handle, GameObject target, LinkBehavior linkBehaviour)
		{
			GetOrAddComponent<MotionHandleLinker>(target).Register(handle, linkBehaviour);
			return handle;
		}

		public static MotionHandle AddTo(this MotionHandle handle, Component target)
		{
			GetOrAddComponent<MotionHandleLinker>(target.gameObject).Register(handle, LinkBehavior.CancelOnDestroy);
			return handle;
		}

		public static MotionHandle AddTo(this MotionHandle handle, Component target, LinkBehavior linkBehaviour)
		{
			GetOrAddComponent<MotionHandleLinker>(target.gameObject).Register(handle, linkBehaviour);
			return handle;
		}

		public static MotionHandle AddTo(this MotionHandle handle, MonoBehaviour target)
		{
			target.destroyCancellationToken.Register(delegate
			{
				if (handle.IsActive())
				{
					handle.Cancel();
				}
			}, useSynchronizationContext: false);
			return handle;
		}

		private static TComponent GetOrAddComponent<TComponent>(GameObject target) where TComponent : Component
		{
			if (!target.TryGetComponent<TComponent>(out var component))
			{
				return target.AddComponent<TComponent>();
			}
			return component;
		}

		public static IDisposable ToDisposable(this MotionHandle handle, DisposeBehavior disposeBehavior = DisposeBehavior.Cancel)
		{
			return new MotionHandleDisposable(handle, disposeBehavior);
		}

		public static IEnumerator ToYieldInstruction(this MotionHandle handle)
		{
			while (handle.IsActive())
			{
				yield return null;
			}
		}

		public static MotionAwaiter GetAwaiter(this MotionHandle handle)
		{
			return new MotionAwaiter(handle);
		}

		public static ValueTask ToValueTask(this MotionHandle handle, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!handle.IsActive())
			{
				return default(ValueTask);
			}
			short token;
			return new ValueTask(ValueTaskMotionTaskSource.Create(handle, CancelBehavior.Cancel, cancelAwaitOnMotionCanceled: true, cancellationToken, out token), token);
		}

		public static ValueTask ToValueTask(this MotionHandle handle, CancelBehavior cancelBehavior, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!handle.IsActive())
			{
				return default(ValueTask);
			}
			short token;
			return new ValueTask(ValueTaskMotionTaskSource.Create(handle, cancelBehavior, cancelAwaitOnMotionCanceled: true, cancellationToken, out token), token);
		}

		public static ValueTask ToValueTask(this MotionHandle handle, CancelBehavior cancelBehavior, bool cancelAwaitOnMotionCanceled, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!handle.IsActive())
			{
				return default(ValueTask);
			}
			short token;
			return new ValueTask(ValueTaskMotionTaskSource.Create(handle, cancelBehavior, cancelAwaitOnMotionCanceled, cancellationToken, out token), token);
		}

		public static Awaitable ToAwaitable(this MotionHandle handle, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!handle.IsActive())
			{
				return AwaitableMotionTaskSource.CompletedSource.Awaitable;
			}
			return AwaitableMotionTaskSource.Create(handle, CancelBehavior.Cancel, cancelAwaitOnMotionCanceled: true, cancellationToken).Awaitable;
		}

		public static Awaitable ToAwaitable(this MotionHandle handle, CancelBehavior cancelBehavior, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!handle.IsActive())
			{
				return AwaitableMotionTaskSource.CompletedSource.Awaitable;
			}
			return AwaitableMotionTaskSource.Create(handle, cancelBehavior, cancelAwaitOnMotionCanceled: true, cancellationToken).Awaitable;
		}

		public static Awaitable ToAwaitable(this MotionHandle handle, CancelBehavior cancelBehavior, bool cancelAwaitOnMotionCanceled, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!handle.IsActive())
			{
				return AwaitableMotionTaskSource.CompletedSource.Awaitable;
			}
			return AwaitableMotionTaskSource.Create(handle, cancelBehavior, cancelAwaitOnMotionCanceled, cancellationToken).Awaitable;
		}
	}
}
