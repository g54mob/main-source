namespace Gh.Tk.Story.GameModifiers
{
	public class PropDiscountGameModifierNode : GameModifierNode
	{
		[DropDownChoice(typeof(StoryHelper), "GetAllPropOptions")]
		public string propTypeId;

		public int discountPercentage;

		public override void OnTrigger(ActiveStory story)
		{
		}

		public override void Complete(ActiveStory story)
		{
		}
	}
}
