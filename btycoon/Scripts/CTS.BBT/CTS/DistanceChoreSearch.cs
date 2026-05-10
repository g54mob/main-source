using System.Collections.Generic;
using CTS.BBT.AI;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS
{
	public class DistanceChoreSearch : ChoreCategoryCalculation
	{
		[SerializeField]
		private float _differentFloorWeight = 10f;

		private readonly List<WorkerChore> _distanceComparisonList = new List<WorkerChore>();

		public override bool TryGetChore(Worker worker, List<WorkerChore> fifoChores, out WorkerChore outChore)
		{
			_distanceComparisonList.Clear();
			WorkerChore workerChore = null;
			foreach (WorkerChore fifoChore in fifoChores)
			{
				if (!fifoChore.IsOnCooldown() && (!_checkRoomAssignations || fifoChore.IsAvailableInRoomAssignation(worker)) && fifoChore.CanBePerformed(worker))
				{
					if ((bool)fifoChore.ChoreTarget)
					{
						_distanceComparisonList.Add(fifoChore);
					}
					else if (_distanceComparisonList.Count <= 0)
					{
						outChore = fifoChore;
						return true;
					}
					if (workerChore == null)
					{
						workerChore = fifoChore;
					}
				}
			}
			Vector3 position = worker.transform.position;
			float num = float.MaxValue;
			WorkerChore workerChore2 = null;
			foreach (WorkerChore distanceComparison in _distanceComparisonList)
			{
				float sqrMagnitude = (distanceComparison.ChoreTarget.transform.position - position).MulY(_differentFloorWeight).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					num = sqrMagnitude;
					workerChore2 = distanceComparison;
				}
			}
			if (workerChore2 != null)
			{
				outChore = workerChore2;
				return true;
			}
			outChore = workerChore;
			return outChore != null;
		}
	}
}
