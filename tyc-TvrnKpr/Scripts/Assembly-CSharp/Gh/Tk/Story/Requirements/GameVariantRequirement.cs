namespace Gh.Tk.Story.Requirements
{
	public class GameVariantRequirement : RequirementNode
	{
		[DropDownChoice(typeof(GameFlags), "GetVariantSymbols")]
		public string variantName;

		protected override bool IsMetInternal(ActiveStory story)
		{
			return false;
		}
	}
}
