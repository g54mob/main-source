using System.Collections.Generic;
using CTS.BBT.AI;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/AI/Workers/Worker Comparer (Salary)")]
	public class WorkerComparerSalary : WorkerComparer
	{
		public class Comparer : IComparer<Worker>
		{
			public int Compare(Worker x, Worker y)
			{
				return x.Salary.CompareTo(y.Salary);
			}
		}

		public override IComparer<Worker> GetComparer()
		{
			return new Comparer();
		}
	}
}
