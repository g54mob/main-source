using System;
using System.Collections.Generic;
using UnityEngine;

public class StaticTree : MonoBehaviour
{
	public MeshFilter TreeMesh;

	public Mesh NoLeaf;

	public Vector3[] BirdPoints = new Vector3[0];

	public bool Cold;

	public bool Temperate;

	public bool Warm;

	[NonSerialized]
	private bool _Initialized;

	private List<Vector2> _uv2s;

	private List<Vector2> _uv3s;

	private List<Vector3> _verts;

	private List<Vector3> _norms;

	private List<Vector4> _tans;

	private List<int> _tris;

	private List<Color> _colors;

	public List<Vector2> UV2s
	{
		get
		{
			Init();
			return _uv2s;
		}
	}

	public List<Vector2> UV3s
	{
		get
		{
			Init();
			return _uv3s;
		}
	}

	public List<Vector3> Verts
	{
		get
		{
			Init();
			return _verts;
		}
	}

	public List<Vector3> Norms
	{
		get
		{
			Init();
			return _norms;
		}
	}

	public List<Vector4> Tans
	{
		get
		{
			Init();
			return _tans;
		}
	}

	public List<int> Tris
	{
		get
		{
			Init();
			return _tris;
		}
	}

	public List<Color> Colors
	{
		get
		{
			Init();
			return _colors;
		}
	}

	public Bounds bounds
	{
		get
		{
			return TreeMesh.sharedMesh.bounds;
		}
	}

	private void Init()
	{
		if (_Initialized)
		{
			return;
		}
		_Initialized = true;
		Mesh sharedMesh = TreeMesh.sharedMesh;
		_verts = new List<Vector3>();
		_norms = new List<Vector3>();
		_tans = new List<Vector4>();
		_tris = new List<int>();
		_uv2s = new List<Vector2>();
		_uv3s = new List<Vector2>();
		sharedMesh.GetVertices(_verts);
		sharedMesh.GetNormals(_norms);
		sharedMesh.GetTangents(_tans);
		sharedMesh.GetTriangles(_tris, 0);
		sharedMesh.GetUVs(1, _uv2s);
		sharedMesh.GetUVs(2, _uv3s);
		_colors = new List<Color>(_verts.Count);
		Vector3[] array = ((NoLeaf == null) ? null : NoLeaf.vertices);
		for (int i = 0; i < _verts.Count; i++)
		{
			if (NoLeaf != null)
			{
				Vector3 vector = (array[i] - _verts[i]) * 0.25f + Vector3.one * 0.5f;
				_colors.Add(new Color(vector.x, vector.y, vector.z));
			}
			else
			{
				_colors.Add(new Color(0.5f, 0.5f, 0.5f));
			}
		}
	}

	public bool ValidFor(GameData.ClimateType climate)
	{
		switch (climate)
		{
		case GameData.ClimateType.Cold:
			return Cold;
		case GameData.ClimateType.Temperate:
			return Temperate;
		case GameData.ClimateType.Warm:
			return Warm;
		default:
			return false;
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.magenta;
		Matrix4x4 localToWorldMatrix = base.transform.localToWorldMatrix;
		for (int i = 0; i < BirdPoints.Length; i++)
		{
			Vector3 vector = localToWorldMatrix.MultiplyPoint(BirdPoints[i]);
			Gizmos.DrawLine(vector + Vector3.up * 0.1f, vector + Vector3.down * 0.1f);
			Gizmos.DrawLine(vector + Vector3.left * 0.1f, vector + Vector3.right * 0.1f);
			Gizmos.DrawLine(vector + Vector3.forward * 0.1f, vector + Vector3.back * 0.1f);
		}
	}
}
