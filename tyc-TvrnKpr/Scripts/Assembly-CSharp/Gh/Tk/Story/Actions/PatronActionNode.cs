using System.Collections.Generic;

namespace Gh.Tk.Story.Actions
{
	public abstract class PatronActionNode : ActorActionNode
	{
		protected override void OnTriggerInternal(ActiveStory story, IEnumerable<Actor> actors)
		{
		}

		protected virtual void OnTriggerInternal(ActiveStory story, Patron[] patrons)
		{
		}

		protected PatronActionNode()
			: base(autoCompleteOnTrigger: false)
		{
		}
	}
}
