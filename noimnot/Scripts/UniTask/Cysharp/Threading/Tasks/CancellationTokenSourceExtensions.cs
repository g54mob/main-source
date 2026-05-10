using System;
using System.Threading;
using UnityEngine;

namespace Cysharp.Threading.Tasks
{
	public static class CancellationTokenSourceExtensions
	{
		private static readonly Action<object> CancelCancellationTokenSourceStateDelegate;

		private static void CancelCancellationTokenSourceState(object state)
		{
		}

		public static IDisposable CancelAfterSlim(this CancellationTokenSource cts, int millisecondsDelay, DelayType delayType = DelayType.DeltaTime, PlayerLoopTiming delayTiming = PlayerLoopTiming.Update)
		{
			return null;
		}

		public static IDisposable CancelAfterSlim(this CancellationTokenSource cts, TimeSpan delayTimeSpan, DelayType delayType = DelayType.DeltaTime, PlayerLoopTiming delayTiming = PlayerLoopTiming.Update)
		{
			return null;
		}

		public static void RegisterRaiseCancelOnDestroy(this CancellationTokenSource cts, Component component)
		{
		}

		public static void RegisterRaiseCancelOnDestroy(this CancellationTokenSource cts, GameObject gameObject)
		{
		}
	}
}
