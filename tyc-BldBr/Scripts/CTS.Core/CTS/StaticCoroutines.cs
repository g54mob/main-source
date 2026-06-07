using System.Collections;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public sealed class StaticCoroutines : MonoPersistentSingleton<StaticCoroutines>
	{
		protected override void OnSingletonDestroy()
		{
		}

		protected override void SingletonAwake()
		{
		}

		public static Coroutine StartStaticCoroutine(IEnumerator routine)
		{
			return MonoSingleton<StaticCoroutines>.GetOrCreateInstance().StartCoroutine(routine);
		}

		public static void StopStaticCoroutine(Coroutine routine)
		{
			if (routine != null && MonoSingleton<StaticCoroutines>.TryGetInstance(out var outInstance))
			{
				outInstance.StopCoroutine(routine);
			}
		}

		public static void StopAllStaticCoroutines()
		{
			if (MonoSingleton<StaticCoroutines>.TryGetInstance(out var outInstance))
			{
				outInstance.StopAllCoroutines();
			}
		}
	}
}
