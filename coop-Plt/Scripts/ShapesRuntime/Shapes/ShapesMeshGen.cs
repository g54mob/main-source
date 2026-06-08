using System;
using System.Collections.Generic;
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
						Vector2 vector = next.pt - pt;
						Vector2 vector2 = pt - prev.pt;
						if (generatingClockwisePolygon)
						{
							reflex = ((ShapesMath.Determinant(vector2, vector) >= -0.001f) ? ReflexState.Reflex : ReflexState.Convex);
						}
						else
						{
							reflex = ((ShapesMath.Determinant(vector, vector2) >= -0.001f) ? ReflexState.Reflex : ReflexState.Convex);
						}
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

		private static bool generatingClockwisePolygon;

		private static bool SamePosition(Vector3 a, Vector3 b)
		{
			return Mathf.Max(Mathf.Max(Mathf.Abs(b.x - a.x), Mathf.Abs(b.y - a.y)), Mathf.Abs(b.z - a.z)) < 1E-05f;
		}

		public static void GenPolylineMesh(Mesh mesh, IList<PolylinePoint> path, bool closed, PolylineJoins joins, bool flattenZ, bool useColors)
		{
			mesh.Clear();
			int num = path.Count;
			if (num < 2)
			{
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
			int num3 = (flag ? 4 : 2);
			int num4 = num * num2;
			int num5 = num4;
			int num6 = (closed ? num : (num - 1)) * num3 * 3;
			int[] array = null;
			int num7 = 0;
			if (flag)
			{
				num7 = (flag2 ? 3 : 5);
				int num8 = (closed ? num : (num - 2));
				int num9 = (flag2 ? 1 : 3);
				int num10 = num8 * num9 * 3;
				int num11 = num8 * num7;
				num5 += num11;
				array = new int[num10];
			}
			Color[] array2 = (useColors ? new Color[num5] : null);
			Vector3[] array3 = new Vector3[num5];
			Vector4[] meshUv0 = new Vector4[num5];
			Vector3[] meshUv1Prevs = new Vector3[num5];
			Vector3[] meshUv2Nexts = new Vector3[num5];
			int[] meshTriangles = new int[num6];
			int num12 = 0;
			int num13 = 0;
			int num14 = 0;
			int num15 = 0;
			int num16 = 0;
			int num17 = 0;
			int num18 = 0;
			int num19 = 0;
			int triId = 0;
			int num20 = 0;
			int i;
			for (i = 0; i < num; i++)
			{
				bool flag3 = i == num - 1;
				bool flag4 = i == 0;
				bool flag5 = closed || (!flag3 && !flag4);
				bool flag6 = !closed && (flag4 || flag3);
				float uvEndpointValue = (flag6 ? ((!flag4) ? 1 : (-1)) : 0);
				Vector3 vector = (flattenZ ? new Vector3(path[i].point.x, path[i].point.y, 0f) : path[i].point);
				Color color = (useColors ? path[i].color : default(Color));
				int num21 = i * num2;
				int num22;
				if (flag)
				{
					num22 = num21 + 1;
					num12 = num21 + 2;
					num13 = num21 + 3;
					num14 = num21 + 4;
					array3[num21] = vector;
					array3[num22] = vector;
					array3[num12] = vector;
					array3[num13] = vector;
					array3[num14] = vector;
					if (useColors)
					{
						array2[num21] = color;
						array2[num22] = color;
						array2[num12] = color;
						array2[num13] = color;
						array2[num14] = color;
					}
					if (flag5)
					{
						num15 = (closed ? i : (i - 1)) * num7 + num4;
						num16 = num15 + 1;
						num17 = num15 + 2;
						num18 = num15 + 3;
						num19 = num15 + 4;
						array3[num15] = vector;
						array3[num16] = vector;
						array3[num17] = vector;
						if (useColors)
						{
							array2[num15] = color;
							array2[num16] = color;
							array2[num17] = color;
						}
						if (!flag2)
						{
							array3[num18] = vector;
							array3[num19] = vector;
							if (useColors)
							{
								array2[num18] = color;
								array2[num19] = color;
							}
						}
					}
				}
				else
				{
					num22 = num21 + 1;
					array3[num21] = vector;
					array3[num22] = vector;
					if (useColors)
					{
						array2[num21] = color;
						array2[num22] = color;
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
				SetPrevNext(num21);
				SetPrevNext(num22);
				if (flag)
				{
					SetPrevNext(num12);
					SetPrevNext(num13);
					SetPrevNext(num14);
					if (flag5)
					{
						SetPrevNext(num15);
						SetPrevNext(num16);
						SetPrevNext(num17);
						if (!flag2)
						{
							SetPrevNext(num18);
							SetPrevNext(num19);
						}
					}
				}
				if (flag)
				{
					SetUv(num21, 0f, 0f);
					SetUv(num22, -1f, -1f);
					SetUv(num12, -1f, 1f);
					SetUv(num13, 1f, -1f);
					SetUv(num14, 1f, 1f);
					if (flag5)
					{
						SetUv(num15, 0f, 0f);
						if (flag2)
						{
							SetUv(num16, 1f, -1f);
							SetUv(num17, 1f, 1f);
						}
						else
						{
							SetUv(num16, 1f, -1f);
							SetUv(num17, -1f, -1f);
							SetUv(num18, -1f, 1f);
							SetUv(num19, 1f, 1f);
						}
					}
				}
				else
				{
					SetUv(num21, -1f, i);
					SetUv(num22, 1f, i);
				}
				if (!(!flag3 || closed))
				{
					continue;
				}
				if (flag)
				{
					int num23 = num21;
					int b = num12;
					int c = num14;
					int num24 = ((!flag3) ? (num23 + num2) : 0);
					int c2 = num24 + 1;
					int b2 = num24 + 3;
					AddQuad(num23, b, c2, num24);
					AddQuad(num24, b2, c, num23);
					if (flag5)
					{
						array[num20++] = num15;
						array[num20++] = num16;
						array[num20++] = num17;
						if (!flag2)
						{
							array[num20++] = num17;
							array[num20++] = num18;
							array[num20++] = num15;
							array[num20++] = num15;
							array[num20++] = num18;
							array[num20++] = num19;
						}
					}
				}
				else
				{
					int num25 = num21;
					int a = num22;
					int num26 = ((!flag3) ? (num25 + num2) : 0);
					int d = num26 + 1;
					AddQuad(a, num25, num26, d);
				}
				void SetPrevNext(int atIndex)
				{
					meshUv1Prevs[atIndex] = prevPos;
					meshUv2Nexts[atIndex] = nextPos;
				}
				void SetUv(int id, float x, float y)
				{
					meshUv0[id] = new Vector4(x, y, uvEndpointValue, path[i].thickness);
				}
			}
			mesh.vertices = array3;
			mesh.subMeshCount = 2;
			mesh.SetTriangles(meshTriangles, 0);
			mesh.SetTriangles(array, 1);
			mesh.SetUVs(0, meshUv0);
			mesh.SetUVs(1, meshUv1Prevs);
			mesh.SetUVs(2, meshUv2Nexts);
			if (useColors)
			{
				mesh.colors = array2;
			}
			void AddQuad(int num27, int num28, int num29, int num30)
			{
				meshTriangles[triId++] = num27;
				meshTriangles[triId++] = num28;
				meshTriangles[triId++] = num29;
				meshTriangles[triId++] = num29;
				meshTriangles[triId++] = num30;
				meshTriangles[triId++] = num27;
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
						Debug.LogError("Invalid polygon triangulation - no convex edges found. Your polygon is likely self-intersecting");
						break;
					}
				}
				if (num5 < 1)
				{
					Debug.LogError("Polygon triangulation failed, please report a bug (Shapes/Report Bug) with this exact case included");
				}
			}
			List<Vector3> list2 = new List<Vector3>(count);
			for (int n = 0; n < count; n++)
			{
				list2.Add(path[n]);
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
			float num2 = (hasSector ? angRadiansEnd : ((float)Math.PI * 2f));
			float num3 = Mathf.Abs(num2 - num) / ((float)Math.PI * 2f);
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
