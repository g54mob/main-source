using UnityEngine;
using XNode;

namespace Gh.Tk.Story.Actions.Visual
{
	[NodeTint("#7f7189")]
	public class CameraAnimClipActionNode : ConnectedStoryNode, ISkippableNode
	{
		[Header("Free Camera Only")]
		public AnimationClip animation;

		public bool allowSkip;

		private string AnimStartedKey => null;

		private void OnValidate()
		{
		}

		public override void OnTrigger(ActiveStory story)
		{
		}

		public override void OnUpdate(ActiveStory story)
		{
		}

		private void StartAnim(ActiveStory story)
		{
		}

		public void Skip(ActiveStory story)
		{
		}
	}
}
