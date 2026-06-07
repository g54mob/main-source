using Coherence.Connection;
using UnityEngine.SceneManagement;

namespace Coherence.Toolkit
{
	public class CoherenceSceneData
	{
		public string SceneName { get; set; }

		public ConnectionType ConnectionType { get; set; }

		public EndpointData EndpointData { get; set; }

		public LocalPhysicsMode LocalPhysicsMode { get; set; }
	}
}
