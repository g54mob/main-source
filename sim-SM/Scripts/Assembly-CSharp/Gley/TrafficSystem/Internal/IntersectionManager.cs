using System.Collections.Generic;
using Gley.UrbanSystem.Internal;

namespace Gley.TrafficSystem.Internal
{
	internal class IntersectionManager : IDestroyable
	{
		private List<GenericIntersection> _activeIntersections;

		internal IntersectionManager()
		{
		}

		public void Assign()
		{
		}

		internal void SetActiveIntersection(List<GenericIntersection> activeIntersections)
		{
		}

		internal void RemoveVehicle(int index)
		{
		}

		internal void UpdateIntersections(float realTimeSinceStartup)
		{
		}

		private void PedestrianRemoved(int pedestrianIndex)
		{
		}

		public void OnDestroy()
		{
		}
	}
}
