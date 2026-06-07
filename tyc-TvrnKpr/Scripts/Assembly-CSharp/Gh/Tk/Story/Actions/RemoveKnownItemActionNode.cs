namespace Gh.Tk.Story.Actions
{
	public class RemoveKnownItemActionNode : ConnectedStoryNode
	{
		[DropDownChoice(typeof(StoryHelper), "GetAllGameItemTemplateIds")]
		public string templateId;

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
