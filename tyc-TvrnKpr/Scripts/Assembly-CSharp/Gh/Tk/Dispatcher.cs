using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class Dispatcher : MonoBehaviour
	{
		private static Queue<Action> _queue;

		private static object _lockObject;

		private void Update()
		{
		}

		public static void AddAction(Action action)
		{
		}
	}
}
