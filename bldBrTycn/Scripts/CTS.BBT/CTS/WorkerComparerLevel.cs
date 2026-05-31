using System.Collections.Generic;
using CTS.BBT.AI;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/AI/Workers/Worker Comparer (Level)")]
	public class WorkerComparerLevel : WorkerComparer
	{
		public class Comparer : IComparer<Worker>
		{
			public int Compare(Worker x, Worker y)
			{
				return x.Level.CurrentLevel.CompareTo(y.Level.CurrentLevel);
			}
		}

		public override IComparer<Worker> GetComparer()
		{
			return new Comparer();
		}
	}
}
