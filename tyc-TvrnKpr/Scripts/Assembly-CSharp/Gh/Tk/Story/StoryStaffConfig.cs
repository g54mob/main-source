using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk.Story
{
	[CreateAssetMenu(fileName = "StaffRaceFilter", menuName = "Greenheart Custom/Story/Filters/Staff Race")]
	public class StoryStaffConfig : BaseTargetFilterConfig<ActorData>
	{
		[Header("Staff Config")]
		public bool excludeStoryStaff;

		[Header("Race")]
		public bool allowDwarf;

		public bool allowElf;

		public bool allowHalfling;

		public bool allowHuman;

		public bool allowOrc;

		public Gender gender;

		public bool useMultipleMatches;

		public bool DoesStaffMatchConfig(Staff staff)
		{
			return false;
		}

		public override List<ActorData> GetAllMatches()
		{
			return null;
		}
	}
}
