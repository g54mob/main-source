namespace Gh.Tk.Story.Requirements
{
	public class BuildMenuSelectedPropRequirementNode : RequirementNode
	{
		[DropDownChoice(typeof(StoryHelper), "GetAllPropOptions")]
		public string targetProp;

		protected override bool IsMetInternal(ActiveStory story)
		{
			return false;
		}
	}
}
