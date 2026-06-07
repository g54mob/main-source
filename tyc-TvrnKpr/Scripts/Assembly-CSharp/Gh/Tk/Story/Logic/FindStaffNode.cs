namespace Gh.Tk.Story.Logic
{
	public class FindStaffNode : ConnectedStoryNode
	{
		[DropDownChoice(typeof(StoryHelper), "GetRaces")]
		public string race;

		public override void OnUpdate(ActiveStory story)
		{
		}

		private Staff FindStaff()
		{
			return null;
		}
	}
}
