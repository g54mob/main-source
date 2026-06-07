using System;
using Coherence.Connection;
using UnityEngine.SceneManagement;

namespace Coherence.Toolkit
{
	[Serializable]
	public class CoherenceSceneLoaderConfig
	{
		public ConnectionType connectionType;

		public string sceneName;

		public LocalPhysicsMode localPhysicsMode;

		public UnloadSceneOptions unloadSceneOptions;
	}
}
