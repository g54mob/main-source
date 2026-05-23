using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
[ExecuteInEditMode]
public class PathMesher : MonoBehaviour
{
	public enum UnwrapMode
	{
		XZWorldSpace = 0,
		River = 1
	}

	[Serializable]
	public class PathPoint
	{
		public Vector3 position;

		public float width;

		public PathPoint(Vector3 _position, float _width)
		{
			position = _position;
			width = _width;
		}
	}

	private MeshFilter meshFilter;

	private MeshCollider meshCollider;

	public int subdivisions = 3;

	public float vertDistance = 0.2f;

	public int endCapSubdivisions = 3;

	public float widthWhobble = 0.5f;

	public float positionWhobble = 0.5f;

	public UnwrapMode uvUnwrapMode;

	public float uvScale = 0.01f;

	public bool topNormalsAlwaysFaceDirectlyUp;

	public Vector3 extrudeDownOffset;

	public bool vertical;

	public bool loop;

	public bool flipNormals;

	private List<FakeTransorm> transformsRemember = new List<FakeTransorm>();

	private List<PathPoint> pathPoints = new List<PathPoint>();

	public void UpdateMesh()
	{
		pathPoints.Clear();
		for (int i = 0; i < base.transform.childCount; i++)
		{
			Transform child = base.transform.GetChild(i);
			pathPoints.Add(new PathPoint(child.localPosition, child.localScale.x));
		}
		if (pathPoints.Count < 2)
		{
			return;
		}
		if (loop)
		{
			Transform child2 = base.transform.GetChild(0);
			pathPoints.Add(new PathPoint(child2.localPosition, child2.localScale.x));
		}
		meshFilter = GetComponent<MeshFilter>();
		meshCollider = GetComponent<MeshCollider>();
		Mesh mesh = new Mesh();
		List<Vector3> list = new List<Vector3>();
		List<Vector2> uvs = new List<Vector2>();
		List<int> list2 = new List<int>();
		List<int> list3 = new List<int>();
		List<PathPoint> _pathOriginal = new List<PathPoint>();
		InterpolateModifyer(pathPoints, _pathOriginal, subdivisions);
		if (vertDistance > 0.1f)
		{
			ResampleModifyer(ref _pathOriginal, vertDistance, vertDistance / 10f);
		}
		AddRoundedEndsModifyer(_pathOriginal, endCapSubdivisions);
		WhobbleModifyer(_pathOriginal, widthWhobble, positionWhobble);
		float num = 0f;
		for (int j = 0; j < _pathOriginal.Count; j++)
		{
			if (_pathOriginal.Count <= 1)
			{
				break;
			}
			Vector3 forwards = GetForwards(j, _pathOriginal);
			Vector3 vector = Quaternion.Euler(0f, 90f, 0f) * forwards * _pathOriginal[j].width;
			Vector3 vector2 = Quaternion.Euler(0f, -90f, 0f) * forwards * _pathOriginal[j].width;
			if (vertical)
			{
				vector = Vector3.up * _pathOriginal[j].width;
				vector2 = Vector3.down * _pathOriginal[j].width;
			}
			AddUnwrappedVertTop(_pathOriginal[j].position + vector, list, uvs, num, 0f - _pathOriginal[j].width);
			AddUnwrappedVertTop(_pathOriginal[j].position + vector2, list, uvs, num, _pathOriginal[j].width);
			if (j > 0)
			{
				num += (_pathOriginal[j].position - _pathOriginal[j - 1].position).magnitude;
			}
		}
		int count = list.Count;
		if (extrudeDownOffset.y != 0f)
		{
			num = 0f;
			for (int k = 0; k <= 1; k++)
			{
				int num2 = 0;
				for (int l = k; l < count - 2; l += 2)
				{
					AddUnwrappedVertTop(list[l], list, uvs, num, 0f);
					AddUnwrappedVertTop(list[l] + extrudeDownOffset, list, uvs, num, 0f - extrudeDownOffset.magnitude);
					num += (_pathOriginal[num2 + 1].position - _pathOriginal[num2].position).magnitude;
					num2++;
					AddUnwrappedVertTop(list[l + 2], list, uvs, num, 0f);
					AddUnwrappedVertTop(list[l + 2] + extrudeDownOffset, list, uvs, num, 0f - extrudeDownOffset.magnitude);
				}
			}
		}
		Vector3[] normals = new Vector3[list.Count];
		for (int m = 0; m < _pathOriginal.Count - 1; m++)
		{
			if (_pathOriginal.Count <= 1)
			{
				break;
			}
			int num3 = m * 2;
			ConnectTriangle(num3 + 2, num3 + 1, num3, list2, normals, list, topNormalsAlwaysFaceDirectlyUp, vertical);
			ConnectTriangle(num3 + 1, num3 + 2, num3 + 3, list2, normals, list, topNormalsAlwaysFaceDirectlyUp, vertical);
		}
		if (extrudeDownOffset.y != 0f)
		{
			int num4 = count;
			for (int n = 0; n < count - 2; n += 2)
			{
				ConnectTriangle(num4, num4 + 1, num4 + 2, list3, normals, list, _makeNormalsFaceUp: false, _showFacesFacedDownwards: true);
				ConnectTriangle(num4 + 3, num4 + 2, num4 + 1, list3, normals, list, _makeNormalsFaceUp: false, _showFacesFacedDownwards: true);
				num4 += 4;
			}
			int num5 = num4;
			for (int num6 = 1; num6 < count - 2; num6 += 2)
			{
				ConnectTriangle(num4 + 2, num4 + 1, num4, list3, normals, list, _makeNormalsFaceUp: false, _showFacesFacedDownwards: true);
				ConnectTriangle(num4 + 1, num4 + 2, num4 + 3, list3, normals, list, _makeNormalsFaceUp: false, _showFacesFacedDownwards: true);
				num4 += 4;
			}
			ConnectTriangle(num5, count + 1, count, list3, normals, list, _makeNormalsFaceUp: false, _showFacesFacedDownwards: true);
			ConnectTriangle(count + 1, num5, num5 + 1, list3, normals, list, _makeNormalsFaceUp: false, _showFacesFacedDownwards: true);
			ConnectTriangle(num5 - 2, num5 - 1, num4 - 2, list3, normals, list, _makeNormalsFaceUp: false, _showFacesFacedDownwards: true);
			ConnectTriangle(num4 - 1, num4 - 2, num5 - 1, list3, normals, list, _makeNormalsFaceUp: false, _showFacesFacedDownwards: true);
		}
		mesh.subMeshCount = ((extrudeDownOffset.y == 0f) ? 1 : 2);
		mesh.SetVertices(list);
		mesh.SetTriangles(list2, 0);
		if (extrudeDownOffset.y != 0f)
		{
			mesh.SetTriangles(list3, 1);
		}
		mesh.SetUVs(0, uvs);
		mesh.SetNormals(normals);
		mesh.RecalculateBounds();
		if ((bool)meshFilter)
		{
			meshFilter.sharedMesh = mesh;
		}
		if ((bool)meshCollider)
		{
			meshCollider.sharedMesh = mesh;
		}
	}

	public void ConnectTriangle(int _vertA, int _vertB, int _vertC, List<int> _tris, Vector3[] _normals, List<Vector3> _verts, bool _makeNormalsFaceUp, bool _showFacesFacedDownwards)
	{
		if (flipNormals)
		{
			int num = _vertA;
			_vertA = _vertC;
			_vertC = num;
		}
		Vector3 normalized = Vector3.Cross(_verts[_vertA] - _verts[_vertB], _verts[_vertC] - _verts[_vertB]).normalized;
		if (normalized.y > 0f || _showFacesFacedDownwards)
		{
			_tris.Add(_vertC);
			_tris.Add(_vertB);
			_tris.Add(_vertA);
			if (_makeNormalsFaceUp)
			{
				_normals[_vertC] = Vector3.up;
				_normals[_vertB] = Vector3.up;
				_normals[_vertA] = Vector3.up;
			}
			else
			{
				_normals[_vertC] = normalized;
				_normals[_vertB] = normalized;
				_normals[_vertA] = normalized;
			}
		}
	}

	public void AddUnwrappedVertTop(Vector3 _pos, List<Vector3> _verts, List<Vector2> _uvs, float _distanceTraveled, float _width)
	{
		_verts.Add(_pos);
		if (uvUnwrapMode == UnwrapMode.XZWorldSpace)
		{
			_pos = base.transform.localToWorldMatrix.MultiplyPoint(_pos);
			_uvs.Add(new Vector2(_pos.x * uvScale, _pos.z * uvScale));
		}
		else if (uvUnwrapMode == UnwrapMode.River)
		{
			_uvs.Add(new Vector2(_distanceTraveled * uvScale, _width * uvScale));
		}
	}

	public void InterpolateModifyer(List<PathPoint> _pathIn, List<PathPoint> _pathOut, int _subdivisions)
	{
		for (int i = 0; i < _pathIn.Count - 1; i++)
		{
			for (int j = 0; j < _subdivisions; j++)
			{
				float num = (float)j / (float)_subdivisions;
				float magnitude = (_pathIn[i + 1].position - _pathIn[i].position).magnitude;
				Vector3 forwards = GetForwards(i, _pathIn);
				Vector3 forwards2 = GetForwards(i + 1, _pathIn);
				Vector3 a = _pathIn[i].position + num * forwards * magnitude;
				Vector3 b = _pathIn[i + 1].position - (1f - num) * forwards2 * magnitude;
				Vector3 position = Vector3.Lerp(a, b, Mathf.SmoothStep(0f, 1f, num));
				float width = Mathf.SmoothStep(_pathIn[i].width, _pathIn[i + 1].width, num);
				PathPoint item = new PathPoint(position, width);
				_pathOut.Add(item);
			}
		}
		_pathOut.Add(_pathIn[_pathIn.Count - 1]);
	}

	public void ResampleModifyer(ref List<PathPoint> _pathOriginal, float _maxDistance, float _stepSize = 0.1f)
	{
		if (_pathOriginal.Count < 2)
		{
			return;
		}
		List<PathPoint> list = new List<PathPoint>();
		list.Add(_pathOriginal[0]);
		float num = 0f;
		for (int i = 0; i < _pathOriginal.Count - 1; i++)
		{
			int num2 = (int)Mathf.Ceil((_pathOriginal[i].position - _pathOriginal[i + 1].position).magnitude / _stepSize);
			for (int j = 0; j < num2; j++)
			{
				num += _stepSize;
				if (num >= _maxDistance)
				{
					float t = (float)j / (float)num2;
					Vector3 position = Vector3.Lerp(_pathOriginal[i].position, _pathOriginal[i + 1].position, t);
					float width = Mathf.Lerp(_pathOriginal[i].width, _pathOriginal[i + 1].width, t);
					num = 0f;
					list.Add(new PathPoint(position, width));
				}
			}
		}
		list.Add(_pathOriginal[_pathOriginal.Count - 1]);
		_pathOriginal = list;
	}

	public void WhobbleModifyer(List<PathPoint> _path, float _widthAmount, float _posAmount)
	{
		UnityEngine.Random.InitState(_path.Count * 7);
		for (int i = 0; i < _path.Count; i++)
		{
			_path[i].position += new Vector3(UnityEngine.Random.value - 0.5f, 0f, UnityEngine.Random.value - 0.5f) * _posAmount;
			_path[i].width *= 1f + (UnityEngine.Random.value - 0.5f) * _widthAmount;
		}
	}

	public void AddRoundedEndsModifyer(List<PathPoint> _pathModify, int _interpolations)
	{
		Vector3 position = _pathModify[0].position;
		Vector3 vector = -GetForwards(0, _pathModify);
		float width = _pathModify[0].width;
		Vector3 position2 = _pathModify[_pathModify.Count - 1].position;
		Vector3 forwards = GetForwards(_pathModify.Count - 1, _pathModify);
		float width2 = _pathModify[_pathModify.Count - 1].width;
		for (int i = 1; i < _interpolations; i++)
		{
			float f = (float)i / (float)_interpolations;
			f = Mathf.Pow(f, 0.5f);
			float width3 = width * (1f - Mathf.Pow(f, 3f));
			float num = width * f;
			_pathModify.Insert(0, new PathPoint(position + num * vector, width3));
		}
		for (int j = 1; j < _interpolations; j++)
		{
			float f2 = (float)j / (float)_interpolations;
			f2 = Mathf.Pow(f2, 0.5f);
			float width4 = width2 * (1f - Mathf.Pow(f2, 3f));
			float num2 = width2 * f2;
			_pathModify.Add(new PathPoint(position2 + num2 * forwards, width4));
		}
	}

	private Vector3 GetForwards(int i, List<PathPoint> path, bool _xzPlaneOnly = true)
	{
		Vector3 result = ((i == 0) ? (path[i + 1].position - path[i].position).normalized : ((i != path.Count - 1) ? (path[i + 1].position - path[i - 1].position).normalized : (path[i].position - path[i - 1].position).normalized));
		if (_xzPlaneOnly)
		{
			result = new Vector3(result.x, 0f, result.z).normalized;
		}
		return result;
	}

	public void Nullify()
	{
		List<Vector3> list = new List<Vector3>();
		for (int i = 0; i < base.transform.childCount; i++)
		{
			Transform child = base.transform.GetChild(i);
			list.Add(child.transform.position);
		}
		base.transform.position = Vector3.zero;
		for (int j = 0; j < base.transform.childCount; j++)
		{
			base.transform.GetChild(j).transform.position = list[j];
		}
	}
}
