using UnityEngine;

namespace Jundroo.Common.Utils
{
	public static class PoseUtility
	{
		public static void DebugDraw(this Pose pose, float size = 0.2f)
		{
			Debug.DrawLine(pose.position, pose.position + size * pose.right, Color.red);
			Debug.DrawLine(pose.position, pose.position + size * pose.up, Color.green);
			Debug.DrawLine(pose.position, pose.position + size * pose.forward, Color.blue);
		}

		public static Pose GetLocalPose(this Transform transform)
		{
			return new Pose(transform.localPosition, transform.localRotation);
		}

		public static Pose GetWorldPose(this Transform transform)
		{
			return new Pose(transform.position, transform.rotation);
		}

		public static void InverseTransformBy(this ref Pose pose, Pose space)
		{
			Quaternion quaternion = Quaternion.Inverse(space.rotation);
			pose.position = quaternion * (pose.position - space.position);
			pose.rotation = quaternion * pose.rotation;
		}

		public static Vector3 InverseTransformPoint(this Pose parent, Vector3 point)
		{
			return Quaternion.Inverse(parent.rotation) * (point - parent.position);
		}

		public static void InverseTransformPoint(this ref Vector3 point, ref Pose space)
		{
			point = Quaternion.Inverse(space.rotation) * (point - space.position);
		}

		public static Pose InverseTransformPose(this Pose parent, Pose world)
		{
			Quaternion quaternion = Quaternion.Inverse(parent.rotation);
			return new Pose(quaternion * (world.position - parent.position), quaternion * world.rotation);
		}

		public static Pose InverseTransformPose(this Transform transform, Pose pose)
		{
			Quaternion quaternion = Quaternion.Inverse(transform.rotation);
			Pose result = new Pose(quaternion * (pose.position - transform.position), quaternion * pose.rotation);
			result.position.Scale(transform.localScale);
			return result;
		}

		public static Pose Inverse(this Pose pose)
		{
			Quaternion quaternion = Quaternion.Inverse(pose.rotation);
			return new Pose(quaternion * -pose.position, quaternion);
		}

		public static Pose Lerp(Pose a, Pose b, float t, bool slerp = false)
		{
			if (slerp)
			{
				return new Pose(Vector3.Lerp(a.position, b.position, t), Quaternion.Slerp(a.rotation, b.rotation, t));
			}
			return new Pose(Vector3.Lerp(a.position, b.position, t), Quaternion.Lerp(a.rotation, b.rotation, t));
		}

		public static void SetGlobalPose(this Transform transform, Pose pose)
		{
			transform.SetPositionAndRotation(pose.position, pose.rotation);
		}

		public static void SetLocalPose(this Transform transform, Pose pose)
		{
			transform.localPosition = pose.position;
			transform.localRotation = pose.rotation;
		}

		public static void TransformBy(this ref Pose pose, Pose space)
		{
			pose.position = space.position + space.rotation * pose.position;
			pose.rotation = space.rotation * pose.rotation;
		}

		public static Vector3 TransformPoint(this Pose parent, Vector3 point)
		{
			return parent.position + parent.rotation * point;
		}

		public static void TransformPoint(this ref Vector3 point, ref Pose space)
		{
			point = space.position + space.rotation * point;
		}

		public static Pose TransformPose(this Pose parent, Pose child)
		{
			return new Pose(parent.position + parent.rotation * child.position, parent.rotation * child.rotation);
		}

		public static Pose TransformPose(this Transform transform, Pose pose)
		{
			return new Pose(transform.TransformPoint(pose.position), transform.rotation * pose.rotation);
		}

		public static Vector3 TransformVector(this Pose parent, Vector3 point)
		{
			return parent.rotation * point;
		}

		public static void TransformVector(this ref Vector3 point, ref Pose space)
		{
			point = space.rotation * point;
		}
	}
}
