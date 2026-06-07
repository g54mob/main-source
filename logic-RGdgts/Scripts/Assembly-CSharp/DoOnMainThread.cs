using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DoOnMainThread : MonoBehaviour
{
	private static readonly Queue<Action> executeOnMainThreadUpdate;

	private static Thread mainThread;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	public static void AddAction(Action newAction, bool forceSchedule = false)
	{
	}
}
