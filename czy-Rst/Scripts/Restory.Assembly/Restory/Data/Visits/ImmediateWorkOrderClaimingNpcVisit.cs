using System;

namespace Restory.Data.Visits
{
	[Serializable]
	public class ImmediateWorkOrderClaimingNpcVisit : ImmediateStoryNpcVisit, IWorkOrderClaimingNpcVisit
	{
		public int WorkOrderID { get; set; }
	}
}
