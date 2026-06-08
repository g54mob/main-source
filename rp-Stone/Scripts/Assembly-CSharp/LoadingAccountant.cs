using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LoadingAccountant
{
	private static readonly float TIMEOUT = 10f;

	private static List<LoadingAccountant> activeObjects = new List<LoadingAccountant>();

	private static Stack<LoadingAccountant> pool = new Stack<LoadingAccountant>();

	public bool isComplete { get; private set; }

	public string debugId { get; private set; }

	public float startTimestamp { get; private set; }

	public void Reset()
	{
		isComplete = true;
		debugId = null;
		startTimestamp = 0f;
	}

	public void MarkComplete()
	{
		Recycle(this);
	}

	public static bool IsBusy()
	{
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		for (int num = activeObjects.Count - 1; num >= 0; num--)
		{
			LoadingAccountant loadingAccountant = activeObjects[num];
			if (realtimeSinceStartup - loadingAccountant.startTimestamp >= TIMEOUT)
			{
				Debug.LogWarning("[Loading Accountant] Timeout when loading " + loadingAccountant.debugId);
				loadingAccountant.MarkComplete();
			}
		}
		return activeObjects.Count > 0;
	}

	public static LoadingAccountant Add(AsyncOperationHandle asyncHandle, string debugId = null)
	{
		LoadingAccountant obj = Add(debugId);
		asyncHandle.Completed += delegate
		{
			obj.MarkComplete();
		};
		return obj;
	}

	public static LoadingAccountant Add(string debugId = null)
	{
		LoadingAccountant loadingAccountant = ((pool.Count <= 0) ? new LoadingAccountant() : pool.Pop());
		activeObjects.Add(loadingAccountant);
		loadingAccountant.debugId = debugId;
		loadingAccountant.startTimestamp = Time.realtimeSinceStartup;
		return loadingAccountant;
	}

	private static void Recycle(LoadingAccountant obj)
	{
		activeObjects.Remove(obj);
		obj.Reset();
		pool.Push(obj);
	}
}
