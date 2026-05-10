using System;
using FishNet.Connection;

namespace FishNet.Managing.Scened
{
	public class LoadQueueData
	{
		[NonSerialized]
		public SceneScopeType ScopeType;

		[NonSerialized]
		public NetworkConnection[] Connections;

		public SceneLoadData SceneLoadData;

		public string[] GlobalScenes;

		[NonSerialized]
		public readonly bool AsServer;

		public LoadQueueData()
		{
		}

		internal LoadQueueData(SceneScopeType scopeType, NetworkConnection[] conns, SceneLoadData sceneLoadData, string[] globalScenes, bool asServer)
		{
		}
	}
}
