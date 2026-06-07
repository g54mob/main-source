using System;
using UnityEngine;

namespace Gh.Tk.Story.Actions
{
	public class AddDirtToTavernActionNode : ConnectedStoryNode
	{
		[Serializable]
		public enum DirtAddingModes
		{
			WholeTavern = 0,
			SameRoomAsStoryTarget = 1,
			TargetZone = 2
		}

		public DirtAddingModes targetMode;

		[DropDownChoice(typeof(StoryHelper), "GetAllZones")]
		public string targetZone;

		[Range(0f, 100f)]
		public int propsPercentageAffected;

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
