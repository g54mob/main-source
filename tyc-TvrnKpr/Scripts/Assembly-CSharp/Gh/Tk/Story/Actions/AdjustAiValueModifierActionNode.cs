using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk.Story.Actions
{
	public class AdjustAiValueModifierActionNode : ActorActionNode
	{
		[DropDownChoice(typeof(StoryHelper), "GetAllAiModifierValueComponents")]
		public string targetComponent;

		public string modifierUniqueKey;

		[Tooltip("set to true if the modifier should be removed")]
		public bool removeModifier;

		[Range(1f, 100f)]
		public int changePercent;

		public float durationInHours;

		[StoryNodeTranslateFieldContent("adjusting a percentage value display reason", "Node")]
		public string displayReason;

		protected override void OnTriggerInternal(ActiveStory story, IEnumerable<Actor> actors)
		{
		}

		public AdjustAiValueModifierActionNode()
			: base(autoCompleteOnTrigger: false)
		{
		}
	}
}
