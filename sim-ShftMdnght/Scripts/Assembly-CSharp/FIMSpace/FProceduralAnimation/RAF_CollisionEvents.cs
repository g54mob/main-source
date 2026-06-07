using FIMSpace.FGenerating;
using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	public class RAF_CollisionEvents : RagdollAnimatorFeatureCollisions
	{
		private IRagdollAnimator2Receiver receiver;

		private FUniversalVariable ignoreSelf;

		private bool collectCollisions;

		public override bool EnableCollectCollision => collectCollisions;

		public override bool OnInit()
		{
			collectCollisions = base.InitializedWith.RequestVariable("Collect Collisions:", false).GetBool();
			base.OnInit();
			FUniversalVariable fUniversalVariable = base.InitializedWith.RequestVariable("Receiver", null);
			if (fUniversalVariable.GetUnityObject() is Transform)
			{
				Transform transform = fUniversalVariable.GetUnityObject() as Transform;
				if ((bool)transform)
				{
					receiver = transform.gameObject.GetComponent<IRagdollAnimator2Receiver>();
				}
			}
			if (receiver == null)
			{
				Debug.Log("[Ragdoll Animator 2] Collision Events Feature: Not assigned collision events receiver! (" + base.InitializedWith.ParentRagdollHandler.BaseTransform.name + ")\nRemoving feature from the controller.");
				return false;
			}
			ignoreSelf = base.InitializedWith.RequestVariable("Ignore Self Limbs:", true);
			return true;
		}

		public override void OnCollisionEnterAction(RA2BoneCollisionHandler hitted, Collision collision)
		{
			if (base.Helper.Enabled && (!ignoreSelf.GetBool() || !base.ParentRagdollHandler.ContainsBoneTransform(collision.transform)))
			{
				receiver.RagdollAnimator2_OnCollisionEnterEvent(hitted, collision);
			}
		}
	}
}
