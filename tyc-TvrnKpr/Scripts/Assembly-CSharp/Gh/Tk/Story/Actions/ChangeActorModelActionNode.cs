using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk.Story.Actions
{
	public class ChangeActorModelActionNode : ActorActionNode
	{
		[Tooltip("For patrons it is the name of the model. (e.g. halfling_female_carter)\nFor staff members it is the last part of the model it needs to match the race, tier. (e.g. 1, 2, or Skeleton1)")]
		public string targetModel;

		protected override void OnTriggerInternal(ActiveStory story, IEnumerable<Actor> actors)
		{
		}

		public ChangeActorModelActionNode()
			: base(autoCompleteOnTrigger: false)
		{
		}
	}
}
