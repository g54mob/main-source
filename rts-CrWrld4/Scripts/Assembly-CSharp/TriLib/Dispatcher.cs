using System;
using System.Collections.Generic;
using UnityEngine;

namespace TriLib
{
	public class Dispatcher : MonoBehaviour
	{
		private static Dispatcher _instance;

		private static bool _instanceExists;

		private static readonly object LockObject;

		private static readonly Queue<Action> Actions;

		public static void CheckInstance()
		{
		}

		public static void InvokeAsync(Action action)
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
