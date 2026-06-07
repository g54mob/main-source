using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[AddComponentMenu("")]
	public class OODCDDQOQC : MonoBehaviour
	{
		public static List<Vector3> OCCQQDQODQ(ERModularRoad scr, int startMarker, int endMarker, List<ERMarkerExt> markers, float faceDist, bool ignorePrefabAlignment, ref List<float> tValues, ref List<float> markerDistances, ref List<float> bendAngles)
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
				Vector3 v = ERModularRoad.OQQCQOQOOD(tmpNodes[0], tmpNodes[1], tmpNodes[2], p, 0.5f, 0.5f);
				scr.startPrefabScript.OCODOODQQQ(tmpNodes[0], v, scr.startConnectionSegment, scr);
			}
			else
			{
				Vector3 lastForward = Vector3.zero;
				OQOCQDQODD.OCCQDCCQCD(scr, ref tmpNodes, list, scr.startPrefabScript, scr.startConnectionSegment, ref scr.startDir, ref lastForward, 0);
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
					scr.OCQOCCOQDD(ref endCP, tmpNodes[tmpNodes.Count - 2], tmpNodes[tmpNodes.Count - 1], tmpNodes[2]);
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
				Vector3 p2 = tmpNodes[tmpNodes.Count - 3];
				if (tmpNodes.Count >= 4)
				{
					p2 = tmpNodes[tmpNodes.Count - 4];
				}
				Vector3 v2 = ERModularRoad.OQQCQOQOOD(p2, tmpNodes[tmpNodes.Count - 3], tmpNodes[tmpNodes.Count - 2], tmpNodes[tmpNodes.Count - 1], 0.5f, 0.5f);
				scr.endPrefabScript.OCODOODQQQ(tmpNodes[tmpNodes.Count - 1], v2, scr.endConnectionSegment, scr);
			}
			else
			{
				OQOCQDQODD.OCCQDCCQCD(scr, ref tmpNodes, list, scr.endPrefabScript, scr.endConnectionSegment, ref scr.endDir, ref scr.lastForward, 1);
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
						Vector3 vector2 = ERModularRoad.OQQCQOQOOD(startCP, array[j], array[j + 1], endCP2, num9, list[j]);
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
					Vector3 normalized2 = (array[j + 1] - array[j]).normalized;
					totalDist = Vector3.Distance(array[j + 1], array[j]);
					float num6 = faceDist;
					if (j == 1)
					{
						num6 = 0f;
					}
					for (; num6 < totalDist; num6 += faceDist)
					{
						Vector3 a2 = vector + normalized2 * num6;
						if (Vector3.Distance(a2, array[j + 1]) > 0.5f * faceDist)
						{
							segPoints.Add(vector + normalized2 * num6);
							num5 = num6 / totalDist;
							tValues2.Add(num5);
						}
					}
					if (scr.tmpMarkersExt[j - 1].controlType == 1)
					{
						for (int k = 0; k < tValues2.Count; k++)
						{
							Vector3 a2 = ERModularRoad.OQQCQOQOOD(array[j - 1], array[j], array[j + 1], array[j + 2], tValues2[k], 0.5f);
							Vector3 value = segPoints[k];
							value.y = a2.y;
							segPoints[k] = value;
						}
					}
					num4 += segPoints.Count;
					vector = segPoints[segPoints.Count - 1];
					scr.totalDistance += totalDist;
					scr.nodeSplinePoint.Add(num4);
				}
				else if (scr.tmpMarkersExt[startMarker + j - 1].controlType == 3)
				{
					float radius = 0f;
					OQOCQDQODD.OCCDOCDDCQ(ref splinePoints, scr, j, ref segPoints, ref tValues2, ref totalDist, startMarker, ref xzDistance, getDistance: false, ref radius, ref bendAngles);
					for (int l = 0; l < tValues2.Count; l++)
					{
						Vector3 vector3 = ERModularRoad.OQQCQOQOOD(array[j - 1], array[j], array[j + 1], array[j + 2], tValues2[l], 0.5f);
						Vector3 value2 = segPoints[l];
						value2.y = vector3.y;
						segPoints[l] = value2;
					}
					scr.segPoints.AddRange(segPoints);
					num4 += segPoints.Count;
					vector = segPoints[segPoints.Count - 1];
					scr.totalDistance += totalDist;
					scr.nodeSplinePoint.Add(num4);
				}
				if (scr.tmpMarkersExt[startMarker + j - 1].followTerrainContours)
				{
					OQOCQDQODD.ODODCDOCDC(scr.baseScript, ref segPoints, tValues2, scr.terrainContoursOffset, ref lastHeightAdjustCP, scr.faceDistance, totalDist, scr.tmpMarkersExt[startMarker + j].followTerrainContours, splinePoints, ref scr.testPoints, ref scr.randomRotations);
				}
				splinePoints.AddRange(segPoints);
				tValues.AddRange(tValues2);
				scr.OQCCOOOODQ(scr.tmpMarkersExt, j, array, vector, totalDist, ref startCP, startMarker, splinePoints);
				if (array.Length > j + 3)
				{
					scr.OQOCDDOQDC(scr.tmpMarkersExt, j, array, ref endCP2, startMarker);
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

		public static void ODDDQDQOOD(ERModularRoad scr, bool ignorePrefabAlignment, List<Vector3> splinePoints, List<float> tValues, List<float> markerDistances, int startMarker, int endMarker, int startInt)
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
			List<float> ODCODQCCDQ = new List<float>();
			List<float> randomRotations = new List<float>();
			List<float> list = scr.ODOCQDOCDD(tValues, markerDistances, scr.markersExt, startMarker, endMarker + 1, ref ODCODQCCDQ, randomRotations);
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
			for (int j = 0; j < scr.roadMaterials.Length; j++)
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
			for (int k = 1; k < scr.roadShape.Count; k++)
			{
				scr.nodeDistance.Add(Vector2.Distance(new Vector2(scr.roadShape[0].x, 0f), new Vector2(scr.roadShape[k].x, 0f)) / scr.roadWidth);
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
				scr.OCQOOQODCQ = scr.startPrefabScript.tmpMeshVecs[qDOODOQQDQODD.connectionVecInts[qDOODOQQDQODD.connectionVecInts.Count - 1]];
				scr.OCQOOQODCQ = scr.startPrefabScript.transform.TransformPoint(scr.OCQOOQODCQ);
				scr.OQQCCQDCOO = scr.startPrefabScript.tmpMeshVecs[qDOODOQQDQODD.connectionVecInts[0]];
				scr.OQQCCQDCOO = scr.startPrefabScript.transform.TransformPoint(scr.OQQCCQDCOO);
				vector2 = scr.startPrefabScript.transform.TransformPoint(scr.startPrefabScript.crossingElements[scr.startConnectionSegment].leftIndentV3);
				vector3 = scr.startPrefabScript.transform.TransformPoint(scr.startPrefabScript.crossingElements[scr.startConnectionSegment].rightIndentV3);
				p = scr.startPrefabScript.transform.TransformPoint(Vector3.zero);
				num8 = scr.startPrefabScript.crossingElements[scr.startConnectionSegment].additionalIndentDistance;
				flag3 = false;
				num9 = ((scr.startbendLeftRight != -1) ? OQOCQDQODD.OCQCOODQDD(scr, splinePoints, scr.baseScript.minIndent, scr.roadShape[scr.roadShape.Count - 1].x, vector3, vector2, scr.startbendLeftRight) : OQOCQDQODD.OCQCOODQDD(scr, splinePoints, scr.baseScript.minIndent, scr.roadShape[0].x, vector3, vector2, scr.startbendLeftRight));
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
				QDOODOQQDQODD qDOODOQQDQODD2 = scr.endPrefabScript.crossingElements[scr.endConnectionSegment];
				scr.endLeft = scr.endPrefabScript.tmpMeshVecs[qDOODOQQDQODD2.connectionVecInts[0]];
				scr.endLeft = scr.endPrefabScript.transform.TransformPoint(scr.endLeft);
				scr.endRight = scr.endPrefabScript.tmpMeshVecs[qDOODOQQDQODD2.connectionVecInts[qDOODOQQDQODD2.connectionVecInts.Count - 1]];
				scr.endRight = scr.endPrefabScript.transform.TransformPoint(scr.endRight);
				num16 = Mathf.RoundToInt(Mathf.Ceil(scr.roadWidth / (scr.faceDistance * 1f)));
				vector4 = scr.endPrefabScript.transform.TransformPoint(scr.endPrefabScript.crossingElements[scr.endConnectionSegment].leftIndentV3);
				vector5 = scr.endPrefabScript.transform.TransformPoint(scr.endPrefabScript.crossingElements[scr.endConnectionSegment].rightIndentV3);
				p2 = scr.endPrefabScript.transform.TransformPoint(Vector3.zero);
				num11 = scr.endPrefabScript.crossingElements[scr.endConnectionSegment].additionalIndentDistance;
				num12 = ((scr.endbendLeftRight != -1) ? OQOCQDQODD.ODDOQQQCCC(scr, splinePoints, scr.baseScript.minIndent, scr.roadShape[0].x, vector5, vector4, scr.endbendLeftRight, ref endAdjustInt, ref endAdjustDistance) : OQOCQDQODD.ODDOQQQCCC(scr, splinePoints, scr.baseScript.minIndent, scr.roadShape[scr.roadShape.Count - 1].x, vector5, vector4, scr.endbendLeftRight, ref endAdjustInt, ref endAdjustDistance));
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
			Vector3 zero2 = Vector3.zero;
			Vector3 zero3 = Vector3.zero;
			for (int l = 0; l < splinePoints.Count; l++)
			{
				if (splinePoints[l] == scr.markersExt[num17 + 1].position)
				{
					item = scr.markersExt[num17 + 1].bridgeObject;
					if (scr.markersExt.Count > num17 + 1)
					{
						num17++;
					}
				}
				list5.Add(item);
				if (l > 0)
				{
					num3 = Vector3.Distance(splinePoints[l - 1], splinePoints[l]);
					num2 += num3;
				}
				num6 = num2 / num7;
				Vector3 vector6 = ((l == 0) ? (splinePoints[l + 1] - splinePoints[l]).normalized : ((l != splinePoints.Count - 1) ? (splinePoints[l + 1] - splinePoints[l - 1]).normalized : (splinePoints[l] - splinePoints[l - 1]).normalized));
				if (l == 0)
				{
					zero2 = vector6;
				}
				zero3 = vector6;
				zero = OQOCQDQODD.GetEulerAngles(vector6);
				vector6 = new Vector3(0f - vector6.z, 0f, vector6.x);
				if (!flag2 && l < splinePoints.Count - 2)
				{
					vector = (splinePoints[l + 1] - splinePoints[l]).normalized;
					vector = new Vector3(0f - vector.z, 0f, vector.x);
				}
				int count = scr.roadShape.Count;
				Vector3 vector8;
				Vector3 vector7 = (vector8 = Vector3.zero);
				Vector3 vector9;
				for (int m = 0; m < scr.roadShape.Count; m++)
				{
					vector9 = ((list[l] == 0f) ? (splinePoints[l] + vector6 * scr.roadShape[m].x) : OQOCQDQODD.OODCODQCCQ(splinePoints[l], scr.roadShape[m], 180f - list[l], zero));
					if (startMarker == 0 && scr.startPrefabScript != null && l < num9 && !flag4)
					{
						vector9.y = OQQOCDQCQD.OQOOCCQQOQ(vector2, vector3, p, vector9);
						num10 = num2;
					}
					else if (startMarker == 0 && scr.startPrefabScript != null && num2 - num10 < num15 - num10 && !flag4)
					{
						Vector3 p3 = vector9;
						p3.y = OQQOCDQCQD.OQOOCCQQOQ(vector2, vector3, p, p3);
						float t = (num2 - num10) / (num15 - num10);
						vector9.y = Mathf.Lerp(p3.y, vector9.y, Mathf.SmoothStep(0f, 1f, t));
					}
					if (endMarker == scr.markersExt.Count - 1 && scr.endPrefabScript != null && l > num12 && !flag5)
					{
						vector9.y = OQQOCDQCQD.OQOOCCQQOQ(vector4, vector5, p2, vector9);
					}
					else if (endMarker == scr.markersExt.Count - 1 && scr.endPrefabScript != null && l >= endAdjustInt && !flag5)
					{
						if (m == 0)
						{
							num4 += num3;
						}
						Vector3 p4 = vector9;
						p4.y = OQQOCDQCQD.OQOOCCQQOQ(vector4, vector5, p2, p4);
						float t = num4 / endAdjustDistance;
						vector9.y = Mathf.Lerp(vector9.y, p4.y, Mathf.SmoothStep(0f, 1f, t));
					}
					if (m == 0)
					{
						vector7 = vector9;
						vector7.y -= 0.05f;
					}
					if (m == scr.roadShape.Count - 1)
					{
						vector8 = vector9;
						vector8.y -= scr.roadShape[m].y;
					}
					vector8 = vector9;
					vector8.y -= 0.05f;
					if (list[l] == 0f)
					{
						vector9.y += scr.roadShape[m].y;
					}
					list2.Add(vector9);
					list3.Add(new Vector2(scr.roadShapeUVs[m], num6));
					if (l < splinePoints.Count - 1 && m < scr.roadShape.Count - 1)
					{
						flag = true;
						if (!flag2)
						{
							flag = false;
							if (!array3[m] || !array3[m + 1])
							{
								if (l == 0)
								{
									array[m] = -1;
									array[m + 1] = -1;
								}
								if (!array3[m])
								{
									Vector3 pCheck = splinePoints[l + 1] + vector * scr.roadShape[m].x;
									if (ERCrossingPrefabs.OOCQODQDQD(scr.OCQOOQODCQ, scr.OQQCCQDCOO, pCheck))
									{
										array3[m] = true;
									}
								}
								if (!array3[m + 1])
								{
									Vector3 pCheck = splinePoints[l + 1] + vector * scr.roadShape[m + 1].x;
									if (ERCrossingPrefabs.OOCQODQDQD(scr.OCQOOQODCQ, scr.OQQCCQDCOO, pCheck))
									{
										array3[m + 1] = true;
									}
								}
								if (array3[m] && array3[m + 1])
								{
									flag = true;
									if (array[m] == -1)
									{
										array[m] = l;
									}
									if (array[m + 1] == -1)
									{
										array[m + 1] = l;
									}
								}
							}
							flag = true;
						}
						if (scr.endPrefabScript != null && l > splinePoints.Count - num16)
						{
							flag = true;
							Vector3 pCheck = splinePoints[l] + vector6 * scr.roadShape[m].x;
							if (ERCrossingPrefabs.OOCQODQDQD(scr.endRight, scr.endLeft, pCheck))
							{
								pCheck = splinePoints[l] + vector6 * scr.roadShape[m + 1].x;
								if (ERCrossingPrefabs.OOCQODQDQD(scr.endRight, scr.endLeft, pCheck))
								{
									flag = true;
								}
							}
						}
						num = scr.roadShapeMaterialInts[m];
						if (flag)
						{
							list4[num].Add(l * count + m);
							list4[num].Add((l + 1) * count + m + 1);
							list4[num].Add(l * count + m + 1);
							list4[num].Add((l + 1) * count + m);
							list4[num].Add((l + 1) * count + m + 1);
							list4[num].Add(l * count + m);
						}
					}
					if (flag2)
					{
						continue;
					}
					flag2 = true;
					for (int n = 0; n < array3.Length; n++)
					{
						if (!array3[n])
						{
							flag2 = false;
						}
					}
				}
				if (startMarker == 0 && scr.startPrefabScript != null && num5 < num8 * 6f)
				{
					if (scr.startbendLeftRight == -1)
					{
						if (l > 0)
						{
							num5 += Vector3.Distance(a, vector7);
						}
						a = vector7;
					}
					else
					{
						if (l > 0)
						{
							num5 += Vector3.Distance(a, vector8);
						}
						a = vector8;
					}
				}
				Vector3 normalized = (vector7 - vector8).normalized;
				vector9 = vector7 + normalized * (minIndent + minSurrounding);
				scr.baseScript.OQCCDQOQOO(ref vector9);
				surfaceVecs.Add(vector9);
				vector9 = vector7 + normalized * minIndent;
				surfaceVecs.Add(vector9);
				vector9 = vector8 + -normalized * minIndent;
				surfaceVecs.Add(vector9);
				vector9 = vector8 + -normalized * (minIndent + minSurrounding);
				scr.baseScript.OQCCDQOQOO(ref vector9);
				surfaceVecs.Add(vector9);
				if (!startSurfacesSafe && !flag4)
				{
					if (l == 0)
					{
						surfaceVecs[3] = scr.startPrefabScript.transform.TransformPoint(scr.startPrefabScript.crossingElements[scr.startConnectionSegment].leftSurroundingV3);
						surfaceVecs[0] = scr.startPrefabScript.transform.TransformPoint(scr.startPrefabScript.crossingElements[scr.startConnectionSegment].rightSurroundingV3);
						surfaceVecs[2] = scr.startPrefabScript.transform.TransformPoint(scr.startPrefabScript.crossingElements[scr.startConnectionSegment].leftIndentV3);
						surfaceVecs[1] = scr.startPrefabScript.transform.TransformPoint(scr.startPrefabScript.crossingElements[scr.startConnectionSegment].rightIndentV3);
					}
					else
					{
						OQOCQDQODD.OODQDQCCOQ(scr, ref surfaceVecs, scr.startPrefabScript, ref startSurfacesSafe, num2, scr.baseScript.minIndent);
					}
				}
				if (l == 0)
				{
					scr.sv1 = vector7;
					scr.sv2 = vector8;
					scr.sv1 = vector7 + vector6 * minIndent;
					scr.sv2 = vector8 + -vector6 * minIndent;
				}
			}
			Vector2[] array5 = list3.ToArray();
			float num18 = 1f / list3[list3.Count - 1].y * Mathf.Floor(list3[list3.Count - 1].y);
			for (int num19 = 0; num19 < array5.Length - 1; num19 += scr.roadShape.Count)
			{
				for (int num20 = 0; num20 < scr.roadShape.Count; num20++)
				{
					if (num20 == 0)
					{
						array5[num19 + num20].y = array5[num19].y * num18;
					}
					else
					{
						array5[num19 + num20].y = array5[num19].y;
					}
				}
			}
			if (startMarker == 0 && scr.startPrefabScript != null)
			{
				if (scr.startPrefabScript.meshVecs.Length == 0)
				{
				}
				int num21 = list2.Count - 1;
				int count2 = scr.roadShape.Count;
				bool flag6 = false;
				if (ERCrossingPrefabs.OOCQODQDQD(list2[count2], list2[0], list2[count2 * 2]))
				{
					flag6 = true;
				}
				List<int> connectionVecInts = scr.startPrefabScript.crossingElements[scr.startConnectionSegment].connectionVecInts;
				for (int num22 = 0; num22 < scr.roadShape.Count; num22++)
				{
					if (num22 + array[num22] * scr.roadShape.Count < 0)
					{
						Debug.LogError("The angle with the crossing is too small");
						break;
					}
					list2[num22 + array[num22] * scr.roadShape.Count] = scr.startPrefabScript.transform.TransformPoint(scr.startPrefabScript.tmpMeshVecs[connectionVecInts[scr.roadShape.Count - num22 - 1]]);
					if (scr.startPrefabScript.crossingElements[scr.startConnectionSegment].rotationPriority)
					{
						continue;
					}
					float num23 = scr.roadWidth / Mathf.Tan(scr.startAngle * (MathF.PI / 180f));
					float num24 = (flag6 ? (10f + (1f - scr.nodeDistance[num22]) * num23 * 2f) : (10f + scr.nodeDistance[num22] * num23 * 2f));
					float num25 = 0f;
					int num26 = 1;
					Vector3 a2;
					Vector3 vector10 = (a2 = list2[num22 + array[num22] * scr.roadShape.Count]);
					while (num25 < num24)
					{
						Vector3 vector11 = list2[num22 + (array[num22] + num26) * scr.roadShape.Count];
						num25 += Vector3.Distance(a2, vector11);
						Vector3 normalized2 = (vector11 - vector10).normalized;
						Vector3 vector12 = Vector3.Lerp(-scr.startDir, normalized2, num25 / num24);
						Vector3 a3 = vector10 + vector12 * num25;
						list2[num22 + (array[num22] + num26) * scr.roadShape.Count] = Vector3.Lerp(a3, vector11, Mathf.SmoothStep(0f, 1f, num25 / num24));
						a2 = vector11;
						num26++;
						if (num22 + (array[num22] + num26) * scr.roadShape.Count > list2.Count - 1)
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
					scr.endPrefabScript.OCODCDCDQQ();
				}
				int num27 = list2.Count - 1;
				int count3 = scr.roadShape.Count;
				bool flag7 = false;
				if (ERCrossingPrefabs.OOCQODQDQD(list2[num27], list2[num27 - count3], list2[num27 - count3 * 2]))
				{
					flag7 = true;
				}
				int num28 = list2.Count - scr.roadShape.Count;
				List<int> connectionVecInts2 = scr.endPrefabScript.crossingElements[scr.endConnectionSegment].connectionVecInts;
				for (int num29 = 0; num29 < scr.roadShape.Count; num29++)
				{
					list2[num28 + num29] = scr.endPrefabScript.transform.TransformPoint(scr.endPrefabScript.tmpMeshVecs[connectionVecInts2[num29]]);
					if (scr.endPrefabScript.crossingElements[scr.endConnectionSegment].rotationPriority)
					{
						continue;
					}
					float num30 = scr.roadWidth / Mathf.Tan(scr.endAngle * (MathF.PI / 180f));
					float num31 = (flag7 ? (10f + (1f - scr.nodeDistance[num29]) * num30 * 2f) : (3f + scr.nodeDistance[num29] * num30 * 2f));
					float num32 = 0f;
					int num33 = 0;
					Vector3 a4;
					Vector3 vector13 = (a4 = list2[num28 + num29 - num33 * scr.roadShape.Count]);
					num33 = 1;
					while (num32 < num31 && num28 + num29 - num33 * scr.roadShape.Count >= 0)
					{
						Vector3 vector14 = list2[num28 + num29 - num33 * scr.roadShape.Count];
						num32 += Vector3.Distance(a4, vector14);
						Vector3 normalized3 = (vector14 - vector13).normalized;
						Vector3 vector15 = Vector3.Lerp(-scr.endDir, normalized3, num32 / num31);
						Vector3 a5 = vector13 + vector15 * num32;
						list2[num28 + num29 - num33 * scr.roadShape.Count] = Vector3.Lerp(a5, vector14, Mathf.SmoothStep(0f, 1f, num32 / num31));
						a4 = vector14;
						num33++;
						if (num28 + num29 - num33 * scr.roadShape.Count > list2.Count - 1)
						{
							break;
						}
					}
				}
			}
			if (scr.closedTrack)
			{
				for (int num34 = 0; num34 < scr.roadShape.Count; num34++)
				{
					list2[list2.Count - scr.roadShape.Count + num34] = list2[num34];
				}
			}
			scr.meshVecs.InsertRange(startInt * scr.roadShape.Count, list2);
			scr.meshUVs.InsertRange(startInt * scr.roadShape.Count, new List<Vector2>(array5));
			for (int num35 = 0; num35 < scr.tris.Count; num35++)
			{
				scr.tris[num35].InsertRange(startInt * scr.roadShapeMaterialIntCounts[num35] * 3, list4[num35]);
			}
			Debug.LogError("we have to update existing triangle int values after the affected area!");
			ODDDQDQOOD(scr);
			num2 = 0f;
			if ((bool)scr.endPrefabScript && !flag5)
			{
				for (int num36 = 0; (!surfacesSafe || num36 < surfaceVecs.Count - 4) && surfaceVecs.Count - num36 - 6 >= 0; num36 += 4)
				{
					if (!surfacesSafe)
					{
						OQOCQDQODD.OQODQQCQDO(scr, ref surfaceVecs, scr.endPrefabScript, num36, ref surfacesSafe, num2, scr.baseScript.minIndent, wallFlagLeft: false, wallFlagRight: false);
					}
					num2 += Vector3.Distance(surfaceVecs[surfaceVecs.Count - 2 - num36], surfaceVecs[surfaceVecs.Count - 2 - num36 - 4]);
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
		}

		public static void ODDDQDQOOD(ERModularRoad scr)
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
				component.markersExt.Add(OQOCQDQODD.DuplicateMarker(scr.markersExt[i]));
			}
			string text = (gameObject.name = scr.name + "[Duplicate]");
			component.name = text;
			component.ODDDQDQOOD(ignorePrefabAlignment: false, forceAutoRotate: false);
			return component;
		}

		public static GameObject ODDCOQCCCD(ERModularRoad scr, Transform parent, Vector3 p1, Vector3 p2, float x1, float x2, float height, Vector3 heighthmapscale, Vector3 soScale)
		{
			float num = Mathf.Abs(p1.x - p2.x);
			float num2 = Mathf.Abs(p1.z - p2.z);
			float num3;
			float num4;
			if (num > num2)
			{
				float z = heighthmapscale.z;
				num3 = heighthmapscale.x;
				num4 = num2 / num;
			}
			else
			{
				float z = heighthmapscale.x;
				num3 = heighthmapscale.z;
				num4 = num / num2;
			}
			float num5 = OQQOCDQCQD.OCCOCQQCCQ(scr.baseScript.activeTerrain, p1, p2);
			float num6 = 1f + num4 * 0.5f;
			x1 -= num5 * 1.5f;
			x2 += num5 * 1.5f;
			Vector3 normalized = (p2 - p1).normalized;
			Vector3 normalized2 = new Vector3(normalized.z, 0f, 0f - normalized.x).normalized;
			float num7 = x2 - x1;
			float f = num7 / num3;
			f = Mathf.Ceil(f);
			float num8 = num7 / f;
			f += 1f;
			Vector3 vector = p1 + normalized2 * x1;
			vector.y += height * soScale.y;
			int num9 = Mathf.RoundToInt(f);
			List<Vector3> list = new List<Vector3>();
			List<Vector2> list2 = new List<Vector2>();
			List<int> list3 = new List<int>();
			Vector3 zero = Vector3.zero;
			float distance = 0f;
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; (float)j < f; j++)
				{
					Vector3 pos = vector + normalized2 * j * num8;
					if (i == 2)
					{
						Vector3 vector2 = pos;
						scr.baseScript.OQCCDQOQOO(ref pos);
						if (pos.y < vector2.y)
						{
							pos.y = vector2.y;
							pos = OQQOCDQCQD.OQOOOCQDDO(pos, normalized, ref distance);
						}
						else
						{
							scr.baseScript.OQCCDQOQOO(ref pos);
							if (pos.y < vector2.y)
							{
								pos.y = vector2.y;
							}
						}
					}
					list.Add(pos);
					list2.Add(new Vector2(1f, 1f));
				}
				if (i < 2)
				{
					for (int k = 0; k < num9 - 1; k++)
					{
						list3.Add(i * num9 + k);
						list3.Add((i + 1) * num9 + k + 1);
						list3.Add(i * num9 + k + 1);
						list3.Add((i + 1) * num9 + k);
						list3.Add((i + 1) * num9 + k + 1);
						list3.Add(i * num9 + k);
					}
				}
				zero = vector;
				float num10 = 1.5f;
				float num11 = 1f;
				if ((double)num5 < 1.5)
				{
					num11 = 1.5f;
				}
				if (i < 1)
				{
					vector += normalized * num5 * num10;
				}
				else
				{
					vector += normalized * num5 * num11;
				}
			}
			GameObject gameObject = new GameObject("TunnelDeform");
			gameObject.AddComponent<MeshFilter>();
			gameObject.AddComponent<MeshRenderer>();
			gameObject.AddComponent<MeshCollider>();
			gameObject.AddComponent<ERSurfaceScript>();
			gameObject.layer = scr.baseScript.sLayer;
			gameObject.transform.parent = parent;
			gameObject.transform.position = Vector3.zero;
			gameObject.hideFlags = HideFlags.HideInHierarchy;
			Mesh mesh = new Mesh();
			mesh.vertices = list.ToArray();
			mesh.uv = list2.ToArray();
			mesh.triangles = list3.ToArray();
			mesh.RecalculateNormals();
			mesh.RecalculateBounds();
			gameObject.GetComponent<MeshFilter>().sharedMesh = mesh;
			gameObject.GetComponent<MeshCollider>().sharedMesh = mesh;
			gameObject.GetComponent<MeshRenderer>().enabled = false;
			gameObject.GetComponent<MeshCollider>().enabled = false;
			return gameObject;
		}

		public static void CreateSplatMeshes(ERModularRoad scr, ref List<GameObject> soSplatmapObjects, float splatSize)
		{
			if (scr.isSideObject)
			{
				return;
			}
			List<Vector3> list = new List<Vector3>();
			List<Vector2> list2 = new List<Vector2>();
			List<int> list3 = new List<int>();
			Vector3 zero = Vector3.zero;
			float splatOpacity = scr.splatOpacity;
			bool flag = false;
			int num = -1;
			int num2 = -1;
			int num3 = scr.exitRoads.Count - 1;
			int num4 = 0;
			if (scr.exitRoads.Count > 0)
			{
				num2 = scr.exitRoads[0].startSplineIndex;
				num = scr.exitRoads[0].endSplineIndex;
				flag = true;
			}
			int num5 = 0;
			Vector3 zero2 = Vector3.zero;
			if (scr.soSplinePoints.Count > scr.bridgeElement.Count)
			{
				for (int i = scr.bridgeElement.Count - 1; i < scr.soSplinePoints.Count; i++)
				{
					scr.bridgeElement.Add(item: false);
				}
			}
			float num6 = 0f;
			int count = scr.soSplinePoints.Count;
			if (count > scr.doLeftSurrounding.Count || count > scr.soSplinePointsLeft.Count || count > scr.doRightSurrounding.Count || count > scr.soSplinePointsRight.Count)
			{
				return;
			}
			int num7 = -1;
			int num8 = -1;
			Vector3 zero3 = Vector3.zero;
			Vector3 zero4 = Vector3.zero;
			int num9 = 0;
			float num10 = 0f;
			float num11 = 0f;
			bool flag2 = false;
			if (scr.soSectionList1.Count > 0)
			{
				num7 = scr.soSectionList1[num9].startSplinePoint;
				num8 = scr.soSectionList1[num9].endSplinePoint;
				zero3 = scr.soSectionList1[num9].startPosition;
				zero4 = scr.soSectionList1[num9].endPosition;
				num10 = scr.soSectionList1[num9].hsStart;
				num11 = scr.soSectionList1[num9].hsEnd;
			}
			for (int j = 0; j < count; j++)
			{
				if (j == num7)
				{
					flag2 = true;
				}
				else if (j == num8)
				{
					num9++;
					if (scr.soSectionList1.Count > num9)
					{
						num7 = scr.soSectionList1[num9].startSplinePoint;
						num8 = scr.soSectionList1[num9].endSplinePoint;
						zero3 = scr.soSectionList1[num9].startPosition;
						zero4 = scr.soSectionList1[num9].endPosition;
						flag2 = false;
					}
				}
				Vector3 vector = scr.soSplinePointsLeft[j] - scr.soSplinePointsRight[j];
				vector = new Vector3(vector.x, 0f, vector.z).normalized;
				zero2 = scr.soSplinePointsRight[j];
				if (j > 1)
				{
					num6 += Vector3.Distance(zero2, scr.soSplinePointsRight[j - 1]);
				}
				if (flag && j >= num2)
				{
					zero2 = scr.exitRoads[num4].soPointsRightStart[j - num2];
					if (j == num)
					{
						num4++;
						if (scr.exitRoads.Count > num4)
						{
							num2 = scr.exitRoads[num4].startSplineIndex;
							num = scr.exitRoads[num4].endSplineIndex;
						}
						else
						{
							flag = false;
						}
					}
				}
				zero = ((!scr.doLeftSurrounding[j] || j >= count) ? scr.soSplinePointsLeft[j] : (scr.soSplinePointsLeft[j] + vector * splatSize * (scr.smoothLevel + scr.expandLevel)));
				zero.y = 0f;
				list.Add(zero);
				list2.Add(new Vector2(0f, num6 + 10f));
				zero = ((!scr.doLeftSurrounding[j] || j >= count) ? scr.soSplinePointsLeft[j] : (scr.soSplinePointsLeft[j] + vector * splatSize * scr.expandLevel));
				zero.y = 0f;
				list.Add(zero);
				list2.Add(new Vector2(splatOpacity, num6 + 10f));
				zero = ((!scr.doRightSurrounding[j] || j >= count) ? zero2 : (zero2 - vector * splatSize * scr.expandLevel));
				zero.y = 0f;
				list.Add(zero);
				list2.Add(new Vector2(splatOpacity, num6));
				zero = ((!scr.doRightSurrounding[j] || j >= count) ? zero2 : (zero2 - vector * splatSize * (scr.smoothLevel + scr.expandLevel)));
				zero.y = 0f;
				list.Add(zero);
				list2.Add(new Vector2(0f, num6));
				if (j == 0 && !scr.closedTrack)
				{
					float num12 = splatSize * (float)(scr.smoothLevel + scr.expandLevel);
					if (scr.startPrefabScript != null)
					{
						num12 = Vector3.Distance(scr.soSplinePoints[0], scr.startPrefabScript.transform.position);
					}
					else
					{
						Vector2 value = (list2[2] = new Vector2(0f, 0f));
						list2[1] = value;
					}
					vector = (scr.soSplinePoints[0] - scr.soSplinePoints[1]).normalized;
					list[0] += vector * num12;
					list[1] += vector * num12;
					list[2] += vector * num12;
					list[3] += vector * num12;
				}
				else if (j == scr.soSplinePoints.Count - 1 && !scr.closedTrack)
				{
					float num13 = splatSize * (float)(scr.smoothLevel + scr.expandLevel);
					if (scr.endPrefabScript != null)
					{
						num13 = Vector3.Distance(scr.soSplinePoints[j], scr.endPrefabScript.transform.position);
					}
					else
					{
						int index = list2.Count - 3;
						Vector2 value = (list2[list2.Count - 2] = new Vector2(0f, 0f));
						list2[index] = value;
					}
					vector = (scr.soSplinePoints[j] - scr.soSplinePoints[j - 1]).normalized;
					list[list.Count - 4] += vector * num13;
					list[list.Count - 3] += vector * num13;
					list[list.Count - 2] += vector * num13;
					list[list.Count - 1] += vector * num13;
				}
				if (j < scr.soSplinePoints.Count - 1 && !scr.bridgeElement[j] && !flag2)
				{
					int num14 = 4;
					for (int k = 0; k < num14 - 1; k++)
					{
						list3.Add(j * num14 + k);
						list3.Add((j + 1) * num14 + k + 1);
						list3.Add(j * num14 + k + 1);
						list3.Add((j + 1) * num14 + k);
						list3.Add((j + 1) * num14 + k + 1);
						list3.Add(j * num14 + k);
					}
				}
			}
			if (scr.exitRoads.Count > 0)
			{
				for (int l = 0; l < scr.exitRoads.Count; l++)
				{
					int count2 = list.Count;
					for (int m = 0; m < scr.exitRoads[l].soPointsLeftStart.Count; m++)
					{
						Vector3 vector = scr.exitRoads[l].soPointsLeftStart[m] - scr.exitRoads[l].soPointsRightStart[m + scr.exitRoads[l].soRightSplitEndIndex];
						vector = new Vector3(vector.x, 0f, vector.z).normalized;
						zero = scr.exitRoads[l].soPointsLeftStart[m] + vector * splatSize * (scr.smoothLevel + scr.expandLevel);
						zero.y = 0f;
						list.Add(zero);
						list2.Add(new Vector2(0f, 0f));
						zero = scr.exitRoads[l].soPointsLeftStart[m] + vector * splatSize * scr.expandLevel;
						zero.y = 0f;
						list.Add(zero);
						list2.Add(new Vector2(splatOpacity, splatOpacity));
						zero = scr.exitRoads[l].soPointsRightStart[m + scr.exitRoads[l].soRightSplitEndIndex] - vector * splatSize * scr.expandLevel;
						zero.y = 0f;
						list.Add(zero);
						list2.Add(new Vector2(splatOpacity, splatOpacity));
						zero = scr.exitRoads[l].soPointsRightStart[m + scr.exitRoads[l].soRightSplitEndIndex] - vector * splatSize * (scr.smoothLevel + scr.expandLevel);
						zero.y = 0f;
						list.Add(zero);
						list2.Add(new Vector2(0f, 0f));
						if (m < scr.exitRoads[l].soPointsLeftStart.Count - 1)
						{
							int num15 = 4;
							for (int n = 0; n < num15 - 1; n++)
							{
								list3.Add(count2 + m * num15 + n);
								list3.Add(count2 + (m + 1) * num15 + n + 1);
								list3.Add(count2 + m * num15 + n + 1);
								list3.Add(count2 + (m + 1) * num15 + n);
								list3.Add(count2 + (m + 1) * num15 + n + 1);
								list3.Add(count2 + m * num15 + n);
							}
						}
					}
				}
			}
			string text = "color" + (scr.splatIndex + 1) + "_" + splatOpacity;
			soSplatmapObjects.Add(BuildSplatMesh(scr, list, list2, list3, text, -15));
		}

		public static GameObject BuildSplatMesh(ERModularRoad scr, List<Vector3> vecs, List<Vector2> uvs, List<int> tris, string name, int pos)
		{
			GameObject gameObject = new GameObject("SplatGO" + name);
			gameObject.AddComponent<MeshFilter>();
			gameObject.AddComponent<MeshRenderer>();
			gameObject.AddComponent<MeshCollider>();
			gameObject.transform.parent = scr.transform;
			Vector3 zero = Vector3.zero;
			gameObject.transform.position = zero;
			Mesh mesh = new Mesh();
			if (scr.gameObject != null)
			{
				mesh.name = scr.gameObject.name + "_splat";
			}
			gameObject.layer = scr.baseScript.sLayer;
			if (vecs == null)
			{
				if (scr.gameObject != null)
				{
					Debug.LogWarning("EasyRoads3Dv3 Warning: road object: " + scr.gameObject.name + " no mesh data exists");
				}
				return gameObject;
			}
			if (tris == null)
			{
				if (scr.gameObject != null)
				{
					Debug.LogWarning("EasyRoads3Dv3 Warning: road object: " + scr.gameObject.name + " no mesh data exists");
				}
				return gameObject;
			}
			mesh.vertices = vecs.ToArray();
			if (uvs == null)
			{
				mesh.uv = new Vector2[vecs.Count];
			}
			else
			{
				mesh.uv = uvs.ToArray();
			}
			mesh.tangents = new Vector4[vecs.Count];
			mesh.triangles = tris.ToArray();
			mesh.RecalculateNormals();
			mesh.RecalculateBounds();
			gameObject.GetComponent<MeshFilter>().sharedMesh = mesh;
			gameObject.GetComponent<MeshCollider>().sharedMesh = mesh;
			gameObject.GetComponent<MeshCollider>().enabled = false;
			return gameObject;
		}

		public static void SetMarkerIndentAlignment(ERMarkerExt m, ERModularRoad scr, string side)
		{
			if (!(m == null) && !(scr.baseScript == null))
			{
				Vector3 direction = m.direction;
				Vector3 position = m.position;
				Vector3 normalized = new Vector3(direction.z, 0f, 0f - direction.x).normalized;
				Vector3 pos = position + normalized * -2f;
				Vector3 pos2 = position + normalized * 2f;
				scr.baseScript.OQCCDQOQOO(ref pos);
				scr.baseScript.OQCCDQOQOO(ref pos2);
				if (pos.y < pos2.y || side == "Left Side of the Road")
				{
					m.leftIndentAlignment = 1;
				}
				else
				{
					m.rightIndentAlignment = 1;
				}
			}
		}

		public static void UnSetMarkerIndentAlignment(ERMarkerExt m, ERModularRoad scr, string side)
		{
			if (!(m == null) && !(scr.baseScript == null))
			{
				if (side == "")
				{
					m.leftIndentAlignment = 0;
					m.rightIndentAlignment = 0;
				}
				else if (side == "Left Side of the Road")
				{
					m.leftIndentAlignment = 0;
				}
				else
				{
					m.rightIndentAlignment = 0;
				}
			}
		}

		public static float GetleftToCenterPerc(List<Vector2> nodeList, int left, int right)
		{
			float num = nodeList[right].x - nodeList[left].x;
			return nodeList[left].x * -1f / num;
		}

		public static void ODOQDDDOOO(ERModularRoad r1, ERModularRoad r2, ERCrossingPrefabs prefab)
		{
			if (prefab.isIConnector)
			{
				ERIConnector component = prefab.gameObject.GetComponent<ERIConnector>();
				if ((!(component.connectorLength1 > 0f) || !(component.connectorLength2 > 0f)) && !(component.connectorLength1 > 0f) && !(component.connectorLength2 > 0f) && !(r1.roadShapeString == r2.roadShapeString) && !(r1.roadShapeString == r2.roadShapeReversedString) && !(r1.roadShapeReversedString == r2.roadShapeString))
				{
				}
			}
		}

		public static void OOQOQOOQCD(ERModularRoad r1, ERModularRoad r2, int road1StartEnd, int road2StartEnd)
		{
		}

		public static void AverageTangentsRoadPrefab(ERModularRoad r1, ERCrossingPrefabs prefab, int road1StartEnd, int prefabStartEnd)
		{
		}
	}
}
