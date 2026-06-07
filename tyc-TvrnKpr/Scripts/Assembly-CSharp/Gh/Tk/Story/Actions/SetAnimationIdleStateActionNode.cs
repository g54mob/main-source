using System.Collections.Generic;

namespace Gh.Tk.Story.Actions
{
	public class SetAnimationIdleStateActionNode : ActorActionNode
	{
		public Actor.SubIdleStates targetState;

		protected override void OnTriggerInternal(ActiveStory story, IEnumerable<Actor> actors)
		{
		}

		public SetAnimationIdleStateActionNode()
			: base(autoCompleteOnTrigger: false)
		{
		}
	}
}
