using Doozy.Engine.Nody.Attributes;
using Doozy.Engine.Nody.Models;
using Doozy.Engine.SceneManagement;
using UnityEngine.SceneManagement;

namespace Doozy.Engine.UI.Nodes
{
	[NodeMenu("Scene Management/Unload Scene", 50, false, false)]
	public class UnloadSceneNode : Node
	{
		public GetSceneBy GetSceneBy;

		public int SceneBuildIndex;

		public string SceneName;

		public bool WaitForSceneToUnload;

		public override void OnCreate()
		{
		}

		public override void AddDefaultSockets()
		{
		}

		public override void CopyNode(Node original)
		{
		}

		public override void OnEnter(Node previousActiveNode, Connection connection)
		{
		}

		public override void OnExit(Node nextActiveNode, Connection connection)
		{
		}

		private void UnloadScene()
		{
		}

		private void SceneUnloaded(Scene unloadedScene)
		{
		}

		public override void CheckForErrors()
		{
		}
	}
}
