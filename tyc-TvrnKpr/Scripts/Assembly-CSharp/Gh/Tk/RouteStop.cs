using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class RouteStop : MonoBehaviour
	{
		public float connectionDistance;

		[SerializeField]
		private List<Road> _roads;

		private Dictionary<RouteStop, float> _straightDistance;

		public void RegisterRoad(Road road)
		{
		}

		public List<Road> GetRoads()
		{
			return null;
		}

		public float GetStraightDistance(RouteStop stop)
		{
			return 0f;
		}

		public float GetEffortToUse()
		{
			return 0f;
		}

		public void OnDrawGizmosSelected()
		{
		}

		public void ResetGenerated()
		{
		}
	}
}
