using System.Collections.Generic;
using UnityEngine;

public class FOW_Camera : MonoBehaviour
{
	[SerializeField]
	private LayerMask _fogOfWarLayer;

	[SerializeField]
	private MeshFilter _fogOfWarPlane;

	[SerializeField]
	private GameObject _player;

	[SerializeField]
	private float _clearRadius;

	private Mesh _mesh;

	private int _vertexCount;

	private List<Vector3> _vertices;

	private List<Color> _colors;

	private void Start()
	{
		_mesh = _fogOfWarPlane.mesh;
		_vertexCount = _mesh.vertexCount;
		_vertices = new List<Vector3>(_vertexCount);
		_colors = new List<Color>(_vertexCount);
	}

	private void Update()
	{
		Vector3 position = _player.transform.position;
		_mesh.GetVertices(_vertices);
		_mesh.GetColors(_colors);
		for (int i = 0; i < _vertexCount; i++)
		{
			float num = Vector3.Distance(_vertices[i], position);
			if (num < _clearRadius)
			{
				float num2 = num / _clearRadius;
				Color value = _colors[i];
				if (num2 < value.a)
				{
					value.a = num2;
					_colors[i] = value;
				}
			}
		}
		_mesh.SetColors(_colors);
	}

	private Color[] ReturnVertexColors(int count, Color color)
	{
		Color[] array = new Color[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = color;
		}
		return array;
	}
}
