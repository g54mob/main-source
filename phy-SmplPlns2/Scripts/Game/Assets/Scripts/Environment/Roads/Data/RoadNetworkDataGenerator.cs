using System;
using System.Collections.Generic;
using System.Linq;
using EasyRoads3Dv3;
using UnityEngine;

namespace Assets.Scripts.Environment.Roads.Data
{
	public class RoadNetworkDataGenerator : MonoBehaviour
	{
		[SerializeField]
		private Vector3 _moveRoads;

		[SerializeField]
		private GameObject[] _roadDatas;

		[ContextMenu("Generate")]
		public void GenerateWaypointData()
		{
			int num = 0;
			RoadNetworkData roadNetworkData = ScriptableObject.CreateInstance<RoadNetworkData>();
			roadNetworkData.roads = new List<RoadNetworkData.Road>();
			ERRoadNetwork eRRoadNetwork = new ERRoadNetwork();
			foreach (Transform item in eRRoadNetwork.roadNetwork.transform)
			{
				if (!item.gameObject.activeInHierarchy)
				{
					Debug.LogError("Ensure that '" + item.gameObject.name + "' object is active", item.gameObject);
					return;
				}
			}
			List<ERRoad> list = new List<ERRoad>();
			list.AddRange(eRRoadNetwork.GetRoadObjects());
			float num2 = 0f;
			Dictionary<string, float> dictionary = new Dictionary<string, float>();
			List<float> list2 = new List<float>();
			foreach (ERRoad item2 in list)
			{
				RoadNetworkData.Road road = new RoadNetworkData.Road();
				roadNetworkData.roads.Add(road);
				ERRoadType roadType = item2.GetRoadType();
				road.id = list.IndexOf(item2);
				road.segmentName = item2.GetName();
				road.waypoints = new List<Vector3>();
				road.roadTypeId = roadType.roadTypeName;
				road.speedMultiplier = 1f;
				if (item2.gameObject.TryGetComponent<RoadDataInfoScript>(out var component))
				{
					road.speedMultiplier = component.SpeedMultiplier;
				}
				float distance = item2.GetDistance();
				list2.Add(distance);
				num2 += distance;
				if (!dictionary.ContainsKey(item2.GetRoadType().roadTypeName))
				{
					dictionary[item2.GetRoadType().roadTypeName] = 0f;
				}
				dictionary[item2.GetRoadType().roadTypeName] += distance;
				Vector3? vector = null;
				ERModularRoad roadScript = item2.roadScript;
				int count = roadScript.roadShape.Count;
				List<Vector3> meshVecs = roadScript.meshVecs;
				for (int i = 0; i + count - 1 < meshVecs.Count; i += count)
				{
					Vector3 vector2 = 0.5f * (meshVecs[i] + meshVecs[i + count - 1]);
					if (vector.HasValue)
					{
						if ((vector2 - vector.Value).magnitude >= 0.05f)
						{
							road.waypoints.Add(vector2);
							vector = vector2;
						}
					}
					else
					{
						road.waypoints.Add(vector2);
						vector = vector2;
					}
					num++;
				}
				num++;
			}
			list2.Sort();
			float num3 = list2[list2.Count / 2];
			string text = $"Total Road Length: {num2 / 1000f:n1}km. Average Length: {num2 / (float)list.Count / 1000f:n2}km. Median Length: {num3 / 1000f:n2}km\n";
			foreach (KeyValuePair<string, float> item3 in dictionary)
			{
				text += $"'{item3.Key}' Road Length: {item3.Value / 1000f:n1}km\n";
			}
			Debug.Log(text);
			roadNetworkData.connections = new List<RoadNetworkData.RoadConnection>();
			ERConnection[] connections = eRRoadNetwork.GetConnections();
			int count2 = list.Count;
			ERConnection[] array = connections;
			foreach (ERConnection eRConnection in array)
			{
				bool flag = false;
				IntersectionRoadConnection[] componentsInChildren = eRConnection.gameObject.GetComponentsInChildren<IntersectionRoadConnection>();
				GameObject gameObject = null;
				if (componentsInChildren.Length == 0)
				{
					string strippedName = GetConnectionName(eRConnection.name);
					GameObject gameObject2 = _roadDatas.Where((GameObject x) => x.name.StartsWith(strippedName)).FirstOrDefault();
					if (gameObject2 != null)
					{
						GameObject obj = UnityEngine.Object.Instantiate(gameObject2);
						obj.transform.SetParent(eRConnection.gameObject.transform, worldPositionStays: false);
						obj.transform.localScale = Vector3.one;
						obj.transform.localRotation = Quaternion.identity;
						obj.transform.localPosition = Vector3.zero;
						gameObject = obj;
						componentsInChildren = eRConnection.gameObject.GetComponentsInChildren<IntersectionRoadConnection>();
					}
					else if (!eRConnection.name.StartsWith("I Connector"))
					{
						Debug.Log("Could not find data prefab for connection " + eRConnection.name + ", stripped name: " + strippedName);
					}
				}
				if (componentsInChildren.Length != 0)
				{
					flag = true;
					IntersectionRoad[] componentsInChildren2 = eRConnection.gameObject.GetComponentsInChildren<IntersectionRoad>();
					foreach (IntersectionRoad intersectionRoad in componentsInChildren2)
					{
						RoadNetworkData.Road road2 = new RoadNetworkData.Road();
						roadNetworkData.roads.Add(road2);
						intersectionRoad.RoadID = count2++;
						road2.id = intersectionRoad.RoadID;
						road2.segmentName = $"{eRConnection.gameObject.name}-{count2}";
						road2.waypoints = new List<Vector3>();
						road2.roadTypeId = intersectionRoad.roadType;
						road2.speedMultiplier = intersectionRoad.speedMultiplier;
						Vector3? vector3 = null;
						foreach (Transform item4 in intersectionRoad.transform)
						{
							road2.waypoints.Add(item4.position);
							if (vector3.HasValue && (item4.position - vector3.Value).sqrMagnitude < 0.05f)
							{
								Debug.Log($"Road waypoint {road2.waypoints.Count} on road {road2.segmentName} ({road2.roadTypeId}) is too close to previous waypoint and will not have a valid forward vector.");
							}
							vector3 = item4.position;
						}
					}
					IntersectionRoadConnection[] array2 = componentsInChildren;
					foreach (IntersectionRoadConnection intersectionRoadConnection in array2)
					{
						RoadNetworkData.RoadConnection roadConnection = new RoadNetworkData.RoadConnection();
						roadConnection.probability = intersectionRoadConnection.probability;
						if (intersectionRoadConnection.from != null)
						{
							IntersectionRoad componentInParent = intersectionRoadConnection.from.GetComponentInParent<IntersectionRoad>();
							roadConnection.entryRoadID = componentInParent.RoadID;
							roadConnection.entryWaypointIndex = intersectionRoadConnection.from.GetSiblingIndex();
							roadConnection.entryLane = intersectionRoadConnection.entryLane;
							roadConnection.direction = intersectionRoadConnection.fromDirection;
						}
						else if (intersectionRoadConnection.entryConnectionIndex >= 0)
						{
							ConnectedTo connectedTo;
							ERRoad connectedRoad = eRConnection.GetConnectedRoad(intersectionRoadConnection.entryConnectionIndex, out connectedTo);
							int num5 = list.IndexOf(connectedRoad);
							if (num5 >= 0)
							{
								roadConnection.entryRoadID = num5;
								roadConnection.entryWaypointIndex = ((connectedTo == ConnectedTo.End) ? (-1) : 0);
								roadConnection.entryLane = intersectionRoadConnection.entryLane;
								roadConnection.direction = ((connectedTo != ConnectedTo.End) ? RoadNetworkData.RoadConnectionDirection.Reverse : RoadNetworkData.RoadConnectionDirection.Forward);
							}
							else
							{
								Debug.LogError($"Could not find connected road with ID {num5}", eRConnection.gameObject);
							}
						}
						else
						{
							Debug.LogError("IntersectionRoadConnection requires 'from' waypoint or an entryConnectionIndex");
						}
						if (intersectionRoadConnection.to != null)
						{
							IntersectionRoad componentInParent2 = intersectionRoadConnection.to.GetComponentInParent<IntersectionRoad>();
							roadConnection.exitRoadID = componentInParent2.RoadID;
							roadConnection.reversed = intersectionRoadConnection.reversed;
							roadConnection.exitWaypointIndex = intersectionRoadConnection.to.GetSiblingIndex();
						}
						else if (intersectionRoadConnection.exitConnectionIndex >= 0)
						{
							ConnectedTo connectedTo2;
							ERRoad connectedRoad2 = eRConnection.GetConnectedRoad(intersectionRoadConnection.exitConnectionIndex, out connectedTo2);
							int num6 = list.IndexOf(connectedRoad2);
							if (num6 >= 0)
							{
								roadConnection.exitRoadID = num6;
								roadConnection.reversed = connectedTo2 == ConnectedTo.End;
								roadConnection.exitWaypointIndex = (roadConnection.reversed ? (-1) : 0);
							}
							else
							{
								Debug.LogError($"Could not find connected road with ID {num6}");
							}
						}
						else
						{
							Debug.LogError("IntersectionRoadConnection requires a 'to' waypoint or an exitConnectionIndex");
						}
						if (roadConnection.entryRoadID >= 0 && roadConnection.exitRoadID >= 0)
						{
							roadNetworkData.connections.Add(roadConnection);
						}
					}
				}
				if (gameObject != null)
				{
					UnityEngine.Object.DestroyImmediate(gameObject);
					gameObject = null;
				}
				if (flag)
				{
					continue;
				}
				int connectionCount = eRConnection.GetConnectionCount();
				for (int num7 = 0; num7 < connectionCount; num7++)
				{
					for (int num8 = 0; num8 < connectionCount; num8++)
					{
						if (num7 != num8)
						{
							ConnectedTo connectedTo3;
							ERRoad connectedRoad3 = eRConnection.GetConnectedRoad(num7, out connectedTo3);
							ConnectedTo connectedTo4;
							ERRoad connectedRoad4 = eRConnection.GetConnectedRoad(num8, out connectedTo4);
							int num9 = list.IndexOf(connectedRoad3);
							int num10 = list.IndexOf(connectedRoad4);
							if (num9 >= 0 && num10 >= 0)
							{
								RoadNetworkData.RoadConnection roadConnection2 = new RoadNetworkData.RoadConnection();
								roadConnection2.entryRoadID = num9;
								roadConnection2.entryWaypointIndex = ((connectedTo3 == ConnectedTo.End) ? (-1) : 0);
								roadConnection2.direction = ((connectedTo3 != ConnectedTo.End) ? RoadNetworkData.RoadConnectionDirection.Reverse : RoadNetworkData.RoadConnectionDirection.Forward);
								roadConnection2.reversed = connectedTo4 == ConnectedTo.End;
								roadConnection2.exitRoadID = num10;
								roadConnection2.exitWaypointIndex = (roadConnection2.reversed ? (-1) : 0);
								roadConnection2.probability = 1f / (float)connectionCount;
								roadNetworkData.connections.Add(roadConnection2);
							}
						}
					}
				}
			}
			throw new InvalidOperationException("Method only supported in the Unity Editor");
		}

		[ContextMenu("Move Connections")]
		public void MoveConnections()
		{
			ERConnection[] connections = new ERRoadNetwork().GetConnections();
			for (int i = 0; i < connections.Length; i++)
			{
				try
				{
					connections[i].SetPosition(connections[i].gameObject.transform.position + _moveRoads);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception, connections[i].gameObject);
				}
			}
		}

		[ContextMenu("Move Roads")]
		public void MoveRoads()
		{
			ERRoadNetwork eRRoadNetwork = new ERRoadNetwork();
			List<ERRoad> list = new List<ERRoad>();
			list.AddRange(eRRoadNetwork.GetRoadObjects());
			foreach (ERRoad item in list)
			{
				for (int i = 0; i < item.GetMarkerCount(); i++)
				{
					item.roadScript.markersExt[i].position = item.GetMarkerPosition(i) + _moveRoads;
				}
				try
				{
					item.Refresh();
				}
				catch (Exception exception)
				{
					Debug.LogException(exception, item.gameObject);
				}
			}
		}

		private static string GetConnectionName(string name)
		{
			int num = name.IndexOf("_ER");
			if (num > 0)
			{
				return name.Substring(0, num);
			}
			return name;
		}
	}
}
