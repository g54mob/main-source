using System;

namespace Restory.Data.Visits
{
	[Serializable]
	public class ImmediateStoryNpcVisit : NpcVisit
	{
		public DateTime TargetVisitTime;

		public TimeSpan AfterVisitMandatoryDelay;
	}
}
