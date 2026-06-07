namespace Gh.Tk.Story.Actions
{
	public class CleanupHiddenObjectsFromLevelActionNode : ConnectedStoryNode
	{
		[DropDownChoice(typeof(StoryHelper), "GetAllStoryFlags")]
		public string storyFlag;

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
