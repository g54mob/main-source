namespace Gh.Tk.Story.Actions
{
	public class ActivateUIThemeActionNode : ConnectedStoryNode
	{
		[DropDownChoice(typeof(StoryHelper), "GetUIThemes")]
		public string uiTheme;

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
