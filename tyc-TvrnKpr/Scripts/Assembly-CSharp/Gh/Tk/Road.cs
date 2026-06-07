using SplineMesh;
using UnityEngine;

namespace Gh.Tk
{
	public class Road : MonoBehaviour
	{
		public GameObject markerPrefab;

		public RouteStop stopA;

		public RouteStop stopB;

		public Spline spline;

		public bool IsAStop(RouteStop stop)
		{
			return false;
		}

		public RouteStop GetConnectingStop(RouteStop stop)
		{
			return null;
		}

		public float GetEffortToTravel()
		{
			return 0f;
		}

		public float GetRoadLength()
		{
			return 0f;
		}

		public void ApplyCurrentLocation(Transform marker, float roadProgress, bool forwardPathDirection)
		{
		}
	}
}
