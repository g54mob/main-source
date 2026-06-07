using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class TreeBatch : MonoBehaviour
{
	[NonSerialized]
	private HashSet<TreeInstance> _trees = new HashSet<TreeInstance>();

	public Vector2 Center;

	public bool IsVisible = true;

	public bool HasMesh;

	public MeshFilter TreeMesh;

	public Material TreeMaterial;

	public int MaxTrees;

	public int Count;

	public bool Dirty;

	private Color _groupColor;

	private void Start()
	{
		_groupColor = Utilities.HSVToRGB(UnityEngine.Random.Range(0, 360), 0.8f, 1f).ToVector4(1f);
	}

	public bool CanAdd(TreeInstance tree)
	{
		if (_trees.Contains(tree))
		{
			return true;
		}
		return _trees.Count < MaxTrees;
	}

	public void AddTree(TreeInstance tree)
	{
		if (_trees.Count == 0)
		{
			Center = tree.GetPos();
		}
		_trees.Add(tree);
		tree.BelongsTo = this;
		Dirty = true;
		SVector3[] list = _trees.Select((TreeInstance x) => x.Position).ToArray();
		Center = new Vector2(list.MedianNonThreaded((SVector3 x) => x.x), list.MedianNonThreaded((SVector3 x) => x.z));
		Count = _trees.Count;
	}

	public void RemoveTree(TreeInstance tree)
	{
		if (_trees.Contains(tree))
		{
			_trees.Remove(tree);
			tree.BelongsTo = null;
			Dirty = true;
			Count = _trees.Count;
		}
	}

	private void Update()
	{
		bool flag = !GameSettings.Instance.IsReferenceNull() && GameSettings.Instance.ActiveFloor > -1;
		if (HasMesh && flag != IsVisible)
		{
			TreeMesh.gameObject.SetActive(flag);
			IsVisible = flag;
		}
	}

	public bool GenerateMesh()
	{
		if (!Dirty)
		{
			return true;
		}
		if (_trees.Count == 0)
		{
			return false;
		}
		Dirty = false;
		CombineInstance[] array = new CombineInstance[_trees.Count];
		int num = 0;
		foreach (TreeInstance tree in _trees)
		{
			StaticTree treeMesh = tree.TreeMesh;
			array[num] = new CombineInstance
			{
				mesh = RandomUVs(treeMesh, tree, tree.Transform),
				transform = tree.Transform
			};
			num++;
		}
		if (!HasMesh)
		{
			TreeMesh = CreateMesh("MergedTrees", TreeMaterial);
			HasMesh = true;
		}
		CombineMeshes(TreeMesh, array, true);
		return true;
	}

	private void CombineMeshes(MeshFilter filter, CombineInstance[] combines, bool destroyCombine)
	{
		if (filter.sharedMesh != null)
		{
			UnityEngine.Object.Destroy(filter.sharedMesh);
		}
		Mesh mesh = new Mesh();
		mesh.CombineMeshes(combines);
		filter.sharedMesh = mesh;
		if (destroyCombine)
		{
			foreach (CombineInstance combineInstance in combines)
			{
				UnityEngine.Object.Destroy(combineInstance.mesh);
			}
		}
	}

	private MeshFilter CreateMesh(string batchName, Material mat)
	{
		GameObject obj = new GameObject(batchName);
		obj.SetActive(IsVisible);
		obj.isStatic = true;
		MeshFilter result = obj.AddComponent<MeshFilter>();
		MeshRenderer meshRenderer = obj.AddComponent<MeshRenderer>();
		meshRenderer.sharedMaterial = mat;
		meshRenderer.reflectionProbeUsage = ReflectionProbeUsage.Off;
		obj.transform.parent = base.transform;
		return result;
	}

	private static Mesh RandomUVs(StaticTree mesh, TreeInstance tree, Matrix4x4 transform)
	{
		Mesh mesh2 = new Mesh();
		Vector2[] uv = mesh.TreeMesh.sharedMesh.uv;
		for (int i = 0; i < uv.Length; i++)
		{
			uv[i] = new Vector2(tree.LeaveOffset, uv[i].y - uv[i].x * tree.LeaveOffset);
		}
		mesh2.SetVertices(mesh.Verts);
		mesh2.SetNormals(mesh.Norms);
		mesh2.SetTangents(mesh.Tans);
		if (transform.MultiplyVector(Vector3.one) != Vector3.one)
		{
			List<Color> list = new List<Color>(mesh.Colors);
			for (int j = 0; j < list.Count; j++)
			{
				Color color = list[j];
				Vector3 vector = transform.MultiplyVector(new Vector3(color.r - 0.5f, color.g - 0.5f, color.b - 0.5f) * 4f) * 0.25f + Vector3.one * 0.5f;
				list[j] = new Color(vector.x, vector.y, vector.z);
			}
			mesh2.SetColors(list);
		}
		else
		{
			mesh2.SetColors(mesh.Colors);
		}
		mesh2.uv = uv;
		mesh2.SetUVs(1, mesh.UV2s);
		mesh2.SetUVs(2, mesh.UV3s);
		mesh2.SetTriangles(mesh.Tris, 0);
		return mesh2;
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = _groupColor;
		foreach (TreeInstance tree in _trees)
		{
			Gizmos.DrawSphere(tree.Position + Vector3.up * 3f, 1f);
		}
	}
}
