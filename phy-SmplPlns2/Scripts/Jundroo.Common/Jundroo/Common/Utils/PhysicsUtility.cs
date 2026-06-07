using System.Collections.Generic;
using UnityEngine;

namespace Jundroo.Common.Utils
{
	public static class PhysicsUtility
	{
		public class RaycastHitDistanceComparer : IComparer<RaycastHit>
		{
			public static RaycastHitDistanceComparer Default { get; } = new RaycastHitDistanceComparer();

			public int Compare(RaycastHit x, RaycastHit y)
			{
				if (x.distance < y.distance)
				{
					return -1;
				}
				if (x.distance > y.distance)
				{
					return 1;
				}
				return 0;
			}
		}

		private static RaycastHit[] _raycastHitBuffer = new RaycastHit[200];

		public static void DepenetrateCollider(CapsuleCollider collider, Transform transToMove, Vector3 depenetrationDirection, float epsilon, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
		{
			if (OverlapCapsule(collider, layerMask, queryTriggerInteraction).Length == 0)
			{
				return;
			}
			Vector3 colliderUp = GetColliderUp(collider);
			float num = collider.radius * 2f;
			float num2 = (collider.height - num) * Mathf.Abs(Vector3.Dot(colliderUp, depenetrationDirection)) + num;
			int num3 = 0;
			bool flag = true;
			while (Mathf.Abs(num2) > epsilon && num3++ < 100)
			{
				transToMove.position += depenetrationDirection * num2;
				UnityEngine.Physics.SyncTransforms();
				if (OverlapCapsule(collider, layerMask, QueryTriggerInteraction.Ignore).Length == 0)
				{
					if (flag)
					{
						num2 = (0f - num2) * 0.5f;
					}
					flag = false;
				}
				else
				{
					if (!flag)
					{
						num2 = (0f - num2) * 0.5f;
					}
					flag = true;
				}
			}
			if (num3 >= 100)
			{
				Debug.LogWarning($"Reached MaxSteps({100}) while tryinig to depenetrate the collider: {collider.name}");
			}
		}

		public static float GetAngularVelocityAroundAxis(Vector3 axis, Quaternion axisTransformRotation, Vector3 angularVelocityWorld)
		{
			return Vector3.Dot(axis, Quaternion.Inverse(axisTransformRotation) * angularVelocityWorld);
		}

		public static Vector3 GetColliderUp(CapsuleCollider collider)
		{
			switch (collider.direction)
			{
			case 0:
				return collider.transform.right;
			case 1:
				return collider.transform.up;
			case 2:
				return collider.transform.forward;
			default:
				Debug.LogError($"Unknown capsule collider direction: {collider.direction}");
				return collider.transform.up;
			}
		}

		public static float GetMomentOfInertiaAboutWorldAxis(Rigidbody rigidbody, Vector3 worldAxis)
		{
			if (rigidbody == null)
			{
				return 0f;
			}
			Vector3 normalized = worldAxis.normalized;
			if (normalized == Vector3.zero)
			{
				return 0f;
			}
			Vector3 vector = rigidbody.transform.InverseTransformDirection(normalized);
			Vector3 inertiaTensor = rigidbody.inertiaTensor;
			Vector3 vector2 = Quaternion.Inverse(rigidbody.inertiaTensorRotation) * vector;
			return inertiaTensor.x * vector2.x * vector2.x + inertiaTensor.y * vector2.y * vector2.y + inertiaTensor.z * vector2.z * vector2.z;
		}

		public static float GetWorldRadius(this SphereCollider collider)
		{
			Vector3 lossyScale = collider.transform.lossyScale;
			lossyScale.y = Mathf.Abs(lossyScale.y);
			lossyScale.z = Mathf.Abs(lossyScale.z);
			float num = Mathf.Abs(lossyScale.x);
			if (lossyScale.y > num)
			{
				num = lossyScale.y;
			}
			if (lossyScale.z > num)
			{
				num = lossyScale.z;
			}
			num *= collider.radius;
			if (num < 1E-05f)
			{
				return 1E-05f;
			}
			return num;
		}

		public static Collider[] OverlapCapsule(CapsuleCollider collider, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
		{
			Vector3 vector = GetColliderUp(collider) * (collider.height * 0.5f - collider.radius);
			Vector3 vector2 = collider.transform.TransformPoint(collider.center);
			return UnityEngine.Physics.OverlapCapsule(vector2 + vector, vector2 - vector, collider.radius, layerMask, queryTriggerInteraction);
		}

		public static void RaycastAll(Vector3 origin, Vector3 direction, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, List<RaycastHit> hits)
		{
			int num = 0;
			bool flag = false;
			while (!flag)
			{
				num = UnityEngine.Physics.RaycastNonAlloc(origin, direction, _raycastHitBuffer, maxDistance, layerMask, queryTriggerInteraction);
				if (num == _raycastHitBuffer.Length)
				{
					_raycastHitBuffer = new RaycastHit[num * 2];
				}
				else
				{
					flag = true;
				}
			}
			if (num >= hits.Capacity)
			{
				hits.Capacity = num;
			}
			for (int i = 0; i < num; i++)
			{
				hits.Add(_raycastHitBuffer[i]);
			}
		}

		public static void RaycastAll(Vector3 origin, Vector3 direction, float maxDistance, int layerMask, List<RaycastHit> hits)
		{
			RaycastAll(origin, direction, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal, hits);
		}

		public static void RaycastAll(Ray ray, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, List<RaycastHit> hits)
		{
			RaycastAll(ray.origin, ray.direction, maxDistance, layerMask, queryTriggerInteraction, hits);
		}

		public static void RaycastAll(Ray ray, float maxDistance, int layerMask, List<RaycastHit> hits)
		{
			RaycastAll(ray.origin, ray.direction, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal, hits);
		}

		public static T RaycastComponent<T>(Ray ray, float maxDistance, int layerMask) where T : MonoBehaviour
		{
			RaycastHit rayHit;
			return RaycastComponent<T>(ray, sphereCast: false, 0f, maxDistance, layerMask, out rayHit);
		}

		public static T RaycastComponent<T>(Ray ray, bool sphereCast, float sphereCastRadius, float maxDistance, int layerMask) where T : MonoBehaviour
		{
			RaycastHit rayHit;
			return RaycastComponent<T>(ray, sphereCast: false, sphereCastRadius, maxDistance, layerMask, out rayHit);
		}

		public static T RaycastComponent<T>(Ray ray, bool sphereCast, float sphereCastRadius, float maxDistance, int layerMask, out RaycastHit rayHit) where T : MonoBehaviour
		{
			T result = null;
			if ((!sphereCast) ? UnityEngine.Physics.Raycast(ray, out rayHit, maxDistance, layerMask) : UnityEngine.Physics.SphereCast(ray, sphereCastRadius, out rayHit, maxDistance, layerMask))
			{
				return rayHit.collider.gameObject.GetComponentInParent<T>();
			}
			return result;
		}

		public static void SphereCastAll(Vector3 origin, float radius, Vector3 direction, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, List<RaycastHit> hits)
		{
			int num = 0;
			bool flag = false;
			while (!flag)
			{
				num = UnityEngine.Physics.SphereCastNonAlloc(origin, radius, direction, _raycastHitBuffer, maxDistance, layerMask, queryTriggerInteraction);
				if (num == _raycastHitBuffer.Length)
				{
					_raycastHitBuffer = new RaycastHit[num * 2];
				}
				else
				{
					flag = true;
				}
			}
			if (num >= hits.Capacity)
			{
				hits.Capacity = num;
			}
			for (int i = 0; i < num; i++)
			{
				hits.Add(_raycastHitBuffer[i]);
			}
		}

		public static void SphereCastAll(Vector3 origin, float radius, Vector3 direction, float maxDistance, int layerMask, List<RaycastHit> hits)
		{
			SphereCastAll(origin, radius, direction, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal, hits);
		}

		public static void SphereCastAll(Ray ray, float radius, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, List<RaycastHit> hits)
		{
			SphereCastAll(ray.origin, radius, ray.direction, maxDistance, layerMask, queryTriggerInteraction, hits);
		}

		public static void SphereCastAll(Ray ray, float radius, float maxDistance, int layerMask, List<RaycastHit> hits)
		{
			SphereCastAll(ray.origin, radius, ray.direction, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal, hits);
		}
	}
}
