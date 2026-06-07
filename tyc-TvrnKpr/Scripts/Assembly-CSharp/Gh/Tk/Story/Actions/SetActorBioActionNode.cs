using System.Collections.Generic;

namespace Gh.Tk.Story.Actions
{
	public class SetActorBioActionNode : ActorActionNode
	{
		[StoryNodeTranslateFieldContent("Character Bio", "Node")]
		public string[] Bios;

		protected override void OnTriggerInternal(ActiveStory story, IEnumerable<Actor> actors)
		{
		}

		public SetActorBioActionNode()
			: base(autoCompleteOnTrigger: false)
		{
		}
	}
}
