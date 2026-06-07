using UnityEngine;
using XNode;

namespace Gh.Tk.Story.Actions.Visual
{
	[NodeTint("#7f7189")]
	public class CameraSetRotationActionNode : ConnectedStoryNode
	{
		[Range(0f, 360f)]
		public float rotationDegree;

		public bool snapToIncrement;

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
