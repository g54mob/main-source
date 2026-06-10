using System;
using System.Collections.Generic;
using UnityEngine;

namespace FIMSpace
{
	public static class FEngineering
	{
		private static Plane axis2DProjection;

		private static PhysicMaterial _slidingMat;

		private static PhysicMaterial _frictMat;

		private static PhysicsMaterial2D _slidingMat2D;

		private static PhysicsMaterial2D _frictMat2D;

		public static PhysicMaterial PMSliding
		{
			get
			{
				if ((bool)_slidingMat)
				{
					return _slidingMat;
				}
				_slidingMat = new PhysicMaterial("Slide");
				_slidingMat.frictionCombine = PhysicMaterialCombine.Minimum;
				_slidingMat.dynamicFriction = 0f;
				_slidingMat.staticFriction = 0f;
				return _slidingMat;
			}
		}

		public static PhysicMaterial PMFrict
		{
			get
			{
				if ((bool)_frictMat)
				{
					return _frictMat;
				}
				_frictMat = new PhysicMaterial("Friction");
				_frictMat.frictionCombine = PhysicMaterialCombine.Maximum;
				_frictMat.dynamicFriction = 10f;
				_frictMat.staticFriction = 10f;
				return _frictMat;
			}
		}

		public static PhysicsMaterial2D PMSliding2D
		{
			get
			{
				if ((bool)_slidingMat2D)
				{
					return _slidingMat2D;
				}
				_slidingMat2D = new PhysicsMaterial2D("Slide2D");
				_slidingMat2D.friction = 0f;
				return _slidingMat2D;
			}
		}

		public static PhysicsMaterial2D PMFrict2D
		{
			get
			{
				if ((bool)_frictMat2D)
				{
					return _frictMat2D;
				}
				_frictMat2D = new PhysicsMaterial2D("Friction2D");
				_frictMat2D.friction = 5f;
				return _frictMat2D;
			}
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			axis2DProjection = default(Plane);
			_slidingMat = null;
			_frictMat = null;
			_frictMat2D = null;
			_slidingMat2D = null;
		}

		public static bool VIsZero(this Vector3 vec)
		{
			if (vec.sqrMagnitude == 0f)
			{
				return true;
			}
			return false;
		}

		public static bool VIsSame(this Vector3 vec1, Vector3 vec2)
		{
			if (vec1.x != vec2.x)
			{
				return false;
			}
			if (vec1.y != vec2.y)
			{
				return false;
			}
			if (vec1.z != vec2.z)
			{
				return false;
			}
			return true;
		}

		public static Vector3 TransformVector(this Quaternion parentRot, Vector3 parentLossyScale, Vector3 childLocalPos)
		{
			return parentRot * Vector3.Scale(childLocalPos, parentLossyScale);
		}

		public static Vector3 TransformInDirection(this Quaternion childRotation, Vector3 parentLossyScale, Vector3 childLocalPos)
		{
			return childRotation * Vector3.Scale(childLocalPos, new Vector3((parentLossyScale.x > 0f) ? 1 : (-1), (parentLossyScale.y > 0f) ? 1 : (-1), (parentLossyScale.y > 0f) ? 1 : (-1)));
		}

		public static Vector3 InverseTransformVector(this Quaternion tRotation, Vector3 tLossyScale, Vector3 worldPos)
		{
			worldPos = Quaternion.Inverse(tRotation) * worldPos;
			return new Vector3(worldPos.x / tLossyScale.x, worldPos.y / tLossyScale.y, worldPos.z / tLossyScale.z);
		}

		public static Vector3 VAxis2DLimit(this Transform parent, Vector3 parentPos, Vector3 childPos, int axis = 3)
		{
			switch (axis)
			{
			case 3:
				axis2DProjection.SetNormalAndPosition(parent.forward, parentPos);
				break;
			case 2:
				axis2DProjection.SetNormalAndPosition(parent.up, parentPos);
				break;
			default:
				axis2DProjection.SetNormalAndPosition(parent.right, parentPos);
				break;
			}
			return axis2DProjection.normal * axis2DProjection.GetDistanceToPoint(childPos);
		}

		public static Quaternion QToLocal(this Quaternion parentRotation, Quaternion worldRotation)
		{
			return Quaternion.Inverse(parentRotation) * worldRotation;
		}

		public static Quaternion QToWorld(this Quaternion parentRotation, Quaternion localRotation)
		{
			return parentRotation * localRotation;
		}

		public static Quaternion QRotateChild(this Quaternion offset, Quaternion parentRot, Quaternion childLocalRot)
		{
			return offset * parentRot * childLocalRot;
		}

		public static Quaternion ClampRotation(this Vector3 current, Vector3 bounds)
		{
			WrapVector(current);
			if (current.x < 0f - bounds.x)
			{
				current.x = 0f - bounds.x;
			}
			else if (current.x > bounds.x)
			{
				current.x = bounds.x;
			}
			if (current.y < 0f - bounds.y)
			{
				current.y = 0f - bounds.y;
			}
			else if (current.y > bounds.y)
			{
				current.y = bounds.y;
			}
			if (current.z < 0f - bounds.z)
			{
				current.z = 0f - bounds.z;
			}
			else if (current.z > bounds.z)
			{
				current.z = bounds.z;
			}
			return Quaternion.Euler(current);
		}

		public static Vector3 QToAngularVelocity(this Quaternion deltaRotation, bool fix = false)
		{
			deltaRotation.ToAngleAxis(out var angle, out var axis);
			if (angle != 0f)
			{
				angle = Mathf.DeltaAngle(0f, angle);
				axis *= angle * (MathF.PI / 180f);
				if (fix)
				{
					axis /= Time.fixedDeltaTime;
				}
				if (float.IsNaN(axis.x))
				{
					return Vector3.zero;
				}
				if (float.IsNaN(axis.y))
				{
					return Vector3.zero;
				}
				if (float.IsNaN(axis.z))
				{
					return Vector3.zero;
				}
				return axis;
			}
			return Vector3.zero;
		}

		public static Vector3 QToAngularVelocity(this Quaternion currentRotation, Quaternion targetRotation, bool fix = false)
		{
			return (targetRotation * Quaternion.Inverse(currentRotation)).QToAngularVelocity(fix);
		}

		public static bool QIsZero(this Quaternion rot)
		{
			if (rot.x != 0f)
			{
				return false;
			}
			if (rot.y != 0f)
			{
				return false;
			}
			if (rot.z != 0f)
			{
				return false;
			}
			return true;
		}

		public static bool QIsSame(this Quaternion rot1, Quaternion rot2)
		{
			if (rot1.x != rot2.x)
			{
				return false;
			}
			if (rot1.y != rot2.y)
			{
				return false;
			}
			if (rot1.z != rot2.z)
			{
				return false;
			}
			if (rot1.w != rot2.w)
			{
				return false;
			}
			return true;
		}

		public static float WrapAngle(float angle)
		{
			angle %= 360f;
			if (angle > 180f)
			{
				return angle - 360f;
			}
			return angle;
		}

		public static Vector3 WrapVector(Vector3 angles)
		{
			return new Vector3(WrapAngle(angles.x), WrapAngle(angles.y), WrapAngle(angles.z));
		}

		public static float UnwrapAngle(float angle)
		{
			if (angle >= 0f)
			{
				return angle;
			}
			angle = (0f - angle) % 360f;
			return 360f - angle;
		}

		public static Vector3 UnwrapVector(Vector3 angles)
		{
			return new Vector3(UnwrapAngle(angles.x), UnwrapAngle(angles.y), UnwrapAngle(angles.z));
		}

		public static Quaternion SmoothDampRotation(this Quaternion current, Quaternion target, ref Quaternion velocityRef, float duration, float delta)
		{
			return current.SmoothDampRotation(target, ref velocityRef, duration, float.PositiveInfinity, delta);
		}

		public static Quaternion SmoothDampRotation(this Quaternion current, Quaternion target, ref Quaternion velocityRef, float duration, float maxSpeed, float delta)
		{
			float num = ((Quaternion.Dot(current, target) > 0f) ? 1f : (-1f));
			target.x *= num;
			target.y *= num;
			target.z *= num;
			target.w *= num;
			Vector4 normalized = new Vector4(Mathf.SmoothDamp(current.x, target.x, ref velocityRef.x, duration, maxSpeed, delta), Mathf.SmoothDamp(current.y, target.y, ref velocityRef.y, duration, maxSpeed, delta), Mathf.SmoothDamp(current.z, target.z, ref velocityRef.z, duration, maxSpeed, delta), Mathf.SmoothDamp(current.w, target.w, ref velocityRef.w, duration, maxSpeed, delta)).normalized;
			Vector4 vector = Vector4.Project(new Vector4(velocityRef.x, velocityRef.y, velocityRef.z, velocityRef.w), normalized);
			velocityRef.x -= vector.x;
			velocityRef.y -= vector.y;
			velocityRef.z -= vector.z;
			velocityRef.w -= vector.w;
			return new Quaternion(normalized.x, normalized.y, normalized.z, normalized.w);
		}

		public static bool SameDirection(this float a, float b)
		{
			if (!(a > 0f) || !(b > 0f))
			{
				if (a < 0f)
				{
					return b < 0f;
				}
				return false;
			}
			return true;
		}

		public static float PointDisperse01(int index, int baseV = 2)
		{
			float num = 0f;
			float num2 = 1f / (float)baseV;
			int num3 = index;
			while (num3 > 0)
			{
				num += num2 * (float)(num3 % baseV);
				num3 = Mathf.FloorToInt(num3 / baseV);
				num2 /= (float)baseV;
			}
			return num;
		}

		public static float PointDisperse(int index, int baseV = 2)
		{
			float num = 0f;
			float num2 = 1f / (float)baseV;
			int num3 = index;
			while (num3 > 0)
			{
				num += num2 * (float)(num3 % baseV);
				num3 = Mathf.FloorToInt(num3 / baseV);
				num2 /= (float)baseV;
			}
			return num - 0.5f;
		}

		public static float GetScaler(this Transform transform)
		{
			if (transform.lossyScale.x > transform.lossyScale.y)
			{
				if (transform.lossyScale.y > transform.lossyScale.z)
				{
					return transform.lossyScale.y;
				}
				return transform.lossyScale.z;
			}
			return transform.lossyScale.x;
		}

		public static Vector3 PosFromMatrix(this Matrix4x4 m)
		{
			return m.GetColumn(3);
		}

		public static Quaternion RotFromMatrix(this Matrix4x4 m)
		{
			return Quaternion.LookRotation(m.GetColumn(2), m.GetColumn(1));
		}

		public static Vector3 ScaleFromMatrix(this Matrix4x4 m)
		{
			return new Vector3(m.GetColumn(0).magnitude, m.GetColumn(1).magnitude, m.GetColumn(2).magnitude);
		}

		public static Bounds TransformBounding(Bounds b, Transform by)
		{
			return TransformBounding(b, by.localToWorldMatrix);
		}

		public static Bounds TransformBounding(Bounds b, Matrix4x4 mx)
		{
			Vector3 vector = mx.MultiplyPoint(b.min);
			Vector3 point = mx.MultiplyPoint(b.max);
			Vector3 point2 = mx.MultiplyPoint(new Vector3(b.max.x, b.center.y, b.min.z));
			Vector3 point3 = mx.MultiplyPoint(new Vector3(b.min.x, b.center.y, b.max.z));
			b = new Bounds(vector, Vector3.zero);
			b.Encapsulate(vector);
			b.Encapsulate(point);
			b.Encapsulate(point2);
			b.Encapsulate(point3);
			return b;
		}

		public static Bounds RotateBoundsByMatrix(this Bounds b, Quaternion rotation)
		{
			if (rotation.QIsZero())
			{
				return b;
			}
			Matrix4x4 matrix4x = Matrix4x4.Rotate(rotation);
			Bounds result = default(Bounds);
			Vector3 point = matrix4x.MultiplyPoint(new Vector3(b.max.x, b.min.y, b.max.z));
			Vector3 point2 = matrix4x.MultiplyPoint(new Vector3(b.max.x, b.min.y, b.min.z));
			Vector3 point3 = matrix4x.MultiplyPoint(new Vector3(b.min.x, b.min.y, b.min.z));
			Vector3 point4 = matrix4x.MultiplyPoint(new Vector3(b.min.x, b.min.y, b.max.z));
			result.Encapsulate(point);
			result.Encapsulate(point2);
			result.Encapsulate(point3);
			result.Encapsulate(point4);
			Vector3 point5 = matrix4x.MultiplyPoint(new Vector3(b.max.x, b.max.y, b.max.z));
			Vector3 point6 = matrix4x.MultiplyPoint(new Vector3(b.max.x, b.max.y, b.min.z));
			Vector3 point7 = matrix4x.MultiplyPoint(new Vector3(b.min.x, b.max.y, b.min.z));
			Vector3 point8 = matrix4x.MultiplyPoint(new Vector3(b.min.x, b.max.y, b.max.z));
			result.Encapsulate(point5);
			result.Encapsulate(point6);
			result.Encapsulate(point7);
			result.Encapsulate(point8);
			return result;
		}

		public static Bounds RotateLocalBounds(this Bounds b, Quaternion rotation)
		{
			float num = Quaternion.Angle(rotation, Quaternion.identity);
			if (num > 45f && num < 135f)
			{
				b.size = new Vector3(b.size.z, b.size.y, b.size.x);
			}
			if (num < 315f && num > 225f)
			{
				b.size = new Vector3(b.size.z, b.size.y, b.size.x);
			}
			return b;
		}

		public static int[] GetLayermaskValues(int mask, int optionsCount)
		{
			List<int> list = new List<int>();
			for (int i = 0; i < optionsCount; i++)
			{
				int num = 1 << i;
				if ((mask & num) != 0)
				{
					list.Add(i);
				}
			}
			return list.ToArray();
		}

		public static LayerMask GetLayerMaskUsingPhysicsProjectSettingsMatrix(int maskForLayer)
		{
			LayerMask layerMask = 0;
			for (int i = 0; i < 32; i++)
			{
				if (!Physics.GetIgnoreLayerCollision(maskForLayer, i))
				{
					layerMask = (int)layerMask | (1 << i);
				}
			}
			return layerMask;
		}
	}
}
