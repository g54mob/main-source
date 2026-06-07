using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ThreadPoolManager : MonoBehaviour
{
	public interface ITask
	{
		bool Completed { get; }

		void ThreadPoolWaitCallback(object state);

		void UnityCompletedCallback();
	}

	private static ThreadPoolManager _instance;

	private Queue<ITask> _taskQueue;

	private List<ITask> _queuedTasks;

	private void Awake()
	{
		if (_instance == null || _instance == this)
		{
			_instance = this;
			_taskQueue = new Queue<ITask>();
			_queuedTasks = new List<ITask>();
		}
		else
		{
			Object.Destroy(this);
		}
	}

	private void Update()
	{
		while (0 < _taskQueue.Count)
		{
			ITask task = _taskQueue.Peek();
			if (task.Completed || ThreadPool.QueueUserWorkItem(task.ThreadPoolWaitCallback))
			{
				_queuedTasks.Add(_taskQueue.Dequeue());
				continue;
			}
			break;
		}
	}

	private void LateUpdate()
	{
		int count = _queuedTasks.Count;
		while (0 < count--)
		{
			ITask task = _queuedTasks[count];
			if (task.Completed)
			{
				task.UnityCompletedCallback();
				_queuedTasks.RemoveAt(count);
			}
		}
	}

	public static bool QueueTask(ITask task)
	{
		if (_instance == null)
		{
			_instance = new GameObject().AddComponent<ThreadPoolManager>();
		}
		return _instance.AddTaskToQueue(task);
	}

	public bool AddTaskToQueue(ITask task)
	{
		if (_taskQueue.Contains(task))
		{
			return false;
		}
		_taskQueue.Enqueue(task);
		return true;
	}
}
