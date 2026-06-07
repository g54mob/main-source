using XNode;

namespace Gh.Tk.Story.Structure
{
	public abstract class StartNode : StoryNode
	{
		public bool isEnabled;

		[Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection output;

		protected virtual bool ShouldCompleteOnTrigger()
		{
			return false;
		}

		public virtual bool CanTrigger()
		{
			return false;
		}

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
