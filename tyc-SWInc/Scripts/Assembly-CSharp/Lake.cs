using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class Lake : Landmark
{
	public class TriangleNode
	{
		public Vector2[] Points;

		public List<TriangleNode> Connections;

		public TriangleNode(Vector2 a, Vector2 b, Vector2 c)
		{
			Points = new Vector2[3] { a, b, c };
			Connections = new List<TriangleNode>();
		}
	}

	public float TexelSize = 0.5f;

	public Vector2[] LakeBounds;

	public Rect LakeArea;

	public float LakeSize;

	public Renderer LakeRendWater;

	public Renderer LakeRendBottom;

	private MeshFilter MeshRend;

	private MeshFilter LakePoly;

	public Material BottomMat;

	[NonSerialized]
	public List<TriangleNode> Nodes;

	public void Init(IList<Vector2> area)
	{
		List<Vector2> list = area.ToList();
		list.CleanUpPolygon(5f);
		List<Vector2> list2 = OffsetBounds(list, 0.1f, 4f);
		for (int i = 0; i < list2.Count; i++)
		{
			Vector2 vector = list2[i];
			Vector2 vector2 = list2[(i + 1) % list2.Count];
			if ((vector - vector2).magnitude > 8f)
			{
				list2.Insert(i + 1, (vector + vector2) * 0.5f);
				i--;
			}
		}
		list.Clear();
		list.AddRange(list2);
		for (int j = 0; j < list2.Count; j++)
		{
			Vector2 p = list[j];
			Vector2 p2 = list[(j + 1) % list.Count];
			Vector2 p3 = list[(j + 2) % list.Count];
			Vector2 p4 = list[(j + 3) % list.Count];
			list2[j] = PathController.Bezier(p, p2, p3, p4, 0.5f);
		}
		for (int k = 0; k < area.Count; k++)
		{
			for (int l = 0; l < list2.Count; l++)
			{
				Vector2 vector3 = list2[l];
				Vector2 vector4 = list2[(l + 1) % list2.Count];
				Vector2 res;
				if (Utilities.ProjectToLine(area[k], vector3, vector4, out res) && (res - area[k]).magnitude < 3f && Utilities.IsLeft(area[k], vector3, vector4) > 0 && Utilities.IsLeft(area[(k + 1) % area.Count], vector3, vector4) < 0)
				{
					list2.Insert(l + 1, area[k]);
				}
			}
		}
		LakeBounds = list2.ToArray();
		InitStuff();
		List<TreeInstance> list3 = GameSettings.Instance.TreeTree.Query(LakeArea).ToList();
		for (int m = 0; m < list3.Count; m++)
		{
			TreeInstance treeInstance = list3[m];
			if (Utilities.IsInside(treeInstance.GetPos(), LakeBounds))
			{
				GameSettings.Instance.RemoveTree(treeInstance);
			}
		}
		TimeOfDay.Instance.GroundTopDirty = true;
	}

	private void InitStuff()
	{
		LakeArea = ((IList<Vector2>)LakeBounds).GetBounds();
		LakeSize = Utilities.PolygonArea(LakeBounds);
		InitNodes();
		GenerateMeshes();
	}

	private void InitNodes()
	{
		Triangulator triangulator = new Triangulator(LakeBounds);
		List<Vector2> list = OffsetBounds(LakeBounds, 0.25f, 4f);
		int[] array = triangulator.Triangulate();
		Nodes = new List<TriangleNode>();
		for (int i = 0; i < array.Length; i += 3)
		{
			Nodes.Add(new TriangleNode(list[array[i]], list[array[i + 1]], list[array[i + 2]]));
		}
		for (int j = 0; j < Nodes.Count; j++)
		{
			int num = array[j * 3];
			int num2 = array[j * 3 + 1];
			int num3 = array[j * 3 + 2];
			for (int k = j * 3; k < array.Length; k += 3)
			{
				TriangleNode triangleNode = Nodes[k / 3];
				int num4 = array[k];
				int num5 = array[k + 1];
				int num6 = array[k + 2];
				if (num == num4 || num == num5 || num == num6 || num2 == num4 || num2 == num5 || num2 == num6 || num3 == num4 || num3 == num5 || num3 == num6)
				{
					Nodes[j].Connections.Add(triangleNode);
					triangleNode.Connections.Add(Nodes[j]);
				}
			}
		}
	}

	private void Tesselate(List<Vector2> vertices, List<int> triangles, float threshold)
	{
		int count = triangles.Count;
		for (int i = 0; i < count; i += 3)
		{
			TesselateTriangle(vertices, triangles, i, threshold);
		}
	}

	private void TesselateTriangle(List<Vector2> vertices, List<int> triangles, int i, float threshold)
	{
		Vector2 vector = vertices[triangles[i]];
		Vector2 vector2 = vertices[triangles[i + 1]];
		Vector2 vector3 = vertices[triangles[i + 2]];
		float sqrMagnitude = (vector - vector2).sqrMagnitude;
		float sqrMagnitude2 = (vector2 - vector3).sqrMagnitude;
		float sqrMagnitude3 = (vector3 - vector).sqrMagnitude;
		if (sqrMagnitude > threshold || sqrMagnitude2 > threshold || sqrMagnitude3 > threshold)
		{
			int num = 0;
			if (sqrMagnitude2 > sqrMagnitude)
			{
				num = ((sqrMagnitude2 > sqrMagnitude3) ? 1 : 2);
			}
			else if (sqrMagnitude3 > sqrMagnitude)
			{
				num = 2;
			}
			int num2 = (num + 1) % 3;
			Vector2 item = (vertices[triangles[i + num]] + vertices[triangles[i + num2]]) * 0.5f;
			int count = vertices.Count;
			vertices.Add(item);
			int item2 = triangles[i + num2];
			triangles[i + num2] = count;
			int count2 = triangles.Count;
			triangles.Add(count);
			triangles.Add(item2);
			triangles.Add(triangles[i + (num + 2) % 3]);
			TesselateTriangle(vertices, triangles, i, threshold);
			TesselateTriangle(vertices, triangles, count2, threshold);
		}
	}

	public void TesselatePolygon(float gridSize, float y, IList<Vector2> polygon, List<Vector3> p, List<int> t)
	{
		Vector2[] offset = polygon.GetOffset(0f - gridSize - 0.1f);
		Rect bounds = ((IList<Vector2>)offset).GetBounds();
		int num = Mathf.CeilToInt(bounds.width / gridSize);
		int num2 = Mathf.CeilToInt(bounds.height / gridSize);
		int[,] array = new int[num, num2];
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < num2; j++)
			{
				Vector3 vector = new Vector3(bounds.xMin + (float)i * gridSize, y, bounds.yMin + (float)j * gridSize);
				if (Utilities.IsInside(vector.FlattenVector3(), offset))
				{
					array[i, j] = p.Count;
					p.Add(vector);
				}
				else
				{
					array[i, j] = -1;
				}
			}
		}
		for (int k = 0; k < num - 1; k++)
		{
			for (int l = 0; l < num2 - 1; l++)
			{
				int num3 = array[k, l];
				int num4 = array[k + 1, l];
				int num5 = array[k + 1, l + 1];
				int num6 = array[k, l + 1];
				if (num3 >= 0 && num4 >= 0 && num5 >= 0 && num6 >= 0)
				{
					t.Add(num5);
					t.Add(num4);
					t.Add(num3);
					t.Add(num6);
					t.Add(num5);
					t.Add(num3);
				}
			}
		}
	}

	private void Update()
	{
		if (!GameSettings.Instance.IsReferenceNull())
		{
			LakeRendBottom.enabled = GameSettings.Instance.ActiveFloor >= 0;
			LakeRendWater.enabled = GameSettings.Instance.ActiveFloor >= 0;
		}
	}

	public List<Vector2> OffsetBounds(IList<Vector2> input, float offsetPercent, float offsetMax)
	{
		List<Vector2> list = new List<Vector2>();
		float[] array = new float[input.Count];
		for (int i = 0; i < input.Count; i++)
		{
			Vector2 vector = input[(i == 0) ? (input.Count - 1) : (i - 1)];
			Vector2 vector2 = input[i];
			Vector2 vector3 = input[(i + 1) % input.Count];
			Vector2 vector4 = (vector + vector3) * 0.5f - vector2;
			if (vector4 == Vector2.zero)
			{
				vector4 = (vector3 - vector).Turn90();
			}
			else if (Utilities.IsLeft(vector, vector3, vector2) > 0)
			{
				vector4 = -vector4;
			}
			vector4 = vector4.normalized;
			float num = offsetMax / offsetPercent;
			Vector2 p = vector2 + vector4 * num;
			for (int j = 0; j < input.Count - 2; j++)
			{
				Vector2 q = input[(i + j + 1) % input.Count];
				Vector2 q2 = input[(i + j + 2) % input.Count];
				Vector2? lineIntersection = Utilities.GetLineIntersection(vector2, p, q, q2);
				if (lineIntersection.HasValue)
				{
					float magnitude = (vector2 - lineIntersection.Value).magnitude;
					if (magnitude < num)
					{
						num = magnitude;
						p = vector2 + vector4 * magnitude;
					}
				}
			}
			array[i] = num * offsetPercent;
		}
		for (int k = 0; k < array.Length; k++)
		{
			Vector2 first = input[(k == 0) ? (input.Count - 1) : (k - 1)];
			Vector2 second = input[k];
			Vector2 third = input[(k + 1) % input.Count];
			float offset = (array[k] + array[(k == 0) ? (array.Length - 1) : (k - 1)] + array[(k + 1) % array.Length]) / 3f;
			list.Add(Utilities.GetOffset(first, second, third, offset, true));
		}
		return list;
	}

	public void GenerateMeshes()
	{
		if (LakeRendBottom != null)
		{
			UnityEngine.Object.Destroy(LakeRendBottom.GetComponent<MeshFilter>().sharedMesh);
			UnityEngine.Object.Destroy(LakeRendWater.GetComponent<MeshFilter>().sharedMesh);
			UnityEngine.Object.Destroy(LakeRendBottom.gameObject);
			UnityEngine.Object.Destroy(LakeRendWater.gameObject);
		}
		Mesh mesh = new Mesh();
		List<Vector3> list = new List<Vector3>();
		List<int> list2 = new List<int>();
		TesselatePolygon(TexelSize, -1f, LakeBounds, list, list2);
		mesh.SetVertices(list);
		mesh.SetTriangles(list2, 0);
		mesh.uv = GenerateEdgeDistance(list, LakeBounds);
		mesh.normals = list.SelectInPlace((Vector3 x) => Vector3.up);
		LakeRendWater = CreateObject("Water", mesh, TimeOfDay.Instance.WaterMat, true);
		Mesh mesh2 = new Mesh();
		list.Clear();
		list2.Clear();
		list.AddRange(from x in OffsetBounds(LakeBounds, 0.25f, 8f)
			select x.ToVector3(-20f));
		list.AddRange(LakeBounds.Select((Vector2 x) => x.ToVector3(0f)));
		for (int num = 0; num < LakeBounds.Length; num++)
		{
			int num2 = (num + 1) % LakeBounds.Length;
			list2.Add(num);
			list2.Add(num2);
			list2.Add(num2 + LakeBounds.Length);
			list2.Add(num);
			list2.Add(num2 + LakeBounds.Length);
			list2.Add(num + LakeBounds.Length);
		}
		mesh2.SetVertices(list);
		mesh2.SetTriangles(list2, 0);
		mesh2.RecalculateNormals();
		LakeRendBottom = CreateObject("bottom", mesh2, BottomMat);
		LakePoly = base.gameObject.AddComponent<MeshFilter>();
		Mesh mesh3 = new Mesh();
		Triangulator triangulator = new Triangulator(LakeBounds);
		mesh3.vertices = LakeBounds.SelectInPlace((Vector2 x) => x.ToVector3(0f));
		mesh3.triangles = triangulator.Triangulate();
		LakePoly.sharedMesh = mesh3;
	}

	private Vector2[] GenerateEdgeDistance(List<Vector3> ps, Vector2[] bounds)
	{
		Vector2[] array = new Vector2[ps.Count];
		float[] array2 = new float[bounds.Length];
		float num = 0f;
		for (int i = 0; i < bounds.Length; i++)
		{
			int num2 = (i + 1) % bounds.Length;
			Vector2 vector = bounds[i];
			Vector2 vector2 = bounds[num2];
			array2[i] = num + (vector2 - vector).magnitude;
			num = array2[i];
		}
		float num3 = num / 2f;
		for (int j = 0; j < bounds.Length; j++)
		{
			if (array2[j] > num3)
			{
				array2[j] = num - array2[j];
			}
		}
		for (int k = 0; k < ps.Count; k++)
		{
			Vector2 vector3 = ps[k].FlattenVector3();
			float num4 = float.MaxValue;
			float y = 0f;
			for (int l = 0; l < bounds.Length; l++)
			{
				int num5 = (l + 1) % bounds.Length;
				Vector2 vector4 = bounds[l];
				Vector2 vector5 = bounds[num5];
				float num6 = Mathf.Clamp01(Utilities.ProjectToLineEndlessMag(vector3, vector4, vector5, false));
				Vector2 vector6 = vector4 + (vector5 - vector4) * num6;
				float magnitude = (vector3 - vector6).magnitude;
				if (magnitude < num4)
				{
					y = Mathf.Lerp(array2[l], array2[num5], num6);
					num4 = magnitude;
				}
			}
			array[k] = new Vector2(Utilities.IsInside(vector3, bounds) ? (1f - Mathf.Clamp01(num4 / 6f)) : 1f, y);
		}
		return array;
	}

	public Renderer CreateObject(string name, Mesh m, Material mat, bool grass = false)
	{
		GameObject gameObject = new GameObject(name);
		MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
		if (grass)
		{
			MeshRend = meshFilter;
		}
		meshFilter.sharedMesh = m;
		MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
		meshRenderer.sharedMaterial = mat;
		meshRenderer.shadowCastingMode = ShadowCastingMode.Off;
		gameObject.transform.SetParent(base.transform);
		return meshRenderer;
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		UnityEngine.Object.Destroy(LakeRendBottom.GetComponent<MeshFilter>().sharedMesh);
		UnityEngine.Object.Destroy(LakeRendWater.GetComponent<MeshFilter>().sharedMesh);
		UnityEngine.Object.Destroy(LakePoly.sharedMesh);
		if (TimeOfDay.Instance != null)
		{
			TimeOfDay.Instance.GroundTopDirty = true;
		}
	}

	public override Rect GetArea()
	{
		return LakeArea;
	}

	public override Vector2[] GetNavMesh()
	{
		return LakeBounds;
	}

	public override Vector2 Center()
	{
		return LakeArea.center;
	}

	public override MeshFilter GetGrassMesh()
	{
		return LakePoly;
	}

	public override float GetHeight()
	{
		return 0f;
	}

	protected override object DeserializeMe(WriteDictionary dictionary, bool loading, LoadType networkMode)
	{
		base.DeserializeMe(dictionary, loading, networkMode);
		LakeBounds = dictionary["Bounds"] as Vector2[];
		InitStuff();
		if (TimeOfDay.Instance != null)
		{
			TimeOfDay.Instance.GroundTopDirty = true;
		}
		return this;
	}

	protected override void SerializeMe(WriteDictionary dictionary, GameReader.NewLoadMode mode, LoadType networkMode, bool checkDIDs)
	{
		base.SerializeMe(dictionary, mode, networkMode, checkDIDs);
		dictionary["Bounds"] = LakeBounds;
	}

	public override bool RemoveOnBuy()
	{
		return false;
	}

	public override string WriteName()
	{
		return "Lake";
	}

	public override bool MakeHole()
	{
		return true;
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.green;
		for (int i = 0; i < Nodes.Count; i++)
		{
			TriangleNode triangleNode = Nodes[i];
			Gizmos.DrawLine(triangleNode.Points[0].ToVector3(0f), triangleNode.Points[1].ToVector3(0f));
			Gizmos.DrawLine(triangleNode.Points[1].ToVector3(0f), triangleNode.Points[2].ToVector3(0f));
			Gizmos.DrawLine(triangleNode.Points[2].ToVector3(0f), triangleNode.Points[0].ToVector3(0f));
		}
	}
}
