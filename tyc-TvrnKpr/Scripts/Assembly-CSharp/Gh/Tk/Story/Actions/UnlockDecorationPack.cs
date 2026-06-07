namespace Gh.Tk.Story.Actions
{
	public class UnlockDecorationPack : ConnectedStoryNode
	{
		[DropDownChoice(typeof(StoryHelper), "GetUnlockableDecorationPackIds")]
		public string packId;

		public bool markAsSeen;

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
