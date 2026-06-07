using UnityEngine;

namespace Gh.Tk.Story.Actions
{
	public class SpawnGoxActionNode : ConnectedStoryNode
	{
		public string prefabId;

		public Vector3 targetPosition;

		public Vector3 targetRotation;

		public override void OnTrigger(ActiveStory story)
		{
		}

		private void Spawn()
		{
		}
	}
}
