using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Placemaker
{
	public static class FastCoroutines
	{
		public struct Item
		{
			public bool isAction;

			public IEnumerator enumerator;

			public Action action;
		}

		public static List<Item> items;

		public static Stopwatch stopwatch;

		public static int staticMilliseconds;

		public static bool FastIterate(int milliseconds)
		{
			return false;
		}

		public static void Queue(this IEnumerator enumerator)
		{
		}

		public static void Queue(this Action action)
		{
		}

		public static void StartFastCoroutine(this MonoBehaviour monoBehaviour, IEnumerator<bool> enumerator, int milliseconds = 6)
		{
		}

		public static bool KeepGoing()
		{
			return false;
		}

		private static IEnumerator FastCoroutine(IEnumerator<bool> enumerator, int milliseconds)
		{
			return null;
		}
	}
}
