using System.Collections;
using UnityEngine;

namespace VampireSurvivors.Tools
{
	public class CoroutineRunner : MonoBehaviour
	{
		public static CoroutineRunner Instance;

		private void Awake()
		{
		}

		private Coroutine Begin(IEnumerator c)
		{
			return null;
		}

		public static Coroutine Run(IEnumerator c)
		{
			return null;
		}
	}
}
