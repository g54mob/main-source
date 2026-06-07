using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace EasyRoads3Dv3
{
	public class ERConnection
	{
		public string name;

		public ERCrossingPrefabs prefabScript;

		public GameObject gameObject;

		public ERConnectionData[] connectionData;

		public static string str = "EasyRoads3D Warning: The free version does not support API calls";

		public GameObject handleObject;

		public ERConnection(GameObject go, string g_name)
		{
			name = g_name;
			gameObject = go;
			prefabScript = go.GetComponent<ERCrossingPrefabs>();
		}

		public static ERConnection Create(GameObject go)
		{
			if (go.GetComponent<ERCrossingPrefabs>() != null)
			{
				return new ERConnection(go, go.name);
			}
			return null;
		}

		public void SetPosition(Vector3 pos)
		{
			if (gameObject != null)
			{
				gameObject.transform.position = pos;
			}
			if (!(prefabScript != null))
			{
				return;
			}
			if (prefabScript.baseScript == null && (bool)prefabScript.transform.parent.parent.gameObject.GetComponent<ERModularBase>())
			{
				prefabScript.baseScript = prefabScript.transform.parent.parent.gameObject.GetComponent<ERModularBase>();
			}
			if (prefabScript.baseScript != null)
			{
				prefabScript.baseScript.UpdateQueue();
			}
			prefabScript.ODOQCOOOCC(ignorePriority: true, null);
			if (prefabScript.isIConnector)
			{
				ERIConnector component = prefabScript.GetComponent<ERIConnector>();
				if (component != null)
				{
					component.ODDDQDQOOD(null);
				}
			}
			if (prefabScript.baseScript.synchSideObjects)
			{
				prefabScript.baseScript.UpdateSideObjectsInScene();
			}
		}

		public Vector3 GetPosition()
		{
			if (gameObject != null)
			{
				return gameObject.transform.position;
			}
			return Vector3.zero;
		}

		public string GetName()
		{
			if (gameObject != null)
			{
				return gameObject.name;
			}
			return "";
		}

		public void SetName(string name)
		{
			if (gameObject != null)
			{
				gameObject.name = name;
			}
		}

		public void SetRotation(Vector3 euler)
		{
			if (gameObject != null)
			{
				gameObject.transform.eulerAngles = euler;
			}
			if (prefabScript != null)
			{
				if (prefabScript.baseScript == null && (bool)prefabScript.transform.parent.parent.gameObject.GetComponent<ERModularBase>())
				{
					prefabScript.baseScript = prefabScript.transform.parent.parent.gameObject.GetComponent<ERModularBase>();
				}
				if (prefabScript.baseScript != null)
				{
					prefabScript.baseScript.UpdateQueue();
				}
				prefabScript.ODOQCOOOCC(ignorePriority: true, null);
				if (prefabScript.baseScript.synchSideObjects)
				{
					prefabScript.baseScript.UpdateSideObjectsInScene();
				}
			}
		}

		public void Destroy()
		{
			if (gameObject != null)
			{
				UnityEngine.Object.DestroyImmediate(gameObject);
			}
			if (prefabScript != null)
			{
				prefabScript.ODOQCOOOCC(ignorePriority: true, null);
			}
		}

		public void UnConnect(int connectionIndex)
		{
			if (prefabScript.crossingElements.Count <= connectionIndex)
			{
				return;
			}
			ERModularRoad eRModularRoad = null;
			int num = 0;
			if (prefabScript.crossingElements[connectionIndex].connectedRoad != null)
			{
				eRModularRoad = prefabScript.crossingElements[connectionIndex].connectedRoad;
				if (prefabScript.crossingElements[connectionIndex].connectedMarker == 0)
				{
					OQOCQDQODD.OOQOOOQODC(eRModularRoad.baseScript, eRModularRoad, 1, 0, 0);
				}
				else
				{
					OQOCQDQODD.ODOCDQDQCO(eRModularRoad.baseScript, eRModularRoad, eRModularRoad.markersExt.Count - 2, eRModularRoad.markersExt.Count - 1, eRModularRoad.markersExt.Count - 1);
				}
			}
		}

		public ERConnectionData[] GetConnectionData()
		{
			if (prefabScript != null)
			{
				List<ERConnectionData> list = new List<ERConnectionData>();
				int num = 0;
				foreach (QDOODOQQDQODD crossingElement in prefabScript.crossingElements)
				{
					if (crossingElement.connectedRoad != null)
					{
						if (crossingElement.connectedRoad.road == null)
						{
							crossingElement.connectedRoad.road = new ERRoad(crossingElement.connectedRoad);
						}
						list.Add(new ERConnectionData(crossingElement.connectedRoad.road, crossingElement.connectedMarker, num));
					}
					num++;
				}
				if (list.Count > 0)
				{
					return list.ToArray();
				}
				return null;
			}
			return null;
		}

		public Vector3 GetLocalConnectionPosition(int connectionIndex)
		{
			if (prefabScript.crossingElements.Count > connectionIndex)
			{
				if (prefabScript.crossingElements[connectionIndex] != null)
				{
					if (prefabScript.crossingElements[connectionIndex].tmpCenterPoint != Vector3.zero)
					{
						return prefabScript.crossingElements[connectionIndex].tmpCenterPoint;
					}
					return prefabScript.crossingElements[connectionIndex].centerPoint;
				}
				return Vector3.zero;
			}
			return Vector3.zero;
		}

		public Vector3[] GetLocalConnectionPositions()
		{
			List<Vector3> list = new List<Vector3>();
			for (int i = 0; i < prefabScript.crossingElements.Count; i++)
			{
				if (prefabScript.crossingElements[i] == null)
				{
					continue;
				}
				if (prefabScript.crossingElements[i].connectedRoad == null)
				{
					if (prefabScript.crossingElements[i].tmpCenterPoint != Vector3.zero)
					{
						list.Add(prefabScript.crossingElements[i].tmpCenterPoint);
					}
					else
					{
						list.Add(prefabScript.crossingElements[i].centerPoint);
					}
				}
				else
				{
					list.Add(Vector3.zero);
				}
			}
			return list.ToArray();
		}

		public Vector3[] GetConnectionWorldPositions()
		{
			Vector3[] localConnectionPositions = GetLocalConnectionPositions();
			for (int i = 0; i < localConnectionPositions.Length; i++)
			{
				if (localConnectionPositions[i] != Vector3.zero)
				{
					localConnectionPositions[i] = gameObject.transform.TransformPoint(localConnectionPositions[i]);
				}
				else
				{
					localConnectionPositions[i] = new Vector3(1000000f, 0f, 1000000f);
				}
			}
			return localConnectionPositions;
		}

		public Vector3 GetConnectionWorldPosition(int connectionIndex)
		{
			Vector3 vector = GetLocalConnectionPosition(connectionIndex);
			if (vector != Vector3.zero)
			{
				vector = gameObject.transform.TransformPoint(vector);
			}
			return vector;
		}

		public int FindNearestConnectionIndex(Vector3 position)
		{
			Vector3[] connectionWorldPositions = GetConnectionWorldPositions();
			float num = float.PositiveInfinity;
			int result = -1;
			for (int i = 0; i < connectionWorldPositions.Length; i++)
			{
				float num2 = Vector3.Distance(position, connectionWorldPositions[i]);
				if (num2 < num)
				{
					num = num2;
					result = i;
				}
			}
			return result;
		}

		public bool SwapTurn()
		{
			if (prefabScript.crossingsScript != null)
			{
				if (!prefabScript.isSnapConnector && prefabScript.tCrossing && !prefabScript.isFlexConnector)
				{
					if (prefabScript.crossingElements.Count > 3)
					{
						if (prefabScript.crossingElements[2].connectedRoad == null && prefabScript.crossingElements[3].connectedRoad == null)
						{
							if (prefabScript.crossingsScript.tCrossingLeftRight == 0)
							{
								prefabScript.crossingsScript.tCrossingLeftRight = 1;
							}
							else
							{
								prefabScript.crossingsScript.tCrossingLeftRight = 0;
							}
							prefabScript.crossingsScript.Refresh();
							return true;
						}
						return false;
					}
					return false;
				}
				return false;
			}
			return false;
		}

		public bool RotateConnections()
		{
			int newIndex = -1;
			int oldIndex = -1;
			int index = -1;
			int index2 = -1;
			ERModularRoad road = null;
			ERModularRoad road2 = null;
			OQQCQDQDCC.SwapConnectionInit(prefabScript.baseScript, prefabScript, ref newIndex, ref oldIndex, ref index, ref index2, ref road, ref road2);
			if (newIndex != -1)
			{
				OQQCQDQDCC.OOOQOCQCQD(prefabScript.baseScript, prefabScript, newIndex, oldIndex, index, index2, road, road2);
				prefabScript.baseScript.UpdateSideObjectsInScene();
				return true;
			}
			return false;
		}

		public ERRoad GetConnectedRoad(int index, out ConnectedTo connectedTo)
		{
			connectedTo = ConnectedTo.None;
			if (index < prefabScript.crossingElements.Count)
			{
				if (prefabScript.crossingElements[index].connectedRoad != null)
				{
					if (prefabScript.crossingElements[index].connectedRoad.startPrefabScript == prefabScript && prefabScript.crossingElements[index].connectedRoad.startConnectionSegment == index)
					{
						connectedTo = ConnectedTo.Start;
					}
					else if (prefabScript.crossingElements[index].connectedRoad.endPrefabScript == prefabScript && prefabScript.crossingElements[index].connectedRoad.endConnectionSegment == index)
					{
						connectedTo = ConnectedTo.End;
					}
					if (prefabScript.crossingElements[index].connectedRoad.road == null)
					{
						prefabScript.crossingElements[index].connectedRoad.road = new ERRoad(prefabScript.crossingElements[index].connectedRoad);
					}
					return prefabScript.crossingElements[index].connectedRoad.road;
				}
				return null;
			}
			return null;
		}

		public ERLaneConnector[] GetLaneData(int connectionIndex)
		{
			if (prefabScript.crossingsScript != null)
			{
				if (prefabScript.siblings.Count > connectionIndex)
				{
					return prefabScript.siblings[connectionIndex].laneData.connectors.ToArray();
				}
				return null;
			}
			return null;
		}

		public ERLaneConnector[] GetLaneData(int connectionIndex, int lane)
		{
			if (prefabScript.crossingsScript != null || prefabScript.isIConnector)
			{
				if (prefabScript.siblings.Count > connectionIndex)
				{
					List<ERLaneConnector> list = new List<ERLaneConnector>();
					if (prefabScript.siblings[connectionIndex].roadType != null)
					{
						int num = ((prefabScript.baseScript.rightHandDriving != 1) ? prefabScript.siblings[connectionIndex].roadType.OCDCDCODCO(lane, ERLaneDirection.Left) : prefabScript.siblings[connectionIndex].roadType.OCDCDCODCO(lane, ERLaneDirection.Right));
						if (num == -1)
						{
							Debug.Log("EasyRoads3D Warning: the passed lane index " + lane + " does not exist for road type " + prefabScript.siblings[connectionIndex].roadType.roadTypeName);
						}
						foreach (ERLaneConnector connector in prefabScript.siblings[connectionIndex].laneData.connectors)
						{
							if (connector.startLaneIndex != num)
							{
								continue;
							}
							if (prefabScript.baseScript.rightHandDriving == 0)
							{
								if (prefabScript.crossingElements[connector.endConnectionIndex].connectedRoad != null && prefabScript.crossingElements[connector.endConnectionIndex].rt != null)
								{
									ERLaneConnector eRLaneConnector = ERLaneConnector.CreateInstance();
									connector.CloneLaneConnector(eRLaneConnector);
									int num2 = 0;
									num2 = ((!prefabScript.isIConnector || !(prefabScript.crossingElements[connector.endConnectionIndex].connectedRoad != null) || prefabScript.crossingElements[connector.endConnectionIndex].connectedRoad.rt == null) ? prefabScript.crossingElements[connector.endConnectionIndex].rt.totalLanes : prefabScript.crossingElements[connector.endConnectionIndex].connectedRoad.rt.totalLanes);
									eRLaneConnector.endLaneIndexRelative = (eRLaneConnector.endLaneIndex = num2 - 1 - connector.endLaneIndex);
									list.Add(eRLaneConnector);
								}
							}
							else
							{
								list.Add(connector);
							}
						}
					}
					return list.ToArray();
				}
				return null;
			}
			if (prefabScript.isCustomPrefab)
			{
				if (prefabScript.crossingElements.Count > connectionIndex)
				{
					List<ERLaneConnector> list2 = new List<ERLaneConnector>();
					if (prefabScript.crossingElements[connectionIndex].roadType != 0.0)
					{
						if (prefabScript.crossingElements[connectionIndex].rt == null || prefabScript.crossingElements[connectionIndex].roadType != prefabScript.crossingElements[connectionIndex].rt.id)
						{
							prefabScript.crossingElements[connectionIndex].rt = QDQDOOQQDQODD.GetRoadTypeElByID(prefabScript.baseScript.roadTypes, prefabScript.crossingElements[connectionIndex].roadType);
						}
						if (prefabScript.crossingElements[connectionIndex].rt != null)
						{
							int num3 = lane;
							foreach (ERLaneConnector connector2 in prefabScript.crossingElements[connectionIndex].laneData.connectors)
							{
								if (connector2.startLaneIndex != num3)
								{
									continue;
								}
								if (connector2.points == null && connector2.localPoints != null)
								{
									connector2.points = new Vector3[connector2.localPoints.Length];
									connector2.localPoints.CopyTo(connector2.points, 0);
									for (int i = 0; i < connector2.points.Length; i++)
									{
										connector2.points[i] = prefabScript.transform.TransformPoint(connector2.points[i]);
									}
								}
								list2.Add(connector2);
							}
							if (list2.Count == 0 && prefabScript.crossingElements[connectionIndex].rt != null && prefabScript.crossingElements[connectionIndex].rt.oneWay)
							{
								for (int j = 0; j < prefabScript.crossingElements.Count; j++)
								{
									if (j == connectionIndex)
									{
										continue;
									}
									foreach (ERLaneConnector connector3 in prefabScript.crossingElements[j].laneData.connectors)
									{
										if (connector3.endConnectionIndex != connectionIndex || connector3.endLaneIndex != num3)
										{
											continue;
										}
										if (connector3.points == null && connector3.localPoints != null)
										{
											connector3.points = new Vector3[connector3.localPoints.Length];
											connector3.localPoints.CopyTo(connector3.points, 0);
											for (int k = 0; k < connector3.points.Length; k++)
											{
												connector3.points[k] = prefabScript.transform.TransformPoint(connector3.points[k]);
											}
										}
										ERLaneConnector eRLaneConnector2 = new ERLaneConnector();
										connector3.CloneLaneConnector(eRLaneConnector2);
										eRLaneConnector2.startConnectionIndex = connectionIndex;
										eRLaneConnector2.startLaneIndex = num3;
										eRLaneConnector2.endConnectionIndex = connector3.startConnectionIndex;
										eRLaneConnector2.endLaneIndex = connector3.startLaneIndex;
										eRLaneConnector2.endLaneIndexRelative = connector3.startLaneIndex;
										Array.Reverse((Array)eRLaneConnector2.points);
										list2.Add(eRLaneConnector2);
									}
								}
							}
						}
						return list2.ToArray();
					}
					return null;
				}
				return null;
			}
			return null;
		}

		public int GetConnectionCount()
		{
			return prefabScript.crossingElements.Count;
		}

		public void AverageNormals(bool flag)
		{
			prefabScript.averageNormals = flag;
		}

		public bool RecalculateNormals()
		{
			if (gameObject.GetComponent<MeshFilter>() != null)
			{
				Mesh sharedMesh = gameObject.GetComponent<MeshFilter>().sharedMesh;
				if (sharedMesh != null)
				{
					sharedMesh.RecalculateNormals();
					return true;
				}
				return false;
			}
			return false;
		}

		public bool RecalculateTangents()
		{
			if (gameObject.GetComponent<MeshFilter>() != null)
			{
				Mesh sharedMesh = gameObject.GetComponent<MeshFilter>().sharedMesh;
				if (sharedMesh != null)
				{
					sharedMesh.RecalculateTangents();
					return true;
				}
				return false;
			}
			return false;
		}

		public void Refresh()
		{
			if (prefabScript.baseScript != null)
			{
				prefabScript.baseScript.UpdateQueue();
			}
			if (prefabScript.isERCrossingExt)
			{
				ERCrossingsExt component = prefabScript.GetComponent<ERCrossingsExt>();
				if (component != null)
				{
					component.ODDDQDQOOD();
				}
			}
			else if (prefabScript.crossingsScript != null && !prefabScript.isFlexConnector)
			{
				prefabScript.crossingsScript.OQDCCQOCCQ(sidewalkSceneHandleFlag: true, rebuildRoads: true);
			}
			else if (prefabScript.roundaboutScript != null && prefabScript.isRoundabout)
			{
				prefabScript.roundaboutScript.OOODQQDOOD();
				prefabScript.roundaboutScript.OCODQOOOCQ();
				if (prefabScript.roundaboutScript.leftFlag && prefabScript.roundaboutScript.rightFlag)
				{
					prefabScript.roundaboutScript.OCOCDCDDOD();
					if (prefabScript.roundaboutScript.connections.Count > 0)
					{
						prefabScript.roundaboutScript.OCCCDCOOOC();
					}
				}
				else
				{
					prefabScript.roundaboutScript.ResetData();
				}
			}
			else if (prefabScript.isFlexConnector)
			{
				prefabScript.crossingsScript.OCOQDOOOQC(null);
			}
			if (prefabScript.baseScript != null)
			{
				prefabScript.baseScript.UpdateSideObjectsInScene();
			}
		}

		public bool IsFlexConnector()
		{
			IsFlexConnector(updateRoadTypes: false);
			return true;
		}

		public bool IsFlexConnector(bool updateRoadTypes)
		{
			if (prefabScript.isFlexConnector)
			{
				return true;
			}
			if (prefabScript.isERCrossing)
			{
				bool flag = true;
				int num = 0;
				for (int i = 0; i < prefabScript.crossingElements.Count; i++)
				{
					if (prefabScript.crossingElements[i].connectedRoad != null)
					{
						num++;
					}
					else if (i < 2)
					{
						flag = false;
					}
				}
				if (flag)
				{
					if (num < 4)
					{
						prefabScript.tCrossing = true;
					}
					prefabScript.isFlexConnector = true;
					prefabScript.InitFlexConnector(updateRoadTypes);
				}
				else
				{
					Debug.Log("EasyRoads3D warning: please first attach roads before turning this connection into a Flex Connector");
				}
			}
			return true;
		}

		public bool SetRoadType(ERRoadType roadType, int connectionIndex, bool updateRoad, bool addNewSideObjects, bool removeOldSideObjects)
		{
			if (prefabScript.isFlexConnector)
			{
				if (prefabScript.siblings.Count <= connectionIndex)
				{
					Debug.Log("EasyRoads3D Warning: Updating the road type for connection index " + connectionIndex + " falied. This connection object has " + prefabScript.siblings.Count + " connections.");
					return false;
				}
				QDDDQODDQDQDQDD.roadTypesDynamic = QDDDQODDQDQDQDD.OOCQOQDDOQ(prefabScript.baseScript.roadTypes, all: false);
				prefabScript.siblings[connectionIndex].roadTypeIndex = QDDDQODDQDQDQDD.GetDynamicRoadTypeIndex(prefabScript.siblings[connectionIndex].road.roadType);
				prefabScript.siblings[connectionIndex].OODODCODOQ(prefabScript.siblings[connectionIndex].roadTypeIndex, prefabScript.crossingsScript.roadTypesDynamic);
				QDQDOOQQDQODD roadType2 = prefabScript.siblings[connectionIndex].roadType;
				float num = prefabScript.siblings[connectionIndex].roadType.roadWidth * 0.2f;
				if (num > prefabScript.siblings[connectionIndex].radius)
				{
					prefabScript.siblings[connectionIndex].radius = num;
				}
				if (updateRoad && prefabScript.crossingElements[connectionIndex].connectedRoad != null)
				{
					prefabScript.crossingElements[connectionIndex].connectedRoad.roadType = prefabScript.siblings[connectionIndex].roadTypeID;
					prefabScript.crossingElements[connectionIndex].connectedRoad.rt = prefabScript.siblings[connectionIndex].roadType;
					int num2 = 0;
					for (int i = 0; i < prefabScript.baseScript.roadTypes.Count; i++)
					{
						if (prefabScript.baseScript.roadTypes[i] == prefabScript.siblings[connectionIndex].roadType)
						{
							num2 = i;
							break;
						}
					}
					ODDOQDDQCQ.UpdateRoadTypeByRoad(prefabScript.baseScript, prefabScript.crossingElements[connectionIndex].connectedRoad, num2 + 1, roadType2);
					prefabScript.crossingElements[connectionIndex].connectedRoad.SetMarkerShape(new List<Vector2>(prefabScript.siblings[connectionIndex].roadType.roadShape), prefabScript.transform.localScale, prefabScript, connectionIndex);
					if (removeOldSideObjects)
					{
						List<ERSORoadExt> soDataExt = prefabScript.crossingElements[connectionIndex].connectedRoad.soDataExt;
						foreach (ERSORoadExt item in soDataExt)
						{
							if (item.active)
							{
								item.active = false;
							}
						}
					}
					if (addNewSideObjects)
					{
						QDQDOOQQDQODD.AssignSideObjects(prefabScript.baseScript, num2 + 1, prefabScript.crossingElements[connectionIndex].connectedRoad);
					}
				}
				prefabScript.baseScript.UpdateQueue();
				prefabScript.crossingsScript.OCOQDOOOQC(roadType2);
				return true;
			}
			return false;
		}

		public Vector3 GetConnectionDirection(int index)
		{
			if (prefabScript.crossingElements.Count > index && index >= 0)
			{
				return prefabScript.crossingElements[index].direction;
			}
			return Vector3.zero;
		}

		public Vector3 GetConnectionCenter(int index)
		{
			if (prefabScript.crossingElements.Count > index && index >= 0)
			{
				return prefabScript.transform.TransformPoint(prefabScript.crossingElements[index].centerPoint);
			}
			return Vector3.zero;
		}

		public Vector3 GetConnectionLeftCorner(int index)
		{
			if (prefabScript.crossingElements.Count > index && index >= 0)
			{
				return prefabScript.transform.TransformPoint(prefabScript.crossingElements[index].leftCorner);
			}
			return Vector3.zero;
		}

		public Vector3 GetConnectionRightCorner(int index)
		{
			if (prefabScript.crossingElements.Count > index && index >= 0)
			{
				return prefabScript.transform.TransformPoint(prefabScript.crossingElements[index].rightCorner);
			}
			return Vector3.zero;
		}

		public bool SetRoadType(ERRoadType roadType, int connectionIndex)
		{
			if (!prefabScript.isFlexConnector)
			{
				Debug.Log("EasyRoads3D: the road type of this object cannot be changed through the scripting API");
				return false;
			}
			if (connectionIndex < 0 || connectionIndex >= prefabScript.crossingElements.Count || connectionIndex >= prefabScript.siblings.Count)
			{
				Debug.Log("EasyRoads3D: the connectionIndex " + connectionIndex + " on this intersection");
			}
			if (roadType == null)
			{
				Debug.Log("EasyRoads3D: the road type object is null");
				return false;
			}
			prefabScript.siblings[connectionIndex].roadTypeID = roadType.id;
			prefabScript.siblings[connectionIndex].roadType = QDQDOOQQDQODD.GetRoadTypeElByID(prefabScript.baseScript.roadTypes, roadType.id);
			Refresh();
			return true;
		}

		public bool SetSidewalk(ERSideWalk sidewalk, int connectionIndex, ERRoadSide side, bool active)
		{
			if (connectionIndex < 0 || connectionIndex >= prefabScript.crossingElements.Count || connectionIndex >= prefabScript.siblings.Count)
			{
				Debug.Log("EasyRoads3D: the connectionIndex " + connectionIndex + " on this intersection");
			}
			if (sidewalk == null)
			{
				Debug.Log("EasyRoads3D: the sidewalk object is null");
				return false;
			}
			if (side == ERRoadSide.Left || side == ERRoadSide.Both)
			{
				prefabScript.siblings[connectionIndex].leftSidewalkid = sidewalk.id;
				prefabScript.siblings[connectionIndex].leftSidewalk = sidewalk;
			}
			if (side == ERRoadSide.Right || side == ERRoadSide.Both)
			{
				prefabScript.siblings[connectionIndex].rightSidewalkid = sidewalk.id;
				prefabScript.siblings[connectionIndex].rightSidewalk = sidewalk;
			}
			SetSidewalk(side, connectionIndex, active);
			return true;
		}

		public bool SetSidewalk(ERRoadSide side, int connectionIndex, bool active)
		{
			if (connectionIndex < 0 || connectionIndex >= prefabScript.crossingElements.Count)
			{
				Debug.Log("EasyRoads3D: the connectionIndex " + connectionIndex + " on this intersection");
			}
			if (!active)
			{
				if (side == ERRoadSide.Left || side == ERRoadSide.Both)
				{
					prefabScript.siblings[connectionIndex].leftSidewalkActive = false;
				}
				if (side == ERRoadSide.Right || side == ERRoadSide.Both)
				{
					prefabScript.siblings[connectionIndex].rightSidewalkActive = false;
				}
			}
			else
			{
				if (side == ERRoadSide.Left || side == ERRoadSide.Both)
				{
					prefabScript.siblings[connectionIndex].leftSidewalkActive = true;
					if (prefabScript.siblings[connectionIndex].roadType != null && prefabScript.siblings[connectionIndex].roadType.crosswalksIntersections)
					{
						prefabScript.siblings[connectionIndex].leftCrosswalkActive = true;
					}
				}
				if (side == ERRoadSide.Right || side == ERRoadSide.Both)
				{
					prefabScript.siblings[connectionIndex].rightSidewalkActive = true;
					if (prefabScript.siblings[connectionIndex].roadType != null && prefabScript.siblings[connectionIndex].roadType.crosswalksIntersections)
					{
						prefabScript.siblings[connectionIndex].rightCrosswalkActive = true;
					}
				}
				Refresh();
			}
			return true;
		}

		public void SetCrosswalk(ERRoadSide side, int connectionIndex, bool active)
		{
			if (!active)
			{
				if (side == ERRoadSide.Left || side == ERRoadSide.Both)
				{
					prefabScript.siblings[connectionIndex].leftCrosswalkActive = false;
				}
				if (side == ERRoadSide.Right || side == ERRoadSide.Both)
				{
					prefabScript.siblings[connectionIndex].rightCrosswalkActive = false;
				}
			}
			else
			{
				if ((side == ERRoadSide.Left || side == ERRoadSide.Both) && prefabScript.siblings[connectionIndex].leftSidewalk != null && prefabScript.siblings[connectionIndex].leftSidewalk.crosswalkPavement)
				{
					prefabScript.siblings[connectionIndex].leftCrosswalkActive = true;
				}
				if ((side == ERRoadSide.Right || side == ERRoadSide.Both) && prefabScript.siblings[connectionIndex].rightSidewalk != null && prefabScript.siblings[connectionIndex].rightSidewalk.crosswalkPavement)
				{
					prefabScript.siblings[connectionIndex].rightCrosswalkActive = true;
				}
			}
			Refresh();
		}

		public void IConnectorTransition(ERIConnectorTransitionType type)
		{
			ERIConnector component = gameObject.GetComponent<ERIConnector>();
			if (!prefabScript.isIConnector || component == null)
			{
				Debug.Log("EasyRoads3D Warning: Unable to update the I Connector transition data. This is not an I Connector");
				return;
			}
			if (type == ERIConnectorTransitionType.BlendTextures)
			{
				component.textureType = 0;
			}
			else
			{
				component.textureType = 1;
			}
			component.blendSection = 0;
			component.ODDDQDQOOD(null);
			if (component.road1 != null)
			{
				component.road1.ODDDQDQOOD(ignorePrefabAlignment: true, forceAutoRotate: false);
			}
			if (component.road2 != null)
			{
				component.road2.ODDDQDQOOD(ignorePrefabAlignment: true, forceAutoRotate: false);
			}
		}

		public void IConnectorTransition(ERIConnectorTransitionType type, ERIConnectorTransitionSection section)
		{
			ERIConnector component = gameObject.GetComponent<ERIConnector>();
			if (!prefabScript.isIConnector || component == null)
			{
				Debug.Log("EasyRoads3D Warning: Unable to update the I Connector transition data.This is not an I Connector");
				return;
			}
			if (type == ERIConnectorTransitionType.BlendTextures)
			{
				component.textureType = 0;
			}
			else
			{
				component.textureType = 1;
			}
			switch (section)
			{
			case ERIConnectorTransitionSection.BothRoads:
				component.blendSection = 0;
				break;
			case ERIConnectorTransitionSection.Road1:
				component.blendSection = 1;
				break;
			case ERIConnectorTransitionSection.Road2:
				component.blendSection = 2;
				break;
			}
			component.ODDDQDQOOD(null);
			if (component.road1 != null)
			{
				component.road1.ODDDQDQOOD(ignorePrefabAlignment: true, forceAutoRotate: false);
			}
			if (component.road2 != null)
			{
				component.road2.ODDDQDQOOD(ignorePrefabAlignment: true, forceAutoRotate: false);
			}
		}

		public void IConnectorTransition(ERIConnectorTransitionType type, ERIConnectorTransitionSection section, float distance, Material mat)
		{
			ERIConnector component = gameObject.GetComponent<ERIConnector>();
			if (!prefabScript.isIConnector || component == null)
			{
				Debug.Log("EasyRoads3D Warning: Unable to update the I Connector transition data.This is not an I Connector");
				return;
			}
			switch (type)
			{
			case ERIConnectorTransitionType.None:
				component.textureType = 0;
				break;
			case ERIConnectorTransitionType.BlendTextures:
				component.textureType = 1;
				break;
			case ERIConnectorTransitionType.TextureTransition:
				component.textureType = 2;
				break;
			}
			switch (section)
			{
			case ERIConnectorTransitionSection.BothRoads:
				component.blendSection = 0;
				break;
			case ERIConnectorTransitionSection.Road1:
				component.blendSection = 1;
				break;
			case ERIConnectorTransitionSection.Road2:
				component.blendSection = 2;
				break;
			}
			component.blendDistance = distance;
			component.blendMaterial = mat;
			component.ODDDQDQOOD(null);
			if (component.road1 != null)
			{
				component.road1.ODDDQDQOOD(ignorePrefabAlignment: true, forceAutoRotate: false);
			}
			if (component.road2 != null)
			{
				component.road2.ODDDQDQOOD(ignorePrefabAlignment: true, forceAutoRotate: false);
			}
		}

		public void IConnectorTransitionDistance(float distance)
		{
			ERIConnector component = gameObject.GetComponent<ERIConnector>();
			if (!prefabScript.isIConnector || component == null)
			{
				Debug.Log("EasyRoads3D Warning: Unable to update the I Connector transition data.This is not an I Connector");
				return;
			}
			component.blendDistance = distance;
			component.ODDDQDQOOD(null);
			if (component.road1 != null)
			{
				component.road1.ODDDQDQOOD(ignorePrefabAlignment: true, forceAutoRotate: false);
			}
			if (component.road2 != null)
			{
				component.road2.ODDDQDQOOD(ignorePrefabAlignment: true, forceAutoRotate: false);
			}
		}

		public void IConnectorTransitionMaterial(Material mat)
		{
			ERIConnector component = gameObject.GetComponent<ERIConnector>();
			if (!prefabScript.isIConnector || component == null)
			{
				Debug.Log("EasyRoads3D Warning: Unable to update the I Connector transition data.This is not an I Connector");
				return;
			}
			component.blendMaterial = mat;
			component.ODDDQDQOOD(null);
			if (component.road1 != null)
			{
				component.road1.ODDDQDQOOD(ignorePrefabAlignment: true, forceAutoRotate: false);
			}
			if (component.road2 != null)
			{
				component.road2.ODDDQDQOOD(ignorePrefabAlignment: true, forceAutoRotate: false);
			}
		}

		public void IConnectorDistance(float distance, ERRoad road = null)
		{
			ERIConnector component = gameObject.GetComponent<ERIConnector>();
			if (!prefabScript.isIConnector || component == null)
			{
				Debug.Log("EasyRoads3D Warning: Unable to update the I Connector transition data.This is not an I Connector");
				return;
			}
			if (road != null)
			{
				if (component.road1 == road.roadScript)
				{
					component.connectorLength1 = distance;
				}
				else if (component.road2 == road.roadScript)
				{
					component.connectorLength2 = distance;
				}
			}
			else if (component.roadWidth1 <= component.roadWidth2)
			{
				component.connectorLength1 = distance;
			}
			else
			{
				component.connectorLength2 = distance;
			}
			component.ODDDQDQOOD(null);
			if (component.road1 != null)
			{
				component.road1.ODDDQDQOOD(ignorePrefabAlignment: true, forceAutoRotate: false);
			}
			if (component.road2 != null)
			{
				component.road2.ODDDQDQOOD(ignorePrefabAlignment: true, forceAutoRotate: false);
			}
		}

		public void IConnectorTransitionCurve(ERIConnectorCurveType curveType, ERRoad road = null)
		{
			ERIConnector component = gameObject.GetComponent<ERIConnector>();
			if (!prefabScript.isIConnector || component == null)
			{
				Debug.Log("EasyRoads3D Warning: Unable to update the I Connector transition data.This is not an I Connector");
				return;
			}
			ERModularRoad road2 = component.road1;
			road2 = ((road != null) ? road.roadScript : ((!(component.roadWidth1 < component.roadWidth2)) ? component.road2 : component.road1));
			component.SetCurveType(road2, curveType);
			component.ODDDQDQOOD(null);
			if (component.road1 != null)
			{
				component.road1.ODDDQDQOOD(ignorePrefabAlignment: true, forceAutoRotate: false);
			}
			if (component.road2 != null)
			{
				component.road2.ODDDQDQOOD(ignorePrefabAlignment: true, forceAutoRotate: false);
			}
		}

		public ERIConnectorCurveType GetIConnectorTransitionCurve(ERRoad road = null)
		{
			ERIConnector component = gameObject.GetComponent<ERIConnector>();
			if (!prefabScript.isIConnector || component == null)
			{
				Debug.Log("EasyRoads3D Warning: Unable to update the I Connector transition data.This is not an I Connector");
				return ERIConnectorCurveType.Lineair;
			}
			return component.GetCurveType(road);
		}

		public void IConnectorStretch(ERRoad road, float ratio, bool autoStretch = true)
		{
			ERIConnector component = gameObject.GetComponent<ERIConnector>();
			if (!prefabScript.isIConnector || component == null)
			{
				Debug.Log("EasyRoads3D Warning: Unable to update the I Connector transition data.This is not an I Connector");
				return;
			}
			if (road == null)
			{
				Debug.Log("EasyRoads3D Warning: The passed ERRoad instance is null.");
				return;
			}
			if (component.road1 == road.roadScript)
			{
				if (component.connectorLength2 != 0f)
				{
					component.road1Stretch = component.roadWidth2 * component.road2Stretch / component.roadWidth1;
				}
				else
				{
					component.road1Stretch = component.roadWidth2 * 1f / component.roadWidth1;
				}
			}
			else if (component.connectorLength1 != 0f)
			{
				component.road2Stretch = component.roadWidth1 * component.road1Stretch / component.roadWidth2;
			}
			else
			{
				component.road2Stretch = component.roadWidth1 * 1f / component.roadWidth2;
			}
			component.ODDDQDQOOD(null);
			if (component.road1 != null)
			{
				component.road1.ODDDQDQOOD(ignorePrefabAlignment: true, forceAutoRotate: false);
			}
			if (component.road2 != null)
			{
				component.road2.ODDDQDQOOD(ignorePrefabAlignment: true, forceAutoRotate: false);
			}
		}

		public void SetCornerRadius(float value, bool refresh = true)
		{
			if (prefabScript.isFlexConnector && value > 1f)
			{
				foreach (ERConnectionSibling sibling in prefabScript.siblings)
				{
					if (value < sibling.roadWidth * prefabScript.baseScript.flexConnectorRadiusMultiplier)
					{
						sibling.radius = value;
					}
				}
			}
			if (refresh)
			{
				Refresh();
			}
		}

		public void SetCornerRadius(float value, int index, bool refresh = true)
		{
			if (prefabScript.isFlexConnector && value > 1f && prefabScript.siblings.Count > index)
			{
				prefabScript.siblings[index].radius = value;
			}
			if (refresh)
			{
				Refresh();
			}
		}

		public void SetCornerSegments(int value, bool refresh = true)
		{
			if (prefabScript.isFlexConnector && value >= 4)
			{
				foreach (ERConnectionSibling sibling in prefabScript.siblings)
				{
					sibling.defaultSegments = value;
				}
			}
			if (refresh)
			{
				Refresh();
			}
		}

		public void SetCornerCurvature(float value, int index, ERRoadSide side)
		{
			if (prefabScript.isFlexConnector && prefabScript.siblings.Count > index)
			{
				value = Mathf.Clamp(value, 0.01f, 1f);
				if (side == ERRoadSide.Left || side == ERRoadSide.Both)
				{
					prefabScript.siblings[index].leftCornerAngle = value;
				}
				if (side == ERRoadSide.Right || side == ERRoadSide.Both)
				{
					prefabScript.siblings[index].rightCornerAngle = value;
				}
			}
			Refresh();
		}

		public void SetCornerCurvature(float value, ERRoadSide side)
		{
			if (prefabScript.isFlexConnector)
			{
				value = Mathf.Clamp(value, 0.01f, 1f);
				foreach (ERConnectionSibling sibling in prefabScript.siblings)
				{
					if (side == ERRoadSide.Left || side == ERRoadSide.Both)
					{
						sibling.leftCornerAngle = value;
					}
					if (side == ERRoadSide.Right || side == ERRoadSide.Both)
					{
						sibling.rightCornerAngle = value;
					}
				}
			}
			Refresh();
		}

		public void UpdateRoundabout()
		{
			gameObject.GetComponent<ERRoundabouts>().OOODQQDOOD();
			gameObject.GetComponent<ERRoundabouts>().OCODQOOOCQ();
		}

		public void ClearLaneConnectors()
		{
			for (int i = 0; i < prefabScript.siblings.Count; i++)
			{
				prefabScript.siblings[i].laneData.connectors.Clear();
			}
		}

		public void ResetLaneConnectors()
		{
			QDDDQODDQDQDQDD.OOQOOODDOC(prefabScript.crossingsScript, null);
			QDDDQODDQDQDQDD.OCQDDQCOCC(hasLaneControlData: false);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void UpdateXIntersection()
		{
		}

		public int GetLaneCount(int connectionIndex)
		{
			if (connectionIndex < 0 || connectionIndex >= prefabScript.crossingElements.Count)
			{
				Debug.Log("EasyRoads3D: this connection index does not exist for connector: " + gameObject.name);
				return -1;
			}
			QDQDOOQQDQODD qDQDOOQQDQODD = null;
			if (!prefabScript.isFlexConnector)
			{
				qDQDOOQQDQODD = QDQDOOQQDQODD.GetRoadTypeElByID(prefabScript.baseScript.roadTypes, prefabScript.crossingElements[connectionIndex].roadType);
			}
			else
			{
				qDQDOOQQDQODD = prefabScript.siblings[connectionIndex].roadTypeAI;
				if (qDQDOOQQDQODD == null)
				{
					qDQDOOQQDQODD = prefabScript.siblings[connectionIndex].roadType;
					if (qDQDOOQQDQODD == null)
					{
						QDQDOOQQDQODD.GetRoadTypeElByID(prefabScript.baseScript.roadTypes, prefabScript.siblings[connectionIndex].roadTypeID);
					}
				}
			}
			if (qDQDOOQQDQODD != null)
			{
				if (qDQDOOQQDQODD.roadShapeData.isset)
				{
					return qDQDOOQQDQODD.roadShapeData.lanes.Count;
				}
				Debug.Log("EasyRoads3D: no lane data available for road type '" + qDQDOOQQDQODD.roadTypeName + "'");
			}
			else
			{
				Debug.Log("EasyRoads3D:  Connection Index '" + connectionIndex + " of " + gameObject.name + "' does not have a road type assigned");
			}
			return 0;
		}

		public int GetRightLaneCount(int connectionIndex)
		{
			if (connectionIndex < 0 || connectionIndex >= prefabScript.crossingElements.Count)
			{
				Debug.Log("EasyRoads3D: this connection index does not exist for connector: " + gameObject.name);
				return -1;
			}
			QDQDOOQQDQODD qDQDOOQQDQODD = null;
			if (!prefabScript.isFlexConnector)
			{
				qDQDOOQQDQODD = QDQDOOQQDQODD.GetRoadTypeElByID(prefabScript.baseScript.roadTypes, prefabScript.crossingElements[connectionIndex].roadType);
			}
			else
			{
				qDQDOOQQDQODD = prefabScript.siblings[connectionIndex].roadTypeAI;
				if (qDQDOOQQDQODD == null)
				{
					qDQDOOQQDQODD = prefabScript.siblings[connectionIndex].roadType;
					if (qDQDOOQQDQODD == null)
					{
						QDQDOOQQDQODD.GetRoadTypeElByID(prefabScript.baseScript.roadTypes, prefabScript.siblings[connectionIndex].roadTypeID);
					}
				}
			}
			if (qDQDOOQQDQODD != null)
			{
				if (qDQDOOQQDQODD.roadShapeData.isset)
				{
					return qDQDOOQQDQODD.roadShapeData.rightLanes;
				}
				Debug.Log("EasyRoads3D: no lane data available for road type '" + qDQDOOQQDQODD.roadTypeName + "'");
			}
			else
			{
				Debug.Log("EasyRoads3D:  Connection Index '" + connectionIndex + " of " + gameObject.name + "' does not have a road type assigned");
			}
			return 0;
		}

		public int GetLeftLaneCount(int connectionIndex)
		{
			if (connectionIndex < 0 || connectionIndex >= prefabScript.crossingElements.Count)
			{
				Debug.Log("EasyRoads3D: this connection index does not exist for connector: " + gameObject.name);
				return -1;
			}
			QDQDOOQQDQODD qDQDOOQQDQODD = null;
			if (!prefabScript.isFlexConnector)
			{
				qDQDOOQQDQODD = QDQDOOQQDQODD.GetRoadTypeElByID(prefabScript.baseScript.roadTypes, prefabScript.crossingElements[connectionIndex].roadType);
			}
			else
			{
				qDQDOOQQDQODD = prefabScript.siblings[connectionIndex].roadTypeAI;
				if (qDQDOOQQDQODD == null)
				{
					qDQDOOQQDQODD = prefabScript.siblings[connectionIndex].roadType;
					if (qDQDOOQQDQODD == null)
					{
						QDQDOOQQDQODD.GetRoadTypeElByID(prefabScript.baseScript.roadTypes, prefabScript.siblings[connectionIndex].roadTypeID);
					}
				}
			}
			if (qDQDOOQQDQODD != null)
			{
				if (qDQDOOQQDQODD.roadShapeData.isset)
				{
					return qDQDOOQQDQODD.roadShapeData.leftLanes;
				}
				Debug.Log("EasyRoads3D: no lane data available for road type '" + qDQDOOQQDQODD.roadTypeName + "'");
			}
			else
			{
				Debug.Log("EasyRoads3D:  Connection Index '" + connectionIndex + " of " + gameObject.name + "' does not have a road type assigned");
			}
			return 0;
		}

		public ERRoadType GetRoadType(int connectionIndex)
		{
			return null;
		}
	}
}
