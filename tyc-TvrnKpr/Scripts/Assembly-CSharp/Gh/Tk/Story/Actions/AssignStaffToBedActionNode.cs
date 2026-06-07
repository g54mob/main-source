using System.Collections.Generic;

namespace Gh.Tk.Story.Actions
{
	public class AssignStaffToBedActionNode : ActorActionNode
	{
		public int targetBedId;

		protected override void OnTriggerInternal(ActiveStory story, IEnumerable<Actor> actors)
		{
		}

		public AssignStaffToBedActionNode()
			: base(autoCompleteOnTrigger: false)
		{
		}
	}
}
