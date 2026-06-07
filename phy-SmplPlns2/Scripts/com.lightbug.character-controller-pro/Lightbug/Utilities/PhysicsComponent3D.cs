using System;
using System.Collections.Generic;
using UnityEngine;

namespace Lightbug.Utilities
{
	public sealed class PhysicsComponent3D : PhysicsComponent
	{
		private readonly ContactPoint[] _contactsBuffer = new ContactPoint[10];

		private readonly RaycastHit[] _hitsBuffer = new RaycastHit[10];

		private readonly Collider[] _overlapsBuffer = new Collider[10];

		public Rigidbody Rigidbody { get; private set; }

		public Collider Collider { get; private set; }

		protected override void Awake()
		{
			base.Awake();
			Collider = GetComponent<Collider>();
		}

		protected override void Start()
		{
			base.Start();
			Rigidbody = GetComponent<Rigidbody>();
		}

		private void OnTriggerStay(Collider other)
		{
			if (ignoreCollisionMessages || !other.isTrigger)
			{
				return;
			}
			bool flag = false;
			float fixedTime = Time.fixedTime;
			for (int i = 0; i < base.Triggers.Count; i++)
			{
				if (flag)
				{
					break;
				}
				if (!(base.Triggers[i] != other))
				{
					flag = true;
					Trigger value = base.Triggers[i];
					value.Update(fixedTime);
					base.Triggers[i] = value;
				}
			}
			if (!flag)
			{
				base.Triggers.Add(new Trigger(other, Time.fixedTime));
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (ignoreCollisionMessages)
			{
				return;
			}
			for (int num = base.Triggers.Count - 1; num >= 0; num--)
			{
				if (base.Triggers[num].collider3D == other)
				{
					base.Triggers.RemoveAt(num);
					break;
				}
			}
		}

		private void OnCollisionEnter(Collision collision)
		{
			if (!ignoreCollisionMessages)
			{
				int contacts = collision.GetContacts(_contactsBuffer);
				for (int i = 0; i < contacts; i++)
				{
					ContactPoint contact = _contactsBuffer[i];
					Contact item = new Contact(firstContact: true, contact, collision);
					base.Contacts.Add(item);
				}
			}
		}

		private void OnCollisionStay(Collision collision)
		{
			if (!ignoreCollisionMessages)
			{
				int contacts = collision.GetContacts(_contactsBuffer);
				for (int i = 0; i < contacts; i++)
				{
					ContactPoint contact = _contactsBuffer[i];
					Contact item = new Contact(firstContact: false, contact, collision);
					base.Contacts.Add(item);
				}
			}
		}

		protected override LayerMask GetCollisionLayerMask()
		{
			int layer = base.gameObject.layer;
			LayerMask result = 0;
			for (int i = 0; i < 32; i++)
			{
				if (!Physics.GetIgnoreLayerCollision(i, layer))
				{
					result.value |= 1 << i;
				}
			}
			return result;
		}

		public override void IgnoreCollision(in HitInfo hitInfo, bool ignore)
		{
			if (!(hitInfo.collider3D == null))
			{
				Physics.IgnoreCollision(Collider, hitInfo.collider3D, ignore);
			}
		}

		public override void IgnoreCollision(Transform otherTransform, bool ignore)
		{
			if (!(otherTransform == null) && otherTransform.TryGetComponent<Collider>(out var component))
			{
				Physics.IgnoreCollision(Collider, component, ignore);
			}
		}

		public void IgnoreCollision(Collider collider, bool ignore)
		{
			if (!(collider == null))
			{
				Physics.IgnoreCollision(Collider, collider, ignore);
			}
		}

		[Obsolete]
		public void IgnoreCollision(Collider collider, bool ignore, int layerMask)
		{
			if (!(collider == null) && CustomUtilities.BelongsToLayerMask(collider.gameObject.layer, layerMask))
			{
				Physics.IgnoreCollision(Collider, collider, ignore);
			}
		}

		public override void IgnoreLayerCollision(int targetLayer, bool ignore)
		{
			Physics.IgnoreLayerCollision(base.gameObject.layer, targetLayer, ignore);
			if (ignore)
			{
				base.CollisionLayerMask = (int)base.CollisionLayerMask & ~(1 << targetLayer);
			}
			else
			{
				base.CollisionLayerMask = (int)base.CollisionLayerMask | (1 << targetLayer);
			}
		}

		public override void IgnoreLayerMaskCollision(LayerMask layerMask, bool ignore)
		{
			int value = layerMask.value;
			int num = 1;
			for (int i = 0; i < 32; i++)
			{
				if ((value & num) > 0)
				{
					IgnoreLayerCollision(i, ignore);
				}
				num <<= 1;
			}
			if (ignore)
			{
				base.CollisionLayerMask = (int)base.CollisionLayerMask & ~layerMask.value;
			}
			else
			{
				base.CollisionLayerMask = (int)base.CollisionLayerMask | layerMask.value;
			}
		}

		protected override int InternalRaycast(Vector3 origin, Vector3 castDisplacement, int layerMask, bool ignoreTriggers, bool allowOverlaps)
		{
			return Physics.RaycastNonAlloc(origin, Vector3.Normalize(castDisplacement), _hitsBuffer, castDisplacement.magnitude, layerMask, ignoreTriggers ? QueryTriggerInteraction.Ignore : QueryTriggerInteraction.Collide);
		}

		protected override int InternalSphereCast(Vector3 center, float radius, Vector3 castDisplacement, int layerMask, bool ignoreTriggers, bool allowOverlaps)
		{
			return Physics.SphereCastNonAlloc(center, radius, Vector3.Normalize(castDisplacement), _hitsBuffer, castDisplacement.magnitude, layerMask, ignoreTriggers ? QueryTriggerInteraction.Ignore : QueryTriggerInteraction.Collide);
		}

		protected override int InternalCapsuleCast(Vector3 bottom, Vector3 top, float radius, Vector3 castDisplacement, int layerMask, bool ignoreTriggers, bool allowOverlaps)
		{
			return Physics.CapsuleCastNonAlloc(bottom, top, radius, Vector3.Normalize(castDisplacement), _hitsBuffer, castDisplacement.magnitude, layerMask, ignoreTriggers ? QueryTriggerInteraction.Ignore : QueryTriggerInteraction.Collide);
		}

		protected override int InternalBoxCast(Vector3 center, Vector3 size, Vector3 castDisplacement, Quaternion orientation, int layerMask, bool ignoreTriggers, bool allowOverlaps)
		{
			return Physics.BoxCastNonAlloc(center, size / 2f, Vector3.Normalize(castDisplacement), _hitsBuffer, orientation, castDisplacement.magnitude, layerMask, ignoreTriggers ? QueryTriggerInteraction.Ignore : QueryTriggerInteraction.Collide);
		}

		protected override int InternalOverlapSphere(Vector3 center, float radius, int layerMask, bool ignoreTriggers)
		{
			return Physics.OverlapSphereNonAlloc(center, radius, _overlapsBuffer, layerMask, ignoreTriggers ? QueryTriggerInteraction.Ignore : QueryTriggerInteraction.Collide);
		}

		protected override int InternalOverlapCapsule(Vector3 bottom, Vector3 top, float radius, int layerMask, bool ignoreTriggers)
		{
			return Physics.OverlapCapsuleNonAlloc(bottom, top, radius, _overlapsBuffer, layerMask, ignoreTriggers ? QueryTriggerInteraction.Ignore : QueryTriggerInteraction.Collide);
		}

		protected override int InternalOverlapBox(Vector3 center, Vector3 size, Quaternion orientation, int layerMask, bool ignoreTriggers)
		{
			return Physics.OverlapBoxNonAlloc(center, size / 2f, _overlapsBuffer, orientation, layerMask, ignoreTriggers ? QueryTriggerInteraction.Ignore : QueryTriggerInteraction.Collide);
		}

		protected override int FilterOverlaps(int overlaps, LayerMask ignoredLayerMask, HitFilterDelegate hitFilter)
		{
			int num = overlaps;
			for (int i = 0; i < overlaps; i++)
			{
				Collider collider = _overlapsBuffer[i];
				if (collider.transform.IsChildOf(base.transform))
				{
					num--;
				}
				else if (hitFilter != null && !hitFilter(collider.transform))
				{
					num--;
				}
				else if (CustomUtilities.BelongsToLayerMask(collider.gameObject.layer, ignoredLayerMask))
				{
					IgnoreCollision(collider, ignore: true);
				}
			}
			return num;
		}

		protected override void GetClosestHit(out HitInfo hitInfo, int hits, Vector3 castDisplacement, in HitInfoFilter filter, bool allowOverlaps, HitFilterDelegate hitFilter)
		{
			RaycastHit raycastHit = new RaycastHit
			{
				distance = float.PositiveInfinity
			};
			bool flag = false;
			base.HitsBuffer.Clear();
			for (int i = 0; i < hits; i++)
			{
				RaycastHit raycastHit2 = _hitsBuffer[i];
				if (PerformHitCheck(ref raycastHit2, in filter, allowOverlaps, hitFilter))
				{
					flag = true;
					HitInfo item = new HitInfo(ref raycastHit2, Vector3.Normalize(castDisplacement));
					base.HitsBuffer.Add(item);
					if (raycastHit2.distance < raycastHit.distance)
					{
						raycastHit = raycastHit2;
					}
				}
			}
			if (flag)
			{
				hitInfo = new HitInfo(ref raycastHit, Vector3.Normalize(castDisplacement));
			}
			else
			{
				hitInfo = default(HitInfo);
			}
		}

		protected override List<HitInfo> GetAllHits(int hits, Vector3 castDisplacement, in HitInfoFilter filter, bool allowOverlaps, HitFilterDelegate hitFilter)
		{
			base.HitsBuffer.Clear();
			for (int i = 0; i < hits; i++)
			{
				RaycastHit raycastHit = _hitsBuffer[i];
				if (PerformHitCheck(ref raycastHit, in filter, allowOverlaps, hitFilter))
				{
					HitInfo item = new HitInfo(ref raycastHit, Vector3.Normalize(castDisplacement));
					base.HitsBuffer.Add(item);
				}
			}
			return base.HitsBuffer;
		}

		private bool PerformHitCheck(ref RaycastHit raycastHit, in HitInfoFilter filter, bool allowOverlaps, HitFilterDelegate hitFilter)
		{
			float distance = raycastHit.distance;
			Collider collider = raycastHit.collider;
			if (collider.transform.IsChildOf(base.transform))
			{
				return false;
			}
			if (hitFilter != null && !hitFilter(collider.transform))
			{
				return false;
			}
			if (!allowOverlaps && distance == 0f)
			{
				return false;
			}
			if (distance < filter.minimumDistance || distance > filter.maximumDistance)
			{
				return false;
			}
			if (filter.ignoreRigidbodies && collider.attachedRigidbody != null)
			{
				return false;
			}
			return true;
		}

		public override bool CheckCollisionsWith(GameObject gameObject)
		{
			if (!gameObject.TryGetComponent<Collider>(out var component))
			{
				return false;
			}
			return !Physics.GetIgnoreCollision(Collider, component);
		}
	}
}
