using System;
using System.Threading;
using Cysharp.Threading.Tasks;

public static class UniTaskUtility
{
	public static async UniTaskVoid Loop(UniTask task, CancellationToken token)
	{
		while (!token.IsCancellationRequested)
		{
			await task;
			await UniTask.NextFrame(token, cancelImmediately: true);
		}
	}

	public static async UniTaskVoid Loop(Action task, CancellationToken token)
	{
		while (!token.IsCancellationRequested)
		{
			task();
			await UniTask.NextFrame(token, cancelImmediately: true);
		}
	}

	public static async UniTaskVoid Interval(float interval, UniTask task, CancellationToken token)
	{
		while (!token.IsCancellationRequested)
		{
			await task;
			await UniTask.WaitForSeconds(interval, ignoreTimeScale: false, PlayerLoopTiming.Update, token, cancelImmediately: true);
		}
	}

	public static async UniTaskVoid Interval(float interval, Action task, CancellationToken token)
	{
		while (!token.IsCancellationRequested)
		{
			task();
			await UniTask.WaitForSeconds(interval, ignoreTimeScale: false, PlayerLoopTiming.Update, token, cancelImmediately: true);
		}
	}

	public static async UniTaskVoid Delayed(float delay, UniTask task, CancellationToken token)
	{
		await UniTask.WaitForSeconds(delay, ignoreTimeScale: false, PlayerLoopTiming.Update, token, cancelImmediately: true);
		await task;
	}

	public static async UniTaskVoid Delayed(float delay, Action task, CancellationToken token)
	{
		await UniTask.WaitForSeconds(delay, ignoreTimeScale: false, PlayerLoopTiming.Update, token, cancelImmediately: true);
		task();
	}
}
