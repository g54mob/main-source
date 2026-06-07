using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ludiq
{
	public static class ReferenceCollector
	{
		public static event Action onSceneUnloaded;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void Initialize()
		{
			SceneManager.sceneUnloaded += delegate
			{
				ReferenceCollector.onSceneUnloaded?.Invoke();
			};
		}
	}
}
