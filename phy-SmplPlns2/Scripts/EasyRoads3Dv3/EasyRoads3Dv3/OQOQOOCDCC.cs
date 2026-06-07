using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[AddComponentMenu("")]
	public class OQOQOOCDCC : MonoBehaviour
	{
		public class OQCOQODCDO
		{
			public int start;

			public int end;

			public OQCOQODCDO(int startV3, int endV3)
			{
				start = startV3;
				end = endV3;
			}
		}

		public static void OOCQCODODQ(List<ERRoundaboutElement> connections, List<Vector3> mainLeftPoints, ref List<Vector3> meshVecs, ref List<Vector2> meshUVs, ref List<int> fullTris)
		{
			int num = 0;
			int num2 = 10000000;
			int num3 = 10000000;
			bool flag = true;
			if (connections.Count > 0)
			{
				num2 = connections[num].leftOuterInt;
				num3 = connections[num].rightOuterInt;
			}
			List<Vector3> list = new List<Vector3>();
			List<Vector2> list2 = new List<Vector2>();
			List<int> list3 = new List<int>();
			int count = mainLeftPoints.Count;
			int num4 = 3;
			int num5 = 0;
			int num6 = 1;
			int num7 = 0;
			for (int i = 0; i < count - num6; i += num6)
			{
				flag = ((i != num2 && i != num3 - 1) ? true : false);
				for (int j = 0; j < num4 - 1; j++)
				{
					if (j != 0 || flag)
					{
						fullTris.Add(i * num4 + j);
						fullTris.Add((i + num6) * num4 + j + 1);
						fullTris.Add(i * num4 + j + 1);
						fullTris.Add((i + num6) * num4 + j);
						fullTris.Add((i + num6) * num4 + j + 1);
						fullTris.Add(i * num4 + j);
						num5 += 6;
					}
				}
				num7 = fullTris.Count - 6 * num4;
				if (i == num2)
				{
					Vector3 p = meshVecs[fullTris[num7 + 3]];
					Vector3 p2 = meshVecs[fullTris[num7 + 3] + num4];
					Vector3 vector = connections[num].leftOuterSegments[0];
					Vector2 uv = meshUVs[fullTris[num7 + 3]];
					Vector2 uv2 = meshUVs[fullTris[num7 + 3] + num4];
					Vector2 item = SetUV(p, p2, vector, uv, uv2);
					list.Add(vector);
					list2.Add(item);
					list3.Add(fullTris[num7 + 3]);
					list3.Add(fullTris[num7 + 4]);
					list3.Add(fullTris[num7 + 3] + num4);
					list3.Add(fullTris[num7 + 4] + num4);
				}
				if (i == num3 - 1)
				{
					Vector3 p = meshVecs[fullTris[num7 + 3]];
					Vector3 p2 = meshVecs[fullTris[num7 + 3] + num4];
					Vector3 vector = connections[num].rightOuterSegments[0];
					Vector2 uv = meshUVs[fullTris[num7 + 3]];
					Vector2 uv2 = meshUVs[fullTris[num7 + 3] + num4];
					Vector2 item = SetUV(p, p2, vector, uv, uv2);
					list.Add(vector);
					list2.Add(item);
					list3.Add(fullTris[num7 + 3]);
					list3.Add(fullTris[num7 + 4]);
					list3.Add(fullTris[num7 + 3] + num4);
					list3.Add(fullTris[num7 + 4] + num4);
					num++;
					if (connections.Count > num)
					{
						num2 = connections[num].leftOuterInt;
						num3 = connections[num].rightOuterInt;
					}
					else
					{
						num2 = 10000000;
						num3 = 10000000;
					}
				}
			}
			int num8 = 0;
			for (int k = 0; k < list.Count; k++)
			{
				meshVecs.Add(list[k]);
				meshUVs.Add(list2[k]);
				num8 = meshVecs.Count - 1;
				fullTris.Add(list3[k * 4]);
				fullTris.Add(num8);
				fullTris.Add(list3[k * 4 + 1]);
				fullTris.Add(num8);
				fullTris.Add(list3[k * 4 + 3]);
				fullTris.Add(list3[k * 4 + 1]);
				fullTris.Add(num8);
				fullTris.Add(list3[k * 4 + 2]);
				fullTris.Add(list3[k * 4 + 3]);
			}
		}

		public static void OOCQODOCDQ(List<ERRoundaboutElement> connections, List<Vector3> meshVecs, int vecCount, ref List<Vector3> connectionVecs, ref List<Vector2> connectionUVs, ref List<int> connectionTris, ref List<List<int>> triList, ref List<Material> materialList)
		{
			Vector3 vA;
			Vector3 vB;
			Vector3 vector = (vA = (vB = Vector3.zero));
			float num = 0f;
			int index = 0;
			for (int i = 0; i < connections.Count; i++)
			{
				if (!connections[i].leftFlag || !connections[i].rightFlag)
				{
					continue;
				}
				List<Vector3> list = new List<Vector3>();
				List<Vector2> list2 = new List<Vector2>();
				List<PointER> list3 = new List<PointER>();
				List<int> list4 = new List<int>();
				List<Vector3> list5 = new List<Vector3>();
				List<Vector2> list6 = new List<Vector2>();
				List<float> list7 = new List<float>();
				List<float> list8 = new List<float>();
				List<Vector2> list9 = new List<Vector2>();
				List<int> list10 = new List<int>();
				List<Vector2> roadShapeVecs = new List<Vector2>();
				List<float> roadShapeUVY = new List<float>();
				connections[i].blendCornerPointInts.Clear();
				connections[i].blendCornerPointWeights.Clear();
				if (connections[i].blendFlag)
				{
					vector = connections[i].rightOuterSegments[connections[i].rightOuterSegments.Count - 1];
					Vector3 vector2 = connections[i].leftOuterSegments[connections[i].leftOuterSegments.Count - 1];
					vA = connections[i].leftOuterSegments[0];
					vB = connections[i].rightOuterSegments[0];
					Vector3 b = OCOOQOQCDC(vA, vB, vector2);
					num = Vector3.Distance(vector2, b);
				}
				bool flag = false;
				for (int j = 0; j < materialList.Count; j++)
				{
					if (materialList[j] == connections[i].connectionMaterial)
					{
						index = j;
						flag = true;
					}
				}
				if (!flag)
				{
					materialList.Add(connections[i].connectionMaterial);
					triList.Add(new List<int>());
					index = triList.Count - 1;
				}
				list5.Clear();
				list5.AddRange(connections[i].leftOuterSegments);
				list6.Clear();
				list6.AddRange(connections[i].leftOuterSegmentsUVs);
				for (int k = 0; k < list5.Count; k++)
				{
					Vector3 vector3 = list5[k];
					list.Add(vector3);
					list3.Add(new PointER(vector3.x, vector3.z, 0f));
					list2.Add(list6[k]);
					list7.Add(vector3.x);
					list8.Add(vector3.z);
					list9.Add(new Vector2(vector3.x, vector3.z));
					if (connections[i].blendFlag)
					{
						connections[i].blendCornerPointInts.Add(vecCount + list.Count - 1);
						Vector3 b = OCOOQOQCDC(vA, vB, vector3);
						connections[i].blendCornerPointWeights.Add(Vector3.Distance(vector3, b) / num);
					}
				}
				list10.Add(vecCount + list.Count - 1);
				list5.Clear();
				list5.AddRange(connections[i].rightOuterSegments);
				list5.Reverse();
				list6.Clear();
				list6.AddRange(connections[i].rightOuterSegmentsUVs);
				list6.Reverse();
				for (int l = 0; l < list5.Count; l++)
				{
					Vector3 vector3 = list5[l];
					list.Add(vector3);
					list3.Add(new PointER(vector3.x, vector3.z, 0f));
					list2.Add(list6[l]);
					list7.Add(vector3.x);
					list8.Add(vector3.z);
					list9.Add(new Vector2(vector3.x, vector3.z));
					if (connections[i].blendFlag)
					{
						connections[i].blendCornerPointInts.Add(vecCount + list.Count - 1);
						Vector3 b = OCOOQOQCDC(vA, vB, vector3);
						connections[i].blendCornerPointWeights.Add(Vector3.Distance(vector3, b) / num);
					}
				}
				list10.Add(vecCount + list.Count - list5.Count);
				list5.Clear();
				list5.AddRange(connections[i].innerRoundaboutPoints);
				list5.Reverse();
				list6.Clear();
				list6.AddRange(connections[i].innerRoundaboutUVs);
				list6.Reverse();
				for (int m = 0; m < list5.Count; m++)
				{
					Vector3 vector3 = list5[m];
					list.Add(vector3);
					list3.Add(new PointER(vector3.x, vector3.z, 0f));
					list2.Add(list6[m]);
					list7.Add(vector3.x);
					list8.Add(vector3.z);
					list9.Add(new Vector2(vector3.x, vector3.z));
				}
				List<int> list11 = new List<int>();
				List<TriangleER> list12 = delaunayER.Triangulate(list3);
				for (int n = 0; n < list12.Count; n++)
				{
					list11.Add(vecCount + delaunayER.FindVertice(new Vector3(list12[n].Vertex1.x, list12[n].Vertex1.z, list12[n].Vertex1.y), list));
					list11.Add(vecCount + delaunayER.FindVertice(new Vector3(list12[n].Vertex3.x, list12[n].Vertex3.z, list12[n].Vertex3.y), list));
					list11.Add(vecCount + delaunayER.FindVertice(new Vector3(list12[n].Vertex2.x, list12[n].Vertex2.z, list12[n].Vertex2.y), list));
				}
				for (int num2 = 0; num2 < list11.Count; num2 += 3)
				{
					Vector3 vector4 = (list[list11[num2] - vecCount] + list[list11[num2 + 1] - vecCount] + list[list11[num2 + 2] - vecCount]) / 3f;
					if (OCDCDOCQCQ(list9.Count, list9, vector4.x, vector4.z))
					{
						list4.Add(list11[num2]);
						list4.Add(list11[num2 + 1]);
						list4.Add(list11[num2 + 2]);
					}
				}
				Vector3 centerPoint = Vector3.Lerp(connections[i].rightOuterSegments[connections[i].rightOuterSegments.Count - 1], connections[i].leftOuterSegments[connections[i].leftOuterSegments.Count - 1], 0.5f);
				list10.Reverse();
				connectionVecs.AddRange(list);
				connectionTris.AddRange(list4);
				triList[index].AddRange(list4);
				connectionUVs.AddRange(list2);
				meshVecs.AddRange(list);
				vecCount += list.Count;
				connections[i].centerPoint = centerPoint;
				connections[i].connectionVecInts.Clear();
				connections[i].connectionVecInts.AddRange(list10);
				connections[i].fullConnectionVecInts.AddRange(list10);
				OQDODOODCD(meshVecs, list10, ref roadShapeVecs, ref roadShapeUVY);
				connections[i].roadShapeVecs.Clear();
				connections[i].roadShapeVecs.AddRange(roadShapeVecs);
				connections[i].roadShapeUVY.Clear();
				connections[i].roadShapeUVY.AddRange(roadShapeUVY);
			}
		}

		public static void OQDODOODCD(List<Vector3> meshVecs, List<int> connectionVecInts, ref List<Vector2> roadShapeVecs, ref List<float> roadShapeUVY)
		{
			Vector3 a = meshVecs[connectionVecInts[0]];
			Vector3 b = meshVecs[connectionVecInts[connectionVecInts.Count - 1]];
			a.y = 0f;
			b.y = 0f;
			Vector3 b2 = Vector3.Lerp(a, b, 0.5f);
			float num = Vector3.Distance(a, b2);
			for (int i = 0; i < connectionVecInts.Count - 1; i++)
			{
			}
			float num2 = 0f;
			Vector2 zero = Vector2.zero;
			for (int j = 0; j < connectionVecInts.Count; j++)
			{
				b = meshVecs[connectionVecInts[j]];
				b.y = 0f;
				zero.x = Vector3.Distance(b, b2);
				if (Vector3.Distance(a, b) < num)
				{
					zero.x *= -1f;
				}
				zero.y = b.y;
				roadShapeVecs.Add(zero);
				if (j < connectionVecInts.Count - 1)
				{
					num2 += Vector3.Distance(meshVecs[connectionVecInts[j]], meshVecs[connectionVecInts[j + 1]]);
				}
			}
			roadShapeUVY.Add(0f);
			float num3 = 0f;
			for (int k = 1; k < connectionVecInts.Count; k++)
			{
				num3 += Vector3.Distance(meshVecs[connectionVecInts[k - 1]], meshVecs[connectionVecInts[k]]);
				roadShapeUVY.Add(num3 / num2);
			}
		}

		public static Vector2 SetUV(Vector3 p1, Vector3 p2, Vector3 p3, Vector2 uv1, Vector2 uv2)
		{
			float t = Vector3.Distance(p1, p3) / Vector3.Distance(p1, p2);
			return new Vector2(0f, Mathf.Lerp(uv1.y, uv2.y, t));
		}

		public static bool OCDCDOCQCQ(int nvert, List<Vector2> vert, float testx, float testy)
		{
			int num = 0;
			bool flag = false;
			int num2 = 0;
			int index = nvert - 1;
			while (num2 < nvert)
			{
				if (vert[num2].y > testy != vert[index].y > testy && testx < (vert[index].x - vert[num2].x) * (testy - vert[num2].y) / (vert[index].y - vert[num2].y) + vert[num2].x)
				{
					flag = !flag;
				}
				index = num2++;
			}
			return flag;
		}

		public static bool OCQQDDDODQ(int nvert, List<float> vertx, List<float> verty, float testx, float testy)
		{
			int num = 0;
			bool flag = false;
			int num2 = 0;
			int index = nvert - 1;
			while (num2 < nvert)
			{
				if (verty[num2] > testy != verty[index] > testy && testx < (vertx[index] - vertx[num2]) * (testy - verty[num2]) / (verty[index] - verty[num2]) + vertx[num2])
				{
					flag = !flag;
				}
				index = num2++;
			}
			return flag;
		}

		public static bool OQOCCOCQCO(List<Vector3> vecs, List<OQCOQODCDO> edges, int p1, int p2, int p3)
		{
			bool result = true;
			for (int i = 0; i < edges.Count; i++)
			{
				if (edges[i].start == p1 && edges[i].end == p2)
				{
					if (!ERCrossingPrefabs.OOCQODQDQD(vecs[p2], vecs[p1], vecs[p3]))
					{
						result = false;
					}
				}
				else if (edges[i].start == p2 && edges[i].end == p1 && !ERCrossingPrefabs.OOCQODQDQD(vecs[p1], vecs[p2], vecs[p3]))
				{
					result = false;
				}
				if (edges[i].start == p1 && edges[i].end == p3)
				{
					if (!ERCrossingPrefabs.OOCQODQDQD(vecs[p3], vecs[p1], vecs[p2]))
					{
						result = false;
					}
				}
				else if (edges[i].start == p3 && edges[i].end == p1 && !ERCrossingPrefabs.OOCQODQDQD(vecs[p1], vecs[p3], vecs[p2]))
				{
					result = false;
				}
				if (edges[i].start == p2 && edges[i].end == p3)
				{
					if (!ERCrossingPrefabs.OOCQODQDQD(vecs[p3], vecs[p2], vecs[p1]))
					{
						result = false;
					}
				}
				else if (edges[i].start == p3 && edges[i].end == p2 && !ERCrossingPrefabs.OOCQODQDQD(vecs[p2], vecs[p3], vecs[p1]))
				{
					result = false;
				}
			}
			return result;
		}

		public static Vector3 OCOOQOQCDC(Vector3 vA, Vector3 vB, Vector3 vPoint)
		{
			Vector3 rhs = vPoint - vA;
			Vector3 normalized = (vB - vA).normalized;
			float num = Vector3.Distance(vA, vB);
			float num2 = Vector3.Dot(normalized, rhs);
			if (num2 <= 0f)
			{
				return vA;
			}
			if (num2 >= num)
			{
				return vB;
			}
			Vector3 vector = normalized * num2;
			return vA + vector;
		}
	}
}
