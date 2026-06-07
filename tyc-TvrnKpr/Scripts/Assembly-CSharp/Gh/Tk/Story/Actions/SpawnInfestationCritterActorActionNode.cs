using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk.Story.Actions
{
	public class SpawnInfestationCritterActorActionNode : ActorActionNode
	{
		[Range(1f, 10f)]
		public int numberOfNests;

		public bool usePreferredZone;

		[DropDownChoice(typeof(StoryHelper), "GetAllZones")]
		public string preferredRoomZone;

		protected override void OnTriggerInternal(ActiveStory story, IEnumerable<Actor> actors)
		{
		}

		public SpawnInfestationCritterActorActionNode()
			: base(autoCompleteOnTrigger: false)
		{
		}
	}
}
