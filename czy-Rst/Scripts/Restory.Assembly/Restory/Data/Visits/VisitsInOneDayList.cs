using System;
using System.Collections.Generic;

namespace Restory.Data.Visits
{
	[Serializable]
	public class VisitsInOneDayList
	{
		public List<StoryNpcVisit> VisitsForTheDay = new List<StoryNpcVisit>();
	}
}
