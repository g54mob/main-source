using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	public class ODCOCCDCQC : MonoBehaviour
	{
		public static void OCQOCOCDQC(List<ERMarkerExt> markers, ref List<Vector3> splinePoints, ref List<float> tValues)
		{
			int num = -1;
			for (int i = 0; i < markers.Count; i++)
			{
				if (!markers[i].attachExit)
				{
					continue;
				}
				if (num <= markers[i].startSplinePoint)
				{
					ODDCCOCOOC(markers[i], ref splinePoints, ref tValues, num);
					markers[i].exitInnerVertices.Clear();
					for (int j = markers[i].startExitInt; j <= markers[i].endExitInt; j++)
					{
						markers[i].exitInnerVertices.Add(splinePoints[j]);
					}
					num = markers[i].endExitInt;
				}
				else
				{
					if (markers.Count <= i + 1 || markers[i + 1].attachExit || num <= markers[i + 1].startSplinePoint)
					{
					}
					markers[i].attachExit = false;
					Debug.LogWarning("An exit road is attached to the preious marker and overlaps the current marker, marker: " + (i + 1));
				}
			}
		}

		public static void ODDCCOCOOC(ERMarkerExt marker, ref List<Vector3> splinePoints, ref List<float> tValues, int currentInt)
		{
			float num = 0f;
			float num2 = 0f;
			bool flag = false;
			if (marker.startExitOffset < 0f)
			{
				float num3 = marker.startExitOffset * -1f;
				for (int num4 = marker.startSplinePoint - 2; num4 >= 0; num4--)
				{
					num2 = Vector3.Distance(splinePoints[num4], splinePoints[num4 + 1]);
					if (num + num2 > num3)
					{
						float t = (num3 - num) / num2;
						Vector3 item = Vector3.Lerp(splinePoints[num4 + 1], splinePoints[num4], t);
						float num5;
						if (tValues[num4 + 1] < tValues[num4])
						{
							num5 = Mathf.Lerp(1f + tValues[num4 + 1], tValues[num4], t);
							if (num5 > 1f)
							{
								num5 -= 1f;
							}
						}
						else
						{
							num5 = Mathf.Lerp(tValues[num4 + 1], tValues[num4], t);
						}
						splinePoints.Insert(num4 + 1, item);
						tValues.Insert(num4 + 1, num5);
						marker.startExitInt = num4 + 1;
						flag = true;
						break;
					}
					if (num4 <= currentInt)
					{
						marker.startExitOffset = 0f;
						Debug.LogWarning("The start offset overlaps the previous exit lane!");
						ODDCCOCOOC(marker, ref splinePoints, ref tValues, currentInt);
					}
					num += num2;
				}
				if (!flag)
				{
					marker.startExitInt = 0;
				}
			}
			else if (marker.startExitOffset > 0f)
			{
				float num3 = marker.startExitOffset;
				flag = false;
				for (int num4 = marker.startSplinePoint - 1; num4 < splinePoints.Count - 1; num4++)
				{
					num2 = Vector3.Distance(splinePoints[num4], splinePoints[num4 + 1]);
					if (num + num2 > num3)
					{
						float t = (num3 - num) / num2;
						Vector3 item = Vector3.Lerp(splinePoints[num4], splinePoints[num4 + 1], t);
						float num5 = Mathf.Lerp(tValues[num4], tValues[num4 + 1], t);
						if (tValues[num4 + 1] < tValues[num4])
						{
							num5 = Mathf.Lerp(tValues[num4], 1f + tValues[num4 + 1], t);
							if (num5 > 1f)
							{
								num5 -= 1f;
							}
						}
						else
						{
							num5 = Mathf.Lerp(tValues[num4], tValues[num4 + 1], t);
						}
						splinePoints.Insert(num4 + 1, item);
						tValues.Insert(num4 + 1, num5);
						marker.startExitInt = num4 + 1;
						flag = true;
						break;
					}
					num += num2;
				}
			}
			else
			{
				marker.startExitInt = marker.startSplinePoint - 1;
				flag = true;
			}
			if (!flag)
			{
				marker.startExitOffset = 0f;
				Debug.LogWarning("The start offset extends the road length!");
				ODDCCOCOOC(marker, ref splinePoints, ref tValues, currentInt);
			}
			float num6 = marker.extrusionDistance + marker.fixedDistance;
			num = 0f;
			flag = false;
			for (int num4 = marker.startExitInt; num4 < splinePoints.Count - 1; num4++)
			{
				num2 = Vector3.Distance(splinePoints[num4], splinePoints[num4 + 1]);
				if (num + num2 > num6)
				{
					float t = (num6 - num) / num2;
					Vector3 item = Vector3.Lerp(splinePoints[num4], splinePoints[num4 + 1], t);
					float num5;
					if (tValues[num4 + 1] < tValues[num4])
					{
						num5 = Mathf.Lerp(tValues[num4], 1f + tValues[num4 + 1], t);
						if (num5 > 1f)
						{
							num5 -= 1f;
						}
					}
					else
					{
						num5 = Mathf.Lerp(tValues[num4], tValues[num4 + 1], t);
					}
					splinePoints.Insert(num4 + 1, item);
					tValues.Insert(num4 + 1, num5);
					marker.endExitInt = num4 + 1;
					flag = true;
					break;
				}
				num += num2;
			}
			if (!flag)
			{
				marker.endExitInt = splinePoints.Count - 1;
			}
		}

		public static void ODCDDCDOOQ(ERModularBase baseScript, List<ERMarkerExt> markers, ref List<Vector3> soSplinePointsLeft, ref List<Vector3> soSplinePointsRight)
		{
			for (int i = 0; i < markers.Count; i++)
			{
				if (markers[i].attachExit)
				{
					OQOOCQOCDO(baseScript, markers[i], ref soSplinePointsLeft, ref soSplinePointsRight);
				}
			}
		}

		public static void OQOOCQOCDO(ERModularBase baseScript, ERMarkerExt marker, ref List<Vector3> soSplinePointsLeft, ref List<Vector3> soSplinePointsRight)
		{
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
				for (int i = 1; i < marker.exitOuterVerticesExtrusion[0].Count; i++)
				{
					item = marker.exitOuterVerticesExtrusion[0][i];
					item = Vector3.Lerp(marker.exitOuterVerticesExtrusion[0][0], marker.exitOuterVerticesExtrusion[0][i], num5);
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
			float num9 = (float)Mathf.RoundToInt(2f * marker.connectionRadius * (float)Math.PI) * (marker.connectionAngle / 360f);
			int num10 = Mathf.RoundToInt(Mathf.Floor(num9 / num8));
			float num11 = marker.connectionAngle / ((float)num10 * 1f);
			float num12 = Mathf.Abs(Vector3.Angle(item - vector, value - vector));
			if (num12 != 0f && !OCQCDQCQOQ.OOOOCDQQOC(vector, item, value))
			{
				num12 *= -1f;
			}
			float num13 = (marker.connectionAngle + num12) / ((float)num10 * 1f);
			int cInt = marker.endExitInt;
			for (int i = 1; i <= num10; i++)
			{
				Vector3 vector2 = OCQCDQCQOQ.OCQDOQQQOD(item, vector, Quaternion.Euler(0f, (float)i * num11, 0f));
				Vector3 item2 = OCQCDQCQOQ.OCQDOQQQOD(value, vector, Quaternion.Euler(0f, (float)i * num13, 0f));
				item2.y = GetCircularY(vector2, soSplinePointsLeft, soSplinePointsRight, ref cInt, flag: false);
				vector2.y = GetCircularY(vector2, soSplinePointsLeft, soSplinePointsRight, ref cInt, flag: true);
				marker.exitOuterVerticesCurve[0].Add(vector2);
				marker.exitInnerVertices.Add(item2);
			}
		}

		public static void OCDCQQCOOQ(ERModularBase baseScript, List<ERMarkerExt> markers, ref List<Vector3> vecs, ref List<Vector2> uvsArray, ref List<Vector2> uvsArray2, ref List<List<int>> tris, ref Material[] materialsList)
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
				GetSetMaterialTrisIndex(ref triIndex, ref tris, ref materialsList, m);
				int num2 = 0;
				int num3 = 0;
				float num4 = 0f;
				float num5 = 0f;
				float num6 = 5f;
				Debug.Log("pass colors to this function");
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
				if (markers[i].fixedDistance != 0f)
				{
					for (int j = 0; j < markers[i].exitOuterVerticesFixed[0].Count; j++)
					{
						num3 = vecs.Count;
						vecs.Add(markers[i].exitInnerVertices[num2 + j]);
						vecs.Add(markers[i].exitOuterVerticesFixed[0][j]);
						if (j > 0)
						{
							num5 += Vector3.Distance(markers[i].exitInnerVertices[num2 + j - 1], markers[i].exitInnerVertices[num2 + j]);
							num4 += Vector3.Distance(markers[i].exitOuterVerticesFixed[0][j - 1], markers[i].exitOuterVerticesFixed[0][j]);
						}
						uvsArray.Add(new Vector2(0f, num5 / num6));
						uvsArray.Add(new Vector2(1f, num4 / num6));
						uvsArray2.Add(new Vector2(0f, num5 / num6));
						uvsArray2.Add(new Vector2(1f, num4 / num6));
						if (j < markers[i].exitOuterVerticesFixed[0].Count - 1)
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
					Debug.Log(markers[i].exitOuterVerticesFixed[0].Count + " ");
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
				for (int j = 0; j < markers[i].exitOuterVerticesCurve[0].Count; j++)
				{
					num3 = vecs.Count;
					vecs.Add(markers[i].exitInnerVertices[num2 + j]);
					vecs.Add(markers[i].exitOuterVerticesCurve[0][j]);
					if (j > 0)
					{
						num5 += Vector3.Distance(markers[i].exitInnerVertices[j - 1], markers[i].exitInnerVertices[j]);
						num4 += Vector3.Distance(markers[i].exitInnerVertices[j - 1], markers[i].exitInnerVertices[j]);
					}
					uvsArray.Add(new Vector2(0f, num5 / num6));
					uvsArray.Add(new Vector2(1f, num4 / num6));
					uvsArray2.Add(new Vector2(0f, num5 / num6));
					uvsArray2.Add(new Vector2(1f, num4 / num6));
					if (j < markers[i].exitOuterVerticesCurve[0].Count - 1)
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

		public static void GetSetMaterialTrisIndex(ref int triIndex, ref List<List<int>> tris, ref Material[] materialsList, Material m)
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

		public static float GetCircularY(Vector3 v, List<Vector3> soSplinePointsLeft, List<Vector3> soSplinePointsRight, ref int cInt, bool flag)
		{
			for (int i = cInt; i < soSplinePointsLeft.Count; i++)
			{
				if (OCQCDQCQOQ.OOOOCDQQOC(soSplinePointsRight[i], soSplinePointsLeft[i], v))
				{
					if (flag)
					{
						cInt = i;
					}
					return OCQCDQCQOQ.OQOQQQQCQD(soSplinePointsLeft[i - 1], soSplinePointsLeft[i], soSplinePointsRight[i], v);
				}
			}
			return v.y;
		}
	}
}
