using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk.Story.Actions
{
	public class AdjustActorStatModifierActionNode : ActorActionNode
	{
		[DropDownChoice(typeof(StoryHelper), "GetAllActorStats")]
		public string targetStat;

		public string modifierUniqueKey;

		[Tooltip("set to true if the modifier should be removed")]
		public bool removeModifier;

		public float changePercentPerHour;

		public float durationInHours;

		[StoryNodeTranslateFieldContent("adjusting actor stat display reason", "Node")]
		public string displayReason;

		protected override void OnTriggerInternal(ActiveStory story, IEnumerable<Actor> actors)
		{
		}

		public AdjustActorStatModifierActionNode()
			: base(autoCompleteOnTrigger: false)
		{
		}
	}
}
