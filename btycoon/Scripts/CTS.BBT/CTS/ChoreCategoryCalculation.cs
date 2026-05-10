using System.Collections.Generic;
using CTS.BBT.AI;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public abstract class ChoreCategoryCalculation : CTSBehaviour
	{
		[SerializeField]
		protected bool _checkRoomAssignations;

		public abstract bool TryGetChore(Worker worker, List<WorkerChore> fifoChores, out WorkerChore outChore);
	}
}
