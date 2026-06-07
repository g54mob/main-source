using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace KS.UnityToolbag
{
	[AddComponentMenu("KS/UnityToolbag/Dispatcher")]
	public class Dispatcher : MonoBehaviour
	{
		private static Dispatcher _instance;

		private static bool _instanceExists;

		private static Thread _mainThread;

		private static object _lockObject;

		private static readonly Queue<Action> _actions;

		public static bool isMainThread => false;

		public static void InvokeAsync(Action action)
		{
		}

		public static void Invoke(Action action)
		{
		}

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void Update()
		{
		}
	}
}
