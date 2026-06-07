using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Environment.Roads.Data;
using UnityEngine;

namespace Assets.Scripts.Environment.Roads
{
	public class RoadNetworkWaypoints : MonoBehaviour
	{
		public class RoadConnection
		{
			public RoadNetworkData.RoadConnectionDirection Direction { get; private set; }

			public int EntryLane { get; }

			public float Probability { get; private set; }

			public bool Reversed { get; private set; }

			public RoadWaypoint Waypoint { get; private set; }

			public RoadConnection(RoadWaypoint waypoint, bool reversed, RoadNetworkData.RoadConnectionDirection direction, float probability, int entryLane)
			{
				Waypoint = waypoint;
				Reversed = reversed;
				Direction = direction;
				Probability = probability;
				EntryLane = entryLane;
			}
		}

		public class RoadSegment
		{
			public int Id { get; set; }

			public string Name { get; set; }

			public RoadTypeData.RoadType RoadType { get; set; }

			public float Speed => SpeedMultiplier * RoadType.speedInMph * 0.44704f;

			public float SpeedMultiplier { get; set; } = 1f;

			public List<RoadWaypoint> Waypoints { get; private set; } = new List<RoadWaypoint>();
		}

		public class RoadWaypoint
		{
			public Vector3 Forward { get; set; }

			public int Id { get; set; }

			public RoadWaypoint Next { get; set; }

			public Vector3 Position { get; set; }

			public RoadWaypoint Previous { get; set; }

			public Vector3 Right { get; set; }

			public List<RoadConnection> RoadConnections { get; private set; } = new List<RoadConnection>();

			public RoadSegment Segment { get; set; }

			public Vector3 GetLanePosition(bool reversed, int lane = 0)
			{
				Vector3 vector = (reversed ? (-Right) : Right);
				float num = Segment.RoadType.lane0;
				if (lane == 1 && Segment.RoadType.lane1 > 0f)
				{
					num = Segment.RoadType.lane1;
				}
				return Position + vector * num;
			}
		}

		[SerializeField]
		private RoadNetworkData _data;

		[SerializeField]
		private string _dirtRoadMaterialName = "BrakeLights";

		private KDTree _kdTree;

		private List<RoadSegment> _roads = new List<RoadSegment>();

		[SerializeField]
		private RoadTypeData _roadTypes;

		private List<RoadWaypoint> _waypoints = new List<RoadWaypoint>();

		public void GenerateWaypoints()
		{
			int num = 0;
			List<string> list = new List<string>();
			foreach (RoadNetworkData.Road road in _data.roads)
			{
				RoadSegment roadSegment = new RoadSegment();
				_roads.Add(roadSegment);
				roadSegment.RoadType = _roadTypes.GetRoadType(road.roadTypeId);
				if (roadSegment.RoadType == null && !list.Contains(road.roadTypeId))
				{
					list.Add(road.roadTypeId);
				}
				roadSegment.Id = road.id;
				roadSegment.Name = road.segmentName;
				roadSegment.SpeedMultiplier = road.speedMultiplier;
				RoadWaypoint roadWaypoint = null;
				foreach (Vector3 waypoint2 in road.waypoints)
				{
					RoadWaypoint roadWaypoint2 = new RoadWaypoint
					{
						Id = num++,
						Position = waypoint2,
						Previous = roadWaypoint,
						Segment = roadSegment
					};
					_waypoints.Add(roadWaypoint2);
					roadSegment.Waypoints.Add(roadWaypoint2);
					if (roadWaypoint != null)
					{
						roadWaypoint.Next = roadWaypoint2;
						roadWaypoint2.Forward = (roadWaypoint2.Position - roadWaypoint.Position).normalized;
						roadWaypoint2.Right = Vector3.Cross(Vector3.up, roadWaypoint2.Forward);
						roadWaypoint.Forward = (roadWaypoint.Forward + roadWaypoint2.Forward) * 0.5f;
						roadWaypoint.Right = Vector3.Cross(Vector3.up, roadWaypoint.Forward);
					}
					roadWaypoint = roadWaypoint2;
				}
				if (roadSegment.Waypoints.Count >= 2)
				{
					RoadWaypoint roadWaypoint3 = roadSegment.Waypoints[0];
					RoadWaypoint roadWaypoint4 = roadSegment.Waypoints[1];
					roadWaypoint3.Forward = (roadWaypoint4.Position - roadWaypoint3.Position).normalized;
					roadWaypoint3.Right = Vector3.Cross(Vector3.up, roadWaypoint3.Forward);
				}
			}
			foreach (RoadNetworkData.RoadConnection roadConnectionData in _data.connections)
			{
				RoadSegment roadSegment2 = _roads.FirstOrDefault((RoadSegment x) => x.Id == roadConnectionData.entryRoadID);
				RoadSegment roadSegment3 = _roads.FirstOrDefault((RoadSegment x) => x.Id == roadConnectionData.exitRoadID);
				if (roadSegment2 != null && roadSegment3 != null)
				{
					RoadWaypoint obj = ((roadConnectionData.entryWaypointIndex >= 0) ? roadSegment2.Waypoints[roadConnectionData.entryWaypointIndex] : roadSegment2.Waypoints.Last());
					RoadWaypoint waypoint = ((roadConnectionData.exitWaypointIndex >= 0) ? roadSegment3.Waypoints[roadConnectionData.exitWaypointIndex] : roadSegment3.Waypoints.Last());
					obj.RoadConnections.Add(new RoadConnection(waypoint, roadConnectionData.reversed, roadConnectionData.direction, roadConnectionData.probability, roadConnectionData.entryLane));
				}
				else if (roadSegment2 == null)
				{
					Debug.LogError($"Could not find entry road with ID: {roadConnectionData.entryRoadID}");
				}
				else if (roadSegment3 == null)
				{
					Debug.LogError($"Could not find exit road with ID: {roadConnectionData.exitRoadID}");
				}
			}
			SubdivideWaypoints();
			if (list.Count > 0)
			{
				Debug.LogError("Missing road types: " + string.Join("\n", list), base.gameObject);
			}
		}

		public RoadWaypoint GetClosestSpawnableWaypoint(Vector3 worldPosition)
		{
			worldPosition -= base.transform.position;
			return _kdTree.FindNearest(new Vector2(worldPosition.x, worldPosition.z));
		}

		public RoadWaypoint GetWaypointById(int id)
		{
			return _waypoints.Where((RoadWaypoint x) => x.Id == id).FirstOrDefault();
		}

		public Vector3 WaypointToWorldPosition(Vector3 waypointPosition)
		{
			return base.transform.position + waypointPosition;
		}

		protected virtual void Start()
		{
			GenerateWaypoints();
		}

		private static void ChangeToRoadLayer(GameObject gameObject)
		{
			if (!(gameObject.GetComponent<StoplightSystemScript>() == null))
			{
				return;
			}
			gameObject.layer = 12;
			foreach (Transform item in gameObject.transform)
			{
				ChangeToRoadLayer(item.gameObject);
			}
		}

		[ContextMenu("Finalize Road Network")]
		private void FinalizeRoadNetwork()
		{
			RemoveDirtRoads();
			RemoveIIntersections();
			FixGuardrailColliders();
			ChangeToRoadLayer(base.gameObject);
		}

		private void FixGuardrailColliders()
		{
			PhysicsMaterial material = Resources.Load<PhysicsMaterial>("Physics/GuardRail");
			foreach (Transform item in base.transform.Find("Road Objects").transform)
			{
				foreach (Transform item2 in item)
				{
					if (item2.name == "Guard Rail")
					{
						BoxCollider[] componentsInChildren = item2.GetComponentsInChildren<BoxCollider>(includeInactive: true);
						for (int i = 0; i < componentsInChildren.Length; i++)
						{
							componentsInChildren[i].material = material;
						}
					}
				}
			}
		}

		private void RemoveIIntersections()
		{
			Transform transform = base.transform.Find("Connection Objects").transform;
			for (int num = transform.childCount - 1; num >= 0; num--)
			{
				Transform child = transform.GetChild(num);
				if (child.name.StartsWith("I Connector"))
				{
					Object.DestroyImmediate(child.gameObject);
				}
			}
		}

		private void RemoveDirtRoads()
		{
			MeshRenderer[] componentsInChildren = GetComponentsInChildren<MeshRenderer>();
			foreach (MeshRenderer meshRenderer in componentsInChildren)
			{
				if (meshRenderer != null && meshRenderer.gameObject != null && meshRenderer.sharedMaterial != null && meshRenderer.sharedMaterial.name == _dirtRoadMaterialName)
				{
					Debug.Log("Removing dirt road: " + meshRenderer.gameObject.name);
					Object.DestroyImmediate(meshRenderer.gameObject);
				}
			}
		}

		private void SubdivideWaypoints()
		{
			List<RoadWaypoint> list = new List<RoadWaypoint>();
			foreach (RoadWaypoint waypoint in _waypoints)
			{
				if (waypoint.Segment.RoadType.minDistanceBetweenCars > 0f)
				{
					list.Add(waypoint);
				}
			}
			_kdTree = new KDTree(list);
		}
	}
}
