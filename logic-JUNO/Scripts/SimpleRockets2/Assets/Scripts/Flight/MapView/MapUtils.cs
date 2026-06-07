using Assets.Scripts.DebugScripts;
using Assets.Scripts.Flight.MapView.Interfaces;
using Assets.Scripts.Flight.Sim;
using ModApi.Flight.Sim;
using UnityEngine;

namespace Assets.Scripts.Flight.MapView
{
	public static class MapUtils
	{
		private static GameObject _prefabSphereOfInfluence;

		public static bool AreUnstableFeaturesEnabled()
		{
			return false;
		}

		public static GameObject CreateSoiSphere(PlanetNode planet, string name, int layer, Transform parent, IMapViewCoordinateConverter coordinateConverter)
		{
			if ((object)_prefabSphereOfInfluence == null)
			{
				_prefabSphereOfInfluence = Game.Instance.ResourceLoader.LoadPrefab("MapView/SoiSphere");
			}
			GameObject sphereOfInfluence = Object.Instantiate(_prefabSphereOfInfluence);
			sphereOfInfluence.name = "Soi_" + name;
			sphereOfInfluence.transform.parent = parent;
			sphereOfInfluence.transform.localPosition = Vector3.zero;
			sphereOfInfluence.layer = layer;
			SetSoiSize();
			planet.OnSoiChanged += delegate
			{
				SetSoiSize();
			};
			return sphereOfInfluence;
			void SetSoiSize()
			{
				float num = (float)(planet.SphereOfInfluence * coordinateConverter.MapScale);
				sphereOfInfluence.transform.localScale = Vector3.one * num * 2f;
			}
		}

		public static void DrawDebugBall(IOrbitNode parentNode, IOrbitPoint point, string name, Color color)
		{
			MapViewScript mapView = FlightSceneScript.Instance.ViewManager.MapViewManager.MapView;
			Vector3d vector3d = mapView.ConvertSolarToMapView(point.Position + parentNode.SolarPosition);
			float num = (float)(mapView.MapCameraScript.Camera.transform.position - vector3d).magnitude;
			float radius = 0.008f * num;
			DebugGizmos.DrawBall(name, (Vector3)vector3d, radius, color, emissive: true, LayerMask.NameToLayer("MapView"));
		}

		public static void DrawDebugRay(string name, IOrbitNode parentNode, IOrbitPoint originPoint, Vector3d direction, double length, Color color)
		{
			DrawDebugRay(name, parentNode, originPoint.Position, direction, length, color);
		}

		public static void DrawDebugRay(string name, IOrbitNode parentNode, Vector3d origin, Vector3d direction, double length, Color color)
		{
			Vector3d vector3d = FlightSceneScript.Instance.ViewManager.MapViewManager.MapView.ConvertSolarToMapView(origin + parentNode.SolarPosition);
			DebugGizmos.DrawRay(name, (Vector3)vector3d, (Vector3)direction, (float)length, color, LayerMask.NameToLayer("MapView"));
		}

		public static IOrbitNode GetCommonAncestor(IOrbitNode nodeA, IOrbitNode nodeB)
		{
			if (nodeA.NestedDepth > nodeB.NestedDepth)
			{
				nodeA = nodeA.GetNodeAtDepth(nodeB.NestedDepth);
			}
			else if (nodeA.NestedDepth < nodeB.NestedDepth)
			{
				nodeB = nodeB.GetNodeAtDepth(nodeA.NestedDepth);
			}
			while (!SamePlanet(nodeA.Parent, nodeB.Parent))
			{
				nodeA = nodeA.Parent;
				nodeB = nodeB.Parent;
			}
			if (nodeA.Parent == null)
			{
				return nodeA;
			}
			return nodeA.Parent;
		}

		public static bool? GetNextBool(bool? current)
		{
			return (!current.HasValue) ? new bool?(true) : ((!current.Value) ? ((bool?)null) : new bool?(false));
		}

		public static bool SamePlanet(IPlanetNode planetA, IPlanetNode planetB)
		{
			return planetA?.PlanetData == planetB?.PlanetData;
		}
	}
}
