using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityThread : MonoBehaviour
{
	private static UnityThread instance = null;

	private static List<Action> actionQueuesUpdateFunc = new List<Action>();

	private List<Action> actionCopiedQueueUpdateFunc = new List<Action>();

	private static volatile bool noActionQueueToExecuteUpdateFunc = true;

	private static List<Action> actionQueuesLateUpdateFunc = new List<Action>();

	private List<Action> actionCopiedQueueLateUpdateFunc = new List<Action>();

	private static volatile bool noActionQueueToExecuteLateUpdateFunc = true;

	private static List<Action> actionQueuesFixedUpdateFunc = new List<Action>();

	private List<Action> actionCopiedQueueFixedUpdateFunc = new List<Action>();

	private static volatile bool noActionQueueToExecuteFixedUpdateFunc = true;

	public static void initUnityThread(bool visible = false)
	{
		if (!(instance != null) && Application.isPlaying)
		{
			GameObject gameObject = new GameObject("MainThreadExecuter");
			if (!visible)
			{
				gameObject.hideFlags = HideFlags.HideAndDontSave;
			}
			UnityEngine.Object.DontDestroyOnLoad(gameObject);
			instance = gameObject.AddComponent<UnityThread>();
		}
	}

	public void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}

	public static void executeCoroutine(IEnumerator action)
	{
		if (instance != null)
		{
			executeInUpdate(delegate
			{
				instance.StartCoroutine(action);
			});
		}
	}

	public static void executeInUpdate(Action action)
	{
		if (action == null)
		{
			throw new ArgumentNullException("action");
		}
		lock (actionQueuesUpdateFunc)
		{
			actionQueuesUpdateFunc.Add(action);
			noActionQueueToExecuteUpdateFunc = false;
		}
	}

	public void Update()
	{
		if (!noActionQueueToExecuteUpdateFunc)
		{
			actionCopiedQueueUpdateFunc.Clear();
			lock (actionQueuesUpdateFunc)
			{
				actionCopiedQueueUpdateFunc.AddRange(actionQueuesUpdateFunc);
				actionQueuesUpdateFunc.Clear();
				noActionQueueToExecuteUpdateFunc = true;
			}
			for (int i = 0; i < actionCopiedQueueUpdateFunc.Count; i++)
			{
				actionCopiedQueueUpdateFunc[i]();
			}
		}
	}

	public void OnDisable()
	{
		if (instance == this)
		{
			instance = null;
		}
	}
}
