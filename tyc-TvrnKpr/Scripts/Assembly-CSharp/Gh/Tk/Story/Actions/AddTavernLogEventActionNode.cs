using UnityEngine;

namespace Gh.Tk.Story.Actions
{
	public class AddTavernLogEventActionNode : ConnectedStoryNode
	{
		[StoryNodeTranslateFieldContent("tavern log event", "Node")]
		public string eventText;

		public TavernEventType eventType;

		[Tooltip("if set to true, clicking on the event text in the log will move the camera to the story target")]
		public bool setStoryTargetAsEventContext;

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
