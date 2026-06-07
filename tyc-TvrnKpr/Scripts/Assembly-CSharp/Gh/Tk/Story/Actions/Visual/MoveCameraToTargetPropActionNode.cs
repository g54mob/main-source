using UnityEngine;
using XNode;

namespace Gh.Tk.Story.Actions.Visual
{
	[NodeTint("#7f7189")]
	public class MoveCameraToTargetPropActionNode : ConnectedStoryNode
	{
		[Tooltip("If left at 0, it will use the first listed in selected prop of the story, if there is any, (use SelectPropTargetNode)")]
		public int propId;

		public Vector3 lookAtOffset;

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
