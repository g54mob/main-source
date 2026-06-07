using System.Collections.Generic;
using UnityEngine;

namespace Mystery.Graphing
{
	public class MeshBuilder
	{
		private List<Vector3> Vertices;

		private List<Vector3> Normals;

		private List<Color> Colors;

		private List<Vector2> UV1;

		private List<Vector2> UV2;

		private List<Vector2> UV3;

		private Vector3 Vertex;

		private Vector3 Normal;

		private Color Color;

		private Vector2 uv1;

		private Vector2 uv2;

		private Vector2 uv3;

		public MeshBuilder(int capacity, bool normals = false, bool colors = false, bool uv1 = false, bool uv2 = false, bool uv3 = false)
		{
			Vertices = new List<Vector3>(capacity);
			if (normals)
			{
				Normals = new List<Vector3>(capacity);
			}
			if (colors)
			{
				Colors = new List<Color>(capacity);
			}
			if (uv1)
			{
				UV1 = new List<Vector2>(capacity);
			}
			if (uv2)
			{
				UV2 = new List<Vector2>(capacity);
			}
			if (uv3)
			{
				UV3 = new List<Vector2>(capacity);
			}
		}

		public void SetVertex(float x, float y, float z)
		{
			SetVertex(new Vector3(x, y, z));
		}

		public void SetVertex(Vector3 value)
		{
			Vertex = value;
		}

		public void SetNormal(Vector3 value)
		{
			Normal = value;
		}

		public void SetColor(Color value)
		{
			Color = value;
		}

		public void SetUV1(float x, float y)
		{
			SetUV1(new Vector2(x, y));
		}

		public void SetUV2(float x, float y)
		{
			SetUV2(new Vector2(x, y));
		}

		public void SetUV3(float x, float y)
		{
			SetUV3(new Vector2(x, y));
		}

		public void SetUV1(Vector2 value)
		{
			uv1 = value;
		}

		public void SetUV2(Vector2 value)
		{
			uv2 = value;
		}

		public void SetUV3(Vector2 value)
		{
			uv3 = value;
		}

		public void Push()
		{
			Vertices.Add(Vertex);
			if (Normals != null)
			{
				Normals.Add(Normal);
			}
			if (Colors != null)
			{
				Colors.Add(Color);
			}
			if (UV1 != null)
			{
				UV1.Add(uv1);
			}
			if (UV2 != null)
			{
				UV2.Add(uv2);
			}
			if (UV3 != null)
			{
				UV3.Add(uv3);
			}
		}

		public Mesh Generate(Mesh mesh = null)
		{
			if (mesh == null)
			{
				mesh = new Mesh();
			}
			mesh.Clear(keepVertexLayout: true);
			mesh.SetVertices(Vertices);
			if (Normals != null)
			{
				mesh.SetNormals(Normals);
			}
			if (Colors != null)
			{
				mesh.SetColors(Colors);
			}
			if (UV1 != null)
			{
				mesh.SetUVs(0, UV1);
			}
			if (UV2 != null)
			{
				mesh.SetUVs(1, UV2);
			}
			if (UV3 != null)
			{
				mesh.SetUVs(2, UV3);
			}
			return mesh;
		}
	}
}
