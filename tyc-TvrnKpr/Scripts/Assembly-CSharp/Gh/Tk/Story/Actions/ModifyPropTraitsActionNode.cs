namespace Gh.Tk.Story.Actions
{
	public class ModifyPropTraitsActionNode : ConnectedStoryNode
	{
		[DropDownChoice(typeof(StoryHelper), "GetPropTraits")]
		public string[] traitsToAdd;

		[DropDownChoice(typeof(StoryHelper), "GetPropTraits")]
		public string[] traitsToRemove;

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
