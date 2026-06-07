using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Shapes
{
	public static class ShapesMeshGen
	{
		private enum ReflexState
		{
			Unknown = 0,
			Reflex = 1,
			Convex = 2
		}

		private class EarClipPoint
		{
			public int vertIndex;

			public Vector2 pt;

			private ReflexState reflex;

			public EarClipPoint prev;

			public EarClipPoint next;

			public ReflexState ReflexState
			{
				get
				{
					if (reflex == ReflexState.Unknown)
					{
						Vector2 b = ShapesMath.Dir(pt, next.pt);
						Vector2 a = ShapesMath.Dir(prev.pt, pt);
						int num = (generatingClockwisePolygon ? 1 : (-1));
						reflex = (((float)num * ShapesMath.Determinant(a, b) >= -0.001f) ? ReflexState.Reflex : ReflexState.Convex);
					}
					return reflex;
				}
			}

			public EarClipPoint(int vertIndex, Vector2 pt)
			{
				this.vertIndex = vertIndex;
				this.pt = pt;
			}

			public void MarkReflexUnknown()
			{
				reflex = ReflexState.Unknown;
			}
		}

		private static readonly ExpandoList<Color> meshColors = new ExpandoList<Color>();

		private static readonly ExpandoList<Vector3> meshVertices = new ExpandoList<Vector3>();

		private static readonly ExpandoList<Vector4> meshUv0 = new ExpandoList<Vector4>();

		private static readonly ExpandoList<Vector3> meshUv1Prevs = new ExpandoList<Vector3>();

		private static readonly ExpandoList<Vector3> meshUv2Nexts = new ExpandoList<Vector3>();

		private static readonly ExpandoList<int> meshTriangles = new ExpandoList<int>();

		private static readonly ExpandoList<int> meshJoinsTriangles = new ExpandoList<int>();

		private static bool generatingClockwisePolygon;

		private static bool SamePosition(Vector3 a, Vector3 b)
		{
			return Mathf.Max(Mathf.Max(Mathf.Abs(b.x - a.x), Mathf.Abs(b.y - a.y)), Mathf.Abs(b.z - a.z)) < 1E-05f;
		}

		public static void GenPolylineMesh(Mesh mesh, IList<PolylinePoint> path, bool closed, PolylineJoins joins, bool flattenZ, bool useColors)
		{
			meshColors.Clear();
			meshVertices.Clear();
			meshUv0.Clear();
			meshUv1Prevs.Clear();
			meshUv2Nexts.Clear();
			meshTriangles.Clear();
			meshJoinsTriangles.Clear();
			int num = path.Count;
			if (num < 2)
			{
				mesh.Clear();
				return;
			}
			if (num == 2 && closed)
			{
				closed = false;
			}
			PolylinePoint polylinePoint = path[0];
			PolylinePoint polylinePoint2 = path[path.Count - 1];
			if ((closed || num == 2) && SamePosition(polylinePoint.point, polylinePoint2.point))
			{
				num--;
				if (num < 2)
				{
					return;
				}
				polylinePoint2 = path[path.Count - 2];
			}
			bool flag = joins.HasJoinMesh();
			bool flag2 = joins.HasSimpleJoin();
			int num2 = (flag ? 5 : 2);
			int num3 = num * num2;
			int num4 = (flag2 ? 3 : 5);
			int num5 = 0;
			int num6 = 0;
			int num7 = 0;
			int num8 = 0;
			int num9 = 0;
			int num10 = 0;
			int num11 = 0;
			int num12 = 0;
			int triId = 0;
			int num13 = 0;
			for (int i = 0; i < num; i++)
			{
				bool flag3 = i == num - 1;
				bool flag4 = i == 0;
				bool flag5 = closed || (!flag3 && !flag4);
				float uvEndpointVal = ((!closed && (flag4 || flag3)) ? ((!flag4) ? 1 : (-1)) : 0);
				float thickness = path[i].thickness;
				Vector3 value = (flattenZ ? new Vector3(path[i].point.x, path[i].point.y, 0f) : path[i].point);
				Color value2 = (useColors ? path[i].color.ColorSpaceAdjusted() : default(Color));
				int num14 = i * num2;
				int num15;
				if (flag)
				{
					num15 = num14 + 1;
					num5 = num14 + 2;
					num6 = num14 + 3;
					num7 = num14 + 4;
					meshVertices[num14] = value;
					meshVertices[num15] = value;
					meshVertices[num5] = value;
					meshVertices[num6] = value;
					meshVertices[num7] = value;
					if (useColors)
					{
						meshColors[num14] = value2;
						meshColors[num15] = value2;
						meshColors[num5] = value2;
						meshColors[num6] = value2;
						meshColors[num7] = value2;
					}
					if (flag5)
					{
						num8 = (closed ? i : (i - 1)) * num4 + num3;
						num9 = num8 + 1;
						num10 = num8 + 2;
						num11 = num8 + 3;
						num12 = num8 + 4;
						meshVertices[num8] = value;
						meshVertices[num9] = value;
						meshVertices[num10] = value;
						if (useColors)
						{
							meshColors[num8] = value2;
							meshColors[num9] = value2;
							meshColors[num10] = value2;
						}
						if (!flag2)
						{
							meshVertices[num11] = value;
							meshVertices[num12] = value;
							if (useColors)
							{
								meshColors[num11] = value2;
								meshColors[num12] = value2;
							}
						}
					}
				}
				else
				{
					num15 = num14 + 1;
					meshVertices[num14] = value;
					meshVertices[num15] = value;
					if (useColors)
					{
						meshColors[num14] = value2;
						meshColors[num15] = value2;
					}
				}
				Vector3 prevPos;
				Vector3 nextPos;
				if (i == 0)
				{
					prevPos = (closed ? polylinePoint2.point : (polylinePoint.point * 2f - path[1].point));
					nextPos = path[i + 1].point;
				}
				else if (i == num - 1)
				{
					prevPos = path[i - 1].point;
					nextPos = (closed ? polylinePoint.point : (path[num - 1].point * 2f - path[num - 2].point));
				}
				else
				{
					prevPos = path[i - 1].point;
					nextPos = path[i + 1].point;
				}
				SetPrevNext(num14);
				SetPrevNext(num15);
				if (flag)
				{
					SetPrevNext(num5);
					SetPrevNext(num6);
					SetPrevNext(num7);
					if (flag5)
					{
						SetPrevNext(num8);
						SetPrevNext(num9);
						SetPrevNext(num10);
						if (!flag2)
						{
							SetPrevNext(num11);
							SetPrevNext(num12);
						}
					}
				}
				if (flag)
				{
					SetUv(meshUv0, uvEndpointVal, thickness, num14, 0f, 0f);
					SetUv(meshUv0, uvEndpointVal, thickness, num15, -1f, -1f);
					SetUv(meshUv0, uvEndpointVal, thickness, num5, -1f, 1f);
					SetUv(meshUv0, uvEndpointVal, thickness, num6, 1f, -1f);
					SetUv(meshUv0, uvEndpointVal, thickness, num7, 1f, 1f);
					if (flag5)
					{
						SetUv(meshUv0, uvEndpointVal, thickness, num8, 0f, 0f);
						if (flag2)
						{
							SetUv(meshUv0, uvEndpointVal, thickness, num9, 1f, -1f);
							SetUv(meshUv0, uvEndpointVal, thickness, num10, 1f, 1f);
						}
						else
						{
							SetUv(meshUv0, uvEndpointVal, thickness, num9, 1f, -1f);
							SetUv(meshUv0, uvEndpointVal, thickness, num10, -1f, -1f);
							SetUv(meshUv0, uvEndpointVal, thickness, num11, -1f, 1f);
							SetUv(meshUv0, uvEndpointVal, thickness, num12, 1f, 1f);
						}
					}
				}
				else
				{
					SetUv(meshUv0, uvEndpointVal, thickness, num14, -1f, i);
					SetUv(meshUv0, uvEndpointVal, thickness, num15, 1f, i);
				}
				if (!(!flag3 || closed))
				{
					continue;
				}
				if (flag)
				{
					int num16 = num14;
					int b = num5;
					int c = num7;
					int num17 = ((!flag3) ? (num16 + num2) : 0);
					int c2 = num17 + 1;
					int b2 = num17 + 3;
					AddQuad(num16, b, c2, num17);
					AddQuad(num17, b2, c, num16);
					if (flag5)
					{
						meshJoinsTriangles[num13++] = num8;
						meshJoinsTriangles[num13++] = num9;
						meshJoinsTriangles[num13++] = num10;
						if (!flag2)
						{
							meshJoinsTriangles[num13++] = num10;
							meshJoinsTriangles[num13++] = num11;
							meshJoinsTriangles[num13++] = num8;
							meshJoinsTriangles[num13++] = num8;
							meshJoinsTriangles[num13++] = num11;
							meshJoinsTriangles[num13++] = num12;
						}
					}
				}
				else
				{
					int num18 = num14;
					int a = num15;
					int num19 = ((!flag3) ? (num18 + num2) : 0);
					int d = num19 + 1;
					AddQuad(a, num18, num19, d);
				}
				void SetPrevNext(int atIndex)
				{
					meshUv1Prevs[atIndex] = prevPos;
					meshUv2Nexts[atIndex] = nextPos;
				}
			}
			mesh.Clear();
			mesh.SetVertices(meshVertices.list);
			mesh.subMeshCount = ((!flag) ? 1 : 2);
			mesh.SetTriangles(meshTriangles.list, 0);
			if (flag)
			{
				mesh.SetTriangles(meshJoinsTriangles.list, 1);
			}
			mesh.SetUVs(0, meshUv0.list);
			mesh.SetUVs(1, meshUv1Prevs.list);
			mesh.SetUVs(2, meshUv2Nexts.list);
			if (useColors)
			{
				mesh.SetColors(meshColors.list);
			}
			void AddQuad(int value3, int value4, int value5, int value6)
			{
				meshTriangles[triId++] = value3;
				meshTriangles[triId++] = value4;
				meshTriangles[triId++] = value5;
				meshTriangles[triId++] = value5;
				meshTriangles[triId++] = value6;
				meshTriangles[triId++] = value3;
			}
			static void SetUv(ExpandoList<Vector4> uvArr, float z, float pathThicc, int id, float x, float y)
			{
				uvArr[id] = new Vector4(x, y, z, pathThicc);
			}
		}

		public static void GenPolygonMesh(Mesh mesh, List<Vector2> path, PolygonTriangulation triangulation)
		{
			generatingClockwisePolygon = ShapesMath.PolygonSignedArea(path) > 0f;
			float num = (generatingClockwisePolygon ? 1f : (-1f));
			mesh.Clear();
			int count = path.Count;
			if (count < 2)
			{
				return;
			}
			int num2 = count - 2;
			int[] array = new int[num2 * 3];
			if (triangulation == PolygonTriangulation.FastConvexOnly)
			{
				int num3 = 0;
				for (int i = 0; i < num2; i++)
				{
					array[num3++] = i + 2;
					array[num3++] = i + 1;
					array[num3++] = 0;
				}
			}
			else
			{
				List<EarClipPoint> list = new List<EarClipPoint>(count);
				for (int j = 0; j < count; j++)
				{
					list.Add(new EarClipPoint(j, new Vector2(path[j].x, path[j].y)));
				}
				for (int k = 0; k < count; k++)
				{
					EarClipPoint earClipPoint = list[k];
					earClipPoint.prev = list[(k + count - 1) % count];
					earClipPoint.next = list[(k + 1) % count];
				}
				int num4 = 0;
				int num5 = 1000000;
				int count2;
				while ((count2 = list.Count) >= 3 && num5-- > 0)
				{
					if (count2 == 3)
					{
						array[num4++] = list[2].vertIndex;
						array[num4++] = list[1].vertIndex;
						array[num4++] = list[0].vertIndex;
						break;
					}
					bool flag = false;
					for (int l = 0; l < count2; l++)
					{
						EarClipPoint earClipPoint2 = list[l];
						if (earClipPoint2.ReflexState != ReflexState.Convex)
						{
							continue;
						}
						bool flag2 = true;
						int num6 = (l + count2 - 1) % count2;
						int num7 = (l + 1) % count2;
						for (int m = 0; m < count2; m++)
						{
							if (m != l && m != num6 && m != num7 && list[m].ReflexState == ReflexState.Reflex && ShapesMath.PointInsideTriangle(earClipPoint2.next.pt, earClipPoint2.pt, earClipPoint2.prev.pt, list[m].pt, 0f, num * -0.0001f))
							{
								flag2 = false;
								break;
							}
						}
						if (flag2)
						{
							array[num4++] = earClipPoint2.next.vertIndex;
							array[num4++] = earClipPoint2.vertIndex;
							array[num4++] = earClipPoint2.prev.vertIndex;
							earClipPoint2.next.MarkReflexUnknown();
							earClipPoint2.prev.MarkReflexUnknown();
							EarClipPoint next = earClipPoint2.next;
							EarClipPoint prev = earClipPoint2.prev;
							EarClipPoint prev2 = earClipPoint2.prev;
							EarClipPoint next2 = earClipPoint2.next;
							next.prev = prev2;
							prev.next = next2;
							list.RemoveAt(l);
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						Debug.LogError(string.Concat("Invalid polygon triangulation - no convex edges found. Your polygon is likely self-intersecting.\n" + "Failed point set:\n", string.Join("\n", list.Select((EarClipPoint p) => $"[{p.vertIndex}]: {p.ReflexState}"))));
						break;
					}
				}
				if (num5 < 1)
				{
					Debug.LogError("Polygon triangulation failed, please report a bug (Shapes/Report Bug) with this exact case included");
				}
			}
			List<Vector3> list2 = new List<Vector3>(count);
			for (int num8 = 0; num8 < count; num8++)
			{
				list2.Add(path[num8]);
			}
			mesh.SetVertices(list2);
			mesh.subMeshCount = 1;
			mesh.SetTriangles(array, 0);
		}

		public static void CreateDisc(Mesh mesh, int segmentsPerFullTurn, float radius)
		{
			GenerateDiscMesh(mesh, segmentsPerFullTurn, hasSector: false, hasInnerRadius: false, radius, 0f, 0f, 0f);
		}

		public static void CreateCircleSector(Mesh mesh, int segmentsPerFullTurn, float radius, float angRadiansStart, float angRadiansEnd)
		{
			GenerateDiscMesh(mesh, segmentsPerFullTurn, hasSector: true, hasInnerRadius: false, radius, 0f, angRadiansStart, angRadiansEnd);
		}

		public static void CreateAnnulus(Mesh mesh, int segmentsPerFullTurn, float radius, float radiusInner)
		{
			GenerateDiscMesh(mesh, segmentsPerFullTurn, hasSector: true, hasInnerRadius: false, radius, radiusInner, 0f, 0f);
		}

		public static void CreateAnnulusSector(Mesh mesh, int segmentsPerFullTurn, float radius, float radiusInner, float angRadiansStart, float angRadiansEnd)
		{
			GenerateDiscMesh(mesh, segmentsPerFullTurn, hasSector: true, hasInnerRadius: false, radius, radiusInner, angRadiansStart, angRadiansEnd);
		}

		private static void GenerateDiscMesh(Mesh mesh, int segmentsPerFullTurn, bool hasSector, bool hasInnerRadius, float radius, float radiusInner, float angRadiansStart, float angRadiansEnd)
		{
			float num = (hasSector ? angRadiansStart : 0f);
			float num2 = (hasSector ? angRadiansEnd : (MathF.PI * 2f));
			float num3 = Mathf.Abs(num2 - num) / (MathF.PI * 2f);
			int num4 = Mathf.Max(1, Mathf.RoundToInt(num3 * (float)segmentsPerFullTurn));
			float num5 = Mathf.Max(radius, radiusInner);
			float num6 = Mathf.Cos(0.5f * Mathf.Abs(num2 - num) / (float)num4) * num5;
			float num7 = num5 * 2f - num6;
			float num8 = (hasInnerRadius ? Mathf.Min(radius, radiusInner) : 0f);
			int num9 = num4 * 2 * 2;
			int num10 = (num4 + 1) * 2;
			int[] triIndices = new int[num9 * 3];
			Vector3[] array = new Vector3[num10];
			Vector3[] array2 = new Vector3[num10];
			for (int i = 0; i < num4 + 1; i++)
			{
				float t = (float)i / (float)num4;
				Vector2 vector = ShapesMath.AngToDir(Mathf.Lerp(num, num2, t));
				int num11 = i * 2;
				int num12 = num11 + 1;
				array[num11] = vector * num7;
				array[num12] = vector * num8;
				array2[num11] = Vector3.forward;
				array2[num12] = Vector3.forward;
			}
			int tri = 0;
			for (int j = 0; j < num4; j++)
			{
				int num13 = j * 2;
				int b = num13 + 1;
				int c = num13 + 2;
				int num14 = num13 + 3;
				DblTri(num13, num14, c);
				DblTri(num13, b, num14);
			}
			mesh.vertices = array;
			mesh.normals = array2;
			mesh.triangles = triIndices;
			mesh.RecalculateBounds();
			void DblTri(int a, int num15, int num16)
			{
				triIndices[tri++] = a;
				triIndices[tri++] = num15;
				triIndices[tri++] = num16;
				triIndices[tri++] = num16;
				triIndices[tri++] = num15;
				triIndices[tri++] = a;
			}
		}
	}
}
