using UnityEngine;
using XNode;

namespace Gh.Tk.Story.Actions.Visual
{
	[NodeTint("#7f7189")]
	public class CameraZoomActionNode : ConnectedStoryNode, ISkippableNode
	{
		[Range(0f, 1f)]
		public float zoomLevel;

		public float duration;

		public bool allowSkip;

		public override void OnTrigger(ActiveStory story)
		{
		}

		public override void OnUpdate(ActiveStory story)
		{
		}

		public void Skip(ActiveStory story)
		{
		}
	}
}
