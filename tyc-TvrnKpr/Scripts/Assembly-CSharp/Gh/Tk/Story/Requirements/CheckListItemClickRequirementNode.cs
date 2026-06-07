namespace Gh.Tk.Story.Requirements
{
	public class CheckListItemClickRequirementNode : RequirementNode
	{
		[DropDownChoice(typeof(StoryHelper), "GetAllStoryFlags")]
		public string setStoryFlagToOne;

		public bool requireConfirmation;

		private string GetClickedFlagId()
		{
			return null;
		}

		public void OnClicked(ActiveStory story)
		{
		}

		private void SetClickedFlag(ActiveStory story)
		{
		}

		protected override bool IsMetInternal(ActiveStory story)
		{
			return false;
		}

		public override string GetLabelKey(ActiveStory story)
		{
			return null;
		}
	}
}
