using System;
using System.Text;
using Assets.Scripts.Craft.MeshGen;
using Assets.Scripts.Craft.Wings.Utilities;
using Unity.Collections;
using Unity.Mathematics;

namespace Assets.Scripts.Craft.Wings
{
	public static class SkeletalInsetter
	{
		public interface IProfileProvider
		{
			float4x3 GetTransform(float inset);
		}

		private struct Edge
		{
			public int A;

			public int B;

			public float Length;

			public float2 Normal;

			public float Shrinkage;
		}

		private struct Polygon : IDisposable
		{
			public NativeList<Edge> Edges;

			public NativeList<Vertex> Vertices;

			public static Polygon CreateFromPoints(NativeArray<float2> points, NativeArray<int> meshIndices, Allocator allocator)
			{
				Polygon result = CreateFromPoints(points, allocator);
				for (int i = 0; i < points.Length; i++)
				{
					Vertex value = result.Vertices[i];
					value.MeshVertex = meshIndices[i];
					result.Vertices[i] = value;
				}
				return result;
			}

			public static Polygon CreateFromPoints(NativeArray<float2> points, Allocator allocator)
			{
				Polygon result = new Polygon
				{
					Vertices = new NativeList<Vertex>(points.Length, allocator),
					Edges = new NativeList<Edge>(points.Length, allocator)
				};
				result.Vertices.Length = 0;
				result.Edges.Length = 0;
				for (int i = 0; i < points.Length; i++)
				{
					int num = (i - 1 + points.Length) % points.Length;
					int num2 = (i + 1) % points.Length;
					int index = (i + 2) % points.Length;
					float2 float5 = points[num];
					float2 float6 = points[i];
					float2 float7 = points[num2];
					float2 float8 = points[index];
					float num3 = ComputePointShrinkage(float6 - float5, float7 - float6);
					float shrinkage = num3 + ComputePointShrinkage(float7 - float6, float8 - float7);
					float2 float9 = math.normalize(float6 - float5);
					float2 float10 = Rotate(float9);
					result.Vertices.Add(new Vertex
					{
						Position = float6,
						InsetVelocity = float10 - num3 * float9,
						IncomingEdge = num,
						OutgoingEdge = i,
						Shrinkage = num3
					});
					result.Edges.Add(new Edge
					{
						A = i,
						B = num2,
						Normal = ComputeEdgeNormal(float6, float7),
						Length = math.length(float7 - float6),
						Shrinkage = shrinkage
					});
				}
				return result;
			}

			public void CullShortEdges(float epsilon = 0.0001f)
			{
				for (int i = 0; i < Edges.Length; i++)
				{
					if (Edges[i].Length <= epsilon)
					{
						Edges.RemoveAt(i--);
					}
				}
			}

			public void Dispose()
			{
				Edges.Dispose();
				Vertices.Dispose();
			}

			public float2 GetEdgeVector(int edgeIndex)
			{
				Edge edge = Edges[edgeIndex];
				return Vertices[edge.B].Position - Vertices[edge.A].Position;
			}

			public void InsetPoints(float amount)
			{
				for (int i = 0; i < Vertices.Length; i++)
				{
					Vertex value = Vertices[i];
					value.Position += value.InsetVelocity * amount;
					Vertices[i] = value;
				}
				for (int j = 0; j < Edges.Length; j++)
				{
					Edge value2 = Edges[j];
					value2.Length -= value2.Shrinkage * amount;
					Edges[j] = value2;
				}
			}

			public void RecalculateEdgeLengths()
			{
				for (int i = 0; i < Edges.Length; i++)
				{
					Edge edge = Edges[i];
					edge.Length = math.distance(Vertices[edge.A], Vertices[edge.B]);
				}
			}

			public void RecalculateEdgeShrinkage(int index)
			{
				Edge value = Edges[index];
				value.Shrinkage = Vertices[value.A].Shrinkage + Vertices[value.B].Shrinkage;
				Edges[index] = value;
			}

			public void RecalculateVertexShrinkageVelocity(int index, bool updateAdjacentEdges = false)
			{
				Vertex value = Vertices[index];
				float2 edgeVector = GetEdgeVector(value.IncomingEdge);
				float2 edgeVector2 = GetEdgeVector(value.OutgoingEdge);
				value.Shrinkage = ComputePointShrinkage(edgeVector, edgeVector2);
				value.InsetVelocity = ComputePointVelocity(value.Shrinkage, edgeVector);
				Vertices[index] = value;
				if (updateAdjacentEdges)
				{
					RecalculateEdgeShrinkage(value.IncomingEdge);
					RecalculateEdgeShrinkage(value.OutgoingEdge);
				}
			}

			public void RemoveEdge(int index, out int successorPointIndex)
			{
				Edge edge = Edges[index];
				int num = Vertices[edge.B].OutgoingEdge;
				Edge value = Edges[num];
				value.A = edge.A;
				Edges[num] = value;
				Vertex value2 = Vertices[edge.A];
				value2.OutgoingEdge = num;
				Vertices[edge.A] = value2;
				Edges.RemoveAtSwapBack(index);
				if (index < Edges.Length)
				{
					Edge edge2 = Edges[index];
					Vertex value3 = Vertices[edge2.A];
					value3.OutgoingEdge = index;
					Vertices[edge2.A] = value3;
					value3 = Vertices[edge2.B];
					value3.IncomingEdge = index;
					Vertices[edge2.B] = value3;
				}
				RemoveVertex(edge.B);
				if (num == Edges.Length)
				{
					num = index;
				}
				successorPointIndex = Edges[num].A;
			}

			public void RemoveEdgeAndVertices(int index)
			{
				Edge edge = Edges[index];
				RemoveVertex(edge.A);
				if (edge.A != edge.B)
				{
					if (edge.B == Vertices.Length)
					{
						edge.B = edge.A;
					}
					RemoveVertex(edge.B);
				}
				Edges.RemoveAtSwapBack(index);
				if (index < Edges.Length)
				{
					UpdateVerticesFromEdge(index);
				}
			}

			public void RemoveEdgeOnly(int index)
			{
				Edges.RemoveAtSwapBack(index);
				if (index < Edges.Length)
				{
					UpdateVerticesFromEdge(index);
				}
			}

			public void RemoveTriangle(int3 vertsToRemove)
			{
				int3 int5 = math.int3(Vertices[vertsToRemove.x].OutgoingEdge, Vertices[vertsToRemove.y].OutgoingEdge, Vertices[vertsToRemove.z].OutgoingEdge);
				for (int i = 0; i < 3; i++)
				{
					Edges[int5[i]] = new Edge
					{
						A = -1,
						B = -1
					};
					Vertices[vertsToRemove[i]] = new Vertex
					{
						IncomingEdge = -1,
						OutgoingEdge = -1
					};
				}
				for (int j = 0; j < 3; j++)
				{
					int num = vertsToRemove[j];
					Vertices.RemoveAtSwapBack(num);
					if (num != Vertices.Length)
					{
						UpdateEdgesFromVertex(num);
					}
					for (int k = j + 1; k < 3; k++)
					{
						if (vertsToRemove[k] == Vertices.Length)
						{
							vertsToRemove[k] = num;
							break;
						}
					}
					int num2 = int5[j];
					Edges.RemoveAtSwapBack(num2);
					if (num2 != Edges.Length)
					{
						UpdateVerticesFromEdge(num2);
					}
					for (int l = j + 1; l < 3; l++)
					{
						if (int5[l] == Edges.Length)
						{
							int5[l] = num2;
							break;
						}
					}
				}
			}

			public void RemoveVertex(int index)
			{
				Vertices.RemoveAtSwapBack(index);
				if (index < Vertices.Length)
				{
					Vertex vertex = Vertices[index];
					Edge value = Edges[vertex.IncomingEdge];
					value.B = index;
					Edges[vertex.IncomingEdge] = value;
					value = Edges[vertex.OutgoingEdge];
					value.A = index;
					Edges[vertex.OutgoingEdge] = value;
				}
			}

			public void UpdateEdgesFromVertex(int vertex)
			{
				Vertex vertex2 = Vertices[vertex];
				if (vertex2.IncomingEdge != -1)
				{
					Edge value = Edges[vertex2.IncomingEdge];
					value.B = vertex;
					value.Length = math.distance(vertex2.Position, Vertices[value.A].Position);
					Edges[vertex2.IncomingEdge] = value;
				}
				if (vertex2.OutgoingEdge != -1)
				{
					Edge value2 = Edges[vertex2.OutgoingEdge];
					value2.A = vertex;
					value2.Length = math.distance(vertex2.Position, Vertices[value2.B].Position);
					Edges[vertex2.OutgoingEdge] = value2;
				}
			}

			public void UpdateVerticesFromEdge(int edge)
			{
				Edge edge2 = Edges[edge];
				if (edge2.A != -1)
				{
					Vertex value = Vertices[edge2.A];
					value.OutgoingEdge = edge;
					Vertices[edge2.A] = value;
				}
				if (edge2.B != -1)
				{
					Vertex value2 = Vertices[edge2.B];
					value2.IncomingEdge = edge;
					Vertices[edge2.B] = value2;
				}
			}
		}

		private struct Vertex
		{
			public int IncomingEdge;

			public float2 InsetVelocity;

			public int MeshVertex;

			public float MeshVertexInset;

			public int OldMeshVertex;

			public int OutgoingEdge;

			public float2 Position;

			public float Shrinkage;

			public static implicit operator float2(Vertex v)
			{
				return v.Position;
			}
		}

		public static void OutsetPoints(Span<float2> points, float amount)
		{
			float2 float5 = points[0];
			float2 float6 = points[points.Length - 1];
			for (int i = 0; i < points.Length; i++)
			{
				float2 float7 = points[i];
				float2 float8 = float6;
				float6 = float7;
				float2 obj = ((i == points.Length - 1) ? float5 : points[i + 1]);
				float2 float9 = float7 - float8;
				float2 outVec = obj - float7;
				float2 float10 = ComputePointVelocity(ComputePointShrinkage(float9, outVec), float9);
				float7 += float10 * amount;
				points[i] = float7;
			}
		}

		public static float EstimateMaxInset(NativeSlice<float2> points)
		{
			float2 float5 = float.PositiveInfinity;
			float2 float6 = float.NegativeInfinity;
			for (int i = 0; i < points.Length; i++)
			{
				float2 y = points[i];
				float5 = math.min(float5, y);
				float6 = math.max(float6, y);
			}
			return 0.5f * math.cmin(float6 - float5);
		}

		public static void MakeInsetMesh<T>(NativeArray<float2> inPoints, Allocator allocator, NativeMesh mesh, NativeArray<float> insets, ref T profileProvider) where T : IProfileProvider
		{
			MakeInsetMeshImpl(Polygon.CreateFromPoints(inPoints, allocator), mesh, insets, ref profileProvider, addInitialVertices: true);
		}

		public static void MakeInsetMesh<T>(NativeArray<float2> inPoints, NativeArray<int> meshVertices, Allocator allocator, NativeMesh mesh, NativeArray<float> insets, ref T profileProvider) where T : IProfileProvider
		{
			MakeInsetMeshImpl(Polygon.CreateFromPoints(inPoints, meshVertices, allocator), mesh, insets, ref profileProvider, addInitialVertices: false);
		}

		private static int CheckConsistency(in Polygon polygon)
		{
			int num = 0;
			for (int i = 0; i < polygon.Vertices.Length; i++)
			{
				Vertex vertex = polygon.Vertices[i];
				if (polygon.Edges[vertex.OutgoingEdge].A != i)
				{
					num++;
				}
				if (polygon.Edges[vertex.IncomingEdge].B != i)
				{
					num++;
				}
			}
			for (int j = 0; j < polygon.Edges.Length; j++)
			{
				Edge edge = polygon.Edges[j];
				if (polygon.Vertices[edge.A].OutgoingEdge != j)
				{
					num++;
				}
				if (polygon.Vertices[edge.B].IncomingEdge != j)
				{
					num++;
				}
			}
			return num;
		}

		private static float2 ComputeEdgeNormal(float2 a, float2 b)
		{
			return math.normalize(Rotate(b - a));
		}

		private static bool ComputeMovingPointLineHit(float2 point, float2 pointVelocity, float2 line1, float2 line2, float2 lineVelocity, float maxTime, out float hitTime, out float hitLineT)
		{
			float3 point2 = math.float3(line1, 0f);
			float3 x = math.float3(line2 - line1, 0f);
			float3 y = math.float3(lineVelocity, 1f);
			float3 normal = math.cross(x, y);
			Plane plane = new Plane(normal, point2);
			float3 float5 = math.float3(point, 0f);
			float3 float6 = math.float3(pointVelocity, 1f);
			if (plane.Raycast(float5, float6, out var t))
			{
				float3 float7 = float5 + t * float6;
				float z = float7.z;
				if (z <= maxTime)
				{
					hitTime = z;
					float2 x2 = float7.xy - (line1 + lineVelocity * z);
					hitLineT = math.dot(x2, x.xy) / math.lengthsq(x.xy);
					return true;
				}
			}
			hitTime = (hitLineT = 0f);
			return false;
		}

		private static float ComputePointShrinkage(float2 inVec, float2 outVec)
		{
			float2 v = math.normalize(inVec);
			float2 float5 = math.normalize(outVec);
			float2 float6 = Rotate(v);
			float2 float7 = Rotate(float5);
			float num = math.dot(float6 - float7, float6);
			float num2 = math.dot(float6, float5);
			if (!(math.abs(num2) <= 1.1920929E-07f))
			{
				return num / num2;
			}
			return 0f;
		}

		private static float2 ComputePointVelocity(float pointShrinkage, float2 edgeVector)
		{
			float2 float5 = math.normalize(edgeVector);
			return Rotate(float5) - pointShrinkage * float5;
		}

		private static string DebugStringVerts(Polygon p)
		{
			StringBuilder stringBuilder = new StringBuilder("verts = [\n");
			for (int i = 0; i < p.Vertices.Length; i++)
			{
				Vertex vertex = p.Vertices[i];
				stringBuilder.AppendLine(string.Format("  (({0}, {1}), ({2}, {3})){4}", vertex.Position.x, vertex.Position.y, vertex.InsetVelocity.x, vertex.InsetVelocity.y, (i == p.Vertices.Length - 1) ? string.Empty : ","));
			}
			stringBuilder.AppendLine("]\n\nedges = [");
			for (int j = 0; j < p.Edges.Length; j++)
			{
				Edge edge = p.Edges[j];
				stringBuilder.AppendLine(string.Format("({0}, {1}, ({2}, {3}), {4}){5}", edge.A, edge.B, edge.Normal.x, edge.Normal.y, edge.Shrinkage, (j == p.Edges.Length - 1) ? string.Empty : ","));
			}
			stringBuilder.AppendLine("]\n\ndisplay_poly(verts, edges)");
			return stringBuilder.ToString();
		}

		private static bool FindNextCollapse(in Polygon polygon, out int nextEdge, ref float nextInset)
		{
			nextEdge = -1;
			for (int i = 0; i < polygon.Edges.Length; i++)
			{
				Edge edge = polygon.Edges[i];
				float num = edge.Length / edge.Shrinkage;
				if (!(num < 0f) && num < nextInset)
				{
					nextEdge = i;
					nextInset = num;
				}
			}
			return nextEdge != -1;
		}

		private static bool FindNextCollision(in Polygon polygon, float maxInset, out int collisionVertex, out int collisionEdge, out float collisionInset)
		{
			collisionVertex = -1;
			collisionEdge = -1;
			collisionInset = maxInset;
			if (maxInset == 0f)
			{
				return false;
			}
			for (int i = 0; i < polygon.Vertices.Length; i++)
			{
				Vertex vertex = polygon.Vertices[i];
				if (!(vertex.Shrinkage < 0f))
				{
					continue;
				}
				for (int j = 0; j < polygon.Edges.Length; j++)
				{
					Edge edge = polygon.Edges[j];
					if (edge.A == i || edge.B == i)
					{
						continue;
					}
					Vertex vertex2 = polygon.Vertices[edge.A];
					Vertex vertex3 = polygon.Vertices[edge.B];
					if (vertex3.OutgoingEdge != vertex.IncomingEdge && vertex2.IncomingEdge != vertex.OutgoingEdge && ComputeMovingPointLineHit(vertex, vertex.InsetVelocity, vertex2, vertex3, vertex2.InsetVelocity, collisionInset, out var hitTime, out var hitLineT))
					{
						float num = 1f - edge.Shrinkage * hitTime / edge.Length;
						if (hitLineT <= num && hitTime < collisionInset)
						{
							collisionVertex = i;
							collisionEdge = j;
							collisionInset = hitTime;
						}
					}
				}
			}
			return collisionVertex != -1;
		}

		private static bool FindShortEdge(in Polygon polygon, float maxLength, out int edge)
		{
			for (int i = 0; i < polygon.Edges.Length; i++)
			{
				if (polygon.Edges[i].Length < maxLength)
				{
					edge = i;
					return true;
				}
			}
			edge = 0;
			return false;
		}

		private static int GetNextEdge(in Polygon polygon, int edge)
		{
			return polygon.Vertices[polygon.Edges[edge].B].OutgoingEdge;
		}

		private static bool IsTriangle(in Polygon polygon, int i)
		{
			int nextEdge = GetNextEdge(in polygon, i);
			int nextEdge2 = GetNextEdge(in polygon, nextEdge);
			return GetNextEdge(in polygon, nextEdge2) == i;
		}

		private static void MakeInsetMeshImpl<T>(Polygon polygon, NativeMesh mesh, NativeArray<float> insets, ref T profileProvider, bool addInitialVertices) where T : IProfileProvider
		{
			float4x3 transform = profileProvider.GetTransform(0f);
			if (addInitialVertices)
			{
				for (int i = 0; i < polygon.Vertices.Length; i++)
				{
					Vertex value = polygon.Vertices[i];
					value.MeshVertex = AddVertex(in value.Position);
					value.MeshVertexInset = 0f;
					polygon.Vertices[i] = value;
				}
			}
			int num = 0;
			float currentInset = 0f;
			while (polygon.Edges.Length > 0)
			{
				float nextInset = insets[num] - currentInset;
				if (CheckConsistency(in polygon) != 0)
				{
					break;
				}
				if (FindShortEdge(in polygon, 4.7683716E-07f, out var edge))
				{
					if (!IsTriangle(in polygon, edge))
					{
						Edge edge2 = polygon.Edges[edge];
						Vertex vertex = polygon.Vertices[edge2.A];
						Vertex vertex2 = polygon.Vertices[edge2.B];
						int meshVertex = polygon.Vertices[polygon.Edges[vertex.IncomingEdge].A].MeshVertex;
						int meshVertex2 = polygon.Vertices[polygon.Edges[vertex2.OutgoingEdge].B].MeshVertex;
						polygon.RemoveEdge(edge, out var successorPointIndex);
						polygon.RecalculateVertexShrinkageVelocity(successorPointIndex, updateAdjacentEdges: true);
						int num2;
						if (vertex.MeshVertexInset == currentInset)
						{
							mesh.Tri(vertex2.MeshVertex, vertex.MeshVertex, meshVertex2);
							num2 = vertex.MeshVertex;
						}
						else if (vertex2.MeshVertexInset == currentInset)
						{
							mesh.Tri(vertex2.MeshVertex, vertex.MeshVertex, meshVertex);
							num2 = vertex2.MeshVertex;
						}
						else
						{
							num2 = AddVertex(in vertex.Position);
							mesh.Tri(num2, vertex.MeshVertex, meshVertex);
							mesh.Tri(num2, vertex2.MeshVertex, vertex.MeshVertex);
							mesh.Tri(num2, meshVertex2, vertex2.MeshVertex);
						}
						Vertex value2 = polygon.Vertices[successorPointIndex];
						value2.MeshVertex = num2;
						value2.MeshVertexInset = currentInset;
						polygon.Vertices[successorPointIndex] = value2;
						continue;
					}
					Edge edge3 = polygon.Edges[edge];
					Vertex vertex3 = polygon.Vertices[edge3.A];
					Vertex vertex4 = polygon.Vertices[edge3.B];
					Vertex vertex5 = polygon.Vertices[polygon.Edges[vertex4.OutgoingEdge].B];
					if (vertex3.MeshVertexInset == currentInset || vertex4.MeshVertexInset == currentInset || vertex5.MeshVertexInset == currentInset)
					{
						mesh.Tri(vertex5.MeshVertex, vertex4.MeshVertex, vertex3.MeshVertex);
						polygon.RemoveTriangle(math.int3(edge3.A, edge3.B, polygon.Edges[vertex4.OutgoingEdge].B));
						continue;
					}
					nextInset = 0f;
				}
				else if (!FindNextCollapse(in polygon, out edge, ref nextInset))
				{
					edge = -1;
				}
				if (FindNextCollision(in polygon, nextInset, out var collisionVertex, out var collisionEdge, out var collisionInset))
				{
					StepInset(collisionInset, ref profileProvider);
					Vertex value3 = polygon.Vertices[collisionVertex];
					Edge edge4 = polygon.Edges[collisionEdge];
					int meshVertex3 = polygon.Vertices[edge4.A].MeshVertex;
					int meshVertex4 = polygon.Vertices[edge4.B].MeshVertex;
					int meshVertex5 = polygon.Vertices[polygon.Edges[value3.IncomingEdge].A].MeshVertex;
					int meshVertex6 = polygon.Vertices[polygon.Edges[value3.OutgoingEdge].B].MeshVertex;
					int num3 = AddVertex(in value3.Position);
					mesh.Tri(num3, meshVertex4, meshVertex3);
					mesh.Tri(num3, value3.MeshVertex, meshVertex5);
					mesh.Tri(num3, meshVertex6, value3.MeshVertex);
					int length = polygon.Vertices.Length;
					int length2 = polygon.Edges.Length;
					value3.MeshVertex = num3;
					value3.MeshVertexInset = currentInset;
					Vertex value4 = new Vertex
					{
						Position = value3.Position,
						MeshVertex = num3,
						MeshVertexInset = currentInset,
						IncomingEdge = value3.IncomingEdge,
						OutgoingEdge = length2
					};
					polygon.Vertices.Add(in value4);
					value3.IncomingEdge = collisionEdge;
					polygon.Vertices[collisionVertex] = value3;
					ref NativeList<Edge> edges = ref polygon.Edges;
					Edge value5 = new Edge
					{
						A = length,
						B = polygon.Edges[collisionEdge].B
					};
					edges.Add(in value5);
					polygon.UpdateEdgesFromVertex(collisionVertex);
					polygon.UpdateEdgesFromVertex(length);
					polygon.RecalculateVertexShrinkageVelocity(collisionVertex, updateAdjacentEdges: true);
					polygon.RecalculateVertexShrinkageVelocity(length, updateAdjacentEdges: true);
				}
				else if (edge != -1)
				{
					StepInset(nextInset, ref profileProvider);
					if (IsTriangle(in polygon, edge))
					{
						Edge edge5 = polygon.Edges[edge];
						int outgoingEdge = polygon.Vertices[edge5.B].OutgoingEdge;
						Edge edge6 = polygon.Edges[outgoingEdge];
						int outgoingEdge2 = polygon.Vertices[edge6.B].OutgoingEdge;
						Edge edge7 = polygon.Edges[outgoingEdge2];
						Vertex vertex6 = polygon.Vertices[edge5.A];
						Vertex vertex7 = polygon.Vertices[edge6.A];
						Vertex vertex8 = polygon.Vertices[edge7.A];
						int a = AddVertex(in vertex6.Position);
						mesh.Tri(a, vertex7.MeshVertex, vertex6.MeshVertex);
						mesh.Tri(a, vertex8.MeshVertex, vertex7.MeshVertex);
						mesh.Tri(a, vertex6.MeshVertex, vertex8.MeshVertex);
						polygon.RemoveTriangle(math.int3(edge5.A, edge6.A, edge7.A));
					}
					else
					{
						Edge edge8 = polygon.Edges[edge];
						Vertex vertex9 = polygon.Vertices[edge8.A];
						Vertex vertex10 = polygon.Vertices[edge8.B];
						int meshVertex7 = polygon.Vertices[polygon.Edges[vertex9.IncomingEdge].A].MeshVertex;
						int meshVertex8 = polygon.Vertices[polygon.Edges[vertex10.OutgoingEdge].B].MeshVertex;
						polygon.RemoveEdge(edge, out var successorPointIndex2);
						int num4 = AddVertex(in vertex9.Position);
						mesh.Tri(num4, vertex9.MeshVertex, meshVertex7);
						mesh.Tri(num4, vertex10.MeshVertex, vertex9.MeshVertex);
						mesh.Tri(num4, meshVertex8, vertex10.MeshVertex);
						Vertex value6 = polygon.Vertices[successorPointIndex2];
						value6.MeshVertex = num4;
						value6.MeshVertexInset = currentInset;
						polygon.Vertices[successorPointIndex2] = value6;
						polygon.RecalculateVertexShrinkageVelocity(successorPointIndex2, updateAdjacentEdges: true);
					}
				}
				else
				{
					StepInset(nextInset, ref profileProvider);
					for (int j = 0; j < polygon.Vertices.Length; j++)
					{
						Vertex value7 = polygon.Vertices[j];
						value7.OldMeshVertex = value7.MeshVertex;
						value7.MeshVertex = AddVertex(in value7.Position);
						value7.MeshVertexInset = currentInset;
						polygon.Vertices[j] = value7;
					}
					for (int k = 0; k < polygon.Edges.Length; k++)
					{
						Edge edge9 = polygon.Edges[k];
						Vertex vertex11 = polygon.Vertices[edge9.A];
						Vertex vertex12 = polygon.Vertices[edge9.B];
						mesh.Quad(vertex11.OldMeshVertex, vertex11.MeshVertex, vertex12.MeshVertex, vertex12.OldMeshVertex);
					}
					if (++num == insets.Length)
					{
						break;
					}
				}
			}
			polygon.Dispose();
			int AddVertex(in float2 pt)
			{
				return mesh.Vert(MathUtils.Transform(transform, pt));
			}
			void StepInset(float by, ref T provider)
			{
				if (by != 0f)
				{
					polygon.InsetPoints(by);
					currentInset += by;
					float inset = currentInset;
					transform = provider.GetTransform(inset);
				}
			}
		}

		private static int NumZeroOldVerts(Polygon p)
		{
			int num = 0;
			for (int i = 0; i < p.Vertices.Length; i++)
			{
				if (p.Vertices[i].OldMeshVertex == 0)
				{
					num++;
				}
			}
			return num;
		}

		private static int NumZeroVerts(Polygon p)
		{
			int num = 0;
			for (int i = 0; i < p.Vertices.Length; i++)
			{
				if (p.Vertices[i].MeshVertex == 0)
				{
					num++;
				}
			}
			return num;
		}

		private static float2 Rotate(float2 v)
		{
			return math.float2(0f - v.y, v.x);
		}
	}
}
