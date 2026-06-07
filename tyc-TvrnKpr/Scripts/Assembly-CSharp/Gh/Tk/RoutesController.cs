using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class RoutesController : SingletonMonoBehaviour<RoutesController>
	{
		public GameObject routeMarkerPrefab;

		public GameObject roadTemplatePrefab;

		public GameObject dragonVisualPrefab;

		public Transform generatedRoadParent;

		public GameObject routeStopTemplate;

		public Transform generatedRouteStopParent;

		public List<RouteStop> customStops;

		public List<RouteStop> generatedStops;

		public Transform routeMarkers;

		public List<Route> routes;

		public GameObject CreateNewRoad(string roadName)
		{
			return null;
		}

		public RouteStop GetClosestRouteStop(Vector3 closestPosition)
		{
			return null;
		}

		public RouteStop GetConnectingRouteStop(Vector3 closestPosition)
		{
			return null;
		}

		public RouteStop GetOrCreateRouteStop(Vector3 closestPosition)
		{
			return null;
		}

		public IEnumerable<RouteStop> GetAllRouteStops()
		{
			return null;
		}

		public void ClearGenerated()
		{
		}

		public void AddRoute(Route route, bool includeReverse = false)
		{
		}

		public Route GetRoute(string stopA, string stopB, bool dragonRoute = false)
		{
			return null;
		}

		public Route GetRoadRoute(RouteStop stopA, RouteStop stopB)
		{
			return null;
		}

		public DragonRoute GetDragonRoute(RouteStop stopA, RouteStop stopB)
		{
			return null;
		}

		private Road GetBestSharedRoad(RouteStop stopA, RouteStop stopB)
		{
			return null;
		}

		public RouteMarker CreateRouteMarker()
		{
			return null;
		}
	}
}
