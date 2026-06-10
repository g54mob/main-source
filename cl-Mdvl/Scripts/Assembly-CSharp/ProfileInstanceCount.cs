using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileInstanceCount
{
	private static readonly object padlock = new object();

	private static readonly Dictionary<string, int> InstanceCount = new Dictionary<string, int>();

	public static IEnumerable<KeyValuePair<string, int>> InstanceCountEnumerator
	{
		get
		{
			lock (padlock)
			{
				foreach (KeyValuePair<string, int> item in InstanceCount)
				{
					yield return item;
				}
			}
		}
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void OnDomainReload()
	{
		InstanceCount.Clear();
	}

	public static IEnumerator ExampleListObjectsInMemory()
	{
		GC.Collect();
		yield return new WaitForEndOfFrame();
		GC.WaitForPendingFinalizers();
		GC.Collect();
		Debug.Log("Object instances in memory: ");
		lock (padlock)
		{
			foreach (KeyValuePair<string, int> item in InstanceCountEnumerator)
			{
				string key = item.Key;
				int value = item.Value;
				if (value > 0)
				{
					Debug.Log($"Object: {key}, count: {value}");
				}
			}
		}
	}

	public static void ClearInstancesCount()
	{
	}

	public static object CreateProfileInstanceCount(string id, object objectInstance)
	{
		return null;
	}

	public static object CreateProfileInstanceCount(object objectInstance)
	{
		return null;
	}
}
