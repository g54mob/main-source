using UnityEngine;
using XNode;

namespace Gh.Tk.Story.Actions
{
	[NodeTint("#db9239")]
	public class SetGameSpeedActionNode : ConnectedStoryNode
	{
		[Range(0f, 3f)]
		public int gameSpeed;

		public override void OnTrigger(ActiveStory story)
		{
		}

		public override void OnUpdate(ActiveStory story)
		{
		}

		private void SetGameSpeed(ActiveStory story)
		{
		}
	}
}
