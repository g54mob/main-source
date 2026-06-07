using FIMSpace.FProceduralAnimation;
using UnityEngine;

namespace FIMSpace.RagdollAnimatorDemo
{
	[DefaultExecutionOrder(100)]
	public class Demo_Ragd_CatchPropAttackerDefeneder : FimpossibleComponent
	{
		public bool IsDefender;

		public RagdollAnimator2 Self;

		public RagdollAnimator2 Defender;

		public RA2AttachableObject AttachableWeapon;

		public RA2MagnetPoint MagnetDefenderHandHelper;

		private GameObject catchObject;

		private RagdollChainBone defenderHand;

		private ConfigurableJoint catchJoint;

		private bool catched;

		private bool triggerHit;

		private Vector3 catchLocalAttackerHandPos;

		private void LateUpdate()
		{
			if (triggerHit)
			{
				triggerHit = false;
				catched = true;
				Physics.SyncTransforms();
				Self.User_SwitchFallState();
				RagdollChainBone ragdollChainBone = Self.User_GetBoneSetupByHumanoidBone(HumanBodyBones.LeftHand);
				defenderHand = Defender.User_GetBoneSetupByHumanoidBone(HumanBodyBones.RightHand);
				catchObject = new GameObject("Generated Sword Catch Body");
				catchObject.transform.position = ragdollChainBone.GameRigidbody.position;
				catchObject.transform.rotation = ragdollChainBone.GameRigidbody.rotation;
				catchObject.transform.parent = ragdollChainBone.GameRigidbody.transform;
				Rigidbody rigidbody = catchObject.AddComponent<Rigidbody>();
				catchJoint = ragdollChainBone.GameRigidbody.transform.gameObject.AddComponent<ConfigurableJoint>();
				RagdollHandler.SetConfigurableJointMotionLock(catchJoint, ConfigurableJointMotion.Locked);
				RagdollHandler.SetConfigurableJointAngularMotionLock(catchJoint, ConfigurableJointMotion.Locked);
				catchJoint.connectedBody = rigidbody;
				catchJoint.autoConfigureConnectedAnchor = false;
				MagnetDefenderHandHelper.ToMove = rigidbody.transform;
				MagnetDefenderHandHelper.transform.rotation = ragdollChainBone.BoneProcessor.AnimatorRotation;
				MagnetDefenderHandHelper.transform.position = defenderHand.BoneProcessor.AnimatorPosition;
				bool flag = AttachableWeapon.AttachableColliders[0].enabled;
				AttachableWeapon.AttachableColliders[0].enabled = true;
				Vector3 position = AttachableWeapon.AttachableColliders[0].ClosestPoint(defenderHand.BoneProcessor.AnimatorPosition);
				AttachableWeapon.AttachableColliders[0].enabled = flag;
				catchLocalAttackerHandPos = ragdollChainBone.SourceBone.InverseTransformPoint(position);
				if (MagnetDefenderHandHelper.OriginOffset == Vector3.zero)
				{
					MagnetDefenderHandHelper.OriginOffset = -catchLocalAttackerHandPos;
				}
				MagnetDefenderHandHelper.transform.position = defenderHand.BoneProcessor.AnimatorPosition;
				MagnetDefenderHandHelper.transform.rotation = defenderHand.BoneProcessor.AnimatorRotation;
				Defender.Handler.IgnoreCollisionWith(AttachableWeapon.GeneratedPhysicsColliders);
				MagnetDefenderHandHelper.enabled = true;
			}
			if (catched)
			{
				MagnetDefenderHandHelper.transform.position = defenderHand.SourceBone.position;
				MagnetDefenderHandHelper.transform.rotation = defenderHand.SourceBone.rotation;
			}
		}

		public void Hit()
		{
			triggerHit = true;
		}

		public void Throw()
		{
			if (IsDefender)
			{
				Self.GetComponent<Demo_Ragd_CatchPropAttackerDefeneder>().Throw();
				return;
			}
			Object.Destroy(catchJoint);
			Object.Destroy(catchObject);
			MagnetDefenderHandHelper.enabled = false;
			Self.User_AddAllBonesImpact((Defender.GetBaseTransform.forward + Vector3.up * 0.15f) * 1f, 0.1f);
			Defender.Handler.IgnoreCollisionWith(AttachableWeapon.GeneratedPhysicsColliders, ignore: false);
		}
	}
}
