namespace Gh.Tk.Story.Actions
{
	public class ExplodeStockActionNode : ConnectedStoryNode
	{
		[DropDownChoice(typeof(StoryHelper), "GetAllGameItemTemplateIds")]
		public string itemKey;

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
