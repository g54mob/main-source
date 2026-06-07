using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public struct OBB
	{
		private Vector3 _size;

		private Vector3 _center;

		private Quaternion _rotation;

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

		public Quaternion Rotation
		{
			get
			{
				return _rotation;
			}
			set
			{
				_rotation = value;
			}
		}

		public Matrix4x4 RotationMatrix => Matrix4x4.TRS(Vector3.zero, _rotation, Vector3.one);

		public Vector3 Right => _rotation * Vector3.right;

		public Vector3 Up => _rotation * Vector3.up;

		public Vector3 Look => _rotation * Vector3.forward;

		public OBB(Vector3 center, Vector3 size)
		{
			_center = center;
			_size = size;
			_rotation = Quaternion.identity;
			_isValid = true;
		}

		public OBB(Vector3 center, Vector3 size, Quaternion rotation)
		{
			_center = center;
			_size = size;
			_rotation = rotation;
			_isValid = true;
		}

		public OBB(Vector3 center, Quaternion rotation)
		{
			_center = center;
			_size = Vector3.zero;
			_rotation = rotation;
			_isValid = true;
		}

		public OBB(Quaternion rotation)
		{
			_center = Vector3.zero;
			_size = Vector3.zero;
			_rotation = rotation;
			_isValid = true;
		}

		public OBB(Bounds bounds, Quaternion rotation)
		{
			_center = bounds.center;
			_size = bounds.size;
			_rotation = rotation;
			_isValid = true;
		}

		public OBB(AABB aabb)
		{
			_center = aabb.Center;
			_size = aabb.Size;
			_rotation = Quaternion.identity;
			_isValid = true;
		}

		public OBB(AABB aabb, Quaternion rotation)
		{
			_center = aabb.Center;
			_size = aabb.Size;
			_rotation = rotation;
			_isValid = true;
		}

		public OBB(AABB modelSpaceAABB, Transform worldTransform)
		{
			_size = Vector3.Scale(modelSpaceAABB.Size, worldTransform.lossyScale);
			_center = worldTransform.TransformPoint(modelSpaceAABB.Center);
			_rotation = worldTransform.rotation;
			_isValid = true;
		}

		public OBB(OBB copy)
		{
			_size = copy._size;
			_center = copy._center;
			_rotation = copy._rotation;
			_isValid = copy._isValid;
		}

		public static OBB GetInvalid()
		{
			return default(OBB);
		}

		public void Inflate(float amount)
		{
			Size += Vector3Ex.FromValue(amount);
		}

		public Matrix4x4 GetUnitBoxTransform()
		{
			if (!_isValid)
			{
				return Matrix4x4.identity;
			}
			return Matrix4x4.TRS(Center, Rotation, Size);
		}

		public List<Vector3> GetCornerPoints()
		{
			return BoxMath.CalcBoxCornerPoints(_center, _size, _rotation);
		}

		public List<Vector3> GetCenterAndCornerPoints()
		{
			List<Vector3> cornerPoints = GetCornerPoints();
			cornerPoints.Add(Center);
			return cornerPoints;
		}

		public void Encapsulate(OBB otherOBB)
		{
			List<Vector3> points = BoxMath.CalcBoxCornerPoints(otherOBB.Center, otherOBB.Size, otherOBB.Rotation);
			List<Vector3> points2 = Matrix4x4.TRS(Center, Rotation, Vector3.one).inverse.TransformPoints(points);
			AABB aABB = new AABB(Vector3.zero, Size);
			aABB.Encapsulate(points2);
			Center = Rotation * aABB.Center + Center;
			Size = aABB.Size;
		}

		public Vector3 GetPointFaceNormal(Vector3 pointOnFace)
		{
			Vector3[] normalizedAxes = Matrix4x4.TRS(Vector3.zero, _rotation, Vector3.one).GetNormalizedAxes();
			Vector3 extents = Extents;
			Vector3 lhs = pointOnFace - _center;
			float num = float.MaxValue;
			float num2 = -1f;
			Vector3 vector = Vector3.zero;
			for (int i = 0; i < 3; i++)
			{
				Vector3 vector2 = normalizedAxes[i];
				float f = Vector3.Dot(lhs, vector2);
				float num3 = Mathf.Abs(Mathf.Abs(f) - extents[i]);
				if (num3 < num)
				{
					num = num3;
					vector = vector2;
					num2 = Mathf.Sign(f);
				}
			}
			return Vector3.Normalize(vector * num2);
		}

		public bool IntersectsOBB(OBB otherOBB)
		{
			return BoxMath.BoxIntersectsBox(_center, _size, _rotation, otherOBB.Center, otherOBB.Size, otherOBB.Rotation);
		}

		public Vector3 GetClosestPoint(Vector3 point)
		{
			return BoxMath.CalcBoxPtClosestToPt(point, _center, _size, _rotation);
		}

		public bool IntersectsSphere(Sphere sphere)
		{
			Vector3 closestPoint = GetClosestPoint(sphere.Center);
			return sphere.ContainsPoint(closestPoint);
		}
	}
}
