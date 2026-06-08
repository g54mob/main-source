using UnityEngine.SceneManagement;

namespace LaundryBear
{
	public static class SceneExtensions
	{
		public enum SceneLoadType
		{
			Unloaded = 0,
			Build = 1,
			AssetBundle = 2,
			NotInBuildSettings = 3
		}

		public static SceneLoadType GetSceneLoadType(this Scene scene)
		{
			if (scene.isLoaded)
			{
				if (scene.buildIndex == -1)
				{
					return SceneLoadType.AssetBundle;
				}
				if (scene.buildIndex >= SceneManager.sceneCountInBuildSettings)
				{
					return SceneLoadType.NotInBuildSettings;
				}
				return SceneLoadType.Build;
			}
			return SceneLoadType.Unloaded;
		}
	}
}
