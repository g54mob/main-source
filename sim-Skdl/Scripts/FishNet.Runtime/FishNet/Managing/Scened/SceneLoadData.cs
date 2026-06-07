using System.Collections.Generic;
using FishNet.Object;
using UnityEngine.SceneManagement;

namespace FishNet.Managing.Scened
{
	public class SceneLoadData
	{
		public SceneLookupData PreferredActiveScene;

		public SceneLookupData[] SceneLookupDatas;

		public NetworkObject[] MovedNetworkObjects;

		public ReplaceOption ReplaceScenes;

		public LoadParams Params;

		public LoadOptions Options;

		public SceneLoadData()
		{
		}

		public SceneLoadData(Scene scene)
		{
		}

		public SceneLoadData(string sceneName)
		{
		}

		public SceneLoadData(int sceneHandle)
		{
		}

		public SceneLoadData(int sceneHandle, string sceneName)
		{
		}

		public SceneLoadData(SceneLookupData sceneLookupData)
		{
		}

		public SceneLoadData(List<Scene> scenes)
		{
		}

		public SceneLoadData(List<string> sceneNames)
		{
		}

		public SceneLoadData(List<int> sceneHandles)
		{
		}

		public SceneLoadData(Scene[] scenes)
		{
		}

		public SceneLoadData(string[] sceneNames)
		{
		}

		public SceneLoadData(int[] sceneHandles)
		{
		}

		public SceneLoadData(SceneLookupData[] sceneLookupDatas)
		{
		}

		public SceneLoadData(Scene scene, NetworkObject[] movedNetworkObjects)
		{
		}

		public SceneLoadData(Scene[] scenes, NetworkObject[] movedNetworkObjects)
		{
		}

		public SceneLoadData(string[] sceneNames, NetworkObject[] movedNetworkObjects)
		{
		}

		public SceneLoadData(int[] sceneHandles, NetworkObject[] movedNetworkObjects)
		{
		}

		public SceneLoadData(SceneLookupData[] sceneLookupDatas, NetworkObject[] movedNetworkObjects)
		{
		}

		private void Construct(SceneLookupData[] datas, NetworkObject[] movedNetworkObjects)
		{
		}

		public Scene GetFirstLookupScene()
		{
			return default(Scene);
		}

		internal bool DataInvalid()
		{
			return false;
		}
	}
}
