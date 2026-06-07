using System.Collections.Generic;

namespace Gh.Tk.Story.Actions
{
	public class StartFightActionNode : ActorActionNode
	{
		protected override void OnTriggerInternal(ActiveStory story, IEnumerable<Actor> actors)
		{
		}

		public StartFightActionNode()
			: base(autoCompleteOnTrigger: false)
		{
		}
	}
}
