using System;
using System.Collections.Generic;
using UnityEngine;

namespace Lightbug.Utilities
{
	public sealed class PhysicsComponent2D : PhysicsComponent
	{
		private readonly ContactPoint2D[] _contactsBuffer = new ContactPoint2D[10];

		private readonly RaycastHit2D[] _hitsBuffer = new RaycastHit2D[10];

		private readonly Collider2D[] _overlapsBuffer = new Collider2D[10];

		private ContactFilter2D _contactFilter;

		public Rigidbody2D Rigidbody { get; private set; }

		public Collider2D Collider { get; private set; }

		protected override void Awake()
		{
			base.Awake();
			Collider = GetComponent<Collider2D>();
			_contactFilter = default(ContactFilter2D).NoFilter();
			_contactFilter.useLayerMask = true;
		}

		protected override void Start()
		{
			base.Start();
			Rigidbody = GetComponent<Rigidbody2D>();
		}

		private void OnTriggerStay2D(Collider2D other)
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

		private void OnTriggerExit2D(Collider2D other)
		{
			if (ignoreCollisionMessages)
			{
				return;
			}
			for (int num = base.Triggers.Count - 1; num >= 0; num--)
			{
				if (base.Triggers[num].collider2D == other)
				{
					base.Triggers.RemoveAt(num);
					break;
				}
			}
		}

		private void OnCollisionEnter2D(Collision2D collision)
		{
			if (!ignoreCollisionMessages)
			{
				int contacts = collision.GetContacts(_contactsBuffer);
				for (int i = 0; i < contacts; i++)
				{
					ContactPoint2D contact = _contactsBuffer[i];
					Contact item = new Contact(firstContact: true, contact, collision);
					base.Contacts.Add(item);
				}
			}
		}

		private void OnCollisionStay2D(Collision2D collision)
		{
			if (!ignoreCollisionMessages)
			{
				int contacts = collision.GetContacts(_contactsBuffer);
				for (int i = 0; i < contacts; i++)
				{
					ContactPoint2D contact = _contactsBuffer[i];
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
				if (!Physics2D.GetIgnoreLayerCollision(i, layer))
				{
					result.value |= 1 << i;
				}
			}
			return result;
		}

		public override void IgnoreCollision(in HitInfo hitInfo, bool ignore)
		{
			if (!(hitInfo.collider2D == null))
			{
				Physics2D.IgnoreCollision(Collider, hitInfo.collider2D, ignore);
			}
		}

		public override void IgnoreCollision(Transform otherTransform, bool ignore)
		{
			if (!(otherTransform == null) && otherTransform.TryGetComponent<Collider2D>(out var component))
			{
				Physics2D.IgnoreCollision(Collider, component, ignore);
			}
		}

		public void IgnoreCollision(Collider2D collider, bool ignore)
		{
			if (!(collider == null))
			{
				Physics2D.IgnoreCollision(Collider, collider, ignore);
			}
		}

		[Obsolete]
		public void IgnoreCollision(Collider2D collider, bool ignore, int layerMask)
		{
			if (!(collider == null) && CustomUtilities.BelongsToLayerMask(collider.gameObject.layer, layerMask))
			{
				Physics2D.IgnoreCollision(Collider, collider, ignore);
			}
		}

		public override void IgnoreLayerCollision(int targetLayer, bool ignore)
		{
			Physics2D.IgnoreLayerCollision(base.gameObject.layer, targetLayer, ignore);
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
			bool queriesHitTriggers = Physics2D.queriesHitTriggers;
			bool queriesStartInColliders = Physics2D.queriesStartInColliders;
			Physics2D.queriesHitTriggers = !ignoreTriggers;
			Physics2D.queriesStartInColliders = true;
			int result = Physics2D.RaycastNonAlloc(origin, Vector3.Normalize(castDisplacement), _hitsBuffer, castDisplacement.magnitude, layerMask);
			Physics2D.queriesHitTriggers = queriesHitTriggers;
			Physics2D.queriesStartInColliders = queriesStartInColliders;
			return result;
		}

		protected override int InternalSphereCast(Vector3 center, float radius, Vector3 castDisplacement, int layerMask, bool ignoreTriggers, bool allowOverlaps)
		{
			bool queriesHitTriggers = Physics2D.queriesHitTriggers;
			bool queriesStartInColliders = Physics2D.queriesStartInColliders;
			Physics2D.queriesHitTriggers = !ignoreTriggers;
			Physics2D.queriesStartInColliders = true;
			_contactFilter.layerMask = layerMask;
			int result = Physics2D.CircleCast(center, radius, Vector3.Normalize(castDisplacement), _contactFilter, _hitsBuffer, castDisplacement.magnitude);
			Physics2D.queriesHitTriggers = queriesHitTriggers;
			Physics2D.queriesStartInColliders = queriesStartInColliders;
			return result;
		}

		protected override int InternalCapsuleCast(Vector3 bottom, Vector3 top, float radius, Vector3 castDisplacement, int layerMask, bool ignoreTriggers, bool allowOverlaps)
		{
			Vector3 vector = top - bottom;
			Vector3 vector2 = bottom + CustomUtilities.Multiply(vector, 0.5f);
			Vector2 size = default(Vector2);
			size.x = 2f * radius;
			size.y = vector.magnitude + size.x;
			float angle = Vector2.SignedAngle(vector, Vector2.up);
			bool queriesHitTriggers = Physics2D.queriesHitTriggers;
			bool queriesStartInColliders = Physics2D.queriesStartInColliders;
			Physics2D.queriesHitTriggers = !ignoreTriggers;
			Physics2D.queriesStartInColliders = true;
			_contactFilter.layerMask = layerMask;
			int result = Physics2D.CapsuleCast(vector2, size, CapsuleDirection2D.Vertical, angle, Vector3.Normalize(castDisplacement), _contactFilter, _hitsBuffer, castDisplacement.magnitude);
			Physics2D.queriesHitTriggers = queriesHitTriggers;
			Physics2D.queriesStartInColliders = queriesStartInColliders;
			return result;
		}

		protected override int InternalBoxCast(Vector3 center, Vector3 size, Vector3 castDisplacement, Quaternion orientation, int layerMask, bool ignoreTriggers, bool allowOverlaps)
		{
			bool queriesHitTriggers = Physics2D.queriesHitTriggers;
			bool queriesStartInColliders = Physics2D.queriesStartInColliders;
			Physics2D.queriesHitTriggers = !ignoreTriggers;
			Physics2D.queriesStartInColliders = true;
			_contactFilter.layerMask = layerMask;
			int result = Physics2D.BoxCast(center, size, orientation.eulerAngles.z, Vector3.Normalize(castDisplacement), _contactFilter, _hitsBuffer, castDisplacement.magnitude);
			Physics2D.queriesHitTriggers = queriesHitTriggers;
			Physics2D.queriesStartInColliders = queriesStartInColliders;
			return result;
		}

		protected override int InternalOverlapSphere(Vector3 center, float radius, int layerMask, bool ignoreTriggers)
		{
			bool queriesHitTriggers = Physics2D.queriesHitTriggers;
			bool queriesStartInColliders = Physics2D.queriesStartInColliders;
			Physics2D.queriesHitTriggers = !ignoreTriggers;
			Physics2D.queriesStartInColliders = true;
			_contactFilter.layerMask = layerMask;
			int result = Physics2D.OverlapCircle(center, radius, _contactFilter, _overlapsBuffer);
			Physics2D.queriesHitTriggers = queriesHitTriggers;
			Physics2D.queriesStartInColliders = queriesStartInColliders;
			return result;
		}

		protected override int InternalOverlapCapsule(Vector3 bottom, Vector3 top, float radius, int layerMask, bool ignoreTriggers)
		{
			Vector3 vector = top - bottom;
			Vector3 vector2 = bottom + 0.5f * vector;
			Vector2 size = new Vector2(2f * radius, vector.magnitude + 2f * radius);
			float angle = Vector2.SignedAngle(vector, Vector2.up);
			bool queriesHitTriggers = Physics2D.queriesHitTriggers;
			bool queriesStartInColliders = Physics2D.queriesStartInColliders;
			Physics2D.queriesHitTriggers = !ignoreTriggers;
			Physics2D.queriesStartInColliders = true;
			_contactFilter.layerMask = layerMask;
			int result = Physics2D.OverlapCapsule(vector2, size, CapsuleDirection2D.Vertical, angle, _contactFilter, _overlapsBuffer);
			Physics2D.queriesHitTriggers = queriesHitTriggers;
			Physics2D.queriesStartInColliders = queriesStartInColliders;
			return result;
		}

		protected override int InternalOverlapBox(Vector3 center, Vector3 size, Quaternion orientation, int layerMask, bool ignoreTriggers)
		{
			bool queriesHitTriggers = Physics2D.queriesHitTriggers;
			bool queriesStartInColliders = Physics2D.queriesStartInColliders;
			Physics2D.queriesHitTriggers = !ignoreTriggers;
			Physics2D.queriesStartInColliders = true;
			float z = orientation.eulerAngles.z;
			_contactFilter.layerMask = layerMask;
			int result = Physics2D.OverlapBox(center, size, z, _contactFilter, _overlapsBuffer);
			Physics2D.queriesHitTriggers = queriesHitTriggers;
			Physics2D.queriesStartInColliders = queriesStartInColliders;
			return result;
		}

		protected override int FilterOverlaps(int overlaps, LayerMask ignoredLayerMask, HitFilterDelegate hitFilter)
		{
			int num = overlaps;
			for (int i = 0; i < overlaps; i++)
			{
				Collider2D collider2D = _overlapsBuffer[i];
				if (collider2D.transform.IsChildOf(base.transform))
				{
					num--;
				}
				else if (hitFilter != null && !hitFilter(collider2D.transform))
				{
					num--;
				}
				else if (CustomUtilities.BelongsToLayerMask(collider2D.gameObject.layer, ignoredLayerMask))
				{
					IgnoreCollision(collider2D, ignore: true);
				}
			}
			return num;
		}

		protected override void GetClosestHit(out HitInfo hitInfo, int hits, Vector3 castDisplacement, in HitInfoFilter filter, bool allowOverlaps, HitFilterDelegate hitFilter)
		{
			RaycastHit2D raycastHit = new RaycastHit2D
			{
				distance = float.PositiveInfinity
			};
			bool flag = false;
			base.HitsBuffer.Clear();
			for (int i = 0; i < hits; i++)
			{
				RaycastHit2D raycastHit2 = _hitsBuffer[i];
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
				RaycastHit2D raycastHit = _hitsBuffer[i];
				if (PerformHitCheck(ref raycastHit, in filter, allowOverlaps, hitFilter))
				{
					HitInfo item = new HitInfo(ref raycastHit, Vector3.Normalize(castDisplacement));
					base.HitsBuffer.Add(item);
				}
			}
			return base.HitsBuffer;
		}

		private bool PerformHitCheck(ref RaycastHit2D raycastHit, in HitInfoFilter filter, bool allowOverlaps, HitFilterDelegate hitFilter)
		{
			float distance = raycastHit.distance;
			Collider2D collider = raycastHit.collider;
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
			if (!gameObject.TryGetComponent<Collider2D>(out var component))
			{
				return false;
			}
			return !Physics2D.GetIgnoreCollision(Collider, component);
		}
	}
}
