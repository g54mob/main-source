using System.Collections;
using UnityEngine;

namespace Restory.Infrastructure.ProjectServices
{
	public class CoroutineRunner : MonoBehaviour, ICoroutineRunner
	{
		public Coroutine Run(IEnumerator coroutine)
		{
			return StartCoroutine(coroutine);
		}

		public void Stop(Coroutine coroutine)
		{
			StopCoroutine(coroutine);
		}

		private void OnDestroy()
		{
			StopAllCoroutines();
		}
	}
}
