using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	[AddComponentMenu("", 0)]
	public class RA2BoneCollisionHandler : RA2BoneCollisionHandlerBase
	{
		public struct CollisionCapture
		{
			public int Enters;

			public Transform Entered;

			public Collision Lastest;
		}

		private bool CollectCollisions;

		public Dictionary<Transform, CollisionCapture> EnteredCollisions { get; private set; }

		public Dictionary<Transform, CollisionCapture> EnteredSelfCollisions { get; private set; }

		public Collision LatestEnterCollision { get; private set; }

		public Collision LatestEnterNonSelfCollision { get; private set; }

		public Collision LatestExitCollision { get; private set; }

		public override void EnableSavingEnteredCollisionsList()
		{
			if (EnteredCollisions == null)
			{
				EnteredCollisions = new Dictionary<Transform, CollisionCapture>();
			}
			if (EnteredSelfCollisions == null)
			{
				EnteredSelfCollisions = new Dictionary<Transform, CollisionCapture>();
			}
			CollectCollisions = true;
		}

		public override RagdollAnimator2BoneIndicator Initialize(RagdollHandler handler, RagdollBoneProcessor boneProcessor, RagdollBonesChain parentChain, bool isAnimatorBone = false, RA2AttachableObject attachable = null)
		{
			LatestEnterCollision = null;
			LatestExitCollision = null;
			return base.Initialize(handler, boneProcessor, parentChain, isAnimatorBone, attachable);
		}

		public void CleanupCollisions()
		{
			LatestExitCollision = null;
			if (EnteredCollisions != null)
			{
				EnteredCollisions.Clear();
			}
			if (EnteredSelfCollisions != null)
			{
				EnteredSelfCollisions.Clear();
			}
		}

		private void OnCollisionEnter(Collision collision)
		{
			if (Ignores.Contains(collision.transform))
			{
				return;
			}
			LatestEnterCollision = collision;
			if (CollectCollisions)
			{
				CollisionCapture value;
				if (base.ParentRagdollProcessor.ContainsPhysicalBoneTransform(collision.transform))
				{
					if (EnteredSelfCollisions.TryGetValue(collision.transform, out value))
					{
						value.Enters++;
						value.Lastest = collision;
						EnteredSelfCollisions[collision.transform] = value;
					}
					else
					{
						value = new CollisionCapture
						{
							Entered = collision.transform,
							Enters = 1,
							Lastest = collision
						};
						EnteredSelfCollisions.Add(collision.transform, value);
					}
				}
				else
				{
					LatestEnterNonSelfCollision = collision;
					if (EnteredCollisions.TryGetValue(collision.transform, out value))
					{
						value.Enters++;
						value.Lastest = collision;
						EnteredCollisions[collision.transform] = value;
					}
					else
					{
						value = new CollisionCapture
						{
							Entered = collision.transform,
							Enters = 1,
							Lastest = collision
						};
						EnteredCollisions.Add(collision.transform, value);
					}
				}
				Colliding = true;
			}
			base.ParentHandler.OnCollisionEnterEvent(this, collision);
		}

		private void OnCollisionExit(Collision collision)
		{
			LatestExitCollision = collision;
			if (!CollectCollisions)
			{
				return;
			}
			CollisionCapture value;
			if (base.ParentRagdollProcessor.ContainsPhysicalBoneTransform(collision.transform))
			{
				if (EnteredSelfCollisions.TryGetValue(collision.transform, out value))
				{
					value.Enters--;
					value.Lastest = collision;
					if (value.Enters <= 0)
					{
						EnteredSelfCollisions.Remove(collision.transform);
					}
					else
					{
						EnteredSelfCollisions[collision.transform] = value;
					}
				}
			}
			else if (EnteredCollisions.TryGetValue(collision.transform, out value))
			{
				value.Enters--;
				value.Lastest = collision;
				if (value.Enters <= 0)
				{
					EnteredCollisions.Remove(collision.transform);
				}
				else
				{
					EnteredCollisions[collision.transform] = value;
				}
			}
			if (UseSelfCollisions)
			{
				if (EnteredCollisions.Count == 0 && EnteredSelfCollisions.Count == 0)
				{
					Colliding = false;
				}
			}
			else if (EnteredCollisions.Count == 0)
			{
				Colliding = false;
			}
		}

		public override bool IsCollidingWith(Collider collider)
		{
			if (EnteredCollisions == null)
			{
				if (!Colliding)
				{
					return false;
				}
				if (LatestEnterCollision != null && LatestEnterCollision.collider == collider)
				{
					return true;
				}
				return false;
			}
			if (LatestEnterNonSelfCollision.collider == collider)
			{
				return true;
			}
			foreach (KeyValuePair<Transform, CollisionCapture> enteredCollision in EnteredCollisions)
			{
				if (enteredCollision.Value.Lastest.collider == collider)
				{
					return true;
				}
			}
			return false;
		}

		public override bool CollidesWithAnything()
		{
			if (EnteredCollisions == null)
			{
				return false;
			}
			return EnteredCollisions.Count > 0;
		}

		public override Collider GetFirstCollidingCollider()
		{
			if (EnteredCollisions == null)
			{
				return null;
			}
			if (EnteredCollisions.Count > 0)
			{
				KeyValuePair<Transform, CollisionCapture> keyValuePair = EnteredCollisions.FirstOrDefault();
				if (keyValuePair.Value.Lastest != null)
				{
					return keyValuePair.Value.Lastest.collider;
				}
			}
			return null;
		}
	}
}
