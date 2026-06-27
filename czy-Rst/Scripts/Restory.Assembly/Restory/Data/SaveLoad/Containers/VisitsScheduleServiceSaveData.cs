using System;
using Restory.Data.Visits;

namespace Restory.Data.SaveLoad.Containers
{
	[Serializable]
	public class VisitsScheduleServiceSaveData
	{
		public VisitsInOneDayList[] Schedule;
	}
}
