using UnityEngine;

namespace Gh.Tk.Story.Actions
{
	public class SetMaxGameSpeedActionNode : ConnectedStoryNode
	{
		[Range(0f, 3f)]
		public int gameSpeed;

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
