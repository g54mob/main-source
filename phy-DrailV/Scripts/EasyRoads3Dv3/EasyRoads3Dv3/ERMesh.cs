using System;
using System.Collections.Generic;
using UnityEngine;

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

		public List<int> startVecsInt = new List<int>();

		public List<Vector3> startVecs = new List<Vector3>();

		public List<Vector2> startUv = new List<Vector2>();

		public List<Vector2> startUv2 = new List<Vector2>();

		public List<Color> startColors = new List<Color>();

		public List<Vector3> startNormals = new List<Vector3>();

		public List<Vector4> startTangents = new List<Vector4>();

		public List<int> startTriangles = new List<int>();

		public List<int> endVecsInt = new List<int>();

		public List<Vector3> endVecs = new List<Vector3>();

		public List<Vector2> endUv = new List<Vector2>();

		public List<Vector2> endUv2 = new List<Vector2>();

		public List<Color> endColors = new List<Color>();

		public List<Vector3> endNormals = new List<Vector3>();

		public List<Vector4> endTangents = new List<Vector4>();

		public List<int> endTriangles = new List<int>();

		public List<Material> materials = new List<Material>();

		public List<Vector3> sVecs = new List<Vector3>();

		public List<Vector2> sUv = new List<Vector2>();

		public List<Vector2> sUv2 = new List<Vector2>();

		public List<Color> sColors = new List<Color>();

		public List<Vector3> sNormals = new List<Vector3>();

		public List<Vector4> sTangents = new List<Vector4>();

		public List<int> sTriangles = new List<int>();

		public List<Vector3> sTerrainNormals = new List<Vector3>();

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

		public int ODODCOOOCDInt = 0;

		public int OOOQOODOCDInt = 0;

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

		public float minZ = 10000f;

		public float minMiddleZ = 10000f;

		public float maxZ = -10000f;

		public float maxMiddleZ = -10000f;

		public float totalZDistance = -10000f;

		public float offset1 = 0.01f;

		public float offset2 = 0.001f;

		public List<int> vertexBatches = new List<int>();

		public List<int> triangleBatches = new List<int>();

		public ERMesh(GameObject m_go, SideObject soScript, float minZ, Transform sourceTransform)
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
			float num2 = totalZDistance - num;
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
			Mesh sharedMesh = m_go.GetComponent<MeshFilter>().sharedMesh;
			if (sharedMesh.tangents.Length == 0)
			{
				OCQQDQQCQQ.OOCCQOQQQC(sharedMesh);
			}
			List<Vector3> list = new List<Vector3>();
			for (int i = 0; i < sharedMesh.vertices.Length; i++)
			{
				Vector3 item = m_go.transform.TransformPoint(sharedMesh.vertices[i]);
				item.z -= minZ;
				if (soScript.flipMesh)
				{
					item.x *= -1f;
				}
				list.Add(item);
			}
			List<Vector3> list2 = new List<Vector3>();
			for (int i = 0; i < sharedMesh.normals.Length; i++)
			{
				if (soScript.flipMesh)
				{
					list2.Add(sharedMesh.normals[i] * -1f);
				}
				else
				{
					list2.Add(sharedMesh.normals[i]);
				}
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
				for (int i = 0; i < sharedMesh.triangles.Length; i += 3)
				{
					try
					{
						ODDCQDDQQD(sharedMesh.triangles[i], list[sharedMesh.triangles[i]], ref vecsInt, ref vecs, ref uv, ref uv2, ref normals, ref colors, ref tangents, sharedMesh.uv[sharedMesh.triangles[i]], zero, list2[sharedMesh.triangles[i]], white, sharedMesh.tangents[sharedMesh.triangles[i]], ref tri);
					}
					catch
					{
					}
					if (Mathf.Abs(list[sharedMesh.triangles[i]].z - startOffset) < offset2 && (list[sharedMesh.triangles[i + 1]].z > startOffset || list[sharedMesh.triangles[i + 2]].z > startOffset))
					{
						OQDCQQQDDO(tri, ref middleStartInts);
					}
					if (Mathf.Abs(list[sharedMesh.triangles[i]].z - num2) < offset2 && (list[sharedMesh.triangles[i + 1]].z < num2 || list[sharedMesh.triangles[i + 2]].z < num2))
					{
						OQDCQQQDDO(tri, ref middleEndInts);
					}
					ODDCQDDQQD(sharedMesh.triangles[i + 1], list[sharedMesh.triangles[i + 1]], ref vecsInt, ref vecs, ref uv, ref uv2, ref normals, ref colors, ref tangents, sharedMesh.uv[sharedMesh.triangles[i + 1]], zero, list2[sharedMesh.triangles[i + 1]], white, sharedMesh.tangents[sharedMesh.triangles[i + 1]], ref tri2);
					if (Mathf.Abs(list[sharedMesh.triangles[i + 1]].z - startOffset) < offset2 && (list[sharedMesh.triangles[i]].z > startOffset || list[sharedMesh.triangles[i + 2]].z > startOffset))
					{
						OQDCQQQDDO(tri2, ref middleStartInts);
					}
					if (Mathf.Abs(list[sharedMesh.triangles[i + 1]].z - num2) < offset2 && (list[sharedMesh.triangles[i]].z < num2 || list[sharedMesh.triangles[i + 2]].z < num2))
					{
						OQDCQQQDDO(tri2, ref middleEndInts);
					}
					ODDCQDDQQD(sharedMesh.triangles[i + 2], list[sharedMesh.triangles[i + 2]], ref vecsInt, ref vecs, ref uv, ref uv2, ref normals, ref colors, ref tangents, sharedMesh.uv[sharedMesh.triangles[i + 2]], zero, list2[sharedMesh.triangles[i + 2]], white, sharedMesh.tangents[sharedMesh.triangles[i + 2]], ref tri3);
					if (Mathf.Abs(list[sharedMesh.triangles[i + 2]].z - startOffset) < offset2 && (list[sharedMesh.triangles[i + 1]].z > startOffset || list[sharedMesh.triangles[i]].z > startOffset))
					{
						OQDCQQQDDO(tri3, ref middleStartInts);
					}
					if (Mathf.Abs(list[sharedMesh.triangles[i + 2]].z - num2) < offset2 && (list[sharedMesh.triangles[i]].z < num2 || list[sharedMesh.triangles[i + 1]].z < num2))
					{
						OQDCQQQDDO(tri3, ref middleEndInts);
					}
					if (Mathf.Abs(list[sharedMesh.triangles[i]].z - startOffset) < offset2 && Mathf.Abs(list[sharedMesh.triangles[i + 1]].z - startOffset) < offset2)
					{
						InEdgePairArray(tri, tri2, ref vecsInts2);
					}
					if (Mathf.Abs(list[sharedMesh.triangles[i]].z - startOffset) < offset2 && Mathf.Abs(list[sharedMesh.triangles[i + 2]].z - startOffset) < offset2)
					{
						InEdgePairArray(tri, tri3, ref vecsInts2);
					}
					if (Mathf.Abs(list[sharedMesh.triangles[i + 1]].z - startOffset) < offset2 && Mathf.Abs(list[sharedMesh.triangles[i + 2]].z - startOffset) < offset2)
					{
						InEdgePairArray(tri2, tri3, ref vecsInts2);
					}
					if (Mathf.Abs(list[sharedMesh.triangles[i]].z - num2) < offset2 && Mathf.Abs(list[sharedMesh.triangles[i + 1]].z - num2) < offset2)
					{
						InEdgePairArray(tri, tri2, ref vecsInts3);
					}
					if (Mathf.Abs(list[sharedMesh.triangles[i]].z - num2) < offset2 && Mathf.Abs(list[sharedMesh.triangles[i + 2]].z - num2) < offset2)
					{
						InEdgePairArray(tri, tri3, ref vecsInts3);
					}
					if (Mathf.Abs(list[sharedMesh.triangles[i + 1]].z - num2) < offset2 && Mathf.Abs(list[sharedMesh.triangles[i + 2]].z - num2) < offset2)
					{
						InEdgePairArray(tri2, tri3, ref vecsInts3);
					}
				}
				vecs = new List<Vector3>(list);
				uv = new List<Vector2>(sharedMesh.uv);
				uv2 = new List<Vector2>(sharedMesh.uv2);
				normals = new List<Vector3>(list2);
				tangents = new List<Vector4>(sharedMesh.tangents);
				colors = new List<Color>(sharedMesh.colors);
				triangles = new List<int>(sharedMesh.triangles);
				soScript.middleZDistance = totalZDistance;
				if (soScript.flipMesh)
				{
					int num9 = 0;
					for (int i = 0; i < triangles.Count; i += 3)
					{
						num9 = triangles[i];
						triangles[i] = triangles[i + 1];
						triangles[i + 1] = num9;
					}
				}
			}
			else
			{
				int tri = 0;
				int tri2 = 0;
				int tri3 = 0;
				Color white = Color.white;
				Vector2 zero = Vector2.zero;
				for (int i = 0; i < sharedMesh.triangles.Length; i += 3)
				{
					bool flag = false;
					if (list[sharedMesh.triangles[i]].z < num2 || list[sharedMesh.triangles[i + 1]].z < num2 || (list[sharedMesh.triangles[i + 2]].z < num2 && list[sharedMesh.triangles[i]].z <= num2 + offset1 && list[sharedMesh.triangles[i + 1]].z <= num2 + offset1 && list[sharedMesh.triangles[i + 2]].z <= num2 + offset1))
					{
						flag = true;
					}
					if (soScript.includeEndEdgeTris && list[sharedMesh.triangles[i]].z <= num2 + offset1 && list[sharedMesh.triangles[i + 1]].z <= num2 + offset1 && list[sharedMesh.triangles[i + 2]].z <= num2 + offset1)
					{
						flag = true;
					}
					if (flag)
					{
						if (sharedMesh.colors.Length > sharedMesh.triangles[i])
						{
							white = sharedMesh.colors[sharedMesh.triangles[i]];
						}
						if (sharedMesh.uv2.Length > sharedMesh.triangles[i])
						{
							zero = sharedMesh.uv2[sharedMesh.triangles[i]];
						}
						try
						{
							ODDCQDDQQD(sharedMesh.triangles[i], list[sharedMesh.triangles[i]], ref startVecsInt, ref startVecs, ref startUv, ref startUv2, ref startNormals, ref startColors, ref startTangents, sharedMesh.uv[sharedMesh.triangles[i]], zero, list2[sharedMesh.triangles[i]], white, sharedMesh.tangents[sharedMesh.triangles[i]], ref tri);
						}
						catch
						{
						}
						if (Mathf.Abs(list[sharedMesh.triangles[i]].z - num2) < offset2 && (list[sharedMesh.triangles[i + 1]].z < num2 || list[sharedMesh.triangles[i + 2]].z < num2))
						{
							OQDCQQQDDO(tri, ref startEndInts);
						}
						if (sharedMesh.colors.Length > sharedMesh.triangles[i + 1])
						{
							white = sharedMesh.colors[sharedMesh.triangles[i + 1]];
						}
						if (sharedMesh.uv2.Length > sharedMesh.triangles[i + 1])
						{
							zero = sharedMesh.uv2[sharedMesh.triangles[i + 1]];
						}
						ODDCQDDQQD(sharedMesh.triangles[i + 1], list[sharedMesh.triangles[i + 1]], ref startVecsInt, ref startVecs, ref startUv, ref startUv2, ref startNormals, ref startColors, ref startTangents, sharedMesh.uv[sharedMesh.triangles[i + 1]], zero, list2[sharedMesh.triangles[i + 1]], white, sharedMesh.tangents[sharedMesh.triangles[i + 1]], ref tri2);
						if (Mathf.Abs(list[sharedMesh.triangles[i + 1]].z - num2) < offset2 && (list[sharedMesh.triangles[i]].z < num2 || list[sharedMesh.triangles[i + 2]].z < num2))
						{
							OQDCQQQDDO(tri2, ref startEndInts);
						}
						if (sharedMesh.colors.Length > sharedMesh.triangles[i + 2])
						{
							white = sharedMesh.colors[sharedMesh.triangles[i + 2]];
						}
						if (sharedMesh.uv2.Length > sharedMesh.triangles[i + 2])
						{
							zero = sharedMesh.uv2[sharedMesh.triangles[i + 2]];
						}
						ODDCQDDQQD(sharedMesh.triangles[i + 2], list[sharedMesh.triangles[i + 2]], ref startVecsInt, ref startVecs, ref startUv, ref startUv2, ref startNormals, ref startColors, ref startTangents, sharedMesh.uv[sharedMesh.triangles[i + 2]], zero, list2[sharedMesh.triangles[i + 2]], white, sharedMesh.tangents[sharedMesh.triangles[i + 2]], ref tri3);
						if (Mathf.Abs(list[sharedMesh.triangles[i + 2]].z - num2) < offset2 && (list[sharedMesh.triangles[i]].z < num2 || list[sharedMesh.triangles[i + 1]].z < num2))
						{
							OQDCQQQDDO(tri3, ref startEndInts);
						}
						if (Mathf.Abs(list[sharedMesh.triangles[i]].z - num2) < offset2 && Mathf.Abs(list[sharedMesh.triangles[i + 1]].z - num2) < offset2)
						{
							InEdgePairArray(tri, tri2, ref vecsInts);
						}
						if (Mathf.Abs(list[sharedMesh.triangles[i]].z - num2) < offset2 && Mathf.Abs(list[sharedMesh.triangles[i + 2]].z - num2) < offset2)
						{
							InEdgePairArray(tri, tri3, ref vecsInts);
						}
						if (Mathf.Abs(list[sharedMesh.triangles[i + 1]].z - num2) < offset2 && Mathf.Abs(list[sharedMesh.triangles[i + 2]].z - num2) < offset2)
						{
							InEdgePairArray(tri2, tri3, ref vecsInts);
						}
						if (!soScript.flipMesh)
						{
							startTriangles.Add(tri);
							startTriangles.Add(tri2);
							startTriangles.Add(tri3);
						}
						else
						{
							startTriangles.Add(tri2);
							startTriangles.Add(tri);
							startTriangles.Add(tri3);
						}
						if (list[sharedMesh.triangles[i]].z <= num3)
						{
							num3 = list[sharedMesh.triangles[i]].z;
						}
						if (list[sharedMesh.triangles[i + 1]].z <= num3)
						{
							num3 = list[sharedMesh.triangles[i + 1]].z;
						}
						if (list[sharedMesh.triangles[i + 2]].z <= num3)
						{
							num3 = list[sharedMesh.triangles[i + 2]].z;
						}
						if (list[sharedMesh.triangles[i]].z >= num4)
						{
							num4 = list[sharedMesh.triangles[i]].z;
						}
						if (list[sharedMesh.triangles[i + 1]].z >= num4)
						{
							num4 = list[sharedMesh.triangles[i + 1]].z;
						}
						if (list[sharedMesh.triangles[i + 2]].z >= num4)
						{
							num4 = list[sharedMesh.triangles[i + 2]].z;
						}
					}
					bool flag2 = false;
					if (list[sharedMesh.triangles[i]].z > startOffset || list[sharedMesh.triangles[i + 1]].z > startOffset || (list[sharedMesh.triangles[i + 2]].z > startOffset && list[sharedMesh.triangles[i]].z > startOffset - offset1 && list[sharedMesh.triangles[i + 1]].z > startOffset - offset1 && list[sharedMesh.triangles[i + 2]].z > startOffset - offset1))
					{
						flag2 = true;
					}
					if (soScript.includeStartEdgeTris && list[sharedMesh.triangles[i]].z >= startOffset - offset1 && list[sharedMesh.triangles[i + 1]].z >= startOffset - offset1 && list[sharedMesh.triangles[i + 2]].z >= startOffset - offset1)
					{
						flag2 = true;
					}
					if (!flag2)
					{
						continue;
					}
					if (sharedMesh.colors.Length > sharedMesh.triangles[i])
					{
						white = sharedMesh.colors[sharedMesh.triangles[i]];
					}
					if (sharedMesh.uv2.Length > sharedMesh.triangles[i])
					{
						zero = sharedMesh.uv2[sharedMesh.triangles[i]];
					}
					ODDCQDDQQD(sharedMesh.triangles[i], list[sharedMesh.triangles[i]], ref endVecsInt, ref endVecs, ref endUv, ref endUv2, ref endNormals, ref endColors, ref endTangents, sharedMesh.uv[sharedMesh.triangles[i]], zero, list2[sharedMesh.triangles[i]], white, sharedMesh.tangents[sharedMesh.triangles[i]], ref tri);
					if (Mathf.Abs(list[sharedMesh.triangles[i]].z - startOffset) < offset2 && (list[sharedMesh.triangles[i + 1]].z > startOffset || list[sharedMesh.triangles[i + 2]].z > startOffset))
					{
						OQDCQQQDDO(tri, ref endStartInts);
					}
					if (sharedMesh.colors.Length > sharedMesh.triangles[i + 1])
					{
						white = sharedMesh.colors[sharedMesh.triangles[i + 1]];
					}
					if (sharedMesh.uv2.Length > sharedMesh.triangles[i + 1])
					{
						zero = sharedMesh.uv2[sharedMesh.triangles[i + 1]];
					}
					ODDCQDDQQD(sharedMesh.triangles[i + 1], list[sharedMesh.triangles[i + 1]], ref endVecsInt, ref endVecs, ref endUv, ref endUv2, ref endNormals, ref endColors, ref endTangents, sharedMesh.uv[sharedMesh.triangles[i + 1]], zero, list2[sharedMesh.triangles[i + 1]], white, sharedMesh.tangents[sharedMesh.triangles[i + 1]], ref tri2);
					if (Mathf.Abs(list[sharedMesh.triangles[i + 1]].z - startOffset) < offset2 && (list[sharedMesh.triangles[i]].z > startOffset || list[sharedMesh.triangles[i + 2]].z > startOffset))
					{
						OQDCQQQDDO(tri2, ref endStartInts);
					}
					if (sharedMesh.colors.Length > sharedMesh.triangles[i + 2])
					{
						white = sharedMesh.colors[sharedMesh.triangles[i + 2]];
					}
					if (sharedMesh.uv2.Length > sharedMesh.triangles[i + 2])
					{
						zero = sharedMesh.uv2[sharedMesh.triangles[i + 2]];
					}
					ODDCQDDQQD(sharedMesh.triangles[i + 2], list[sharedMesh.triangles[i + 2]], ref endVecsInt, ref endVecs, ref endUv, ref endUv2, ref endNormals, ref endColors, ref endTangents, sharedMesh.uv[sharedMesh.triangles[i + 2]], zero, list2[sharedMesh.triangles[i + 2]], white, sharedMesh.tangents[sharedMesh.triangles[i + 2]], ref tri3);
					if (Mathf.Abs(list[sharedMesh.triangles[i + 2]].z - startOffset) < offset2 && (list[sharedMesh.triangles[i + 1]].z > startOffset || list[sharedMesh.triangles[i]].z > startOffset))
					{
						OQDCQQQDDO(tri3, ref endStartInts);
					}
					if (Mathf.Abs(list[sharedMesh.triangles[i]].z - startOffset) < offset2 && Mathf.Abs(list[sharedMesh.triangles[i + 1]].z - startOffset) < offset2)
					{
						InEdgePairArray(tri, tri2, ref vecsInts4);
					}
					if (Mathf.Abs(list[sharedMesh.triangles[i]].z - startOffset) < offset2 && Mathf.Abs(list[sharedMesh.triangles[i + 2]].z - startOffset) < offset2)
					{
						InEdgePairArray(tri, tri3, ref vecsInts4);
					}
					if (Mathf.Abs(list[sharedMesh.triangles[i + 1]].z - startOffset) < offset2 && Mathf.Abs(list[sharedMesh.triangles[i + 2]].z - startOffset) < offset2)
					{
						InEdgePairArray(tri2, tri3, ref vecsInts4);
					}
					if (!soScript.flipMesh)
					{
						endTriangles.Add(tri);
						endTriangles.Add(tri2);
						endTriangles.Add(tri3);
					}
					else
					{
						endTriangles.Add(tri2);
						endTriangles.Add(tri);
						endTriangles.Add(tri3);
					}
					if (list[sharedMesh.triangles[i]].z <= num7)
					{
						num7 = list[sharedMesh.triangles[i]].z;
					}
					if (list[sharedMesh.triangles[i + 1]].z <= num7)
					{
						num7 = list[sharedMesh.triangles[i + 1]].z;
					}
					if (list[sharedMesh.triangles[i + 2]].z <= num7)
					{
						num7 = list[sharedMesh.triangles[i + 2]].z;
					}
					if (list[sharedMesh.triangles[i]].z >= num8)
					{
						num8 = list[sharedMesh.triangles[i]].z;
					}
					if (list[sharedMesh.triangles[i + 1]].z >= num8)
					{
						num8 = list[sharedMesh.triangles[i + 1]].z;
					}
					if (list[sharedMesh.triangles[i + 2]].z >= num8)
					{
						num8 = list[sharedMesh.triangles[i + 2]].z;
					}
					if (flag)
					{
						if (sharedMesh.colors.Length > sharedMesh.triangles[i])
						{
							white = sharedMesh.colors[sharedMesh.triangles[i]];
						}
						if (sharedMesh.uv2.Length > sharedMesh.triangles[i])
						{
							zero = sharedMesh.uv2[sharedMesh.triangles[i]];
						}
						ODDCQDDQQD(sharedMesh.triangles[i], list[sharedMesh.triangles[i]], ref vecsInt, ref vecs, ref uv, ref uv2, ref normals, ref colors, ref tangents, sharedMesh.uv[sharedMesh.triangles[i]], zero, list2[sharedMesh.triangles[i]], white, sharedMesh.tangents[sharedMesh.triangles[i]], ref tri);
						if (Mathf.Abs(list[sharedMesh.triangles[i]].z - startOffset) < offset2 && (list[sharedMesh.triangles[i + 1]].z > startOffset || list[sharedMesh.triangles[i + 2]].z > startOffset))
						{
							OQDCQQQDDO(tri, ref middleStartInts);
						}
						if (Mathf.Abs(list[sharedMesh.triangles[i]].z - num2) < offset2 && (list[sharedMesh.triangles[i + 1]].z < num2 || list[sharedMesh.triangles[i + 2]].z < num2))
						{
							OQDCQQQDDO(tri, ref middleEndInts);
						}
						if (sharedMesh.colors.Length > sharedMesh.triangles[i + 1])
						{
							white = sharedMesh.colors[sharedMesh.triangles[i + 1]];
						}
						if (sharedMesh.uv2.Length > sharedMesh.triangles[i + 1])
						{
							zero = sharedMesh.uv2[sharedMesh.triangles[i + 1]];
						}
						ODDCQDDQQD(sharedMesh.triangles[i + 1], list[sharedMesh.triangles[i + 1]], ref vecsInt, ref vecs, ref uv, ref uv2, ref normals, ref colors, ref tangents, sharedMesh.uv[sharedMesh.triangles[i + 1]], zero, list2[sharedMesh.triangles[i + 1]], white, sharedMesh.tangents[sharedMesh.triangles[i + 1]], ref tri2);
						if (Mathf.Abs(list[sharedMesh.triangles[i + 1]].z - startOffset) < offset2 && (list[sharedMesh.triangles[i]].z > startOffset || list[sharedMesh.triangles[i + 2]].z > startOffset))
						{
							OQDCQQQDDO(tri2, ref middleStartInts);
						}
						if (Mathf.Abs(list[sharedMesh.triangles[i + 1]].z - num2) < offset2 && (list[sharedMesh.triangles[i]].z < num2 || list[sharedMesh.triangles[i + 2]].z < num2))
						{
							OQDCQQQDDO(tri2, ref middleEndInts);
						}
						if (sharedMesh.colors.Length > sharedMesh.triangles[i + 2])
						{
							white = sharedMesh.colors[sharedMesh.triangles[i + 2]];
						}
						if (sharedMesh.uv2.Length > sharedMesh.triangles[i + 2])
						{
							zero = sharedMesh.uv2[sharedMesh.triangles[i + 2]];
						}
						ODDCQDDQQD(sharedMesh.triangles[i + 2], list[sharedMesh.triangles[i + 2]], ref vecsInt, ref vecs, ref uv, ref uv2, ref normals, ref colors, ref tangents, sharedMesh.uv[sharedMesh.triangles[i + 2]], zero, list2[sharedMesh.triangles[i + 2]], white, sharedMesh.tangents[sharedMesh.triangles[i + 2]], ref tri3);
						if (Mathf.Abs(list[sharedMesh.triangles[i + 2]].z - startOffset) < offset2 && (list[sharedMesh.triangles[i + 1]].z > startOffset || list[sharedMesh.triangles[i]].z > startOffset))
						{
							OQDCQQQDDO(tri3, ref middleStartInts);
						}
						if (Mathf.Abs(list[sharedMesh.triangles[i + 2]].z - num2) < offset2 && (list[sharedMesh.triangles[i]].z < num2 || list[sharedMesh.triangles[i + 1]].z < num2))
						{
							OQDCQQQDDO(tri3, ref middleEndInts);
						}
						if (Mathf.Abs(list[sharedMesh.triangles[i]].z - startOffset) < offset2 && Mathf.Abs(list[sharedMesh.triangles[i + 1]].z - startOffset) < offset2)
						{
							InEdgePairArray(tri, tri2, ref vecsInts2);
						}
						if (Mathf.Abs(list[sharedMesh.triangles[i]].z - startOffset) < offset2 && Mathf.Abs(list[sharedMesh.triangles[i + 2]].z - startOffset) < offset2)
						{
							InEdgePairArray(tri, tri3, ref vecsInts2);
						}
						if (Mathf.Abs(list[sharedMesh.triangles[i + 1]].z - startOffset) < offset2 && Mathf.Abs(list[sharedMesh.triangles[i + 2]].z - startOffset) < offset2)
						{
							InEdgePairArray(tri2, tri3, ref vecsInts2);
						}
						if (Mathf.Abs(list[sharedMesh.triangles[i]].z - num2) < offset2 && Mathf.Abs(list[sharedMesh.triangles[i + 1]].z - num2) < offset2)
						{
							InEdgePairArray(tri, tri2, ref vecsInts3);
						}
						if (Mathf.Abs(list[sharedMesh.triangles[i]].z - num2) < offset2 && Mathf.Abs(list[sharedMesh.triangles[i + 2]].z - num2) < offset2)
						{
							InEdgePairArray(tri, tri3, ref vecsInts3);
						}
						if (Mathf.Abs(list[sharedMesh.triangles[i + 1]].z - num2) < offset2 && Mathf.Abs(list[sharedMesh.triangles[i + 2]].z - num2) < offset2)
						{
							InEdgePairArray(tri2, tri3, ref vecsInts3);
						}
						if (!soScript.flipMesh)
						{
							triangles.Add(tri);
							triangles.Add(tri2);
							triangles.Add(tri3);
						}
						else
						{
							triangles.Add(tri2);
							triangles.Add(tri);
							triangles.Add(tri3);
						}
						if (list[sharedMesh.triangles[i]].z <= num5)
						{
							num5 = list[sharedMesh.triangles[i]].z;
						}
						if (list[sharedMesh.triangles[i + 1]].z <= num5)
						{
							num5 = list[sharedMesh.triangles[i + 1]].z;
						}
						if (list[sharedMesh.triangles[i + 2]].z <= num5)
						{
							num5 = list[sharedMesh.triangles[i + 2]].z;
						}
						if (list[sharedMesh.triangles[i]].z >= num6)
						{
							num6 = list[sharedMesh.triangles[i]].z;
						}
						if (list[sharedMesh.triangles[i + 1]].z >= num6)
						{
							num6 = list[sharedMesh.triangles[i + 1]].z;
						}
						if (list[sharedMesh.triangles[i + 2]].z >= num6)
						{
							num6 = list[sharedMesh.triangles[i + 2]].z;
						}
					}
				}
				for (int i = 0; i < endVecs.Count; i++)
				{
					Vector3 item = endVecs[i];
					item.z -= startOffset;
					endVecs[i] = item;
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
			for (int i = 0; i < vecs.Count; i++)
			{
				Vector3 item = vecs[i];
				item.z -= startOffset;
				vecs[i] = item;
			}
			materials = new List<Material>();
			materials.Add(m_go.GetComponent<MeshRenderer>().sharedMaterial);
			zValuesStart.Clear();
			zValueVecIndexesStart.Clear();
			zValuesEnd.Clear();
			zValueVecIndexesEnd.Clear();
			for (int i = 0; i < vecs.Count; i++)
			{
				if (!ODDQCCDQCQ(vecs[i], i, zValues, ref zValueVecIndexes))
				{
					zValues.Add(vecs[i].z);
					zValueVecIndexes.Add(new ZIndexArray());
					zValueVecIndexes[zValueVecIndexes.Count - 1].index.Add(i);
				}
			}
			for (int i = 0; i < startVecs.Count; i++)
			{
				if (!ODDQCCDQCQ(startVecs[i], i, zValuesStart, ref zValueVecIndexesStart))
				{
					zValuesStart.Add(startVecs[i].z);
					zValueVecIndexesStart.Add(new ZIndexArray());
					zValueVecIndexesStart[zValueVecIndexesStart.Count - 1].index.Add(i);
				}
			}
			for (int i = 0; i < endVecs.Count; i++)
			{
				if (!ODDQCCDQCQ(endVecs[i], i, zValuesEnd, ref zValueVecIndexesEnd))
				{
					zValuesEnd.Add(endVecs[i].z);
					zValueVecIndexesEnd.Add(new ZIndexArray());
					zValueVecIndexesEnd[zValueVecIndexesEnd.Count - 1].index.Add(i);
				}
			}
			List<Vector3> list3 = new List<Vector3>();
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
				MatchEdgePairs(vecsInts, new List<CRedge>(vecsInts2), ref startEndInts, ref middleStartStartInts, ref startEndIntsNC, ref middleStartStartIntsNC, startVecs, vecs, startNormals, normals, ref ODODCOOOCDInt, ref OOOQOODOCDInt);
			}
			MatchEdgePairs(vecsInts2, new List<CRedge>(vecsInts3), ref middleStartInts, ref middleEndInts, ref middleStartIntsNC, ref middleEndIntsNC, vecs, vecs, normals, normals, ref middleLeftInt, ref middleRightInt);
			if (soScript.includeEndSegment)
			{
				MatchEdgePairs(vecsInts3, vecsInts4, ref middleEndEndInts, ref endStartInts, ref middleEndEndIntsNC, ref endStartIntsNC, vecs, endVecs, normals, endNormals, ref endLeftInt, ref endRightInt);
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
					sharedMesh = new Mesh();
					gameObject2.GetComponent<MeshRenderer>().sharedMaterial = materials[0];
					gameObject2.GetComponent<MeshFilter>().sharedMesh = sharedMesh;
					sharedMesh.vertices = startVecs.ToArray();
					sharedMesh.uv = startUv.ToArray();
					sharedMesh.uv2 = startUv2.ToArray();
					sharedMesh.colors = startColors.ToArray();
					sharedMesh.normals = startNormals.ToArray();
					sharedMesh.tangents = startTangents.ToArray();
					sharedMesh.triangles = startTriangles.ToArray();
					sharedMesh.RecalculateNormals();
					sharedMesh.RecalculateBounds();
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
					sharedMesh = new Mesh();
					gameObject2.GetComponent<MeshRenderer>().sharedMaterial = materials[0];
					gameObject2.GetComponent<MeshFilter>().sharedMesh = sharedMesh;
					sharedMesh.vertices = endVecs.ToArray();
					sharedMesh.uv = endUv.ToArray();
					sharedMesh.uv2 = endUv2.ToArray();
					sharedMesh.colors = endColors.ToArray();
					sharedMesh.normals = endNormals.ToArray();
					sharedMesh.tangents = endTangents.ToArray();
					sharedMesh.triangles = endTriangles.ToArray();
					sharedMesh.RecalculateNormals();
					sharedMesh.RecalculateBounds();
				}
				gameObject2 = new GameObject("middle object");
				gameObject2.transform.parent = gameObject.transform;
				testMeshPos = soScript.testMeshPos;
				testMeshPos.z += num2;
				gameObject2.transform.position = testMeshPos;
				gameObject2.AddComponent<MeshRenderer>();
				gameObject2.AddComponent<MeshFilter>();
				sharedMesh = new Mesh();
				gameObject2.GetComponent<MeshRenderer>().sharedMaterial = materials[0];
				gameObject2.GetComponent<MeshFilter>().sharedMesh = sharedMesh;
				sharedMesh.vertices = vecs.ToArray();
				sharedMesh.uv = uv.ToArray();
				sharedMesh.uv2 = uv2.ToArray();
				sharedMesh.colors = colors.ToArray();
				sharedMesh.normals = normals.ToArray();
				sharedMesh.tangents = tangents.ToArray();
				sharedMesh.triangles = triangles.ToArray();
				sharedMesh.RecalculateNormals();
				sharedMesh.RecalculateBounds();
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

		public bool ODDQCCDQCQ(Vector3 v, int index, List<float> zV, ref List<ZIndexArray> zVIndexes)
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

		public void ODDCQDDQQD(int index, Vector3 v, ref List<int> vecsInts, ref List<Vector3> vecs, ref List<Vector2> uv, ref List<Vector2> uv2, ref List<Vector3> normals, ref List<Color> colors, ref List<Vector4> tangents, Vector2 sourceUv, Vector2 sourceUv2, Vector3 sourceNormal, Color sourceColor, Vector4 sourceTangent, ref int tri)
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

		public void OQDCQQQDDO(int index, ref List<int> vecsInts)
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

		public void OODDQOCDOC(float adjustZ)
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

		public void ODCDCQQOOO(ref List<List<int>> groups, List<int> triInts, List<int> edgeInts)
		{
			List<CRedge> list = new List<CRedge>();
			for (int i = 0; i < edgeInts.Count; i++)
			{
				for (int j = 0; j < triInts.Count; j += 3)
				{
					if (triInts[j] == edgeInts[i])
					{
						if (OQDCQQQDDO(triInts[j + 1], edgeInts))
						{
							if (!OCDOOQCQDC(list, edgeInts[i], triInts[j + 1]))
							{
								list.Add(new CRedge(edgeInts[i], triInts[j + 1]));
							}
						}
						else if (OQDCQQQDDO(triInts[j + 2], edgeInts) && !OCDOOQCQDC(list, edgeInts[i], triInts[j + 2]))
						{
							list.Add(new CRedge(edgeInts[i], triInts[j + 2]));
						}
					}
					else if (triInts[j + 1] == edgeInts[i])
					{
						if (OQDCQQQDDO(triInts[j], edgeInts))
						{
							if (!OCDOOQCQDC(list, edgeInts[i], triInts[j]))
							{
								list.Add(new CRedge(edgeInts[i], triInts[j]));
							}
						}
						else if (OQDCQQQDDO(triInts[j + 2], edgeInts) && !OCDOOQCQDC(list, edgeInts[i], triInts[j + 2]))
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
						if (OQDCQQQDDO(triInts[j + 1], edgeInts))
						{
							if (!OCDOOQCQDC(list, edgeInts[i], triInts[j + 1]))
							{
								list.Add(new CRedge(edgeInts[i], triInts[j + 1]));
							}
						}
						else if (OQDCQQQDDO(triInts[j], edgeInts) && !OCDOOQCQDC(list, edgeInts[i], triInts[j]))
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
					ODDCDCQQOC(list, ref curInt);
					groups.Add(new List<int>());
					num++;
					groups[num].Add(curInt);
				}
				flag = false;
				for (int j = 0; j < list.Count; j++)
				{
					if (list[j].v1 == curInt)
					{
						groups[num].Add(list[j].v2);
						curInt = list[j].v2;
						list.RemoveAt(j);
						flag = true;
						break;
					}
					if (list[j].v2 == curInt)
					{
						groups[num].Add(list[j].v1);
						curInt = list[j].v1;
						list.RemoveAt(j);
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

		public void ODDCDCQQOC(List<CRedge> edges, ref int curInt)
		{
			if (edges.Count > 1)
			{
				for (int i = 0; i < edges.Count; i++)
				{
					curInt = edges[i].v1;
					if (!ODOODDQQOD(edges, i + 1, curInt))
					{
						break;
					}
					curInt = edges[i].v2;
					if (!ODOODDQQOD(edges, i + 1, curInt))
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

		public bool ODOODDQQOD(List<CRedge> edges, int index, int curInt)
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

		public bool OQDCQQQDDO(int index, List<int> edgeInts)
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

		public bool OCDOOQCQDC(List<CRedge> edges, int index1, int index2)
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

		public void MatchEdgePairs(List<CRedge> startEdgePairs, List<CRedge> endEdgePairs, ref List<int> startInts, ref List<int> endInts, ref List<int> startIntsNC, ref List<int> endIntsNC, List<Vector3> startVecs, List<Vector3> endVecs, List<Vector3> startNormals, List<Vector3> normals, ref int ODODCOOOCDInt, ref int OOOQOODOCDInt)
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
						if (!OQDCQQQDDO(startEdgePairs[i].v1, startInts))
						{
							startInts.Add(startEdgePairs[i].v1);
							endInts.Add(endEdgePairs[j].v1);
						}
						if (!OQDCQQQDDO(startEdgePairs[i].v2, startInts))
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
						if (!OQDCQQQDDO(startEdgePairs[i].v1, startInts))
						{
							startInts.Add(startEdgePairs[i].v1);
							endInts.Add(endEdgePairs[j].v2);
						}
						if (!OQDCQQQDDO(startEdgePairs[i].v2, startInts))
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
				for (int i = 0; i < startEdgePairs.Count; i++)
				{
					if (!OQDCQQQDDO(startEdgePairs[i].v1, startInts) && !OQDCQQQDDO(startEdgePairs[i].v1, startIntsNC))
					{
						startIntsNC.Add(startEdgePairs[i].v1);
					}
					if (!OQDCQQQDDO(startEdgePairs[i].v2, startInts) && !OQDCQQQDDO(startEdgePairs[i].v2, startIntsNC))
					{
						startIntsNC.Add(startEdgePairs[i].v2);
					}
				}
			}
			if (endEdgePairs.Count > 0)
			{
				for (int i = 0; i < endEdgePairs.Count; i++)
				{
					if (!OQDCQQQDDO(endEdgePairs[i].v1, endInts) && !OQDCQQQDDO(endEdgePairs[i].v1, endIntsNC))
					{
						endIntsNC.Add(endEdgePairs[i].v1);
					}
					if (!OQDCQQQDDO(endEdgePairs[i].v2, endInts) && !OQDCQQQDDO(endEdgePairs[i].v2, endIntsNC))
					{
						endIntsNC.Add(endEdgePairs[i].v2);
					}
				}
			}
			if ((startEdgePairs.Count <= 0 && endEdgePairs.Count <= 0) || startInts.Count <= 0)
			{
				return;
			}
			float num3 = 10000f;
			float num4 = -10000f;
			for (int i = 0; i < startInts.Count; i++)
			{
				if (startVecs[startInts[i]].x < num3)
				{
					num3 = startVecs[startInts[i]].x;
					ODODCOOOCDInt = i;
				}
				if (startVecs[startInts[i]].x > num4)
				{
					num4 = startVecs[startInts[i]].x;
					ODODCOOOCDInt = i;
				}
			}
		}

		public void ODCQQQCQCQ(List<List<int>> startGroups, List<List<int>> endGroups, ref List<int> startInts, ref List<int> endInts, List<Vector3> startVecs, List<Vector3> endVecs)
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
			for (int i = 0; i < startGroups.Count; i++)
			{
				list.AddRange(startGroups[i]);
			}
			for (int i = 0; i < endGroups.Count; i++)
			{
				list2.AddRange(endGroups[i]);
			}
			for (int i = 0; i < list.Count; i++)
			{
				for (int j = i + 1; j < list.Count; j++)
				{
					if (list[i] == list[j])
					{
						list.RemoveAt(j);
						j--;
					}
				}
			}
			for (int i = 0; i < list2.Count; i++)
			{
				for (int j = i + 1; j < list2.Count; j++)
				{
					if (list2[i] == list2[j])
					{
						list2.RemoveAt(j);
						j--;
					}
				}
			}
			for (int i = 0; i < list.Count; i++)
			{
				for (int j = 0; j < list2.Count; j++)
				{
					if (Mathf.Abs(startVecs[list[i]].x - endVecs[list2[j]].x) < offset2 && Mathf.Abs(startVecs[list[i]].y - endVecs[list2[j]].y) < offset2)
					{
						startInts.Add(list[i]);
						endInts.Add(list2[j]);
						list2.RemoveAt(j);
						break;
					}
				}
			}
		}

		public void OODOQQQCDD(GameObject go, SideObject so, ERModularBase scr)
		{
			if (so.meshObjects.Count == 1 && so.meshObjects[0].sVecsGroups.Count == 0)
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
				go.isStatic = so.isStatic;
				if (so.castShadows)
				{
					go.GetComponent<MeshRenderer>().castShadows = true;
				}
				else
				{
					go.GetComponent<MeshRenderer>().castShadows = false;
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
				BuildMeshInstance(go, so, scr, so.meshObjects[0].sVecs, so.meshObjects[0].sUv, so.meshObjects[0].sUv2, so.meshObjects[0].sColors, so.meshObjects[0].sNormals, so.meshObjects[0].sTangents, so.meshObjects[0].sTriangles, so.meshObjects[0].normalArray1, so.meshObjects[0].normalArray2, so.meshObjects[0].materials, so.meshObjects[0].sTerrainNormals);
			}
			else
			{
				for (int i = 0; i < so.meshObjects.Count; i++)
				{
					GameObject gameObject;
					for (int j = 0; j < so.meshObjects[i].sVecsGroups.Count; j++)
					{
						gameObject = ((so.meshObjects.Count == 1) ? new GameObject(so.name + " Batch " + (j + 1)) : ((so.meshObjects[i].sVecsGroups.Count <= 0) ? new GameObject(so.name + " Mesh " + (i + 1)) : new GameObject(so.name + " Mesh " + (i + 1) + " Batch " + (so.meshObjects[i].sVecsGroups.Count + 1))));
						gameObject.transform.parent = go.transform;
						gameObject.AddComponent<MeshRenderer>();
						gameObject.AddComponent<MeshFilter>();
						gameObject.transform.parent = go.transform;
						gameObject.layer = so.layer;
						gameObject.isStatic = so.isStatic;
						if (so.castShadows)
						{
							gameObject.GetComponent<MeshRenderer>().castShadows = true;
						}
						else
						{
							gameObject.GetComponent<MeshRenderer>().castShadows = false;
						}
						BuildMeshInstance(gameObject, so, scr, so.meshObjects[i].sVecsGroups[j], so.meshObjects[i].sUvGroups[j], so.meshObjects[i].sUv2Groups[j], so.meshObjects[i].sColorsGroups[j], so.meshObjects[i].sNormalsGroups[j], so.meshObjects[i].sTangentsGroups[j], so.meshObjects[i].sTrianglesGroups[j], so.meshObjects[i].normalArray1Group[j], so.meshObjects[i].normalArray2Group[j], so.meshObjects[i].materials, so.meshObjects[i].sTerrainNormals);
					}
					gameObject = ((so.meshObjects.Count == 1) ? new GameObject(so.name + " Batch " + (so.meshObjects[i].sVecsGroups.Count + 1)) : ((so.meshObjects[i].sVecsGroups.Count <= 0) ? new GameObject(so.name + " Mesh " + (i + 1)) : new GameObject(so.name + " Mesh " + (i + 1) + " Batch " + (so.meshObjects[i].sVecsGroups.Count + 1))));
					gameObject.transform.parent = go.transform;
					gameObject.AddComponent<MeshRenderer>();
					gameObject.AddComponent<MeshFilter>();
					gameObject.transform.parent = go.transform;
					gameObject.layer = so.layer;
					gameObject.isStatic = so.isStatic;
					if (so.castShadows)
					{
						gameObject.GetComponent<MeshRenderer>().castShadows = true;
					}
					else
					{
						gameObject.GetComponent<MeshRenderer>().castShadows = false;
					}
					BuildMeshInstance(gameObject, so, scr, so.meshObjects[i].sVecs, so.meshObjects[i].sUv, so.meshObjects[i].sUv2, so.meshObjects[i].sColors, so.meshObjects[i].sNormals, so.meshObjects[i].sTangents, so.meshObjects[i].sTriangles, so.meshObjects[i].normalArray1, so.meshObjects[i].normalArray2, so.meshObjects[i].materials, so.meshObjects[i].sTerrainNormals);
				}
				if ((bool)go.GetComponent<MeshRenderer>())
				{
					UnityEngine.Object.DestroyImmediate(go.GetComponent<MeshRenderer>());
				}
				if ((bool)go.GetComponent<MeshFilter>())
				{
					UnityEngine.Object.DestroyImmediate(go.GetComponent<MeshFilter>());
				}
				if ((bool)go.GetComponent<MeshCollider>())
				{
					UnityEngine.Object.DestroyImmediate(go.GetComponent<MeshCollider>());
				}
			}
			Clear();
		}

		private void BuildMeshInstance(GameObject go, SideObject so, ERModularBase scr, List<Vector3> sVecs, List<Vector2> sUv, List<Vector2> sUv2, List<Color> sColors, List<Vector3> sNormals, List<Vector4> sTangents, List<int> sTriangles, List<int> normalArray1, List<int> normalArray2, List<Material> materials, List<Vector3> sTerrainNormals)
		{
			if (go.GetComponent<MeshFilter>() == null)
			{
				go.AddComponent<MeshFilter>();
			}
			Mesh mesh = go.GetComponent<MeshFilter>().sharedMesh;
			if (mesh == null)
			{
				mesh = new Mesh();
				go.GetComponent<MeshFilter>().sharedMesh = mesh;
			}
			if (materials.Count > 0)
			{
				go.GetComponent<MeshRenderer>().sharedMaterial = materials[0];
			}
			mesh.Clear();
			mesh.vertices = sVecs.ToArray();
			mesh.uv = sUv.ToArray();
			mesh.uv4 = sUv2.ToArray();
			mesh.colors = sColors.ToArray();
			mesh.normals = new Vector3[mesh.vertices.Length];
			mesh.tangents = sTangents.ToArray();
			mesh.triangles = sTriangles.ToArray();
			mesh.RecalculateNormals();
			mesh.RecalculateBounds();
			sNormals = new List<Vector3>(mesh.normals);
			Vector3 zero = Vector3.zero;
			int[] array = normalArray1.ToArray();
			int[] array2 = normalArray2.ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				List<Vector3> list = sNormals;
				int index = normalArray1[i];
				Vector3 value = (sNormals[array[i]] = (sNormals[array[i]] + sNormals[array2[i]]) * 0.5f);
				list[index] = value;
			}
			if (so.objectType == 1 && so.indentController)
			{
				for (int i = 0; i < sTerrainNormals.Count; i++)
				{
					if (sTerrainNormals[i] != Vector3.zero)
					{
						sNormals[i] = sTerrainNormals[i];
					}
				}
			}
			if (sNormals.Count == mesh.normals.Length)
			{
				mesh.normals = sNormals.ToArray();
			}
			if (so.collider)
			{
				if ((bool)go.GetComponent<MeshCollider>())
				{
					go.GetComponent<MeshCollider>().sharedMesh = null;
				}
				else
				{
					go.AddComponent<MeshCollider>();
				}
				go.GetComponent<MeshCollider>().sharedMesh = mesh;
			}
			if (so.objectType == 1)
			{
				OCQQDQQCQQ.OOCCQOQQQC(mesh);
			}
			if (sVecs.Count == 0)
			{
				if (go.GetComponent<MeshFilter>() != null)
				{
					UnityEngine.Object.DestroyImmediate(go.GetComponent<MeshFilter>());
				}
				if (go.GetComponent<MeshRenderer>() != null)
				{
					UnityEngine.Object.DestroyImmediate(go.GetComponent<MeshRenderer>());
				}
				if (go.GetComponent<MeshCollider>() != null)
				{
					UnityEngine.Object.DestroyImmediate(go.GetComponent<MeshCollider>());
				}
			}
		}

		private void OCDCDOOODQ(ref int vecCount, ref List<int> intList, List<Vector3> vecsList, float zValue)
		{
			for (int i = 0; i < vecsList.Count; i++)
			{
				Vector3 a = vecsList[i];
				a.z = zValue;
				if (Vector3.Distance(a, vecsList[i]) < offset1)
				{
					intList.Add(i);
				}
			}
			vecCount = intList.Count;
		}

		private void OOQDDCCQCO(ref List<int> targetIntList, List<int> sourceIntList, List<Vector3> targetVecs, List<Vector3> sourceVecs)
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
