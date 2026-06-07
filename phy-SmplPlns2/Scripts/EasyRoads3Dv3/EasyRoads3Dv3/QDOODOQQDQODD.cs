using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[Serializable]
	public class QDOODOQQDQODD
	{
		[HideInInspector]
		public GameObject connectionHandleObject;

		public bool isHandleActive = true;

		[HideInInspector]
		public ERPosition connectionPosition;

		public Vector3 centerPoint = Vector3.zero;

		[HideInInspector]
		public Vector3 tmpCenterPoint = Vector3.zero;

		[HideInInspector]
		public Vector3 stageCenterPoint = Vector3.zero;

		[HideInInspector]
		public Vector3 tmpStageCenterPoint = Vector3.zero;

		[HideInInspector]
		public List<ERBlendVecs> blendData = new List<ERBlendVecs>();

		[HideInInspector]
		public Vector3 controlPointV3 = Vector3.zero;

		[HideInInspector]
		public Vector2 controlPoint = Vector2.zero;

		[HideInInspector]
		public Vector3 endSplinePoint = Vector3.zero;

		[HideInInspector]
		public Vector3 endControlPoint = Vector3.zero;

		[HideInInspector]
		public float blendDistance = 0f;

		[HideInInspector]
		public float extendBounds = 0f;

		[HideInInspector]
		public List<Vector3> blendCornerPoints = new List<Vector3>();

		[HideInInspector]
		public List<int> blendCornerPointInts = new List<int>();

		[HideInInspector]
		public List<float> blendCornerPointWeights = new List<float>();

		[HideInInspector]
		public List<Vector3> blendCornerPointsTransformed = new List<Vector3>();

		[HideInInspector]
		public float blendRatio = 1f;

		public float curveStrength = 0f;

		public List<Vector2> roadShapeVecs = new List<Vector2>();

		[HideInInspector]
		public string roadShapeVecsString = "";

		public int roadShapeMatchCount = 0;

		public List<float> roadShapeUVY = new List<float>();

		public List<float> roadShapeUVY2 = new List<float>();

		public List<bool> hardEdge = new List<bool>();

		public List<int> roadShapeMaterialInts = new List<int>();

		public List<Vector2> sidewalkLeftVecs = new List<Vector2>();

		public List<float> sidewalkLeftUVY = new List<float>();

		public List<int> sidewalkLeftMaterialInts = new List<int>();

		public List<Vector2> sidewalkRightVecs = new List<Vector2>();

		public List<float> sidewalkRightUVY = new List<float>();

		public List<int> sidewalkRightMaterialInts = new List<int>();

		[HideInInspector]
		public List<ERConnectionVecs> connectionVecs = new List<ERConnectionVecs>();

		[HideInInspector]
		public List<int> connectionVecInts = new List<int>();

		[HideInInspector]
		public List<int> fullConnectionVecInts = new List<int>();

		[HideInInspector]
		public List<int> sidewalkLeftConnectionVecInts = new List<int>();

		[HideInInspector]
		public List<int> sidewalkRightConnectionVecInts = new List<int>();

		public List<bool> doConnectionTri = new List<bool>();

		[HideInInspector]
		public List<int> outerVecInts = new List<int>();

		[HideInInspector]
		public List<Vector3> outerVecs = new List<Vector3>();

		[HideInInspector]
		public bool rotationPriority = false;

		[HideInInspector]
		public float centerPointAngle = 1000f;

		public ERModularRoad connectedRoad = null;

		public int connectedMarker = -1;

		[HideInInspector]
		public GameObject connectedRoadGO = null;

		[HideInInspector]
		public int connectedRoadID = 0;

		[HideInInspector]
		public Vector3 connectedRoadControlPoint = Vector3.zero;

		public bool includeLeftSidewalk = true;

		public bool includeRightSidewalk = true;

		public Material roadMaterial;

		public Material[] roadMaterials;

		[HideInInspector]
		public float centerPointPercentage = 0.5f;

		[HideInInspector]
		private float vssss = 0f;

		[HideInInspector]
		public int leftIndent = -1;

		[HideInInspector]
		public int rightIndent = -1;

		[HideInInspector]
		public int leftSurrounding = -1;

		[HideInInspector]
		public int rightSurrounding = -1;

		[HideInInspector]
		public float leftRoadIndent = 0f;

		[HideInInspector]
		public float rightRoadIndent = 0f;

		[HideInInspector]
		public float leftRoadSurrounding = 0f;

		[HideInInspector]
		public float rightRoadSurrounding = 0f;

		[HideInInspector]
		public Vector3 leftIndentV3;

		[HideInInspector]
		public Vector3 leftSurroundingV3;

		[HideInInspector]
		public Vector3 rightIndentV3;

		[HideInInspector]
		public Vector3 rightSurroundingV3;

		[HideInInspector]
		public Vector3 leftRoadpoint;

		[HideInInspector]
		public Vector3 rightRoadpoint;

		[HideInInspector]
		public List<Vector3> leftRoundingPoints = new List<Vector3>();

		[HideInInspector]
		public List<Vector3> rightRoundingPoints = new List<Vector3>();

		[HideInInspector]
		public List<Vector3> leftRoundingPointsGlobal = new List<Vector3>();

		[HideInInspector]
		public List<Vector3> rightRoundingPointsGlobal = new List<Vector3>();

		[HideInInspector]
		public List<Vector3> leftInnerIndentPoints = new List<Vector3>();

		[HideInInspector]
		public List<Vector3> rightInnerIndentPoints = new List<Vector3>();

		[HideInInspector]
		public int leftCornerInt = -1;

		[HideInInspector]
		public int rightCornerInt = -1;

		[HideInInspector]
		public int leftIndentInt = 0;

		[HideInInspector]
		public int rightIndentInt = 0;

		[HideInInspector]
		public int leftInt = 0;

		[HideInInspector]
		public int rightInt = 0;

		[HideInInspector]
		public int leftIntFull = 0;

		[HideInInspector]
		public int rightIntFull = 0;

		[HideInInspector]
		public Vector3 alignmentHandleVec;

		public float additionalIndentDistance = 0f;

		[HideInInspector]
		public float connectionAngle = 0f;

		[HideInInspector]
		public Vector3 alignmentHandleVecRotationGizmo = Vector3.zero;

		[HideInInspector]
		public bool inwards = false;

		public double roadType = 0.0;

		public QDQDOOQQDQODD rt = null;

		[HideInInspector]
		public double roadTypeTimestamp = 0.0;

		[HideInInspector]
		public Vector3 leftCorner;

		[HideInInspector]
		public Vector3 rightCorner;

		[HideInInspector]
		public Vector3 direction;

		[HideInInspector]
		public Vector3 centerCornerDirectionLeft;

		[HideInInspector]
		public Vector3 centerCornerDirectionRight;

		[HideInInspector]
		public float leftAngle;

		[HideInInspector]
		public float rightAngle;

		[HideInInspector]
		public bool triangulateLeft = true;

		[HideInInspector]
		public bool triangulateRight = true;

		[HideInInspector]
		public ERLaneData laneData;

		public static void SetGlobalLeftOCCDOCDDCQ(int el, ERCrossingPrefabs prefabScript)
		{
			if (el >= prefabScript.crossingElements.Count)
			{
				return;
			}
			prefabScript.crossingElements[el].leftRoundingPointsGlobal.Clear();
			int num = prefabScript.crossingElements[el].leftRoundingPoints.Count - 1;
			if (num > 0 && (bool)prefabScript.roundaboutScript)
			{
				if (Vector3.Distance(prefabScript.crossingElements[el].leftRoundingPoints[0], prefabScript.crossingElements[el].leftRoundingPoints[1]) < 0.1f)
				{
					prefabScript.crossingElements[el].leftRoundingPoints.RemoveAt(1);
					num--;
				}
				if (Vector3.Distance(prefabScript.crossingElements[el].leftRoundingPoints[num], prefabScript.crossingElements[el].leftRoundingPoints[num - 1]) < 0.1f)
				{
					prefabScript.crossingElements[el].leftRoundingPoints.RemoveAt(num - 1);
					num--;
				}
			}
			for (int i = 0; i < prefabScript.crossingElements[el].leftRoundingPoints.Count; i++)
			{
				prefabScript.crossingElements[el].leftRoundingPointsGlobal.Add(prefabScript.transform.TransformPoint(prefabScript.crossingElements[el].leftRoundingPoints[i]));
			}
		}

		public static void SetGlobalRightOCCDOCDDCQ(int el, ERCrossingPrefabs prefabScript)
		{
			if (el >= prefabScript.crossingElements.Count)
			{
				return;
			}
			prefabScript.crossingElements[el].rightRoundingPointsGlobal.Clear();
			int num = prefabScript.crossingElements[el].rightRoundingPoints.Count - 1;
			if (num > 0 && (bool)prefabScript.roundaboutScript)
			{
				if (Vector3.Distance(prefabScript.crossingElements[el].rightRoundingPoints[0], prefabScript.crossingElements[el].rightRoundingPoints[1]) < 0.1f)
				{
					prefabScript.crossingElements[el].rightRoundingPoints.RemoveAt(1);
					num--;
				}
				if (Vector3.Distance(prefabScript.crossingElements[el].rightRoundingPoints[num], prefabScript.crossingElements[el].rightRoundingPoints[num - 1]) < 0.1f)
				{
					prefabScript.crossingElements[el].rightRoundingPoints.RemoveAt(num - 1);
					num--;
				}
			}
			for (int i = 0; i <= num; i++)
			{
				prefabScript.crossingElements[el].rightRoundingPointsGlobal.Add(prefabScript.transform.TransformPoint(prefabScript.crossingElements[el].rightRoundingPoints[i]));
			}
		}

		public static void SetCornerDirectionLeft(int el, ERCrossingPrefabs prefabScript)
		{
			if (prefabScript.crossingElements[el].leftRoundingPoints.Count <= 0 || prefabScript.crossingElements[el].rightRoundingPoints.Count <= 0)
			{
				return;
			}
			int num = ussst(prefabScript, el, 0);
			SetGlobalRightOCCDOCDDCQ(num, prefabScript);
			SetGlobalLeftOCCDOCDDCQ(num, prefabScript);
			if (prefabScript.crossingElements[num].rightRoundingPoints.Count > 1)
			{
				int num2 = prefabScript.crossingElements[el].leftRoundingPointsGlobal.Count - 1;
				if (num2 == -1)
				{
					SetGlobalLeftOCCDOCDDCQ(el, prefabScript);
					num2 = prefabScript.crossingElements[el].leftRoundingPointsGlobal.Count - 1;
				}
				Vector3 normalized = (prefabScript.crossingElements[el].leftRoundingPointsGlobal[num2 - 1] - prefabScript.crossingElements[el].leftRoundingPointsGlobal[num2]).normalized;
				int num3 = prefabScript.crossingElements[num].rightRoundingPointsGlobal.Count - 1;
				if (num3 == -1)
				{
					SetGlobalRightOCCDOCDDCQ(num, prefabScript);
					num3 = prefabScript.crossingElements[num].rightRoundingPointsGlobal.Count - 1;
				}
				Vector3 normalized2 = (prefabScript.crossingElements[num].rightRoundingPointsGlobal[num3 - 1] - prefabScript.crossingElements[num].rightRoundingPointsGlobal[num3]).normalized;
				prefabScript.crossingElements[el].centerCornerDirectionLeft = Vector3.Lerp(normalized, normalized2, 0.5f).normalized;
				if (prefabScript.crossingElements[el].centerCornerDirectionLeft == Vector3.zero)
				{
					Vector3 vector = prefabScript.crossingElements[num].rightRoundingPointsGlobal[num3 - 1] - prefabScript.crossingElements[el].leftRoundingPointsGlobal[num2 - 1];
					prefabScript.crossingElements[el].centerCornerDirectionLeft = new Vector3(vector.z, 0f, 0f - vector.x).normalized;
				}
				Vector3 pCheck = prefabScript.crossingElements[el].leftRoundingPointsGlobal[num2] + prefabScript.crossingElements[el].centerCornerDirectionLeft;
				if (OQQOCDQCQD.OOCQODQDQD(prefabScript.crossingElements[el].leftRoundingPointsGlobal[num2], prefabScript.crossingElements[el].leftRoundingPointsGlobal[num2 - 1], pCheck))
				{
					prefabScript.crossingElements[el].centerCornerDirectionLeft *= -1f;
				}
				prefabScript.crossingElements[el].leftAngle = Vector3.Angle(normalized, normalized2);
			}
		}

		public static void SetCornerDirectionRight(int el, ERCrossingPrefabs prefabScript)
		{
			if (prefabScript.crossingElements[el].rightRoundingPoints.Count <= 0 || prefabScript.crossingElements[el].leftRoundingPoints.Count <= 0)
			{
				return;
			}
			int num = ussst(prefabScript, el, 1);
			if (prefabScript.crossingElements[num].leftRoundingPoints.Count > 1)
			{
				int num2 = prefabScript.crossingElements[el].rightRoundingPointsGlobal.Count - 1;
				if (num2 == -1)
				{
					SetGlobalRightOCCDOCDDCQ(el, prefabScript);
					num2 = prefabScript.crossingElements[el].rightRoundingPointsGlobal.Count - 1;
				}
				Vector3 normalized = (prefabScript.crossingElements[el].rightRoundingPointsGlobal[num2 - 1] - prefabScript.crossingElements[el].rightRoundingPointsGlobal[num2]).normalized;
				int num3 = prefabScript.crossingElements[num].leftRoundingPointsGlobal.Count - 1;
				if (num3 == -1)
				{
					SetGlobalLeftOCCDOCDDCQ(num, prefabScript);
					num3 = prefabScript.crossingElements[num].leftRoundingPointsGlobal.Count - 1;
				}
				Vector3 normalized2 = (prefabScript.crossingElements[num].leftRoundingPointsGlobal[num3 - 1] - prefabScript.crossingElements[num].leftRoundingPointsGlobal[num3]).normalized;
				prefabScript.crossingElements[el].centerCornerDirectionRight = Vector3.Lerp(normalized, normalized2, 0.5f).normalized;
				if (prefabScript.crossingElements[el].centerCornerDirectionRight == Vector3.zero)
				{
					Vector3 vector = prefabScript.crossingElements[num].leftRoundingPointsGlobal[num3 - 1] - prefabScript.crossingElements[el].rightRoundingPointsGlobal[num2 - 1];
					prefabScript.crossingElements[el].centerCornerDirectionRight = new Vector3(vector.z, 0f, 0f - vector.x).normalized;
				}
				Vector3 pCheck = prefabScript.crossingElements[el].rightRoundingPointsGlobal[num2] + prefabScript.crossingElements[el].centerCornerDirectionRight;
				if (!OQQOCDQCQD.OOCQODQDQD(prefabScript.crossingElements[el].rightRoundingPointsGlobal[num2], prefabScript.crossingElements[el].rightRoundingPointsGlobal[num2 - 1], pCheck))
				{
					prefabScript.crossingElements[el].centerCornerDirectionRight *= -1f;
				}
				prefabScript.crossingElements[el].rightAngle = Vector3.Angle(normalized, normalized2);
			}
		}

		public static void SetLeftInnerIndentPoints(int el, ERCrossingPrefabs prefabScript)
		{
			if (el >= prefabScript.crossingElements.Count)
			{
				return;
			}
			prefabScript.crossingElements[el].leftInnerIndentPoints.Clear();
			float num = prefabScript.crossingElements[el].leftRoadIndent;
			for (int i = 0; i < prefabScript.crossingElements[el].leftRoundingPoints.Count; i++)
			{
				Vector3 normalized;
				if (i == 0)
				{
					normalized = (prefabScript.crossingElements[el].rightRoundingPoints[0] - prefabScript.crossingElements[el].leftRoundingPoints[0]).normalized;
				}
				else
				{
					normalized = prefabScript.crossingElements[el].leftRoundingPoints[i] - prefabScript.crossingElements[el].leftRoundingPoints[i - 1];
					normalized = new Vector3(normalized.z, 0f, 0f - normalized.x).normalized;
				}
				prefabScript.crossingElements[el].leftInnerIndentPoints.Add(prefabScript.crossingElements[el].leftRoundingPoints[i] + normalized * num);
			}
		}

		public static void SetRightInnerIndentPoints(int el, ERCrossingPrefabs prefabScript)
		{
			if (el >= prefabScript.crossingElements.Count)
			{
				return;
			}
			List<Vector3> list = new List<Vector3>(prefabScript.crossingElements[el].rightRoundingPoints);
			int count = list.Count;
			prefabScript.crossingElements[el].rightInnerIndentPoints.Clear();
			float num = prefabScript.crossingElements[el].rightRoadIndent;
			for (int i = 0; i < count; i++)
			{
				Vector3 normalized;
				if (i == 0)
				{
					normalized = (prefabScript.crossingElements[el].leftRoundingPoints[0] - prefabScript.crossingElements[el].rightRoundingPoints[0]).normalized;
				}
				else
				{
					normalized = list[i] - list[i - 1];
					normalized = new Vector3(0f - normalized.z, 0f, normalized.x).normalized;
				}
				prefabScript.crossingElements[el].rightInnerIndentPoints.Add(list[i] + normalized * num);
			}
		}

		public static int GetConnectionIndex(ERCrossingPrefabs prefabScript, ERConnectionSibling sibling)
		{
			for (int i = 0; i < prefabScript.siblings.Count; i++)
			{
				if (prefabScript.siblings[i] == sibling)
				{
					return i;
				}
			}
			return 0;
		}

		public static int ODOODDDQOO(ERCrossingPrefabs prefabScript, int el)
		{
			for (int i = 0; i < prefabScript.siblings.Count; i++)
			{
				if (prefabScript.siblings[i].orderedIndex == el)
				{
					return i;
				}
			}
			return 0;
		}

		private static int ussst(ERCrossingPrefabs tssss, int ussss, int vssss)
		{
			int num = tssss.crossingElements.Count - 1;
			if (tssss.isFlexConnector)
			{
				if (vssss == 0)
				{
					if (tssss.siblings[ussss].orderedIndex < num)
					{
						return ODOODDDQOO(tssss, tssss.siblings[ussss].orderedIndex + 1);
					}
					return ODOODDDQOO(tssss, 0);
				}
				if (tssss.siblings[ussss].orderedIndex > 0)
				{
					return ODOODDDQOO(tssss, tssss.siblings[ussss].orderedIndex - 1);
				}
				return ODOODDDQOO(tssss, num);
			}
			if (tssss.isRoundabout || tssss.isCustomPrefab)
			{
				if (vssss == 0)
				{
					if (ussss < num)
					{
						return ussss + 1;
					}
					return 0;
				}
				if (ussss > 0)
				{
					return ussss - 1;
				}
				return num;
			}
			if (vssss == 0)
			{
				switch (ussss)
				{
				case 0:
					if (!tssss.tCrossing || tssss.tCrossingLeftRight == 0)
					{
						return 2;
					}
					return 1;
				case 1:
					if (!tssss.tCrossing || tssss.tCrossingLeftRight == 1)
					{
						return 3;
					}
					return 0;
				case 2:
					return 1;
				default:
					return 0;
				}
			}
			switch (ussss)
			{
			case 0:
				if (!tssss.tCrossing || tssss.tCrossingLeftRight == 1)
				{
					return 3;
				}
				return 1;
			case 1:
				if (!tssss.tCrossing || tssss.tCrossingLeftRight == 0)
				{
					return 2;
				}
				return 0;
			case 2:
				return 0;
			default:
				return 1;
			}
		}

		public void SynchRoadObject(ERModularRoad roadObject, ERCrossingPrefabs prefabScript)
		{
			if (!(roadObject == connectedRoad) && (connectedRoadID == 0 || connectedRoadID != roadObject.id))
			{
				return;
			}
			connectedRoad = roadObject;
			connectedRoadGO = roadObject.gameObject;
			if (connectedMarker == 0)
			{
				roadObject.startPrefabScript = prefabScript;
			}
			else
			{
				roadObject.endPrefabScript = prefabScript;
			}
			for (int i = 0; i < prefabScript.crossingElements.Count; i++)
			{
				if (prefabScript.crossingElements[i] == this)
				{
					if (connectedMarker == 0)
					{
						roadObject.startConnectionSegment = i;
					}
					else
					{
						roadObject.endConnectionSegment = i;
					}
					break;
				}
			}
		}
	}
}
