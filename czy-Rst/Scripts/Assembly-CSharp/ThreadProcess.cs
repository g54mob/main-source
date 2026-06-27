using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class ThreadProcess
{
	public static async void SetProcess(Func<bool> method, Action onFinish = null)
	{
		Task _r = Processing(method);
		await _r;
		if (_r.IsCompleted)
		{
			onFinish?.Invoke();
		}
		if (_r.IsFaulted)
		{
			Debug.Log("Task Fail");
		}
		if (_r.IsCanceled)
		{
			Debug.Log("Task Canceled");
		}
		_r.Dispose();
	}

	private static Task Processing(Func<bool> method)
	{
		Task task = new Task(delegate
		{
			new Thread((ThreadStart)delegate
			{
				method();
			}).Start();
		});
		task.Start();
		return task;
	}
}
