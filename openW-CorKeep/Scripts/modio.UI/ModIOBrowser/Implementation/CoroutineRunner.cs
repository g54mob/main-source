using System.Collections;
using ModIO.Util;
using UnityEngine;

namespace ModIOBrowser.Implementation
{
	internal class CoroutineRunner : SelfInstancingMonoSingleton<CoroutineRunner>
	{
		public Coroutine Run(IEnumerator coroutine)
		{
			return StartCoroutine(coroutine);
		}
	}
}
