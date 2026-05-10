using System.Collections.Generic;
using CTS.BBT.AI;
using CTS.Core;

namespace CTS
{
	public abstract class UI_WorkerMgr_SortingAnchorBase : CTSBehaviour
	{
		private IComparer<Worker> _cachedComparer;

		public IComparer<Worker> GetComparer()
		{
			return _cachedComparer ?? (_cachedComparer = CreateComparer());
		}

		protected abstract IComparer<Worker> CreateComparer();
	}
}
