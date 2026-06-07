using System.Collections;
using DV.Utils;
using UnityEngine;

public class CoroutineManager : SingletonBehaviour<CoroutineManager>
{
	public new static string AllowAutoCreate()
	{
		return "[coroutine manager]";
	}

	public Coroutine Run(IEnumerator coro)
	{
		return StartCoroutine(coro);
	}

	public void Stop(Coroutine coro)
	{
		if (coro != null)
		{
			StopCoroutine(coro);
		}
	}
}
