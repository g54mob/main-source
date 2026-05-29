using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace FishNet.Managing.Scened
{
	public class SceneUnloadData
	{
		public SceneLookupData PreferredActiveScene;

		public SceneLookupData[] SceneLookupDatas;

		public UnloadParams Params;

		public UnloadOptions Options;

		public SceneUnloadData()
		{
		}

		public SceneUnloadData(Scene scene)
		{
		}

		public SceneUnloadData(string sceneName)
		{
		}

		public SceneUnloadData(int sceneHandle)
		{
		}

		public SceneUnloadData(SceneLookupData sceneLookupData)
		{
		}

		public SceneUnloadData(List<Scene> scenes)
		{
		}

		public SceneUnloadData(List<string> sceneNames)
		{
		}

		public SceneUnloadData(List<int> sceneHandles)
		{
		}

		public SceneUnloadData(Scene[] scenes)
		{
		}

		public SceneUnloadData(string[] sceneNames)
		{
		}

		public SceneUnloadData(int[] sceneHandles)
		{
		}

		public SceneUnloadData(SceneLookupData[] sceneLookupDatas)
		{
		}

		internal bool DataInvalid()
		{
			return false;
		}
	}
}
