using System.Collections.Generic;

namespace Gh.Tk.Story.Actions
{
	public class TeleportActorToRoomTypeActionNode : ActorActionNode
	{
		[DropDownChoice(typeof(StoryHelper), "GetAllZones")]
		public string roomType;

		protected override void OnTriggerInternal(ActiveStory story, IEnumerable<Actor> actors)
		{
		}

		public TeleportActorToRoomTypeActionNode()
			: base(autoCompleteOnTrigger: false)
		{
		}
	}
}
