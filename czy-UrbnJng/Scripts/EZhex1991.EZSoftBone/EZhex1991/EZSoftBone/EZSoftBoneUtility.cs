using UnityEngine;

namespace EZhex1991.EZSoftBone
{
	public static class EZSoftBoneUtility
	{
		public static Vector3 Abs(this Vector3 v)
		{
			return new Vector3(Mathf.Abs(v.x), Mathf.Abs(v.y), Mathf.Abs(v.z));
		}

		public static float Max(this Vector3 v)
		{
			return Mathf.Max(v.x, Mathf.Max(v.y, v.z));
		}

		public static bool Contains(this LayerMask mask, int layer)
		{
			return ((int)mask | (1 << layer)) == (int)mask;
		}

		public static void GetCapsuleParams(CapsuleCollider collider, out Vector3 center0, out Vector3 center1, out float radius)
		{
			Vector3 vector = collider.transform.lossyScale.Abs();
			radius = collider.radius;
			center0 = (center1 = collider.center);
			float num = collider.height * 0.5f;
			switch (collider.direction)
			{
			case 0:
				radius *= Mathf.Max(vector.y, vector.z);
				num = Mathf.Max(0f, num - radius / vector.x);
				center0.x -= num;
				center1.x += num;
				break;
			case 1:
				radius *= Mathf.Max(vector.x, vector.z);
				num = Mathf.Max(0f, num - radius / vector.y);
				center0.y -= num;
				center1.y += num;
				break;
			case 2:
				radius *= Mathf.Max(vector.x, vector.y);
				num = Mathf.Max(0f, num - radius / vector.z);
				center0.z -= num;
				center1.z += num;
				break;
			}
			center0 = collider.transform.TransformPoint(center0);
			center1 = collider.transform.TransformPoint(center1);
		}

		public static void GetCylinderParams(Transform transform, out Vector3 center, out Vector3 direction, out float radius, out float height)
		{
			Vector3 vector = transform.lossyScale.Abs();
			center = transform.position;
			direction = transform.up;
			radius = Mathf.Max(vector.x, vector.z) * 0.5f;
			height = vector.y;
		}

		public static void PointOutsideSphere(ref Vector3 position, SphereCollider collider, float spacing)
		{
			Vector3 v = collider.transform.lossyScale.Abs();
			float num = collider.radius * v.Max();
			PointOutsideSphere(ref position, collider.transform.TransformPoint(collider.center), num + spacing);
		}

		private static void PointOutsideSphere(ref Vector3 position, Vector3 spherePosition, float radius)
		{
			Vector3 vector = position - spherePosition;
			if (vector.magnitude < radius)
			{
				position = spherePosition + vector.normalized * radius;
			}
		}

		public static void PointInsideSphere(ref Vector3 position, SphereCollider collider, float spacing)
		{
			PointInsideSphere(ref position, collider.transform.TransformPoint(collider.center), collider.radius - spacing);
		}

		private static void PointInsideSphere(ref Vector3 position, Vector3 spherePosition, float radius)
		{
			Vector3 vector = position - spherePosition;
			if (vector.magnitude > radius)
			{
				position = spherePosition + vector.normalized * radius;
			}
		}

		public static void PointOutsideCapsule(ref Vector3 position, CapsuleCollider collider, float spacing)
		{
			GetCapsuleParams(collider, out var center, out var center2, out var radius);
			PointOutsideCapsule(ref position, center, center2, radius + spacing);
		}

		private static void PointOutsideCapsule(ref Vector3 position, Vector3 center0, Vector3 center1, float radius)
		{
			Vector3 vector = center1 - center0;
			Vector3 vector2 = position - center0;
			float num = Vector3.Dot(vector, vector2);
			if (num <= 0f)
			{
				PointOutsideSphere(ref position, center0, radius);
				return;
			}
			if (num >= vector.sqrMagnitude)
			{
				PointOutsideSphere(ref position, center1, radius);
				return;
			}
			Vector3 vector3 = vector2 - Vector3.Project(vector2, vector);
			float num2 = radius - vector3.magnitude;
			if (num2 > 0f)
			{
				position += vector3.normalized * num2;
			}
		}

		public static void PointInsideCapsule(ref Vector3 position, CapsuleCollider collider, float spacing)
		{
			GetCapsuleParams(collider, out var center, out var center2, out var radius);
			PointInsideCapsule(ref position, center, center2, radius - spacing);
		}

		private static void PointInsideCapsule(ref Vector3 position, Vector3 center0, Vector3 center1, float radius)
		{
			Vector3 vector = center1 - center0;
			Vector3 vector2 = position - center0;
			float num = Vector3.Dot(vector, vector2);
			if (num <= 0f)
			{
				PointInsideSphere(ref position, center0, radius);
				return;
			}
			if (num >= vector.sqrMagnitude)
			{
				PointInsideSphere(ref position, center1, radius);
				return;
			}
			Vector3 vector3 = vector2 - Vector3.Project(vector2, vector);
			float num2 = radius - vector3.magnitude;
			if (num2 < 0f)
			{
				position += vector3.normalized * num2;
			}
		}

		public static void PointOutsideCylinder(ref Vector3 position, Transform transform, float spacing)
		{
			GetCylinderParams(transform, out var center, out var direction, out var radius, out var height);
			PointOutsideCylinder(ref position, center, direction, radius + spacing, height + spacing);
		}

		private static void PointOutsideCylinder(ref Vector3 position, Vector3 center, Vector3 direction, float radius, float height)
		{
			Vector3 vector = position - center;
			Vector3 vector2 = Vector3.Project(vector, direction);
			float num = height - vector2.magnitude;
			if (!(num > 0f))
			{
				return;
			}
			Vector3 vector3 = vector - vector2;
			float num2 = radius - vector3.magnitude;
			if (num2 > 0f)
			{
				if (num2 < num)
				{
					position += vector3.normalized * num2;
				}
				else
				{
					position += vector2.normalized * num;
				}
			}
		}

		public static void PointInsideCylinder(ref Vector3 position, Transform transform, float spacing)
		{
			GetCylinderParams(transform, out var center, out var direction, out var radius, out var height);
			PointInsideCylinder(ref position, center, direction, radius - spacing, height - spacing);
		}

		private static void PointInsideCylinder(ref Vector3 position, Vector3 center, Vector3 direction, float radius, float height)
		{
			Vector3 vector = position - center;
			Vector3 vector2 = Vector3.Project(vector, direction);
			float num = height - vector2.magnitude;
			Vector3 vector3 = vector - vector2;
			float num2 = radius - vector3.magnitude;
			if (num < 0f || num2 < 0f)
			{
				if (num2 < num)
				{
					position += vector3.normalized * num2;
				}
				else
				{
					position += vector2.normalized * num;
				}
			}
		}

		public static void PointOutsideBox(ref Vector3 position, BoxCollider collider, float spacing)
		{
			Vector3 position2 = collider.transform.InverseTransformPoint(position) - collider.center;
			PointOutsideBox(ref position2, collider.size.Abs() / 2f + collider.transform.InverseTransformVector(Vector3.one * spacing).Abs());
			position = collider.transform.TransformPoint(collider.center + position2);
		}

		private static void PointOutsideBox(ref Vector3 position, Vector3 boxSize)
		{
			Vector3 vector = position.Abs();
			if (!(vector.x < boxSize.x) || !(vector.y < boxSize.y) || !(vector.z < boxSize.z))
			{
				return;
			}
			Vector3 vector2 = (vector - boxSize).Abs();
			if (vector2.x < vector2.y)
			{
				if (vector2.x < vector2.z)
				{
					position.x = Mathf.Sign(position.x) * boxSize.x;
				}
				else
				{
					position.z = Mathf.Sign(position.z) * boxSize.z;
				}
			}
			else if (vector2.y < vector2.z)
			{
				position.y = Mathf.Sign(position.y) * boxSize.y;
			}
			else
			{
				position.z = Mathf.Sign(position.z) * boxSize.z;
			}
		}

		public static void PointInsideBox(ref Vector3 position, BoxCollider collider, float spacing)
		{
			Vector3 position2 = collider.transform.InverseTransformPoint(position) - collider.center;
			PointInsideBox(ref position2, collider.size.Abs() / 2f - collider.transform.InverseTransformVector(Vector3.one * spacing).Abs());
			position = collider.transform.TransformPoint(collider.center + position2);
		}

		private static void PointInsideBox(ref Vector3 position, Vector3 boxSize)
		{
			Vector3 vector = position.Abs();
			if (vector.x > boxSize.x)
			{
				position.x = Mathf.Sign(position.x) * boxSize.x;
			}
			if (vector.y > boxSize.y)
			{
				position.y = Mathf.Sign(position.y) * boxSize.y;
			}
			if (vector.z > boxSize.z)
			{
				position.z = Mathf.Sign(position.z) * boxSize.z;
			}
		}

		public static void PointOutsideCollider(ref Vector3 position, Collider collider, float spacing)
		{
			Vector3 vector = collider.ClosestPoint(position);
			if (position == vector)
			{
				Vector3 vector2 = position - collider.bounds.center;
				Debug.DrawLine(collider.bounds.center, vector, Color.red);
				position = vector + vector2.normalized * spacing;
				return;
			}
			Vector3 vector3 = position - vector;
			if (vector3.magnitude < spacing)
			{
				position = vector + vector3.normalized * spacing;
			}
		}

		public static void DrawGizmosArrow(Vector3 startPoint, Vector3 direction, float halfWidth, Vector3 normal)
		{
			Vector3 vector = Vector3.Cross(direction, normal).normalized * halfWidth;
			Vector3[] array = new Vector3[8];
			array[0] = startPoint + vector * 0.5f;
			array[1] = array[0] + direction * 0.5f;
			array[2] = array[1] + vector * 0.5f;
			array[3] = startPoint + direction;
			array[4] = startPoint - vector + direction * 0.5f;
			array[5] = array[4] + vector * 0.5f;
			array[6] = startPoint - vector * 0.5f;
			array[7] = array[0];
			DrawGizmosPolyLine(array);
		}

		public static void DrawGizmosPolyLine(params Vector3[] vertices)
		{
			for (int i = 0; i < vertices.Length - 1; i++)
			{
				Gizmos.DrawLine(vertices[i], vertices[i + 1]);
			}
		}
	}
}
