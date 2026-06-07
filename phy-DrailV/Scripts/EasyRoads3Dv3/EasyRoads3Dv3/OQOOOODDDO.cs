using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	public class OQOOOODDDO : MonoBehaviour
	{
		public static List<Vector3> OQQOQCQQQD(ERModularRoad scr, int startMarker, int endMarker, List<ERMarkerExt> markers, float faceDist, bool ignorePrefabAlignment, ref List<float> tValues, ref List<float> markerDistances)
		{
			int num = 0;
			if (startMarker > 0)
			{
				num = scr.markersExt[startMarker].startSplinePoint;
			}
			float num2 = 0f;
			if (startMarker > 0)
			{
				num2 = scr.markersExt[startMarker].startDistance;
			}
			scr.startDir = (scr.endDir = Vector3.zero);
			scr.tmpMarkersExt.Clear();
			scr.tmpMarkersExt.AddRange(markers);
			if (scr.closedTrack && endMarker >= scr.markersExt.Count)
			{
				scr.tmpMarkersExt.Add(markers[0]);
			}
			List<Vector3> tmpNodes = new List<Vector3>();
			List<float> list = new List<float>();
			for (int i = startMarker; i <= endMarker; i++)
			{
				tmpNodes.Add(scr.tmpMarkersExt[i].position);
				if (scr.tmpMarkersExt[i].splineStrength == 0f)
				{
					scr.tmpMarkersExt[i].splineStrength = 0.5f;
				}
				list.Add(scr.tmpMarkersExt[i].splineStrength);
			}
			if (startMarker != 0)
			{
				tmpNodes.Insert(0, scr.tmpMarkersExt[startMarker - 1].position);
				list.Insert(0, scr.tmpMarkersExt[startMarker - 1].splineStrength);
			}
			else if (scr.startPrefabScript == null)
			{
				if (scr.closedTrack && scr.tmpMarkersExt[0].controlType == 0)
				{
					tmpNodes.Insert(0, scr.markersExt[markers.Count - 1].position);
					list.Insert(0, scr.markersExt[markers.Count - 1].splineStrength);
				}
				else
				{
					tmpNodes.Insert(0, tmpNodes[0]);
					list.Insert(0, list[0]);
				}
			}
			else if (!ignorePrefabAlignment && scr.startPrefabScript.crossingElements[scr.startConnectionSegment].rotationPriority)
			{
				tmpNodes.Insert(0, tmpNodes[0]);
				list.Insert(0, list[0]);
				Vector3 p = tmpNodes[2];
				if (tmpNodes.Count >= 4)
				{
					p = tmpNodes[3];
				}
				Vector3 v = ERModularRoad.OQODDDCOQD(tmpNodes[0], tmpNodes[1], tmpNodes[2], p, 0.5f, 0.5f);
				scr.startPrefabScript.ODOOOQODQC(tmpNodes[0], v, scr.startConnectionSegment, scr);
			}
			else
			{
				Vector3 lastForward = Vector3.zero;
				ODQCQOODDO.ODOOOQOOQO(scr, ref tmpNodes, list, scr.startPrefabScript, scr.startConnectionSegment, ref scr.startDir, ref lastForward, 0);
			}
			if (endMarker < scr.markersExt.Count - 1)
			{
				tmpNodes.Add(scr.tmpMarkersExt[endMarker + 1].position);
				list.Add(scr.tmpMarkersExt[endMarker + 1].splineStrength);
			}
			else if (scr.endPrefabScript == null)
			{
				if (scr.closedTrack && scr.tmpMarkersExt[0].controlType == 0)
				{
					if (endMarker < markers.Count)
					{
						tmpNodes.Add(scr.tmpMarkersExt[0].position);
						list.Add(scr.tmpMarkersExt[0].splineStrength);
					}
					else
					{
						tmpNodes.Add(scr.tmpMarkersExt[1].position);
						list.Add(scr.tmpMarkersExt[1].splineStrength);
					}
				}
				else if (scr.closedTrack && (scr.tmpMarkersExt[0].controlType == 1 || scr.tmpMarkersExt[0].controlType == 2))
				{
					Vector3 endCP = Vector3.zero;
					scr.OQDCOOCQOQ(ref endCP, tmpNodes[tmpNodes.Count - 2], tmpNodes[tmpNodes.Count - 1], tmpNodes[2]);
					tmpNodes.Add(endCP);
					list.Add(list[list.Count - 1]);
				}
				else
				{
					tmpNodes.Add(tmpNodes[tmpNodes.Count - 1]);
					list.Add(list[list.Count - 1]);
				}
			}
			else if (!ignorePrefabAlignment && scr.endPrefabScript.crossingElements[scr.endConnectionSegment].rotationPriority)
			{
				tmpNodes.Add(tmpNodes[tmpNodes.Count - 1]);
				list.Add(list[list.Count - 1]);
				Vector3 p = tmpNodes[tmpNodes.Count - 3];
				if (tmpNodes.Count >= 4)
				{
					p = tmpNodes[tmpNodes.Count - 4];
				}
				Vector3 v2 = ERModularRoad.OQODDDCOQD(p, tmpNodes[tmpNodes.Count - 3], tmpNodes[tmpNodes.Count - 2], tmpNodes[tmpNodes.Count - 1], 0.5f, 0.5f);
				scr.endPrefabScript.ODOOOQODQC(tmpNodes[tmpNodes.Count - 1], v2, scr.endConnectionSegment, scr);
			}
			else
			{
				ODQCQOODDO.ODOOOQOOQO(scr, ref tmpNodes, list, scr.endPrefabScript, scr.endConnectionSegment, ref scr.endDir, ref scr.lastForward, 1);
			}
			Vector3[] array = tmpNodes.ToArray();
			float num3 = 0f;
			Vector3 a = array[1];
			List<Vector3> splinePoints = new List<Vector3>();
			Vector3 vector = Vector3.zero;
			bool flag = false;
			scr.totalDistance = 0f;
			scr.nodeSplinePoint.Clear();
			scr.nodeSplinePoint.Add(0);
			int num4 = 0;
			Vector3 startCP = array[0];
			Vector3 endCP2 = array[3];
			Vector3 lastHeightAdjustCP = Vector3.zero;
			if (scr.tmpMarkersExt.Count > startMarker + 1 && scr.tmpMarkersExt[startMarker + 1].controlType == 3)
			{
				Vector3 normalized = (array[2] - array[1]).normalized;
				endCP2 = array[2] + normalized * Vector3.Distance(array[2], array[3]);
				endCP2.y = array[3].y;
			}
			markerDistances.Add(0f);
			List<float> tValues2 = new List<float>();
			List<Vector3> segPoints = new List<Vector3>();
			float num5 = 0f;
			scr.p3 = array[1];
			scr.p4 = array[0];
			float xzDistance = 0f;
			for (int j = 1; j < array.Length - 2; j++)
			{
				float totalDist = 0f;
				if (j > 1)
				{
					scr.markersExt[startMarker + j - 1].startSplinePoint = num + splinePoints.Count;
					scr.markersExt[startMarker + j - 1].startDistance = num2 + scr.totalDistance;
				}
				scr.segPoints.Clear();
				tValues2.Clear();
				segPoints.Clear();
				if (scr.tmpMarkersExt[startMarker + j - 1].controlType == 0)
				{
					float num6 = Vector3.Distance(array[j], array[j + 1]);
					float num7 = 0.2f / num6;
					if (num3 > 0f)
					{
						num3 -= 1f;
					}
					num3 = 0f;
					float num8 = 0.5f;
					for (float num9 = num3; num9 < 1f; num9 += num7)
					{
						flag = false;
						Vector3 vector2 = ERModularRoad.OQODDDCOQD(startCP, array[j], array[j + 1], endCP2, num9, list[j]);
						if (num9 + num7 > 1f && Vector3.Distance(vector2, array[j + 1]) < 0.25f)
						{
							vector2 = array[j + 1];
							flag = true;
						}
						if (Vector3.Distance(a, vector2) > faceDist || flag || (j == 1 && num9 == 0f))
						{
							num6 = Vector3.Distance(a, vector2);
							scr.totalDistance += num6;
							totalDist += num6;
							a = vector2;
							vector = vector2;
							segPoints.Add(vector);
							tValues2.Add(num9);
							if (flag)
							{
								scr.nodeSplinePoint.Add(num4);
							}
							num4++;
						}
					}
				}
				else if (scr.tmpMarkersExt[startMarker + j - 1].controlType == 1 || scr.tmpMarkersExt[startMarker + j - 1].controlType == 2)
				{
					if (j == 1)
					{
						vector = array[j];
					}
					Vector3 normalized = (array[j + 1] - array[j]).normalized;
					totalDist = Vector3.Distance(array[j + 1], array[j]);
					float num6 = faceDist;
					if (j == 1)
					{
						num6 = 0f;
					}
					for (; num6 < totalDist; num6 += faceDist)
					{
						Vector3 lastForward = vector + normalized * num6;
						if (Vector3.Distance(lastForward, array[j + 1]) > 0.5f * faceDist)
						{
							segPoints.Add(vector + normalized * num6);
							num5 = num6 / totalDist;
							tValues2.Add(num5);
						}
					}
					if (scr.tmpMarkersExt[j - 1].controlType == 1)
					{
						for (int i = 0; i < tValues2.Count; i++)
						{
							Vector3 lastForward = ERModularRoad.OQODDDCOQD(array[j - 1], array[j], array[j + 1], array[j + 2], tValues2[i], 0.5f);
							Vector3 value = segPoints[i];
							value.y = lastForward.y;
							segPoints[i] = value;
						}
					}
					num4 += segPoints.Count;
					vector = segPoints[segPoints.Count - 1];
					scr.totalDistance += totalDist;
					scr.nodeSplinePoint.Add(num4);
				}
				else if (scr.tmpMarkersExt[startMarker + j - 1].controlType == 3)
				{
					ODQCQOODDO.ODDCDDDCOQ(ref splinePoints, scr, j, ref segPoints, ref tValues2, ref totalDist, startMarker, ref xzDistance, getDistance: false);
					for (int i = 0; i < tValues2.Count; i++)
					{
						Vector3 lastForward = ERModularRoad.OQODDDCOQD(array[j - 1], array[j], array[j + 1], array[j + 2], tValues2[i], 0.5f);
						Vector3 value = segPoints[i];
						value.y = lastForward.y;
						segPoints[i] = value;
					}
					scr.segPoints.AddRange(segPoints);
					num4 += segPoints.Count;
					vector = segPoints[segPoints.Count - 1];
					scr.totalDistance += totalDist;
					scr.nodeSplinePoint.Add(num4);
				}
				if (scr.tmpMarkersExt[startMarker + j - 1].followTerrainContours)
				{
					ODQCQOODDO.OQOQQDOQDD(scr.baseScript, ref segPoints, tValues2, scr.terrainContoursOffset, ref lastHeightAdjustCP, scr.faceDistance, totalDist, scr.tmpMarkersExt[startMarker + j].followTerrainContours, splinePoints, ref scr.testPoints, ref scr.randomRotations);
				}
				splinePoints.AddRange(segPoints);
				tValues.AddRange(tValues2);
				scr.OOCCQOOOCQ(scr.tmpMarkersExt, j, array, vector, totalDist, ref startCP, startMarker, splinePoints);
				if (array.Length > j + 3)
				{
					scr.OOQDDDDDCD(scr.tmpMarkersExt, j, array, ref endCP2, startMarker);
				}
				markerDistances.Add(scr.totalDistance);
				if (scr.markersExt.Count > startMarker + j)
				{
					scr.markersExt[startMarker + j].direction = (splinePoints[splinePoints.Count - 1] - splinePoints[splinePoints.Count - 2]).normalized;
				}
				if (j == 1)
				{
					scr.markersExt[startMarker + j - 1].direction = (splinePoints[1] - splinePoints[0]).normalized;
				}
			}
			if (!scr.closedTrack)
			{
				scr.markersExt[endMarker].startSplinePoint = num + splinePoints.Count;
				scr.markersExt[endMarker].startDistance = num2 + scr.totalDistance;
				scr.markersExt[0].startSplinePoint = 0;
				scr.markersExt[0].startDistance = 0f;
			}
			else if (endMarker == scr.markersExt.Count - 1)
			{
				scr.markersExt[0].startSplinePoint = num + splinePoints.Count;
				scr.markersExt[0].startDistance = num2 + scr.totalDistance;
			}
			return splinePoints;
		}

		public static void OCCCCCCDCC(ERModularRoad scr, bool ignorePrefabAlignment, List<Vector3> splinePoints, List<float> tValues, List<float> markerDistances, int startMarker, int endMarker, int startInt)
		{
			scr.vecsBelowTerrain.Clear();
			if (scr.markersExt.Count < scr.controlPoints.Count)
			{
				scr.markersExt.Clear();
				for (int i = 0; i < scr.controlPoints.Count; i++)
				{
					scr.markersExt.Add(ERMarkerExt.CreateInstance(scr.controlPoints[i], scr, scr.markersExt.Count));
				}
			}
			List<float> OQCODCDCDC = new List<float>();
			List<float> randomRotations = new List<float>();
			List<float> list = scr.OQCDDDCOOD(tValues, markerDistances, scr.markersExt, startMarker, endMarker + 1, ref OQCODCDCDC, randomRotations);
			List<Vector3> list2 = new List<Vector3>();
			List<Vector2> list3 = new List<Vector2>();
			List<Vector3> surfaceVecs = new List<Vector3>();
			float minIndent = scr.baseScript.minIndent;
			float minSurrounding = scr.baseScript.minSurrounding;
			Debug.Log("fffffffff ");
			scr.treeVecs.Clear();
			scr.detailVecs.Clear();
			scr.vegetationTris.Clear();
			List<List<int>> list4 = new List<List<int>>();
			list4.Clear();
			for (int i = 0; i < scr.roadMaterials.Length; i++)
			{
				list4.Add(new List<int>());
			}
			int num = 0;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			float num5 = 0f;
			float num6 = 0f;
			float num7 = 5f;
			scr.roadWidth = Vector2.Distance(new Vector2(scr.roadShape[0].x, 0f), new Vector2(scr.roadShape[scr.roadShape.Count - 1].x, 0f));
			scr.nodeDistance.Clear();
			scr.nodeDistance.Add(0f);
			for (int i = 1; i < scr.roadShape.Count; i++)
			{
				scr.nodeDistance.Add(Vector2.Distance(new Vector2(scr.roadShape[0].x, 0f), new Vector2(scr.roadShape[i].x, 0f)) / scr.roadWidth);
			}
			int[] array = new int[scr.roadShape.Count];
			int[] array2 = new int[scr.roadShape.Count];
			bool[] array3 = new bool[scr.roadShape.Count];
			bool[] array4 = new bool[scr.roadShape.Count];
			bool flag = true;
			bool flag2 = false;
			bool startSurfacesSafe = false;
			Vector3 vector = Vector3.zero;
			Vector3 vector2 = Vector3.zero;
			Vector3 vector3 = Vector3.zero;
			Vector3 p = Vector3.zero;
			bool flag3 = false;
			float num8 = 0f;
			int num9 = -1;
			float num10 = 0f;
			Vector3 a = Vector3.zero;
			Vector3 vector4 = Vector3.zero;
			Vector3 vector5 = Vector3.zero;
			Vector3 p2 = Vector3.zero;
			float num11 = 0f;
			int num12 = -1;
			int endAdjustInt = 0;
			float num13 = 0f;
			float num14 = 30f;
			if (scr.totalDistance < num14)
			{
				num14 = scr.totalDistance;
			}
			if (scr.startPrefabScript != null && scr.endPrefabScript != null && scr.totalDistance * 0.5f < num14)
			{
				num14 = scr.totalDistance * 0.5f;
			}
			float num15 = num14;
			float endAdjustDistance = num14;
			if (scr.startPrefabScript != null && startMarker == 0)
			{
				QDOODOQQDQODD qDOODOQQDQODD = scr.startPrefabScript.crossingElements[scr.startConnectionSegment];
				scr.ODODCOOOCD = scr.startPrefabScript.tmpMeshVecs[qDOODOQQDQODD.connectionVecInts[qDOODOQQDQODD.connectionVecInts.Count - 1]];
				scr.ODODCOOOCD = scr.startPrefabScript.transform.TransformPoint(scr.ODODCOOOCD);
				scr.OOOQOODOCD = scr.startPrefabScript.tmpMeshVecs[qDOODOQQDQODD.connectionVecInts[0]];
				scr.OOOQOODOCD = scr.startPrefabScript.transform.TransformPoint(scr.OOOQOODOCD);
				vector2 = scr.startPrefabScript.transform.TransformPoint(scr.startPrefabScript.crossingElements[scr.startConnectionSegment].leftIndentV3);
				vector3 = scr.startPrefabScript.transform.TransformPoint(scr.startPrefabScript.crossingElements[scr.startConnectionSegment].rightIndentV3);
				p = scr.startPrefabScript.transform.TransformPoint(Vector3.zero);
				num8 = scr.startPrefabScript.crossingElements[scr.startConnectionSegment].additionalIndentDistance;
				flag3 = false;
				num9 = ((scr.startbendLeftRight != -1) ? ODQCQOODDO.OOQOCQDDDC(scr, splinePoints, scr.baseScript.minIndent, scr.roadShape[scr.roadShape.Count - 1].x, vector3, vector2, scr.startbendLeftRight) : ODQCQOODDO.OOQOCQDDDC(scr, splinePoints, scr.baseScript.minIndent, scr.roadShape[0].x, vector3, vector2, scr.startbendLeftRight));
			}
			else
			{
				flag2 = true;
				startSurfacesSafe = true;
			}
			int num16 = 0;
			bool surfacesSafe = true;
			if (scr.endPrefabScript != null && endMarker == scr.markersExt.Count - 1)
			{
				surfacesSafe = false;
				QDOODOQQDQODD qDOODOQQDQODD = scr.endPrefabScript.crossingElements[scr.endConnectionSegment];
				scr.endLeft = scr.endPrefabScript.tmpMeshVecs[qDOODOQQDQODD.connectionVecInts[0]];
				scr.endLeft = scr.endPrefabScript.transform.TransformPoint(scr.endLeft);
				scr.endRight = scr.endPrefabScript.tmpMeshVecs[qDOODOQQDQODD.connectionVecInts[qDOODOQQDQODD.connectionVecInts.Count - 1]];
				scr.endRight = scr.endPrefabScript.transform.TransformPoint(scr.endRight);
				num16 = Mathf.RoundToInt(Mathf.Ceil(scr.roadWidth / (scr.faceDistance * 1f)));
				vector4 = scr.endPrefabScript.transform.TransformPoint(scr.endPrefabScript.crossingElements[scr.endConnectionSegment].leftIndentV3);
				vector5 = scr.endPrefabScript.transform.TransformPoint(scr.endPrefabScript.crossingElements[scr.endConnectionSegment].rightIndentV3);
				p2 = scr.endPrefabScript.transform.TransformPoint(Vector3.zero);
				num11 = scr.endPrefabScript.crossingElements[scr.endConnectionSegment].additionalIndentDistance;
				num12 = ((scr.endbendLeftRight != -1) ? ODQCQOODDO.ODODDODDCO(scr, splinePoints, scr.baseScript.minIndent, scr.roadShape[0].x, vector5, vector4, scr.endbendLeftRight, ref endAdjustInt, ref endAdjustDistance) : ODQCQOODDO.ODODDODDCO(scr, splinePoints, scr.baseScript.minIndent, scr.roadShape[scr.roadShape.Count - 1].x, vector5, vector4, scr.endbendLeftRight, ref endAdjustInt, ref endAdjustDistance));
			}
			bool flag4 = false;
			if (scr.startPrefabScript != null && scr.startPrefabScript.surfaceMeshVecs.Length == 0)
			{
				flag4 = true;
			}
			bool flag5 = false;
			if (scr.endPrefabScript != null && scr.endPrefabScript.surfaceMeshVecs.Length == 0)
			{
				flag5 = true;
			}
			Vector3 zero = Vector3.zero;
			int num17 = 0;
			bool item = false;
			List<bool> list5 = new List<bool>();
			Vector3 firstDir = Vector3.zero;
			Vector3 lastDir = Vector3.zero;
			for (int i = 0; i < splinePoints.Count; i++)
			{
				if (splinePoints[i] == scr.markersExt[num17 + 1].position)
				{
					item = scr.markersExt[num17 + 1].bridgeObject;
					if (scr.markersExt.Count > num17 + 1)
					{
						num17++;
					}
				}
				list5.Add(item);
				if (i > 0)
				{
					num3 = Vector3.Distance(splinePoints[i - 1], splinePoints[i]);
					num2 += num3;
				}
				num6 = num2 / num7;
				Vector3 vector6 = ((i == 0) ? (splinePoints[i + 1] - splinePoints[i]).normalized : ((i != splinePoints.Count - 1) ? (splinePoints[i + 1] - splinePoints[i - 1]).normalized : (splinePoints[i] - splinePoints[i - 1]).normalized));
				if (i == 0)
				{
					firstDir = vector6;
				}
				lastDir = vector6;
				zero = ODQCQOODDO.GetEulerAngles(vector6);
				vector6 = new Vector3(0f - vector6.z, 0f, vector6.x);
				if (!flag2 && i < splinePoints.Count - 2)
				{
					vector = (splinePoints[i + 1] - splinePoints[i]).normalized;
					vector = new Vector3(0f - vector.z, 0f, vector.x);
				}
				int count = scr.roadShape.Count;
				Vector3 vector8;
				Vector3 vector7 = (vector8 = Vector3.zero);
				Vector3 vector9;
				for (int j = 0; j < scr.roadShape.Count; j++)
				{
					vector9 = ((list[i] == 0f) ? (splinePoints[i] + vector6 * scr.roadShape[j].x) : ODQCQOODDO.ODCCODOOQQ(splinePoints[i], scr.roadShape[j], 180f - list[i], zero));
					if (startMarker == 0 && scr.startPrefabScript != null && i < num9 && !flag4)
					{
						vector9.y = OCQCDQCQOQ.OQOQQQQCQD(vector2, vector3, p, vector9);
						num10 = num2;
					}
					else if (startMarker == 0 && scr.startPrefabScript != null && num2 - num10 < num15 - num10 && !flag4)
					{
						Vector3 p3 = vector9;
						p3.y = OCQCDQCQOQ.OQOQQQQCQD(vector2, vector3, p, p3);
						float t = (num2 - num10) / (num15 - num10);
						vector9.y = Mathf.Lerp(p3.y, vector9.y, Mathf.SmoothStep(0f, 1f, t));
					}
					if (endMarker == scr.markersExt.Count - 1 && scr.endPrefabScript != null && i > num12 && !flag5)
					{
						vector9.y = OCQCDQCQOQ.OQOQQQQCQD(vector4, vector5, p2, vector9);
					}
					else if (endMarker == scr.markersExt.Count - 1 && scr.endPrefabScript != null && i >= endAdjustInt && !flag5)
					{
						if (j == 0)
						{
							num4 += num3;
						}
						Vector3 p4 = vector9;
						p4.y = OCQCDQCQOQ.OQOQQQQCQD(vector4, vector5, p2, p4);
						float t = num4 / endAdjustDistance;
						vector9.y = Mathf.Lerp(vector9.y, p4.y, Mathf.SmoothStep(0f, 1f, t));
					}
					if (j == 0)
					{
						vector7 = vector9;
						vector7.y -= 0.05f;
					}
					if (j == scr.roadShape.Count - 1)
					{
						vector8 = vector9;
						vector8.y -= scr.roadShape[j].y;
					}
					vector8 = vector9;
					vector8.y -= 0.05f;
					if (list[i] == 0f)
					{
						vector9.y += scr.roadShape[j].y;
					}
					list2.Add(vector9);
					list3.Add(new Vector2(scr.roadShapeUVs[j], num6));
					if (i < splinePoints.Count - 1 && j < scr.roadShape.Count - 1)
					{
						flag = true;
						if (!flag2)
						{
							flag = false;
							if (!array3[j] || !array3[j + 1])
							{
								if (i == 0)
								{
									array[j] = -1;
									array[j + 1] = -1;
								}
								if (!array3[j])
								{
									Vector3 pCheck = splinePoints[i + 1] + vector * scr.roadShape[j].x;
									if (ERCrossingPrefabs.OOOOCDQQOC(scr.ODODCOOOCD, scr.OOOQOODOCD, pCheck))
									{
										array3[j] = true;
									}
								}
								if (!array3[j + 1])
								{
									Vector3 pCheck = splinePoints[i + 1] + vector * scr.roadShape[j + 1].x;
									if (ERCrossingPrefabs.OOOOCDQQOC(scr.ODODCOOOCD, scr.OOOQOODOCD, pCheck))
									{
										array3[j + 1] = true;
									}
								}
								if (array3[j] && array3[j + 1])
								{
									flag = true;
									if (array[j] == -1)
									{
										array[j] = i;
									}
									if (array[j + 1] == -1)
									{
										array[j + 1] = i;
									}
								}
							}
							flag = true;
						}
						if (scr.endPrefabScript != null && i > splinePoints.Count - num16)
						{
							flag = true;
							Vector3 pCheck = splinePoints[i] + vector6 * scr.roadShape[j].x;
							if (ERCrossingPrefabs.OOOOCDQQOC(scr.endRight, scr.endLeft, pCheck))
							{
								pCheck = splinePoints[i] + vector6 * scr.roadShape[j + 1].x;
								if (ERCrossingPrefabs.OOOOCDQQOC(scr.endRight, scr.endLeft, pCheck))
								{
									flag = true;
								}
							}
						}
						num = scr.roadShapeMaterialInts[j];
						if (flag)
						{
							list4[num].Add(i * count + j);
							list4[num].Add((i + 1) * count + j + 1);
							list4[num].Add(i * count + j + 1);
							list4[num].Add((i + 1) * count + j);
							list4[num].Add((i + 1) * count + j + 1);
							list4[num].Add(i * count + j);
						}
					}
					if (flag2)
					{
						continue;
					}
					flag2 = true;
					for (int k = 0; k < array3.Length; k++)
					{
						if (!array3[k])
						{
							flag2 = false;
						}
					}
				}
				if (startMarker == 0 && scr.startPrefabScript != null && num5 < num8 * 6f)
				{
					if (scr.startbendLeftRight == -1)
					{
						if (i > 0)
						{
							num5 += Vector3.Distance(a, vector7);
						}
						a = vector7;
					}
					else
					{
						if (i > 0)
						{
							num5 += Vector3.Distance(a, vector8);
						}
						a = vector8;
					}
				}
				Vector3 normalized = (vector7 - vector8).normalized;
				vector9 = vector7 + normalized * (minIndent + minSurrounding);
				scr.baseScript.OCCDCQCOQC(ref vector9);
				surfaceVecs.Add(vector9);
				vector9 = vector7 + normalized * minIndent;
				surfaceVecs.Add(vector9);
				vector9 = vector8 + -normalized * minIndent;
				surfaceVecs.Add(vector9);
				vector9 = vector8 + -normalized * (minIndent + minSurrounding);
				scr.baseScript.OCCDCQCOQC(ref vector9);
				surfaceVecs.Add(vector9);
				if (!startSurfacesSafe && !flag4)
				{
					if (i == 0)
					{
						surfaceVecs[3] = scr.startPrefabScript.transform.TransformPoint(scr.startPrefabScript.crossingElements[scr.startConnectionSegment].leftSurroundingV3);
						surfaceVecs[0] = scr.startPrefabScript.transform.TransformPoint(scr.startPrefabScript.crossingElements[scr.startConnectionSegment].rightSurroundingV3);
						surfaceVecs[2] = scr.startPrefabScript.transform.TransformPoint(scr.startPrefabScript.crossingElements[scr.startConnectionSegment].leftIndentV3);
						surfaceVecs[1] = scr.startPrefabScript.transform.TransformPoint(scr.startPrefabScript.crossingElements[scr.startConnectionSegment].rightIndentV3);
					}
					else
					{
						ODQCQOODDO.OCOCQQCCCC(scr, ref surfaceVecs, scr.startPrefabScript, ref startSurfacesSafe, num2, scr.baseScript.minIndent);
					}
				}
				if (i == 0)
				{
					scr.sv1 = vector7;
					scr.sv2 = vector8;
					scr.sv1 = vector7 + vector6 * minIndent;
					scr.sv2 = vector8 + -vector6 * minIndent;
				}
			}
			Vector2[] array5 = list3.ToArray();
			float num18 = 1f / list3[list3.Count - 1].y * Mathf.Floor(list3[list3.Count - 1].y);
			for (int i = 0; i < array5.Length - 1; i += scr.roadShape.Count)
			{
				for (int j = 0; j < scr.roadShape.Count; j++)
				{
					if (j == 0)
					{
						array5[i + j].y = array5[i].y * num18;
					}
					else
					{
						array5[i + j].y = array5[i].y;
					}
				}
			}
			if (startMarker == 0 && scr.startPrefabScript != null)
			{
				if (scr.startPrefabScript.meshVecs.Length == 0)
				{
				}
				int num19 = list2.Count - 1;
				int count2 = scr.roadShape.Count;
				bool flag6 = false;
				if (ERCrossingPrefabs.OOOOCDQQOC(list2[count2], list2[0], list2[count2 * 2]))
				{
					flag6 = true;
				}
				List<int> connectionVecInts = scr.startPrefabScript.crossingElements[scr.startConnectionSegment].connectionVecInts;
				for (int i = 0; i < scr.roadShape.Count; i++)
				{
					if (i + array[i] * scr.roadShape.Count < 0)
					{
						Debug.LogError("The angle with the crossing is too small");
						break;
					}
					list2[i + array[i] * scr.roadShape.Count] = scr.startPrefabScript.transform.TransformPoint(scr.startPrefabScript.tmpMeshVecs[connectionVecInts[scr.roadShape.Count - i - 1]]);
					if (scr.startPrefabScript.crossingElements[scr.startConnectionSegment].rotationPriority)
					{
						continue;
					}
					float num20 = scr.roadWidth / Mathf.Tan(scr.startAngle * ((float)Math.PI / 180f));
					float num21 = (flag6 ? (10f + (1f - scr.nodeDistance[i]) * num20 * 2f) : (10f + scr.nodeDistance[i] * num20 * 2f));
					float num22 = 0f;
					int num23 = 1;
					Vector3 a2;
					Vector3 vector9 = (a2 = list2[i + array[i] * scr.roadShape.Count]);
					while (num22 < num21)
					{
						Vector3 vector10 = list2[i + (array[i] + num23) * scr.roadShape.Count];
						num22 += Vector3.Distance(a2, vector10);
						Vector3 normalized2 = (vector10 - vector9).normalized;
						Vector3 vector11 = Vector3.Lerp(-scr.startDir, normalized2, num22 / num21);
						Vector3 a3 = vector9 + vector11 * num22;
						list2[i + (array[i] + num23) * scr.roadShape.Count] = Vector3.Lerp(a3, vector10, Mathf.SmoothStep(0f, 1f, num22 / num21));
						a2 = vector10;
						num23++;
						if (i + (array[i] + num23) * scr.roadShape.Count > list2.Count - 1)
						{
							break;
						}
					}
				}
			}
			if (endMarker == scr.markersExt.Count - 1 && scr.endPrefabScript != null)
			{
				if (scr.endPrefabScript.meshVecs.Length == 0)
				{
					scr.endPrefabScript.OODDCDQQDO();
				}
				int num19 = list2.Count - 1;
				int count2 = scr.roadShape.Count;
				bool flag6 = false;
				if (ERCrossingPrefabs.OOOOCDQQOC(list2[num19], list2[num19 - count2], list2[num19 - count2 * 2]))
				{
					flag6 = true;
				}
				int num24 = list2.Count - scr.roadShape.Count;
				List<int> connectionVecInts = scr.endPrefabScript.crossingElements[scr.endConnectionSegment].connectionVecInts;
				for (int i = 0; i < scr.roadShape.Count; i++)
				{
					list2[num24 + i] = scr.endPrefabScript.transform.TransformPoint(scr.endPrefabScript.tmpMeshVecs[connectionVecInts[i]]);
					if (scr.endPrefabScript.crossingElements[scr.endConnectionSegment].rotationPriority)
					{
						continue;
					}
					float num20 = scr.roadWidth / Mathf.Tan(scr.endAngle * ((float)Math.PI / 180f));
					float num21 = (flag6 ? (10f + (1f - scr.nodeDistance[i]) * num20 * 2f) : (3f + scr.nodeDistance[i] * num20 * 2f));
					float num22 = 0f;
					int num23 = 0;
					Vector3 a2;
					Vector3 vector9 = (a2 = list2[num24 + i - num23 * scr.roadShape.Count]);
					num23 = 1;
					while (num22 < num21 && num24 + i - num23 * scr.roadShape.Count >= 0)
					{
						Vector3 vector10 = list2[num24 + i - num23 * scr.roadShape.Count];
						num22 += Vector3.Distance(a2, vector10);
						Vector3 normalized2 = (vector10 - vector9).normalized;
						Vector3 vector11 = Vector3.Lerp(-scr.endDir, normalized2, num22 / num21);
						Vector3 a3 = vector9 + vector11 * num22;
						list2[num24 + i - num23 * scr.roadShape.Count] = Vector3.Lerp(a3, vector10, Mathf.SmoothStep(0f, 1f, num22 / num21));
						a2 = vector10;
						num23++;
						if (num24 + i - num23 * scr.roadShape.Count > list2.Count - 1)
						{
							break;
						}
					}
				}
			}
			if (scr.closedTrack)
			{
				for (int i = 0; i < scr.roadShape.Count; i++)
				{
					list2[list2.Count - scr.roadShape.Count + i] = list2[i];
				}
			}
			scr.meshVecs.InsertRange(startInt * scr.roadShape.Count, list2);
			scr.meshUVs.InsertRange(startInt * scr.roadShape.Count, new List<Vector2>(array5));
			for (int i = 0; i < scr.tris.Count; i++)
			{
				scr.tris[i].InsertRange(startInt * scr.roadShapeMaterialIntCounts[i] * 3, list4[i]);
			}
			Debug.LogError("we have to update existing triangle int values after the affected area!");
			OCCCCCCDCC(scr);
			num2 = 0f;
			if ((bool)scr.endPrefabScript && !flag5)
			{
				for (int l = 0; (!surfacesSafe || l < surfaceVecs.Count - 4) && surfaceVecs.Count - l - 6 >= 0; l += 4)
				{
					if (!surfacesSafe)
					{
						ODQCQOODDO.OCQDQDDCQO(scr, ref surfaceVecs, scr.endPrefabScript, l, ref surfacesSafe, num2, scr.baseScript.minIndent);
					}
					num2 += Vector3.Distance(surfaceVecs[surfaceVecs.Count - 2 - l], surfaceVecs[surfaceVecs.Count - 2 - l - 4]);
				}
			}
			if (scr.closedTrack)
			{
				surfaceVecs[surfaceVecs.Count - 4] = surfaceVecs[0];
				surfaceVecs[surfaceVecs.Count - 3] = surfaceVecs[1];
				surfaceVecs[surfaceVecs.Count - 2] = surfaceVecs[2];
				surfaceVecs[surfaceVecs.Count - 1] = surfaceVecs[3];
				Debug.LogError("adjust the above: add surface vecs first to full surface array. Then make sure start and end vecs are the same");
			}
			scr.OOCCDQQODC(surfaceVecs, new List<Vector2>(), splinePoints.Count, list5, firstDir, lastDir, minIndent, minSurrounding);
		}

		public static void OCCCCCCDCC(ERModularRoad scr)
		{
			if (scr.gameObject.GetComponent<MeshFilter>() == null)
			{
				scr.gameObject.AddComponent<MeshFilter>();
			}
			if (scr.gameObject.GetComponent<MeshRenderer>() == null)
			{
				scr.gameObject.AddComponent<MeshRenderer>();
			}
			if (scr.gameObject.GetComponent<MeshCollider>() == null)
			{
				scr.gameObject.AddComponent<MeshCollider>();
			}
			Mesh mesh;
			if (scr.gameObject.GetComponent<MeshFilter>().sharedMesh != null)
			{
				mesh = scr.gameObject.GetComponent<MeshFilter>().sharedMesh;
			}
			else
			{
				mesh = new Mesh();
				scr.gameObject.GetComponent<MeshFilter>().sharedMesh = mesh;
			}
			scr.gameObject.isStatic = true;
			mesh.Clear();
			mesh.vertices = scr.meshVecs.ToArray();
			mesh.uv = scr.meshUVs.ToArray();
			mesh.tangents = new Vector4[scr.meshVecs.Count];
			mesh.subMeshCount = scr.tris.Count;
			for (int i = 0; i < scr.tris.Count; i++)
			{
				mesh.SetTriangles(scr.tris[i].ToArray(), i);
			}
			mesh.RecalculateNormals();
			mesh.RecalculateBounds();
			scr.gameObject.GetComponent<MeshCollider>().sharedMesh = null;
			scr.gameObject.GetComponent<MeshCollider>().sharedMesh = mesh;
			scr.testmesh = mesh;
		}

		public static ERModularRoad DuplicateObject(ERModularRoad scr)
		{
			if (scr == null)
			{
				return null;
			}
			GameObject gameObject = UnityEngine.Object.Instantiate(scr.gameObject);
			gameObject.transform.parent = scr.transform.parent;
			List<GameObject> list = new List<GameObject>();
			foreach (Transform item in gameObject.transform)
			{
				list.Add(item.gameObject);
			}
			foreach (GameObject item2 in list)
			{
				UnityEngine.Object.DestroyImmediate(item2);
			}
			if ((bool)gameObject.GetComponent<MeshFilter>())
			{
				gameObject.GetComponent<MeshFilter>().sharedMesh = null;
			}
			if ((bool)gameObject.GetComponent<MeshCollider>())
			{
				gameObject.GetComponent<MeshCollider>().sharedMesh = null;
			}
			ERModularRoad component = gameObject.GetComponent<ERModularRoad>();
			component.road = null;
			component.soDataExt.Clear();
			foreach (ERSORoadExt item3 in scr.soDataExt)
			{
				component.soDataExt.Add(UnityEngine.Object.Instantiate(item3));
			}
			component.markersExt.Clear();
			for (int i = 0; i < scr.markersExt.Count; i++)
			{
				component.markersExt.Add(ODQCQOODDO.DuplicateMarker(scr.markersExt[i]));
			}
			string text = (gameObject.name = scr.name + "[Duplicate]");
			component.name = text;
			component.OCCCCCCDCC(ignorePrefabAlignment: false, forceAutoRotate: false);
			return component;
		}

		public static void CreateSplatMeshes(ERModularRoad scr, ref List<GameObject> soSplatmapObjects, float splatSize)
		{
			List<int> list = new List<int>();
			List<List<Vector3>> list2 = new List<List<Vector3>>();
			list2.Add(new List<Vector3>());
			for (int i = 0; i < scr.smoothLevel; i++)
			{
				list2.Add(new List<Vector3>());
			}
			Vector3 zero = Vector3.zero;
			for (int j = 0; j < scr.soSplinePoints.Count; j++)
			{
				Vector3 vector = scr.soSplinePointsLeft[j] - scr.soSplinePointsRight[j];
				vector = new Vector3(vector.x, 0f, vector.z).normalized;
				for (int i = 0; i < scr.smoothLevel + 1; i++)
				{
					zero = scr.soSplinePointsLeft[j] + vector * splatSize * (i + scr.expandLevel);
					zero.y = 0f;
					list2[i].Add(zero);
					zero = scr.soSplinePointsRight[j] - vector * splatSize * (i + scr.expandLevel);
					zero.y = 0f;
					list2[i].Add(zero);
				}
				if (j < scr.soSplinePoints.Count - 1)
				{
					list.Add(j * 2);
					list.Add(j * 2 + 2);
					list.Add(j * 2 + 3);
					list.Add(j * 2);
					list.Add(j * 2 + 3);
					list.Add(j * 2 + 1);
				}
			}
			for (int j = 0; j < list2.Count; j++)
			{
				string text = "color" + (scr.splatIndex + 1) + "_";
				text += (1f - (float)j * 1f / ((float)list2.Count * 1f)) * scr.splatOpacity;
				soSplatmapObjects.Add(BuildSplatMesh(scr, list2[j], list, text, j));
			}
		}

		public static GameObject BuildSplatMesh(ERModularRoad scr, List<Vector3> vecs, List<int> tris, string name, int pos)
		{
			GameObject gameObject = new GameObject("SplatGO" + name);
			gameObject.AddComponent<MeshFilter>();
			gameObject.AddComponent<MeshRenderer>();
			gameObject.AddComponent<MeshCollider>();
			gameObject.transform.parent = scr.transform;
			Vector3 zero = Vector3.zero;
			zero.y -= pos;
			gameObject.transform.position = zero;
			Mesh mesh = new Mesh();
			gameObject.layer = 31;
			mesh.vertices = vecs.ToArray();
			mesh.uv = new Vector2[vecs.Count];
			mesh.tangents = new Vector4[vecs.Count];
			mesh.triangles = tris.ToArray();
			mesh.RecalculateNormals();
			mesh.RecalculateBounds();
			gameObject.GetComponent<MeshFilter>().sharedMesh = mesh;
			gameObject.GetComponent<MeshCollider>().sharedMesh = mesh;
			gameObject.GetComponent<MeshCollider>().enabled = false;
			return gameObject;
		}

		public static void SetMarkerIndentAlignment(ERMarkerExt m, ERModularRoad scr)
		{
			Vector3 direction = m.direction;
			Vector3 position = m.position;
			Vector3 normalized = new Vector3(direction.z, 0f, 0f - direction.x).normalized;
			Vector3 pos = position + normalized * -2f;
			Vector3 pos2 = position + normalized * 2f;
			scr.baseScript.OCCDCQCOQC(ref pos);
			scr.baseScript.OCCDCQCOQC(ref pos2);
			if (pos.y < pos2.y)
			{
				m.leftIndentAlignment = 1;
				m.rightIndentAlignment = 0;
			}
			else
			{
				m.leftIndentAlignment = 0;
				m.rightIndentAlignment = 1;
			}
		}

		public static float GetleftToCenterPerc(List<Vector2> nodeList, int left, int right)
		{
			float num = nodeList[right].x - nodeList[left].x;
			return nodeList[left].x * -1f / num;
		}

		public static void OQOOCQDOQD(ERModularRoad r1, ERModularRoad r2, ERCrossingPrefabs prefab)
		{
			if (prefab.isIConnector)
			{
				ERIConnector component = prefab.gameObject.GetComponent<ERIConnector>();
				if ((!(component.connectorLength1 > 0f) || !(component.connectorLength2 > 0f)) && !(component.connectorLength1 > 0f) && !(component.connectorLength2 > 0f) && !(r1.roadShapeString == r2.roadShapeString) && !(r1.roadShapeString == r2.roadShapeReversedString) && !(r1.roadShapeReversedString == r2.roadShapeString))
				{
				}
			}
		}

		public static void OCCODOQQOQ(ERModularRoad r1, ERModularRoad r2, int road1StartEnd, int road2StartEnd)
		{
		}

		public static void AverageTangentsRoadPrefab(ERModularRoad r1, ERCrossingPrefabs prefab, int road1StartEnd, int prefabStartEnd)
		{
		}
	}
}
