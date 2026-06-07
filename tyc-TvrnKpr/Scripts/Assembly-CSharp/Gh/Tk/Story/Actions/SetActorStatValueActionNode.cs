using System.Collections.Generic;

namespace Gh.Tk.Story.Actions
{
	public class SetActorStatValueActionNode : ActorActionNode
	{
		[DropDownChoice(typeof(StoryHelper), "GetAllActorStats")]
		public string targetStat;

		public float value;

		protected override void OnTriggerInternal(ActiveStory story, IEnumerable<Actor> actors)
		{
		}

		public SetActorStatValueActionNode()
			: base(autoCompleteOnTrigger: false)
		{
		}
	}
}
