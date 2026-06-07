using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WalkwayFloor
{
	public struct Hit
	{
		public bool valid;

		public float worldY;

		public Vector3 normal;

		public Hit(float worldY_, Vector3 normal_)
		{
			valid = true;
			worldY = worldY_;
			normal = normal_;
		}

		public static Hit GetBest(Hit a, Hit b)
		{
			if (a.valid && !b.valid)
			{
				return a;
			}
			if (!a.valid && b.valid)
			{
				return b;
			}
			return (!(a.worldY > b.worldY)) ? b : a;
		}
	}

	[Serializable]
	public class SourceMesh
	{
		public Mesh mesh;

		public Matrix4x4 transform;
	}

	[Serializable]
	public struct HardEdge
	{
		public Vector3 A;

		public Vector3 B;

		public HardEdge(Vector3 A_, Vector3 B_)
		{
			A = A_;
			B = B_;
		}
	}

	[Serializable]
	public struct Tri
	{
		public Vector3 A;

		public Vector3 B;

		public Vector3 C;

		public Vector2 a;

		public Vector2 b;

		public Vector2 c;

		public Rect rect;

		public Vector3 normal;

		public Vector3 V0;

		public Vector3 V1;

		public Vector2 v0;

		public Vector2 v1;

		public float dot00;

		public float dot01;

		public float dot11;

		public float threshU;

		public float threshV;

		public Tri(Vector3 A_, Vector3 B_, Vector3 C_)
		{
			normal = Vector3.Cross(B_ - A_, C_ - A_).normalized;
			if (normal.y < 0f)
			{
				Vector3 vector = A_;
				A_ = C_;
				C_ = vector;
				normal = -normal;
			}
			A = A_;
			B = B_;
			C = C_;
			a = new Vector2(A.x, A.z);
			b = new Vector2(B.x, B.z);
			c = new Vector2(C.x, C.z);
			V0 = C - A;
			V1 = B - A;
			v0 = c - a;
			v1 = b - a;
			dot00 = Vector2.Dot(v0, v0);
			dot01 = Vector2.Dot(v0, v1);
			dot11 = Vector2.Dot(v1, v1);
			threshU = 0.001f / V0.magnitude;
			threshV = 0.001f / V1.magnitude;
			rect = default(Rect);
			rect.xMin = Mathf.Min(a.x, b.x, c.x);
			rect.xMax = Mathf.Max(a.x, b.x, c.x);
			rect.yMin = Mathf.Min(a.y, b.y, c.y);
			rect.yMax = Mathf.Max(a.y, b.y, c.y);
		}

		public bool Contains(Vector2 p, ref Vector3 P)
		{
			if (!rect.Contains(p))
			{
				return false;
			}
			Vector2 rhs = p - a;
			float num = Vector2.Dot(v0, rhs);
			float num2 = Vector2.Dot(v1, rhs);
			float num3 = 1f / (dot00 * dot11 - dot01 * dot01);
			float num4 = (dot11 * num - dot01 * num2) * num3;
			float num5 = (dot00 * num2 - dot01 * num) * num3;
			if (num4 >= 0f - threshU && num5 >= 0f - threshV && num4 + num5 < 1f + threshU + threshV)
			{
				P = A + num4 * V0 + num5 * V1;
				return true;
			}
			return false;
		}
	}

	private class EdgeInfo
	{
		public Vector3 a;

		public Vector3 b;

		public bool hard;

		public Vector3 norm;

		public EdgeInfo(Vector3 a_, Vector3 b_, Vector3 norm_)
		{
			a = a_;
			b = b_;
			norm = norm_;
			hard = true;
		}

		public static string ToId(Vector3 a, Vector3 b)
		{
			string text = string.Format("{0:0.000},{1:0.000},{2:0.000},", a.x, a.y, a.z);
			string text2 = string.Format("{0:0.000},{1:0.000},{2:0.000},", b.x, b.y, b.z);
			if (text.CompareTo(text2) < 0)
			{
				return text + text2;
			}
			return text2 + text;
		}
	}

	private class EdgeInfos : Dictionary<string, EdgeInfo>
	{
		public void Add(Vector3 a, Vector3 b, Vector3 norm)
		{
			string key = EdgeInfo.ToId(a, b);
			EdgeInfo value = null;
			if (TryGetValue(key, out value))
			{
				if (Mathf.Abs(1f - Vector3.Dot(value.norm, norm)) < 0.1f)
				{
					value.hard = false;
				}
			}
			else
			{
				Add(key, new EdgeInfo(a, b, norm));
			}
		}
	}

	public Bounds bounds;

	public int numSourceMeshes;

	public List<Tri> tris = new List<Tri>();

	public List<HardEdge> hardEdges = new List<HardEdge>();

	public void Clear()
	{
		tris.Clear();
		hardEdges.Clear();
		bounds = default(Bounds);
		numSourceMeshes = 0;
	}

	public void Add(Mesh mesh, Matrix4x4 transform)
	{
		Vector3[] vertices = mesh.vertices;
		if (tris.Count == 0)
		{
			bounds = new Bounds(transform.MultiplyPoint(vertices[0]), Vector3.zero);
		}
		for (int i = 0; i < vertices.Length; i++)
		{
			bounds.Encapsulate(transform.MultiplyPoint(vertices[i]));
		}
		int[] triangles = mesh.triangles;
		EdgeInfos edgeInfos = new EdgeInfos();
		for (int j = 0; j < triangles.Length; j += 3)
		{
			Tri item = new Tri(transform.MultiplyPoint(vertices[triangles[j]]), transform.MultiplyPoint(vertices[triangles[j + 1]]), transform.MultiplyPoint(vertices[triangles[j + 2]]));
			tris.Add(item);
			edgeInfos.Add(item.A, item.B, item.normal);
			edgeInfos.Add(item.B, item.C, item.normal);
			edgeInfos.Add(item.C, item.A, item.normal);
		}
		foreach (EdgeInfo value in edgeInfos.Values)
		{
			if (value.hard)
			{
				hardEdges.Add(new HardEdge(value.a, value.b));
			}
		}
		numSourceMeshes++;
	}

	public Hit GetBestHit(Vector2 pos)
	{
		Hit hit = default(Hit);
		Vector3 P = Vector3.zero;
		foreach (Tri tri in tris)
		{
			if (tri.Contains(pos, ref P))
			{
				Hit b = new Hit(P.y, tri.normal);
				hit = Hit.GetBest(hit, b);
			}
		}
		return hit;
	}

	public Mesh CreateMesh()
	{
		List<int> list = new List<int>();
		List<Vector3> list2 = new List<Vector3>();
		List<Vector3> list3 = new List<Vector3>();
		foreach (Tri tri in tris)
		{
			list.Add(list.Count);
			list.Add(list.Count);
			list.Add(list.Count);
			list2.Add(tri.A);
			list2.Add(tri.B);
			list2.Add(tri.C);
			list3.Add(tri.normal);
			list3.Add(tri.normal);
			list3.Add(tri.normal);
		}
		Mesh mesh = new Mesh();
		mesh.vertices = list2.ToArray();
		mesh.triangles = list.ToArray();
		mesh.normals = list3.ToArray();
		return mesh;
	}

	public void DrawDebug(DebugLiner liner)
	{
		liner.matrix = Matrix4x4.identity;
		foreach (HardEdge hardEdge in hardEdges)
		{
			liner.DrawLine(hardEdge.A, hardEdge.B);
		}
	}
}
