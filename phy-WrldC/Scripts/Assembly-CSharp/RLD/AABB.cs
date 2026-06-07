using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public struct AABB
	{
		private Vector3 _size;

		private Vector3 _center;

		private bool _isValid;

		public bool IsValid => _isValid;

		public Vector3 Center
		{
			get
			{
				return _center;
			}
			set
			{
				_center = value;
			}
		}

		public Vector3 Size
		{
			get
			{
				return _size;
			}
			set
			{
				_size = value;
			}
		}

		public Vector3 Extents => Size * 0.5f;

		public Vector3 Min
		{
			get
			{
				return Center - Extents;
			}
			set
			{
				if (_isValid)
				{
					Vector3 min = Vector3.Min(value, Max);
					RecalculateCenterAndSize(min, Max);
				}
			}
		}

		public Vector3 Max
		{
			get
			{
				return Center + Extents;
			}
			set
			{
				if (_isValid)
				{
					Vector3 max = Vector3.Max(value, Min);
					RecalculateCenterAndSize(Min, max);
				}
			}
		}

		public AABB(Vector3 center, Vector3 size)
		{
			_center = center;
			_size = size;
			_isValid = true;
		}

		public AABB(Bounds bounds)
		{
			_center = bounds.center;
			_size = bounds.size;
			_isValid = true;
		}

		public AABB(IEnumerable<Vector3> pointCloud)
		{
			Vector3 vector = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
			Vector3 vector2 = new Vector3(float.MinValue, float.MinValue, float.MinValue);
			foreach (Vector3 item in pointCloud)
			{
				vector = Vector3.Min(item, vector);
				vector2 = Vector3.Max(item, vector2);
			}
			_center = (vector + vector2) * 0.5f;
			_size = vector2 - vector;
			_isValid = true;
		}

		public AABB(IEnumerable<Vector2> pointCloud)
		{
			Vector2 vector = new Vector2(float.MaxValue, float.MaxValue);
			Vector2 vector2 = new Vector2(float.MinValue, float.MinValue);
			foreach (Vector2 item in pointCloud)
			{
				vector = Vector2.Min(item, vector);
				vector2 = Vector2.Max(item, vector2);
			}
			_center = (vector + vector2) * 0.5f;
			_size = vector2 - vector;
			_isValid = true;
		}

		public static AABB GetInvalid()
		{
			return default(AABB);
		}

		public void Inflate(float amount)
		{
			Size += Vector3Ex.FromValue(amount);
		}

		public void Inflate(Vector3 amount)
		{
			Size += amount;
		}

		public void Encapsulate(Vector3 point)
		{
			Vector3 min = Min;
			Vector3 max = Max;
			if (point.x < min.x)
			{
				min.x = point.x;
			}
			if (point.x > max.x)
			{
				max.x = point.x;
			}
			if (point.y < min.y)
			{
				min.y = point.y;
			}
			if (point.y > max.y)
			{
				max.y = point.y;
			}
			if (point.z < min.z)
			{
				min.z = point.z;
			}
			if (point.z > max.z)
			{
				max.z = point.z;
			}
			_isValid = true;
			Min = min;
			Max = max;
		}

		public void Encapsulate(IEnumerable<Vector3> points)
		{
			foreach (Vector3 point in points)
			{
				Encapsulate(point);
			}
		}

		public void Encapsulate(AABB aabb)
		{
			Vector3 min = Min;
			Vector3 max = Max;
			Vector3 min2 = aabb.Min;
			Vector3 max2 = aabb.Max;
			if (min2.x < min.x)
			{
				min.x = min2.x;
			}
			if (min2.y < min.y)
			{
				min.y = min2.y;
			}
			if (min2.z < min.z)
			{
				min.z = min2.z;
			}
			if (max2.x > max.x)
			{
				max.x = max2.x;
			}
			if (max2.y > max.y)
			{
				max.y = max2.y;
			}
			if (max2.z > max.z)
			{
				max.z = max2.z;
			}
			_isValid = true;
			Min = min;
			Max = max;
		}

		public void Transform(Matrix4x4 transformMatrix)
		{
			BoxMath.TransformBox(_center, _size, transformMatrix, out _center, out _size);
		}

		public bool ContainsPoint(Vector3 point)
		{
			return BoxMath.ContainsPoint(point, _center, _size, Quaternion.identity);
		}

		public List<Vector3> GetCornerPoints()
		{
			return BoxMath.CalcBoxCornerPoints(_center, _size, Quaternion.identity);
		}

		public List<Vector3> GetCenterAndCornerPoints()
		{
			List<Vector3> cornerPoints = GetCornerPoints();
			cornerPoints.Add(Center);
			return cornerPoints;
		}

		public List<Vector2> GetScreenCornerPoints(Camera camera)
		{
			List<Vector3> cornerPoints = GetCornerPoints();
			List<Vector2> list = new List<Vector2>(cornerPoints.Count);
			foreach (Vector3 item in cornerPoints)
			{
				list.Add(camera.WorldToScreenPoint(item));
			}
			return list;
		}

		public List<Vector2> GetScreenCenterAndCornerPoints(Camera camera)
		{
			List<Vector3> centerAndCornerPoints = GetCenterAndCornerPoints();
			List<Vector2> list = new List<Vector2>(centerAndCornerPoints.Count);
			foreach (Vector3 item in centerAndCornerPoints)
			{
				list.Add(camera.WorldToScreenPoint(item));
			}
			return list;
		}

		public Rect GetScreenRectangle(Camera camera)
		{
			List<Vector2> screenCornerPoints = GetScreenCornerPoints(camera);
			Vector3 lhs = screenCornerPoints[0];
			Vector3 lhs2 = screenCornerPoints[0];
			for (int i = 1; i < screenCornerPoints.Count; i++)
			{
				lhs = Vector3.Min(lhs, screenCornerPoints[i]);
				lhs2 = Vector3.Max(lhs2, screenCornerPoints[i]);
			}
			return Rect.MinMaxRect(lhs.x, lhs.y, lhs2.x, lhs2.y);
		}

		public Matrix4x4 GetUnitBoxTransform()
		{
			return Matrix4x4.TRS(Center, Quaternion.identity, Size);
		}

		public Bounds ToBounds()
		{
			return new Bounds(_center, _size);
		}

		private void RecalculateCenterAndSize(Vector3 min, Vector3 max)
		{
			_center = (min + max) * 0.5f;
			_size = max - min;
		}
	}
}
