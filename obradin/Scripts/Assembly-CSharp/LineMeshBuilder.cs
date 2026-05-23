using System.Collections.Generic;
using UnityEngine;

public class LineMeshBuilder
{
	private struct Seg
	{
		public Vector3 p0;

		public Vector3 p1;

		public float density;

		public int textureSliceOffset;
	}

	private List<Seg> segs = new List<Seg>();

	public int numTriangles
	{
		get
		{
			return segs.Count * 2;
		}
	}

	private Vector3[] vertices
	{
		get
		{
			Vector3[] array = new Vector3[segs.Count * 4];
			for (int i = 0; i < segs.Count; i++)
			{
				array[i * 4] = segs[i].p0;
				array[i * 4 + 1] = segs[i].p0;
				array[i * 4 + 2] = segs[i].p1;
				array[i * 4 + 3] = segs[i].p1;
			}
			return array;
		}
	}

	private int[] triangles
	{
		get
		{
			int[] array = new int[segs.Count * 6];
			for (int i = 0; i < segs.Count; i++)
			{
				array[i * 6] = i * 4;
				array[i * 6 + 1] = i * 4 + 1;
				array[i * 6 + 2] = i * 4 + 3;
				array[i * 6 + 3] = i * 4 + 1;
				array[i * 6 + 4] = i * 4 + 2;
				array[i * 6 + 5] = i * 4 + 3;
			}
			return array;
		}
	}

	private Vector2[] uv
	{
		get
		{
			Vector2[] array = new Vector2[segs.Count * 4];
			int num = 256;
			for (int i = 0; i < segs.Count; i++)
			{
				Seg seg = segs[i];
				float num2 = (float)((i + seg.textureSliceOffset) % num) / (float)num + 0.5f;
				float x = num2 + 0.25f / (float)num;
				array[i * 4] = new Vector2(num2, 1f + seg.density);
				array[i * 4 + 1] = new Vector2(x, 1f + seg.density);
				array[i * 4 + 2] = new Vector2(x, seg.density);
				array[i * 4 + 3] = new Vector2(num2, seg.density);
			}
			return array;
		}
	}

	private Vector4[] tangents
	{
		get
		{
			Vector4[] array = new Vector4[segs.Count * 4];
			for (int i = 0; i < segs.Count; i++)
			{
				Seg seg = segs[i];
				array[i * 4] = new Vector4(seg.p1.x, seg.p1.y, seg.p1.z, -1f);
				array[i * 4 + 1] = new Vector4(seg.p1.x, seg.p1.y, seg.p1.z, 1f);
				array[i * 4 + 2] = new Vector4(seg.p0.x, seg.p0.y, seg.p0.z, -1f);
				array[i * 4 + 3] = new Vector4(seg.p0.x, seg.p0.y, seg.p0.z, 1f);
			}
			return array;
		}
	}

	public void Add(Vector3 p0, Vector3 p1, float density = 1f, int textureSliceOffset = 0)
	{
		segs.Add(new Seg
		{
			p0 = p0,
			p1 = p1,
			density = Mathf.Clamp(density, 0.01f, 0.9f),
			textureSliceOffset = textureSliceOffset
		});
	}

	public void Clear()
	{
		segs.Clear();
	}

	public void Apply(Mesh mesh)
	{
		mesh.vertices = vertices;
		mesh.uv = uv;
		mesh.tangents = tangents;
		mesh.SetTriangles(triangles, 0);
	}
}
