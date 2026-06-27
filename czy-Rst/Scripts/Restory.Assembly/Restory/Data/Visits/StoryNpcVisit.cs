using System;

namespace Restory.Data.Visits
{
	[Serializable]
	public class StoryNpcVisit : NpcVisit
	{
		public StoryVisitType VisitType;

		public VisitTimeInterval IntendedTimeInterval;
	}
}
