using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class ZoneSizeRequirement : RequirementNode
	{
		[DropDownChoice(typeof(StoryHelper), "GetZoneIds")]
		public string room;

		[Range(0f, 350f)]
		public int minSize;

		public bool includeUnconfirmedChanges;

		public bool showPips;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private void OnRoomsChanged(ActiveStory data)
		{
		}

		public override string GetLabelKey(ActiveStory data)
		{
			return null;
		}

		public override int GetMaxPips(ActiveStory story)
		{
			return 0;
		}

		public override float GetFilledPips(ActiveStory story)
		{
			return 0f;
		}

		private float GetCurrentAmountOfTiles()
		{
			return 0f;
		}

		private IEnumerable<Room> GetMatchingRooms()
		{
			return null;
		}

		protected override bool IsMetInternal(ActiveStory data)
		{
			return false;
		}
	}
}
