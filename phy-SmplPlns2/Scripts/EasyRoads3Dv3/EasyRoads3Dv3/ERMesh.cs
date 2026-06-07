using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace EasyRoads3Dv3
{
	[Serializable]
	public class ERMesh
	{
		public List<int> vecsInt = new List<int>();

		public List<Vector3> vecs = new List<Vector3>();

		public List<Vector2> uv = new List<Vector2>();

		public List<Vector2> uv2 = new List<Vector2>();

		public List<Color> colors = new List<Color>();

		public List<Vector3> normals = new List<Vector3>();

		public List<Vector4> tangents = new List<Vector4>();

		public List<int> triangles = new List<int>();

		public List<int> triangles2 = new List<int>();

		public List<int> startVecsInt = new List<int>();

		public List<Vector3> startVecs = new List<Vector3>();

		public List<Vector2> startUv = new List<Vector2>();

		public List<Vector2> startUv2 = new List<Vector2>();

		public List<Color> startColors = new List<Color>();

		public List<Vector3> startNormals = new List<Vector3>();

		public List<Vector4> startTangents = new List<Vector4>();

		public List<int> startTriangles = new List<int>();

		public List<int> startTriangles2 = new List<int>();

		public List<int> endVecsInt = new List<int>();

		public List<Vector3> endVecs = new List<Vector3>();

		public List<Vector2> endUv = new List<Vector2>();

		public List<Vector2> endUv2 = new List<Vector2>();

		public List<Color> endColors = new List<Color>();

		public List<Vector3> endNormals = new List<Vector3>();

		public List<Vector4> endTangents = new List<Vector4>();

		public List<int> endTriangles = new List<int>();

		public List<int> endTriangles2 = new List<int>();

		public List<int> suVecsInt = new List<int>();

		public List<Vector3> suVecs = new List<Vector3>();

		public List<Vector2> suUv = new List<Vector2>();

		public List<Vector2> suUv2 = new List<Vector2>();

		public List<Color> suColors = new List<Color>();

		public List<Vector3> suNormals = new List<Vector3>();

		public List<Vector4> suTangents = new List<Vector4>();

		public List<int> suTriangles = new List<int>();

		public List<int> suTriangles2 = new List<int>();

		public List<int> sdVecsInt = new List<int>();

		public List<Vector3> sdVecs = new List<Vector3>();

		public List<Vector2> sdUv = new List<Vector2>();

		public List<Vector2> sdUv2 = new List<Vector2>();

		public List<Color> sdColors = new List<Color>();

		public List<Vector3> sdNormals = new List<Vector3>();

		public List<Vector4> sdTangents = new List<Vector4>();

		public List<int> sdTriangles = new List<int>();

		public List<int> sdTriangles2 = new List<int>();

		public List<Material> materials = new List<Material>();

		public List<Vector3> sVecs = new List<Vector3>();

		public List<Vector2> sUv = new List<Vector2>();

		public List<Vector2> sUv2 = new List<Vector2>();

		public List<Color> sColors = new List<Color>();

		public List<Vector3> sNormals = new List<Vector3>();

		public List<Vector4> sTangents = new List<Vector4>();

		public List<int> sTriangles = new List<int>();

		public List<Vector3> sTerrainNormals = new List<Vector3>();

		public List<Vector3> dualSidedEdgeVertices = new List<Vector3>();

		public int startSplinePointIndex = 0;

		public int endSplinePointIndex = 0;

		public List<List<Vector3>> sVecsGroups = new List<List<Vector3>>();

		public List<List<Vector2>> sUvGroups = new List<List<Vector2>>();

		public List<List<Vector2>> sUv2Groups = new List<List<Vector2>>();

		public List<List<Color>> sColorsGroups = new List<List<Color>>();

		public List<List<Vector3>> sNormalsGroups = new List<List<Vector3>>();

		public List<List<Vector4>> sTangentsGroups = new List<List<Vector4>>();

		public List<List<int>> sTrianglesGroups = new List<List<int>>();

		public List<List<Vector3>> sTerrainNormalsGroups = new List<List<Vector3>>();

		public List<Vector3> sStartVecs = new List<Vector3>();

		public List<Vector2> sStartUv = new List<Vector2>();

		public List<Vector2> sStartUv2 = new List<Vector2>();

		public List<Color> sStartColors = new List<Color>();

		public List<Vector3> sStartNormals = new List<Vector3>();

		public List<Vector4> sStartTangents = new List<Vector4>();

		public List<int> sStartTriangles = new List<int>();

		public List<Vector3> sEndVecs = new List<Vector3>();

		public List<Vector2> sEndUv = new List<Vector2>();

		public List<Vector2> sEndUv2 = new List<Vector2>();

		public List<Color> sEndColors = new List<Color>();

		public List<Vector3> sEndNormals = new List<Vector3>();

		public List<Vector4> sEndTangents = new List<Vector4>();

		public List<int> sEndTriangles = new List<int>();

		public List<Vector3> sSuVecs = new List<Vector3>();

		public List<Vector2> sSuUv = new List<Vector2>();

		public List<Vector2> sSuUv2 = new List<Vector2>();

		public List<Color> sSuColors = new List<Color>();

		public List<Vector3> sSuNormals = new List<Vector3>();

		public List<Vector4> sSuTangents = new List<Vector4>();

		public List<int> sSuTriangles = new List<int>();

		public List<Vector3> sSdVecs = new List<Vector3>();

		public List<Vector2> sSdUv = new List<Vector2>();

		public List<Vector2> sSdUv2 = new List<Vector2>();

		public List<Color> sSdColors = new List<Color>();

		public List<Vector3> sSdNormals = new List<Vector3>();

		public List<Vector4> sSdTangents = new List<Vector4>();

		public List<int> sSdTriangles = new List<int>();

		public int startEndVecCount = 0;

		public int middleStartVecCount = 0;

		public int middleEndVecCount = 0;

		public int endStartVecCount = 0;

		public List<Vector3> middleEndVecs = new List<Vector3>();

		public List<int> startEndInts = new List<int>();

		public List<int> middleStartInts = new List<int>();

		public List<int> middleEndInts = new List<int>();

		public List<int> middleStartStartInts = new List<int>();

		public List<int> middleEndEndInts = new List<int>();

		public List<int> endStartInts = new List<int>();

		public List<int> startEndIntsNC = new List<int>();

		public List<int> middleStartStartIntsNC = new List<int>();

		public List<int> middleStartIntsNC = new List<int>();

		public List<int> middleEndIntsNC = new List<int>();

		public List<int> middleEndEndIntsNC = new List<int>();

		public List<int> endStartIntsNC = new List<int>();

		public int OCQOOQODCQInt = 0;

		public int OQQCCQDCOOInt = 0;

		public int middleLeftInt = 0;

		public int middleRightInt = 0;

		public int endLeftInt = 0;

		public int endRightInt = 0;

		public List<int> normalArray1 = new List<int>();

		public List<int> normalArray2 = new List<int>();

		public List<List<int>> normalArray1Group = new List<List<int>>();

		public List<List<int>> normalArray2Group = new List<List<int>>();

		public int vecCount = 0;

		public List<float> zValues = new List<float>();

		public List<ZIndexArray> zValueVecIndexes = new List<ZIndexArray>();

		public List<float> zValuesStart = new List<float>();

		public List<ZIndexArray> zValueVecIndexesStart = new List<ZIndexArray>();

		public List<float> zValuesEnd = new List<float>();

		public List<ZIndexArray> zValueVecIndexesEnd = new List<ZIndexArray>();

		public List<float> zValuesStepUp = new List<float>();

		public List<ZIndexArray> zValueVecIndexesStepUp = new List<ZIndexArray>();

		public List<float> zValuesStepDown = new List<float>();

		public List<ZIndexArray> zValueVecIndexesStepDown = new List<ZIndexArray>();

		public float minZ = 10000f;

		public float minMiddleZ = 10000f;

		public float maxZ = -10000f;

		public float maxMiddleZ = -10000f;

		public float totalZDistance = -10000f;

		public float offset1 = 0.01f;

		public float offset2 = 0.001f;

		public List<int> vertexBatches = new List<int>();

		public List<int> triangleBatches = new List<int>();

		public int lodIndex = 0;

		public bool castShadows = true;

		public int middleIndex = 0;

		public int startIndex = 0;

		public int endIndex = 0;

		public string name = "";

		public bool terrainMesh = false;

		public bool snapStartVertices = false;

		public bool snapMiddleVertices = false;

		public bool snapEndVertices = false;

		public void OQDCDCQOOD()
		{
			startTriangles2 = new List<int>(startTriangles);
			int num = 0;
			for (int i = 0; i < startTriangles2.Count; i += 3)
			{
				num = startTriangles2[i + 1];
				startTriangles2[i + 1] = startTriangles2[i + 2];
				startTriangles2[i + 2] = num;
			}
			endTriangles2 = new List<int>(endTriangles);
			for (int j = 0; j < endTriangles2.Count; j += 3)
			{
				num = endTriangles2[j + 1];
				endTriangles2[j + 1] = endTriangles2[j + 2];
				endTriangles2[j + 2] = num;
			}
			triangles2 = new List<int>(triangles);
			for (int k = 0; k < triangles2.Count; k += 3)
			{
				num = triangles2[k + 1];
				triangles2[k + 1] = triangles2[k + 2];
				triangles2[k + 2] = num;
			}
			suTriangles2 = new List<int>(suTriangles);
			for (int l = 0; l < suTriangles2.Count; l += 3)
			{
				num = suTriangles2[l + 1];
				suTriangles2[l + 1] = suTriangles2[l + 2];
				suTriangles2[l + 2] = num;
			}
			sdTriangles2 = new List<int>(sdTriangles);
			for (int m = 0; m < sdTriangles2.Count; m += 3)
			{
				num = sdTriangles2[m + 1];
				sdTriangles2[m + 1] = sdTriangles2[m + 2];
				sdTriangles2[m + 2] = num;
			}
		}

		public ERMesh(GameObject m_go, SideObject soScript, float minZ, Transform sourceTransform, Vector3 scale, Mesh m, Material mat, float startMin = 0f, float endMax = 0f, bool rotate180 = false)
		{
			if (m_go == null)
			{
				if (soScript.material != null)
				{
					materials.Add(soScript.material);
				}
				return;
			}
			totalZDistance = soScript.totalZDistance;
			float startOffset = soScript.startOffset;
			float num = soScript.endOffset;
			float num2 = totalZDistance;
			if (soScript.includeEndSegment)
			{
				num2 -= num;
			}
			startOffset += 0.0001f;
			num2 -= 0.0001f;
			if (!soScript.includeStartSegment)
			{
				startOffset = 0f;
			}
			if (!soScript.includeEndSegment)
			{
				num = 0f;
			}
			soScript.lodLevels = 0;
			sVecs.Clear();
			sUv.Clear();
			sUv2.Clear();
			sColors.Clear();
			sNormals.Clear();
			sTangents.Clear();
			sTriangles.Clear();
			sStartVecs.Clear();
			sStartUv.Clear();
			sStartUv2.Clear();
			sStartColors.Clear();
			sStartNormals.Clear();
			sStartTangents.Clear();
			sStartTriangles.Clear();
			sEndVecs.Clear();
			sEndUv.Clear();
			sEndUv2.Clear();
			sEndColors.Clear();
			sEndNormals.Clear();
			sEndTangents.Clear();
			sEndTriangles.Clear();
			sSuVecs.Clear();
			sSuUv.Clear();
			sSuUv2.Clear();
			sSuColors.Clear();
			sSuNormals.Clear();
			sSuTangents.Clear();
			sSuTriangles.Clear();
			sSdVecs.Clear();
			sSdUv.Clear();
			sSdUv2.Clear();
			sSdColors.Clear();
			sSdNormals.Clear();
			sSdTangents.Clear();
			sSdTriangles.Clear();
			if (m.uv.Length == 0)
			{
				m.uv = new Vector2[m.vertices.Length];
				Debug.Log("EasyRoads3Dv3 warning: Mesh " + m_go.name + " does not have uv data assigned");
			}
			if (m.tangents.Length == 0)
			{
				m.RecalculateTangents();
			}
			List<Vector3> list = new List<Vector3>();
			for (int i = 0; i < m.vertices.Length; i++)
			{
				Vector3 item = m_go.transform.TransformPoint(m.vertices[i]);
				item.z -= minZ;
				if (soScript.flipMesh)
				{
					item.x *= -1f;
				}
				list.Add(item);
			}
			List<Vector3> list2 = new List<Vector3>();
			for (int j = 0; j < m.normals.Length; j++)
			{
				Vector3 item2 = m_go.transform.TransformPoint(m.normals[j]);
				if (soScript.flipMesh)
				{
					item2.x *= -1f;
				}
				list2.Add(item2);
			}
			if (m_go.name.Contains("_start") || m_go.name.Contains("_middle") || m_go.name.Contains("_end") || m_go.name.Contains("_stepUp") || m_go.name.Contains("_stepDown"))
			{
				ussst(m_go, soScript, minZ, sourceTransform, scale, m, mat, startMin, endMax, rotate180);
				return;
			}
			List<CRedge> vecsInts = new List<CRedge>();
			List<CRedge> vecsInts2 = new List<CRedge>();
			List<CRedge> vecsInts3 = new List<CRedge>();
			List<CRedge> vecsInts4 = new List<CRedge>();
			float num3 = 1000f;
			float num4 = -1000f;
			float num5 = 1000f;
			float num6 = -1000f;
			float num7 = 1000f;
			float num8 = -1000f;
			if (startOffset == 0f && num == 0f)
			{
				GetMiddleSementInfo(list, ref num5, ref num6, ref middleStartInts, ref middleEndInts);
				int tri = 0;
				int tri2 = 0;
				int tri3 = 0;
				Color white = Color.white;
				Vector2 zero = Vector2.zero;
				for (int k = 0; k < m.triangles.Length; k += 3)
				{
					try
					{
						ODQDQCOCCO(m.triangles[k], list[m.triangles[k]], ref vecsInt, ref vecs, ref uv, ref uv2, ref normals, ref colors, ref tangents, m.uv[m.triangles[k]], zero, list2[m.triangles[k]], white, m.tangents[m.triangles[k]], ref tri);
					}
					catch
					{
					}
					if (Mathf.Abs(list[m.triangles[k]].z - startOffset) < offset2 && (list[m.triangles[k + 1]].z > startOffset || list[m.triangles[k + 2]].z > startOffset))
					{
						OCCQDDCDCQ(tri, ref middleStartInts);
					}
					if (Mathf.Abs(list[m.triangles[k]].z - num2) < offset2 && (list[m.triangles[k + 1]].z < num2 || list[m.triangles[k + 2]].z < num2))
					{
						OCCQDDCDCQ(tri, ref middleEndInts);
					}
					ODQDQCOCCO(m.triangles[k + 1], list[m.triangles[k + 1]], ref vecsInt, ref vecs, ref uv, ref uv2, ref normals, ref colors, ref tangents, m.uv[m.triangles[k + 1]], zero, list2[m.triangles[k + 1]], white, m.tangents[m.triangles[k + 1]], ref tri2);
					if (Mathf.Abs(list[m.triangles[k + 1]].z - startOffset) < offset2 && (list[m.triangles[k]].z > startOffset || list[m.triangles[k + 2]].z > startOffset))
					{
						OCCQDDCDCQ(tri2, ref middleStartInts);
					}
					if (Mathf.Abs(list[m.triangles[k + 1]].z - num2) < offset2 && (list[m.triangles[k]].z < num2 || list[m.triangles[k + 2]].z < num2))
					{
						OCCQDDCDCQ(tri2, ref middleEndInts);
					}
					ODQDQCOCCO(m.triangles[k + 2], list[m.triangles[k + 2]], ref vecsInt, ref vecs, ref uv, ref uv2, ref normals, ref colors, ref tangents, m.uv[m.triangles[k + 2]], zero, list2[m.triangles[k + 2]], white, m.tangents[m.triangles[k + 2]], ref tri3);
					if (Mathf.Abs(list[m.triangles[k + 2]].z - startOffset) < offset2 && (list[m.triangles[k + 1]].z > startOffset || list[m.triangles[k]].z > startOffset))
					{
						OCCQDDCDCQ(tri3, ref middleStartInts);
					}
					if (Mathf.Abs(list[m.triangles[k + 2]].z - num2) < offset2 && (list[m.triangles[k]].z < num2 || list[m.triangles[k + 1]].z < num2))
					{
						OCCQDDCDCQ(tri3, ref middleEndInts);
					}
					if (Mathf.Abs(list[m.triangles[k]].z - startOffset) < offset2 && Mathf.Abs(list[m.triangles[k + 1]].z - startOffset) < offset2)
					{
						InEdgePairArray(m.triangles[k], m.triangles[k + 1], ref vecsInts2);
					}
					if (Mathf.Abs(list[m.triangles[k]].z - startOffset) < offset2 && Mathf.Abs(list[m.triangles[k + 2]].z - startOffset) < offset2)
					{
						InEdgePairArray(m.triangles[k], m.triangles[k + 2], ref vecsInts2);
					}
					if (Mathf.Abs(list[m.triangles[k + 1]].z - startOffset) < offset2 && Mathf.Abs(list[m.triangles[k + 2]].z - startOffset) < offset2)
					{
						InEdgePairArray(m.triangles[k + 1], m.triangles[k + 2], ref vecsInts2);
					}
					if (Mathf.Abs(list[m.triangles[k]].z - num2) < offset2 && Mathf.Abs(list[m.triangles[k + 1]].z - num2) < offset2)
					{
						InEdgePairArray(m.triangles[k], m.triangles[k + 1], ref vecsInts3);
					}
					if (Mathf.Abs(list[m.triangles[k]].z - num2) < offset2 && Mathf.Abs(list[m.triangles[k + 2]].z - num2) < offset2)
					{
						InEdgePairArray(m.triangles[k], m.triangles[k + 2], ref vecsInts3);
					}
					if (Mathf.Abs(list[m.triangles[k + 1]].z - num2) < offset2 && Mathf.Abs(list[m.triangles[k + 2]].z - num2) < offset2)
					{
						InEdgePairArray(m.triangles[k + 1], m.triangles[k + 2], ref vecsInts3);
					}
				}
				vecs = new List<Vector3>(list);
				uv = new List<Vector2>(m.uv);
				uv2 = new List<Vector2>(m.uv2);
				normals = new List<Vector3>(list2);
				tangents = new List<Vector4>(m.tangents);
				colors = new List<Color>(m.colors);
				triangles = new List<int>(m.triangles);
				soScript.middleZDistance = totalZDistance;
				if (soScript.flipMesh)
				{
					int num9 = 0;
					for (int l = 0; l < triangles.Count; l += 3)
					{
						num9 = triangles[l];
						triangles[l] = triangles[l + 1];
						triangles[l + 1] = num9;
					}
				}
			}
			else
			{
				int tri4 = 0;
				int tri5 = 0;
				int tri6 = 0;
				Color sourceColor = Color.white;
				Vector2 sourceUv = Vector2.zero;
				for (int n = 0; n < m.triangles.Length; n += 3)
				{
					bool flag = false;
					if (list[m.triangles[n]].z < num2 || list[m.triangles[n + 1]].z < num2 || (list[m.triangles[n + 2]].z < num2 && list[m.triangles[n]].z <= num2 + offset1 && list[m.triangles[n + 1]].z <= num2 + offset1 && list[m.triangles[n + 2]].z <= num2 + offset1))
					{
						flag = true;
					}
					if (soScript.includeEndEdgeTris && list[m.triangles[n]].z <= num2 + offset1 && list[m.triangles[n + 1]].z <= num2 + offset1 && list[m.triangles[n + 2]].z <= num2 + offset1)
					{
						flag = true;
					}
					if (flag)
					{
						if (m.colors.Length > m.triangles[n])
						{
							sourceColor = m.colors[m.triangles[n]];
						}
						if (m.uv2.Length > m.triangles[n])
						{
							sourceUv = m.uv2[m.triangles[n]];
						}
						try
						{
							ODQDQCOCCO(m.triangles[n], list[m.triangles[n]], ref startVecsInt, ref startVecs, ref startUv, ref startUv2, ref startNormals, ref startColors, ref startTangents, m.uv[m.triangles[n]], sourceUv, list2[m.triangles[n]], sourceColor, m.tangents[m.triangles[n]], ref tri4);
						}
						catch
						{
						}
						if (Mathf.Abs(list[m.triangles[n]].z - num2) < offset2 && (list[m.triangles[n + 1]].z < num2 || list[m.triangles[n + 2]].z < num2))
						{
							OCCQDDCDCQ(tri4, ref startEndInts);
						}
						if (m.colors.Length > m.triangles[n + 1])
						{
							sourceColor = m.colors[m.triangles[n + 1]];
						}
						if (m.uv2.Length > m.triangles[n + 1])
						{
							sourceUv = m.uv2[m.triangles[n + 1]];
						}
						ODQDQCOCCO(m.triangles[n + 1], list[m.triangles[n + 1]], ref startVecsInt, ref startVecs, ref startUv, ref startUv2, ref startNormals, ref startColors, ref startTangents, m.uv[m.triangles[n + 1]], sourceUv, list2[m.triangles[n + 1]], sourceColor, m.tangents[m.triangles[n + 1]], ref tri5);
						if (Mathf.Abs(list[m.triangles[n + 1]].z - num2) < offset2 && (list[m.triangles[n]].z < num2 || list[m.triangles[n + 2]].z < num2))
						{
							OCCQDDCDCQ(tri5, ref startEndInts);
						}
						if (m.colors.Length > m.triangles[n + 2])
						{
							sourceColor = m.colors[m.triangles[n + 2]];
						}
						if (m.uv2.Length > m.triangles[n + 2])
						{
							sourceUv = m.uv2[m.triangles[n + 2]];
						}
						ODQDQCOCCO(m.triangles[n + 2], list[m.triangles[n + 2]], ref startVecsInt, ref startVecs, ref startUv, ref startUv2, ref startNormals, ref startColors, ref startTangents, m.uv[m.triangles[n + 2]], sourceUv, list2[m.triangles[n + 2]], sourceColor, m.tangents[m.triangles[n + 2]], ref tri6);
						if (Mathf.Abs(list[m.triangles[n + 2]].z - num2) < offset2 && (list[m.triangles[n]].z < num2 || list[m.triangles[n + 1]].z < num2))
						{
							OCCQDDCDCQ(tri6, ref startEndInts);
						}
						if (Mathf.Abs(list[m.triangles[n]].z - num2) < offset2 && Mathf.Abs(list[m.triangles[n + 1]].z - num2) < offset2)
						{
							InEdgePairArray(tri4, tri5, ref vecsInts);
						}
						if (Mathf.Abs(list[m.triangles[n]].z - num2) < offset2 && Mathf.Abs(list[m.triangles[n + 2]].z - num2) < offset2)
						{
							InEdgePairArray(tri4, tri6, ref vecsInts);
						}
						if (Mathf.Abs(list[m.triangles[n + 1]].z - num2) < offset2 && Mathf.Abs(list[m.triangles[n + 2]].z - num2) < offset2)
						{
							InEdgePairArray(tri5, tri6, ref vecsInts);
						}
						if (!soScript.flipMesh)
						{
							startTriangles.Add(tri4);
							startTriangles.Add(tri5);
							startTriangles.Add(tri6);
						}
						else
						{
							startTriangles.Add(tri5);
							startTriangles.Add(tri4);
							startTriangles.Add(tri6);
						}
						if (list[m.triangles[n]].z <= num3)
						{
							num3 = list[m.triangles[n]].z;
						}
						if (list[m.triangles[n + 1]].z <= num3)
						{
							num3 = list[m.triangles[n + 1]].z;
						}
						if (list[m.triangles[n + 2]].z <= num3)
						{
							num3 = list[m.triangles[n + 2]].z;
						}
						if (list[m.triangles[n]].z >= num4)
						{
							num4 = list[m.triangles[n]].z;
						}
						if (list[m.triangles[n + 1]].z >= num4)
						{
							num4 = list[m.triangles[n + 1]].z;
						}
						if (list[m.triangles[n + 2]].z >= num4)
						{
							num4 = list[m.triangles[n + 2]].z;
						}
					}
					bool flag2 = false;
					if (list[m.triangles[n]].z > startOffset || list[m.triangles[n + 1]].z > startOffset || (list[m.triangles[n + 2]].z > startOffset && list[m.triangles[n]].z > startOffset - offset1 && list[m.triangles[n + 1]].z > startOffset - offset1 && list[m.triangles[n + 2]].z > startOffset - offset1))
					{
						flag2 = true;
					}
					if (soScript.includeStartEdgeTris && list[m.triangles[n]].z >= startOffset - offset1 && list[m.triangles[n + 1]].z >= startOffset - offset1 && list[m.triangles[n + 2]].z >= startOffset - offset1)
					{
						flag2 = true;
					}
					if (!flag2)
					{
						continue;
					}
					if (m.colors.Length > m.triangles[n])
					{
						sourceColor = m.colors[m.triangles[n]];
					}
					if (m.uv2.Length > m.triangles[n])
					{
						sourceUv = m.uv2[m.triangles[n]];
					}
					ODQDQCOCCO(m.triangles[n], list[m.triangles[n]], ref endVecsInt, ref endVecs, ref endUv, ref endUv2, ref endNormals, ref endColors, ref endTangents, m.uv[m.triangles[n]], sourceUv, list2[m.triangles[n]], sourceColor, m.tangents[m.triangles[n]], ref tri4);
					if (Mathf.Abs(list[m.triangles[n]].z - startOffset) < offset2 && (list[m.triangles[n + 1]].z > startOffset || list[m.triangles[n + 2]].z > startOffset))
					{
						OCCQDDCDCQ(tri4, ref endStartInts);
					}
					if (m.colors.Length > m.triangles[n + 1])
					{
						sourceColor = m.colors[m.triangles[n + 1]];
					}
					if (m.uv2.Length > m.triangles[n + 1])
					{
						sourceUv = m.uv2[m.triangles[n + 1]];
					}
					ODQDQCOCCO(m.triangles[n + 1], list[m.triangles[n + 1]], ref endVecsInt, ref endVecs, ref endUv, ref endUv2, ref endNormals, ref endColors, ref endTangents, m.uv[m.triangles[n + 1]], sourceUv, list2[m.triangles[n + 1]], sourceColor, m.tangents[m.triangles[n + 1]], ref tri5);
					if (Mathf.Abs(list[m.triangles[n + 1]].z - startOffset) < offset2 && (list[m.triangles[n]].z > startOffset || list[m.triangles[n + 2]].z > startOffset))
					{
						OCCQDDCDCQ(tri5, ref endStartInts);
					}
					if (m.colors.Length > m.triangles[n + 2])
					{
						sourceColor = m.colors[m.triangles[n + 2]];
					}
					if (m.uv2.Length > m.triangles[n + 2])
					{
						sourceUv = m.uv2[m.triangles[n + 2]];
					}
					ODQDQCOCCO(m.triangles[n + 2], list[m.triangles[n + 2]], ref endVecsInt, ref endVecs, ref endUv, ref endUv2, ref endNormals, ref endColors, ref endTangents, m.uv[m.triangles[n + 2]], sourceUv, list2[m.triangles[n + 2]], sourceColor, m.tangents[m.triangles[n + 2]], ref tri6);
					if (Mathf.Abs(list[m.triangles[n + 2]].z - startOffset) < offset2 && (list[m.triangles[n + 1]].z > startOffset || list[m.triangles[n]].z > startOffset))
					{
						OCCQDDCDCQ(tri6, ref endStartInts);
					}
					if (Mathf.Abs(list[m.triangles[n]].z - startOffset) < offset2 && Mathf.Abs(list[m.triangles[n + 1]].z - startOffset) < offset2)
					{
						InEdgePairArray(tri4, tri5, ref vecsInts4);
					}
					if (Mathf.Abs(list[m.triangles[n]].z - startOffset) < offset2 && Mathf.Abs(list[m.triangles[n + 2]].z - startOffset) < offset2)
					{
						InEdgePairArray(tri4, tri6, ref vecsInts4);
					}
					if (Mathf.Abs(list[m.triangles[n + 1]].z - startOffset) < offset2 && Mathf.Abs(list[m.triangles[n + 2]].z - startOffset) < offset2)
					{
						InEdgePairArray(tri5, tri6, ref vecsInts4);
					}
					if (!soScript.flipMesh)
					{
						endTriangles.Add(tri4);
						endTriangles.Add(tri5);
						endTriangles.Add(tri6);
					}
					else
					{
						endTriangles.Add(tri5);
						endTriangles.Add(tri4);
						endTriangles.Add(tri6);
					}
					if (list[m.triangles[n]].z <= num7)
					{
						num7 = list[m.triangles[n]].z;
					}
					if (list[m.triangles[n + 1]].z <= num7)
					{
						num7 = list[m.triangles[n + 1]].z;
					}
					if (list[m.triangles[n + 2]].z <= num7)
					{
						num7 = list[m.triangles[n + 2]].z;
					}
					if (list[m.triangles[n]].z >= num8)
					{
						num8 = list[m.triangles[n]].z;
					}
					if (list[m.triangles[n + 1]].z >= num8)
					{
						num8 = list[m.triangles[n + 1]].z;
					}
					if (list[m.triangles[n + 2]].z >= num8)
					{
						num8 = list[m.triangles[n + 2]].z;
					}
					if (flag)
					{
						if (m.colors.Length > m.triangles[n])
						{
							sourceColor = m.colors[m.triangles[n]];
						}
						if (m.uv2.Length > m.triangles[n])
						{
							sourceUv = m.uv2[m.triangles[n]];
						}
						ODQDQCOCCO(m.triangles[n], list[m.triangles[n]], ref vecsInt, ref vecs, ref uv, ref uv2, ref normals, ref colors, ref tangents, m.uv[m.triangles[n]], sourceUv, list2[m.triangles[n]], sourceColor, m.tangents[m.triangles[n]], ref tri4);
						if (Mathf.Abs(list[m.triangles[n]].z - startOffset) < offset2 && (list[m.triangles[n + 1]].z > startOffset || list[m.triangles[n + 2]].z > startOffset))
						{
							OCCQDDCDCQ(tri4, ref middleStartInts);
						}
						if (Mathf.Abs(list[m.triangles[n]].z - num2) < offset2 && (list[m.triangles[n + 1]].z < num2 || list[m.triangles[n + 2]].z < num2))
						{
							OCCQDDCDCQ(tri4, ref middleEndInts);
						}
						if (m.colors.Length > m.triangles[n + 1])
						{
							sourceColor = m.colors[m.triangles[n + 1]];
						}
						if (m.uv2.Length > m.triangles[n + 1])
						{
							sourceUv = m.uv2[m.triangles[n + 1]];
						}
						ODQDQCOCCO(m.triangles[n + 1], list[m.triangles[n + 1]], ref vecsInt, ref vecs, ref uv, ref uv2, ref normals, ref colors, ref tangents, m.uv[m.triangles[n + 1]], sourceUv, list2[m.triangles[n + 1]], sourceColor, m.tangents[m.triangles[n + 1]], ref tri5);
						if (Mathf.Abs(list[m.triangles[n + 1]].z - startOffset) < offset2 && (list[m.triangles[n]].z > startOffset || list[m.triangles[n + 2]].z > startOffset))
						{
							OCCQDDCDCQ(tri5, ref middleStartInts);
						}
						if (Mathf.Abs(list[m.triangles[n + 1]].z - num2) < offset2 && (list[m.triangles[n]].z < num2 || list[m.triangles[n + 2]].z < num2))
						{
							OCCQDDCDCQ(tri5, ref middleEndInts);
						}
						if (m.colors.Length > m.triangles[n + 2])
						{
							sourceColor = m.colors[m.triangles[n + 2]];
						}
						if (m.uv2.Length > m.triangles[n + 2])
						{
							sourceUv = m.uv2[m.triangles[n + 2]];
						}
						ODQDQCOCCO(m.triangles[n + 2], list[m.triangles[n + 2]], ref vecsInt, ref vecs, ref uv, ref uv2, ref normals, ref colors, ref tangents, m.uv[m.triangles[n + 2]], sourceUv, list2[m.triangles[n + 2]], sourceColor, m.tangents[m.triangles[n + 2]], ref tri6);
						if (Mathf.Abs(list[m.triangles[n + 2]].z - startOffset) < offset2 && (list[m.triangles[n + 1]].z > startOffset || list[m.triangles[n]].z > startOffset))
						{
							OCCQDDCDCQ(tri6, ref middleStartInts);
						}
						if (Mathf.Abs(list[m.triangles[n + 2]].z - num2) < offset2 && (list[m.triangles[n]].z < num2 || list[m.triangles[n + 1]].z < num2))
						{
							OCCQDDCDCQ(tri6, ref middleEndInts);
						}
						if (Mathf.Abs(list[m.triangles[n]].z - startOffset) < offset2 && Mathf.Abs(list[m.triangles[n + 1]].z - startOffset) < offset2)
						{
							InEdgePairArray(tri4, tri5, ref vecsInts2);
						}
						if (Mathf.Abs(list[m.triangles[n]].z - startOffset) < offset2 && Mathf.Abs(list[m.triangles[n + 2]].z - startOffset) < offset2)
						{
							InEdgePairArray(tri4, tri6, ref vecsInts2);
						}
						if (Mathf.Abs(list[m.triangles[n + 1]].z - startOffset) < offset2 && Mathf.Abs(list[m.triangles[n + 2]].z - startOffset) < offset2)
						{
							InEdgePairArray(tri5, tri6, ref vecsInts2);
						}
						if (Mathf.Abs(list[m.triangles[n]].z - num2) < offset2 && Mathf.Abs(list[m.triangles[n + 1]].z - num2) < offset2)
						{
							InEdgePairArray(tri4, tri5, ref vecsInts3);
						}
						if (Mathf.Abs(list[m.triangles[n]].z - num2) < offset2 && Mathf.Abs(list[m.triangles[n + 2]].z - num2) < offset2)
						{
							InEdgePairArray(tri4, tri6, ref vecsInts3);
						}
						if (Mathf.Abs(list[m.triangles[n + 1]].z - num2) < offset2 && Mathf.Abs(list[m.triangles[n + 2]].z - num2) < offset2)
						{
							InEdgePairArray(tri5, tri6, ref vecsInts3);
						}
						if (!soScript.flipMesh)
						{
							triangles.Add(tri4);
							triangles.Add(tri5);
							triangles.Add(tri6);
						}
						else
						{
							triangles.Add(tri5);
							triangles.Add(tri4);
							triangles.Add(tri6);
						}
						if (list[m.triangles[n]].z <= num5)
						{
							num5 = list[m.triangles[n]].z;
						}
						if (list[m.triangles[n + 1]].z <= num5)
						{
							num5 = list[m.triangles[n + 1]].z;
						}
						if (list[m.triangles[n + 2]].z <= num5)
						{
							num5 = list[m.triangles[n + 2]].z;
						}
						if (list[m.triangles[n]].z >= num6)
						{
							num6 = list[m.triangles[n]].z;
						}
						if (list[m.triangles[n + 1]].z >= num6)
						{
							num6 = list[m.triangles[n + 1]].z;
						}
						if (list[m.triangles[n + 2]].z >= num6)
						{
							num6 = list[m.triangles[n + 2]].z;
						}
					}
				}
				for (int num10 = 0; num10 < endVecs.Count; num10++)
				{
					Vector3 item = endVecs[num10];
					item.z -= startOffset;
					endVecs[num10] = item;
				}
			}
			if (soScript.minStartZ > num3)
			{
				soScript.minStartZ = num3;
			}
			if (soScript.maxStartZ < num4)
			{
				soScript.maxStartZ = num4;
			}
			if (soScript.minMiddleZ > num5)
			{
				soScript.minMiddleZ = num5;
			}
			if (soScript.maxMiddleZ < num6)
			{
				soScript.maxMiddleZ = num6;
			}
			if (soScript.minEndZ > num7)
			{
				soScript.minEndZ = num7;
			}
			if (soScript.maxEndZ < num8)
			{
				soScript.maxEndZ = num8;
			}
			for (int num11 = 0; num11 < vecs.Count; num11++)
			{
				Vector3 item = vecs[num11];
				item.z -= startOffset;
				vecs[num11] = item;
			}
			materials = new List<Material>();
			materials.Add(mat);
			zValuesStart.Clear();
			zValueVecIndexesStart.Clear();
			zValuesEnd.Clear();
			zValueVecIndexesEnd.Clear();
			OQCCCOOQOO(vecs, ref zValueVecIndexes, ref zValues);
			OQCCCOOQOO(startVecs, ref zValueVecIndexesStart, ref zValuesStart);
			OQCCCOOQOO(endVecs, ref zValueVecIndexesEnd, ref zValuesEnd);
			startEndInts.Clear();
			middleStartStartInts.Clear();
			middleStartInts.Clear();
			middleEndInts.Clear();
			middleEndEndInts.Clear();
			endStartInts.Clear();
			startEndIntsNC.Clear();
			middleStartStartIntsNC.Clear();
			middleStartIntsNC.Clear();
			middleEndIntsNC.Clear();
			middleEndEndIntsNC.Clear();
			endStartIntsNC.Clear();
			if (soScript.includeStartSegment)
			{
				MatchEdgePairs(vecsInts, new List<CRedge>(vecsInts2), ref startEndInts, ref middleStartStartInts, ref startEndIntsNC, ref middleStartStartIntsNC, startVecs, vecs, startNormals, normals, ref OCQOOQODCQInt, ref OQQCCQDCOOInt);
			}
			MatchEdgePairs(vecsInts2, new List<CRedge>(vecsInts3), ref middleStartInts, ref middleEndInts, ref middleStartIntsNC, ref middleEndIntsNC, vecs, vecs, normals, normals, ref middleLeftInt, ref middleRightInt);
			if (soScript.includeEndSegment)
			{
				MatchEdgePairs(vecsInts3, vecsInts4, ref middleEndEndInts, ref endStartInts, ref middleEndEndIntsNC, ref endStartIntsNC, vecs, endVecs, normals, endNormals, ref endLeftInt, ref endRightInt);
			}
			if (scale != Vector3.one)
			{
				for (int num12 = 0; num12 < startVecs.Count; num12++)
				{
					Vector3 item = startVecs[num12];
					item.x *= scale.x;
					item.y *= scale.y;
					item.z *= scale.z;
					startVecs[num12] = item;
				}
				for (int num13 = 0; num13 < vecs.Count; num13++)
				{
					Vector3 item = vecs[num13];
					item.x *= scale.x;
					item.y *= scale.y;
					item.z *= scale.z;
					vecs[num13] = item;
				}
				for (int num14 = 0; num14 < endVecs.Count; num14++)
				{
					Vector3 item = endVecs[num14];
					item.x *= scale.x;
					item.y *= scale.y;
					item.z *= scale.z;
					endVecs[num14] = item;
				}
			}
			if (soScript.doTestmesh)
			{
				ERModularBase eRModularBase = UnityEngine.Object.FindObjectOfType(typeof(ERModularBase)) as ERModularBase;
				Transform transform = eRModularBase.transform;
				Transform transform2 = transform.Find("tmp folder");
				if ((bool)transform2)
				{
					UnityEngine.Object.DestroyImmediate(transform2.gameObject);
				}
				GameObject gameObject = new GameObject("tmp folder");
				gameObject.transform.position = Vector3.zero;
				gameObject.transform.parent = transform;
				GameObject gameObject2;
				if (soScript.includeStartSegment)
				{
					gameObject2 = new GameObject("start object");
					gameObject2.transform.parent = gameObject.transform;
					gameObject2.transform.position = soScript.testMeshPos;
					gameObject2.AddComponent<MeshRenderer>();
					gameObject2.AddComponent<MeshFilter>();
					m = new Mesh();
					gameObject2.GetComponent<MeshRenderer>().sharedMaterial = materials[0];
					gameObject2.GetComponent<MeshFilter>().sharedMesh = m;
					m.vertices = startVecs.ToArray();
					m.uv = startUv.ToArray();
					m.uv2 = startUv2.ToArray();
					m.colors = startColors.ToArray();
					m.normals = startNormals.ToArray();
					m.tangents = startTangents.ToArray();
					m.triangles = startTriangles.ToArray();
					m.RecalculateNormals();
					m.RecalculateBounds();
				}
				Vector3 testMeshPos;
				if (soScript.includeEndSegment)
				{
					gameObject2 = new GameObject("end object");
					gameObject2.transform.parent = gameObject.transform;
					testMeshPos = soScript.testMeshPos;
					testMeshPos.z += num2 + num2 - startOffset;
					gameObject2.transform.position = testMeshPos;
					gameObject2.AddComponent<MeshRenderer>();
					gameObject2.AddComponent<MeshFilter>();
					m = new Mesh();
					m.MarkDynamic();
					gameObject2.GetComponent<MeshRenderer>().sharedMaterial = materials[0];
					gameObject2.GetComponent<MeshFilter>().sharedMesh = m;
					m.vertices = endVecs.ToArray();
					m.uv = endUv.ToArray();
					m.uv2 = endUv2.ToArray();
					m.colors = endColors.ToArray();
					m.normals = endNormals.ToArray();
					m.tangents = endTangents.ToArray();
					m.triangles = endTriangles.ToArray();
					m.RecalculateNormals();
					m.RecalculateBounds();
				}
				gameObject2 = new GameObject("middle object");
				gameObject2.transform.parent = gameObject.transform;
				testMeshPos = soScript.testMeshPos;
				testMeshPos.z += num2;
				gameObject2.transform.position = testMeshPos;
				gameObject2.AddComponent<MeshRenderer>();
				gameObject2.AddComponent<MeshFilter>();
				m = new Mesh();
				gameObject2.GetComponent<MeshRenderer>().sharedMaterial = materials[0];
				gameObject2.GetComponent<MeshFilter>().sharedMesh = m;
				m.vertices = vecs.ToArray();
				m.uv = uv.ToArray();
				m.uv2 = uv2.ToArray();
				m.colors = colors.ToArray();
				m.normals = normals.ToArray();
				m.tangents = tangents.ToArray();
				m.triangles = triangles.ToArray();
				m.RecalculateNormals();
				m.RecalculateBounds();
			}
			OQDCDCQOOD();
		}

		private void ussst(GameObject tssss, SideObject ussss, float vssss, Transform wssss, Vector3 xssss, Mesh yssss, Material Assss, float _0ssss, float _1ssss, bool _2ssss)
		{
			List<float> list = new List<float>();
			List<ZIndexArray> list2 = new List<ZIndexArray>();
			List<Vector3> list3 = new List<Vector3>(yssss.vertices);
			List<Vector2> list4 = new List<Vector2>(yssss.uv);
			List<Vector2> list5 = new List<Vector2>(yssss.uv4);
			List<Color> list6 = new List<Color>(yssss.colors);
			List<Vector3> list7 = new List<Vector3>(yssss.normals);
			List<Vector4> list8 = new List<Vector4>(yssss.tangents);
			List<int> list9 = new List<int>(yssss.triangles);
			float num = 10000f;
			float num2 = -10000f;
			bool flag = false;
			if (tssss.name.Contains("_start"))
			{
				flag = true;
			}
			bool flag2 = false;
			if (tssss.name.Contains("_end"))
			{
				flag2 = true;
			}
			for (int i = 0; i < list3.Count; i++)
			{
				if (_2ssss)
				{
				}
				list3[i] = tssss.transform.TransformPoint(list3[i]);
				if (list3[i].z < num)
				{
					num = list3[i].z;
				}
				if (list3[i].z > num2)
				{
					num2 = list3[i].z;
				}
			}
			float num3 = Mathf.Abs(num2 - num) + 0.001f;
			for (int j = 0; j < list3.Count; j++)
			{
				Vector3 value = list3[j];
				if (flag)
				{
					value.z -= _0ssss;
				}
				else if (flag2 && _1ssss > num3)
				{
					value.z = value.z - num + _1ssss - num2;
				}
				else
				{
					value.z -= num;
				}
				list3[j] = value;
			}
			lodIndex = -1;
			string text = tssss.name;
			if (text.Contains("_lod") || text.Contains("_LOD"))
			{
				int num4 = text.ToUpper().IndexOf("_LOD");
				if (text.Length >= num4 + 5)
				{
					string s = text.Substring(num4 + 4, 1);
					lodIndex = -1;
					if (int.TryParse(s, out lodIndex) && lodIndex > ussss.lodLevels)
					{
						ussss.lodLevels = lodIndex;
					}
				}
			}
			if (tssss.name.Contains("_start"))
			{
				ussss.includeStartSegment = true;
				startVecs = list3;
				startUv = list4;
				startUv2 = list5;
				startColors = list6;
				startNormals = list7;
				startTangents = list8;
				startTriangles = list9;
				ussss.startZDistance = num3;
				if (ussss.maxStartZ < num2)
				{
					ussss.maxStartZ = num2;
				}
				if (ussss.minStartZ > num)
				{
					ussss.minStartZ = num;
				}
				ussss.startSection = true;
				if (tssss.name.Contains("_terrain"))
				{
					if (startColors.Count != list3.Count)
					{
						startColors = new List<Color>(new Color[list3.Count]);
					}
					startColors = OOCCQCDQQQ(tssss, list3, startColors, 1f);
					ussss.hasVertexColors = true;
				}
			}
			else if (tssss.name.Contains("_end"))
			{
				ussss.includeEndSegment = true;
				endVecs = list3;
				endUv = list4;
				endUv2 = list5;
				endColors = list6;
				endNormals = list7;
				endTangents = list8;
				endTriangles = list9;
				ussss.endZDistance = num3;
				if (ussss.maxEndZ < num2)
				{
					ussss.maxEndZ = num2;
				}
				if (ussss.minEndZ > num)
				{
					ussss.minEndZ = num;
				}
				ussss.endSection = true;
				if (tssss.name.Contains("_terrain"))
				{
					if (endColors.Count != list3.Count)
					{
						endColors = new List<Color>(new Color[list3.Count]);
					}
					endColors = OOCCQCDQQQ(tssss, list3, endColors, -1f);
					ussss.hasVertexColors = true;
				}
			}
			else if (tssss.name.Contains("_middle"))
			{
				vecs = list3;
				uv = list4;
				uv2 = list5;
				colors = list6;
				normals = list7;
				tangents = list8;
				triangles = list9;
				ussss.middleZDistance = num3;
				ussss.maxMiddleZ = num2;
				ussss.minMiddleZ = num;
				if (ussss.maxMiddleZ < num2)
				{
					ussss.maxMiddleZ = num2;
				}
				if (ussss.minMiddleZ > num)
				{
					ussss.minMiddleZ = num;
				}
			}
			else if (tssss.name.Contains("_stepUp"))
			{
				suVecs = list3;
				suUv = list4;
				suUv2 = list5;
				suColors = list6;
				suNormals = list7;
				suTangents = list8;
				suTriangles = list9;
				ussss.stepUp = true;
			}
			else if (tssss.name.Contains("_stepDown"))
			{
				sdVecs = list3;
				sdUv = list4;
				sdUv2 = list5;
				sdColors = list6;
				sdNormals = list7;
				sdTangents = list8;
				sdTriangles = list9;
				ussss.stepDown = true;
			}
			materials = new List<Material>();
			materials.Add(Assss);
			zValuesStart.Clear();
			zValueVecIndexesStart.Clear();
			zValues.Clear();
			zValueVecIndexes.Clear();
			zValuesEnd.Clear();
			zValueVecIndexesEnd.Clear();
			zValuesStepUp.Clear();
			zValueVecIndexesStepUp.Clear();
			zValuesStepDown.Clear();
			zValueVecIndexesStepDown.Clear();
			OQCCCOOQOO(vecs, ref zValueVecIndexes, ref zValues);
			OQCCCOOQOO(startVecs, ref zValueVecIndexesStart, ref zValuesStart);
			OQCCCOOQOO(endVecs, ref zValueVecIndexesEnd, ref zValuesEnd);
			OQCCCOOQOO(suVecs, ref zValueVecIndexesStepUp, ref zValuesStepUp);
			OQCCCOOQOO(sdVecs, ref zValueVecIndexesStepDown, ref zValuesStepDown);
			OQDCDCQOOD();
		}

		private List<int> OQDQOOODDC(List<int> tris, List<Color> colors, List<Vector3> vecs)
		{
			for (int i = 0; i < tris.Count; i += 3)
			{
				if (colors[tris[i]].g == 1f && colors[tris[i + 1]].g == 1f && colors[tris[i + 2]].g == 1f && vecs[tris[i]].y - 0.5f > 0f && vecs[tris[i + 1]].y - 0.5f > 0f && vecs[tris[i + 2]].y - 0.5f > 0f)
				{
					tris.RemoveRange(i, 3);
					i -= 3;
				}
			}
			return tris;
		}

		private void OQCCCOOQOO(List<Vector3> vecs, ref List<ZIndexArray> zValueVecIndexes, ref List<float> zValues)
		{
			for (int i = 0; i < vecs.Count; i++)
			{
				if (!OCODOQCQCD(vecs[i], i, zValues, ref zValueVecIndexes))
				{
					zValues.Add(vecs[i].z);
					zValueVecIndexes.Add(new ZIndexArray());
					zValueVecIndexes[zValueVecIndexes.Count - 1].index.Add(i);
				}
			}
		}

		public void GetMiddleSementInfo(List<Vector3> vecs, ref float minMiddleZ, ref float maxMiddleZ, ref List<int> middleStartInts, ref List<int> middleEndInts)
		{
			for (int i = 0; i < vecs.Count; i++)
			{
				if (vecs[i].z < minMiddleZ)
				{
					minMiddleZ = vecs[i].z;
				}
				if (vecs[i].z > maxMiddleZ)
				{
					maxMiddleZ = vecs[i].z;
				}
			}
			GetMiddleEdges(vecs, minMiddleZ, ref middleStartInts);
			GetMiddleEdges(vecs, maxMiddleZ, ref middleEndInts);
		}

		public void GetMiddleEdges(List<Vector3> vecs, float z, ref List<int> edgeInts)
		{
			for (int i = 0; i < vecs.Count; i++)
			{
				if (Mathf.Abs(vecs[i].z - z) < offset2)
				{
					edgeInts.Add(i);
				}
			}
		}

		public bool OCODOQCQCD(Vector3 v, int index, List<float> zV, ref List<ZIndexArray> zVIndexes)
		{
			for (int i = 0; i < zV.Count; i++)
			{
				if (zV[i] == v.z)
				{
					zVIndexes[i].index.Add(index);
					return true;
				}
			}
			return false;
		}

		public void ODQDQCOCCO(int index, Vector3 v, ref List<int> vecsInts, ref List<Vector3> vecs, ref List<Vector2> uv, ref List<Vector2> uv2, ref List<Vector3> normals, ref List<Color> colors, ref List<Vector4> tangents, Vector2 sourceUv, Vector2 sourceUv2, Vector3 sourceNormal, Color sourceColor, Vector4 sourceTangent, ref int tri)
		{
			for (int i = 0; i < vecsInts.Count; i++)
			{
				if (index == vecsInts[i])
				{
					tri = i;
					return;
				}
			}
			vecsInts.Add(index);
			vecs.Add(v);
			uv.Add(sourceUv);
			uv2.Add(sourceUv2);
			normals.Add(sourceNormal);
			colors.Add(sourceColor);
			tangents.Add(sourceTangent);
			tri = vecs.Count - 1;
		}

		public void OCCQDDCDCQ(int index, ref List<int> vecsInts)
		{
			for (int i = 0; i < vecsInts.Count; i++)
			{
				if (index == vecsInts[i])
				{
					return;
				}
			}
			vecsInts.Add(index);
		}

		public void InEdgePairArray(int index1, int index2, ref List<CRedge> vecsInts)
		{
			for (int i = 0; i < vecsInts.Count; i++)
			{
				if ((index1 == vecsInts[i].v1 && index2 == vecsInts[i].v2) || (index1 == vecsInts[i].v2 && index2 == vecsInts[i].v1))
				{
					return;
				}
			}
			vecsInts.Add(new CRedge(index1, index2));
		}

		public void OQQOODODDO(float adjustZ)
		{
			for (int i = 0; i < zValues.Count; i++)
			{
				zValues[i] -= adjustZ;
				for (int j = 0; j < zValueVecIndexes[i].index.Count; j++)
				{
					Vector3 value = vecs[zValueVecIndexes[i].index[j]];
					value.z -= adjustZ;
					vecs[zValueVecIndexes[i].index[j]] = value;
				}
			}
		}

		public void ODOCOOOCDD(ref List<List<int>> groups, List<int> triInts, List<int> edgeInts)
		{
			List<CRedge> list = new List<CRedge>();
			for (int i = 0; i < edgeInts.Count; i++)
			{
				for (int j = 0; j < triInts.Count; j += 3)
				{
					if (triInts[j] == edgeInts[i])
					{
						if (OCCQDDCDCQ(triInts[j + 1], edgeInts))
						{
							if (!OQDDOOCOOO(list, edgeInts[i], triInts[j + 1]))
							{
								list.Add(new CRedge(edgeInts[i], triInts[j + 1]));
							}
						}
						else if (OCCQDDCDCQ(triInts[j + 2], edgeInts) && !OQDDOOCOOO(list, edgeInts[i], triInts[j + 2]))
						{
							list.Add(new CRedge(edgeInts[i], triInts[j + 2]));
						}
					}
					else if (triInts[j + 1] == edgeInts[i])
					{
						if (OCCQDDCDCQ(triInts[j], edgeInts))
						{
							if (!OQDDOOCOOO(list, edgeInts[i], triInts[j]))
							{
								list.Add(new CRedge(edgeInts[i], triInts[j]));
							}
						}
						else if (OCCQDDCDCQ(triInts[j + 2], edgeInts) && !OQDDOOCOOO(list, edgeInts[i], triInts[j + 2]))
						{
							list.Add(new CRedge(edgeInts[i], triInts[j + 2]));
						}
					}
					else
					{
						if (triInts[j + 2] != edgeInts[i])
						{
							continue;
						}
						if (OCCQDDCDCQ(triInts[j + 1], edgeInts))
						{
							if (!OQDDOOCOOO(list, edgeInts[i], triInts[j + 1]))
							{
								list.Add(new CRedge(edgeInts[i], triInts[j + 1]));
							}
						}
						else if (OCCQDDCDCQ(triInts[j], edgeInts) && !OQDDOOCOOO(list, edgeInts[i], triInts[j]))
						{
							list.Add(new CRedge(edgeInts[i], triInts[j]));
						}
					}
				}
			}
			int curInt = -1;
			int num = -1;
			bool flag = false;
			while (list.Count > 0)
			{
				if (curInt == -1)
				{
					ODDCCODODO(list, ref curInt);
					groups.Add(new List<int>());
					num++;
					groups[num].Add(curInt);
				}
				flag = false;
				for (int k = 0; k < list.Count; k++)
				{
					if (list[k].v1 == curInt)
					{
						groups[num].Add(list[k].v2);
						curInt = list[k].v2;
						list.RemoveAt(k);
						flag = true;
						break;
					}
					if (list[k].v2 == curInt)
					{
						groups[num].Add(list[k].v1);
						curInt = list[k].v1;
						list.RemoveAt(k);
						flag = true;
						break;
					}
				}
				if (!flag && list.Count > 0)
				{
					curInt = -1;
				}
			}
		}

		public void ODDCCODODO(List<CRedge> edges, ref int curInt)
		{
			if (edges.Count > 1)
			{
				for (int i = 0; i < edges.Count; i++)
				{
					curInt = edges[i].v1;
					if (!OQODODQCOD(edges, i + 1, curInt))
					{
						break;
					}
					curInt = edges[i].v2;
					if (!OQODODQCOD(edges, i + 1, curInt))
					{
						break;
					}
				}
			}
			else
			{
				curInt = edges[0].v1;
			}
		}

		public bool OQODODQCOD(List<CRedge> edges, int index, int curInt)
		{
			for (int i = index; i < edges.Count; i++)
			{
				if (edges[i].v1 == curInt)
				{
					return true;
				}
				if (edges[i].v2 == curInt)
				{
					return true;
				}
			}
			return false;
		}

		public bool OCCQDDCDCQ(int index, List<int> edgeInts)
		{
			for (int i = 0; i < edgeInts.Count; i++)
			{
				if (index == edgeInts[i])
				{
					return true;
				}
			}
			return false;
		}

		public bool OQDDOOCOOO(List<CRedge> edges, int index1, int index2)
		{
			for (int i = 0; i < edges.Count; i++)
			{
				if ((edges[i].v1 == index1 && edges[i].v2 == index2) || (edges[i].v2 == index1 && edges[i].v1 == index2))
				{
					return true;
				}
			}
			return false;
		}

		public void MatchEdgePairs(List<CRedge> startEdgePairs, List<CRedge> endEdgePairs, ref List<int> startInts, ref List<int> endInts, ref List<int> startIntsNC, ref List<int> endIntsNC, List<Vector3> startVecs, List<Vector3> endVecs, List<Vector3> startNormals, List<Vector3> normals, ref int OCQOOQODCQInt, ref int OQQCCQDCOOInt)
		{
			for (int i = 0; i < startEdgePairs.Count; i++)
			{
				for (int j = 0; j < endEdgePairs.Count; j++)
				{
					Vector3 b = endVecs[endEdgePairs[j].v1];
					Vector3 b2 = endVecs[endEdgePairs[j].v2];
					b.z = (b2.z = startVecs[startEdgePairs[i].v1].z);
					float num = Vector3.Distance(startVecs[startEdgePairs[i].v1], b);
					float num2 = Vector3.Distance(startVecs[startEdgePairs[i].v2], b2);
					if (num < offset2 && num2 < offset2)
					{
						if (!OCCQDDCDCQ(startEdgePairs[i].v1, startInts))
						{
							startInts.Add(startEdgePairs[i].v1);
							endInts.Add(endEdgePairs[j].v1);
						}
						if (!OCCQDDCDCQ(startEdgePairs[i].v2, startInts))
						{
							startInts.Add(startEdgePairs[i].v2);
							endInts.Add(endEdgePairs[j].v2);
						}
						startEdgePairs.RemoveAt(i);
						endEdgePairs.RemoveAt(j);
						i--;
						break;
					}
					num = Vector3.Distance(startVecs[startEdgePairs[i].v1], b2);
					num2 = Vector3.Distance(startVecs[startEdgePairs[i].v2], b);
					if (num < offset2 && num2 < offset2)
					{
						if (!OCCQDDCDCQ(startEdgePairs[i].v1, startInts))
						{
							startInts.Add(startEdgePairs[i].v1);
							endInts.Add(endEdgePairs[j].v2);
						}
						if (!OCCQDDCDCQ(startEdgePairs[i].v2, startInts))
						{
							startInts.Add(startEdgePairs[i].v2);
							endInts.Add(endEdgePairs[j].v1);
						}
						startEdgePairs.RemoveAt(i);
						endEdgePairs.RemoveAt(j);
						i--;
						break;
					}
				}
			}
			if (startEdgePairs.Count > 0)
			{
				for (int k = 0; k < startEdgePairs.Count; k++)
				{
					if (!OCCQDDCDCQ(startEdgePairs[k].v1, startInts) && !OCCQDDCDCQ(startEdgePairs[k].v1, startIntsNC))
					{
						startIntsNC.Add(startEdgePairs[k].v1);
					}
					if (!OCCQDDCDCQ(startEdgePairs[k].v2, startInts) && !OCCQDDCDCQ(startEdgePairs[k].v2, startIntsNC))
					{
						startIntsNC.Add(startEdgePairs[k].v2);
					}
				}
			}
			if (endEdgePairs.Count > 0)
			{
				for (int l = 0; l < endEdgePairs.Count; l++)
				{
					if (!OCCQDDCDCQ(endEdgePairs[l].v1, endInts) && !OCCQDDCDCQ(endEdgePairs[l].v1, endIntsNC))
					{
						endIntsNC.Add(endEdgePairs[l].v1);
					}
					if (!OCCQDDCDCQ(endEdgePairs[l].v2, endInts) && !OCCQDDCDCQ(endEdgePairs[l].v2, endIntsNC))
					{
						endIntsNC.Add(endEdgePairs[l].v2);
					}
				}
			}
			if ((startEdgePairs.Count <= 0 && endEdgePairs.Count <= 0) || startInts.Count <= 0)
			{
				return;
			}
			float num3 = 10000f;
			float num4 = -10000f;
			for (int m = 0; m < startInts.Count; m++)
			{
				if (startVecs[startInts[m]].x < num3)
				{
					num3 = startVecs[startInts[m]].x;
					OCQOOQODCQInt = m;
				}
				if (startVecs[startInts[m]].x > num4)
				{
					num4 = startVecs[startInts[m]].x;
					OCQOOQODCQInt = m;
				}
			}
		}

		public void ODQDDCDQCC(List<List<int>> startGroups, List<List<int>> endGroups, ref List<int> startInts, ref List<int> endInts, List<Vector3> startVecs, List<Vector3> endVecs)
		{
			startInts.Clear();
			endInts.Clear();
			bool flag = true;
			for (int i = 0; i < startGroups.Count; i++)
			{
				bool flag2 = false;
				for (int j = 0; j < endGroups.Count; j++)
				{
					if (startGroups[i].Count == endGroups[j].Count)
					{
						if (Mathf.Abs(startVecs[startGroups[i][0]].x - endVecs[endGroups[j][0]].x) < offset2 && Mathf.Abs(startVecs[startGroups[i][0]].y - endVecs[endGroups[j][0]].y) < offset2 && Mathf.Abs(startVecs[startGroups[i][startGroups[i].Count - 1]].x - endVecs[endGroups[j][endGroups[j].Count - 1]].x) < offset2 && Mathf.Abs(startVecs[startGroups[i][startGroups[i].Count - 1]].y - endVecs[endGroups[j][endGroups[j].Count - 1]].y) < offset2)
						{
							flag2 = true;
							startInts.AddRange(startGroups[i]);
							endInts.AddRange(endGroups[j]);
							break;
						}
						if (Mathf.Abs(startVecs[startGroups[i][0]].x - endVecs[endGroups[j][endGroups[j].Count - 1]].x) < offset2 && Mathf.Abs(startVecs[startGroups[i][0]].y - endVecs[endGroups[j][endGroups[j].Count - 1]].y) < offset2 && Mathf.Abs(startVecs[startGroups[i][startGroups[i].Count - 1]].x - endVecs[endGroups[j][0]].x) < offset2 && Mathf.Abs(startVecs[startGroups[i][startGroups[i].Count - 1]].y - endVecs[endGroups[j][0]].y) < offset2)
						{
							flag2 = true;
							startInts.AddRange(startGroups[i]);
							endGroups[j].Reverse();
							endInts.AddRange(endGroups[j]);
							break;
						}
					}
				}
				if (!flag2)
				{
					flag = false;
				}
			}
			if (flag)
			{
				return;
			}
			startInts.Clear();
			endInts.Clear();
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			for (int k = 0; k < startGroups.Count; k++)
			{
				list.AddRange(startGroups[k]);
			}
			for (int l = 0; l < endGroups.Count; l++)
			{
				list2.AddRange(endGroups[l]);
			}
			for (int m = 0; m < list.Count; m++)
			{
				for (int n = m + 1; n < list.Count; n++)
				{
					if (list[m] == list[n])
					{
						list.RemoveAt(n);
						n--;
					}
				}
			}
			for (int num = 0; num < list2.Count; num++)
			{
				for (int num2 = num + 1; num2 < list2.Count; num2++)
				{
					if (list2[num] == list2[num2])
					{
						list2.RemoveAt(num2);
						num2--;
					}
				}
			}
			for (int num3 = 0; num3 < list.Count; num3++)
			{
				for (int num4 = 0; num4 < list2.Count; num4++)
				{
					if (Mathf.Abs(startVecs[list[num3]].x - endVecs[list2[num4]].x) < offset2 && Mathf.Abs(startVecs[list[num3]].y - endVecs[list2[num4]].y) < offset2)
					{
						startInts.Add(list[num3]);
						endInts.Add(list2[num4]);
						list2.RemoveAt(num4);
						break;
					}
				}
			}
		}

		public static List<Color> OOCCQCDQQQ(GameObject go, List<Vector3> _vecs, List<Color> colors, float forward)
		{
			Mesh mesh = go.GetComponent<MeshFilter>().sharedMesh;
			GameObject gameObject = UnityEngine.Object.Instantiate(go);
			if ((bool)gameObject.GetComponent<MeshFilter>())
			{
				Mesh sharedMesh = gameObject.GetComponent<MeshFilter>().sharedMesh;
				if (mesh == sharedMesh)
				{
					mesh = sharedMesh;
				}
			}
			foreach (Transform item in gameObject.transform)
			{
				if ((bool)item.GetComponent<MeshFilter>())
				{
					Mesh sharedMesh2 = item.GetComponent<MeshFilter>().sharedMesh;
					if (mesh == sharedMesh2)
					{
						mesh = sharedMesh2;
						Debug.Log("Terrain Tunnel Mesh Found");
						break;
					}
				}
			}
			Vector3[] vertices = mesh.vertices;
			for (int i = 0; i < vertices.Length; i++)
			{
				vertices[i] = gameObject.transform.TransformPoint(vertices[i]);
			}
			int[] array = mesh.triangles;
			List<int> edgeGroupsInts = new List<int>();
			List<int> list = OQQOCDQCQDExt.OCCDQCCQDC(mesh.vertices, mesh.triangles, 1, ref edgeGroupsInts, debugGroupCount: true);
			Bounds bounds = mesh.bounds;
			bounds.min *= go.transform.localScale.x;
			bounds.max *= go.transform.localScale.x;
			List<Vector3> list2 = new List<Vector3>();
			List<Vector3> list3 = new List<Vector3>();
			bool flag = false;
			for (int j = 0; j < list.Count; j++)
			{
				list2.Add(vertices[list[j]]);
				if ((double)vertices[list[j]].x - 0.1 < (double)bounds.min.x)
				{
					flag = true;
				}
				if (!flag)
				{
					list2.Add(vertices[list[j]]);
				}
				else
				{
					list3.Add(vertices[list[j]]);
				}
			}
			list2.InsertRange(0, list3);
			MeshCollider meshCollider = gameObject.GetComponent<MeshCollider>();
			if (meshCollider == null)
			{
				meshCollider = gameObject.AddComponent<MeshCollider>();
				meshCollider.sharedMesh = mesh;
			}
			Vector3 vector = new Vector3(0f, bounds.min.y + 0.1f, bounds.min.z - 50f * forward) + go.transform.position;
			Ray ray = new Ray
			{
				origin = vector,
				direction = go.transform.forward * forward
			};
			float num = 0f;
			int num2 = -1;
			int num3 = -1;
			int num4 = 0;
			RaycastHit hitInfo;
			while (num > bounds.min.x)
			{
				if (meshCollider.Raycast(ray, out hitInfo, 100f))
				{
					int triangleIndex = hitInfo.triangleIndex;
					Vector3 vector2 = vertices[array[triangleIndex * 3]];
					Vector3 vector3 = vertices[array[triangleIndex * 3 + 1]];
					Vector3 vector4 = vertices[array[triangleIndex * 3 + 2]];
					bool flag2 = false;
					bool flag3 = false;
					bool flag4 = false;
					int num5 = 0;
					if (list2.Contains(vector2) && (double)vector2.y - 0.1 < (double)bounds.min.y)
					{
						flag2 = true;
						num5++;
					}
					if (list2.Contains(vector3) && (double)vector3.y - 0.1 < (double)bounds.min.y)
					{
						flag3 = true;
						num5++;
					}
					if (list2.Contains(vector4) && (double)vector4.y - 0.1 < (double)bounds.min.y)
					{
						flag4 = true;
						num5++;
					}
					if (num5 == 1)
					{
						if (flag2)
						{
							num2 = GetIndex(list2, vector2);
						}
						if (flag3)
						{
							num2 = GetIndex(list2, vector3);
						}
						if (flag4)
						{
							num2 = GetIndex(list2, vector4);
						}
					}
					else if (flag2 && flag3)
					{
						num2 = ((!(vector2.x > vector3.x)) ? GetIndex(list2, vector3) : GetIndex(list2, vector2));
					}
					else if (flag2 && flag4)
					{
						num2 = ((!(vector2.x > vector4.x)) ? GetIndex(list2, vector4) : GetIndex(list2, vector2));
					}
					else if (flag3 && flag4)
					{
						num2 = ((!(vector3.x > vector4.x)) ? GetIndex(list2, vector4) : GetIndex(list2, vector3));
					}
					break;
				}
				vector.x -= 0.25f;
				ray.origin = vector;
				num4++;
				if (num4 > 1000)
				{
					Vector3 vector5 = vector;
					Debug.Log("EasyRoads3Dv3 warning: Could not set terrain vertex colors " + vector5.ToString());
					return colors;
				}
			}
			vector = (ray.origin = new Vector3(0f, bounds.min.y + 0.1f, bounds.min.z - 50f * forward) + go.transform.position);
			num4 = 0;
			while (num < bounds.max.x)
			{
				if (meshCollider.Raycast(ray, out hitInfo, 100f))
				{
					int triangleIndex2 = hitInfo.triangleIndex;
					Vector3 vector7 = vertices[array[triangleIndex2 * 3]];
					Vector3 vector8 = vertices[array[triangleIndex2 * 3 + 1]];
					Vector3 vector9 = vertices[array[triangleIndex2 * 3 + 2]];
					bool flag5 = false;
					bool flag6 = false;
					bool flag7 = false;
					int num6 = 0;
					if (list2.Contains(vector7) && (double)vector7.y - 0.1 < (double)bounds.min.y)
					{
						flag5 = true;
						num6++;
					}
					if (list2.Contains(vector8) && (double)vector8.y - 0.1 < (double)bounds.min.y)
					{
						flag6 = true;
						num6++;
					}
					if (list2.Contains(vector9) && (double)vector9.y - 0.1 < (double)bounds.min.y)
					{
						flag7 = true;
						num6++;
					}
					if (num6 == 1)
					{
						if (flag5)
						{
							num3 = GetIndex(list2, vector7);
						}
						if (flag6)
						{
							num3 = GetIndex(list2, vector8);
						}
						if (flag7)
						{
							num3 = GetIndex(list2, vector9);
						}
					}
					else if (flag5 && flag6)
					{
						num3 = ((!(vector7.x < vector8.x)) ? GetIndex(list2, vector8) : GetIndex(list2, vector7));
					}
					else if (flag5 && flag7)
					{
						num3 = ((!(vector7.x < vector9.x)) ? GetIndex(list2, vector9) : GetIndex(list2, vector7));
					}
					else if (flag6 && flag7)
					{
						num3 = ((!(vector8.x < vector9.x)) ? GetIndex(list2, vector9) : GetIndex(list2, vector8));
					}
					break;
				}
				vector.x += 0.25f;
				ray.origin = vector;
				num4++;
				if (num4 > 1000)
				{
					Vector3 vector5 = vector;
					Debug.Log("EasyRoads3Dv3 warning: Could not set terrain vertex colors " + vector5.ToString());
					return colors;
				}
			}
			if (num3 == -1 || num2 == -1)
			{
				Debug.Log("EasyRoads3Dv3 warning: Could not set terrain vertex colors, start and end indexes are unknown");
				return colors;
			}
			bool flag8 = false;
			if (num3 > num2)
			{
				int num7 = num2;
				num2 = num3;
				num3 = num7;
				flag8 = true;
			}
			List<int> list4 = new List<int>();
			List<Vector3> list5 = new List<Vector3>();
			float y = list2[num3].y;
			for (int k = num3; k <= num2; k++)
			{
				list5.Add(list2[k]);
				if (y < list2[k].y)
				{
					y = list2[k].y;
				}
			}
			if (flag8)
			{
				list5.Reverse();
			}
			float num8 = bounds.max.x - list5[0].x;
			float num9 = bounds.max.y - y;
			float num10 = 1f;
			Color black = Color.black;
			float dist = 0f;
			for (int l = 0; l < vertices.Length; l++)
			{
				black = Color.black;
				if (list5.Contains(vertices[l]))
				{
					black = Color.black;
				}
				else
				{
					int num11 = OQCDCOQODO(list5, vertices[l], ref dist);
					if (vertices[l].y < y)
					{
						if (dist < num10)
						{
							black.g = (black.r = 0f);
						}
						else
						{
							black.g = (black.r = Mathf.SmoothStep(0f, 1f, (dist - num10) / (num8 - num10)));
						}
					}
					else if (num8 > num9)
					{
						black.g = (black.r = Mathf.SmoothStep(0f, 1f, dist / num8));
					}
					else
					{
						black.g = (black.r = Mathf.SmoothStep(0f, 1f, dist / num9));
					}
				}
				if (vertices[l].y - 0.1f < bounds.min.y && vertices[l] != vertices[num3] && vertices[l] != vertices[num2])
				{
					black.b = 1f;
				}
				colors[l] = black;
			}
			mesh.colors = colors.ToArray();
			UnityEngine.Object.DestroyImmediate(gameObject);
			return colors;
		}

		public static int GetIndex(List<Vector3> vecs, Vector3 v)
		{
			for (int i = 0; i < vecs.Count; i++)
			{
				if (vecs[i] == v)
				{
					return i;
				}
			}
			return -1;
		}

		public static int OQCDCOQODO(List<Vector3> vecs, Vector3 v, ref float dist)
		{
			int result = 0;
			dist = 10000f;
			for (int i = 0; i < vecs.Count; i++)
			{
				float num = Vector3.Distance(v, vecs[i]);
				if (num < dist)
				{
					dist = num;
					result = i;
				}
			}
			return result;
		}

		public void OCOCDCDDOD(ERModularRoad roadScr, GameObject go, SideObject so, ERModularBase scr, bool mirrored, int sectionListIndex, List<int> sectionIndexes, int autoSectionStart, List<List<Vector3>> vecPositionsArray, List<List<float>> vecDistancesArray, ERSORoadExt sodata, ERSnapSideObjects startSnapObject, ERSnapSideObjects endSnapObject)
		{
			List<ERSideObjectSection> list = new List<ERSideObjectSection>();
			int count = sectionIndexes.Count;
			int num = 0;
			if (sectionListIndex >= 0)
			{
				if (sectionListIndex == 3 && ((so.relativeTo == 1 && mirrored) || (so.relativeTo == 2 && !mirrored)))
				{
					sectionListIndex = 4;
				}
				if (sectionListIndex == 6 && ((so.relativeTo == 1 && mirrored) || (so.relativeTo == 2 && !mirrored)))
				{
					sectionListIndex = 7;
				}
				if (sectionListIndex == 5 && so.relativeTo == 2)
				{
					num = 1;
				}
			}
			if (so.meshObjects.Count == 1 && so.meshObjects[0].sVecsGroups.Count == 0 && !mirrored && sectionListIndex <= 0)
			{
				if (go.GetComponent<MeshRenderer>() == null)
				{
					go.AddComponent<MeshRenderer>();
				}
				if (go.GetComponent<MeshFilter>() == null)
				{
					go.AddComponent<MeshFilter>();
				}
				go.layer = so.layer;
				go.tag = so.tag;
				go.isStatic = so.isStatic;
				if (so.deformationObject)
				{
					go.layer = scr.sLayer;
				}
				if (so.castShadows && so.meshObjects[0].castShadows && !so.meshObjects[0].terrainMesh)
				{
					go.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.On;
				}
				else
				{
					go.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.Off;
				}
				if (so.objectType == 1 && so.meshObjects[0].materials.Count > 0)
				{
					if (so.meshObjects[0].materials[0] != so.material)
					{
						so.meshObjects[0].materials[0] = so.material;
					}
					else if (so.objectType == 1 && so.meshObjects[0].materials.Count == 0)
					{
						so.meshObjects[0].materials.Add(so.material);
					}
				}
				vssss(go, so, scr, so.meshObjects[0].sVecs, so.meshObjects[0].sUv, so.meshObjects[0].sUv2, so.meshObjects[0].sColors, so.meshObjects[0].sNormals, so.meshObjects[0].sTangents, so.meshObjects[0].sTriangles, so.meshObjects[0].normalArray1, so.meshObjects[0].normalArray2, so.meshObjects[0].materials, so.meshObjects[0].sTerrainNormals);
				if (startSnapObject != null && go.GetComponent<MeshFilter>() != null)
				{
					startSnapObject.ERSetMesh(sodata, go.GetComponent<MeshFilter>().sharedMesh, roadScr);
				}
				if (endSnapObject != null && go.GetComponent<MeshFilter>() != null)
				{
					endSnapObject.ERSetMesh(sodata, go.GetComponent<MeshFilter>().sharedMesh, roadScr);
				}
			}
			else
			{
				List<Material> list2 = new List<Material>();
				List<Mesh> list3 = new List<Mesh>();
				List<GameObject> list4 = new List<GameObject>();
				for (int i = 0; i < so.meshObjects.Count; i++)
				{
					if (i > 0 && so.subMesh)
					{
						if (so.meshObjects[i].materials.Count > 0)
						{
							list2.Add(so.meshObjects[i].materials[0]);
						}
						else
						{
							list2.Add(null);
						}
					}
					GameObject gameObject;
					for (int j = 0; j < so.meshObjects[i].sVecsGroups.Count; j++)
					{
						if (i > 0 && so.subMesh)
						{
							list3[j].subMeshCount++;
							list3[j].SetTriangles(so.meshObjects[i].sTrianglesGroups[j], i);
							list4[j].GetComponent<MeshRenderer>().sharedMaterials = list2.ToArray();
							continue;
						}
						gameObject = ((so.meshObjects.Count == 1) ? new GameObject(so.name + " Batch " + (j + 1)) : ((so.meshObjects[i].sVecsGroups.Count <= 0) ? new GameObject(so.name + " Mesh " + (i + 1)) : new GameObject(so.name + " Mesh " + (i + 1) + " Batch " + (j + 1))));
						gameObject.transform.parent = go.transform;
						gameObject.AddComponent<MeshRenderer>();
						gameObject.AddComponent<MeshFilter>();
						gameObject.transform.parent = go.transform;
						gameObject.layer = so.layer;
						if (so.deformationObject)
						{
							gameObject.layer = scr.sLayer;
						}
						gameObject.tag = so.tag;
						gameObject.isStatic = so.isStatic;
						if (so.castShadows && so.meshObjects[i].castShadows && !so.meshObjects[i].terrainMesh)
						{
							gameObject.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.On;
						}
						else
						{
							gameObject.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.Off;
						}
						vssss(gameObject, so, scr, so.meshObjects[i].sVecsGroups[j], so.meshObjects[i].sUvGroups[j], so.meshObjects[i].sUv2Groups[j], so.meshObjects[i].sColorsGroups[j], so.meshObjects[i].sNormalsGroups[j], so.meshObjects[i].sTangentsGroups[j], so.meshObjects[i].sTrianglesGroups[j], so.meshObjects[i].normalArray1Group[j], so.meshObjects[i].normalArray2Group[j], so.meshObjects[i].materials, so.meshObjects[i].sTerrainNormals);
						if (so.subMesh)
						{
							if (gameObject.GetComponent<MeshFilter>() != null)
							{
								list3.Add(gameObject.GetComponent<MeshFilter>().sharedMesh);
							}
							else
							{
								Debug.Log("EasyRoads3D Side Object submesh, missing MeshFilter: " + so.name + ", road object: " + roadScr.gameObject.name);
							}
							list4.Add(gameObject);
						}
						if (j >= autoSectionStart && sectionListIndex >= 0 && j - autoSectionStart < count)
						{
							ERSideObjectSection eRSideObjectSection = gameObject.AddComponent<ERSideObjectSection>();
							list.Add(eRSideObjectSection);
							eRSideObjectSection.road = roadScr;
							eRSideObjectSection.sectionIndex = sectionIndexes[j - autoSectionStart];
							eRSideObjectSection.mirrored = mirrored;
							if ((num == 0 && !mirrored) || (num == 1 && mirrored))
							{
								eRSideObjectSection.leftright = 0;
							}
							else
							{
								eRSideObjectSection.leftright = 1;
							}
							eRSideObjectSection.sectionListIndex = sectionListIndex;
							eRSideObjectSection.soId = so.id;
							eRSideObjectSection.so = so;
							eRSideObjectSection.points = vecPositionsArray[j];
							eRSideObjectSection.distances = vecDistancesArray[j];
							if (!OQQQOQODOO(roadScr, sectionListIndex, sectionIndexes[j - autoSectionStart], so, mirrored) && gameObject != null)
							{
								gameObject.GetComponent<MeshRenderer>().sharedMaterial = roadScr.baseScript.soSectionMaterial;
							}
						}
						if (gameObject.GetComponent<MeshFilter>() != null)
						{
							gameObject.GetComponent<MeshFilter>().sharedMesh.name = gameObject.name;
						}
						if (i == 0 && j == 0 && startSnapObject != null && gameObject.GetComponent<MeshFilter>() != null)
						{
							startSnapObject.ERSetMesh(sodata, gameObject.GetComponent<MeshFilter>().sharedMesh, roadScr);
						}
					}
					if (i > 0 && so.subMesh)
					{
						list3[list3.Count - 1].subMeshCount++;
						list3[list3.Count - 1].SetTriangles(so.meshObjects[i].sTriangles, i);
						list4[list4.Count - 1].GetComponent<MeshRenderer>().sharedMaterials = list2.ToArray();
						continue;
					}
					gameObject = ((so.meshObjects.Count == 1) ? new GameObject(so.name + " Batch " + (so.meshObjects[i].sVecsGroups.Count + 1)) : ((so.meshObjects[i].sVecsGroups.Count <= 0) ? new GameObject(so.name + " Mesh " + (i + 1)) : new GameObject(so.name + " Mesh " + (i + 1) + " Batch " + (so.meshObjects[i].sVecsGroups.Count + 1))));
					gameObject.transform.parent = go.transform;
					gameObject.AddComponent<MeshRenderer>();
					gameObject.AddComponent<MeshFilter>();
					gameObject.transform.parent = go.transform;
					gameObject.layer = so.layer;
					if (so.deformationObject)
					{
						gameObject.layer = scr.sLayer;
					}
					gameObject.tag = so.tag;
					gameObject.isStatic = so.isStatic;
					if (so.castShadows && so.meshObjects[i].castShadows && !so.meshObjects[i].terrainMesh)
					{
						gameObject.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.On;
					}
					else
					{
						gameObject.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.Off;
					}
					vssss(gameObject, so, scr, so.meshObjects[i].sVecs, so.meshObjects[i].sUv, so.meshObjects[i].sUv2, so.meshObjects[i].sColors, so.meshObjects[i].sNormals, so.meshObjects[i].sTangents, so.meshObjects[i].sTriangles, so.meshObjects[i].normalArray1, so.meshObjects[i].normalArray2, so.meshObjects[i].materials, so.meshObjects[i].sTerrainNormals);
					if (gameObject.GetComponent<MeshFilter>() != null)
					{
						gameObject.GetComponent<MeshFilter>().sharedMesh.name = gameObject.name;
					}
					if (endSnapObject != null && gameObject.GetComponent<MeshFilter>() != null)
					{
						endSnapObject.ERSetMesh(sodata, gameObject.GetComponent<MeshFilter>().sharedMesh, roadScr);
					}
					if (so.subMesh && gameObject.GetComponent<MeshFilter>() != null)
					{
						list3.Add(gameObject.GetComponent<MeshFilter>().sharedMesh);
						if (so.meshObjects[i].materials.Count > 0)
						{
							list2.Add(so.meshObjects[i].materials[0]);
						}
						else
						{
							list2.Add(null);
						}
						list4.Add(gameObject);
					}
					if (count > 0 && sectionListIndex >= 0)
					{
						ERSideObjectSection eRSideObjectSection2 = gameObject.AddComponent<ERSideObjectSection>();
						list.Add(eRSideObjectSection2);
						eRSideObjectSection2.road = roadScr;
						eRSideObjectSection2.sectionIndex = sectionIndexes[count - 1];
						eRSideObjectSection2.mirrored = mirrored;
						if ((num == 0 && !mirrored) || (num == 1 && mirrored))
						{
							eRSideObjectSection2.leftright = 0;
						}
						else
						{
							eRSideObjectSection2.leftright = 1;
						}
						eRSideObjectSection2.sectionListIndex = sectionListIndex;
						eRSideObjectSection2.soId = so.id;
						eRSideObjectSection2.so = so;
						if (vecPositionsArray.Count > count - 1)
						{
							eRSideObjectSection2.points = vecPositionsArray[count - 1];
						}
						if (vecDistancesArray.Count > count - 1)
						{
							eRSideObjectSection2.distances = vecDistancesArray[count - 1];
						}
						if (gameObject != null && !OQQQOQODOO(roadScr, sectionListIndex, sectionIndexes[count - 1], so, mirrored))
						{
							gameObject.GetComponent<MeshRenderer>().sharedMaterial = roadScr.baseScript.soSectionMaterial;
						}
					}
					if (i == 0 && startSnapObject != null && gameObject.GetComponent<MeshFilter>() != null)
					{
						startSnapObject.ERSetMesh(sodata, gameObject.GetComponent<MeshFilter>().sharedMesh, roadScr);
					}
					if (i == 0 && endSnapObject != null && gameObject.GetComponent<MeshFilter>() != null)
					{
						endSnapObject.ERSetMesh(sodata, gameObject.GetComponent<MeshFilter>().sharedMesh, roadScr);
					}
				}
				if (!mirrored)
				{
					if (go.GetComponent<MeshRenderer>() != null)
					{
						UnityEngine.Object.DestroyImmediate(go.GetComponent<MeshRenderer>());
					}
					if (go.GetComponent<MeshFilter>() != null)
					{
						UnityEngine.Object.DestroyImmediate(go.GetComponent<MeshFilter>());
					}
					if (go.GetComponent<MeshCollider>() != null)
					{
						UnityEngine.Object.DestroyImmediate(go.GetComponent<MeshCollider>());
					}
				}
			}
			Clear();
			if ((bool)go.GetComponent<ERSideObjectInstance>())
			{
				ERSideObjectInstance component = go.GetComponent<ERSideObjectInstance>();
				if (ERRoadNetwork.onSideObjectUpdate != null)
				{
					ERRoadNetwork.OnSideObjectUpdated(component);
				}
				if (!(Math.Abs(so.id - 1596266182.70205) < 0.0001))
				{
				}
			}
			if (Math.Abs(so.id - 1596266182.70205) < 0.0001 && !so.bridgeObject)
			{
			}
		}

		public static bool OQQQOQODOO(ERModularRoad rd, int listIndex, int listItemIndex, SideObject so, bool mirrored)
		{
			if (listIndex == 1 && rd.soSectionList1.Count > listItemIndex)
			{
				return rd.soSectionList1[listItemIndex].active;
			}
			if (listIndex == 2 && rd.soSectionList2.Count > listItemIndex)
			{
				return rd.soSectionList2[listItemIndex].active;
			}
			if (listIndex == 3 && rd.soSectionList3.Count > listItemIndex)
			{
				return rd.soSectionList3[listItemIndex].active;
			}
			if (listIndex == 4 && rd.soSectionList4.Count > listItemIndex)
			{
				return rd.soSectionList4[listItemIndex].active;
			}
			if (listIndex == 5 && rd.soSectionList5.Count > listItemIndex)
			{
				return rd.soSectionList5[listItemIndex].active;
			}
			if (listIndex == 6 && rd.soSectionList6.Count > listItemIndex)
			{
				return rd.soSectionList6[listItemIndex].active;
			}
			if (listIndex == 7 && rd.soSectionList7.Count > listItemIndex)
			{
				return rd.soSectionList7[listItemIndex].active;
			}
			return true;
		}

		private void vssss(GameObject tssss, SideObject ussss, ERModularBase vssss, List<Vector3> wssss, List<Vector2> xssss, List<Vector2> yssss, List<Color> Assss, List<Vector3> _0ssss, List<Vector4> _1ssss, List<int> _2ssss, List<int> _3ssss, List<int> _4ssss, List<Material> ttsss, List<Vector3> utsss)
		{
			if (tssss.GetComponent<MeshFilter>() == null)
			{
				tssss.AddComponent<MeshFilter>();
			}
			Mesh mesh = tssss.GetComponent<MeshFilter>().sharedMesh;
			if (mesh == null)
			{
				mesh = new Mesh();
				mesh.MarkDynamic();
				tssss.GetComponent<MeshFilter>().sharedMesh = mesh;
			}
			if (ttsss.Count > 0)
			{
				tssss.GetComponent<MeshRenderer>().sharedMaterial = ttsss[0];
			}
			mesh.Clear();
			mesh.vertices = wssss.ToArray();
			mesh.uv = xssss.ToArray();
			mesh.uv4 = yssss.ToArray();
			mesh.colors = Assss.ToArray();
			if (ussss.objectType == 1 || _0ssss.Count != wssss.Count)
			{
				mesh.normals = new Vector3[mesh.vertices.Length];
			}
			else if (ussss.objectType == 2)
			{
				mesh.normals = _0ssss.ToArray();
			}
			mesh.tangents = _1ssss.ToArray();
			mesh.triangles = _2ssss.ToArray();
			List<Vector3> list = new List<Vector3>();
			if (ussss.recalculateNormals && ussss.tunnelObject)
			{
				list = new List<Vector3>(mesh.normals);
			}
			if (ussss.objectType == 1 || _0ssss.Count != wssss.Count || ussss.recalculateNormals)
			{
				mesh.RecalculateNormals();
			}
			if (ussss.recalculateNormals && ussss.tunnelObject)
			{
				Color[] array = mesh.colors;
				Vector3[] array2 = mesh.normals;
				for (int i = 0; i < list.Count; i++)
				{
					if ((double)array[i].g > 0.6)
					{
						array2[i] = list[i];
					}
				}
				mesh.normals = array2;
			}
			mesh.RecalculateBounds();
			_0ssss = new List<Vector3>(mesh.normals);
			Vector3 zero = Vector3.zero;
			int[] array3 = _3ssss.ToArray();
			int[] array4 = _4ssss.ToArray();
			for (int j = 0; j < array3.Length; j++)
			{
				List<Vector3> list2 = _0ssss;
				int index = _3ssss[j];
				Vector3 value = (_0ssss[array3[j]] = (_0ssss[array3[j]] + _0ssss[array4[j]]) * 0.5f);
				list2[index] = value;
			}
			if (ussss.objectType == 1 && ussss.indentController && utsss.Count <= _0ssss.Count)
			{
				for (int k = 0; k < utsss.Count; k++)
				{
					if (utsss[k] != Vector3.zero)
					{
						_0ssss[k] = utsss[k];
					}
				}
			}
			if (ussss.tunnelObject && ussss.hasVertexColors && wssss.Count <= Assss.Count && wssss.Count <= _0ssss.Count)
			{
				for (int l = 0; l < wssss.Count; l++)
				{
					if (Assss[l].r != 0f)
					{
						Vector3 b = vssss.OOQDDODCDO(wssss[l]);
						_0ssss[l] = Vector3.Lerp(_0ssss[l], b, Assss[l].r);
					}
				}
			}
			if (_0ssss.Count == mesh.normals.Length)
			{
				mesh.normals = _0ssss.ToArray();
			}
			if (ussss.collider)
			{
				if ((bool)tssss.GetComponent<MeshCollider>())
				{
					tssss.GetComponent<MeshCollider>().sharedMesh = null;
				}
				else
				{
					tssss.AddComponent<MeshCollider>();
				}
				tssss.GetComponent<MeshCollider>().sharedMesh = mesh;
				tssss.GetComponent<MeshCollider>().material = ussss.physicMaterial;
			}
			mesh.RecalculateTangents();
			if (wssss.Count == 0)
			{
				if (tssss.GetComponent<MeshFilter>() != null)
				{
					UnityEngine.Object.DestroyImmediate(tssss.GetComponent<MeshFilter>());
				}
				if (tssss.GetComponent<MeshRenderer>() != null)
				{
					UnityEngine.Object.DestroyImmediate(tssss.GetComponent<MeshRenderer>());
				}
				if (tssss.GetComponent<MeshCollider>() != null)
				{
					UnityEngine.Object.DestroyImmediate(tssss.GetComponent<MeshCollider>());
				}
			}
		}

		public void TriangulateDoubleSidedShapes(ERModularRoad roadScr, GameObject go, SideObject so, ERSORoadExt soData)
		{
			GameObject gameObject = new GameObject("Bridge Bottom");
			gameObject.transform.parent = go.transform;
			gameObject.AddComponent<MeshRenderer>();
			gameObject.AddComponent<MeshFilter>();
			gameObject.transform.parent = go.transform;
			gameObject.layer = so.layer;
			gameObject.tag = so.tag;
			gameObject.isStatic = so.isStatic;
			bool flag = true;
			bool flag2 = false;
			if (so.dualSidedMaterial != null)
			{
				gameObject.GetComponent<MeshRenderer>().sharedMaterial = so.dualSidedMaterial;
				if (so.dualSidedMaterial == so.material)
				{
					if (so.material.shader.name == "ERBridge")
					{
						flag2 = true;
					}
				}
				else
				{
					flag = false;
				}
			}
			else
			{
				gameObject.GetComponent<MeshRenderer>().sharedMaterial = so.material;
			}
			List<Vector3> list = new List<Vector3>();
			List<Vector2> list2 = new List<Vector2>();
			List<int> list3 = new List<int>();
			List<Vector3> list4 = new List<Vector3>();
			List<Vector2> list5 = new List<Vector2>();
			List<int> list6 = new List<int>();
			List<Vector3> list7 = new List<Vector3>();
			float num = 0f;
			float num2 = 5f;
			float num3 = 0f;
			float num4 = so.totalDistance;
			if (so.objectType != 1)
			{
				num4 = 1f;
			}
			num3 = 1f / num4;
			float y = so.nodeList[0].y;
			if (so.nodeList[so.nodeList.Count - 1].y < y)
			{
				y = so.nodeList[so.nodeList.Count - 1].y;
			}
			Vector3 vector = Vector3.zero;
			Vector3 vector2 = Vector3.zero;
			if (soData.startSplinePointIndexes.Count > 0 && soData.startSplinePointIndexes[0] == 0 && roadScr.startPrefabScript != null)
			{
				vector = roadScr.startPrefabScript.transform.position;
				vector.y += y;
			}
			if (soData.endSplinePointIndexes.Count > 0 && soData.endSplinePointIndexes[soData.endSplinePointIndexes.Count - 1] == roadScr.soSplinePoints.Count - 1 && roadScr.endPrefabScript != null)
			{
				vector2 = roadScr.endPrefabScript.transform.position;
				vector2.y += y;
			}
			for (int i = 0; i < soData.mainTriangulateVecs.Count; i++)
			{
				for (int j = 0; j < soData.mainTriangulateVecs.Count; j++)
				{
					list7 = null;
					if (soData.startSplinePointIndexes[i] == soData.startSplinePointIndexesMirrored[j] && soData.endSplinePointIndexes[i] == soData.endSplinePointIndexesMirrored[j])
					{
						list7 = soData.mirroredTriangulateVecs[j];
						break;
					}
				}
				if (list7 != null)
				{
					int count = list4.Count;
					float num5 = 3f;
					num = num5 / num2 * so.dualSidedMaterialTiling;
					list.Clear();
					list2.Clear();
					list.AddRange(soData.mainTriangulateVecs[i]);
					list.Reverse();
					if (i == 0 && vector != Vector3.zero)
					{
						list.Add(vector);
					}
					list.AddRange(list7);
					for (int k = 0; k < list.Count; k++)
					{
						list2.Add(Vector2.zero);
					}
					if (i == soData.mainTriangulateVecs.Count - 1 && vector2 != Vector3.zero)
					{
						list.Add(vector2);
						list2.Add(Vector2.zero);
					}
					list3 = OQQOCDQCQD.Triangulate(list, list);
					int num6 = 0;
					for (int l = 0; l < list3.Count; l += 3)
					{
						num6 = list3[l];
						list3[l] = list3[l + 1];
						list3[l + 1] = num6;
						list3[l] += count;
						list3[l + 1] += count;
						list3[l + 2] += count;
					}
					list4.AddRange(list);
					list5.AddRange(list2);
					list6.AddRange(list3);
				}
			}
			Mesh mesh = new Mesh();
			mesh.vertices = list4.ToArray();
			mesh.uv = list5.ToArray();
			mesh.triangles = list6.ToArray();
			if (flag2)
			{
				Color color = new Color(1f, 1f, 1f, 0f);
				Color[] array = new Color[list4.Count];
				for (int m = 0; m < array.Length; m++)
				{
					array[m] = color;
				}
				mesh.SetColors(array);
			}
			mesh.RecalculateNormals();
			mesh.RecalculateBounds();
			mesh.RecalculateTangents();
			Vector3 center = mesh.bounds.center;
			int count2 = list4.Count;
			Vector2[] array2 = mesh.uv;
			for (int n = 0; n < count2; n++)
			{
				if (!flag)
				{
					array2[n] = new Vector2((center.x - list4[n].x) * num, (center.z - list4[n].z) * num);
				}
				else
				{
					array2[n] = new Vector2((center.x - list4[n].x) * num3 * so.uvy, (center.z - list4[n].z) * num3 * so.uvy);
				}
			}
			mesh.uv = array2;
			gameObject.GetComponent<MeshFilter>().sharedMesh = mesh;
		}

		private void wssst(ref int tssss, ref List<int> ussss, List<Vector3> vssss, float wssss)
		{
			for (int i = 0; i < vssss.Count; i++)
			{
				Vector3 a = vssss[i];
				a.z = wssss;
				if (Vector3.Distance(a, vssss[i]) < offset1)
				{
					ussss.Add(i);
				}
			}
			tssss = ussss.Count;
		}

		private void OCOCCDOOCO(ref List<int> targetIntList, List<int> sourceIntList, List<Vector3> targetVecs, List<Vector3> sourceVecs)
		{
			List<int> list = new List<int>(targetIntList);
			int num = 0;
			float num2 = 1000f;
			float num3 = 1000f;
			int num4 = -1;
			for (int i = 0; i < targetIntList.Count; i++)
			{
				Vector2 a = new Vector2(targetVecs[targetIntList[i]].x, targetVecs[targetIntList[i]].y);
				num2 = 1000f;
				num4 = -1;
				for (int j = 0; j < sourceIntList.Count; j++)
				{
					Vector2 b = new Vector2(sourceVecs[sourceIntList[j]].x, sourceVecs[sourceIntList[j]].y);
					num3 = Vector2.Distance(a, b);
					if ((double)num3 < 0.005 && num3 < num2)
					{
						num4 = j;
						break;
					}
					if (num4 != -1)
					{
						list[num4] = targetIntList[i];
						num++;
					}
				}
			}
			targetIntList = new List<int>(list);
		}

		public void Clear()
		{
			sVecs.Clear();
			sUv.Clear();
			sUv2.Clear();
			sColors.Clear();
			sNormals.Clear();
			sTangents.Clear();
			sTriangles.Clear();
			normalArray1.Clear();
			normalArray2.Clear();
			sTerrainNormals.Clear();
			dualSidedEdgeVertices.Clear();
			if (sVecsGroups != null)
			{
				sVecsGroups.Clear();
			}
			else
			{
				sVecsGroups = new List<List<Vector3>>();
			}
			if (sUvGroups != null)
			{
				sUvGroups.Clear();
			}
			else
			{
				sUvGroups = new List<List<Vector2>>();
			}
			if (sUv2Groups != null)
			{
				sUv2Groups.Clear();
			}
			else
			{
				sUv2Groups = new List<List<Vector2>>();
			}
			if (sColorsGroups != null)
			{
				sColorsGroups.Clear();
			}
			else
			{
				sColorsGroups = new List<List<Color>>();
			}
			if (sNormalsGroups != null)
			{
				sNormalsGroups.Clear();
			}
			else
			{
				sNormalsGroups = new List<List<Vector3>>();
			}
			if (sTangentsGroups != null)
			{
				sTangentsGroups.Clear();
			}
			else
			{
				sTangentsGroups = new List<List<Vector4>>();
			}
			if (sTrianglesGroups != null)
			{
				sTrianglesGroups.Clear();
			}
			else
			{
				sTrianglesGroups = new List<List<int>>();
			}
			if (normalArray1Group != null)
			{
				normalArray1Group.Clear();
			}
			else
			{
				normalArray1Group = new List<List<int>>();
			}
			if (normalArray2Group != null)
			{
				normalArray2Group.Clear();
			}
			else
			{
				normalArray2Group = new List<List<int>>();
			}
			if (sTerrainNormalsGroups != null)
			{
				sTerrainNormalsGroups.Clear();
			}
			else
			{
				sTerrainNormalsGroups = new List<List<Vector3>>();
			}
			vecCount = 0;
		}
	}
}
