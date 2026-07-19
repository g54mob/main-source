using System;
using System.Collections.Generic;
using UnityEngine;

namespace Subdiv
{
	public class SubdivisionSurface
	{
		public static Mesh Subdivide(Mesh source, int details = 1, bool weld = false)
		{
			return Subdivide(source, details).Build(weld);
		}

		public static Model Subdivide(Mesh source, int details = 1)
		{
			Model model = new Model(source);
			SubdivisionSurface subdivisionSurface = new SubdivisionSurface();
			for (int i = 0; i < details; i++)
			{
				model = subdivisionSurface.Divide(model);
			}
			return model;
		}

		public static Mesh Weld(Mesh mesh, float threshold, float bucketStep)
		{
			Vector3[] vertices = mesh.vertices;
			Vector3[] array = new Vector3[vertices.Length];
			int[] array2 = new int[vertices.Length];
			int num = 0;
			Vector3 vector = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
			Vector3 vector2 = new Vector3(float.MinValue, float.MinValue, float.MinValue);
			for (int i = 0; i < vertices.Length; i++)
			{
				if (vertices[i].x < vector.x)
				{
					vector.x = vertices[i].x;
				}
				if (vertices[i].y < vector.y)
				{
					vector.y = vertices[i].y;
				}
				if (vertices[i].z < vector.z)
				{
					vector.z = vertices[i].z;
				}
				if (vertices[i].x > vector2.x)
				{
					vector2.x = vertices[i].x;
				}
				if (vertices[i].y > vector2.y)
				{
					vector2.y = vertices[i].y;
				}
				if (vertices[i].z > vector2.z)
				{
					vector2.z = vertices[i].z;
				}
			}
			int num2 = Mathf.FloorToInt((vector2.x - vector.x) / bucketStep) + 1;
			int num3 = Mathf.FloorToInt((vector2.y - vector.y) / bucketStep) + 1;
			int num4 = Mathf.FloorToInt((vector2.z - vector.z) / bucketStep) + 1;
			List<int>[,,] array3 = new List<int>[num2, num3, num4];
			for (int j = 0; j < vertices.Length; j++)
			{
				int num5 = Mathf.FloorToInt((vertices[j].x - vector.x) / bucketStep);
				int num6 = Mathf.FloorToInt((vertices[j].y - vector.y) / bucketStep);
				int num7 = Mathf.FloorToInt((vertices[j].z - vector.z) / bucketStep);
				if (array3[num5, num6, num7] == null)
				{
					array3[num5, num6, num7] = new List<int>();
				}
				int num8 = 0;
				while (true)
				{
					if (num8 < array3[num5, num6, num7].Count)
					{
						if (Vector3.SqrMagnitude(array[array3[num5, num6, num7][num8]] - vertices[j]) < threshold)
						{
							array2[j] = array3[num5, num6, num7][num8];
							break;
						}
						num8++;
						continue;
					}
					array[num] = vertices[j];
					array3[num5, num6, num7].Add(num);
					array2[j] = num;
					num++;
					break;
				}
			}
			int[] triangles = mesh.triangles;
			int[] array4 = new int[triangles.Length];
			for (int k = 0; k < triangles.Length; k++)
			{
				array4[k] = array2[triangles[k]];
			}
			Vector3[] array5 = new Vector3[num];
			for (int l = 0; l < num; l++)
			{
				array5[l] = array[l];
			}
			mesh.Clear();
			mesh.vertices = array5;
			mesh.triangles = array4;
			mesh.RecalculateNormals();
			return mesh;
		}

		public Edge GetEdge(List<Edge> edges, Vertex v0, Vertex v1)
		{
			Edge edge = v0.edges.Find((Edge e) => e.Has(v1));
			if (edge != null)
			{
				return edge;
			}
			Edge edge2 = new Edge(v0, v1);
			v0.AddEdge(edge2);
			v1.AddEdge(edge2);
			edges.Add(edge2);
			return edge2;
		}

		private Model Divide(Model model)
		{
			Model model2 = new Model();
			int i = 0;
			for (int count = model.triangles.Count; i < count; i++)
			{
				Triangle triangle = model.triangles[i];
				Vertex edgePoint = GetEdgePoint(triangle.e0);
				Vertex edgePoint2 = GetEdgePoint(triangle.e1);
				Vertex edgePoint3 = GetEdgePoint(triangle.e2);
				Vertex vertexPoint = GetVertexPoint(triangle.v0);
				Vertex vertexPoint2 = GetVertexPoint(triangle.v1);
				Vertex vertexPoint3 = GetVertexPoint(triangle.v2);
				model2.AddTriangle(vertexPoint, edgePoint, edgePoint3);
				model2.AddTriangle(edgePoint, vertexPoint2, edgePoint2);
				model2.AddTriangle(edgePoint, edgePoint2, edgePoint3);
				model2.AddTriangle(edgePoint3, edgePoint2, vertexPoint3);
			}
			return model2;
		}

		public Vertex GetEdgePoint(Edge e)
		{
			if (e.ept != null)
			{
				return e.ept;
			}
			if (e.faces.Count != 2)
			{
				Vector3 p = (e.a.p + e.b.p) * 0.5f;
				e.ept = new Vertex(p, e.a.index);
			}
			else
			{
				Vertex otherVertex = e.faces[0].GetOtherVertex(e);
				Vertex otherVertex2 = e.faces[1].GetOtherVertex(e);
				e.ept = new Vertex((e.a.p + e.b.p) * 0.375f + (otherVertex.p + otherVertex2.p) * 0.125f, e.a.index);
			}
			return e.ept;
		}

		public Vertex[] GetAdjancies(Vertex v)
		{
			Vertex[] array = new Vertex[v.edges.Count];
			int i = 0;
			for (int count = v.edges.Count; i < count; i++)
			{
				array[i] = v.edges[i].GetOtherVertex(v);
			}
			return array;
		}

		public Vertex GetVertexPoint(Vertex v)
		{
			if (v.updated != null)
			{
				return v.updated;
			}
			Vertex[] adjancies = GetAdjancies(v);
			int num = adjancies.Length;
			if (num < 3)
			{
				Vertex otherVertex = v.edges[0].GetOtherVertex(v);
				Vertex otherVertex2 = v.edges[1].GetOtherVertex(v);
				v.updated = new Vertex(0.75f * v.p + 0.125f * (otherVertex.p + otherVertex2.p), v.index);
			}
			else
			{
				float num2 = ((num == 3) ? 0.1875f : (1f / (float)num * (0.625f - Mathf.Pow(0.375f + 0.25f * Mathf.Cos(MathF.PI * 2f / (float)num), 2f))));
				Vector3 p = (1f - (float)num * num2) * v.p;
				for (int i = 0; i < num; i++)
				{
					Vertex vertex = adjancies[i];
					p += num2 * vertex.p;
				}
				v.updated = new Vertex(p, v.index);
			}
			return v.updated;
		}
	}
}
