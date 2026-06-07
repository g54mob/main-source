using System.Collections.Generic;

namespace Gh.Tk.Story.Actions
{
	public class ChangeStaffScheduleToUseUniformStaffActionNode : ActorActionNode
	{
		[DropDownChoice(typeof(StoryHelper), "GetAllRoles")]
		public string targetRole;

		protected override void OnTriggerInternal(ActiveStory story, IEnumerable<Actor> actors)
		{
		}

		public ChangeStaffScheduleToUseUniformStaffActionNode()
			: base(autoCompleteOnTrigger: false)
		{
		}
	}
}
