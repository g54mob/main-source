using XNode;

namespace Gh.Tk.Story.Logic
{
	public class IfConditionNode : ContinueWhenStoryNode
	{
		[Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection outputFalse;

		public override void OnUpdate(ActiveStory story)
		{
		}

		private void Complete(ActiveStory story, bool conditionMet)
		{
		}
	}
}
