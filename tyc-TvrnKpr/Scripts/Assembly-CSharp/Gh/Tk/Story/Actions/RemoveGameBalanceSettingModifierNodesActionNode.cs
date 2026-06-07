using Gh.Tk.Story.GameModifiers;

namespace Gh.Tk.Story.Actions
{
	public class RemoveGameBalanceSettingModifierNodesActionNode : ConnectedStoryNode
	{
		[DropDownChoice(typeof(GameBalanceSettingModifierNode), "GetAllPropertyNames")]
		public string propertyName;

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
