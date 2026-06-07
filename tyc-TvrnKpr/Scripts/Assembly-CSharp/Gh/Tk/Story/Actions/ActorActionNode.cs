using System.Collections.Generic;
using XNode;

namespace Gh.Tk.Story.Actions
{
	public abstract class ActorActionNode : StoryNode
	{
		private readonly bool _autoCompleteOnTrigger;

		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection previous;

		[Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection next;

		protected ActorActionNode(bool autoCompleteOnTrigger = true)
		{
		}

		public override void OnTrigger(ActiveStory story)
		{
		}

		protected abstract void OnTriggerInternal(ActiveStory story, IEnumerable<Actor> actors);
	}
}
