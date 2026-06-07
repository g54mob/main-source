using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace EasyRoads3Dv3
{
	[AddComponentMenu("")]
	public class QDDDQODDQDQDQDD : MonoBehaviour
	{
		[Serializable]
		private sealed class ussst
		{
			public static readonly ussst _003C_003E9 = new ussst();

			public static Comparison<ERConnectionSibling> _003C_003E9__22_0;

			internal int _003CODCDQQOOOD_003Eb__22_0(ERConnectionSibling x, ERConnectionSibling y)
			{
				return x.angle.CompareTo(y.angle);
			}
		}

		public static Vector3 testPoint;

		public static ERCrossings cScr;

		public static List<Vector3> ll1 = new List<Vector3>();

		public static List<Vector3> ll2 = new List<Vector3>();

		public static List<Vector3> ll3 = new List<Vector3>();

		public static List<Vector3> ll4 = new List<Vector3>();

		public static int crossingStructure = 0;

		public static List<QDQDOOQQDQODD> roadTypesDynamic = new List<QDQDOOQQDQODD>();

		public static ERModularBase baseScript;

		public static List<ERConnectionSibling> siblings = new List<ERConnectionSibling>();

		public static Vector3 crossPointCenter;

		public static ERCrossingPrefabs prefabScript;

		public static ERConnectionSibling primaryPriorityConnection;

		public static ERConnectionSibling secondPriorityConnection;

		private static float _3ssss = 0f;

		private static float _4ssst = 0f;

		public static List<Vector3> debugEdges = new List<Vector3>();

		public static List<Vector3> debugvecs = new List<Vector3>();

		public static float turnSWAroundCornerThreshold = 100f;

		public static List<QDQDOOQQDQODD> OOCQOQDDOQ(List<QDQDOOQQDQODD> roadTypes, bool all)
		{
			List<QDQDOOQQDQODD> list = new List<QDQDOOQQDQODD>();
			QDQDOOQQDQODD qDQDOOQQDQODD = null;
			int num = 0;
			int num2 = 1;
			foreach (QDQDOOQQDQODD roadType in roadTypes)
			{
				if (all)
				{
					list.Add(roadType);
				}
				else if (roadType.roadShape.Count == 2 && !roadType.isSideObject && !roadType.isCustomRoad)
				{
					list.Add(roadType);
				}
				if (roadType.type != ERRoadWayType.Primary || qDQDOOQQDQODD == null)
				{
				}
				if (qDQDOOQQDQODD == null)
				{
					qDQDOOQQDQODD = roadType;
					num = num2;
				}
				num2++;
			}
			return list;
		}

		public static int GetDynamicRoadTypeIndex(double id)
		{
			int num = 0;
			foreach (QDQDOOQQDQODD item in roadTypesDynamic)
			{
				if (item.id == id)
				{
					return num;
				}
				num++;
			}
			return 0;
		}

		public static void OOQOOODDOC(ERCrossings scr, QDQDOOQQDQODD sourceRoadType)
		{
			cScr = scr;
			if (scr == null)
			{
				return;
			}
			if (cScr.baseScript == null)
			{
				if (!(cScr.transform.parent != null))
				{
					return;
				}
				cScr.baseScript = cScr.transform.parent.GetComponent<ERModularBase>();
				if (cScr.baseScript == null)
				{
					if ((bool)cScr.transform.parent.parent)
					{
						cScr.baseScript = cScr.transform.parent.parent.GetComponent<ERModularBase>();
					}
					if (cScr.baseScript == null)
					{
						return;
					}
				}
			}
			if (scr.prefabScript.isFlexConnector)
			{
				cScr.roadTypesDynamic = (roadTypesDynamic = OOCQOQDDOQ(cScr.baseScript.roadTypes, all: true));
			}
			else
			{
				cScr.roadTypesDynamic = (roadTypesDynamic = OOCQOQDDOQ(cScr.baseScript.roadTypes, all: false));
			}
			crossingStructure = scr.crossingStructure;
			baseScript = scr.baseScript;
			siblings = scr.prefabScript.siblings;
			crossPointCenter = scr.crossPointCenter;
			prefabScript = scr.prefabScript;
			debugEdges = scr.edges;
			primaryPriorityConnection = scr.primaryPriorityConnection;
			secondPriorityConnection = scr.secondPriorityConnection;
			_3ssss = scr.leftIntOffset;
			_4ssst = scr.rightIntOffset;
			if (sourceRoadType == null)
			{
				return;
			}
			siblings = scr.prefabScript.siblings;
			for (int i = 0; i < siblings.Count; i++)
			{
				if (siblings[i].roadType.id == sourceRoadType.id)
				{
					if (siblings[i].buildPriority == 0)
					{
						siblings[i].defaultSegments = (siblings[i].cornerSegments = (siblings[i].defaultCornerSegments = sourceRoadType.cornerSementsMainRoad));
						siblings[i].radius = (siblings[i].defaultRadius = sourceRoadType.cornerRadiusMainRoad);
						siblings[i].leftCornerAngle = (siblings[i].rightCornerAngle = (siblings[i].defaultLeftCornerAngle = (siblings[i].defaultRightCornerAngle = sourceRoadType.cornerRadiusSecondaryCurvature)));
					}
					else
					{
						siblings[i].defaultSegments = (siblings[i].cornerSegments = (siblings[i].defaultCornerSegments = sourceRoadType.cornerSementsSecondaryRoad));
						siblings[i].radius = (siblings[i].defaultRadius = sourceRoadType.cornerRadiusSecondaryRoad);
						siblings[i].leftCornerAngle = (siblings[i].rightCornerAngle = (siblings[i].defaultLeftCornerAngle = (siblings[i].defaultRightCornerAngle = sourceRoadType.cornerRadiusSecondaryCurvature)));
					}
					siblings[i].leftSidewalkActive = (siblings[i].rightSidewalkActive = sourceRoadType.sidewalks);
					siblings[i].leftSidewalkid = (siblings[i].rightSidewalkid = sourceRoadType.defaultSidewalk);
					if (sourceRoadType.defaultSidewalk != 0.0)
					{
						siblings[i].leftSidewalk = (siblings[i].rightSidewalk = ERSideWalk.GetSidewalk(baseScript.sidewalks, sourceRoadType.defaultSidewalk));
						siblings[i].leftCrosswalkActive = (siblings[i].rightCrosswalkActive = sourceRoadType.crosswalksIntersections);
					}
				}
			}
		}

		public static void ODCDQQOOOD()
		{
			debugEdges.Clear();
			debugvecs.Clear();
			primaryPriorityConnection = null;
			secondPriorityConnection = null;
			if (cScr == null)
			{
				return;
			}
			if (prefabScript == null)
			{
				prefabScript = cScr.gameObject.GetComponent<ERCrossingPrefabs>();
				if (prefabScript == null)
				{
					cScr.gameObject.AddComponent<ERCrossingPrefabs>();
					prefabScript = cScr.gameObject.GetComponent<ERCrossingPrefabs>();
				}
			}
			int num = -1;
			int num2 = -1;
			for (int i = 0; i < siblings.Count; i++)
			{
				if (siblings[i].road == null && prefabScript.crossingElements.Count > i)
				{
					siblings[i].road = prefabScript.crossingElements[i].connectedRoad;
				}
				siblings[i].Clear();
				if (siblings[i].crosswalkObject != null)
				{
					UnityEngine.Object.DestroyImmediate(siblings[i].crosswalkObject);
				}
				if (siblings[i].primaryPriorityConnection)
				{
					num = i;
					primaryPriorityConnection = siblings[i];
				}
				else if (siblings[i].secondaryPriorityConnection)
				{
					num2 = i;
					secondPriorityConnection = siblings[i];
				}
				if (prefabScript.crossingElements.Count > i)
				{
					siblings[i].oldCP = prefabScript.crossingElements[i].centerPoint;
				}
			}
			if (num == -1 || num2 == -1)
			{
				if (num != -1 && num < siblings.Count)
				{
					siblings[num].primaryPriorityConnection = false;
				}
				if (num2 != -1 && num2 < siblings.Count)
				{
					siblings[num2].secondaryPriorityConnection = false;
				}
				primaryPriorityConnection = (secondPriorityConnection = null);
			}
			float num3 = 200f;
			Clear();
			double num4 = 0.0;
			for (int j = 0; j < siblings.Count; j++)
			{
				siblings[j].name = "Road " + (j + 1);
				if (siblings[j].roadTypeIndex == 0)
				{
					if (prefabScript != null && prefabScript.crossingElements.Count > j)
					{
						if (prefabScript.crossingElements[j].connectedRoad != null)
						{
							siblings[j].OCOQDOCCOO(prefabScript.crossingElements[j].connectedRoad.roadType, roadTypesDynamic);
						}
						else
						{
							siblings[j].OCOQDOCCOO(prefabScript.crossingElements[j].roadType, roadTypesDynamic);
						}
					}
					if (siblings[j].roadTypeIndex == 0)
					{
						return;
					}
				}
				if (!(siblings[j].angleControlPoint == Vector3.zero))
				{
					siblings[j].angle = 360f - OCCQDDQQCD(siblings[j].angleControlPoint, Vector3.forward, Vector3.up);
				}
				if (siblings[j].primarySection)
				{
					bool flag = false;
					for (int k = j + 1; k < siblings.Count; k++)
					{
						if (siblings[k].roadTypeID == siblings[j].roadTypeID && siblings[k].primarySection)
						{
							flag = true;
							num4 = siblings[j].roadType.id;
							break;
						}
					}
					if (!flag)
					{
						siblings[j].primarySection = false;
					}
				}
				if (siblings[j].cornerSegments < 3)
				{
					if (siblings[j].roadType != null)
					{
						if (siblings[j].buildPriority == 0)
						{
							siblings[j].cornerSegments = siblings[j].roadType.cornerSementsMainRoad;
						}
						else
						{
							siblings[j].cornerSegments = siblings[j].roadType.cornerSementsSecondaryRoad;
						}
						if (siblings[j].cornerSegments < 3)
						{
							siblings[j].cornerSegments = 5;
						}
					}
					else
					{
						siblings[j].cornerSegments = 5;
					}
				}
				if ((float)siblings[j].cornerSegments * 0.5f != Mathf.Round((float)siblings[j].cornerSegments * 0.5f))
				{
					ERConnectionSibling eRConnectionSibling = siblings[j];
					eRConnectionSibling.cornerSegments++;
				}
				if ((float)siblings[j].defaultSegments * 0.5f != Mathf.Round((float)siblings[j].defaultSegments * 0.5f))
				{
					ERConnectionSibling eRConnectionSibling = siblings[j];
					eRConnectionSibling.defaultSegments++;
				}
				if (!(siblings[j].radius < 1f))
				{
					continue;
				}
				if (siblings[j].roadType != null)
				{
					if (siblings[j].buildPriority == 0)
					{
						siblings[j].radius = siblings[j].roadType.cornerRadiusMainRoad;
					}
					else
					{
						siblings[j].radius = siblings[j].roadType.cornerRadiusSecondaryRoad;
					}
					if (siblings[j].radius < 1f)
					{
						siblings[j].radius = 1f;
					}
				}
				else
				{
					siblings[j].radius = 1f;
				}
			}
			List<ERConnectionSibling> list = new List<ERConnectionSibling>(siblings);
			list.Sort((ERConnectionSibling x, ERConnectionSibling y) => x.angle.CompareTo(y.angle));
			float num5 = 35f;
			for (int num6 = 0; num6 < list.Count; num6++)
			{
				float num7 = 0f;
				if (num6 == list.Count - 1)
				{
					num7 = list[0].angle + 360f - list[num6].angle;
					list[0].angleWithPreviousRoad = num7;
				}
				else
				{
					num7 = list[num6 + 1].angle - list[num6].angle;
					list[num6 + 1].angleWithPreviousRoad = num7;
				}
				list[num6].angleWithNextRoad = num7;
				if (num7 < num5)
				{
					return;
				}
				num7 = ((num6 != 0) ? (list[num6].angle - list[num6 - 1].angle) : (list[num6].angle + 360f - list[list.Count - 1].angle));
				if (num7 < num5)
				{
					return;
				}
			}
			bool flag2 = false;
			cScr.disableAdjustMainRadiusFlag = true;
			cScr.showScaleSliderAtPrimary = false;
			cScr.showScaleSliderAtSecondary = false;
			List<ERConnectionSibling> list2 = new List<ERConnectionSibling>();
			List<ERConnectionSibling> list3 = new List<ERConnectionSibling>();
			ERRoadWayType eRRoadWayType = ERRoadWayType.Dirt;
			for (int num8 = 0; num8 < list.Count; num8++)
			{
				list[num8].orderedIndex = num8;
				if (list[num8].roadType != null && list[num8].roadType.type < eRRoadWayType && OQCCCCCOQD(list[num8].roadType, out var _))
				{
					eRRoadWayType = list[num8].roadType.type;
				}
				if (num8 > 0)
				{
					if ((list[num8] == cScr.primaryPriorityConnection && list[num8 - 1] == cScr.secondPriorityConnection) || (list[num8] == cScr.secondPriorityConnection && list[num8 - 1] == cScr.primaryPriorityConnection))
					{
						cScr.disableAdjustMainRadiusFlag = false;
					}
					if (cScr.primaryPriorityConnection != null && cScr.secondPriorityConnection != null)
					{
						cScr.disableAdjustMainRadiusFlag = false;
					}
				}
				if (num8 < list.Count - 1 && list[num8] == primaryPriorityConnection && list[num8 + 1] == secondPriorityConnection)
				{
					cScr.showScaleSliderAtPrimary = true;
				}
			}
			if (list[0] == primaryPriorityConnection && list[list.Count - 1] == secondPriorityConnection)
			{
				cScr.showScaleSliderAtSecondary = true;
			}
			if ((list[0] == cScr.primaryPriorityConnection && list[list.Count - 1] == cScr.secondPriorityConnection) || (list[0] == cScr.secondPriorityConnection && list[list.Count - 1] == cScr.primaryPriorityConnection))
			{
				cScr.disableAdjustMainRadiusFlag = false;
			}
			float num9 = 0f;
			cScr.prioritySiblings.Clear();
			bool flag3 = false;
			bool flag4 = false;
			for (int num10 = 0; num10 < list.Count; num10++)
			{
				if (list[num10].roadType != null)
				{
					if (list[num10].primarySection && list[num10].roadType.type == eRRoadWayType && list[num10].roadType.id != num4)
					{
						for (int num11 = 0; num11 < list2.Count; num11++)
						{
							list3.Add(list2[num11]);
							list2[num11].buildPriority = 0;
							list[num10].primarySection = false;
							if (!list2[num11].isset)
							{
								list2[num11].SetDefaultVars(prefabScript);
							}
						}
						list2.Clear();
						num4 = list[num10].roadType.id;
					}
					if (list[num10].roadType.type == eRRoadWayType && (list[num10].roadType.id == num4 || num4 == 0.0))
					{
						num4 = list[num10].roadType.id;
						list[num10].buildPriority = 0;
						list[num10].primarySection = true;
						list[num10].highPriorityConnection = true;
						list2.Add(list[num10]);
						if (list[num10].priorityRoad)
						{
							flag2 = true;
						}
						if (primaryPriorityConnection != null && list[num10].angle == primaryPriorityConnection.angle)
						{
							flag3 = true;
							flag2 = true;
						}
						if (secondPriorityConnection != null && list[num10].angle == secondPriorityConnection.angle)
						{
							flag4 = true;
						}
						if (!list[num10].isset)
						{
							list[num10].SetDefaultVars(prefabScript);
						}
					}
					else
					{
						list[num10].buildPriority = 1;
						list[num10].primarySection = false;
						list[num10].highPriorityConnection = false;
						list3.Add(list[num10]);
						if (!list[num10].isset)
						{
							list[num10].SetDefaultVars(prefabScript, list[num10].roadType);
						}
					}
				}
				else
				{
					list3.Add(list[num10]);
					if (!list[num10].isset)
					{
						list[num10].SetDefaultVars(prefabScript);
					}
				}
				if (list[num10].radius > num9)
				{
					num9 = list[num10].radius;
				}
			}
			prefabScript.priorityRoadCount = list2.Count;
			if (list2.Count == 1 && list3.Count > 1)
			{
				List<ERConnectionSibling> collection = new List<ERConnectionSibling>(list2);
				list2 = new List<ERConnectionSibling>(list3);
				list3 = new List<ERConnectionSibling>(collection);
				for (int num12 = 0; num12 < list2.Count; num12++)
				{
					list2[num12].buildPriority = 0;
					list2[num12].isset = false;
					list2[num12].SetDefaultVars(prefabScript);
				}
				for (int num13 = 0; num13 < list3.Count; num13++)
				{
					list3[num13].buildPriority = 1;
					list3[num13].isset = false;
					list3[num13].SetDefaultVars(prefabScript);
				}
			}
			if (list2.Count == 1 && list3.Count <= 1)
			{
				Debug.LogError("EasyRoads3Dv3 Flex Connector Error: this connector has only two connections of different types or only one connection");
				return;
			}
			float num14 = 0f;
			bool flag5 = false;
			cScr.prioritySiblings = new List<ERConnectionSibling>(list2);
			if (list2.Count > 0)
			{
				prefabScript.snapRadius = list2[0].roadType.roadWidth * 0.33f;
			}
			if (flag3 && flag4)
			{
				for (int num15 = 0; num15 < list2.Count; num15++)
				{
					if (list2[num15] != primaryPriorityConnection && list2[num15] != secondPriorityConnection)
					{
						list3.Add(list2[num15]);
						list2[num15].buildPriority = 1;
						list2.RemoveAt(num15);
						num15--;
					}
					else if (list2[num15] == primaryPriorityConnection)
					{
						flag5 = cScr.adjustMainRadiusFlag;
					}
				}
			}
			else
			{
				primaryPriorityConnection = (cScr.primaryPriorityConnection = null);
				secondPriorityConnection = (cScr.secondPriorityConnection = null);
			}
			bool flag6 = false;
			for (int num16 = 0; num16 < list2.Count; num16++)
			{
				if (list2[num16].roadShape.Count == 0)
				{
				}
				if (!list2[num16].OQQQQCOODQ(baseScript, roadTypesDynamic))
				{
					Debug.Log("EasyRoads3Dv3 Warning: No road object is attached to connection: " + list2[num16].name + " of " + prefabScript.gameObject.name);
					return;
				}
				cScr.priorityWayType = list2[num16].roadType.type;
				list2[num16].cp = GetCenterPoint(8f * list2[num16].roadWidth, list2[num16].angle);
				OODCDQODQC(list2[num16].cp, list2[num16].roadWidth, ref list2[num16].lStart, ref list2[num16].lEnd, ref list2[num16].rStart, ref list2[num16].rEnd, num9);
				Vector3 normalized = (list2[num16].rEnd - list2[num16].rStart).normalized;
				list2[num16].cp1 = list2[num16].cp + normalized * num3;
				list2[num16].dir = (list2[num16].lEnd - list2[num16].lStart).normalized;
				list2[num16].leftCurvatureDir = (list2[num16].rightCurvatureDir = Vector3.zero);
			}
			float num17 = 180f;
			int count = list2.Count;
			if (count == 2)
			{
				num17 = Vector3.Angle(list2[0].dir, list2[1].dir);
			}
			for (int num18 = 0; num18 < count; num18++)
			{
				if (num18 < count - 1)
				{
					if (num17 != 180f || count != 2)
					{
						list2[num18].ip = (list2[num18 + 1].ipRight = OQQOCDQCQD.OCDCQCDDCC(list2[num18].lStart, list2[num18].lEnd, list2[num18 + 1].rStart, list2[num18 + 1].rEnd, flag: false));
					}
					else
					{
						list2[num18].ip = (list2[num18 + 1].ipRight = OQQOCDQCQD.OCOOQOQCDC(list2[num18].lStart, list2[num18 + 1].rStart, Vector3.zero));
					}
					if ((list2[num18].leftSidewalkActive && list2[num18].leftCrosswalkActive) || (list2[num18].rightSidewalkActive && list2[num18].rightCrosswalkActive))
					{
						num14 = list2[num18].radius;
					}
					else
					{
						num14 = ((flag5 && list3.Count != 0) ? ((list3[0].roadWidth + list3[0].radius * list3[0].leftCornerAngle + list3[0].radius * list3[0].rightCornerAngle) * 0.4f) : list2[num18].radius);
						if (list2[num18] == primaryPriorityConnection || list2[num18] == secondPriorityConnection)
						{
							if (OQQOCDQCQD.OOCQODQDQD(list2[1].cp, list2[0].cp, Vector3.zero))
							{
								if (num17 < 75f)
								{
									num17 = 75f;
								}
								float num19 = 3f + list2[num18].roadWidth * 1.25f * (75f / num17);
								if (num14 < num19)
								{
									num14 = num19;
								}
							}
						}
						else if (list2.Count == 2 && list3.Count > 0 && num14 < list3[0].roadWidth * 0.5f)
						{
							num14 = list3[0].roadWidth * 0.5f;
						}
					}
					GetOCCDOCDDCQ(num18, list2[num18].ip, num14, list2[num18].defaultSegments, list2[num18].lStart, list2[num18 + 1].rStart, ref list2[num18].leftRoundingPoints, ref list2[num18 + 1].rightRoundingPoints, flag: true, list2[num18]);
					if (list3.Count > 0)
					{
						list2[num18].leftRoundingPoints.Insert(0, list2[num18].lStart + -list2[num18].dir * 100f);
						list2[num18 + 1].rightRoundingPoints.Insert(0, list2[num18 + 1].rStart + -list2[num18 + 1].dir * 100f);
						list2[num18].addedNodeAtStart = true;
						list2[num18 + 1].addedNodeAtStart = true;
					}
					list2[num18].mainConnectionDecalEndDir = list2[num18 + 1].dir;
				}
				else
				{
					if (num17 != 180f || count != 2)
					{
						list2[num18].ip = (list2[0].ipRight = OQQOCDQCQD.OCDCQCDDCC(list2[num18].lStart, list2[num18].lEnd, list2[0].rStart, list2[0].rEnd, flag: false));
					}
					else
					{
						list2[num18].ip = (list2[0].ipRight = OQQOCDQCQD.OCOOQOQCDC(list2[num18].lStart, list2[0].rStart, Vector3.zero));
					}
					if ((list2[num18].leftSidewalkActive && list2[num18].leftCrosswalkActive) || (list2[num18].rightSidewalkActive && list2[num18].rightCrosswalkActive))
					{
						num14 = list2[num18].radius;
					}
					else
					{
						num14 = ((flag5 && list3.Count != 0) ? ((list3[0].roadWidth + list3[0].radius * list3[0].leftCornerAngle + list3[0].radius * list3[0].rightCornerAngle) * 0.4f) : list2[num18].radius);
						if (list2[num18] == primaryPriorityConnection || list2[num18] == secondPriorityConnection)
						{
							if (!OQQOCDQCQD.OOCQODQDQD(list2[0].cp, list2[1].cp, Vector3.zero))
							{
								if (num17 < 75f)
								{
									num17 = 75f;
								}
								float num20 = 3f + list2[num18].roadWidth * 1.25f * (75f / num17);
								if (num14 < num20)
								{
									num14 = num20;
								}
							}
						}
						else if (list2.Count == 2 && list3.Count > 0 && num14 < list3[0].roadWidth * 0.5f)
						{
							num14 = list3[0].roadWidth * 0.5f;
						}
					}
					GetOCCDOCDDCQ(num18, list2[num18].ip, num14, list2[num18].defaultSegments, list2[num18].lStart, list2[0].rStart, ref list2[num18].leftRoundingPoints, ref list2[0].rightRoundingPoints, flag: true, list2[num18]);
					if (list3.Count > 0)
					{
						list2[num18].leftRoundingPoints.Insert(0, list2[num18].lStart + -list2[num18].dir * 100f);
						list2[0].rightRoundingPoints.Insert(0, list2[0].rStart + -list2[0].dir * 100f);
						list2[num18].addedNodeAtStart = true;
						list2[0].addedNodeAtStart = true;
					}
					list2[num18].mainConnectionDecalEndDir = list2[0].dir;
				}
				list2[num18].outerCorner = list2[num18].leftRoundingPoints[list2[num18].leftRoundingPoints.Count - 1];
			}
			if (list2.Count > 1)
			{
				crossPointCenter = OQQOCDQCQD.OCDCQCDDCC(list2[0].cp, list2[0].cp1, list2[1].cp, list2[1].cp1, flag: false);
			}
			else
			{
				crossPointCenter = Vector3.zero;
			}
			if (list3.Count == 0)
			{
				for (int num21 = 0; num21 < list.Count; num21++)
				{
					list[num21].originalLeftRoundingPoints = list[num21].leftRoundingPoints.Count;
					list[num21].originalRightRoundingPoints = list[num21].rightRoundingPoints.Count;
					if (num21 < list.Count - 1)
					{
						_1ssss(list[num21], list[num21 + 1]);
					}
					else
					{
						_1ssss(list[num21], list[0]);
					}
				}
				for (int num22 = 0; num22 < list.Count; num22++)
				{
					if ((list[num22].leftSidewalkActive && list[num22].leftCrosswalkActive) || (list[num22].rightSidewalkActive && list[num22].rightCrosswalkActive))
					{
						float num23 = 0f;
						float num24 = 0f;
						float num25 = 0f;
						if (list[num22].leftCrosswalkActive && list[num22].leftSidewalk != null && list[num22].leftSidewalk.crosswalkPavement)
						{
							num24 = list[num22].leftSidewalk.crosswalkSize;
						}
						if (list[num22].rightCrosswalkActive && list[num22].rightSidewalk != null && list[num22].rightSidewalk.crosswalkPavement)
						{
							num25 = list[num22].rightSidewalk.crosswalkSize;
						}
						num23 = ((!(num24 > num25)) ? num25 : num24);
						list[num22].crosswalkAddedDistance = num23 + 1f;
						list[num22].firstLeftRoundingVec = list[num22].leftRoundingPoints[0];
						Vector3 item = list[num22].leftRoundingPoints[0] - list[num22].forward * (num23 + 1f);
						list[num22].leftRoundingPoints.Insert(0, item);
						list[num22].firstRightRoundingVec = list[num22].rightRoundingPoints[0];
						item = list[num22].rightRoundingPoints[0] - list[num22].forward * (num23 + 1f);
						list[num22].rightRoundingPoints.Insert(0, item);
					}
				}
			}
			for (int num26 = 0; num26 < list2.Count; num26++)
			{
				if (list2[num26] == primaryPriorityConnection)
				{
					int num27 = num26;
					num27 = ((num26 <= 0) ? (list2.Count - 1) : (num26 - 1));
					ODQOOQDOQQ(list2[num26].rightRoundingPoints, list2[num26].leftRoundingPoints, list2[num27].leftRoundingPoints, list2[num27].rightRoundingPoints, ref list2[num26].priorityLeftPoints, ref list2[num26].priorityRightPoints, list2[num26].roadWidth);
				}
				else
				{
					if (flag2 || list3.Count != 0)
					{
						continue;
					}
					MatchLeftRights(ref list2[num26].leftRoundingPoints, list2[num26].lStart, ref list2[num26].rightRoundingPoints, list2[num26].rStart, list2[num26]);
					if (list2[num26].leftRoundingPoints.Count <= 1 || list2[num26].rightRoundingPoints.Count <= 1)
					{
						continue;
					}
					float num28 = Vector3.Distance(list2[num26].leftRoundingPoints[0], list2[num26].leftRoundingPoints[1]);
					float num29 = Vector3.Distance(list2[num26].leftRoundingPoints[1], list2[num26].leftRoundingPoints[2]);
					if ((double)(num29 / num28) < 0.5 && list2[num26].angleWithNextRoad > 145f)
					{
						list2[num26].leftRoundingPoints[1] = Vector3.Lerp(list2[num26].leftRoundingPoints[0], list2[num26].leftRoundingPoints[2], 0.25f);
					}
					else if (list2[num26].angleWithPreviousRoad > 145f)
					{
						num28 = Vector3.Distance(list2[num26].rightRoundingPoints[0], list2[num26].rightRoundingPoints[1]);
						num29 = Vector3.Distance(list2[num26].rightRoundingPoints[1], list2[num26].rightRoundingPoints[2]);
						if ((double)(num29 / num28) < 0.5)
						{
							list2[num26].rightRoundingPoints[1] = Vector3.Lerp(list2[num26].rightRoundingPoints[0], list2[num26].rightRoundingPoints[2], 0.25f);
						}
					}
				}
			}
			if (list3.Count != 0)
			{
				for (int num30 = 0; num30 < list3.Count; num30++)
				{
					if (!list3[num30].OQQQQCOODQ(baseScript, roadTypesDynamic))
					{
						Debug.Log("EasyRoads3Dv3 Warning: No road object is attached to connection: " + list3[num30].name + " of " + prefabScript.gameObject.name);
						return;
					}
					list3[num30].cp = GetCenterPoint(8f * list3[num30].roadWidth, list3[num30].angle);
					OODCDQODQC(list3[num30].cp, list3[num30].roadWidth, ref list3[num30].lStart, ref list3[num30].lEnd, ref list3[num30].rStart, ref list3[num30].rEnd, num9);
					Vector3 normalized2 = (list3[num30].rEnd - list3[num30].rStart).normalized;
					list3[num30].cp1 = list3[num30].cp + normalized2 * 200f;
					list3[num30].dir = normalized2;
					ERConnectionSibling eRConnectionSibling2 = null;
					ERConnectionSibling eRConnectionSibling3 = null;
					bool flag7 = false;
					bool flag8 = false;
					for (int num31 = 0; num31 < list.Count; num31++)
					{
						if (list[num31] != list3[num30])
						{
							continue;
						}
						if (num31 > 0)
						{
							for (int num32 = num31 - 1; num32 >= 0; num32--)
							{
								if (list[num32].buildPriority == 0)
								{
									eRConnectionSibling2 = list[num32];
									if (eRConnectionSibling2 == secondPriorityConnection)
									{
										eRConnectionSibling2 = primaryPriorityConnection;
										flag7 = true;
									}
									list3[num30].rightConnectionType = ERFlexConnectionType.Priority;
									break;
								}
								if (list[num32].roadType == list3[num30].roadType)
								{
									eRConnectionSibling2 = list[num32];
									list3[num30].rightConnectionType = ERFlexConnectionType.SameType;
									break;
								}
								Debug.LogError("EasyRoads3Dv3: " + prefabScript.gameObject.name + " - two lower priority roads of different type next to each other. This is not yet supported. Connection: " + list3[num30].angle);
							}
						}
						if (eRConnectionSibling2 == null)
						{
							for (int num33 = list.Count - 1; num33 > 1; num33--)
							{
								if (list[num33].buildPriority == 0)
								{
									eRConnectionSibling2 = list[num33];
									if (eRConnectionSibling2 == secondPriorityConnection)
									{
										eRConnectionSibling2 = primaryPriorityConnection;
										flag7 = true;
									}
									list3[num30].rightConnectionType = ERFlexConnectionType.Priority;
									break;
								}
								if (list[num33].roadType == list3[num30].roadType)
								{
									eRConnectionSibling2 = list[num33];
									list3[num30].rightConnectionType = ERFlexConnectionType.SameType;
									break;
								}
								Debug.LogError("EasyRoads3Dv3 - Flex Connector Warning: " + prefabScript.gameObject.name + " -  two lower priority roads of different type next to each other. This is not yet supported. Connection: " + list3[num30].angle);
							}
						}
						if (eRConnectionSibling2 == null)
						{
							Debug.LogError("EasyRoads3Dv3 - Flex Connector Warning:" + prefabScript.gameObject.name + " -  No Connection Match found on the right side");
						}
						if (num31 < list.Count - 1)
						{
							for (int num34 = num31 + 1; num34 <= list.Count - 1; num34++)
							{
								if (list[num34].buildPriority == 0)
								{
									eRConnectionSibling3 = list[num34];
									if (eRConnectionSibling3 == secondPriorityConnection)
									{
										eRConnectionSibling3 = primaryPriorityConnection;
										flag8 = true;
									}
									list[num31].leftConnectionType = ERFlexConnectionType.Priority;
									break;
								}
								if (list[num34].roadType == list3[num30].roadType)
								{
									eRConnectionSibling3 = list[num34];
									list[num31].leftConnectionType = ERFlexConnectionType.SameType;
									break;
								}
								Debug.LogError("EasyRoads3Dv3 - Flex Connector Warning:" + prefabScript.gameObject.name + " -  two lower priority roads of different type next to each other. This is not yet supported");
							}
						}
						if (eRConnectionSibling3 == null)
						{
							for (int num35 = 0; num35 < num31; num35++)
							{
								if (list[num35].buildPriority == 0)
								{
									eRConnectionSibling3 = list[num35];
									if (eRConnectionSibling3 == secondPriorityConnection)
									{
										eRConnectionSibling3 = primaryPriorityConnection;
										flag8 = true;
									}
									list[num31].leftConnectionType = ERFlexConnectionType.Priority;
									break;
								}
								if (list[num35].roadType == list3[num30].roadType)
								{
									eRConnectionSibling3 = list[num35];
									list[num31].leftConnectionType = ERFlexConnectionType.SameType;
									break;
								}
								Debug.LogError("EasyRoads3Dv3 - Flex Connector Warning: " + prefabScript.gameObject.name + " -  two lower priority roads of different type next to each other. This is not yet supported");
							}
						}
						if (eRConnectionSibling3 == null)
						{
							Debug.LogError("EasyRoads3Dv3 - Flex Connector Warning: " + prefabScript.gameObject.name + " - No Connection Match found on the left side");
						}
						if (eRConnectionSibling3 == null && eRConnectionSibling2 == null)
						{
							Debug.LogError("EasyRoads3Dv3 - Flex Connector Warning: " + prefabScript.gameObject.name + " - No Connection Match found on the right side");
							return;
						}
						break;
					}
					bool flag9 = false;
					Vector3 vector = Vector3.zero;
					if (secondPriorityConnection != null && primaryPriorityConnection != null)
					{
						flag9 = true;
						vector = secondPriorityConnection.dir;
					}
					float num36 = list3[num30].radius;
					float num37 = list3[num30].roadType.roadWidth * 0.2f;
					if (num37 > num36)
					{
						num36 = num37;
					}
					if (num36 < 3f)
					{
						num36 = 3f;
					}
					if (list3[num30].rightConnectionType != ERFlexConnectionType.SameType)
					{
						if (flag7)
						{
							int ttsss = -1;
							bool utsss = false;
							if (!wssst(list3[num30].radius, list3[num30].defaultSegments, list3[num30].rStart, list3[num30].rEnd, ref list3[num30].rightRoundingPoints, ref eRConnectionSibling2.priorityRightPoints, list3[num30].rightCornerAngle, flag7, flag9, vector, 1, _4ssss: false, ref ttsss, ref utsss))
							{
								return;
							}
							secondPriorityConnection.middleIndentIndexLeft = eRConnectionSibling2.priorityRightPoints.Count - 1 - ttsss;
							list3[num30].priorityPointsMain = eRConnectionSibling2.priorityRightPoints;
							list3[num30].rightCurvatureVec = list3[num30].rightRoundingPoints[list3[num30].rightRoundingPoints.Count - 1];
							list3[num30].rightCurvatureDir = -vector;
						}
						else
						{
							int ttsss2 = -1;
							bool utsss2 = false;
							if (flag9)
							{
								Vector3 vector2 = eRConnectionSibling2.priorityLeftPoints[1];
								Vector3 vector3 = eRConnectionSibling2.priorityLeftPoints[eRConnectionSibling2.priorityLeftPoints.Count - 2];
								Vector3 vector4 = eRConnectionSibling2.priorityLeftPoints[Mathf.RoundToInt(Mathf.Floor((float)eRConnectionSibling2.priorityLeftPoints.Count * 0.5f))];
								if (OQQOCDQCQD.OOCQODQDQD(vector2, vector3, vector4))
								{
									Vector3 a = OQQOCDQCQD.OCOOQOQCDC(vector2, vector3, vector4);
									float num38 = Vector3.Distance(a, vector4);
									if (num38 > num36 * 0.2f)
									{
										float adjacentMainRoadAngle = GetAdjacentMainRoadAngle(list3, list, num30);
										float a2 = num38 * 5.5f;
										float b = num38 * 2f;
										a2 = Mathf.Lerp(a2, b, (180f - adjacentMainRoadAngle) / 90f);
										if (num36 < a2)
										{
											num36 = a2;
										}
									}
								}
								if (!wssst(num36, list3[num30].defaultSegments, list3[num30].rStart, list3[num30].rEnd, ref list3[num30].rightRoundingPoints, ref eRConnectionSibling2.priorityLeftPoints, list3[num30].rightCornerAngle, flag7, flag9, eRConnectionSibling2.dir, 1, _4ssss: true, ref ttsss2, ref utsss2))
								{
									return;
								}
								eRConnectionSibling2.middleIndentIndexLeft = ttsss2;
								list3[num30].rightCurvatureVec = list3[num30].rightRoundingPoints[list3[num30].rightRoundingPoints.Count - 1];
								list3[num30].rightCurvatureDir = -eRConnectionSibling2.dir;
							}
							else
							{
								Vector3 vector5 = eRConnectionSibling2.leftRoundingPoints[eRConnectionSibling2.leftRoundingPoints.Count - 1];
								Vector3 vector6 = eRConnectionSibling2.leftRoundingPoints[1];
								Vector3 vector7 = eRConnectionSibling3.rightRoundingPoints[1];
								if (OQQOCDQCQD.OOCQODQDQD(vector6, vector7, vector5))
								{
									Vector3 a3 = OQQOCDQCQD.OCOOQOQCDC(vector6, vector7, vector5);
									float num39 = Vector3.Distance(a3, vector5);
									if (num39 > num36 * 0.25f)
									{
										float adjacentMainRoadAngle2 = GetAdjacentMainRoadAngle(list3, list, num30);
										float a4 = num39 * 5.5f;
										float b2 = num39 * 2f;
										a4 = Mathf.Lerp(a4, b2, (180f - adjacentMainRoadAngle2) / 90f);
										if (num36 < a4)
										{
											num36 = a4;
										}
									}
								}
								if (!wssst(num36, list3[num30].defaultSegments, list3[num30].rStart, list3[num30].rEnd, ref list3[num30].rightRoundingPoints, ref eRConnectionSibling2.leftRoundingPoints, list3[num30].rightCornerAngle, flag7, flag9, eRConnectionSibling2.dir, 1, _4ssss: true, ref ttsss2, ref utsss2))
								{
									return;
								}
								eRConnectionSibling2.middleIndentIndexLeft = ttsss2;
								list3[num30].rightCurvatureVec = list3[num30].rightRoundingPoints[list3[num30].rightRoundingPoints.Count - 1];
								list3[num30].rightCurvatureDir = -eRConnectionSibling2.dir;
							}
							if (flag9)
							{
								list3[num30].priorityPointsMain = eRConnectionSibling2.priorityLeftPoints;
							}
							else
							{
								list3[num30].priorityPointsMain = new List<Vector3>(eRConnectionSibling2.leftRoundingPoints);
							}
						}
					}
					if (list3[num30].rightConnectionType == ERFlexConnectionType.SameType)
					{
						list3[num30].ip = OQQOCDQCQD.OCDCQCDDCC(list3[num30].lStart, list3[num30].lEnd, eRConnectionSibling3.rStart, eRConnectionSibling3.rEnd, flag: false);
						GetOCCDOCDDCQ(num30, list3[num30].ip, list3[num30].radius, list3[num30].defaultSegments, list3[num30].lStart, list3[num30 + 1].rStart, ref list3[num30].leftRoundingPoints, ref eRConnectionSibling3.rightRoundingPoints, flag: true, list3[num30]);
						continue;
					}
					if (flag8)
					{
						int ttsss3 = -1;
						bool utsss3 = false;
						if (!wssst(num36, list3[num30].defaultSegments, list3[num30].lStart, list3[num30].lEnd, ref list3[num30].leftRoundingPoints, ref eRConnectionSibling3.priorityLeftPoints, list3[num30].leftCornerAngle, flag8, flag9, vector, 0, _4ssss: false, ref ttsss3, ref utsss3))
						{
							return;
						}
						secondPriorityConnection.middleIndentIndexRight = eRConnectionSibling3.priorityLeftPoints.Count - 1 - ttsss3;
						list3[num30].priorityPointsMain = eRConnectionSibling3.priorityLeftPoints;
						list3[num30].leftCurvatureVec = list3[num30].leftRoundingPoints[list3[num30].leftRoundingPoints.Count - 1];
						list3[num30].leftCurvatureDir = -vector;
						continue;
					}
					int ttsss4 = -1;
					bool utsss4 = false;
					if (flag9)
					{
						if (!wssst(num36, list3[num30].defaultSegments, list3[num30].lStart, list3[num30].lEnd, ref list3[num30].leftRoundingPoints, ref eRConnectionSibling3.priorityRightPoints, list3[num30].leftCornerAngle, flag8, flag9, eRConnectionSibling3.dir, 0, _4ssss: true, ref ttsss4, ref utsss4))
						{
							return;
						}
						eRConnectionSibling3.middleIndentIndexRight = ttsss4;
						list3[num30].leftCurvatureVec = list3[num30].leftRoundingPoints[list3[num30].leftRoundingPoints.Count - 1];
						list3[num30].leftCurvatureDir = -eRConnectionSibling3.dir;
					}
					else
					{
						if (!wssst(num36, list3[num30].defaultSegments, list3[num30].lStart, list3[num30].lEnd, ref list3[num30].leftRoundingPoints, ref eRConnectionSibling3.rightRoundingPoints, list3[num30].leftCornerAngle, flag8, flag9, eRConnectionSibling3.dir, 0, _4ssss: false, ref ttsss4, ref utsss4))
						{
							return;
						}
						eRConnectionSibling3.middleIndentIndexRight = ttsss4;
						list3[num30].leftCurvatureVec = list3[num30].leftRoundingPoints[list3[num30].leftRoundingPoints.Count - 1];
						list3[num30].leftCurvatureDir = -eRConnectionSibling3.dir;
					}
					if (flag9)
					{
						list3[num30].priorityPointsMain = eRConnectionSibling3.priorityRightPoints;
						continue;
					}
					List<Vector3> list4 = new List<Vector3>(eRConnectionSibling3.rightRoundingPoints);
					list4.Reverse();
					list3[num30].priorityPointsMain.AddRange(list4);
				}
				int num40 = list.Count - 1;
				float num41 = 0f;
				float num42 = 0f;
				float num43 = 0f;
				for (int num44 = 0; num44 <= num40; num44++)
				{
					bool flag10 = false;
					if (((list[num44].leftSidewalkActive && list[num44].leftCrosswalkActive) || (list[num44].rightSidewalkActive && list[num44].rightCrosswalkActive)) && list[num44].originalLeftRoundingPoints == 0 && list[num44].originalRightRoundingPoints == 0)
					{
						list[num44].originalLeftRoundingPoints = list[num44].leftRoundingPoints.Count;
						list[num44].originalRightRoundingPoints = list[num44].rightRoundingPoints.Count;
						if (list[num44].leftCrosswalkActive && list[num44].leftSidewalk != null && list[num44].leftSidewalk.crosswalkPavement)
						{
							num42 = list[num44].leftSidewalk.crosswalkSize;
						}
						if (list[num44].rightCrosswalkActive && list[num44].rightSidewalk != null && list[num44].rightSidewalk.crosswalkPavement)
						{
							num43 = list[num44].rightSidewalk.crosswalkSize;
						}
						num41 = ((!(num42 > num43)) ? num43 : num42);
						list[num44].crosswalkAddedDistance = num41 + 0.5f;
						int num45 = 0;
						if (list[num44].addedNodeAtStart)
						{
							num45 = 1;
						}
						int ussss = 0;
						Vector3 zero = Vector3.zero;
						int wssss = 0;
						Vector3 zero2 = Vector3.zero;
						if (!list3.Contains(list[num44]))
						{
							Vector3 vector8 = Vector3.zero;
							Vector3 vector9 = Vector3.zero;
							if (list[num44].rightSidewalkActive && list[num44].rightCrosswalkActive)
							{
								int num46 = -1;
								int num47 = 0;
								if (list[num44].secondaryPriorityConnection)
								{
									num46 = _2ssst();
									num47 = 1;
								}
								zero = Vector3.zero;
								if (num47 == 0)
								{
									if (num44 > 0)
									{
										_0ssst(list[num44 - 1], ref ussss, ref zero, ref wssss, list[num44].rightRoundingPoints, list[num44].priorityRightPoints, list[num44].primaryPriorityConnection, 0, num47);
									}
									else
									{
										_0ssst(list[num40], ref ussss, ref zero, ref wssss, list[num44].rightRoundingPoints, list[num44].priorityRightPoints, list[num44].primaryPriorityConnection, 0, num47);
									}
								}
								else if (num44 > 0)
								{
									_0ssst(list[num44 - 1], ref ussss, ref zero, ref wssss, list[num44].rightRoundingPoints, siblings[num46].priorityLeftPoints, list[num44].primaryPriorityConnection, 0, num47);
								}
								else
								{
									_0ssst(list[num40], ref ussss, ref zero, ref wssss, list[num44].rightRoundingPoints, siblings[num46].priorityLeftPoints, list[num44].primaryPriorityConnection, 0, num47);
								}
								if (!list[num44].leftSidewalkActive || !list[num44].leftCrosswalkActive)
								{
									Vector3 zero3 = Vector3.zero;
									Vector3 zero4 = Vector3.zero;
									if (num44 == num40)
									{
										if (num47 == 0)
										{
											_0ssst(list[0], ref ussss, ref zero3, ref wssss, list[num44].leftRoundingPoints, list[num44].priorityLeftPoints, list[num44].primaryPriorityConnection, 1, num47);
										}
										else
										{
											_0ssst(list[0], ref ussss, ref zero3, ref wssss, list[num44].leftRoundingPoints, siblings[num46].priorityRightPoints, list[num44].primaryPriorityConnection, 1, num47);
										}
									}
									else if (num47 == 0)
									{
										_0ssst(list[num44 + 1], ref ussss, ref zero3, ref wssss, list[num44].leftRoundingPoints, list[num44].priorityLeftPoints, list[num44].primaryPriorityConnection, 1, num47);
									}
									else
									{
										_0ssst(list[num44 + 1], ref ussss, ref zero3, ref wssss, list[num44].leftRoundingPoints, siblings[num46].priorityRightPoints, list[num44].primaryPriorityConnection, 1, num47);
									}
									zero4 = ((num44 != 0) ? list[num44 - 1].ip : list[num40].ip);
									vector9 = zero3;
									zero3 = OQQOCDQCQD.OCOOQOQCDC(list[num44].rightRoundingPoints[0], zero4, zero3);
									float num48 = Vector3.Distance(zero3, list[num44].rightRoundingPoints[0]);
									float num49 = Vector3.Distance(zero, list[num44].rightRoundingPoints[0]);
									if (num48 < num49)
									{
										zero = zero3;
										list[num44].rightRoundingPoints.Insert(1, zero);
										if (list[num44].priorityRightPoints.Count > 0)
										{
											list[num44].priorityRightPoints.Insert(1, zero);
										}
										if (!list[num44].secondaryPriorityConnection)
										{
										}
									}
								}
								if (zero != Vector3.zero)
								{
									vector8 = zero;
									float num50 = 0f;
									if (list[num44].angleWithPreviousRoad < 90f)
									{
										ERConnectionSibling eRConnectionSibling4 = null;
										eRConnectionSibling4 = ((num44 <= 0) ? list[list.Count - 1] : list[num44 - 1]);
										num50 = Assss(list[num44].angleWithPreviousRoad, zero, list[num44].forward, -list[num44].sideways, list[num44].rightSidewalk.sidewalkWidth, -eRConnectionSibling4.forward, eRConnectionSibling4.leftRoundingPoints[0], 0.5f);
									}
									if (Vector3.Distance(zero, list[num44].rightRoundingPoints[1]) < num41 + 1f + num50)
									{
										zero2 = zero - list[num44].forward * (num41 + 1f + num50);
										list[num44].rightRoundingPoints.Insert(1, zero2);
										if (list[num44].priorityRightPoints.Count > 0)
										{
											list[num44].priorityRightPoints.Insert(1, zero2);
										}
										list[num44].crosswalkRoundingVecRightAdded = true;
										list[num44].firstRightRoundingVec = zero;
										if (num46 != -1)
										{
											siblings[num46].priorityLeftPoints.Insert(siblings[num46].priorityLeftPoints.Count - 1, zero2);
											siblings[num46].crosswalkRoundingVecLeftEndAdded = true;
										}
									}
								}
							}
							if (list[num44].leftSidewalkActive && list[num44].leftCrosswalkActive)
							{
								int num51 = -1;
								int num52 = 0;
								if (list[num44].secondaryPriorityConnection)
								{
									num51 = _2ssst();
									num52 = 1;
								}
								zero = Vector3.zero;
								if (num52 == 0)
								{
									if (vector9 != Vector3.zero)
									{
										zero = vector9;
									}
									else if (num44 == num40)
									{
										_0ssst(list[0], ref ussss, ref zero, ref wssss, list[num44].leftRoundingPoints, list[num44].priorityLeftPoints, list[num44].primaryPriorityConnection, 1, num52);
									}
									else
									{
										_0ssst(list[num44 + 1], ref ussss, ref zero, ref wssss, list[num44].leftRoundingPoints, list[num44].priorityLeftPoints, list[num44].primaryPriorityConnection, 1, num52);
									}
								}
								else if (num44 == num40)
								{
									_0ssst(list[0], ref ussss, ref zero, ref wssss, list[num44].leftRoundingPoints, siblings[num51].priorityRightPoints, list[num44].primaryPriorityConnection, 1, num52);
								}
								else
								{
									_0ssst(list[num44 + 1], ref ussss, ref zero, ref wssss, list[num44].leftRoundingPoints, siblings[num51].priorityRightPoints, list[num44].primaryPriorityConnection, 1, num52);
								}
								if (!list[num44].rightSidewalkActive || !list[num44].rightCrosswalkActive)
								{
									Vector3 vPoint = Vector3.zero;
									if (vector8 != Vector3.zero)
									{
										vPoint = vector8;
									}
									else if (num52 == 0)
									{
										if (num44 > 0)
										{
											_0ssst(list[num44 - 1], ref ussss, ref vPoint, ref wssss, list[num44].rightRoundingPoints, list[num44].priorityRightPoints, list[num44].primaryPriorityConnection, 0, num52);
										}
										else
										{
											_0ssst(list[num40], ref ussss, ref zero, ref wssss, list[num44].rightRoundingPoints, list[num44].priorityRightPoints, list[num44].primaryPriorityConnection, 0, num52);
										}
									}
									else if (num44 > 0)
									{
										_0ssst(list[num44 - 1], ref ussss, ref vPoint, ref wssss, list[num44].rightRoundingPoints, siblings[num51].priorityLeftPoints, list[num44].primaryPriorityConnection, 0, num52);
									}
									else
									{
										_0ssst(list[num40], ref ussss, ref zero, ref wssss, list[num44].rightRoundingPoints, siblings[num51].priorityLeftPoints, list[num44].primaryPriorityConnection, 0, num52);
									}
									vPoint = OQQOCDQCQD.OCOOQOQCDC(list[num44].leftRoundingPoints[0], list[num44].ip, vPoint);
									float num53 = Vector3.Distance(vPoint, list[num44].leftRoundingPoints[0]);
									float num54 = Vector3.Distance(zero, list[num44].leftRoundingPoints[0]);
									if (num53 < num54)
									{
										zero = vPoint;
										list[num44].leftRoundingPoints.Insert(1, zero);
										if (list[num44].priorityLeftPoints.Count > 0)
										{
											list[num44].priorityLeftPoints.Insert(1, zero);
										}
									}
								}
								if (zero != Vector3.zero)
								{
									float num55 = 0f;
									if (list[num44].angleWithNextRoad < 90f)
									{
										ERConnectionSibling eRConnectionSibling5 = null;
										eRConnectionSibling5 = ((num44 <= list.Count - 1) ? list[0] : list[num44 = 1]);
										num55 = Assss(list[num44].angleWithNextRoad, zero, list[num44].forward, list[num44].sideways, list[num44].rightSidewalk.sidewalkWidth, -eRConnectionSibling5.forward, eRConnectionSibling5.rightRoundingPoints[0], 0.5f);
									}
									if (Vector3.Distance(zero, list[num44].leftRoundingPoints[1]) < num41 + 1f + num55)
									{
										zero2 = zero - list[num44].forward * (num41 + 1f + num55);
										list[num44].leftRoundingPoints.Insert(1, zero2);
										if (list[num44].priorityLeftPoints.Count > 0)
										{
											list[num44].priorityLeftPoints.Insert(1, zero2);
										}
										list[num44].crosswalkRoundingVecLeftAdded = true;
										list[num44].firstLeftRoundingVec = zero;
										if (num51 != -1)
										{
											siblings[num51].priorityRightPoints.Insert(siblings[num51].priorityRightPoints.Count - 1, zero2);
											siblings[num51].crosswalkRoundingVecRightEndAdded = true;
										}
									}
								}
							}
							if (!list[num44].primaryPriorityConnection)
							{
							}
						}
						else
						{
							flag10 = true;
							list[num44].maxCrosswalkSize = num41;
						}
					}
					if (num44 < list.Count - 1)
					{
						_1ssss(list[num44], list[num44 + 1]);
					}
					else
					{
						_1ssss(list[num44], list[0]);
					}
				}
				if (list3.Count > 0)
				{
					for (int num56 = 0; num56 < list3.Count; num56++)
					{
						if (list3[num56].maxCrosswalkSize > 0f)
						{
							float angleWithPreviousRoad = list3[num56].angleWithPreviousRoad;
							float angleWithNextRoad = list3[num56].angleWithNextRoad;
							if (angleWithPreviousRoad < angleWithNextRoad || (list3[num56].rightSidewalkActive && list3[num56].rightCrosswalkActive))
							{
								list3[num56].firstRightRoundingVec = list3[num56].rightRoundingPoints[0];
								Vector3 item2 = list3[num56].rightRoundingPoints[0] - list3[num56].forward * (list3[num56].maxCrosswalkSize + 1f);
								list3[num56].rightRoundingPoints.Insert(0, item2);
							}
							if (angleWithPreviousRoad > angleWithNextRoad || (list3[num56].leftSidewalkActive && list3[num56].leftCrosswalkActive))
							{
								list3[num56].firstLeftRoundingVec = list3[num56].leftRoundingPoints[0];
								Vector3 item3 = list3[num56].leftRoundingPoints[0] - list3[num56].forward * (list3[num56].maxCrosswalkSize + 1f);
								list3[num56].leftRoundingPoints.Insert(0, item3);
							}
						}
					}
					num3 = 0.0625f * Vector3.Distance(list2[0].leftRoundingPoints[0], list2[0].rightRoundingPoints[0]);
					if (num3 < 1f)
					{
						num3 = 1f;
					}
					for (int num57 = 0; num57 < list2.Count; num57++)
					{
						if (list2[num57] == secondPriorityConnection)
						{
							continue;
						}
						List<Vector3> list5;
						List<Vector3> list6;
						if (secondPriorityConnection != null)
						{
							list5 = list2[num57].priorityLeftPoints;
							list6 = list2[num57].priorityRightPoints;
						}
						else
						{
							list5 = list2[num57].leftRoundingPoints;
							list6 = list2[num57].rightRoundingPoints;
						}
						float num58 = Vector3.Distance(list5[0], list5[1]);
						float num59 = Vector3.Distance(list6[0], list6[1]);
						Vector3 vector10 = OQQOCDQCQD.OCOOQOQCDC(list6[0], list2[num57].rEnd, list5[1]);
						if (num58 <= num59)
						{
							if (!list2[num57].crosswalkRoundingVecLeftAdded)
							{
								list5[0] = list5[1] + -list2[num57].dir * num3;
							}
							else
							{
								list5.RemoveAt(0);
							}
							if (list2[num57].crosswalkRoundingVecRightAdded)
							{
								list6.RemoveAt(1);
							}
							list6[0] = OQQOCDQCQD.OCOOQOQCDC(list6[0], list6[1], list5[0]);
						}
						else
						{
							if (!list2[num57].crosswalkRoundingVecRightAdded)
							{
								list6[0] = list6[1] + -list2[num57].dir * num3;
							}
							else
							{
								list6.RemoveAt(0);
							}
							if (list2[num57].crosswalkRoundingVecLeftAdded)
							{
								list5.RemoveAt(1);
							}
							list5[0] = OQQOCDQCQD.OCOOQOQCDC(list5[0], list5[1], list6[0]);
						}
						if (list2[num57] == primaryPriorityConnection)
						{
							num58 = Vector3.Distance(list5[list5.Count - 1], list5[list5.Count - 2]);
							num59 = Vector3.Distance(list6[list6.Count - 1], list6[list6.Count - 2]);
							vector10 = OQQOCDQCQD.OCOOQOQCDC(list6[list6.Count - 1], list6[list6.Count - 2], list5[list5.Count - 2]);
							if (num58 <= num59)
							{
								if (!list2[num57].crosswalkRoundingVecLeftAdded)
								{
									list5[list5.Count - 1] = list5[list5.Count - 2] + -secondPriorityConnection.dir * num3;
								}
								else
								{
									list5.RemoveAt(list5.Count - 1);
								}
								if (list2[num57].crosswalkRoundingVecRightEndAdded)
								{
									list6.RemoveAt(list6.Count - 2);
								}
								list6[list6.Count - 1] = OQQOCDQCQD.OCOOQOQCDC(list6[list6.Count - 1], list6[list6.Count - 2], list5[list5.Count - 1]);
							}
							else
							{
								if (!list2[num57].crosswalkRoundingVecRightEndAdded)
								{
									list6[list6.Count - 1] = list6[list6.Count - 2] + -secondPriorityConnection.dir * num3;
								}
								else
								{
									list6.RemoveAt(list6.Count - 1);
								}
								if (list2[num57].crosswalkRoundingVecLeftEndAdded)
								{
									list5.RemoveAt(list5.Count - 2);
								}
								list5[list5.Count - 1] = OQQOCDQCQD.OCOOQOQCDC(list5[list5.Count - 1], list5[list5.Count - 2], list6[list6.Count - 1]);
							}
						}
						if (secondPriorityConnection != null)
						{
							list2[num57].leftRoundingPoints = new List<Vector3>(list5);
							list2[num57].rightRoundingPoints = new List<Vector3>(list6);
						}
					}
					if (secondPriorityConnection != null)
					{
						secondPriorityConnection.leftRoundingPoints = new List<Vector3>(primaryPriorityConnection.priorityRightPoints);
						secondPriorityConnection.rightRoundingPoints = new List<Vector3>(primaryPriorityConnection.priorityLeftPoints);
						secondPriorityConnection.leftRoundingPoints.Reverse();
						secondPriorityConnection.rightRoundingPoints.Reverse();
					}
				}
			}
			for (int num60 = 0; num60 < list2.Count; num60++)
			{
				list2[num60].forward = (list2[num60].lEnd - list2[num60].lStart).normalized;
				list2[num60].sideways = (list2[num60].leftRoundingPoints[0] - list2[num60].rightRoundingPoints[0]).normalized;
				if (list2[num60] == primaryPriorityConnection)
				{
					ODCCQDOOQQ(list2[num60].priorityLeftPoints, list2[num60].priorityRightPoints, ref list2[num60].roadVecs, list2[num60].roadShape, list2[num60].leftFixedIndex, list2[num60].rightFixedIndex, list2[num60].middleIndex, list2[num60].cp, list2[num60].cp1);
					if (list2[num60].roadVecs[2].Count > 2)
					{
						list2[num60].roadVecs[2][1] = Vector3.Lerp(list2[num60].roadVecs[2][0], list2[num60].roadVecs[2][2], 0.25f);
					}
					EROQODDCCCCD(list2[num60].roadVecs, list2[num60].roadShapeUVs, ref list2[num60].roadUVs, ref list2[num60].roadColors, list2[num60].priorityPointsMain, ref list2[num60].priorityPointsMainUVs, ref list2[num60].priorityPointsMainColors, crossPointCenter, list2[num60].uvRatio, list2[num60], primarySection: true);
				}
				else
				{
					ODOQOCOOOO(list2[num60].leftRoundingPoints, list2[num60].rightRoundingPoints, ref list2[num60].roadVecs, list2[num60].roadShape, list2[num60].leftFixedIndex, list2[num60].rightFixedIndex, list2[num60].middleIndex, list2[num60].cp, list2[num60].cp1, ref list2[num60].priorityPointsMain, list2[num60], isSecondary: false);
					if (list2[num60].roadVecs[2].Count > 2)
					{
						list2[num60].roadVecs[2][1] = Vector3.Lerp(list2[num60].roadVecs[2][0], list2[num60].roadVecs[2][2], 0.25f);
					}
					EROQODDCCCCD(list2[num60].roadVecs, list2[num60].roadShapeUVs, ref list2[num60].roadUVs, ref list2[num60].roadColors, list2[num60].priorityPointsMain, ref list2[num60].priorityPointsMainUVs, ref list2[num60].priorityPointsMainColors, crossPointCenter, list2[num60].uvRatio, list2[num60], primarySection: false);
				}
			}
			for (int num61 = 0; num61 < list3.Count; num61++)
			{
				list3[num61].forward = (list3[num61].lEnd - list3[num61].lStart).normalized;
				list3[num61].sideways = (list3[num61].leftRoundingPoints[0] - list3[num61].rightRoundingPoints[0]).normalized;
				MatchLeftRights(ref list3[num61].leftRoundingPoints, list3[num61].lStart, ref list3[num61].rightRoundingPoints, list3[num61].rStart, list3[num61]);
				if (list3[num61].triangulationType != 0)
				{
					continue;
				}
				ODOQOCOOOO(list3[num61].leftRoundingPoints, list3[num61].rightRoundingPoints, ref list3[num61].roadVecs, list3[num61].roadShape, list3[num61].leftFixedIndex, list3[num61].rightFixedIndex, list3[num61].middleIndex, list3[num61].cp, list3[num61].cp1, ref list3[num61].priorityPointsMain, list3[num61], isSecondary: true);
				switch (list3[num61].roadVecs[list3[num61].middleIndex].Count)
				{
				case 1:
				{
					Vector3 item5 = list3[num61].roadVecs[list3[num61].middleIndex][0] + list3[num61].forward * 0.35f;
					list3[num61].roadVecs[list3[num61].middleIndex].Add(item5);
					item5 = list3[num61].roadVecs[list3[num61].middleIndex][0] + list3[num61].forward * 0.75f;
					list3[num61].roadVecs[list3[num61].middleIndex].Add(item5);
					break;
				}
				case 2:
				{
					Vector3 item4 = Vector3.Lerp(list3[num61].roadVecs[list3[num61].middleIndex][0], list3[num61].roadVecs[list3[num61].middleIndex][1], 0.25f);
					list3[num61].roadVecs[list3[num61].middleIndex].Insert(1, item4);
					break;
				}
				}
				bool flag11 = false;
				for (int num62 = 0; num62 < list.Count; num62++)
				{
					if (list[num62] != list3[num61])
					{
						continue;
					}
					for (int num63 = num62; num63 < list.Count; num63++)
					{
						if (list[num63].buildPriority == 0)
						{
							list[num63].mainConnectionDecalVecs = list3[num61].priorityPointsMain;
							flag11 = true;
							break;
						}
					}
					if (flag11)
					{
						continue;
					}
					for (int num64 = 0; num64 < num62; num64++)
					{
						if (list[num64].buildPriority == 0)
						{
							list[num64].mainConnectionDecalVecs = list3[num61].priorityPointsMain;
							flag11 = true;
							break;
						}
					}
				}
				EROQODDCCCCD(list3[num61].roadVecs, list3[num61].roadShapeUVs, ref list3[num61].roadUVs, ref list3[num61].roadColors, list3[num61].priorityPointsMain, ref list3[num61].priorityPointsMainUVs, ref list3[num61].priorityPointsMainColors, crossPointCenter, list3[num61].uvRatio, list3[num61], primarySection: false);
			}
			OCOCDCDDOD(siblings, list2);
			prefabScript.isYConnector = true;
			bool hasLaneControlData = false;
			for (int num65 = 0; num65 < siblings.Count; num65++)
			{
				if (prefabScript.crossingElements.Count - 1 < num65)
				{
					prefabScript.crossingElements.Add(new QDOODOQQDQODD());
				}
				if (prefabScript.sidewalkControlElements.Count - 1 < num65)
				{
					prefabScript.sidewalkControlElements.Add(new QDOQDSQOOQDDD(baseScript));
				}
				if (siblings[num65].laneData == null)
				{
					siblings[num65].laneData = ERLaneData.CreateInstance();
				}
				ERLaneData laneData = siblings[num65].laneData;
				if (laneData.connectors.Count > 0)
				{
					hasLaneControlData = true;
				}
				if (!prefabScript.signPostsSet)
				{
				}
				siblings[num65].globalForward = (prefabScript.transform.TransformPoint(siblings[num65].leftRoundingPoints[0]) - prefabScript.transform.TransformPoint(siblings[num65].leftRoundingPoints[1])).normalized;
				siblings[num65].TrafficPostsHandler(num65, prefabScript.transform, prefabScript);
			}
			if (prefabScript.crossingElements.Count > siblings.Count)
			{
				for (int num66 = siblings.Count - 1; num66 < prefabScript.crossingElements.Count; num66++)
				{
					prefabScript.crossingElements.RemoveAt(num66);
				}
			}
			for (int num67 = 0; num67 < siblings.Count; num67++)
			{
				if (siblings[num67].road != null)
				{
					if (prefabScript.crossingElements[num67].connectedMarker == 0)
					{
						siblings[num67].leftRoadIndent = (prefabScript.crossingElements[num67].leftRoadIndent = siblings[num67].road.markersExt[0].rightIndent);
						siblings[num67].leftRoadSurrounding = (prefabScript.crossingElements[num67].leftRoadSurrounding = siblings[num67].road.markersExt[0].rightSurrounding);
						siblings[num67].rightRoadIndent = (prefabScript.crossingElements[num67].rightRoadIndent = siblings[num67].road.markersExt[0].leftIndent);
						siblings[num67].rightRoadSurrounding = (prefabScript.crossingElements[num67].rightRoadSurrounding = siblings[num67].road.markersExt[0].leftSurrounding);
					}
					else
					{
						siblings[num67].leftRoadIndent = (prefabScript.crossingElements[num67].leftRoadIndent = siblings[num67].road.markersExt[siblings[num67].road.markersExt.Count - 1].leftIndent);
						siblings[num67].leftRoadSurrounding = (prefabScript.crossingElements[num67].leftRoadSurrounding = siblings[num67].road.markersExt[siblings[num67].road.markersExt.Count - 1].leftSurrounding);
						siblings[num67].rightRoadIndent = (prefabScript.crossingElements[num67].rightRoadIndent = siblings[num67].road.markersExt[siblings[num67].road.markersExt.Count - 1].rightIndent);
						siblings[num67].rightRoadSurrounding = (prefabScript.crossingElements[num67].rightRoadSurrounding = siblings[num67].road.markersExt[siblings[num67].road.markersExt.Count - 1].rightSurrounding);
					}
				}
			}
			if (!baseScript.connectionSWObjects.Contains(prefabScript))
			{
				baseScript.connectionSWObjects.Add(prefabScript);
			}
			prefabScript.turnSWAroundCornerThreshold = turnSWAroundCornerThreshold;
			for (int num68 = 0; num68 < list.Count; num68++)
			{
				if (list[num68].roadType != null)
				{
					OQDDQOOCCO(list, num68);
					if (list[num68].leftSidewalkGO != null)
					{
						UnityEngine.Object.DestroyImmediate(list[num68].leftSidewalkGO);
					}
					if (list[num68].rightSidewalkGO != null)
					{
						UnityEngine.Object.DestroyImmediate(list[num68].rightSidewalkGO);
					}
				}
				prefabScript.crossingElements[num68].leftCorner = prefabScript.transform.TransformPoint(siblings[num68].ip);
				prefabScript.crossingElements[num68].rightCorner = prefabScript.transform.TransformPoint(siblings[num68].ipRight);
				prefabScript.crossingElements[num68].centerCornerDirectionLeft = (prefabScript.crossingElements[num68].leftCorner - prefabScript.transform.TransformPoint(Vector3.zero)).normalized;
				prefabScript.crossingElements[num68].centerCornerDirectionRight = (prefabScript.crossingElements[num68].rightCorner - prefabScript.transform.TransformPoint(Vector3.zero)).normalized;
			}
			prefabScript.sidewalkControlElements.Clear();
			bool flag12 = true;
			for (int num69 = 0; num69 < siblings.Count; num69++)
			{
				prefabScript.sidewalkControlElements.Add(new QDOQDSQOOQDDD(baseScript));
				if (siblings[num69].roadType != null)
				{
					OOOQCCODDC(prefabScript.crossingElements[num69], siblings[num69], num69, siblings.Count);
				}
				else
				{
					Debug.Log("EasyRoads3Dv3: Connection " + num69 + ", no road type assigned. The flex connector requires roads / connections with a road type assigned");
				}
				if (siblings[num69].road.startPrefabScript == prefabScript && siblings[num69].road.startConnectionSegment == num69)
				{
					if (!siblings[num69].road.bridgeAtStart)
					{
						flag12 = false;
					}
					else
					{
						siblings[num69].bridgeSection = true;
					}
				}
				else if (siblings[num69].road.endPrefabScript == prefabScript && siblings[num69].road.endConnectionSegment == num69)
				{
					if (!siblings[num69].road.bridgeAtEnd)
					{
						flag12 = false;
					}
					else
					{
						siblings[num69].bridgeSection = true;
					}
				}
			}
			if (prefabScript.deformTerrain)
			{
				if (flag12)
				{
					if (prefabScript.surfaceObject != null)
					{
						if (prefabScript.surfaceObject.GetComponent<MeshFilter>() != null && prefabScript.surfaceObject.GetComponent<MeshFilter>().sharedMesh != null)
						{
							prefabScript.surfaceObject.GetComponent<MeshFilter>().sharedMesh.Clear();
						}
						if (prefabScript.surfaceObject.GetComponent<MeshCollider>() != null && prefabScript.surfaceObject.GetComponent<MeshCollider>().sharedMesh != null)
						{
							prefabScript.surfaceObject.GetComponent<MeshCollider>().sharedMesh.Clear();
						}
					}
				}
				else
				{
					OCDDOODQDQ.UpdateYCrossingSurfaces(prefabScript, prefabScript.tmpMeshVecs, list, ref prefabScript.surfaceMeshVecs);
				}
			}
			else if (prefabScript.surfaceObject != null)
			{
				UnityEngine.Object.DestroyImmediate(prefabScript.surfaceObject);
			}
			prefabScript.meshVecs = cScr.gameObject.GetComponent<MeshFilter>().sharedMesh.vertices;
			prefabScript.tmpMeshVecs = prefabScript.meshVecs;
			prefabScript.tmpFullMeshVecs = prefabScript.meshVecs;
			int num70 = 0;
			for (int num71 = 0; num71 < siblings.Count; num71++)
			{
				prefabScript.crossingElements[num71].rightIndent = siblings[num71].rightIndent;
				prefabScript.crossingElements[num71].rightIndentV3 = siblings[num71].rightIndentV3;
				prefabScript.crossingElements[num71].leftIndent = siblings[num71].leftIndent;
				prefabScript.crossingElements[num71].leftIndentV3 = siblings[num71].leftIndentV3;
				prefabScript.crossingElements[num71].rightSurrounding = siblings[num71].rightSurrounding;
				prefabScript.crossingElements[num71].rightSurroundingV3 = siblings[num71].rightSurroundingV3;
				prefabScript.crossingElements[num71].leftSurrounding = siblings[num71].leftSurrounding;
				prefabScript.crossingElements[num71].leftSurroundingV3 = siblings[num71].leftSurroundingV3;
				prefabScript.crossingElements[num71].direction = siblings[num71].forward.normalized;
				prefabScript.crossingElements[num71].includeLeftSidewalk = siblings[num71].leftSidewalkActive;
				prefabScript.crossingElements[num71].includeRightSidewalk = siblings[num71].rightSidewalkActive;
				prefabScript.crossingElements[num71].centerCornerDirectionLeft = (prefabScript.crossingElements[num71].centerCornerDirectionRight = Vector3.zero);
				bool flag13 = false;
				bool flag14 = false;
				ERConnectionSibling eRConnectionSibling6 = null;
				eRConnectionSibling6 = ((siblings[num71].orderedIndex >= siblings.Count - 1) ? list[0] : list[siblings[num71].orderedIndex + 1]);
				ERConnectionSibling eRConnectionSibling7 = null;
				eRConnectionSibling7 = ((siblings[num71].orderedIndex <= 0) ? list[list.Count - 1] : list[siblings[num71].orderedIndex - 1]);
				if (eRConnectionSibling6.buildPriority == 1)
				{
					flag14 = true;
				}
				if (eRConnectionSibling7.buildPriority == 1)
				{
					flag13 = true;
				}
				if (siblings[num71].buildPriority == 0 && !siblings[num71].primaryPriorityConnection && !siblings[num71].secondaryPriorityConnection && !flag14 && !flag13)
				{
					prefabScript.crossingElements[num71].leftRoundingPoints = new List<Vector3>(siblings[num71].leftRoundingPoints);
					prefabScript.crossingElements[num71].rightRoundingPoints = new List<Vector3>(siblings[num71].rightRoundingPoints);
				}
				else if (siblings[num71].buildPriority == 1)
				{
					prefabScript.crossingElements[num71].leftRoundingPoints = new List<Vector3>(siblings[num71].leftRoundingPoints);
					prefabScript.crossingElements[num71].rightRoundingPoints = new List<Vector3>(siblings[num71].rightRoundingPoints);
				}
				else
				{
					if (flag14)
					{
						prefabScript.crossingElements[num71].leftRoundingPoints.Clear();
						Vector3 vector11 = eRConnectionSibling6.rightRoundingPoints[eRConnectionSibling6.rightRoundingPoints.Count - 1];
						for (int num72 = 0; num72 < siblings[num71].leftRoundingPoints.Count; num72++)
						{
							prefabScript.crossingElements[num71].leftRoundingPoints.Add(siblings[num71].leftRoundingPoints[num72]);
							if (siblings[num71].leftRoundingPoints[num72] == vector11)
							{
								break;
							}
						}
					}
					else
					{
						prefabScript.crossingElements[num71].leftRoundingPoints = new List<Vector3>(siblings[num71].leftRoundingPoints);
					}
					if (flag13)
					{
						prefabScript.crossingElements[num71].rightRoundingPoints.Clear();
						Vector3 vector11 = eRConnectionSibling7.leftRoundingPoints[eRConnectionSibling7.leftRoundingPoints.Count - 1];
						for (int num73 = 0; num73 < siblings[num71].rightRoundingPoints.Count; num73++)
						{
							prefabScript.crossingElements[num71].rightRoundingPoints.Add(siblings[num71].rightRoundingPoints[num73]);
							if (siblings[num71].rightRoundingPoints[num73] == vector11)
							{
								break;
							}
						}
					}
					else
					{
						prefabScript.crossingElements[num71].rightRoundingPoints = new List<Vector3>(siblings[num71].rightRoundingPoints);
					}
				}
				siblings[num71].prevAngle = siblings[num71].angle;
				if (siblings[num71].oldCP != prefabScript.crossingElements[num71].centerPoint)
				{
					siblings[num71].hasChanged = true;
				}
				if (!prefabScript.baseScript.RoadObjectsSoUpdates.Contains(siblings[num71].road))
				{
				}
				num70 = siblings[num71].orderedIndex + 1;
				if (num70 >= list.Count)
				{
					num70 = 0;
				}
				for (int num74 = 0; num74 < siblings.Count; num74++)
				{
					if (siblings[num74].orderedIndex == num70)
					{
						num70 = num74;
						break;
					}
				}
				prefabScript.sidewalkControlElements[num71].crossingElementLeftIndex = num71;
				prefabScript.sidewalkControlElements[num71].crossingElementRightIndex = num70;
				if (siblings[num71].buildPriority == 0 && siblings[num70].buildPriority == 0)
				{
					prefabScript.sidewalkControlElements[num71].centerHandleV3 = siblings[num71].leftRoundingPoints[siblings[num71].leftRoundingPoints.Count - 1];
				}
				else if (siblings[num71].buildPriority == 1)
				{
					prefabScript.sidewalkControlElements[num71].centerHandleV3 = siblings[num71].leftCurvatureVec;
				}
				else
				{
					prefabScript.sidewalkControlElements[num71].centerHandleV3 = siblings[num70].rightCurvatureVec;
				}
				prefabScript.sidewalkControlElements[num71].leftHandleV3 = siblings[num71].leftRoundingPoints[0];
				prefabScript.sidewalkControlElements[num71].rightHandleV3 = siblings[num70].rightRoundingPoints[0];
				if (siblings[num71].leftSidewalkActive || siblings[num70].rightSidewalkActive)
				{
					prefabScript.sidewalkControlElements[num71].renderFlag = true;
				}
				else
				{
					prefabScript.sidewalkControlElements[num71].renderFlag = false;
				}
				prefabScript.sidewalkControlElements[num71].leftConnectionHandle = siblings[num71].leftSidewalkActive;
				prefabScript.sidewalkControlElements[num71].rightConnectionHandle = siblings[num70].rightSidewalkActive;
			}
			if (prefabScript.baseScript.aiTraffic)
			{
				OCQDDQCOCC(hasLaneControlData);
			}
			prefabScript.ODOQCOOOCC(ignorePriority: true, null);
			prefabScript.isFlexUpdating = false;
		}

		public static void HandleSidewalks()
		{
		}

		public static bool OQCOOCOQQQ(List<ERConnectionSibling> siblings, int thisSibling, int OtherSibling, int startLane)
		{
			if (siblings[OtherSibling].leftRoundingPoints.Count == 0 || siblings[OtherSibling].roadType == null || siblings[OtherSibling].roadType.roadShapeData.lanes.Count == 0)
			{
				return false;
			}
			if (siblings[thisSibling].roadType == null || siblings[thisSibling].roadType.roadShapeData.lanes.Count <= startLane)
			{
				return false;
			}
			Vector3 a = Vector3.Lerp(siblings[OtherSibling].leftRoundingPoints[0], prefabScript.crossingElements[OtherSibling].centerPoint, -1f * siblings[OtherSibling].roadType.roadShapeData.lanes[0].position);
			int index = siblings[OtherSibling].roadType.roadShapeData.lanes.Count - 1;
			Vector3 a2 = Vector3.Lerp(siblings[OtherSibling].leftRoundingPoints[0], prefabScript.crossingElements[OtherSibling].centerPoint, -1f * siblings[OtherSibling].roadType.roadShapeData.lanes[index].position);
			Vector3 b = Vector3.Lerp(siblings[thisSibling].leftRoundingPoints[0], prefabScript.crossingElements[thisSibling].centerPoint, -1f * siblings[thisSibling].roadType.roadShapeData.lanes[startLane].position);
			float num = Vector3.Distance(a, b);
			float num2 = Vector3.Distance(a2, b);
			bool flag = false;
			if (num2 > num)
			{
				flag = true;
			}
			if (!flag)
			{
				int num3 = 0;
				for (int i = 0; i < siblings.Count; i++)
				{
					if (siblings[i].buildPriority == 0)
					{
						num3++;
					}
				}
				if (num3 > 2)
				{
					flag = true;
				}
			}
			return true;
		}

		public static void OCQDDQCOCC(bool hasLaneControlData)
		{
			if (prefabScript == null)
			{
				return;
			}
			if (prefabScript.baseScript == null)
			{
				if ((bool)prefabScript.transform.parent && (bool)prefabScript.transform.parent.parent)
				{
					baseScript = prefabScript.transform.parent.parent.GetComponent<ERModularBase>();
				}
				if (baseScript == null)
				{
					baseScript = UnityEngine.Object.FindObjectOfType(typeof(ERModularBase)) as ERModularBase;
					if (baseScript == null)
					{
						return;
					}
				}
			}
			if (!prefabScript.baseScript.displayLaneData)
			{
				return;
			}
			if (hasLaneControlData)
			{
				for (int i = 0; i < siblings.Count; i++)
				{
					if (siblings[i].roadType == null)
					{
						return;
					}
					bool flag = false;
					if (siblings[i].aIInit && prefabScript.crossingElements[i].connectedRoad != null && prefabScript.crossingElements[i].connectedRoad.roadType != 0.0 && prefabScript.crossingElements[i].connectedRoad.roadType != siblings[i].roadTypeAIid)
					{
						QDQDOOQQDQODD roadTypeAI = siblings[i].roadTypeAI;
						flag = true;
						siblings[i].roadTypeAI = (prefabScript.crossingElements[i].connectedRoad.rt = QDQDOOQQDQODD.GetRoadTypeElByID(prefabScript.crossingElements[i].connectedRoad.baseScript.roadTypes, prefabScript.crossingElements[i].connectedRoad.roadType));
						siblings[i].roadTypeAIid = siblings[i].roadTypeAI.id;
						if (QDQDOOQQDQODD.ODQOCQCQCD(roadTypeAI, siblings[i].roadTypeAI))
						{
							siblings[i].laneData.connectors.Clear();
							for (int j = 0; j < siblings.Count; j++)
							{
								ERLaneData laneData = siblings[i].laneData;
								for (int k = 0; k < laneData.connectors.Count; k++)
								{
									if (laneData.connectors[k].endLaneIndex == i)
									{
										laneData.connectors.RemoveAt(k);
										k--;
									}
								}
							}
							siblings[i].aIInit = false;
						}
					}
					if (siblings[i].aIInit)
					{
						continue;
					}
					ERLaneData laneData2 = siblings[i].laneData;
					if (siblings[i].roadTypeAI == null)
					{
						siblings[i].roadTypeAI = siblings[i].roadType;
					}
					for (int l = 0; l < siblings[i].roadTypeAI.roadShapeData.lanes.Count; l++)
					{
						if (siblings[i].roadTypeAI.roadShapeData.lanes[l].direction != ERLaneDirection.Right)
						{
							continue;
						}
						int num = -1;
						if (siblings[i] == primaryPriorityConnection)
						{
							num = 0;
						}
						else if (siblings[i] == secondPriorityConnection)
						{
							num = 1;
						}
						for (int m = 0; m < siblings.Count; m++)
						{
							if (siblings[m].leftRoundingPoints.Count == 0 || siblings[m].rightRoundingPoints.Count == 0)
							{
								return;
							}
							if (m == i)
							{
								continue;
							}
							if (siblings[m].roadTypeAI.roadShapeData.leftLanes == -1)
							{
								siblings[m].roadTypeAI.OQCOOODCQC();
							}
							for (int n = 0; n < siblings[m].roadTypeAI.roadShapeData.leftLanes; n++)
							{
								bool stop = false;
								if (siblings[i].buildPriority == 1)
								{
									stop = true;
								}
								if (siblings[m].buildPriority == 1)
								{
									stop = OQCOOCOQQQ(siblings, i, m, l);
								}
								ERLaneConnector eRLaneConnector = OOQCCDOOQD(cScr, i, l, m, n, stop, siblings[i].roadTypeAI.roadShapeData.lanes[l].TurnOptions, siblings[i].forward, siblings[m].forward, siblings[m].roadTypeAI.roadShapeData.lanes.Count);
								if (eRLaneConnector != null)
								{
									eRLaneConnector.minSpeed = siblings[m].roadTypeAI.minSpeed;
									eRLaneConnector.maxSpeed = siblings[m].roadTypeAI.maxSpeed;
									eRLaneConnector.speedLimit = siblings[m].roadTypeAI.speedLimitConnections;
									laneData2.connectors.Add(eRLaneConnector);
								}
							}
							if (siblings[i].roadTypeAI.roadShapeData.leftLanes == -1)
							{
								siblings[i].roadTypeAI.OQCOOODCQC();
							}
							ERLaneData laneData3 = siblings[m].laneData;
							for (int num2 = 0; num2 < siblings[m].roadTypeAI.roadShapeData.lanes.Count; num2++)
							{
								if (siblings[m].roadTypeAI.roadShapeData.lanes[num2].direction != ERLaneDirection.Right)
								{
									continue;
								}
								num = -1;
								if (siblings[m] == primaryPriorityConnection)
								{
									num = 0;
								}
								else if (siblings[m] == secondPriorityConnection)
								{
									num = 1;
								}
								for (int num3 = 0; num3 < siblings[i].roadTypeAI.roadShapeData.leftLanes; num3++)
								{
									if (!laneData3.Exists(i, num3))
									{
										bool stop2 = false;
										if (siblings[i].buildPriority == 1)
										{
											stop2 = true;
										}
										if (siblings[i].buildPriority == 1)
										{
											stop2 = OQCOOCOQQQ(siblings, m, i, num2);
										}
										ERLaneConnector eRLaneConnector2 = OOQCCDOOQD(cScr, m, num2, i, num3, stop2, siblings[i].roadTypeAI.roadShapeData.lanes[l].TurnOptions, siblings[i].forward, siblings[m].forward, siblings[m].roadTypeAI.roadShapeData.lanes.Count);
										if (eRLaneConnector2 != null)
										{
											eRLaneConnector2.minSpeed = siblings[i].roadTypeAI.minSpeed;
											eRLaneConnector2.maxSpeed = siblings[i].roadTypeAI.maxSpeed;
											eRLaneConnector2.speedLimit = siblings[i].roadTypeAI.speedLimitConnections;
											laneData3.connectors.Add(eRLaneConnector2);
										}
									}
								}
							}
						}
					}
				}
			}
			for (int num4 = 0; num4 < siblings.Count && siblings[num4].leftRoundingPoints.Count != 0 && siblings[num4].rightRoundingPoints.Count != 0; num4++)
			{
				if (!hasLaneControlData)
				{
					siblings[num4].roadTypeAI = siblings[num4].roadType;
					if (siblings[num4].roadTypeAI != null)
					{
						siblings[num4].roadTypeAIid = siblings[num4].roadTypeAI.id;
					}
					if (prefabScript.crossingElements[num4].connectedRoad != null)
					{
						if (prefabScript.crossingElements[num4].connectedRoad.roadType != 0.0 && prefabScript.crossingElements[num4].connectedRoad.roadType != siblings[num4].roadTypeAIid)
						{
							QDQDOOQQDQODD roadTypeAI2 = siblings[num4].roadTypeAI;
							bool flag2 = true;
							if (prefabScript.crossingElements[num4].connectedRoad.roadType == 0.0)
							{
								Debug.Log("EasyRoads3Dv3 Warning: " + prefabScript.crossingElements[num4].connectedRoad.gameObject.name + " has no road type assigned, lane data generation aborted");
								continue;
							}
							siblings[num4].roadTypeAI = (prefabScript.crossingElements[num4].connectedRoad.rt = QDQDOOQQDQODD.GetRoadTypeElByID(prefabScript.crossingElements[num4].connectedRoad.baseScript.roadTypes, prefabScript.crossingElements[num4].connectedRoad.roadType));
							if (siblings[num4].roadTypeAI == null)
							{
								Debug.Log("EasyRoads3Dv3 Warning: " + prefabScript.crossingElements[num4].connectedRoad.gameObject.name + " has no road type assigned, lane data generation aborted");
								continue;
							}
							siblings[num4].roadTypeAIid = siblings[num4].roadTypeAI.id;
						}
					}
					else if (prefabScript.baseScript.aiIgnoreConnections)
					{
						continue;
					}
				}
				if (siblings[num4].roadTypeAI == null)
				{
					siblings[num4].roadTypeAI = siblings[num4].roadType;
				}
				if (siblings[num4].roadTypeAI == null)
				{
					break;
				}
				ERLaneData laneData4 = siblings[num4].laneData;
				siblings[num4].aIInit = true;
				if (siblings[num4].road == null)
				{
					siblings[num4].road = prefabScript.crossingElements[num4].connectedRoad;
				}
				if (siblings[num4].roadTypeAI.roadShapeData.leftLanes == -1)
				{
					siblings[num4].roadTypeAI.OQCOOODCQC();
				}
				if (!hasLaneControlData)
				{
					if (laneData4 == null)
					{
						break;
					}
					laneData4.connectors.Clear();
					ERLaneDirection eRLaneDirection = ERLaneDirection.Right;
					if (prefabScript.baseScript.rightHandDriving == 0)
					{
						eRLaneDirection = ERLaneDirection.Left;
					}
					bool flag3 = !prefabScript.baseScript.aiMatchingLanesOnly;
					int num5 = 0;
					int num6 = 0;
					if (!siblings[num4].roadTypeAI.roadShapeData.isset)
					{
						continue;
					}
					for (int num7 = 0; num7 < siblings[num4].roadTypeAI.roadShapeData.lanes.Count; num7++)
					{
						bool flag4 = false;
						bool flag5 = false;
						if (siblings[num4].roadTypeAI.oneWay)
						{
							if (siblings[num4].road != null && ((siblings[num4].road.endPrefabScript == prefabScript && siblings[num4].road.endConnectionSegment == num4 && siblings[num4].road.oneWayDirection == ERLaneDirection.Right) || (siblings[num4].road.startPrefabScript == prefabScript && siblings[num4].road.startConnectionSegment == num4 && siblings[num4].road.oneWayDirection == ERLaneDirection.Left)))
							{
								flag4 = true;
							}
						}
						else if (siblings[num4].roadTypeAI.roadShapeData.lanes[num7].direction == eRLaneDirection)
						{
							flag4 = true;
						}
						if (!flag4)
						{
							continue;
						}
						num6 = siblings[num4].roadTypeAI.roadShapeData.lanes[num7].laneIndex;
						int num8 = -1;
						if (siblings[num4] == primaryPriorityConnection)
						{
							num8 = 0;
						}
						else if (siblings[num4] == secondPriorityConnection)
						{
							num8 = 1;
						}
						for (int num9 = 0; num9 < siblings.Count; num9++)
						{
							if (prefabScript.crossingElements[num9].connectedRoad == null && prefabScript.baseScript.aiIgnoreConnections)
							{
								continue;
							}
							if (siblings[num9].leftRoundingPoints.Count == 0 || siblings[num9].rightRoundingPoints.Count == 0)
							{
								return;
							}
							if (num9 == num4)
							{
								continue;
							}
							if (siblings[num9].roadTypeAI == null)
							{
								siblings[num9].roadTypeAI = siblings[num9].roadType;
							}
							if (siblings[num9].roadTypeAI.roadShapeData.leftLanes == -1)
							{
								siblings[num9].roadTypeAI.OQCOOODCQC();
							}
							flag5 = false;
							if (siblings[num9].roadTypeAI.oneWay && siblings[num9].road != null && ((siblings[num9].road.endPrefabScript == prefabScript && siblings[num9].road.endConnectionSegment == num9 && siblings[num9].road.oneWayDirection == ERLaneDirection.Left) || (siblings[num9].road.startPrefabScript == prefabScript && siblings[num9].road.startConnectionSegment == num9 && siblings[num9].road.oneWayDirection == ERLaneDirection.Right)))
							{
								flag5 = true;
							}
							int num10 = 10;
							int num11 = 0;
							bool flag6 = false;
							int count = siblings[num9].roadTypeAI.roadShapeData.lanes.Count;
							if (siblings[num9].roadTypeAI.oneWay)
							{
								if (flag5)
								{
									num10 = 0;
									num11 = count;
								}
							}
							else if (prefabScript.baseScript.rightHandDriving == 1)
							{
								num10 = 0;
								num11 = siblings[num9].roadTypeAI.roadShapeData.leftLanes;
							}
							else
							{
								num10 = siblings[num9].roadTypeAI.roadShapeData.leftLanes;
								num11 = siblings[num9].roadTypeAI.roadShapeData.lanes.Count;
							}
							int num12 = -1;
							if (num6 >= num11 && !flag3 && prefabScript.baseScript.aiconnectNonMatchinglaneCounts)
							{
								num12 = num11 - 1;
							}
							for (int num13 = num10; num13 < num11; num13++)
							{
								flag6 = false;
								if (flag5)
								{
									if (siblings[num4].roadTypeAI.oneWay)
									{
										if (count - num13 - 1 == num7)
										{
											flag6 = true;
										}
									}
									else
									{
										flag6 = true;
									}
								}
								if (!(((num6 == num13 - num10 || flag3 || num13 - num10 == num12) && !siblings[num9].roadTypeAI.oneWay) || flag6))
								{
									continue;
								}
								bool stop3 = false;
								if (siblings[num4].buildPriority == 1)
								{
									stop3 = true;
								}
								if (siblings[num9].buildPriority == 1)
								{
									stop3 = OQCOOCOQQQ(siblings, num4, num9, num7);
								}
								ERLaneConnector eRLaneConnector3 = OOQCCDOOQD(cScr, num4, num7, num9, num13, stop3, siblings[num4].roadTypeAI.roadShapeData.lanes[num7].TurnOptions, siblings[num4].forward, siblings[num9].forward, siblings[num9].roadTypeAI.roadShapeData.lanes.Count);
								if (eRLaneConnector3 != null)
								{
									eRLaneConnector3.minSpeed = siblings[num9].roadTypeAI.minSpeed;
									eRLaneConnector3.maxSpeed = siblings[num9].roadTypeAI.maxSpeed;
									eRLaneConnector3.speedLimit = siblings[num9].roadTypeAI.speedLimitConnections;
									if (eRLaneConnector3.points != null && eRLaneConnector3.points.Length > 2)
									{
										laneData4.connectors.Add(eRLaneConnector3);
									}
								}
							}
						}
						num5++;
					}
					continue;
				}
				for (int num14 = 0; num14 < laneData4.connectors.Count; num14++)
				{
					ERLaneConnector conn = laneData4.connectors[num14];
					if (siblings.Count > conn.endConnectionIndex)
					{
						ODOCCDCOQO(cScr.prefabScript, ref conn, num4, conn.endConnectionIndex, ERLaneDirectionOptions.AllDirections, siblings[num4].forward, siblings[conn.endConnectionIndex].forward);
					}
				}
			}
		}

		public static ERLaneConnector OOQCCDOOQD(ERCrossings scr, int startConnectionIndex, int startLaneIndex, int endConnectionIndex, int endLaneIndex, bool stop, ERLaneDirectionOptions turnOptions, Vector3 sourceDir, Vector3 targetDir, int totalLanes)
		{
			ERLaneConnector conn = ERLaneConnector.CreateInstance();
			conn.startConnectionIndex = startConnectionIndex;
			conn.startLaneIndex = startLaneIndex;
			conn.endConnectionIndex = endConnectionIndex;
			conn.endLaneIndex = endLaneIndex;
			conn.endLaneIndexRelative = totalLanes - 1 - endLaneIndex;
			conn.stop = stop;
			ODOCCDCOQO(scr.prefabScript, ref conn, startConnectionIndex, endConnectionIndex, turnOptions, sourceDir, targetDir);
			return conn;
		}

		public static void ODOCCDCOQO(ERCrossingPrefabs scr, ref ERLaneConnector conn, int startConnectionIndex, int endConnectionIndex, ERLaneDirectionOptions turnOptions, Vector3 sourceDir, Vector3 targetDir)
		{
			bool flag = false;
			if (scr.siblings[startConnectionIndex].buildPriority == 0 && scr.siblings[conn.endConnectionIndex].buildPriority == 0 && (scr.siblings[startConnectionIndex] == primaryPriorityConnection || scr.siblings[conn.endConnectionIndex] == primaryPriorityConnection))
			{
				flag = true;
			}
			int num = -1;
			if (scr.siblings[startConnectionIndex] == primaryPriorityConnection && scr.siblings[conn.endConnectionIndex].buildPriority == 0)
			{
				num = 0;
			}
			else if (scr.siblings[conn.endConnectionIndex] == primaryPriorityConnection && scr.siblings[startConnectionIndex].buildPriority == 0)
			{
				num = 1;
			}
			bool mainConnection = false;
			if (num != -1)
			{
				mainConnection = true;
			}
			if (scr.siblings[conn.endConnectionIndex].roadTypeAI.roadShapeData.lanes.Count == 0)
			{
				if (scr.baseScript.debugMode)
				{
					Debug.Log("EasyRoads3Dv3: road type " + scr.siblings[conn.endConnectionIndex].roadTypeAI.roadTypeName + " does not have lane info set");
				}
				return;
			}
			if (scr.siblings[startConnectionIndex].roadTypeAI.roadShapeData.lanes.Count == 0)
			{
				if (scr.baseScript.debugMode)
				{
					Debug.Log("EasyRoads3Dv3: road type " + scr.siblings[startConnectionIndex].roadTypeAI.roadTypeName + " does not have lane info set");
				}
				return;
			}
			if (conn.startLaneIndex >= scr.siblings[startConnectionIndex].roadTypeAI.roadShapeData.lanes.Count || conn.endLaneIndex >= scr.siblings[conn.endConnectionIndex].roadTypeAI.roadShapeData.lanes.Count)
			{
				if (scr.baseScript.debugMode)
				{
					Debug.Log("EasyRoads3Dv3: road type " + conn.startLaneIndex + " >= " + scr.siblings[startConnectionIndex].roadTypeAI.roadShapeData.lanes.Count + " OR " + scr.siblings[conn.endConnectionIndex].roadTypeAI.roadShapeData.lanes.Count + " < " + conn.endLaneIndex);
				}
				conn = null;
				return;
			}
			if (scr.baseScript.rightHandDriving == 1)
			{
				float position = scr.siblings[startConnectionIndex].roadTypeAI.roadShapeData.lanes[conn.startLaneIndex].position;
				if (position < 0f)
				{
					conn.connectorStartLocal = Vector3.Lerp(scr.crossingElements[startConnectionIndex].centerPoint, scr.siblings[startConnectionIndex].leftRoundingPoints[0], 0f - position);
				}
				else
				{
					conn.connectorStartLocal = Vector3.Lerp(scr.crossingElements[startConnectionIndex].centerPoint, scr.siblings[startConnectionIndex].rightRoundingPoints[0], position);
				}
				position = scr.siblings[conn.endConnectionIndex].roadTypeAI.roadShapeData.lanes[conn.endLaneIndex].position;
				if (position < 0f)
				{
					conn.connectorEndLocal = Vector3.Lerp(scr.crossingElements[conn.endConnectionIndex].centerPoint, scr.siblings[conn.endConnectionIndex].leftRoundingPoints[0], 0f - position);
				}
				else
				{
					conn.connectorEndLocal = Vector3.Lerp(scr.crossingElements[conn.endConnectionIndex].centerPoint, scr.siblings[conn.endConnectionIndex].rightRoundingPoints[0], position);
				}
			}
			else
			{
				conn.connectorStartLocal = Vector3.Lerp(scr.crossingElements[startConnectionIndex].centerPoint, scr.siblings[startConnectionIndex].leftRoundingPoints[0], -1f * scr.siblings[startConnectionIndex].roadTypeAI.roadShapeData.lanes[conn.startLaneIndex].position);
				conn.connectorEndLocal = Vector3.Lerp(scr.crossingElements[conn.endConnectionIndex].centerPoint, scr.siblings[conn.endConnectionIndex].rightRoundingPoints[0], scr.siblings[conn.endConnectionIndex].roadTypeAI.roadShapeData.lanes[conn.endLaneIndex].position);
			}
			conn.connectorStart = scr.transform.TransformPoint(conn.connectorStartLocal);
			conn.connectorEnd = scr.transform.TransformPoint(conn.connectorEndLocal);
			conn.mainConnection = mainConnection;
			conn.laneDirection = ERDirectionType.Straight;
			if (sourceDir != Vector3.zero)
			{
				float num2 = Vector3.Angle(sourceDir, targetDir);
				int orderedIndex = siblings[startConnectionIndex].orderedIndex;
				int orderedIndex2 = siblings[endConnectionIndex].orderedIndex;
				int num3 = siblings.Count - 1;
				int num4 = Mathf.Abs(orderedIndex - orderedIndex2);
				int num5 = 0;
				if (orderedIndex2 < orderedIndex && num4 == 1)
				{
					num5 = 1;
					conn.laneDirection = ERDirectionType.Right;
				}
				else if (orderedIndex2 > orderedIndex && num4 == 1)
				{
					num5 = -1;
					conn.laneDirection = ERDirectionType.Left;
				}
				if ((orderedIndex == 0 && orderedIndex2 == num3) || (orderedIndex == num3 && orderedIndex2 == 0))
				{
					num4 = 1;
					if (orderedIndex == 0 && orderedIndex2 == num3)
					{
						num5 = 1;
						conn.laneDirection = ERDirectionType.Right;
					}
					else
					{
						num5 = -1;
						conn.laneDirection = ERDirectionType.Left;
					}
				}
				if (num2 > 145f)
				{
					conn.laneDirection = ERDirectionType.Straight;
				}
				else if (num5 == -1)
				{
					conn.laneDirection = ERDirectionType.Left;
				}
				else
				{
					conn.laneDirection = ERDirectionType.Right;
				}
				if (turnOptions != ERLaneDirectionOptions.AllDirections)
				{
					if (num5 == -1 && (turnOptions == ERLaneDirectionOptions.Right || turnOptions == ERLaneDirectionOptions.Straight || turnOptions == ERLaneDirectionOptions.StraightRight))
					{
						conn = null;
						return;
					}
					if (num5 == 0 && (turnOptions == ERLaneDirectionOptions.Right || turnOptions == ERLaneDirectionOptions.Left))
					{
						conn = null;
						return;
					}
					if (num5 == 1 && (turnOptions == ERLaneDirectionOptions.Left || turnOptions == ERLaneDirectionOptions.Straight || turnOptions == ERLaneDirectionOptions.StraightLeft))
					{
						conn = null;
						return;
					}
				}
			}
			List<Vector3> list = new List<Vector3>();
			List<Vector3> list2 = new List<Vector3>();
			float num6 = 0f;
			int num7 = 0;
			float num8 = 0f;
			float num9 = 0f;
			float num10 = 0f;
			float num11 = 0f;
			float num12 = 0f;
			float num13 = 0f;
			if (flag)
			{
				if (num == 0)
				{
					if (scr.baseScript.rightHandDriving == 1)
					{
						list2 = new List<Vector3>(scr.siblings[startConnectionIndex].priorityRightPoints);
					}
					else
					{
						list2 = new List<Vector3>(scr.siblings[startConnectionIndex].priorityLeftPoints);
						list2.Reverse();
					}
				}
				else if (scr.baseScript.rightHandDriving == 1)
				{
					list2 = new List<Vector3>(scr.siblings[conn.endConnectionIndex].priorityLeftPoints);
					list2.Reverse();
				}
				else
				{
					list2 = new List<Vector3>(scr.siblings[startConnectionIndex].priorityRightPoints);
				}
				num11 = Vector3.Distance(conn.connectorStartLocal, list2[0]);
				num12 = Vector3.Distance(conn.connectorEndLocal, list2[list2.Count - 1]);
				num13 = num11 - num12;
			}
			if (flag && (double)num13 > -0.5 && (double)num13 < 0.5)
			{
				list = new List<Vector3>(list2);
				list2[0] = conn.connectorStartLocal;
				list2[list2.Count - 1] = conn.connectorEndLocal;
				float num14 = 0f;
				float num15 = (float)(list.Count - 2) * 1f;
				for (int i = 1; i < list.Count - 1; i++)
				{
					Vector3 normalized = (list[i - 1] - list[i + 1]).normalized;
					normalized = new Vector3(normalized.z, 0f, 0f - normalized.x).normalized;
					num14 = Mathf.Lerp(num11, num12, (float)i * 1f / num15);
					list2[i] = list[i] + normalized * num14;
					num6 += Vector3.Distance(list2[i - 1], list2[i]);
				}
				num6 += Vector3.Distance(list2[list2.Count - 2], list2[list2.Count - 1]);
			}
			else
			{
				Vector3 connectorStartLocal = conn.connectorStartLocal;
				Vector3 connectorEndLocal = conn.connectorEndLocal;
				Vector3 vector = connectorStartLocal;
				Vector3 vector2 = connectorEndLocal;
				float num16 = Vector3.Distance(connectorStartLocal, connectorEndLocal);
				Vector3 p = connectorStartLocal + scr.siblings[startConnectionIndex].dir * 1f;
				Vector3 vector3 = connectorEndLocal + scr.siblings[conn.endConnectionIndex].dir * 1f;
				Vector3 vector4 = OQQOCDQCQD.OCDCQCDDCC(connectorStartLocal, p, connectorEndLocal, vector3, flag: false);
				List<Vector3> leftpoints = new List<Vector3>();
				List<Vector3> rightpoints = new List<Vector3>();
				if (Vector3.Angle(scr.siblings[startConnectionIndex].dir, scr.siblings[conn.endConnectionIndex].dir) > 145f)
				{
					num16 = Vector3.Distance(connectorStartLocal, vector3);
					p = connectorStartLocal + -scr.siblings[startConnectionIndex].dir * num16;
					vector3 = connectorEndLocal + -scr.siblings[conn.endConnectionIndex].dir * num16;
					List<Vector3> points = new List<Vector3> { p, connectorStartLocal, connectorEndLocal, vector3 };
					list2 = OQQOCDQCQD.ODOQDOQCOD(points, 0.8f, 1f / num16);
					list2[list2.Count - 1] = connectorEndLocal;
				}
				else
				{
					float num17 = Vector3.Distance(connectorStartLocal, vector4);
					float num18 = Vector3.Distance(connectorEndLocal, vector4);
					if (num17 > num18)
					{
						vector = vector4 + -scr.siblings[startConnectionIndex].dir * num18;
					}
					else
					{
						vector2 = vector4 + -scr.siblings[conn.endConnectionIndex].dir * num17;
					}
					num16 = Vector3.Distance(vector, vector2);
					int cornerSegments = Mathf.RoundToInt(num16);
					float radius = num16 / conn.strength;
					GetOCCDOCDDCQ(0, vector4, radius, cornerSegments, vector, vector2, ref leftpoints, ref rightpoints, flag: true, scr.siblings[startConnectionIndex]);
					Vector3 pTarget = scr.siblings[startConnectionIndex].leftRoundingPoints[0];
					int num19 = 0;
					while (num19 < leftpoints.Count && !OQQOCDQCQD.OOCQODQDQD(pTarget, connectorStartLocal, leftpoints[num19]))
					{
						leftpoints.RemoveAt(num19);
						num19--;
						num19++;
					}
					pTarget = scr.siblings[conn.endConnectionIndex].leftRoundingPoints[0];
					int num20 = 0;
					while (num20 < rightpoints.Count && !OQQOCDQCQD.OOCQODQDQD(pTarget, connectorEndLocal, rightpoints[num20]))
					{
						rightpoints.RemoveAt(num20);
						num20--;
						num20++;
					}
					rightpoints.Reverse();
					if (rightpoints.Count > 0)
					{
						rightpoints.RemoveAt(0);
					}
					list2.AddRange(leftpoints);
					list2.AddRange(rightpoints);
					list2.Insert(0, connectorStartLocal);
					list2.Add(connectorEndLocal);
				}
				for (int j = 1; j < list2.Count; j++)
				{
					num6 += Vector3.Distance(list2[j - 1], list2[j]);
				}
			}
			num7 = Mathf.RoundToInt(num6 / 2f);
			num8 = num6 / ((float)num7 * 1f);
			list.Clear();
			list.Add(scr.transform.TransformPoint(list2[0]));
			num9 = 0f;
			num10 = 0f;
			float num21 = Vector3.Distance(list2[0], list2[1]);
			if (num21 > num8 * 1.5f)
			{
				float num22 = Mathf.RoundToInt(num21 / 2f);
				float num23 = num21 / (num22 * 1f);
				Vector3 normalized = (list2[1] - list2[0]).normalized;
				for (int k = 1; (float)k <= num22; k++)
				{
					list.Add(scr.transform.TransformPoint(list2[0] + normalized * k * num23));
				}
			}
			for (int l = 1; l < list2.Count - 1; l++)
			{
				num10 = Vector3.Distance(list2[l], list2[l + 1]);
				if (num9 + num10 > num8)
				{
					float num24 = num8 - num9;
					Vector3 normalized = (list2[l + 1] - list2[l]).normalized;
					Vector3 item = scr.transform.TransformPoint(list2[l] + normalized * num24);
					list.Add(item);
					num9 = num10 - num24;
				}
				else
				{
					num9 += num10;
				}
			}
			float num25 = Vector3.Distance(list2[list2.Count - 1], list2[list2.Count - 2]);
			if (num25 > num8 * 1.5f)
			{
				float num26 = Mathf.RoundToInt(num25 / 2f);
				float num27 = num25 / (num26 * 1f);
				Vector3 normalized = (list2[list2.Count - 1] - list2[list2.Count - 2]).normalized;
				for (int m = 1; (float)m <= num26 - 1f; m++)
				{
					list.Add(scr.transform.TransformPoint(list2[list2.Count - 2] + normalized * m * num27));
				}
			}
			list.Add(scr.transform.TransformPoint(list2[list2.Count - 1]));
			conn.points = list.ToArray();
		}

		public static bool OOCDOOCOOC(Vector3 left, Vector3 rightStart, Vector3 rightEnd, ref float angle1, float prevAngle1, float angle2, bool flag)
		{
			float num = angle1;
			if (num < 0f)
			{
				num += 360f;
			}
			if (angle2 < 0f)
			{
				angle2 += 360f;
			}
			else if (angle2 < angle1 && angle1 > 270f)
			{
				angle2 = 360f - angle2;
			}
			if (angle1 != prevAngle1 && Mathf.Abs(num - angle2) < 45f)
			{
				if (OQQOCDQCQD.OOCQODQDQD(rightStart, rightEnd, left) == flag)
				{
					angle1 = prevAngle1;
					return false;
				}
				if (Vector3.Distance(left, rightStart) < 2f)
				{
					angle1 = prevAngle1;
					return false;
				}
			}
			return true;
		}

		public static Vector3 GetCenterPoint(float distance, float angle)
		{
			return OQQOCDQCQD.OOQOCODQOO(new Vector3(0f, 0f, 0f - distance), Vector3.zero, Quaternion.Euler(0f, angle, 0f));
		}

		public static void OODCDQODQC(Vector3 cp, float roadWidth, ref Vector3 lStart, ref Vector3 lEnd, ref Vector3 rStart, ref Vector3 rEnd, float largestRadius)
		{
			largestRadius += 5f;
			Vector3 normalized = (Vector3.zero - cp).normalized;
			Vector3 normalized2 = new Vector3(0f - normalized.z, normalized.y, normalized.x).normalized;
			lStart = cp + normalized2 * 0.5f * roadWidth;
			lStart += -normalized * largestRadius;
			lEnd = lStart + normalized * roadWidth * 2f;
			rStart = cp + -normalized2 * 0.5f * roadWidth;
			rStart += -normalized * largestRadius;
			rEnd = rStart + normalized * roadWidth * 2f;
		}

		public static void GetOCCDOCDDCQ(int segment, Vector3 cp, float radius, int cornerSegments, Vector3 leftPoint, Vector3 rightPoint, ref List<Vector3> leftpoints, ref List<Vector3> rightpoints, bool flag, ERConnectionSibling sibling)
		{
			leftpoints.Clear();
			Vector3 normalized = (leftPoint - cp).normalized;
			if (flag)
			{
				leftPoint = cp + normalized * radius;
				normalized = (rightPoint - cp).normalized;
				rightPoint = cp + normalized * radius;
			}
			Vector3 normalized2 = (cp - leftPoint).normalized;
			Vector3 normalized3 = (rightPoint - leftPoint).normalized;
			Vector3 normalized4 = (cp - rightPoint).normalized;
			Vector3 normalized5 = (leftPoint - rightPoint).normalized;
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			if (normalized2 == normalized3)
			{
				num = Vector3.Distance(leftPoint, rightPoint);
				num3 = num / ((float)cornerSegments * 1f);
			}
			if (normalized4 == normalized5)
			{
				num2 = Vector3.Distance(cp, rightPoint);
				num4 = num2 / ((float)cornerSegments * 1f);
			}
			Vector3 vector = Vector3.zero;
			Vector3 vector2 = Vector3.zero;
			Vector3 vector3 = Vector3.zero;
			Vector3 vector4 = Vector3.zero;
			for (int i = 0; i <= cornerSegments; i++)
			{
				if (num == 0f)
				{
					normalized = Vector3.Lerp(normalized2, normalized3, (float)i * 1f / ((float)cornerSegments * 1f));
					vector = leftPoint - normalized * 10f;
					vector2 = leftPoint + normalized * 10f;
					ll1.Add(vector);
					ll2.Add(vector2);
				}
				else
				{
					leftpoints.Add(leftPoint + normalized2 * num3 * i);
				}
				if (num == 0f)
				{
					normalized = Vector3.Lerp(normalized5, normalized4, (float)i * 1f / ((float)cornerSegments * 1f));
					vector3 = rightPoint - normalized * 10f;
					vector4 = rightPoint + normalized * 10f;
					ll3.Add(vector3);
					ll4.Add(vector4);
				}
				if (num == 0f)
				{
					leftpoints.Add(OQQOCDQCQD.OCDCQCDDCC(vector, vector2, vector3, vector4, flag: false));
				}
			}
			if (flag)
			{
				rightpoints = new List<Vector3>(leftpoints);
				int num5 = Mathf.RoundToInt(Mathf.Ceil((float)cornerSegments * 0.5f));
				leftpoints.RemoveRange(num5 + 1, cornerSegments - num5);
				rightpoints.Reverse();
				rightpoints.RemoveRange(num5 + 1, cornerSegments - num5);
			}
		}

		private static void ODQOOQDOQQ(List<Vector3> rightPoints1, List<Vector3> leftPoints1, List<Vector3> leftPoints2, List<Vector3> rightPoints2, ref List<Vector3> outerpoints, ref List<Vector3> innerpoints, float dist)
		{
			outerpoints.Clear();
			innerpoints.Clear();
			innerpoints.AddRange(rightPoints1);
			for (int i = 0; i < rightPoints1.Count; i++)
			{
				Vector3 normalized;
				if (i == 0)
				{
					normalized = (leftPoints1[0] - rightPoints1[0]).normalized;
				}
				else if (i < rightPoints1.Count - 1)
				{
					normalized = (rightPoints1[i + 1] - rightPoints1[i - 1]).normalized;
					normalized = new Vector3(0f - normalized.z, 0f, normalized.x).normalized;
				}
				else
				{
					normalized = (rightPoints1[i] - rightPoints1[i - 1]).normalized;
					normalized = new Vector3(0f - normalized.z, 0f, normalized.x).normalized;
				}
				outerpoints.Add(rightPoints1[i] + normalized * dist);
			}
			int num = outerpoints.Count - 1;
			List<Vector3> list = new List<Vector3>();
			for (int j = 0; j < leftPoints2.Count; j++)
			{
				Vector3 normalized;
				if (j == 0)
				{
					normalized = (rightPoints2[0] - leftPoints2[0]).normalized;
				}
				else if (j < leftPoints2.Count - 1)
				{
					normalized = (leftPoints2[j + 1] - leftPoints2[j - 1]).normalized;
					normalized = new Vector3(normalized.z, 0f, 0f - normalized.x).normalized;
				}
				else
				{
					normalized = (leftPoints2[j] - leftPoints2[j - 1]).normalized;
					normalized = new Vector3(normalized.z, 0f, 0f - normalized.x).normalized;
				}
				list.Add(leftPoints2[j] + normalized * dist);
			}
			list.Reverse();
			outerpoints.AddRange(list);
			List<Vector3> list2 = new List<Vector3>(leftPoints2);
			list2.Reverse();
			list2.RemoveAt(0);
			innerpoints.AddRange(list2);
			List<Vector3> obj = outerpoints;
			Vector3 value = (outerpoints[num + 1] = Vector3.Lerp(outerpoints[num], outerpoints[num + 1], 0.5f));
			obj[num] = value;
			outerpoints.RemoveAt(num + 1);
		}

		private void vssss(ref float tssss, ref List<Vector3> ussss, ref List<Vector3> vssss, ref List<Vector3> wssss, ref List<Vector3> xssss, ref List<Vector3> yssss, ref List<Vector3> Assss)
		{
			float num = 0f;
			Vector3 a = Vector3.Lerp(ussss[0], vssss[0], 0.5f);
			for (int i = 1; i < ussss.Count; i++)
			{
				Vector3 vector = Vector3.Lerp(ussss[i], vssss[i], 0.5f);
				num += Vector3.Distance(a, vector);
				a = vector;
			}
			float num2 = Mathf.Floor(num / tssss) + 1f;
			float num3 = (num2 * tssss - num) * 0.5f;
			Vector3 normalized = (ussss[0] - ussss[1]).normalized;
			Vector3 item = ussss[0] + normalized * num3;
			ussss.Insert(0, item);
			xssss.Insert(0, item);
			item = vssss[0] + normalized * num3;
			vssss.Insert(0, item);
			wssss.Insert(0, item);
			normalized = (ussss[ussss.Count - 1] - ussss[ussss.Count - 2]).normalized;
			item = ussss[ussss.Count - 1] + normalized * num3;
			ussss.Add(item);
			Assss.Insert(0, item);
			item = vssss[vssss.Count - 1] + normalized * num3;
			vssss.Add(item);
			yssss.Insert(0, item);
		}

		private static bool wssst(float tssss, int ussss, Vector3 vssss, Vector3 wssss, ref List<Vector3> xssss, ref List<Vector3> yssss, float Assss, bool _0ssss, bool _1ssss, Vector3 _2ssss, int _3ssss, bool _4ssss, ref int ttsss, ref bool utsss)
		{
			xssss.Clear();
			Vector3 vector = OQQOCDQCQD.OCDCQCDDCC(vssss, wssss, yssss[0], yssss[yssss.Count - 1], flag: false);
			Vector3 zero;
			Vector3 vector2 = (zero = Vector3.zero);
			if ((double)Assss < 0.05)
			{
				Assss = 0.05f;
			}
			float num = tssss * Assss;
			float num2 = num * 0.1f;
			int num3 = -1;
			int num4 = -1;
			float num6;
			float num5 = (num6 = 100000f);
			float num7 = 0f;
			if (_0ssss)
			{
				bool flag = OQQOCDQCQD.OOCQODQDQD(vssss, wssss, yssss[yssss.Count - 1]);
				for (int num8 = yssss.Count - 1; num8 >= 0; num8--)
				{
					if (OQQOCDQCQD.OOCQODQDQD(vssss, wssss, yssss[num8]) != flag)
					{
						if (num8 == yssss.Count - 1)
						{
							Debug.Log("EasyRoads3Dv3: crosspoint is outside first priority index > swapflag " + _0ssss);
							num3 = yssss.Count - 2;
							num4 = yssss.Count - 1;
						}
						else
						{
							num3 = num8;
							num4 = num3 + 1;
						}
						break;
					}
				}
			}
			else
			{
				bool flag2 = OQQOCDQCQD.OOCQODQDQD(vssss, wssss, yssss[0]);
				for (int i = 0; i < yssss.Count; i++)
				{
					if (OQQOCDQCQD.OOCQODQDQD(vssss, wssss, yssss[i]) != _4ssss)
					{
						if (i == 0)
						{
							num3 = 1;
							num4 = 0;
						}
						else
						{
							num3 = i;
							num4 = i - 1;
						}
						break;
					}
				}
			}
			if (num4 < 0)
			{
				num4 = 0;
				if (num4 == num3)
				{
					num4++;
				}
			}
			else if (num4 >= yssss.Count)
			{
				num4 = yssss.Count - 1;
				if (num4 == num3)
				{
					num4--;
				}
			}
			if (num3 == -1 || num4 == -1)
			{
				Debug.LogError("EasyRoads3Dv3 Error: These angles between connections is not supported for the involved road types");
				return false;
			}
			vector = OQQOCDQCQD.OCDCQCDDCC(vssss, wssss, yssss[num3], yssss[num4], flag: false);
			int num9 = -1;
			bool flag3 = false;
			if (_0ssss)
			{
				int num10 = num3 + 1;
				if (num4 < num3)
				{
					num10 = num3;
				}
				float num11 = Vector3.Distance(vector, yssss[num10]);
				if (num11 > num)
				{
					if (num11 < num + num2)
					{
						vector2 = yssss[num10];
						num9 = num10;
					}
					else
					{
						zero = (yssss[num10] - vector).normalized;
						vector2 = vector + zero * num;
						num9 = num10;
						flag3 = true;
					}
				}
				else
				{
					for (int j = num10; j < yssss.Count - 1; j++)
					{
						num7 = Vector3.Distance(yssss[j], yssss[j + 1]);
						if (num7 + num11 > num)
						{
							if (num7 + num11 < num + num2)
							{
								vector2 = yssss[j + 1];
								num9 = j + 1;
								break;
							}
							zero = (yssss[j + 1] - yssss[j]).normalized;
							vector2 = yssss[j] + zero * (num - num11);
							num9 = j + 1;
							flag3 = true;
							break;
						}
						num11 += num7;
						if (num11 + num2 > num)
						{
							vector2 = yssss[j + 1];
							num9 = j + 1;
							break;
						}
					}
				}
				if (num9 == -1)
				{
					vector2 = yssss[yssss.Count - 1];
					zero = (yssss[yssss.Count - 1] - yssss[yssss.Count - 2]).normalized;
					float num12 = num - num11;
					vector2 += zero * num12;
					yssss.Add(vector2);
					yssss.Add(vector2 + zero * 0.5f);
				}
			}
			else
			{
				int num13 = num3;
				if (num4 < num3)
				{
					num13 = num4;
				}
				float num14 = Vector3.Distance(vector, yssss[num13]);
				if (num14 > num)
				{
					if (num14 < num + num2)
					{
						vector2 = yssss[num13];
						num9 = num13;
					}
					else
					{
						zero = (yssss[num13] - vector).normalized;
						vector2 = vector + zero * num;
						num9 = num13 + 1;
						flag3 = true;
					}
					float num15 = 0f;
					float num16 = 0f;
					bool flag4 = false;
					for (int k = 0; k < yssss.Count - 1; k++)
					{
						num15 = Vector3.Distance(yssss[k], vector2);
						num16 = Vector3.Distance(yssss[k], yssss[k + 1]);
						if (num15 < num16)
						{
							num9 = k + 1;
							flag4 = true;
							break;
						}
					}
					if (!flag4)
					{
						flag3 = false;
						vector2 = yssss[yssss.Count - 1];
						num9 = yssss.Count - 1;
					}
				}
				else
				{
					for (int num17 = num13; num17 > 0; num17--)
					{
						num7 = Vector3.Distance(yssss[num17], yssss[num17 - 1]);
						if (num7 + num14 > num)
						{
							if (num7 + num14 < num + num2)
							{
								vector2 = yssss[num17 - 1];
								num9 = num17 - 1;
								break;
							}
							zero = (yssss[num17 - 1] - yssss[num17]).normalized;
							vector2 = yssss[num17] + zero * (num - num14);
							num9 = num17;
							flag3 = true;
							break;
						}
						num14 += num7;
						if (num14 + num2 > num)
						{
							vector2 = yssss[num17 - 1];
							num9 = num17 - 1;
							break;
						}
					}
				}
				if (num9 == -1)
				{
					vector2 = yssss[0];
					zero = (yssss[0] - yssss[1]).normalized;
					float num18 = num - num14;
					vector2 += zero * num18;
					yssss.Insert(0, vector2);
					yssss.Insert(0, vector2 + zero * 0.5f);
				}
			}
			Vector3 normalized = (vector - vssss).normalized;
			Vector3 vector3 = vector + -normalized * tssss;
			Vector3 normalized2 = (vector2 - vector3).normalized;
			Vector3 normalized3 = (vector - vector2).normalized;
			Vector3 normalized4 = (vector3 - vector2).normalized;
			normalized3 = Vector3.Lerp(normalized4, normalized3, Assss);
			for (int l = 0; l <= ussss; l++)
			{
				Vector3 vector4 = Vector3.Lerp(normalized, normalized2, (float)l * 1f / ((float)ussss * 1f));
				Vector3 p = vector3 - vector4 * 10f;
				Vector3 p2 = vector3 + vector4 * 10f;
				vector4 = Vector3.Lerp(normalized4, normalized3, (float)l * 1f / ((float)ussss * 1f));
				Vector3 p3 = vector2 - vector4 * 10f;
				Vector3 p4 = vector2 + vector4 * 10f;
				xssss.Add(OQQOCDQCQD.OCDCQCDDCC(p, p2, p3, p4, flag: false));
			}
			if (flag3)
			{
				if (num9 - 1 >= 0)
				{
					float num19 = Vector3.Distance(vector2, yssss[num9 - 1]);
					float num20 = Vector3.Distance(yssss[num9], yssss[num9 - 1]);
					if (num20 < num19)
					{
						num9++;
					}
				}
				if (yssss.Count > num9 + 1)
				{
					float num21 = Vector3.Distance(vector2, yssss[num9 + 1]);
					float num22 = Vector3.Distance(yssss[num9], yssss[num9 + 1]);
					if (num21 < num22)
					{
						num9++;
					}
				}
				yssss.Insert(num9, vector2);
				utsss = flag3;
			}
			ttsss = num9;
			return true;
		}

		private static void MatchLeftRights(ref List<Vector3> leftRoundingPoints, Vector3 lStart, ref List<Vector3> rightRoundingPoints, Vector3 rStart, ERConnectionSibling conn)
		{
			float num = Vector3.Distance(lStart, leftRoundingPoints[0]);
			float num2 = Vector3.Distance(rStart, rightRoundingPoints[0]);
			float num3 = 1f;
			if (num > num2)
			{
				float num4 = num - num2;
				Vector3 normalized = (lStart - leftRoundingPoints[0]).normalized;
				Vector3 value = leftRoundingPoints[0] + normalized * num4;
				if ((double)num4 > 0.25)
				{
					leftRoundingPoints.Insert(0, leftRoundingPoints[0] + normalized * num4 * num3);
					return;
				}
				leftRoundingPoints[0] = value;
				leftRoundingPoints.Insert(0, leftRoundingPoints[0] + normalized * num4 * num3);
			}
			else if (num < num2)
			{
				float num5 = num2 - num;
				Vector3 normalized2 = (rStart - rightRoundingPoints[0]).normalized;
				Vector3 value2 = rightRoundingPoints[0] + normalized2 * num5;
				if ((double)num5 > 0.25)
				{
					rightRoundingPoints.Insert(0, rightRoundingPoints[0] + normalized2 * num5 * num3);
				}
				else
				{
					rightRoundingPoints[0] = value2;
				}
			}
		}

		public static void ODOQOCOOOO(List<Vector3> leftRoundingPoints, List<Vector3> rightRoundingPoints, ref List<List<Vector3>> roadVecs, List<Vector2> roadShape, int leftFixedPoint, int rightFixedPoint, int middleIndex, Vector3 cp, Vector3 cp1, ref List<Vector3> priorityPointsMain, ERConnectionSibling prioritySibling, bool isSecondary)
		{
			int num = 0;
			for (int i = 0; i < leftRoundingPoints.Count; i++)
			{
				Vector3 normalized;
				if (i == 0)
				{
					normalized = (rightRoundingPoints[0] - leftRoundingPoints[0]).normalized;
				}
				else if (i == leftRoundingPoints.Count - 1)
				{
					normalized = (crossPointCenter - leftRoundingPoints[i]).normalized;
				}
				else
				{
					normalized = (leftRoundingPoints[i + 1] - leftRoundingPoints[i - 1]).normalized;
					normalized = new Vector3(normalized.z, 0f, 0f - normalized.x).normalized;
				}
				for (int j = 0; j <= middleIndex; j++)
				{
					if (roadVecs.Count <= j)
					{
						roadVecs.Add(new List<Vector3>());
					}
					Vector3 vector;
					if (j <= leftFixedPoint)
					{
						vector = leftRoundingPoints[i] + normalized * (roadShape[j].x - roadShape[0].x);
						vector.y = roadShape[j].y;
					}
					else
					{
						vector = leftRoundingPoints[i] + normalized * (roadShape[j].x - roadShape[0].x);
						vector.y = roadShape[j].y;
						vector = OQQOCDQCQD.OCDCQCDDCC(leftRoundingPoints[i], vector, cp, cp1, flag: false);
						vector = Vector3.Lerp(vector, leftRoundingPoints[i], roadShape[j].x / roadShape[0].x);
						vector.y = roadShape[j].y;
					}
					if (!isSecondary || vector != Vector3.zero)
					{
						roadVecs[j].Add(vector);
					}
				}
			}
			for (int k = 0; k < rightRoundingPoints.Count; k++)
			{
				Vector3 normalized;
				if (k == 0)
				{
					normalized = (leftRoundingPoints[0] - rightRoundingPoints[0]).normalized;
				}
				else if (k == rightRoundingPoints.Count - 1)
				{
					normalized = (crossPointCenter - rightRoundingPoints[k]).normalized;
				}
				else
				{
					normalized = (rightRoundingPoints[k + 1] - rightRoundingPoints[k - 1]).normalized;
					normalized = new Vector3(0f - normalized.z, 0f, normalized.x).normalized;
				}
				float x = roadShape[roadShape.Count - 1].x;
				for (int l = middleIndex + 1; l < roadShape.Count; l++)
				{
					if (roadVecs.Count <= l)
					{
						roadVecs.Add(new List<Vector3>());
					}
					Vector3 vector;
					if (l < rightFixedPoint)
					{
						vector = rightRoundingPoints[k] + normalized * (x - roadShape[l].x);
						vector.y = roadShape[l].y;
						vector = OQQOCDQCQD.OCDCQCDDCC(rightRoundingPoints[k], vector, cp, cp1, flag: false);
						vector = Vector3.Lerp(vector, rightRoundingPoints[k], roadShape[l].x / x);
						vector.y = roadShape[l].y;
					}
					else
					{
						vector = rightRoundingPoints[k] + normalized * (x - roadShape[l].x);
						vector.y = roadShape[l].y;
					}
					if (!isSecondary || vector != Vector3.zero)
					{
						roadVecs[l].Add(vector);
					}
				}
			}
			if (!isSecondary)
			{
				return;
			}
			int num2 = -1;
			int num3 = -1;
			Vector2 vector2 = new Vector2(rightRoundingPoints[rightRoundingPoints.Count - 1].x, rightRoundingPoints[rightRoundingPoints.Count - 1].z);
			Vector2 b = new Vector2(leftRoundingPoints[leftRoundingPoints.Count - 1].x, leftRoundingPoints[leftRoundingPoints.Count - 1].z);
			for (int m = 0; m < priorityPointsMain.Count; m++)
			{
				Vector3 vector3 = cScr.transform.TransformPoint(vector2);
				Vector3 vector4 = cScr.transform.TransformPoint(priorityPointsMain[m]);
				if ((double)Vector2.Distance(new Vector2(priorityPointsMain[m].x, priorityPointsMain[m].z), vector2) < 0.001)
				{
					num2 = m;
				}
				if ((double)Vector2.Distance(new Vector2(priorityPointsMain[m].x, priorityPointsMain[m].z), b) < 0.001)
				{
					num3 = m;
				}
				if (num2 != -1 && num3 != -1)
				{
					break;
				}
			}
			if (num2 > num3)
			{
				int num4 = num2;
				num2 = num3;
				num3 = num4;
			}
			List<Vector2> list = new List<Vector2>();
			List<Vector3> list2 = new List<Vector3>();
			list.Add(new Vector2(leftRoundingPoints[0].x, leftRoundingPoints[0].z));
			if (num2 != -1 && num3 != -1)
			{
				float num5 = Vector3.Distance(roadVecs[0][roadVecs[0].Count - 1], priorityPointsMain[0]);
				float num6 = Vector3.Distance(roadVecs[roadVecs.Count - 1][roadVecs[roadVecs.Count - 1].Count - 1], priorityPointsMain[0]);
				if (num5 > num6)
				{
					for (int num7 = num3; num7 >= num2; num7--)
					{
						list.Add(new Vector2(priorityPointsMain[num7].x, priorityPointsMain[num7].z));
						list2.Add(priorityPointsMain[num7]);
					}
				}
				else
				{
					for (int n = num2; n <= num3; n++)
					{
						list.Add(new Vector2(priorityPointsMain[n].x, priorityPointsMain[n].z));
						list2.Add(priorityPointsMain[n]);
					}
				}
			}
			list.Add(new Vector2(rightRoundingPoints[0].x, rightRoundingPoints[0].z));
			int count = roadVecs.Count;
			Vector3 zero = Vector3.zero;
			bool flag = true;
			if (list2.Count > 2 && OQQOCDQCQD.OOCQODQDQD(list2[0], list2[list2.Count - 1], list2[Mathf.RoundToInt((float)list2.Count * 0.5f)]))
			{
				flag = false;
			}
			bool flag2 = true;
			for (int num8 = 1; num8 < roadVecs.Count - 1; num8++)
			{
				int num9 = roadVecs[num8].Count - 1;
				for (int num10 = num9; num10 >= 1; num10--)
				{
					if ((num8 != 0 || num10 != num9) && (num8 != count - 1 || num10 != num9))
					{
						bool flag3 = false;
						Vector3 vector5 = roadVecs[num8][num10];
						if (!OQOQOOCDCC.OCDCDOCQCQ(list.Count, list, roadVecs[num8][num10].x, roadVecs[num8][num10].z))
						{
							roadVecs[num8].RemoveAt(num10);
							flag3 = true;
						}
						if ((!flag3 || (num10 == 1 && flag3 && (num8 == prioritySibling.leftFixedIndex || num8 == prioritySibling.leftFixedIndex))) && num10 != num9)
						{
							zero = Vector3.zero;
							if (num10 == 1)
							{
								vector5 = roadVecs[num8][0] + prioritySibling.forward;
							}
							int index = -1;
							zero = ODDQOOQCCD(roadVecs[num8][num10 - 1], vector5, vector5, priorityPointsMain, 0, ref index);
							if (num8 == prioritySibling.leftFixedIndex)
							{
								prioritySibling.priorityPointsMainLeftIndex = index;
							}
							else if (num8 == prioritySibling.rightFixedIndex)
							{
								prioritySibling.priorityPointsMainRightIndex = index;
							}
							if (num10 >= 1 && Vector3.Distance(zero, roadVecs[num8][roadVecs[num8].Count - 1]) < 0.5f)
							{
								roadVecs[num8].RemoveAt(roadVecs[num8].Count - 1);
							}
							roadVecs[num8].Add(zero);
							break;
						}
					}
				}
			}
			int num11 = Mathf.RoundToInt((float)roadVecs[0].Count * 0.5f);
			if (roadVecs[middleIndex].Count < num11)
			{
				int count2 = roadVecs[middleIndex].Count;
				for (int num12 = count2; num12 < num11; num12++)
				{
					if (count2 - 2 >= 0)
					{
						roadVecs[middleIndex].Insert(count2 - 1, roadVecs[middleIndex][count2 - 2]);
					}
				}
			}
			else
			{
				int num13 = num11 - 2;
				int num14 = roadVecs[middleIndex].Count - num11;
				if (num13 <= 1)
				{
					num13 = 2;
				}
				if (roadVecs[middleIndex].Count - num14 <= 3)
				{
					num14 = roadVecs[middleIndex].Count - 4;
					num13 = 2;
				}
				if (num14 > 0)
				{
					roadVecs[middleIndex].RemoveRange(num13, num14);
				}
			}
			Vector3 b2 = roadVecs[middleIndex][roadVecs[middleIndex].Count - 1];
			float num15 = roadVecs[middleIndex].Count;
			for (int num16 = 1; num16 < roadVecs[middleIndex].Count - 1; num16++)
			{
				roadVecs[middleIndex][num16] = Vector3.Lerp(roadVecs[middleIndex][0], b2, (float)num16 * 1f / num15);
			}
			priorityPointsMain = new List<Vector3>(list2);
			prioritySibling.prioritySectionStart = num2;
			prioritySibling.prioritySectionEnd = num3;
		}

		public static bool OOQQDODDOD(Vector3 v, List<Vector3> points, int firstIndex, int lastIndex)
		{
			for (int i = firstIndex; i < lastIndex; i++)
			{
				if (OQQOCDQCQD.OOCQODQDQD(points[i + 1], points[i], v))
				{
					return false;
				}
			}
			return true;
		}

		public static void ODCCQDOOQQ(List<Vector3> leftRoundingPoints, List<Vector3> rightRoundingPoints, ref List<List<Vector3>> roadVecs, List<Vector2> roadShape, int leftFixedPoint, int rightFixedPoint, int middleIndex, Vector3 cp, Vector3 cp1)
		{
			int num = 0;
			for (int i = 0; i < leftRoundingPoints.Count; i++)
			{
				Vector3 normalized;
				if (i == 0)
				{
					normalized = (rightRoundingPoints[0] - leftRoundingPoints[0]).normalized;
				}
				else if (i == leftRoundingPoints.Count - 1)
				{
					normalized = (rightRoundingPoints[rightRoundingPoints.Count - 1] - leftRoundingPoints[i]).normalized;
				}
				else
				{
					normalized = (leftRoundingPoints[i + 1] - leftRoundingPoints[i - 1]).normalized;
					normalized = new Vector3(normalized.z, 0f, 0f - normalized.x).normalized;
				}
				for (int j = 0; j <= middleIndex; j++)
				{
					if (roadVecs.Count <= j)
					{
						roadVecs.Add(new List<Vector3>());
					}
					Vector3 item = leftRoundingPoints[i] + normalized * (roadShape[j].x - roadShape[0].x);
					item.y = roadShape[j].y;
					roadVecs[j].Add(item);
				}
			}
			for (int k = 0; k < rightRoundingPoints.Count; k++)
			{
				Vector3 normalized;
				if (k == 0)
				{
					normalized = (leftRoundingPoints[0] - rightRoundingPoints[0]).normalized;
				}
				else if (k == rightRoundingPoints.Count - 1)
				{
					normalized = (leftRoundingPoints[leftRoundingPoints.Count - 1] - rightRoundingPoints[k]).normalized;
				}
				else
				{
					normalized = (rightRoundingPoints[k + 1] - rightRoundingPoints[k - 1]).normalized;
					normalized = new Vector3(0f - normalized.z, 0f, normalized.x).normalized;
				}
				float x = roadShape[roadShape.Count - 1].x;
				for (int l = middleIndex + 1; l < roadShape.Count; l++)
				{
					if (roadVecs.Count <= l)
					{
						roadVecs.Add(new List<Vector3>());
					}
					Vector3 item = rightRoundingPoints[k] + normalized * (x - roadShape[l].x);
					item.y = roadShape[l].y;
					roadVecs[l].Add(item);
				}
			}
		}

		public static void OOQDQOCQOC(List<Vector3> roundingPoints, ref List<Vector3> pointsIndents, float indent, Vector3 lp, Vector3 rp, bool leftSide)
		{
			pointsIndents.Clear();
			for (int i = 0; i < roundingPoints.Count; i++)
			{
				Vector3 vector;
				if (i == 0)
				{
					vector = (rp - lp).normalized;
				}
				else if (i == roundingPoints.Count - 1)
				{
					vector = (Vector3.zero - roundingPoints[i]).normalized;
				}
				else
				{
					vector = (roundingPoints[i + 1] - roundingPoints[i - 1]).normalized;
					vector = ((!leftSide) ? new Vector3(0f - vector.z, 0f, vector.x).normalized : new Vector3(vector.z, 0f, 0f - vector.x).normalized);
				}
				pointsIndents.Add(roundingPoints[i] + vector * indent);
			}
		}

		public static void OQCOCOCQQQ(ref List<Vector3> centerPoints, List<Vector3> leftRoundingPoints, List<Vector3> leftPointsIndents, List<Vector3> rightRoundingPoints, List<Vector3> rightPointsIndents, Vector3 cp)
		{
			List<Vector3> list = leftPointsIndents;
			List<Vector3> list2 = rightPointsIndents;
			if (rightPointsIndents.Count > list.Count)
			{
				list = rightPointsIndents;
				list2 = leftPointsIndents;
			}
			centerPoints.Add(Vector3.Lerp(leftRoundingPoints[0], rightRoundingPoints[0], 0.5f));
			float num = Vector3.Distance(cp, list[1]);
			for (int i = 1; i < list2.Count; i++)
			{
				if (Vector3.Distance(cp, list2[i]) < num)
				{
					centerPoints.Add(OQQOCDQCQD.OCOOQOQCDC(cp, Vector3.zero, list2[i]));
				}
			}
			for (int j = 1; j < list.Count; j++)
			{
				centerPoints.Add(OQQOCDQCQD.OCOOQOQCDC(cp, Vector3.zero, list[j]));
			}
		}

		public static void OQCOODQDCO(ref List<Vector3> centerPoints, List<Vector3> leftRoundingPoints, List<Vector3> leftPointsIndents, List<Vector3> rightRoundingPoints, List<Vector3> rightPointsIndents)
		{
			centerPoints.Clear();
			List<Vector3> list = leftRoundingPoints;
			List<Vector3> list2 = rightRoundingPoints;
			float num = 1f;
			if (rightRoundingPoints.Count > list.Count)
			{
				list = rightRoundingPoints;
				list2 = leftRoundingPoints;
				num = -1f;
			}
			float num2 = Vector3.Distance(leftRoundingPoints[0], rightRoundingPoints[0]) * 0.5f;
			for (int i = 1; i < list.Count - 1; i++)
			{
				Vector3 vector = list[i + 1] - list[i - 1];
				vector = new Vector3(vector.z, 0f, 0f - vector.x).normalized * num;
				centerPoints.Add(list[i + 1] + vector * num2);
			}
		}

		public static void MatchInnerOCCDOCDDCQ(ref List<Vector3> innerArray, List<Vector3> startVecs, List<Vector3> endVecs)
		{
			for (int i = 0; i < startVecs.Count && innerArray[i] != startVecs[i]; i++)
			{
				innerArray.Insert(i, startVecs[i]);
			}
			bool flag = false;
			List<Vector3> list = new List<Vector3>(endVecs);
			list.Reverse();
			for (int j = 0; j < list.Count; j++)
			{
				if (flag)
				{
					innerArray.Add(list[j]);
				}
				if (innerArray[innerArray.Count - 1] == list[j])
				{
					flag = true;
				}
			}
		}

		public static void OQCCOQOQOO(ref List<Vector3> targetArray, List<Vector3> otherArray)
		{
			List<Vector3> list = new List<Vector3>(otherArray);
			list.Reverse();
			list.RemoveAt(0);
			targetArray.AddRange(list);
		}

		public static void EROQODDCCCCD(List<List<Vector3>> roadVecs, List<float> shapeUVs, ref List<List<Vector2>> uvs, ref List<List<Color>> colors, List<Vector3> priorityPointsMain, ref List<Vector2> priorityPointsMainUVs, ref List<Color> priorityPointsMainColors, Vector2 cp, float uvRatio, ERConnectionSibling sibling, bool primarySection)
		{
			float num = 0f;
			if (primarySection)
			{
				int middleIndex = sibling.middleIndex;
				for (int i = 1; i < roadVecs[middleIndex].Count; i++)
				{
					num += Vector3.Distance(roadVecs[middleIndex][i - 1], roadVecs[middleIndex][i]);
				}
			}
			List<float> list = new List<float>();
			List<float> list2 = new List<float>();
			list.Add(0f);
			list2.Add(0f);
			Color black = Color.black;
			int count = roadVecs[0].Count;
			float num2 = count;
			float num3 = 1f - (sibling.fadeIn - 0.001f);
			List<float> list3 = new List<float>();
			float num4 = sibling.fadeIn - 0.001f;
			float num5 = 0f;
			float num6 = 0f;
			for (int j = 0; (float)j < num2; j++)
			{
				if (sibling.fadeIn != 0f)
				{
					list3.Add((1f - num4) * ((float)j * 1f / num2 * num3 / num3));
					continue;
				}
				num6 = (num2 - (float)j) * 1f / (num2 * 1f);
				if (num6 >= sibling.fadeInDistance)
				{
					num5 = (num6 - sibling.fadeInDistance) / (1f - sibling.fadeInDistance);
					num6 = Mathf.Lerp(0f, 1f, num5);
					list3.Add(num6);
				}
				else
				{
					list3.Add(0f);
				}
			}
			if (sibling.fadeIn != 0f)
			{
				list3.Reverse();
			}
			Color black2 = Color.black;
			if (sibling.buildPriority != 0 && sibling.roadType.type == ERRoadWayType.Dirt)
			{
				black2.a = sibling.fadeIn;
			}
			for (int k = 0; k < roadVecs.Count; k++)
			{
				uvs.Add(new List<Vector2>());
				colors.Add(new List<Color>());
				float num7 = 0f;
				float num8 = 1f;
				uvs[k].Add(new Vector2(shapeUVs[k], 0f));
				black.a = 1f;
				colors[k].Add(black);
				if (primarySection)
				{
					for (int l = 1; l < roadVecs[k].Count; l++)
					{
						num7 += Vector3.Distance(roadVecs[k][l - 1], roadVecs[k][l]);
					}
					num8 = num7 / num;
				}
				num7 = 0f;
				for (int m = 1; m < roadVecs[k].Count; m++)
				{
					num7 += Vector3.Distance(roadVecs[k][m - 1], roadVecs[k][m]);
					if (k == 0)
					{
						list.Add(num7);
					}
					else if (k == roadVecs.Count - 1)
					{
						list2.Add(num7);
					}
					if (primarySection)
					{
						uvs[k].Add(new Vector2(shapeUVs[k], num7 / uvRatio / num8));
						colors[k].Add(black);
						continue;
					}
					uvs[k].Add(new Vector2(shapeUVs[k], num7 / uvRatio));
					if (m < count)
					{
						black.a = sibling.fadeIn + list3[m];
					}
					else
					{
						black.a = sibling.fadeIn + list3[count - 1];
					}
					colors[k].Add(black);
				}
			}
			if (priorityPointsMain.Count <= 0)
			{
				return;
			}
			Vector3 vector = Vector3.Lerp(roadVecs[0][0], roadVecs[roadVecs.Count - 1][0], 0.5f);
			Vector3 vector2 = vector + sibling.forward * 100f;
			int num9 = -1;
			float num10 = 0f;
			float num11 = 0f;
			float num12 = 0f;
			List<float> list4 = new List<float>();
			List<float> list5 = new List<float>();
			List<float> list6 = new List<float>();
			float num13 = 0f;
			float num14 = 0f;
			list4.Add(0f);
			float num15 = 0f;
			float num16 = 0f;
			float num17 = 0f;
			for (int n = 0; n < priorityPointsMain.Count - 1; n++)
			{
				num11 = Vector3.Distance(priorityPointsMain[n], priorityPointsMain[n + 1]);
				num10 += num11;
				list4.Add(num10);
				if (num9 == -1 && OQQOCDQCQD.OOCQODQDQD(vector2, vector, priorityPointsMain[n + 1]))
				{
					Vector3 b = OQQOCDQCQD.OCDCQCDDCC(vector2, vector, priorityPointsMain[n], priorityPointsMain[n + 1], flag: false);
					num12 = num10 - Vector3.Distance(priorityPointsMain[n + 1], b);
					num9 = n + 1;
				}
			}
			bool flag = false;
			int num18 = 0;
			int num19 = 0;
			Vector3 zero = Vector3.zero;
			int index = 0;
			Vector3 vector3 = roadVecs[sibling.leftFixedIndex][roadVecs[sibling.leftFixedIndex].Count - 1];
			Vector3 pSource;
			if (roadVecs[sibling.leftFixedIndex].Count >= 2)
			{
				pSource = roadVecs[sibling.leftFixedIndex][roadVecs[sibling.leftFixedIndex].Count - 2];
			}
			else
			{
				pSource = vector3;
				vector3 = roadVecs[sibling.leftFixedIndex][0] + sibling.forward;
				Debug.Log("EasyRoads3Dv3 warning #F001: This may have unexpected connection results for the secondary road on Flex Connector: " + prefabScript.gameObject.name + ", please contact us if that is the case.");
			}
			Vector3 vector4 = roadVecs[sibling.rightFixedIndex][roadVecs[sibling.rightFixedIndex].Count - 1];
			Vector3 pSource2;
			if (roadVecs[sibling.rightFixedIndex].Count >= 2)
			{
				pSource2 = roadVecs[sibling.rightFixedIndex][roadVecs[sibling.rightFixedIndex].Count - 2];
			}
			else
			{
				pSource2 = vector4;
				vector4 = roadVecs[sibling.rightFixedIndex][0] + sibling.forward;
				Debug.Log("EasyRoads3Dv3 warning #F001: This may have unexpected connection results for the secondary road on Flex Connector: " + prefabScript.gameObject.name + ", please contact us if that is the case.");
			}
			int count2 = priorityPointsMain.Count;
			for (int num20 = 0; num20 < count2; num20++)
			{
				bool flag2 = false;
				float num21 = Vector3.Distance(roadVecs[0][roadVecs[0].Count - 1], roadVecs[sibling.leftFixedIndex][roadVecs[sibling.leftFixedIndex].Count - 1]);
				float num22 = Vector3.Distance(roadVecs[roadVecs.Count - 1][roadVecs[roadVecs.Count - 1].Count - 1], roadVecs[sibling.rightFixedIndex][roadVecs[sibling.rightFixedIndex].Count - 1]);
				if (num20 == 0)
				{
					priorityPointsMainUVs.Add(uvs[0][uvs[0].Count - 2]);
					priorityPointsMainColors.Add(black2);
					flag2 = true;
				}
				else if (!flag && num20 < num9)
				{
					if (!OQQOCDQCQD.OOCQODQDQD(vector3, pSource, priorityPointsMain[num20]))
					{
						zero = OCQODDCOCQ(priorityPointsMain[num20], roadVecs[0], ref index, 1);
						float num23 = Vector3.Distance(zero, priorityPointsMain[num20]);
						float x = Mathf.Lerp(shapeUVs[0], shapeUVs[sibling.leftFixedIndex], num23 / sibling.leftFixedDistance);
						num16 = Mathf.Lerp(uvs[0][uvs[0].Count - 2].y, uvs[sibling.leftFixedIndex][uvs[sibling.leftFixedIndex].Count - 1].y, num23 / sibling.leftFixedDistance);
						priorityPointsMainUVs.Add(new Vector2(x, num16));
						priorityPointsMainColors.Add(black2);
						flag2 = true;
					}
					else
					{
						flag = true;
						num18 = num20;
						num13 = Vector3.Distance(roadVecs[sibling.leftFixedIndex][roadVecs[sibling.leftFixedIndex].Count - 1], priorityPointsMain[num20]);
						list5.Add(num13);
						for (int num24 = num20 + 1; num24 < num9; num24++)
						{
							num13 += list4[num24] - list4[num24 - 1];
							list5.Add(num13);
						}
						num13 += Vector3.Distance(roadVecs[sibling.middleIndex][roadVecs[sibling.middleIndex].Count - 1], priorityPointsMain[num9 - 1]);
						list5.Add(num13);
						for (int num25 = 0; num25 < list5.Count; num25++)
						{
							if (num20 + num25 < num9)
							{
								num16 = Mathf.Lerp(uvs[sibling.leftFixedIndex][uvs[sibling.leftFixedIndex].Count - 1].y, uvs[sibling.middleIndex][uvs[sibling.middleIndex].Count - 1].y, list5[num25] / num13);
								Vector2 item = Vector2.Lerp(uvs[sibling.leftFixedIndex][uvs[sibling.leftFixedIndex].Count - 1], uvs[sibling.middleIndex][uvs[sibling.middleIndex].Count - 1], list5[num25] / num13);
								priorityPointsMainUVs.Add(item);
								priorityPointsMainColors.Add(black2);
							}
						}
						num20 = num9 - 1;
					}
				}
				if (num20 >= num9)
				{
					zero = OCQODDCOCQ(priorityPointsMain[num20], roadVecs[roadVecs.Count - 1], ref index, 1);
					bool flag3 = OQQOCDQCQD.OOCQODQDQD(vector4, pSource2, priorityPointsMain[num20]);
					float num26 = Vector3.Distance(zero, priorityPointsMain[num20]);
					num26 = Vector3.Distance(priorityPointsMain[num20], roadVecs[roadVecs.Count - 1][roadVecs[roadVecs.Count - 1].Count - 1]);
					float num27 = Vector3.Distance(roadVecs[sibling.rightFixedIndex][roadVecs[sibling.rightFixedIndex].Count - 1], roadVecs[roadVecs.Count - 1][roadVecs[roadVecs.Count - 1].Count - 1]);
					if (flag3 || num20 == count2 - 1)
					{
						float x2 = Mathf.Lerp(shapeUVs[shapeUVs.Count - 1], shapeUVs[sibling.rightFixedIndex], num26 / sibling.rightFixedDistance);
						List<Vector2> list7 = uvs[uvs.Count - 1];
						List<Vector2> list8 = uvs[sibling.rightFixedIndex];
						num16 = (num17 = Mathf.Lerp(list7[list7.Count - 1].y, list8[list8.Count - 1].y, num26 / sibling.rightFixedDistance));
						if (num19 == 0)
						{
							num19 = num20 - 1;
							num14 = Vector3.Distance(roadVecs[sibling.middleIndex][roadVecs[sibling.middleIndex].Count - 1], priorityPointsMain[num9]);
							list6.Add(num14);
							for (int num28 = num9 + 1; num28 <= num19; num28++)
							{
								num14 += list4[num28] - list4[num28 - 1];
								list6.Add(num14);
							}
							num14 += Vector3.Distance(roadVecs[sibling.rightFixedIndex][roadVecs[sibling.rightFixedIndex].Count - 1], priorityPointsMain[num19]);
							list6.Add(num14);
							for (int num29 = 0; num29 < list6.Count; num29++)
							{
								if (list4.Count > num9 + num29)
								{
									x2 = 0.5f + (list4[num9 + num29] - num12) / (num10 - num12) * 0.5f;
								}
								num16 = Mathf.Lerp(uvs[sibling.middleIndex][uvs[sibling.middleIndex].Count - 1].y, uvs[sibling.rightFixedIndex][uvs[sibling.rightFixedIndex].Count - 1].y, list6[num29] / num14);
								Vector2 item2 = Vector2.Lerp(uvs[sibling.middleIndex][uvs[sibling.middleIndex].Count - 1], uvs[sibling.rightFixedIndex][uvs[sibling.rightFixedIndex].Count - 1], list6[num29] / num14);
								priorityPointsMainUVs.Add(item2);
								priorityPointsMainColors.Add(black2);
							}
						}
						priorityPointsMainUVs.Add(new Vector2(x2, num17));
						priorityPointsMainColors.Add(black2);
						flag2 = true;
					}
				}
				if (!flag2)
				{
					Vector3 b2 = OQQOCDQCQD.OCOOQOQCDC(vector2, vector, priorityPointsMain[num20]);
					float num30 = Vector3.Distance(vector, b2);
					if (num20 < num9)
					{
						num16 = num30 / uvRatio;
					}
					else
					{
						List<Vector2> list9 = uvs[uvs.Count - 1];
						List<Vector2> list10 = uvs[sibling.rightFixedIndex];
						num16 = num30 / uvRatio;
						float num31 = list10[list10.Count - 1].y - num15;
						float num32 = list10[list10.Count - 1].y - num16;
						if (num16 < list10[list10.Count - 1].y && (num15 > list10[list10.Count - 1].y || num32 > num31))
						{
							zero = OCQODDCOCQ(priorityPointsMain[num20], roadVecs[0], ref index, 1);
							float num33 = Vector3.Distance(zero, priorityPointsMain[num20]);
							float num34 = Mathf.Lerp(list9[list9.Count - 1].y, list10[list10.Count - 1].y, num33 / sibling.rightFixedDistance);
							num16 = num34;
						}
					}
				}
				num15 = num16;
			}
		}

		public static void OODQDDDOQO(List<Vector3> leftRoundingPoints, List<Vector3> leftPointsIndents, List<Vector3> centerPoints, List<Vector3> rightPointsIndents, List<Vector3> rightRoundingPoints, ref List<Vector2> leftRoundingPointsUV, ref List<Vector2> leftPointsIndentsUV, ref List<Vector2> centerPointsUV, ref List<Vector2> rightPointsIndentsUV, ref List<Vector2> rightRoundingPointsUV, ref Vector2 cp, float leftIndentUVX, float rightIndentUVX)
		{
			centerPointsUV.Clear();
			leftRoundingPointsUV.Clear();
			leftPointsIndentsUV.Clear();
			rightRoundingPointsUV.Clear();
			rightPointsIndentsUV.Clear();
			float num = 0.2f;
			float num2 = 0f;
			centerPointsUV.Add(new Vector2(0.5f, 0f));
			for (int i = 1; i < centerPoints.Count; i++)
			{
				num2 += Vector3.Distance(centerPoints[i - 1], centerPoints[i]);
				centerPointsUV.Add(new Vector2(0.5f, num2 * num));
			}
			num2 += Vector3.Distance(centerPoints[centerPoints.Count - 1], Vector3.zero);
			cp = new Vector2(0.5f, num2 * num);
			num2 = 0f;
			leftRoundingPointsUV.Add(new Vector2(0f, 0f));
			leftPointsIndentsUV.Add(new Vector2(leftIndentUVX, 0f));
			for (int j = 1; j < leftRoundingPoints.Count; j++)
			{
				num2 += Vector3.Distance(leftRoundingPoints[j - 1], leftRoundingPoints[j]);
				leftRoundingPointsUV.Add(new Vector2(0f, num2 * num));
				leftPointsIndentsUV.Add(new Vector2(leftIndentUVX, num2 * num));
			}
			num2 = 0f;
			rightRoundingPointsUV.Add(new Vector2(1f, 0f));
			rightPointsIndentsUV.Add(new Vector2(rightIndentUVX, 0f));
			for (int k = 1; k < rightRoundingPoints.Count; k++)
			{
				num2 += Vector3.Distance(rightRoundingPoints[k - 1], rightRoundingPoints[k]);
				rightRoundingPointsUV.Add(new Vector2(1f, num2 * num));
				rightPointsIndentsUV.Add(new Vector2(rightIndentUVX, num2 * num));
			}
		}

		public static void OCOCQQOCDC(List<Vector3> leftRoundingPoints, List<Vector3> rightRoundingPoints, ref List<Vector2> leftRoundingPointsUV, ref List<Vector2> rightRoundingPointsUV)
		{
			leftRoundingPointsUV.Clear();
			rightRoundingPointsUV.Clear();
			float num = 0.2f;
			float num2 = 0f;
			for (int i = 1; i < leftRoundingPoints.Count; i++)
			{
				num2 += Vector3.Distance(leftRoundingPoints[i - 1], leftRoundingPoints[i]);
			}
			float num3 = 0f;
			for (int j = 1; j < rightRoundingPoints.Count; j++)
			{
				num3 += Vector3.Distance(rightRoundingPoints[j - 1], rightRoundingPoints[j]);
			}
			float num4 = (num2 + num3) * 0.5f;
			float num5 = num4 / num2;
			float num6 = num4 / num3;
			num4 = 0f;
			leftRoundingPointsUV.Add(new Vector2(0f, 0f));
			for (int k = 1; k < leftRoundingPoints.Count; k++)
			{
				num4 += Vector3.Distance(leftRoundingPoints[k - 1], leftRoundingPoints[k]);
				leftRoundingPointsUV.Add(new Vector2(0f, num4 * num5 * num));
			}
			num4 = 0f;
			rightRoundingPointsUV.Add(new Vector2(1f, 0f));
			for (int l = 1; l < rightRoundingPoints.Count; l++)
			{
				num4 += Vector3.Distance(rightRoundingPoints[l - 1], rightRoundingPoints[l]);
				rightRoundingPointsUV.Add(new Vector2(1f, num4 * num6 * num));
			}
		}

		public static void OOCCDDOOCQ(ref List<Vector3> leftRoundingPoints, ref List<Vector3> rightRoundingPoints, ref List<Vector3> centerPoints, ref Vector3 cpLeft, ref Vector3 cpRight, List<Vector3> priorityRoad, float cornerRadius, float cornerSegments, Vector3 lStart, Vector3 lEnd, Vector3 rStart, Vector3 rEnd, float leftIndent, float leftIndentUVX, float rightIndent, float rightIndentUVX)
		{
		}

		public static void OODDQDDQCQ(List<Vector3> outerPoints, Vector3 pos, ref float uvX, float indentUVX, float indentdist, int leftright)
		{
			int num = 0;
			for (int i = 0; i < outerPoints.Count - 1; i++)
			{
				Vector3 b = OQQOCDQCQD.OCOOQOQCDC(outerPoints[i], outerPoints[i + 1], pos);
				float num2 = Vector3.Distance(pos, outerPoints[i]);
				float num3 = Vector3.Distance(pos, outerPoints[i + 1]);
				float num4 = Vector3.Distance(outerPoints[i], outerPoints[i + 1]);
				if (!(num2 < num4) || !(num3 < num4))
				{
					continue;
				}
				float num5 = Vector3.Distance(pos, b);
				if (num5 < indentdist)
				{
					uvX = num5 / indentdist * indentUVX;
					if (leftright == 0)
					{
						_3ssss = 1f;
					}
					else
					{
						_4ssst = 1f;
					}
				}
				break;
			}
		}

		public static void OCDDDDQCDQ(ref List<Vector3> indentPoints, List<Vector3> outerPoints, List<Vector3> priorityConnectionPoints, int leftright)
		{
			Vector3 vector = priorityConnectionPoints[0];
			Vector3 vector2 = priorityConnectionPoints[1];
			bool flag = false;
			if (leftright == 1)
			{
				vector = priorityConnectionPoints[priorityConnectionPoints.Count - 1];
				vector2 = priorityConnectionPoints[priorityConnectionPoints.Count - 2];
				flag = true;
			}
			Vector3 normalized = (vector - vector2).normalized;
			float num = Vector3.Distance(outerPoints[0], indentPoints[0]);
			for (int i = 0; i < indentPoints.Count; i++)
			{
				if (OQQOCDQCQD.OOCQODQDQD(vector2, vector, indentPoints[i]) == flag)
				{
					Vector3 normalized2 = (outerPoints[i] - indentPoints[i]).normalized;
					float num2 = Vector3.Angle(normalized, normalized2);
					Vector3 vector3 = outerPoints[i];
					if (i != indentPoints.Count - 1)
					{
						vector3 = OQQOCDQCQD.OCDCQCDDCC(outerPoints[i], indentPoints[i], vector, vector2, flag: false);
						num = Vector3.Distance(vector3, indentPoints[i]);
					}
					num /= Mathf.Cos(num2 * (MathF.PI / 180f));
					indentPoints[i] = vector3 + -normalized * num;
				}
			}
		}

		public static void OOOOOOCDDD(ref List<Vector3> centerPoints, List<Vector3> priorityConnectionPoints)
		{
			int num = Mathf.RoundToInt((float)priorityConnectionPoints.Count * 0.5f) - 1;
			for (int i = 0; i < centerPoints.Count; i++)
			{
				for (int j = num; j < num + 2; j++)
				{
					if (centerPoints.Count > i && !OQQOCDQCQD.OOCQODQDQD(priorityConnectionPoints[j + 1], priorityConnectionPoints[j], centerPoints[i]))
					{
						centerPoints.RemoveAt(i);
						i--;
						break;
					}
				}
			}
		}

		public static void OCOCDCDDOD(List<ERConnectionSibling> priorityRoads, List<ERConnectionSibling> primaryRoads)
		{
			Mesh mesh = null;
			if (!cScr.gameObject.GetComponent<MeshRenderer>())
			{
				cScr.gameObject.AddComponent<MeshRenderer>();
			}
			if (priorityRoads[0].roadType.castShadow)
			{
				cScr.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.On;
			}
			else
			{
				cScr.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.Off;
			}
			if (!cScr.gameObject.GetComponent<MeshFilter>())
			{
				cScr.gameObject.AddComponent<MeshFilter>();
			}
			if (!cScr.gameObject.GetComponent<MeshCollider>())
			{
				cScr.gameObject.AddComponent<MeshCollider>();
			}
			if (cScr.gameObject.GetComponent<MeshFilter>().sharedMesh != null)
			{
				mesh = cScr.gameObject.GetComponent<MeshFilter>().sharedMesh;
			}
			else
			{
				mesh = new Mesh();
				cScr.gameObject.GetComponent<MeshFilter>().sharedMesh = mesh;
				cScr.gameObject.GetComponent<MeshCollider>().sharedMesh = mesh;
			}
			List<Vector3> list = new List<Vector3>();
			List<Vector2> list2 = new List<Vector2>();
			List<Vector2> list3 = new List<Vector2>();
			List<Vector2> list4 = new List<Vector2>();
			List<int> list5 = new List<int>();
			List<Vector3> list6 = new List<Vector3>();
			List<Vector2> list7 = new List<Vector2>();
			List<Vector2> list8 = new List<Vector2>();
			List<Vector2> list9 = new List<Vector2>();
			List<int> list10 = new List<int>();
			List<Color> list11 = new List<Color>();
			List<Color> list12 = new List<Color>();
			List<Vector3> vecs = new List<Vector3>();
			List<Vector2> uvs = new List<Vector2>();
			List<Vector2> uvs2 = new List<Vector2>();
			List<Vector2> uvs3 = new List<Vector2>();
			List<List<int>> tris = new List<List<int>>();
			List<Vector3> vecs2 = new List<Vector3>();
			List<Vector2> uvs4 = new List<Vector2>();
			List<Vector2> uvsTmp = new List<Vector2>();
			List<Vector2> uvsTmp2 = new List<Vector2>();
			List<int> tris2 = new List<int>();
			List<Color> colors = new List<Color>();
			List<Color> colors2 = new List<Color>();
			List<Material> mats = new List<Material>();
			bool weldVecs = false;
			bool flag = false;
			if (crossingStructure == 0)
			{
				List<int> secondPriorityInts = new List<int>();
				List<int> list13 = new List<int>();
				for (int i = 0; i < priorityRoads.Count; i++)
				{
					if (priorityRoads[i] == secondPriorityConnection)
					{
						continue;
					}
					secondPriorityInts.Clear();
					Material material = priorityRoads[i].roadType.connectionMaterial;
					if (material == null)
					{
						material = priorityRoads[i].roadType.roadMaterial;
					}
					if (priorityRoads[i] == primaryPriorityConnection)
					{
						material = priorityRoads[i].roadType.roadMaterial;
					}
					bool singleSectionFlag = false;
					if (priorityRoads[i] == primaryPriorityConnection)
					{
						singleSectionFlag = true;
					}
					if (priorityRoads[i].buildPriority == 0)
					{
						OCCCDOQCCC(ref tris2, ref vecs2, ref uvs4, priorityRoads[i].roadVecs, priorityRoads[i].roadUVs, priorityRoads[i].roadColors, priorityRoads[i].priorityPointsMain, priorityRoads[i].priorityPointsMainUVs, priorityRoads[i].priorityPointsMainColors, ref colors2, priorityRoads[i].originalShapeVecs, ref priorityRoads[i].connectionVecInts, vecs.Count, ref secondPriorityInts, singleSectionFlag, priorityRoads[i]);
					}
					else
					{
						if (!priorityRoads[i].shapeSubSegments)
						{
							ForkTriangulationDelaunay(ref tris2, ref vecs2, ref uvs4, priorityRoads[i].roadVecs, priorityRoads[i].roadUVs, priorityRoads[i].roadColors, priorityRoads[i].priorityPointsMain, priorityRoads[i].priorityPointsMainUVs, priorityRoads[i].priorityPointsMainColors, ref colors2, priorityRoads[i].originalShapeVecs, ref priorityRoads[i].connectionVecInts, vecs.Count, ref secondPriorityInts, singleSectionFlag, priorityRoads[i]);
						}
						else
						{
							ForkTriangulationDelaunay(ref tris2, ref vecs2, ref uvs4, priorityRoads[i].roadVecs, priorityRoads[i].roadUVs, priorityRoads[i].roadColors, priorityRoads[i].priorityPointsMain, priorityRoads[i].priorityPointsMainUVs, priorityRoads[i].priorityPointsMainColors, ref colors2, priorityRoads[i].originalShapeVecs, ref priorityRoads[i].connectionVecInts, vecs.Count, ref secondPriorityInts, singleSectionFlag, priorityRoads[i]);
						}
						if (priorityRoads[i].roadType.type == ERRoadWayType.Dirt && priorityRoads[i].fadeIn != 1f)
						{
							flag = true;
						}
					}
					MergeMeshDataExt(ref tris, ref vecs, ref uvs, ref uvs2, ref uvs3, ref colors, ref tris2, ref vecs2, ref uvs4, ref uvsTmp, ref uvsTmp2, ref colors2, skipMiddles: false, weldVecs, material, ref mats);
					if (priorityRoads[i] == primaryPriorityConnection)
					{
						list13 = new List<int>(secondPriorityInts);
					}
				}
				if (secondPriorityConnection != null)
				{
					list13.Reverse();
					secondPriorityConnection.connectionVecInts = list13;
				}
			}
			else if (crossingStructure != 1 && crossingStructure != 2 && crossingStructure != 3)
			{
			}
			int num = 0;
			cScr.gameObject.GetComponent<MeshRenderer>().sharedMaterials = mats.ToArray();
			if (priorityRoads[0].roadType != null)
			{
				if (cScr.gameObject.isStatic != priorityRoads[0].roadType.isStatic)
				{
					cScr.gameObject.isStatic = priorityRoads[0].roadType.isStatic;
				}
				if (cScr.gameObject.layer != priorityRoads[0].roadType.layer)
				{
					cScr.gameObject.layer = priorityRoads[0].roadType.layer;
				}
				if (cScr.gameObject.tag != priorityRoads[0].roadType.tag && priorityRoads[0].roadType.tag != null && priorityRoads[0].roadType.tag != "")
				{
					cScr.gameObject.tag = priorityRoads[0].roadType.tag;
				}
			}
			mesh.Clear();
			mesh.vertices = vecs.ToArray();
			mesh.uv = uvs.ToArray();
			if (flag)
			{
				mesh.colors = colors.ToArray();
			}
			else
			{
				mesh.colors = null;
			}
			mesh.subMeshCount = tris.Count;
			for (int j = 0; j < tris.Count; j++)
			{
				mesh.SetTriangles(tris[j].ToArray(), j);
			}
			mesh.tangents = new Vector4[vecs.Count];
			mesh.RecalculateNormals();
			int count = primaryRoads[0].normalIndexes.Count;
			bool flag2 = true;
			for (int k = 0; k < primaryRoads.Count - 1; k++)
			{
				if (primaryRoads[k].roadType.id != primaryRoads[k + 1].roadType.id)
				{
					flag2 = false;
					break;
				}
			}
			if (flag2 && primaryPriorityConnection == null && count > 0)
			{
				int num2 = Mathf.RoundToInt(Mathf.Floor((float)count * 0.5f));
				bool flag3 = false;
				if ((float)num2 != (float)count * 0.5f)
				{
					flag3 = true;
				}
				Vector3[] normals = mesh.normals;
				for (int l = 0; l < primaryRoads.Count; l++)
				{
					for (int m = 0; m < num2; m++)
					{
						int num3 = primaryRoads[l].normalIndexes[m];
						int num4 = ((l >= primaryRoads.Count - 1) ? primaryRoads[0].normalIndexes[count - 1 - m] : primaryRoads[l + 1].normalIndexes[count - 1 - m]);
						normals[num3] = (normals[num4] = Vector3.Lerp(normals[num3], normals[num4], 0.5f));
					}
					if (flag3)
					{
						int num3 = primaryRoads[l].normalIndexes[num2 + 1];
						int num4 = ((l >= primaryRoads.Count - 1) ? primaryRoads[0].normalIndexes[num2 + 1] : primaryRoads[l + 1].normalIndexes[num2 + 1]);
						normals[num3] = (normals[num4] = Vector3.Lerp(normals[num3], normals[num4], 0.5f));
					}
				}
				mesh.normals = normals;
			}
			mesh.RecalculateBounds();
			mesh.RecalculateTangents();
			cScr.gameObject.GetComponent<MeshFilter>().sharedMesh = mesh;
			if (prefabScript.priorityRoads.Count == 0)
			{
				for (int n = 0; n < priorityRoads.Count; n++)
				{
					if (priorityRoads[n].mainConnectionDecal != null)
					{
						if (priorityRoads[n].mainConnectionDecal.transform.childCount > 0)
						{
							UnityEngine.Object.DestroyImmediate(priorityRoads[n].mainConnectionDecal);
						}
						else if ((bool)priorityRoads[n].mainConnectionDecal.GetComponent<MeshFilter>() && (bool)priorityRoads[n].mainConnectionDecal.GetComponent<MeshFilter>().sharedMesh)
						{
							priorityRoads[n].mainConnectionDecal.GetComponent<MeshFilter>().sharedMesh.Clear();
						}
					}
				}
			}
			prefabScript.priorityRoads = new List<ERConnectionSibling>(priorityRoads);
		}

		public static void OCQODDCDQC(Transform tr, ERConnectionSibling sibling, int index)
		{
			ERDecal eRDecal = null;
			if (sibling.roadType != null)
			{
				eRDecal = ERDecal.OOCQOOODDC(sibling.mainRoadConnectionEdgeDecal, sibling.roadType.decalPresets);
			}
			if (!(eRDecal != null))
			{
				return;
			}
			List<Vector3> projectorsPositions = new List<Vector3>();
			List<Vector3> startVecs = new List<Vector3>();
			List<Vector3> endVecs = new List<Vector3>();
			if (!eRDecal.projector)
			{
				ODDOQDDQCQ.OCDDOCCOOC(tr, sibling.mainConnectionDecalVecs, eRDecal.xOffset, eRDecal.startOffset, eRDecal.endOffset, eRDecal.distances, 5f, sibling.mainConnectionDecalEndDir, sibling.dir, ref projectorsPositions, ref startVecs, ref endVecs, eRDecal.length, sibling.rightRoundingPoints[0], sibling.uvRatio, eRDecal.startEndSections, eRDecal.interpolatedStartEndSections);
				OQQOCDQCQD.OQCDCDDDDO(tr, ref sibling.mainConnectionDecal, "Main Connection Decal", projectorsPositions, startVecs, endVecs, eRDecal.material, eRDecal.xOffset, eRDecal.startOffset, eRDecal.endOffset, eRDecal.heightOffset, eRDecal.length, eRDecal.width, eRDecal.uvLeftTop, eRDecal.uvRightBottom, sibling.uvRatio, eRDecal);
				return;
			}
			ODDOQDDQCQ.OCQQDCCCQC(tr, sibling.mainConnectionDecalVecs, eRDecal.xOffset, eRDecal.startOffset, eRDecal.endOffset, eRDecal.distances, 5f, sibling.mainConnectionDecalEndDir, sibling.dir, ref projectorsPositions, ref startVecs, ref endVecs, eRDecal.length, eRDecal.overlap, sibling.rightRoundingPoints[0], sibling.uvRatio, eRDecal.startEndSections, eRDecal.interpolatedStartEndSections);
			if (sibling.mainConnectionDecal != null)
			{
				UnityEngine.Object.DestroyImmediate(sibling.mainConnectionDecal);
			}
			sibling.mainConnectionDecal = new GameObject(eRDecal.name);
			sibling.mainConnectionDecal.transform.position = tr.position;
			sibling.mainConnectionDecal.transform.parent = tr;
			Vector3 vector = tr.TransformPoint(sibling.leftRoundingPoints[0]);
			Vector3 vector2 = tr.TransformPoint(sibling.rightRoundingPoints[0]);
			Vector3 normalized = (vector - vector2).normalized;
			Vector3 normalized2 = new Vector3(normalized.x, 0f, normalized.z).normalized;
			float num = Vector3.Angle(normalized, normalized2);
			if (num > 1f && vector2.y < vector.y)
			{
				num *= -1f;
			}
			OQQOCDQCQD.OQQDCDCDOQ(sibling.mainConnectionDecal.transform, projectorsPositions, eRDecal, num);
		}

		public static void OCQCCQQCDD(ref List<int> tris, ref List<Vector3> vecs, ref List<Vector2> uvs, List<List<Vector3>> vecsData, List<List<Vector2>> uvsData, List<List<Color>> colorsData, List<Vector3> priorityPointsMain, List<Vector2> priorityPointsMainUVs, List<Color> priorityPointsMainColors, ref List<Color> colors, List<bool> originalShapeVecs, ref List<int> connInts, int totalVecs, ref List<int> secondPriorityInts, bool singleSectionFlag, ERConnectionSibling sibling)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			int num6 = 0;
			int index = 0;
			int num7 = 0;
			float num8 = 0f;
			float num9 = 0f;
			int num10 = -1;
			int count = vecsData.Count;
			num = 0;
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			int item = 0;
			int num11 = 0;
			connInts.Add(totalVecs + vecs.Count);
			List<int> list3 = new List<int>();
			vecs.AddRange(vecsData[0]);
			uvs.AddRange(uvsData[0]);
			colors.AddRange(colorsData[0]);
			num11 = totalVecs + vecs.Count - 1;
			if (singleSectionFlag)
			{
				secondPriorityInts.Add(totalVecs + vecs.Count - 1);
			}
			sibling.normalIndexes.Add(totalVecs + vecs.Count - 1);
			num4 = vecs.Count - 1;
			int leftFixedIndex = sibling.leftFixedIndex;
			int rightFixedIndex = sibling.rightFixedIndex;
			for (int i = 1; i < count; i++)
			{
				num = num2;
				num3 = num4;
				if (i == leftFixedIndex + 1 && sibling.buildPriority != 0)
				{
					num3--;
					index = num3 + 1;
					list3.Add(num3);
				}
				num2 = vecs.Count;
				if (originalShapeVecs[i])
				{
					connInts.Add(totalVecs + vecs.Count);
					if (singleSectionFlag)
					{
						secondPriorityInts.Add(totalVecs + vecs.Count + vecsData[i].Count - 1);
					}
				}
				if (!originalShapeVecs[i])
				{
					if (list.Count == 0)
					{
						list.Add(item);
						list2.Add(num11);
					}
					list.Add(totalVecs + vecs.Count);
					int num12 = vecsData[i].Count;
					if (singleSectionFlag)
					{
						num12--;
					}
					else if (sibling.buildPriority != 0 && i > leftFixedIndex && i < rightFixedIndex)
					{
						num12--;
					}
					for (int j = 1; j < num12; j++)
					{
						vecs.Add(vecsData[i][j]);
						uvs.Add(uvsData[i][j]);
						colors.Add(colorsData[i][j]);
					}
					if (sibling.buildPriority != 0 && i > leftFixedIndex && i < rightFixedIndex)
					{
						list3.Add(vecs.Count - 1);
					}
					list2.Add(totalVecs + vecs.Count - 1);
				}
				else
				{
					item = vecs.Count;
					if (sibling.buildPriority == 0 || i <= leftFixedIndex + 1 || i >= rightFixedIndex)
					{
						vecs.AddRange(vecsData[i]);
						uvs.AddRange(uvsData[i]);
						colors.AddRange(colorsData[i]);
					}
					else
					{
						int num13 = vecsData[i].Count - 1;
						for (int k = 0; k < num13; k++)
						{
							vecs.Add(vecsData[i][k]);
							uvs.Add(uvsData[i][k]);
							colors.Add(colorsData[i][k]);
						}
						if (sibling.buildPriority != 0 && i > leftFixedIndex && i < rightFixedIndex)
						{
							list3.Add(vecs.Count - 1);
						}
					}
					num11 = totalVecs + vecs.Count - 1;
				}
				sibling.normalIndexes.Add(totalVecs + vecs.Count - 1);
				num4 = vecs.Count - 1;
				int num14 = num4;
				if (i == rightFixedIndex && sibling.buildPriority != 0)
				{
					num14--;
					list3.Add(num14);
					num7 = num4;
				}
				num5 = num;
				num6 = num2;
				num10 = -1;
				int num15 = 0;
				if (sibling.buildPriority != 0)
				{
				}
				int _2ssss = 0;
				int num16 = 0;
				xssss(num5, num3, num6, num14, vecs, ref tris, sibling, 0, 0, ref _2ssss, ref num16);
				if (originalShapeVecs[i] && list.Count > 0)
				{
					list.Add(num2);
					list2.Add(num4);
					if (list.Count >= 3)
					{
						tris.Add(list[0]);
						tris.Add(list[1]);
						tris.Add(list[2]);
					}
					if (list.Count == 4)
					{
						tris.Add(list[0]);
						tris.Add(list[2]);
						tris.Add(list[3]);
					}
					else if (list.Count > 4)
					{
						tris.Add(list[2]);
						tris.Add(list[3]);
						tris.Add(list[4]);
						tris.Add(list[0]);
						tris.Add(list[2]);
						tris.Add(list[4]);
					}
					list.Clear();
					if (singleSectionFlag)
					{
						if (list2.Count >= 3)
						{
							tris.Add(list2[0]);
							tris.Add(list2[2]);
							tris.Add(list2[1]);
						}
						if (list2.Count == 4)
						{
							tris.Add(list2[0]);
							tris.Add(list2[3]);
							tris.Add(list2[2]);
						}
						else if (list2.Count > 4)
						{
							tris.Add(list2[2]);
							tris.Add(list2[4]);
							tris.Add(list2[3]);
							tris.Add(list2[0]);
							tris.Add(list2[4]);
							tris.Add(list2[2]);
						}
					}
					list2.Clear();
				}
				if (!sibling.hardEdge[i])
				{
					continue;
				}
				if (!originalShapeVecs[i])
				{
					for (int l = 1; l < vecsData[i].Count; l++)
					{
						vecs.Add(vecsData[i][l]);
						uvs.Add(uvsData[i][l]);
						colors.Add(colorsData[i][l]);
					}
					num2 += vecsData[i].Count - 1;
					num4 += vecsData[i].Count - 1;
				}
				else
				{
					vecs.AddRange(vecsData[i]);
					uvs.AddRange(uvsData[i]);
					colors.AddRange(colorsData[i]);
					num2 += vecsData[i].Count;
					num4 += vecsData[i].Count;
				}
				sibling.normalIndexes.Add(totalVecs + vecs.Count - 1);
			}
			if (sibling.buildPriority == 0)
			{
				return;
			}
			num5 = vecs.Count - 1;
			List<Vector3> list4 = new List<Vector3>();
			List<Vector2> list5 = new List<Vector2>();
			List<Color> list6 = new List<Color>();
			list4.Add(vecs[index]);
			list5.Add(uvs[index]);
			list6.Add(colors[index]);
			float num17 = Vector3.Distance(vecs[index], priorityPointsMain[0]);
			float num18 = 0f;
			int num19 = 0;
			for (int m = 1; m < priorityPointsMain.Count; m++)
			{
				num18 = Vector3.Distance(priorityPointsMain[m], priorityPointsMain[0]);
				if (num18 > num17)
				{
					num19 = m;
					break;
				}
			}
			int num20 = priorityPointsMain.Count - 1;
			num17 = Vector3.Distance(vecs[num7], priorityPointsMain[num20]);
			num18 = 0f;
			int num21 = 0;
			for (int num22 = num20 - 1; num22 > 0; num22--)
			{
				num18 = Vector3.Distance(priorityPointsMain[num22], priorityPointsMain[num20]);
				if (num18 > num17)
				{
					num21 = num22;
					break;
				}
			}
			int num23 = leftFixedIndex + 1;
			Vector3 a = list4[0];
			num18 = Vector3.Distance(a, vecsData[num23][vecsData[num23].Count - 1]);
			bool flag = false;
			for (int n = num19; n <= num21; n++)
			{
				num17 = Vector3.Distance(a, priorityPointsMain[n]);
				if (num17 < num18 || flag)
				{
					list4.Add(priorityPointsMain[n]);
					list5.Add(priorityPointsMainUVs[n]);
					list6.Add(priorityPointsMainColors[n]);
					a = list4[list4.Count - 1];
					num18 = Vector3.Distance(a, vecsData[num23][vecsData[num23].Count - 1]);
					continue;
				}
				list4.Add(vecsData[num23][vecsData[num23].Count - 1]);
				list5.Add(uvsData[num23][uvsData[num23].Count - 1]);
				list6.Add(colorsData[num23][colorsData[num23].Count - 1]);
				num23++;
				a = list4[list4.Count - 1];
				if (vecsData.Count > num23)
				{
					num18 = Vector3.Distance(a, vecsData[num23][vecsData[num23].Count - 1]);
				}
				else
				{
					flag = true;
				}
				n--;
			}
			list4.Add(vecs[num7]);
			list5.Add(uvs[num7]);
			list6.Add(colors[num7]);
			vecs.AddRange(list4);
			uvs.AddRange(list5);
			colors.AddRange(list6);
			num3 = vecs.Count - 1;
			for (int num24 = 0; num24 < list3.Count; num24++)
			{
			}
			yssst(num5, num3, index, num7, list3, vecs, ref tris, sibling);
		}

		public static void OCCCDOQCCC(ref List<int> tris, ref List<Vector3> vecs, ref List<Vector2> uvs, List<List<Vector3>> vecsData, List<List<Vector2>> uvsData, List<List<Color>> colorsData, List<Vector3> priorityPointsMain, List<Vector2> priorityPointsMainUVs, List<Color> priorityPointsMainColors, ref List<Color> colors, List<bool> originalShapeVecs, ref List<int> connInts, int totalVecs, ref List<int> secondPriorityInts, bool singleSectionFlag, ERConnectionSibling sibling)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			int num6 = 0;
			float num7 = 0f;
			float num8 = 0f;
			int num9 = -1;
			int count = vecsData.Count;
			num = 0;
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			int item = 0;
			int num10 = 0;
			connInts.Add(totalVecs + vecs.Count);
			List<int> list3 = new List<int>();
			vecs.AddRange(vecsData[0]);
			uvs.AddRange(uvsData[0]);
			colors.AddRange(colorsData[0]);
			num10 = vecs.Count - 1;
			list3.Add(vecs.Count - 1);
			if (singleSectionFlag)
			{
				secondPriorityInts.Add(totalVecs + vecs.Count - 1);
			}
			sibling.normalIndexes.Add(totalVecs + vecs.Count - 1);
			num4 = vecs.Count - 1;
			int _2ssss = 0;
			int num11 = 0;
			for (int i = 1; i < count; i++)
			{
				num = num2;
				num3 = num4;
				num2 = vecs.Count;
				if (originalShapeVecs[i])
				{
					connInts.Add(totalVecs + vecs.Count);
					if (singleSectionFlag)
					{
						secondPriorityInts.Add(totalVecs + vecs.Count + vecsData[i].Count - 1);
					}
				}
				if (!originalShapeVecs[i])
				{
					if (list.Count == 0)
					{
						list.Add(item);
						list2.Add(num10);
					}
					list.Add(vecs.Count);
					int num12 = vecsData[i].Count;
					if (singleSectionFlag)
					{
						num12--;
					}
					for (int j = 1; j < num12; j++)
					{
						vecs.Add(vecsData[i][j]);
						uvs.Add(uvsData[i][j]);
						colors.Add(colorsData[i][j]);
					}
					list2.Add(vecs.Count - 1);
				}
				else
				{
					item = vecs.Count;
					vecs.AddRange(vecsData[i]);
					uvs.AddRange(uvsData[i]);
					colors.AddRange(colorsData[i]);
					num10 = vecs.Count - 1;
				}
				list3.Add(vecs.Count - 1);
				sibling.normalIndexes.Add(totalVecs + vecs.Count - 1);
				num4 = vecs.Count - 1;
				num5 = num;
				num6 = num2;
				num9 = -1;
				int num13 = 0;
				if (sibling.buildPriority != 0)
				{
				}
				xssss(num5, num3, num6, num4, vecs, ref tris, sibling, 0, 0, ref _2ssss, ref num11);
				if (originalShapeVecs[i] && list.Count > 0)
				{
					list.Add(num2);
					list2.Add(vecs.Count - 1);
					if (list.Count >= 3)
					{
						tris.Add(list[0]);
						tris.Add(list[1]);
						tris.Add(list[2]);
					}
					if (list.Count == 4)
					{
						tris.Add(list[0]);
						tris.Add(list[2]);
						tris.Add(list[3]);
					}
					else if (list.Count > 4)
					{
						tris.Add(list[2]);
						tris.Add(list[3]);
						tris.Add(list[4]);
						tris.Add(list[0]);
						tris.Add(list[2]);
						tris.Add(list[4]);
					}
					list.Clear();
					if (singleSectionFlag)
					{
						if (list2.Count >= 3)
						{
							tris.Add(list2[0]);
							tris.Add(list2[2]);
							tris.Add(list2[1]);
						}
						if (list2.Count == 4)
						{
							tris.Add(list2[0]);
							tris.Add(list2[3]);
							tris.Add(list2[2]);
						}
						else if (list2.Count > 4)
						{
							tris.Add(list2[2]);
							tris.Add(list2[4]);
							tris.Add(list2[3]);
							tris.Add(list2[0]);
							tris.Add(list2[4]);
							tris.Add(list2[2]);
						}
					}
					list2.Clear();
				}
				if (!sibling.hardEdge[i])
				{
					continue;
				}
				item = vecs.Count;
				if (!originalShapeVecs[i])
				{
					for (int k = 1; k < vecsData[i].Count; k++)
					{
						vecs.Add(vecsData[i][k]);
						uvs.Add(uvsData[i][k]);
						colors.Add(colorsData[i][k]);
					}
					num2 += vecsData[i].Count - 1;
					num4 += vecsData[i].Count - 1;
				}
				else
				{
					vecs.AddRange(vecsData[i]);
					uvs.AddRange(uvsData[i]);
					colors.AddRange(colorsData[i]);
					num2 += vecsData[i].Count;
					num4 += vecsData[i].Count;
				}
				num10 = totalVecs + vecs.Count - 1;
				sibling.normalIndexes.Add(totalVecs + vecs.Count - 1);
			}
			if (sibling.buildPriority != 0)
			{
				num5 = vecs.Count - 1;
				vecs.AddRange(priorityPointsMain);
				uvs.AddRange(priorityPointsMainUVs);
				colors.AddRange(priorityPointsMainColors);
				num3 = vecs.Count - 1;
				yssst(num5, num3, num6, num4, list3, vecs, ref tris, sibling);
			}
		}

		public static void ForkTriangulationDelaunay(ref List<int> tris, ref List<Vector3> vecs, ref List<Vector2> uvs, List<List<Vector3>> vecsData, List<List<Vector2>> uvsData, List<List<Color>> colorsData, List<Vector3> priorityPointsMain, List<Vector2> priorityPointsMainUVs, List<Color> priorityPointsMainColors, ref List<Color> colors, List<bool> originalShapeVecs, ref List<int> connInts, int totalVecs, ref List<int> secondPriorityInts, bool singleSectionFlag, ERConnectionSibling sibling)
		{
			List<Vector3> list = new List<Vector3>();
			List<Vector3> list2 = new List<Vector3>();
			List<Vector2> list3 = new List<Vector2>();
			List<Color> list4 = new List<Color>();
			List<Vector3> list5 = new List<Vector3>();
			List<ERCell> list6 = new List<ERCell>();
			List<int> list7 = new List<int>();
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			int num6 = 0;
			float num7 = 0f;
			float num8 = 0f;
			int num9 = -1;
			int count = vecsData.Count;
			num = 0;
			List<int> list8 = new List<int>();
			List<int> list9 = new List<int>();
			int item = 0;
			int num10 = 0;
			connInts.Add(totalVecs + vecs.Count);
			List<int> list10 = new List<int>();
			vecs.AddRange(vecsData[0]);
			uvs.AddRange(uvsData[0]);
			colors.AddRange(colorsData[0]);
			num10 = vecs.Count - 1;
			list10.Add(vecs.Count - 1);
			if (singleSectionFlag)
			{
				secondPriorityInts.Add(totalVecs + vecs.Count - 1);
			}
			sibling.normalIndexes.Add(totalVecs + vecs.Count - 1);
			num4 = vecs.Count - 1;
			List<int> list11 = new List<int>();
			List<Vector3> list12 = new List<Vector3>();
			List<Vector3> list13 = new List<Vector3>();
			int num11 = 0;
			int num12 = 0;
			int num13 = 0;
			int num14 = 0;
			if (sibling.buildPriority != 0)
			{
				if (sibling.defaultSegments >= 25)
				{
					num13 = 3;
				}
				else if (sibling.defaultSegments >= 19)
				{
					num13 = 2;
				}
				else if (sibling.defaultSegments >= 16)
				{
					num13 = 1;
				}
			}
			if (sibling.buildPriority != 0 && sibling.priorityPointsMainLeftIndex != -1 && sibling.priorityPointsMainRightIndex != -1)
			{
				Vector3 a = vecsData[sibling.middleIndex][vecsData[sibling.middleIndex].Count - 1];
				float num15 = 0f;
				float num16 = 0f;
				if (sibling.leftFixedIndex > 0)
				{
					num15 = Vector3.Distance(a, vecsData[sibling.leftFixedIndex][vecsData[sibling.leftFixedIndex].Count - 1]);
					num16 = Vector3.Distance(a, vecsData[sibling.rightFixedIndex][vecsData[sibling.rightFixedIndex].Count - 1]);
				}
				else
				{
					num15 = Vector3.Distance(a, vecsData[0][vecsData[0].Count - 1]);
					num16 = Vector3.Distance(a, vecsData[vecsData.Count - 1][vecsData[vecsData.Count - 1].Count - 1]);
				}
				int count2 = priorityPointsMain.Count;
				for (int i = 0; i < count2; i++)
				{
					if (Vector3.Distance(a, priorityPointsMain[i]) < num15)
					{
						num11 = i;
						break;
					}
				}
				count2--;
				for (int num17 = count2; num17 > 0; num17--)
				{
					if (Vector3.Distance(a, priorityPointsMain[num17]) < num16)
					{
						num12 = num17;
						break;
					}
				}
			}
			int num18 = 1;
			int num19 = vecsData[sibling.middleIndex].Count - 1;
			int num20 = num19 - 1;
			while (num20 > 1 && !((double)Vector3.Distance(vecsData[sibling.middleIndex][num19], vecsData[sibling.middleIndex][num20]) > 1.5))
			{
				num18++;
				num20--;
			}
			int num21 = Mathf.RoundToInt(Mathf.Floor((float)sibling.defaultSegments * 0.5f));
			int _2ssss = 0;
			int num22 = 0;
			for (int j = 1; j < count; j++)
			{
				num = num2;
				num3 = num4;
				num14 = 0;
				num2 = vecs.Count;
				if (originalShapeVecs[j])
				{
					connInts.Add(totalVecs + vecs.Count);
					if (singleSectionFlag)
					{
						secondPriorityInts.Add(totalVecs + vecs.Count + vecsData[j].Count - 1);
					}
				}
				if (!originalShapeVecs[j])
				{
					if (list8.Count == 0)
					{
						list8.Add(item);
						list9.Add(num10);
					}
					list8.Add(vecs.Count);
					int num23 = vecsData[j].Count;
					if (singleSectionFlag)
					{
						num23--;
					}
					for (int k = 1; k < num23; k++)
					{
						vecs.Add(vecsData[j][k]);
						uvs.Add(uvsData[j][k]);
						colors.Add(colorsData[j][k]);
					}
					list9.Add(vecs.Count - 1);
				}
				else
				{
					item = vecs.Count;
					vecs.AddRange(vecsData[j]);
					uvs.AddRange(uvsData[j]);
					colors.AddRange(colorsData[j]);
					num10 = vecs.Count - 1;
				}
				list10.Add(vecs.Count - 1);
				sibling.normalIndexes.Add(totalVecs + vecs.Count - 1);
				num4 = vecs.Count - 1;
				num5 = num;
				num6 = num2;
				num9 = -1;
				int num24 = 0;
				if (sibling.buildPriority != 0)
				{
				}
				if (j <= sibling.leftFixedIndex || j > sibling.rightFixedIndex)
				{
					xssss(num5, num3, num6, num4, vecs, ref tris, sibling, 0, 0, ref _2ssss, ref num22);
				}
				else
				{
					int _0ssss = 0;
					int num25 = 0;
					if (j == sibling.middleIndex)
					{
						_0ssss = num21;
					}
					if (j == sibling.rightFixedIndex)
					{
						num25 = num21 - num18;
						_0ssss = num18;
					}
					int ussss = num3 - num18;
					if (j == sibling.middleIndex + 1)
					{
						_0ssss = 1;
						num14 = num13;
					}
					xssss(num5, ussss, num6, num4 - num18 + num14, vecs, ref tris, sibling, _0ssss, num25, ref _2ssss, ref num22);
					if (j == sibling.leftFixedIndex + 1)
					{
						int num26 = vecsData[j - 1].Count - num18;
						int num27 = 0;
						int num28 = _2ssss;
						if (!vecsData[sibling.leftFixedIndex].Contains(vecs[_2ssss]))
						{
							num28++;
						}
						for (int l = num28; l <= num3; l++)
						{
							list12.Add(vecs[l]);
							list13.Add(vecs[l]);
							list11.Add(num28 + num27);
							num27++;
						}
						if (num11 != 0 && num12 != 0)
						{
							list13.AddRange(priorityPointsMain.GetRange(num11, num12 - num11));
						}
						else
						{
							list13.AddRange(priorityPointsMain.GetRange(1, priorityPointsMain.Count - 2));
						}
					}
					if (j == sibling.rightFixedIndex)
					{
						int num29 = vecsData[j].Count - num18 - 1;
						int num30 = num4 - num18;
						if (num21 > num18)
						{
							num29 = vecsData[j].Count - num21 - 1;
							num30 = num4 - num21;
						}
						int num31 = 0;
						if (num29 < 0)
						{
							num29 = 0;
						}
						int count3 = list13.Count;
						for (int m = num29; m < vecsData[j].Count; m++)
						{
							list12.Add(vecsData[j][m]);
							list13.Insert(count3, vecsData[j][m]);
							list11.Add(num30 + num31);
							num31++;
						}
					}
					else
					{
						int num32 = vecsData[j].Count - 1 - num18;
						if (num32 < 0)
						{
							num32 = 0;
						}
						Vector3 vector = vecsData[j][num32];
						list12.Add(vector);
						list13.Insert(0, vector);
						if (vecs[num4 - num18] == vector)
						{
							list11.Add(num4 - num18);
						}
						else
						{
							list11.Add(num4 - num18 + 1);
						}
						list12.Add(vecs[num4]);
						list11.Add(num4);
					}
				}
				if (originalShapeVecs[j] && list8.Count > 0)
				{
					list8.Add(num2);
					list9.Add(vecs.Count - 1);
					if (list8.Count >= 3)
					{
						tris.Add(list8[0]);
						tris.Add(list8[1]);
						tris.Add(list8[2]);
					}
					if (list8.Count == 4)
					{
						tris.Add(list8[0]);
						tris.Add(list8[2]);
						tris.Add(list8[3]);
					}
					else if (list8.Count > 4)
					{
						tris.Add(list8[2]);
						tris.Add(list8[3]);
						tris.Add(list8[4]);
						tris.Add(list8[0]);
						tris.Add(list8[2]);
						tris.Add(list8[4]);
					}
					list8.Clear();
					if (singleSectionFlag)
					{
						if (list9.Count >= 3)
						{
							tris.Add(list9[0]);
							tris.Add(list9[2]);
							tris.Add(list9[1]);
						}
						if (list9.Count == 4)
						{
							tris.Add(list9[0]);
							tris.Add(list9[3]);
							tris.Add(list9[2]);
						}
						else if (list9.Count > 4)
						{
							tris.Add(list9[2]);
							tris.Add(list9[4]);
							tris.Add(list9[3]);
							tris.Add(list9[0]);
							tris.Add(list9[4]);
							tris.Add(list9[2]);
						}
					}
					list9.Clear();
				}
				if (!sibling.hardEdge[j])
				{
					continue;
				}
				item = vecs.Count;
				if (!originalShapeVecs[j])
				{
					for (int n = 1; n < vecsData[j].Count; n++)
					{
						vecs.Add(vecsData[j][n]);
						uvs.Add(uvsData[j][n]);
						colors.Add(colorsData[j][n]);
					}
					num2 += vecsData[j].Count - 1;
					num4 += vecsData[j].Count - 1;
				}
				else
				{
					vecs.AddRange(vecsData[j]);
					uvs.AddRange(uvsData[j]);
					colors.AddRange(colorsData[j]);
					num2 += vecsData[j].Count;
					num4 += vecsData[j].Count;
				}
				num10 = totalVecs + vecs.Count - 1;
				sibling.normalIndexes.Add(totalVecs + vecs.Count - 1);
			}
			prefabScript.debugVecs1.Clear();
			prefabScript.debugVecs1.AddRange(list12);
			if (sibling.buildPriority != 0)
			{
				num5 = vecs.Count - 1;
				int num33 = 0;
				int count4 = vecs.Count;
				if (num11 != 0 && num12 != 0)
				{
					num33 = num12 - num11 + 1;
					vecs.AddRange(priorityPointsMain.GetRange(num11, num33));
					uvs.AddRange(priorityPointsMainUVs.GetRange(num11, num33));
					colors.AddRange(priorityPointsMainColors.GetRange(num11, num33));
					list12.AddRange(priorityPointsMain.GetRange(num11, num33));
				}
				else
				{
					int num34 = priorityPointsMainUVs.Count - 2;
					vecs.AddRange(priorityPointsMain.GetRange(1, priorityPointsMain.Count - 2));
					uvs.AddRange(priorityPointsMainUVs.GetRange(1, priorityPointsMainUVs.Count - 2));
					colors.AddRange(priorityPointsMainColors.GetRange(1, priorityPointsMainColors.Count - 2));
					list12.AddRange(priorityPointsMain.GetRange(1, priorityPointsMain.Count - 2));
					num33 = priorityPointsMain.Count - 2;
				}
				for (int num35 = 0; num35 < num33; num35++)
				{
					list11.Add(count4 + num35);
				}
				list13.Add(list13[0]);
				num3 = vecs.Count - 1;
				tris.AddRange(OOQOQOCODD(list12, list13, list11));
			}
		}

		private static void xssss(int tssss, int ussss, int vssss, int wssss, List<Vector3> xssss, ref List<int> yssss, ERConnectionSibling Assss, int _0ssss, int _1ssss, ref int _2ssss, ref int _3ssss)
		{
			float num = 0f;
			float num2 = 0f;
			int num3 = -1;
			int num4 = 0;
			while (tssss < ussss || vssss < wssss)
			{
				if (vssss > wssss)
				{
					vssss = wssss;
				}
				if (tssss > ussss)
				{
					tssss = ussss;
				}
				num2 = ((vssss >= wssss) ? 0f : Vector3.Distance(xssss[tssss], xssss[vssss + 1]));
				num = ((tssss >= ussss) ? 0f : Vector3.Distance(xssss[tssss + 1], xssss[vssss]));
				if ((num < num2 && tssss < ussss && tssss <= ussss - _0ssss) || vssss == wssss - _1ssss)
				{
					if (tssss <= ussss - _0ssss)
					{
						yssss.Add(tssss);
						yssss.Add(tssss + 1);
						yssss.Add(vssss);
						tssss++;
						_2ssss = tssss;
					}
					num3 = 1;
				}
				else if (vssss + 1 <= wssss - _1ssss)
				{
					yssss.Add(tssss);
					yssss.Add(vssss + 1);
					yssss.Add(vssss);
					_3ssss = vssss;
					vssss++;
					num3 = 0;
				}
				else if (_3ssss != vssss)
				{
				}
				if (Assss.buildPriority != 0)
				{
				}
				num4++;
				if (num4 > 100)
				{
					break;
				}
			}
		}

		private static void yssst(int tssss, int ussss, int vssss, int wssss, List<int> xssss, List<Vector3> yssss, ref List<int> Assss, ERConnectionSibling _0ssss)
		{
			float num = 0f;
			float num2 = 0f;
			int num3 = -1;
			int num4 = 0;
			vssss = 0;
			wssss = xssss.Count - 1;
			tssss++;
			while (tssss < ussss || vssss < wssss)
			{
				num2 = ((vssss >= wssss) ? 0f : Vector3.Distance(yssss[tssss], yssss[xssss[vssss + 1]]));
				num = ((tssss >= ussss) ? 0f : Vector3.Distance(yssss[tssss + 1], yssss[xssss[vssss]]));
				if ((num < num2 && tssss < ussss) || vssss == wssss)
				{
					Assss.Add(tssss);
					Assss.Add(tssss + 1);
					Assss.Add(xssss[vssss]);
					tssss++;
					num3 = 1;
				}
				else
				{
					Assss.Add(tssss);
					Assss.Add(xssss[vssss + 1]);
					Assss.Add(xssss[vssss]);
					vssss++;
					num3 = 0;
				}
				if (_0ssss == null || _0ssss.buildPriority != 0)
				{
				}
				num4++;
				if (num4 > 100)
				{
					break;
				}
			}
		}

		public static void OQDQCOODQC(ref List<int> tris, ref List<Vector3> vecs, ref List<Vector2> uvs, List<List<Vector3>> vecsData, List<List<Vector2>> uvsData, List<Vector3> priorityPointsMain, List<Vector2> priorityPointsMainUVs, ref List<Color> colors, List<bool> originalShapeVecs, ref List<int> connInts, int totalVecs, ref List<int> secondPriorityInts, bool singleSectionFlag, ERConnectionSibling sibling)
		{
			List<List<int>> tris2 = new List<List<int>>();
			Material mat = null;
			List<Material> mats = new List<Material>();
			List<Vector2> uvs2 = new List<Vector2>();
			List<Vector2> uvs3 = new List<Vector2>();
			List<Color> colorsTmp = new List<Color>();
			List<Vector2> uvsTmp = new List<Vector2>();
			List<Vector2> uvsTmp2 = new List<Vector2>();
			List<Vector3> list = new List<Vector3>();
			List<Vector3> list2 = new List<Vector3>();
			List<Vector3> list3 = new List<Vector3>();
			List<Vector3> list4 = new List<Vector3>();
			List<Vector3> list5 = new List<Vector3>();
			List<Vector3> vecsTmp = new List<Vector3>();
			List<Vector2> uvsTmp3 = new List<Vector2>();
			List<Vector3> list6 = new List<Vector3>();
			List<Vector3> list7 = new List<Vector3>();
			List<int> list8 = new List<int>();
			bool flag = false;
			if (sibling.leftFixedIndex == 0)
			{
				flag = true;
			}
			int num = 0;
			int num2 = 1;
			int num3 = 1;
			if (priorityPointsMain.Count > 0)
			{
				for (int i = 0; i < vecsData[0].Count - 1; i++)
				{
					list2.Add(vecsData[0][i]);
				}
			}
			else
			{
				list2.AddRange(vecsData[0]);
			}
			int num4 = 0;
			int num5 = 0;
			for (int j = 0; j < vecsData.Count; j++)
			{
				if (priorityPointsMain.Count == 0)
				{
					if (!singleSectionFlag)
					{
						list3.Add(vecsData[j][vecsData[j].Count - 1]);
					}
					else if (originalShapeVecs[j])
					{
						list3.Add(vecsData[j][vecsData[j].Count - 1]);
					}
				}
				else if (j > 0)
				{
					Vector3 vector = vecsData[j][vecsData[j].Count - 1];
					Vector3 pSource = vector + sibling.dir * 15f;
					for (int k = num; k < priorityPointsMain.Count; k++)
					{
						if (OQQOCDQCQD.OOCQODQDQD(vector, pSource, priorityPointsMain[k]))
						{
							list3.Add(priorityPointsMain[k]);
							vecsTmp.Add(priorityPointsMain[k]);
							uvsTmp3.Add(priorityPointsMainUVs[k]);
							continue;
						}
						num = k;
						num3 = k;
						break;
					}
				}
				if (originalShapeVecs[j])
				{
					list5.Add(vecsData[j][0]);
				}
				if (originalShapeVecs[j])
				{
					connInts.Add(totalVecs + vecsTmp.Count);
					list6.Add(vecsData[j][0]);
					list8.Add(vecsTmp.Count);
					vecsTmp.AddRange(vecsData[j]);
					uvsTmp3.AddRange(uvsData[j]);
					if (priorityPointsMain.Count == 0)
					{
						sibling.normalIndexes.Add(totalVecs + vecsTmp.Count - 1);
					}
					if (singleSectionFlag)
					{
						secondPriorityInts.Add(totalVecs + vecsTmp.Count - 1);
						list7.Add(vecsData[j][vecsData[j].Count - 1]);
					}
				}
				else
				{
					int num6 = vecsData[j].Count;
					if (singleSectionFlag)
					{
						num6--;
					}
					for (int l = 1; l < num6; l++)
					{
						vecsTmp.Add(vecsData[j][l]);
						uvsTmp3.Add(uvsData[j][l]);
						if (l == num6 - 1 && priorityPointsMain.Count == 0)
						{
							sibling.normalIndexes.Add(totalVecs + vecsTmp.Count - 1);
						}
					}
				}
				if (!sibling.hardEdge[j] && j != sibling.leftFixedIndex && j != sibling.rightFixedIndex && j != vecsData.Count - 1)
				{
					continue;
				}
				if (originalShapeVecs[j])
				{
					list4 = new List<Vector3>(vecsData[j]);
				}
				else if (j == sibling.leftFixedIndex)
				{
					for (int m = 1; m < vecsData[j].Count; m++)
					{
						list4.Add(vecsData[j][m]);
					}
				}
				else
				{
					int index = 0;
					for (int n = j + 1; n < vecsData.Count; n++)
					{
						if (originalShapeVecs[n])
						{
							list4.Add(vecsData[n][0]);
							vecsTmp.Add(vecsData[n][0]);
							uvsTmp3.Add(uvsData[n][0]);
							index = n;
							break;
						}
					}
					int num7 = vecsData[j].Count;
					if (singleSectionFlag)
					{
						num7--;
					}
					for (int num8 = 1; num8 < num7; num8++)
					{
						list4.Add(vecsData[j][num8]);
					}
					if (singleSectionFlag)
					{
						list4.Add(vecsData[index][vecsData[index].Count - 1]);
						vecsTmp.Add(vecsData[index][vecsData[index].Count - 1]);
						uvsTmp3.Add(uvsData[index][vecsData[index].Count - 1]);
					}
				}
				list4.Reverse();
				list5.Reverse();
				list.AddRange(list2);
				list.AddRange(list3);
				list.AddRange(list4);
				list.AddRange(list5);
				List<int> trisTmp = OOQOQOCODD(vecsTmp, list);
				if (num4 != 2 || priorityPointsMain.Count > 0)
				{
				}
				if (totalVecs < 25 && num4 == 2)
				{
					debugEdges.AddRange(list);
					debugvecs.AddRange(vecsTmp);
				}
				MergeMeshDataExt(ref tris2, ref vecs, ref uvs, ref uvs2, ref uvs3, ref colors, ref trisTmp, ref vecsTmp, ref uvsTmp3, ref uvsTmp, ref uvsTmp2, ref colorsTmp, skipMiddles: false, weldVecs: true, mat, ref mats);
				vecsTmp.Clear();
				uvsTmp3.Clear();
				list2.Clear();
				list3.Clear();
				list4.Clear();
				list5.Clear();
				list.Clear();
				int index2 = -1;
				if (originalShapeVecs[j])
				{
					list2 = new List<Vector3>(vecsData[j]);
					vecsTmp.AddRange(vecsData[j]);
					uvsTmp3.AddRange(uvsData[j]);
				}
				else
				{
					if (j == sibling.leftFixedIndex)
					{
						if (j == 0)
						{
							list2.Add(vecsData[0][0]);
							vecsTmp.Add(vecsData[0][0]);
							uvsTmp3.Add(uvsData[0][0]);
						}
						else
						{
							for (int num9 = j - 1; num9 >= 0; num9--)
							{
								if (originalShapeVecs[num9])
								{
									list2.Add(vecsData[num9][0]);
									vecsTmp.Add(vecsData[num9][0]);
									uvsTmp3.Add(uvsData[num9][0]);
									index2 = num9;
									break;
								}
							}
						}
					}
					else if (j == vecsData.Count - 1)
					{
						list2.Add(vecsData[vecsData.Count - 1][0]);
					}
					else
					{
						for (int num10 = j + 1; num10 < vecsData.Count; num10++)
						{
							if (originalShapeVecs[num10])
							{
								list2.Add(vecsData[num10][0]);
								index2 = num10;
								break;
							}
						}
					}
					int num11 = vecsData[j].Count;
					if (singleSectionFlag)
					{
						num11--;
					}
					for (int num12 = 1; num12 < num11; num12++)
					{
						list2.Add(vecsData[j][num12]);
						vecsTmp.Add(vecsData[j][num12]);
						uvsTmp3.Add(uvsData[j][num12]);
					}
					if (singleSectionFlag && j != sibling.leftFixedIndex)
					{
					}
				}
				if (singleSectionFlag)
				{
					if (originalShapeVecs[j])
					{
						list3.Add(vecsData[j][vecsData[j].Count - 1]);
						vecsTmp.Add(vecsData[j][vecsData[j].Count - 1]);
						uvsTmp3.Add(uvsData[j][vecsData[j].Count - 1]);
					}
					else
					{
						list3.Add(vecsData[index2][vecsData[index2].Count - 1]);
						vecsTmp.Add(vecsData[index2][vecsData[index2].Count - 1]);
						uvsTmp3.Add(uvsData[index2][vecsData[index2].Count - 1]);
					}
				}
				else if (priorityPointsMain.Count == 0)
				{
					list3.Add(vecsData[j][vecsData[j].Count - 1]);
				}
				else
				{
					list3.Add(priorityPointsMain[num]);
				}
				num4++;
			}
			connInts.Clear();
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			if (singleSectionFlag)
			{
				secondPriorityInts.Clear();
			}
			for (int num13 = 0; num13 < list6.Count; num13++)
			{
				flag3 = (flag4 = false);
				for (int num14 = 0; num14 < vecs.Count; num14++)
				{
					if (list6[num13] == vecs[num14] && !flag3)
					{
						connInts.Add(totalVecs + num14);
						flag3 = true;
						if (!singleSectionFlag || flag4)
						{
							break;
						}
					}
					if (singleSectionFlag && list7[num13] == vecs[num14] && !flag4)
					{
						secondPriorityInts.Add(totalVecs + num14);
						flag4 = true;
						if (flag3)
						{
							break;
						}
					}
				}
			}
			sibling.normalIndexes.Clear();
			int count = vecs.Count;
			int num15 = 0;
			int num16 = 1;
			Vector3 vector2 = Vector3.zero;
			for (int num17 = 0; num17 < vecsData.Count; num17++)
			{
				Vector3 vector3 = vecsData[num17][vecsData[num17].Count - 1];
				if (num17 > 0)
				{
					num16 = ((!(vector3 == vector2)) ? 1 : 2);
					vector2 = vector3;
				}
				num15 = 1;
				for (int num18 = 0; num18 < count; num18++)
				{
					if (vecs[num18] == vector3)
					{
						if (num15 == num16)
						{
							sibling.normalIndexes.Add(totalVecs + num18);
							break;
						}
						num15++;
					}
				}
			}
			List<Color> list9 = new List<Color>();
			tris = tris2[0];
		}

		public static void ODOODDDCOD(ref List<int> tris, ref List<Vector3> vecs, ref List<Vector2> uvs, List<List<Vector3>> vecsData, List<List<Vector2>> uvsData, List<Vector3> priorityPointsMain, List<Vector2> priorityPointsMainUVs, ref List<Color> colors, List<bool> originalShapeVecs, ref List<int> connInts, int totalVecs, ref List<int> secondPriorityInts, bool singleSectionFlag, ERConnectionSibling sibling)
		{
			List<Vector3> list = new List<Vector3>();
			list.AddRange(vecsData[0]);
			List<int> list2 = new List<int>();
			if (priorityPointsMain.Count == 0)
			{
				for (int i = 1; i < vecsData.Count - 1; i++)
				{
					if (!singleSectionFlag)
					{
						list.Add(vecsData[i][vecsData[i].Count - 1]);
					}
					else if (originalShapeVecs[i])
					{
						list.Add(vecsData[i][vecsData[i].Count - 1]);
					}
				}
			}
			else
			{
				list.AddRange(priorityPointsMain);
			}
			List<Vector3> list3 = new List<Vector3>(vecsData[vecsData.Count - 1]);
			list3.Reverse();
			list.AddRange(list3);
			list3.Clear();
			for (int j = 1; j < vecsData.Count - 1; j++)
			{
				if (originalShapeVecs[j])
				{
					list3.Add(vecsData[j][0]);
				}
			}
			list3.Reverse();
			for (int k = 0; k < vecsData.Count; k++)
			{
				if (originalShapeVecs[k])
				{
					connInts.Add(totalVecs + vecs.Count);
					list2.Add(vecs.Count);
					vecs.AddRange(vecsData[k]);
					uvs.AddRange(uvsData[k]);
					secondPriorityInts.Add(totalVecs + vecs.Count - 1);
					continue;
				}
				int num = vecsData[k].Count;
				if (singleSectionFlag)
				{
					num--;
				}
				for (int l = 1; l < num; l++)
				{
					vecs.Add(vecsData[k][l]);
					uvs.Add(uvsData[k][l]);
				}
			}
			if (priorityPointsMain.Count > 0)
			{
				for (int m = 1; m < priorityPointsMain.Count - 1; m++)
				{
					vecs.Add(priorityPointsMain[m]);
					uvs.Add(priorityPointsMainUVs[m]);
				}
			}
			tris = OOQOQOCODD(vecs, list);
			List<Color> list4 = new List<Color>();
		}

		public static void OQQDOOQCOQ(ref List<int> tris, ref List<Vector3> vecs, ref List<Vector2> uvs, ref List<Vector2> uvs1, ref List<Vector2> uvs2, ref List<Color> colors, List<Vector3> mleftPoints, List<Vector3> rightPoints, List<Vector3> centerPoints, Vector3 leftPoint, Vector3 rightPoint, List<Vector2> leftRoundingPointsUV, List<Vector2> rightRoundingPointsUV, List<Vector2> centerPointsUV, Vector2 cpUV, List<Vector3> leftPointsIndents, List<Vector2> leftPointsIndentsUV, List<Vector3> rightPointsIndents, List<Vector2> rightPointsIndentsUV)
		{
			vecs.AddRange(mleftPoints);
			vecs.Add(Vector3.zero);
			List<Vector3> list = new List<Vector3>(rightPoints);
			list.Reverse();
			vecs.AddRange(list);
			List<Vector3> edges = new List<Vector3>(vecs);
			List<Vector3> list2 = new List<Vector3>(centerPoints);
			list2.RemoveAt(0);
			vecs.AddRange(list2);
			for (int i = 1; i < leftPointsIndents.Count; i++)
			{
				vecs.Add(leftPointsIndents[i]);
			}
			for (int j = 1; j < rightPointsIndents.Count; j++)
			{
				vecs.Add(rightPointsIndents[j]);
			}
			uvs.AddRange(leftRoundingPointsUV);
			uvs.Add(cpUV);
			List<Vector2> list3 = new List<Vector2>(rightRoundingPointsUV);
			list3.Reverse();
			uvs.AddRange(list3);
			List<Vector2> list4 = new List<Vector2>(centerPointsUV);
			list4.RemoveAt(0);
			uvs.AddRange(list4);
			for (int k = 1; k < leftPointsIndentsUV.Count; k++)
			{
				uvs.Add(leftPointsIndentsUV[k]);
			}
			for (int l = 1; l < rightPointsIndentsUV.Count; l++)
			{
				uvs.Add(rightPointsIndentsUV[l]);
			}
			tris = OOQOQOCODD(vecs, edges);
			List<Color> list5 = new List<Color>();
		}

		public static void ODCDDCQDDC(ref List<int> tris, ref List<Vector3> vecs, ref List<Vector2> uvs, ref List<Vector2> uvs1, ref List<Vector2> uvs2, ref List<Color> colors, List<Vector3> mleftPoints, List<Vector3> rightPoints, List<Vector3> centerPoints, Vector3 leftPoint, Vector3 rightPoint, List<Vector2> leftRoundingPointsUV, List<Vector2> rightRoundingPointsUV, List<Vector2> centerPointsUV, Vector2 cpUV, List<Vector3> leftPointsIndents, List<Vector2> leftPointsIndentsUV, List<Vector3> rightPointsIndents, List<Vector2> rightPointsIndentsUV)
		{
			vecs.AddRange(mleftPoints);
			List<Vector3> list = new List<Vector3>(rightPoints);
			list.Reverse();
			vecs.AddRange(list);
			List<Vector3> edges = new List<Vector3>(vecs);
			uvs.AddRange(leftRoundingPointsUV);
			List<Vector2> list2 = new List<Vector2>(rightRoundingPointsUV);
			list2.Reverse();
			uvs.AddRange(list2);
			tris = OOQOQOCODD(vecs, edges);
			List<Color> list3 = new List<Color>();
		}

		public static void ForkPriorityOCDDCCCCOC(ref List<int> tris, ref List<Vector3> vecs, ref List<Vector2> uvs, ref List<Vector2> uvs1, ref List<Vector2> uvs2, ref List<Color> colors, List<Vector3> mleftPoints, List<Vector3> rightPoints, List<Vector3> centerPoints, Vector3 leftPoint, Vector3 rightPoint, List<Vector2> leftRoundingPointsUV, List<Vector2> rightRoundingPointsUV, List<Vector2> centerPointsUV, Vector2 cpUV, List<Vector3> leftPointsIndents, List<Vector2> leftPointsIndentsUV, List<Vector3> rightPointsIndents, List<Vector2> rightPointsIndentsUV, List<Vector3> mainPoints, List<Vector2> mainPointsUV)
		{
			vecs.AddRange(mleftPoints);
			vecs.AddRange(mainPoints);
			List<Vector3> list = new List<Vector3>(rightPoints);
			list.Reverse();
			vecs.AddRange(list);
			List<Vector3> edges = new List<Vector3>(vecs);
			for (int i = 1; (float)i < (float)leftPointsIndents.Count - _3ssss; i++)
			{
				vecs.Add(leftPointsIndents[i]);
			}
			for (int j = 1; (float)j < (float)rightPointsIndents.Count - _4ssst; j++)
			{
				vecs.Add(rightPointsIndents[j]);
			}
			uvs.AddRange(leftRoundingPointsUV);
			uvs.AddRange(mainPointsUV);
			List<Vector2> list2 = new List<Vector2>(rightRoundingPointsUV);
			list2.Reverse();
			uvs.AddRange(list2);
			for (int k = 1; (float)k < (float)leftPointsIndentsUV.Count - _3ssss; k++)
			{
				uvs.Add(leftPointsIndentsUV[k]);
			}
			for (int l = 1; (float)l < (float)rightPointsIndentsUV.Count - _4ssst; l++)
			{
				uvs.Add(rightPointsIndentsUV[l]);
			}
			tris = OOQOQOCODD(vecs, edges);
			List<Color> list3 = new List<Color>();
		}

		private void OQQQDQDCCQ(ref List<int> tris, ref List<Vector3> vecs, ref List<Vector2> uvs, ref List<Vector2> uvs1, ref List<Vector2> uvs2, ref List<Color> colors, ref List<int> trisTmp, ref List<Vector3> vecsTmp, ref List<Vector2> uvsTmp, ref List<Vector2> uvsTmp1, ref List<Vector2> uvsTmp2, ref List<Color> colorsTmp, bool skipMiddles, bool weldVecs)
		{
			int count = vecs.Count;
			bool[] array = new bool[trisTmp.Count];
			int num = -1;
			for (int i = 0; i < vecsTmp.Count; i++)
			{
				vecs.Add(vecsTmp[i]);
				uvs.Add(uvsTmp[i]);
				num = vecs.Count - 1;
				for (int j = 0; j < trisTmp.Count; j++)
				{
					if (trisTmp[j] == i && !array[j])
					{
						trisTmp[j] = num;
						array[j] = true;
					}
				}
			}
			tris.AddRange(trisTmp);
			trisTmp.Clear();
			vecsTmp.Clear();
			uvsTmp.Clear();
			uvsTmp1.Clear();
			uvsTmp2.Clear();
			colorsTmp.Clear();
		}

		private static void MergeMeshDataExt(ref List<List<int>> tris, ref List<Vector3> vecs, ref List<Vector2> uvs, ref List<Vector2> uvs1, ref List<Vector2> uvs2, ref List<Color> colors, ref List<int> trisTmp, ref List<Vector3> vecsTmp, ref List<Vector2> uvsTmp, ref List<Vector2> uvsTmp1, ref List<Vector2> uvsTmp2, ref List<Color> colorsTmp, bool skipMiddles, bool weldVecs, Material mat, ref List<Material> mats)
		{
			int num = -1;
			if (mat == null && mats.Count == 0)
			{
				mats.Add(mat);
				tris.Add(new List<int>());
				num = 0;
			}
			for (int i = 0; i < mats.Count; i++)
			{
				if (mats[i] == mat)
				{
					num = i;
					break;
				}
			}
			if (num == -1)
			{
				mats.Add(mat);
				tris.Add(new List<int>());
				num = mats.Count - 1;
			}
			bool[] array = new bool[trisTmp.Count];
			int num2 = -1;
			for (int j = 0; j < vecsTmp.Count; j++)
			{
				num2 = -1;
				if ((!skipMiddles || vecsTmp[j].x != 0f) && weldVecs)
				{
					for (int k = 0; k < vecs.Count; k++)
					{
						if (vecsTmp[j] == vecs[k])
						{
							num2 = k;
							break;
						}
					}
				}
				if (num2 == -1 || !weldVecs)
				{
					vecs.Add(vecsTmp[j]);
					uvs.Add(uvsTmp[j]);
					colors.Add(colorsTmp[j]);
					num2 = vecs.Count - 1;
				}
				for (int l = 0; l < trisTmp.Count; l++)
				{
					if (trisTmp[l] == j && !array[l])
					{
						trisTmp[l] = num2;
						array[l] = true;
					}
				}
			}
			tris[num].AddRange(trisTmp);
			trisTmp.Clear();
			vecsTmp.Clear();
			uvsTmp.Clear();
			uvsTmp1.Clear();
			uvsTmp2.Clear();
			colorsTmp.Clear();
		}

		private void OOQOOQOCOC(ref List<int> tris, ref List<Vector3> vecs, ref List<Vector2> uvs, ref List<Vector2> uvs1, ref List<Vector2> uvs2, ref List<Color> colors, ref List<int> trisTmp, ref List<Vector3> vecsTmp, ref List<Vector2> uvsTmp, ref List<Vector2> uvsTmp1, ref List<Vector2> uvsTmp2, ref List<Color> colorsTmp, bool skipMiddles, bool weldVecs)
		{
			bool[] array = new bool[trisTmp.Count];
			int num = -1;
			for (int i = 0; i < vecsTmp.Count; i++)
			{
				num = -1;
				if ((!skipMiddles || vecsTmp[i].x != 0f) && weldVecs)
				{
					for (int j = 0; j < vecs.Count; j++)
					{
						if (vecsTmp[i] == vecs[j])
						{
							num = j;
							break;
						}
					}
				}
				if (num == -1 || !weldVecs)
				{
					vecs.Add(vecsTmp[i]);
					uvs.Add(uvsTmp[i]);
					num = vecs.Count - 1;
				}
				for (int k = 0; k < trisTmp.Count; k++)
				{
					if (trisTmp[k] == i && !array[k])
					{
						trisTmp[k] = num;
						array[k] = true;
					}
				}
			}
			tris.AddRange(trisTmp);
			trisTmp.Clear();
			vecsTmp.Clear();
			uvsTmp.Clear();
			uvsTmp1.Clear();
			uvsTmp2.Clear();
			colorsTmp.Clear();
		}

		public static List<int> OOQOQOCODD(List<Vector3> vecs, List<Vector3> edges)
		{
			List<Vector2> list = new List<Vector2>();
			List<PointER> list2 = new List<PointER>();
			for (int i = 0; i < vecs.Count; i++)
			{
				Vector3 vector = vecs[i];
				list2.Add(new PointER(vector.x, vector.z, 0f));
			}
			for (int j = 0; j < edges.Count; j++)
			{
				Vector3 vector = edges[j];
				list.Add(new Vector2(vector.x, vector.z));
			}
			List<int> list3 = new List<int>();
			List<int> list4 = new List<int>();
			List<TriangleER> list5 = delaunayER.Triangulate(list2);
			for (int k = 0; k < list5.Count; k++)
			{
				list3.Add(delaunayER.FindVertice(new Vector3(list5[k].Vertex1.x, list5[k].Vertex1.z, list5[k].Vertex1.y), vecs));
				list3.Add(delaunayER.FindVertice(new Vector3(list5[k].Vertex3.x, list5[k].Vertex3.z, list5[k].Vertex3.y), vecs));
				list3.Add(delaunayER.FindVertice(new Vector3(list5[k].Vertex2.x, list5[k].Vertex2.z, list5[k].Vertex2.y), vecs));
			}
			for (int l = 0; l < list3.Count; l += 3)
			{
				if (list.Count == 0)
				{
					list4.Add(list3[l]);
					list4.Add(list3[l + 1]);
					list4.Add(list3[l + 2]);
					continue;
				}
				Vector3 vector2 = (vecs[list3[l]] + vecs[list3[l + 1]] + vecs[list3[l + 2]]) / 3f;
				if (OQOQOOCDCC.OCDCDOCQCQ(list.Count, list, vector2.x, vector2.z))
				{
					list4.Add(list3[l]);
					list4.Add(list3[l + 1]);
					list4.Add(list3[l + 2]);
				}
			}
			return list4;
		}

		public static List<int> OOQOQOCODD(List<Vector3> vecs, List<Vector3> edges, List<int> vecIndexes)
		{
			List<Vector2> list = new List<Vector2>();
			List<PointER> list2 = new List<PointER>();
			for (int i = 0; i < vecs.Count; i++)
			{
				Vector3 vector = vecs[i];
				list2.Add(new PointER(vector.x, vector.z, 0f));
			}
			for (int j = 0; j < edges.Count; j++)
			{
				Vector3 vector = edges[j];
				list.Add(new Vector2(vector.x, vector.z));
			}
			List<int> list3 = new List<int>();
			List<int> list4 = new List<int>();
			List<TriangleER> list5 = delaunayER.Triangulate(list2);
			for (int k = 0; k < list5.Count; k++)
			{
				list3.Add(delaunayER.FindVertice(new Vector3(list5[k].Vertex1.x, list5[k].Vertex1.z, list5[k].Vertex1.y), vecs));
				list3.Add(delaunayER.FindVertice(new Vector3(list5[k].Vertex3.x, list5[k].Vertex3.z, list5[k].Vertex3.y), vecs));
				list3.Add(delaunayER.FindVertice(new Vector3(list5[k].Vertex2.x, list5[k].Vertex2.z, list5[k].Vertex2.y), vecs));
			}
			for (int l = 0; l < list3.Count; l += 3)
			{
				if (list.Count == 0)
				{
					list4.Add(vecIndexes[list3[l]]);
					list4.Add(vecIndexes[list3[l + 1]]);
					list4.Add(vecIndexes[list3[l + 2]]);
					continue;
				}
				Vector3 vector2 = (vecs[list3[l]] + vecs[list3[l + 1]] + vecs[list3[l + 2]]) / 3f;
				if (OQOQOOCDCC.OCDCDOCQCQ(list.Count, list, vector2.x, vector2.z))
				{
					list4.Add(vecIndexes[list3[l]]);
					list4.Add(vecIndexes[list3[l + 1]]);
					list4.Add(vecIndexes[list3[l + 2]]);
				}
			}
			return list4;
		}

		public static void OOOQCCODDC(QDOODOQQDQODD connection, ERConnectionSibling sibling, int index, int total)
		{
			if (sibling != secondPriorityConnection)
			{
				sibling.uvy = sibling.roadUVs[0][0].y;
				sibling.uvy -= Mathf.Floor(sibling.uvy);
			}
			if (sibling == primaryPriorityConnection)
			{
				secondPriorityConnection.uvy = sibling.roadUVs[0][sibling.roadUVs[0].Count - 1].y;
				secondPriorityConnection.uvy -= Mathf.Floor(secondPriorityConnection.uvy);
			}
			connection.centerPoint = (connection.tmpCenterPoint = OQQOCDQCQD.OCDCQCDDCC(sibling.roadVecs[0][0], sibling.roadVecs[sibling.roadVecs.Count - 1][0], sibling.cp, Vector3.zero, flag: true));
			connection.centerPoint.y = (connection.tmpCenterPoint.y = 0f);
			Vector3 normalized = new Vector3(sibling.forward.x, 0f, sibling.forward.z).normalized;
			sibling.controlPoint = (connection.controlPointV3 = connection.centerPoint + normalized * 25f);
			connection.controlPointV3 = sibling.controlPoint;
			connection.controlPoint = new Vector3(sibling.controlPoint.x, sibling.controlPoint.z);
			connection.rotationPriority = false;
			normalized = (sibling.controlPoint - connection.centerPoint).normalized;
			connection.alignmentHandleVec = connection.centerPoint + normalized * 2f;
			connection.roadType = sibling.roadType.id;
			connection.connectionVecInts.Clear();
			connection.blendCornerPointInts.Clear();
			connection.blendCornerPointWeights.Clear();
			connection.roadShapeUVY.Clear();
			QDOQDSQOOQDDD qDOQDSQOOQDDD = null;
			QDOQDSQOOQDDD qDOQDSQOOQDDD2 = null;
			connection.connectionVecInts = new List<int>(sibling.connectionVecInts);
			connection.roadShapeUVY.Clear();
			for (int i = 0; i < sibling.roadShape.Count; i++)
			{
				if (sibling.originalShapeVecs[i])
				{
					connection.roadShapeUVY.Add(sibling.roadShapeUVs[i]);
				}
			}
			connection.sidewalkRightUVY.Clear();
			connection.sidewalkRightConnectionVecInts.Clear();
			if (connection.includeRightSidewalk)
			{
			}
			connection.fullConnectionVecInts = new List<int>(connection.connectionVecInts);
			connection.leftInt = 0;
			connection.leftIntFull = 0;
			connection.rightInt = connection.connectionVecInts.Count - 1;
			connection.rightIntFull = connection.fullConnectionVecInts.Count - 1;
			connection.roadShapeVecs.Clear();
			connection.sidewalkLeftVecs.Clear();
			connection.sidewalkRightVecs.Clear();
			Vector3 zero;
			Vector3 vector = (zero = Vector3.zero);
			Vector3 a = ((sibling.leftSidewalk == null || sibling.leftSidewalkVecs.Count <= 0) ? sibling.roadVecs[0][0] : sibling.leftSidewalkVecs[0][0]);
			Vector3 b = ((sibling.rightSidewalk == null || sibling.rightSidewalkVecs.Count <= 0) ? sibling.roadVecs[sibling.roadVecs.Count - 1][0] : sibling.rightSidewalkVecs[sibling.rightSidewalkVecs.Count - 1][0]);
			Vector3 centerPoint = connection.centerPoint;
			float num = Vector3.Distance(a, b) * 0.5f;
			for (int j = 0; j < connection.connectionVecInts.Count - 1; j++)
			{
			}
			List<Vector2> list = new List<Vector2>();
			if (connection.includeLeftSidewalk && sibling.leftSidewalkVecs.Count > 0)
			{
				list.AddRange(connection.sidewalkLeftVecs);
				Debug.Log("check if we have to reverse with new sidwalk code!!!");
				connection.roadShapeVecs.AddRange(list);
			}
			list.Clear();
			list.AddRange(sibling.roadType.roadShape);
			if (vector == Vector3.zero)
			{
				vector = list[0];
			}
			zero = list[list.Count - 1];
			connection.roadShapeVecs.AddRange(list);
			if (connection.includeRightSidewalk && sibling.rightSidewalkVecs.Count > 0)
			{
				list.Clear();
				list.AddRange(connection.sidewalkRightVecs);
				connection.roadShapeVecs.AddRange(list);
			}
			vector.y = 0f;
			zero.y = 0f;
			float num2 = Vector3.Distance(vector, zero);
			connection.centerPointPercentage = num / num2;
			connection.roadShapeVecsString = ERCrossings.GetRoadShapeVecString(connection.roadShapeVecs, connection.sidewalkLeftVecs, connection.sidewalkRightVecs, ref connection.roadShapeMatchCount);
			QDOODOQQDQODD qDOODOQQDQODD = prefabScript.crossingElements[index];
			qDOQDSQOOQDDD2 = prefabScript.sidewalkControlElements[index];
			connection.roadMaterial = sibling.roadType.roadMaterial;
			List<Material> list2 = new List<Material>();
			List<int> list3 = new List<int>();
			list2.Add(sibling.roadType.roadMaterial);
			int num3 = 0;
			for (int k = 0; k < sibling.roadType.roadShape.Count; k++)
			{
				list3.Add(0);
			}
			int num4 = 0;
			connection.roadMaterials = list2.ToArray();
			connection.roadShapeMaterialInts.Clear();
			connection.roadShapeMaterialInts.AddRange(list3);
			connection.roadMaterial = sibling.roadType.roadMaterial;
			connection.doConnectionTri.Clear();
			connection.doConnectionTri = new List<bool>(sibling.roadType.doConnectionTri);
			connection.hardEdge.Clear();
			connection.hardEdge = new List<bool>(sibling.roadType.hardEdge);
			connection.roadType = sibling.roadType.id;
			connection.roadTypeTimestamp = sibling.roadType.timestamp;
			prefabScript.sidewalkControlElements[index].crossingElementRightIndex = index;
			if (index == 0)
			{
				prefabScript.sidewalkControlElements[index].crossingElementLeftIndex = total - 1;
			}
			else
			{
				prefabScript.sidewalkControlElements[index].crossingElementLeftIndex = index - 1;
			}
		}

		public static void OQDDQOOCCO(List<ERConnectionSibling> siblings, int index)
		{
			if (baseScript == null)
			{
				baseScript = UnityEngine.Object.FindObjectOfType(typeof(ERModularBase)) as ERModularBase;
			}
			float minIndent = baseScript.minIndent;
			float minSurrounding = baseScript.minSurrounding;
			float leftRoadIndent = siblings[index].leftRoadIndent;
			float leftRoadSurrounding = siblings[index].leftRoadSurrounding;
			float rightRoadIndent = siblings[index].rightRoadIndent;
			float rightRoadSurrounding = siblings[index].rightRoadSurrounding;
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			if (index < siblings.Count - 1)
			{
				num = siblings[index + 1].rightRoadIndent;
				num2 = siblings[index + 1].rightRoadSurrounding;
			}
			else
			{
				num = siblings[0].rightRoadIndent;
				num2 = siblings[0].rightRoadSurrounding;
			}
			if (index == 0)
			{
				num3 = siblings[siblings.Count - 1].leftRoadIndent;
				num4 = siblings[siblings.Count - 1].leftRoadSurrounding;
			}
			else
			{
				num3 = siblings[index - 1].leftRoadIndent;
				num4 = siblings[index - 1].leftRoadSurrounding;
			}
			num = Mathf.Lerp(leftRoadIndent, num, 0.5f);
			num2 = Mathf.Lerp(leftRoadSurrounding, num2, 0.5f);
			num3 = Mathf.Lerp(rightRoadIndent, num3, 0.5f);
			num4 = Mathf.Lerp(rightRoadSurrounding, num4, 0.5f);
			ERConnectionSibling eRConnectionSibling = siblings[index];
			if (eRConnectionSibling == primaryPriorityConnection || eRConnectionSibling == secondPriorityConnection)
			{
				if (eRConnectionSibling.middleIndentIndexRight == -1)
				{
					eRConnectionSibling.middleIndentIndexRight = Mathf.RoundToInt((float)eRConnectionSibling.rightRoundingPoints.Count * 0.5f + 1f);
				}
				if (eRConnectionSibling.middleIndentIndexLeft == -1)
				{
					eRConnectionSibling.middleIndentIndexLeft = Mathf.RoundToInt((float)eRConnectionSibling.leftRoundingPoints.Count * 0.5f + 1f);
				}
			}
			List<Vector3> leftRoundingPoints = eRConnectionSibling.leftRoundingPoints;
			Vector3 normalized;
			Vector3 vector;
			if (eRConnectionSibling.middleIndentIndexLeft == -1)
			{
				vector = leftRoundingPoints[leftRoundingPoints.Count - 1];
				vector.y = 0f;
				Vector3 vector2 = -eRConnectionSibling.dir;
				Vector3 vector3 = ((index != siblings.Count - 1) ? (-siblings[index + 1].dir) : (-siblings[0].dir));
				normalized = Vector3.Lerp(vector2, vector3, 0.5f).normalized;
				Vector3 vector4 = vector + vector2 * 2f;
				Vector3 vector5 = vector + vector3 * 2f;
				Vector3 vector6 = vector + normalized * 2f;
			}
			else
			{
				vector = leftRoundingPoints[eRConnectionSibling.middleIndentIndexLeft];
				Vector3 vector2 = -eRConnectionSibling.dir;
				Vector3 vector3 = ((index != siblings.Count - 1) ? (-siblings[index + 1].dir) : (-siblings[0].dir));
				normalized = Vector3.Lerp(vector2, vector3, 0.5f).normalized;
			}
			Vector3 vector7 = vector + normalized * num;
			if (OQQOCDQCQD.OOCQODQDQD(vector, leftRoundingPoints[0], vector7))
			{
				normalized *= -1f;
				vector7 = vector + normalized * num;
			}
			Vector3 vector8 = vector;
			Vector3 vector9 = vector7 + normalized * num2;
			int num5 = leftRoundingPoints.Count;
			if (leftRoundingPoints[leftRoundingPoints.Count - 1] == Vector3.zero)
			{
				num5--;
			}
			for (int i = 0; i < num5; i++)
			{
				vector = leftRoundingPoints[i];
				vector.y = 0f;
				Vector3 vector10;
				if (i == 0 && num5 > 1)
				{
					vector10 = leftRoundingPoints[1] - leftRoundingPoints[0];
					vector10 = new Vector3(0f - vector10.z, 0f, vector10.x).normalized;
				}
				else if (i < num5 - 1)
				{
					vector10 = leftRoundingPoints[i + 1] - leftRoundingPoints[i - 1];
					vector10 = new Vector3(0f - vector10.z, 0f, vector10.x).normalized;
				}
				else
				{
					vector10 = normalized;
				}
				minIndent = Mathf.SmoothStep(leftRoadIndent, num, (float)i * 1f / ((float)(num5 - 1) * 1f));
				minSurrounding = Mathf.SmoothStep(leftRoadSurrounding, num2, (float)i * 1f / ((float)(num5 - 1) * 1f));
				Vector3 vector11 = vector + vector10 * minIndent;
				Vector3 pos = vector + vector10 * (minIndent + minSurrounding);
				if (OQQOCDQCQD.OOCQODQDQD(vector, vector11, vector8))
				{
					vector11 = vector7;
					pos = vector9;
				}
				else if (OQQOCDQCQD.OOCQODQDQD(vector7, vector8, vector11))
				{
					vector11 = vector7;
					pos = vector9;
				}
				else if (OQQOCDQCQD.OOCQODQDQD(vector9, vector8, pos))
				{
					pos = vector9;
				}
				prefabScript.baseScript.OQCCDQOQOO(ref pos);
				eRConnectionSibling.leftIndentvecs.Add(vector11);
				eRConnectionSibling.leftSurroundingvecs.Add(pos);
			}
			leftRoundingPoints = eRConnectionSibling.rightRoundingPoints;
			if (eRConnectionSibling.middleIndentIndexRight == -1)
			{
				vector = leftRoundingPoints[leftRoundingPoints.Count - 1];
				vector.y = 0f;
				Vector3 vector2 = -eRConnectionSibling.dir;
				Vector3 vector3 = ((index != 0) ? (-siblings[index - 1].dir) : (-siblings[siblings.Count - 1].dir));
				normalized = Vector3.Lerp(vector2, vector3, 0.5f).normalized;
				Vector3 vector12 = vector + vector2 * 2f;
				Vector3 vector13 = vector + vector3 * 2f;
				Vector3 vector14 = vector + normalized * 2f;
			}
			else
			{
				vector = leftRoundingPoints[eRConnectionSibling.middleIndentIndexRight];
				Vector3 vector2 = -eRConnectionSibling.dir;
				Vector3 vector3 = ((index != 0) ? (-siblings[index - 1].dir) : (-siblings[siblings.Count - 1].dir));
				normalized = Vector3.Lerp(vector2, vector3, 0.5f).normalized;
			}
			vector7 = vector + normalized * num3;
			if (!OQQOCDQCQD.OOCQODQDQD(vector, leftRoundingPoints[0], vector7))
			{
				normalized *= -1f;
				vector7 = vector + normalized * num3;
			}
			vector8 = vector;
			vector9 = vector + normalized * (num3 + num4);
			num5 = leftRoundingPoints.Count;
			if (leftRoundingPoints[leftRoundingPoints.Count - 1] == Vector3.zero)
			{
				num5--;
			}
			for (int j = 0; j < num5; j++)
			{
				vector = leftRoundingPoints[j];
				vector.y = 0f;
				Vector3 vector10;
				if (j == 0 && num5 > 1)
				{
					vector10 = leftRoundingPoints[1] - leftRoundingPoints[0];
					vector10 = new Vector3(vector10.z, 0f, 0f - vector10.x).normalized;
				}
				else if (j < num5 - 1)
				{
					vector10 = leftRoundingPoints[j + 1] - leftRoundingPoints[j - 1];
					vector10 = new Vector3(vector10.z, 0f, 0f - vector10.x).normalized;
				}
				else
				{
					vector10 = normalized;
				}
				minIndent = Mathf.SmoothStep(rightRoadIndent, num3, (float)j * 1f / ((float)(num5 - 1) * 1f));
				minSurrounding = Mathf.SmoothStep(rightRoadSurrounding, num4, (float)j * 1f / ((float)(num5 - 1) * 1f));
				Vector3 vector15 = vector + vector10 * minIndent;
				Vector3 pos2 = vector + vector10 * (minIndent + minSurrounding);
				if (!OQQOCDQCQD.OOCQODQDQD(vector, vector15, vector8))
				{
					vector15 = vector7;
					pos2 = vector9;
				}
				else if (!OQQOCDQCQD.OOCQODQDQD(vector7, vector8, vector15))
				{
					vector15 = vector7;
					pos2 = vector9;
				}
				else if (!OQQOCDQCQD.OOCQODQDQD(vector9, vector8, pos2))
				{
					pos2 = vector9;
				}
				prefabScript.baseScript.OQCCDQOQOO(ref pos2);
				eRConnectionSibling.rightIndentvecs.Add(vector15);
				eRConnectionSibling.rightSurroundingvecs.Add(pos2);
			}
		}

		private static float Assss(float tssss, Vector3 ussss, Vector3 vssss, Vector3 wssss, float xssss, Vector3 yssss, Vector3 Assss, float _0ssss)
		{
			Vector3 p = ussss + wssss * 50f;
			Vector3 p2 = Assss + yssss * 50f;
			Vector3 p3 = Assss - yssss * 50f;
			Vector3 b = OQQOCDQCQD.OCDCQCDDCC(ussss, p, p2, p3, flag: true);
			float num = Vector3.Distance(ussss, b);
			if (num < xssss)
			{
				num = xssss - num;
				_0ssss = num / Mathf.Tan(tssss * (MathF.PI / 180f));
				return _0ssss;
			}
			return 0f;
		}

		private static void _0ssst(ERConnectionSibling tssss, ref int ussss, ref Vector3 vssss, ref int wssss, List<Vector3> xssss, List<Vector3> yssss, bool Assss, int _0ssss, int _1ssss)
		{
			wssss = tssss.buildPriority;
			List<Vector3> list = null;
			list = ((_0ssss != 0) ? tssss.rightRoundingPoints : tssss.leftRoundingPoints);
			List<Vector3> list2 = null;
			list2 = ((!Assss && _1ssss != 1) ? xssss : yssss);
			if (wssss == 0)
			{
				if (_1ssss == 0)
				{
					vssss = list2[1];
				}
				else
				{
					vssss = list2[list2.Count - 2];
				}
				return;
			}
			Vector3 vector = list[list.Count - 1];
			int count = list2.Count;
			if (_1ssss == 0)
			{
				for (int i = 0; i < count; i++)
				{
					if (list2[i] == vector)
					{
						ussss = i;
						vssss = vector;
						break;
					}
				}
				return;
			}
			for (int num = count - 1; num > 0; num--)
			{
				if (list2[num] == vector)
				{
					ussss = num;
					vssss = vector;
					break;
				}
			}
		}

		public static bool OQCCCCCOQD(QDQDOOQQDQODD roadType, out int c)
		{
			c = 0;
			for (int i = 0; i < siblings.Count; i++)
			{
				if (siblings[i].roadType.id == roadType.id)
				{
					c++;
					if (c > 1)
					{
						return true;
					}
				}
			}
			return false;
		}

		public static Vector3 OCDCOCDODQ(int index, Vector3 p0, Vector3 p1, Vector3 p2)
		{
			Vector3 vector = cScr.transform.TransformPoint(Vector3.zero);
			float num = Vector3.Distance(vector, p1);
			float num2 = Vector3.Distance(vector, p0);
			if (num2 == 0f)
			{
				num2 = 5f;
			}
			float t = num2 / num;
			float num3 = Vector3.Distance(p1, p2);
			Vector3 p3 = vector + (vector - p1).normalized * Vector3.Distance(p1, p2);
			Vector3 position = ERModularRoad.OQQCQOQOOD(p3, vector, p1, p2, t, 0.5f);
			siblings[index].angleControlPoint = cScr.transform.InverseTransformPoint(position);
			ODCDQQOOOD();
			return cScr.transform.TransformPoint(prefabScript.crossingElements[index].centerPoint);
		}

		public static void Clear()
		{
			ll1.Clear();
			ll2.Clear();
			ll3.Clear();
			ll4.Clear();
			_3ssss = 0f;
			_4ssst = 0f;
		}

		public static void OQCCDCCCOD()
		{
		}

		private static void _1ssss(ERConnectionSibling tssss, ERConnectionSibling ussss)
		{
			Vector3 vector = Vector3.zero;
			float num = 0f;
			float num2 = 0f;
			if (ussss.rightSidewalkActive && ussss.rightSidewalkid != 0.0)
			{
				if (ussss.rightSidewalk == null)
				{
					ERSideWalk.GetSidewalk(baseScript.sidewalks, ussss.rightSidewalkid);
				}
				if (ussss.rightSidewalk != null)
				{
					num = 1.2f;
					num2 = ussss.angle - tssss.angle;
					if (num2 < 0f)
					{
						num2 += 360f;
					}
					if (num2 < 150f)
					{
						if (num2 < 90f)
						{
							num = Mathf.Lerp(2.3f, 1.2f, num2 / 90f);
						}
						float num3 = ussss.rightSidewalk.sidewalkWidth * num;
						int index = 0;
						if (tssss.addedNodeAtStart)
						{
							index = 1;
						}
						int index2 = 0;
						if (ussss.addedNodeAtStart)
						{
							index2 = 1;
						}
						Vector3 vector2 = tssss.leftRoundingPoints[index];
						int num4 = -1;
						if (tssss.secondaryPriorityConnection)
						{
							num4 = _2ssst();
							if (num4 != -1 && siblings[num4].priorityRightPoints.Count > 1)
							{
								vector2 = siblings[num4].priorityRightPoints[siblings[num4].priorityRightPoints.Count - 2];
							}
						}
						vector = OQQOCDQCQD.GetIntersectionByDir(tssss.leftRoundingPoints[index], tssss.forward, ussss.rightRoundingPoints[index2], ussss.forward);
						if (OQQOCDQCQD.OOCQODQDQD(ussss.rightRoundingPoints[0], vector, vector2))
						{
							vector2 = vector;
						}
						Vector3 a = OQQOCDQCQD.OCOOQOQCDC(ussss.rightRoundingPoints[0], vector, vector2);
						float num5 = Vector3.Distance(a, vector2);
						Vector3 normalized = new Vector3(tssss.forward.z, 0f, 0f - tssss.forward.x).normalized;
						Vector3 vector3 = vector2 + -normalized * ussss.rightSidewalk.sidewalkWidth;
						a = OQQOCDQCQD.OCOOQOQCDC(ussss.rightRoundingPoints[0], vector, vector3);
						float num6 = Vector3.Distance(a, vector3);
						if (ussss.buildPriority == 1)
						{
							for (int i = 0; i < ussss.rightRoundingPoints.Count - 1; i++)
							{
								Vector3 vector4 = OQQOCDQCQD.OCDCQCDDCC(ussss.rightRoundingPoints[i], ussss.rightRoundingPoints[i + 1], vector3, a, flag: true);
								if (vector4 != Vector3.zero)
								{
									num3 += Vector3.Distance(a, vector4);
									break;
								}
							}
						}
						if (num6 < num5)
						{
							num5 = num6;
						}
						if (num5 < num3 || num6 < num3)
						{
							float num7 = num3 - num5;
							float num8 = num7 / Mathf.Sin(num2 * (MathF.PI / 180f));
							Vector3 normalized2 = (tssss.leftRoundingPoints[0] - vector).normalized;
							Vector3 item = vector2 + normalized2 * num8;
							tssss.leftRoundingPoints.Insert(index, item);
							if (tssss.secondaryPriorityConnection && num4 != -1)
							{
								siblings[num4].priorityRightPoints.Insert(siblings[num4].priorityRightPoints.Count - 1, item);
							}
							if (tssss.primaryPriorityConnection)
							{
								tssss.priorityLeftPoints.Insert(1, item);
							}
						}
					}
				}
			}
			if (!tssss.leftSidewalkActive || tssss.leftSidewalkid == 0.0)
			{
				return;
			}
			if (tssss.leftSidewalk == null)
			{
				ERSideWalk.GetSidewalk(baseScript.sidewalks, tssss.leftSidewalkid);
			}
			if (tssss.leftSidewalk == null)
			{
				return;
			}
			num = 1.2f;
			num2 = ussss.angle - tssss.angle;
			if (num2 < 0f)
			{
				num2 += 360f;
			}
			if (!(num2 < 150f))
			{
				return;
			}
			if (num2 < 90f)
			{
				num = Mathf.Lerp(2.3f, 1.2f, num2 / 90f);
			}
			float num9 = tssss.leftSidewalk.sidewalkWidth * num;
			int index3 = 0;
			if (ussss.addedNodeAtStart)
			{
				index3 = 1;
			}
			int index4 = 0;
			if (tssss.buildPriority == 0 && ussss.buildPriority == 1)
			{
				index4 = 1;
			}
			if (tssss.addedNodeAtStart)
			{
				index4 = 1;
			}
			Vector3 vector5 = ussss.rightRoundingPoints[index3];
			int num10 = -1;
			if (ussss.secondaryPriorityConnection)
			{
				num10 = _2ssst();
				if (num10 != -1 && siblings[num10].priorityLeftPoints.Count > 1)
				{
					vector5 = siblings[num10].priorityLeftPoints[siblings[num10].priorityLeftPoints.Count - 2];
				}
			}
			if (vector == Vector3.zero)
			{
				vector = OQQOCDQCQD.GetIntersectionByDir(tssss.leftRoundingPoints[index4], tssss.forward, ussss.rightRoundingPoints[index3], ussss.forward);
			}
			if (!OQQOCDQCQD.OOCQODQDQD(tssss.leftRoundingPoints[0], vector, vector5))
			{
				vector5 = vector;
			}
			Vector3 a2 = OQQOCDQCQD.OCOOQOQCDC(tssss.leftRoundingPoints[0], vector, vector5);
			float num11 = Vector3.Distance(a2, vector5);
			Vector3 normalized3 = new Vector3(ussss.forward.z, 0f, 0f - ussss.forward.x).normalized;
			Vector3 vector6 = vector5 + normalized3 * tssss.leftSidewalk.sidewalkWidth;
			a2 = OQQOCDQCQD.OCOOQOQCDC(tssss.leftRoundingPoints[0], vector, vector6);
			float num12 = Vector3.Distance(a2, vector6);
			if (tssss.buildPriority == 1)
			{
				for (int j = 0; j < tssss.leftRoundingPoints.Count - 1; j++)
				{
					Vector3 vector7 = OQQOCDQCQD.OCDCQCDDCC(tssss.leftRoundingPoints[j], tssss.leftRoundingPoints[j + 1], vector6, a2, flag: true);
					if (vector7 != Vector3.zero)
					{
						num9 += Vector3.Distance(a2, vector7);
						break;
					}
				}
			}
			if (num12 < num11)
			{
				num11 = num12;
			}
			if (num11 < num9)
			{
				float num13 = num9 - num11;
				float num14 = num13 / Mathf.Sin(num2 * (MathF.PI / 180f));
				Vector3 normalized4 = (ussss.rightRoundingPoints[0] - vector).normalized;
				Vector3 item2 = vector5 + normalized4 * num14;
				ussss.rightRoundingPoints.Insert(index3, item2);
				if (ussss.secondaryPriorityConnection && num10 != -1)
				{
					siblings[num10].priorityLeftPoints.Insert(siblings[num10].priorityLeftPoints.Count - 1, item2);
				}
				if (ussss.primaryPriorityConnection)
				{
					ussss.priorityRightPoints.Insert(1, item2);
				}
			}
		}

		private static int _2ssst()
		{
			for (int i = 0; i < siblings.Count; i++)
			{
				if (siblings[i].primaryPriorityConnection)
				{
					return i;
				}
			}
			return -1;
		}

		public static void OCODQDOQDO(ERTexture roadERTexture, ref float roadWidth, ref float leftIndent, ref float rightIndent, ref float leftUVX, ref float rightUVX, ref float leftIndentInner, ref float rightIndentInner, ref float roadOuterUVXInner, float cornerRadius)
		{
			if (roadERTexture != null)
			{
				roadWidth = roadERTexture.roadWidth;
				leftIndent = roadERTexture.roadWidth * roadERTexture.leftOffset;
				leftUVX = roadERTexture.leftOffset;
				leftIndentInner = roadERTexture.roadWidth * roadERTexture.leftInnerOffset;
				roadOuterUVXInner = roadERTexture.leftInnerOffset;
				rightIndent = roadERTexture.roadWidth * roadERTexture.rightOffset;
				rightIndentInner = roadERTexture.roadWidth * roadERTexture.rightInnerOffset;
				rightUVX = 1f - roadERTexture.rightOffset;
				Debug.Log(roadERTexture.leftOffset + " " + roadERTexture.roadWidth + " " + leftIndent + " " + leftUVX + " " + leftIndentInner + " " + roadOuterUVXInner);
			}
			else
			{
				leftIndent = 0.25f;
				leftUVX = 0.25f / cornerRadius;
				leftIndentInner = 0.1f;
				roadOuterUVXInner = 0.1f / cornerRadius;
				rightIndent = 0.25f;
				rightIndentInner = 0.1f;
				rightUVX = 0.25f / cornerRadius;
				Debug.Log("EasyRoads3Dv3: No indent texture info found for the selected connection material. The connection material is either null or no texture info has been assigned for the repsective material");
			}
		}

		public static void OOQQCQCDQO(int connection, QDQDOOQQDQODD roadType)
		{
			List<Vector2> list = new List<Vector2>(roadType.roadShape);
			List<float> list2 = new List<float>(roadType.roadShapeUVs);
			List<Vector2> list3 = new List<Vector2>(roadType.roadShapeExt);
			List<float> list4 = new List<float>(roadType.roadShapeExtUVs);
		}

		public static float OCCQDDQQCD(Vector3 v1, Vector3 v2, Vector3 n)
		{
			v1.y = (v2.y = 0f);
			float num = Vector3.Angle(v1, v2);
			float num2 = Mathf.Sign(Vector3.Dot(n, Vector3.Cross(v1, v2)));
			float num3 = num * num2;
			return (num3 + 180f) % 360f;
		}

		public static Vector3 ODDQOOQCCD(Vector3 dirPos1, Vector3 dirPos2, Vector3 currentPos, List<Vector3> vecs, int startend, ref int index)
		{
			Vector3 normalized = (dirPos2 - dirPos1).normalized;
			Vector3 p = currentPos + normalized * 100f;
			int num = vecs.Count - 1;
			if (startend == 0)
			{
				for (int i = 0; i < num; i++)
				{
					Vector3 vector = OQQOCDQCQD.OCDCQCDDCC(currentPos, p, vecs[i], vecs[i + 1], flag: false);
					if (OOOCDOQCQC(vecs[i], vecs[i + 1], vector))
					{
						index = i;
						return vector;
					}
				}
			}
			else
			{
				for (int num2 = num; num2 > 0; num2--)
				{
					Vector3 vector2 = OQQOCDQCQD.OCDCQCDDCC(currentPos, p, vecs[num2], vecs[num2 - 1], flag: false);
					if (OOOCDOQCQC(vecs[num2], vecs[num2 - 1], vector2))
					{
						index = num2;
						return vector2;
					}
				}
			}
			return Vector3.zero;
		}

		public static float GetAdjacentMainRoadAngle(List<ERConnectionSibling> secondaryRoads, List<ERConnectionSibling> siblingList, int index)
		{
			Vector3 vector = ((secondaryRoads[index].orderedIndex <= 0) ? siblingList[siblingList.Count - 1].forward : siblingList[secondaryRoads[index].orderedIndex - 1].forward);
			Vector3 to = ((secondaryRoads[index].orderedIndex >= siblingList.Count - 1) ? siblingList[0].forward : siblingList[secondaryRoads[index].orderedIndex + 1].forward);
			return Vector3.Angle(vector, to);
		}

		public static Vector3 OCQODDCOCQ(Vector3 currentPos, List<Vector3> vecs, ref int index, int startend)
		{
			index = -1;
			int num = vecs.Count - 1;
			if (startend == 0)
			{
				for (int i = 0; i < num; i++)
				{
					if (vecs[i] != Vector3.zero)
					{
						Vector3 vector = OQQOCDQCQD.OCOOQOQCDC(vecs[i], vecs[i + 1], currentPos);
						if (OOOCDOQCQC(vecs[i], vecs[i + 1], vector))
						{
							index = i;
							return vector;
						}
					}
				}
			}
			else
			{
				for (int num2 = num; num2 > 0; num2--)
				{
					if (vecs[num2] != Vector3.zero)
					{
						Vector3 vector2 = OQQOCDQCQD.OCOOQOQCDC(vecs[num2], vecs[num2 - 1], currentPos);
						if (OOOCDOQCQC(vecs[num2], vecs[num2 - 1], vector2))
						{
							index = num2 - 1;
							return vector2;
						}
					}
				}
			}
			return Vector3.zero;
		}

		public static bool OOOCDOQCQC(Vector3 p1, Vector3 p2, Vector3 v)
		{
			float num = Vector3.Distance(p1, p2);
			float num2 = Vector3.Distance(p1, v);
			float num3 = Vector3.Distance(v, p2);
			if (num2 < num && num3 < num)
			{
				return true;
			}
			return false;
		}
	}
}
