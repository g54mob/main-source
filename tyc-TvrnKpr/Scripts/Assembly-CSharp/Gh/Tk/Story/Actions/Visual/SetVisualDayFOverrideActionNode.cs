using UnityEngine;

namespace Gh.Tk.Story.Actions.Visual
{
	public class SetVisualDayFOverrideActionNode : ConnectedStoryNode
	{
		[Range(0f, 1f)]
		public float dayF;

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
