using System;
using System.Collections.Generic;
using System.Linq;

namespace Restory.Data.NPCs
{
	[Serializable]
	public class NpcVisitsOrder
	{
		public NpcVisitDayQueueParameters[] VisitsOrder;

		public NpcVisitsOrder(IEnumerable<NpcVisitDayQueueParameters> visitsOrder)
		{
			VisitsOrder = visitsOrder.ToArray();
		}
	}
}
