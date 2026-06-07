using System.Collections.Generic;

namespace Gh.Tk.Story.Actions
{
	public class ModifyActorTransformsActionNode : ActorActionNode
	{
		public string[] transformsToEnable;

		public string[] transformsToDisable;

		protected override void OnTriggerInternal(ActiveStory story, IEnumerable<Actor> actors)
		{
		}

		public ModifyActorTransformsActionNode()
			: base(autoCompleteOnTrigger: false)
		{
		}
	}
}
