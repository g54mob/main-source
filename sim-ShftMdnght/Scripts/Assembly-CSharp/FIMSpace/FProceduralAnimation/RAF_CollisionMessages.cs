using FIMSpace.FGenerating;
using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	public class RAF_CollisionMessages : RagdollAnimatorFeatureCollisions
	{
		private GameObject receiver;

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
					receiver = transform.gameObject;
				}
			}
			if (receiver == null)
			{
				Debug.Log("[Ragdoll Animator 2] Collision Messages Feature: Not assigned collision messages receiver! (" + base.InitializedWith.ParentRagdollHandler.BaseTransform.name + ")\nRemoving feature from the controller.");
				return false;
			}
			ignoreSelf = base.InitializedWith.RequestVariable("Ignore Self Limbs:", true);
			return true;
		}

		public override void OnCollisionEnterAction(RA2BoneCollisionHandler hitted, Collision collision)
		{
			if (base.Helper.Enabled && (!ignoreSelf.GetBool() || !base.ParentRagdollHandler.ContainsAnimatorBoneTransform(collision.transform)))
			{
				receiver.SendMessage("RagdollAnimator2BoneCollision", hitted);
			}
		}
	}
}
