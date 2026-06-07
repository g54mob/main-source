namespace Gh.Tk.Story.Requirements
{
	public class BuildMenuSelectedZoneRequirementNode : RequirementNode
	{
		[DropDownChoice(typeof(StoryHelper), "GetAllZones")]
		public string targetZone;

		protected override bool IsMetInternal(ActiveStory story)
		{
			return false;
		}
	}
}
