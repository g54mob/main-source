using UnityEngine;

namespace Gh.Tk.Story.Actions
{
	public class ReplacePropActionNode : ConnectedStoryNode
	{
		[Tooltip("If left 0, it will use the target prop from the story")]
		public int targetPropId;

		public string newTemplateUniqueKey;

		public bool playDesignAnimOnProp;

		public string soundEventOnTrigger;

		public override void OnTrigger(ActiveStory story)
		{
		}

		private Prop ReplaceProp(Prop prop, BuildableTemplate template)
		{
			return null;
		}
	}
}
