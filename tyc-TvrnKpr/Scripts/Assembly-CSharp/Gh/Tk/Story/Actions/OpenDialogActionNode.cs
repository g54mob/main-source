namespace Gh.Tk.Story.Actions
{
	public class OpenDialogActionNode : ConnectedStoryNode
	{
		[DropDownChoice(typeof(StoryHelper), "GetAllDialogIds")]
		public string dialogId;

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
