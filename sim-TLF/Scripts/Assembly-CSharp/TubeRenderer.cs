using System;
using UnityEngine;

[ExecuteInEditMode]
public class TubeRenderer : MonoBehaviour
{
	[SerializeField]
	private Vector3[] _positions;

	[SerializeField]
	private int _sides;

	[SerializeField]
	private float _radiusOne;

	[SerializeField]
	private float _radiusTwo;

	[SerializeField]
	private bool _useWorldSpace = true;

	[SerializeField]
	private bool _useTwoRadii;

	private Vector3[] _vertices;

	private Mesh _mesh;

	private MeshFilter _meshFilter;

	private MeshRenderer _meshRenderer;

	public Material material
	{
		get
		{
			return _meshRenderer.material;
		}
		set
		{
			_meshRenderer.material = value;
		}
	}

	private void Awake()
	{
		_meshFilter = GetComponent<MeshFilter>();
		if (_meshFilter == null)
		{
			_meshFilter = base.gameObject.AddComponent<MeshFilter>();
		}
		_meshRenderer = GetComponent<MeshRenderer>();
		if (_meshRenderer == null)
		{
			_meshRenderer = base.gameObject.AddComponent<MeshRenderer>();
		}
		_mesh = new Mesh();
		_meshFilter.mesh = _mesh;
	}

	private void OnEnable()
	{
		_meshRenderer.enabled = true;
	}

	private void OnDisable()
	{
		_meshRenderer.enabled = false;
	}

	private void Update()
	{
		GenerateMesh();
	}

	private void OnValidate()
	{
		_sides = Mathf.Max(3, _sides);
	}

	public void SetPositions(Vector3[] positions)
	{
		_positions = positions;
		GenerateMesh();
	}

	private void GenerateMesh()
	{
		if (_mesh == null || _positions == null || _positions.Length <= 1)
		{
			_mesh = new Mesh();
			return;
		}
		int num = _sides * _positions.Length;
		if (_vertices == null || _vertices.Length != num)
		{
			_vertices = new Vector3[num];
			int[] triangles = GenerateIndices();
			Vector2[] uv = GenerateUVs();
			if (num > _mesh.vertexCount)
			{
				_mesh.vertices = _vertices;
				_mesh.triangles = triangles;
				_mesh.uv = uv;
			}
			else
			{
				_mesh.triangles = triangles;
				_mesh.vertices = _vertices;
				_mesh.uv = uv;
			}
		}
		int num2 = 0;
		for (int i = 0; i < _positions.Length; i++)
		{
			Vector3[] array = CalculateCircle(i);
			foreach (Vector3 vector in array)
			{
				_vertices[num2++] = (_useWorldSpace ? base.transform.InverseTransformPoint(vector) : vector);
			}
		}
		_mesh.vertices = _vertices;
		_mesh.RecalculateNormals();
		_mesh.RecalculateBounds();
		_meshFilter.mesh = _mesh;
	}

	private Vector2[] GenerateUVs()
	{
		Vector2[] array = new Vector2[_positions.Length * _sides];
		for (int i = 0; i < _positions.Length; i++)
		{
			for (int j = 0; j < _sides; j++)
			{
				int num = i * _sides + j;
				float x = (float)j / ((float)_sides - 1f);
				float y = (float)i / ((float)_positions.Length - 1f);
				array[num] = new Vector2(x, y);
			}
		}
		return array;
	}

	private int[] GenerateIndices()
	{
		int[] array = new int[_positions.Length * _sides * 2 * 3];
		int num = 0;
		for (int i = 1; i < _positions.Length; i++)
		{
			for (int j = 0; j < _sides; j++)
			{
				int num2 = i * _sides + j;
				int num3 = num2 - _sides;
				array[num++] = num3;
				array[num++] = ((j == _sides - 1) ? (num2 - (_sides - 1)) : (num2 + 1));
				array[num++] = num2;
				array[num++] = ((j == _sides - 1) ? (num3 - (_sides - 1)) : (num3 + 1));
				array[num++] = ((j == _sides - 1) ? (num2 - (_sides - 1)) : (num2 + 1));
				array[num++] = num3;
			}
		}
		return array;
	}

	private Vector3[] CalculateCircle(int index)
	{
		int num = 0;
		Vector3 zero = Vector3.zero;
		if (index > 0)
		{
			zero += (_positions[index] - _positions[index - 1]).normalized;
			num++;
		}
		if (index < _positions.Length - 1)
		{
			zero += (_positions[index + 1] - _positions[index]).normalized;
			num++;
		}
		zero = (zero / num).normalized;
		Vector3 normalized = Vector3.Cross(zero, zero + new Vector3(0.123564f, 0.34675f, 0.756892f)).normalized;
		Vector3 normalized2 = Vector3.Cross(zero, normalized).normalized;
		Vector3[] array = new Vector3[_sides];
		float num2 = 0f;
		float num3 = MathF.PI * 2f / (float)_sides;
		float t = (float)index / ((float)_positions.Length - 1f);
		float num4 = (_useTwoRadii ? Mathf.Lerp(_radiusOne, _radiusTwo, t) : _radiusOne);
		for (int i = 0; i < _sides; i++)
		{
			float num5 = Mathf.Cos(num2);
			float num6 = Mathf.Sin(num2);
			array[i] = _positions[index] + normalized * num5 * num4 + normalized2 * num6 * num4;
			num2 += num3;
		}
		return array;
	}
}
