using UnityEngine;

namespace Gh.Tk.Story.Actions
{
	public class AddGazetteSideStoryActionNode : ConnectedStoryNode
	{
		[StoryNodeTranslateFieldContent("gazette side stories", "Gazette")]
		[Tooltip("These will have a 20% chance to be picked as a side story")]
		public string[] sideStories;

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
