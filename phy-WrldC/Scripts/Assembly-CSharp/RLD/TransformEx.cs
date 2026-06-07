using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public static class TransformEx
	{
		public static void TransformPoints(this Transform transform, List<Vector3> points)
		{
			for (int i = 0; i < points.Count; i++)
			{
				points[i] = transform.TransformPoint(points[i]);
			}
		}

		public static List<Transform> GetGameObjectTransformCollection(IEnumerable<GameObject> gameObjects)
		{
			List<Transform> list = new List<Transform>(10);
			foreach (GameObject gameObject in gameObjects)
			{
				list.Add(gameObject.transform);
			}
			return list;
		}

		public static List<Transform> FilterParentsOnly(IEnumerable<Transform> transforms)
		{
			if (transforms == null)
			{
				return new List<Transform>();
			}
			List<Transform> list = new List<Transform>(10);
			foreach (Transform transform in transforms)
			{
				bool flag = false;
				foreach (Transform transform2 in transforms)
				{
					if (transform2 != transform && transform.IsChildOf(transform2.transform))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					list.Add(transform);
				}
			}
			return list;
		}

		public static void SetWorldScale(this Transform transform, Vector3 worldScale)
		{
			Transform parent = transform.parent;
			transform.parent = null;
			transform.localScale = worldScale;
			transform.parent = parent;
		}

		public static void ScaleFromPivot(this Transform transform, Vector3 scaleFactor, Vector3 pivot)
		{
			Vector3 lossyScale = transform.lossyScale;
			lossyScale = Vector3.Scale(lossyScale, scaleFactor);
			transform.SetWorldScale(lossyScale);
			Vector3 right = transform.right;
			Vector3 up = transform.up;
			Vector3 forward = transform.forward;
			Vector3 lhs = transform.position - pivot;
			float num = Vector3.Dot(lhs, right) * scaleFactor.x;
			float num2 = Vector3.Dot(lhs, up) * scaleFactor.y;
			float num3 = Vector3.Dot(lhs, forward) * scaleFactor.z;
			transform.position = pivot + right * num + up * num2 + forward * num3;
		}

		public static void RotateAroundPivot(this Transform transform, Quaternion rotation, Vector3 pivot)
		{
			Vector3 vector = transform.position - pivot;
			transform.rotation = rotation * transform.rotation;
			vector = rotation * vector;
			transform.position = pivot + vector;
		}

		public static Vector3 GetLocalAxis(this Transform transform, AxisDescriptor axisDesc)
		{
			Vector3 vector = transform.right;
			if (axisDesc.Index == 1)
			{
				vector = transform.up;
			}
			else if (axisDesc.Index == 2)
			{
				vector = transform.forward;
			}
			if (axisDesc.Sign == AxisSign.Negative)
			{
				vector = -vector;
			}
			return vector;
		}

		public static Plane GetLocalPlane(this Transform transform, PlaneDescriptor planeDesc)
		{
			Vector3 localAxis = transform.GetLocalAxis(planeDesc.FirstAxisDescriptor);
			Vector3 localAxis2 = transform.GetLocalAxis(planeDesc.SecondAxisDescriptor);
			return new Plane(Vector3.Normalize(Vector3.Cross(localAxis, localAxis2)), transform.position);
		}

		public static Quaternion Align(this Transform transform, Vector3 normAlignVector, TransformAxis alignmentAxis)
		{
			Vector3 vector = transform.up;
			switch (alignmentAxis)
			{
			case TransformAxis.PositiveX:
				vector = transform.right;
				break;
			case TransformAxis.NegativeX:
				vector = -transform.right;
				break;
			case TransformAxis.NegativeY:
				vector = -transform.up;
				break;
			case TransformAxis.PositiveZ:
				vector = transform.forward;
				break;
			case TransformAxis.NegativeZ:
				vector = -transform.forward;
				break;
			}
			float num = Vector3.Dot(vector, normAlignVector);
			if (1f - num < 1E-05f)
			{
				return Quaternion.identity;
			}
			Vector3 axis = Vector3.zero;
			if (num + 1f < 1E-05f)
			{
				switch (alignmentAxis)
				{
				case TransformAxis.PositiveX:
					axis = transform.up;
					break;
				case TransformAxis.NegativeX:
					axis = -transform.up;
					break;
				case TransformAxis.PositiveY:
					axis = transform.right;
					break;
				case TransformAxis.NegativeY:
					axis = -transform.right;
					break;
				case TransformAxis.PositiveZ:
					axis = transform.up;
					break;
				case TransformAxis.NegativeZ:
					axis = -transform.up;
					break;
				}
			}
			else
			{
				axis = Vector3.Normalize(Vector3.Cross(vector, normAlignVector));
			}
			float angle = Vector3Ex.SignedAngle(vector, normAlignVector, axis);
			transform.Rotate(axis, angle, Space.World);
			return Quaternion.AngleAxis(angle, axis);
		}
	}
}
