using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.Serialization;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class RoomRequirement : RequirementNode
	{
		[DropDownChoice(typeof(StoryHelper), "GetZoneIds")]
		public string room;

		[FormerlySerializedAs("targetStarRating")]
		[Range(-1f, 5f)]
		public int minstarRating;

		[Range(0f, 350f)]
		public int minSize;

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

		private IEnumerable<Room> GetMatchingRooms(bool ignoreSizeRequirement = false)
		{
			return null;
		}

		protected override bool IsMetInternal(ActiveStory data)
		{
			return false;
		}
	}
}
