using UnityEngine;

namespace Gh.Tk.Story.Actions
{
	public class AddHandbookTopic : ConnectedStoryNode
	{
		public string topicCodexId;

		[Tooltip("Show a notification when topic is added (only if topic is not already known)")]
		public bool announceTopic;

		[Tooltip("Optional when announced: Scroll to header with this codex line i.e. 'h2:Walls & Doors'")]
		public string scrollTo;

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
