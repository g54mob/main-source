using UnityEngine;
using UnityEngine.SceneManagement;

namespace VisualDesignCafe.Nature
{
	internal class RuntimeGlobalWindInitializer
	{
		[RuntimeInitializeOnLoadMethod]
		private static void Initialize()
		{
		}

		private static void OnActiveSceneChanged(Scene previousScene, Scene activeScene)
		{
		}

		private static void ApplyDefaultWind()
		{
		}
	}
}
