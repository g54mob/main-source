namespace Gh.Tk.Story.Actions
{
	public class SpawnInfestationNestActionNode : ConnectedStoryNode
	{
		public int numberOfNests;

		public bool preferRoomZone;

		[DropDownChoice(typeof(StoryHelper), "GetAllZones")]
		public string preferredRoomZone;

		public override void OnTrigger(ActiveStory story)
		{
		}

		private void SpawnNests(ActiveStory story)
		{
		}
	}
}
