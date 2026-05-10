using System.Collections.Generic;
using CTS.BBT.AI;
using UnityEngine;

namespace CTS
{
	public class UI_WorkerMgr_SortingAnchor : UI_WorkerMgr_SortingAnchorBase
	{
		[SerializeField]
		protected WorkerComparer _comparer;

		protected override IComparer<Worker> CreateComparer()
		{
			return _comparer.GetComparer();
		}
	}
}
