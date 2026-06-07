using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class MeshCombiner
{
	public string Name;

	private List<Vector4> _tangents = new List<Vector4>();

	private List<Vector3> _vertices = new List<Vector3>();

	private List<Vector3> _normals = new List<Vector3>();

	private List<Vector2> _uv1 = new List<Vector2>();

	private List<Vector2> _uv2 = new List<Vector2>();

	private List<Vector2> _uv3 = new List<Vector2>();

	private List<int> _triangles = new List<int>();

	private List<Color> _colors = new List<Color>();

	public readonly bool UseUV1;

	public readonly bool UseUV2;

	public readonly bool UseUV3;

	public readonly bool UseColor;

	private bool _hasErrored;

	public MeshCombiner(string name, bool useUV1, bool useUV2 = true, bool useColor = false, bool useUV3 = false)
	{
		Name = name;
		UseUV1 = useUV1;
		UseUV2 = useUV1 && useUV2;
		UseUV3 = useUV2 && useUV3;
		UseColor = useColor;
	}

	public void Clear(string name)
	{
		Name = name;
		_tangents.Clear();
		_vertices.Clear();
		_normals.Clear();
		_uv1.Clear();
		_uv2.Clear();
		_triangles.Clear();
		_colors.Clear();
		_hasErrored = false;
	}

	private static void AddToList<T>(List<T> output, IList<T> input, Func<T, T> change, int max = -1)
	{
		if (max == -1)
		{
			max = input.Count;
		}
		int num = Mathf.Max(1, output.Capacity);
		int num2 = output.Count + max;
		while (num < num2)
		{
			num *= 2;
		}
		output.Capacity = num;
		for (int i = 0; i < max; i++)
		{
			output.Add(change(input[i]));
		}
	}

	public static Vector3 ReverseZ(Vector3 input, bool rev)
	{
		if (!rev)
		{
			return input;
		}
		return -input;
	}

	public void AddMesh(Mesh inputMesh, Matrix4x4 transform, Vector2 a, float last, int floor, Vector2 uv2, bool reverseZ = false)
	{
		int count = _vertices.Count;
		int num = inputMesh.vertexCount;
		int num2 = CanAddMore(num);
		if (num2 >= 0 && num2 < 3)
		{
			return;
		}
		transform *= Matrix4x4.TRS(new Vector3(0f, -floor * 2, 0f), Quaternion.identity, Vector3.one);
		if (num2 > 0)
		{
			AddToList(_vertices, inputMesh.vertices, (Vector3 x) => transform.MultiplyPoint(x), num2);
			AddToList(_normals, inputMesh.normals, (Vector3 x) => transform.MultiplyVector(ReverseZ(x, reverseZ)).normalized, num2);
			AddToList(_tangents, inputMesh.tangents, (Vector4 x) => transform.MultiplyVector(ReverseZ(x.FlattenVector4(), reverseZ)).normalized.ToVector4(1f), num2);
			num = num2;
		}
		else
		{
			AddToList(_vertices, inputMesh.vertices, (Vector3 x) => transform.MultiplyPoint(x));
			AddToList(_normals, inputMesh.normals, (Vector3 x) => transform.MultiplyVector(ReverseZ(x, reverseZ)).normalized);
			AddToList(_tangents, inputMesh.tangents, (Vector4 x) => transform.MultiplyVector(ReverseZ(x.FlattenVector4(), reverseZ)).normalized.ToVector4(1f));
		}
		if (UseUV1)
		{
			for (int num3 = 0; num3 < num; num3++)
			{
				Vector3 vector = _vertices[count + num3];
				Vector2 p = new Vector2(vector.x, vector.z);
				float num4 = a.Dist(p) / 2f;
				float y = vector.y / 2f;
				_uv1.Add(new Vector2(last + num4, y));
				if (UseUV2)
				{
					_uv2.Add(uv2);
				}
			}
		}
		int[] triangles = inputMesh.triangles;
		int count2 = _triangles.Count;
		for (int num5 = 0; num5 < triangles.Length; num5 += 3)
		{
			if (num2 < 0 || (triangles[num5] < num2 && triangles[num5 + 1] < num2 && triangles[num5 + 2] < num2))
			{
				_triangles.Add(count + triangles[num5]);
				_triangles.Add(count + triangles[num5 + 1]);
				_triangles.Add(count + triangles[num5 + 2]);
			}
		}
		if (reverseZ)
		{
			_triangles.Reverse(count2, _triangles.Count - count2);
		}
	}

	public void AddTriangleFlatFan(IList<Vector2> points, float y, bool open)
	{
		int count = _vertices.Count;
		int count2 = points.Count;
		if (CanAddMore(count2) < 0)
		{
			_vertices.AddRange(points.Select((Vector2 x) => x.ToVector3(y)));
			if (UseUV1)
			{
				_uv1.AddRange(points);
			}
			_normals.AddRange(Utilities.RepeatValue(Vector3.up, count2));
			_tangents.AddRange(Utilities.RepeatValue(new Vector4(1f, 0f, 0f, -1f), count2));
			for (int num = 1; num < points.Count - 1; num++)
			{
				_triangles.Add(count);
				_triangles.Add(count + num + 1);
				_triangles.Add(count + num);
			}
			if (!open)
			{
				_triangles.Add(count);
				_triangles.Add(count + 1);
				_triangles.Add(count + points.Count - 1);
			}
		}
	}

	public void AddTriangleFlatFan(Vector2 pos, float startAngle, float angleRangeDeg, float dist, int amount, float y)
	{
		int count = _vertices.Count;
		int num = amount + 1;
		if (CanAddMore(num) >= 0)
		{
			return;
		}
		_vertices.Add(pos.ToVector3(y));
		if (UseUV1)
		{
			_uv1.Add(pos);
		}
		_normals.AddRange(Utilities.RepeatValue(Vector3.up, num));
		_tangents.AddRange(Utilities.RepeatValue(new Vector4(1f, 0f, 0f, -1f), num));
		float num2 = angleRangeDeg * ((float)Math.PI / 180f) / (float)(amount - 1);
		float num3 = startAngle;
		for (int i = 0; i < amount; i++)
		{
			Vector2 vector = pos + new Vector2(Mathf.Cos(num3) * dist, Mathf.Sin(num3) * dist);
			_vertices.Add(vector.ToVector3(0f));
			if (UseUV1)
			{
				_uv1.Add(vector);
			}
			num3 += num2;
			if (i > 0)
			{
				_triangles.Add(count);
				_triangles.Add(count + i + 1);
				_triangles.Add(count + i);
			}
		}
	}

	public void AddFlatMesh(IList<Vector2> verts, IList<int> tris, float y, Vector2? uvExtra = null, Color? color = null)
	{
		int count = _vertices.Count;
		int num = verts.Count;
		int num2 = CanAddMore(num);
		if (num2 >= 0 && num2 < 3)
		{
			return;
		}
		if (num2 > 0)
		{
			_vertices.AddRange(from x in verts.Take(num2)
				select x.ToVector3(y));
			if (UseUV1)
			{
				_uv1.AddRange(verts.Take(num2));
			}
			_normals.AddRange(Utilities.RepeatValue(Vector3.up, num2));
			_tangents.AddRange(Utilities.RepeatValue(new Vector4(1f, 0f, 0f, -1f), num2));
			num = num2;
		}
		else
		{
			_vertices.AddRange(verts.Select((Vector2 x) => x.ToVector3(y)));
			if (UseUV1)
			{
				_uv1.AddRange(verts);
			}
			_normals.AddRange(Utilities.RepeatValue(Vector3.up, num));
			_tangents.AddRange(Utilities.RepeatValue(new Vector4(1f, 0f, 0f, -1f), num));
		}
		if (UseUV2)
		{
			if (uvExtra.HasValue)
			{
				AddToList(_uv2, uvExtra.Value, num);
			}
			else
			{
				Debug.LogException(new Exception("Ignore: UV2 not provided, but required for MeshCombiner " + Name));
			}
		}
		if (UseColor)
		{
			if (color.HasValue)
			{
				AddToList(_colors, color.Value, num);
			}
			else
			{
				Debug.LogException(new Exception("Ignore: Colors not provided, but required for MeshCombiner " + Name));
			}
		}
		for (int num3 = 0; num3 < tris.Count; num3 += 3)
		{
			if (num2 < 0 || (tris[num3] < num2 && tris[num3 + 1] < num2 && tris[num3 + 2] < num2))
			{
				_triangles.Add(count + tris[num3]);
				_triangles.Add(count + tris[num3 + 1]);
				_triangles.Add(count + tris[num3 + 2]);
			}
		}
	}

	public void AddMesh(Vector3[] vertices, Vector3[] normals, Vector4[] tangents, int[] triangles, Matrix4x4 transform, Color color)
	{
		int count = _vertices.Count;
		int num = vertices.Length;
		int num2 = CanAddMore(num);
		if (num2 >= 0 && num2 < 3)
		{
			return;
		}
		if (num2 > 0)
		{
			AddToList(_vertices, vertices, ((Matrix4x4)transform).MultiplyPoint, num2);
			AddToList(_normals, normals, (Vector3 x) => transform.MultiplyVector(x).normalized, num2);
			AddToList(_tangents, tangents, (Vector4 x) => transform.MultiplyVector(x.FlattenVector4()).normalized.ToVector4(-1f), num2);
			num = num2;
		}
		else
		{
			AddToList(_vertices, vertices, ((Matrix4x4)transform).MultiplyPoint);
			AddToList(_normals, normals, (Vector3 x) => transform.MultiplyVector(x).normalized);
			AddToList(_tangents, tangents, (Vector4 x) => transform.MultiplyVector(x.FlattenVector4()).normalized.ToVector4(-1f));
		}
		AddToList(_colors, color, num);
		for (int num3 = 0; num3 < triangles.Length; num3 += 3)
		{
			if (num2 < 0 || (triangles[num3] < num2 && triangles[num3 + 1] < num2 && triangles[num3 + 2] < num2))
			{
				_triangles.Add(count + triangles[num3]);
				_triangles.Add(count + triangles[num3 + 1]);
				_triangles.Add(count + triangles[num3 + 2]);
			}
		}
	}

	public void AddMesh(Mesh inputMesh, Matrix4x4 transform, bool reverseTris, Vector2? uv1 = null, Vector2? uvExtra = null, Color? color = null)
	{
		int count = _vertices.Count;
		int num = inputMesh.vertexCount;
		int num2 = CanAddMore(num);
		if (num2 >= 0 && num2 < 3)
		{
			return;
		}
		if (num2 > 0)
		{
			AddToList(_vertices, inputMesh.vertices, ((Matrix4x4)transform).MultiplyPoint, num2);
			AddToList(_normals, inputMesh.normals, (Vector3 x) => transform.MultiplyVector(x).normalized, num2);
			AddToList(_tangents, inputMesh.tangents, (Vector4 x) => transform.MultiplyVector(x.FlattenVector4()).normalized.ToVector4(-1f), num2);
			num = num2;
		}
		else
		{
			AddToList(_vertices, inputMesh.vertices, ((Matrix4x4)transform).MultiplyPoint);
			AddToList(_normals, inputMesh.normals, (Vector3 x) => transform.MultiplyVector(x).normalized);
			AddToList(_tangents, inputMesh.tangents, (Vector4 x) => transform.MultiplyVector(x.FlattenVector4()).normalized.ToVector4(-1f));
		}
		if (UseUV1)
		{
			if (uv1.HasValue)
			{
				AddToList(_uv1, uv1.Value, num);
			}
			else
			{
				_uv1.AddRange(inputMesh.uv);
			}
		}
		if (UseUV2)
		{
			if (uvExtra.HasValue)
			{
				AddToList(_uv2, uvExtra.Value, num);
			}
			else
			{
				Vector2[] uv2 = inputMesh.uv2;
				if (uv2 != null && uv2.Length != 0)
				{
					List<Vector2> uv3 = _uv2;
					IEnumerable<Vector2> collection;
					if (num2 <= 0)
					{
						IEnumerable<Vector2> enumerable = uv2;
						collection = enumerable;
					}
					else
					{
						collection = uv2.Take(num);
					}
					uv3.AddRange(collection);
				}
				else
				{
					AddToList(_uv2, Vector2.zero, num);
				}
			}
		}
		if (UseUV3)
		{
			Vector2[] uv4 = inputMesh.uv3;
			if (uv4 != null && uv4.Length != 0)
			{
				List<Vector2> uv5 = _uv3;
				IEnumerable<Vector2> collection2;
				if (num2 <= 0)
				{
					IEnumerable<Vector2> enumerable = uv4;
					collection2 = enumerable;
				}
				else
				{
					collection2 = uv4.Take(num);
				}
				uv5.AddRange(collection2);
			}
			else
			{
				AddToList(_uv3, Vector2.zero, num);
			}
		}
		if (UseColor)
		{
			if (color.HasValue)
			{
				AddToList(_colors, color.Value, num);
			}
			else
			{
				Color[] colors = inputMesh.colors;
				if (colors != null && colors.Length != 0)
				{
					if (num2 > 0)
					{
						_colors.AddRange(colors.Take(num));
					}
					else
					{
						_colors.AddRange(colors);
					}
				}
				else
				{
					AddToList(_colors, Color.white, num);
				}
			}
		}
		int[] triangles = inputMesh.triangles;
		if (reverseTris)
		{
			for (int num3 = triangles.Length - 1; num3 >= 0; num3 -= 3)
			{
				if (num2 < 0 || (triangles[num3] < num2 && triangles[num3 - 1] < num2 && triangles[num3 - 2] < num2))
				{
					_triangles.Add(count + triangles[num3]);
					_triangles.Add(count + triangles[num3 - 1]);
					_triangles.Add(count + triangles[num3 - 2]);
				}
			}
			return;
		}
		for (int num4 = 0; num4 < triangles.Length; num4 += 3)
		{
			if (num2 < 0 || (triangles[num4] < num2 && triangles[num4 + 1] < num2 && triangles[num4 + 2] < num2))
			{
				_triangles.Add(count + triangles[num4]);
				_triangles.Add(count + triangles[num4 + 1]);
				_triangles.Add(count + triangles[num4 + 2]);
			}
		}
	}

	public void AddMesh(Mesh inputMesh, Matrix4x4 transform, Vector2? uvScale, Vector2Int atlasPos)
	{
		int count = _vertices.Count;
		int num = inputMesh.vertexCount;
		int num2 = CanAddMore(num);
		if (num2 >= 0 && num2 < 3)
		{
			return;
		}
		if (num2 > 0)
		{
			AddToList(_vertices, inputMesh.vertices, ((Matrix4x4)transform).MultiplyPoint, num2);
			AddToList(_normals, inputMesh.normals, (Vector3 x) => transform.MultiplyVector(x).normalized, num2);
			AddToList(_tangents, inputMesh.tangents, (Vector4 x) => transform.MultiplyVector(x.FlattenVector4()).normalized.ToVector4(-1f), num2);
			num = num2;
		}
		else
		{
			AddToList(_vertices, inputMesh.vertices, ((Matrix4x4)transform).MultiplyPoint);
			AddToList(_normals, inputMesh.normals, (Vector3 x) => transform.MultiplyVector(x).normalized);
			AddToList(_tangents, inputMesh.tangents, (Vector4 x) => transform.MultiplyVector(x.FlattenVector4()).normalized.ToVector4(-1f));
		}
		if (UseUV1)
		{
			Vector2[] uv = inputMesh.uv;
			List<Vector2> uv2 = _uv1;
			IEnumerable<Vector2> collection;
			if (!uvScale.HasValue)
			{
				IEnumerable<Vector2> enumerable = uv;
				collection = enumerable;
			}
			else
			{
				collection = uv.Select((Vector2 x) => Vector2.Scale(x, uvScale.Value));
			}
			uv2.AddRange(collection);
		}
		if (UseUV2)
		{
			AddToList(_uv2, atlasPos, num);
		}
		if (UseColor)
		{
			Color[] colors = inputMesh.colors;
			if (colors != null && colors.Length != 0)
			{
				List<Color> colors2 = _colors;
				IEnumerable<Color> collection2;
				if (num2 <= 0)
				{
					IEnumerable<Color> enumerable2 = colors;
					collection2 = enumerable2;
				}
				else
				{
					collection2 = colors.Take(num);
				}
				colors2.AddRange(collection2);
			}
			else
			{
				AddToList(_colors, Color.white, num);
			}
		}
		int[] triangles = inputMesh.triangles;
		for (int num3 = 0; num3 < triangles.Length; num3 += 3)
		{
			if (num2 < 0 || (triangles[num3] < num2 && triangles[num3 + 1] < num2 && triangles[num3 + 2] < num2))
			{
				_triangles.Add(count + triangles[num3]);
				_triangles.Add(count + triangles[num3 + 1]);
				_triangles.Add(count + triangles[num3 + 2]);
			}
		}
	}

	public void AddWall(List<Vector2> points, List<Vector3> normals, List<Vector4> tangents, List<float> uvs, Vector2 uv2, bool reverse)
	{
		int count = _vertices.Count;
		if (CanAddMore(points.Count * 2) >= 0)
		{
			return;
		}
		for (int i = 0; i < points.Count; i++)
		{
			_vertices.Add(points[i].ToVector3(0f));
			if (UseUV1)
			{
				_uv1.Add(new Vector2(uvs[i], 0f));
			}
			_normals.Add(normals[i]);
			_tangents.Add(tangents[i]);
			if (UseUV2)
			{
				_uv2.Add(uv2);
			}
		}
		for (int j = 0; j < points.Count; j++)
		{
			_vertices.Add(points[j].ToVector3(2f));
			if (UseUV1)
			{
				_uv1.Add(new Vector2(uvs[j], 1f));
			}
			_normals.Add(normals[j]);
			_tangents.Add(tangents[j]);
			if (UseUV2)
			{
				_uv2.Add(uv2);
			}
		}
		for (int k = 0; k < points.Count - 1; k += 2)
		{
			if (reverse)
			{
				_triangles.Add(count + points.Count + k + 1);
				_triangles.Add(count + points.Count + k);
				_triangles.Add(count + k);
				_triangles.Add(count + k);
				_triangles.Add(count + k + 1);
				_triangles.Add(count + points.Count + k + 1);
			}
			else
			{
				_triangles.Add(count + k);
				_triangles.Add(count + points.Count + k);
				_triangles.Add(count + points.Count + k + 1);
				_triangles.Add(count + points.Count + k + 1);
				_triangles.Add(count + k + 1);
				_triangles.Add(count + k);
			}
		}
	}

	public void ColorMesh(Mesh mesh, Matrix4x4 t, Color color)
	{
		AddMesh(mesh, t, false, null, null, color);
	}

	private static Vector3 GetTangent(Vector3 normal)
	{
		Vector3 result = Vector3.Cross(normal, Vector3.forward);
		if (result.sqrMagnitude != 0f)
		{
			return result;
		}
		return Vector3.Cross(normal, Vector3.up);
	}

	public void AddQuad(Vector3 v1, Vector3 v2, Vector3 v3, Vector3 v4, Vector2 uv1, Vector2 uv2, Vector2 uv3, Vector2 uv4, Vector2? uv22, Vector3 n, Vector4 t)
	{
		int count = _vertices.Count;
		AddToList(_vertices, v1, v2, v3, v4);
		AddToList(_uv1, uv1, uv2, uv3, uv4);
		if (uv22.HasValue)
		{
			AddToList(_uv2, uv22.Value, 4);
		}
		AddToList(_normals, n, 4);
		AddToList(_tangents, t, 4);
		AddToList(_triangles, count, count + 1, count + 2, count + 2, count + 3, count);
	}

	public void MakeFace(Vector3 v1, Vector3 v2, Vector3 v3, Vector3 v4, Vector3? n, Color col, Vector3? t = null)
	{
		bool flag = true;
		if (v1 == v2)
		{
			v2 = v3;
			v3 = v4;
			flag = false;
		}
		else if (v2 == v3)
		{
			v3 = v4;
			flag = false;
		}
		else if (v3 == v4)
		{
			flag = false;
		}
		else if (v4 == v1)
		{
			flag = false;
		}
		if (CanAddMore(flag ? 4 : 3) >= 0)
		{
			return;
		}
		int count = _vertices.Count;
		if (!n.HasValue)
		{
			n = Vector3.Cross(v2 - v1, v3 - v1).normalized;
		}
		if (flag)
		{
			AddToList(_vertices, v1, v2, v3, v4);
			AddToList(_normals, n.Value, 4);
			if (t.HasValue)
			{
				AddToList(_tangents, t.Value, 4);
			}
			if (UseUV1)
			{
				AddToList(_uv1, Vector2.zero, 4);
			}
			if (UseUV2)
			{
				AddToList(_uv2, Vector2.zero, 4);
			}
			if (UseColor)
			{
				AddToList(_colors, col, 4);
			}
			AddToList(_triangles, count, count + 1, count + 2, count + 2, count + 3, count);
		}
		else
		{
			AddToList(_vertices, v1, v2, v3);
			AddToList(_normals, n.Value, 3);
			if (t.HasValue)
			{
				AddToList(_tangents, t.Value, 3);
			}
			if (UseUV1)
			{
				AddToList(_uv1, Vector2.zero, 3);
			}
			if (UseUV2)
			{
				AddToList(_uv2, Vector2.zero, 3);
			}
			if (UseColor)
			{
				AddToList(_colors, col, 3);
			}
			AddToList(_triangles, count, count + 1, count + 2);
		}
	}

	private void AddToList<T>(List<T> list, T v, int n)
	{
		int num = Mathf.Max(1, list.Capacity);
		int num2 = list.Count + n;
		while (num < num2)
		{
			num *= 2;
		}
		list.Capacity = num;
		for (int i = 0; i < n; i++)
		{
			list.Add(v);
		}
	}

	private void AddToList<T>(List<T> list, T v1, T v2, T v3)
	{
		list.Add(v1);
		list.Add(v2);
		list.Add(v3);
	}

	private void AddToList<T>(List<T> list, T v1, T v2, T v3, T v4)
	{
		list.Add(v1);
		list.Add(v2);
		list.Add(v3);
		list.Add(v4);
	}

	private void AddToList<T>(List<T> list, T v1, T v2, T v3, T v4, T v5)
	{
		list.Add(v1);
		list.Add(v2);
		list.Add(v3);
		list.Add(v4);
		list.Add(v5);
	}

	private void AddToList<T>(List<T> list, T v1, T v2, T v3, T v4, T v5, T v6)
	{
		list.Add(v1);
		list.Add(v2);
		list.Add(v3);
		list.Add(v4);
		list.Add(v5);
		list.Add(v6);
	}

	private int CanAddMore(int amount)
	{
		return -1;
	}

	public Mesh CreateMesh(Vector3 translate, Vector3 scale)
	{
		Mesh mesh = new Mesh();
		mesh.name = Name;
		mesh.indexFormat = ((_vertices.Count >= 65534) ? IndexFormat.UInt32 : IndexFormat.UInt16);
		for (int i = 0; i < _vertices.Count; i++)
		{
			_vertices[i] = Vector3.Scale(_vertices[i], scale) + translate;
		}
		mesh.SetVertices(_vertices);
		mesh.SetNormals(_normals);
		mesh.SetTangents(_tangents);
		if (UseUV1)
		{
			mesh.SetUVs(0, _uv1);
		}
		if (UseUV2 && _uv2.Count == _vertices.Count)
		{
			mesh.SetUVs(1, _uv2);
		}
		if (UseUV3 && _uv3.Count == _vertices.Count)
		{
			mesh.SetUVs(2, _uv3);
		}
		if (UseColor && _colors.Count == _vertices.Count)
		{
			mesh.SetColors(_colors);
		}
		mesh.SetTriangles(_triangles, 0);
		return mesh;
	}

	public Mesh CreateMesh(Vector2? uv2 = null)
	{
		Mesh mesh = new Mesh();
		mesh.name = Name;
		mesh.indexFormat = ((_vertices.Count >= 65534) ? IndexFormat.UInt32 : IndexFormat.UInt16);
		mesh.SetVertices(_vertices);
		mesh.SetNormals(_normals);
		mesh.SetTangents(_tangents);
		if (UseUV1)
		{
			mesh.SetUVs(0, _uv1);
		}
		if (uv2.HasValue)
		{
			mesh.uv2 = Utilities.RepeatValue(uv2.Value, _vertices.Count);
		}
		else if (UseUV2 && _uv2.Count == _vertices.Count)
		{
			mesh.SetUVs(1, _uv2);
		}
		if (UseUV3 && _uv3.Count == _vertices.Count)
		{
			mesh.SetUVs(2, _uv3);
		}
		if (UseColor && _colors.Count == _vertices.Count)
		{
			mesh.SetColors(_colors);
		}
		mesh.SetTriangles(_triangles, 0);
		return mesh;
	}

	public void CreateMesh(Mesh m)
	{
		m.Clear();
		m.indexFormat = ((_vertices.Count >= 65534) ? IndexFormat.UInt32 : IndexFormat.UInt16);
		m.SetVertices(_vertices);
		m.SetNormals(_normals);
		m.SetTangents(_tangents);
		if (UseUV1)
		{
			m.SetUVs(0, _uv1);
		}
		if (UseUV2 && _uv2.Count == _vertices.Count)
		{
			m.SetUVs(1, _uv2);
		}
		if (UseUV3 && _uv3.Count == _vertices.Count)
		{
			m.SetUVs(2, _uv3);
		}
		if (UseColor && _colors.Count == _vertices.Count)
		{
			m.SetColors(_colors);
		}
		m.SetTriangles(_triangles, 0);
	}

	public CombineInstance CreateCombine()
	{
		return new CombineInstance
		{
			mesh = CreateMesh(),
			transform = Matrix4x4.identity
		};
	}

	public bool HasData()
	{
		return _vertices.Count > 0;
	}
}
