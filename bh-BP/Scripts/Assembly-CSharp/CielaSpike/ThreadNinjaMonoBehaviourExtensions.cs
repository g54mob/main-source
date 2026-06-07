using System.Collections;
using UnityEngine;

namespace CielaSpike
{
	public static class ThreadNinjaMonoBehaviourExtensions
	{
		public static Coroutine StartCoroutineAsync(this MonoBehaviour behaviour, IEnumerator routine, out Task task)
		{
			task = null;
			return null;
		}

		public static Coroutine StartCoroutineAsync(this MonoBehaviour behaviour, IEnumerator routine)
		{
			return null;
		}
	}
}
