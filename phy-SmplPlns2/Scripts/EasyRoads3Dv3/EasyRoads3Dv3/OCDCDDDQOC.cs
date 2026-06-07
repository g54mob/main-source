using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[AddComponentMenu("")]
	public class OCDCDDDQOC : MonoBehaviour
	{
		[HideInInspector]
		public QDQDOOQQDQODD roadType;

		[HideInInspector]
		public double roadTypeID;

		[HideInInspector]
		public int roadTypeIndex;

		[HideInInspector]
		public int geometryType;

		[HideInInspector]
		public ERExitType exitType = ERExitType.RightExit;

		[HideInInspector]
		public float offset = 0f;

		[HideInInspector]
		public int halfwayIndex = 0;

		[HideInInspector]
		public int startSplineIndex = 0;

		[HideInInspector]
		public int endSplineIndex = 0;

		[HideInInspector]
		public Vector3 endSplinePointRight;

		[HideInInspector]
		public Vector3 endSplinePointLeft;

		[HideInInspector]
		public float startDistance = 0f;

		[HideInInspector]
		public float endDistance = 0f;

		[HideInInspector]
		public int markerIndex = 0;

		[HideInInspector]
		public int extrusionType = 0;

		[HideInInspector]
		public AnimationCurve extrusionCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

		[HideInInspector]
		public float extrusionDistance = 10f;

		[HideInInspector]
		public int startDistanceIndex = 0;

		[HideInInspector]
		public float startDecalDistance = 0f;

		[HideInInspector]
		public float fixedDistance = 5f;

		[HideInInspector]
		public int fixedDistanceIndex = 0;

		[HideInInspector]
		public float splitDistance = 5f;

		[HideInInspector]
		public AnimationCurve splitCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

		[HideInInspector]
		public float splitEndWidth = 0f;

		[HideInInspector]
		public float connectionAngle = 25f;

		[HideInInspector]
		public float connectionRadius = 10f;

		[HideInInspector]
		public ERModularRoad road;

		[HideInInspector]
		public ERCrossingPrefabs connector;

		[HideInInspector]
		public Vector3 connectionHandlePosition;

		[HideInInspector]
		public Vector3 OQCCCQCQOD;

		[HideInInspector]
		public Vector3 handleDirection;

		[HideInInspector]
		public GameObject surfaceMesh;

		[HideInInspector]
		public GameObject exitSignObject;

		[HideInInspector]
		public float exitSignObjectOffset;

		[HideInInspector]
		public GameObject exitSignObjectInstance;

		[HideInInspector]
		public GameObject exitSplitSpawnObject;

		[HideInInspector]
		public int exitSplitSpawnType = 0;

		[HideInInspector]
		public float exitSplitSpawnDistance = 1f;

		[HideInInspector]
		public float exitSplitSpawnStartOffset = 0f;

		[HideInInspector]
		public float exitSplitSpawnOffset = 0f;

		[HideInInspector]
		public float exitSplitSpawnObjectBounds;

		[HideInInspector]
		public List<GameObject> spawnedSplitObjects = new List<GameObject>();

		[HideInInspector]
		public List<Vector3> soPointsRightStart = new List<Vector3>();

		[HideInInspector]
		public int soRightSplitEndIndex = 0;

		[HideInInspector]
		public List<Vector3> soPointsLeftStart = new List<Vector3>();

		[HideInInspector]
		public int startLineMarkingDecal = 0;

		[HideInInspector]
		public bool startDecalFoldout = false;

		[HideInInspector]
		public int splitLineMarkingDecal1 = 0;

		[HideInInspector]
		public bool splitDecal1Foldout = false;

		[HideInInspector]
		public int splitLineMarkingDecal2 = 0;

		[HideInInspector]
		public bool splitDecal2Foldout = false;

		[HideInInspector]
		public List<Vector3> edgeVecs = new List<Vector3>();

		[HideInInspector]
		public List<Vector3> vecs = new List<Vector3>();

		[HideInInspector]
		public List<Vector2> uvsArray = new List<Vector2>();

		[HideInInspector]
		public List<Vector2> uvsArray2 = new List<Vector2>();

		[HideInInspector]
		public List<Color> customColors = new List<Color>();

		[HideInInspector]
		public List<Color> colors = new List<Color>();

		[HideInInspector]
		public List<int> tris = new List<int>();

		[HideInInspector]
		private int vssss = 0;

		[HideInInspector]
		private int wssst = 0;

		[HideInInspector]
		private int xssss = 0;

		[HideInInspector]
		private List<Vector3> yssst = new List<Vector3>();

		[HideInInspector]
		private List<Vector3> Assss = new List<Vector3>();

		[HideInInspector]
		private List<Vector3> _0ssst = new List<Vector3>();

		[HideInInspector]
		private List<float> _1ssss = new List<float>();

		[HideInInspector]
		private List<Vector3> _2ssst = new List<Vector3>();

		[HideInInspector]
		private Vector3 _3ssss;

		[HideInInspector]
		private float _4ssst;

		[HideInInspector]
		private float ttsss;

		[HideInInspector]
		private float utsst;

		[HideInInspector]
		private float vtsss;

		[HideInInspector]
		private int wtsst = 0;

		[HideInInspector]
		private int xtsss = 0;

		[HideInInspector]
		public List<Vector3> treeVecs = new List<Vector3>();

		[HideInInspector]
		public List<Vector3> detailVecs = new List<Vector3>();

		public static void OCOQQDDDOD(List<ERMarkerExt> markers, List<OCDCDDDQOC> exitRoads, ref List<Vector3> splinePoints, ref List<float> tValues)
		{
			int currentInt = -1;
			for (int i = 0; i < exitRoads.Count; i++)
			{
				if (exitRoads[i] == null)
				{
					exitRoads.RemoveAt(i);
					i--;
					Debug.Log("EasyRoads3Dv3 Warning: exit road is null, this exit road instance has been removed");
					continue;
				}
				OQCCDCDOCD(markers, exitRoads[i], ref splinePoints, ref tValues, currentInt);
				markers[i].exitInnerVertices.Clear();
				if (exitRoads[i].startSplineIndex != -1)
				{
					currentInt = exitRoads[i].endSplineIndex;
					continue;
				}
				Debug.LogWarning("An exit road is attached to the preious marker and overlaps the current marker, marker: " + (i + 1));
				exitRoads.RemoveAt(i);
				i--;
			}
		}

		public static void OQCCDCDOCD(List<ERMarkerExt> markers, OCDCDDDQOC exitRoad, ref List<Vector3> splinePoints, ref List<float> tValues, int currentInt)
		{
			ERMarkerExt eRMarkerExt = markers[exitRoad.markerIndex];
			float num = exitRoad.extrusionDistance + exitRoad.fixedDistance + exitRoad.splitDistance;
			float num2 = exitRoad.extrusionDistance + exitRoad.fixedDistance;
			if (exitRoad.offset < 0f && exitRoad.markerIndex == 0)
			{
				exitRoad.offset = 0.5f;
			}
			float num3 = eRMarkerExt.totalDistance * exitRoad.offset;
			float num4 = num3 - 0.5f * num;
			float num5 = 0f;
			float num6 = 0f;
			bool flag = false;
			if (num4 < 0f)
			{
				num4 *= -1f;
				for (int num7 = eRMarkerExt.startSplinePoint - 2; num7 >= 0; num7--)
				{
					num6 = Vector3.Distance(splinePoints[num7], splinePoints[num7 + 1]);
					if (num5 + num6 > num4)
					{
						float t = (num4 - num5) / num6;
						Vector3 vector = Vector3.Lerp(splinePoints[num7 + 1], splinePoints[num7], t);
						float num8;
						if (tValues[num7 + 1] < tValues[num7])
						{
							num8 = Mathf.Lerp(1f + tValues[num7 + 1], tValues[num7], t);
							if (num8 > 1f)
							{
								num8 -= 1f;
							}
						}
						else
						{
							num8 = Mathf.Lerp(tValues[num7 + 1], tValues[num7], t);
						}
						float num9 = Vector3.Distance(splinePoints[num7], vector);
						if ((double)num9 < 0.25)
						{
							splinePoints[num7] = vector;
							tValues[num7] = num8;
							exitRoad.startSplineIndex = num7;
						}
						else
						{
							num9 = Vector3.Distance(splinePoints[num7 + 1], vector);
							if ((double)num9 < 0.25)
							{
								splinePoints[num7 + 1] = vector;
								tValues[num7 + 1] = num8;
							}
							else
							{
								splinePoints.Insert(num7 + 1, vector);
								tValues.Insert(num7 + 1, num8);
							}
							exitRoad.startSplineIndex = num7 + 1;
						}
						flag = true;
						break;
					}
					if (num7 <= currentInt)
					{
						exitRoad.startSplineIndex = -1;
						Debug.LogWarning("The start offset overlaps the previous exit lane!");
						return;
					}
					num5 += num6;
				}
				if (!flag)
				{
					exitRoad.startSplineIndex = -1;
				}
			}
			else if (num4 > 0f)
			{
				flag = false;
				int num10 = eRMarkerExt.startSplinePoint - 1;
				if (num10 < 0)
				{
					num10 = 0;
				}
				for (int i = num10; i < splinePoints.Count - 1; i++)
				{
					num6 = Vector3.Distance(splinePoints[i], splinePoints[i + 1]);
					if (num5 + num6 > num4)
					{
						float t2 = (num4 - num5) / num6;
						Vector3 vector = Vector3.Lerp(splinePoints[i], splinePoints[i + 1], t2);
						float num8 = Mathf.Lerp(tValues[i], tValues[i + 1], t2);
						if (tValues[i + 1] < tValues[i])
						{
							num8 = Mathf.Lerp(tValues[i], 1f + tValues[i + 1], t2);
							if (num8 > 1f)
							{
								num8 -= 1f;
							}
						}
						else
						{
							num8 = Mathf.Lerp(tValues[i], tValues[i + 1], t2);
						}
						float num11 = Vector3.Distance(splinePoints[i], vector);
						if ((double)num11 < 0.25)
						{
							splinePoints[i] = vector;
							tValues[i] = num8;
							exitRoad.startSplineIndex = i;
						}
						else
						{
							num11 = Vector3.Distance(splinePoints[i + 1], vector);
							if ((double)num11 < 0.25)
							{
								splinePoints[i + 1] = vector;
								tValues[i + 1] = num8;
							}
							else
							{
								splinePoints.Insert(i + 1, vector);
								tValues.Insert(i + 1, num8);
							}
							exitRoad.startSplineIndex = i + 1;
						}
						flag = true;
						if (exitRoad.startSplineIndex <= currentInt)
						{
							exitRoad.startSplineIndex = 1;
							Debug.LogWarning("The start offset overlaps the previous exit lane!");
							return;
						}
						break;
					}
					num5 += num6;
				}
			}
			else
			{
				eRMarkerExt.startExitInt = eRMarkerExt.startSplinePoint - 1;
				exitRoad.startSplineIndex = eRMarkerExt.startSplinePoint - 1;
				flag = true;
			}
			if (!flag)
			{
				exitRoad.startSplineIndex = 1;
				Debug.LogWarning("The start offset extends the road length!");
			}
			num5 = 0f;
			flag = false;
			bool flag2 = false;
			bool flag3 = false;
			int num12 = 0;
			for (int j = exitRoad.startSplineIndex; j < splinePoints.Count - 1; j++)
			{
				num6 = Vector3.Distance(splinePoints[j], splinePoints[j + 1]);
				if (!flag2 && num5 + num6 > exitRoad.extrusionDistance)
				{
					if (num5 + num6 - exitRoad.extrusionDistance > 1f)
					{
						if (exitRoad.extrusionDistance - num5 > 1f)
						{
							Vector3 normalized = (splinePoints[j + 1] - splinePoints[j]).normalized;
							float num13 = exitRoad.extrusionDistance - num5;
							Vector3 vector = splinePoints[j] + normalized * num13;
							splinePoints.Insert(j + 1, splinePoints[j] + normalized * num13);
							float num14 = tValues[j + 1];
							if (num14 < tValues[j])
							{
								num14 += 1f;
							}
							tValues.Insert(j + 1, Mathf.Lerp(tValues[j], num14, num13 / num6));
							exitRoad.startDistanceIndex = j + 1;
						}
						else
						{
							exitRoad.startDistanceIndex = j;
						}
					}
					else
					{
						exitRoad.startDistanceIndex = j + 1;
					}
					if (exitRoad.fixedDistance == 0f)
					{
						exitRoad.fixedDistanceIndex = exitRoad.startDistanceIndex;
						flag3 = true;
					}
					flag2 = true;
					num6 = Vector3.Distance(splinePoints[j], splinePoints[j + 1]);
				}
				if (!flag3 && flag2 && num5 + num6 > num2)
				{
					if (num5 + num6 - num2 > 1f)
					{
						if (num2 - num5 > 1f)
						{
							Vector3 normalized2 = (splinePoints[j + 1] - splinePoints[j]).normalized;
							float num15 = num2 - num5;
							Vector3 vector = splinePoints[j] + normalized2 * num15;
							splinePoints.Insert(j + 1, splinePoints[j] + normalized2 * num15);
							float num16 = tValues[j + 1];
							if (num16 < tValues[j])
							{
								num16 += 1f;
							}
							tValues.Insert(j + 1, Mathf.Lerp(tValues[j], num16, num15 / num6));
							exitRoad.fixedDistanceIndex = j + 1;
						}
						else
						{
							exitRoad.fixedDistanceIndex = j;
						}
					}
					else
					{
						exitRoad.fixedDistanceIndex = j + 1;
					}
					num6 = Vector3.Distance(splinePoints[j], splinePoints[j + 1]);
					flag3 = true;
				}
				num12++;
				if (num5 + num6 > num)
				{
					float t3 = (num - num5) / num6;
					Vector3 vector = Vector3.Lerp(splinePoints[j], splinePoints[j + 1], t3);
					float num8;
					if (tValues[j + 1] < tValues[j])
					{
						num8 = Mathf.Lerp(tValues[j], 1f + tValues[j + 1], t3);
						if (num8 > 1f)
						{
							num8 -= 1f;
						}
					}
					else
					{
						num8 = Mathf.Lerp(tValues[j], tValues[j + 1], t3);
					}
					float num17 = Vector3.Distance(splinePoints[j], vector);
					if ((double)num17 < 0.25)
					{
						splinePoints[j] = vector;
						tValues[j] = num8;
						exitRoad.endSplineIndex = j;
					}
					else
					{
						num17 = Vector3.Distance(splinePoints[j + 1], vector);
						if ((double)num17 < 0.25)
						{
							splinePoints[j + 1] = vector;
							tValues[j + 1] = num8;
						}
						else
						{
							splinePoints.Insert(j + 1, vector);
							tValues.Insert(j + 1, num8);
						}
						exitRoad.endSplineIndex = j + 1;
					}
					flag = true;
					break;
				}
				num5 += num6;
			}
			if (!flag)
			{
				exitRoad.endSplineIndex = splinePoints.Count - 2;
			}
		}

		public static void OQCQOQQOOQ(ERModularBase baseScript, ERModularRoad road, List<OCDCDDDQOC> exitRoads, List<ERMarkerExt> markers, ref List<Vector3> soSplinePointsLeft, ref List<Vector3> soSplinePointsRight, ref bool hasExits, List<float> leftIndentFloats, List<float> rightIndentFloats, List<float> leftSurroundingFloats, List<float> rightSurroundingFloats, ref List<Vector3> surfaceVecs)
		{
			for (int i = 0; i < exitRoads.Count; i++)
			{
				OCOOCQQQDC(baseScript, road, exitRoads[i], ref soSplinePointsLeft, ref soSplinePointsRight, leftIndentFloats, rightIndentFloats, leftSurroundingFloats, rightSurroundingFloats, ref surfaceVecs);
				hasExits = true;
				if (exitRoads[i].connector != null && exitRoads[i].connector.crossingElements.Count > 0 && exitRoads[i].connector.crossingElements[0].connectedRoad != null)
				{
					exitRoads[i].connector.crossingElements[0].connectedRoad.ODDDQDQOOD(ignorePrefabAlignment: true, forceAutoRotate: false);
				}
			}
		}

		public static void OCOOCQQQDC(ERModularBase baseScript, ERModularRoad road, OCDCDDDQOC exitRoad, ref List<Vector3> soSplinePointsLeft, ref List<Vector3> soSplinePointsRight, List<float> leftIndentFloats, List<float> rightIndentFloats, List<float> leftSurroundingFloats, List<float> rightSurroundingFloats, ref List<Vector3> roadSurfaceVecs)
		{
			Debug.Log("To Do: optional and necessary for two lane ramps. add vec twice at right outerlane index. instead of calculating uvs from right to left according shape, calculate from left (start value) to right over distance, that way the middle lane will be in the center");
			List<List<Vector3>> list = new List<List<Vector3>>();
			List<List<Vector2>> list2 = new List<List<Vector2>>();
			List<List<Vector2>> list3 = new List<List<Vector2>>();
			exitRoad.yssst.Clear();
			List<Vector3> list4 = exitRoad.yssst;
			exitRoad._0ssst.Clear();
			List<Vector3> list5 = exitRoad._0ssst;
			exitRoad._1ssss.Clear();
			List<float> list6 = exitRoad._1ssss;
			List<Vector2> list7 = new List<Vector2>();
			exitRoad._2ssst.Clear();
			List<Vector3> list8 = exitRoad._2ssst;
			exitRoad.Assss.Clear();
			List<Vector3> assss = exitRoad.Assss;
			List<List<Vector3>> list9 = new List<List<Vector3>>();
			List<List<Vector2>> list10 = new List<List<Vector2>>();
			List<List<Vector2>> list11 = new List<List<Vector2>>();
			List<List<Vector3>> list12 = new List<List<Vector3>>();
			List<List<Vector2>> list13 = new List<List<Vector2>>();
			List<List<Vector2>> list14 = new List<List<Vector2>>();
			List<List<Vector3>> list15 = new List<List<Vector3>>();
			List<List<Vector2>> list16 = new List<List<Vector2>>();
			List<List<Vector2>> list17 = new List<List<Vector2>>();
			exitRoad.vecs.Clear();
			exitRoad.uvsArray.Clear();
			exitRoad.uvsArray2.Clear();
			exitRoad.customColors.Clear();
			exitRoad.colors.Clear();
			exitRoad.tris.Clear();
			exitRoad.treeVecs.Clear();
			exitRoad.detailVecs.Clear();
			List<Vector3> list18 = exitRoad.vecs;
			List<Vector2> list19 = exitRoad.uvsArray;
			List<Vector2> list20 = exitRoad.uvsArray2;
			List<Color> list21 = exitRoad.customColors;
			List<Color> collection = exitRoad.colors;
			List<int> Assss = exitRoad.tris;
			List<Vector3> list22 = new List<Vector3>();
			List<Vector2> list23 = new List<Vector2>();
			int num = 0;
			Material material = null;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			exitRoad.vssss = 0;
			exitRoad.wssst = 0;
			int num6 = 0;
			List<bool> hardEdge = new List<bool>();
			List<Vector2> roadShapeVecs = new List<Vector2>();
			int rightOuterIndex = exitRoad.roadType.roadShapeData.outerLaneMarkingRightIndex;
			exitRoad._4ssst = 5f;
			float num7 = 5f;
			List<float> roadShapeUVs = new List<float>();
			float num8 = 0f;
			exitRoad.edgeVecs.Clear();
			List<int> list24 = new List<int>();
			List<float> list25 = new List<float>();
			list25.Add(0f);
			List<float> list26 = new List<float>();
			List<Vector3> list27 = new List<Vector3>();
			List<Vector3> list28 = new List<Vector3>(soSplinePointsRight);
			float num9 = 5f;
			float num10 = 0f;
			float num11 = (exitRoad.utsst = 0f);
			float num12 = (exitRoad.vtsss = 0f);
			if (exitRoad.roadType != null)
			{
				exitRoad.roadType = QDQDOOQQDQODD.GetRoadTypeElByID(baseScript.roadTypes, exitRoad.roadType.id);
				material = exitRoad.roadType.roadMaterial;
				num9 = exitRoad.roadType.roadWidth;
				ODDOQDDQCQ.ODCQCCCDOC(exitRoad.roadType, ref roadShapeVecs, ref roadShapeUVs, ref hardEdge, ref rightOuterIndex);
				num7 = (exitRoad._4ssst = exitRoad.roadType.roadWidth * exitRoad.roadType.uvTiling);
				num8 = roadShapeUVs[exitRoad.roadType.roadShapeData.outerOuterLaneMarkingLeftIndex];
				num11 = (exitRoad.utsst = roadShapeVecs[exitRoad.roadType.roadShapeData.outerOuterLaneMarkingLeftIndex].y);
				num10 = exitRoad.roadType.roadShapeData.nodes[exitRoad.roadType.roadShapeData.nodes.Count - 1].x - exitRoad.roadType.roadShapeData.nodes[exitRoad.roadType.roadShapeData.outerOuterLaneMarkingLeftIndex].x;
				for (int i = 0; i < roadShapeVecs.Count; i++)
				{
					list.Add(new List<Vector3>());
					list2.Add(new List<Vector2>());
					list3.Add(new List<Vector2>());
					list9.Add(new List<Vector3>());
					list10.Add(new List<Vector2>());
					list11.Add(new List<Vector2>());
					list12.Add(new List<Vector3>());
					list13.Add(new List<Vector2>());
					list14.Add(new List<Vector2>());
					list26.Add(roadShapeVecs[roadShapeVecs.Count - 1].x - roadShapeVecs[i].x);
					if (hardEdge[i])
					{
						num6++;
					}
				}
				int num13 = exitRoad.roadType.roadShapeData.outerOuterLaneMarkingLeftIndex;
				if (num13 == -1)
				{
					num13 = 0;
				}
				List<ERDecal> list29 = ERDecal.FilterByType(exitRoad.roadType.decalPresets, ERDecalType.MotorwayRampLineMarking);
				float num14 = road.rt.roadShapeData.nodes[road.rt.roadShapeData.nodes.Count - 1].x - road.rt.roadShapeData.nodes[road.rt.roadShapeData.outerLaneMarkingRightIndex].x;
				float num15 = num14;
				num14 = 0f;
				float num16 = -1f * (road.rt.roadShapeData.nodes[0].x - road.rt.roadShapeData.nodes[road.rt.roadShapeData.outerLaneMarkingLeftIndex].x) + num14;
				num16 += exitRoad.splitEndWidth;
				float num17 = 0f;
				exitRoad.ttsss = 0f;
				if (road.rt.roadShapeData.outerLaneMarkingRightIndex != -1 && road.rt.roadShapeData.outerLaneMarkingRightIndex < road.rt.roadShapeData.nodes.Count)
				{
					exitRoad.ttsss = road.rt.roadShapeData.nodes[road.rt.roadShapeData.outerOuterLaneMarkingRightIndex].x - road.rt.roadShapeData.nodes[road.rt.roadShapeData.outerLaneMarkingRightIndex].x;
				}
				float num18 = exitRoad.ttsss;
				List<Vector3> list30 = new List<Vector3>();
				List<int> list31 = new List<int>();
				float num19 = 0f;
				float num21;
				float num20 = (num21 = 0f);
				bool flag = false;
				bool flag2 = false;
				if (exitRoad.fixedDistance == 0f)
				{
					flag2 = true;
				}
				Vector3 zero = Vector3.zero;
				Vector3 normalized = (soSplinePointsRight[exitRoad.startSplineIndex + 1] - soSplinePointsRight[exitRoad.startSplineIndex]).normalized;
				Vector3 vector = soSplinePointsRight[exitRoad.startSplineIndex - 1];
				float num22 = 0f;
				float num23 = 1f;
				float num24 = 1f;
				float num25 = 0f;
				if (exitRoad.extrusionType == 0)
				{
					num24 = exitRoad.extrusionDistance / num23;
				}
				Vector3 vector2 = soSplinePointsRight[exitRoad.startSplineIndex - 1];
				Vector3 normalized2 = (soSplinePointsRight[exitRoad.startSplineIndex] - soSplinePointsLeft[exitRoad.startSplineIndex]).normalized;
				list4.Add(soSplinePointsRight[exitRoad.startSplineIndex] - normalized2 * num14);
				list5.Add(list4[0] + normalized2 * num18);
				exitRoad.edgeVecs.Add(soSplinePointsRight[exitRoad.startSplineIndex] + normalized2 * num15);
				exitRoad.treeVecs.Add(list4[0]);
				exitRoad.treeVecs.Add(exitRoad.edgeVecs[0] + normalized2 * baseScript.treeDistance);
				exitRoad.detailVecs.Add(list4[0]);
				exitRoad.detailVecs.Add(exitRoad.edgeVecs[0] + normalized2 * baseScript.detailDistance - baseScript.detailOffsetVec);
				assss.Add(list4[0]);
				Vector3 vector3;
				if (exitRoad.road.terrainDeformation)
				{
					int num26 = exitRoad.startSplineIndex;
					if (num26 > 0)
					{
						num26--;
					}
					vector3 = soSplinePointsRight[num26];
					list22.Add(vector3);
					list23.Add(new Vector2(0f, 1f));
					Vector3 pos;
					if (exitRoad.road.doRightSurrounding[exitRoad.startSplineIndex])
					{
						pos = vector3 + normalized2 * rightIndentFloats[num26];
					}
					else
					{
						pos = vector3;
						road.baseScript.OQCCDQOQOO(ref pos);
						if (!(pos.y < vector3.y))
						{
							pos = vector3 + normalized2 * rightIndentFloats[num26];
						}
					}
					list22.Add(pos);
					list23.Add(new Vector2(0f, 1f));
					pos += normalized2 * rightSurroundingFloats[num26];
					road.baseScript.OQCCDQOQOO(ref pos);
					list22.Add(pos);
					list23.Add(new Vector2(0f, 0f));
				}
				float num27 = (exitRoad.extrusionDistance + exitRoad.fixedDistance + exitRoad.splitDistance) * 0.5f;
				float num28 = exitRoad.extrusionDistance + exitRoad.fixedDistance;
				bool flag3 = false;
				exitRoad.endSplinePointRight = exitRoad.road.soSplinePointsRight[exitRoad.endSplineIndex - 1];
				exitRoad.endSplinePointLeft = exitRoad.road.soSplinePointsLeft[exitRoad.endSplineIndex - 1];
				exitRoad.soPointsRightStart.Clear();
				exitRoad.soPointsLeftStart.Clear();
				int num29 = -1;
				bool flag4 = false;
				for (int j = exitRoad.startSplineIndex; j < exitRoad.endSplineIndex; j++)
				{
					flag4 = exitRoad.road.doRightSurrounding[j];
					exitRoad.road.doRightSurrounding[j] = false;
					normalized2 = (soSplinePointsRight[j + 1] - soSplinePointsLeft[j + 1]).normalized;
					num19 += Vector3.Distance(list28[j], list28[j + 1]);
					Vector3 vector4 = soSplinePointsRight[j + 1] - normalized2 * num14;
					list4.Add(vector4);
					if (!flag)
					{
						float num30 = num19 / exitRoad.extrusionDistance;
						if (exitRoad.extrusionType == 0)
						{
							num20 = num30 * (num10 - num14);
							if (num20 > num10 - num14)
							{
								num20 = num10 - num14;
							}
						}
						else
						{
							num20 = Mathf.SmoothStep(0f, num10 - num14 - num18, num19 / exitRoad.extrusionDistance);
							if (num20 > num10)
							{
								num20 = num10 - num14;
							}
							num25 += 1f;
						}
						num30 = exitRoad.extrusionCurve.Evaluate(num30);
						num20 = Mathf.Lerp(0f, num10 - num15 + num18, num30);
						float num31 = Mathf.Lerp(0f, num18, num30);
						float num32 = Mathf.SmoothStep(0f, 1f, num19 / exitRoad.extrusionDistance);
						num21 = Mathf.Lerp(0f, num10, num32 * num32);
						vector3 = soSplinePointsRight[exitRoad.startSplineIndex] + normalized * num32 * num32 * exitRoad.extrusionDistance;
						vector3 += normalized2 * num21;
						list25.Add(num20 + num31);
						vector3 = (zero = soSplinePointsRight[j + 1] + normalized2 * (num20 + num17 + num15));
						exitRoad.edgeVecs.Add(vector3);
						list5.Add(vector4 + normalized2 * (num17 + num18));
						assss.Add(Vector3.zero);
						exitRoad.treeVecs.Add(vector4);
						exitRoad.treeVecs.Add(vector3 + normalized2 * baseScript.treeDistance);
						exitRoad.detailVecs.Add(vector4);
						exitRoad.detailVecs.Add(vector3 + normalized2 * baseScript.detailDistance - baseScript.detailOffsetVec);
						Vector3 vector5 = vector3 - vector;
						vector5 = new Vector3(vector5.z, 0f, 0f - vector5.x);
						vector = vector3;
					}
					else if (!flag2)
					{
						vector3 = (zero = soSplinePointsRight[j + 1] + normalized2 * (num10 - num14 + num18));
						exitRoad.edgeVecs.Add(vector3);
						list5.Add(vector4 + normalized2 * (num17 + num18));
						assss.Add(vector4 + normalized2 * num18);
						list24.Add(exitRoad.edgeVecs.Count - 1);
						if (j + 1 == exitRoad.fixedDistanceIndex || num19 > exitRoad.extrusionDistance + exitRoad.fixedDistance)
						{
							flag2 = true;
							exitRoad.road.exitFixedEnd = exitRoad.edgeVecs[exitRoad.edgeVecs.Count - 1];
							num3 = exitRoad.edgeVecs.Count - 1;
							exitRoad.vssss = list4.Count - 1;
						}
						exitRoad.treeVecs.Add(vector4);
						exitRoad.treeVecs.Add(vector3 + normalized2 * baseScript.treeDistance);
						exitRoad.detailVecs.Add(vector4);
						exitRoad.detailVecs.Add(vector3 + normalized2 * baseScript.detailDistance - baseScript.detailOffsetVec);
					}
					else
					{
						float time = (num19 - exitRoad.fixedDistance - exitRoad.extrusionDistance) / exitRoad.splitDistance;
						time = exitRoad.splitCurve.Evaluate(time);
						num17 = num16 * time;
						vector3 = (zero = soSplinePointsRight[j + 1] + normalized2 * (0f - num14 + num17));
						list5.Add(vector3);
						assss.Add(vector3 + normalized2 * (0f - num17));
						Vector3 vector6 = vector3 - list5[list5.Count - 2];
						vector6 = new Vector3(vector6.z, 0f, 0f - vector6.x).normalized;
						vector3 += vector6 * num10;
						vector3.y = OQQOCDQCQD.OQOOCCQQOQ(zero, list5[list5.Count - 2], soSplinePointsLeft[j + 1], vector3);
						exitRoad.edgeVecs.Add(vector3);
						list24.Add(exitRoad.edgeVecs.Count - 1);
						exitRoad.treeVecs.Add(vector4);
						exitRoad.treeVecs.Add(vector3 + normalized2 * baseScript.treeDistance);
						exitRoad.detailVecs.Add(vector4);
						exitRoad.detailVecs.Add(vector3 + normalized2 * baseScript.detailDistance - baseScript.detailOffsetVec);
					}
					num++;
					if (exitRoad.road.terrainDeformation)
					{
						list22.Add(list5[list5.Count - 1]);
						normalized2 = (exitRoad.edgeVecs[exitRoad.edgeVecs.Count - 1] - list5[list5.Count - 1]).normalized;
						list23.Add(new Vector2(0f, 1f));
						Vector3 pos;
						if (flag4)
						{
							pos = vector3 + normalized2 * rightIndentFloats[j];
						}
						else
						{
							pos = vector3;
							road.baseScript.OQCCDQOQOO(ref pos);
							if (!(pos.y < vector3.y))
							{
								pos = vector3 + normalized2 * rightIndentFloats[j];
							}
						}
						list22.Add(pos);
						list23.Add(new Vector2(0f, 1f));
						pos += normalized2 * rightSurroundingFloats[j];
						road.baseScript.OQCCDQOQOO(ref pos);
						list22.Add(pos);
						list23.Add(new Vector2(0f, 0f));
					}
					if ((j + 1 == exitRoad.startDistanceIndex || num19 > exitRoad.extrusionDistance) && !flag)
					{
						flag = true;
						exitRoad.road.exitExtrudeEnd = exitRoad.edgeVecs[exitRoad.edgeVecs.Count - 1];
						num2 = exitRoad.edgeVecs.Count - 1;
						num5 = list4.Count - 1;
						bool flag5 = true;
						float num33 = exitRoad.extrusionCurve.Evaluate(0.25f);
						if ((double)num33 > 0.24 && (double)num33 < 0.26)
						{
							num33 = exitRoad.extrusionCurve.Evaluate(0.75f);
							if ((double)num33 > 0.74 && (double)num33 < 0.76)
							{
								flag5 = false;
							}
						}
						if (flag5)
						{
							List<Vector3> tmpvecs = new List<Vector3>();
							tmpvecs.Add(exitRoad.edgeVecs[0]);
							list24.Add(0);
							float num34 = 1f;
							float angleThreshold = 2f;
							if (num34 == 2f)
							{
								angleThreshold = 6f;
							}
							else if (num34 == 3f)
							{
								angleThreshold = 10f;
							}
							Vector3 normalized3 = (list28[exitRoad.startSplineIndex - 1] - list28[exitRoad.startSplineIndex]).normalized;
							float num35 = Vector3.Distance(list28[exitRoad.startSplineIndex], list28[exitRoad.startSplineIndex + 1]);
							vector2 = list28[exitRoad.startSplineIndex] + normalized3 * num35;
							ODQDQQDDOD(j, 0, vector2, exitRoad.edgeVecs, soSplinePointsRight, angleThreshold, ref tmpvecs);
							tmpvecs.Add(exitRoad.edgeVecs[1]);
							list24.Add(tmpvecs.Count - 1);
							vector2 = exitRoad.edgeVecs[0];
							for (int k = 1; k < exitRoad.edgeVecs.Count - 1; k++)
							{
								ODQDQQDDOD(j, k, vector2, exitRoad.edgeVecs, soSplinePointsRight, angleThreshold, ref tmpvecs);
								tmpvecs.Add(exitRoad.edgeVecs[k + 1]);
								list24.Add(tmpvecs.Count - 1);
								vector2 = exitRoad.edgeVecs[k];
							}
							exitRoad.edgeVecs = tmpvecs;
						}
						else
						{
							for (int l = 0; l < exitRoad.edgeVecs.Count - 1; l++)
							{
								list24.Add(l);
							}
						}
						if (exitRoad.fixedDistance == 0f)
						{
							flag2 = true;
							exitRoad.road.exitFixedEnd = exitRoad.edgeVecs[exitRoad.edgeVecs.Count - 1];
							num3 = exitRoad.edgeVecs.Count - 1;
							exitRoad.vssss = list4.Count - 1;
						}
					}
					if (num19 > num27 && !flag3)
					{
						float num36 = num19 - num27;
						Vector3 normalized4 = (soSplinePointsRight[j + 1] - soSplinePointsRight[j]).normalized;
						exitRoad.OQCCCQCQOD = soSplinePointsRight[j + 1] - normalized4 * num36;
						exitRoad.OQCCCQCQOD += normalized2 * (0.5f * num20);
						exitRoad.handleDirection = normalized4;
						flag3 = true;
					}
					exitRoad.soPointsRightStart.Add(exitRoad.edgeVecs[exitRoad.edgeVecs.Count - 1]);
				}
				if (exitRoad.fixedDistance == 0f)
				{
				}
				int num37 = exitRoad.edgeVecs.Count - 1;
				float num38 = Vector3.Distance(exitRoad.edgeVecs[num37], exitRoad.edgeVecs[num37 - 1]);
				Vector3 normalized5 = (exitRoad.edgeVecs[num37 - 1] - exitRoad.edgeVecs[num37 - 2]).normalized;
				exitRoad.edgeVecs[exitRoad.edgeVecs.Count - 1] = exitRoad.edgeVecs[num37 - 1] + normalized5 * num38;
				exitRoad.soRightSplitEndIndex = exitRoad.soPointsRightStart.Count - 1;
				exitRoad.road.debugVecs.AddRange(list5);
				exitRoad.road.exitSplitEnd = exitRoad.edgeVecs[exitRoad.edgeVecs.Count - 1];
				num4 = exitRoad.edgeVecs.Count - 1;
				exitRoad.wssst = list4.Count - 1;
				float num39 = 0f;
				float num40 = 0f;
				float num41 = 0f;
				int num42 = 0;
				Vector3 vector7 = list4[0];
				Vector3 vector8 = list4[1];
				Vector3 vector9 = list4[1];
				float num43 = 0f + num41;
				float num44 = 0f + num41;
				float num45 = Vector3.Distance(vector7, vector8);
				num40 = num45;
				Vector3 normalized6 = (list4[0] - exitRoad.edgeVecs[0]).normalized;
				float num46 = 0f;
				float b = num45 / num7;
				list6.Add(num46);
				if (list4.Count > 1)
				{
					num40 = Vector3.Distance(list4[0], list4[2]);
					b = num19 / num7;
					vector8 = list4[2];
				}
				bool flag6 = false;
				for (int m = 0; m < exitRoad.edgeVecs.Count; m++)
				{
					if (list24[num42 + 1] <= m && list4.Count > num42 + 2)
					{
						num42++;
						vector7 = list5[num42];
						num39 += Vector3.Distance(list5[num42 - 1], list5[num42]);
						num46 = num39 / num7;
						list6.Add(num46);
						vector8 = ((list5.Count <= num42 + 2) ? list5[num42 + 1] : list5[num42 + 2]);
						num19 = Vector3.Distance(vector7, vector8);
						num40 = num19;
						b = (num39 + num40) / num7;
						normalized6 = (vector7 - exitRoad.edgeVecs[m]).normalized;
					}
					if (m == 0)
					{
						normalized2 = (list4[0] - exitRoad.edgeVecs[0]).normalized;
					}
					else if (m == exitRoad.edgeVecs.Count - 1)
					{
						normalized2 = exitRoad.edgeVecs[m] - exitRoad.edgeVecs[m - 1];
						normalized2 = new Vector3(0f - normalized2.z, 0f, normalized2.x).normalized;
					}
					else
					{
						normalized2 = exitRoad.edgeVecs[m + 1] - exitRoad.edgeVecs[m - 1];
						normalized2 = new Vector3(0f - normalized2.z, 0f, normalized2.x).normalized;
					}
					int num47 = list.Count - 1;
					int num48 = -1;
					int num49 = list.Count - 1;
					for (int n = num47; n < list.Count && n >= 0; n += num48)
					{
						if (num42 < list25.Count)
						{
							if (n < rightOuterIndex)
							{
								if ((list26[n] >= list25[num42] && !flag6) || n < num13)
								{
									vector3 = Vector3.zero;
								}
								else
								{
									vector3 = exitRoad.edgeVecs[m] + normalized6 * list26[n];
									if (m != 0)
									{
										vector3.y += num12 + roadShapeVecs[n].y;
									}
								}
							}
							else
							{
								vector3 = exitRoad.edgeVecs[m];
								if (n < num49)
								{
									vector3 = exitRoad.edgeVecs[m] + normalized2 * list26[n];
								}
								if (m != 0)
								{
									vector3.y += num12 + roadShapeVecs[n].y;
								}
								if (n == rightOuterIndex)
								{
									list8.Add(vector3);
								}
							}
							Vector3 b2 = OQQOCDQCQD.OCOOQOQCDC(vector7, vector8, vector3);
							float num50 = Vector3.Distance(vector7, b2);
							float y = Mathf.Lerp(num46, b, num50 / num19);
							list9[n].Add(vector3);
							list10[n].Add(new Vector2(roadShapeUVs[n], y));
							list11[n].Add(Vector2.zero);
						}
						else
						{
							if ((list26[n] >= num10 && !flag6) || n < num13)
							{
								list9[n].Add(Vector3.zero);
								list10[n].Add(Vector2.zero);
								list11[n].Add(Vector2.zero);
							}
							else
							{
								vector3 = exitRoad.edgeVecs[m] + normalized6 * list26[n];
								vector3.y += num12 + roadShapeVecs[n].y;
								Vector3 b3 = OQQOCDQCQD.OCOOQOQCDC(vector7, vector8, vector3);
								float num51 = Vector3.Distance(vector7, b3);
								float y2 = Mathf.Lerp(num46, b, num51 / num19);
								list9[n].Add(vector3);
								list10[n].Add(new Vector2(roadShapeUVs[n], y2));
								list11[n].Add(Vector2.zero);
							}
							if (n == num13 && m == exitRoad.edgeVecs.Count - 1)
							{
								vector3 = exitRoad.edgeVecs[m] + normalized6 * list26[n];
								vector3.y += num12 + roadShapeVecs[n].y;
								list5[list5.Count - 1] = vector3;
							}
						}
					}
				}
				if (list6.Count < list5.Count)
				{
					num39 += Vector3.Distance(list5[list5.Count - 1], list5[list5.Count - 2]);
					num46 = num39 / num7;
					list6.Add(num46);
				}
				int count = list9.Count;
				int num52 = 0;
				int num53 = 0;
				int num54 = 0;
				int tssss = 0;
				int num55 = 0;
				num42 = 0;
				bool flag7 = true;
				bool flag8 = false;
				List<int> list32 = new List<int>();
				for (int num56 = 0; num56 < list9[0].Count; num56++)
				{
					if (list24[num42 + 1] <= num56)
					{
						if (list4.Count > num42 + 1)
						{
							num42++;
							num55 = list18.Count;
							flag7 = true;
						}
					}
					else if (num56 != 0)
					{
						flag7 = false;
					}
					flag8 = false;
					num54 = 0;
					for (int num57 = 0; num57 < count; num57++)
					{
						list18.Add(list9[num57][num56]);
						list19.Add(list10[num57][num56]);
						if (!flag8 && list9[num57][num56] != Vector3.zero)
						{
							list32.Add(list18.Count - 1);
							flag8 = true;
						}
						if (hardEdge.Count > num57 && hardEdge[num57])
						{
							list18.Add(list9[num57][num56]);
							list19.Add(list10[num57][num56]);
							num54++;
						}
						if (num57 < count - 1 && num56 != 0)
						{
							int num58 = num52 + num57 + num54 + num6;
							int num59 = num52 + num57 + num54 + 1 + num6;
							int num60 = num52 + num57 + num54 + count + num6;
							int item = num52 + num57 + num54 + count + 1 + num6;
							if (list18[num58] != Vector3.zero && list18[num59] != Vector3.zero && list18[num60] != Vector3.zero)
							{
								Assss.Add(num58);
								Assss.Add(num60);
								Assss.Add(num59);
								Assss.Add(num59);
								Assss.Add(num60);
								Assss.Add(item);
							}
						}
					}
					num52 = num56 * (count + num6);
					if (flag7)
					{
						vector3 = list5[num42];
						vector3.y += num11;
						list18[num55] = vector3;
						Vector2 value = list19[list19.Count - 1];
						value.x = num8;
						list19[num55] = value;
						ussst(tssss, num55, 0, list32.Count - 1, list32, list18, ref Assss);
						int num58 = list32[list32.Count - 1];
						list32.Clear();
						list32.Add(num58);
						tssss = num55;
					}
				}
				exitRoad.xssss = list18.Count - (count + num6);
				int num61 = count + num6;
				int count2 = list18.Count;
				Vector3 vector10 = list18[list18.Count - num61 + num13];
				int num62 = list18.Count - 1;
				Debug.Log("Check point in case of triangulation errors at end split!!!!!!!");
				vector3 = list9[list9.Count - 1][list9[list9.Count - 1].Count - 1];
				zero = list9[list9.Count - 1][list9[list9.Count - 1].Count - 2];
				Vector3 vector11 = road.soSplinePointsRight[exitRoad.endSplineIndex];
				if (exitRoad.endSplineIndex + 1 < road.soSplinePointsRight.Count)
				{
					Vector3 vector12 = road.soSplinePointsRight[exitRoad.endSplineIndex + 1];
				}
				else
				{
					Vector3 vector12 = road.soSplinePointsRight[exitRoad.endSplineIndex - 1];
				}
				Vector3 vector13 = road.soSplinePoints[exitRoad.endSplineIndex];
				float num63 = exitRoad.connectionAngle;
				float num64 = exitRoad.connectionRadius;
				int num65 = exitRoad.markerIndex + 1;
				float num66 = Vector3.Distance(road.soSplinePoints[exitRoad.endSplineIndex], road.markersExt[num65].position);
				if (num66 < exitRoad.connectionRadius)
				{
					num65++;
				}
				if (OQQOCDQCQD.OOCQODQDQD(road.soSplinePoints[exitRoad.endSplineIndex], road.soSplinePoints[exitRoad.endSplineIndex - 1], road.markersExt[num65].position))
				{
					Vector3 vector14 = road.soSplinePoints[exitRoad.endSplineIndex - 1] - road.soSplinePoints[exitRoad.endSplineIndex];
					Vector3 to = road.markersExt[num65].position - road.soSplinePoints[exitRoad.endSplineIndex];
					float num67 = 180f - Vector3.Angle(vector14, to);
					if (num67 > num63)
					{
						float num68 = num63;
						num63 += num67;
						num64 *= num68 / num63;
					}
				}
				if (num64 < num9 + 1f)
				{
					num64 = num9 + 1f;
				}
				normalized2 = (vector3 - zero).normalized;
				normalized2 = new Vector3(normalized2.z, 0f, 0f - normalized2.x).normalized;
				Vector3 vector15 = vector3 + normalized2 * num64;
				float num69 = 2f;
				float num70 = (float)Mathf.RoundToInt(2f * num64 * MathF.PI) * (num63 / 360f);
				int num71 = Mathf.RoundToInt(Mathf.Floor(num70 / num69));
				float num72 = num63 / ((float)num71 * 1f);
				float num73 = (float)Mathf.RoundToInt(2f * (num64 + list26[0] * 0.5f) * MathF.PI) * (num63 / 360f);
				float num74 = num73 / ((float)num71 * 1f);
				float num75 = num74 / num7;
				float num76 = Mathf.Abs(Vector3.Angle(vector3 - vector15, zero - vector15));
				if (num76 != 0f && !OQQOCDQCQD.OOCQODQDQD(vector15, vector3, zero))
				{
					num76 *= -1f;
				}
				float num77 = (num63 + num76) / ((float)num71 * 1f);
				Vector3 vector16 = Vector3.zero;
				int cInt = exitRoad.endSplineIndex - 2;
				int match = cInt;
				b = (num39 + num40) / num7;
				roadShapeVecs = exitRoad.roadType.roadShape;
				roadShapeUVs = exitRoad.roadType.roadShapeUVs;
				hardEdge = exitRoad.roadType.hardEdge;
				count = roadShapeVecs.Count;
				num6 = 0;
				for (int num78 = 0; num78 < roadShapeVecs.Count; num78++)
				{
					list26.Add(roadShapeVecs[roadShapeVecs.Count - 1].x - roadShapeVecs[num78].x);
					if (hardEdge[num78])
					{
						num6++;
					}
				}
				list31.Clear();
				num52 += count + num6;
				Vector3 vector17 = Vector3.Lerp(list4[exitRoad.wssst - 1], list5[exitRoad.wssst - 1], 0.5f);
				Vector3 prefDirVec = (exitRoad._3ssss = Vector3.zero);
				float num79 = 2f * rightIndentFloats[cInt];
				List<bool> list33 = new List<bool>();
				Vector3 vector18;
				for (int num80 = 0; num80 <= num71; num80++)
				{
					vector18 = OQQOCDQCQD.OOQOCODQOO(vector3, vector15, Quaternion.Euler(0f, (float)num80 * num72, 0f));
					vector18.y = OCDDCQQDQD(vector18, soSplinePointsLeft, soSplinePointsRight, ref cInt, flag: true, ref match);
					exitRoad.soPointsRightStart.Add(vector18);
					b += num75;
					normalized2 = (vector18 - vector15).normalized;
					for (int num81 = 0; num81 < roadShapeVecs.Count; num81++)
					{
						Vector3 vector19;
						if (num81 < count - 1)
						{
							vector19 = vector18 + normalized2 * list26[num81];
							vector19.y = OCDDCQQDQD(vector19, soSplinePointsLeft, soSplinePointsRight, ref cInt, flag: false, ref match);
						}
						else
						{
							vector19 = vector18;
						}
						Vector3 vector20 = vector19;
						vector19.y += roadShapeVecs[num81].y;
						if (num81 == 0)
						{
							vector16 = vector19;
							Vector3 vector4 = OQQOCDQCQD.OCOOQOQCDC(soSplinePointsRight[match - 1], soSplinePointsRight[match], vector19);
							num66 = Vector3.Distance(vector4, vector19);
							Vector3 pos;
							if (num66 > num79)
							{
								pos = vector20 + normalized2 * (baseScript.terrainMinIndent + baseScript.minSurrounding);
								road.baseScript.OQCCDQOQOO(ref pos);
								list22.Add(pos);
								list23.Add(new Vector2(0f, 1f));
								pos = vector20 + normalized2 * baseScript.terrainMinIndent;
								pos.y = OCDDCQQDQD(pos, soSplinePointsLeft, soSplinePointsRight, ref cInt, flag: false, ref match);
								list22.Add(pos);
								list23.Add(new Vector2(0f, 1f));
								list33.Add(item: true);
							}
							else
							{
								exitRoad.road.doRightSurrounding[match - 1] = false;
								exitRoad.road.doRightSurrounding[match] = false;
								list33.Add(item: false);
								pos = vector20 + normalized2 * baseScript.terrainMinIndent;
								Vector3 p = Vector3.Lerp(vector4, vector19, 0.5f);
								pos = OQQOCDQCQD.OCDCQCDDCC(vector17, p, vector19, pos, flag: false);
								pos.y = OCDDCQQDQD(pos, soSplinePointsLeft, soSplinePointsRight, ref cInt, flag: false, ref match);
								list22.Add(pos);
								list23.Add(new Vector2(0f, 1f));
								list22.Add(pos);
								list23.Add(new Vector2(0f, 1f));
								if (num80 != 0)
								{
									p = Vector3.Lerp(vector4, vector19, 0.6f);
									Vector3 vPoint = OQQOCDQCQD.OCDCQCDDCC(vector17, p, soSplinePointsRight[match], soSplinePointsLeft[match], flag: false);
									vPoint = OQQOCDQCQD.OCOOQOQCDC(vector17, p, vPoint);
									roadSurfaceVecs[(match - 1) * 5 + 3] = vPoint;
									roadSurfaceVecs[(match - 1) * 5 + 4] = vPoint;
								}
							}
							pos.y = OCDDCQQDQD(pos, soSplinePointsLeft, soSplinePointsRight, ref cInt, flag: false, ref match);
							pos = Vector3.Lerp(vector20, vector18, 0.5f);
							list22.Add(pos);
							list23.Add(new Vector2(0f, 1f));
							pos = vector18 + -normalized2 * rightIndentFloats[match];
							pos.y = OCDDCQQDQD(pos, soSplinePointsLeft, soSplinePointsRight, ref cInt, flag: false, ref match);
							list22.Add(pos);
							list23.Add(new Vector2(0f, 1f));
							pos += -normalized2 * rightSurroundingFloats[match];
							road.baseScript.OQCCDQOQOO(ref pos);
							list22.Add(pos);
							list23.Add(new Vector2(0f, 1f));
							exitRoad.treeVecs.Add(vector19 + normalized2 * baseScript.treeDistance);
							exitRoad.treeVecs.Add(vector18 - normalized2 * baseScript.treeDistance);
							exitRoad.detailVecs.Add(vector19 + normalized2 * baseScript.detailDistance - baseScript.detailOffsetVec);
							exitRoad.detailVecs.Add(vector18 - normalized2 * baseScript.detailDistance - baseScript.detailOffsetVec);
							exitRoad.soPointsLeftStart.Add(vector19);
						}
						list18.Add(vector19);
						list19.Add(new Vector2(roadShapeUVs[num81], b));
						if (hardEdge.Count > num81 && hardEdge[num81])
						{
							list18.Add(vector19);
							list19.Add(Vector2.zero);
							num54++;
						}
						if (num81 < count - 1 && num80 > 0)
						{
							Assss.Add(num52 + num81 + num54);
							Assss.Add(num52 + num81 + num54 + count + num6);
							Assss.Add(num52 + num81 + num54 + count + 1 + num6);
							Assss.Add(num52 + num81 + num54);
							Assss.Add(num52 + num81 + num54 + count + 1 + num6);
							Assss.Add(num52 + num81 + num54 + 1);
						}
						if (num80 == 0 && num81 == 0)
						{
							exitRoad._3ssss = vector19;
						}
					}
					num52 += count + num6;
					if (num80 == num71)
					{
						list30.Add(vector18);
						list30.Add(vector16);
						list31.Add(0);
						list31.Add(1);
						exitRoad.connectionHandlePosition = Vector3.Lerp(vector18, vector16, 0.5f);
					}
					else if (num80 == num71 - 1)
					{
						prefDirVec = vector18;
					}
				}
				int num82 = count2 + count + num6;
				int num83 = count2;
				vector18 = Vector3.zero;
				for (int num84 = exitRoad.xssss; num84 < exitRoad.xssss + num61; num84++)
				{
					float num85 = 1000f;
					for (int num86 = num83; num86 < num82 - 1; num86++)
					{
						if (list18[num86] != list18[num86 + 1])
						{
							vector3 = OQQOCDQCQD.OCOOQOQCDC(list18[num86], list18[num86 + 1], list18[num84]);
							num19 = Vector3.Distance(list18[num84], vector3);
							if (num19 < num85)
							{
								num85 = num19;
								vector18 = vector3;
								num83 = num86;
							}
						}
					}
					list18[num84] = vector18;
				}
				exitRoad.xtsss = num52;
				List<Vector3> list34 = new List<Vector3>(list18);
				List<Vector2> uvs = new List<Vector2>(list19);
				List<Color> list35 = new List<Color>(collection);
				List<int> list36 = new List<int>(Assss);
				exitRoad.BuildMeshInit(exitRoad, list34, uvs, list36, list35, material, exitRoad.road);
				exitRoad.ODQQOOQDOC(list22, list23, num, num71);
				exitRoad.OCODCCQOQD(list30, list31, list22, prefDirVec);
				exitRoad.wtsst = exitRoad.wssst;
				exitRoad.OQCDCQOCCD();
				exitRoad.SpawnSplitObjects();
			}
			else
			{
				Debug.Log("EasyRoads3Dv3 Warning: no road type is assigned to this exit road");
			}
		}

		public void BuildMeshInit(OCDCDDDQOC exitRoad, List<Vector3> vecs, List<Vector2> uvs, List<int> tris, List<Color> colors, Material mat, ERModularRoad road)
		{
			OQQOCDODCC(exitRoad, xtsss, vecs, uvs, tris);
			ODQDOOQCOO(exitRoad, xtsss, vecs, uvs, tris, 0);
			ODQDOOQCOO(exitRoad, xtsss, vecs, uvs, tris, exitRoad.startLineMarkingDecal);
			OCOCDCDDOD(vecs, uvs, tris, colors, mat, exitRoad.gameObject, road);
		}

		public void OQCDCQOCCD()
		{
			if (exitSignObject != null)
			{
				if (exitSignObjectInstance == null)
				{
					exitSignObjectInstance = UnityEngine.Object.Instantiate(exitSignObject);
					exitSignObjectInstance.name = exitSignObject.name;
				}
				exitSignObjectInstance.transform.parent = base.transform;
				Vector3 position = Vector3.Lerp(yssst[wtsst], _0ssst[wtsst], 0.5f);
				Vector3 normalized = (yssst[wtsst - 1] - yssst[wtsst]).normalized;
				if (exitSignObjectOffset != 0f)
				{
					position += normalized * exitSignObjectOffset;
				}
				exitSignObjectInstance.transform.position = position;
				exitSignObjectInstance.transform.forward = normalized;
			}
		}

		public void SpawnSplitObjects()
		{
			if (exitSplitSpawnObject != null)
			{
				int curGo = 0;
				float num = 0f;
				bool flag = false;
				Vector3 vector = Vector3.zero;
				Vector3 vector2 = Vector3.zero;
				float num2 = 0f;
				Vector3 normalized = (_0ssst[vssss] - yssst[vssss]).normalized;
				Vector3 a = yssst[vssss] + normalized * (ttsss + exitSplitSpawnOffset);
				Vector3 b = _0ssst[vssss] - normalized * exitSplitSpawnOffset;
				float num3 = Vector3.Distance(a, b);
				float num4 = Vector3.Distance(_0ssst[vssss], yssst[vssss]);
				float num5 = 0f;
				bool flag2 = false;
				float b2 = 0f;
				float a2 = 0f;
				if (num3 > exitSplitSpawnObjectBounds * 2.1f && num4 > exitSplitSpawnObjectBounds * 2.1f && exitSplitSpawnType == 0)
				{
					flag = true;
				}
				else
				{
					normalized = (_0ssst[vssss] - yssst[vssss]).normalized;
					if (exitSplitSpawnType == 0)
					{
						a = yssst[vssss] + normalized * (ttsss + exitSplitSpawnOffset);
						b = _0ssst[vssss] - normalized * exitSplitSpawnOffset;
						Vector3 vector3 = Vector3.Lerp(a, b, 0.5f);
					}
					else if (exitSplitSpawnType == 1)
					{
						Vector3 vector3 = yssst[vssss] + normalized * (ttsss + exitSplitSpawnOffset);
					}
					else
					{
						Vector3 vector3 = _0ssst[vssss] - normalized * exitSplitSpawnOffset;
					}
				}
				float num6 = 0f;
				float num7 = 0f;
				for (int i = vssss; i < wtsst; i++)
				{
					Vector3 normalized2;
					normalized = (normalized2 = (_0ssst[i] - yssst[i]).normalized);
					a = yssst[i] + normalized * (ttsss + exitSplitSpawnOffset);
					b = _0ssst[i] - normalized * exitSplitSpawnOffset;
					if (exitSplitSpawnType == 0)
					{
						num3 = Vector3.Distance(a, b);
						if (num3 > exitSplitSpawnObjectBounds * 2.1f)
						{
							num4 = Vector3.Distance(_0ssst[i], yssst[i]);
							if ((double)num4 > (double)exitSplitSpawnObjectBounds * 2.1)
							{
								flag = true;
							}
						}
						else if (i < wtsst - 1)
						{
							num5 = Vector3.Distance(yssst[i + 1] + normalized * (ttsss + exitSplitSpawnOffset), _0ssst[i + 1] - normalized * exitSplitSpawnOffset);
							if ((double)num5 > (double)exitSplitSpawnObjectBounds * 2.1)
							{
								flag2 = true;
								b2 = num3;
								a2 = num5;
							}
						}
					}
					num6 = (num7 = Vector3.Distance(a, yssst[i + 1]));
					if (num + num6 >= exitSplitSpawnDistance)
					{
						Vector3 vector3;
						if (exitSplitSpawnType == 0 && !flag)
						{
							vector3 = Vector3.Lerp(a, b, 0.5f);
							normalized = (Vector3.Lerp(yssst[i + 1], _0ssst[i + 1], 0.5f) - vector3).normalized;
						}
						else if (exitSplitSpawnType == 1 || flag)
						{
							vector3 = a;
							normalized = (yssst[i + 1] - yssst[i]).normalized;
							if (exitSplitSpawnType == 0)
							{
								vector2 = b;
								vector = (_0ssst[i + 1] - _0ssst[i]).normalized;
							}
						}
						else
						{
							vector3 = b;
							normalized = (_0ssst[i + 1] - _0ssst[i]).normalized;
						}
						vector3 += normalized * (exitSplitSpawnDistance - num);
						if (exitSplitSpawnType == 0 && flag && num2 >= exitSplitSpawnStartOffset)
						{
							vector2 += vector * (exitSplitSpawnDistance - num);
							OOOCDQQOOQ(ref curGo, vector2);
						}
						if (num2 >= exitSplitSpawnStartOffset)
						{
							OOOCDQQOOQ(ref curGo, vector3);
						}
						num2 += exitSplitSpawnDistance;
						num6 -= exitSplitSpawnDistance - num;
						num = 0f;
						while (num6 >= exitSplitSpawnDistance)
						{
							vector3 += normalized * exitSplitSpawnDistance;
							if (exitSplitSpawnType == 0 && !flag && flag2)
							{
								float t = num6 / num7;
								float num8 = Mathf.Lerp(a2, b2, t);
								if (num8 > exitSplitSpawnObjectBounds * 2.1f)
								{
									flag = true;
									normalized = (yssst[i + 1] - yssst[i]).normalized;
									vector = (_0ssst[i + 1] - _0ssst[i]).normalized;
									vector3 += -normalized2 * num8 * 0.5f;
									vector2 = vector3 + normalized2 * num8;
									vector2 = OQQOCDQCQD.OCDCQCDDCC(vector3, vector2, _0ssst[i + 1], _0ssst[i], flag: false);
									vector2 += -normalized2 * exitSplitSpawnOffset;
									vector3 = OQQOCDQCQD.OCDCQCDDCC(vector3, vector2, yssst[i + 1], yssst[i], flag: false);
									vector3 += normalized2 * (ttsss + exitSplitSpawnOffset);
									vector2 -= vector * exitSplitSpawnDistance;
								}
							}
							if (num2 >= exitSplitSpawnStartOffset)
							{
								OOOCDQQOOQ(ref curGo, vector3);
							}
							if (exitSplitSpawnType == 0 && flag)
							{
								vector2 += vector * exitSplitSpawnDistance;
								if (num2 >= exitSplitSpawnStartOffset)
								{
									OOOCDQQOOQ(ref curGo, vector2);
								}
							}
							num6 -= exitSplitSpawnDistance;
							num2 += exitSplitSpawnDistance;
						}
						num = num6;
					}
					else
					{
						num += num6;
					}
				}
				int num9;
				for (num9 = curGo; num9 < spawnedSplitObjects.Count; num9++)
				{
					if (spawnedSplitObjects[num9] != null)
					{
						UnityEngine.Object.DestroyImmediate(spawnedSplitObjects[num9]);
					}
					spawnedSplitObjects.RemoveAt(num9);
					num9--;
				}
			}
			int num10 = 0;
			for (int j = startSplineIndex; j < endSplineIndex; j++)
			{
				num10++;
			}
		}

		public void OOOCDQQOOQ(ref int curGo, Vector3 v)
		{
			if (spawnedSplitObjects.Count > curGo)
			{
				if (spawnedSplitObjects[curGo] != null)
				{
					spawnedSplitObjects[curGo].transform.position = v;
				}
				else
				{
					GameObject gameObject = UnityEngine.Object.Instantiate(exitSplitSpawnObject);
					gameObject.transform.parent = base.transform;
					gameObject.transform.position = v;
					spawnedSplitObjects[curGo] = gameObject;
				}
			}
			else
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(exitSplitSpawnObject);
				gameObject.transform.parent = base.transform;
				gameObject.transform.position = v;
				spawnedSplitObjects.Add(gameObject);
			}
			curGo++;
		}

		public static void OQQOCDODCC(OCDCDDDQOC exitRoad, int vecCount, List<Vector3> vecs, List<Vector2> uvsArray, List<int> tris)
		{
			List<ERDecal> list = ERDecal.FilterByType(exitRoad.roadType.decalPresets, ERDecalType.MotorwayRampLineMarking);
			if (list.Count == 0)
			{
				return;
			}
			float num = exitRoad.utsst;
			float num2 = 0f;
			float num3 = 0f;
			float width = list[0].width;
			float x = list[0].uvLeftTop2.x;
			float num4 = list[0].uvRightBottom2.x - list[0].uvLeftTop2.x;
			vecCount = vecs.Count;
			List<int> list2 = new List<int>();
			Vector3 item;
			for (int i = exitRoad.vssss; i <= exitRoad.wssst; i++)
			{
				item = exitRoad.Assss[i];
				item.y += num;
				vecs.Add(item);
				item = exitRoad._0ssst[i];
				if (i == exitRoad.wssst)
				{
					item = vecs[exitRoad.xssss];
				}
				item.y += exitRoad.utsst;
				vecs.Add(item);
				num3 = Vector3.Distance(exitRoad.Assss[i], exitRoad._0ssst[i]);
				num2 = x + num3 / width * num4;
				uvsArray.Add(new Vector2(x, exitRoad._1ssss[i]));
				uvsArray.Add(new Vector2(num2, exitRoad._1ssss[i]));
				if (i < exitRoad.wssst)
				{
					if (vecs[vecCount] != vecs[vecCount + 1])
					{
						tris.Add(vecCount);
						tris.Add(vecCount + 2);
						tris.Add(vecCount + 1);
					}
					tris.Add(vecCount + 1);
					tris.Add(vecCount + 2);
					tris.Add(vecCount + 3);
				}
				vecCount += 2;
			}
			vecs.Add(exitRoad._3ssss);
			item = OQQOCDQCQD.OCOOQOQCDC(vecs[vecCount - 2], vecs[vecCount - 1], exitRoad._3ssss);
			num3 = Vector3.Distance(vecs[vecCount - 2], vecs[vecCount - 1]);
			float num5 = Vector3.Distance(vecs[vecCount - 2], item);
			num2 = Mathf.Lerp(uvsArray[vecCount - 2].x, uvsArray[vecCount - 1].x, num5 / num3);
			float y = uvsArray[vecCount - 2].y + Vector3.Distance(item, exitRoad._3ssss) / exitRoad._4ssst;
			uvsArray.Add(new Vector2(num2, y));
			tris.Add(vecCount - 2);
			tris.Add(vecCount);
			tris.Add(vecCount - 1);
		}

		public static void ODQDOOQCOO(OCDCDDDQOC exitRoad, int vecCount, List<Vector3> vecs, List<Vector2> uvsArray, List<int> tris, int decalIndex)
		{
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			float num5 = 0f;
			float num6 = 0f;
			float num7 = 0f;
			float num8 = 0f;
			float num9 = 0f;
			float num10 = 0f;
			if (decalIndex != 0)
			{
				ERDecal eRDecal = ERDecal.OOCQOOODDC(decalIndex, exitRoad.roadType.decalPresets);
				if (eRDecal == null)
				{
					return;
				}
				num = eRDecal.width;
				num2 = eRDecal.uvLeftTop2.x;
				num3 = eRDecal.uvRightBottom2.x - eRDecal.uvLeftTop2.x;
				num4 = eRDecal.width;
				num5 = eRDecal.uvLeftTop.x;
				num6 = eRDecal.uvRightBottom.x;
				num7 = eRDecal.xOffset;
				num8 = eRDecal.heightOffset;
				num9 = eRDecal.uvLeftTop1.x;
				num10 = eRDecal.uvRightBottom1.x;
			}
			else
			{
				Debug.Log("to Do: create 'decal' option for Fill Gap motorway ramps in road types and use this decal here");
				num = 0f;
				num2 = 0f;
				num3 = 0f;
				num4 = 0f;
				num5 = 0f;
				num6 = 0f;
				num7 = 0f;
				num8 = 0f;
				num9 = 0f;
				num10 = 0f;
			}
			float num11 = exitRoad.utsst;
			float num12 = 0f;
			float num13 = 0f;
			vecCount = vecs.Count;
			List<int> list = new List<int>();
			vecCount = vecs.Count;
			int num14 = 1;
			int num15 = 0;
			float num16 = Vector3.Distance(exitRoad.yssst[0], exitRoad._2ssst[0]);
			float num17 = 2f * exitRoad.ttsss;
			if (num16 < num17)
			{
				Vector3 zero = Vector3.zero;
				Vector3 zero2 = Vector3.zero;
				Vector3 vector = Vector3.zero;
				bool flag = false;
				int tssss = 0;
				int num18 = 0;
				list.Clear();
				for (int i = 0; i <= exitRoad.vssss; i++)
				{
					num15 = i;
					Vector3 vector2 = exitRoad.road.soSplinePointsRight[i + exitRoad.startSplineIndex];
					Vector3 vector3 = exitRoad.road.soSplinePointsLeft[i + exitRoad.startSplineIndex];
					Vector3 normalized = (vector2 - vector3).normalized;
					zero = exitRoad.yssst[i] - normalized * num7;
					zero2 = ((decalIndex == 0) ? exitRoad._0ssst[i] : (zero + normalized * num4));
					bool flag2 = true;
					if (i > 0)
					{
						if (OQQOCDQCQD.OOCQODQDQD(vector, zero2, exitRoad._2ssst[num14]))
						{
							flag2 = false;
							Vector3 vector4 = exitRoad._2ssst[num14];
							vector4.y += num11 + exitRoad.vtsss;
							vecs.Add(vector4);
							Vector3 a = OQQOCDQCQD.OCOOQOQCDC(vector, zero2, vector4);
							num16 = Vector3.Distance(a, vector4);
							num12 = Mathf.Lerp(num5, num6, (num4 - num16) / num4);
							a = OQQOCDQCQD.OCOOQOQCDC(vector2, vector3, vector4);
							num16 = Vector3.Distance(a, vector4);
							num17 = Vector3.Distance(vector, zero2);
							float y = Mathf.Lerp(exitRoad._1ssss[i - 1], exitRoad._1ssss[i], (num17 - num16) / num17);
							uvsArray.Add(new Vector2(num12, y));
							list.Add(vecs.Count - 1);
							num14++;
						}
						else
						{
							Vector3 vector4 = OQQOCDQCQD.OCDCQCDDCC(vector, zero2, exitRoad._2ssst[num14 - 1], exitRoad._2ssst[num14], flag: false);
							vector4 = OQQOCDQCQD.OCOOQOQCDC(exitRoad._2ssst[num14 - 1], exitRoad._2ssst[num14], vector4);
							vecs.Add(vector4);
							num12 = num6;
							Vector3 a = OQQOCDQCQD.OCOOQOQCDC(vector2, vector3, vector4);
							num16 = Vector3.Distance(a, vector4);
							num17 = Vector3.Distance(vector, zero2);
							float y2 = Mathf.Lerp(exitRoad._1ssss[i - 1], exitRoad._1ssss[i], (num17 - num16) / num17);
							uvsArray.Add(new Vector2(num12, y2));
							list.Add(vecs.Count - 1);
							flag = true;
						}
						if (flag2)
						{
							Vector3 vector4 = OQQOCDQCQD.OCDCQCDDCC(vector, zero2, exitRoad._2ssst[num14 - 1], exitRoad._2ssst[num14], flag: false);
							vector4 = OQQOCDQCQD.OCOOQOQCDC(exitRoad._2ssst[num14 - 1], exitRoad._2ssst[num14], vector4);
							vecs.Add(vector4);
							num12 = num6;
							Vector3 a = OQQOCDQCQD.OCOOQOQCDC(vector2, vector3, vector4);
							num16 = Vector3.Distance(a, vector4);
							num17 = Vector3.Distance(vector, zero2);
							float y3 = Mathf.Lerp(exitRoad._1ssss[i - 1], exitRoad._1ssss[i], (num17 - num16) / num17);
							uvsArray.Add(new Vector2(num12, y3));
							list.Add(vecs.Count - 1);
							flag = true;
						}
						zero.y += num11 + exitRoad.vtsss + num8;
						num18 = vecs.Count;
						vecs.Add(zero);
						uvsArray.Add(new Vector2(num5, exitRoad._1ssss[i]));
						if (flag)
						{
							zero2.y += num11 + exitRoad.vtsss + num8;
							vecs.Add(zero2);
							uvsArray.Add(new Vector2(num6, exitRoad._1ssss[i]));
							list.Add(vecs.Count - 1);
						}
						ussst(tssss, num18, 0, list.Count - 1, list, vecs, ref tris);
						if (list.Count <= 0)
						{
							break;
						}
						int item = list[list.Count - 1];
						list.Clear();
						list.Add(item);
						if (flag)
						{
							break;
						}
					}
					else
					{
						num18 = vecs.Count;
						zero.y += exitRoad.utsst + exitRoad.vtsss + num8;
						vecs.Add(zero);
						uvsArray.Add(new Vector2(num5, exitRoad._1ssss[i]));
						if (decalIndex != 0)
						{
							Vector3 vector4 = exitRoad.yssst[i];
							vector4.y += exitRoad.utsst + exitRoad.vtsss + num8;
							vecs.Add(vector4);
							num12 = Mathf.Lerp(num5, num6, Vector3.Distance(zero, vector4) / num4);
							uvsArray.Add(new Vector2(num12, exitRoad._1ssss[i]));
							list.Add(vecs.Count - 1);
						}
					}
					vector = zero2;
					tssss = num18;
				}
			}
			vecCount = vecs.Count;
			num13 = 0f;
			bool flag3 = false;
			float num19 = exitRoad.startDecalDistance;
			if (num19 == 0f)
			{
				num19 = 0.1f;
			}
			if (num19 == 0f)
			{
				num5 = num9;
				num6 = num10;
				flag3 = true;
			}
			int num20 = exitRoad.vssss;
			if (decalIndex != 0)
			{
				num20++;
			}
			for (int j = num15; j <= exitRoad.vssss; j++)
			{
				Vector3 vector2 = exitRoad.road.soSplinePointsRight[j + exitRoad.startSplineIndex];
				Vector3 vector3 = exitRoad.road.soSplinePointsLeft[j + exitRoad.startSplineIndex];
				Vector3 normalized = (vector2 - vector3).normalized;
				Vector3 vector4 = exitRoad.yssst[j] - normalized * num7;
				vector4.y += num11 + exitRoad.vtsss + num8;
				vecs.Add(vector4);
				if (decalIndex != 0)
				{
					vector4 += normalized * num4;
				}
				else
				{
					vector4 = exitRoad._0ssst[j];
				}
				vecs.Add(vector4);
				num12 = num2 + num13 / num * num3;
				uvsArray.Add(new Vector2(num5, exitRoad._1ssss[j]));
				uvsArray.Add(new Vector2(num6, exitRoad._1ssss[j]));
				if (j < num20)
				{
					tris.Add(vecCount);
					tris.Add(vecCount + 2);
					tris.Add(vecCount + 1);
					tris.Add(vecCount + 1);
					tris.Add(vecCount + 2);
					tris.Add(vecCount + 3);
				}
				vecCount += 2;
				if (j > 0 && !flag3 && exitRoad.yssst.Count > j + 1)
				{
					num16 = Vector3.Distance(exitRoad.yssst[j], exitRoad.yssst[j + 1]);
					if (num13 + num16 > num19 && decalIndex != 0)
					{
						num17 = num19 - num13;
						float t = num17 / num16;
						vector2 = exitRoad.road.soSplinePointsRight[j + 1 + exitRoad.startSplineIndex];
						vector3 = exitRoad.road.soSplinePointsLeft[j + 1 + exitRoad.startSplineIndex];
						normalized = (vector2 - vector3).normalized;
						vector4 = exitRoad.yssst[j + 1] - normalized * num7;
						vector4.y += num11 + exitRoad.vtsss + num8;
						vector4 = Vector3.Lerp(vecs[vecs.Count - 2], vector4, t);
						vecs.Add(vector4);
						uvsArray.Add(new Vector2(num5, Mathf.Lerp(exitRoad._1ssss[j], exitRoad._1ssss[j + 1], t)));
						vector4 += normalized * num4;
						vecs.Add(vector4);
						uvsArray.Add(new Vector2(num6, Mathf.Lerp(exitRoad._1ssss[j], exitRoad._1ssss[j + 1], t)));
						num5 = num9;
						num6 = num10;
						vecs.Add(vecs[vecs.Count - 2]);
						vecs.Add(vecs[vecs.Count - 2]);
						Vector2 item2 = uvsArray[uvsArray.Count - 2];
						item2.x = num5;
						uvsArray.Add(item2);
						item2 = uvsArray[uvsArray.Count - 2];
						item2.x = num6;
						uvsArray.Add(item2);
						flag3 = true;
						vecCount += 2;
					}
					num13 += num16;
				}
			}
		}

		public static void ODQDQQDDOD(int i, int j, Vector3 prevPos, List<Vector3> edgeVecs, List<Vector3> soSplinePointsRight, float angleThreshold, ref List<Vector3> tmpvecs)
		{
			Vector3 vector = edgeVecs[j] - prevPos;
			Vector3 to = edgeVecs[j] - edgeVecs[j + 1];
			float num = Vector3.Angle(vector, to);
			float num2 = 180f - num - angleThreshold;
			if (!(num2 > 0f))
			{
				return;
			}
			float num3 = Vector3.Distance(edgeVecs[j + 1], edgeVecs[j]);
			float num4 = 0.75f / num3;
			if (num4 > 0f && (double)num4 < 0.5)
			{
				Vector3 p;
				if (j < edgeVecs.Count - 2)
				{
					p = edgeVecs[j + 2];
				}
				else
				{
					num3 = Vector3.Distance(soSplinePointsRight[i + 1], soSplinePointsRight[i]);
					vector = ((soSplinePointsRight.Count <= i + 2) ? (soSplinePointsRight[i + 1] - soSplinePointsRight[i]).normalized.normalized : (soSplinePointsRight[i + 2] - soSplinePointsRight[i + 1]).normalized.normalized);
					p = edgeVecs[j + 1] + vector * num3;
				}
				List<Vector3> list = OQQOCDQCQD.ODOQDOQCOD(prevPos, edgeVecs[j], edgeVecs[j + 1], p, num4);
				if ((double)Vector3.Distance(list[list.Count - 1], edgeVecs[j + 1]) < 0.25)
				{
					list.RemoveAt(list.Count - 1);
				}
				tmpvecs.AddRange(list);
			}
		}

		private static void ussst(int tssss, int ussss, int vssss, int wssss, List<int> xssss, List<Vector3> yssss, ref List<int> Assss)
		{
			float num = 0f;
			float num2 = 0f;
			int num3 = -1;
			int num4 = 0;
			if (xssss.Count <= vssss)
			{
				Debug.Log("ramp edge tris error, rightInts.Count: " + xssss.Count);
				return;
			}
			while (tssss < ussss || vssss < wssss)
			{
				num2 = ((vssss >= wssss) ? 0f : Vector3.Distance(yssss[tssss], yssss[xssss[vssss + 1]]));
				num = ((tssss >= ussss) ? 0f : Vector3.Distance(yssss[ussss], yssss[xssss[vssss]]));
				if ((num < num2 && tssss < ussss) || vssss == wssss)
				{
					Assss.Add(tssss);
					Assss.Add(ussss);
					Assss.Add(xssss[vssss]);
					tssss = ussss;
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
				num4++;
				if (num4 > 100)
				{
					break;
				}
			}
		}

		public static void OQOQQCOOQC(List<Vector3> vecs, ref List<int> tris)
		{
			bool flag = false;
			for (int i = 0; i < tris.Count; i += 3)
			{
				flag = false;
				if (vecs[tris[i]] == Vector3.zero)
				{
					flag = true;
				}
				else if (vecs[tris[i + 1]] == Vector3.zero)
				{
					flag = true;
				}
				else if (vecs[tris[i + 2]] == Vector3.zero)
				{
					flag = true;
				}
				if (flag)
				{
					tris.RemoveRange(i, 3);
					i -= 3;
				}
			}
		}

		public static void ODOQODCOOQ(ERModularBase baseScript, ERModularRoad road, OCDCDDDQOC exitRoad, ref List<Vector3> soSplinePointsLeft, ref List<Vector3> soSplinePointsRight)
		{
			List<List<Vector3>> list = new List<List<Vector3>>();
			List<List<Vector3>> list2 = new List<List<Vector3>>();
			List<List<Vector3>> list3 = new List<List<Vector3>>();
			List<Vector3> list4 = new List<Vector3>();
			List<Vector3> list5 = new List<Vector3>(soSplinePointsRight);
			float num = 5f;
			float num2 = 0.5f;
			if (exitRoad.roadType != null)
			{
				num = exitRoad.roadType.roadWidth;
				num2 = 0.125f;
				if (num2 == 0f)
				{
					num2 = 0.25f;
				}
				List<Vector3> list6 = new List<Vector3>();
				List<int> list7 = new List<int>();
				list.Add(new List<Vector3>());
				list2.Add(new List<Vector3>());
				list3.Add(new List<Vector3>());
				list.Add(new List<Vector3>());
				list2.Add(new List<Vector3>());
				list3.Add(new List<Vector3>());
				list[0].Add(soSplinePointsRight[exitRoad.startSplineIndex]);
				list[1].Add(soSplinePointsRight[exitRoad.startSplineIndex]);
				list4.Add(soSplinePointsRight[exitRoad.startSplineIndex]);
				float num3 = 0f;
				float num4 = 0f;
				bool flag = false;
				Vector3 normalized = (soSplinePointsRight[exitRoad.startSplineIndex + 1] - soSplinePointsRight[exitRoad.startSplineIndex]).normalized;
				float num5 = 0f;
				Vector3 vector;
				Vector3 value;
				Vector3 normalized2;
				for (int i = exitRoad.startSplineIndex; i < exitRoad.endSplineIndex; i++)
				{
					normalized2 = (soSplinePointsRight[i + 1] - soSplinePointsLeft[i + 1]).normalized;
					num3 += Vector3.Distance(list5[i], list5[i + 1]);
					if (!flag)
					{
						float num6;
						if (exitRoad.extrusionType == 0)
						{
							num6 = num3 / exitRoad.extrusionDistance * num;
							if (num6 > num)
							{
								num6 = num;
							}
						}
						else
						{
							num6 = Mathf.SmoothStep(0f, num, num3 / exitRoad.extrusionDistance);
							if (num6 > num)
							{
								num6 = num;
							}
						}
						float num7 = Mathf.SmoothStep(0f, 1f, num3 / exitRoad.extrusionDistance);
						num4 = Mathf.Lerp(0f, num, num7 * num7);
						vector = soSplinePointsRight[i + 1];
						vector += normalized2 * num4;
						vector = (value = soSplinePointsRight[i + 1] + normalized2 * num6);
						list[0].Add(vector);
						vector += -normalized2 * num2;
						list[1].Add(vector);
					}
					else
					{
						vector = (value = soSplinePointsRight[i + 1] + normalized2 * num);
						list2[0].Add(vector);
					}
					vector = soSplinePointsRight[i + 1] + -normalized2 * 0.25f;
					list4.Add(vector);
					soSplinePointsRight[i + 1] = value;
					if (num3 > exitRoad.extrusionDistance)
					{
						flag = true;
						if (exitRoad.fixedDistance == 0f)
						{
							break;
						}
					}
				}
				if (exitRoad.fixedDistance == 0f)
				{
					float num8 = 0f;
					float num9 = Mathf.Sqrt(exitRoad.extrusionDistance * exitRoad.extrusionDistance - num * num);
					float num10 = Vector3.Distance(list[0][0], list[0][list[0].Count - 1]);
					num8 = num9 / num10;
					for (int j = 1; j < list[0].Count; j++)
					{
						vector = list[0][j];
						vector = Vector3.Lerp(list[0][0], list[0][j], num8);
					}
				}
				if (exitRoad.fixedDistance < 1f)
				{
					vector = list[0][list[0].Count - 1];
					value = list4[list4.Count - 1];
				}
				else
				{
					vector = list2[0][list2[0].Count - 1];
					value = list4[list4.Count - 1];
				}
				float num11 = exitRoad.connectionAngle;
				float num12 = exitRoad.connectionRadius;
				int num13 = exitRoad.markerIndex + 1;
				float num14 = Vector3.Distance(road.soSplinePoints[exitRoad.endSplineIndex], road.markersExt[num13].position);
				if (num14 < exitRoad.connectionRadius)
				{
					num13++;
				}
				if (OQQOCDQCQD.OOCQODQDQD(road.soSplinePoints[exitRoad.endSplineIndex], road.soSplinePoints[exitRoad.endSplineIndex - 1], road.markersExt[num13].position))
				{
					Vector3 vector2 = road.soSplinePoints[exitRoad.endSplineIndex - 1] - road.soSplinePoints[exitRoad.endSplineIndex];
					Vector3 to = road.markersExt[num13].position - road.soSplinePoints[exitRoad.endSplineIndex];
					float num15 = 180f - Vector3.Angle(vector2, to);
					if (num15 > num11)
					{
						float num16 = num11;
						num11 += num15;
						num12 *= num16 / num11;
					}
				}
				if (num12 < num + 1f)
				{
					num12 = num + 1f;
				}
				normalized2 = ((exitRoad.fixedDistance < 1f || list2[0].Count <= 0) ? (vector - list[0][list[0].Count - 2]) : ((list2[0].Count <= 1) ? (vector - list[0][list[0].Count - 1]) : (vector - list2[0][list2[0].Count - 2])));
				normalized2 = new Vector3(normalized2.z, 0f, 0f - normalized2.x).normalized;
				Vector3 vector3 = vector + normalized2 * num12;
				float num17 = 1f;
				float num18 = (float)Mathf.RoundToInt(2f * num12 * MathF.PI) * (num11 / 360f);
				int num19 = Mathf.RoundToInt(Mathf.Floor(num18 / num17));
				float num20 = num11 / ((float)num19 * 1f);
				float num21 = Mathf.Abs(Vector3.Angle(vector - vector3, value - vector3));
				if (num21 != 0f && !OQQOCDQCQD.OOCQODQDQD(vector3, vector, value))
				{
					num21 *= -1f;
				}
				float num22 = (num11 + num21) / ((float)num19 * 1f);
				int cInt = exitRoad.endSplineIndex;
				int match = 0;
				for (int k = 1; k <= num19; k++)
				{
					Vector3 vector4 = OQQOCDQCQD.OOQOCODQOO(vector, vector3, Quaternion.Euler(0f, (float)k * num20, 0f));
					Vector3 vector5 = OQQOCDQCQD.OOQOCODQOO(value, vector3, Quaternion.Euler(0f, (float)k * num22, 0f));
					vector5.y = OCDDCQQDQD(vector4, soSplinePointsLeft, soSplinePointsRight, ref cInt, flag: false, ref match);
					vector4.y = OCDDCQQDQD(vector4, soSplinePointsLeft, soSplinePointsRight, ref cInt, flag: true, ref match);
					list3[0].Add(vector4);
					list4.Add(vector5);
					if (k == num19)
					{
						list6.Add(vector4);
						list6.Add(vector5);
						list7.Add(0);
						list7.Add(1);
						exitRoad.connectionHandlePosition = Vector3.Lerp(vector4, vector5, 0.5f);
					}
				}
				ODOOQQQODD(baseScript, road, exitRoad, null, list, list2, list3, list4);
				exitRoad.OCODCCQOQD(list6, list7, null, Vector3.zero);
			}
			else
			{
				Debug.Log("EasyRoads3Dv3 Warning: no road type is assigned to this exit road");
			}
		}

		public static void OCCDDOCCDC(ERModularBase baseScript, ERModularRoad road, ERMarkerExt marker, ref List<Vector3> soSplinePointsLeft, ref List<Vector3> soSplinePointsRight)
		{
			GameObject gameObject = null;
			OCDCDDDQOC componentInChildren = road.gameObject.GetComponentInChildren<OCDCDDDQOC>();
			if (componentInChildren != null)
			{
				gameObject = componentInChildren.gameObject;
			}
			else
			{
				gameObject = new GameObject("Exit Road");
				gameObject.AddComponent<OCDCDDDQOC>();
				gameObject.transform.parent = road.transform;
			}
			float num = 5f;
			float num2 = 0.5f;
			if (marker.exitRoadType != 0)
			{
				num = baseScript.roadTypes[marker.exitRoadType - 1].roadWidth;
				num2 = baseScript.roadTypes[marker.exitRoadType - 1].outerIndent;
				if (num2 == 0f)
				{
					num2 = 0.25f;
				}
			}
			List<Vector3> list = new List<Vector3>();
			List<int> list2 = new List<int>();
			if (marker.exitOuterVerticesExtrusion != null)
			{
				marker.exitOuterVerticesExtrusion.Clear();
			}
			else
			{
				marker.exitOuterVerticesExtrusion = new List<List<Vector3>>();
			}
			if (marker.exitOuterVerticesFixed != null)
			{
				marker.exitOuterVerticesFixed.Clear();
			}
			else
			{
				marker.exitOuterVerticesFixed = new List<List<Vector3>>();
			}
			if (marker.exitOuterVerticesCurve != null)
			{
				marker.exitOuterVerticesCurve.Clear();
			}
			else
			{
				marker.exitOuterVerticesCurve = new List<List<Vector3>>();
			}
			marker.exitOuterVerticesExtrusion.Add(new List<Vector3>());
			marker.exitOuterVerticesFixed.Add(new List<Vector3>());
			marker.exitOuterVerticesCurve.Add(new List<Vector3>());
			marker.exitOuterVerticesExtrusion.Add(new List<Vector3>());
			marker.exitOuterVerticesFixed.Add(new List<Vector3>());
			marker.exitOuterVerticesCurve.Add(new List<Vector3>());
			marker.exitInnerVertices.Clear();
			marker.exitOuterVerticesExtrusion[0].Add(soSplinePointsRight[marker.startExitInt]);
			marker.exitOuterVerticesExtrusion[1].Add(soSplinePointsRight[marker.startExitInt]);
			marker.exitInnerVertices.Add(soSplinePointsRight[marker.startExitInt]);
			float num3 = 0f;
			bool flag = false;
			Vector3 item;
			Vector3 value;
			Vector3 normalized;
			for (int i = marker.startExitInt; i < marker.endExitInt; i++)
			{
				normalized = (soSplinePointsRight[i + 1] - soSplinePointsLeft[i + 1]).normalized;
				num3 += Vector3.Distance(soSplinePointsRight[i], soSplinePointsRight[i + 1]);
				if (!flag)
				{
					float num4;
					if (marker.extrusionType == 0)
					{
						num4 = num3 / marker.extrusionDistance * num;
						if (num4 > num)
						{
							num4 = num;
						}
					}
					else
					{
						num4 = Mathf.Lerp(0f, num, Mathf.SmoothStep(0f, 1f, num3 / marker.extrusionDistance));
						if (num4 > num)
						{
							num4 = num;
						}
					}
					item = (value = soSplinePointsRight[i + 1] + normalized * num4);
					marker.exitOuterVerticesExtrusion[0].Add(item);
					item += -normalized * num2;
					marker.exitOuterVerticesExtrusion[1].Add(item);
				}
				else
				{
					item = (value = soSplinePointsRight[i + 1] + normalized * num);
					marker.exitOuterVerticesFixed[0].Add(item);
				}
				marker.exitInnerVertices.Add(soSplinePointsRight[i + 1]);
				soSplinePointsRight[i + 1] = value;
				if (num3 > marker.extrusionDistance)
				{
					flag = true;
					if (marker.fixedDistance == 0f)
					{
						break;
					}
				}
			}
			if (marker.fixedDistance == 0f)
			{
				float num5 = 0f;
				float num6 = Mathf.Sqrt(marker.extrusionDistance * marker.extrusionDistance - num * num);
				float num7 = Vector3.Distance(marker.exitOuterVerticesExtrusion[0][0], marker.exitOuterVerticesExtrusion[0][marker.exitOuterVerticesExtrusion[0].Count - 1]);
				num5 = num6 / num7;
				for (int j = 1; j < marker.exitOuterVerticesExtrusion[0].Count; j++)
				{
					item = marker.exitOuterVerticesExtrusion[0][j];
					item = Vector3.Lerp(marker.exitOuterVerticesExtrusion[0][0], marker.exitOuterVerticesExtrusion[0][j], num5);
				}
			}
			if (marker.fixedDistance == 0f)
			{
				item = marker.exitOuterVerticesExtrusion[0][marker.exitOuterVerticesExtrusion[0].Count - 1];
				value = marker.exitInnerVertices[marker.exitInnerVertices.Count - 1];
			}
			else
			{
				item = marker.exitOuterVerticesFixed[0][marker.exitOuterVerticesFixed[0].Count - 1];
				value = marker.exitInnerVertices[marker.exitInnerVertices.Count - 1];
			}
			normalized = ((marker.fixedDistance != 0f) ? (item - marker.exitOuterVerticesFixed[0][marker.exitOuterVerticesFixed[0].Count - 2]) : (item - marker.exitOuterVerticesExtrusion[0][marker.exitOuterVerticesExtrusion[0].Count - 2]));
			normalized = new Vector3(normalized.z, 0f, 0f - normalized.x).normalized;
			Vector3 vector = item + normalized * marker.connectionRadius;
			float num8 = 1f;
			float num9 = (float)Mathf.RoundToInt(2f * marker.connectionRadius * MathF.PI) * (marker.connectionAngle / 360f);
			int num10 = Mathf.RoundToInt(Mathf.Floor(num9 / num8));
			float num11 = marker.connectionAngle / ((float)num10 * 1f);
			float num12 = Mathf.Abs(Vector3.Angle(item - vector, value - vector));
			if (num12 != 0f && !OQQOCDQCQD.OOCQODQDQD(vector, item, value))
			{
				num12 *= -1f;
			}
			float num13 = (marker.connectionAngle + num12) / ((float)num10 * 1f);
			int cInt = marker.endExitInt;
			int match = 0;
			for (int k = 1; k <= num10; k++)
			{
				Vector3 vector2 = OQQOCDQCQD.OOQOCODQOO(item, vector, Quaternion.Euler(0f, (float)k * num11, 0f));
				Vector3 vector3 = OQQOCDQCQD.OOQOCODQOO(value, vector, Quaternion.Euler(0f, (float)k * num13, 0f));
				vector3.y = OCDDCQQDQD(vector2, soSplinePointsLeft, soSplinePointsRight, ref cInt, flag: false, ref match);
				vector2.y = OCDDCQQDQD(vector2, soSplinePointsLeft, soSplinePointsRight, ref cInt, flag: true, ref match);
				marker.exitOuterVerticesCurve[0].Add(vector2);
				marker.exitInnerVertices.Add(vector3);
				if (k == num10)
				{
					list.Add(vector2);
					list.Add(vector3);
					list2.Add(0);
					list2.Add(1);
					componentInChildren.connectionHandlePosition = Vector3.Lerp(vector2, vector3, 0.5f);
				}
			}
			componentInChildren.OCODCCQOQD(list, list2, null, Vector3.zero);
		}

		public static void ODOOQQQODD(ERModularBase baseScript, ERModularRoad road, OCDCDDDQOC exitRoad, List<ERMarkerExt> markers, List<List<Vector3>> exitOuterVerticesExtrusion, List<List<Vector3>> exitOuterVerticesFixed, List<List<Vector3>> exitOuterVerticesCurve, List<Vector3> exitInnerVertices)
		{
			List<Vector3> list = new List<Vector3>();
			List<Vector2> list2 = new List<Vector2>();
			List<Vector2> list3 = new List<Vector2>();
			List<Color> list4 = new List<Color>();
			List<Color> list5 = new List<Color>();
			List<int> list6 = new List<int>();
			Material roadMaterial = exitRoad.roadType.roadMaterial;
			float x = 0.97f;
			float num = 5f;
			num = exitRoad.roadType.roadWidth;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			float num5 = 0f;
			float num6 = 0f;
			float num7 = 5f;
			for (int i = 0; i < exitOuterVerticesExtrusion[0].Count; i++)
			{
				num4 = list.Count;
				list.Add(exitInnerVertices[i]);
				list.Add(exitOuterVerticesExtrusion[1][i]);
				list.Add(exitOuterVerticesExtrusion[1][i]);
				list.Add(exitOuterVerticesExtrusion[0][i]);
				if (i > 0)
				{
					num6 += Vector3.Distance(exitInnerVertices[i - 1], exitInnerVertices[i]);
					num5 += Vector3.Distance(exitOuterVerticesExtrusion[0][i - 1], exitOuterVerticesExtrusion[0][i]);
				}
				float num8 = Vector3.Distance(exitInnerVertices[i], exitOuterVerticesExtrusion[1][i]);
				list2.Add(new Vector2(0f, num6 / num7));
				list2.Add(new Vector2(num8 / num, num6 / num7));
				list2.Add(new Vector2(x, num5 / num7));
				list2.Add(new Vector2(1f, num5 / num7));
				list3.Add(new Vector2(0f, num6 / num7));
				list3.Add(new Vector2(num8 / num, num6 / num7));
				list3.Add(new Vector2(x, num5 / num7));
				list3.Add(new Vector2(1f, num5 / num7));
				list4.Add(Color.white);
				list4.Add(Color.white);
				list4.Add(Color.white);
				list4.Add(Color.white);
				list5.Add(Color.white);
				list5.Add(Color.white);
				list5.Add(Color.white);
				list5.Add(Color.white);
				if (i < exitOuterVerticesExtrusion[0].Count - 1)
				{
					list6.Add(num4);
					list6.Add(num4 + 4);
					list6.Add(num4 + 1);
					list6.Add(num4 + 1);
					list6.Add(num4 + 4);
					list6.Add(num4 + 5);
					list6.Add(num4 + 2);
					list6.Add(num4 + 6);
					list6.Add(num4 + 3);
					list6.Add(num4 + 3);
					list6.Add(num4 + 6);
					list6.Add(num4 + 7);
				}
				num3++;
			}
			if (exitRoad.fixedDistance >= 1f)
			{
				num6 += Vector3.Distance(exitInnerVertices[num3 - 1], exitInnerVertices[num3]);
				num5 += Vector3.Distance(exitOuterVerticesExtrusion[0][exitOuterVerticesExtrusion[0].Count - 1], exitOuterVerticesFixed[0][0]);
			}
			else
			{
				num6 += Vector3.Distance(exitInnerVertices[num3 - 1], exitInnerVertices[num3]);
				num5 += Vector3.Distance(exitOuterVerticesExtrusion[0][exitOuterVerticesExtrusion[0].Count - 1], exitOuterVerticesCurve[0][0]);
			}
			num4 = list.Count;
			list6.Add(num4 - 4);
			list6.Add(num4);
			list6.Add(num4 - 3);
			list6.Add(num4 - 2);
			list6.Add(num4);
			list6.Add(num4 + 1);
			list6.Add(num4 - 1);
			list6.Add(num4 - 2);
			list6.Add(num4 + 1);
			if (exitRoad.fixedDistance >= 1f)
			{
				for (int j = 0; j < exitOuterVerticesFixed[0].Count; j++)
				{
					num4 = list.Count;
					list.Add(exitInnerVertices[num3 + j]);
					list.Add(exitOuterVerticesFixed[0][j]);
					if (j > 0)
					{
						num6 += Vector3.Distance(exitInnerVertices[num3 + j - 1], exitInnerVertices[num3 + j]);
						num5 += Vector3.Distance(exitOuterVerticesFixed[0][j - 1], exitOuterVerticesFixed[0][j]);
					}
					list2.Add(new Vector2(0f, num6 / num7));
					list2.Add(new Vector2(1f, num5 / num7));
					list3.Add(new Vector2(0f, num6 / num7));
					list3.Add(new Vector2(1f, num5 / num7));
					list4.Add(Color.white);
					list4.Add(Color.white);
					list5.Add(Color.white);
					list5.Add(Color.white);
					if (j < exitOuterVerticesFixed[0].Count - 1)
					{
						list6.Add(num4);
						list6.Add(num4 + 2);
						list6.Add(num4 + 1);
						list6.Add(num4 + 1);
						list6.Add(num4 + 2);
						list6.Add(num4 + 3);
					}
				}
				num3 += exitOuterVerticesFixed[0].Count;
				if (num3 < exitInnerVertices.Count)
				{
					num6 += Vector3.Distance(exitInnerVertices[num3 - 1], exitInnerVertices[num3]);
				}
				if (exitOuterVerticesCurve[0].Count > exitOuterVerticesFixed[0].Count - 1 && exitOuterVerticesCurve[0].Count > 0)
				{
					num5 += Vector3.Distance(exitOuterVerticesFixed[0][exitOuterVerticesFixed[0].Count - 1], exitOuterVerticesCurve[0][0]);
				}
				num4 = list.Count;
				list6.Add(num4 - 2);
				list6.Add(num4);
				list6.Add(num4 - 1);
				list6.Add(num4 - 1);
				list6.Add(num4);
				list6.Add(num4 + 1);
			}
			for (int k = 0; k < exitOuterVerticesCurve[0].Count; k++)
			{
				num4 = list.Count;
				list.Add(exitInnerVertices[num3 + k]);
				list.Add(exitOuterVerticesCurve[0][k]);
				if (k > 0)
				{
					num6 += Vector3.Distance(exitInnerVertices[k - 1], exitInnerVertices[k]);
					num5 += Vector3.Distance(exitInnerVertices[k - 1], exitInnerVertices[k]);
				}
				list2.Add(new Vector2(0f, num6 / num7));
				list2.Add(new Vector2(1f, num5 / num7));
				list3.Add(new Vector2(0f, num6 / num7));
				list3.Add(new Vector2(1f, num5 / num7));
				list4.Add(Color.white);
				list4.Add(Color.white);
				list5.Add(Color.white);
				list5.Add(Color.white);
				if (k < exitOuterVerticesCurve[0].Count - 1)
				{
					list6.Add(num4);
					list6.Add(num4 + 2);
					list6.Add(num4 + 1);
					list6.Add(num4 + 1);
					list6.Add(num4 + 2);
					list6.Add(num4 + 3);
				}
			}
			num3 += exitOuterVerticesCurve[0].Count;
			OCOCDCDDOD(list, list2, list6, list5, roadMaterial, exitRoad.gameObject, road);
		}

		public static void ODQDCCQCDD(ERModularBase baseScript, ERModularRoad road, List<ERMarkerExt> markers)
		{
			List<Vector3> list = new List<Vector3>();
			List<Vector2> list2 = new List<Vector2>();
			List<Vector2> list3 = new List<Vector2>();
			List<Color> list4 = new List<Color>();
			List<Color> list5 = new List<Color>();
			List<int> list6 = new List<int>();
			for (int i = 0; i < markers.Count; i++)
			{
				if (!markers[i].attachExit)
				{
					continue;
				}
				GameObject gameObject = null;
				OCDCDDDQOC componentInChildren = road.gameObject.GetComponentInChildren<OCDCDDDQOC>();
				if (componentInChildren != null)
				{
					gameObject = componentInChildren.gameObject;
				}
				else
				{
					gameObject = new GameObject("Exit Road");
					gameObject.AddComponent<OCDCDDDQOC>();
					gameObject.transform.parent = road.transform;
				}
				Material mat = null;
				float x = 0.9f;
				float num = 5f;
				if (markers[i].exitRoadType != 0)
				{
					mat = baseScript.roadTypes[markers[i].exitRoadType - 1].roadMaterial;
					num = baseScript.roadTypes[markers[i].exitRoadType - 1].roadWidth;
				}
				int num2 = 0;
				int num3 = 0;
				int num4 = 0;
				float num5 = 0f;
				float num6 = 0f;
				float num7 = 5f;
				for (int j = 0; j < markers[i].exitOuterVerticesExtrusion[0].Count; j++)
				{
					num4 = list.Count;
					list.Add(markers[i].exitInnerVertices[j]);
					list.Add(markers[i].exitOuterVerticesExtrusion[1][j]);
					list.Add(markers[i].exitOuterVerticesExtrusion[1][j]);
					list.Add(markers[i].exitOuterVerticesExtrusion[0][j]);
					if (j > 0)
					{
						num6 += Vector3.Distance(markers[i].exitInnerVertices[j - 1], markers[i].exitInnerVertices[j]);
						num5 += Vector3.Distance(markers[i].exitOuterVerticesExtrusion[0][j - 1], markers[i].exitOuterVerticesExtrusion[0][j]);
					}
					float num8 = Vector3.Distance(markers[i].exitInnerVertices[j], markers[i].exitOuterVerticesExtrusion[1][j]);
					list2.Add(new Vector2(0f, num6 / num7));
					list2.Add(new Vector2(num8 / num, num6 / num7));
					list2.Add(new Vector2(x, num5 / num7));
					list2.Add(new Vector2(1f, num5 / num7));
					list3.Add(new Vector2(0f, num6 / num7));
					list3.Add(new Vector2(num8 / num, num6 / num7));
					list3.Add(new Vector2(x, num5 / num7));
					list3.Add(new Vector2(1f, num5 / num7));
					list4.Add(Color.white);
					list4.Add(Color.white);
					list4.Add(Color.white);
					list4.Add(Color.white);
					list5.Add(Color.white);
					list5.Add(Color.white);
					list5.Add(Color.white);
					list5.Add(Color.white);
					if (j < markers[i].exitOuterVerticesExtrusion[0].Count - 1)
					{
						list6.Add(num4);
						list6.Add(num4 + 4);
						list6.Add(num4 + 1);
						list6.Add(num4 + 1);
						list6.Add(num4 + 4);
						list6.Add(num4 + 5);
						list6.Add(num4 + 2);
						list6.Add(num4 + 6);
						list6.Add(num4 + 3);
						list6.Add(num4 + 3);
						list6.Add(num4 + 6);
						list6.Add(num4 + 7);
					}
					num3++;
				}
				if (markers[i].fixedDistance != 0f)
				{
					num6 += Vector3.Distance(markers[i].exitInnerVertices[num3 - 1], markers[i].exitInnerVertices[num3]);
					num5 += Vector3.Distance(markers[i].exitOuterVerticesExtrusion[0][markers[i].exitOuterVerticesExtrusion[0].Count - 1], markers[i].exitOuterVerticesFixed[0][0]);
				}
				else
				{
					num6 += Vector3.Distance(markers[i].exitInnerVertices[num3 - 1], markers[i].exitInnerVertices[num3]);
					num5 += Vector3.Distance(markers[i].exitOuterVerticesExtrusion[0][markers[i].exitOuterVerticesExtrusion[0].Count - 1], markers[i].exitOuterVerticesCurve[0][0]);
				}
				num4 = list.Count;
				list6.Add(num4 - 4);
				list6.Add(num4);
				list6.Add(num4 - 3);
				list6.Add(num4 - 2);
				list6.Add(num4);
				list6.Add(num4 + 1);
				list6.Add(num4 - 1);
				list6.Add(num4 - 2);
				list6.Add(num4 + 1);
				if (markers[i].fixedDistance != 0f)
				{
					for (int k = 0; k < markers[i].exitOuterVerticesFixed[0].Count; k++)
					{
						num4 = list.Count;
						list.Add(markers[i].exitInnerVertices[num3 + k]);
						list.Add(markers[i].exitOuterVerticesFixed[0][k]);
						if (k > 0)
						{
							num6 += Vector3.Distance(markers[i].exitInnerVertices[num3 + k - 1], markers[i].exitInnerVertices[num3 + k]);
							num5 += Vector3.Distance(markers[i].exitOuterVerticesFixed[0][k - 1], markers[i].exitOuterVerticesFixed[0][k]);
						}
						list2.Add(new Vector2(0f, num6 / num7));
						list2.Add(new Vector2(1f, num5 / num7));
						list3.Add(new Vector2(0f, num6 / num7));
						list3.Add(new Vector2(1f, num5 / num7));
						list4.Add(Color.white);
						list4.Add(Color.white);
						list5.Add(Color.white);
						list5.Add(Color.white);
						if (k < markers[i].exitOuterVerticesFixed[0].Count - 1)
						{
							list6.Add(num4);
							list6.Add(num4 + 2);
							list6.Add(num4 + 1);
							list6.Add(num4 + 1);
							list6.Add(num4 + 2);
							list6.Add(num4 + 3);
						}
					}
					num3 += markers[i].exitOuterVerticesFixed[0].Count;
					if (num3 < markers[i].exitInnerVertices.Count)
					{
						num6 += Vector3.Distance(markers[i].exitInnerVertices[num3 - 1], markers[i].exitInnerVertices[num3]);
					}
					if (markers[i].exitOuterVerticesCurve[0].Count > markers[i].exitOuterVerticesFixed[0].Count - 1 && markers[i].exitOuterVerticesCurve[0].Count > 0)
					{
						num5 += Vector3.Distance(markers[i].exitOuterVerticesFixed[0][markers[i].exitOuterVerticesFixed[0].Count - 1], markers[i].exitOuterVerticesCurve[0][0]);
					}
					num4 = list.Count;
					list6.Add(num4 - 2);
					list6.Add(num4);
					list6.Add(num4 - 1);
					list6.Add(num4 - 1);
					list6.Add(num4);
					list6.Add(num4 + 1);
				}
				for (int l = 0; l < markers[i].exitOuterVerticesCurve[0].Count; l++)
				{
					num4 = list.Count;
					list.Add(markers[i].exitInnerVertices[num3 + l]);
					list.Add(markers[i].exitOuterVerticesCurve[0][l]);
					if (l > 0)
					{
						num6 += Vector3.Distance(markers[i].exitInnerVertices[l - 1], markers[i].exitInnerVertices[l]);
						num5 += Vector3.Distance(markers[i].exitInnerVertices[l - 1], markers[i].exitInnerVertices[l]);
					}
					list2.Add(new Vector2(0f, num6 / num7));
					list2.Add(new Vector2(1f, num5 / num7));
					list3.Add(new Vector2(0f, num6 / num7));
					list3.Add(new Vector2(1f, num5 / num7));
					list4.Add(Color.white);
					list4.Add(Color.white);
					list5.Add(Color.white);
					list5.Add(Color.white);
					if (l < markers[i].exitOuterVerticesCurve[0].Count - 1)
					{
						list6.Add(num4);
						list6.Add(num4 + 2);
						list6.Add(num4 + 1);
						list6.Add(num4 + 1);
						list6.Add(num4 + 2);
						list6.Add(num4 + 3);
					}
				}
				num3 += markers[i].exitOuterVerticesCurve[0].Count;
				OCOCDCDDOD(list, list2, list6, list5, mat, gameObject, road);
			}
		}

		public static void OQCDQCQDDC(ERModularBase baseScript, List<ERMarkerExt> markers, ref List<Vector3> vecs, ref List<Vector2> uvsArray, ref List<Vector2> uvsArray2, ref List<Color> customColors, ref List<Color> colors, ref List<List<int>> tris, ref Material[] materialsList)
		{
			for (int i = 0; i < markers.Count; i++)
			{
				if (!markers[i].attachExit)
				{
					continue;
				}
				Material m = null;
				float x = 0.9f;
				float num = 5f;
				if (markers[i].exitRoadType != 0)
				{
					m = baseScript.roadTypes[markers[i].exitRoadType - 1].roadMaterial;
					num = baseScript.roadTypes[markers[i].exitRoadType - 1].roadWidth;
				}
				int triIndex = 0;
				OOOQCQCODC(ref triIndex, ref tris, ref materialsList, m);
				int num2 = 0;
				int num3 = 0;
				float num4 = 0f;
				float num5 = 0f;
				float num6 = 5f;
				for (int j = 0; j < markers[i].exitOuterVerticesExtrusion[0].Count; j++)
				{
					num3 = vecs.Count;
					vecs.Add(markers[i].exitInnerVertices[j]);
					vecs.Add(markers[i].exitOuterVerticesExtrusion[1][j]);
					vecs.Add(markers[i].exitOuterVerticesExtrusion[1][j]);
					vecs.Add(markers[i].exitOuterVerticesExtrusion[0][j]);
					if (j > 0)
					{
						num5 += Vector3.Distance(markers[i].exitInnerVertices[j - 1], markers[i].exitInnerVertices[j]);
						num4 += Vector3.Distance(markers[i].exitOuterVerticesExtrusion[0][j - 1], markers[i].exitOuterVerticesExtrusion[0][j]);
					}
					float num7 = Vector3.Distance(markers[i].exitInnerVertices[j], markers[i].exitOuterVerticesExtrusion[1][j]);
					uvsArray.Add(new Vector2(0f, num5 / num6));
					uvsArray.Add(new Vector2(num7 / num, num5 / num6));
					uvsArray.Add(new Vector2(x, num4 / num6));
					uvsArray.Add(new Vector2(1f, num4 / num6));
					uvsArray2.Add(new Vector2(0f, num5 / num6));
					uvsArray2.Add(new Vector2(num7 / num, num5 / num6));
					uvsArray2.Add(new Vector2(x, num4 / num6));
					uvsArray2.Add(new Vector2(1f, num4 / num6));
					customColors.Add(Color.white);
					customColors.Add(Color.white);
					customColors.Add(Color.white);
					customColors.Add(Color.white);
					colors.Add(Color.white);
					colors.Add(Color.white);
					colors.Add(Color.white);
					colors.Add(Color.white);
					if (j < markers[i].exitOuterVerticesExtrusion[0].Count - 1)
					{
						tris[triIndex].Add(num3);
						tris[triIndex].Add(num3 + 4);
						tris[triIndex].Add(num3 + 1);
						tris[triIndex].Add(num3 + 1);
						tris[triIndex].Add(num3 + 4);
						tris[triIndex].Add(num3 + 5);
						tris[triIndex].Add(num3 + 2);
						tris[triIndex].Add(num3 + 6);
						tris[triIndex].Add(num3 + 3);
						tris[triIndex].Add(num3 + 3);
						tris[triIndex].Add(num3 + 6);
						tris[triIndex].Add(num3 + 7);
					}
					num2++;
				}
				if (markers[i].fixedDistance != 0f)
				{
					num5 += Vector3.Distance(markers[i].exitInnerVertices[num2 - 1], markers[i].exitInnerVertices[num2]);
					num4 += Vector3.Distance(markers[i].exitOuterVerticesExtrusion[0][markers[i].exitOuterVerticesExtrusion[0].Count - 1], markers[i].exitOuterVerticesFixed[0][0]);
				}
				else
				{
					num5 += Vector3.Distance(markers[i].exitInnerVertices[num2 - 1], markers[i].exitInnerVertices[num2]);
					num4 += Vector3.Distance(markers[i].exitOuterVerticesExtrusion[0][markers[i].exitOuterVerticesExtrusion[0].Count - 1], markers[i].exitOuterVerticesCurve[0][0]);
				}
				num3 = vecs.Count;
				tris[triIndex].Add(num3 - 4);
				tris[triIndex].Add(num3);
				tris[triIndex].Add(num3 - 3);
				tris[triIndex].Add(num3 - 2);
				tris[triIndex].Add(num3);
				tris[triIndex].Add(num3 + 1);
				tris[triIndex].Add(num3 - 1);
				tris[triIndex].Add(num3 - 2);
				tris[triIndex].Add(num3 + 1);
				if (markers[i].fixedDistance >= 1f)
				{
					for (int k = 0; k < markers[i].exitOuterVerticesFixed[0].Count; k++)
					{
						num3 = vecs.Count;
						vecs.Add(markers[i].exitInnerVertices[num2 + k]);
						vecs.Add(markers[i].exitOuterVerticesFixed[0][k]);
						if (k > 0)
						{
							num5 += Vector3.Distance(markers[i].exitInnerVertices[num2 + k - 1], markers[i].exitInnerVertices[num2 + k]);
							num4 += Vector3.Distance(markers[i].exitOuterVerticesFixed[0][k - 1], markers[i].exitOuterVerticesFixed[0][k]);
						}
						uvsArray.Add(new Vector2(0f, num5 / num6));
						uvsArray.Add(new Vector2(1f, num4 / num6));
						uvsArray2.Add(new Vector2(0f, num5 / num6));
						uvsArray2.Add(new Vector2(1f, num4 / num6));
						customColors.Add(Color.white);
						customColors.Add(Color.white);
						colors.Add(Color.white);
						colors.Add(Color.white);
						if (k < markers[i].exitOuterVerticesFixed[0].Count - 1)
						{
							tris[triIndex].Add(num3);
							tris[triIndex].Add(num3 + 2);
							tris[triIndex].Add(num3 + 1);
							tris[triIndex].Add(num3 + 1);
							tris[triIndex].Add(num3 + 2);
							tris[triIndex].Add(num3 + 3);
						}
					}
					num2 += markers[i].exitOuterVerticesFixed[0].Count;
					if (num2 < markers[i].exitInnerVertices.Count)
					{
						num5 += Vector3.Distance(markers[i].exitInnerVertices[num2 - 1], markers[i].exitInnerVertices[num2]);
					}
					if (markers[i].exitOuterVerticesCurve[0].Count > markers[i].exitOuterVerticesFixed[0].Count - 1 && markers[i].exitOuterVerticesCurve[0].Count > 0)
					{
						num4 += Vector3.Distance(markers[i].exitOuterVerticesFixed[0][markers[i].exitOuterVerticesFixed[0].Count - 1], markers[i].exitOuterVerticesCurve[0][0]);
					}
					num3 = vecs.Count;
					tris[triIndex].Add(num3 - 2);
					tris[triIndex].Add(num3);
					tris[triIndex].Add(num3 - 1);
					tris[triIndex].Add(num3 - 1);
					tris[triIndex].Add(num3);
					tris[triIndex].Add(num3 + 1);
				}
				for (int l = 0; l < markers[i].exitOuterVerticesCurve[0].Count; l++)
				{
					num3 = vecs.Count;
					vecs.Add(markers[i].exitInnerVertices[num2 + l]);
					vecs.Add(markers[i].exitOuterVerticesCurve[0][l]);
					if (l > 0)
					{
						num5 += Vector3.Distance(markers[i].exitInnerVertices[l - 1], markers[i].exitInnerVertices[l]);
						num4 += Vector3.Distance(markers[i].exitInnerVertices[l - 1], markers[i].exitInnerVertices[l]);
					}
					uvsArray.Add(new Vector2(0f, num5 / num6));
					uvsArray.Add(new Vector2(1f, num4 / num6));
					uvsArray2.Add(new Vector2(0f, num5 / num6));
					uvsArray2.Add(new Vector2(1f, num4 / num6));
					customColors.Add(Color.white);
					customColors.Add(Color.white);
					colors.Add(Color.white);
					colors.Add(Color.white);
					if (l < markers[i].exitOuterVerticesCurve[0].Count - 1)
					{
						tris[triIndex].Add(num3);
						tris[triIndex].Add(num3 + 2);
						tris[triIndex].Add(num3 + 1);
						tris[triIndex].Add(num3 + 1);
						tris[triIndex].Add(num3 + 2);
						tris[triIndex].Add(num3 + 3);
					}
				}
				num2 += markers[i].exitOuterVerticesCurve[0].Count;
			}
		}

		public static void OOOQCQCODC(ref int triIndex, ref List<List<int>> tris, ref Material[] materialsList, Material m)
		{
			for (int i = 0; i < materialsList.Length; i++)
			{
				if (materialsList[i] == m)
				{
					triIndex = i;
					return;
				}
			}
			tris.Add(new List<int>());
			triIndex = tris.Count - 1;
			List<Material> list = new List<Material>(materialsList);
			list.Add(m);
			materialsList = list.ToArray();
		}

		public static float OCDDCQQDQD(Vector3 v, List<Vector3> soSplinePointsLeft, List<Vector3> soSplinePointsRight, ref int cInt, bool flag, ref int match)
		{
			for (int i = cInt; i < soSplinePointsLeft.Count; i++)
			{
				if (OQQOCDQCQD.OOCQODQDQD(soSplinePointsRight[i], soSplinePointsLeft[i], v))
				{
					match = i;
					if (flag)
					{
						cInt = i;
					}
					return OQQOCDQCQD.OQOOCCQQOQ(soSplinePointsLeft[i - 1], soSplinePointsLeft[i], soSplinePointsRight[i], v);
				}
			}
			return v.y;
		}

		private static void OCOCDCDDOD(List<Vector3> vecs, List<Vector2> uvs, List<int> tris, List<Color> colors, Material mat, GameObject go, ERModularRoad road)
		{
			if (go == null)
			{
				go = new GameObject("exit");
				go.AddComponent<MeshFilter>();
				go.AddComponent<MeshRenderer>();
				go.AddComponent<MeshCollider>();
				go.GetComponent<MeshRenderer>().material = mat;
				go.transform.parent = road.transform;
				go.layer = road.gameObject.layer;
			}
			if (go.GetComponent<MeshFilter>() == null)
			{
				go.AddComponent<MeshFilter>();
			}
			if (go.GetComponent<MeshRenderer>() == null)
			{
				go.AddComponent<MeshRenderer>();
			}
			go.GetComponent<MeshRenderer>().material = mat;
			Mesh mesh;
			if (go.GetComponent<MeshFilter>().sharedMesh != null)
			{
				mesh = go.GetComponent<MeshFilter>().sharedMesh;
			}
			else
			{
				mesh = new Mesh();
				go.GetComponent<MeshFilter>().sharedMesh = mesh;
				if (go.GetComponent<MeshCollider>() == null)
				{
					go.AddComponent<MeshCollider>();
				}
				go.GetComponent<MeshCollider>().sharedMesh = mesh;
			}
			if (go.GetComponent<MeshCollider>() == null)
			{
				go.AddComponent<MeshCollider>();
				go.GetComponent<MeshCollider>().sharedMesh = mesh;
			}
			mesh.Clear();
			mesh.vertices = vecs.ToArray();
			mesh.uv = uvs.ToArray();
			mesh.colors = colors.ToArray();
			mesh.triangles = tris.ToArray();
			mesh.RecalculateNormals();
			mesh.RecalculateBounds();
			mesh.RecalculateTangents();
			go.GetComponent<MeshCollider>().sharedMesh = null;
			go.GetComponent<MeshCollider>().sharedMesh = mesh;
		}

		private void OCODCCQOQD(List<Vector3> vecs, List<int> connectionInts, List<Vector3> surfaceVecs, Vector3 prefDirVec)
		{
			if (connector == null)
			{
				GameObject gameObject = new GameObject("Exit Road Connector");
				ERConnectionParent eRConnectionParent = (ERConnectionParent)UnityEngine.Object.FindObjectOfType(typeof(ERConnectionParent));
				if (eRConnectionParent != null)
				{
					gameObject.transform.parent = eRConnectionParent.transform;
				}
				connector = gameObject.AddComponent<ERCrossingPrefabs>();
				connector.crossingElements.Add(new QDOODOQQDQODD());
				connector.isExitRoadConnector = true;
				connector.isSnapConnector = true;
			}
			if (connector == null)
			{
				Debug.Log("EasyRooads3D warning: No connector attached to exit road");
				return;
			}
			if (connector.crossingElements.Count == 0)
			{
				connector.crossingElements.Add(new QDOODOQQDQODD());
			}
			connector.meshVecs = vecs.ToArray();
			connector.tmpMeshVecs = new Vector3[connector.meshVecs.Length];
			Array.Copy(connector.meshVecs, connector.tmpMeshVecs, connector.meshVecs.Length);
			connector.tmpFullMeshVecs = new Vector3[connector.meshVecs.Length];
			Array.Copy(connector.meshVecs, connector.tmpFullMeshVecs, connector.meshVecs.Length);
			connector.fullMeshVecs = new Vector3[connector.meshVecs.Length];
			Array.Copy(connector.meshVecs, connector.fullMeshVecs, connector.meshVecs.Length);
			Vector3 normalized = (vecs[0] - vecs[1]).normalized;
			Vector3 normalized2 = (prefDirVec - vecs[0]).normalized;
			Vector3 vector = base.transform.InverseTransformPoint(connectionHandlePosition);
			connector.crossingElements[0].centerPoint = (connector.crossingElements[0].tmpCenterPoint = vector);
			connector.crossingElements[0].controlPointV3 = vector + normalized2 * 15f;
			connector.isExitRoadConnector = true;
			connector.prefabCenterDummy = prefDirVec;
			connector.crossingElements[0].connectionVecInts = new List<int>(connectionInts);
			connector.crossingElements[0].fullConnectionVecInts = new List<int>(connectionInts);
			Vector3 leftSurroundingV = vecs[0] + normalized * 8f;
			connector.crossingElements[0].leftSurroundingV3 = leftSurroundingV;
			leftSurroundingV = vecs[1] + -normalized * 8f;
			connector.crossingElements[0].rightSurroundingV3 = leftSurroundingV;
			leftSurroundingV = vecs[0] + normalized * 3f;
			connector.crossingElements[0].leftIndentV3 = leftSurroundingV;
			leftSurroundingV = vecs[1] + -normalized * 3f;
			connector.crossingElements[0].rightIndentV3 = leftSurroundingV;
			int num = 0;
			int num2 = connectionInts.Count - 1;
			connector.crossingElements[0].leftInt = num;
			connector.crossingElements[0].leftIntFull = num;
			connector.crossingElements[0].rightInt = num2;
			connector.crossingElements[0].rightIntFull = num2;
			connector.crossingElements[0].leftSurroundingV3 = surfaceVecs[surfaceVecs.Count - 1];
			connector.crossingElements[0].leftIndentV3 = surfaceVecs[surfaceVecs.Count - 2];
			connector.crossingElements[0].rightIndentV3 = surfaceVecs[surfaceVecs.Count - 4];
			connector.crossingElements[0].rightSurroundingV3 = surfaceVecs[surfaceVecs.Count - 5];
			connector.crossingElements[0].leftSurrounding = surfaceVecs.Count - 1;
			connector.crossingElements[0].leftIndent = surfaceVecs.Count - 2;
			connector.crossingElements[0].rightIndent = surfaceVecs.Count - 4;
			connector.crossingElements[0].rightSurrounding = surfaceVecs.Count - 5;
			connector.crossingElements[0].roadShapeVecs = new List<Vector2>(roadType.roadShape);
			connector.crossingElements[0].roadShapeUVY = new List<float>(roadType.roadShapeUVs);
			connector.crossingElements[0].roadShapeUVY2 = new List<float>(roadType.roadShapeUVs2);
			connector.surfaceMeshVecs = surfaceVecs.ToArray();
			connector.crossingElements[0].roadType = roadType.id;
			connector.crossingElements[0].roadShapeMatchCount = vecs.Count;
			connector.doTerrainDeformation = road.terrainDeformation;
		}

		public Vector3 OOQODDDCQC()
		{
			Vector3 pos = Vector3.zero;
			int num = OQQOCDQCQD.ODDQOCDCQQ(road.soSplinePoints, offset * road.markersExt[markerIndex].totalDistance, road.markersExt[markerIndex].startSplinePoint, ref pos);
			OQCCCQCQOD = OQQOCDQCQD.OCOOQOQCDC(road.soSplinePointsRight[num], road.soSplinePointsRight[num + 1], pos);
			handleDirection = (road.soSplinePointsRight[num + 1] - road.soSplinePointsRight[num]).normalized;
			if (road != null && roadType == null)
			{
				roadType = QDQDOOQQDQODD.GetRoadTypeElByID(road.baseScript.roadTypes, roadTypeID);
			}
			if (roadType != null)
			{
				Vector3 normalized = (OQCCCQCQOD - pos).normalized;
				OQCCCQCQOD -= normalized;
			}
			return OQCCCQCQOD;
		}

		public void ODQQOOQDOC(List<Vector3> surfaceVecs, List<Vector2> uvs, int firstSection, int secondSection)
		{
			if (surfaceMesh == null)
			{
				ERSurfaceScript componentInChildren = base.gameObject.GetComponentInChildren<ERSurfaceScript>();
				if (componentInChildren != null)
				{
					surfaceMesh = componentInChildren.gameObject;
				}
			}
			if (surfaceMesh == null)
			{
				surfaceMesh = new GameObject("surface");
				surfaceMesh.hideFlags = HideFlags.HideInHierarchy;
				surfaceMesh.AddComponent<MeshFilter>();
				surfaceMesh.AddComponent<MeshRenderer>();
				surfaceMesh.AddComponent<MeshCollider>();
				surfaceMesh.AddComponent<ERSurfaceScript>();
				ERModularBase eRModularBase = UnityEngine.Object.FindObjectOfType<ERModularBase>();
				if (eRModularBase != null)
				{
					surfaceMesh.GetComponent<MeshRenderer>().material = eRModularBase.surfaceMaterial;
				}
				surfaceMesh.transform.parent = base.transform;
				surfaceMesh.GetComponent<MeshRenderer>().enabled = !road.baseScript.hideSurfaces;
				surfaceMesh.GetComponent<MeshCollider>().enabled = !road.baseScript.hideSurfaces;
				surfaceMesh.layer = road.baseScript.sLayer;
			}
			if (surfaceMesh.GetComponent<MeshFilter>() == null)
			{
				surfaceMesh.AddComponent<MeshFilter>();
			}
			Mesh mesh;
			if (surfaceMesh.GetComponent<MeshFilter>().sharedMesh != null)
			{
				mesh = surfaceMesh.GetComponent<MeshFilter>().sharedMesh;
			}
			else
			{
				mesh = new Mesh();
				surfaceMesh.GetComponent<MeshFilter>().sharedMesh = mesh;
				if (surfaceMesh.GetComponent<MeshCollider>() == null)
				{
					surfaceMesh.AddComponent<MeshCollider>();
				}
				surfaceMesh.GetComponent<MeshCollider>().sharedMesh = mesh;
			}
			if (surfaceMesh.GetComponent<MeshCollider>() == null)
			{
				surfaceMesh.AddComponent<MeshCollider>();
				surfaceMesh.GetComponent<MeshCollider>().sharedMesh = mesh;
			}
			if (!road.terrainDeformation)
			{
				UnityEngine.Object.DestroyImmediate(surfaceMesh);
				return;
			}
			surfaceMesh.layer = road.baseScript.sLayer;
			int num = 0;
			List<int> list = new List<int>();
			int num2 = 3;
			int num3 = 1;
			int num4 = firstSection + 1;
			for (int i = 0; i < num4 - 1; i += num3)
			{
				for (int j = 0; j < num2 - 1; j++)
				{
					list.Add(num + j);
					list.Add(num + num2 + j + 1);
					list.Add(num + j + 1);
					list.Add(num + num2 + j);
					list.Add(num + num2 + j + 1);
					list.Add(num + j);
				}
				num += 3;
			}
			num += 3;
			surfaceVecs[num - 3] = surfaceVecs[num + 1];
			surfaceVecs[num - 2] = surfaceVecs[num + 3];
			surfaceVecs[num - 1] = surfaceVecs[num + 4];
			secondSection += firstSection;
			num2 = 5;
			for (int k = firstSection; k < secondSection; k += num3)
			{
				for (int l = 0; l < num2 - 1; l++)
				{
					list.Add(num + l);
					list.Add(num + num2 + l + 1);
					list.Add(num + l + 1);
					list.Add(num + num2 + l);
					list.Add(num + num2 + l + 1);
					list.Add(num + l);
				}
				num += 5;
			}
			mesh.Clear();
			mesh.vertices = surfaceVecs.ToArray();
			mesh.uv = uvs.ToArray();
			mesh.tangents = new Vector4[surfaceVecs.Count];
			mesh.triangles = list.ToArray();
			mesh.RecalculateNormals();
			mesh.RecalculateBounds();
			surfaceMesh.GetComponent<MeshCollider>().sharedMesh = null;
			surfaceMesh.GetComponent<MeshCollider>().sharedMesh = mesh;
			if (surfaceMesh.GetComponent<MeshCollider>().sharedMesh == null)
			{
				UnityEngine.Object.DestroyImmediate(surfaceMesh.GetComponent<MeshCollider>());
				surfaceMesh.AddComponent<MeshCollider>();
				if (surfaceMesh.GetComponent<MeshCollider>().sharedMesh == null)
				{
					Debug.LogWarning("EasyRoads3Dv3 Warning: No mesh assigned to the surface mesh Collider");
				}
			}
			if (road.baseScript.hideSurfaces)
			{
				surfaceMesh.GetComponent<MeshCollider>().enabled = false;
				surfaceMesh.SetActive(value: false);
				surfaceMesh.SetActive(value: true);
				return;
			}
			if ((bool)surfaceMesh.GetComponent<MeshRenderer>())
			{
				surfaceMesh.GetComponent<MeshRenderer>().enabled = true;
			}
			if ((bool)surfaceMesh.GetComponent<MeshCollider>())
			{
				surfaceMesh.GetComponent<MeshCollider>().enabled = true;
			}
		}
	}
}
