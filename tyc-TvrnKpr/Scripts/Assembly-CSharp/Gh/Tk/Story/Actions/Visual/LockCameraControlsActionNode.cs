using UnityEngine;
using XNode;

namespace Gh.Tk.Story.Actions.Visual
{
	[NodeTint("#7f7189")]
	public class LockCameraControlsActionNode : ConnectedStoryNode
	{
		public bool isLocked;

		[Tooltip("Skips cinemas bars transition")]
		public bool skipTransition;

		public override void OnTrigger(ActiveStory story)
		{
		}

		public override void OnUpdate(ActiveStory story)
		{
		}
	}
}
