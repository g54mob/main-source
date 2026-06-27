using System;
using Restory.Data.Visits;
using Restory.TimeSystems;

namespace Restory.Data.SaveLoad.Containers
{
	[Serializable]
	public class CurrentDayVisitsQueueServiceSaveData
	{
		public NpcVisit CurrentVisit;

		public bool WasCurrentVisitInteracted;

		private NpcVisit LeftoverUninteractedVisit;

		public NpcVisit[] MainVisits;

		public NpcVisit[] CourierVisits;

		public ImmediateStoryNpcVisit[] ImmediateVisits;

		public DateTime NextVisitTime;

		public DateTime NextVisitTimeAfterCourierVisit;

		public TimeSpan LastTimeBetweenVisits;

		public MainDayTimes SaveTime;
	}
}
