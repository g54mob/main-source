namespace Gh.Tk.Story.Actions
{
	public class AddHiddenObjectsToLevelActionNode : ConnectedStoryNode
	{
		[DropDownChoice(typeof(StoryHelper), "GetAllStoryFlags")]
		public string storyFlag;

		public bool initializeStoryFlagsToZero;

		public string transformKey;

		public string prefabId;

		public int amount;

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
