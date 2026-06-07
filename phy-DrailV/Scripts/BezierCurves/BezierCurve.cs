using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[ExecuteInEditMode]
public class BezierCurve : MonoBehaviour
{
	public enum Axis
	{
		X = 0,
		Y = 1,
		Z = 2
	}

	private struct TBetweenPointsData
	{
		public BezierPoint p1;

		public BezierPoint p2;

		public float t;
	}

	private const int RESOLUTION_TO_NUMPOINTS_FACTOR = 3;

	[HideInInspector]
	public int version = 1;

	public float resolution = 5f;

	[NonSerialized]
	public bool dirty = true;

	public Color drawColor = Color.white;

	public static bool drawInterpolatedPoints;

	[SerializeField]
	private bool _close;

	[SerializeField]
	private bool _mirror;

	[SerializeField]
	private Axis _axis;

	private float _length;

	[NonSerialized]
	public int lastClickedPointIndex = -1;

	[SerializeField]
	private BezierPoint[] points = new BezierPoint[0];

	public bool close
	{
		get
		{
			return _close;
		}
		set
		{
			if (_close != value)
			{
				_close = value;
				dirty = true;
			}
		}
	}

	public bool mirror
	{
		get
		{
			return _mirror;
		}
		set
		{
			if (_mirror != value)
			{
				_mirror = value;
				dirty = true;
			}
		}
	}

	public Axis axis
	{
		get
		{
			return _axis;
		}
		set
		{
			if (_axis != value)
			{
				_axis = value;
				dirty = true;
			}
		}
	}

	public BezierPoint this[int index] => points[index];

	public int pointCount => points.Length;

	public float length
	{
		get
		{
			if (dirty || _length == 0f)
			{
				_length = 0f;
				for (int i = 0; i < points.Length - 1; i++)
				{
					_length += ApproximateLength(points[i], points[i + 1], resolution);
				}
				if (close)
				{
					_length += ApproximateLength(points[points.Length - 1], points[0], resolution);
				}
				dirty = false;
			}
			return _length;
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = drawColor;
		if (points.Length <= 1)
		{
			return;
		}
		for (int i = 0; i < points.Length - 1; i++)
		{
			DrawCurve(points[i], points[i + 1], resolution);
		}
		if (close)
		{
			DrawCurve(points[points.Length - 1], points[0], resolution);
		}
		if (mirror)
		{
			for (int j = 0; j < points.Length - 1; j++)
			{
				DrawCurveMirrored(base.transform, points[j], points[j + 1], resolution, axis);
			}
		}
	}

	private void Awake()
	{
		BezierCurveUpgrade.Upgrade(this);
		dirty = true;
	}

	public void SnapAllNodesToAxis(Axis axis)
	{
		for (int i = 0; i < points.Length; i++)
		{
			switch (axis)
			{
			case Axis.X:
				points[i].localPosition = new Vector3(0f, points[i].localPosition.y, points[i].localPosition.z);
				points[i].handle1 = new Vector3(0f, points[i].handle1.y, points[i].handle1.z);
				points[i].handle2 = new Vector3(0f, points[i].handle2.y, points[i].handle2.z);
				break;
			case Axis.Y:
				points[i].localPosition = new Vector3(points[i].localPosition.x, 0f, points[i].localPosition.z);
				points[i].handle1 = new Vector3(points[i].handle1.x, 0f, points[i].handle1.z);
				points[i].handle2 = new Vector3(points[i].handle2.x, 0f, points[i].handle2.z);
				break;
			case Axis.Z:
				points[i].localPosition = new Vector3(points[i].localPosition.x, points[i].localPosition.y, 0f);
				points[i].handle1 = new Vector3(points[i].handle1.x, points[i].handle1.y, 0f);
				points[i].handle2 = new Vector3(points[i].handle2.x, points[i].handle2.y, 0f);
				break;
			}
		}
	}

	public void MirrorAllNodesAroundAxis(Axis axis)
	{
		for (int i = 0; i < points.Length; i++)
		{
			switch (axis)
			{
			case Axis.X:
				points[i].localPosition = new Vector3(0f - points[i].localPosition.x, points[i].localPosition.y, points[i].localPosition.z);
				points[i].handle1 = new Vector3(0f - points[i].handle1.x, points[i].handle1.y, points[i].handle1.z);
				break;
			case Axis.Y:
				points[i].localPosition = new Vector3(points[i].localPosition.x, 0f - points[i].localPosition.y, points[i].localPosition.z);
				points[i].handle1 = new Vector3(points[i].handle1.x, 0f - points[i].handle1.y, points[i].handle1.z);
				break;
			case Axis.Z:
				points[i].localPosition = new Vector3(points[i].localPosition.x, points[i].localPosition.y, 0f - points[i].localPosition.z);
				points[i].handle1 = new Vector3(points[i].handle1.x, points[i].handle1.y, 0f - points[i].handle1.z);
				break;
			}
		}
	}

	public void AddPoint(BezierPoint point)
	{
		List<BezierPoint> list = new List<BezierPoint>(points);
		list.Add(point);
		points = list.ToArray();
		dirty = true;
	}

	public void InsertPoint(int index, BezierPoint point)
	{
		List<BezierPoint> list = new List<BezierPoint>(points);
		list.Insert(index, point);
		points = list.ToArray();
		dirty = true;
	}

	public BezierPoint CreatePointAt(Vector3 position)
	{
		GameObject obj = new GameObject("Point " + pointCount);
		obj.transform.parent = base.transform;
		obj.transform.position = position;
		BezierPoint bezierPoint = obj.AddComponent<BezierPoint>();
		bezierPoint._curve = this;
		return bezierPoint;
	}

	public BezierPoint AddPointAt(Vector3 position)
	{
		BezierPoint bezierPoint = CreatePointAt(position);
		AddPoint(bezierPoint);
		return bezierPoint;
	}

	public BezierPoint AddPointBehind(Vector3 position)
	{
		BezierPoint bezierPoint = CreatePointAt(position);
		bezierPoint.transform.SetAsFirstSibling();
		InsertPoint(0, bezierPoint);
		return bezierPoint;
	}

	public BezierPoint InsertPointAt(int index, Vector3 position)
	{
		BezierPoint bezierPoint = CreatePointAt(position);
		bezierPoint.transform.SetSiblingIndex(index);
		InsertPoint(index, bezierPoint);
		return bezierPoint;
	}

	public void RemovePoint(BezierPoint point)
	{
		List<BezierPoint> list = new List<BezierPoint>(points);
		list.Remove(point);
		points = list.ToArray();
		dirty = false;
	}

	public void RemovePoint(int index)
	{
		List<BezierPoint> list = new List<BezierPoint>(points);
		list.RemoveAt(index);
		points = list.ToArray();
		dirty = false;
	}

	public void CleanupNullPoints()
	{
		List<BezierPoint> list = new List<BezierPoint>();
		BezierPoint[] array = points;
		foreach (BezierPoint bezierPoint in array)
		{
			if (bezierPoint != null)
			{
				list.Add(bezierPoint);
			}
		}
		points = list.ToArray();
		dirty = false;
	}

	public BezierPoint[] GetAnchorPoints()
	{
		return (BezierPoint[])points.Clone();
	}

	public BezierPoint Last()
	{
		return this[points.Length - 1];
	}

	private TBetweenPointsData GetTBetweenPoints(float t)
	{
		if (t <= 0f)
		{
			return new TBetweenPointsData
			{
				p1 = points[0],
				p2 = points[1],
				t = 0f
			};
		}
		if (t >= 1f)
		{
			if (close)
			{
				return new TBetweenPointsData
				{
					p1 = points[points.Length - 1],
					p2 = points[0],
					t = 1f
				};
			}
			return new TBetweenPointsData
			{
				p1 = points[points.Length - 2],
				p2 = points[points.Length - 1],
				t = 1f
			};
		}
		float num = 0f;
		float num2 = 0f;
		BezierPoint bezierPoint = null;
		BezierPoint bezierPoint2 = null;
		int num3 = 10;
		int num4 = 0;
		int num5 = 10;
		while (bezierPoint == null && bezierPoint2 == null)
		{
			num = 0f;
			int num6 = (close ? points.Length : (points.Length - 1));
			for (int i = 0; i < num6; i++)
			{
				BezierPoint bezierPoint3 = points[i];
				BezierPoint bezierPoint4 = points[(i + 1) % points.Length];
				num2 = ApproximateLength(bezierPoint3, bezierPoint4, num3) / length;
				if (num + num2 > t || (double)Mathf.Abs(t - (num + num2)) < 5E-06)
				{
					bezierPoint = bezierPoint3;
					bezierPoint2 = bezierPoint4;
					break;
				}
				num += num2;
			}
			num3 += 10;
			if (++num4 >= num5)
			{
				Debug.LogError("BezierCurve couldn't find a point", this);
				return default(TBetweenPointsData);
			}
		}
		if (bezierPoint == null)
		{
			Debug.LogError("p1 is null");
		}
		if (bezierPoint2 == null)
		{
			Debug.LogError("p2 is null");
		}
		return new TBetweenPointsData
		{
			p1 = bezierPoint,
			p2 = bezierPoint2,
			t = (t - num) / num2
		};
	}

	public Vector3 GetPointAt(float t)
	{
		TBetweenPointsData tBetweenPoints = GetTBetweenPoints(t);
		return GetPoint(tBetweenPoints.p1, tBetweenPoints.p2, tBetweenPoints.t);
	}

	public Vector3 GetTangentAt(float t)
	{
		TBetweenPointsData tBetweenPoints = GetTBetweenPoints(t);
		return GetTangent(tBetweenPoints.p1, tBetweenPoints.p2, tBetweenPoints.t);
	}

	public Vector3 GetTangent(BezierPoint bp1, BezierPoint bp2, float t)
	{
		if (bp1.handleStyle == BezierPoint.HandleStyle.None && bp2.handleStyle == BezierPoint.HandleStyle.None)
		{
			return (bp2.position - bp1.position).normalized;
		}
		Vector3 position = bp1.position;
		Vector3 globalHandle = bp1.globalHandle2;
		Vector3 globalHandle2 = bp2.globalHandle1;
		Vector3 position2 = bp2.position;
		return Tangent(position, globalHandle, globalHandle2, position2, t);
	}

	public Vector3 GetLocalTangent(BezierPoint bp1, BezierPoint bp2, float t)
	{
		if (bp1.handleStyle == BezierPoint.HandleStyle.None && bp2.handleStyle == BezierPoint.HandleStyle.None)
		{
			return (bp2.localPosition - bp1.localPosition).normalized;
		}
		Vector3 localPosition = bp1.localPosition;
		Vector3 b = bp1.localPosition + bp1.handle2;
		Vector3 c = bp2.localPosition + bp2.handle1;
		Vector3 localPosition2 = bp2.localPosition;
		return Tangent(localPosition, b, c, localPosition2, t);
	}

	public static Vector3 Tangent(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float t)
	{
		Vector3 vector = d - 3f * c + 3f * b - a;
		Vector3 vector2 = 3f * c - 6f * b + 3f * a;
		Vector3 vector3 = 3f * b - 3f * a;
		return 3f * vector * t * t + 2f * vector2 * t + vector3;
	}

	public int GetPointIndex(BezierPoint point)
	{
		int result = -1;
		for (int i = 0; i < points.Length; i++)
		{
			if (points[i] == point)
			{
				result = i;
				break;
			}
		}
		return result;
	}

	public void SetDirty()
	{
		dirty = true;
	}

	public static Vector3[] Interpolate(Vector3 p1, Vector3 p1Handle2, Vector3 p2, Vector3 p2Handle1, int numPoints)
	{
		Vector3[] array = new Vector3[numPoints + 1];
		array[0] = p1;
		array[array.Length - 1] = p2;
		float num = numPoints;
		for (int i = 1; i < array.Length - 1; i++)
		{
			array[i] = GetPoint(p1, p1Handle2, p2, p2Handle1, (float)i / num);
		}
		return array;
	}

	public static Vector3[] Interpolate(Vector3 p1, Vector3 p1Handle2, Vector3 p2, Vector3 p2Handle1, float resolution)
	{
		int numPoints = GetNumPoints(p1, p1Handle2, p2, p2Handle1, resolution);
		return Interpolate(p1, p1Handle2, p2, p2Handle1, numPoints);
	}

	public static void DrawCurve(BezierPoint p1, BezierPoint p2, int resolution)
	{
		Vector3[] array = Interpolate(p1.position, p1.globalHandle2, p2.position, p2.globalHandle1, resolution);
		Vector3 vector = array[0];
		Vector3 zero = Vector3.zero;
		DrawInterpolatedPoint(vector);
		for (int i = 1; i < array.Length; i++)
		{
			zero = array[i];
			Gizmos.DrawLine(vector, zero);
			vector = zero;
			DrawInterpolatedPoint(vector);
		}
	}

	public static void DrawCurve(BezierPoint p1, BezierPoint p2, float resolution)
	{
		DrawCurve(p1, p2, GetNumPoints(p1, p2, resolution));
	}

	private static void DrawInterpolatedPoint(Vector3 position)
	{
	}

	public static void DrawCurveMirrored(Transform localTransform, BezierPoint p1, BezierPoint p2, int resolution, Axis axis)
	{
		int num = resolution + 1;
		float num2 = resolution;
		Vector3 position = p1.position;
		position = localTransform.InverseTransformPoint(position);
		position = GetMirroredPoint(position, axis);
		position = localTransform.TransformPoint(position);
		Vector3 zero = Vector3.zero;
		for (int i = 1; i < num; i++)
		{
			zero = GetPoint(p1, p2, (float)i / num2);
			zero = localTransform.InverseTransformPoint(zero);
			zero = GetMirroredPoint(zero, axis);
			zero = localTransform.TransformPoint(zero);
			Gizmos.DrawLine(position, zero);
			position = zero;
		}
	}

	public static void DrawCurveMirrored(Transform localTransform, BezierPoint p1, BezierPoint p2, float resolution, Axis axis)
	{
		DrawCurveMirrored(localTransform, p1, p2, GetNumPoints(p1, p2, resolution), axis);
	}

	public static Vector3 GetMirroredPoint(Vector3 point, Axis axis)
	{
		switch (axis)
		{
		case Axis.X:
			point.x *= -1f;
			break;
		case Axis.Y:
			point.y *= -1f;
			break;
		case Axis.Z:
			point.z *= -1f;
			break;
		}
		return point;
	}

	public static Vector3 GetPoint(BezierPoint p1, BezierPoint p2, float t)
	{
		return GetPoint(p1.position, p1.globalHandle2, p2.position, p2.globalHandle1, t);
	}

	public static Vector3 GetPoint(Vector3 p1, Vector3 p1Handle2, Vector3 p2, Vector3 p2Handle1, float t)
	{
		if (p1Handle2 != p1)
		{
			if (p2Handle1 != p2)
			{
				return GetCubicCurvePoint(p1, p1Handle2, p2Handle1, p2, t);
			}
			return GetQuadraticCurvePoint(p1, p1Handle2, p2, t);
		}
		if (p2Handle1 != p2)
		{
			return GetQuadraticCurvePoint(p1, p2Handle1, p2, t);
		}
		return GetLinearPoint(p1, p2, t);
	}

	public static Vector3 GetPoint(float t, params Vector3[] points)
	{
		t = Mathf.Clamp01(t);
		int num = points.Length - 1;
		Vector3 zero = Vector3.zero;
		for (int i = 0; i < points.Length; i++)
		{
			Vector3 vector = points[points.Length - i - 1] * ((float)BinomialCoefficient(i, num) * Mathf.Pow(t, num - i) * Mathf.Pow(1f - t, i));
			zero += vector;
		}
		return zero;
	}

	public static Vector3 GetPointLocal(BezierPoint p1, BezierPoint p2, float t)
	{
		Vector3 p3 = p1.localPosition + p1.handle2;
		Vector3 vector = p2.localPosition + p2.handle1;
		if (p1.handle2 != Vector3.zero)
		{
			if (p2.handle1 != Vector3.zero)
			{
				return GetCubicCurvePoint(p1.localPosition, p3, vector, p2.localPosition, t);
			}
			return GetQuadraticCurvePoint(p1.localPosition, p3, p2.localPosition, t);
		}
		if (p2.handle1 != Vector3.zero)
		{
			return GetQuadraticCurvePoint(p1.localPosition, vector, p2.localPosition, t);
		}
		return GetLinearPoint(p1.localPosition, p2.localPosition, t);
	}

	public static Vector3 GetCubicCurvePoint(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4, float t)
	{
		t = Mathf.Clamp01(t);
		Vector3 vector = Mathf.Pow(1f - t, 3f) * p1;
		Vector3 vector2 = 3f * Mathf.Pow(1f - t, 2f) * t * p2;
		Vector3 vector3 = 3f * (1f - t) * Mathf.Pow(t, 2f) * p3;
		Vector3 vector4 = Mathf.Pow(t, 3f) * p4;
		return vector + vector2 + vector3 + vector4;
	}

	public static Vector3 GetQuadraticCurvePoint(Vector3 p1, Vector3 p2, Vector3 p3, float t)
	{
		t = Mathf.Clamp01(t);
		Vector3 vector = Mathf.Pow(1f - t, 2f) * p1;
		Vector3 vector2 = 2f * (1f - t) * t * p2;
		Vector3 vector3 = Mathf.Pow(t, 2f) * p3;
		return vector + vector2 + vector3;
	}

	public static Vector3 GetLinearPoint(Vector3 p1, Vector3 p2, float t)
	{
		return p1 + (p2 - p1) * t;
	}

	public static float ApproximateLength(BezierPoint p1, BezierPoint p2, int numPoints = 10)
	{
		return ApproximateLength(p1.position, p1.globalHandle2, p2.position, p2.globalHandle1, numPoints);
	}

	public static float ApproximateLength(Vector3 p1, Vector3 p1Handle2, Vector3 p2, Vector3 p2Handle1, int numPoints = 10)
	{
		float num = numPoints;
		float num2 = 0f;
		Vector3 vector = p1;
		for (int i = 0; i < numPoints + 1; i++)
		{
			Vector3 point = GetPoint(p1, p1Handle2, p2, p2Handle1, (float)i / num);
			num2 += (point - vector).magnitude;
			vector = point;
		}
		return num2;
	}

	public static float ApproximateLength(BezierPoint p1, BezierPoint p2, float resolution = 0.5f)
	{
		int numPoints = GetNumPoints(p1, p2, resolution);
		return ApproximateLength(p1, p2, numPoints);
	}

	public static float ApproximateLength(Vector3 p1, Vector3 p1Handle2, Vector3 p2, Vector3 p2Handle1, float resolution = 0.5f)
	{
		int numPoints = GetNumPoints(p1, p1Handle2, p2, p2Handle1, resolution);
		return ApproximateLength(p1, p1Handle2, p2, p2Handle1, numPoints);
	}

	public static int GetNumPoints(BezierPoint p1, BezierPoint p2, float resolution)
	{
		return GetNumPoints(p1.position, p1.globalHandle2, p2.position, p2.globalHandle1, resolution);
	}

	public static int GetNumPoints(Vector3 p1, Vector3 p1Handle2, Vector3 p2, Vector3 p2Handle1, float resolution)
	{
		int val = Mathf.RoundToInt(ApproximateLength(p1, p1Handle2, p2, p2Handle1, 3) * resolution);
		return Math.Max(2, val);
	}

	private static int BinomialCoefficient(int i, int n)
	{
		return Factoral(n) / (Factoral(i) * Factoral(n - i));
	}

	private static int Factoral(int i)
	{
		if (i == 0)
		{
			return 1;
		}
		int num = 1;
		while (i - 1 >= 0)
		{
			num *= i;
			i--;
		}
		return num;
	}
}
