using System.Collections.Generic;
using CTS.BBT.AI;

namespace CTS
{
	public class PriorityChoreSearch : DefaultChoreSearch
	{
		private class Sorter : IComparer<WorkerChore>
		{
			public int Compare(WorkerChore x, WorkerChore y)
			{
				if (x.ChorePriority > y.ChorePriority)
				{
					return -1;
				}
				if (x.ChorePriority < y.ChorePriority)
				{
					return 1;
				}
				return 0;
			}
		}

		private readonly List<WorkerChore> _prioritySortedList = new List<WorkerChore>();

		private readonly Sorter _prioritySorter = new Sorter();

		public override bool TryGetChore(Worker worker, List<WorkerChore> fifoChores, out WorkerChore outChore)
		{
			_prioritySortedList.Clear();
			_prioritySortedList.AddRange(fifoChores);
			_prioritySortedList.Sort(_prioritySorter);
			return base.TryGetChore(worker, _prioritySortedList, out outChore);
		}
	}
}
