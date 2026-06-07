namespace Gh.Tk.Story.Actions
{
	public class UnlockTavernLevelNode : ConnectedStoryNode
	{
		[DropDownChoice(typeof(StoryHelper), "GetTavernLevelIds")]
		public string tavernLevel;

		public bool promptToGoToNextTavern;

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
