using System;
using System.Collections.Generic;
using CTS.BBT.AI;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/AI/Workers/Worker Comparer (First Name)")]
	public class WorkerComparerName : WorkerComparer
	{
		public class Comparer : IComparer<Worker>
		{
			public int Compare(Worker x, Worker y)
			{
				return string.Compare(x.agentFirstName, y.agentFirstName, StringComparison.Ordinal);
			}
		}

		public override IComparer<Worker> GetComparer()
		{
			return new Comparer();
		}
	}
}
