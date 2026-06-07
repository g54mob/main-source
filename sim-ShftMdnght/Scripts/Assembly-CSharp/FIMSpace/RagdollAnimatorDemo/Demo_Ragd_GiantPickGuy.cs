using FIMSpace.FProceduralAnimation;
using UnityEngine;

namespace FIMSpace.RagdollAnimatorDemo
{
	public class Demo_Ragd_GiantPickGuy : FimpossibleComponent
	{
		public RagdollAnimator2 GiantRagdoll;

		public RagdollAnimator2 ToCatch;

		private GameObject catchObject;

		public void Pick()
		{
			ToCatch.SendMessage("Catched");
			RagdollChainBone ragdollChainBone = ToCatch.User_GetBoneSetupByHumanoidBone(HumanBodyBones.Head);
			RagdollChainBone ragdollChainBone2 = GiantRagdoll.User_GetBoneSetupByHumanoidBone(HumanBodyBones.RightHand);
			catchObject = new GameObject("Generated Catch Joints");
			catchObject.transform.position = ragdollChainBone.PhysicalDummyBone.position;
			catchObject.transform.rotation = ragdollChainBone.PhysicalDummyBone.rotation;
			catchObject.AddComponent<Rigidbody>();
			ConfigurableJoint configurableJoint = catchObject.AddComponent<ConfigurableJoint>();
			configurableJoint.connectedBody = ragdollChainBone2.GameRigidbody;
			RagdollHandler.SetConfigurableJointMotionLock(configurableJoint, ConfigurableJointMotion.Locked);
			configurableJoint.autoConfigureConnectedAnchor = false;
			configurableJoint.connectedAnchor = ragdollChainBone2.GameRigidbody.transform.InverseTransformPoint(ragdollChainBone.SourceBone.position);
			ConfigurableJoint configurableJoint2 = catchObject.AddComponent<ConfigurableJoint>();
			configurableJoint2.connectedBody = ragdollChainBone.GameRigidbody;
			RagdollHandler.SetConfigurableJointMotionLock(configurableJoint2, ConfigurableJointMotion.Locked);
		}

		public void Throw()
		{
			Object.Destroy(catchObject);
			ToCatch.SendMessage("Throw");
		}
	}
}
