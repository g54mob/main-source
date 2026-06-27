using System;

namespace Restory.Data.Visits
{
	[Serializable]
	public class WorkOrderClaimingNpcVisit : NpcVisit, IWorkOrderClaimingNpcVisit
	{
		public int WorkOrderID { get; set; }
	}
}
