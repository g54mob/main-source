using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainThreadDispatcher : MonoBehaviour
{
	private static readonly Queue<Action> queue;

	private static MainThreadDispatcher instance;

	public void Awake()
	{
	}

	public void Update()
	{
	}

	public void Enqueue(IEnumerator action)
	{
	}

	public void Enqueue(Action action)
	{
	}

	private IEnumerator ActionWrapper(Action action)
	{
		return null;
	}

	public static bool Exists()
	{
		return false;
	}

	public static MainThreadDispatcher Instance()
	{
		return null;
	}

	private void OnDestroy()
	{
	}
}
