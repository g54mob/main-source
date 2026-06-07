using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace MEC
{
	public class Threading : MonoBehaviour
	{
		private struct Process
		{
			public CoroutineHandle Handle;

			public IEnumerator<float> Enumerator;

			public Exception Exception;
		}

		private class ThreadData
		{
			public bool Running;

			public Thread Thread;

			public readonly object RunLock;

			public readonly object ProcessLock;

			public Process[] Processes;

			public int Head;

			public int Tail;
		}

		public const float SwitchBackToGUIThread = 0f;

		public const float YieldToOtherTasksOnThisThread = -42f;

		private readonly CoroutineHandle _coroutineKey;

		private readonly Queue<Exception> _exceptions;

		private readonly Queue<Process> _returningProcesses;

		private readonly List<ThreadData>[] _threadSpindles;

		private readonly List<ThreadData> _looseThreads;

		private readonly Queue<ThreadData> _abandonedThreads;

		private readonly object _returnLock;

		private static ThreadData _chosenThread;

		private const int ProcessesBlockSize = 32;

		private bool initialized;

		private static Threading _instance;

		private static Threading Instance => null;

		private void Awake()
		{
		}

		private void Initialize()
		{
		}

		private void OnDestroy()
		{
		}

		private void Update()
		{
		}

		public static float SwitchToExternalThread(UnityEngine.ThreadPriority priority)
		{
			return 0f;
		}

		public static float SwitchToExternalThread(System.Threading.ThreadPriority priority = System.Threading.ThreadPriority.Normal)
		{
			return 0f;
		}

		public static float SwitchToDedicatedExternalThread(UnityEngine.ThreadPriority priority)
		{
			return 0f;
		}

		public static float SwitchToDedicatedExternalThread(System.Threading.ThreadPriority priority = System.Threading.ThreadPriority.Normal)
		{
			return 0f;
		}

		private static IEnumerator<float> RetrieveCoroutine(IEnumerator<float> coptr, CoroutineHandle handle)
		{
			return null;
		}

		private static void AddItemToProcessQueue(ThreadData chosenThread, Process process)
		{
		}

		private static void SelectThreadFromSpindle(System.Threading.ThreadPriority priority)
		{
		}

		private static void SelectLooseThread(System.Threading.ThreadPriority priority)
		{
		}

		private static void ThreadProcess(object input)
		{
		}

		private void ReturnAllProcesses()
		{
		}

		private void ReturnProcess(Process process)
		{
		}

		public static void Sleep(float seconds)
		{
		}
	}
}
