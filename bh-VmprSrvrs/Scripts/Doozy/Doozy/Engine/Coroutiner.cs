using System.Collections;
using UnityEngine;

namespace Doozy.Engine
{
	public class Coroutiner : MonoBehaviour
	{
		private static Coroutiner s_instance;

		public static Coroutiner Instance => null;

		public static bool ApplicationIsQuitting { get; private set; }

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void RunOnStart()
		{
		}

		private void Awake()
		{
		}

		private void OnApplicationQuit()
		{
		}

		public Coroutine StartLocalCoroutine(IEnumerator enumerator)
		{
			return null;
		}

		public void StopLocalCoroutine(Coroutine coroutine)
		{
		}

		public void StopLocalCoroutine(IEnumerator enumerator)
		{
		}

		public void StopAllLocalCoroutines()
		{
		}

		public static Coroutine Start(IEnumerator enumerator)
		{
			return null;
		}

		public static void Stop(IEnumerator enumerator)
		{
		}

		public static void Stop(Coroutine coroutine)
		{
		}

		public static void StopAll()
		{
		}
	}
}
