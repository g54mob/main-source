using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lightbug.Utilities
{
	public abstract class PhysicsComponent : MonoBehaviour
	{
		private RigidbodyComponent rigidbodyComponent;

		private Coroutine postSimulationCoroutine;

		protected bool ignoreCollisionMessages;

		protected bool wasKinematic;

		public List<HitInfo> HitsBuffer { get; protected set; } = new List<HitInfo>(20);

		public List<Contact> Contacts { get; protected set; } = new List<Contact>(20);

		public List<Trigger> Triggers { get; protected set; } = new List<Trigger>(20);

		public LayerMask CollisionLayerMask { get; protected set; } = 0;

		protected abstract LayerMask GetCollisionLayerMask();

		public abstract void IgnoreCollision(in HitInfo hitInfo, bool ignore);

		public abstract void IgnoreCollision(Transform otherTransform, bool ignore);

		public abstract void IgnoreLayerCollision(int targetLayer, bool ignore);

		public abstract void IgnoreLayerMaskCollision(LayerMask layerMask, bool ignore);

		protected abstract int FilterOverlaps(int overlaps, LayerMask ignoredLayerMask, HitFilterDelegate hitFilter);

		public void ClearContacts()
		{
			Contacts.Clear();
		}

		protected abstract void GetClosestHit(out HitInfo hitInfo, int hits, Vector3 castDisplacement, in HitInfoFilter filter, bool allowOverlaps, HitFilterDelegate hitFilter);

		protected abstract List<HitInfo> GetAllHits(int hits, Vector3 castDisplacement, in HitInfoFilter filter, bool allowOverlaps, HitFilterDelegate hitFilter);

		protected abstract int InternalRaycast(Vector3 origin, Vector3 castDisplacement, int layerMask, bool ignoreTriggers, bool allowOverlaps);

		protected abstract int InternalSphereCast(Vector3 center, float radius, Vector3 castDisplacement, int layerMask, bool ignoreTriggers, bool allowOverlaps);

		protected abstract int InternalCapsuleCast(Vector3 bottom, Vector3 top, float radius, Vector3 castDisplacement, int layerMask, bool ignoreTriggers, bool allowOverlaps);

		protected abstract int InternalBoxCast(Vector3 center, Vector3 size, Vector3 castDisplacement, Quaternion orientation, int layerMask, bool ignoreTriggers, bool allowOverlaps);

		protected abstract int InternalOverlapSphere(Vector3 center, float radius, int layerMask, bool ignoreTriggers);

		protected abstract int InternalOverlapCapsule(Vector3 bottom, Vector3 top, float radius, int layerMask, bool ignoreTriggers);

		protected abstract int InternalOverlapBox(Vector3 center, Vector3 size, Quaternion orientation, int layerMask, bool ignoreTriggers);

		public abstract bool CheckCollisionsWith(GameObject gameObject);

		public int Raycast(out HitInfo hitInfo, Vector3 origin, Vector3 castDisplacement, in HitInfoFilter filter, bool allowOverlaps = false, HitFilterDelegate hitFilter = null)
		{
			int num = InternalRaycast(origin, castDisplacement, filter.collisionLayerMask, filter.ignoreTriggers, allowOverlaps);
			if (num != 0)
			{
				GetClosestHit(out hitInfo, num, castDisplacement, in filter, allowOverlaps, hitFilter);
			}
			else
			{
				hitInfo = default(HitInfo);
			}
			return num;
		}

		public List<HitInfo> Raycast(Vector3 origin, Vector3 castDisplacement, in HitInfoFilter filter, bool allowOverlaps = false, HitFilterDelegate hitFilter = null)
		{
			int num = InternalRaycast(origin, castDisplacement, filter.collisionLayerMask, filter.ignoreTriggers, allowOverlaps);
			if (num != 0)
			{
				return GetAllHits(num, castDisplacement, in filter, allowOverlaps, hitFilter);
			}
			return null;
		}

		public int SphereCast(out HitInfo hitInfo, Vector3 center, float radius, Vector3 castDisplacement, in HitInfoFilter filter, bool allowOverlaps = false, HitFilterDelegate hitFilter = null)
		{
			int num = InternalSphereCast(center, radius, castDisplacement, filter.collisionLayerMask, filter.ignoreTriggers, allowOverlaps);
			if (num != 0)
			{
				GetClosestHit(out hitInfo, num, castDisplacement, in filter, allowOverlaps, hitFilter);
			}
			else
			{
				hitInfo = default(HitInfo);
			}
			return num;
		}

		public List<HitInfo> SphereCast(Vector3 center, float radius, Vector3 castDisplacement, in HitInfoFilter filter, bool allowOverlaps = false, HitFilterDelegate hitFilter = null)
		{
			int num = InternalSphereCast(center, radius, castDisplacement, filter.collisionLayerMask, filter.ignoreTriggers, allowOverlaps);
			if (num != 0)
			{
				return GetAllHits(num, castDisplacement, in filter, allowOverlaps, hitFilter);
			}
			return null;
		}

		public int CapsuleCast(out HitInfo hitInfo, Vector3 bottom, Vector3 top, float radius, Vector3 castDisplacement, in HitInfoFilter filter, bool allowOverlaps = false, HitFilterDelegate hitFilter = null)
		{
			int num = InternalCapsuleCast(bottom, top, radius, castDisplacement, filter.collisionLayerMask, filter.ignoreTriggers, allowOverlaps);
			if (num != 0)
			{
				GetClosestHit(out hitInfo, num, castDisplacement, in filter, allowOverlaps, hitFilter);
			}
			else
			{
				hitInfo = default(HitInfo);
			}
			return num;
		}

		public List<HitInfo> CapsuleCast(Vector3 bottom, Vector3 top, float radius, Vector3 castDisplacement, in HitInfoFilter filter, bool allowOverlaps = false, HitFilterDelegate hitFilter = null)
		{
			int num = InternalCapsuleCast(bottom, top, radius, castDisplacement, filter.collisionLayerMask, filter.ignoreTriggers, allowOverlaps);
			if (num != 0)
			{
				return GetAllHits(num, castDisplacement, in filter, allowOverlaps, hitFilter);
			}
			return null;
		}

		public int BoxCast(out HitInfo hitInfo, Vector3 center, Vector3 size, Vector3 castDisplacement, Quaternion orientation, in HitInfoFilter filter, bool allowOverlaps = false, HitFilterDelegate hitFilter = null)
		{
			int num = InternalBoxCast(center, size, castDisplacement, orientation, filter.collisionLayerMask, filter.ignoreTriggers, allowOverlaps);
			if (num != 0)
			{
				GetClosestHit(out hitInfo, num, castDisplacement, in filter, allowOverlaps, hitFilter);
			}
			else
			{
				hitInfo = default(HitInfo);
			}
			return num;
		}

		public List<HitInfo> BoxCast(Vector3 center, Vector3 size, Vector3 castDisplacement, Quaternion orientation, in HitInfoFilter filter, bool allowOverlaps = false, HitFilterDelegate hitFilter = null)
		{
			int num = InternalBoxCast(center, size, castDisplacement, orientation, filter.collisionLayerMask, filter.ignoreTriggers, allowOverlaps);
			if (num != 0)
			{
				return GetAllHits(num, castDisplacement, in filter, allowOverlaps, hitFilter);
			}
			return null;
		}

		public bool OverlapSphere(Vector3 center, float radius, in HitInfoFilter filter, HitFilterDelegate hitFilter = null)
		{
			int overlaps = InternalOverlapSphere(center, radius, filter.collisionLayerMask, filter.ignoreTriggers);
			return FilterOverlaps(overlaps, filter.ignorePhysicsLayerMask, hitFilter) != 0;
		}

		public bool OverlapCapsule(Vector3 bottom, Vector3 top, float radius, in HitInfoFilter filter, HitFilterDelegate hitFilter = null)
		{
			int overlaps = InternalOverlapCapsule(bottom, top, radius, filter.collisionLayerMask, filter.ignoreTriggers);
			return FilterOverlaps(overlaps, filter.ignorePhysicsLayerMask, hitFilter) != 0;
		}

		public bool OverlapBox(Vector3 center, Vector3 size, Quaternion orientation, in HitInfoFilter filter, HitFilterDelegate hitFilter = null)
		{
			int overlaps = InternalOverlapBox(center, size, orientation, filter.collisionLayerMask, filter.ignoreTriggers);
			return FilterOverlaps(overlaps, filter.ignorePhysicsLayerMask, hitFilter) != 0;
		}

		protected virtual void Awake()
		{
			base.hideFlags = HideFlags.None;
			CollisionLayerMask = GetCollisionLayerMask();
		}

		protected virtual void Start()
		{
			rigidbodyComponent = GetComponent<RigidbodyComponent>();
		}

		public static PhysicsComponent CreateInstance(GameObject gameObject)
		{
			Rigidbody2D component = gameObject.GetComponent<Rigidbody2D>();
			Rigidbody component2 = gameObject.GetComponent<Rigidbody>();
			if (component != null)
			{
				return gameObject.GetOrAddComponent<PhysicsComponent2D>();
			}
			if (component2 != null)
			{
				return gameObject.GetOrAddComponent<PhysicsComponent3D>();
			}
			return null;
		}

		private void OnEnable()
		{
			rigidbodyComponent = GetComponent<RigidbodyComponent>();
			if (rigidbodyComponent != null)
			{
				rigidbodyComponent.OnBodyTypeChange += OnBodyTypeChange;
			}
			if (postSimulationCoroutine == null)
			{
				postSimulationCoroutine = StartCoroutine(PostSimulationUpdate());
			}
		}

		private void OnDisable()
		{
			if (rigidbodyComponent != null)
			{
				rigidbodyComponent.OnBodyTypeChange -= OnBodyTypeChange;
			}
			if (postSimulationCoroutine != null)
			{
				StopCoroutine(PostSimulationUpdate());
				postSimulationCoroutine = null;
			}
		}

		private void OnBodyTypeChange()
		{
			ignoreCollisionMessages = true;
		}

		private void FixedUpdate()
		{
			for (int num = Triggers.Count - 1; num >= 0; num--)
			{
				if (Triggers[num].gameObject == null)
				{
					Triggers.RemoveAt(num);
				}
			}
		}

		private IEnumerator PostSimulationUpdate()
		{
			YieldInstruction waitForFixedUpdate = new WaitForFixedUpdate();
			while (true)
			{
				yield return waitForFixedUpdate;
				ignoreCollisionMessages = false;
			}
		}
	}
}
