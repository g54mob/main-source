namespace Gh.Tk.Story.Actions
{
	public class GiftPropToPlayerActionNode : ActionBaseNode
	{
		[DropDownChoice(typeof(StoryHelper), "GetAllPropOptionsWithoutAnyX")]
		public string[] props;

		[DropDownChoice(typeof(StoryHelper), "GetAllDecoPropKeys")]
		public string[] decoProps;

		public bool spawnUnlockScreen;

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
