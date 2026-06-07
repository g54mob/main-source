using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Jundroo.Common.Threading.Tasks
{
	public static class UniTaskEx
	{
		public static async UniTask<T> WaitUntilNotNull<T>(Func<T> valueFunc, PlayerLoopTiming timing = PlayerLoopTiming.Update) where T : class
		{
			T val;
			for (val = valueFunc(); val == null; val = valueFunc())
			{
				await UniTask.Yield(timing);
			}
			return val;
		}

		public static async UniTask<bool> WaitUntilWithTimeout(Func<bool> predicate, int timeout, PlayerLoopTiming timing = PlayerLoopTiming.Update, DelayType timeoutDelayType = DelayType.UnscaledDeltaTime, PlayerLoopTiming timeoutDelayTiming = PlayerLoopTiming.Update)
		{
			CancellationTokenSource cancellationToken = new CancellationTokenSource();
			IDisposable timeoutTask = cancellationToken.CancelAfterSlim(timeout, timeoutDelayType, timeoutDelayTiming);
			try
			{
				await UniTask.WaitUntil(predicate, timing, cancellationToken.Token);
			}
			catch (OperationCanceledException)
			{
				return false;
			}
			finally
			{
				timeoutTask.Dispose();
				cancellationToken.Dispose();
			}
			return true;
		}

		public static async UniTask<bool> WaitWithTimeout(Func<CancellationToken, UniTask> task, int timeout, DelayType timeoutDelayType = DelayType.UnscaledDeltaTime, PlayerLoopTiming timeoutDelayTiming = PlayerLoopTiming.Update)
		{
			CancellationTokenSource cancellationToken = new CancellationTokenSource();
			IDisposable timeoutTask = cancellationToken.CancelAfterSlim(timeout, timeoutDelayType, timeoutDelayTiming);
			try
			{
				UniTask t = task(cancellationToken.Token);
				await t;
				return t.Status == UniTaskStatus.Succeeded;
			}
			catch (OperationCanceledException)
			{
				return false;
			}
			finally
			{
				timeoutTask.Dispose();
				cancellationToken.Dispose();
			}
		}

		public static async UniTask<(TTaskResult TaskResult, bool Success)> WaitWithTimeout<TTaskResult>(Func<CancellationToken, UniTask<TTaskResult>> task, int timeout, DelayType timeoutDelayType = DelayType.UnscaledDeltaTime, PlayerLoopTiming timeoutDelayTiming = PlayerLoopTiming.Update)
		{
			CancellationTokenSource cancellationToken = new CancellationTokenSource();
			IDisposable timeoutTask = cancellationToken.CancelAfterSlim(timeout, timeoutDelayType, timeoutDelayTiming);
			try
			{
				UniTask<TTaskResult> t = task(cancellationToken.Token);
				return (await t, t.Status == UniTaskStatus.Succeeded);
			}
			catch (OperationCanceledException)
			{
				return (default(TTaskResult), false);
			}
			finally
			{
				timeoutTask.Dispose();
				cancellationToken.Dispose();
			}
		}
	}
}
