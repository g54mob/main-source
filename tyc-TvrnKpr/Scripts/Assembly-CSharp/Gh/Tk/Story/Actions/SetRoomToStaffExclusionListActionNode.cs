using System.Collections.Generic;

namespace Gh.Tk.Story.Actions
{
	public class SetRoomToStaffExclusionListActionNode : ActorActionNode
	{
		[DropDownChoice(typeof(StoryHelper), "GetAllZones")]
		public string[] roomZones;

		protected override void OnTriggerInternal(ActiveStory story, IEnumerable<Actor> actors)
		{
		}

		public SetRoomToStaffExclusionListActionNode()
			: base(autoCompleteOnTrigger: false)
		{
		}
	}
}
