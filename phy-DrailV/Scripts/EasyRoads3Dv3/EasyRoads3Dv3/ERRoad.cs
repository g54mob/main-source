using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	public class ERRoad
	{
		public ERModularRoad roadScript;

		public GameObject gameObject;

		public string str = "EasyRoads3Dv3v3 Warning: The free version does not support API calls";

		public ERRoad()
		{
		}

		public ERRoad(ERModularRoad scr)
		{
			roadScript = scr;
			gameObject = scr.gameObject;
		}

		public void AddInititialMarkers(Vector3 pos)
		{
			roadScript.markersExt.Add(ERMarkerExt.CreateInstance(pos, roadScript, 0));
		}

		public void AddMarker(Vector3 pos)
		{
			if (roadScript.endPrefabScript == null)
			{
				if (roadScript.snapToTerrain)
				{
					roadScript.baseScript.OCCDCQCOQC(ref pos);
				}
				roadScript.markersExt.Add(ERMarkerExt.CreateInstance(pos, roadScript, roadScript.markersExt.Count));
			}
			Refresh();
		}

		public void FlipTexture()
		{
			Material[] sharedMaterials = roadScript.gameObject.GetComponent<MeshRenderer>().sharedMaterials;
			int num = 0;
			for (int i = 0; i < sharedMaterials.Length; i++)
			{
				if (sharedMaterials[i] == roadScript.roadMaterial)
				{
					num = i;
					break;
				}
			}
			for (int i = 0; i < roadScript.roadShapeUVs.Count; i++)
			{
				if (roadScript.roadShapeMaterialInts[i] == num)
				{
					roadScript.roadShapeUVs[i] = 1f - roadScript.roadShapeUVs[i];
					if (roadScript.roadShapeUVs2.Count > i)
					{
						roadScript.roadShapeUVs2[i] = 1f - roadScript.roadShapeUVs2[i];
					}
				}
			}
			Refresh();
		}

		public void AddMarkers(Vector3[] pos)
		{
			if (roadScript.endPrefabScript == null)
			{
				for (int i = 0; i < pos.Length; i++)
				{
					roadScript.markersExt.Add(ERMarkerExt.CreateInstance(pos[i], roadScript, roadScript.markersExt.Count));
				}
			}
			Refresh();
		}

		public void InsertMarker(Vector3 pos)
		{
			roadScript.OOQQDOOODC(pos);
			Refresh();
		}

		public void InsertMarkerAt(Vector3 pos, int index)
		{
			if (roadScript.markersExt.Count >= index + 1 && index >= 0)
			{
				roadScript.markersExt.Insert(index, ERMarkerExt.CreateInstance(pos, roadScript, index));
				Refresh();
			}
		}

		public void DeleteMarker(int i)
		{
			if (roadScript.markersExt.Count > i && i >= 0)
			{
				roadScript.markersExt.RemoveAt(i);
				Refresh();
			}
		}

		public void SetLayer(int layer)
		{
			roadScript.gameObject.layer = (roadScript.layer = layer);
		}

		public void SetTag(string tag)
		{
			roadScript.gameObject.tag = (roadScript.tag = tag);
		}

		public void SetWidth(float width)
		{
			roadScript.roadWidth = width;
			roadScript.roadShape.Clear();
			Refresh();
		}

		public float GetWidth()
		{
			if (roadScript != null)
			{
				return roadScript.roadWidth;
			}
			return 0f;
		}

		public float GetLength()
		{
			return roadScript.totalDistance;
		}

		public ERRoadType GetRoadType(ERRoadType[] roadTypes)
		{
			ERRoadType[] roadTypes2 = roadScript.baseScript.GetRoadTypes();
			return roadScript.GetRoadType(roadTypes2);
		}

		public ERRoadType GetRoadType()
		{
			ERRoadType[] roadTypes = roadScript.baseScript.GetRoadTypes();
			return roadScript.GetRoadType(roadTypes);
		}

		public bool SetRoadType(ERRoadType roadType)
		{
			if (roadType == null)
			{
				Debug.LogError("EasyRoads3Dv3: the passed road type is null");
				return false;
			}
			ERRoadType[] roadTypes = roadScript.baseScript.GetRoadTypes();
			QDQDOOQQDQODD roadType2 = ERRoadType.GetRoadType(roadType, roadScript.baseScript);
			if (roadType2 != null)
			{
				OCQQDQQCQQ.UpdateRoadTypeByRoad(roadScript.baseScript, roadScript, -1, roadType2);
				return true;
			}
			return false;
		}

		public bool SetMarkerControlType(int marker, ERMarkerControlType type)
		{
			if (type == ERMarkerControlType.Circular && roadScript.markersExt.Count <= 2)
			{
				Debug.Log("The circular controller type cannot be used on a two marker road");
				return false;
			}
			if (roadScript.markersExt.Count > marker && marker >= 0)
			{
				roadScript.markersExt[marker].SetControlType(type);
				Refresh();
				return true;
			}
			return false;
		}

		public bool SetSplineStrength(int marker, float strength)
		{
			if (roadScript.markersExt.Count > marker && marker >= 0)
			{
				if (strength < 0.01f)
				{
					strength = 0.01f;
				}
				if (strength > 1f)
				{
					strength = 1f;
				}
				roadScript.markersExt[marker].splineStrength = strength;
				Refresh();
				return true;
			}
			return false;
		}

		public void IsSideObject(bool isSideObject)
		{
			roadScript.isSideObject = isSideObject;
		}

		public ERRoad InsertIConnector(int index)
		{
			ERCrossingPrefabs pScript = null;
			return InsertIConnectorCore(index, ref pScript);
		}

		public ERRoad InsertIConnector(int index, string connectionName)
		{
			ERCrossingPrefabs pScript = null;
			ERRoad result = InsertIConnectorCore(index, ref pScript);
			pScript.gameObject.name = connectionName;
			return result;
		}

		public ERRoad InsertIConnector(int index, string connectionName, out ERConnection connection)
		{
			ERCrossingPrefabs pScript = null;
			ERRoad result = InsertIConnectorCore(index, ref pScript);
			pScript.gameObject.name = connectionName;
			connection = new ERConnection(pScript.gameObject, pScript.gameObject.name);
			return result;
		}

		private ERRoad InsertIConnectorCore(int index, ref ERCrossingPrefabs pScript)
		{
			ERModularRoad eRModularRoad = roadScript;
			if (index < 0 || index >= eRModularRoad.markersExt.Count)
			{
				Debug.LogWarning("EasyRoads3Dv3: road " + eRModularRoad.name + " no marker exists at index: " + index);
				return null;
			}
			int num = 0;
			ERModularRoad eRModularRoad2 = null;
			if (index != 0 && index != eRModularRoad.markersExt.Count - 1)
			{
				eRModularRoad2 = ODQCQOODDO.ODCQCQODDD(eRModularRoad, index);
			}
			pScript = eRModularRoad.baseScript.AttachConnector(eRModularRoad, index);
			ERRoad result = null;
			if (eRModularRoad2 != null)
			{
				eRModularRoad2.nodeWithinRange = 0;
				ODQCQOODDO.OCOQODCDCQ(eRModularRoad2, pScript.transform.position, pScript, 1, reverse: true, uvReverse: true, forceAutoRotate: false);
				result = new ERRoad(eRModularRoad2);
			}
			Refresh();
			return result;
		}

		public ERModularRoad ODCQCQODDD()
		{
			return null;
		}

		public void SetSideObjects(List<ERSORoadExt> soDataExt)
		{
			roadScript.soDataExt.Clear();
			roadScript.soDataExt = new List<ERSORoadExt>();
			for (int i = 0; i < soDataExt.Count; i++)
			{
				roadScript.soDataExt.Add(ERSORoadExt.CreateInstance(soDataExt[i].sideObject));
				if (soDataExt[i].active)
				{
					roadScript.soDataExt[roadScript.soDataExt.Count - 1].active = true;
				}
			}
		}

		public void SetSplatmap(bool active)
		{
			roadScript.splatMapActive = active;
		}

		public void SetSplatmap(bool active, int splatIndex, int expand, int smoothLevel, float opacity)
		{
			roadScript.splatMapActive = active;
			roadScript.splatIndex = splatIndex;
			roadScript.expandLevel = expand;
			roadScript.smoothLevel = smoothLevel;
			roadScript.splatOpacity = opacity;
		}

		public void SetMaterial(Material mat)
		{
			roadScript.roadMaterial = mat;
			if (roadScript.roadMaterials == null)
			{
				roadScript.roadMaterials = new Material[1];
			}
			roadScript.roadMaterials[0] = (roadScript.roadMaterial = mat);
			roadScript.gameObject.GetComponent<MeshRenderer>().sharedMaterials = roadScript.roadMaterials;
			Refresh();
		}

		public void SetMarkerPosition(int marker, Vector3 vec)
		{
			if (roadScript.markersExt.Count > marker && marker >= 0)
			{
				roadScript.markersExt[marker].position = vec;
				Refresh();
			}
		}

		public void SetResolution(float res)
		{
			roadScript.faceDistance = res;
			Refresh();
		}

		public void IsStatic(bool value)
		{
			roadScript.gameObject.isStatic = value;
		}

		public bool IsStatic()
		{
			return roadScript.gameObject.isStatic;
		}

		public float GetResolution()
		{
			return roadScript.faceDistance;
		}

		public void SetAngleThreshold(float res)
		{
			roadScript.angleTreshold = res;
			Refresh();
		}

		public float GetAngleTreshold(float res)
		{
			return roadScript.angleTreshold;
		}

		public bool ClosedTrack(bool value)
		{
			if (roadScript.startPrefabScript == null && roadScript.endPrefabScript == null)
			{
				roadScript.closedTrack = value;
				Refresh();
				return true;
			}
			return false;
		}

		public void SetMarkerPositions(Vector3[] vecs)
		{
			if (vecs.Length != roadScript.markersExt.Count)
			{
				return;
			}
			int num = 0;
			foreach (ERMarkerExt item in roadScript.markersExt)
			{
				item.position = vecs[num];
				num++;
			}
			Refresh();
		}

		public void SetMarkerPositions(Vector3[] vecs, int index)
		{
			if (index + vecs.Length < roadScript.markersExt.Count && index >= 0)
			{
				for (int i = index; i < index + vecs.Length; i++)
				{
					roadScript.markersExt[i].position = vecs[i - index];
				}
				Refresh();
			}
		}

		public Vector3 GetMarkerPosition(int marker)
		{
			if (roadScript.markersExt.Count > marker && marker >= 0)
			{
				return roadScript.markersExt[marker].position;
			}
			return Vector3.zero;
		}

		public Vector3[] GetMarkerPositions()
		{
			List<Vector3> list = new List<Vector3>();
			foreach (ERMarkerExt item in roadScript.markersExt)
			{
				list.Add(item.position);
			}
			return list.ToArray();
		}

		public void SetMarkerTilting(float value, int index)
		{
			if (roadScript.markersExt.Count > index && index >= 0)
			{
				roadScript.markersExt[index].rotation = value;
				Refresh();
			}
		}

		public float GetMarkerTilting(int index)
		{
			if (roadScript.markersExt.Count > index && index >= 0)
			{
				return roadScript.markersExt[index].rotation;
			}
			return 0f;
		}

		public void SetMarkerTiltingCenter(float value, int index)
		{
			if (roadScript.markersExt.Count > index && index >= 0)
			{
				if (value > 1f)
				{
					value = 1f;
				}
				else if (value < 0f)
				{
					value = 0f;
				}
				roadScript.markersExt[index].rotationCenter = value;
				Refresh();
			}
		}

		public float GetMarkerTiltingCenter(int index)
		{
			if (roadScript.markersExt.Count > index && index >= 0)
			{
				return roadScript.markersExt[index].rotationCenter;
			}
			return 0f;
		}

		public Color GetVertexColor(int index)
		{
			if (roadScript.markersExt.Count > index && index >= 0)
			{
				return roadScript.markersExt[index].customColor;
			}
			return Color.red;
		}

		public void SetVertexColor(int index, Color color)
		{
			if (roadScript.markersExt.Count > index && index >= 0)
			{
				roadScript.markersExt[index].customColor = color;
				Refresh();
			}
		}

		public void SetDistances()
		{
			float num = 0f;
			roadScript.distances.Add(0f);
			for (int i = 1; i < roadScript.soSplinePoints.Count; i++)
			{
				num += Vector3.Distance(roadScript.soSplinePoints[i - 1], roadScript.soSplinePoints[i]);
				roadScript.distances.Add(num);
			}
		}

		public Vector3 GetPosition(float distance, ref int currentElement)
		{
			if (roadScript.distances.Count == 0)
			{
				SetDistances();
			}
			float num = roadScript.distances[currentElement];
			if (distance < 0f)
			{
				return roadScript.soSplinePoints[0];
			}
			if (num <= distance)
			{
				for (int i = currentElement; i < roadScript.distances.Count; i++)
				{
					if (roadScript.distances[i] > distance)
					{
						currentElement = i - 1;
						break;
					}
				}
			}
			else
			{
				for (int i = currentElement; i < roadScript.distances.Count; i--)
				{
					if (roadScript.distances[i] < distance)
					{
						currentElement = i;
						break;
					}
				}
			}
			if (distance >= roadScript.distances[roadScript.distances.Count - 1])
			{
				currentElement = roadScript.distances.Count - 1;
			}
			Vector3 vector = roadScript.soSplinePoints[0];
			if (currentElement < roadScript.distances.Count - 1)
			{
				float num2 = distance - roadScript.distances[currentElement];
				float num3 = roadScript.distances[currentElement + 1] - roadScript.distances[currentElement];
				vector = Vector3.Lerp(roadScript.soSplinePoints[currentElement], roadScript.soSplinePoints[currentElement + 1], num2 / num3);
			}
			else
			{
				vector = roadScript.soSplinePoints[roadScript.soSplinePoints.Count - 1];
			}
			return vector;
		}

		public Vector3 GetLookatAtDistanceSmooth(float distance, ref int currentElement)
		{
			if (roadScript.distances.Count == 0)
			{
				SetDistances();
			}
			float num = roadScript.distances[currentElement];
			if (distance < 0f)
			{
				return roadScript.soSplinePoints[0];
			}
			if (num <= distance)
			{
				for (int i = currentElement; i < roadScript.distances.Count; i++)
				{
					if (roadScript.distances[i] > distance)
					{
						currentElement = i - 1;
						break;
					}
				}
			}
			else
			{
				for (int i = currentElement; i < roadScript.distances.Count; i--)
				{
					if (roadScript.distances[i] < distance)
					{
						currentElement = i;
						break;
					}
				}
			}
			if (distance >= roadScript.distances[roadScript.distances.Count - 1])
			{
				currentElement = roadScript.distances.Count - 1;
			}
			Vector3 vector = roadScript.soSplinePoints[0];
			Vector3 result;
			if (currentElement < roadScript.distances.Count - 1)
			{
				float num2 = distance - roadScript.distances[currentElement];
				float num3 = roadScript.distances[currentElement + 1] - roadScript.distances[currentElement];
				float num4 = num2 / num3;
				Vector3 normalized = (roadScript.soSplinePoints[currentElement + 1] - roadScript.soSplinePoints[currentElement]).normalized;
				if ((double)num4 > 0.5)
				{
					if (currentElement + 1 < roadScript.distances.Count - 1)
					{
						Vector3 normalized2 = (roadScript.soSplinePoints[currentElement + 2] - roadScript.soSplinePoints[currentElement + 1]).normalized;
						num4 -= 0.5f;
						result = Vector3.Lerp(normalized, normalized2, num4);
					}
					else
					{
						result = normalized;
					}
				}
				else if (currentElement > 0)
				{
					Vector3 normalized2 = (roadScript.soSplinePoints[currentElement] - roadScript.soSplinePoints[currentElement - 1]).normalized;
					num4 += 0.5f;
					result = Vector3.Lerp(normalized2, normalized, num4);
				}
				else
				{
					result = normalized;
				}
			}
			else
			{
				result = (roadScript.soSplinePoints[roadScript.soSplinePoints.Count - 2] - roadScript.soSplinePoints[roadScript.soSplinePoints.Count - 1]).normalized;
			}
			return result;
		}

		public int GetMarkerByPoint(int el)
		{
			Debug.Log(roadScript.markersExt.Count + " el " + roadScript.markersExt[1].startSplinePoint);
			for (int i = 1; i < roadScript.markersExt.Count - 1; i++)
			{
				if (roadScript.markersExt[i].startSplinePoint <= el && roadScript.markersExt[i + 1].startSplinePoint > el)
				{
					return i;
				}
			}
			return roadScript.markersExt.Count - 1;
		}

		public Vector3[] GetSplinePointsCenter()
		{
			return roadScript.soSplinePoints.ToArray();
		}

		public Vector3[] GetSplinePointsRightSide()
		{
			return roadScript.soSplinePointsRight.ToArray();
		}

		public Vector3[] GetSplinePointsRightSideExt()
		{
			return roadScript.soSplinePointsRight.ToArray();
		}

		public Vector3[] GetSplinePointsLeftSide()
		{
			return roadScript.soSplinePointsLeft.ToArray();
		}

		public void SetMeshCollider(bool flag)
		{
			roadScript.hasMeshCollider = flag;
			if (flag)
			{
				if (roadScript.gameObject.GetComponent<MeshCollider>() == null)
				{
					roadScript.gameObject.AddComponent<MeshCollider>();
				}
			}
			else if ((bool)roadScript.gameObject.GetComponent<MeshCollider>())
			{
				Object.Destroy(roadScript.gameObject.GetComponent<MeshCollider>());
			}
		}

		public void Refresh()
		{
			roadScript.OCCCCCCDCC(ignorePrefabAlignment: false, forceAutoRotate: false);
			if (roadScript.baseScript == null)
			{
				if ((bool)roadScript.transform.parent.parent.gameObject.GetComponent<ERModularBase>())
				{
					roadScript.baseScript = roadScript.transform.parent.parent.gameObject.GetComponent<ERModularBase>();
				}
				else if (roadScript.baseScript == null)
				{
					roadScript.baseScript = roadScript.transform.parent.parent.parent.gameObject.GetComponent<ERModularBase>();
				}
			}
			roadScript.baseScript.UpdateSideObjectsInScene();
		}

		public ERConnection GetConnectionAtStart()
		{
			if (roadScript.startPrefabScript != null)
			{
				if (roadScript.startPrefabScript.connObject == null)
				{
					roadScript.startPrefabScript.connObject = ERConnection.Create(roadScript.startPrefabScript.gameObject);
				}
				return roadScript.startPrefabScript.connObject;
			}
			return null;
		}

		public GameObject GetConnectionObjectAtStart()
		{
			if (roadScript.startPrefabScript != null)
			{
				return roadScript.startPrefabScript.gameObject;
			}
			return null;
		}

		public ERConnection GetConnectionAtStart(out int connection)
		{
			if (roadScript.startPrefabScript != null)
			{
				connection = roadScript.startConnectionSegment;
				if (roadScript.startPrefabScript.connObject == null)
				{
					roadScript.startPrefabScript.connObject = ERConnection.Create(roadScript.startPrefabScript.gameObject);
				}
				return roadScript.startPrefabScript.connObject;
			}
			connection = -1;
			return null;
		}

		public ERConnection GetConnectionObjectAtEnd()
		{
			if (roadScript.endPrefabScript != null)
			{
				if (roadScript.endPrefabScript.connObject == null)
				{
					roadScript.endPrefabScript.connObject = ERConnection.Create(roadScript.endPrefabScript.gameObject);
				}
				return roadScript.endPrefabScript.connObject;
			}
			return null;
		}

		public ERConnection GetConnectionAtEnd()
		{
			if (roadScript.endPrefabScript != null)
			{
				if (roadScript.endPrefabScript.connObject == null)
				{
					roadScript.endPrefabScript.connObject = ERConnection.Create(roadScript.endPrefabScript.gameObject);
				}
				return roadScript.endPrefabScript.connObject;
			}
			return null;
		}

		public ERConnection GetConnectionAtEnd(out int connection)
		{
			if (roadScript.endPrefabScript != null)
			{
				connection = roadScript.endConnectionSegment;
				if (roadScript.endPrefabScript.connObject == null)
				{
					roadScript.endPrefabScript.connObject = ERConnection.Create(roadScript.endPrefabScript.gameObject);
				}
				return roadScript.endPrefabScript.connObject;
			}
			connection = -1;
			return null;
		}

		public GameObject GetConnectionObjectAtEnd(out int connection)
		{
			if (roadScript.endPrefabScript != null)
			{
				connection = roadScript.endConnectionSegment;
				return roadScript.endPrefabScript.gameObject;
			}
			connection = -1;
			return null;
		}

		public bool ConnectionCheck(ERCrossingPrefabs prefab, int index, int startEnd)
		{
			if (roadScript == null)
			{
				Debug.LogError("EasyRoads3Dv3 Error: the passed road object is null");
				return false;
			}
			if (roadScript.soSplinePoints.Count < 2)
			{
				Debug.LogError("EasyRoads3Dv3 Error: the passed road does not have road data");
				return false;
			}
			if (prefab == null)
			{
				Debug.LogError("EasyRoads3Dv3 Error: the passed connection prefab is null");
				return false;
			}
			if (prefab.crossingElements.Count < index || index < 0)
			{
				Debug.LogError("EasyRoads3Dv3 Error: the passed connection index does not exist on the prefab");
				return false;
			}
			if (prefab.crossingElements[index].connectedRoad != null)
			{
				Debug.LogError("EasyRoads3Dv3 Error: a road object is already attached to the passed connection index");
				return false;
			}
			if ((startEnd == 0 && roadScript.startPrefabScript != null) || (startEnd == 1 && roadScript.endPrefabScript != null))
			{
				Debug.LogError("EasyRoads3Dv3 Error: a connection prefab is already attached on this end of the road");
				return false;
			}
			return true;
		}

		public bool ConnectToStart(ERConnection connectionObject, int connectionIndex)
		{
			if (ConnectionCheck(connectionObject.prefabScript, connectionIndex, 0))
			{
				return ConnectToStartExt(connectionObject, connectionIndex, autoAlign: false);
			}
			return false;
		}

		public bool ConnectToStart(ERConnection connectionObject, int connectionIndex, bool autoAlign)
		{
			if (ConnectionCheck(connectionObject.prefabScript, connectionIndex, 0))
			{
				ODQCQOODDO.ODOQDCODCQ(connectionObject.prefabScript, roadScript, connectionIndex, 0);
				return ConnectToStartExt(connectionObject, connectionIndex, autoAlign);
			}
			return false;
		}

		public bool ConnectToStartExt(ERConnection connectionObject, int connectionIndex, bool autoAlign)
		{
			if (roadScript.closedTrack)
			{
				return false;
			}
			if (roadScript.startPrefabScript != null)
			{
				return false;
			}
			if (roadScript.endPrefabScript != null && !ConnectionMatch(connectionObject, connectionIndex))
			{
				return false;
			}
			roadScript.nodeWithinRange = 0;
			Vector3 tmpCenterPoint = connectionObject.prefabScript.crossingElements[connectionIndex].tmpCenterPoint;
			tmpCenterPoint = connectionObject.prefabScript.transform.TransformPoint(tmpCenterPoint);
			ODQCQOODDO.OCOQODCDCQ(roadScript, tmpCenterPoint, connectionObject.prefabScript, connectionIndex, reverse: true, uvReverse: true, autoAlign);
			return true;
		}

		public bool ConnectToEnd(ERConnection connectionObject, int connectionIndex)
		{
			if (ConnectionCheck(connectionObject.prefabScript, connectionIndex, 1))
			{
				return ConnectToEndEx(connectionObject, connectionIndex, autoAlign: false);
			}
			return false;
		}

		public bool ConnectToEnd(ERConnection connectionObject, int connectionIndex, bool autoAlign)
		{
			if (ConnectionCheck(connectionObject.prefabScript, connectionIndex, 1))
			{
				ODQCQOODDO.ODOQDCODCQ(connectionObject.prefabScript, roadScript, connectionIndex, 1);
				return ConnectToEndEx(connectionObject, connectionIndex, autoAlign);
			}
			return false;
		}

		public bool ConnectToEndEx(ERConnection connectionObject, int connectionIndex, bool autoAlign)
		{
			if (roadScript.closedTrack)
			{
				return false;
			}
			if (roadScript.endPrefabScript != null)
			{
				return false;
			}
			if (roadScript.startPrefabScript != null && !ConnectionMatch(connectionObject, connectionIndex))
			{
				return false;
			}
			roadScript.nodeWithinRange = roadScript.markersExt.Count - 1;
			Vector3 tmpCenterPoint = connectionObject.prefabScript.crossingElements[connectionIndex].tmpCenterPoint;
			tmpCenterPoint = connectionObject.prefabScript.transform.TransformPoint(tmpCenterPoint);
			ODQCQOODDO.OCOQODCDCQ(roadScript, tmpCenterPoint, connectionObject.prefabScript, connectionIndex, reverse: false, uvReverse: false, autoAlign);
			return true;
		}

		public ERConnection AttachToStart(ERConnection connectionObject)
		{
			ERConnection eRConnection = null;
			if (roadScript.closedTrack)
			{
				return null;
			}
			if (roadScript.startPrefabScript != null)
			{
				return null;
			}
			if (roadScript.endPrefabScript != null && !ConnectionMatch(connectionObject))
			{
				return null;
			}
			ERCrossingPrefabs eRCrossingPrefabs = roadScript.baseScript.OOQQQOCCQD(connectionObject.prefabScript.gameObject, roadScript, 0, -1);
			return new ERConnection(eRCrossingPrefabs.gameObject, eRCrossingPrefabs.gameObject.name);
		}

		public ERConnection AttachToEnd(ERConnection connectionObject)
		{
			if (roadScript.closedTrack)
			{
				return null;
			}
			if (roadScript.endPrefabScript != null)
			{
				return null;
			}
			if (roadScript.startPrefabScript != null && !ConnectionMatch(connectionObject))
			{
				return null;
			}
			ERCrossingPrefabs eRCrossingPrefabs = roadScript.baseScript.OOQQQOCCQD(connectionObject.prefabScript.gameObject, roadScript, roadScript.markersExt.Count - 1, -1);
			return new ERConnection(eRCrossingPrefabs.gameObject, eRCrossingPrefabs.gameObject.name);
		}

		public bool ConnectionMatch(ERConnection connection)
		{
			for (int i = 0; i < connection.prefabScript.crossingElements.Count; i++)
			{
				if (roadScript.roadShapeMatchCount == connection.prefabScript.crossingElements[i].roadShapeMatchCount || roadScript.roadShapeMatchCount == 0 || connection.prefabScript.crossingElements[i].roadShapeMatchCount == 0)
				{
					return true;
				}
			}
			return false;
		}

		public void UnConnectStart()
		{
			bool flag = false;
			if (roadScript.startPrefabScript != null)
			{
				ODQCQOODDO.ODCOOQCQQD(roadScript.baseScript, roadScript, 1, 0, 0);
				Refresh();
			}
		}

		public void UnConnectEnd()
		{
			bool flag = false;
			if (roadScript.endPrefabScript != null)
			{
				ODQCQOODDO.OQDOCOCDDO(roadScript.baseScript, roadScript, roadScript.markersExt.Count - 2, roadScript.markersExt.Count - 1, roadScript.markersExt.Count - 1);
				Refresh();
			}
		}

		public bool ConnectionMatch(ERConnection connection, int connectionIndex)
		{
			if (roadScript.roadShapeMatchCount == connection.prefabScript.crossingElements[connectionIndex].roadShapeMatchCount || roadScript.roadShapeMatchCount == 0 || connection.prefabScript.crossingElements[connectionIndex].roadShapeMatchCount == 0)
			{
				return true;
			}
			return false;
		}

		public void SnapToTerrain(bool flag)
		{
			roadScript.snapVertices = flag;
			roadScript.terrainDeformation = !flag;
			Refresh();
		}

		public void SnapToTerrain(bool flag, float offset)
		{
			roadScript.snapVertices = flag;
			roadScript.snapOffset = offset;
			roadScript.terrainDeformation = !flag;
			Refresh();
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
				roadScript.roadName = name;
			}
		}

		public void Destroy()
		{
			ERCrossingPrefabs startPrefabScript = roadScript.startPrefabScript;
			ERCrossingPrefabs endPrefabScript = roadScript.endPrefabScript;
			if (startPrefabScript != null && startPrefabScript.isIConnector && (bool)startPrefabScript.gameObject.GetComponent<ERIConnector>())
			{
				startPrefabScript.gameObject.GetComponent<ERIConnector>().OCCCCCCDCC(null);
			}
			if (endPrefabScript != null && endPrefabScript.isIConnector && (bool)endPrefabScript.gameObject.GetComponent<ERIConnector>())
			{
				endPrefabScript.gameObject.GetComponent<ERIConnector>().OCCCCCCDCC(null);
			}
			if (gameObject != null)
			{
				Object.DestroyImmediate(gameObject);
			}
			roadScript = null;
		}
	}
}
