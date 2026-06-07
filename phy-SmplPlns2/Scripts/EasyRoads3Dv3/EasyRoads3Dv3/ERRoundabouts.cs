using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[AddComponentMenu("")]
	public class ERRoundabouts : MonoBehaviour
	{
		public float roundAboutRadius = 10f;

		[HideInInspector]
		public float prevRoundAboutRadius = 10f;

		[HideInInspector]
		public int totalNodes = 0;

		[HideInInspector]
		public float roundAboutResolution = 1f;

		[HideInInspector]
		public float prevRoundAboutResolution = 1f;

		[HideInInspector]
		public float rDist = 0f;

		[HideInInspector]
		public Vector3 raStartPos;

		public float roundaboutWidth = 5f;

		[HideInInspector]
		public float prevRoundaboutWidth = 5f;

		public float uvTiling = 1f;

		[HideInInspector]
		public bool flipUVy = false;

		[HideInInspector]
		public int roadTypeInt = 0;

		[HideInInspector]
		public int prevRoadTypeInt = 0;

		public float roadWidth = 5f;

		[HideInInspector]
		public float prevRoadWidth = 5f;

		[HideInInspector]
		public bool lockLeftRightRoundingRadius = true;

		[HideInInspector]
		public float leftRoundingRadius = 2f;

		[HideInInspector]
		public float prevLeftRoundingRadius = 2f;

		[HideInInspector]
		public float rightRoundingRadius = 2f;

		[HideInInspector]
		public float prevRightRoundingRadius = 2f;

		public int roundingSegments = 5;

		public float connectionLength = 5f;

		public float maxRoadWidth = 0f;

		public float maxRoundingRadius = 0f;

		[HideInInspector]
		public List<Vector3> meshVecs = new List<Vector3>();

		[HideInInspector]
		public List<Vector3> mainRightPoints = new List<Vector3>();

		[HideInInspector]
		public List<Vector3> mainCenterPoints = new List<Vector3>();

		[HideInInspector]
		public List<Vector3> mainLeftPoints = new List<Vector3>();

		[HideInInspector]
		public List<Vector3> ODOQDCQOOQ = new List<Vector3>();

		[HideInInspector]
		public List<Vector2> mainRightPointsUVs = new List<Vector2>();

		[HideInInspector]
		public List<Vector2> mainCenterPointsUVs = new List<Vector2>();

		[HideInInspector]
		public List<Vector2> mainLeftPointsUVs = new List<Vector2>();

		[HideInInspector]
		public List<Vector2> ODOQDCQOOQUVs = new List<Vector2>();

		[HideInInspector]
		public List<Vector3> innerRoundaboutSidewalkV3 = new List<Vector3>();

		[HideInInspector]
		public List<Vector2> innerRoundaboutSidewalUV = new List<Vector2>();

		[HideInInspector]
		public List<int> innerRoundaboutSidewalTris = new List<int>();

		[HideInInspector]
		public Material innerRoundaboutSidewalkMaterial;

		[HideInInspector]
		public List<int> innerRoundaboutSidewalkIntsStart = new List<int>();

		[HideInInspector]
		public List<int> innerRoundaboutSidewalkIntsEnd = new List<int>();

		[HideInInspector]
		public int innerSidewalkSegments = 0;

		[HideInInspector]
		public Vector3 leftPoint;

		[HideInInspector]
		public Vector3 leftPoint1;

		[HideInInspector]
		public Vector3 rightPoint;

		[HideInInspector]
		public Vector3 rightPoint1;

		[HideInInspector]
		public Vector3 centerOnLine;

		[HideInInspector]
		public Vector3 leftOuterPoint;

		[HideInInspector]
		public Vector3 rightOuterPoint;

		[HideInInspector]
		public Vector3 pl;

		[HideInInspector]
		public Vector3 pr;

		[HideInInspector]
		public List<Vector3> edgePoints = new List<Vector3>();

		[HideInInspector]
		public int newSegmentInt = -1;

		[HideInInspector]
		public int prevNewSegmentInt = -1;

		[HideInInspector]
		public List<ERRoundaboutElement> connections = new List<ERRoundaboutElement>();

		[HideInInspector]
		public string[] QDOOOQOOQQQQD;

		[HideInInspector]
		public int selectedConnection = 0;

		[HideInInspector]
		public int selectedConnection2 = 0;

		[HideInInspector]
		public int activeConnection = 0;

		[HideInInspector]
		public int tmpSelectedConnection = 0;

		[HideInInspector]
		public int minStartInt = 1;

		[HideInInspector]
		public int maxEndInt = 0;

		[HideInInspector]
		public int centerInt = 0;

		[HideInInspector]
		public int leftOuterInt = 0;

		[HideInInspector]
		public int rightOuterInt = 0;

		[HideInInspector]
		public List<Vector3> leftOuterSegments = new List<Vector3>();

		[HideInInspector]
		public List<Vector3> leftInnerSegments = new List<Vector3>();

		[HideInInspector]
		public List<Vector3> rightOuterSegments = new List<Vector3>();

		[HideInInspector]
		public List<Vector3> rightInnerSegments = new List<Vector3>();

		[HideInInspector]
		public List<Vector2> leftOuterSegmentsUVs = new List<Vector2>();

		[HideInInspector]
		public List<Vector2> leftInnerSegmentsUVs = new List<Vector2>();

		[HideInInspector]
		public List<Vector2> rightOuterSegmentsUVs = new List<Vector2>();

		[HideInInspector]
		public List<Vector2> rightInnerSegmentsUVs = new List<Vector2>();

		[HideInInspector]
		public Vector3 outerCenterPoint;

		[HideInInspector]
		public bool blendFlag = false;

		[HideInInspector]
		public Material mainRoadMaterial;

		[HideInInspector]
		public Material roadMaterial;

		[HideInInspector]
		public Material connectionMaterial;

		[HideInInspector]
		public Material defaultConnectionMaterial;

		public double roadType = 0.0;

		[HideInInspector]
		public double roadTypeTimestamp = 0.0;

		[HideInInspector]
		public List<Vector3> innerRoundaboutPoints = new List<Vector3>();

		[HideInInspector]
		public List<Vector2> innerRoundaboutUVs = new List<Vector2>();

		[HideInInspector]
		public float innerSegmentDistance = 0.5f;

		[HideInInspector]
		public float innerSidewalkWidth1 = 1.5f;

		[HideInInspector]
		public float innerSidewalkWidth2 = 1.5f;

		[HideInInspector]
		public float innerCurbHeight = 0.25f;

		[HideInInspector]
		public float innerCurbDepth = 0.25f;

		[HideInInspector]
		public bool innerBeveledCurb = false;

		[HideInInspector]
		public float innerBeveledHeight = 0f;

		[HideInInspector]
		public float innerBeveledDepth = 0f;

		[HideInInspector]
		public bool innerOuterCurb = false;

		[HideInInspector]
		public bool innerRoadSideCurbUVControl = false;

		[HideInInspector]
		public bool innerOuterSideCurbUVControl = false;

		[HideInInspector]
		public Material innerSidewalkMaterial;

		[HideInInspector]
		public List<float> innerSidewalkUVs = new List<float>();

		[HideInInspector]
		public List<float> innerCurbUVs = new List<float>();

		[HideInInspector]
		public int selectedCorner = 0;

		[HideInInspector]
		public int selectedCornerPreset = 0;

		[HideInInspector]
		public int selectedSidewalkPreset = 0;

		[HideInInspector]
		public string sidewalkPresetName = "";

		[HideInInspector]
		public int innerRoundaboutPreset = 0;

		[HideInInspector]
		public bool leftFlag = true;

		[HideInInspector]
		public bool rightFlag = true;

		private bool vssss = false;

		[HideInInspector]
		public ERCrossingPrefabs prefabScript;

		[HideInInspector]
		public QDOODOQQDQODD connectionElement;

		[HideInInspector]
		public ERModularBase baseScript;

		[HideInInspector]
		public bool isSceneObject = true;

		[HideInInspector]
		public bool guiChanged = true;

		[HideInInspector]
		public string crossingName = "";

		[HideInInspector]
		public bool activeSidewalks = true;

		[HideInInspector]
		public bool newConnectionFlag = false;

		[HideInInspector]
		public Vector3 testIndentMiddlePoint = Vector3.zero;

		[HideInInspector]
		public List<QDQDOOQQDQODD> roadTypesDynamic = new List<QDQDOOQQDQODD>();

		private void ussst()
		{
		}

		public bool UpdateToRoadType(QDQDOOQQDQODD sourcePreset)
		{
			if (prefabScript == null)
			{
				Debug.LogWarning("EasyRoads3Dv3 Warning: Missing ER Crossing Prefabs script on: " + base.gameObject.name);
				return false;
			}
			bool flag = false;
			Material material = sourcePreset.connectionMaterial;
			if (material == null)
			{
				material = sourcePreset.roadMaterial;
			}
			List<int> list = new List<int>();
			for (int i = 0; i < connections.Count; i++)
			{
				if (connections[i].roadType == sourcePreset.id && connections[i].roadType != 0.0)
				{
					flag = true;
					prefabScript.crossingElements[i].roadTypeTimestamp = sourcePreset.timestamp;
					if (sourcePreset.roadWidth < maxRoadWidth)
					{
						connections[i].roadWidth = sourcePreset.roadWidth;
					}
					else
					{
						Debug.LogError("EasyRoads3Dv3 Alert: The '" + sourcePreset.roadTypeName + "' road width is too wide for roundabout: " + base.gameObject.name);
					}
					connections[i].roadMaterial = sourcePreset.roadMaterial;
					connections[i].connectionMaterial = material;
					if (selectedConnection == i && sourcePreset.roadWidth < maxRoadWidth)
					{
						roadWidth = sourcePreset.roadWidth;
						connectionMaterial = sourcePreset.connectionMaterial;
					}
					if (prefabScript.crossingElements[i].connectedRoad != null && prefabScript.crossingElements[i].connectedRoad.roadType == prefabScript.crossingElements[i].roadType)
					{
						list.Add(i);
					}
				}
			}
			if (flag)
			{
				OOODQQDOOD();
				OCODQOOOCQ();
				if (leftFlag && rightFlag)
				{
					OCOCDCDDOD();
					OCCCDCOOOC();
				}
				else
				{
					Debug.LogError("EasyRoads3Dv3 Alert: The '" + sourcePreset.roadTypeName + "' road width is too wide for roundabout: " + base.gameObject.name);
				}
			}
			for (int j = 0; j < list.Count; j++)
			{
				ERModularRoad connectedRoad = prefabScript.crossingElements[list[j]].connectedRoad;
				if ((bool)connectedRoad.startPrefabScript && (bool)connectedRoad.endPrefabScript)
				{
					if (connectedRoad.startPrefabScript == prefabScript)
					{
						connectedRoad.OODCDQQQDD(prefabScript, list[j], reverse: true, uvReverse: true, UpdateResolutionFlag: false);
						if (connectedRoad.roadShape[0].x < 0f)
						{
							connectedRoad.OODCDQQQDD(prefabScript, list[j], reverse: false, uvReverse: false, UpdateResolutionFlag: false);
						}
					}
				}
				else if (prefabScript.crossingElements[list[j]].connectedMarker == 0)
				{
					connectedRoad.OODCDQQQDD(prefabScript, list[j], reverse: true, uvReverse: true, UpdateResolutionFlag: false);
					if (connectedRoad.roadShape[0].x < 0f)
					{
						connectedRoad.OODCDQQQDD(prefabScript, list[j], reverse: false, uvReverse: false, UpdateResolutionFlag: false);
					}
				}
				else
				{
					connectedRoad.OODCDQQQDD(prefabScript, list[j], reverse: false, uvReverse: false, UpdateResolutionFlag: false);
					if (connectedRoad.roadShape[0].x < 0f)
					{
						connectedRoad.OODCDQQQDD(prefabScript, list[j], reverse: true, uvReverse: true, UpdateResolutionFlag: false);
					}
				}
				if (connectedRoad.flipRoadUVs)
				{
					connectedRoad.FlipRoadUVs(update: false);
				}
				connectedRoad.ODDDQDQOOD(ignorePrefabAlignment: true, forceAutoRotate: false);
			}
			return flag;
		}

		public void ResetData()
		{
			roundAboutRadius = prevRoundAboutRadius;
			roundAboutResolution = prevRoundAboutResolution;
			roundaboutWidth = prevRoundaboutWidth;
			newSegmentInt = prevNewSegmentInt;
			roadWidth = prevRoadWidth;
			leftRoundingRadius = prevLeftRoundingRadius;
			rightRoundingRadius = prevRightRoundingRadius;
			roadTypeInt = prevRoadTypeInt;
			if (connections.Count > 0 && selectedConnection >= 0 && connections.Count > selectedConnection)
			{
				connections[selectedConnection].roadWidth = connections[selectedConnection].prevRoadWidth;
				connections[selectedConnection].centerInt = connections[selectedConnection].prevCenterInt;
				connections[selectedConnection].leftRoundingRadius = connections[selectedConnection].prevLeftRoundingRadius;
				connections[selectedConnection].rightRoundingRadius = connections[selectedConnection].prevRightRoundingRadius;
				connections[selectedConnection].roadType = connections[selectedConnection].prevRoadType;
				connections[selectedConnection].roadTypeTimestamp = connections[selectedConnection].prevTimestamp;
			}
		}

		public void OCOCDCCODO()
		{
			int num = Mathf.RoundToInt(2f * roundAboutRadius * MathF.PI);
			float num2 = 360f / ((float)num * 1f) * roundAboutResolution;
			float num3 = 360f / num2;
			int count = connections.Count;
			float num4 = Mathf.Floor(num3 / (float)count);
			float num5 = num4 * (float)count;
			float num6 = (float)num / num5;
			float num7 = roadWidth * 2f;
			if (connections.Count > 0)
			{
				int num8 = connections[connections.Count - 1].rightOuterInt;
				if ((float)(mainLeftPoints.Count - num8) * num6 < num7)
				{
					Debug.LogWarning("EasyRoads3Dv3 Warning: Connections are added clockwise. There is no room for more connections, please increase the radius or reposition existing connections first");
					return;
				}
			}
			connections.Add(new ERRoundaboutElement());
			selectedConnection = (selectedCorner = connections.Count - 1);
			QDOOOQOOQQQQD = (prefabScript.QDOOOQOOQQQQD = new string[connections.Count]);
			int num9 = 0;
			for (int i = 0; i < connections.Count; i++)
			{
				QDOOOQOOQQQQD[i] = (prefabScript.QDOOOQOOQQQQD[i] = "Connection " + (i + 1));
				if (connections[i].rightOuterInt > num9)
				{
					num9 = connections[i].rightOuterInt;
				}
			}
			if (selectedConnection == 0)
			{
				num9 = 5;
			}
			prefabScript.crossingElements.Add(new QDOODOQQDQODD());
			QDOODOQQDQODD qDOODOQQDQODD = prefabScript.crossingElements[prefabScript.crossingElements.Count - 1];
			prefabScript.sidewalkControlElements.Add(new QDOQDSQOOQDDD(baseScript));
			if (prefabScript.sidewalkControlElements.Count > 1)
			{
				prefabScript.sidewalkControlElements[prefabScript.sidewalkControlElements.Count - 1].renderFlag = prefabScript.sidewalkControlElements[prefabScript.sidewalkControlElements.Count - 2].renderFlag;
			}
			else
			{
				prefabScript.sidewalkControlElements[prefabScript.sidewalkControlElements.Count - 1].renderFlag = activeSidewalks;
			}
			if (prefabScript.crossingElements.Count > 1)
			{
				prefabScript.crossingElements[prefabScript.crossingElements.Count - 1].includeRightSidewalk = prefabScript.crossingElements[prefabScript.crossingElements.Count - 2].includeLeftSidewalk;
				prefabScript.crossingElements[prefabScript.crossingElements.Count - 1].includeLeftSidewalk = prefabScript.crossingElements[0].includeRightSidewalk;
			}
			else
			{
				prefabScript.crossingElements[prefabScript.crossingElements.Count - 1].includeLeftSidewalk = activeSidewalks;
				prefabScript.crossingElements[prefabScript.crossingElements.Count - 1].includeRightSidewalk = activeSidewalks;
			}
			if (prefabScript.sidewalkControlElements[prefabScript.sidewalkControlElements.Count - 1].sidewalkMaterial == null && prefabScript.sidewalkControlElements.Count > 1)
			{
				prefabScript.sidewalkControlElements[prefabScript.sidewalkControlElements.Count - 1].sidewalkMaterial = prefabScript.sidewalkControlElements[prefabScript.sidewalkControlElements.Count - 2].sidewalkMaterial;
			}
			connections[selectedConnection].prefabElement = prefabScript.crossingElements.Count - 1;
			connections[selectedConnection].connectionMaterial = defaultConnectionMaterial;
			if (roadMaterial == null)
			{
				roadMaterial = baseScript.roadMaterial;
			}
			connections[selectedConnection].roadMaterial = roadMaterial;
			newSegmentInt = (connections[selectedConnection].centerInt = num9 + Mathf.RoundToInt((float)(mainCenterPoints.Count - num9) / 2f));
			connections[selectedConnection].positionPercentage = (float)newSegmentInt * 1f / ((float)mainLeftPoints.Count * 1f);
			GetConnectionData();
			newConnectionFlag = true;
		}

		public void OCCCDCOOOC()
		{
			if (connections.Count != 0)
			{
				connections[selectedConnection].roadWidth = roadWidth;
				connections[selectedConnection].roundingSegments = roundingSegments;
				connections[selectedConnection].lockLeftRightRoundingRadius = lockLeftRightRoundingRadius;
				connections[selectedConnection].leftRoundingRadius = leftRoundingRadius;
				connections[selectedConnection].rightRoundingRadius = rightRoundingRadius;
				connections[selectedConnection].connectionLength = connectionLength;
				connections[selectedConnection].centerInt = centerInt;
				connections[selectedConnection].outerCenterPoint = outerCenterPoint;
				connections[selectedConnection].leftOuterSegments = leftOuterSegments;
				connections[selectedConnection].leftInnerSegments = leftInnerSegments;
				connections[selectedConnection].rightOuterSegments = rightOuterSegments;
				connections[selectedConnection].rightInnerSegments = rightInnerSegments;
				connections[selectedConnection].leftFlag = leftFlag;
				connections[selectedConnection].rightFlag = rightFlag;
				connections[selectedConnection].blendFlag = blendFlag;
				connections[selectedConnection].connectionMaterial = connectionMaterial;
			}
		}

		public void GetConnectionData()
		{
			roadWidth = connections[selectedConnection].roadWidth;
			roundingSegments = connections[selectedConnection].roundingSegments;
			lockLeftRightRoundingRadius = connections[selectedConnection].lockLeftRightRoundingRadius;
			leftRoundingRadius = connections[selectedConnection].leftRoundingRadius;
			rightRoundingRadius = connections[selectedConnection].rightRoundingRadius;
			centerInt = connections[selectedConnection].centerInt;
			outerCenterPoint = connections[selectedConnection].outerCenterPoint;
			connectionLength = connections[selectedConnection].connectionLength;
			centerInt = connections[selectedConnection].centerInt;
			leftOuterSegments = connections[selectedConnection].leftOuterSegments;
			leftInnerSegments = connections[selectedConnection].leftInnerSegments;
			rightOuterSegments = connections[selectedConnection].rightOuterSegments;
			rightInnerSegments = connections[selectedConnection].rightInnerSegments;
			leftFlag = connections[selectedConnection].leftFlag;
			rightFlag = connections[selectedConnection].rightFlag;
			blendFlag = connections[selectedConnection].blendFlag;
			roadMaterial = connections[selectedConnection].roadMaterial;
			connectionMaterial = connections[selectedConnection].connectionMaterial;
			roadType = connections[selectedConnection].roadType;
			roadTypeInt = GetRoadPresetInt(roadType);
			roadTypeTimestamp = connections[selectedConnection].roadTypeTimestamp;
			newSegmentInt = centerInt;
			UpdateMinMaxInts();
		}

		public void UpdateMinMaxInts()
		{
			if (selectedConnection == 0)
			{
				minStartInt = 0;
			}
			else
			{
				minStartInt = connections[selectedConnection - 1].rightOuterInt;
			}
			if (minStartInt < 0 || minStartInt > mainLeftPoints.Count)
			{
				minStartInt = 0;
			}
			if (prefabScript.crossingElements.Count > 0)
			{
				if (selectedConnection == connections.Count - 1)
				{
					maxEndInt = mainLeftPoints.Count - 2;
				}
				else
				{
					maxEndInt = connections[selectedConnection + 1].leftOuterInt;
				}
				if (maxEndInt < 0 || maxEndInt > mainLeftPoints.Count - 1)
				{
					maxEndInt = mainLeftPoints.Count - 1;
				}
				leftOuterInt = connections[selectedConnection].leftOuterInt;
				rightOuterInt = connections[selectedConnection].rightOuterInt;
			}
			else if (maxEndInt < 0 || maxEndInt > mainLeftPoints.Count - 1)
			{
				maxEndInt = mainLeftPoints.Count - 1;
			}
		}

		public void ChecknewSegmentInt()
		{
			if (newSegmentInt - connections[selectedConnection].intsFromCenter < minStartInt)
			{
				newSegmentInt = minStartInt + connections[selectedConnection].intsFromCenter;
			}
			if (newSegmentInt + connections[selectedConnection].intsFromCenter > maxEndInt)
			{
				newSegmentInt = maxEndInt - connections[selectedConnection].intsFromCenter;
			}
		}

		public int GetRoadPresetInt(double id)
		{
			string text = "";
			int result = 0;
			for (int i = 0; i < baseScript.roadTypes.Count; i++)
			{
				if (baseScript.roadTypes[i].id == id)
				{
					text = baseScript.roadTypes[i].roadTypeName;
					break;
				}
			}
			for (int j = 0; j < roadTypesDynamic.Count; j++)
			{
				if (roadTypesDynamic[j].id == id)
				{
					result = j + 1;
					break;
				}
			}
			return result;
		}

		public void ODODCODQCQ(ERRoundabouts source, bool refreshFlag)
		{
			roadTypesDynamic.Clear();
			if (prefabScript == null)
			{
				prefabScript = base.gameObject.GetComponent<ERCrossingPrefabs>();
			}
			if (prefabScript.baseScript == null)
			{
				prefabScript.baseScript = UnityEngine.Object.FindObjectOfType(typeof(ERModularBase)) as ERModularBase;
			}
			foreach (QDQDOOQQDQODD roadType in prefabScript.baseScript.roadTypes)
			{
				if (roadType.roadShape.Count == 2 && !roadType.isSideObject && !roadType.isCustomRoad)
				{
					roadTypesDynamic.Add(roadType);
				}
			}
			connections.Clear();
			for (int i = 0; i < source.connections.Count; i++)
			{
				connections.Add(new ERRoundaboutElement());
				connections[i].roadWidth = source.connections[i].roadWidth;
				connections[i].prevRoadWidth = source.connections[i].prevRoadWidth;
				connections[i].roundingSegments = source.connections[i].roundingSegments;
				connections[i].lockLeftRightRoundingRadius = source.connections[i].lockLeftRightRoundingRadius;
				connections[i].leftRoundingRadius = source.connections[i].leftRoundingRadius;
				connections[i].prevLeftRoundingRadius = source.connections[i].prevLeftRoundingRadius;
				connections[i].rightRoundingRadius = source.connections[i].rightRoundingRadius;
				connections[i].prevRightRoundingRadius = source.connections[i].prevRightRoundingRadius;
				connections[i].connectionLength = source.connections[i].connectionLength;
				connections[i].centerInt = source.connections[i].centerInt;
				connections[i].prevCenterInt = source.connections[i].prevCenterInt;
				connections[i].positionPercentage = source.connections[i].positionPercentage;
				connections[i].leftOuterInt = source.connections[i].leftOuterInt;
				connections[i].rightOuterInt = source.connections[i].rightOuterInt;
				connections[i].intsFromCenter = source.connections[i].intsFromCenter;
				connections[i].outerCenterPoint = source.connections[i].outerCenterPoint;
				connections[i].blendFlag = source.connections[i].blendFlag;
				connections[i].roadMaterial = source.connections[i].roadMaterial;
				connections[i].connectionMaterial = source.connections[i].connectionMaterial;
				connections[i].prefabElement = source.connections[i].prefabElement;
				connections[i].roadType = source.connections[i].roadType;
				connections[i].prevRoadType = source.connections[i].prevRoadType;
				connections[i].roadTypeTimestamp = source.connections[i].roadTypeTimestamp;
				connections[i].prevTimestamp = source.connections[i].prevTimestamp;
			}
			ERCrossingPrefabs component = source.gameObject.GetComponent<ERCrossingPrefabs>();
			if (component != null)
			{
				for (int j = 0; j < component.crossingElements.Count; j++)
				{
					prefabScript.crossingElements.Add(new QDOODOQQDQODD());
					prefabScript.crossingElements[j].rotationPriority = component.crossingElements[j].rotationPriority;
					prefabScript.crossingElements[j].includeLeftSidewalk = component.crossingElements[j].includeLeftSidewalk;
					prefabScript.crossingElements[j].includeRightSidewalk = component.crossingElements[j].includeRightSidewalk;
					prefabScript.crossingElements[j].roadMaterial = component.crossingElements[j].roadMaterial;
					prefabScript.crossingElements[j].roadType = component.crossingElements[j].roadType;
					prefabScript.crossingElements[j].roadTypeTimestamp = component.crossingElements[j].roadTypeTimestamp;
					prefabScript.sidewalkControlElements.Add(new QDOQDSQOOQDDD(UnityEngine.Object.FindObjectOfType(typeof(ERModularBase)) as ERModularBase));
					if (component.sidewalkControlElements.Count > j)
					{
						prefabScript.sidewalkControlElements[j].crossingElementLeftIndex = component.sidewalkControlElements[j].crossingElementLeftIndex;
						prefabScript.sidewalkControlElements[j].crossingElementRightIndex = component.sidewalkControlElements[j].crossingElementRightIndex;
						prefabScript.sidewalkControlElements[j].centerHandleV3 = component.sidewalkControlElements[j].centerHandleV3;
						prefabScript.sidewalkControlElements[j].leftHandleV3 = component.sidewalkControlElements[j].leftHandleV3;
						prefabScript.sidewalkControlElements[j].rightHandleV3 = component.sidewalkControlElements[j].rightHandleV3;
						prefabScript.sidewalkControlElements[j].renderFlag = component.sidewalkControlElements[j].renderFlag;
						prefabScript.sidewalkControlElements[j].leftConnectionHandle = component.sidewalkControlElements[j].leftConnectionHandle;
						prefabScript.sidewalkControlElements[j].rightConnectionHandle = component.sidewalkControlElements[j].rightConnectionHandle;
						prefabScript.sidewalkControlElements[j].sidewalkWidth1 = component.sidewalkControlElements[j].sidewalkWidth1;
						prefabScript.sidewalkControlElements[j].sidewalkWidth2 = component.sidewalkControlElements[j].sidewalkWidth2;
						prefabScript.sidewalkControlElements[j].curbHeight = component.sidewalkControlElements[j].curbHeight;
						prefabScript.sidewalkControlElements[j].curbDepth = component.sidewalkControlElements[j].curbDepth;
						prefabScript.sidewalkControlElements[j].beveledCurb = component.sidewalkControlElements[j].beveledCurb;
						prefabScript.sidewalkControlElements[j].beveledHeight = component.sidewalkControlElements[j].beveledHeight;
						prefabScript.sidewalkControlElements[j].beveledDepth = component.sidewalkControlElements[j].beveledDepth;
						prefabScript.sidewalkControlElements[j].outerCurb = component.sidewalkControlElements[j].outerCurb;
						prefabScript.sidewalkControlElements[j].roadSideCurbUVControl = component.sidewalkControlElements[j].roadSideCurbUVControl;
						prefabScript.sidewalkControlElements[j].outerSideCurbUVControl = component.sidewalkControlElements[j].outerSideCurbUVControl;
						prefabScript.sidewalkControlElements[j].sidewalkMaterial = component.sidewalkControlElements[j].sidewalkMaterial;
						prefabScript.sidewalkControlElements[j].sidewalkUVs = new List<float>(component.sidewalkControlElements[j].sidewalkUVs);
						prefabScript.sidewalkControlElements[j].curbUVs = new List<float>(component.sidewalkControlElements[j].curbUVs);
						prefabScript.sidewalkControlElements[j].lockUVs = component.sidewalkControlElements[j].lockUVs;
						prefabScript.sidewalkControlElements[j].cornerRadius = component.sidewalkControlElements[j].cornerRadius;
						prefabScript.sidewalkControlElements[j].cornerSegments = component.sidewalkControlElements[j].cornerSegments;
						prefabScript.sidewalkControlElements[j].innerSegmentDistance = component.sidewalkControlElements[j].innerSegmentDistance;
						prefabScript.sidewalkControlElements[j].startAngle = component.sidewalkControlElements[j].startAngle;
					}
				}
			}
			for (int k = 0; k < prefabScript.sidewalkControlElements.Count; k++)
			{
				prefabScript.sidewalkControlElements[k].renderFlag = component.sidewalkControlElements[k].renderFlag;
				prefabScript.sidewalkControlElements[k].leftConnectionHandle = component.sidewalkControlElements[k].leftConnectionHandle;
				prefabScript.sidewalkControlElements[k].rightConnectionHandle = component.sidewalkControlElements[k].rightConnectionHandle;
			}
			for (int l = 0; l < prefabScript.crossingElements.Count; l++)
			{
				prefabScript.crossingElements[l].includeLeftSidewalk = component.crossingElements[l].includeLeftSidewalk;
				prefabScript.crossingElements[l].includeRightSidewalk = component.crossingElements[l].includeRightSidewalk;
			}
			OOODQQDOOD();
			OCODQOOOCQ();
			OCOCDCDDOD();
		}

		public void OQCQDQCOQD()
		{
			ERCrossingPrefabs component = base.gameObject.GetComponent<ERCrossingPrefabs>();
			QDOODOQQDQODD qDOODOQQDQODD = component.crossingElements[connections[selectedConnection].prefabElement];
		}

		public void OODODCODQC(List<SidewalkPresetClass> sidewalkPresets, int el)
		{
			selectedSidewalkPreset = el;
			prefabScript.sidewalkControlElements[selectedCorner].sidewalkWidth1 = sidewalkPresets[selectedSidewalkPreset - 1].sidewalkWidth1;
			prefabScript.sidewalkControlElements[selectedCorner].sidewalkWidth2 = sidewalkPresets[selectedSidewalkPreset - 1].sidewalkWidth2;
			prefabScript.sidewalkControlElements[selectedCorner].curbHeight = sidewalkPresets[selectedSidewalkPreset - 1].curbHeight;
			prefabScript.sidewalkControlElements[selectedCorner].curbDepth = sidewalkPresets[selectedSidewalkPreset - 1].curbDepth;
			prefabScript.sidewalkControlElements[selectedCorner].beveledCurb = sidewalkPresets[selectedSidewalkPreset - 1].beveledCurb;
			prefabScript.sidewalkControlElements[selectedCorner].beveledHeight = sidewalkPresets[selectedSidewalkPreset - 1].beveledHeight;
			prefabScript.sidewalkControlElements[selectedCorner].beveledDepth = sidewalkPresets[selectedSidewalkPreset - 1].beveledDepth;
			prefabScript.sidewalkControlElements[selectedCorner].outerCurb = sidewalkPresets[selectedSidewalkPreset - 1].outerCurb;
			prefabScript.sidewalkControlElements[selectedCorner].roadSideCurbUVControl = sidewalkPresets[selectedSidewalkPreset - 1].roadSideCurbUVControl;
			prefabScript.sidewalkControlElements[selectedCorner].outerSideCurbUVControl = sidewalkPresets[selectedSidewalkPreset - 1].outerSideCurbUVControl;
			prefabScript.sidewalkControlElements[selectedCorner].sidewalkMaterial = sidewalkPresets[selectedSidewalkPreset - 1].sidewalkMaterial;
			prefabScript.sidewalkControlElements[selectedCorner].sidewalkUVs.Clear();
			prefabScript.sidewalkControlElements[selectedCorner].sidewalkUVs.AddRange(sidewalkPresets[selectedSidewalkPreset - 1].sidewalkUVs);
			prefabScript.sidewalkControlElements[selectedCorner].curbUVs.Clear();
			prefabScript.sidewalkControlElements[selectedCorner].curbUVs.AddRange(sidewalkPresets[selectedSidewalkPreset - 1].curbUVs);
			prefabScript.sidewalkControlElements[selectedCorner].lockUVs = sidewalkPresets[selectedSidewalkPreset - 1].lockUVs;
		}

		public void OOODQQDOOD()
		{
			vssss = false;
			if (QDOOOQOOQQQQD.Length != connections.Count)
			{
				QDOOOQOOQQQQD = new string[connections.Count];
				prefabScript.QDOOOQOOQQQQD = new string[connections.Count];
				for (int i = 0; i < connections.Count; i++)
				{
					QDOOOQOOQQQQD[i] = "Connection " + (i + 1);
					prefabScript.QDOOOQOOQQQQD[i] = "Connection " + (i + 1);
				}
				selectedConnection = 0;
			}
			if (selectedConnection >= connections.Count)
			{
				selectedConnection = 0;
			}
			int count = mainLeftPoints.Count;
			mainRightPoints.Clear();
			mainCenterPoints.Clear();
			mainLeftPoints.Clear();
			ODOQDCQOOQ.Clear();
			mainRightPointsUVs.Clear();
			mainCenterPointsUVs.Clear();
			mainLeftPointsUVs.Clear();
			ODOQDCQOOQUVs.Clear();
			innerRoundaboutPoints.Clear();
			int num = Mathf.RoundToInt(2f * roundAboutRadius * MathF.PI);
			float num2 = 360f / ((float)num * 1f) * roundAboutResolution;
			float num3 = 360f / num2;
			int count2 = connections.Count;
			float num4 = Mathf.Floor(num3 / (float)count2);
			float num5 = num4 * (float)count2;
			num2 = 360f / num5;
			Vector3 position = base.transform.position;
			rDist = 0f;
			float num6 = 0f;
			Vector3 zero = Vector3.zero;
			int num7 = 0;
			float num8 = 0f;
			Vector3 zero2;
			Vector3 vector = (zero2 = Vector3.zero);
			float num9 = roundaboutWidth * 0.5f;
			float num10 = 0f;
			float y = 0f;
			float num11 = 5f;
			while (num6 < 360f + num8)
			{
				zero.x = roundAboutRadius * Mathf.Cos((0f - num6 + num8) * (MathF.PI / 180f));
				zero.z = roundAboutRadius * Mathf.Sin((0f - num6 + num8) * (MathF.PI / 180f));
				Vector3 normalized = (zero - Vector3.zero).normalized;
				mainLeftPoints.Add(zero + normalized * num9);
				mainRightPoints.Add(zero + -normalized * num9);
				mainCenterPoints.Add(zero);
				if (num7 > 0)
				{
					num10 += Vector3.Distance(zero, vector);
					y = num10 / num11 * uvTiling;
				}
				mainLeftPointsUVs.Add(new Vector2(0f, y));
				mainCenterPointsUVs.Add(new Vector2(0.5f, y));
				mainRightPointsUVs.Add(new Vector2(1f, y));
				num6 += num2;
				if (num7 == 0)
				{
					zero2 = (raStartPos = zero);
				}
				else
				{
					rDist += Vector3.Distance(vector, zero);
				}
				num7++;
				vector = zero;
			}
			totalNodes = mainCenterPoints.Count;
			if (newConnectionFlag)
			{
				for (int j = 1; j < connections.Count; j++)
				{
					connections[j].centerInt = connections[j - 1].centerInt + Mathf.RoundToInt(num4);
					newSegmentInt = connections[j].centerInt;
				}
			}
			if (mainLeftPoints[0] != mainLeftPoints[mainLeftPoints.Count - 1])
			{
				mainLeftPoints.Add(mainLeftPoints[0]);
				mainRightPoints.Add(mainRightPoints[0]);
				mainCenterPoints.Add(mainCenterPoints[0]);
				num10 += Vector3.Distance(mainCenterPoints[0], mainCenterPoints[1]);
				y = num10 / num11 * uvTiling;
				mainLeftPointsUVs.Add(new Vector2(0f, y));
				mainCenterPointsUVs.Add(new Vector2(0.5f, y));
				mainRightPointsUVs.Add(new Vector2(1f, y));
			}
			float num12 = Vector3.Distance(mainLeftPoints[0], Vector3.zero) * 2f;
			maxRoadWidth = 0.5f * num12;
			maxRoundingRadius = (num12 - roadWidth) / 4f;
			if (count != 0 && mainLeftPoints.Count != count && !newConnectionFlag)
			{
				float num13 = (float)mainLeftPoints.Count * 1f / ((float)count * 1f);
				for (int k = 0; k < connections.Count; k++)
				{
					if (connections[k].positionPercentage == 0f)
					{
						connections[k].positionPercentage = (float)connections[k].centerInt * 1f / ((float)count * 1f);
					}
					connections[k].centerInt = Mathf.RoundToInt(connections[k].positionPercentage * (float)mainLeftPoints.Count);
					if (k == selectedConnection)
					{
						newSegmentInt = connections[k].centerInt;
					}
				}
			}
			innerRoundaboutSidewalkV3.Clear();
			innerRoundaboutSidewalUV.Clear();
			innerRoundaboutSidewalTris.Clear();
			innerRoundaboutSidewalkIntsStart.Clear();
			innerRoundaboutSidewalkIntsEnd.Clear();
			if (innerRoundaboutPreset != 0)
			{
				ERRoundaboutsFunctions.BuildInnerRoundaboutSidewalkData(this, baseScript, mainRightPoints, ref innerRoundaboutSidewalkV3, ref innerRoundaboutSidewalUV, ref innerRoundaboutSidewalTris, ref innerSidewalkSegments);
			}
		}

		public void OCODQOOOCQ()
		{
			if (QDOOOQOOQQQQD.Length != connections.Count)
			{
				QDOOOQOOQQQQD = new string[connections.Count];
				prefabScript.QDOOOQOOQQQQD = new string[connections.Count];
				for (int i = 0; i < connections.Count; i++)
				{
					QDOOOQOOQQQQD[i] = "Connection " + (i + 1);
					prefabScript.QDOOOQOOQQQQD[i] = "Connection " + (i + 1);
				}
				selectedConnection = 0;
			}
			if (selectedConnection >= connections.Count)
			{
				selectedConnection = 0;
			}
			centerInt = newSegmentInt;
			OCCCDCOOOC();
			activeConnection = selectedConnection;
			leftFlag = (rightFlag = true);
			for (int j = 0; j < connections.Count; j++)
			{
				if (connections[j].roadMaterial == null)
				{
				}
				ODQQQQOCOC(j);
				if (!connections[j].leftFlag)
				{
					leftFlag = false;
				}
				if (!connections[j].rightFlag)
				{
					rightFlag = false;
				}
			}
			newConnectionFlag = false;
			if (leftFlag && rightFlag)
			{
				ERRoundaboutsFunctions.OCQCDOQCCO(this);
			}
		}

		public void ODQQQQOCOC(int currentIndex)
		{
			if (connections.Count == 0)
			{
				return;
			}
			connections[currentIndex].leftSidewalkV3.Clear();
			connections[currentIndex].rightSidewalkV3.Clear();
			connections[currentIndex].leftSidewalkUV.Clear();
			connections[currentIndex].rightSidewalkUV.Clear();
			connections[currentIndex].leftSidewalkTris.Clear();
			connections[currentIndex].rightSidewalkTris.Clear();
			connections[currentIndex].roadConnectionTris.Clear();
			connections[currentIndex].leftSidewalkSourceVecs.Clear();
			connections[currentIndex].rightSidewalkSourceVecs.Clear();
			connections[currentIndex].rightIndentvecs.Clear();
			connections[currentIndex].rightSurroundingvecs.Clear();
			connections[currentIndex].leftIndentvecs.Clear();
			connections[currentIndex].leftSurroundingvecs.Clear();
			connections[currentIndex].innerRoundaboutPoints.Clear();
			connections[currentIndex].leftFlag = true;
			connections[currentIndex].rightFlag = true;
			int num = connections[currentIndex].centerInt;
			int num2 = connections[currentIndex].leftOuterInt;
			int num3 = connections[currentIndex].rightOuterInt;
			if (prefabScript.sidewalkControlElements.Count < connections.Count)
			{
				for (int i = prefabScript.sidewalkControlElements.Count; i < connections.Count; i++)
				{
					prefabScript.sidewalkControlElements.Add(new QDOQDSQOOQDDD(baseScript));
				}
			}
			float num4 = connections[currentIndex].roadWidth + 2f * connections[currentIndex].leftRoundingRadius;
			float num5 = 0f;
			int num6 = 1;
			bool flag = true;
			while (num5 < num4)
			{
				if (connections[currentIndex].centerInt - num6 < 0)
				{
					rightFlag = (connections[currentIndex].rightFlag = false);
					flag = false;
					return;
				}
				if (connections[currentIndex].centerInt + num6 >= mainLeftPoints.Count)
				{
					leftFlag = (connections[currentIndex].leftFlag = false);
					flag = false;
					return;
				}
				leftOuterPoint = mainLeftPoints[connections[currentIndex].centerInt - num6];
				rightOuterPoint = mainLeftPoints[connections[currentIndex].centerInt + num6];
				num5 = Vector3.Distance(leftOuterPoint, rightOuterPoint);
				if (num5 > num4)
				{
					break;
				}
				num6++;
				if (connections[currentIndex].centerInt - num6 <= 0)
				{
					leftFlag = (connections[currentIndex].leftFlag = false);
					Debug.Log("connection " + currentIndex + " cannot be updated, move the position forward");
					flag = false;
					ResetData();
					break;
				}
				if (newSegmentInt + num6 >= mainLeftPoints.Count - 1)
				{
					rightFlag = (connections[currentIndex].rightFlag = false);
					Debug.Log("connection " + currentIndex + " cannot be updated, move the position backwards");
					flag = false;
					if (!newConnectionFlag)
					{
						ResetData();
					}
					break;
				}
			}
			if (!flag)
			{
				return;
			}
			centerOnLine = Vector3.Lerp(leftOuterPoint, rightOuterPoint, 0.5f);
			Vector3 normalized = (rightOuterPoint - leftOuterPoint).normalized;
			leftPoint = centerOnLine - normalized * 0.5f * num4;
			rightPoint = centerOnLine + normalized * 0.5f * num4;
			normalized = (mainLeftPoints[connections[currentIndex].centerInt] - mainCenterPoints[connections[currentIndex].centerInt]).normalized;
			pl = leftPoint + normalized * 15f;
			pr = rightPoint + normalized * 15f;
			Vector3 p = mainLeftPoints[connections[currentIndex].centerInt - num6];
			Vector3 p2 = mainLeftPoints[connections[currentIndex].centerInt - num6 + 1];
			leftPoint1 = OCDCQCDDCC(leftPoint, pl, p, p2);
			Vector3 p3 = mainLeftPoints[connections[currentIndex].centerInt + num6];
			Vector3 p4 = mainLeftPoints[connections[currentIndex].centerInt + num6 - 1];
			rightPoint1 = OCDCQCDDCC(rightPoint, pr, p3, p4);
			if (currentIndex == activeConnection)
			{
				edgePoints.Clear();
				edgePoints.Add(leftPoint1);
				edgePoints.Add(rightPoint1);
			}
			connections[currentIndex].centerInt = connections[currentIndex].centerInt;
			connections[currentIndex].leftOuterInt = connections[currentIndex].centerInt - num6;
			connections[currentIndex].rightOuterInt = connections[currentIndex].centerInt + num6;
			connections[currentIndex].intsFromCenter = num6;
			if (selectedConnection == currentIndex && connections[currentIndex].centerInt != connections[currentIndex].prevCenterInt)
			{
				connections[currentIndex].positionPercentage = (float)connections[currentIndex].centerInt * 1f / ((float)mainLeftPoints.Count * 1f);
			}
			connections[currentIndex].outerCenterPoint = mainLeftPoints[connections[currentIndex].centerInt];
			for (int j = 0; j < connections.Count; j++)
			{
				if (j != currentIndex)
				{
					if (connections[currentIndex].leftOuterInt < connections[j].rightOuterInt + 1 && connections[currentIndex].leftOuterInt >= connections[j].leftOuterInt)
					{
						connections[currentIndex].leftFlag = false;
					}
					if (connections[currentIndex].rightOuterInt <= connections[j].rightOuterInt && connections[currentIndex].rightOuterInt >= connections[j].leftOuterInt)
					{
						connections[currentIndex].rightFlag = false;
					}
				}
			}
			if (connections[currentIndex].leftOuterInt < 0)
			{
				leftFlag = (connections[currentIndex].leftFlag = false);
			}
			if (connections[currentIndex].rightOuterInt >= mainLeftPoints.Count)
			{
				rightFlag = (connections[currentIndex].rightFlag = false);
			}
			for (int k = connections[currentIndex].leftOuterInt + 1; k < connections[currentIndex].rightOuterInt; k++)
			{
				connections[currentIndex].innerRoundaboutPoints.Add(mainLeftPoints[k]);
			}
			if (!connections[currentIndex].leftFlag || !connections[currentIndex].rightFlag)
			{
				if (currentIndex == selectedConnection)
				{
					newSegmentInt = num;
				}
				connections[currentIndex].centerInt = num;
				connections[currentIndex].leftOuterInt = num2;
				connections[currentIndex].rightOuterInt = num3;
				return;
			}
			OOOOOQODCQ(ref connections[currentIndex].leftOuterSegments, ref connections[currentIndex].leftInnerSegments, -1, connections[currentIndex].centerInt - num6, leftPoint1, rightPoint1, normalized, currentIndex);
			OOOOOQODCQ(ref connections[currentIndex].rightOuterSegments, ref connections[currentIndex].rightInnerSegments, 1, connections[currentIndex].centerInt + num6, leftPoint1, rightPoint1, normalized, currentIndex);
			ERRoundaboutsFunctions.OCDODOQQDO(this, currentIndex);
			OQCQODQQQQ(currentIndex);
			ERRoundaboutsFunctions.OCOCQQDOQD(this, currentIndex);
			connections[currentIndex].sceneSelectionV3 = Vector3.Lerp(connections[currentIndex].leftOuterSegments[connections[currentIndex].leftOuterSegments.Count - 1], connections[currentIndex].rightOuterSegments[connections[currentIndex].rightOuterSegments.Count - 1], 0.5f);
			float num7 = Vector3.Angle(Vector3.forward, mainLeftPoints[connections[currentIndex].centerInt]);
			if (OQQOCDQCQD.OQDDDQOOQO(Vector3.forward, mainLeftPoints[connections[currentIndex].centerInt], Vector3.up) == -1f)
			{
				num7 = 360f - num7;
			}
			prefabScript.crossingElements[currentIndex].connectionAngle = num7;
		}

		public void OOOOOQODCQ(ref List<Vector3> ODOQDCQOOQ, ref List<Vector3> innerSegmentPoints, int leftRight, int startElement, Vector3 leftPoint, Vector3 rightPoint, Vector3 forward, int currentIndex)
		{
			ODOQDCQOOQ.Clear();
			innerSegmentPoints.Clear();
			float num = roundAboutRadius + 0.5f * roundaboutWidth;
			Vector3 vector = mainLeftPoints[startElement];
			Vector3 vector2 = mainLeftPoints[startElement + leftRight * -1];
			Vector3 normalized = (vector2 - vector).normalized;
			if (leftRight == 1)
			{
				normalized = (vector - vector2).normalized;
			}
			Vector3 normalized2 = (rightPoint - leftPoint).normalized;
			float num2 = Vector3.Angle(normalized, normalized2);
			float num3 = 90f / ((float)connections[currentIndex].roundingSegments * 1f);
			float num4 = (90f - num2) / ((float)connections[currentIndex].roundingSegments * 1f);
			num4 = num3;
			if (leftRight == 1)
			{
				num4 *= -1f;
			}
			float num5 = connections[currentIndex].leftRoundingRadius * (num2 / 90f + 1f);
			centerOnLine = Vector3.Lerp(rightPoint, leftPoint, 0.5f);
			Vector3 vector3 = centerOnLine - normalized2 * (0.5f * connections[currentIndex].roadWidth + num5);
			if (leftRight == 1)
			{
				vector3 = centerOnLine + normalized2 * (0.5f * connections[currentIndex].roadWidth + num5);
			}
			Vector3 pivot = vector3 + forward * num5;
			vector3 = centerOnLine - normalized2 * 0.5f * connections[currentIndex].roadWidth;
			if (leftRight == 1)
			{
				vector3 = centerOnLine + normalized2 * 0.5f * connections[currentIndex].roadWidth;
			}
			Vector3 vector4 = vector3 + forward * num5;
			ODOQDCQOOQ.Add(vector4);
			float num6 = 10000f;
			float num7 = 10000f;
			Vector3 vector5;
			for (int i = 1; i < connections[currentIndex].roundingSegments - 1; i++)
			{
				vector5 = OOQOCODQOO(vector4, pivot, Quaternion.Euler(0f, num4 * (float)i, 0f));
				num6 = Vector3.Distance(Vector3.zero, vector5);
				if (num6 > num7)
				{
					break;
				}
				num7 = num6;
				ODOQDCQOOQ.Add(vector5);
				if (num6 < num)
				{
					break;
				}
			}
			Vector3 normalized3 = ODOQDCQOOQ[ODOQDCQOOQ.Count - 1].normalized;
			vector5 = Vector3.zero + normalized3 * num;
			ODOQDCQOOQ[ODOQDCQOOQ.Count - 1] = vector5;
			int num8 = connections[currentIndex].leftOuterInt - 2;
			if (num8 < 0)
			{
				num8 = 0;
			}
			for (int j = num8; j < mainLeftPoints.Count - 1; j++)
			{
				num6 = Vector3.Distance(mainLeftPoints[j], mainLeftPoints[j + 1]);
				num7 = Vector3.Distance(mainLeftPoints[j], vector5);
				if (num7 < num6)
				{
					if (leftRight == -1)
					{
						connections[currentIndex].leftOuterInt = j;
					}
					else
					{
						connections[currentIndex].rightOuterInt = j + 1;
					}
					break;
				}
			}
			if (leftRight == -1)
			{
				ODOQDCQOOQ.Reverse();
			}
			else
			{
				ODOQDCQOOQ.Reverse();
			}
			Vector3 normalized4 = (leftPoint - mainLeftPoints[startElement]).normalized;
			if (leftRight == 1)
			{
				normalized4 = (rightPoint - mainLeftPoints[startElement]).normalized;
			}
			normalized4 = new Vector3(normalized4.z, 0f, 0f - normalized4.x);
			if (leftRight == -1)
			{
				innerSegmentPoints.Add(leftPoint + normalized4 * innerSegmentDistance);
			}
			else
			{
				innerSegmentPoints.Add(rightPoint + -normalized4 * innerSegmentDistance);
			}
			for (int k = 1; k < ODOQDCQOOQ.Count - 1; k++)
			{
				normalized4 = (ODOQDCQOOQ[k] - ODOQDCQOOQ[k - 1]).normalized;
				normalized4 = new Vector3(normalized4.z, 0f, 0f - normalized4.x);
				if (leftRight == -1)
				{
					innerSegmentPoints.Add(ODOQDCQOOQ[k] + normalized4 * innerSegmentDistance);
				}
				else
				{
					innerSegmentPoints.Add(ODOQDCQOOQ[k] + -normalized4 * innerSegmentDistance);
				}
			}
			vector5 = ODOQDCQOOQ[ODOQDCQOOQ.Count - 1];
			vector4 = vector5 + forward * roundAboutResolution;
			normalized4 = (vector4 - ODOQDCQOOQ[ODOQDCQOOQ.Count - 1]).normalized;
			normalized4 = new Vector3(normalized4.z, 0f, 0f - normalized4.x);
			if (leftRight == -1)
			{
				innerSegmentPoints.Add(ODOQDCQOOQ[ODOQDCQOOQ.Count - 1] + normalized4 * innerSegmentDistance);
			}
			else
			{
				innerSegmentPoints.Add(ODOQDCQOOQ[ODOQDCQOOQ.Count - 1] + -normalized4 * innerSegmentDistance);
			}
			ODOQDCQOOQ.Add(vector4);
			innerSegmentPoints.Add(Vector3.zero);
		}

		public void OQCQODQQQQ(int currentIndex)
		{
			connections[currentIndex].leftOuterSegmentsUVs.Clear();
			connections[currentIndex].rightOuterSegmentsUVs.Clear();
			connections[currentIndex].innerRoundaboutUVs.Clear();
			Vector3 vA = connections[currentIndex].leftOuterSegments[connections[currentIndex].leftOuterSegments.Count - 1];
			Vector3 vB = connections[currentIndex].rightOuterSegments[connections[currentIndex].rightOuterSegments.Count - 1];
			Vector3 a = OQOQOOCDCC.OCOOQOQCDC(vA, vB, connections[currentIndex].leftOuterSegments[0]);
			float num = Vector3.Distance(a, connections[currentIndex].leftOuterSegments[0]);
			Vector3 vector = connections[currentIndex].rightOuterSegments[0];
			Vector3 vector2 = connections[currentIndex].leftOuterSegments[0];
			float num2 = Vector3.Distance(vector, vector2);
			for (int i = 0; i < connections[currentIndex].leftOuterSegments.Count; i++)
			{
				a = OQOQOOCDCC.OCOOQOQCDC(vA, vB, connections[currentIndex].leftOuterSegments[i]);
				float num3 = Vector3.Distance(a, connections[currentIndex].leftOuterSegments[i]) / num;
				a = OQOQOOCDCC.OCOOQOQCDC(vector, vector2, connections[currentIndex].leftOuterSegments[i]);
				float num4 = Vector3.Distance(a, connections[currentIndex].leftOuterSegments[i]) / num2;
				if (!flipUVy)
				{
					connections[currentIndex].leftOuterSegmentsUVs.Add(new Vector2(1f, num3));
				}
				else
				{
					connections[currentIndex].leftOuterSegmentsUVs.Add(new Vector2(1f, 1f - num3));
				}
			}
			for (int j = 0; j < connections[currentIndex].rightOuterSegments.Count; j++)
			{
				a = OQOQOOCDCC.OCOOQOQCDC(vA, vB, connections[currentIndex].rightOuterSegments[j]);
				float num3 = Vector3.Distance(a, connections[currentIndex].rightOuterSegments[j]) / num;
				a = OQOQOOCDCC.OCOOQOQCDC(vector, vector2, connections[currentIndex].rightOuterSegments[j]);
				float num4 = Vector3.Distance(a, connections[currentIndex].rightOuterSegments[j]) / num2;
				if (!flipUVy)
				{
					connections[currentIndex].rightOuterSegmentsUVs.Add(new Vector2(0f, num3));
				}
				else
				{
					connections[currentIndex].rightOuterSegmentsUVs.Add(new Vector2(0f, 1f - num3));
				}
			}
			for (int k = 0; k < connections[currentIndex].innerRoundaboutPoints.Count; k++)
			{
				a = OQOQOOCDCC.OCOOQOQCDC(vA, vB, connections[currentIndex].innerRoundaboutPoints[k]);
				float num3 = Vector3.Distance(a, connections[currentIndex].innerRoundaboutPoints[k]) / num;
				a = OQOQOOCDCC.OCOOQOQCDC(vector, vector2, connections[currentIndex].innerRoundaboutPoints[k]);
				float num4 = Vector3.Distance(a, vector) / num2;
				if (!flipUVy)
				{
					connections[currentIndex].innerRoundaboutUVs.Add(new Vector2(num4, num3));
				}
				else
				{
					connections[currentIndex].innerRoundaboutUVs.Add(new Vector2(num4, 1f - num3));
				}
			}
		}

		public void OCOCDCDDOD()
		{
			if (base.gameObject.GetComponent<MeshFilter>() == null)
			{
				base.gameObject.AddComponent<MeshFilter>();
			}
			if (base.gameObject.GetComponent<MeshRenderer>() == null)
			{
				base.gameObject.AddComponent<MeshRenderer>();
			}
			if (base.gameObject.GetComponent<MeshCollider>() == null)
			{
				base.gameObject.AddComponent<MeshCollider>();
			}
			Mesh mesh;
			if (base.gameObject.GetComponent<MeshFilter>().sharedMesh != null)
			{
				mesh = base.gameObject.GetComponent<MeshFilter>().sharedMesh;
			}
			else
			{
				mesh = new Mesh();
				base.gameObject.GetComponent<MeshFilter>().sharedMesh = mesh;
				base.gameObject.GetComponent<MeshCollider>().sharedMesh = mesh;
			}
			if (base.gameObject.GetComponent<MeshRenderer>().sharedMaterial == null)
			{
				if (mainRoadMaterial == null)
				{
					mainRoadMaterial = baseScript.roundAboutMaterial;
				}
				base.gameObject.GetComponent<MeshRenderer>().sharedMaterial = mainRoadMaterial;
			}
			if (defaultConnectionMaterial == null)
			{
				defaultConnectionMaterial = baseScript.roadMaterial;
			}
			meshVecs = new List<Vector3>();
			List<Vector2> meshUVs = new List<Vector2>();
			for (int i = 0; i < mainRightPoints.Count; i++)
			{
				meshVecs.Add(mainLeftPoints[i]);
				meshVecs.Add(mainCenterPoints[i]);
				meshVecs.Add(mainRightPoints[i]);
				meshUVs.Add(mainLeftPointsUVs[i]);
				meshUVs.Add(mainCenterPointsUVs[i]);
				meshUVs.Add(mainRightPointsUVs[i]);
			}
			List<int> fullTris = new List<int>();
			List<Vector3> connectionVecs = new List<Vector3>();
			List<Vector2> connectionUVs = new List<Vector2>();
			List<int> connectionTris = new List<int>();
			List<List<int>> triList = new List<List<int>>();
			List<Material> materialList = new List<Material>();
			materialList.Add(mainRoadMaterial);
			OQOQOOCDCC.OOCQCODODQ(connections, mainLeftPoints, ref meshVecs, ref meshUVs, ref fullTris);
			triList.Add(fullTris);
			if (connections.Count > 0)
			{
				OQOQOOCDCC.OOCQODOCDQ(connections, meshVecs, meshVecs.Count, ref connectionVecs, ref connectionUVs, ref connectionTris, ref triList, ref materialList);
			}
			meshUVs.AddRange(connectionUVs);
			bool flag = true;
			for (int j = 0; j < connections.Count; j++)
			{
				if (connections[j].leftSidewalkActive && connections[j].leftSidewalkid != 0.0)
				{
					flag = false;
					prefabScript.crossingElements[j].sidewalkLeftVecs.Clear();
					prefabScript.crossingElements[j].sidewalkRightVecs.Clear();
					connections[j].leftSidewalk = null;
					if (connections[j].leftSidewalk == null)
					{
						connections[j].leftSidewalk = ERSideWalk.GetSidewalk(baseScript.sidewalks, connections[j].leftSidewalkid);
					}
					if (connections[j].leftSidewalkGO == null)
					{
						connections[j].leftSidewalkGO = ERSideWalkInstance.CreateObject(base.transform, connections[j].leftSidewalk, "_left");
					}
					connections[j].leftSidewalkGO.transform.position = base.transform.position;
					connections[j].rt = QDQDOOQQDQODD.GetRoadTypeElByID(baseScript.roadTypes, connections[j].roadType);
					if (connections[j].rt == null)
					{
						Debug.Log("EasyRoads3Dv3: No road type is assigned to Connection " + j + ". V3.3 sidewalks require road types");
					}
					else
					{
						ODQCCDQOCO.OCOCDCDDOD(prefabScript, connections[j], connections[j].leftSidewalk, connections[j].leftSidewalk.shape, connections[j].leftSidewalk.doConnectionTri, connections[j].leftSidewalk.sidewalkUVs, connections[j].rightSidewalkSourceVecs, null, -1, connections[j].leftSidewalkGO, 0f - connections[j].rt.roadShapeData.leftSidewalkOffset, closedStart: false, closedEnd: false);
					}
				}
				else if (connections[j].leftSidewalkGO != null)
				{
					UnityEngine.Object.DestroyImmediate(connections[j].leftSidewalkGO);
				}
				if (connections[j].rightSidewalkActive && connections[j].rightSidewalkid != 0.0)
				{
					flag = false;
					prefabScript.crossingElements[j].sidewalkLeftVecs.Clear();
					prefabScript.crossingElements[j].sidewalkRightVecs.Clear();
					connections[j].rightSidewalk = null;
					if (connections[j].rightSidewalk == null)
					{
						connections[j].rightSidewalk = ERSideWalk.GetSidewalk(baseScript.sidewalks, connections[j].rightSidewalkid);
					}
					if (connections[j].rightSidewalkGO == null)
					{
						connections[j].rightSidewalkGO = ERSideWalkInstance.CreateObject(base.transform, connections[j].rightSidewalk, "_right");
					}
					connections[j].rightSidewalkGO.transform.position = base.transform.position;
					connections[j].rt = QDQDOOQQDQODD.GetRoadTypeElByID(baseScript.roadTypes, connections[j].roadType);
					if (connections[j].rt == null)
					{
						Debug.Log("EasyRoads3Dv3: No road type is assigned to Connection " + j + ". V3.3 sidewalks require road types");
					}
					else
					{
						ODQCCDQOCO.OCOCDCDDOD(prefabScript, connections[j], connections[j].rightSidewalk, connections[j].rightSidewalk.shape, connections[j].rightSidewalk.doConnectionTri, connections[j].rightSidewalk.sidewalkUVs, connections[j].leftSidewalkSourceVecs, null, 1, connections[j].rightSidewalkGO, 0f - connections[j].rt.roadShapeData.rightSidewalkOffset, closedStart: false, closedEnd: false);
					}
				}
				else if (connections[j].rightSidewalkGO != null)
				{
					UnityEngine.Object.DestroyImmediate(connections[j].rightSidewalkGO);
				}
			}
			if (flag)
			{
				prefabScript.v32Sidewalks = true;
				ODQCCDQOCO.ODQODDODCC(this, ref meshVecs, ref meshUVs, ref triList, ref materialList);
			}
			else
			{
				prefabScript.v32Sidewalks = false;
			}
			if (innerRoundaboutPreset != 0)
			{
				ODQCCDQOCO.OQDQDOCODD(this, innerRoundaboutSidewalkV3, innerRoundaboutSidewalUV, innerRoundaboutSidewalTris, ref meshVecs, ref meshUVs, ref triList, ref materialList);
			}
			mesh.Clear();
			mesh.subMeshCount = triList.Count;
			mesh.vertices = meshVecs.ToArray();
			mesh.uv = meshUVs.ToArray();
			mesh.uv2 = meshUVs.ToArray();
			mesh.tangents = new Vector4[mesh.vertices.Length];
			for (int k = 0; k < triList.Count; k++)
			{
				mesh.SetTriangles(triList[k].ToArray(), k);
			}
			mesh.RecalculateBounds();
			mesh.RecalculateNormals();
			if (activeSidewalks || prefabScript.isSceneObject)
			{
				mesh.normals = ERSideWalkVecs.OCQDQCODCD(this, mesh.normals);
			}
			mesh.RecalculateTangents();
			base.gameObject.GetComponent<MeshCollider>().sharedMesh = null;
			base.gameObject.GetComponent<MeshCollider>().sharedMesh = mesh;
			base.gameObject.GetComponent<MeshRenderer>().sharedMaterials = materialList.ToArray();
			prefabScript.isRoundabout = true;
			prefabScript.roundaboutScript = this;
			prefabScript.meshVecs = (prefabScript.tmpMeshVecs = (prefabScript.tmpFullMeshVecs = (prefabScript.fullMeshVecs = meshVecs.ToArray())));
			for (int l = 0; l < connections.Count; l++)
			{
				if (connections[l].leftFlag && connections[l].rightFlag)
				{
					if (prefabScript.crossingElements.Count < l + 1)
					{
						prefabScript.crossingElements.Add(new QDOODOQQDQODD());
						connections[l].prefabElement = prefabScript.crossingElements.Count - 1;
					}
					if (prefabScript.sidewalkControlElements.Count < l + 1)
					{
						prefabScript.sidewalkControlElements.Add(new QDOQDSQOOQDDD(baseScript));
					}
					QDOODOQQDQODD qDOODOQQDQODD = prefabScript.crossingElements[l];
					qDOODOQQDQODD.centerPoint = (qDOODOQQDQODD.tmpCenterPoint = connections[l].centerPoint);
					qDOODOQQDQODD.controlPointV3 = connections[l].outerCenterPoint;
					ODDOQOODQO(l, connections[l].connectionVecInts, connections[l].roadShapeUVY, connections[l].leftSidewalkTris, connections[l].rightSidewalkTris, 0);
					OQDODOODCD(meshVecs, prefabScript.crossingElements[l].connectionVecInts, ref prefabScript.crossingElements[l].roadShapeVecs, connections[l].roadShapeVecs, connections[l].leftSidewalkV3, connections[l].rightSidewalkV3, l, 0);
					prefabScript.crossingElements[l].roadShapeVecsString = ERCrossings.GetRoadShapeVecString(prefabScript.crossingElements[l].roadShapeVecs, prefabScript.crossingElements[l].sidewalkLeftVecs, prefabScript.crossingElements[l].sidewalkRightVecs, ref prefabScript.crossingElements[l].roadShapeMatchCount);
					OCCQDQOOCQ(l, connections[l].roadMaterial, connections[l].leftSidewalkV3.Count, connections[l].rightSidewalkV3.Count);
					qDOODOQQDQODD.roadMaterial = connections[l].roadMaterial;
					qDOODOQQDQODD.blendCornerPointInts = connections[l].blendCornerPointInts;
					qDOODOQQDQODD.blendCornerPointWeights = connections[l].blendCornerPointWeights;
					qDOODOQQDQODD.alignmentHandleVecRotationGizmo = mainLeftPoints[connections[l].centerInt];
					List<Vector3> list = new List<Vector3>(connections[l].rightSidewalkSourceVecs);
					list.Reverse();
					qDOODOQQDQODD.leftRoundingPoints = list;
					list = new List<Vector3>(connections[l].leftSidewalkSourceVecs);
					list.Reverse();
					qDOODOQQDQODD.rightRoundingPoints = list;
					if (l > 0)
					{
						List<Vector3> leftRoundingPoints = prefabScript.crossingElements[l - 1].leftRoundingPoints;
						int index = prefabScript.crossingElements[l - 1].leftRoundingPoints.Count - 1;
						Vector3 value = (qDOODOQQDQODD.rightRoundingPoints[qDOODOQQDQODD.rightRoundingPoints.Count - 1] = Vector3.Lerp(prefabScript.crossingElements[l - 1].leftRoundingPoints[prefabScript.crossingElements[l - 1].leftRoundingPoints.Count - 1], qDOODOQQDQODD.rightRoundingPoints[qDOODOQQDQODD.rightRoundingPoints.Count - 1], 0.5f));
						leftRoundingPoints[index] = value;
					}
					qDOODOQQDQODD.centerCornerDirectionLeft = (qDOODOQQDQODD.centerCornerDirectionRight = Vector3.zero);
					qDOODOQQDQODD.roadType = connections[l].roadType;
					qDOODOQQDQODD.roadTypeTimestamp = connections[l].roadTypeTimestamp;
					OQQOODCODD(l);
					prefabScript.sidewalkControlElements[l].crossingElementRightIndex = l;
					if (l == 0)
					{
						prefabScript.sidewalkControlElements[l].crossingElementLeftIndex = connections.Count - 1;
					}
					else
					{
						prefabScript.sidewalkControlElements[l].crossingElementLeftIndex = l - 1;
					}
				}
			}
			if (prefabScript.crossingElements.Count > 0)
			{
				List<Vector3> leftRoundingPoints2 = prefabScript.crossingElements[prefabScript.crossingElements.Count - 1].leftRoundingPoints;
				int index2 = prefabScript.crossingElements[prefabScript.crossingElements.Count - 1].leftRoundingPoints.Count - 1;
				Vector3 value = (prefabScript.crossingElements[0].rightRoundingPoints[prefabScript.crossingElements[0].rightRoundingPoints.Count - 1] = Vector3.Lerp(prefabScript.crossingElements[prefabScript.crossingElements.Count - 1].leftRoundingPoints[prefabScript.crossingElements[prefabScript.crossingElements.Count - 1].leftRoundingPoints.Count - 1], prefabScript.crossingElements[0].rightRoundingPoints[prefabScript.crossingElements[0].rightRoundingPoints.Count - 1], 0.5f));
				leftRoundingPoints2[index2] = value;
			}
			OOOOQCQOQC();
			prefabScript.ODDDOQCCCD();
			prevRoundAboutRadius = roundAboutRadius;
			prevRoundAboutResolution = roundAboutResolution;
			prevRoundaboutWidth = roundaboutWidth;
			prevNewSegmentInt = newSegmentInt;
			prevRoadWidth = roadWidth;
			prevLeftRoundingRadius = leftRoundingRadius;
			prevRightRoundingRadius = rightRoundingRadius;
			prevRoadTypeInt = roadTypeInt;
			if (connections.Count > 0 && selectedConnection >= 0 && connections.Count > selectedConnection)
			{
				connections[selectedConnection].prevRoadWidth = connections[selectedConnection].roadWidth;
				connections[selectedConnection].prevCenterInt = connections[selectedConnection].centerInt;
				connections[selectedConnection].prevLeftRoundingRadius = connections[selectedConnection].leftRoundingRadius;
				connections[selectedConnection].prevRightRoundingRadius = connections[selectedConnection].rightRoundingRadius;
				connections[selectedConnection].prevRoadType = connections[selectedConnection].roadType;
			}
			UpdateMinMaxInts();
		}

		public void ODDOQOODQO(int el, List<int> trIntArray, List<float> uvArray, List<List<int>> leftSidewalkIntArray, List<List<int>> rightSidewalkIntArray, int startend)
		{
			QDOODOQQDQODD qDOODOQQDQODD = prefabScript.crossingElements[el];
			qDOODOQQDQODD.connectionVecInts.Clear();
			qDOODOQQDQODD.blendCornerPointInts.Clear();
			qDOODOQQDQODD.blendCornerPointWeights.Clear();
			qDOODOQQDQODD.roadShapeUVY.Clear();
			QDOQDSQOOQDDD qDOQDSQOOQDDD = null;
			QDOQDSQOOQDDD qDOQDSQOOQDDD2 = null;
			qDOQDSQOOQDDD2 = prefabScript.sidewalkControlElements[el];
			qDOQDSQOOQDDD = ((el >= connections.Count - 1) ? prefabScript.sidewalkControlElements[0] : prefabScript.sidewalkControlElements[el + 1]);
			qDOODOQQDQODD.sidewalkLeftUVY.Clear();
			qDOODOQQDQODD.sidewalkLeftConnectionVecInts.Clear();
			if (qDOODOQQDQODD.includeLeftSidewalk)
			{
				for (int i = 0; i < leftSidewalkIntArray.Count; i++)
				{
					qDOODOQQDQODD.sidewalkLeftConnectionVecInts.Add(leftSidewalkIntArray[i][0]);
				}
				qDOODOQQDQODD.sidewalkLeftConnectionVecInts.Reverse();
				qDOODOQQDQODD.sidewalkLeftUVY.AddRange(qDOQDSQOOQDDD.sidewalkUVs);
				qDOODOQQDQODD.sidewalkLeftUVY.Reverse();
			}
			qDOODOQQDQODD.connectionVecInts.Add(trIntArray[0]);
			qDOODOQQDQODD.connectionVecInts.Add(trIntArray[trIntArray.Count - 1]);
			qDOODOQQDQODD.roadShapeUVY.Add(uvArray[0]);
			qDOODOQQDQODD.roadShapeUVY.Add(uvArray[uvArray.Count - 1]);
			qDOODOQQDQODD.sidewalkRightUVY.Clear();
			qDOODOQQDQODD.sidewalkRightConnectionVecInts.Clear();
			if (qDOODOQQDQODD.includeRightSidewalk)
			{
				for (int j = 0; j < rightSidewalkIntArray.Count; j++)
				{
					qDOODOQQDQODD.sidewalkRightConnectionVecInts.Add(rightSidewalkIntArray[j][0]);
				}
				qDOODOQQDQODD.sidewalkRightUVY.AddRange(qDOQDSQOOQDDD2.sidewalkUVs);
			}
			qDOODOQQDQODD.connectionVecInts.InsertRange(0, qDOODOQQDQODD.sidewalkLeftConnectionVecInts);
			qDOODOQQDQODD.connectionVecInts.AddRange(qDOODOQQDQODD.sidewalkRightConnectionVecInts);
			qDOODOQQDQODD.fullConnectionVecInts = new List<int>(qDOODOQQDQODD.connectionVecInts);
			qDOODOQQDQODD.leftInt = 0;
			qDOODOQQDQODD.leftIntFull = 0;
			qDOODOQQDQODD.rightInt = qDOODOQQDQODD.connectionVecInts.Count - 1;
			qDOODOQQDQODD.rightIntFull = qDOODOQQDQODD.fullConnectionVecInts.Count - 1;
		}

		public void OQDODOODCD(List<Vector3> meshVecs, List<int> connectionVecInts, ref List<Vector2> roadShapeVecs, List<Vector2> vecArrays, List<List<Vector3>> leftSidewalkArray, List<List<Vector3>> rightSidewalkArray, int connectionElement, int startend)
		{
			QDOODOQQDQODD qDOODOQQDQODD = prefabScript.crossingElements[connectionElement];
			roadShapeVecs.Clear();
			qDOODOQQDQODD.sidewalkLeftVecs.Clear();
			qDOODOQQDQODD.sidewalkRightVecs.Clear();
			Vector3 zero;
			Vector3 vector = (zero = Vector3.zero);
			Vector3 vector2 = leftSidewalkArray[0][0];
			Vector3 centerPoint = connections[connectionElement].centerPoint;
			float num = Vector3.Distance(leftSidewalkArray[0][0], rightSidewalkArray[0][0]) * 0.5f;
			for (int i = 0; i < connectionVecInts.Count - 1; i++)
			{
			}
			List<Vector3> list = new List<Vector3>();
			if (qDOODOQQDQODD.includeLeftSidewalk)
			{
				for (int j = 0; j < leftSidewalkArray.Count; j++)
				{
					list.Add(leftSidewalkArray[j][0]);
				}
				list.Reverse();
				vector = list[0];
				vector2 = vector;
				vector2.y = 0f;
				num = Vector3.Distance(vector2, centerPoint);
				ERCrossings.OQODQCOODD(list, ref qDOODOQQDQODD.sidewalkLeftVecs, centerPoint, vector2, num);
			}
			list.Clear();
			list.Add(leftSidewalkArray[0][0]);
			list.Add(rightSidewalkArray[0][0]);
			if (vector == Vector3.zero)
			{
				vector = list[0];
			}
			zero = list[list.Count - 1];
			ERCrossings.OQODQCOODD(list, ref roadShapeVecs, centerPoint, vector2, num);
			if (qDOODOQQDQODD.includeRightSidewalk)
			{
				list.Clear();
				for (int k = 0; k < rightSidewalkArray.Count; k++)
				{
					list.Add(rightSidewalkArray[k][0]);
				}
				zero = list[list.Count - 1];
				ERCrossings.OQODQCOODD(list, ref qDOODOQQDQODD.sidewalkRightVecs, centerPoint, vector2, num);
			}
			vector.y = 0f;
			zero.y = 0f;
			float num2 = Vector3.Distance(vector, zero);
			qDOODOQQDQODD.centerPointPercentage = num / num2;
		}

		public void OCCQDQOOCQ(int el, Material roadMaterial, int leftVecCount, int rightVecCount)
		{
			QDOODOQQDQODD qDOODOQQDQODD = prefabScript.crossingElements[el];
			QDOQDSQOOQDDD qDOQDSQOOQDDD = prefabScript.sidewalkControlElements[el];
			QDOQDSQOOQDDD qDOQDSQOOQDDD2 = null;
			qDOQDSQOOQDDD2 = ((el >= connections.Count - 1) ? prefabScript.sidewalkControlElements[0] : prefabScript.sidewalkControlElements[el + 1]);
			qDOODOQQDQODD.roadMaterial = roadMaterial;
			List<Material> list = new List<Material>();
			List<int> list2 = new List<int>();
			list.Add(roadMaterial);
			if (qDOODOQQDQODD.includeLeftSidewalk)
			{
				if (list[0] != qDOQDSQOOQDDD2.sidewalkMaterial)
				{
					list.Add(qDOQDSQOOQDDD2.sidewalkMaterial);
					for (int i = 0; i < leftVecCount; i++)
					{
						list2.Add(1);
					}
				}
				else
				{
					for (int j = 0; j < leftVecCount; j++)
					{
						list2.Add(0);
					}
				}
			}
			list2.Add(0);
			list2.Add(0);
			if (qDOODOQQDQODD.includeRightSidewalk)
			{
				if (list[0] != qDOQDSQOOQDDD.sidewalkMaterial && qDOQDSQOOQDDD2.sidewalkMaterial != qDOQDSQOOQDDD.sidewalkMaterial && qDOODOQQDQODD.includeLeftSidewalk)
				{
					list.Add(qDOQDSQOOQDDD.sidewalkMaterial);
					for (int k = 0; k < rightVecCount; k++)
					{
						list2.Add(2);
					}
				}
				else if (list[0] == qDOQDSQOOQDDD.sidewalkMaterial)
				{
					for (int l = 0; l < rightVecCount; l++)
					{
						list2.Add(0);
					}
				}
				else if (qDOQDSQOOQDDD2.sidewalkMaterial == qDOQDSQOOQDDD.sidewalkMaterial || !qDOODOQQDQODD.includeLeftSidewalk)
				{
					if (!qDOODOQQDQODD.includeLeftSidewalk)
					{
						list.Add(qDOQDSQOOQDDD.sidewalkMaterial);
					}
					for (int m = 0; m < rightVecCount; m++)
					{
						list2.Add(1);
					}
				}
			}
			qDOODOQQDQODD.roadMaterials = list.ToArray();
			qDOODOQQDQODD.roadShapeMaterialInts.Clear();
			qDOODOQQDQODD.roadShapeMaterialInts.AddRange(list2);
		}

		public void OOOOQCQOQC()
		{
		}

		public void OQQOODCODD(int el)
		{
			QDOODOQQDQODD qDOODOQQDQODD = prefabScript.crossingElements[el];
			QDOQDSQOOQDDD qDOQDSQOOQDDD = prefabScript.sidewalkControlElements[el];
			QDOQDSQOOQDDD qDOQDSQOOQDDD2 = null;
			qDOQDSQOOQDDD2 = ((el >= connections.Count - 1) ? prefabScript.sidewalkControlElements[0] : prefabScript.sidewalkControlElements[el + 1]);
			float num = roundAboutRadius + 0.5f * roundaboutWidth;
			float num2 = 0f;
			Vector3 prevVec = Vector3.zero;
			Vector3 firstIndent = Vector3.zero;
			Vector3 vector = Vector3.zero;
			List<Vector3> list = new List<Vector3>();
			if (baseScript == null)
			{
				baseScript = UnityEngine.Object.FindObjectOfType(typeof(ERModularBase)) as ERModularBase;
			}
			float num3 = num + baseScript.minIndent;
			float num4 = num3 + baseScript.minSurrounding;
			float num5 = baseScript.minIndent;
			Vector3 vector2 = connections[el].leftSidewalkV3[0][connections[el].leftSidewalkV3[0].Count - 1];
			Vector3 vector3 = connections[el].rightSidewalkV3[0][connections[el].rightSidewalkV3[0].Count - 1];
			if (el == 0 || el == connections.Count - 1)
			{
				int num6 = connections[0].leftOuterInt;
				int num7 = mainLeftPoints.Count - connections[connections.Count - 1].rightOuterInt;
				int num8 = Mathf.RoundToInt((float)(num6 + num7) * 0.5f);
				num8 = ((num8 >= num6) ? (mainLeftPoints.Count - (num8 - num6)) : (num6 - num8));
				if (num8 >= mainLeftPoints.Count)
				{
					num8 = mainLeftPoints.Count - 1;
				}
				if (el == 0)
				{
					vector3 = mainLeftPoints[num8];
				}
				else
				{
					vector2 = mainLeftPoints[num8];
				}
			}
			if (qDOQDSQOOQDDD.renderFlag)
			{
				num3 += qDOQDSQOOQDDD.sidewalkWidth1;
				num2 = qDOQDSQOOQDDD.sidewalkWidth1;
				num5 += qDOQDSQOOQDDD.sidewalkWidth1;
			}
			num4 = num3 + baseScript.minSurrounding;
			list.AddRange(connections[el].rightSidewalkV3[0]);
			connections[el].rightIndentBorderInt = -1;
			for (int i = 0; i < list.Count; i++)
			{
				Vector3 vector4 = ((i == 0) ? (list[i + 1] - list[i]).normalized : ((i >= list.Count - 1) ? (list[i] - list[i - 1]).normalized : (list[i + 1] - list[i - 1]).normalized));
				vector4 = new Vector3(vector4.z, 0f, 0f - vector4.x).normalized;
				Vector3 vec = list[i] + vector4 * num5;
				if (OCDCOOQQCO(i, num3, prevVec, boolCheck: true, ref vec, ref connections[el].rightIndentBorderInt))
				{
					if (i == 0 && connections[el].rightIndentBorderInt == 0)
					{
						vec = list[i].normalized * num3;
						vec += vector4 * num5;
					}
					connections[el].rightIndentvecs.Add(vec);
					prevVec = vec;
					if (i == 0)
					{
						firstIndent = vec;
					}
					vec += vector4 * baseScript.minSurrounding;
					vec = OCOCODQQDC.OQOOOCQDDO(base.transform, vec, baseScript);
					if (connections[el].rightIndentBorderInt <= 0 && vector3 != list[i])
					{
						ODCQQOQDOO(num4, vector3, list[i], boolCheck: true, ref vec);
					}
					if (vector != Vector3.zero)
					{
						CheckAgainstFirstSurroundingVec(firstIndent, vector, boolCheck: true, ref vec);
					}
					connections[el].rightSurroundingvecs.Add(vec);
					if (i == 0)
					{
						vector = vec;
					}
				}
			}
			num3 = num + baseScript.minIndent;
			num4 = num3 + baseScript.minSurrounding;
			num5 = baseScript.minIndent;
			prevVec = Vector3.zero;
			firstIndent = Vector3.zero;
			vector = Vector3.zero;
			if (qDOQDSQOOQDDD2.renderFlag)
			{
				num3 += qDOQDSQOOQDDD2.sidewalkWidth1;
				num2 = qDOQDSQOOQDDD2.sidewalkWidth1;
				num5 += qDOQDSQOOQDDD2.sidewalkWidth1;
			}
			num4 = num3 + baseScript.minSurrounding;
			list.Clear();
			list.AddRange(connections[el].leftSidewalkV3[0]);
			connections[el].leftIndentBorderInt = -1;
			for (int j = 0; j < list.Count; j++)
			{
				Vector3 vector4 = ((j == 0) ? (list[j + 1] - list[j]).normalized : ((j >= list.Count - 1) ? (list[j] - list[j - 1]).normalized : (list[j + 1] - list[j - 1]).normalized));
				vector4 = new Vector3(vector4.z, 0f, 0f - vector4.x).normalized * -1f;
				Vector3 vec = list[j] + vector4 * num5;
				if (OCDCOOQQCO(j, num3, prevVec, boolCheck: false, ref vec, ref connections[el].leftIndentBorderInt))
				{
					if (j == 0 && connections[el].leftIndentBorderInt == 0)
					{
						vec = list[j].normalized * num3;
						vec += vector4 * num5;
					}
					connections[el].leftIndentvecs.Add(vec);
					prevVec = vec;
					if (j == 0)
					{
						firstIndent = vec;
					}
					vec += vector4 * baseScript.minSurrounding;
					vec = OCOCODQQDC.OQOOOCQDDO(base.transform, vec, baseScript);
					if (connections[el].leftIndentBorderInt <= 0 && vector2 != list[j])
					{
						ODCQQOQDOO(num4, vector2, list[j], boolCheck: false, ref vec);
					}
					if (vector != Vector3.zero)
					{
						CheckAgainstFirstSurroundingVec(firstIndent, vector, boolCheck: false, ref vec);
					}
					connections[el].leftSurroundingvecs.Add(vec);
					if (j == 0)
					{
						vector = vec;
					}
				}
			}
		}

		public static bool OCDCOOQQCO(int el, float roundaboutIndent, Vector3 prevVec, bool boolCheck, ref Vector3 vec, ref int indentBorderInt)
		{
			float num = Vector3.Distance(vec, Vector3.zero) + 0.2f;
			if (num < roundaboutIndent)
			{
				if (indentBorderInt == -1)
				{
					indentBorderInt = el - 1;
				}
				if (indentBorderInt == -1)
				{
					indentBorderInt = 0;
					Vector3 normalized = vec.normalized;
					vec += normalized * (roundaboutIndent - num);
					return true;
				}
				return false;
			}
			if (prevVec != Vector3.zero)
			{
				if (OQQOCDQCQD.OOCQODQDQD(vec, Vector3.zero, prevVec) == boolCheck)
				{
					return true;
				}
				return false;
			}
			return true;
		}

		public void ODCQQOQDOO(float minSurrounding, Vector3 middleVec, Vector3 origVec, bool boolCheck, ref Vector3 vec)
		{
			float num = Vector3.Distance(vec, Vector3.zero);
			if (num < minSurrounding)
			{
				Vector3 normalized = vec.normalized;
				vec = normalized * minSurrounding;
				vec = OCOCODQQDC.OQOOOCQDDO(base.transform, vec, baseScript);
			}
			if (OQQOCDQCQD.OOCQODQDQD(middleVec, Vector3.zero, vec) != boolCheck && OQQOCDQCQD.OOCQODQDQD(middleVec, Vector3.zero, origVec) == boolCheck)
			{
				vec = OQQOCDQCQD.OCDCQCDDCC(Vector3.zero, middleVec, origVec, vec, flag: false);
				vec = OCOCODQQDC.OQOOOCQDDO(base.transform, vec, baseScript);
			}
		}

		public void CheckAgainstFirstSurroundingVec(Vector3 firstIndent, Vector3 firstSurrounding, bool boolCheck, ref Vector3 vec)
		{
			if (OQQOCDQCQD.OOCQODQDQD(firstSurrounding, firstIndent, vec) == boolCheck)
			{
				vec = firstSurrounding;
			}
		}

		public static Vector3 OCDCQCDDCC(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4)
		{
			float num = p1.x - p3.x;
			float num2 = p1.z - p3.z;
			float num3 = p2.z - p1.z;
			float num4 = p2.x - p1.x;
			float num5 = num3 * p1.x + num4 * p1.z;
			float num6 = p4.z - p3.z;
			float num7 = p4.x - p3.x;
			float num8 = num6 * p3.x + num7 * p3.z;
			float num9 = num3 * num7 - num6 * num4;
			if (num9 == 0f)
			{
				return Vector3.zero;
			}
			float num10 = num6 * num4 - num7 * num3;
			float num11 = (num7 * num2 - num6 * num) / num10;
			float num12 = (num4 * num2 - num3 * num) / num10;
			float x = p1.x + num11 * num4;
			float z = p1.z + num11 * num3;
			return new Vector3(x, p1.y, z);
		}

		public static Vector3 OOQOCODQOO(Vector3 point, Vector3 pivot, Quaternion angle)
		{
			Vector3 vector = point - pivot;
			vector = angle * vector;
			return vector + pivot;
		}
	}
}
