using UnityEngine;
using XNode;

namespace Gh.Tk.Story.Narrative
{
	[NodeWidth(350)]
	[NodeTint("#466969")]
	public class MailNode : ConnectedStoryNode
	{
		[StoryNodeTranslateFieldContent("Mail Notification Title", "Mail")]
		public string notificationTitle;

		[DropDownChoice(typeof(StoryHelper), "GetAllHeaderImages")]
		public string topImage;

		[StoryNodeTranslateFieldContent("Mail Greeting", "Mail")]
		public string greeting;

		[TextArea(10, 20)]
		[StoryNodeTranslateFieldContent("Mail Content", "Mail")]
		public string content;

		[StoryNodeTranslateFieldContent("Mail Farewell", "Mail")]
		public string farewell;

		[TextArea(1, 3)]
		[StoryNodeTranslateFieldContent("Mail Signature", "Mail")]
		public string signature;

		[TextArea(1, 2)]
		[StoryNodeTranslateFieldContent("Mail Post Script", "Mail")]
		public string postScriptText;

		[DropDownChoice(typeof(StoryHelper), "GetAllMailSeals")]
		public string sealPrefab;

		public bool autoOpen;

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
