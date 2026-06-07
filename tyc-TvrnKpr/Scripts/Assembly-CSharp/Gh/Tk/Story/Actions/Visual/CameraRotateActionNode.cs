using System.Collections.Generic;
using DG.Tweening;
using XNode;

namespace Gh.Tk.Story.Actions.Visual
{
	[NodeTint("#7f7189")]
	public class CameraRotateActionNode : ConnectedStoryNode
	{
		private static List<Tween> _cameraTweens;

		public Ease easing;

		public float degree;

		public float duration;

		static CameraRotateActionNode()
		{
		}

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
