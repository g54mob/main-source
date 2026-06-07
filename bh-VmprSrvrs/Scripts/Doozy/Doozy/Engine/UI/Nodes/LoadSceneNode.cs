using Doozy.Engine.Nody.Attributes;
using Doozy.Engine.Nody.Models;
using Doozy.Engine.SceneManagement;
using UnityEngine.SceneManagement;

namespace Doozy.Engine.UI.Nodes
{
	[NodeMenu("Scene Management/Load Scene", 50, false, false)]
	public class LoadSceneNode : Node
	{
		public GetSceneBy GetSceneBy;

		public LoadSceneMode LoadSceneMode;

		public bool AllowSceneActivation;

		public float SceneActivationDelay;

		public int SceneBuildIndex;

		public string SceneName;

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

		private void LoadScene()
		{
		}

		public override void CheckForErrors()
		{
		}
	}
}
