using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public static class UniTaskExtensions
{
	public static void ForgetSafe(this UniTask task, Action<Exception> onException = null)
	{
		ForgetInternal(task, onException).Forget();
	}

	private static async UniTaskVoid ForgetInternal(UniTask task, Action<Exception> onException)
	{
		try
		{
			await task;
		}
		catch (OperationCanceledException)
		{
		}
		catch (Exception ex2)
		{
			onException?.Invoke(ex2);
			Debug.LogException(ex2);
		}
	}
}
