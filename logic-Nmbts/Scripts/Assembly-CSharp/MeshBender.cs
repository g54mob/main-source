using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(MeshFilter))]
[ExecuteInEditMode]
public class MeshBender : MonoBehaviour
{
	private struct Vertex
	{
		public Vector3 v;

		public Vector3 n;
	}

	private Mesh source;

	private Mesh result;

	private readonly List<Vertex> vertices = new List<Vertex>();

	private Quaternion sourceRotation;

	private Vector3 sourceTranslation;

	private Vector3 endTranslation;

	private EUvStretchMode uvMode = EUvStretchMode.SeamlessStretch;

	private float yTiling = 1f;

	public CubicBezierCurve curve;

	private float startScale = 1f;

	private float endScale = 1f;

	private float startRoll;

	private float endRoll;

	private void OnEnable()
	{
		result = new Mesh();
		GetComponent<MeshFilter>().sharedMesh = result;
	}

	public void SetCurve(CubicBezierCurve curve, bool update = true)
	{
		if (this.curve != null)
		{
			this.curve.Changed.RemoveListener(delegate
			{
				Compute();
			});
		}
		this.curve = curve;
		curve.Changed.AddListener(delegate
		{
			Compute();
		});
		if (update)
		{
			Compute();
		}
	}

	public void SetStartScale(float scale, bool update = true)
	{
		startScale = scale;
		if (update)
		{
			Compute();
		}
	}

	public void SetEndScale(float scale, bool update = true)
	{
		endScale = scale;
		if (update)
		{
			Compute();
		}
	}

	public void SetStartRoll(float roll, bool update = true)
	{
		startRoll = roll;
		if (update)
		{
			Compute();
		}
	}

	public void SetEndRoll(float roll, bool update = true)
	{
		endRoll = roll;
		if (update)
		{
			Compute();
		}
	}

	public void SetSourceMesh(Mesh mesh, bool update = true)
	{
		if (source != mesh)
		{
			source = mesh;
			vertices.Clear();
			for (int i = 0; i < source.vertices.Length; i++)
			{
				Vertex item = new Vertex
				{
					v = source.vertices[i],
					n = source.normals[i]
				};
				vertices.Add(item);
			}
		}
		if (update)
		{
			Compute();
		}
	}

	public void SetRotation(Quaternion rotation, bool update = true)
	{
		sourceRotation = rotation;
		if (update)
		{
			Compute();
		}
	}

	public void SetTranslation(Vector3 translation, bool update = true)
	{
		sourceTranslation = translation;
		if (update)
		{
			Compute();
		}
	}

	public void SetEndTranslation(Vector3 translation, bool update = true)
	{
		endTranslation = translation;
		if (update)
		{
			Compute();
		}
	}

	public void SetUvMode(EUvStretchMode mode, bool update = true)
	{
		uvMode = mode;
		if (update)
		{
			Compute();
		}
	}

	public void SetUvYTiling(float value, bool update = true)
	{
		yTiling = value;
		if (update)
		{
			Compute();
		}
	}

	private void Compute()
	{
		if (source == null)
		{
			return;
		}
		int capacity = source.vertices.Length;
		float num = float.MaxValue;
		float num2 = float.MinValue;
		for (int i = 0; i < vertices.Count; i++)
		{
			Vector3 vector = vertices[i].v;
			if (sourceRotation != Quaternion.identity)
			{
				vector = sourceRotation * vector;
			}
			num2 = Math.Max(num2, vector.x);
			num = Math.Min(num, vector.x);
		}
		float num3 = Math.Abs(num2 - num);
		List<Vector3> list = new List<Vector3>(capacity);
		List<Vector3> list2 = new List<Vector3>(capacity);
		List<Vector2> list3 = new List<Vector2>(capacity);
		for (int j = 0; j < vertices.Count; j++)
		{
			Vector3 v = vertices[j].v;
			Vector3 n = vertices[j].n;
			float num4 = Math.Abs(v.x - num) / num3;
			Vector3 locationAtDistance = curve.GetLocationAtDistance(curve.Length * num4);
			Quaternion quaternion = CubicBezierCurve.GetRotationFromTangent(curve.GetTangentAtDistance(curve.Length * num4)) * Quaternion.Euler(90f, 0f, 90f);
			v = sourceRotation * v;
			n = sourceRotation * n;
			Vector3 vector2 = sourceTranslation + (endTranslation - sourceTranslation) * num4;
			v += vector2;
			float num5 = startScale + (endScale - startScale) * num4;
			v *= num5;
			float angle = startRoll + (endRoll - startRoll) * num4;
			v = Quaternion.AngleAxis(angle, Vector3.right) * v;
			n = Quaternion.AngleAxis(angle, Vector3.right) * n;
			v = new Vector3(0f, v.y, v.z);
			list.Add(quaternion * v + locationAtDistance);
			list2.Add(quaternion * n);
		}
		result.vertices = list.ToArray();
		result.normals = list2.ToArray();
		result.triangles = source.triangles;
		CubicBezierCurve cubicBezierCurve = curve;
		if (sourceTranslation != Vector3.zero || endTranslation != Vector3.zero)
		{
			Vector3 tangent = curve.GetTangent(0f);
			tangent = Vector3.Cross(tangent, Vector3.back);
			Vector3 vector3 = curve.GetLocation(0f) + tangent.normalized * startScale * (0f - sourceTranslation.y);
			Vector3 tangent2 = curve.GetTangent(1f);
			tangent2 = Vector3.Cross(tangent2, Vector3.back);
			Vector3 vector4 = curve.GetLocation(1f) + tangent2.normalized * endScale * (0f - endTranslation.y);
			float num6 = (vector3 - vector4).magnitude / (curve.GetLocation(0f) - curve.GetLocation(1f)).magnitude;
			Vector3 direction = vector3 + (curve.n1.direction - curve.n1.position) * num6;
			Vector3 direction2 = vector4 + (curve.n2.direction - curve.n2.position) * num6;
			SplineNode n2 = new SplineNode(vector3, direction);
			SplineNode n3 = new SplineNode(vector4, direction2);
			cubicBezierCurve = new CubicBezierCurve(n2, n3);
		}
		switch (uvMode)
		{
		case EUvStretchMode.Raw:
			list3 = source.uv.ToList();
			break;
		case EUvStretchMode.NoStretch:
		{
			for (int m = 0; m < vertices.Count; m++)
			{
				float x2 = source.uv[m].x;
				float y2 = source.uv[m].y * curve.Length / (startScale * num3 * 2f);
				list3.Add(new Vector2(x2, y2));
			}
			break;
		}
		case EUvStretchMode.SeamlessSquash:
		{
			float num11 = float.MaxValue;
			float num12 = float.MinValue;
			for (int num13 = 0; num13 < vertices.Count; num13++)
			{
				if (source.uv[num13].y < num11)
				{
					num11 = source.uv[num13].y;
				}
				if (source.uv[num13].y > num12)
				{
					num12 = source.uv[num13].y;
				}
			}
			float num14 = cubicBezierCurve.Length / (startScale * num3 * 2f) * yTiling;
			float a2 = num11 * (float)Mathf.FloorToInt(num14);
			float b = ((num14 > float.Epsilon) ? (num12 * (float)Mathf.CeilToInt(num14)) : ((!(num14 < -1E-45f)) ? num12 : (num12 * (float)Mathf.FloorToInt(num14))));
			for (int num15 = 0; num15 < vertices.Count; num15++)
			{
				float x3 = source.uv[num15].x;
				float y3 = Mathf.Lerp(a2, b, Mathf.InverseLerp(num11, num12, source.uv[num15].y));
				list3.Add(new Vector2(x3, y3));
			}
			break;
		}
		case EUvStretchMode.SeamlessStretch:
		{
			float num7 = float.MaxValue;
			float num8 = float.MinValue;
			for (int k = 0; k < vertices.Count; k++)
			{
				if (source.uv[k].y < num7)
				{
					num7 = source.uv[k].y;
				}
				if (source.uv[k].y > num8)
				{
					num8 = source.uv[k].y;
				}
			}
			float num9 = cubicBezierCurve.Length / (startScale * num3 * 2f) * yTiling;
			float a = num7 * (float)Mathf.FloorToInt(num9);
			float num10 = ((num9 > float.Epsilon) ? (num8 * (float)Mathf.FloorToInt(num9)) : ((!(num9 < -1E-45f)) ? num8 : (num8 * (float)Mathf.CeilToInt(num9))));
			if (num10 <= Mathf.Epsilon && num10 >= 0f - Mathf.Epsilon)
			{
				num10 = ((Mathf.Clamp(num10, 1f, 2.1474836E+09f) * (num9 / yTiling) > 0f) ? 1 : (-1));
			}
			for (int l = 0; l < vertices.Count; l++)
			{
				float x = source.uv[l].x;
				float y = Mathf.Lerp(a, num10, Mathf.InverseLerp(num7, num8, source.uv[l].y));
				list3.Add(new Vector2(x, y));
			}
			break;
		}
		default:
			throw new Exception("UvMode not set");
		}
		result.uv = list3.ToArray();
		GetComponent<MeshFilter>().mesh = result;
	}

	private void OnDestroy()
	{
		curve.Changed.RemoveListener(Compute);
	}
}
