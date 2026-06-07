using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	public class OCCQCCQOQD : MonoBehaviour
	{
		public static void OCQDQCQDOQ(ERCrossingPrefabs scr, ERModularBase baseScript)
		{
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
			if (scr.indent == 0f || scr.indent < baseScript.terrainMinIndent)
			{
				scr.indent = baseScript.terrainMinIndent;
			}
			if (scr.surrounding == 0f || scr.indent < baseScript.minSurrounding)
			{
				scr.surrounding = baseScript.minSurrounding;
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
			bool lastIndentIsRight = false;
			OOCOQDDDCC(ref indentVecs, ref baseVecs, ref uvs, ref doSurroundingTriangle, scr.surfaceVecs, scr.surfaceVecType, indent, surrounding, scr, ref lastIndentIsRight);
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
			List<TriangleER> list6 = delaunayER.Triangulate(list3);
			List<int> list7 = new List<int>();
			List<int> list8 = new List<int>();
			for (int j = 0; j < list6.Count; j++)
			{
				list7.Add(num + delaunayER.FindVertice(new Vector3(list6[j].Vertex1.x, list6[j].Vertex1.z, list6[j].Vertex1.y), list2));
				list7.Add(num + delaunayER.FindVertice(new Vector3(list6[j].Vertex3.x, list6[j].Vertex3.z, list6[j].Vertex3.y), list2));
				list7.Add(num + delaunayER.FindVertice(new Vector3(list6[j].Vertex2.x, list6[j].Vertex2.z, list6[j].Vertex2.y), list2));
			}
			for (int j = 0; j < list7.Count; j += 3)
			{
				Vector3 vector = (list2[list7[j] - num] + list2[list7[j + 1] - num] + list2[list7[j + 2] - num]) / 3f;
				if (OOCDOQCOCD.OCCOQDODDD(list4.Count, list, vector.x, vector.z))
				{
					list8.Add(list7[j]);
					list8.Add(list7[j + 1]);
					list8.Add(list7[j + 2]);
				}
			}
			scr.surfaceSurroundingInts.Clear();
			num = list2.Count;
			bool flag = true;
			float num2 = 0f;
			bool flag2 = false;
			for (int i = 0; i < num; i++)
			{
				num2 = scr.surrounding;
				flag2 = false;
				if (!doSurroundingTriangle[i])
				{
					flag2 = true;
				}
				if (i == 0)
				{
					if (!doSurroundingTriangle[num - 1])
					{
						flag2 = true;
					}
				}
				else if (!doSurroundingTriangle[i - 1])
				{
					flag2 = true;
				}
				if (flag2)
				{
					num2 = Mathf.Sqrt(num2 * num2 + num2 * num2);
				}
				Vector3 normalized = (list2[i] - baseVecs[i]).normalized;
				Vector3 item = list2[i] + normalized * num2;
				if (i > 0 && !OCQCDQCQOQ.OOOOCDQQOC(list2[list2.Count - 1], list2[list2.Count - 1 - num], item))
				{
					item = list2[list2.Count - 1];
				}
				list2.Add(item);
				uvs.Add(new Vector2(0f, 0f));
				scr.surfaceSurroundingInts.Add(num + i);
				if (doSurroundingTriangle[i] && i < num - 1)
				{
					list8.Add(i);
					list8.Add(i + num);
					list8.Add(i + 1);
					list8.Add(i + num);
					list8.Add(i + num + 1);
					list8.Add(i + 1);
				}
				else if (i == num - 1 && !lastIndentIsRight)
				{
					list8.Add(i);
					list8.Add(i + num);
					list8.Add(0);
					list8.Add(i + num);
					list8.Add(num);
					list8.Add(0);
				}
			}
			for (int i = 0; i < scr.crossingElements.Count; i++)
			{
				int leftIndent = scr.crossingElements[i].leftIndent;
				scr.crossingElements[i].leftSurrounding = leftIndent + num;
				scr.crossingElements[i].leftSurroundingV3 = list2[leftIndent + num];
				leftIndent = scr.crossingElements[i].rightIndent;
				scr.crossingElements[i].rightSurrounding = leftIndent + num;
				scr.crossingElements[i].rightSurroundingV3 = list2[leftIndent + num];
			}
			if (scr.surfaceObject == null)
			{
				if ((bool)scr.transform.Find("surface"))
				{
					scr.surfaceObject = scr.transform.Find("surface").gameObject;
				}
				else
				{
					scr.surfaceObject = new GameObject("surface");
					scr.surfaceObject.hideFlags = HideFlags.HideInHierarchy;
					scr.surfaceObject.transform.position = scr.transform.position;
					scr.surfaceObject.transform.rotation = scr.transform.rotation;
					scr.surfaceObject.transform.parent = scr.transform;
					scr.surfaceObject.layer = 31;
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
				scr.surfaceObject.GetComponent<MeshRenderer>().sharedMaterial = Resources.Load("Materials/surfaceMaterial") as Material;
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
			scr.surfaceObject.layer = 31;
			mesh.Clear();
			mesh.vertices = list2.ToArray();
			mesh.uv = uvs.ToArray();
			mesh.tangents = new Vector4[list2.Count];
			mesh.triangles = list8.ToArray();
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

		public static void OOCOQDDDCC(ref List<Vector3> indentVecs, ref List<Vector3> baseVecs, ref List<Vector2> uvs, ref List<bool> doSurroundingTriangle, List<Vector3> vecs, List<int> surfaceVecType, float indent, float surrounding, ERCrossingPrefabs scr, ref bool lastIndentIsRight)
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
			indent += scr.extraIndentMargin;
			if (localScale != new Vector3(1f, 1f, 1f))
			{
				for (int i = 0; i < vecs.Count; i++)
				{
					vecs[i] = new Vector3(localScale.x * vecs[i].x, localScale.y * vecs[i].y, localScale.z * vecs[i].z);
				}
				foreach (QDOODOQQDQODD crossingElement in scr.crossingElements)
				{
					crossingElement.rightSurroundingV3 = new Vector3(crossingElement.rightSurroundingV3.x / localScale.x, crossingElement.rightSurroundingV3.y / localScale.y, crossingElement.rightSurroundingV3.z / localScale.z);
					crossingElement.leftSurroundingV3 = new Vector3(crossingElement.leftSurroundingV3.x / localScale.x, crossingElement.leftSurroundingV3.y / localScale.y, crossingElement.leftSurroundingV3.z / localScale.z);
					crossingElement.rightIndentV3 = new Vector3(crossingElement.rightIndentV3.x / localScale.x, crossingElement.rightIndentV3.y / localScale.y, crossingElement.rightIndentV3.z / localScale.z);
					crossingElement.leftIndentV3 = new Vector3(crossingElement.leftIndentV3.x / localScale.x, crossingElement.leftIndentV3.y / localScale.y, crossingElement.leftIndentV3.z / localScale.z);
				}
			}
			for (int i = 0; i < vecs.Count; i++)
			{
				flag3 = true;
				Vector3 nextVec;
				Vector3 vector6;
				Vector3 vector5;
				if (i == 0)
				{
					vector5 = (vecs[1] - vecs[vecs.Count - 1]).normalized;
					nextVec = vecs[1];
					vector6 = vecs[vecs.Count - 1];
				}
				else if (i == vecs.Count - 1)
				{
					vector5 = (vecs[0] - vecs[vecs.Count - 2]).normalized;
					nextVec = vecs[0];
					vector6 = vecs[i - 1];
				}
				else
				{
					float num2 = Vector3.Distance(vecs[i], vecs[i + 1]);
					vector5 = ((surfaceVecType[i + 1] != 0 && !(num2 > 2f * indent)) ? (vecs[i] - vecs[i - 1]).normalized : (vecs[i + 1] - vecs[i - 1]).normalized);
					nextVec = vecs[i + 1];
					vector6 = vecs[i - 1];
				}
				if (surfaceVecType[i] == 1)
				{
					flag4 = false;
					vector5 = ((i <= 0) ? (vecs[i] - vecs[vecs.Count - 1]).normalized : (vecs[i] - vecs[i - 1]).normalized);
					Vector3 leftVec = (vector = vecs[i]);
					vector2 = leftVec + vector5 * indent;
					Vector3 vector7 = new Vector3(0f - vector5.z, 0f, vector5.x);
					vector2 += vector7 * indent;
					ODDOOQOQOO(ref vector2, ref vector5, vecs[i], vector6, nextVec, indent, 0);
					Vector3 normalized = (vector2 - vecs[i]).normalized;
					Vector3 vector8 = leftVec + normalized * (indent + surrounding);
					num = i;
					flag = OQCQCQCCCQ(vecs[i], ref indentVec, ref rightVec, ref vector2, ref leftVec, ref i, vecs, surfaceVecType, indent, vector5, vector2);
					vector7 = vector5;
					vector3 = vector2;
					scr.crossingElements[scr.surfaceConnectionInt[num]].leftIndentV3 = vector3;
					scr.crossingElements[scr.surfaceConnectionInt[num]].leftIndent = indentVecs.Count;
					scr.crossingElements[scr.surfaceConnectionInt[num]].leftSurroundingV3 = vector3;
					scr.crossingElements[scr.surfaceConnectionInt[num]].leftSurrounding = indentVecs.Count;
					vector4 = leftVec;
					if (!flag)
					{
						flag3 = false;
					}
				}
				else if (surfaceVecType[i] == 2)
				{
					vector5 = ((i >= vecs.Count - 1) ? (vecs[i] - vecs[0]).normalized : (vecs[i] - vecs[i + 1]).normalized);
					flag4 = true;
					Vector3 vector7;
					if (indentVec == Vector3.zero)
					{
						rightVec = vecs[i];
						indentVec = rightVec + vector5 * indent;
						vector7 = new Vector3(vector5.z, 0f, 0f - vector5.x);
						indentVec += vector7 * indent;
					}
					ODDOOQOQOO(ref indentVec, ref vector5, vecs[i], vector6, nextVec, indent, 1);
					vector4 = rightVec;
					vector7 = vector5;
					vector3 = indentVec;
					OOCCODDODD(ref indentVecs, ref baseVecs, ref doSurroundingTriangle, indentVec, vector4);
					try
					{
						scr.crossingElements[scr.surfaceConnectionInt[i]].rightIndentV3 = vector3;
						scr.crossingElements[scr.surfaceConnectionInt[i]].rightIndent = indentVecs.Count;
						scr.crossingElements[scr.surfaceConnectionInt[i]].rightSurroundingV3 = vector3;
						scr.crossingElements[scr.surfaceConnectionInt[i]].rightSurrounding = indentVecs.Count;
					}
					catch
					{
						Debug.Log(i + " ERROR setting surface surrounding elements: " + scr.surfaceConnectionInt[i] + " " + scr.crossingElements.Count);
					}
					flag3 = false;
				}
				else
				{
					flag4 = false;
					if (Vector3.Distance(a, vecs[i]) < 1f)
					{
						flag2 = false;
					}
					if (flag2)
					{
						Vector3 vector7 = new Vector3(0f - vector5.z, 0f, vector5.x);
						Vector3 normalized2 = (vecs[i] - vector6).normalized;
						float num3 = indent;
						normalized2 = new Vector3(0f - normalized2.z, 0f, normalized2.x);
						float num4 = Vector3.Angle(vector7, normalized2);
						if (num4 > 50f)
						{
							vector7 = Vector3.Lerp(vector7, normalized2, 0.4f).normalized;
							num4 = Vector3.Angle(vector7, normalized2);
						}
						num3 = indent / Mathf.Cos(Vector3.Angle(vector7, normalized2) * ((float)Math.PI / 180f));
						if (num3 > 2f * indent)
						{
							num3 = 2f * indent;
						}
						vector3 = vecs[i] + vector7 * num3;
						vector4 = vecs[i];
						try
						{
							if (indentVecs.Count > 0 && !OCQCDQCQOQ.OOOOCDQQOC(indentVecs[indentVecs.Count - 1], baseVecs[indentVecs.Count - 1], vector3))
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
							Vector3 vector9 = OCQCDQCQOQ.OQQQDCODQD(indentVecs[indentVecs.Count - 1], vB, vecs[i]);
							if (Vector3.Distance(vecs[i], vector9) < indent * 0.8f)
							{
								vector5 = (vector9 - vecs[i]).normalized;
								vector3 = vecs[i] + vector5 * indent;
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
					a = vecs[i];
					uvs.Add(new Vector2(0f, 1f));
					lastIndentIsRight = flag4;
				}
				flag2 = true;
			}
		}

		public static void ODDOOQOQOO(ref Vector3 indentVec, ref Vector3 dir, Vector3 vec, Vector3 prefVec, Vector3 nextVec, float indent, int leftOrRight)
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
				if (!OCQCDQCQOQ.OOOOCDQQOC(indentVec, vec, nextVec))
				{
					flag = true;
				}
			}
			else if (OCQCDQCQOQ.OOOOCDQQOC(indentVec, vec, prefVec))
			{
				flag = true;
			}
			Vector3 vector = vec + dir * 1000f;
			Vector3 vector2 = ((leftOrRight != 0) ? OCQCDQCQOQ.OQQQDCODQD(vector, nextVec, prefVec) : OCQCDQCQOQ.OQQQDCODQD(prefVec, vector, nextVec));
			float num = indent;
			float num2 = Vector3.Distance(vec, vector2);
			if (!flag)
			{
				float num3 = ((leftOrRight != 0) ? Vector3.Distance(prefVec, vector2) : Vector3.Distance(nextVec, vector2));
				num = ((!(num2 < num3)) ? (indent - num3) : (indent - num2));
			}
			if (Vector3.Distance(vec, indentVec) > num2)
			{
				float num4 = num / Mathf.Cos((float)Math.PI / 4f);
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
				vector2 = OCQCDQCQOQ.OCDCDCDCQD(indentVec, p, vector4, p2);
				indentVec = vector2;
			}
			else
			{
				Vector3 vector3 = ((leftOrRight != 0) ? new Vector3(dir.z, 0f, 0f - dir.x).normalized : new Vector3(0f - dir.z, 0f, dir.x).normalized);
				indentVec += vector3 * num;
			}
		}

		public static bool OQCQCQCCCQ(Vector3 vec, ref Vector3 rightIndentVec, ref Vector3 rightVec, ref Vector3 leftIndentVec, ref Vector3 leftVec, ref int startInt, List<Vector3> vecs, List<int> surfaceVecType, float indent, Vector3 leftIndentDir, Vector3 checkVec)
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
				for (int i = 0; i < startInt; i++)
				{
					if (surfaceVecType[i] == 2)
					{
						rightVec = vecs[i];
						vector = ((i >= vecs.Count - 1) ? vecs[0] : vecs[i + 1]);
						num = i;
						break;
					}
				}
			}
			Vector3 normalized = (rightVec - vector).normalized;
			rightIndentVec = rightVec + normalized * indent;
			Vector3 vector2 = new Vector3(normalized.z, 0f, 0f - normalized.x);
			rightIndentVec += vector2 * indent;
			if (Mathf.Abs(leftIndentDir.x) != Mathf.Abs(normalized.x) || Mathf.Abs(leftIndentDir.z) != Mathf.Abs(normalized.z))
			{
				if (OCQCDQCQOQ.OOOOCDQQOC(rightIndentVec, rightVec, checkVec) && !OCQCDQCQOQ.OOOOCDQQOC(leftIndentVec, vec, rightIndentVec))
				{
					Vector3 vector3 = OCQCDQCQOQ.OCDCDCDCQD(rightVec, rightIndentVec, leftVec, leftIndentVec);
					leftVec = (rightVec = vector3);
					float num2 = Vector3.Distance(vector3, leftVec);
					if (num2 < indent)
					{
						Vector3 vector4 = Vector3.Lerp(leftIndentDir, normalized, 0.5f);
						float num3 = Vector3.Angle(new Vector3(0f - leftIndentDir.z, 0f, leftIndentDir.x), vector4);
						float num4 = (indent - num2) / Mathf.Sin(num3 * ((float)Math.PI / 180f));
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
			Vector3 b = OCQCDQCQOQ.OQQQDCODQD(vA, vB, vec);
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
				for (int i = 0; i < startInt; i++)
				{
					if (surfaceVecType[i] == 2)
					{
						result = vecs[i];
						num = i;
						break;
					}
				}
			}
			return result;
		}

		public static void OOCCODDODD(ref List<Vector3> indentVecs, ref List<Vector3> baseVecs, ref List<bool> doSurroundingTriangle, Vector3 rightVec, Vector3 baseVec)
		{
			bool flag = false;
			for (int num = indentVecs.Count - 1; num >= 0; num--)
			{
				Vector3 a = OCQCDQCQOQ.OQQQDCODQD(rightVec, baseVec, indentVecs[num]);
				if (Vector3.Distance(a, baseVec) < Vector3.Distance(rightVec, baseVec))
				{
					flag = true;
					if (!OCQCDQCQOQ.OOOOCDQQOC(rightVec, baseVec, indentVecs[num]))
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
