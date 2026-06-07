using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk.Story.Actions
{
	public class SetPositionActorActionNode : ActorActionNode
	{
		public Vector3 worldPosition;

		protected override void OnTriggerInternal(ActiveStory story, IEnumerable<Actor> actors)
		{
		}

		public SetPositionActorActionNode()
			: base(autoCompleteOnTrigger: false)
		{
		}
	}
}
