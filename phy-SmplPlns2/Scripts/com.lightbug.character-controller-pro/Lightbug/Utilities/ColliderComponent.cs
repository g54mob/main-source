using System;
using UnityEngine;

namespace Lightbug.Utilities
{
	public abstract class ColliderComponent : MonoBehaviour
	{
		public delegate void PenetrationDelegate(ref Vector3 bodyPosition, ref Quaternion bodyRotation, Transform otherColliderTransform, Vector3 penetrationDirection, float penetrationDistance);

		public abstract Vector3 Size { get; set; }

		public abstract Vector3 Offset { get; set; }

		public abstract Vector3 BoundsSize { get; }

		public Vector3 Center => base.transform.position + base.transform.TransformVectorUnscaled(Offset);

		public static ColliderComponent CreateInstance(GameObject gameObject, bool includeChildren = true)
		{
			Collider2D collider2D = (includeChildren ? gameObject.GetComponentInChildren<Collider2D>() : gameObject.GetComponent<Collider2D>());
			Collider collider = (includeChildren ? gameObject.GetComponentInChildren<Collider>() : gameObject.GetComponent<Collider>());
			if (collider2D != null)
			{
				BoxCollider2D boxCollider2D = null;
				try
				{
					boxCollider2D = (BoxCollider2D)collider2D;
				}
				catch (Exception)
				{
				}
				if (boxCollider2D != null)
				{
					return gameObject.AddComponent<BoxColliderComponent2D>();
				}
				CircleCollider2D circleCollider2D = null;
				try
				{
					circleCollider2D = (CircleCollider2D)collider2D;
				}
				catch (Exception)
				{
				}
				if (circleCollider2D != null)
				{
					return gameObject.AddComponent<SphereColliderComponent2D>();
				}
				CapsuleCollider2D capsuleCollider2D = null;
				try
				{
					capsuleCollider2D = (CapsuleCollider2D)collider2D;
				}
				catch (Exception)
				{
				}
				if (capsuleCollider2D != null)
				{
					return gameObject.AddComponent<CapsuleColliderComponent2D>();
				}
			}
			else if (collider != null)
			{
				BoxCollider boxCollider = null;
				try
				{
					boxCollider = (BoxCollider)collider;
				}
				catch (Exception)
				{
				}
				if (boxCollider != null)
				{
					return gameObject.AddComponent<BoxColliderComponent3D>();
				}
				SphereCollider sphereCollider = null;
				try
				{
					sphereCollider = (SphereCollider)collider;
				}
				catch (Exception)
				{
				}
				if (sphereCollider != null)
				{
					return gameObject.AddComponent<SphereColliderComponent3D>();
				}
				CapsuleCollider capsuleCollider = null;
				try
				{
					capsuleCollider = (CapsuleCollider)collider;
				}
				catch (Exception)
				{
				}
				if (capsuleCollider != null)
				{
					return gameObject.AddComponent<CapsuleColliderComponent3D>();
				}
			}
			return null;
		}

		public abstract bool ComputePenetration(ref Vector3 position, ref Quaternion rotation, PenetrationDelegate Action);

		public abstract Vector3 ComputePenetrationVector(ref Vector3 position, ref Quaternion rotation, PenetrationDelegate Action);

		public abstract int OverlapBody(Vector3 position, Quaternion rotation);

		protected abstract void OnEnable();

		protected abstract void OnDisable();

		protected virtual void Awake()
		{
			base.hideFlags = HideFlags.None;
		}
	}
}
