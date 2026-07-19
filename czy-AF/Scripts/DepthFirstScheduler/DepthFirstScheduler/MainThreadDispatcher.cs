using System;
using System.Collections.Generic;
using UnityEngine;

namespace DepthFirstScheduler
{
	public class MainThreadDispatcher : MonoBehaviour
	{
		[Header("Debug")]
		public int TaskCount;

		private static MainThreadDispatcher instance;

		private static bool initialized;

		private static bool isQuitting;

		[ThreadStatic]
		private static object mainThreadToken;

		public static bool IsInitialized
		{
			get
			{
				if (initialized)
				{
					return instance != null;
				}
				return false;
			}
		}

		public static MainThreadDispatcher Instance
		{
			get
			{
				Initialize();
				return instance;
			}
		}

		public static bool IsInMainThread => mainThreadToken != null;

		private IEnumerable<Transform> Ancestors(Transform t)
		{
			yield return t;
			if (!(t.parent != null))
			{
				yield break;
			}
			foreach (Transform item in Ancestors(t.parent))
			{
				yield return item;
			}
		}

		private void Update()
		{
			TaskCount = Scheduler.MainThread.UpdateAndGetTaskCount();
		}

		public static void Initialize()
		{
			if (initialized)
			{
				return;
			}
			MainThreadDispatcher mainThreadDispatcher = null;
			try
			{
				mainThreadDispatcher = UnityEngine.Object.FindObjectOfType<MainThreadDispatcher>();
			}
			catch
			{
				Exception ex = new Exception("DepthFirstScheduler requires a MainThreadDispatcher component created on the main thread. Make sure it is added to the scene before calling DepthFirstScheduler from a worker thread.");
				Debug.LogException(ex);
				throw ex;
			}
			if (!isQuitting)
			{
				if (mainThreadDispatcher == null)
				{
					new GameObject("DepthFirstScheduler").AddComponent<MainThreadDispatcher>();
				}
				else
				{
					mainThreadDispatcher.Awake();
				}
			}
		}

		private void Awake()
		{
			if (instance == null)
			{
				Debug.Log("Initialize UniTask.MainThreadDispatcher");
				instance = this;
				mainThreadToken = new object();
				initialized = true;
				UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			}
			else if (this != instance)
			{
				Debug.LogWarning("There is already a MainThreadDispatcher in the scene.");
			}
		}

		private void OnDestroy()
		{
			if (instance == this)
			{
				instance = UnityEngine.Object.FindObjectOfType<MainThreadDispatcher>();
				initialized = instance != null;
			}
			if (Scheduler.SingleWorkerThread != null)
			{
				Scheduler.SingleWorkerThread.Dispose();
			}
		}

		private void OnApplicationQuit()
		{
			isQuitting = true;
		}
	}
}
