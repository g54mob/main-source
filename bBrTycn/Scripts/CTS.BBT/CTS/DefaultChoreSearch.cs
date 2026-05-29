using System.Collections.Generic;
using CTS.BBT.AI;

namespace CTS
{
	public class DefaultChoreSearch : ChoreCategoryCalculation
	{
		public override bool TryGetChore(Worker worker, List<WorkerChore> fifoChores, out WorkerChore outChore)
		{
			foreach (WorkerChore fifoChore in fifoChores)
			{
				if (!fifoChore.IsOnCooldown() && (!_checkRoomAssignations || fifoChore.IsAvailableInRoomAssignation(worker)) && fifoChore.CanBePerformed(worker))
				{
					outChore = fifoChore;
					return true;
				}
			}
			outChore = null;
			return false;
		}
	}
}
