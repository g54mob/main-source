using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

namespace Subdiv
{
	public class Model
	{
		private List<Vertex> vertices;

		private List<Edge> edges;

		public List<Triangle> triangles;

		public Model()
		{
			vertices = new List<Vertex>();
			edges = new List<Edge>();
			triangles = new List<Triangle>();
		}

		public Model(Mesh source)
			: this()
		{
			Vector3[] array = source.vertices;
			int i = 0;
			for (int num = array.Length; i < num; i++)
			{
				Vertex item = new Vertex(array[i], i);
				vertices.Add(item);
			}
			int[] array2 = source.triangles;
			int j = 0;
			for (int num2 = array2.Length; j < num2; j += 3)
			{
				int index = array2[j];
				int index2 = array2[j + 1];
				int index3 = array2[j + 2];
				Vertex vertex = vertices[index];
				Vertex vertex2 = vertices[index2];
				Vertex vertex3 = vertices[index3];
				Edge edge = GetEdge(edges, vertex, vertex2);
				Edge edge2 = GetEdge(edges, vertex2, vertex3);
				Edge edge3 = GetEdge(edges, vertex3, vertex);
				Triangle triangle = new Triangle(vertex, vertex2, vertex3, edge, edge2, edge3);
				triangles.Add(triangle);
				vertex.AddTriangle(triangle);
				vertex2.AddTriangle(triangle);
				vertex3.AddTriangle(triangle);
				edge.AddTriangle(triangle);
				edge2.AddTriangle(triangle);
				edge3.AddTriangle(triangle);
			}
		}

		private Edge GetEdge(List<Edge> edges, Vertex v0, Vertex v1)
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

		public void AddTriangle(Vertex v0, Vertex v1, Vertex v2)
		{
			if (!vertices.Contains(v0))
			{
				vertices.Add(v0);
			}
			if (!vertices.Contains(v1))
			{
				vertices.Add(v1);
			}
			if (!vertices.Contains(v2))
			{
				vertices.Add(v2);
			}
			Edge edge = GetEdge(v0, v1);
			Edge edge2 = GetEdge(v1, v2);
			Edge edge3 = GetEdge(v2, v0);
			Triangle triangle = new Triangle(v0, v1, v2, edge, edge2, edge3);
			triangles.Add(triangle);
			v0.AddTriangle(triangle);
			v1.AddTriangle(triangle);
			v2.AddTriangle(triangle);
			edge.AddTriangle(triangle);
			edge2.AddTriangle(triangle);
			edge3.AddTriangle(triangle);
		}

		private Edge GetEdge(Vertex v0, Vertex v1)
		{
			Edge edge = v0.edges.Find((Edge e) => e.a == v1 || e.b == v1);
			if (edge != null)
			{
				return edge;
			}
			Edge edge2 = new Edge(v0, v1);
			edges.Add(edge2);
			v0.AddEdge(edge2);
			v1.AddEdge(edge2);
			return edge2;
		}

		public Mesh Build(bool weld = false)
		{
			Mesh mesh = new Mesh();
			int[] array = new int[triangles.Count * 3];
			if (weld)
			{
				int i = 0;
				for (int count = triangles.Count; i < count; i++)
				{
					Triangle triangle = triangles[i];
					array[i * 3] = vertices.IndexOf(triangle.v0);
					array[i * 3 + 1] = vertices.IndexOf(triangle.v1);
					array[i * 3 + 2] = vertices.IndexOf(triangle.v2);
				}
				mesh.vertices = vertices.Select((Vertex v) => v.p).ToArray();
			}
			else
			{
				Vector3[] array2 = new Vector3[triangles.Count * 3];
				int num = 0;
				for (int count2 = triangles.Count; num < count2; num++)
				{
					Triangle triangle2 = triangles[num];
					int num2 = num * 3;
					int num3 = num * 3 + 1;
					int num4 = num * 3 + 2;
					array2[num2] = triangle2.v0.p;
					array2[num3] = triangle2.v1.p;
					array2[num4] = triangle2.v2.p;
					array[num2] = num2;
					array[num3] = num3;
					array[num4] = num4;
				}
				mesh.vertices = array2;
			}
			mesh.indexFormat = ((mesh.vertexCount >= 65535) ? IndexFormat.UInt32 : IndexFormat.UInt16);
			mesh.triangles = array;
			mesh.RecalculateNormals();
			mesh.RecalculateBounds();
			return mesh;
		}
	}
}
