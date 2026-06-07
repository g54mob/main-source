using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace EasyRoads3Dv3
{
	public class ERRoad
	{
		public ERModularRoad roadScript;

		public GameObject gameObject;

		public List<GameObject> markerGameObjects = new List<GameObject>();

		public List<GameObject> childGameObjects = new List<GameObject>();

		public string str = "EasyRoads3D Warning: The free version does not support API calls";

		public ERRoad()
		{
		}

		public ERRoad(ERModularRoad scr)
		{
			roadScript = scr;
			gameObject = scr.gameObject;
			roadScript.road = this;
		}

		public void AddInititialMarkers(Vector3 pos)
		{
			roadScript.markersExt.Add(ERMarkerExt.CreateInstance(pos, roadScript, 0));
		}

		public int AddMarker(Vector3 pos, bool refresh = true)
		{
			int result = -1;
			if (roadScript.endPrefabScript == null)
			{
				if (roadScript.snapToTerrain)
				{
					roadScript.baseScript.OQCCDQOQOO(ref pos);
				}
				roadScript.markersExt.Add(ERMarkerExt.CreateInstance(pos, roadScript, roadScript.markersExt.Count));
				result = roadScript.markersExt.Count - 1;
			}
			if (refresh)
			{
				Refresh();
			}
			return result;
		}

		public void ClampUVs(bool value)
		{
			roadScript.lockUVs = !value;
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
			for (int j = 0; j < roadScript.roadShapeUVs.Count; j++)
			{
				if (roadScript.roadShapeMaterialInts[j] == num)
				{
					roadScript.roadShapeUVs[j] = 1f - roadScript.roadShapeUVs[j];
					if (roadScript.roadShapeUVs2.Count > j)
					{
						roadScript.roadShapeUVs2[j] = 1f - roadScript.roadShapeUVs2[j];
					}
				}
			}
			Refresh();
		}

		public void ReverseMarkerOrder()
		{
			OQOCQDQODD.ReverseRoadMarkers(roadScript);
		}

		public void AddMarkers(Vector3[] pos, bool refresh = true)
		{
			if (roadScript.endPrefabScript == null)
			{
				for (int i = 0; i < pos.Length; i++)
				{
					roadScript.markersExt.Add(ERMarkerExt.CreateInstance(pos[i], roadScript, roadScript.markersExt.Count));
				}
			}
			if (refresh)
			{
				Refresh();
			}
		}

		public int InsertMarker(Vector3 pos, bool refresh = true)
		{
			int num = -1;
			roadScript.nodeWithinRange = -1;
			num = roadScript.OOODDDDQDO(pos);
			if (refresh)
			{
				Refresh();
			}
			return num;
		}

		public void InsertMarkerAt(Vector3 pos, int markerIndex, bool refresh = true)
		{
			if (roadScript.markersExt.Count >= markerIndex + 1 && markerIndex >= 0)
			{
				roadScript.markersExt.Insert(markerIndex, ERMarkerExt.CreateInstance(pos, roadScript, markerIndex));
				if (refresh)
				{
					Refresh();
				}
			}
		}

		public void DeleteMarker(int i, bool refresh = true)
		{
			if (roadScript.markersExt.Count > i && i >= 0)
			{
				roadScript.markersExt.RemoveAt(i);
				if (roadScript.markersExt.Count == 2)
				{
					roadScript.closedTrack = false;
				}
				if (refresh)
				{
					Refresh();
				}
			}
		}

		public bool IsConnectedAtStart()
		{
			if (roadScript.startPrefabScript == null)
			{
				return false;
			}
			return true;
		}

		public bool IsConnectedAtEnd()
		{
			if (roadScript.endPrefabScript == null)
			{
				return false;
			}
			return true;
		}

		public void SetLayer(int layer)
		{
			roadScript.gameObject.layer = (roadScript.layer = layer);
		}

		public void SetTag(string tag)
		{
			if (!string.IsNullOrEmpty(tag))
			{
				roadScript.gameObject.tag = (roadScript.tag = tag);
			}
		}

		public void SetWidth(float width, bool refresh = true)
		{
			roadScript.roadWidth = width;
			roadScript.roadShape.Clear();
			if (refresh)
			{
				Refresh();
			}
		}

		public float GetWidth()
		{
			if (roadScript != null)
			{
				return roadScript.roadWidth;
			}
			return 0f;
		}

		public void SetWidth(float width, int markerIndex, bool refresh = true)
		{
			if (markerIndex < 0 || roadScript.markersExt.Count <= markerIndex)
			{
				return;
			}
			Vector2[] array = roadScript.markersExt[markerIndex].roadShape.ToArray();
			float num = 1000f;
			float num2 = -1000f;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].x < num)
				{
					num = array[i].x;
				}
				if (array[i].x > num2)
				{
					num2 = array[i].x;
				}
			}
			float num3 = width / (num2 - num);
			for (int j = 0; j < array.Length; j++)
			{
				array[j].x *= num3;
			}
			roadScript.markersExt[markerIndex].roadShape = new List<Vector2>(array);
			if (refresh)
			{
				Refresh();
			}
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
				Debug.LogError("EasyRoads3D: the passed road type is null");
				return false;
			}
			ERRoadType[] roadTypes = roadScript.baseScript.GetRoadTypes();
			QDQDOOQQDQODD roadType2 = ERRoadType.GetRoadType(roadType, roadScript.baseScript);
			if (roadType2 != null)
			{
				ODDOQDDQCQ.UpdateRoadTypeByRoad(roadScript.baseScript, roadScript, -1, roadType2);
				roadScript.rt = QDQDOOQQDQODD.GetRoadTypeElByID(roadScript.baseScript.roadTypes, roadType2.id, clone: true);
				return true;
			}
			return false;
		}

		public bool SetMarkerControlType(int marker, ERMarkerControlType type, bool refresh = true)
		{
			if (type == ERMarkerControlType.Circular && roadScript.markersExt.Count <= 2)
			{
				Debug.Log("EasyRoads3D Warning: The circular controller type cannot be used on a road object with two or less marker control points.");
				return false;
			}
			if (roadScript.markersExt.Count > marker && marker >= 0)
			{
				roadScript.markersExt[marker].SetControlType(type);
				if (refresh)
				{
					Refresh();
				}
				return true;
			}
			return false;
		}

		public ERMarkerControlType GetMarkerControlType(int marker)
		{
			return roadScript.markersExt[marker].GetControlType();
		}

		public bool SetSplineStrength(int markerIndex, float strength, bool refresh = true)
		{
			if (roadScript.markersExt.Count > markerIndex && markerIndex >= 0)
			{
				if (strength < 0.01f)
				{
					strength = 0.01f;
				}
				if (strength > 1f)
				{
					strength = 1f;
				}
				roadScript.markersExt[markerIndex].splineStrength = strength;
				if (refresh)
				{
					Refresh();
				}
				return true;
			}
			return false;
		}

		public float GetSplineStrength(int markerIndex)
		{
			if (roadScript.markersExt.Count > markerIndex && markerIndex >= 0)
			{
				return roadScript.markersExt[markerIndex].splineStrength;
			}
			return 0f;
		}

		public void IsSideObject(bool value)
		{
			roadScript.isSideObject = value;
		}

		public bool IsSideObject()
		{
			return roadScript.isSideObject;
		}

		public ERRoad InsertIConnector(int markerIndex)
		{
			ERCrossingPrefabs ussss = null;
			return ussst(markerIndex, ref ussss);
		}

		public ERRoad InsertIConnector(int markerIndex, string connectionName)
		{
			ERCrossingPrefabs ussss = null;
			ERRoad result = ussst(markerIndex, ref ussss);
			ussss.gameObject.name = connectionName;
			return result;
		}

		public ERRoad InsertIConnector(int markerIndex, string connectionName, out ERConnection connection)
		{
			ERCrossingPrefabs ussss = null;
			ERRoad result = ussst(markerIndex, ref ussss);
			ussss.gameObject.name = connectionName;
			connection = new ERConnection(ussss.gameObject, ussss.gameObject.name);
			return result;
		}

		private ERRoad ussst(int tssss, ref ERCrossingPrefabs ussss)
		{
			int num = tssss;
			ERModularRoad eRModularRoad = roadScript;
			if (tssss < 0 || tssss >= eRModularRoad.markersExt.Count)
			{
				Debug.LogWarning("EasyRoads3D: road " + eRModularRoad.name + " no marker exists at index: " + tssss);
				return null;
			}
			int num2 = 0;
			ERModularRoad eRModularRoad2 = null;
			if (num != 0 && num != eRModularRoad.markersExt.Count - 1)
			{
				eRModularRoad2 = OQOCQDQODD.ODOOOQCQCQ(eRModularRoad, num);
			}
			ussss = eRModularRoad.baseScript.AttachConnector(eRModularRoad, num);
			ERRoad eRRoad = null;
			if (eRModularRoad2 != null)
			{
				eRModularRoad2.nodeWithinRange = 0;
				OQOCQDQODD.ODCQDDOQOQ(eRModularRoad2, ussss.transform.position, ussss, 1, reverse: true, uvReverse: true, forceAutoRotate: false);
				eRRoad = (eRModularRoad2.road = new ERRoad(eRModularRoad2));
				eRRoad.gameObject = eRModularRoad2.gameObject;
			}
			ussss.isIConnector = true;
			Refresh();
			return eRRoad;
		}

		public ERRoad SplitRoad(int markerIndex)
		{
			ERModularRoad eRModularRoad = vssss(markerIndex);
			if (eRModularRoad != null)
			{
				eRModularRoad.road = new ERRoad(eRModularRoad);
				return eRModularRoad.road;
			}
			return null;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		private ERModularRoad vssss(int tssss)
		{
			if (tssss < 1 || tssss >= roadScript.markersExt.Count - 1)
			{
				Debug.LogWarning("EasyRoads3D: the road cannot be split at marker " + tssss);
				return null;
			}
			return OQOCQDQODD.ODOOOQCQCQ(roadScript, tssss);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetSideObjects(List<ERSORoadExt> soDataExt, double id = 0.0)
		{
			bool flag = true;
			for (int i = 0; i < roadScript.baseScript.roadTypes.Count; i++)
			{
				if (roadScript.baseScript.roadTypes[i].id == id)
				{
					soDataExt = roadScript.baseScript.roadTypes[i].soDataExt;
				}
			}
			roadScript.soDataExt.Clear();
			roadScript.soDataExt = new List<ERSORoadExt>();
			for (int j = 0; j < soDataExt.Count; j++)
			{
				roadScript.soDataExt.Add(ERSORoadExt.CreateInstance(soDataExt[j].sideObject));
				if (soDataExt[j].active)
				{
					roadScript.soDataExt[roadScript.soDataExt.Count - 1].active = true;
				}
				roadScript.soDataExt[roadScript.soDataExt.Count - 1].autoGenerate = soDataExt[j].autoGenerate;
				roadScript.soDataExt[roadScript.soDataExt.Count - 1].markerActive = soDataExt[j].markerActive;
				roadScript.soDataExt[roadScript.soDataExt.Count - 1].xPosition = soDataExt[j].xPosition;
				roadScript.soDataExt[roadScript.soDataExt.Count - 1].randomMinXPosition = soDataExt[j].randomMinXPosition;
				roadScript.soDataExt[roadScript.soDataExt.Count - 1].randomMaxXPosition = soDataExt[j].randomMaxXPosition;
				roadScript.soDataExt[roadScript.soDataExt.Count - 1].yPosition = soDataExt[j].yPosition;
				roadScript.soDataExt[roadScript.soDataExt.Count - 1].randomMinYPosition = soDataExt[j].randomMinYPosition;
				roadScript.soDataExt[roadScript.soDataExt.Count - 1].randomMaxYPosition = soDataExt[j].randomMaxYPosition;
				roadScript.soDataExt[roadScript.soDataExt.Count - 1].minRandomXPositionDistance = soDataExt[j].minRandomXPositionDistance;
				roadScript.soDataExt[roadScript.soDataExt.Count - 1].maxRandomXPositionDistance = soDataExt[j].maxRandomXPositionDistance;
				roadScript.soDataExt[roadScript.soDataExt.Count - 1].minRandomYPositionDistance = soDataExt[j].minRandomYPositionDistance;
				roadScript.soDataExt[roadScript.soDataExt.Count - 1].maxRandomYPositionDistance = soDataExt[j].maxRandomYPositionDistance;
				roadScript.soDataExt[roadScript.soDataExt.Count - 1].randomMinRotation = soDataExt[j].randomMinRotation;
				roadScript.soDataExt[roadScript.soDataExt.Count - 1].randomMaxRotation = soDataExt[j].randomMaxRotation;
				roadScript.soDataExt[roadScript.soDataExt.Count - 1].minRandomRotationDistance = soDataExt[j].minRandomRotationDistance;
				roadScript.soDataExt[roadScript.soDataExt.Count - 1].maxRandomRotationDistance = soDataExt[j].maxRandomRotationDistance;
				roadScript.soDataExt[roadScript.soDataExt.Count - 1].lockRandomRotations = soDataExt[j].lockRandomRotations;
				roadScript.soDataExt[roadScript.soDataExt.Count - 1].distanceChange = soDataExt[j].distanceChange;
				roadScript.soDataExt[roadScript.soDataExt.Count - 1].xPosChange = soDataExt[j].xPosChange;
				roadScript.soDataExt[roadScript.soDataExt.Count - 1].yPosChange = soDataExt[j].yPosChange;
				roadScript.soDataExt[roadScript.soDataExt.Count - 1].rotationAngleChange = soDataExt[j].rotationAngleChange;
				roadScript.soDataExt[roadScript.soDataExt.Count - 1].rotationDistanceChange = soDataExt[j].rotationDistanceChange;
				roadScript.soDataExt[roadScript.soDataExt.Count - 1].randomXPositionChange = soDataExt[j].randomXPositionChange;
				roadScript.soDataExt[roadScript.soDataExt.Count - 1].xPositionDistanceChange = soDataExt[j].xPositionDistanceChange;
				roadScript.soDataExt[roadScript.soDataExt.Count - 1].yPositionDistanceChange = soDataExt[j].yPositionDistanceChange;
				roadScript.soDataExt[roadScript.soDataExt.Count - 1].randomXPositionChange = soDataExt[j].randomXPositionChange;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetMarkerSideObjects()
		{
			if (roadScript.markersExt.Count <= 0)
			{
				return;
			}
			foreach (ERSOMarkerExt soDatum in roadScript.markersExt[0].soData)
			{
				foreach (ERSORoadExt item in roadScript.soDataExt)
				{
					if (soDatum.id == item.id)
					{
						soDatum.xPosition = item.xPosition;
					}
				}
			}
		}

		public bool SetSidewalk(ERSideWalk sidewalk, ERRoadSide side, bool active)
		{
			if (sidewalk == null)
			{
				Debug.Log("EasyRoads3D Warning: the sidewalk object is null");
				return false;
			}
			if (side == ERRoadSide.Left || side == ERRoadSide.Both)
			{
				roadScript.defaultLeftSidewalkid = sidewalk.id;
			}
			if (side == ERRoadSide.Right || side == ERRoadSide.Both)
			{
				roadScript.defaultRightSidewalkid = sidewalk.id;
			}
			SetSidewalk(side, active);
			return true;
		}

		public bool SetSidewalk(ERRoadSide side, bool active)
		{
			if (!active)
			{
				if (side == ERRoadSide.Left || side == ERRoadSide.Both)
				{
					roadScript.leftSidewalkActive = false;
					ERSideWalk eRSideWalk = null;
					if (roadScript.leftSidewalks.Count > 0)
					{
						eRSideWalk = roadScript.leftSidewalks[0].sidewalk;
					}
					roadScript.RemoveSidewalks(ERRoadSide.Left);
					ERCrossingPrefabs.SidewalkActiveState(roadScript, active: false, eRSideWalk.id, 0);
				}
				if (side == ERRoadSide.Right || side == ERRoadSide.Both)
				{
					roadScript.rightSidewalkActive = false;
					ERSideWalk eRSideWalk2 = null;
					if (roadScript.rightSidewalks.Count > 0)
					{
						eRSideWalk2 = roadScript.rightSidewalks[0].sidewalk;
					}
					roadScript.RemoveSidewalks(ERRoadSide.Right);
					ERCrossingPrefabs.SidewalkActiveState(roadScript, active: false, eRSideWalk2.id, 1);
				}
			}
			else
			{
				if (side == ERRoadSide.Left || side == ERRoadSide.Both)
				{
					roadScript.leftSidewalkActive = true;
				}
				if (side == ERRoadSide.Right || side == ERRoadSide.Both)
				{
					roadScript.rightSidewalkActive = true;
				}
				Refresh();
			}
			return true;
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

		public void SetMarkerPosition(int markerIndex, Vector3 vec, bool refresh = true)
		{
			if (roadScript.markersExt.Count > markerIndex && markerIndex >= 0)
			{
				roadScript.markersExt[markerIndex].position = vec;
				if (refresh)
				{
					Refresh();
				}
			}
		}

		public void SetRandomBumpiness(float minHeight, float maxHeight, float minDistance, float maxDistance, bool refresh = true)
		{
			foreach (ERMarkerExt item in roadScript.markersExt)
			{
				item.randomMinYPosition = minHeight;
				item.randomMaxYPosition = maxHeight;
				item.minRandomYPositionDistance = minDistance;
				item.maxRandomYPositionDistance = maxDistance;
			}
			roadScript.randomMinYPosition = minHeight;
			roadScript.randomMaxYPosition = maxHeight;
			roadScript.minRandomYPositionDistance = minDistance;
			roadScript.maxRandomYPositionDistance = maxDistance;
			if (refresh)
			{
				Refresh();
			}
		}

		public void SetRandomTilting(float minAngle, float maxAngle, float minDistance, float maxDistance, bool refresh = true)
		{
			foreach (ERMarkerExt item in roadScript.markersExt)
			{
				item.randomMinRotation = minAngle;
				item.randomMaxRotation = maxAngle;
				item.minRandomRotationDistance = minDistance;
				item.maxRandomRotationDistance = maxDistance;
			}
			roadScript.randomMinRotation = minAngle;
			roadScript.randomMaxRotation = maxAngle;
			roadScript.minRandomRotationDistance = minDistance;
			roadScript.maxRandomRotationDistance = maxDistance;
			if (refresh)
			{
				Refresh();
			}
		}

		public void SetRandomBumpiness(int markerIndex, float minHeight, float maxHeight, float minDistance, float maxDistance, bool refresh = true)
		{
			if (roadScript.markersExt.Count > markerIndex && markerIndex >= 0)
			{
				roadScript.markersExt[markerIndex].randomMinYPosition = minHeight;
				roadScript.markersExt[markerIndex].randomMaxYPosition = maxHeight;
				roadScript.markersExt[markerIndex].minRandomYPositionDistance = minDistance;
				roadScript.markersExt[markerIndex].maxRandomYPositionDistance = maxDistance;
				if (refresh)
				{
					Refresh();
				}
			}
		}

		public void SetRandomTilting(int markerIndex, float minAngle, float maxAngle, float minDistance, float maxDistance, bool refresh = true)
		{
			if (roadScript.markersExt.Count > markerIndex && markerIndex >= 0)
			{
				roadScript.markersExt[markerIndex].randomMinRotation = minAngle;
				roadScript.markersExt[markerIndex].randomMaxRotation = maxAngle;
				roadScript.markersExt[markerIndex].minRandomRotationDistance = minDistance;
				roadScript.markersExt[markerIndex].maxRandomRotationDistance = maxDistance;
				if (refresh)
				{
					Refresh();
				}
			}
		}

		public void SetResolution(float res, bool refresh = true)
		{
			roadScript.faceDistance = res;
			if (refresh)
			{
				Refresh();
			}
		}

		public void SetStartLevelDistance(int markerIndex, float value, bool refresh = true)
		{
			if (markerIndex >= 0 && markerIndex < roadScript.markersExt.Count - 1)
			{
				if (value < 0f)
				{
					value *= -1f;
				}
				if (value > 0.5f * roadScript.markersExt[markerIndex].totalDistance)
				{
					value = 0.4f * roadScript.markersExt[markerIndex].totalDistance;
				}
				roadScript.markersExt[markerIndex].bridgeStartLevelDistance = value;
				if (refresh)
				{
					Refresh();
				}
			}
		}

		public void SetEndLevelDistance(int markerIndex, float value, bool refresh = true)
		{
			if (markerIndex >= 0 && markerIndex < roadScript.markersExt.Count - 1)
			{
				if (value < 0f)
				{
					value *= -1f;
				}
				if (value > 0.5f * roadScript.markersExt[markerIndex].totalDistance)
				{
					value = 0.4f * roadScript.markersExt[markerIndex].totalDistance;
				}
				roadScript.markersExt[markerIndex].bridgeEndLevelDistance = value;
				if (refresh)
				{
					Refresh();
				}
			}
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

		public void SetAngleThreshold(float res, bool refresh = true)
		{
			roadScript.angleTreshold = res;
			if (refresh)
			{
				Refresh();
			}
		}

		public float GetAngleTreshold(float res)
		{
			return roadScript.angleTreshold;
		}

		public bool ClosedTrack(bool value, bool refresh = true)
		{
			if (roadScript.startPrefabScript == null && roadScript.endPrefabScript == null)
			{
				roadScript.closedTrack = value;
				if (refresh)
				{
					Refresh();
				}
				return true;
			}
			return false;
		}

		public void FollowTerrainContours(bool value, bool refresh = true)
		{
			roadScript.followTerrainContours = value;
			for (int i = 0; i < roadScript.markersExt.Count; i++)
			{
				roadScript.markersExt[i].followTerrainContours = value;
				if (value && roadScript.baseScript != null)
				{
					Vector3 pos = roadScript.markersExt[i].position;
					roadScript.baseScript.OQCCDQOQOO(ref pos);
					roadScript.markersExt[i].position = pos;
				}
			}
			if (refresh)
			{
				Refresh();
			}
		}

		[Obsolete("obsolete")]
		public void SetFollowTerrainContoursOffset(float value, bool refresh = true)
		{
			roadScript.terrainContoursOffset = value;
			if (refresh)
			{
				Refresh();
			}
		}

		public void FollowTerrainContourThreshold(float value, bool refresh = true)
		{
			roadScript.terrainContoursOffset = value;
			if (refresh)
			{
				Refresh();
			}
		}

		public void FollowTerrainContours(int markerIndex, bool value, bool refresh = true)
		{
			if (roadScript.markersExt.Count > markerIndex && markerIndex >= 0)
			{
				roadScript.markersExt[markerIndex].followTerrainContours = value;
				if (refresh)
				{
					Refresh();
				}
			}
		}

		public bool IsClosedTrack()
		{
			return roadScript.closedTrack;
		}

		public void SetMarkerPositions(Vector3[] vecs, bool refresh = true)
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
			if (refresh)
			{
				Refresh();
			}
		}

		public void SetMarkerPositions(Vector3[] vecs, int markerIndex, bool refresh = true)
		{
			if (markerIndex + vecs.Length < roadScript.markersExt.Count && markerIndex >= 0)
			{
				for (int i = markerIndex; i < markerIndex + vecs.Length; i++)
				{
					roadScript.markersExt[i].position = vecs[i - markerIndex];
				}
				if (refresh)
				{
					Refresh();
				}
			}
		}

		public Vector3 GetMarkerPosition(int markerIndex)
		{
			if (roadScript.markersExt.Count > markerIndex && markerIndex >= 0)
			{
				return roadScript.markersExt[markerIndex].position;
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

		public int GetMarkerCount()
		{
			return roadScript.markersExt.Count;
		}

		public void SetMarkerTilting(float value, int markerIndex, bool refresh = true)
		{
			if (roadScript.markersExt.Count > markerIndex && markerIndex >= 0)
			{
				roadScript.markersExt[markerIndex].rotation = value;
				if (refresh)
				{
					Refresh();
				}
			}
		}

		public float GetMarkerTilting(int markerIndex)
		{
			if (roadScript.markersExt.Count > markerIndex && markerIndex >= 0)
			{
				return roadScript.markersExt[markerIndex].rotation;
			}
			return 0f;
		}

		public void SetMarkerTiltingCenter(float value, int markerIndex, bool refresh = true)
		{
			if (roadScript.markersExt.Count > markerIndex && markerIndex >= 0)
			{
				if (value > 1f)
				{
					value = 1f;
				}
				else if (value < 0f)
				{
					value = 0f;
				}
				roadScript.markersExt[markerIndex].rotationCenter = value;
				if (refresh)
				{
					Refresh();
				}
			}
		}

		public float GetRadius(int markerIndex)
		{
			if (roadScript.markersExt.Count > markerIndex && markerIndex >= 0)
			{
				if (roadScript.markersExt[markerIndex].controlType == 3)
				{
					return roadScript.markersExt[markerIndex].radius;
				}
				return 0f;
			}
			return 0f;
		}

		public float GetMarkerTiltingCenter(int markerIndex)
		{
			if (roadScript.markersExt.Count > markerIndex && markerIndex >= 0)
			{
				return roadScript.markersExt[markerIndex].rotationCenter;
			}
			return 0f;
		}

		public Color GetVertexColor(int markerIndex)
		{
			if (roadScript.markersExt.Count > markerIndex && markerIndex >= 0)
			{
				return roadScript.markersExt[markerIndex].customColor;
			}
			return Color.red;
		}

		public void SetVertexColor(int markerIndex, Color color, bool refresh = true)
		{
			if (roadScript.markersExt.Count > markerIndex && markerIndex >= 0)
			{
				roadScript.markersExt[markerIndex].customColor = color;
				if (refresh)
				{
					Refresh();
				}
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
				for (int num2 = currentElement; num2 < roadScript.distances.Count; num2--)
				{
					if (roadScript.distances[num2] < distance)
					{
						currentElement = num2;
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
				float num3 = distance - roadScript.distances[currentElement];
				float num4 = roadScript.distances[currentElement + 1] - roadScript.distances[currentElement];
				vector = Vector3.Lerp(roadScript.soSplinePoints[currentElement], roadScript.soSplinePoints[currentElement + 1], num3 / num4);
			}
			else
			{
				vector = roadScript.soSplinePoints[roadScript.soSplinePoints.Count - 1];
			}
			return vector;
		}

		public Vector3 GetLookatSmooth(float distance, int currentElement)
		{
			if (roadScript.distances.Count == 0)
			{
				SetDistances();
			}
			float num = roadScript.distances[currentElement];
			if (distance < 0f)
			{
				return (roadScript.soSplinePoints[1] - roadScript.soSplinePoints[0]).normalized;
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
				for (int num2 = currentElement; num2 < roadScript.distances.Count; num2--)
				{
					if (roadScript.distances[num2] < distance)
					{
						currentElement = num2;
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
				float num3 = distance - roadScript.distances[currentElement];
				float num4 = roadScript.distances[currentElement + 1] - roadScript.distances[currentElement];
				float num5 = num3 / num4;
				Vector3 normalized = (roadScript.soSplinePoints[currentElement + 1] - roadScript.soSplinePoints[currentElement]).normalized;
				if ((double)num5 > 0.5)
				{
					if (currentElement + 1 < roadScript.distances.Count - 1)
					{
						Vector3 normalized2 = (roadScript.soSplinePoints[currentElement + 2] - roadScript.soSplinePoints[currentElement + 1]).normalized;
						num5 -= 0.5f;
						result = Vector3.Lerp(normalized, normalized2, num5);
					}
					else
					{
						result = normalized;
					}
				}
				else if (currentElement > 0)
				{
					Vector3 normalized3 = (roadScript.soSplinePoints[currentElement] - roadScript.soSplinePoints[currentElement - 1]).normalized;
					num5 += 0.5f;
					result = Vector3.Lerp(normalized3, normalized, num5);
				}
				else
				{
					result = normalized;
				}
			}
			else
			{
				result = (roadScript.soSplinePoints[roadScript.soSplinePoints.Count - 1] - roadScript.soSplinePoints[roadScript.soSplinePoints.Count - 2]).normalized;
			}
			return result;
		}

		[Obsolete("obsolete")]
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
				for (int num2 = currentElement; num2 < roadScript.distances.Count; num2--)
				{
					if (roadScript.distances[num2] < distance)
					{
						currentElement = num2;
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
				float num3 = distance - roadScript.distances[currentElement];
				float num4 = roadScript.distances[currentElement + 1] - roadScript.distances[currentElement];
				float num5 = num3 / num4;
				Vector3 normalized = (roadScript.soSplinePoints[currentElement + 1] - roadScript.soSplinePoints[currentElement]).normalized;
				if ((double)num5 > 0.5)
				{
					if (currentElement + 1 < roadScript.distances.Count - 1)
					{
						Vector3 normalized2 = (roadScript.soSplinePoints[currentElement + 2] - roadScript.soSplinePoints[currentElement + 1]).normalized;
						num5 -= 0.5f;
						result = Vector3.Lerp(normalized, normalized2, num5);
					}
					else
					{
						result = normalized;
					}
				}
				else if (currentElement > 0)
				{
					Vector3 normalized3 = (roadScript.soSplinePoints[currentElement] - roadScript.soSplinePoints[currentElement - 1]).normalized;
					num5 += 0.5f;
					result = Vector3.Lerp(normalized3, normalized, num5);
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

		public float SetIndent(float value, int markerIndex, bool refresh = true)
		{
			if (markerIndex >= 0 && markerIndex < roadScript.markersExt.Count)
			{
				if (value < roadScript.baseScript.minIndent)
				{
					value = roadScript.baseScript.minIndent;
				}
				roadScript.markersExt[markerIndex].rightIndent = value;
				roadScript.markersExt[markerIndex].leftIndent = value;
				if (refresh)
				{
					Refresh();
				}
				return value;
			}
			return -1f;
		}

		public float SetIndent(float value, int markerIndex, ERRoadSide type, bool refresh = true)
		{
			if (markerIndex >= 0 && markerIndex < roadScript.markersExt.Count)
			{
				if (value < roadScript.baseScript.minIndent)
				{
					value = roadScript.baseScript.minIndent;
				}
				if (type != ERRoadSide.Left)
				{
					roadScript.markersExt[markerIndex].rightIndent = value;
				}
				if (type != ERRoadSide.Right)
				{
					roadScript.markersExt[markerIndex].leftIndent = value;
				}
				if (refresh)
				{
					Refresh();
				}
				return value;
			}
			return -1f;
		}

		[Obsolete("obsolete")]
		public float SetRightIndent(float value, int markerIndex)
		{
			if (markerIndex >= 0 && markerIndex < roadScript.markersExt.Count)
			{
				if (value < roadScript.baseScript.minIndent)
				{
					value = roadScript.baseScript.minIndent;
				}
				roadScript.markersExt[markerIndex].rightIndent = value;
				return value;
			}
			return -1f;
		}

		[Obsolete("obsolete")]
		public float SetLeftIndent(float value, int markerIndex)
		{
			if (markerIndex >= 0 && markerIndex < roadScript.markersExt.Count)
			{
				if (value < roadScript.baseScript.minIndent)
				{
					value = roadScript.baseScript.minIndent;
				}
				roadScript.markersExt[markerIndex].leftIndent = value;
				return value;
			}
			return -1f;
		}

		public float SetSurrounding(float value, int markerIndex, bool refresh = true)
		{
			if (markerIndex >= 0 && markerIndex < roadScript.markersExt.Count)
			{
				if (value < roadScript.baseScript.minIndent)
				{
					value = roadScript.baseScript.minIndent;
				}
				roadScript.markersExt[markerIndex].rightSurrounding = value;
				roadScript.markersExt[markerIndex].leftSurrounding = value;
				if (refresh)
				{
					Refresh();
				}
				return value;
			}
			return -1f;
		}

		public float SetSurrounding(float value, int markerIndex, ERRoadSide type, bool refresh = true)
		{
			if (markerIndex >= 0 && markerIndex < roadScript.markersExt.Count)
			{
				if (value < roadScript.baseScript.minIndent)
				{
					value = roadScript.baseScript.minIndent;
				}
				if (type != ERRoadSide.Left)
				{
					roadScript.markersExt[markerIndex].rightSurrounding = value;
				}
				if (type != ERRoadSide.Right)
				{
					roadScript.markersExt[markerIndex].leftSurrounding = value;
				}
				if (refresh)
				{
					Refresh();
				}
				return value;
			}
			return -1f;
		}

		public void SetIndentAlignment(ERIndentAlignment value, int markerIndex, ERRoadSide type)
		{
			roadScript.OCQDQQDDOC(value, markerIndex, type);
		}

		public ERIndentAlignment GetIndentAlignment(int markerIndex, ERRoadSide type)
		{
			return roadScript.ERGetIndentAlignment(markerIndex, type);
		}

		[Obsolete("obsolete")]
		public float SetRightSurrouding(float value, int markerIndex)
		{
			if (markerIndex >= 0 && markerIndex < roadScript.markersExt.Count)
			{
				if (value < 0f)
				{
					value = 0f;
				}
				roadScript.markersExt[markerIndex].rightSurrounding = value;
				return value;
			}
			return -1f;
		}

		[Obsolete("obsolete")]
		public float SetLeftSurrouding(float value, int markerIndex)
		{
			if (markerIndex >= 0 && markerIndex < roadScript.markersExt.Count)
			{
				if (value < 0f)
				{
					value = 0f;
				}
				roadScript.markersExt[markerIndex].leftSurrounding = value;
				return value;
			}
			return -1f;
		}

		public Vector3[] GetRightIndentPoints()
		{
			return roadScript.rightIndentVecsSV.ToArray();
		}

		public Vector3[] GetLeftIndentPoints()
		{
			return roadScript.leftIndentVecsSV.ToArray();
		}

		public Vector3[] GetRightSurroundingPoints()
		{
			return roadScript.rightSurroundingVecs.ToArray();
		}

		public Vector3[] GetLeftSurroudingPoints()
		{
			return roadScript.leftSurroundingVecs.ToArray();
		}

		[Obsolete("obsolete")]
		public float GetLength()
		{
			return roadScript.totalDistance;
		}

		public float GetDistance()
		{
			return roadScript.totalDistance;
		}

		public float GetDistance(int markerIndex)
		{
			if (markerIndex >= 0 && markerIndex < roadScript.markersExt.Count)
			{
				return roadScript.markersExt[markerIndex].totalDistance;
			}
			return 0f;
		}

		public bool SideObjectSetActive(SideObject obj, bool value)
		{
			bool result = false;
			if (obj != null)
			{
				result = roadScript.OQQCODOQCC(obj, value);
			}
			else
			{
				Debug.Log("EasyRoads3D Warning: The side object is null");
			}
			return result;
		}

		public bool GetSideObjectActiveState(SideObject obj)
		{
			bool result = false;
			if (obj != null)
			{
				return roadScript.GetSideObjectActiveState(obj);
			}
			Debug.Log("EasyRoads3D Warning: The side object is null");
			return result;
		}

		public bool SideObjectMarkerSetActive(SideObject obj, int markerIndex, bool value, ERRoadSide roadSide = ERRoadSide.Both, bool refresh = true)
		{
			bool result = false;
			if (obj != null)
			{
				if (roadScript.OQOOCDDQCQ(obj, markerIndex, value, roadSide) && refresh)
				{
					Refresh();
				}
			}
			else
			{
				Debug.Log("EasyRoads3D Warning: The side object is null");
			}
			return result;
		}

		public void SideObjectMarkerSetActive(SideObject obj, int[] markers, bool value, ERRoadSide roadSide = ERRoadSide.Both)
		{
			if (obj != null)
			{
				if (roadScript.OQOOCDDQCQ(obj, markers, value))
				{
					Refresh();
				}
			}
			else
			{
				Debug.Log("EasyRoads3D Warning: The side object is null");
			}
		}

		public bool GetSideObjectMarkerActiveState(SideObject obj, int markerIndex)
		{
			if (obj != null)
			{
				return roadScript.GetSideObjectMarkerActiveState(obj, markerIndex);
			}
			Debug.Log("EasyRoads3D Warning: The side object is null");
			return false;
		}

		public ERRoadSide GetSideObjectMarkerActiveStateSides(SideObject obj, int markerIndex)
		{
			if (obj != null)
			{
				return roadScript.GetSideObjectMarkerActiveStateSides(obj, markerIndex);
			}
			Debug.Log("EasyRoads3D Warning: The side object is null");
			return ERRoadSide.none;
		}

		public void SetSideObjectOffset(SideObject obj, int markerIndex, OffsetPosition position, float value, ERRoadSide roadSide = ERRoadSide.Both, bool refresh = true)
		{
			if (obj != null)
			{
				roadScript.ERSetSideObjectOffset(obj, markerIndex, position, value, roadSide);
			}
			else
			{
				Debug.Log("EasyRoads3D Warning: The side object is null");
			}
		}

		public void SetSideObjectOffset(SideObject obj, int markerIndex, OffsetPosition position, float value, bool refresh)
		{
			if (obj != null)
			{
				roadScript.ERSetSideObjectOffset(obj, markerIndex, position, value, ERRoadSide.Both, refresh);
			}
			else
			{
				Debug.Log("EasyRoads3D Warning: The side object is null");
			}
		}

		public float GetSideObjectOffset(SideObject obj, int markerIndex, OffsetPosition position, ERRoadSide roadSide)
		{
			if (obj != null)
			{
				return roadScript.ERGetSideObjectOffset(obj, markerIndex, position, roadSide);
			}
			Debug.Log("EasyRoads3D Warning: The side object is null");
			return 0f;
		}

		public void SetSideObjectXPosition(SideObject obj, int markerIndex, float value, ERRoadSide roadSide = ERRoadSide.Both, bool refresh = true)
		{
			if (obj != null)
			{
				roadScript.ERSetSideObjectXPosition(obj, markerIndex, SideObjectSide.DefaultSide, value, roadSide, refresh);
			}
			else
			{
				Debug.Log("EasyRoads3D Warning: The side object is null");
			}
		}

		public void SetSideObjectXPosition(SideObject obj, int markerIndex, float value, bool refresh = true)
		{
			if (obj != null)
			{
				roadScript.ERSetSideObjectXPosition(obj, markerIndex, SideObjectSide.DefaultSide, value, ERRoadSide.Both, refresh);
			}
			else
			{
				Debug.Log("EasyRoads3D Warning: The side object is null");
			}
		}

		public void SetSideObjectXPosition(SideObject obj, int markerIndex, SideObjectSide side, float value)
		{
			if (obj != null)
			{
				roadScript.ERSetSideObjectXPosition(obj, markerIndex, side, value, ERRoadSide.Both, refresh: true);
			}
			else
			{
				Debug.Log("EasyRoads3D Warning: The side object is null");
			}
		}

		public void SetSideObjectXPosition(SideObject obj, int markerIndex, SideObjectSide side, float value, bool refresh)
		{
			if (obj != null)
			{
				roadScript.ERSetSideObjectXPosition(obj, markerIndex, side, value, ERRoadSide.Both, refresh);
			}
			else
			{
				Debug.Log("EasyRoads3D Warning: The side object is null");
			}
		}

		public float GetSideObjectXPosition(SideObject obj, int markerIndex, ERRoadSide roadSide)
		{
			if (obj != null)
			{
				return roadScript.ERGetSideObjectXPosition(obj, markerIndex, roadSide);
			}
			Debug.Log("EasyRoads3D Warning: The side object is null");
			return 0f;
		}

		public Vector3[] GetSideObjectInstancePoints(SideObject so)
		{
			ERSideObjectInstance[] componentsInChildren = gameObject.GetComponentsInChildren<ERSideObjectInstance>();
			ERSideObjectInstance[] array = componentsInChildren;
			foreach (ERSideObjectInstance eRSideObjectInstance in array)
			{
				if (eRSideObjectInstance.so.id == so.id)
				{
					return eRSideObjectInstance.points.ToArray();
				}
			}
			return null;
		}

		public GameObject[] GetSideObjectInstances(SideObject so)
		{
			foreach (ERSORoadExt item in roadScript.soDataExt)
			{
				if (item.sideObject.id == so.id)
				{
					return item.runtimeObjects.ToArray();
				}
			}
			return null;
		}

		public void SetTerrainDeformation(bool value, bool refresh = true)
		{
			roadScript.terrainDeformation = value;
			if (refresh)
			{
				Refresh();
			}
		}

		public void SetTerrainDeformation(int markerIndex, bool value)
		{
			if (markerIndex >= 0 && markerIndex < roadScript.markersExt.Count)
			{
				if (value)
				{
					roadScript.terrainDeformation = value;
				}
				roadScript.markersExt[markerIndex].bridgeObject = !value;
			}
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
				UnityEngine.Object.Destroy(roadScript.gameObject.GetComponent<MeshCollider>());
			}
		}

		public void Refresh()
		{
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
			roadScript.baseScript.UpdateQueue();
			roadScript.ODDDQDQOOD(ignorePrefabAlignment: false, forceAutoRotate: false);
			if (roadScript.baseScript.synchSideObjects)
			{
				roadScript.baseScript.UpdateSideObjectsInScene();
			}
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

		public ERConnection GetConnectionAtStart(out int connectionIndex)
		{
			if (roadScript.startPrefabScript != null)
			{
				connectionIndex = roadScript.startConnectionSegment;
				if (roadScript.startPrefabScript.connObject == null)
				{
					roadScript.startPrefabScript.connObject = ERConnection.Create(roadScript.startPrefabScript.gameObject);
				}
				return roadScript.startPrefabScript.connObject;
			}
			connectionIndex = -1;
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

		public ERConnection GetConnectionAtEnd(out int connectionIndex)
		{
			if (roadScript.endPrefabScript != null)
			{
				connectionIndex = roadScript.endConnectionSegment;
				if (roadScript.endPrefabScript.connObject == null)
				{
					roadScript.endPrefabScript.connObject = ERConnection.Create(roadScript.endPrefabScript.gameObject);
				}
				return roadScript.endPrefabScript.connObject;
			}
			connectionIndex = -1;
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

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ConnectionCheck(ERCrossingPrefabs prefab, int index, int startEnd, bool connectionCheck)
		{
			if (roadScript == null)
			{
				Debug.LogError("EasyRoads3D Error: the passed road object is null");
				return false;
			}
			if (roadScript.soSplinePoints.Count < 2)
			{
				Debug.LogError("EasyRoads3D Error: the passed road does not have road data");
				return false;
			}
			if (prefab == null)
			{
				Debug.LogError("EasyRoads3D Error: the passed connection prefab is null");
				return false;
			}
			if (connectionCheck)
			{
				if (prefab.crossingElements.Count < index || index < 0)
				{
					Debug.LogError("EasyRoads3D Error: the passed connection index does not exist on the prefab");
					return false;
				}
				if (prefab.crossingElements[index].connectedRoad != null)
				{
					Debug.LogError("EasyRoads3D Error: a road object is already attached to the passed connection index");
					return false;
				}
			}
			if ((startEnd == 0 && roadScript.startPrefabScript != null) || (startEnd == 1 && roadScript.endPrefabScript != null))
			{
				Debug.LogError("EasyRoads3D Error: a connection prefab is already attached on this end of the road");
				return false;
			}
			if (connectionCheck && prefab.crossingElements[index].centerPoint == Vector3.zero && !prefab.isIConnector)
			{
				Debug.LogError("EasyRoads3D Error: connection index " + index + " is not a valid connection");
				return false;
			}
			return true;
		}

		public bool ConnectToStart(ERConnection connectionObject)
		{
			if (connectionObject != null)
			{
				if (connectionObject.prefabScript.isFlexConnector)
				{
					if (ConnectionCheck(connectionObject.prefabScript, 0, 0, connectionCheck: false))
					{
						if (roadScript.markersExt[0].position == connectionObject.prefabScript.transform.position)
						{
							roadScript.markersExt[0].position = Vector3.Lerp(roadScript.markersExt[1].position, roadScript.markersExt[0].position, 0.99f);
							Refresh();
						}
						connectionObject.prefabScript.OQQCDDOQOQ(roadScript, 0);
						return true;
					}
					return false;
				}
				return false;
			}
			return false;
		}

		public bool ConnectToStart(ERConnection connectionObject, int connectionIndex)
		{
			if (connectionObject != null)
			{
				if (ConnectionCheck(connectionObject.prefabScript, connectionIndex, 0, connectionCheck: true))
				{
					return ConnectToStartExt(connectionObject, connectionIndex, autoAlign: false);
				}
				return false;
			}
			return false;
		}

		public bool ConnectToStart(ERConnection connectionObject, int connectionIndex, bool autoAlign)
		{
			if (connectionObject != null)
			{
				if (ConnectionCheck(connectionObject.prefabScript, connectionIndex, 0, connectionCheck: true))
				{
					OQOCQDQODD.OOQODOCQOD(connectionObject.prefabScript, roadScript, connectionIndex, 0);
					return ConnectToStartExt(connectionObject, connectionIndex, autoAlign);
				}
				return false;
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
			OQOCQDQODD.ODCQDDOQOQ(roadScript, tmpCenterPoint, connectionObject.prefabScript, connectionIndex, reverse: true, uvReverse: true, autoAlign);
			if (connectionObject.prefabScript.isIConnector)
			{
				Refresh();
			}
			roadScript.baseScript.UpdateSideObjectsInScene();
			return true;
		}

		public bool ConnectToEnd(ERConnection connectionObject)
		{
			if (connectionObject != null)
			{
				if (connectionObject.prefabScript.isFlexConnector)
				{
					if (ConnectionCheck(connectionObject.prefabScript, -1, 1, connectionCheck: false))
					{
						if (roadScript.markersExt[roadScript.markersExt.Count - 1].position == connectionObject.prefabScript.transform.position)
						{
							roadScript.markersExt[roadScript.markersExt.Count - 1].position = Vector3.Lerp(roadScript.markersExt[roadScript.markersExt.Count - 2].position, roadScript.markersExt[roadScript.markersExt.Count - 1].position, 0.99f);
							Refresh();
						}
						connectionObject.prefabScript.OQQCDDOQOQ(roadScript, 1);
						return true;
					}
					return false;
				}
				return false;
			}
			return false;
		}

		public bool ConnectToEnd(ERConnection connectionObject, int connectionIndex)
		{
			if (connectionObject != null)
			{
				if (ConnectionCheck(connectionObject.prefabScript, connectionIndex, 1, connectionCheck: true))
				{
					return ConnectToEndEx(connectionObject, connectionIndex, autoAlign: false);
				}
				return false;
			}
			return false;
		}

		public bool ConnectToEnd(ERConnection connectionObject, int connectionIndex, bool autoAlign)
		{
			if (connectionObject != null)
			{
				if (ConnectionCheck(connectionObject.prefabScript, connectionIndex, 1, connectionCheck: true))
				{
					OQOCQDQODD.OOQODOCQOD(connectionObject.prefabScript, roadScript, connectionIndex, 1);
					return ConnectToEndEx(connectionObject, connectionIndex, autoAlign);
				}
				return false;
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
			OQOCQDQODD.ODCQDDOQOQ(roadScript, tmpCenterPoint, connectionObject.prefabScript, connectionIndex, reverse: false, uvReverse: false, autoAlign);
			if (connectionObject.prefabScript.isIConnector)
			{
				Refresh();
			}
			roadScript.baseScript.UpdateSideObjectsInScene();
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
			ERCrossingPrefabs eRCrossingPrefabs = roadScript.baseScript.OOCOQDCODD(connectionObject.prefabScript.gameObject, roadScript, 0, -1);
			roadScript.baseScript.UpdateSideObjectsInScene();
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
			ERCrossingPrefabs eRCrossingPrefabs = roadScript.baseScript.OOCOQDCODD(connectionObject.prefabScript.gameObject, roadScript, roadScript.markersExt.Count - 1, -1);
			roadScript.baseScript.UpdateSideObjectsInScene();
			return new ERConnection(eRCrossingPrefabs.gameObject, eRCrossingPrefabs.gameObject.name);
		}

		public ERConnection AttachToStart(ERConnection OQCQQDQOCD, int connectionIndex)
		{
			if (roadScript.closedTrack)
			{
				return null;
			}
			if (roadScript.startPrefabScript != null)
			{
				return null;
			}
			if (roadScript.endPrefabScript != null && !ConnectionMatch(OQCQQDQOCD))
			{
				return null;
			}
			ERCrossingPrefabs eRCrossingPrefabs = roadScript.baseScript.OOCOQDCODD(OQCQQDQOCD.prefabScript.gameObject, roadScript, 0, connectionIndex);
			roadScript.baseScript.UpdateSideObjectsInScene();
			return new ERConnection(eRCrossingPrefabs.gameObject, eRCrossingPrefabs.gameObject.name);
		}

		public ERConnection AttachToEnd(ERConnection connectionInstance, int connectionIndex)
		{
			if (connectionInstance == null)
			{
				Debug.LogError("EasyRoad3D: NullReferenceException: The connectionInstance is not set to an instance of ERConnection");
				return null;
			}
			if (roadScript.closedTrack)
			{
				return null;
			}
			if (roadScript.endPrefabScript != null)
			{
				return null;
			}
			if (roadScript.startPrefabScript != null && !ConnectionMatch(connectionInstance))
			{
				return null;
			}
			ERCrossingPrefabs eRCrossingPrefabs = roadScript.baseScript.OOCOQDCODD(connectionInstance.prefabScript.gameObject, roadScript, roadScript.markersExt.Count - 1, connectionIndex);
			roadScript.baseScript.UpdateSideObjectsInScene();
			return new ERConnection(eRCrossingPrefabs.gameObject, eRCrossingPrefabs.gameObject.name);
		}

		public Vector3 GetCenterPoint(Vector3 position)
		{
			int splinePointByPosition = roadScript.GetSplinePointByPosition(position);
			if (splinePointByPosition > 0 && splinePointByPosition < roadScript.soSplinePoints.Count - 1)
			{
				float num = Vector3.Distance(roadScript.soSplinePoints[splinePointByPosition - 1], position);
				float num2 = Vector3.Distance(position, roadScript.soSplinePoints[splinePointByPosition + 1]);
				if (num < num2)
				{
					return OQQOCDQCQD.OCOOQOQCDC(roadScript.soSplinePoints[splinePointByPosition - 1], roadScript.soSplinePoints[splinePointByPosition], position);
				}
				return OQQOCDQCQD.OCOOQOQCDC(roadScript.soSplinePoints[splinePointByPosition + 1], roadScript.soSplinePoints[splinePointByPosition], position);
			}
			return roadScript.soSplinePoints[splinePointByPosition];
		}

		public ERConnection InsertFlexConnector(Vector3 position, ERRoad road2, int markerIndex, out ERRoad road3)
		{
			road3 = null;
			if (road2 == null || roadScript.roadType == 0.0 || roadScript.GetRoadType() == null || road2.roadScript.roadType == 0.0 || road2.roadScript.GetRoadType() == null)
			{
				Debug.LogError("EasyRoads3D: valid road types for the involved road objects are required for Flex Connectors.");
				return null;
			}
			if (markerIndex < 0 || markerIndex >= road2.roadScript.markersExt.Count)
			{
				Debug.LogError("EasyRoads3D: passed the marker index does not exist for road2.");
				return null;
			}
			int splinePointByPosition = roadScript.GetSplinePointByPosition(position);
			Vector3 vector = ((splinePointByPosition <= 0) ? (roadScript.soSplinePoints[1] - roadScript.soSplinePoints[0]).normalized : (roadScript.soSplinePoints[splinePointByPosition] - roadScript.soSplinePoints[splinePointByPosition - 1]).normalized);
			Vector3 to = ((markerIndex == 0) ? (road2.roadScript.soSplinePoints[1] - road2.roadScript.soSplinePoints[0]).normalized : (road2.roadScript.soSplinePoints[road2.roadScript.markersExt[markerIndex].startSplinePoint - 1] - road2.roadScript.soSplinePoints[road2.roadScript.markersExt[markerIndex].startSplinePoint - 2]).normalized);
			float num = Vector3.Angle(vector, to);
			if (num < ERModularBase.minSnapAngle || num > ERModularBase.maxSnapAngle)
			{
				Debug.LogError("EasyRoads3D: The angle between the two road objects is too sharp.");
				return null;
			}
			int marker = 0;
			ERRoad eRRoad = (road3 = OCOOODDOOQ(roadScript.baseScript, roadScript, splinePointByPosition, position, ref marker));
			GameObject gameObject = new GameObject(ERCrossingPrefabs.SetFlexConnectorName(roadScript.baseScript));
			if (roadScript.baseScript != null)
			{
				roadScript.baseScript.OCDCCCQCCQ = gameObject;
			}
			gameObject.transform.position = position;
			ERConnectionParent eRConnectionParent = (ERConnectionParent)UnityEngine.Object.FindObjectOfType(typeof(ERConnectionParent));
			if (eRConnectionParent != null)
			{
				gameObject.transform.parent = eRConnectionParent.transform;
			}
			ERCrossingPrefabs eRCrossingPrefabs = gameObject.AddComponent<ERCrossingPrefabs>();
			eRCrossingPrefabs.isFlexConnector = true;
			eRCrossingPrefabs.baseScript = roadScript.baseScript;
			eRCrossingPrefabs.crossingsScript = gameObject.AddComponent<ERCrossings>();
			eRCrossingPrefabs.crossingsScript.prefabScript = eRCrossingPrefabs;
			eRCrossingPrefabs.crossingsScript.baseScript = roadScript.baseScript;
			Vector3 zero = Vector3.zero;
			Vector3 zero2 = Vector3.zero;
			for (int i = 0; i < 3; i++)
			{
				QDOODOQQDQODD qDOODOQQDQODD = new QDOODOQQDQODD();
				qDOODOQQDQODD.roadType = roadScript.roadType;
				eRCrossingPrefabs.crossingElements.Add(qDOODOQQDQODD);
				switch (i)
				{
				case 0:
					qDOODOQQDQODD.connectedRoad = roadScript;
					qDOODOQQDQODD.connectedMarker = roadScript.markersExt.Count - 1;
					if (marker == 0 && eRRoad == null)
					{
						roadScript.startPrefabScript = eRCrossingPrefabs;
						roadScript.startConnectionSegment = 0;
					}
					else
					{
						roadScript.endPrefabScript = eRCrossingPrefabs;
						roadScript.endConnectionSegment = 0;
					}
					continue;
				case 1:
					if (eRRoad != null)
					{
						qDOODOQQDQODD.connectedRoad = eRRoad.roadScript;
						qDOODOQQDQODD.connectedMarker = 0;
						eRRoad.roadScript.startPrefabScript = eRCrossingPrefabs;
						eRRoad.roadScript.startConnectionSegment = 1;
						continue;
					}
					break;
				}
				if (i != 2)
				{
					continue;
				}
				if (roadScript != road2.roadScript)
				{
					qDOODOQQDQODD.connectedRoad = road2.roadScript;
					qDOODOQQDQODD.connectedMarker = markerIndex;
					if (markerIndex == 0)
					{
						road2.roadScript.startPrefabScript = eRCrossingPrefabs;
						road2.roadScript.startConnectionSegment = 2;
					}
					else
					{
						road2.roadScript.endPrefabScript = eRCrossingPrefabs;
						road2.roadScript.endConnectionSegment = 2;
					}
				}
				else if (markerIndex == 0)
				{
					qDOODOQQDQODD.connectedRoad = roadScript;
					qDOODOQQDQODD.connectedMarker = markerIndex;
					roadScript.startPrefabScript = eRCrossingPrefabs;
					roadScript.startConnectionSegment = 2;
				}
				else
				{
					qDOODOQQDQODD.connectedRoad = eRRoad.roadScript;
					qDOODOQQDQODD.connectedMarker = eRRoad.roadScript.markersExt.Count - 1;
					eRRoad.roadScript.endPrefabScript = eRCrossingPrefabs;
					eRRoad.roadScript.endConnectionSegment = 2;
				}
			}
			ERSideWalkVecs.OCQCQODCOO(road2.roadScript, road2.roadScript, roadScript, eRCrossingPrefabs, zero, zero2);
			eRCrossingPrefabs.InitFlexConnector(updateRoadTypes: true);
			roadScript.baseScript.UpdateQueue();
			eRCrossingPrefabs.crossingsScript.OCOQDOOOQC(null);
			eRCrossingPrefabs.baseScript.UpdateSideObjectsInScene();
			return new ERConnection(eRCrossingPrefabs.gameObject, eRCrossingPrefabs.gameObject.name);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static ERRoad OCOOODDOOQ(ERModularBase scr, ERModularRoad road, int index, Vector3 pos, ref int marker)
		{
			Vector3 zero = Vector3.zero;
			zero = ((index >= 2) ? (road.soSplinePoints[index] - road.soSplinePoints[index - 2]).normalized : ((index != 1) ? (road.soSplinePoints[index + 1] - road.soSplinePoints[index]).normalized : (road.soSplinePoints[index] - road.soSplinePoints[index - 1]).normalized));
			if (road.markersExt.Count > 2)
			{
				int count = road.markersExt.Count;
				for (int i = 0; i < count - 1; i++)
				{
					if (road.markersExt[i].startSplinePoint > index || ((i >= count || road.markersExt[i + 1].startSplinePoint <= index) && i != count - 1))
					{
						continue;
					}
					float num = Vector3.Distance(road.markersExt[i].position, road.soSplinePoints[index]);
					float num2 = Vector3.Distance(road.markersExt[i + 1].position, road.soSplinePoints[index]);
					if ((i > 0 || num2 < 20f) && (num < 20f || num2 < 20f))
					{
						if (num < num2 && i != 0)
						{
							marker = i;
						}
						else
						{
							marker = i + 1;
						}
					}
					else
					{
						road.nodeWithinRange = -1;
						marker = road.OOODDDDQDO(pos);
					}
					break;
				}
			}
			else
			{
				road.markersExt.Insert(1, ERMarkerExt.CreateInstance(pos, road, 1));
				marker = 1;
			}
			bool flag = true;
			if (marker <= 1)
			{
				if (Vector3.Distance(road.markersExt[0].position, pos) < road.roadWidth)
				{
					flag = false;
					marker = 0;
				}
			}
			else if (marker >= road.markersExt.Count - 2 && Vector3.Distance(road.markersExt[road.markersExt.Count - 1].position, pos) < road.roadWidth)
			{
				flag = false;
				marker = road.markersExt.Count - 1;
			}
			ERSideWalkInstanceScript[] componentsInChildren = road.gameObject.GetComponentsInChildren<ERSideWalkInstanceScript>();
			ERSideWalkInstanceScript[] array = componentsInChildren;
			foreach (ERSideWalkInstanceScript eRSideWalkInstanceScript in array)
			{
				UnityEngine.Object.DestroyImmediate(eRSideWalkInstanceScript.gameObject);
			}
			ERModularRoad eRModularRoad = null;
			if (flag)
			{
				if (marker == 0)
				{
					marker = 1;
				}
				else if (marker == road.markersExt.Count - 1)
				{
					marker = road.markersExt.Count - 2;
				}
				eRModularRoad = OQOCQDQODD.ODOOOQCQCQ(road, marker);
				if (eRModularRoad != null)
				{
					scr.RoadObjectsSoUpdates.Add(eRModularRoad);
				}
			}
			Vector3 targetPos = pos + -zero * road.roadWidth;
			OQCQQCOOOO(road, ref marker, targetPos);
			targetPos = pos + zero * road.roadWidth;
			int index2 = 0;
			if (eRModularRoad != null)
			{
				eRModularRoad.road = null;
				OQCQQCOOOO(eRModularRoad, ref index2, targetPos);
				return new ERRoad(eRModularRoad);
			}
			return null;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void OQCQQCOOOO(ERModularRoad road, ref int index, Vector3 targetPos)
		{
			if (index != 0)
			{
				Vector3 position = road.markersExt[index].position;
				float num = Vector3.Distance(position, targetPos);
				bool flag = false;
				index--;
				while (index > 0 && !flag)
				{
					float num2 = Vector3.Distance(road.markersExt[index].position, targetPos);
					float num3 = Vector3.Distance(road.markersExt[index].position, position);
					if (num2 < num || num3 < 5f)
					{
						Vector3 vector = road.markersExt[index].position - road.markersExt[index + 1].position;
						vector.y = 0f;
						Vector3 to = road.markersExt[index].position - road.markersExt[index - 1].position;
						to.y = 0f;
						if (Vector3.Angle(vector, to) > 135f)
						{
							road.markersExt.RemoveAt(index);
						}
						else
						{
							road.markersExt[index].position = targetPos + Vector3.Normalize(vector) * 15f;
							flag = true;
						}
					}
					else
					{
						flag = true;
					}
					index--;
				}
				index = road.markersExt.Count - 1;
				return;
			}
			Vector3 position2 = road.markersExt[index].position;
			float num4 = Vector3.Distance(position2, targetPos);
			bool flag2 = false;
			index++;
			while (index < road.markersExt.Count - 1 && !flag2)
			{
				float num5 = Vector3.Distance(road.markersExt[index].position, targetPos);
				float num6 = Vector3.Distance(road.markersExt[index].position, position2);
				if (num5 < num4 || num6 < 5f)
				{
					Vector3 vector2 = road.markersExt[index].position - road.markersExt[index - 1].position;
					vector2.y = 0f;
					Vector3 to2 = road.markersExt[index].position - road.markersExt[index + 1].position;
					to2.y = 0f;
					if (Vector3.Angle(vector2, to2) > 135f)
					{
						road.markersExt.RemoveAt(index);
					}
					else
					{
						road.markersExt[index].position = targetPos + Vector3.Normalize(vector2) * 15f;
						flag2 = true;
					}
				}
				else
				{
					flag2 = true;
				}
				index++;
			}
			index = 0;
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

		public void SetCustomMarkerPoints(int markerIndex, List<Vector3> points)
		{
			if (markerIndex >= 0 && markerIndex < roadScript.markersExt.Count)
			{
				roadScript.markersExt[markerIndex].customPoints.Clear();
				roadScript.markersExt[markerIndex].customPoints.AddRange(points);
			}
		}

		public ERConnection InsertConnector(ERConnection connectionObject, int markerIndex, int connectionIndex1, int connectionIndex2, out ERRoad road)
		{
			if (connectionObject == null)
			{
				Debug.LogWarning("EasyRoads3D: The passed connectionObject is null ");
				road = null;
				return null;
			}
			if (roadScript.closedTrack)
			{
				roadScript.closedTrack = false;
			}
			int num = markerIndex;
			ERModularRoad eRModularRoad = roadScript;
			if (markerIndex < 0 || markerIndex >= eRModularRoad.markersExt.Count)
			{
				Debug.LogWarning("EasyRoads3D: road " + eRModularRoad.name + " no marker exists at index: " + markerIndex);
				road = null;
				return null;
			}
			Vector3 position = roadScript.markersExt[markerIndex].position;
			int num2 = 0;
			ERModularRoad eRModularRoad2 = null;
			if (num != 0 && num != eRModularRoad.markersExt.Count - 1)
			{
				eRModularRoad2 = OQOCQDQODD.ODOOOQCQCQ(eRModularRoad, num);
			}
			ERCrossingPrefabs eRCrossingPrefabs = roadScript.baseScript.OOCOQDCODD(connectionObject.prefabScript.gameObject, roadScript, roadScript.markersExt.Count - 1, connectionIndex1);
			ERConnection eRConnection = new ERConnection(eRCrossingPrefabs.gameObject, eRCrossingPrefabs.gameObject.name);
			if (markerIndex > 0 && markerIndex < roadScript.markersExt.Count - 1)
			{
				eRConnection.SetPosition(position);
			}
			ERRoad eRRoad = null;
			if (eRModularRoad2 != null)
			{
				eRModularRoad2.nodeWithinRange = 0;
				OQOCQDQODD.ODCQDDOQOQ(eRModularRoad2, eRCrossingPrefabs.transform.position, eRCrossingPrefabs, connectionIndex2, reverse: true, uvReverse: true, forceAutoRotate: false);
				eRRoad = new ERRoad(eRModularRoad2);
			}
			road = new ERRoad();
			road.roadScript = eRModularRoad2;
			eRModularRoad2.road = road;
			road.gameObject = eRModularRoad2.gameObject;
			Refresh();
			return eRConnection;
		}

		public void UnConnectStart(bool mergeRoadObjects = true)
		{
			bool flag = false;
			if (roadScript.startPrefabScript != null)
			{
				OQOCQDQODD.OOQOOOQODC(roadScript.baseScript, roadScript, 1, 0, 0, mergeRoadObjects);
				Refresh();
			}
		}

		public void UnConnectEnd(bool mergeRoadObjects = true)
		{
			bool flag = false;
			if (roadScript.endPrefabScript != null)
			{
				OQOCQDQODD.ODOCDQDQCO(roadScript.baseScript, roadScript, roadScript.markersExt.Count - 2, roadScript.markersExt.Count - 1, roadScript.markersExt.Count - 1, mergeRoadObjects);
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

		public void SnapToTerrain(bool flag, bool refresh = true)
		{
			roadScript.snapVertices = flag;
			roadScript.terrainDeformation = !flag;
			if (refresh)
			{
				Refresh();
			}
		}

		public void SnapToTerrain(bool flag, float offset, bool refresh = true)
		{
			roadScript.snapVertices = flag;
			roadScript.snapOffset = offset;
			roadScript.terrainDeformation = !flag;
			if (refresh)
			{
				Refresh();
			}
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

		public Vector2[] GetShapeNodes()
		{
			if (roadScript != null)
			{
				return roadScript.roadShape.ToArray();
			}
			return null;
		}

		public Vector2[] GetRoadShapeNodes(int markerIndex)
		{
			if (roadScript != null && roadScript.markersExt.Count > markerIndex)
			{
				return roadScript.markersExt[markerIndex].roadShape.ToArray();
			}
			return null;
		}

		public void SetRoadShapeNodes(int markerIndex, Vector2[] nodes)
		{
			if (roadScript != null && roadScript.markersExt.Count > markerIndex && nodes.Length == roadScript.markersExt[markerIndex].roadShape.Count)
			{
				roadScript.markersExt[markerIndex].roadShape = new List<Vector2>(nodes);
				Refresh();
			}
		}

		public void SetRoadShapeNodes(int[] markerIndexes, Vector2[] nodes)
		{
			if (!(roadScript != null) || nodes.Length != roadScript.roadShape.Count)
			{
				return;
			}
			for (int i = 0; i < markerIndexes.Length; i++)
			{
				if (roadScript.markersExt.Count > markerIndexes[i])
				{
					roadScript.markersExt[markerIndexes[i]].roadShape = new List<Vector2>(nodes);
				}
				Refresh();
			}
		}

		public void Clear()
		{
			if (roadScript != null)
			{
				roadScript.markersExt.Clear();
				if (roadScript.surfaceMesh != null && roadScript.surfaceMesh.GetComponent<MeshFilter>() != null && roadScript.surfaceMesh.GetComponent<MeshFilter>().sharedMesh != null)
				{
					roadScript.surfaceMesh.GetComponent<MeshFilter>().sharedMesh.Clear();
				}
				if (roadScript.gameObject.GetComponent<MeshFilter>() != null && roadScript.gameObject.GetComponent<MeshFilter>().sharedMesh != null)
				{
					roadScript.gameObject.GetComponent<MeshFilter>().sharedMesh.Clear();
				}
				int childCount = roadScript.transform.childCount;
				for (int num = childCount - 1; num > 0; num--)
				{
					UnityEngine.Object.DestroyImmediate(roadScript.transform.GetChild(num).gameObject);
				}
				if (roadScript.baseScript != null && roadScript.baseScript.OOOCDDCQCD == roadScript)
				{
					roadScript.baseScript.OODOOQQDQD = -1;
				}
			}
		}

		public void Destroy()
		{
			ERCrossingPrefabs startPrefabScript = roadScript.startPrefabScript;
			ERCrossingPrefabs endPrefabScript = roadScript.endPrefabScript;
			if (startPrefabScript != null && startPrefabScript.isIConnector && (bool)startPrefabScript.gameObject.GetComponent<ERIConnector>())
			{
				startPrefabScript.gameObject.GetComponent<ERIConnector>().ODDDQDQOOD(null);
			}
			if (endPrefabScript != null && endPrefabScript.isIConnector && (bool)endPrefabScript.gameObject.GetComponent<ERIConnector>())
			{
				endPrefabScript.gameObject.GetComponent<ERIConnector>().ODDDQDQOOD(null);
			}
			if (Application.isPlaying)
			{
				foreach (ERSORoadExt item in roadScript.soDataExt)
				{
					foreach (GameObject runtimeObject in item.runtimeObjects)
					{
						if (runtimeObject != null)
						{
							UnityEngine.Object.DestroyImmediate(runtimeObject);
						}
					}
				}
			}
			if (gameObject != null)
			{
				UnityEngine.Object.DestroyImmediate(gameObject);
			}
			roadScript = null;
		}

		public int GetLaneCount()
		{
			QDQDOOQQDQODD roadTypeElByID = QDQDOOQQDQODD.GetRoadTypeElByID(roadScript.baseScript.roadTypes, roadScript.roadType);
			if (roadTypeElByID != null)
			{
				if (roadTypeElByID.roadShapeData.isset)
				{
					return roadTypeElByID.roadShapeData.lanes.Count;
				}
				Debug.Log("EasyRoads3D: no lane data available for road type '" + roadTypeElByID.roadTypeName + "'");
			}
			else
			{
				Debug.Log("EasyRoads3D:  '" + roadScript.name + "' does not have a road type assigned");
			}
			return 0;
		}

		public int GetRightLaneCount()
		{
			QDQDOOQQDQODD roadTypeElByID = QDQDOOQQDQODD.GetRoadTypeElByID(roadScript.baseScript.roadTypes, roadScript.roadType);
			if (roadTypeElByID != null)
			{
				if (roadTypeElByID.roadShapeData.isset)
				{
					return roadTypeElByID.roadShapeData.rightLanes;
				}
				Debug.Log("EasyRoads3D: no lane data available for road type '" + roadTypeElByID.roadTypeName + "'");
			}
			else
			{
				Debug.Log("EasyRoads3D:  '" + roadScript.name + "' does not have a road type assigned");
			}
			return 0;
		}

		public int GetLeftLaneCount()
		{
			QDQDOOQQDQODD roadTypeElByID = QDQDOOQQDQODD.GetRoadTypeElByID(roadScript.baseScript.roadTypes, roadScript.roadType);
			if (roadTypeElByID != null)
			{
				if (roadTypeElByID.roadShapeData.isset)
				{
					return roadTypeElByID.roadShapeData.leftLanes;
				}
				Debug.Log("EasyRoads3D: no lane data available for road type '" + roadTypeElByID.roadTypeName + "'");
			}
			else
			{
				Debug.Log("EasyRoads3D:  '" + roadScript.name + "' does not have a road type assigned");
			}
			return 0;
		}

		public ERLaneData GetLaneData(int laneIndex)
		{
			if (roadScript.laneData.Count > laneIndex)
			{
				return roadScript.laneData[laneIndex];
			}
			return null;
		}

		public ERLaneData GetLaneData(int laneIndex, ERLaneDirection direction)
		{
			foreach (ERLaneData laneDatum in roadScript.laneData)
			{
				if (laneDatum.direction == direction && laneIndex == laneDatum.laneIndex)
				{
					return laneDatum;
				}
			}
			return null;
		}

		public Vector3[] GetLanePoints(int laneIndex, ERLaneDirection direction)
		{
			if (roadScript.oneWayRoad)
			{
				return roadScript.laneData[roadScript.laneData.Count - laneIndex - 1].points;
			}
			if (roadScript.baseScript.rightHandDriving == 0)
			{
			}
			foreach (ERLaneData laneDatum in roadScript.laneData)
			{
				if (laneDatum.direction == direction && laneIndex == laneDatum.laneIndex)
				{
					return laneDatum.points;
				}
			}
			return null;
		}

		public Vector3 GetLaneCenterPosition(Vector3 position)
		{
			int index;
			Vector3 forwardDirection;
			return GetLaneCenterPosition(position, out index, out forwardDirection);
		}

		public Vector3 GetLaneCenterPosition(Vector3 position, out int index, out Vector3 forwardDirection)
		{
			return roadScript.GetLaneDataCenterPosition(position, out index, out forwardDirection);
		}

		public float GetSpeedLimit()
		{
			if (roadScript.roadType != 0.0)
			{
				return QDQDOOQQDQODD.GetRoadTypeElByID(roadScript.baseScript.roadTypes, roadScript.roadType)?.speedLimit ?? 0f;
			}
			return 0f;
		}
	}
}
