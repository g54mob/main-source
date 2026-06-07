using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[Serializable]
	public class ERConnectionSibling
	{
		private class ussst : IComparer
		{
			int IComparer.Compare(object tssss, object ussss)
			{
				ERConnectionSibling eRConnectionSibling = (ERConnectionSibling)tssss;
				ERConnectionSibling eRConnectionSibling2 = (ERConnectionSibling)ussss;
				if (eRConnectionSibling.roadType.type > eRConnectionSibling2.roadType.type)
				{
					return 1;
				}
				if (eRConnectionSibling.roadType.type < eRConnectionSibling2.roadType.type)
				{
					return -1;
				}
				if (eRConnectionSibling.angle < eRConnectionSibling2.angle)
				{
					return -1;
				}
				return 1;
			}
		}

		[Serializable]
		private sealed class vssss
		{
			public static readonly vssss _003C_003E9 = new vssss();

			public static Comparison<ERConnectionSibling> _003C_003E9__177_0;

			internal int _003CCreateInstance_003Eb__177_0(ERConnectionSibling x, ERConnectionSibling y)
			{
				return x.angle.CompareTo(y.angle);
			}
		}

		public string name = "";

		[HideInInspector]
		public ERModularRoad road;

		[HideInInspector]
		public Transform transform;

		[HideInInspector]
		public Vector3 angleControlPoint = Vector3.zero;

		public QDQDOOQQDQODD roadType;

		public double roadTypeID = 0.0;

		[HideInInspector]
		public QDQDOOQQDQODD roadTypeAI;

		[HideInInspector]
		public double roadTypeAIid = 0.0;

		[HideInInspector]
		public bool aIInit = false;

		[HideInInspector]
		public int roadTypeIndex = 0;

		[HideInInspector]
		public int rampRoadTypeIndex = 0;

		[HideInInspector]
		public QDQDOOQQDQODD rampRoadType;

		public int roadTypeInstances = 0;

		public int priorityLevel = 0;

		public bool priorityRoad = false;

		[HideInInspector]
		public int prioritySectionStart = -1;

		[HideInInspector]
		public int prioritySectionEnd = -1;

		public float angle;

		[HideInInspector]
		public float prevAngle;

		[HideInInspector]
		public float angleWithNextRoad = 0f;

		[HideInInspector]
		public float angleWithPreviousRoad = 0f;

		[HideInInspector]
		public float roadWidth;

		[HideInInspector]
		public Vector3 controlPoint;

		[HideInInspector]
		public List<Vector2> roadShape = new List<Vector2>();

		[HideInInspector]
		public List<bool> hardEdge = new List<bool>();

		[HideInInspector]
		public List<float> roadShapeUVs = new List<float>();

		[HideInInspector]
		public List<bool> originalShapeVecs = new List<bool>();

		[HideInInspector]
		public bool includeOuterLaneOffset = true;

		[HideInInspector]
		public float leftFixedDistance = 0f;

		[HideInInspector]
		public float rightFixedDistance = 0f;

		public int buildPriority = 0;

		[HideInInspector]
		public bool addedNodeAtStart = false;

		[HideInInspector]
		public bool highPriorityConnection = false;

		[HideInInspector]
		public int triangulationType = 0;

		[HideInInspector]
		public bool adjustRadius = false;

		[HideInInspector]
		public float resolution = 1f;

		[HideInInspector]
		public int defaultSegments = 6;

		[HideInInspector]
		public int segments = 6;

		[HideInInspector]
		public float radius = 3f;

		[HideInInspector]
		public float defaultRadius = 3f;

		[HideInInspector]
		public int cornerSegments = 6;

		[HideInInspector]
		public int defaultCornerSegments = 6;

		[HideInInspector]
		public float leftCornerAngle = 0.35f;

		[HideInInspector]
		public float rightCornerAngle = 0.35f;

		[HideInInspector]
		public float defaultLeftCornerAngle = 0.35f;

		[HideInInspector]
		public float defaultRightCornerAngle = 0.35f;

		[HideInInspector]
		public Vector3 leftCurvatureDir;

		[HideInInspector]
		public Vector3 leftCurvatureVec;

		[HideInInspector]
		public Vector3 rightCurvatureDir;

		[HideInInspector]
		public Vector3 rightCurvatureVec;

		[HideInInspector]
		public ERFlexConnectionType leftConnectionType;

		[HideInInspector]
		public ERFlexConnectionType rightConnectionType;

		[HideInInspector]
		public Vector3 cp;

		[HideInInspector]
		public Vector3 oldCP;

		[HideInInspector]
		public Vector3 cp1;

		[HideInInspector]
		public Vector3 lStart;

		[HideInInspector]
		public Vector3 lEnd;

		[HideInInspector]
		public Vector3 rStart;

		[HideInInspector]
		public Vector3 rEnd;

		[HideInInspector]
		public Vector3 ip;

		[HideInInspector]
		public Vector3 ipRight;

		[HideInInspector]
		public Vector3 dir;

		[HideInInspector]
		public Vector3 outerCorner;

		[HideInInspector]
		public float cornerHandleScale = 1f;

		[HideInInspector]
		public List<Vector3> splinePoints = new List<Vector3>();

		[HideInInspector]
		public float leftRoundingPointsDistance = 0f;

		[HideInInspector]
		public List<Vector3> leftRoundingPoints = new List<Vector3>();

		[HideInInspector]
		public int originalLeftRoundingPoints = 0;

		[HideInInspector]
		public int originalRightRoundingPoints = 0;

		[HideInInspector]
		public float rightRoundingPointsDistance = 0f;

		[HideInInspector]
		public List<Vector3> rightRoundingPoints = new List<Vector3>();

		[HideInInspector]
		public List<Vector3> innerRoundingPoints = new List<Vector3>();

		[HideInInspector]
		public List<Vector3> priorityLeftPoints = new List<Vector3>();

		[HideInInspector]
		public List<Vector3> priorityRightPoints = new List<Vector3>();

		[HideInInspector]
		public List<Vector3> priorityPointsMain = new List<Vector3>();

		[HideInInspector]
		public List<Vector2> priorityPointsMainUVs = new List<Vector2>();

		[HideInInspector]
		public List<Color> priorityPointsMainColors = new List<Color>();

		[HideInInspector]
		public List<List<Vector3>> roadVecs = new List<List<Vector3>>();

		[HideInInspector]
		public List<List<Vector3>> rampVecs = new List<List<Vector3>>();

		[HideInInspector]
		public int rampStartStartRoundingIndex = 0;

		[HideInInspector]
		public int rampStartEndRoundingIndex = 0;

		[HideInInspector]
		public int rampEndStartRoundingIndex = 0;

		[HideInInspector]
		public int rampEndEndRoundingIndex = 0;

		[HideInInspector]
		public List<List<Vector3>> roadVecsRight = new List<List<Vector3>>();

		[HideInInspector]
		public List<List<Vector3>> roadVecsLeft = new List<List<Vector3>>();

		[HideInInspector]
		public List<List<Vector2>> roadUVs = new List<List<Vector2>>();

		[HideInInspector]
		public List<List<Vector2>> roadUVsLeft = new List<List<Vector2>>();

		[HideInInspector]
		public List<List<Vector2>> roadUVsRight = new List<List<Vector2>>();

		[HideInInspector]
		public List<List<Color>> roadColors = new List<List<Color>>();

		[HideInInspector]
		public List<int> connectionVecInts = new List<int>();

		[HideInInspector]
		public List<float> roadVecPerc = new List<float>();

		[HideInInspector]
		public int leftFixedIndex = 0;

		[HideInInspector]
		public int rightFixedIndex = 0;

		[HideInInspector]
		public int middleIndex = 0;

		[HideInInspector]
		public int middleIndentIndexLeft = -1;

		[HideInInspector]
		public int middleIndentIndexRight = -1;

		[HideInInspector]
		public int priorityPointsMainLeftIndex = -1;

		[HideInInspector]
		public int priorityPointsMainRightIndex = -1;

		[HideInInspector]
		public ERSideWalk leftSidewalk = null;

		[HideInInspector]
		public ERSideWalk rightSidewalk = null;

		[HideInInspector]
		public bool leftSidewalkActive = false;

		[HideInInspector]
		public bool leftCrosswalkActive = false;

		[HideInInspector]
		public bool rightSidewalkActive = false;

		[HideInInspector]
		public bool rightCrosswalkActive = false;

		[HideInInspector]
		public float maxCrosswalkSize = 0f;

		[HideInInspector]
		public bool crosswalkRoundingVecLeftAdded = false;

		[HideInInspector]
		public bool crosswalkRoundingVecRightAdded = false;

		[HideInInspector]
		public bool crosswalkRoundingVecLeftEndAdded = false;

		[HideInInspector]
		public bool crosswalkRoundingVecRightEndAdded = false;

		public Vector3 firstLeftRoundingVec = Vector3.zero;

		[HideInInspector]
		public Vector3 firstRightRoundingVec = Vector3.zero;

		[HideInInspector]
		public float crosswalkAddedDistance = 0f;

		[HideInInspector]
		public GameObject crosswalkObject;

		[HideInInspector]
		public Vector3 crosswalkLeftPosition;

		[HideInInspector]
		public Vector3 crosswalkRightPosition;

		[HideInInspector]
		public double leftSidewalkid = 0.0;

		[HideInInspector]
		public double rightSidewalkid = 0.0;

		[HideInInspector]
		public int leftSidewalkIndex = 0;

		[HideInInspector]
		public int rightSidewalkIndex = 0;

		[HideInInspector]
		public GameObject leftSidewalkGO = null;

		[HideInInspector]
		public GameObject rightSidewalkGO = null;

		[HideInInspector]
		public List<List<Vector3>> leftSidewalkVecs = new List<List<Vector3>>();

		[HideInInspector]
		public List<List<Vector2>> leftSidewalkUVs = new List<List<Vector2>>();

		[HideInInspector]
		public List<List<Vector3>> rightSidewalkVecs = new List<List<Vector3>>();

		[HideInInspector]
		public List<List<Vector2>> rightSidewalkUVs = new List<List<Vector2>>();

		[HideInInspector]
		public List<int> leftSidewalkTris = new List<int>();

		[HideInInspector]
		public List<int> rightSidewalkTris = new List<int>();

		[HideInInspector]
		public List<Vector3> leftIndentvecs = new List<Vector3>();

		[HideInInspector]
		public List<Vector3> rightIndentvecs = new List<Vector3>();

		[HideInInspector]
		public List<Vector3> leftSurroundingvecs = new List<Vector3>();

		[HideInInspector]
		public List<Vector3> rightSurroundingvecs = new List<Vector3>();

		[HideInInspector]
		public int leftIndent = 0;

		[HideInInspector]
		public int rightIndent = 0;

		[HideInInspector]
		public Vector3 leftIndentV3;

		[HideInInspector]
		public Vector3 rightIndentV3;

		[HideInInspector]
		public int leftSurrounding = 0;

		[HideInInspector]
		public int rightSurrounding = 0;

		[HideInInspector]
		public float leftRoadIndent = 0f;

		[HideInInspector]
		public float rightRoadIndent = 0f;

		[HideInInspector]
		public float leftRoadSurrounding = 0f;

		[HideInInspector]
		public float rightRoadSurrounding = 0f;

		[HideInInspector]
		public Vector3 leftSurroundingV3;

		[HideInInspector]
		public Vector3 rightSurroundingV3;

		[HideInInspector]
		public float uvRatio = 0.2f;

		[HideInInspector]
		public float uvy = 0f;

		[HideInInspector]
		public int mainRoadConnectionEdgeDecal = 0;

		[HideInInspector]
		public bool mainRoadConnectionEdgeDecalEditor = false;

		[HideInInspector]
		public GameObject mainConnectionDecal;

		[HideInInspector]
		public List<Vector3> mainConnectionDecalVecs = new List<Vector3>();

		[HideInInspector]
		public Vector3 mainConnectionDecalEndDir;

		[HideInInspector]
		public int middleInt = 0;

		[HideInInspector]
		public bool primaryPriorityConnection = false;

		[HideInInspector]
		public bool secondaryPriorityConnection = false;

		[HideInInspector]
		public bool manuallyPrioritized = false;

		[HideInInspector]
		public float fadeIn = 1f;

		[HideInInspector]
		public float fadeInDistance = 0f;

		[HideInInspector]
		public bool shapeSubSegments = false;

		[HideInInspector]
		public List<int> normalIndexes = new List<int>();

		[HideInInspector]
		public bool primarySection = false;

		public ERLaneData laneData;

		[HideInInspector]
		public Vector3 forward = Vector3.zero;

		[HideInInspector]
		public Vector3 globalForward = Vector3.zero;

		[HideInInspector]
		public Vector3 sideways = Vector3.zero;

		public int orderedIndex = 0;

		[HideInInspector]
		public bool hasChanged = false;

		[HideInInspector]
		public bool isset = false;

		[HideInInspector]
		public bool retainingWallSection = false;

		[HideInInspector]
		public int updateQueue = 0;

		[HideInInspector]
		public List<ERTrafficPosts> trafficPosts = new List<ERTrafficPosts>();

		[HideInInspector]
		public List<GameObject> trafficPostInstances = new List<GameObject>();

		[HideInInspector]
		public bool trafficPostsInit = false;

		[HideInInspector]
		public bool showTrafficPosts = false;

		[HideInInspector]
		public int activeTrafficPostIndex = -1;

		[HideInInspector]
		public bool bridgeSection = false;

		public void Clear()
		{
			splinePoints.Clear();
			leftRoundingPoints.Clear();
			rightRoundingPoints.Clear();
			innerRoundingPoints.Clear();
			priorityLeftPoints.Clear();
			priorityRightPoints.Clear();
			priorityPointsMain = new List<Vector3>();
			priorityPointsMainUVs.Clear();
			priorityPointsMainColors.Clear();
			roadVecs.Clear();
			roadUVs.Clear();
			roadColors.Clear();
			hardEdge.Clear();
			roadVecsRight.Clear();
			roadVecsLeft.Clear();
			roadUVsLeft.Clear();
			roadUVsRight.Clear();
			originalShapeVecs.Clear();
			connectionVecInts.Clear();
			leftSidewalkVecs.Clear();
			leftSidewalkUVs.Clear();
			rightSidewalkVecs.Clear();
			rightSidewalkUVs.Clear();
			leftSidewalkTris.Clear();
			rightSidewalkTris.Clear();
			leftIndentvecs.Clear();
			rightIndentvecs.Clear();
			leftSurroundingvecs.Clear();
			rightSurroundingvecs.Clear();
			middleIndentIndexLeft = -1;
			middleIndentIndexRight = -1;
			prioritySectionStart = -1;
			prioritySectionEnd = -1;
			mainConnectionDecalVecs.Clear();
			normalIndexes.Clear();
			hasChanged = false;
			priorityPointsMainLeftIndex = -1;
			priorityPointsMainRightIndex = -1;
			addedNodeAtStart = false;
			crosswalkRoundingVecLeftAdded = false;
			crosswalkRoundingVecRightAdded = false;
			crosswalkRoundingVecLeftEndAdded = false;
			crosswalkRoundingVecRightEndAdded = false;
			originalRightRoundingPoints = 0;
			originalLeftRoundingPoints = 0;
			maxCrosswalkSize = 0f;
			firstRightRoundingVec = (firstLeftRoundingVec = (crosswalkLeftPosition = (crosswalkRightPosition = Vector3.zero)));
			ipRight = Vector3.zero;
			rampVecs.Clear();
			bridgeSection = false;
		}

		private void xssss(ERModularRoad tssss, float ussss, Vector3 vssss, Transform wssss)
		{
			road = tssss;
			angle = ussss;
			angleControlPoint = vssss;
			transform = wssss;
			if (tssss != null)
			{
				yssst(tssss.roadType, tssss.baseScript.roadTypes);
			}
		}

		public static ERConnectionSibling CreateInstance(ERModularRoad scr, float angle, Vector3 controlPoint, Transform transform, List<ERConnectionSibling> siblings)
		{
			ERConnectionSibling eRConnectionSibling = new ERConnectionSibling();
			if (siblings != null && angle == 0f)
			{
				angle = 0f;
				if (siblings.Count == 1)
				{
					angle = siblings[0].angle + 180f;
				}
				else if (siblings.Count > 1)
				{
					float num = 0f;
					List<ERConnectionSibling> list = new List<ERConnectionSibling>(siblings);
					list.Sort((ERConnectionSibling x, ERConnectionSibling y) => x.angle.CompareTo(y.angle));
					for (int num2 = 0; num2 < list.Count; num2++)
					{
						if (num2 < list.Count - 1)
						{
							if (list[num2 + 1].angle - list[num2].angle > num)
							{
								num = list[num2 + 1].angle - list[num2].angle;
								angle = list[num2].angle + num * 0.5f;
							}
						}
						else if (list[0].angle + 360f - list[num2].angle > num)
						{
							angle = list[num2].angle + num * 0.5f;
						}
					}
				}
				if (angle > 360f)
				{
					angle -= 360f;
				}
			}
			eRConnectionSibling.xssss(scr, angle, controlPoint, transform);
			return eRConnectionSibling;
		}

		private void yssst(double tssss, List<QDQDOOQQDQODD> ussss)
		{
			for (int i = 0; i < ussss.Count; i++)
			{
				if (tssss == ussss[i].id)
				{
					roadTypeIndex = i + 1;
					roadType = (roadTypeAI = new QDQDOOQQDQODD(ussss.Count - 1));
					roadType.OOODDCQQOQ(ussss[i], null, null, copyShapeData: true, fromLog: false);
					roadTypeAI = roadType;
					roadTypeID = (roadTypeAIid = roadTypeAI.id);
					break;
				}
			}
		}

		public void OODODCODOQ(int index, List<QDQDOOQQDQODD> types)
		{
			roadTypeIndex = index;
			roadType = types[index - 1];
			roadType = new QDQDOOQQDQODD(types.Count - 1);
			roadType.OOODDCQQOQ(types[index], null, null, copyShapeData: true, fromLog: false);
			roadTypeID = types[index - 1].id;
		}

		public bool OQQQQCOODQ(ERModularBase baseScript, List<QDQDOOQQDQODD> types)
		{
			if ((float)defaultSegments * 0.5f == Mathf.Round((float)defaultSegments * 0.5f))
			{
			}
			if (roadTypeIndex == 0)
			{
				return false;
			}
			if (types.Count >= roadTypeIndex)
			{
				int num = 0;
				if (types[roadTypeIndex - 1].id != roadType.id)
				{
					for (int i = 0; i < types.Count; i++)
					{
						if (types[i].id == roadType.id)
						{
							roadTypeIndex = i + 1;
							break;
						}
					}
					if (types[roadTypeIndex - 1].id != roadType.id)
					{
						roadType = new QDQDOOQQDQODD(types.Count - 1);
						roadType.OOODDCQQOQ(types[roadTypeIndex - 1], null, null, copyShapeData: true, fromLog: false);
					}
				}
				if (roadType != null)
				{
					roadTypeID = roadType.id;
				}
				if (roadTypeID == 0.0 && road != null)
				{
					roadTypeID = road.roadType;
					roadType = QDQDOOQQDQODD.GetRoadTypeElByID(types, roadTypeID, clone: true);
				}
				else if (road == null)
				{
					return false;
				}
				roadWidth = roadType.roadWidth;
				if (roadType.uvTiling <= 0f)
				{
					roadType.uvTiling = 1f;
				}
				uvRatio = 5f * roadType.uvTiling;
				if (roadType.roadShape.Count == 0)
				{
					roadType.roadShape = new List<Vector2>();
					roadType.roadShape.Add(new Vector2((0f - roadWidth) * 0.5f, 0f));
					roadType.roadShape.Add(new Vector2(roadWidth * 0.5f, 0f));
					types[roadTypeIndex - 1].roadShape = new List<Vector2>();
					types[roadTypeIndex - 1].roadShape.Add(new Vector2((0f - roadWidth) * 0.5f, 0f));
					types[roadTypeIndex - 1].roadShape.Add(new Vector2(roadWidth * 0.5f, 0f));
					Debug.Log("EasyRoads3Dv3: The road shape for road type '" + roadType.roadTypeName + "' is not set correctly");
				}
				if (!roadType.roadShapeData.isset)
				{
					roadType.roadShapeData = new ERRoadShape(roadType.roadWidth);
					roadType.roadShapeData.OQDDCDOOOQ(roadType.roadShape);
					types[roadTypeIndex - 1].roadShapeData = new ERRoadShape(types[roadTypeIndex - 1].roadWidth);
					types[roadTypeIndex - 1].roadShapeData.OQDDCDOOOQ(types[roadTypeIndex - 1].roadShape);
					if (roadType.roadShape.Count == 0)
					{
						roadType.roadShape = new List<Vector2>(roadType.roadShapeData.nodes);
						types[roadTypeIndex - 1].roadShape = new List<Vector2>(types[roadTypeIndex - 1].roadShapeData.nodes);
					}
				}
				if (roadType.roadShapeData.isset)
				{
					roadShape = new List<Vector2>(roadType.roadShapeExt2);
					roadShapeUVs = new List<float>(roadType.roadShapeExtUVs2);
					hardEdge = new List<bool>(roadType.roadShapeData.hardEdge);
					if (roadShape.Count == 0)
					{
						if (roadType.roadShapeData.nodes.Count > 0)
						{
							roadType.roadShapeExt2 = new List<Vector2>(roadType.roadShapeData.nodes);
							roadType.roadShapeExtUVs2 = OQQOCDQCQD.OCDQQOCDCQ(roadType.roadShapeData.nodes);
							ODDOQDDQCQ.RebuildMainRoadShape(roadType);
							types[roadTypeIndex - 1].roadShapeExt2 = new List<Vector2>(types[roadTypeIndex - 1].roadShapeData.nodes);
							types[roadTypeIndex - 1].roadShapeExtUVs2 = OQQOCDQCQD.OCDQQOCDCQ(types[roadTypeIndex - 1].roadShapeData.nodes);
							ODDOQDDQCQ.RebuildMainRoadShape(types[roadTypeIndex - 1]);
						}
						else
						{
							roadType.roadShapeData = new ERRoadShape(roadType.roadWidth);
							roadType.roadShapeData.OQDDCDOOOQ(roadType.roadShape);
							types[roadTypeIndex - 1].roadShapeData = new ERRoadShape(types[roadTypeIndex - 1].roadWidth);
							types[roadTypeIndex - 1].roadShapeData.OQDDCDOOOQ(types[roadTypeIndex - 1].roadShape);
						}
						roadShape = new List<Vector2>(roadType.roadShapeExt2);
						roadShapeUVs = new List<float>(roadType.roadShapeExtUVs2);
						hardEdge = new List<bool>(roadType.roadShapeData.hardEdge);
					}
					if (roadType.roadShapeData.isSymmetrical == 0)
					{
						roadType.roadShapeData.IsSymmetrical();
						types[roadTypeIndex - 1].roadShapeData.IsSymmetrical();
					}
				}
				else
				{
					roadShape = new List<Vector2>(roadType.roadShape);
					roadShapeUVs = new List<float>(roadType.roadShapeUVs);
					hardEdge.Clear();
					hardEdge = new List<bool>(new bool[roadShape.Count]);
				}
				if (hardEdge.Count != roadShape.Count)
				{
					hardEdge = new List<bool>(new bool[roadShape.Count]);
				}
				Assss();
			}
			if (leftSidewalkid != 0.0)
			{
				leftSidewalk = ERSideWalk.GetSidewalk(baseScript.sidewalks, leftSidewalkid);
			}
			if (rightSidewalkid != 0.0)
			{
				rightSidewalk = ERSideWalk.GetSidewalk(baseScript.sidewalks, rightSidewalkid);
			}
			return true;
		}

		private void Assss()
		{
			foreach (Vector2 item2 in roadShape)
			{
				originalShapeVecs.Add(item: true);
			}
			leftFixedIndex = 0;
			rightFixedIndex = roadShape.Count - 1;
			if (roadType.roadShapeData.isset)
			{
				if (roadType.roadShapeData.outerLaneMarkingLeftIndex != -1 && roadType.roadShapeData.outerLaneMarkingRightIndex < roadShape.Count - 1)
				{
					includeOuterLaneOffset = true;
					leftFixedDistance = roadShape[0].x - roadShape[roadType.roadShapeData.outerLaneMarkingLeftIndex].x;
					leftFixedIndex = roadType.roadShapeData.outerLaneMarkingLeftIndex;
					if (!roadType.roadShapeData.includeOuterlaneLeftInShape)
					{
						originalShapeVecs[roadType.roadShapeData.outerLaneMarkingLeftIndex] = false;
					}
				}
				if (roadType.roadShapeData.outerLaneMarkingRightIndex != -1 && roadType.roadShapeData.outerLaneMarkingRightIndex < roadShape.Count - 1)
				{
					includeOuterLaneOffset = true;
					rightFixedDistance = roadShape[roadShape.Count - 1].x - roadShape[roadType.roadShapeData.outerLaneMarkingRightIndex].x;
					rightFixedIndex = roadType.roadShapeData.outerLaneMarkingRightIndex;
					if (!roadType.roadShapeData.includeOuterlaneRightInShape)
					{
						originalShapeVecs[roadType.roadShapeData.outerLaneMarkingRightIndex] = false;
					}
				}
			}
			if (includeOuterLaneOffset && !roadType.roadShapeData.isset)
			{
				leftFixedDistance = roadShape[0].x - 0.1f * roadShape[0].x;
				rightFixedDistance = roadShape[roadShape.Count - 1].x - 0.1f * roadShape[roadShape.Count - 1].x;
				bool flag = false;
				bool flag2 = false;
				for (int i = 0; i < roadShape.Count; i++)
				{
					if (roadShape[i].x > leftFixedDistance && !flag)
					{
						Vector2 vector = GetVector2(roadShape[i - 1], roadShape[i], new Vector2(leftFixedDistance, 0f));
						roadShape.Insert(i, vector);
						roadShapeUVs.Insert(i, 0.05f);
						hardEdge.Insert(i, item: false);
						originalShapeVecs.Insert(i, item: false);
						flag = true;
						leftFixedIndex = i;
						leftFixedDistance = Vector2.Distance(roadShape[0], roadShape[leftFixedIndex]);
						middleIndex++;
					}
					if (roadShape[i].x > rightFixedDistance && !flag2)
					{
						Vector2 vector2 = GetVector2(roadShape[i - 1], roadShape[i], new Vector2(rightFixedDistance, 0f));
						roadShape.Insert(i, vector2);
						roadShapeUVs.Insert(i, 0.95f);
						hardEdge.Insert(i, item: false);
						originalShapeVecs.Insert(i, item: false);
						flag2 = true;
						rightFixedIndex = i;
						rightFixedDistance = Vector2.Distance(roadShape[roadShape.Count - 1], roadShape[rightFixedIndex]);
					}
				}
				leftFixedIndex = 1;
				rightFixedIndex = 2;
			}
			float x = roadShape[0].x;
			float x2 = roadShape[0].x;
			int num = -1;
			for (int j = 0; j < roadShape.Count; j++)
			{
				if (roadShape[j].x <= 0.01f)
				{
					x = roadShape[j].x;
				}
				if (roadShape[j].x > 0f && x2 < 0f)
				{
					x2 = roadShape[j].x;
				}
				if (num == -1 && roadShape[j].x >= 0f)
				{
					num = (middleIndex = j);
				}
			}
			if (roadShape[0].x > roadShape[roadShape.Count - 1].x)
			{
				Debug.Log("EasyRoads3Dv3 Warning: incorrect shape data detected for road type: " + roadType.roadTypeName + ". The node order appears to be from right to left. The correct order is from left to right.");
			}
			else if (num == 0)
			{
				num = (middleIndex = 1);
				Debug.Log("EasyRoads3Dv3 Warning: incorrect shape data detected for road type: " + roadType.roadTypeName + ". Please visualize the road type in General Settings > Road Types, and set the left and right nodes at the correct positions.");
			}
			if (x < x * 0.1f && x2 > x2 * 0.1f)
			{
				Vector2 item = roadShape[num - 1];
				item.x = 0f;
				roadShape.Insert(num, item);
				roadShapeUVs.Insert(num, 0.5f);
				originalShapeVecs.Insert(num, item: false);
				hardEdge.Insert(num, item: false);
				if (rightFixedIndex >= 0)
				{
					rightFixedIndex++;
				}
			}
			else
			{
				for (int k = 0; k < roadShape.Count; k++)
				{
					if (roadShape[k].x >= 0f)
					{
						middleIndex = k;
						break;
					}
				}
			}
			float num2 = Mathf.Abs(roadShape[middleIndex - 1].x);
			float num3 = Mathf.Abs(roadShape[middleIndex - 1].x) / Mathf.Abs(roadShape[0].x);
			if ((double)num3 < 0.6)
			{
				shapeSubSegments = true;
			}
		}

		public static void SetPriorityConnection(List<ERConnectionSibling> siblings, int index)
		{
			for (int i = 0; i < siblings.Count; i++)
			{
				if (i == index)
				{
					siblings[i].priorityRoad = true;
				}
				else
				{
					siblings[i].priorityRoad = false;
				}
			}
		}

		public Vector2 GetVector2(Vector2 v1, Vector2 v2, Vector2 v3)
		{
			Vector2 vector = v1;
			vector.y = 0f;
			Vector2 vector2 = v2;
			vector2.y = 0f;
			Vector3 vector3 = v3;
			vector3.y = 0f;
			float num = Vector2.Distance(v1, v2);
			float num2 = Vector2.Distance(v1, v3);
			return Vector2.Lerp(v1, v2, num2 / num);
		}

		public void OCOQDOCCOO(double type, List<QDQDOOQQDQODD> roadTypes)
		{
			for (int i = 0; i < roadTypes.Count; i++)
			{
				if (roadTypes[i].id == type)
				{
					roadTypeIndex = i + 1;
					break;
				}
			}
		}

		public void SetDefaultVars(ERCrossingPrefabs prefabScript, QDQDOOQQDQODD newRoadType = null)
		{
			if (roadTypeID == 0.0 || roadType == null || road == null)
			{
				if (road == null)
				{
					for (int i = 0; i < prefabScript.siblings.Count; i++)
					{
						if (this == prefabScript.siblings[i])
						{
							road = prefabScript.crossingElements[i].connectedRoad;
							break;
						}
					}
				}
				if (newRoadType != null)
				{
					roadTypeID = newRoadType.id;
				}
				else if (roadTypeID == 0.0 && road != null)
				{
					roadTypeID = road.roadType;
					roadType = road.rt;
				}
				if (roadType == null)
				{
					roadType = QDQDOOQQDQODD.GetRoadTypeElByID(prefabScript.baseScript.roadTypes, roadTypeID, clone: true);
				}
				if (roadType == null)
				{
					Debug.Log("EasyRoads3Dv3 warning: The road type for this connection is NULL. The Flex Connector cannot be generated, Flex Connector: " + prefabScript.gameObject.name);
				}
			}
			if (buildPriority == 0)
			{
				if (roadType.cornerRadiusMainRoad > 0f)
				{
					radius = (defaultRadius = roadType.cornerRadiusMainRoad);
				}
				if (roadType.cornerSementsMainRoad > 0)
				{
					defaultSegments = (defaultCornerSegments = roadType.cornerSementsMainRoad);
				}
				if (roadType.cornerRadiusSecondaryCurvature > 0f)
				{
					leftCornerAngle = (rightCornerAngle = (defaultLeftCornerAngle = (defaultRightCornerAngle = roadType.cornerRadiusSecondaryCurvature)));
				}
			}
			else
			{
				if (roadType.cornerRadiusSecondaryRoad > 0f)
				{
					radius = (defaultRadius = roadType.cornerRadiusSecondaryRoad);
				}
				if (roadType.cornerSementsSecondaryRoad > 0)
				{
					defaultSegments = (defaultCornerSegments = roadType.cornerSementsSecondaryRoad);
				}
				if (roadType.cornerRadiusSecondaryCurvature > 0f)
				{
					leftCornerAngle = (rightCornerAngle = (defaultLeftCornerAngle = (defaultRightCornerAngle = roadType.cornerRadiusSecondaryCurvature)));
				}
			}
			isset = true;
		}

		public static Vector3 GetAngleControlPoint(Vector3 cp, Vector3 p0, Vector3 p1, Vector3 p2)
		{
			float num = Vector3.Distance(cp, p1);
			float num2 = Vector3.Distance(cp, p0);
			if (num2 == 0f)
			{
				num2 = 5f;
			}
			float num3 = num2 / num;
			num3 = 0.5f;
			float num4 = Vector3.Distance(p1, p2);
			Vector3 vector = cp + (cp - p1).normalized * Vector3.Distance(p1, p2);
			return ERModularRoad.OQQCQOQOOD(cp, cp, p1, p2, num3, 0.75f);
		}

		public void OQCQODQDQD()
		{
			trafficPosts.Clear();
			if (roadType == null)
			{
				return;
			}
			for (int i = 0; i < roadType.trafficPosts.Count; i++)
			{
				bool flag = false;
				for (int j = 0; j < trafficPosts.Count; j++)
				{
					if (roadType.trafficPosts[i].prefab == null && roadType.trafficPosts[i].prefab == trafficPosts[j].prefab)
					{
						flag = true;
					}
				}
				if (!flag)
				{
					ERTrafficPosts item = new ERTrafficPosts
					{
						prefab = roadType.trafficPosts[i].prefab
					};
					if (item.prefab != null)
					{
						item.active = roadType.trafficPosts[i].active;
					}
					item.scale = roadType.trafficPosts[i].scale;
					item.roadSide = roadType.trafficPosts[i].roadSide;
					item.includeSidewalks = roadType.trafficPosts[i].includeSidewalks;
					item.postType = roadType.trafficPosts[i].postType;
					item.sidewaysOffset = roadType.trafficPosts[i].sidewaysOffset;
					item.forwardOffset = roadType.trafficPosts[i].forwardOffset;
					item.isset = roadType.trafficPosts[i].isset;
					trafficPosts.Add(item);
				}
			}
			trafficPostsInit = true;
		}

		public void TrafficPostsHandler(int index, Transform parent, ERCrossingPrefabs prefabScript)
		{
			if (!trafficPostsInit)
			{
				OQCQODQDQD();
			}
			List<bool> list = new List<bool>();
			bool flag = false;
			for (int i = 0; i < trafficPosts.Count; i++)
			{
				flag = false;
				ERTrafficPosts post = trafficPosts[i];
				if (!trafficPosts[i].isset && trafficPosts[i].active)
				{
					TrafficPostsSettings(ref post);
					trafficPosts[i] = post;
				}
				if (trafficPosts[i].prefab != null && trafficPosts[i].active)
				{
					if (trafficPosts[i].postType == ERTrafficPostType.OneWay || trafficPosts[i].postType == ERTrafficPostType.OneWayNoEntry)
					{
						if ((road.oneWayDirection == ERLaneDirection.Right && road.startConnectionSegment == index) || (road.oneWayDirection == ERLaneDirection.Left && road.endConnectionSegment == index))
						{
							if (trafficPosts[i].postType == ERTrafficPostType.OneWayNoEntry)
							{
								flag = true;
								if (trafficPosts[i].instance != null)
								{
									for (int j = 0; j < trafficPostInstances.Count; j++)
									{
										if (trafficPostInstances[j] == trafficPosts[i].instance)
										{
											UnityEngine.Object.DestroyImmediate(trafficPosts[i].instance);
											trafficPostInstances.RemoveAt(j);
											break;
										}
									}
								}
							}
						}
						else if (trafficPosts[i].postType == ERTrafficPostType.OneWay)
						{
							flag = true;
							if (trafficPosts[i].instance != null)
							{
								for (int k = 0; k < trafficPostInstances.Count; k++)
								{
									if (trafficPostInstances[k] == trafficPosts[i].instance)
									{
										UnityEngine.Object.DestroyImmediate(trafficPosts[i].instance);
										trafficPostInstances.RemoveAt(k);
										break;
									}
								}
							}
						}
					}
					if (flag)
					{
						continue;
					}
					if (trafficPosts[i].instance == null)
					{
						post.instance = UnityEngine.Object.Instantiate(trafficPosts[i].prefab);
						post.instance.transform.parent = parent;
						post.instance.name = trafficPosts[i].prefab.name;
						if ((bool)post.instance.GetComponent<ERTrafficPost>())
						{
							UnityEngine.Object.DestroyImmediate(post.instance.GetComponent<ERTrafficPost>());
						}
						trafficPostInstances.Add(post.instance);
						trafficPosts[i] = post;
						if (updateQueue != prefabScript.baseScript.updateQueue)
						{
							prefabScript.baseScript.postInstances.Add(new ERPostInstances(post.instance, trafficPosts[i].prefab, trafficPosts[i], this));
							updateQueue = prefabScript.baseScript.updateQueue;
						}
					}
					Vector3 postPosition = GetPostPosition(post);
					postPosition = parent.TransformPoint(postPosition);
					post.instance.transform.position = postPosition;
					post.instance.transform.forward = globalForward;
					trafficPosts[i] = post;
				}
				else
				{
					RemovePostInstances();
				}
			}
		}

		public Vector3 GetPostPosition(ERTrafficPosts post)
		{
			Vector3 vector = rightRoundingPoints[0];
			float num = 0f;
			float num2 = 0f;
			if (post.roadSide == ERRoadSide.Right)
			{
				float num3 = 0f;
				if (post.includeSidewalks && rightSidewalkActive && rightSidewalk != null)
				{
					num3 = rightSidewalk.sidewalkWidth;
				}
				vector = rightRoundingPoints[0];
				if (post.forwardOffset > 0f)
				{
					for (int i = 1; i < rightRoundingPoints.Count - 1; i++)
					{
						num = Vector3.Distance(rightRoundingPoints[i - 1], rightRoundingPoints[i]);
						if (num + num2 > post.forwardOffset)
						{
							vector = Vector3.Lerp(rightRoundingPoints[i - 1], rightRoundingPoints[i], (post.forwardOffset - num2) / num);
							break;
						}
						vector = rightRoundingPoints[i];
						num2 += num;
					}
				}
				vector += -sideways * (post.sidewaysOffset + num3);
			}
			else if (post.roadSide == ERRoadSide.Left)
			{
				float num4 = 0f;
				if (post.includeSidewalks && leftSidewalkActive && leftSidewalk != null)
				{
					num4 = leftSidewalk.sidewalkWidth;
				}
				vector = leftRoundingPoints[0];
				if (post.forwardOffset > 0f)
				{
					for (int j = 1; j < leftRoundingPoints.Count - 1; j++)
					{
						num = Vector3.Distance(leftRoundingPoints[j - 1], leftRoundingPoints[j]);
						if (num + num2 > post.forwardOffset)
						{
							vector = Vector3.Lerp(vector, leftRoundingPoints[j], (post.forwardOffset - num2) / num);
							break;
						}
						vector = leftRoundingPoints[j];
						num2 += num;
					}
				}
				vector += sideways * (post.sidewaysOffset + num4);
			}
			if (post.roadSide == ERRoadSide.Center)
			{
				vector = Vector3.Lerp(leftRoundingPoints[0], rightRoundingPoints[0], 0.5f);
				if (post.forwardOffset > 0f)
				{
					vector += forward * post.forwardOffset;
				}
			}
			return vector;
		}

		public void TrafficPostsSettings(ref ERTrafficPosts post)
		{
			if (post.prefab != null && !post.isset)
			{
				ERTrafficPost component = post.prefab.GetComponent<ERTrafficPost>();
				if (component != null)
				{
					post.scale = component.scale;
					post.roadSide = component.roadSide;
					post.includeSidewalks = component.includeSidewalks;
					post.postType = component.postType;
					post.sidewaysOffset = component.sidewaysOffset;
					post.forwardOffset = component.forwardOffset;
					post.isset = true;
				}
			}
		}

		public void RemovePostInstances()
		{
			for (int i = 0; i < trafficPostInstances.Count; i++)
			{
				if (trafficPostInstances[i] == null)
				{
					trafficPostInstances.RemoveAt(i);
					i--;
					continue;
				}
				bool flag = false;
				for (int j = 0; j < trafficPosts.Count; j++)
				{
					if (trafficPostInstances[i] != null && trafficPosts[j].instance == trafficPostInstances[i] && trafficPosts[j].active)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					UnityEngine.Object.DestroyImmediate(trafficPostInstances[i]);
					trafficPostInstances.RemoveAt(i);
					i--;
				}
			}
		}
	}
}
