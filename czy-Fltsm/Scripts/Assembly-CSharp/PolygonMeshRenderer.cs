using System.Collections.Generic;
using PajamaLlama.Math;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
public class PolygonMeshRenderer : MonoBehaviour
{
	[SerializeField]
	private MeshFilter _meshFilter;

	[SerializeField]
	private MeshRenderer _meshRenderer;

	[SerializeField]
	private bool _applyInverseTransformPoint = true;

	private void Awake()
	{
		if (!_meshFilter)
		{
			_meshFilter = GetComponent<MeshFilter>();
		}
		if (!_meshRenderer)
		{
			_meshRenderer = GetComponent<MeshRenderer>();
		}
	}

	public void Initialize(IReadOnlyList<Vector2> vertices, Material material = null)
	{
		_meshFilter.mesh = GenerateMesh(vertices);
		if ((bool)material)
		{
			_meshRenderer.sharedMaterial = material;
		}
	}

	private Mesh GenerateMesh(IReadOnlyList<Vector2> polygonVertices, bool applyInverseTransformPoint = true)
	{
		Mesh mesh = new Mesh();
		_ = GameSettings.Instance.BuildableSettings.GridSize;
		int count = polygonVertices.Count;
		int num = polygonVertices.Count + 1;
		int num2 = count;
		float y = 0.01f;
		Vector3 vector = polygonVertices.Average().Vector3TopDown(y);
		Vector3[] array = new Vector3[num];
		array[num - 1] = vector;
		int[] array2 = new int[num2 * 3];
		Vector2[] array3 = new Vector2[num];
		array3[num - 1] = vector.Vector2TopDown();
		Vector3[] array4 = new Vector3[num];
		array4[num - 1] = Vector3.up;
		int num3 = count;
		for (int i = 0; i < num2; i++)
		{
			int num4 = i * 3;
			array[i] = polygonVertices[i].Vector3TopDown(y);
			array2[num4] = i % num2;
			array2[num4 + 1] = (i + 1) % num2;
			array2[num4 + 2] = num3;
			array4[i] = Vector3.up;
			array3[i] = polygonVertices[i];
		}
		if (_applyInverseTransformPoint)
		{
			for (int j = 0; j < array.Length; j++)
			{
				array[j] = base.transform.InverseTransformPoint(array[j]);
			}
		}
		mesh.vertices = array;
		mesh.uv = array3;
		mesh.normals = array4;
		mesh.triangles = array2;
		mesh.RecalculateNormals();
		return mesh;
	}
}
