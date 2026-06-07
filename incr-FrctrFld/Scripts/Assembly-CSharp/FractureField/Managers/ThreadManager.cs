using System;
using System.Collections.Generic;
using UnityEngine;

namespace FractureField.Managers
{
	public class ThreadManager : MonoBehaviour
	{
		private static readonly List<Action> executeOnMainThread;

		private static readonly List<Action> executeCopiedOnMainThread;

		private static bool actionToExecuteOnMainThread;

		public void Execute()
		{
		}

		public static void QueueMainThread(Action _action)
		{
		}

		public static void UpdateMain()
		{
		}
	}
}
