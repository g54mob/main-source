using UnityEngine;

namespace Gh.Tk.Story.Actions
{
	public class SetTavernStarsActionNode : ConnectedStoryNode
	{
		[Range(1f, 5f)]
		public int stars;

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
