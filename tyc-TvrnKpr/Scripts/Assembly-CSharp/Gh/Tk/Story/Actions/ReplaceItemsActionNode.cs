namespace Gh.Tk.Story.Actions
{
	public class ReplaceItemsActionNode : ConnectedStoryNode
	{
		[DropDownChoice(typeof(StoryHelper), "GetAllGameItemTemplateIds")]
		public string templateId;

		[DropDownChoice(typeof(StoryHelper), "GetAllGameItemTemplateIds")]
		public string newTemplateId;

		public override void OnTrigger(ActiveStory story)
		{
		}

		public override void OnUpdate(ActiveStory story)
		{
		}
	}
}
