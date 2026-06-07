using System.Collections.Generic;

namespace Gh.Tk.Story.Actions
{
	public class StaffQuitActionNode : ActorActionNode
	{
		public bool staffQuitsVoluntarily;

		protected override void OnTriggerInternal(ActiveStory story, IEnumerable<Actor> actors)
		{
		}

		public StaffQuitActionNode()
			: base(autoCompleteOnTrigger: false)
		{
		}
	}
}
