using System.Collections.Generic;
using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	[AddComponentMenu("", 0)]
	public class RA2BoneTriggerCollisionHandler : RA2BoneCollisionHandlerBase
	{
		private bool CollectCollisions;

		public List<Collider> EnteredColliders { get; private set; }

		public List<Collider> EnteredSelfColliders { get; private set; }

		public Collider LatestEnterCollider { get; private set; }

		public Collider LatestEnterNonSelfCollider { get; private set; }

		public Collider LatestExitCollider { get; private set; }

		public override void EnableSavingEnteredCollisionsList()
		{
			if (EnteredColliders == null)
			{
				EnteredColliders = new List<Collider>();
			}
			if (EnteredSelfColliders == null)
			{
				EnteredSelfColliders = new List<Collider>();
			}
			CollectCollisions = true;
		}

		public override RagdollAnimator2BoneIndicator Initialize(RagdollHandler handler, RagdollBoneProcessor boneProcessor, RagdollBonesChain parentChain, bool isAnimatorBone = false, RA2AttachableObject attachable = null)
		{
			LatestEnterCollider = null;
			LatestExitCollider = null;
			return base.Initialize(handler, boneProcessor, parentChain, isAnimatorBone, attachable);
		}

		private void OnTriggerEnter(Collider collider)
		{
			if (Ignores.Contains(collider.transform))
			{
				return;
			}
			LatestEnterCollider = collider;
			if (CollectCollisions)
			{
				if (base.ParentRagdollProcessor.ContainsBoneTransform(collider.transform))
				{
					if (!EnteredSelfColliders.Contains(collider))
					{
						EnteredSelfColliders.Add(collider);
					}
				}
				else if (!EnteredColliders.Contains(collider))
				{
					EnteredColliders.Add(collider);
				}
				if (UseSelfCollisions)
				{
					if (EnteredColliders.Count > 0 || EnteredSelfColliders.Count > 0)
					{
						Colliding = true;
					}
				}
				else if (EnteredColliders.Count > 0)
				{
					Colliding = true;
				}
			}
			base.ParentHandler.OnTriggerEnterEvent(this, collider);
		}

		private void OnTriggerExit(Collider collider)
		{
			LatestExitCollider = collider;
			if (!CollectCollisions)
			{
				return;
			}
			if (base.ParentRagdollProcessor.ContainsBoneTransform(collider.transform))
			{
				if (EnteredSelfColliders.Contains(collider))
				{
					EnteredSelfColliders.Remove(collider);
				}
			}
			else if (EnteredColliders.Contains(collider))
			{
				EnteredColliders.Remove(collider);
			}
			if (UseSelfCollisions)
			{
				if (EnteredColliders.Count == 0 && EnteredSelfColliders.Count == 0)
				{
					Colliding = false;
				}
			}
			else if (EnteredColliders.Count == 0)
			{
				Colliding = false;
			}
		}

		public override bool IsCollidingWith(Collider collider)
		{
			if (EnteredColliders == null)
			{
				if (!Colliding)
				{
					return false;
				}
				if (LatestEnterCollider != null && LatestEnterCollider.GetComponent<Collider>() == collider)
				{
					return true;
				}
				return false;
			}
			if (LatestEnterNonSelfCollider.GetComponent<Collider>() == collider)
			{
				return true;
			}
			foreach (Collider enteredCollider in EnteredColliders)
			{
				if (enteredCollider == collider)
				{
					return true;
				}
			}
			return false;
		}

		public override bool CollidesWithAnything()
		{
			return Colliding;
		}

		public override Collider GetFirstCollidingCollider()
		{
			if (EnteredColliders == null)
			{
				return null;
			}
			if (EnteredColliders.Count > 0)
			{
				return EnteredColliders[0];
			}
			return null;
		}
	}
}
