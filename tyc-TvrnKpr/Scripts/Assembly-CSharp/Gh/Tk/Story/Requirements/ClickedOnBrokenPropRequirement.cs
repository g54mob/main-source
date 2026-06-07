namespace Gh.Tk.Story.Requirements
{
	public class ClickedOnBrokenPropRequirement : SelectedObjectRequirementBase
	{
		protected override bool IsMetInternal(ActiveStory story)
		{
			return false;
		}

		protected override void OnSelectedObjectChanged(ISelectable selectable, ActiveStory story)
		{
		}
	}
}
