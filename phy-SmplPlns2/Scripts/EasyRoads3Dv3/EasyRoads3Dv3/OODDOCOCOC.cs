using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[AddComponentMenu("")]
	public class OODDOCOCOC : MonoBehaviour
	{
		public static void OCOOOQCCCQ(ERCrossingPrefabs scr, ERModularBase baseScript, bool doTerrainDeformation)
		{
			if (!scr.isCustomPrefab)
			{
				return;
			}
			List<Vector2> list = new List<Vector2>();
			List<Vector3> list2 = new List<Vector3>();
			List<Vector3> baseVecs = new List<Vector3>();
			List<Vector3> indentVecs = new List<Vector3>();
			List<Vector2> uvs = new List<Vector2>();
			List<bool> doSurroundingTriangle = new List<bool>();
			List<PointER> list3 = new List<PointER>();
			List<float> list4 = new List<float>();
			List<float> list5 = new List<float>();
			int num = 0;
			if (baseScript != null)
			{
				if (scr.indent == 0f || scr.indent < baseScript.terrainMinIndent)
				{
					scr.indent = baseScript.terrainMinIndent;
				}
				if (scr.surrounding == 0f || scr.indent < baseScript.minSurrounding)
				{
					scr.surrounding = baseScript.minSurrounding;
				}
			}
			for (int i = 0; i < list2.Count; i++)
			{
				uvs.Add(new Vector2(0f, 1f));
			}
			float indent = scr.indent;
			float surrounding = scr.surrounding;
			indentVecs.Clear();
			scr.debugVecs1.Clear();
			scr.debugVecs2.Clear();
			List<float> surroundingValues = new List<float>();
			if (scr.surfaceVecs[0] == scr.surfaceVecs[1])
			{
				scr.surfaceVecs.RemoveAt(0);
				scr.surfaceVecType.RemoveAt(0);
				scr.surfaceConnectionInt.RemoveAt(0);
			}
			if (scr.surfaceVecs[0] == scr.surfaceVecs[scr.surfaceVecs.Count - 1])
			{
			}
			bool lastIndentIsRight = false;
			OODQQDQDOO(ref indentVecs, ref baseVecs, ref uvs, ref doSurroundingTriangle, scr.surfaceVecs, scr.surfaceVecType, indent, surrounding, scr, ref lastIndentIsRight, ref surroundingValues);
			if (!doTerrainDeformation)
			{
				return;
			}
			scr.indentVecs = new List<Vector3>(indentVecs);
			scr.debugVecs1.AddRange(indentVecs);
			for (int j = 0; j < indentVecs.Count; j++)
			{
				Vector3 item = indentVecs[j];
				list2.Add(item);
				list3.Add(new PointER(item.x, item.z, 0f));
				list4.Add(item.x);
				list5.Add(item.z);
				list.Add(new Vector2(item.x, item.z));
			}
			List<int> list6 = new List<int>();
			List<int> list7 = new List<int>();
			List<TriangleER> list8 = delaunayER.Triangulate(list3);
			for (int k = 0; k < list8.Count; k++)
			{
				list6.Add(num + delaunayER.FindVertice(new Vector3(list8[k].Vertex1.x, list8[k].Vertex1.z, list8[k].Vertex1.y), list2));
				list6.Add(num + delaunayER.FindVertice(new Vector3(list8[k].Vertex3.x, list8[k].Vertex3.z, list8[k].Vertex3.y), list2));
				list6.Add(num + delaunayER.FindVertice(new Vector3(list8[k].Vertex2.x, list8[k].Vertex2.z, list8[k].Vertex2.y), list2));
			}
			for (int l = 0; l < list6.Count; l += 3)
			{
				Vector3 vector = (list2[list6[l] - num] + list2[list6[l + 1] - num] + list2[list6[l + 2] - num]) / 3f;
				if (OQOQOOCDCC.OCDCDOCQCQ(list4.Count, list, vector.x, vector.z))
				{
					list7.Add(list6[l]);
					list7.Add(list6[l + 1]);
					list7.Add(list6[l + 2]);
				}
			}
			scr.surfaceSurroundingInts.Clear();
			num = list2.Count;
			bool flag = true;
			float num2 = 0f;
			bool flag2 = false;
			for (int m = 0; m < num; m++)
			{
				num2 = surroundingValues[m];
				flag2 = false;
				if (!doSurroundingTriangle[m])
				{
					flag2 = true;
				}
				if (m == 0)
				{
					if (!doSurroundingTriangle[num - 1])
					{
						flag2 = true;
					}
				}
				else if (!doSurroundingTriangle[m - 1])
				{
					flag2 = true;
				}
				if (flag2)
				{
					num2 = Mathf.Sqrt(num2 * num2 + num2 * num2);
				}
				Vector3 normalized = (list2[m] - baseVecs[m]).normalized;
				Vector3 item = list2[m] + normalized * num2;
				if (m > 0 && !OQQOCDQCQD.OOCQODQDQD(list2[list2.Count - 1], list2[list2.Count - 1 - num], item))
				{
					item = list2[list2.Count - 1];
				}
				item = scr.transform.TransformPoint(item);
				if (baseScript != null)
				{
					baseScript.OQCCDQOQOO(ref item);
				}
				item = scr.transform.InverseTransformPoint(item);
				list2.Add(item);
				uvs.Add(new Vector2(0f, 0f));
				scr.surfaceSurroundingInts.Add(num + m);
				if (doSurroundingTriangle[m] && m < num - 1)
				{
					list7.Add(m);
					list7.Add(m + num);
					list7.Add(m + 1);
					list7.Add(m + num);
					list7.Add(m + num + 1);
					list7.Add(m + 1);
				}
				else if (m == num - 1 && !lastIndentIsRight)
				{
					list7.Add(m);
					list7.Add(m + num);
					list7.Add(0);
					list7.Add(m + num);
					list7.Add(num);
					list7.Add(0);
				}
			}
			int count = list2.Count;
			for (int n = 0; n < scr.crossingElements.Count; n++)
			{
				int leftIndent = scr.crossingElements[n].leftIndent;
				if (leftIndent >= 0 && leftIndent + num >= 0 && leftIndent + num < count)
				{
					scr.crossingElements[n].leftSurrounding = leftIndent + num;
					scr.crossingElements[n].leftSurroundingV3 = list2[leftIndent + num];
				}
				else
				{
					scr.crossingElements[n].leftSurrounding = -1;
					scr.crossingElements[n].leftSurroundingV3 = Vector3.zero;
				}
				leftIndent = scr.crossingElements[n].rightIndent;
				if (leftIndent >= 0 && leftIndent + num >= 0 && leftIndent + num < count)
				{
					scr.crossingElements[n].rightSurrounding = leftIndent + num;
					scr.crossingElements[n].rightSurroundingV3 = list2[leftIndent + num];
				}
				else
				{
					scr.crossingElements[n].rightSurrounding = -1;
					scr.crossingElements[n].rightSurroundingV3 = Vector3.zero;
				}
			}
			if (scr.surfaceObject == null)
			{
				if ((bool)scr.transform.Find("surface"))
				{
					scr.surfaceObject = scr.transform.Find("surface").gameObject;
					scr.surfaceObject.hideFlags = HideFlags.HideInHierarchy;
				}
				else
				{
					scr.surfaceObject = new GameObject("surface");
					scr.surfaceObject.hideFlags = HideFlags.HideInHierarchy;
					scr.surfaceObject.transform.position = scr.transform.position;
					scr.surfaceObject.transform.rotation = scr.transform.rotation;
					scr.surfaceObject.transform.parent = scr.transform;
					scr.surfaceObject.layer = baseScript.sLayer;
					scr.surfaceObject.AddComponent<ERSurfaceScript>();
				}
			}
			if (scr.surfaceObject.GetComponent<MeshFilter>() == null)
			{
				scr.surfaceObject.AddComponent<MeshFilter>();
			}
			if (scr.surfaceObject.GetComponent<MeshRenderer>() == null)
			{
				scr.surfaceObject.AddComponent<MeshRenderer>();
				if (baseScript != null)
				{
					scr.surfaceObject.GetComponent<MeshRenderer>().sharedMaterial = baseScript.surfaceMaterial;
				}
				else
				{
					scr.surfaceObject.GetComponent<MeshRenderer>().sharedMaterial = scr.baseScript.surfaceMaterial;
				}
			}
			if (scr.surfaceObject.GetComponent<MeshCollider>() == null)
			{
				scr.surfaceObject.AddComponent<MeshCollider>();
			}
			Mesh mesh;
			if (scr.surfaceObject.GetComponent<MeshFilter>().sharedMesh != null)
			{
				mesh = scr.surfaceObject.GetComponent<MeshFilter>().sharedMesh;
			}
			else
			{
				mesh = new Mesh();
				mesh.name = "surface";
				scr.surfaceObject.GetComponent<MeshFilter>().sharedMesh = mesh;
			}
			if (list2.Count != uvs.Count)
			{
				uvs.Clear();
				for (int num3 = 0; num3 < list2.Count; num3++)
				{
					uvs.Add(new Vector2(0f, 1f));
				}
				Debug.Log("Intersection " + scr.gameObject.name + " Vertices uvs count mismatch, this has been repaired.");
			}
			scr.surfaceObject.layer = baseScript.sLayer;
			mesh.Clear();
			mesh.vertices = list2.ToArray();
			mesh.uv = uvs.ToArray();
			mesh.tangents = new Vector4[list2.Count];
			mesh.triangles = list7.ToArray();
			mesh.RecalculateNormals();
			mesh.RecalculateBounds();
			scr.surfaceObject.GetComponent<MeshCollider>().sharedMesh = null;
			scr.surfaceObject.GetComponent<MeshCollider>().sharedMesh = mesh;
			if (baseScript.hideSurfaces)
			{
				scr.surfaceObject.GetComponent<MeshRenderer>().enabled = false;
				scr.surfaceObject.GetComponent<MeshCollider>().enabled = false;
			}
			scr.surfaceMeshVecs = list2.ToArray();
			scr.tmpSurfaceMeshVecs = new Vector3[scr.surfaceMeshVecs.Length];
			Array.Copy(scr.surfaceMeshVecs, scr.tmpSurfaceMeshVecs, scr.surfaceMeshVecs.Length);
		}

		public static void OODQQDQDOO(ref List<Vector3> indentVecs, ref List<Vector3> baseVecs, ref List<Vector2> uvs, ref List<bool> doSurroundingTriangle, List<Vector3> originalVecs, List<int> surfaceVecType, float indent, float surrounding, ERCrossingPrefabs scr, ref bool lastIndentIsRight, ref List<float> surroundingValues)
		{
			Vector3 localScale = scr.transform.localScale;
			Vector3 rightVec;
			Vector3 indentVec;
			Vector3 vector2;
			Vector3 vector = (vector2 = (rightVec = (indentVec = Vector3.zero)));
			bool flag = true;
			bool flag2 = true;
			bool flag3 = true;
			bool flag4 = false;
			int num = 0;
			Vector3 a = Vector3.zero;
			Vector3 vector4;
			Vector3 vector3 = (vector4 = Vector3.zero);
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			float num5 = 0f;
			int num6 = scr.crossingElements.Count - 1;
			for (int i = 0; i <= num6; i++)
			{
				scr.crossingElements[i].leftSurroundingV3 = Vector3.zero;
				scr.crossingElements[i].rightSurroundingV3 = Vector3.zero;
				scr.crossingElements[i].leftIndent = -1;
				scr.crossingElements[i].rightIndent = -1;
				if (scr.crossingElements[i].connectedRoad != null)
				{
					if (scr.crossingElements[i].connectedMarker == 0)
					{
						scr.crossingElements[i].leftRoadIndent = scr.crossingElements[i].connectedRoad.markersExt[0].rightIndent;
						scr.crossingElements[i].leftRoadSurrounding = scr.crossingElements[i].connectedRoad.markersExt[0].rightSurrounding;
						scr.crossingElements[i].rightRoadIndent = scr.crossingElements[i].connectedRoad.markersExt[0].leftIndent;
						scr.crossingElements[i].rightRoadSurrounding = scr.crossingElements[i].connectedRoad.markersExt[0].leftSurrounding;
					}
					else
					{
						scr.crossingElements[i].leftRoadIndent = scr.crossingElements[i].connectedRoad.markersExt[scr.crossingElements[i].connectedRoad.markersExt.Count - 1].leftIndent;
						scr.crossingElements[i].leftRoadSurrounding = scr.crossingElements[i].connectedRoad.markersExt[scr.crossingElements[i].connectedRoad.markersExt.Count - 1].leftSurrounding;
						scr.crossingElements[i].rightRoadIndent = scr.crossingElements[i].connectedRoad.markersExt[scr.crossingElements[i].connectedRoad.markersExt.Count - 1].rightIndent;
						scr.crossingElements[i].rightRoadSurrounding = scr.crossingElements[i].connectedRoad.markersExt[scr.crossingElements[i].connectedRoad.markersExt.Count - 1].rightSurrounding;
					}
				}
				else
				{
					indent += scr.extraIndentMargin;
					scr.crossingElements[i].leftRoadIndent = indent + scr.extraIndentMargin;
					scr.crossingElements[i].leftRoadSurrounding = surrounding;
					scr.crossingElements[i].rightRoadIndent = indent + scr.extraIndentMargin;
					scr.crossingElements[i].rightRoadSurrounding = surrounding;
				}
			}
			indent += scr.extraIndentMargin;
			List<Vector3> list = new List<Vector3>(originalVecs);
			if (localScale != new Vector3(1f, 1f, 1f))
			{
				for (int j = 0; j < list.Count; j++)
				{
					list[j] = new Vector3(localScale.x * list[j].x, localScale.y * list[j].y, localScale.z * list[j].z);
				}
				foreach (QDOODOQQDQODD crossingElement in scr.crossingElements)
				{
					crossingElement.rightSurroundingV3 = new Vector3(crossingElement.rightSurroundingV3.x / localScale.x, crossingElement.rightSurroundingV3.y / localScale.y, crossingElement.rightSurroundingV3.z / localScale.z);
					crossingElement.leftSurroundingV3 = new Vector3(crossingElement.leftSurroundingV3.x / localScale.x, crossingElement.leftSurroundingV3.y / localScale.y, crossingElement.leftSurroundingV3.z / localScale.z);
					crossingElement.rightIndentV3 = new Vector3(crossingElement.rightIndentV3.x / localScale.x, crossingElement.rightIndentV3.y / localScale.y, crossingElement.rightIndentV3.z / localScale.z);
					crossingElement.leftIndentV3 = new Vector3(crossingElement.leftIndentV3.x / localScale.x, crossingElement.leftIndentV3.y / localScale.y, crossingElement.leftIndentV3.z / localScale.z);
				}
			}
			List<int> list2 = new List<int>(scr.surfaceConnectionInt);
			bool flag5 = false;
			int num7 = -1;
			for (int k = 0; k < list.Count; k++)
			{
				flag3 = true;
				Vector3 nextVec;
				Vector3 vector6;
				Vector3 vector5;
				if (k == 0)
				{
					vector5 = (list[1] - list[list.Count - 1]).normalized;
					nextVec = list[1];
					vector6 = list[list.Count - 1];
				}
				else if (k == list.Count - 1)
				{
					vector5 = (list[0] - list[list.Count - 2]).normalized;
					nextVec = list[0];
					vector6 = list[k - 1];
				}
				else
				{
					float num8 = Vector3.Distance(list[k], list[k + 1]);
					vector5 = ((surfaceVecType[k + 1] != 0 && !(num8 > 2f * indent)) ? (list[k] - list[k - 1]).normalized : (list[k + 1] - list[k - 1]).normalized);
					nextVec = list[k + 1];
					vector6 = list[k - 1];
				}
				if (surfaceVecType[k] == 1)
				{
					int num9 = -1;
					for (int l = k + 1; l < list.Count; l++)
					{
						if (surfaceVecType[l] == 2 || l == list.Count - 1)
						{
							num9 = l;
							break;
						}
					}
					float minIndent = 0f;
					if (scr.baseScript != null)
					{
						minIndent = scr.baseScript.minIndent;
					}
					List<Vector3> wallIndentPoints = GetWallIndentPoints(list, indentVecs, k, scr.meshVecs, scr.crossingElements[list2[k]].outerVecInts, minIndent, num9, scr, ref scr.crossingElements[list2[k]].outerVecs, null);
					scr.roundingPointsSet = false;
					if (!scr.roundingPointsSet && scr.crossingElements[list2[k]].leftRoundingPoints.Count == 0)
					{
						int num10 = Mathf.RoundToInt(Mathf.Floor((float)scr.crossingElements[list2[k]].outerVecs.Count * 0.5f));
						if (scr.crossingElements[list2[k]].outerVecs.Count > 0 && wallIndentPoints.Count - num10 - 1 > 0)
						{
							scr.crossingElements[list2[k]].leftRoundingPoints = new List<Vector3>(scr.crossingElements[list2[k]].outerVecs);
							scr.crossingElements[list2[k]].leftRoundingPoints.RemoveRange(num10 + 1, wallIndentPoints.Count - num10 - 1);
							scr.crossingElements[list2[num9]].rightRoundingPoints = new List<Vector3>(scr.crossingElements[list2[k]].outerVecs);
							scr.crossingElements[list2[num9]].rightRoundingPoints.RemoveRange(0, num10);
							scr.crossingElements[list2[num9]].rightRoundingPoints.Reverse();
						}
					}
					if (!scr.crossingElements[list2[k]].triangulateLeft)
					{
						for (int m = k + 1; m < list.Count; m++)
						{
							if (surfaceVecType[m] != 2 && m != list.Count - 1)
							{
								continue;
							}
							List<Vector3> list3 = null;
							if (scr.roundingPointsSet)
							{
								list3 = new List<Vector3>(scr.crossingElements[list2[k]].leftRoundingPoints);
								List<Vector3> list4 = new List<Vector3>(scr.crossingElements[list2[m]].rightRoundingPoints);
								list4.Reverse();
								list4.RemoveAt(0);
								list3.AddRange(list4);
							}
							wallIndentPoints = GetWallIndentPoints(list, indentVecs, k, scr.meshVecs, scr.crossingElements[list2[k]].outerVecInts, minIndent, m, scr, ref scr.crossingElements[list2[k]].outerVecs, list3);
							int count = wallIndentPoints.Count;
							for (int n = 0; n < count; n++)
							{
								if (n <= 0 || n < count - 1)
								{
								}
								if (n == 0)
								{
									vector5 = ((k <= 0) ? (list[k] - list[list.Count - 1]).normalized : (list[k] - list[k - 1]).normalized);
									Vector3 vector7 = new Vector3(0f - vector5.z, 0f, vector5.x);
									wallIndentPoints[n] += vector7 * indent;
								}
								else if (n == count - 1)
								{
									vector5 = ((m >= list.Count - 1) ? (list[m] - list[0]).normalized : (list[m] - list[m + 1]).normalized);
									Vector3 vector7 = new Vector3(vector5.z, 0f, 0f - vector5.x);
									wallIndentPoints[n] += vector7 * indent;
								}
								indentVecs.Add(wallIndentPoints[n]);
								baseVecs.Add(wallIndentPoints[n]);
								a = wallIndentPoints[n];
								doSurroundingTriangle.Add(item: false);
								uvs.Add(new Vector2(0f, 1f));
								surroundingValues.Add(0f);
								lastIndentIsRight = flag4;
							}
							k = m;
							break;
						}
						flag2 = false;
					}
					else
					{
						flag4 = false;
						vector5 = ((k <= 0) ? (list[k] - list[list.Count - 1]).normalized : (list[k] - list[k - 1]).normalized);
						indent = scr.crossingElements[list2[k]].leftRoadIndent;
						surrounding = scr.crossingElements[list2[k]].leftRoadSurrounding;
						Vector3 leftVec = (vector = list[k]);
						vector2 = leftVec + vector5 * indent;
						Vector3 vector7 = new Vector3(0f - vector5.z, 0f, vector5.x);
						vector2 += vector7 * indent;
						ODDCQCQCDO(ref vector2, ref vector5, list[k], vector6, nextVec, indent, 0);
						Vector3 normalized = (vector2 - list[k]).normalized;
						Vector3 vector8 = leftVec + normalized * (indent + surrounding);
						num = k;
						if (scr.crossingElements[list2[num]].inwards)
						{
							vector2 = list[k];
							flag = true;
						}
						else
						{
							float num11 = 0f;
							flag = OQDODQCQCC(nextRightIndent: (list2[k] >= num6) ? scr.crossingElements[0].rightRoadIndent : scr.crossingElements[list2[k] + 1].rightRoadIndent, vec: list[k], rightIndentVec: ref indentVec, rightVec: ref rightVec, leftIndentVec: ref vector2, leftVec: ref leftVec, startInt: ref k, vecs: list, surfaceVecType: surfaceVecType, indent: indent, leftIndentDir: vector5, checkVec: vector2);
						}
						vector7 = vector5;
						if (scr.crossingElements[list2[k]].triangulateLeft)
						{
							vector3 = vector2;
						}
						scr.crossingElements[list2[num]].leftIndentV3 = vector3;
						scr.crossingElements[list2[num]].leftIndent = indentVecs.Count;
						scr.crossingElements[list2[num]].leftSurroundingV3 = vector3;
						scr.crossingElements[list2[num]].leftSurrounding = indentVecs.Count;
						vector4 = leftVec;
						if (!flag)
						{
							flag3 = false;
						}
					}
				}
				else if (surfaceVecType[k] == 2)
				{
					vector5 = ((k >= list.Count - 1) ? (list[k] - list[0]).normalized : (list[k] - list[k + 1]).normalized);
					flag4 = true;
					indent = scr.crossingElements[list2[k]].rightRoadIndent;
					surrounding = scr.crossingElements[list2[k]].rightRoadSurrounding;
					Vector3 vector7;
					if (indentVec == Vector3.zero)
					{
						rightVec = list[k];
						indentVec = rightVec + vector5 * indent;
						vector7 = new Vector3(vector5.z, 0f, 0f - vector5.x);
						indentVec += vector7 * indent;
					}
					ODDCQCQCDO(ref indentVec, ref vector5, list[k], vector6, nextVec, indent, 1);
					vector4 = rightVec;
					vector7 = vector5;
					vector3 = indentVec;
					if (list2[k] - 1 >= 0 && scr.crossingElements[list2[k] - 1].triangulateLeft)
					{
						OOCQQDCDDO(ref indentVecs, ref baseVecs, ref doSurroundingTriangle, indentVec, vector4);
					}
					try
					{
						scr.crossingElements[list2[k]].rightIndentV3 = vector3;
						scr.crossingElements[list2[k]].rightIndent = indentVecs.Count;
						scr.crossingElements[list2[k]].rightSurroundingV3 = vector3;
						scr.crossingElements[list2[k]].rightSurrounding = indentVecs.Count;
					}
					catch
					{
						Debug.Log(k + " EasyRoads3Dv3 Error setting surface surrounding elements: " + list2[k] + " " + scr.crossingElements.Count);
					}
					flag3 = false;
				}
				else if (!scr.crossingElements[list2[k]].triangulateLeft)
				{
					vector3 = list[k];
					flag3 = false;
				}
				else
				{
					flag4 = false;
					if (Vector3.Distance(a, list[k]) < 1f)
					{
						flag2 = false;
					}
					if (flag2)
					{
						Vector3 vector7 = new Vector3(0f - vector5.z, 0f, vector5.x);
						Vector3 normalized2 = (list[k] - vector6).normalized;
						float num12 = indent;
						normalized2 = new Vector3(0f - normalized2.z, 0f, normalized2.x);
						float num13 = Vector3.Angle(vector7, normalized2);
						if (num13 > 50f)
						{
							vector7 = Vector3.Lerp(vector7, normalized2, 0.4f).normalized;
							num13 = Vector3.Angle(vector7, normalized2);
						}
						num12 = indent / Mathf.Cos(Vector3.Angle(vector7, normalized2) * (MathF.PI / 180f));
						if (num12 > 2f * indent)
						{
							num12 = 2f * indent;
						}
						vector3 = list[k] + vector7 * num12;
						vector4 = list[k];
						try
						{
							if (indentVecs.Count > 0 && !OQQOCDQCQD.OOCQODQDQD(indentVecs[indentVecs.Count - 1], baseVecs[indentVecs.Count - 1], vector3))
							{
								flag2 = false;
							}
						}
						catch
						{
							Debug.Log(baseVecs.Count + " " + (indentVecs.Count - 1));
						}
						if (indentVecs.Count > 0)
						{
							vector5 = (vector3 - indentVecs[indentVecs.Count - 1]).normalized;
							Vector3 vB = indentVecs[indentVecs.Count - 1] + vector5 * 100f;
							Vector3 vector9 = OQQOCDQCQD.OCOOQOQCDC(indentVecs[indentVecs.Count - 1], vB, list[k]);
							if (Vector3.Distance(list[k], vector9) < indent * 0.8f)
							{
								vector5 = (vector9 - list[k]).normalized;
								vector3 = list[k] + vector5 * indent;
							}
							else if (Vector3.Distance(indentVecs[indentVecs.Count - 1], vector3) < 0.2f * indent)
							{
								vector5 = (vector3 - indentVecs[indentVecs.Count - 1]).normalized;
								vector3 = indentVecs[indentVecs.Count - 1] + vector5 * (0.2f * indent);
							}
						}
					}
				}
				if (flag2)
				{
					indentVecs.Add(vector3);
					baseVecs.Add(vector4);
					doSurroundingTriangle.Add(flag3);
					a = list[k];
					uvs.Add(new Vector2(0f, 1f));
					surroundingValues.Add(surrounding);
					lastIndentIsRight = flag4;
				}
				flag2 = true;
			}
		}

		public static List<Vector3> GetWallIndentPoints(List<Vector3> sourceVecs, List<Vector3> indentVecs, int index, Vector3[] meshVecs, List<int> outerVecInts, float minIndent, int nextRightIndex, ERCrossingPrefabs scr, ref List<Vector3> outervecs, List<Vector3> roundingPoints)
		{
			List<Vector3> list = new List<Vector3>();
			outervecs.Clear();
			Vector3 zero = Vector3.zero;
			int num = outerVecInts.Count - 1;
			if (roundingPoints != null)
			{
				num = roundingPoints.Count - 1;
			}
			for (int i = 0; i <= num; i++)
			{
				if (i == 0)
				{
					Vector3 vector = ((index <= 0) ? (sourceVecs[sourceVecs.Count - 1] - sourceVecs[index]).normalized : (sourceVecs[index - 1] - sourceVecs[index]).normalized);
					zero = sourceVecs[index];
					list.Add(zero + vector * minIndent);
					outervecs.Add(zero);
				}
				else if (i == num)
				{
					Vector3 vector = ((nextRightIndex != sourceVecs.Count - 1) ? (sourceVecs[nextRightIndex + 1] - sourceVecs[nextRightIndex]).normalized : (sourceVecs[0] - sourceVecs[nextRightIndex]).normalized);
					zero = sourceVecs[nextRightIndex];
					list.Add(zero + vector * minIndent);
					outervecs.Add(zero);
				}
				else if (roundingPoints != null)
				{
					Vector3 vector = (roundingPoints[i + 1] - roundingPoints[i]).normalized;
					vector = new Vector3(vector.z, 0f, 0f - vector.x).normalized;
					list.Add(roundingPoints[i] + vector * minIndent);
					outervecs.Add(roundingPoints[i]);
				}
				else
				{
					Vector3 vector = (meshVecs[outerVecInts[i + 1]] - meshVecs[outerVecInts[i]]).normalized;
					vector = new Vector3(vector.z, 0f, 0f - vector.x).normalized;
					list.Add(meshVecs[outerVecInts[i]] + vector * minIndent);
					outervecs.Add(meshVecs[outerVecInts[i]]);
				}
			}
			return list;
		}

		public static void ODDCQCQCDO(ref Vector3 indentVec, ref Vector3 dir, Vector3 vec, Vector3 prefVec, Vector3 nextVec, float indent, int leftOrRight)
		{
			if (leftOrRight == 0)
			{
				if (Vector3.Distance(nextVec, indentVec) >= indent)
				{
					return;
				}
			}
			else if (Vector3.Distance(prefVec, indentVec) >= indent)
			{
				return;
			}
			bool flag = false;
			if (leftOrRight == 0)
			{
				if (!OQQOCDQCQD.OOCQODQDQD(indentVec, vec, nextVec))
				{
					flag = true;
				}
			}
			else if (OQQOCDQCQD.OOCQODQDQD(indentVec, vec, prefVec))
			{
				flag = true;
			}
			Vector3 vector = vec + dir * 1000f;
			Vector3 vector2 = ((leftOrRight != 0) ? OQQOCDQCQD.OCOOQOQCDC(vector, nextVec, prefVec) : OQQOCDQCQD.OCOOQOQCDC(prefVec, vector, nextVec));
			float num = indent;
			float num2 = Vector3.Distance(vec, vector2);
			if (!flag)
			{
				float num3 = ((leftOrRight != 0) ? Vector3.Distance(prefVec, vector2) : Vector3.Distance(nextVec, vector2));
				num = ((!(num2 < num3)) ? (indent - num3) : (indent - num2));
			}
			if (Vector3.Distance(vec, indentVec) > num2)
			{
				float num4 = num / Mathf.Cos(MathF.PI / 4f);
				Vector3 vector3 = ((leftOrRight != 0) ? new Vector3(dir.z, 0f, 0f - dir.x).normalized : new Vector3(0f - dir.z, 0f, dir.x).normalized);
				vector = vector2 + vector3 * 5f;
				dir = ((vector3 + dir) * 0.5f).normalized;
				Vector3 vector4;
				Vector3 normalized;
				if (flag)
				{
					vector4 = nextVec + dir * num;
					normalized = (vector4 - nextVec).normalized;
				}
				else
				{
					vector4 = vector2 + dir * num;
					normalized = (vector4 - vector2).normalized;
				}
				Vector3 vector5 = ((leftOrRight != 0) ? new Vector3(0f - normalized.z, 0f, normalized.x).normalized : new Vector3(normalized.z, 0f, 0f - normalized.x).normalized);
				Vector3 p = indentVec + vector3 * 5f;
				Vector3 p2 = vector4 + vector5 * 5f;
				vector2 = OQQOCDQCQD.OCDCQCDDCC(indentVec, p, vector4, p2, flag: false);
				indentVec = vector2;
			}
			else
			{
				Vector3 vector6 = ((leftOrRight != 0) ? new Vector3(dir.z, 0f, 0f - dir.x).normalized : new Vector3(0f - dir.z, 0f, dir.x).normalized);
				indentVec += vector6 * num;
			}
		}

		public static bool OQDODQCQCC(Vector3 vec, ref Vector3 rightIndentVec, ref Vector3 rightVec, ref Vector3 leftIndentVec, ref Vector3 leftVec, ref int startInt, List<Vector3> vecs, List<int> surfaceVecType, float indent, Vector3 leftIndentDir, Vector3 checkVec, float nextRightIndent)
		{
			Vector3 vector = Vector3.zero;
			int num = 0;
			for (int i = startInt; i < vecs.Count; i++)
			{
				if (surfaceVecType[i] == 2)
				{
					rightVec = vecs[i];
					vector = ((i >= vecs.Count - 1) ? vecs[0] : vecs[i + 1]);
					num = i;
					break;
				}
			}
			if (startInt > 0 && num == 0)
			{
				for (int j = 0; j < startInt; j++)
				{
					if (surfaceVecType[j] == 2)
					{
						rightVec = vecs[j];
						vector = ((j >= vecs.Count - 1) ? vecs[0] : vecs[j + 1]);
						num = j;
						break;
					}
				}
			}
			Vector3 normalized = (rightVec - vector).normalized;
			rightIndentVec = rightVec + normalized * nextRightIndent;
			Vector3 vector2 = new Vector3(normalized.z, 0f, 0f - normalized.x);
			rightIndentVec += vector2 * nextRightIndent;
			if (Mathf.Abs(leftIndentDir.x) != Mathf.Abs(normalized.x) || Mathf.Abs(leftIndentDir.z) != Mathf.Abs(normalized.z))
			{
				if (OQQOCDQCQD.OOCQODQDQD(rightIndentVec, rightVec, checkVec) && !OQQOCDQCQD.OOCQODQDQD(leftIndentVec, vec, rightIndentVec))
				{
					Vector3 vector3 = OQQOCDQCQD.OCDCQCDDCC(rightVec, rightIndentVec, leftVec, leftIndentVec, flag: false);
					leftVec = (rightVec = vector3);
					float num2 = Vector3.Distance(vector3, leftVec);
					if (num2 < indent)
					{
						Vector3 vector4 = Vector3.Lerp(leftIndentDir, normalized, 0.5f);
						float num3 = Vector3.Angle(new Vector3(0f - leftIndentDir.z, 0f, leftIndentDir.x), vector4);
						float num4 = (indent - num2) / Mathf.Sin(num3 * (MathF.PI / 180f));
						leftIndentVec = vector3 + vector4 * num4;
						rightIndentVec = leftIndentVec;
						if (num > startInt)
						{
							startInt = num - 1;
						}
						else
						{
							startInt = vecs.Count - 1;
						}
						return false;
					}
					return true;
				}
				return true;
			}
			return true;
		}

		public static float ERGetInterpolationDistance(Vector3 pos, Vector3 dir, Vector3 vec)
		{
			Vector3 vA = pos + dir * 100f;
			Vector3 vB = pos - dir * 100f;
			Vector3 b = OQQOCDQCQD.OCOOQOQCDC(vA, vB, vec);
			return Vector3.Distance(vec, b);
		}

		public static Vector3 GetNextRightVec(int startInt, List<Vector3> vecs, List<int> surfaceVecType)
		{
			Vector3 result = Vector3.zero;
			int num = 0;
			for (int i = startInt; i < vecs.Count; i++)
			{
				if (surfaceVecType[i] == 2)
				{
					result = vecs[i];
					num = i;
					break;
				}
			}
			if (startInt > 0 && num == 0)
			{
				for (int j = 0; j < startInt; j++)
				{
					if (surfaceVecType[j] == 2)
					{
						result = vecs[j];
						num = j;
						break;
					}
				}
			}
			return result;
		}

		public static void OOCQQDCDDO(ref List<Vector3> indentVecs, ref List<Vector3> baseVecs, ref List<bool> doSurroundingTriangle, Vector3 rightVec, Vector3 baseVec)
		{
			bool flag = false;
			for (int num = indentVecs.Count - 1; num >= 0; num--)
			{
				Vector3 a = OQQOCDQCQD.OCOOQOQCDC(rightVec, baseVec, indentVecs[num]);
				if (Vector3.Distance(a, baseVec) < Vector3.Distance(rightVec, baseVec))
				{
					flag = true;
					if (!OQQOCDQCQD.OOCQODQDQD(rightVec, baseVec, indentVecs[num]))
					{
						break;
					}
					indentVecs.RemoveAt(num);
					baseVecs.RemoveAt(num);
					doSurroundingTriangle.RemoveAt(num);
				}
			}
		}
	}
}
