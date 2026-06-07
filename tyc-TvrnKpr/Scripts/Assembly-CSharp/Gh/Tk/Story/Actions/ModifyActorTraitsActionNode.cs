using System.Collections.Generic;

namespace Gh.Tk.Story.Actions
{
	public class ModifyActorTraitsActionNode : ActorActionNode
	{
		[DropDownChoice(typeof(StoryHelper), "GetActorTraits")]
		public string[] traitsToAdd;

		[DropDownChoice(typeof(StoryHelper), "GetActorTraits")]
		public string[] traitsToRemove;

		public bool addToTavernLog;

		protected override void OnTriggerInternal(ActiveStory story, IEnumerable<Actor> actors)
		{
		}

		public ModifyActorTraitsActionNode()
			: base(autoCompleteOnTrigger: false)
		{
		}
	}
}
