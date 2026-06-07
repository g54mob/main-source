namespace Gh.Tk.Story.Actions
{
	public class SetTavernNameActionNode : ConnectedStoryNode
	{
		[StoryNodeTranslateFieldContent("tavernName", "Node")]
		public string tavernName;

		public override void OnTrigger(ActiveStory story)
		{
		}

		protected override void GenerateI18nEntriesInternal(string context)
		{
		}
	}
}
