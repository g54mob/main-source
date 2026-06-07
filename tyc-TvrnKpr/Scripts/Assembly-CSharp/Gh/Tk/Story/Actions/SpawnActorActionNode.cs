namespace Gh.Tk.Story.Actions
{
	public class SpawnActorActionNode : ConnectedStoryNode
	{
		public string prefabId;

		[StoryNodeTranslateFieldContent("Actor Name", "Node")]
		public new string name;

		[DropDownChoice(typeof(StoryHelper), "GetRaces")]
		public string race;

		[DropDownChoice(typeof(StoryHelper), "GetGenders")]
		public string gender;

		public override void OnTrigger(ActiveStory story)
		{
		}

		private Actor SpawnActor()
		{
			return null;
		}
	}
}
