using System.Collections.Generic;
using Gley.UrbanSystem.Internal;

namespace Gley.TrafficSystem.Internal
{
	internal class ActiveIntersectionsManager : IDestroyable
	{
		private readonly AllIntersectionsDataHandler _allIntersectionsHandler;

		private List<GenericIntersection> _activeIntersections;

		internal ActiveIntersectionsManager(AllIntersectionsDataHandler trafficIntersectionsDataHandler)
		{
		}

		public void Assign()
		{
		}

		private void UpdateActiveIntersections(CellData[] activeCells)
		{
		}

		public void OnDestroy()
		{
		}
	}
}
