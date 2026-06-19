using System;
using UnityEngine;

public class GlobalPersistentInstance : MonoBehaviour
{
	private static GlobalPersistentInstance Instance;

	private static Action _doTriggerOnLoad;

	public static void TriggerWhenLoaded(Action action)
	{
	}

	private void Awake()
	{
	}
}
