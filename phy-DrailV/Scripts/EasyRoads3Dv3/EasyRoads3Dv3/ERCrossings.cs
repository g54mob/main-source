using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	public class ERCrossings : MonoBehaviour
	{
		public List<List<Vector3>> startConnectionV3 = new List<List<Vector3>>();

		public List<List<Vector3>> endConnectionV3 = new List<List<Vector3>>();

		public List<List<Vector3>> leftConnectionV3 = new List<List<Vector3>>();

		public List<List<Vector3>> rightConnectionV3 = new List<List<Vector3>>();

		public List<List<Vector2>> startConnectionUV = new List<List<Vector2>>();

		public List<List<Vector2>> endConnectionUV = new List<List<Vector2>>();

		public List<List<Vector2>> leftConnectionUV = new List<List<Vector2>>();

		public List<List<Vector2>> rightConnectionUV = new List<List<Vector2>>();

		public List<List<int>> startConnectionTris = new List<List<int>>();

		public List<List<int>> endConnectionTris = new List<List<int>>();

		public List<List<int>> leftConnectionTris = new List<List<int>>();

		public List<List<int>> rightConnectionTris = new List<List<int>>();

		public List<List<Vector3>> leftSidewalkStartV3 = new List<List<Vector3>>();

		public List<List<Vector3>> rightSidewalkStartV3 = new List<List<Vector3>>();

		public List<List<Vector3>> leftSidewalkEndV3 = new List<List<Vector3>>();

		public List<List<Vector3>> rightSidewalkEndV3 = new List<List<Vector3>>();

		public List<List<Vector2>> leftSidewalkStartUV = new List<List<Vector2>>();

		public List<List<Vector2>> rightSidewalkStartUV = new List<List<Vector2>>();

		public List<List<Vector2>> leftSidewalkEndUV = new List<List<Vector2>>();

		public List<List<Vector2>> rightSidewalkEndUV = new List<List<Vector2>>();

		public List<List<Vector3>> leftSidewalkLeftV3 = new List<List<Vector3>>();

		public List<List<Vector3>> leftSidewalkRightV3 = new List<List<Vector3>>();

		public List<List<Vector3>> rightSidewalkLeftV3 = new List<List<Vector3>>();

		public List<List<Vector3>> rightSidewalkRightV3 = new List<List<Vector3>>();

		public List<List<Vector2>> leftSidewalkLeftUV = new List<List<Vector2>>();

		public List<List<Vector2>> leftSidewalkRightUV = new List<List<Vector2>>();

		public List<List<Vector2>> rightSidewalkLeftUV = new List<List<Vector2>>();

		public List<List<Vector2>> rightSidewalkRightUV = new List<List<Vector2>>();

		public List<List<int>> leftSidewalkStartTris = new List<List<int>>();

		public List<List<int>> rightSidewalkStartTris = new List<List<int>>();

		public List<List<int>> leftSidewalkEndTris = new List<List<int>>();

		public List<List<int>> rightSidewalkEndTris = new List<List<int>>();

		public List<List<int>> leftSidewalkLeftTris = new List<List<int>>();

		public List<List<int>> leftSidewalkRightTris = new List<List<int>>();

		public List<List<int>> rightSidewalkLeftTris = new List<List<int>>();

		public List<List<int>> rightSidewalkRightTris = new List<List<int>>();

		public List<float> uvArrayFront = new List<float>();

		public List<float> uvArrayBack = new List<float>();

		public List<float> uvArrayLeft = new List<float>();

		public List<float> uvArrayRight = new List<float>();

		public List<int> OQOCCQDCCO = new List<int>();

		public List<int> ODCDCOODCQ = new List<int>();

		public List<int> OCDCDQQCDD = new List<int>();

		public List<int> OCCDCQDDDD = new List<int>();

		public List<int> OQCQCCCQQC = new List<int>();

		public List<int> OOOCCCCODQ = new List<int>();

		public List<int> OCDDDQCCOO = new List<int>();

		public List<int> ODQQCQDOQC = new List<int>();

		public List<int> OQOCCQDCCOStart = new List<int>();

		public List<int> ODCDCOODCQStart = new List<int>();

		public List<int> OCDCDQQCDDStart = new List<int>();

		public List<int> OCCDCQDDDDStart = new List<int>();

		public List<int> OQCQCCCQQCStart = new List<int>();

		public List<int> OOOCCCCODQStart = new List<int>();

		public List<int> OCDDDQCCOOStart = new List<int>();

		public List<int> ODQQCQDOQCStart = new List<int>();

		public List<int> frontLeftRoadInts = new List<int>();

		public List<int> frontRightRoadInts = new List<int>();

		public List<int> backLeftRoadInts = new List<int>();

		public List<int> backRightRoadInts = new List<int>();

		public List<int> leftLeftRoadInts = new List<int>();

		public List<int> leftRightRoadInts = new List<int>();

		public List<int> rightLeftRoadInts = new List<int>();

		public List<int> rightRightRoadInts = new List<int>();

		public int leftStartSidewalkCornerInt = 0;

		public int rightStartSidewalkCornerInt = 0;

		public int leftEndSidewalkCornerInt = 0;

		public int rightEndSidewalkCornerInt = 0;

		public int leftLeftSidewalkCornerInt = 0;

		public int rightLeftSidewalkCornerInt = 0;

		public int leftRightSidewalkCornerInt = 0;

		public int rightRightSidewalkCornerInt = 0;

		public Vector3[] sidewalkControlPoints = new Vector3[12];

		public bool[] sidewalkControlStatus = new bool[0];

		public bool copySettingsFlag = false;

		public bool generalSettingsFlag = false;

		public bool connectionSettingsFlag = false;

		public bool cornerSettingsFlag = false;

		public bool sidewalkSettingsFlag = false;

		public string[] QDOOOQOOQQQQD;

		public int selectedConnection = 0;

		public float startAngle = 0f;

		public bool roundedCorners = true;

		public float roundingRadius = 1f;

		public int roundingSegments = 5;

		public float innerSegmentDistance = 0.5f;

		public bool tCrossing = false;

		public bool tStraightBending = true;

		public bool oldTCrossing = false;

		public int tCrossingLeftRight = 1;

		public int oldtCrossingLeftRight = 1;

		public int geometryType = 0;

		public float resolution = 1f;

		public bool includeSidewalks = true;

		public bool defaultSidewalkEnabledStatus = true;

		public bool planarUVs = false;

		public float planarTiling = 1f;

		public bool isSceneObject = true;

		public int connectionHandling = 0;

		public List<QDQDOOQQDQODD> roadTypesDynamic = new List<QDQDOOQQDQODD>();

		public int frontRoadTypeInt = 0;

		public double frontRoadTypeID = 0.0;

		public float frontRoadWidth = 8f;

		public Material frontMaterial;

		public Material frontRoadMaterial;

		public float frontRoadUVTiling = 1f;

		public int backRoadTypeInt = 0;

		public double backRoadTypeID = 0.0;

		public float backRoadWidth = 8f;

		public Material backMaterial;

		public Material backRoadMaterial;

		public float backRoadUVTiling = 1f;

		public int leftRoadTypeInt = 0;

		public double leftRoadTypeID = 0.0;

		public float leftRoadWidth = 8f;

		public Material leftMaterial;

		public Material leftRoadMaterial;

		public float leftRoadUVTiling = 1f;

		public int rightRoadTypeInt = 0;

		public double rightRoadTypeID = 0.0;

		public float rightRoadWidth = 8f;

		public Material rightMaterial;

		public Material rightRoadMaterial;

		public float rightRoadUVTiling = 1f;

		public int selectedRoadType = 0;

		public bool uniformCornersFlag;

		public int selectedCorner = 0;

		public int selectedCornerPreset = 0;

		public string cornerPresetName;

		public int selectedSidewalkPreset = 0;

		public string sidewalkPresetName;

		public int OQDOOOQODCCorner = 0;

		public Vector3 leftBottom;

		public Vector3 rightBottom;

		public Vector3 leftTop;

		public Vector3 rightTop;

		public Vector3 frontCenter;

		public Vector3 backCenter;

		public Vector3 leftCenter;

		public Vector3 rightCenter;

		public int prefabId = 0;

		public ERCrossingPrefabs prefabScript;

		public QDOODOQQDQODD connectionElement;

		public int crossingOuterElement = 0;

		public string crossingName;

		public bool guiChanged;

		public bool includeSidewalkChangeFlag = false;

		public List<Vector3> debugVecs = new List<Vector3>();

		public List<NormalPairs> normalPairs = new List<NormalPairs>();

		public float maxConnectionWidth = 75f;

		public void ODCQOCQDOO()
		{
			OODDODOQCQ(sidewalkSceneHandleFlag: true, rebuildRoads: true);
		}

		public bool UpdateToRoadType(QDQDOOQQDQODD sourcePreset, ref List<ERModularRoad> updatedRoads)
		{
			if (prefabScript == null)
			{
				Debug.LogWarning("EasyRoads3Dv3 Warning: Missing ER Crossing Prefabs script on: " + base.gameObject.name);
				return false;
			}
			List<int> list = new List<int>();
			bool flag = false;
			if (prefabScript.crossingElements[0].roadType == sourcePreset.id && prefabScript.crossingElements[0].roadType != 0.0)
			{
				flag = true;
				frontRoadWidth = sourcePreset.roadWidth;
				frontMaterial = sourcePreset.connectionMaterial;
				frontRoadMaterial = sourcePreset.roadMaterial;
				prefabScript.crossingElements[0].roadTypeTimestamp = sourcePreset.timestamp;
				if (prefabScript.crossingElements[0].connectedRoad != null && prefabScript.crossingElements[0].connectedRoad.roadType == prefabScript.crossingElements[0].roadType && !RoadIsUpdated(prefabScript.crossingElements[0].connectedRoad, ref updatedRoads))
				{
					list.Add(0);
				}
			}
			if (prefabScript.crossingElements[1].roadType == sourcePreset.id && prefabScript.crossingElements[1].roadType != 0.0)
			{
				flag = true;
				backRoadWidth = sourcePreset.roadWidth;
				backMaterial = sourcePreset.connectionMaterial;
				backRoadMaterial = sourcePreset.roadMaterial;
				prefabScript.crossingElements[1].roadTypeTimestamp = sourcePreset.timestamp;
				if (prefabScript.crossingElements[1].connectedRoad != null && prefabScript.crossingElements[1].connectedRoad.roadType == prefabScript.crossingElements[1].roadType && !RoadIsUpdated(prefabScript.crossingElements[1].connectedRoad, ref updatedRoads))
				{
					list.Add(1);
				}
			}
			if (prefabScript.crossingElements[2].roadType == sourcePreset.id && prefabScript.crossingElements[2].roadType != 0.0)
			{
				flag = true;
				leftRoadWidth = sourcePreset.roadWidth;
				leftMaterial = sourcePreset.connectionMaterial;
				leftRoadMaterial = sourcePreset.roadMaterial;
				prefabScript.crossingElements[2].roadTypeTimestamp = sourcePreset.timestamp;
				if (prefabScript.crossingElements[2].connectedRoad != null && prefabScript.crossingElements[2].connectedRoad.roadType == prefabScript.crossingElements[2].roadType && !RoadIsUpdated(prefabScript.crossingElements[2].connectedRoad, ref updatedRoads))
				{
					list.Add(2);
				}
			}
			if (prefabScript.crossingElements[3].roadType == sourcePreset.id && prefabScript.crossingElements[3].roadType != 0.0)
			{
				flag = true;
				rightRoadWidth = sourcePreset.roadWidth;
				rightMaterial = sourcePreset.connectionMaterial;
				rightRoadMaterial = sourcePreset.roadMaterial;
				prefabScript.crossingElements[3].roadTypeTimestamp = sourcePreset.timestamp;
				if (prefabScript.crossingElements[3].connectedRoad != null && prefabScript.crossingElements[3].connectedRoad.roadType == prefabScript.crossingElements[3].roadType && !RoadIsUpdated(prefabScript.crossingElements[3].connectedRoad, ref updatedRoads))
				{
					list.Add(3);
				}
			}
			if (flag)
			{
				crossingName = base.gameObject.name;
				OODDODOQCQ(sidewalkSceneHandleFlag: false, rebuildRoads: true);
				for (int i = 0; i < list.Count; i++)
				{
					ERModularRoad connectedRoad = prefabScript.crossingElements[list[i]].connectedRoad;
					if ((bool)connectedRoad.startPrefabScript && (bool)connectedRoad.endPrefabScript)
					{
						connectedRoad.OQCCCCQCCO(prefabScript, list[i], reverse: true, uvReverse: true);
						if (connectedRoad.roadShape[0].x < 0f)
						{
							connectedRoad.OQCCCCQCCO(prefabScript, list[i], reverse: false, uvReverse: false);
						}
					}
					else if (prefabScript.crossingElements[list[i]].connectedMarker == 0)
					{
						connectedRoad.OQCCCCQCCO(prefabScript, list[i], reverse: true, uvReverse: true);
						if (connectedRoad.roadShape[0].x < 0f)
						{
							connectedRoad.OQCCCCQCCO(prefabScript, list[i], reverse: false, uvReverse: false);
						}
					}
					else
					{
						connectedRoad.OQCCCCQCCO(prefabScript, list[i], reverse: false, uvReverse: false);
						if (connectedRoad.roadShape[0].x < 0f)
						{
							connectedRoad.OQCCCCQCCO(prefabScript, list[i], reverse: true, uvReverse: true);
						}
					}
					connectedRoad.OCCCCCCDCC(ignorePrefabAlignment: false, forceAutoRotate: false);
				}
			}
			return flag;
		}

		public bool RoadIsUpdated(ERModularRoad rd, ref List<ERModularRoad> updatedRoads)
		{
			foreach (ERModularRoad updatedRoad in updatedRoads)
			{
				if (updatedRoad == rd)
				{
					return true;
				}
			}
			updatedRoads.Add(rd);
			return false;
		}

		public int SetRoadTypeInt(double id)
		{
			int num = 1;
			foreach (QDQDOOQQDQODD item in roadTypesDynamic)
			{
				if (id == item.id)
				{
					return num;
				}
				num++;
			}
			return 0;
		}

		public void OOOQQCCQQC(ERCrossings source)
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
			prefabId = source.prefabId;
			uvArrayFront = new List<float>(source.uvArrayFront.Count);
			uvArrayBack = new List<float>(source.uvArrayBack.Count);
			uvArrayLeft = new List<float>(source.uvArrayLeft.Count);
			uvArrayRight = new List<float>(source.uvArrayRight.Count);
			sidewalkControlPoints = new Vector3[source.sidewalkControlPoints.Length];
			Array.Copy(source.sidewalkControlPoints, sidewalkControlPoints, source.sidewalkControlPoints.Length);
			sidewalkControlStatus = new bool[source.sidewalkControlStatus.Length];
			Array.Copy(source.sidewalkControlStatus, sidewalkControlStatus, source.sidewalkControlStatus.Length);
			QDOOOQOOQQQQD = new string[source.QDOOOQOOQQQQD.Length];
			Array.Copy(source.QDOOOQOOQQQQD, QDOOOQOOQQQQD, source.QDOOOQOOQQQQD.Length);
			selectedConnection = source.selectedConnection;
			startAngle = source.startAngle;
			roundedCorners = source.roundedCorners;
			roundingRadius = source.roundingRadius;
			roundingSegments = source.roundingSegments;
			innerSegmentDistance = source.innerSegmentDistance;
			tCrossing = source.tCrossing;
			geometryType = source.geometryType;
			resolution = source.resolution;
			connectionHandling = source.connectionHandling;
			frontRoadTypeInt = source.frontRoadTypeInt;
			frontRoadTypeID = source.frontRoadTypeID;
			frontRoadWidth = source.frontRoadWidth;
			frontMaterial = source.frontMaterial;
			frontRoadMaterial = source.frontRoadMaterial;
			frontRoadUVTiling = source.frontRoadUVTiling;
			backRoadTypeInt = source.backRoadTypeInt;
			backRoadTypeID = source.backRoadTypeID;
			backRoadWidth = source.backRoadWidth;
			backMaterial = source.backMaterial;
			backRoadMaterial = source.backRoadMaterial;
			backRoadUVTiling = source.backRoadUVTiling;
			leftRoadTypeInt = source.leftRoadTypeInt;
			leftRoadTypeID = source.leftRoadTypeID;
			leftRoadWidth = source.leftRoadWidth;
			leftMaterial = source.leftMaterial;
			leftRoadMaterial = source.leftRoadMaterial;
			leftRoadUVTiling = source.leftRoadUVTiling;
			rightRoadTypeInt = source.rightRoadTypeInt;
			rightRoadTypeID = source.rightRoadTypeID;
			rightRoadWidth = source.rightRoadWidth;
			rightMaterial = source.rightMaterial;
			rightRoadMaterial = source.rightRoadMaterial;
			rightRoadUVTiling = source.rightRoadUVTiling;
			frontRoadTypeInt = SetRoadTypeInt(frontRoadTypeID);
			backRoadTypeInt = SetRoadTypeInt(backRoadTypeID);
			leftRoadTypeInt = SetRoadTypeInt(leftRoadTypeID);
			rightRoadTypeInt = SetRoadTypeInt(rightRoadTypeID);
			selectedRoadType = source.selectedRoadType;
			uniformCornersFlag = source.uniformCornersFlag;
			selectedCorner = source.selectedCorner;
			selectedCornerPreset = source.selectedCornerPreset;
			cornerPresetName = source.cornerPresetName;
			selectedSidewalkPreset = source.selectedSidewalkPreset;
			sidewalkPresetName = source.sidewalkPresetName;
			OQDOOOQODCCorner = source.OQDOOOQODCCorner;
			leftBottom = source.leftBottom;
			rightBottom = source.rightBottom;
			leftTop = source.leftTop;
			rightTop = source.rightTop;
			frontCenter = source.frontCenter;
			backCenter = source.backCenter;
			leftCenter = source.leftCenter;
			rightCenter = source.rightCenter;
			includeSidewalks = source.defaultSidewalkEnabledStatus;
			defaultSidewalkEnabledStatus = source.defaultSidewalkEnabledStatus;
			if (source.sidewalkControlPoints != null)
			{
				sidewalkControlPoints = new Vector3[source.sidewalkControlPoints.Length];
				Array.Copy(source.sidewalkControlPoints, sidewalkControlPoints, source.sidewalkControlPoints.Length);
			}
			if (source.sidewalkControlStatus != null)
			{
				sidewalkControlStatus = new bool[source.sidewalkControlStatus.Length];
				Array.Copy(source.sidewalkControlStatus, sidewalkControlStatus, source.sidewalkControlStatus.Length);
			}
			prefabScript.crossingElements.Clear();
			prefabScript.sidewalkControlElements.Clear();
			ERCrossingPrefabs component = source.gameObject.GetComponent<ERCrossingPrefabs>();
			if (component != null)
			{
				for (int i = 0; i < component.crossingElements.Count; i++)
				{
					prefabScript.crossingElements.Add(new QDOODOQQDQODD());
					prefabScript.crossingElements[i].rotationPriority = component.crossingElements[i].rotationPriority;
					prefabScript.crossingElements[i].includeLeftSidewalk = component.crossingElements[i].includeLeftSidewalk;
					prefabScript.crossingElements[i].includeRightSidewalk = component.crossingElements[i].includeRightSidewalk;
					prefabScript.crossingElements[i].roadMaterial = component.crossingElements[i].roadMaterial;
					prefabScript.crossingElements[i].roadType = component.crossingElements[i].roadType;
					prefabScript.crossingElements[i].roadTypeTimestamp = component.crossingElements[i].roadTypeTimestamp;
					prefabScript.sidewalkControlElements.Add(new QDOQDSQOOQDDD(UnityEngine.Object.FindObjectOfType(typeof(ERModularBase)) as ERModularBase));
					if (component.sidewalkControlElements.Count > i)
					{
						prefabScript.sidewalkControlElements[i].crossingElementLeftIndex = component.sidewalkControlElements[i].crossingElementLeftIndex;
						prefabScript.sidewalkControlElements[i].crossingElementRightIndex = component.sidewalkControlElements[i].crossingElementRightIndex;
						prefabScript.sidewalkControlElements[i].centerHandleV3 = component.sidewalkControlElements[i].centerHandleV3;
						prefabScript.sidewalkControlElements[i].leftHandleV3 = component.sidewalkControlElements[i].leftHandleV3;
						prefabScript.sidewalkControlElements[i].rightHandleV3 = component.sidewalkControlElements[i].rightHandleV3;
						prefabScript.sidewalkControlElements[i].renderFlag = component.sidewalkControlElements[i].renderFlag;
						prefabScript.sidewalkControlElements[i].leftConnectionHandle = component.sidewalkControlElements[i].leftConnectionHandle;
						prefabScript.sidewalkControlElements[i].rightConnectionHandle = component.sidewalkControlElements[i].rightConnectionHandle;
						prefabScript.sidewalkControlElements[i].sidewalkWidth1 = component.sidewalkControlElements[i].sidewalkWidth1;
						prefabScript.sidewalkControlElements[i].sidewalkWidth2 = component.sidewalkControlElements[i].sidewalkWidth2;
						prefabScript.sidewalkControlElements[i].curbHeight = component.sidewalkControlElements[i].curbHeight;
						prefabScript.sidewalkControlElements[i].curbDepth = component.sidewalkControlElements[i].curbDepth;
						prefabScript.sidewalkControlElements[i].beveledCurb = component.sidewalkControlElements[i].beveledCurb;
						prefabScript.sidewalkControlElements[i].beveledHeight = component.sidewalkControlElements[i].beveledHeight;
						prefabScript.sidewalkControlElements[i].beveledDepth = component.sidewalkControlElements[i].beveledDepth;
						prefabScript.sidewalkControlElements[i].outerCurb = component.sidewalkControlElements[i].outerCurb;
						prefabScript.sidewalkControlElements[i].roadSideCurbUVControl = component.sidewalkControlElements[i].roadSideCurbUVControl;
						prefabScript.sidewalkControlElements[i].outerSideCurbUVControl = component.sidewalkControlElements[i].outerSideCurbUVControl;
						prefabScript.sidewalkControlElements[i].sidewalkMaterial = component.sidewalkControlElements[i].sidewalkMaterial;
						prefabScript.sidewalkControlElements[i].sidewalkUVs = new List<float>(component.sidewalkControlElements[i].sidewalkUVs);
						prefabScript.sidewalkControlElements[i].curbUVs = new List<float>(component.sidewalkControlElements[i].curbUVs);
						prefabScript.sidewalkControlElements[i].lockUVs = component.sidewalkControlElements[i].lockUVs;
						prefabScript.sidewalkControlElements[i].cornerRadius = component.sidewalkControlElements[i].cornerRadius;
						prefabScript.sidewalkControlElements[i].cornerSegments = component.sidewalkControlElements[i].cornerSegments;
						prefabScript.sidewalkControlElements[i].innerSegmentDistance = component.sidewalkControlElements[i].innerSegmentDistance;
						prefabScript.sidewalkControlElements[i].startAngle = component.sidewalkControlElements[i].startAngle;
					}
				}
			}
			if (!defaultSidewalkEnabledStatus)
			{
				for (int i = 0; i < prefabScript.sidewalkControlElements.Count; i++)
				{
					prefabScript.sidewalkControlElements[i].renderFlag = false;
					prefabScript.sidewalkControlElements[i].leftConnectionHandle = false;
					prefabScript.sidewalkControlElements[i].rightConnectionHandle = false;
				}
				for (int i = 0; i < prefabScript.crossingElements.Count; i++)
				{
					prefabScript.crossingElements[i].includeLeftSidewalk = false;
					prefabScript.crossingElements[i].includeRightSidewalk = false;
				}
			}
			if (base.gameObject.name != "")
			{
				crossingName = base.gameObject.name;
			}
			OODDODOQCQ(sidewalkSceneHandleFlag: true, rebuildRoads: false);
		}

		public void OODQDDCQDC()
		{
			debugVecs.Clear();
			normalPairs.Clear();
			startConnectionV3.Clear();
			endConnectionV3.Clear();
			leftConnectionV3.Clear();
			rightConnectionV3.Clear();
			startConnectionUV.Clear();
			endConnectionUV.Clear();
			leftConnectionUV.Clear();
			rightConnectionUV.Clear();
			startConnectionTris.Clear();
			endConnectionTris.Clear();
			leftConnectionTris.Clear();
			rightConnectionTris.Clear();
			leftSidewalkStartV3.Clear();
			rightSidewalkStartV3.Clear();
			leftSidewalkEndV3.Clear();
			rightSidewalkEndV3.Clear();
			leftSidewalkStartUV.Clear();
			rightSidewalkStartUV.Clear();
			leftSidewalkEndUV.Clear();
			rightSidewalkEndUV.Clear();
			leftSidewalkLeftV3.Clear();
			leftSidewalkRightV3.Clear();
			rightSidewalkLeftV3.Clear();
			rightSidewalkRightV3.Clear();
			leftSidewalkLeftUV.Clear();
			leftSidewalkRightUV.Clear();
			rightSidewalkLeftUV.Clear();
			rightSidewalkRightUV.Clear();
			leftSidewalkStartTris.Clear();
			rightSidewalkStartTris.Clear();
			leftSidewalkEndTris.Clear();
			rightSidewalkEndTris.Clear();
			leftSidewalkLeftTris.Clear();
			leftSidewalkRightTris.Clear();
			rightSidewalkLeftTris.Clear();
			rightSidewalkRightTris.Clear();
			OQOCCQDCCO.Clear();
			ODCDCOODCQ.Clear();
			OCDCDQQCDD.Clear();
			OCCDCQDDDD.Clear();
			OQCQCCCQQC.Clear();
			OOOCCCCODQ.Clear();
			OCDDDQCCOO.Clear();
			ODQQCQDOQC.Clear();
			OQOCCQDCCOStart.Clear();
			ODCDCOODCQStart.Clear();
			OCDCDQQCDDStart.Clear();
			OCCDCQDDDDStart.Clear();
			OQCQCCCQQCStart.Clear();
			OOOCCCCODQStart.Clear();
			OCDDDQCCOOStart.Clear();
			ODQQCQDOQCStart.Clear();
			frontLeftRoadInts.Clear();
			frontRightRoadInts.Clear();
			backLeftRoadInts.Clear();
			backRightRoadInts.Clear();
			leftLeftRoadInts.Clear();
			leftRightRoadInts.Clear();
			rightLeftRoadInts.Clear();
			rightRightRoadInts.Clear();
			prefabScript.tCrossingBlendData.Clear();
		}

		public void OODDODOQCQ(bool sidewalkSceneHandleFlag, bool rebuildRoads)
		{
			prefabScript.isERCrossing = true;
			if (oldTCrossing != tCrossing || oldtCrossingLeftRight != tCrossingLeftRight)
			{
				ODCOCDDOCC();
				oldTCrossing = tCrossing;
				oldtCrossingLeftRight = tCrossingLeftRight;
			}
			if (tCrossing)
			{
				if (tCrossingLeftRight == 1)
				{
					prefabScript.sidewalkControlElements[2].renderFlag = prefabScript.sidewalkControlElements[1].renderFlag;
				}
				else
				{
					prefabScript.sidewalkControlElements[3].renderFlag = prefabScript.sidewalkControlElements[0].renderFlag;
				}
			}
			if (uniformCornersFlag)
			{
				for (int i = 0; i < prefabScript.sidewalkControlElements.Count; i++)
				{
					if (i != selectedCorner)
					{
						prefabScript.sidewalkControlElements[i].cornerRadius = prefabScript.sidewalkControlElements[selectedCorner].cornerRadius;
						prefabScript.sidewalkControlElements[i].cornerSegments = prefabScript.sidewalkControlElements[selectedCorner].cornerSegments;
						prefabScript.sidewalkControlElements[i].innerSegmentDistance = prefabScript.sidewalkControlElements[selectedCorner].innerSegmentDistance;
						prefabScript.sidewalkControlElements[i].sidewalkWidth1 = prefabScript.sidewalkControlElements[selectedCorner].sidewalkWidth1;
						prefabScript.sidewalkControlElements[i].sidewalkWidth2 = prefabScript.sidewalkControlElements[selectedCorner].sidewalkWidth2;
						prefabScript.sidewalkControlElements[i].curbHeight = prefabScript.sidewalkControlElements[selectedCorner].curbHeight;
						prefabScript.sidewalkControlElements[i].curbDepth = prefabScript.sidewalkControlElements[selectedCorner].curbDepth;
						prefabScript.sidewalkControlElements[i].beveledCurb = prefabScript.sidewalkControlElements[selectedCorner].beveledCurb;
						prefabScript.sidewalkControlElements[i].beveledHeight = prefabScript.sidewalkControlElements[selectedCorner].beveledHeight;
						prefabScript.sidewalkControlElements[i].beveledDepth = prefabScript.sidewalkControlElements[selectedCorner].beveledDepth;
						prefabScript.sidewalkControlElements[i].outerCurb = prefabScript.sidewalkControlElements[selectedCorner].outerCurb;
						prefabScript.sidewalkControlElements[i].roadSideCurbUVControl = prefabScript.sidewalkControlElements[selectedCorner].roadSideCurbUVControl;
						prefabScript.sidewalkControlElements[i].outerSideCurbUVControl = prefabScript.sidewalkControlElements[selectedCorner].outerSideCurbUVControl;
						prefabScript.sidewalkControlElements[i].sidewalkMaterial = prefabScript.sidewalkControlElements[selectedCorner].sidewalkMaterial;
						prefabScript.sidewalkControlElements[i].sidewalkUVs.Clear();
						prefabScript.sidewalkControlElements[i].sidewalkUVs.AddRange(prefabScript.sidewalkControlElements[selectedCorner].sidewalkUVs);
						prefabScript.sidewalkControlElements[i].curbUVs.Clear();
						prefabScript.sidewalkControlElements[i].curbUVs.AddRange(prefabScript.sidewalkControlElements[selectedCorner].curbUVs);
						prefabScript.sidewalkControlElements[i].lockUVs = prefabScript.sidewalkControlElements[selectedCorner].lockUVs;
					}
				}
			}
			if (sidewalkSceneHandleFlag && includeSidewalkChangeFlag)
			{
				for (int i = 0; i < prefabScript.sidewalkControlElements.Count; i++)
				{
					prefabScript.crossingElements[prefabScript.sidewalkControlElements[i].crossingElementLeftIndex].includeLeftSidewalk = includeSidewalks;
					prefabScript.crossingElements[prefabScript.sidewalkControlElements[i].crossingElementRightIndex].includeRightSidewalk = includeSidewalks;
				}
			}
			OODQDDCQDC();
			float firstSegmentDistance = 0f;
			if (!tCrossing)
			{
				ODQOQQODOD.OOQCCCODOD(this, ref firstSegmentDistance);
				ODQOQQODOD.OQDOQOOQDC(this);
				ODQOQQODOD.OODDQDCQQC(this);
				ODQOQQODOD.OCDDQOODCC(this);
				ODQOQQODOD.OCDQQOQDOC(this);
				leftBottom = startConnectionV3[0][startConnectionV3[0].Count - 1];
				rightBottom = startConnectionV3[startConnectionV3.Count - 1][startConnectionV3[startConnectionV3.Count - 1].Count - 1];
				rightTop = endConnectionV3[0][endConnectionV3[0].Count - 1];
				leftTop = endConnectionV3[endConnectionV3.Count - 1][endConnectionV3[endConnectionV3.Count - 1].Count - 1];
				leftBottom.y = (rightBottom.y = (rightTop.y = (leftTop.y = 0.5f)));
				frontCenter = startConnectionV3[2][0];
				backCenter = endConnectionV3[2][0];
				leftCenter = leftConnectionV3[2][0];
				rightCenter = rightConnectionV3[2][0];
				OOQCCQOCDO.InitODOCDQCCCD(this);
				ERSideWalkVecs.OCDDQODQDQ(this);
				OODOQQQCDD(rebuildRoads);
				return;
			}
			OCODOCOOCO.OOQCCCODOD(this, ref firstSegmentDistance);
			OCODOCOOCO.OQDOQOOQDC(this);
			OCODOCOOCO.OODDQDCQQC(this);
			OCODOCOOCO.OCDDQOODCC(this);
			OCODOCOOCO.OCDQQOQDOC(this);
			OQQQDOQOQQ.InitODOCDQCCCD(this);
			OOQDOCOOCC.OCDDQODQDQ(this);
			leftBottom = startConnectionV3[0][startConnectionV3[0].Count - 1];
			rightBottom = startConnectionV3[startConnectionV3.Count - 1][startConnectionV3[startConnectionV3.Count - 1].Count - 1];
			rightTop = endConnectionV3[0][endConnectionV3[0].Count - 1];
			leftTop = endConnectionV3[endConnectionV3.Count - 1][endConnectionV3[endConnectionV3.Count - 1].Count - 1];
			leftBottom.y = (rightBottom.y = (rightTop.y = (leftTop.y = 0.5f)));
			if (tCrossingLeftRight == 1)
			{
				leftTop = Vector3.zero;
				prefabScript.tConnectionRoadWidth = rightRoadWidth;
			}
			if (tCrossingLeftRight == 0)
			{
				rightTop = Vector3.zero;
				prefabScript.tConnectionRoadWidth = leftRoadWidth;
			}
			prefabScript.tMainRoadWidth = frontRoadWidth;
			OODOQQQCDD(rebuildRoads);
		}

		public void OQOQQCDODO()
		{
		}

		public void OODOQQQCDD(bool rebuildRoads)
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
				mesh.name = base.gameObject.name + "_Mesh";
				base.gameObject.GetComponent<MeshFilter>().sharedMesh = mesh;
				base.gameObject.GetComponent<MeshCollider>().sharedMesh = mesh;
			}
			if (crossingName != "")
			{
				base.gameObject.name = crossingName;
			}
			List<Vector3> meshVecs = new List<Vector3>();
			List<Vector2> meshUVs = new List<Vector2>();
			List<List<int>> triList = new List<List<int>>();
			List<Material> materialList = new List<Material>();
			List<Material> list = new List<Material>();
			triList.Add(new List<int>());
			materialList.Add(frontMaterial);
			list.Add(frontMaterial);
			list.Add(backMaterial);
			list.Add(leftMaterial);
			list.Add(rightMaterial);
			int triArrayElement = 0;
			ODQQCQQQQD.ODCQDQOCDD(ref materialList, ref triList, backMaterial, ref triArrayElement);
			if (!tCrossing || tCrossingLeftRight == 0)
			{
				ODQQCQQQQD.ODCQDQOCDD(ref materialList, ref triList, leftMaterial, ref triArrayElement);
			}
			if (!tCrossing || tCrossingLeftRight == 1)
			{
				ODQQCQQQQD.ODCQDQOCDD(ref materialList, ref triList, rightMaterial, ref triArrayElement);
			}
			if (!tCrossing)
			{
				OOQCCQOCDO.OQDCOOOOCO(this, ref meshVecs, ref meshUVs, ref triList, materialList, list);
			}
			else
			{
				OQQQDOQOQQ.OQDCOOOOCO(this, ref meshVecs, ref meshUVs, ref triList, materialList, list);
			}
			int num = 1;
			for (int i = 0; i < startConnectionV3.Count; i++)
			{
				for (int j = 0; j < startConnectionV3[i].Count; j++)
				{
					num++;
				}
			}
			int num2 = (prefabScript.lastVecRoadIndex = meshVecs.Count - 1);
			ODQQCQQQQD.OQDCOOOOCO(this, ref meshVecs, ref meshUVs, ref triList, ref materialList);
			float num3 = 10000f;
			float num4 = -10000f;
			float num5 = 10000f;
			float num6 = -10000f;
			for (int i = 0; i <= num2; i++)
			{
				if (meshVecs[i].x < num3)
				{
					num3 = meshVecs[i].x;
				}
				if (meshVecs[i].x > num4)
				{
					num4 = meshVecs[i].x;
				}
				if (meshVecs[i].z < num5)
				{
					num5 = meshVecs[i].z;
				}
				if (meshVecs[i].z > num6)
				{
					num6 = meshVecs[i].z;
				}
			}
			float num7 = num4 - num3;
			float num8 = num6 - num5;
			List<Vector2> list2 = new List<Vector2>();
			for (int i = 0; i < meshVecs.Count; i++)
			{
				list2.Add(new Vector2((meshVecs[i].x - num3) / num7, (meshVecs[i].z - num5) / num8));
			}
			mesh.Clear();
			mesh.subMeshCount = triList.Count;
			mesh.vertices = meshVecs.ToArray();
			mesh.uv = meshUVs.ToArray();
			mesh.uv4 = list2.ToArray();
			mesh.tangents = new Vector4[mesh.vertices.Length];
			for (int i = 0; i < triList.Count; i++)
			{
				mesh.SetTriangles(triList[i].ToArray(), i);
			}
			mesh.RecalculateBounds();
			mesh.RecalculateNormals();
			mesh.name = "mesh";
			mesh.normals = ERSideWalkVecs.OODOCDCQDC(this, mesh.normals);
			OCQQDQQCQQ.OOCCQOQQQC(mesh);
			mesh.tangents = ERSideWalkVecs.AdjustSidewalkTangents(this, mesh.tangents);
			base.gameObject.GetComponent<MeshCollider>().sharedMesh = mesh;
			base.gameObject.GetComponent<MeshRenderer>().sharedMaterials = materialList.ToArray();
			prefabScript.meshVecs = meshVecs.ToArray();
			prefabScript.tmpMeshVecs = new Vector3[prefabScript.meshVecs.Length];
			Array.Copy(prefabScript.meshVecs, prefabScript.tmpMeshVecs, prefabScript.meshVecs.Length);
			prefabScript.tmpFullMeshVecs = new Vector3[prefabScript.meshVecs.Length];
			Array.Copy(prefabScript.meshVecs, prefabScript.tmpFullMeshVecs, prefabScript.meshVecs.Length);
			prefabScript.fullMeshVecs = new Vector3[prefabScript.meshVecs.Length];
			Array.Copy(prefabScript.meshVecs, prefabScript.fullMeshVecs, prefabScript.meshVecs.Length);
			prefabScript.tCrossingTmpFullMeshVecs = new Vector3[prefabScript.meshVecs.Length];
			Array.Copy(prefabScript.meshVecs, prefabScript.tCrossingTmpFullMeshVecs, prefabScript.meshVecs.Length);
			prefabScript.tCrossing = tCrossing;
			prefabScript.tStraightBending = tStraightBending;
			prefabScript.tCrossingLeftRight = tCrossingLeftRight;
			prefabScript.planarUVs = planarUVs;
			prefabScript.planarTiling = planarTiling;
			int index = Mathf.RoundToInt(Mathf.Floor((float)startConnectionV3.Count * 0.5f));
			prefabScript.crossingElements[0].centerPoint = (prefabScript.crossingElements[0].tmpCenterPoint = startConnectionV3[index][0]);
			index = Mathf.RoundToInt(Mathf.Floor((float)endConnectionV3.Count * 0.5f));
			prefabScript.crossingElements[1].centerPoint = (prefabScript.crossingElements[1].tmpCenterPoint = endConnectionV3[index][0]);
			if (!tCrossing || tCrossingLeftRight == 0)
			{
				index = Mathf.RoundToInt(Mathf.Floor((float)leftConnectionV3.Count * 0.5f));
				prefabScript.crossingElements[2].centerPoint = (prefabScript.crossingElements[2].tmpCenterPoint = leftConnectionV3[index][0]);
			}
			else
			{
				prefabScript.crossingElements[2].centerPoint = (prefabScript.crossingElements[2].tmpCenterPoint = Vector3.zero);
			}
			if (!tCrossing || tCrossingLeftRight == 1)
			{
				index = Mathf.RoundToInt(Mathf.Floor((float)rightConnectionV3.Count * 0.5f));
				prefabScript.crossingElements[3].centerPoint = (prefabScript.crossingElements[3].tmpCenterPoint = rightConnectionV3[index][0]);
			}
			else
			{
				prefabScript.crossingElements[3].centerPoint = (prefabScript.crossingElements[3].tmpCenterPoint = Vector3.zero);
			}
			prefabScript.crossingElements[0].controlPointV3 = Vector3.zero;
			prefabScript.crossingElements[1].controlPointV3 = Vector3.zero;
			prefabScript.crossingElements[2].controlPointV3 = Vector3.zero;
			prefabScript.crossingElements[3].controlPointV3 = Vector3.zero;
			ODQDCQOQQC(0, startConnectionTris, uvArrayFront, leftSidewalkStartTris, rightSidewalkStartTris, 0);
			ODQDCQOQQC(1, endConnectionTris, uvArrayBack, leftSidewalkEndTris, rightSidewalkEndTris, 1);
			if (!tCrossing || tCrossingLeftRight == 0)
			{
				ODQDCQOQQC(2, leftConnectionTris, uvArrayLeft, leftSidewalkLeftTris, rightSidewalkLeftTris, 0);
			}
			if (!tCrossing || tCrossingLeftRight == 1)
			{
				ODQDCQOQQC(3, rightConnectionTris, uvArrayRight, leftSidewalkRightTris, rightSidewalkRightTris, 1);
			}
			OQDQDQOQDO(meshVecs, prefabScript.crossingElements[0].connectionVecInts, ref prefabScript.crossingElements[0].roadShapeVecs, startConnectionV3, leftSidewalkStartV3, rightSidewalkStartV3, 0, 0);
			prefabScript.crossingElements[0].roadShapeVecsString = GetRoadShapeVecString(prefabScript.crossingElements[0].roadShapeVecs, prefabScript.crossingElements[0].sidewalkLeftVecs, prefabScript.crossingElements[0].sidewalkRightVecs, ref prefabScript.crossingElements[0].roadShapeMatchCount);
			OQDQDQOQDO(meshVecs, prefabScript.crossingElements[1].connectionVecInts, ref prefabScript.crossingElements[1].roadShapeVecs, endConnectionV3, leftSidewalkEndV3, rightSidewalkEndV3, 1, 1);
			prefabScript.crossingElements[1].roadShapeVecsString = GetRoadShapeVecString(prefabScript.crossingElements[1].roadShapeVecs, prefabScript.crossingElements[1].sidewalkLeftVecs, prefabScript.crossingElements[1].sidewalkRightVecs, ref prefabScript.crossingElements[1].roadShapeMatchCount);
			if (!tCrossing || tCrossingLeftRight == 0)
			{
				OQDQDQOQDO(meshVecs, prefabScript.crossingElements[2].connectionVecInts, ref prefabScript.crossingElements[2].roadShapeVecs, leftConnectionV3, leftSidewalkLeftV3, rightSidewalkLeftV3, 2, 0);
				prefabScript.crossingElements[2].roadShapeVecsString = GetRoadShapeVecString(prefabScript.crossingElements[2].roadShapeVecs, prefabScript.crossingElements[2].sidewalkLeftVecs, prefabScript.crossingElements[2].sidewalkRightVecs, ref prefabScript.crossingElements[2].roadShapeMatchCount);
				if (tCrossing)
				{
					prefabScript.crossingElements[3].roadShapeMatchCount = -1;
				}
			}
			if (!tCrossing || tCrossingLeftRight == 1)
			{
				OQDQDQOQDO(meshVecs, prefabScript.crossingElements[3].connectionVecInts, ref prefabScript.crossingElements[3].roadShapeVecs, rightConnectionV3, leftSidewalkRightV3, rightSidewalkRightV3, 3, 1);
				prefabScript.crossingElements[3].roadShapeVecsString = GetRoadShapeVecString(prefabScript.crossingElements[3].roadShapeVecs, prefabScript.crossingElements[3].sidewalkLeftVecs, prefabScript.crossingElements[3].sidewalkRightVecs, ref prefabScript.crossingElements[3].roadShapeMatchCount);
				if (tCrossing)
				{
					prefabScript.crossingElements[2].roadShapeMatchCount = -1;
				}
			}
			prefabScript.crossingElements[0].alignmentHandleVec = Vector3.zero;
			prefabScript.crossingElements[1].alignmentHandleVec = Vector3.zero;
			prefabScript.crossingElements[2].alignmentHandleVec = Vector3.zero;
			prefabScript.crossingElements[3].alignmentHandleVec = Vector3.zero;
			OQCQCQDDCD(0, frontRoadMaterial, 0, 1, leftSidewalkStartV3.Count, rightSidewalkStartV3.Count);
			OQCQCQDDCD(1, backRoadMaterial, 3, 2, leftSidewalkEndV3.Count, rightSidewalkEndV3.Count);
			if (!tCrossing || tCrossingLeftRight == 0)
			{
				OQCQCQDDCD(2, leftRoadMaterial, 2, 0, leftSidewalkLeftV3.Count, rightSidewalkLeftV3.Count);
			}
			if (!tCrossing || tCrossingLeftRight == 1)
			{
				OQCQCQDDCD(3, rightRoadMaterial, 1, 3, leftSidewalkRightV3.Count, rightSidewalkRightV3.Count);
			}
			OCQCDCQDOD();
			prefabScript.OCODQQCQQO();
			prefabScript.tmpSurfaceVecsTCrossings = new Vector3[prefabScript.surfaceMeshVecs.Length];
			Array.Copy(prefabScript.surfaceMeshVecs, prefabScript.tmpSurfaceVecsTCrossings, prefabScript.surfaceMeshVecs.Length);
			OCOCOODCCO();
			ODDQDQDQQC();
			if (roadTypesDynamic.Count >= 1)
			{
				if (frontRoadTypeInt > 0)
				{
					if (prefabScript.crossingElements[0].roadType != roadTypesDynamic[frontRoadTypeInt - 1].id)
					{
						frontRoadTypeID = roadTypesDynamic[frontRoadTypeInt - 1].id;
						prefabScript.crossingElements[0].roadType = frontRoadTypeID;
						prefabScript.crossingElements[0].roadTypeTimestamp = roadTypesDynamic[frontRoadTypeInt - 1].timestamp;
					}
				}
				else
				{
					prefabScript.crossingElements[0].roadType = 0.0;
				}
				if (backRoadTypeInt == 0 && (connectionHandling == 0 || connectionHandling == 1))
				{
					backRoadTypeInt = frontRoadTypeInt;
				}
				if (backRoadTypeInt > 0)
				{
					if (prefabScript.crossingElements[1].roadType != roadTypesDynamic[backRoadTypeInt - 1].id)
					{
						backRoadTypeID = roadTypesDynamic[backRoadTypeInt - 1].id;
						prefabScript.crossingElements[1].roadType = backRoadTypeID;
						prefabScript.crossingElements[1].roadTypeTimestamp = roadTypesDynamic[backRoadTypeInt - 1].timestamp;
					}
				}
				else
				{
					prefabScript.crossingElements[1].roadType = 0.0;
				}
				if (leftRoadTypeInt == 0 && connectionHandling == 0)
				{
					leftRoadTypeInt = frontRoadTypeInt;
				}
				if (leftRoadTypeInt != 0)
				{
					if (prefabScript.crossingElements[2].roadType != roadTypesDynamic[leftRoadTypeInt - 1].id)
					{
						leftRoadTypeID = roadTypesDynamic[leftRoadTypeInt - 1].id;
						prefabScript.crossingElements[2].roadType = leftRoadTypeID;
						prefabScript.crossingElements[2].roadTypeTimestamp = roadTypesDynamic[leftRoadTypeInt - 1].timestamp;
					}
				}
				else
				{
					prefabScript.crossingElements[2].roadType = 0.0;
				}
				if (rightRoadTypeInt == 0 && (connectionHandling == 0 || connectionHandling == 1))
				{
					rightRoadTypeInt = leftRoadTypeInt;
				}
				if (rightRoadTypeInt != 0)
				{
					if (prefabScript.crossingElements[3].roadType != roadTypesDynamic[rightRoadTypeInt - 1].id)
					{
						rightRoadTypeID = roadTypesDynamic[rightRoadTypeInt - 1].id;
						prefabScript.crossingElements[3].roadType = rightRoadTypeID;
						prefabScript.crossingElements[3].roadTypeTimestamp = roadTypesDynamic[rightRoadTypeInt - 1].timestamp;
					}
				}
				else
				{
					prefabScript.crossingElements[3].roadType = 0.0;
				}
			}
			if (rebuildRoads)
			{
				prefabScript.OCOOQCCDQO(ignorePriority: true, null);
			}
		}

		public void ODQDCQOQQC(int el, List<List<int>> trIntArray, List<float> uvArray, List<List<int>> leftSidewalkIntArray, List<List<int>> rightSidewalkIntArray, int startend)
		{
			QDOODOQQDQODD qDOODOQQDQODD = prefabScript.crossingElements[el];
			qDOODOQQDQODD.connectionVecInts.Clear();
			qDOODOQQDQODD.blendCornerPointInts.Clear();
			qDOODOQQDQODD.blendCornerPointWeights.Clear();
			qDOODOQQDQODD.roadShapeUVY.Clear();
			QDOQDSQOOQDDD qDOQDSQOOQDDD = null;
			QDOQDSQOOQDDD qDOQDSQOOQDDD2 = null;
			switch (el)
			{
			case 0:
				qDOQDSQOOQDDD = prefabScript.sidewalkControlElements[0];
				qDOQDSQOOQDDD2 = prefabScript.sidewalkControlElements[1];
				break;
			case 1:
				qDOQDSQOOQDDD = prefabScript.sidewalkControlElements[3];
				qDOQDSQOOQDDD2 = prefabScript.sidewalkControlElements[2];
				qDOQDSQOOQDDD2 = prefabScript.sidewalkControlElements[0];
				break;
			case 2:
				qDOQDSQOOQDDD = prefabScript.sidewalkControlElements[2];
				qDOQDSQOOQDDD2 = prefabScript.sidewalkControlElements[0];
				break;
			case 3:
				qDOQDSQOOQDDD = prefabScript.sidewalkControlElements[1];
				qDOQDSQOOQDDD2 = prefabScript.sidewalkControlElements[3];
				break;
			}
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
			qDOODOQQDQODD.connectionVecInts.Add(trIntArray[0][0]);
			qDOODOQQDQODD.connectionVecInts.Add(trIntArray[trIntArray.Count - 1][0]);
			qDOODOQQDQODD.roadShapeUVY.Add(uvArray[0]);
			qDOODOQQDQODD.roadShapeUVY.Add(uvArray[uvArray.Count - 1]);
			if (startend == 1)
			{
				qDOODOQQDQODD.roadShapeUVY[0] = 1f - qDOODOQQDQODD.roadShapeUVY[0];
				qDOODOQQDQODD.roadShapeUVY[1] = 1f - qDOODOQQDQODD.roadShapeUVY[1];
			}
			qDOODOQQDQODD.sidewalkRightUVY.Clear();
			qDOODOQQDQODD.sidewalkRightConnectionVecInts.Clear();
			if (qDOODOQQDQODD.includeRightSidewalk)
			{
				for (int i = 0; i < rightSidewalkIntArray.Count; i++)
				{
					qDOODOQQDQODD.sidewalkRightConnectionVecInts.Add(rightSidewalkIntArray[i][0]);
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
			if (startend != 1)
			{
			}
		}

		public void OQCQCQDDCD(int el, Material roadMaterial, int leftCorner, int rightCorner, int leftVecCount, int rightVecCount)
		{
			QDOODOQQDQODD qDOODOQQDQODD = prefabScript.crossingElements[el];
			QDOQDSQOOQDDD qDOQDSQOOQDDD = prefabScript.sidewalkControlElements[leftCorner];
			QDOQDSQOOQDDD qDOQDSQOOQDDD2 = prefabScript.sidewalkControlElements[rightCorner];
			qDOODOQQDQODD.roadMaterial = roadMaterial;
			List<Material> list = new List<Material>();
			List<int> list2 = new List<int>();
			list.Add(roadMaterial);
			if (qDOODOQQDQODD.includeLeftSidewalk)
			{
				if (list[0] != qDOQDSQOOQDDD.sidewalkMaterial)
				{
					list.Add(qDOQDSQOOQDDD.sidewalkMaterial);
					for (int i = 0; i < leftVecCount; i++)
					{
						list2.Add(1);
					}
				}
				else
				{
					for (int i = 0; i < leftVecCount; i++)
					{
						list2.Add(0);
					}
				}
			}
			list2.Add(0);
			list2.Add(0);
			if (qDOODOQQDQODD.includeRightSidewalk)
			{
				if (list[0] != qDOQDSQOOQDDD2.sidewalkMaterial && qDOQDSQOOQDDD.sidewalkMaterial != qDOQDSQOOQDDD2.sidewalkMaterial && qDOODOQQDQODD.includeLeftSidewalk)
				{
					list.Add(qDOQDSQOOQDDD2.sidewalkMaterial);
					for (int i = 0; i < rightVecCount; i++)
					{
						list2.Add(2);
					}
				}
				else if (list[0] == qDOQDSQOOQDDD2.sidewalkMaterial)
				{
					for (int i = 0; i < rightVecCount; i++)
					{
						list2.Add(0);
					}
				}
				else if (qDOQDSQOOQDDD.sidewalkMaterial == qDOQDSQOOQDDD2.sidewalkMaterial || !qDOODOQQDQODD.includeLeftSidewalk)
				{
					if (!qDOODOQQDQODD.includeLeftSidewalk)
					{
						list.Add(qDOQDSQOOQDDD2.sidewalkMaterial);
					}
					for (int i = 0; i < rightVecCount; i++)
					{
						list2.Add(1);
					}
				}
			}
			qDOODOQQDQODD.roadMaterials = list.ToArray();
			qDOODOQQDQODD.roadShapeMaterialInts.Clear();
			qDOODOQQDQODD.roadShapeMaterialInts.AddRange(list2);
			switch (el)
			{
			case 0:
				qDOODOQQDQODD.alignmentHandleVec = Vector3.Lerp(Vector3.zero, startConnectionV3[2][0], 0.5f);
				break;
			case 1:
				qDOODOQQDQODD.alignmentHandleVec = Vector3.Lerp(Vector3.zero, endConnectionV3[2][0], 0.5f);
				break;
			case 2:
				qDOODOQQDQODD.alignmentHandleVec = Vector3.Lerp(Vector3.zero, leftConnectionV3[2][0], 0.5f);
				break;
			case 3:
				qDOODOQQDQODD.alignmentHandleVec = Vector3.Lerp(Vector3.zero, rightConnectionV3[2][0], 0.5f);
				break;
			}
		}

		public void OQDQDQOQDO(List<Vector3> meshVecs, List<int> connectionVecInts, ref List<Vector2> roadShapeVecs, List<List<Vector3>> vecArrays, List<List<Vector3>> leftSidewalkArray, List<List<Vector3>> rightSidewalkArray, int connectionElement, int startend)
		{
			QDOODOQQDQODD qDOODOQQDQODD = prefabScript.crossingElements[connectionElement];
			roadShapeVecs.Clear();
			qDOODOQQDQODD.sidewalkLeftVecs.Clear();
			qDOODOQQDQODD.sidewalkRightVecs.Clear();
			Vector3 zero;
			Vector3 vector = (zero = Vector3.zero);
			Vector3 vector2 = vecArrays[0][0];
			Vector3 b = vecArrays[vecArrays.Count - 1][0];
			vector2.y = 0f;
			b.y = 0f;
			Vector3 vector3 = Vector3.Lerp(vector2, b, 0.5f);
			float num = Vector3.Distance(vector2, vector3);
			for (int i = 0; i < connectionVecInts.Count - 1; i++)
			{
			}
			List<Vector3> list = new List<Vector3>();
			if (qDOODOQQDQODD.includeLeftSidewalk)
			{
				for (int i = 0; i < leftSidewalkArray.Count; i++)
				{
					list.Add(leftSidewalkArray[i][0]);
				}
				list.Reverse();
				vector = list[0];
				vector2 = vector;
				vector2.y = 0f;
				num = Vector3.Distance(vector2, vector3);
				OCCCQDQOOD(list, ref qDOODOQQDQODD.sidewalkLeftVecs, vector3, vector2, num);
			}
			list.Clear();
			list.Add(vecArrays[0][0]);
			list.Add(vecArrays[vecArrays.Count - 1][0]);
			if (vector == Vector3.zero)
			{
				vector = list[0];
			}
			zero = list[list.Count - 1];
			OCCCQDQOOD(list, ref roadShapeVecs, vector3, vector2, num);
			if (qDOODOQQDQODD.includeRightSidewalk)
			{
				list.Clear();
				for (int i = 0; i < rightSidewalkArray.Count; i++)
				{
					list.Add(rightSidewalkArray[i][0]);
				}
				zero = list[list.Count - 1];
				OCCCQDQOOD(list, ref qDOODOQQDQODD.sidewalkRightVecs, vector3, vector2, num);
			}
			vector.y = 0f;
			zero.y = 0f;
			float num2 = Vector3.Distance(vector, zero);
			qDOODOQQDQODD.centerPointPercentage = num / num2;
		}

		public static void OCCCQDQOOD(List<Vector3> sourceVecs, ref List<Vector2> roadShapeVecs, Vector3 centerPoint, Vector3 startPoint, float halfWayDistance)
		{
			Vector2 zero = Vector2.zero;
			for (int i = 0; i < sourceVecs.Count; i++)
			{
				Vector3 vector = sourceVecs[i];
				float y = vector.y;
				vector.y = 0f;
				zero.x = Vector3.Distance(vector, centerPoint);
				if (Vector3.Distance(startPoint, vector) < halfWayDistance)
				{
					zero.x *= -1f;
				}
				zero.y = y;
				roadShapeVecs.Add(zero);
			}
		}

		public static string GetRoadShapeVecString(List<Vector2> vecs, List<Vector2> lvecs, List<Vector2> rvecs, ref int matchCount)
		{
			List<Vector2> list = new List<Vector2>(lvecs);
			list.AddRange(vecs);
			list.AddRange(rvecs);
			matchCount = 0;
			string text = "";
			bool flag = true;
			for (int i = 0; i < list.Count; i++)
			{
				flag = true;
				if (i > 0 && (double)Vector2.Distance(list[i - 1], list[i]) < 0.01)
				{
					flag = false;
				}
				if (flag)
				{
					Vector2 vector = list[i];
					vector.x = (float)Math.Round(vector.x, 1, MidpointRounding.AwayFromZero);
					vector.y = (float)Math.Round(vector.y, 1, MidpointRounding.AwayFromZero);
					string text2 = text;
					text = text2 + vector.x + ", " + vector.y + ";";
					matchCount++;
				}
			}
			return text;
		}

		public void OCQCDCQDOD()
		{
			prefabScript.surfaceInts = new int[16];
			List<int> list = new List<int>();
			if (prefabScript.sidewalkControlElements[0].renderFlag)
			{
				List<int> list2 = rightSidewalkStartTris[rightSidewalkStartTris.Count - 1];
				prefabScript.surfaceInts[2] = list2[list2.Count - 1];
				prefabScript.surfaceInts[3] = list2[0];
				if (!tCrossing || tCrossingLeftRight == 1)
				{
					list2 = leftSidewalkRightTris[leftSidewalkRightTris.Count - 1];
					prefabScript.surfaceInts[12] = list2[list2.Count - 1];
					prefabScript.surfaceInts[13] = list2[0];
				}
				else
				{
					list.AddRange(list2);
					list2.Clear();
					list2.AddRange(leftSidewalkEndTris[leftSidewalkEndTris.Count - 1]);
					prefabScript.surfaceInts[12] = list2[list2.Count - 1];
					prefabScript.surfaceInts[13] = list2[0];
					list2.Reverse();
					list.AddRange(list2);
				}
			}
			else
			{
				List<int> list2 = startConnectionTris[startConnectionTris.Count - 1];
				prefabScript.surfaceInts[2] = list2[list2.Count - 1];
				prefabScript.surfaceInts[3] = list2[0];
				if (!tCrossing || tCrossingLeftRight == 1)
				{
					list2 = rightConnectionTris[0];
					prefabScript.surfaceInts[12] = list2[list2.Count - 1];
					prefabScript.surfaceInts[13] = list2[0];
				}
				else
				{
					list.AddRange(list2);
					list2.Clear();
					list2.AddRange(endConnectionTris[0]);
					prefabScript.surfaceInts[12] = list2[list2.Count - 1];
					prefabScript.surfaceInts[13] = list2[0];
					list2.Reverse();
					list.AddRange(list2);
				}
			}
			if (prefabScript.sidewalkControlElements[1].renderFlag)
			{
				List<int> list2 = leftSidewalkStartTris[leftSidewalkStartTris.Count - 1];
				prefabScript.surfaceInts[0] = list2[list2.Count - 1];
				prefabScript.surfaceInts[1] = list2[0];
				if (!tCrossing || tCrossingLeftRight == 0)
				{
					list2 = rightSidewalkLeftTris[rightSidewalkLeftTris.Count - 1];
					prefabScript.surfaceInts[10] = list2[list2.Count - 1];
					prefabScript.surfaceInts[11] = list2[0];
				}
				else
				{
					list.AddRange(list2);
					list2.Clear();
					list2.AddRange(rightSidewalkEndTris[rightSidewalkEndTris.Count - 1]);
					prefabScript.surfaceInts[10] = list2[list2.Count - 1];
					prefabScript.surfaceInts[11] = list2[0];
					list2.Reverse();
					list.AddRange(list2);
				}
			}
			else
			{
				List<int> list2 = startConnectionTris[0];
				prefabScript.surfaceInts[0] = list2[list2.Count - 1];
				prefabScript.surfaceInts[1] = list2[0];
				if (!tCrossing || tCrossingLeftRight == 0)
				{
					list2 = leftConnectionTris[leftConnectionTris.Count - 1];
					prefabScript.surfaceInts[10] = list2[list2.Count - 1];
					prefabScript.surfaceInts[11] = list2[0];
				}
				else
				{
					list.AddRange(list2);
					list2.Clear();
					list2.AddRange(endConnectionTris[endConnectionTris.Count - 1]);
					prefabScript.surfaceInts[10] = list2[list2.Count - 1];
					prefabScript.surfaceInts[11] = list2[0];
					list2.Reverse();
					list.AddRange(list2);
				}
			}
			if (prefabScript.sidewalkControlElements[2].renderFlag)
			{
				List<int> list2 = rightSidewalkEndTris[rightSidewalkEndTris.Count - 1];
				prefabScript.surfaceInts[4] = list2[list2.Count - 1];
				prefabScript.surfaceInts[5] = list2[0];
				if (!tCrossing || tCrossingLeftRight == 0)
				{
					list2 = leftSidewalkLeftTris[leftSidewalkLeftTris.Count - 1];
					prefabScript.surfaceInts[8] = list2[list2.Count - 1];
					prefabScript.surfaceInts[9] = list2[0];
				}
				else
				{
					list2 = leftSidewalkStartTris[leftSidewalkStartTris.Count - 1];
					prefabScript.surfaceInts[8] = list2[list2.Count - 1];
					prefabScript.surfaceInts[9] = list2[0];
				}
			}
			else
			{
				List<int> list2 = endConnectionTris[endConnectionTris.Count - 1];
				prefabScript.surfaceInts[4] = list2[list2.Count - 1];
				prefabScript.surfaceInts[5] = list2[0];
				if (!tCrossing || tCrossingLeftRight == 0)
				{
					list2 = leftConnectionTris[0];
					prefabScript.surfaceInts[8] = list2[list2.Count - 1];
					prefabScript.surfaceInts[9] = list2[0];
				}
				else
				{
					list2 = startConnectionTris[0];
					prefabScript.surfaceInts[8] = list2[list2.Count - 1];
					prefabScript.surfaceInts[9] = list2[0];
				}
			}
			if (prefabScript.sidewalkControlElements[3].renderFlag)
			{
				List<int> list2 = leftSidewalkEndTris[leftSidewalkEndTris.Count - 1];
				prefabScript.surfaceInts[6] = list2[list2.Count - 1];
				prefabScript.surfaceInts[7] = list2[0];
				if (!tCrossing || tCrossingLeftRight == 1)
				{
					list2 = rightSidewalkRightTris[rightSidewalkRightTris.Count - 1];
					prefabScript.surfaceInts[14] = list2[list2.Count - 1];
					prefabScript.surfaceInts[15] = list2[0];
				}
				else
				{
					list2 = rightSidewalkStartTris[rightSidewalkStartTris.Count - 1];
					prefabScript.surfaceInts[14] = list2[list2.Count - 1];
					prefabScript.surfaceInts[15] = list2[0];
				}
			}
			else
			{
				List<int> list2 = endConnectionTris[0];
				prefabScript.surfaceInts[6] = list2[list2.Count - 1];
				prefabScript.surfaceInts[7] = list2[0];
				if (!tCrossing || tCrossingLeftRight == 1)
				{
					list2 = rightConnectionTris[rightConnectionTris.Count - 1];
					prefabScript.surfaceInts[14] = list2[list2.Count - 1];
					prefabScript.surfaceInts[15] = list2[0];
				}
				else
				{
					list2 = startConnectionTris[startConnectionTris.Count - 1];
					prefabScript.surfaceInts[14] = list2[list2.Count - 1];
					prefabScript.surfaceInts[15] = list2[0];
				}
			}
			if (tCrossing)
			{
				List<int> collection = new List<int>(prefabScript.surfaceInts);
				list.InsertRange(0, collection);
				prefabScript.surfaceInts = list.ToArray();
			}
		}

		public void OQOOOCDQQO(ERModularBase scr, int el)
		{
			selectedSidewalkPreset = el;
			if (!uniformCornersFlag)
			{
				prefabScript.sidewalkControlElements[selectedCorner].sidewalkWidth1 = scr.sidewalkPresets[selectedSidewalkPreset - 1].sidewalkWidth1;
				prefabScript.sidewalkControlElements[selectedCorner].sidewalkWidth2 = scr.sidewalkPresets[selectedSidewalkPreset - 1].sidewalkWidth2;
				prefabScript.sidewalkControlElements[selectedCorner].curbHeight = scr.sidewalkPresets[selectedSidewalkPreset - 1].curbHeight;
				prefabScript.sidewalkControlElements[selectedCorner].curbDepth = scr.sidewalkPresets[selectedSidewalkPreset - 1].curbDepth;
				prefabScript.sidewalkControlElements[selectedCorner].beveledCurb = scr.sidewalkPresets[selectedSidewalkPreset - 1].beveledCurb;
				prefabScript.sidewalkControlElements[selectedCorner].beveledHeight = scr.sidewalkPresets[selectedSidewalkPreset - 1].beveledHeight;
				prefabScript.sidewalkControlElements[selectedCorner].beveledDepth = scr.sidewalkPresets[selectedSidewalkPreset - 1].beveledDepth;
				prefabScript.sidewalkControlElements[selectedCorner].outerCurb = scr.sidewalkPresets[selectedSidewalkPreset - 1].outerCurb;
				prefabScript.sidewalkControlElements[selectedCorner].roadSideCurbUVControl = scr.sidewalkPresets[selectedSidewalkPreset - 1].roadSideCurbUVControl;
				prefabScript.sidewalkControlElements[selectedCorner].outerSideCurbUVControl = scr.sidewalkPresets[selectedSidewalkPreset - 1].outerSideCurbUVControl;
				prefabScript.sidewalkControlElements[selectedCorner].sidewalkMaterial = scr.sidewalkPresets[selectedSidewalkPreset - 1].sidewalkMaterial;
				prefabScript.sidewalkControlElements[selectedCorner].sidewalkUVs.Clear();
				prefabScript.sidewalkControlElements[selectedCorner].sidewalkUVs.AddRange(scr.sidewalkPresets[selectedSidewalkPreset - 1].sidewalkUVs);
				prefabScript.sidewalkControlElements[selectedCorner].curbUVs.Clear();
				prefabScript.sidewalkControlElements[selectedCorner].curbUVs.AddRange(scr.sidewalkPresets[selectedSidewalkPreset - 1].curbUVs);
				prefabScript.sidewalkControlElements[selectedCorner].lockUVs = scr.sidewalkPresets[selectedSidewalkPreset - 1].lockUVs;
				return;
			}
			for (int i = 0; i < prefabScript.sidewalkControlElements.Count; i++)
			{
				prefabScript.sidewalkControlElements[i].sidewalkWidth1 = scr.sidewalkPresets[selectedSidewalkPreset - 1].sidewalkWidth1;
				prefabScript.sidewalkControlElements[i].sidewalkWidth2 = scr.sidewalkPresets[selectedSidewalkPreset - 1].sidewalkWidth2;
				prefabScript.sidewalkControlElements[i].curbHeight = scr.sidewalkPresets[selectedSidewalkPreset - 1].curbHeight;
				prefabScript.sidewalkControlElements[i].curbDepth = scr.sidewalkPresets[selectedSidewalkPreset - 1].curbDepth;
				prefabScript.sidewalkControlElements[i].beveledCurb = scr.sidewalkPresets[selectedSidewalkPreset - 1].beveledCurb;
				prefabScript.sidewalkControlElements[i].beveledHeight = scr.sidewalkPresets[selectedSidewalkPreset - 1].beveledHeight;
				prefabScript.sidewalkControlElements[i].beveledDepth = scr.sidewalkPresets[selectedSidewalkPreset - 1].beveledDepth;
				prefabScript.sidewalkControlElements[i].outerCurb = scr.sidewalkPresets[selectedSidewalkPreset - 1].outerCurb;
				prefabScript.sidewalkControlElements[i].roadSideCurbUVControl = scr.sidewalkPresets[selectedSidewalkPreset - 1].roadSideCurbUVControl;
				prefabScript.sidewalkControlElements[i].outerSideCurbUVControl = scr.sidewalkPresets[selectedSidewalkPreset - 1].outerSideCurbUVControl;
				prefabScript.sidewalkControlElements[i].sidewalkMaterial = scr.sidewalkPresets[selectedSidewalkPreset - 1].sidewalkMaterial;
				prefabScript.sidewalkControlElements[i].sidewalkUVs.Clear();
				prefabScript.sidewalkControlElements[i].sidewalkUVs.AddRange(scr.sidewalkPresets[selectedSidewalkPreset - 1].sidewalkUVs);
				prefabScript.sidewalkControlElements[i].curbUVs.Clear();
				prefabScript.sidewalkControlElements[i].curbUVs.AddRange(scr.sidewalkPresets[selectedSidewalkPreset - 1].curbUVs);
				prefabScript.sidewalkControlElements[i].lockUVs = scr.sidewalkPresets[selectedSidewalkPreset - 1].lockUVs;
			}
		}

		public void OCOCOODCCO()
		{
			sidewalkControlPoints = new Vector3[12];
			prefabScript.sidewalkControlElements[0].centerHandleV3 = prefabScript.meshVecs[prefabScript.surfaceInts[2]];
			prefabScript.sidewalkControlElements[0].leftHandleV3 = prefabScript.meshVecs[prefabScript.surfaceInts[13]];
			prefabScript.sidewalkControlElements[0].rightHandleV3 = prefabScript.meshVecs[prefabScript.surfaceInts[3]];
			prefabScript.sidewalkControlElements[1].centerHandleV3 = prefabScript.meshVecs[prefabScript.surfaceInts[0]];
			prefabScript.sidewalkControlElements[1].leftHandleV3 = prefabScript.meshVecs[prefabScript.surfaceInts[1]];
			prefabScript.sidewalkControlElements[1].rightHandleV3 = prefabScript.meshVecs[prefabScript.surfaceInts[11]];
			prefabScript.sidewalkControlElements[2].centerHandleV3 = prefabScript.meshVecs[prefabScript.surfaceInts[4]];
			prefabScript.sidewalkControlElements[2].leftHandleV3 = prefabScript.meshVecs[prefabScript.surfaceInts[9]];
			prefabScript.sidewalkControlElements[2].rightHandleV3 = prefabScript.meshVecs[prefabScript.surfaceInts[5]];
			prefabScript.sidewalkControlElements[3].centerHandleV3 = prefabScript.meshVecs[prefabScript.surfaceInts[6]];
			prefabScript.sidewalkControlElements[3].leftHandleV3 = prefabScript.meshVecs[prefabScript.surfaceInts[7]];
			prefabScript.sidewalkControlElements[3].rightHandleV3 = prefabScript.meshVecs[prefabScript.surfaceInts[15]];
		}

		public void OOQCCDCDCO(int el)
		{
			switch (el)
			{
			case 0:
				sidewalkControlStatus[1] = (sidewalkControlStatus[11] = sidewalkControlStatus[0]);
				prefabScript.crossingElements[0].includeRightSidewalk = sidewalkControlStatus[0];
				prefabScript.crossingElements[3].includeRightSidewalk = sidewalkControlStatus[0];
				break;
			case 1:
				if (sidewalkControlStatus[1])
				{
					sidewalkControlStatus[0] = true;
				}
				else if (!sidewalkControlStatus[1] && !sidewalkControlStatus[11])
				{
					sidewalkControlStatus[0] = false;
				}
				prefabScript.crossingElements[0].includeRightSidewalk = sidewalkControlStatus[1];
				break;
			case 2:
				if (sidewalkControlStatus[2])
				{
					sidewalkControlStatus[3] = true;
				}
				else if (!sidewalkControlStatus[2] && !sidewalkControlStatus[4])
				{
					sidewalkControlStatus[3] = false;
				}
				prefabScript.crossingElements[0].includeLeftSidewalk = sidewalkControlStatus[2];
				break;
			case 3:
				sidewalkControlStatus[2] = (sidewalkControlStatus[4] = sidewalkControlStatus[3]);
				prefabScript.crossingElements[0].includeLeftSidewalk = sidewalkControlStatus[3];
				prefabScript.crossingElements[2].includeRightSidewalk = sidewalkControlStatus[3];
				break;
			case 4:
				if (sidewalkControlStatus[4])
				{
					sidewalkControlStatus[3] = true;
				}
				else if (!sidewalkControlStatus[4] && !sidewalkControlStatus[2])
				{
					sidewalkControlStatus[3] = false;
				}
				prefabScript.crossingElements[2].includeRightSidewalk = sidewalkControlStatus[4];
				break;
			case 5:
				if (sidewalkControlStatus[5])
				{
					sidewalkControlStatus[6] = true;
				}
				else if (!sidewalkControlStatus[5] && !sidewalkControlStatus[7])
				{
					sidewalkControlStatus[6] = false;
				}
				prefabScript.crossingElements[2].includeLeftSidewalk = sidewalkControlStatus[5];
				break;
			case 6:
				sidewalkControlStatus[5] = (sidewalkControlStatus[7] = sidewalkControlStatus[6]);
				prefabScript.crossingElements[1].includeLeftSidewalk = sidewalkControlStatus[6];
				prefabScript.crossingElements[2].includeLeftSidewalk = sidewalkControlStatus[6];
				break;
			case 7:
				if (sidewalkControlStatus[7])
				{
					sidewalkControlStatus[6] = true;
				}
				else if (!sidewalkControlStatus[7] && !sidewalkControlStatus[5])
				{
					sidewalkControlStatus[6] = false;
				}
				prefabScript.crossingElements[1].includeLeftSidewalk = sidewalkControlStatus[7];
				break;
			case 8:
				if (sidewalkControlStatus[8])
				{
					sidewalkControlStatus[9] = true;
				}
				else if (!sidewalkControlStatus[8] && !sidewalkControlStatus[10])
				{
					sidewalkControlStatus[9] = false;
				}
				prefabScript.crossingElements[1].includeRightSidewalk = sidewalkControlStatus[8];
				break;
			case 9:
				sidewalkControlStatus[8] = (sidewalkControlStatus[10] = sidewalkControlStatus[9]);
				prefabScript.crossingElements[1].includeRightSidewalk = sidewalkControlStatus[9];
				prefabScript.crossingElements[3].includeLeftSidewalk = sidewalkControlStatus[9];
				break;
			case 10:
				if (sidewalkControlStatus[10])
				{
					sidewalkControlStatus[9] = true;
				}
				else if (!sidewalkControlStatus[10] && !sidewalkControlStatus[8])
				{
					sidewalkControlStatus[9] = false;
				}
				prefabScript.crossingElements[3].includeLeftSidewalk = sidewalkControlStatus[10];
				break;
			case 11:
				if (sidewalkControlStatus[11])
				{
					sidewalkControlStatus[0] = true;
				}
				else if (!sidewalkControlStatus[11] && !sidewalkControlStatus[1])
				{
					sidewalkControlStatus[0] = false;
				}
				prefabScript.crossingElements[3].includeRightSidewalk = sidewalkControlStatus[11];
				break;
			}
		}

		public void ODCOCDDOCC()
		{
			if (prefabScript.sidewalkControlElements.Count != 4)
			{
				prefabScript.sidewalkControlElements.Clear();
				for (int i = 0; i < prefabScript.crossingElements.Count; i++)
				{
					prefabScript.sidewalkControlElements.Add(new QDOQDSQOOQDDD(UnityEngine.Object.FindObjectOfType(typeof(ERModularBase)) as ERModularBase));
				}
			}
			prefabScript.sidewalkControlElements[0].crossingElementLeftIndex = 3;
			prefabScript.sidewalkControlElements[0].crossingElementRightIndex = 0;
			prefabScript.sidewalkControlElements[1].crossingElementLeftIndex = 0;
			prefabScript.sidewalkControlElements[1].crossingElementRightIndex = 2;
			prefabScript.sidewalkControlElements[2].crossingElementLeftIndex = 2;
			prefabScript.sidewalkControlElements[2].crossingElementRightIndex = 1;
			prefabScript.sidewalkControlElements[3].crossingElementLeftIndex = 1;
			prefabScript.sidewalkControlElements[3].crossingElementRightIndex = 3;
			if (tCrossing && tCrossingLeftRight == 1)
			{
				prefabScript.sidewalkControlElements[1].crossingElementRightIndex = 1;
			}
			else if (tCrossing && tCrossingLeftRight == 0)
			{
				prefabScript.sidewalkControlElements[0].crossingElementLeftIndex = 1;
			}
		}

		public void ODDQDQDQQC()
		{
			float num = 0f;
			QDOQDSQOOQDDD qDOQDSQOOQDDD = prefabScript.sidewalkControlElements[0];
			prefabScript.bottomLeftSidewalkWidth = qDOQDSQOOQDDD.sidewalkWidth1;
			prefabScript.bottomLeftSidewalkOuterOffset = qDOQDSQOOQDDD.sidewalkWidth1 - qDOQDSQOOQDDD.curbDepth;
			prefabScript.bottomLeftSidewalkCurbDepth = qDOQDSQOOQDDD.curbDepth;
			qDOQDSQOOQDDD = prefabScript.sidewalkControlElements[1];
			prefabScript.bottomRightSidewalkWidth = qDOQDSQOOQDDD.sidewalkWidth1;
			prefabScript.bottomRightSidewalkOuterOffset = qDOQDSQOOQDDD.sidewalkWidth1 - qDOQDSQOOQDDD.curbDepth;
			prefabScript.bottomRightSidewalkCurbDepth = qDOQDSQOOQDDD.curbDepth;
			qDOQDSQOOQDDD = prefabScript.sidewalkControlElements[2];
			prefabScript.topLeftSidewalkWidth = qDOQDSQOOQDDD.sidewalkWidth1;
			prefabScript.topLeftSidewalkOuterOffset = qDOQDSQOOQDDD.sidewalkWidth1 - qDOQDSQOOQDDD.curbDepth;
			prefabScript.topLeftSidewalkCurbDepth = qDOQDSQOOQDDD.curbDepth;
			qDOQDSQOOQDDD = prefabScript.sidewalkControlElements[3];
			prefabScript.topRightSidewalkWidth = qDOQDSQOOQDDD.sidewalkWidth1;
			prefabScript.topRightSidewalkOuterOffset = qDOQDSQOOQDDD.sidewalkWidth1 - qDOQDSQOOQDDD.curbDepth;
			prefabScript.topRightSidewalkCurbDepth = qDOQDSQOOQDDD.curbDepth;
		}
	}
}
