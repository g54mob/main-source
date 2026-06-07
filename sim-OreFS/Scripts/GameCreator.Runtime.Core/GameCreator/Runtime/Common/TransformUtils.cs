using System.Text;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	public static class TransformUtils
	{
		public static Vector3 TransformPoint(Vector3 point, Vector3 position, Quaternion rotation, Vector3 scale)
		{
			return Matrix4x4.TRS(position, rotation, scale).MultiplyPoint3x4(point);
		}

		public static Vector3 InverseTransformPoint(Vector3 point, Vector3 position, Quaternion rotation, Vector3 scale)
		{
			return Matrix4x4.TRS(position, rotation, scale).inverse.MultiplyPoint3x4(point);
		}

		public static Quaternion TransformRotation(Quaternion value, Vector3 position, Quaternion rotation, Vector3 scale)
		{
			Matrix4x4 matrix4x = Matrix4x4.TRS(position, rotation, scale);
			Vector3 forward = matrix4x.MultiplyVector(value * Vector3.forward);
			Vector3 upwards = matrix4x.MultiplyVector(value * Vector3.up);
			return Quaternion.LookRotation(forward, upwards);
		}

		public static Quaternion InverseTransformRotation(Quaternion value, Vector3 position, Quaternion rotation, Vector3 scale)
		{
			Matrix4x4 matrix4x = Matrix4x4.Inverse(Matrix4x4.TRS(position, rotation, scale));
			Vector3 forward = matrix4x.MultiplyVector(value * Vector3.forward);
			Vector3 upwards = matrix4x.MultiplyVector(value * Vector3.up);
			return Quaternion.LookRotation(forward, upwards);
		}

		public static string GetHierarchyPath(Transform transform, Transform parent = null)
		{
			if (transform == null)
			{
				return string.Empty;
			}
			StringBuilder stringBuilder = new StringBuilder(transform.gameObject.name);
			while (transform.parent != null && transform.parent != parent)
			{
				transform = transform.parent;
				stringBuilder.Insert(0, transform.gameObject.name + "/");
			}
			return stringBuilder.ToString();
		}
	}
}
